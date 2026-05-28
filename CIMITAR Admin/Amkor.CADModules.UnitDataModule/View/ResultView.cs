using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.UnitDataModule.CIMitarAdminWS;
using Amkor.CADModules.UnitDataModule.Class;
using Amkor.CADModules.UnitDataModule.Properties;
using ATDFW.Classes.CIMitar;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.UnitDataModule.View
{
	// Token: 0x02000027 RID: 39
	public partial class ResultView : Form
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x0000A919 File Offset: 0x00008B19
		public ResultView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000A93D File Offset: 0x00008B3D
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000A94B File Offset: 0x00008B4B
		private void UploadUnit_Load(object sender, EventArgs e)
		{
			this.initGrid();
			this.setGridBinding();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000A95C File Offset: 0x00008B5C
		private DataSet queryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._factorySetting._urlServer + "CIMitarWebService/CIMitarWS.asmx";
				cimitarWSSoapClient.Endpoint.Address = new EndpointAddress(uri);
				dataSet = cimitarWSSoapClient.CIMitarQuaryCall("CIMitarMasterDBConnect", sQuery);
				result = dataSet;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				result = dataSet;
			}
			return result;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000A9D4 File Offset: 0x00008BD4
		private void initGrid()
		{
			this.gridResultList.ColumnsCount = 3;
			this.gridResultList.RowsCount = 1;
			this.gridResultList.FixedRows = 1;
			this.gridResultList[0, 0] = new GridInfo.ColHeader("Num");
			this.gridResultList[0, 1] = new GridInfo.ColHeader("SN");
			this.gridResultList[0, 2] = new GridInfo.ColHeader("ErrorMsg");
			this.gridResultList.Columns[0].Width = 50;
			this.gridResultList.Columns[1].Width = 150;
			this.gridResultList.Columns[2].Width = 200;
			this.gridInfo.SetColumnCellColor(this.gridResultList, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000AABC File Offset: 0x00008CBC
		private void setGridBinding()
		{
			for (int i = 0; i < this.slData.Count; i++)
			{
				UnitData unitData = (UnitData)this.slData.GetByIndex(i);
				this.gridResultList.Rows.Insert(this.gridResultList.RowsCount);
				this.gridResultList[i + 1, 0] = new Cell((i + 1).ToString());
				this.gridResultList[i + 1, 1] = new Cell(unitData.SN);
				this.gridResultList[i + 1, 2] = new Cell(unitData.Failure_message);
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000AB68 File Offset: 0x00008D68
		private void cmd_Apply_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Incorrect data.But Do you want to proceed", "ESI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			base.DialogResult = dialogResult;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000AB8F File Offset: 0x00008D8F
		private void cmd_Apply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmd_Apply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000ABAC File Offset: 0x00008DAC
		private void cmd_Apply_MouseLeave(object sender, EventArgs e)
		{
			this.cmd_Apply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000ABC9 File Offset: 0x00008DC9
		private void cmd_Apply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmd_Apply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000ABE6 File Offset: 0x00008DE6
		private void cmd_Apply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x04000106 RID: 262
		public FactorySettings _factorySetting;

		// Token: 0x04000107 RID: 263
		public SortedList slData = new SortedList();

		// Token: 0x04000108 RID: 264
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x04000109 RID: 265
		private Thread _thread;

		// Token: 0x0400010A RID: 266
		private BarPrograss _barPrograss;
	}
}
