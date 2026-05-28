using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.CIMitar;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000049 RID: 73
	public partial class UserDefColumn : Form
	{
		// Token: 0x06000342 RID: 834 RVA: 0x00051ED0 File Offset: 0x000500D0
		public UserDefColumn()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00051F20 File Offset: 0x00050120
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000344 RID: 836 RVA: 0x00051F28 File Offset: 0x00050128
		// (set) Token: 0x06000345 RID: 837 RVA: 0x00051F35 File Offset: 0x00050135
		public string Caption
		{
			get
			{
				return this.lblTop.Text;
			}
			set
			{
				this.lblTop.Text = value;
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00051F43 File Offset: 0x00050143
		private void UserDefColumn_Load(object sender, EventArgs e)
		{
			this.sFilePath = Application.StartupPath + "\\" + this.sName + ".xml";
			this.initGrid();
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00051F6C File Offset: 0x0005016C
		private void initGrid()
		{
			this.gridColumnList.ColumnsCount = 2;
			this.gridColumnList.RowsCount = this.slAllList.Count + 1;
			this.gridColumnList.FixedRows = 1;
			this.gridColumnList[0, 0] = new GridInfo.ColHeader("", false);
			this.gridColumnList[0, 1] = new GridInfo.ColHeader("Column Name", false);
			for (int i = 0; i < this.slAllList.Count; i++)
			{
				if (this.slSelectList.ContainsKey(this.slAllList.GetKey(i)))
				{
					this.gridColumnList[i + 1, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(true));
				}
				else
				{
					this.gridColumnList[i + 1, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
				}
				this.gridColumnList[i + 1, 1] = new Cell(this.slAllList.GetByIndex(i));
			}
			this.gridColumnList.Rows[0].Tag = "Header";
			this.gridInfo.SetColumnCellColor(this.gridColumnList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.CreateColHeaderCheckBox(this.gridColumnList, new System.Windows.Forms.CheckBox(), 1);
			this.gridInfo.AutoSetGrid(this.gridColumnList);
			this.gridColumnList.Columns[1].Width = 150;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x000520E4 File Offset: 0x000502E4
		private void cmdApply_Click(object sender, EventArgs e)
		{
			this.slSelectList = new SortedList();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<Config>");
			for (int i = 1; i < this.gridColumnList.Rows.Count; i++)
			{
				if ((bool)this.gridColumnList[i, 0].Value)
				{
					stringBuilder.AppendFormat("<field key=\"{0}\" value=\"{1}\" ", i.ToString(), this.gridColumnList[i, 1].ToString());
					stringBuilder.Append("/>");
					this.slSelectList.Add(i, this.gridColumnList[i, 1].ToString());
				}
			}
			stringBuilder.AppendLine("</Config>");
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(stringBuilder.ToString());
			xmlDocument.Save(this.sFilePath);
			base.Close();
		}

		// Token: 0x06000349 RID: 841 RVA: 0x000521C9 File Offset: 0x000503C9
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
			base.Close();
		}

		// Token: 0x0600034A RID: 842 RVA: 0x000521D8 File Offset: 0x000503D8
		private void cmdApply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x000521F5 File Offset: 0x000503F5
		private void cmdApply_MouseLeave(object sender, EventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00052212 File Offset: 0x00050412
		private void cmdApply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0005222F File Offset: 0x0005042F
		private void cmdApply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x04000578 RID: 1400
		public FactorySettings _factorySetting;

		// Token: 0x04000579 RID: 1401
		public string sName = string.Empty;

		// Token: 0x0400057A RID: 1402
		public SortedList slSelectList = new SortedList();

		// Token: 0x0400057B RID: 1403
		public SortedList slAllList = new SortedList();

		// Token: 0x0400057C RID: 1404
		private string sFilePath = string.Empty;

		// Token: 0x0400057D RID: 1405
		private GridInfo gridInfo = new GridInfo();
	}
}
