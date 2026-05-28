using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Amkor.CADModules.ManufactureHistory.GrobalConstMFG;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.ManufactureHistory.SubForm
{
	// Token: 0x0200000B RID: 11
	public partial class AdminSetting : BaseWinView
	{
		// Token: 0x0600002E RID: 46 RVA: 0x0000440B File Offset: 0x0000260B
		public AdminSetting(CIMitarAccount cimitarUser, FactorySettings factorySettings)
		{
			this._factorySettings = factorySettings;
			this._cimitarUser = cimitarUser;
			this.InitializeComponent();
			this.InitGridCell();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000443C File Offset: 0x0000263C
		private void InitGridCell()
		{
			Color color = Color.FromArgb(130, 179, 237);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader.BackColor = color;
			columnHeader.Border = RectangleBorder.NoBorder;
			columnHeader.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_header1 = new SourceGrid.Cells.Views.ColumnHeader();
			this.cell_header1.Background = columnHeader;
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000044BC File Offset: 0x000026BC
		private void InitGrid()
		{
			this.grid_oepration.Rows.Clear();
			this.grid_oepration.ColumnsCount = 4;
			this.grid_oepration.FixedRows = 1;
			this.grid_oepration.FixedColumns = 4;
			this.grid_oepration.Rows.Insert(0);
			this.grid_oepration[0, 0] = new SourceGrid.Cells.ColumnHeader("Factory");
			this.grid_oepration[0, 0].View = this.cell_header1;
			this.grid_oepration.Columns[0].Visible = true;
			this.grid_oepration[0, 1] = new SourceGrid.Cells.ColumnHeader("Operation Code");
			this.grid_oepration[0, 1].View = this.cell_header1;
			this.grid_oepration.Columns[1].Visible = true;
			this.grid_oepration[0, 2] = new SourceGrid.Cells.ColumnHeader("Operation Name");
			this.grid_oepration[0, 2].View = this.cell_header1;
			this.grid_oepration.Columns[2].Visible = true;
			this.grid_oepration[0, 3] = new SourceGrid.Cells.ColumnHeader("Check");
			this.grid_oepration[0, 3].View = this.cell_header1;
			this.grid_oepration.Columns[3].Visible = true;
			this.grid_oepration.AutoSizeCells();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004644 File Offset: 0x00002844
		private void btnAddOperation_Click(object sender, EventArgs e)
		{
			if (this.tbOperationCode.Text.Trim().Length != 0 && this.tbOperationName.Text.Trim().Length != 0)
			{
				string empty = string.Empty;
				if (cFunction.setOperation(Convert.ToInt32(this.tbOperationCode.Text.Trim()), this.tbOperationName.Text.Trim(), out empty))
				{
					this.tbOperationCode.Text = string.Empty;
					this.tbOperationName.Text = string.Empty;
					this.setOperationList();
				}
				else
				{
					MessageBox.Show(empty, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00004708 File Offset: 0x00002908
		private void tbOperationCode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar >= '0' && e.KeyChar <= '9')
			{
				e.KeyChar = e.KeyChar;
			}
			else
			{
				e.KeyChar = '\0';
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004768 File Offset: 0x00002968
		private void setOperationList()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			DataSet operation = cFunction.getOperation();
			if (operation != null && operation.Tables.Count != 0)
			{
				for (int i = 0; i < operation.Tables[0].Rows.Count; i++)
				{
					string key = operation.Tables[0].Rows[i]["OperationCode"].ToString();
					string value = operation.Tables[0].Rows[i]["OperationName"].ToString();
					if (!dictionary.ContainsKey(key))
					{
						dictionary.Add(key, value);
					}
				}
				from x in dictionary
				orderby x.Value
				select x;
			}
			this.InitGrid();
			for (int i = 0; i < dictionary.Count; i++)
			{
				this.grid_oepration.Rows.Insert(i + 1);
				this.grid_oepration[i + 1, 0] = new SourceGrid.Cells.Cell(cFunction.getFactory());
				this.grid_oepration[i + 1, 1] = new SourceGrid.Cells.Cell(dictionary.ElementAt(i).Key);
				this.grid_oepration[i + 1, 2] = new SourceGrid.Cells.Cell(dictionary.ElementAt(i).Value);
				this.grid_oepration[i + 1, 3] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004916 File Offset: 0x00002B16
		private void AdminSetting_Shown(object sender, EventArgs e)
		{
			this.InitGrid();
			this.setOperationList();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004928 File Offset: 0x00002B28
		private void btnDelOperation_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			bool flag = false;
			for (int i = 1; i < this.grid_oepration.RowsCount; i++)
			{
				if ((bool)this.grid_oepration[i, 3].Value)
				{
					if (!cFunction.deleteOperation(Convert.ToInt32(this.grid_oepration[i, 1].ToString()), this.grid_oepration[i, 2].ToString(), out empty))
					{
						MessageBox.Show(empty, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						break;
					}
					flag = true;
				}
			}
			if (flag)
			{
				MessageBox.Show("delete succeed.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.setOperationList();
			}
		}

		// Token: 0x0400000D RID: 13
		private FactorySettings _factorySettings;

		// Token: 0x0400000E RID: 14
		private new CIMitarAccount _cimitarUser;

		// Token: 0x0400000F RID: 15
		private SourceGrid.Cells.Views.Cell cell_header1;
	}
}
