using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000051 RID: 81
	public partial class ResultView : Form
	{
		// Token: 0x060003CC RID: 972 RVA: 0x00059268 File Offset: 0x00057468
		public ResultView()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060003CD RID: 973 RVA: 0x00059297 File Offset: 0x00057497
		// (set) Token: 0x060003CE RID: 974 RVA: 0x000592A4 File Offset: 0x000574A4
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

		// Token: 0x060003CF RID: 975 RVA: 0x000592B2 File Offset: 0x000574B2
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x000592C0 File Offset: 0x000574C0
		private void ResultView_Load(object sender, EventArgs e)
		{
			this.init();
			this.viewGrid();
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x000592D0 File Offset: 0x000574D0
		private void init()
		{
			this.grpApply.Visible = false;
			this.gridResultList.ColumnsCount = 4;
			this.gridResultList.RowsCount = 1;
			this.gridResultList.FixedRows = 1;
			this.gridResultList[0, 0] = new GridInfo.ColHeader("Result", false);
			this.gridResultList[0, 1] = new GridInfo.ColHeader("Line", false);
			this.gridResultList[0, 2] = new GridInfo.ColHeader("Carrier Barcode", false);
			this.gridResultList[0, 3] = new GridInfo.ColHeader("Failture Reason", false);
			if (this.sType == "Clean")
			{
				this.queryMgr = new QueryMgr(this._factorySetting);
				this.grpApply.Visible = true;
				this.menuGrid = new ContextMenu();
				this.menuGrid.MenuItems.Clear();
				this.menuGrid.MenuItems.Add("Block Carrier Apply", new EventHandler(this.clean_Apply));
				this.gridResultList.ContextMenu = this.menuGrid;
			}
			this.gridInfo.SetColumnCellColor(this.gridResultList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridResultList);
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00059420 File Offset: 0x00057620
		private void gridResultList_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.menuGrid != null)
			{
				if (e.Button != MouseButtons.Right)
				{
					return;
				}
				if (this.gridResultList.RowsCount > 0)
				{
					this.menuGrid.Show(this.gridResultList, new Point(e.X, e.Y));
				}
			}
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00059474 File Offset: 0x00057674
		private void clean_Apply(object sender, EventArgs e)
		{
			try
			{
				if (this.sType == "Clean")
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Apply Data....");
					this._barPrograss.setValue(0);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					this._barPrograss.setMax(this.slResult.Count);
					for (int i = 1; i < this.gridResultList.RowsCount; i++)
					{
						if (this.gridResultList[i, 0].ToString() == "Fail")
						{
							string key = this.gridResultList[i, 2].ToString();
							if (this.slResult.ContainsKey(key))
							{
								CarrierInfo carrierInfo = (CarrierInfo)this.slResult[key];
								CarrierInfo carrierInfo2 = carrierInfo;
								carrierInfo2.Memo += " 48hr";
								string sQuery = string.Concat(new string[]
								{
									"EXEC [CIMitar_Factory].[dbo].[USP_Admin_ChangeCarrierStatus]  @type = '",
									this.sType,
									"', @location = '",
									carrierInfo.Barcode,
									"', @memo = N'",
									carrierInfo.Memo,
									"', @userid = '",
									this._cimitarUser._id,
									"', @loadtester = '",
									carrierInfo.LoadTester,
									"', @repaircode = '",
									carrierInfo.RepairCodeSite1,
									"', @repaircode1 = '",
									carrierInfo.RepairCodeSite2,
									"', @revision = '",
									carrierInfo.Revision,
									"', @subbarcode1 = '",
									carrierInfo.SubBarcode1,
									"', @subbarcode2 = '",
									carrierInfo.SubBarcode2,
									"', @checkflag = 'N'"
								});
								DataSet dataSet = this.queryMgr.queryCall(sQuery);
								if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
								{
									if (dataSet.Tables[0].Rows[0]["ReturnCode"].ToString() == "-1")
									{
										carrierInfo.Result = "Fail";
										carrierInfo.Reason = dataSet.Tables[0].Rows[0]["ReturnValue"].ToString();
									}
									else
									{
										carrierInfo.Result = "Success";
										carrierInfo.Reason = string.Empty;
									}
								}
								this.gridResultList[i, 0] = new Cell(carrierInfo.Result);
								this.gridResultList[i, 3] = new Cell(carrierInfo.Reason);
								this.gridResultList[i, 0].View = this.gridInfo.CellColor.cell_font_blue;
								this.gridResultList[i, 1].View = this.gridInfo.CellColor.cell_font_blue;
								this.gridResultList[i, 2].View = this.gridInfo.CellColor.cell_font_blue;
								this.gridResultList[i, 3].View = this.gridInfo.CellColor.cell_font_blue;
								this.gridResultList.Refresh();
								this.gridInfo.AutoSetGrid(this.gridResultList);
							}
						}
						this._barPrograss.setValue(i + 1);
					}
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x000598B8 File Offset: 0x00057AB8
		private void viewGrid()
		{
			this.gridResultList.RowsCount = 1;
			for (int i = 0; i < this.slResult.Count; i++)
			{
				CarrierInfo carrierInfo = (CarrierInfo)this.slResult.GetByIndex(i);
				this.gridResultList.Rows.Insert(this.gridResultList.RowsCount);
				this.gridResultList[i + 1, 0] = new Cell(carrierInfo.Result);
				this.gridResultList[i + 1, 1] = new Cell(carrierInfo.Line.ToString());
				this.gridResultList[i + 1, 2] = new Cell(carrierInfo.Barcode);
				this.gridResultList[i + 1, 3] = new Cell(carrierInfo.Reason);
				if (this.gridResultList[i + 1, 0].ToString() == "Fail")
				{
					for (int j = 0; j < this.gridResultList.ColumnsCount; j++)
					{
						this.gridResultList[i + 1, j].View = this.gridInfo.CellColor.cell_font_red;
					}
				}
			}
			this.gridInfo.AutoSetGrid(this.gridResultList);
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000599F2 File Offset: 0x00057BF2
		private void cmdApply_Click(object sender, EventArgs e)
		{
			this.clean_Apply(null, null);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x000599FC File Offset: 0x00057BFC
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00059A04 File Offset: 0x00057C04
		private void cmdApply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00059A21 File Offset: 0x00057C21
		private void cmdApply_MouseLeave(object sender, EventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00059A3E File Offset: 0x00057C3E
		private void cmdApply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00059A5B File Offset: 0x00057C5B
		private void cmdApply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00059A68 File Offset: 0x00057C68
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00059A85 File Offset: 0x00057C85
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00059AA2 File Offset: 0x00057CA2
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00059ABF File Offset: 0x00057CBF
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x04000616 RID: 1558
		public FactorySettings _factorySetting;

		// Token: 0x04000617 RID: 1559
		public CIMitarAccount _cimitarUser;

		// Token: 0x04000618 RID: 1560
		private QueryMgr queryMgr;

		// Token: 0x04000619 RID: 1561
		private Thread _thread;

		// Token: 0x0400061A RID: 1562
		private BarPrograss _barPrograss;

		// Token: 0x0400061B RID: 1563
		public SortedList slResult = new SortedList();

		// Token: 0x0400061C RID: 1564
		public string sType = string.Empty;

		// Token: 0x0400061D RID: 1565
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x0400061E RID: 1566
		private ContextMenu menuGrid;
	}
}
