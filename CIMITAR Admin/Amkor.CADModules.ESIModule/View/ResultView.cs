using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.ESIModule.CIMitarAdminWS;
using Amkor.CADModules.ESIModule.Class;
using Amkor.CADModules.ESIModule.Properties;
using ATDFW.Classes.CIMitar;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.ESIModule.View
{
	// Token: 0x02000030 RID: 48
	public partial class ResultView : Form
	{
		// Token: 0x0600016E RID: 366 RVA: 0x00025160 File Offset: 0x00023360
		public ResultView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00025184 File Offset: 0x00023384
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00025192 File Offset: 0x00023392
		private void UploadUnit_Load(object sender, EventArgs e)
		{
			this.initGrid();
			this.setGridBinding();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000251A0 File Offset: 0x000233A0
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

		// Token: 0x06000172 RID: 370 RVA: 0x00025218 File Offset: 0x00023418
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

		// Token: 0x06000173 RID: 371 RVA: 0x00025300 File Offset: 0x00023500
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

		// Token: 0x06000174 RID: 372 RVA: 0x000253AC File Offset: 0x000235AC
		private void cmd_Apply_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Incorrect data.But Do you want to proceed", "ESI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			base.DialogResult = dialogResult;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000253D3 File Offset: 0x000235D3
		private void cmd_Apply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmd_Apply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000253F0 File Offset: 0x000235F0
		private void cmd_Apply_MouseLeave(object sender, EventArgs e)
		{
			this.cmd_Apply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0002540D File Offset: 0x0002360D
		private void cmd_Apply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmd_Apply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0002542A File Offset: 0x0002362A
		private void cmd_Apply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x04000276 RID: 630
		public FactorySettings _factorySetting;

		// Token: 0x04000277 RID: 631
		public SortedList slData = new SortedList();

		// Token: 0x04000278 RID: 632
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x04000279 RID: 633
		private Thread _thread;

		// Token: 0x0400027A RID: 634
		private BarPrograss _barPrograss;
	}
}
