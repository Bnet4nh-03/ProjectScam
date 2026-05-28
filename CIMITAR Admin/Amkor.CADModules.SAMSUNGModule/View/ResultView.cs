using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.SAMSUNGModule.CIMitarAdminWS;
using Amkor.CADModules.SAMSUNGModule.Class;
using Amkor.CADModules.SAMSUNGModule.Properties;
using ATDFW.Classes.CIMitar;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.SAMSUNGModule.View
{
	// Token: 0x02000027 RID: 39
	public partial class ResultView : Form
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x0000B76C File Offset: 0x0000996C
		public ResultView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000B790 File Offset: 0x00009990
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000B79E File Offset: 0x0000999E
		private void UploadUnit_Load(object sender, EventArgs e)
		{
			this.initGrid();
			this.setGridBinding();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000B7AC File Offset: 0x000099AC
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

		// Token: 0x060000C7 RID: 199 RVA: 0x0000B824 File Offset: 0x00009A24
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

		// Token: 0x060000C8 RID: 200 RVA: 0x0000B90C File Offset: 0x00009B0C
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

		// Token: 0x060000C9 RID: 201 RVA: 0x0000B9B8 File Offset: 0x00009BB8
		private void cmd_Apply_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Incorrect data.But Do you want to proceed", "ESI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			base.DialogResult = dialogResult;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000B9DF File Offset: 0x00009BDF
		private void cmd_Apply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmd_Apply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000B9FC File Offset: 0x00009BFC
		private void cmd_Apply_MouseLeave(object sender, EventArgs e)
		{
			this.cmd_Apply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000BA19 File Offset: 0x00009C19
		private void cmd_Apply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmd_Apply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000BA36 File Offset: 0x00009C36
		private void cmd_Apply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x04000112 RID: 274
		public FactorySettings _factorySetting;

		// Token: 0x04000113 RID: 275
		public SortedList slData = new SortedList();

		// Token: 0x04000114 RID: 276
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x04000115 RID: 277
		private Thread _thread;

		// Token: 0x04000116 RID: 278
		private BarPrograss _barPrograss;
	}
}
