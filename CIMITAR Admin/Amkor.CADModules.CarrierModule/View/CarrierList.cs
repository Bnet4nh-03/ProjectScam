using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.CIMitar;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200004C RID: 76
	public partial class CarrierList : Form
	{
		// Token: 0x0600037B RID: 891 RVA: 0x00055706 File Offset: 0x00053906
		public CarrierList()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00055735 File Offset: 0x00053935
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600037D RID: 893 RVA: 0x0005573D File Offset: 0x0005393D
		// (set) Token: 0x0600037E RID: 894 RVA: 0x0005574A File Offset: 0x0005394A
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

		// Token: 0x0600037F RID: 895 RVA: 0x00055758 File Offset: 0x00053958
		private void ResultView_Load(object sender, EventArgs e)
		{
			this.initGrid();
			this.viewGrid();
		}

		// Token: 0x06000380 RID: 896 RVA: 0x00055768 File Offset: 0x00053968
		private void checkGrid(Grid grid, bool checkFlag)
		{
			for (int i = 1; i < grid.RowsCount; i++)
			{
				grid[i, 0].Value = checkFlag;
			}
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0005579C File Offset: 0x0005399C
		private void cellClickEvent_Click(object sender, EventArgs e)
		{
			CellContext cellContext = (CellContext)sender;
			try
			{
				int row = cellContext.Position.Row;
				int column = cellContext.Position.Column;
				Grid grid = (Grid)cellContext.Grid;
				Cell cell = (Cell)cellContext.Cell;
				if (row > 0 && column == 0)
				{
					this.checkGrid(grid, false);
					cell.Value = true;
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00055824 File Offset: 0x00053A24
		private void initGrid()
		{
			this.gridResultList.ColumnsCount = 7;
			this.gridResultList.RowsCount = 1;
			this.gridResultList.FixedRows = 1;
			this.gridResultList[0, 0] = new GridInfo.ColHeader("Check", false);
			this.gridResultList[0, 1] = new GridInfo.ColHeader("Line", false);
			this.gridResultList[0, 2] = new GridInfo.ColHeader("CarrierBarcode", false);
			this.gridResultList[0, 3] = new GridInfo.ColHeader("Device", false);
			this.gridResultList[0, 4] = new GridInfo.ColHeader("CarrierNo", false);
			this.gridResultList[0, 5] = new GridInfo.ColHeader("CarrierType", false);
			this.gridResultList[0, 6] = new GridInfo.ColHeader("CurrentStatus", false);
			this.gridInfo.SetColumnCellColor(this.gridResultList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridResultList);
			CustomEvents customEvents = new CustomEvents();
			customEvents.Click += this.cellClickEvent_Click;
			this.gridResultList.Controller.AddController(customEvents);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0005595C File Offset: 0x00053B5C
		private void viewGrid()
		{
			this.gridResultList.RowsCount = 1;
			for (int i = 0; i < this.slResult.Count; i++)
			{
				CarrierInfo carrierInfo = (CarrierInfo)this.slResult.GetByIndex(i);
				this.gridResultList.Rows.Insert(this.gridResultList.RowsCount);
				this.gridResultList[i + 1, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
				this.gridResultList[i + 1, 1] = new Cell(carrierInfo.Line.ToString());
				this.gridResultList[i + 1, 2] = new Cell(carrierInfo.Barcode);
				this.gridResultList[i + 1, 3] = new Cell(carrierInfo.Device);
				this.gridResultList[i + 1, 4] = new Cell(carrierInfo.CarrierNo);
				this.gridResultList[i + 1, 5] = new Cell(carrierInfo.CarrierType);
				this.gridResultList[i + 1, 6] = new Cell(carrierInfo.Status);
			}
			this.gridInfo.AutoSetGrid(this.gridResultList);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00055A8B File Offset: 0x00053C8B
		private void gridResultList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00055A90 File Offset: 0x00053C90
		private void cmdApply_Click(object sender, EventArgs e)
		{
			bool flag = false;
			if (this.gridResultList.RowsCount <= 0)
			{
				MessageBox.Show("Carrier does not exist.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			for (int i = 1; i < this.gridResultList.RowsCount; i++)
			{
				if ((bool)this.gridResultList[i, 0].Value)
				{
					this.sBarcode = this.gridResultList[i, 2].Value.ToString();
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				MessageBox.Show("Please check Carrier BarCode.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			base.DialogResult = DialogResult.Yes;
			base.Close();
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00055B35 File Offset: 0x00053D35
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
			base.Close();
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00055B44 File Offset: 0x00053D44
		private void cmdApply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00055B61 File Offset: 0x00053D61
		private void cmdApply_MouseLeave(object sender, EventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00055B7E File Offset: 0x00053D7E
		private void cmdApply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00055B9B File Offset: 0x00053D9B
		private void cmdApply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00055BA8 File Offset: 0x00053DA8
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00055BC5 File Offset: 0x00053DC5
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00055BE2 File Offset: 0x00053DE2
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00055BFF File Offset: 0x00053DFF
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x040005BE RID: 1470
		public FactorySettings _factorySetting;

		// Token: 0x040005BF RID: 1471
		public SortedList slResult = new SortedList();

		// Token: 0x040005C0 RID: 1472
		public string sBarcode = string.Empty;

		// Token: 0x040005C1 RID: 1473
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x0200004D RID: 77
		public class GridColumn
		{
			// Token: 0x040005CC RID: 1484
			public const int Check = 0;

			// Token: 0x040005CD RID: 1485
			public const int Line = 1;

			// Token: 0x040005CE RID: 1486
			public const int Barcode = 2;

			// Token: 0x040005CF RID: 1487
			public const int Device = 3;

			// Token: 0x040005D0 RID: 1488
			public const int CarrierNo = 4;

			// Token: 0x040005D1 RID: 1489
			public const int CarrierType = 5;

			// Token: 0x040005D2 RID: 1490
			public const int Status = 6;
		}
	}
}
