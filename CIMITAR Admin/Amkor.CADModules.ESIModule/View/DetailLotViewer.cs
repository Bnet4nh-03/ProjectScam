using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.ESIModule.Class;
using Amkor.CADModules.ESIModule.Control;
using Amkor.CADModules.ESIModule.Properties;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.ESIModule.View
{
	// Token: 0x02000031 RID: 49
	public partial class DetailLotViewer : Form
	{
		// Token: 0x0600017B RID: 379 RVA: 0x00025B20 File Offset: 0x00023D20
		public DetailLotViewer(SortedList slData, string sSelectStation, string sSelectlot, string sDcc, bool bStationGathering, uint iMode)
		{
			this.InitializeComponent();
			this.Text = "Serial Number List";
			this._sKeyStation = sSelectStation;
			this._sKeyLot = sSelectlot;
			this._sKeyDcc = sDcc;
			this._bStatioanGathering = bStationGathering;
			this._slData = slData;
			this.rbAll.Checked = true;
			this.cbStation.Enabled = this._bStatioanGathering;
			this.cbStation.SelectedItem = "ALL";
			switch (iMode)
			{
			case 0U:
				this.rbAll.Checked = true;
				this.rbPass.Checked = false;
				this.rbFail.Checked = false;
				break;
			case 1U:
				this.rbAll.Checked = false;
				this.rbPass.Checked = true;
				this.rbFail.Checked = false;
				break;
			case 2U:
				this.rbAll.Checked = false;
				this.rbPass.Checked = false;
				this.rbFail.Checked = true;
				break;
			}
			this.iniUnitData(true);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00025C5C File Offset: 0x00023E5C
		private void initGrid()
		{
			this.gridDetailUnitList.ColumnsCount = 7;
			this.gridDetailUnitList.RowsCount = 1;
			this.gridDetailUnitList.FixedRows = 1;
			int p = 0;
			this.gridDetailUnitList.Columns[p].Width = 30;
			this.gridDetailUnitList[0, p++] = new GridInfo.ColHeader("No");
			this.gridDetailUnitList.Columns[p].Width = 180;
			this.gridDetailUnitList[0, p++] = new GridInfo.ColHeader("Staion");
			this.gridDetailUnitList.Columns[p].Width = 150;
			this.gridDetailUnitList[0, p++] = new GridInfo.ColHeader("SN");
			this.gridDetailUnitList.Columns[p].Width = 70;
			this.gridDetailUnitList[0, p++] = new GridInfo.ColHeader("Config");
			this.gridDetailUnitList.Columns[p].Width = 60;
			this.gridDetailUnitList[0, p++] = new GridInfo.ColHeader("Dcc");
			this.gridDetailUnitList.Columns[p].Width = 150;
			this.gridDetailUnitList[0, p++] = new GridInfo.ColHeader("in Date");
			this.gridDetailUnitList.Columns[p].Width = 50;
			this.gridDetailUnitList[0, p++] = new GridInfo.ColHeader("Result");
			this.gridInfo.SetColumnCellColor(this.gridDetailUnitList, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00025E20 File Offset: 0x00024020
		private void iniUnitData(bool bResetComboBox)
		{
			try
			{
				this.gridDetailUnitList.Rows.Clear();
				this.initGrid();
				List<string> list = new List<string>();
				SortedList slData = this._slData;
				StationData stationData = new StationData();
				StationIDData stationIDData = new StationIDData();
				LotData lotData = new LotData();
				new UnitData();
				int num = 1;
				if (this._bStatioanGathering)
				{
					for (int i = 0; i < slData.Count; i++)
					{
						stationData = (StationData)slData.GetByIndex(i);
						for (int j = 0; j < stationData.slLot.Count; j++)
						{
							bool flag = true;
							lotData = (LotData)stationData.slLot.GetByIndex(j);
							if (lotData.Lotid == this._sKeyLot && lotData.Dcc == this._sKeyDcc && stationData.Station == this._sKeyStation)
							{
								flag = false;
							}
							if (!flag)
							{
								int k = 0;
								while (k < lotData.slUnit.Count)
								{
									UnitData unitData = (UnitData)lotData.slUnit.GetByIndex(k);
									if (this.rbPass.Checked)
									{
										if (!(unitData.result != "PASS"))
										{
											goto IL_129;
										}
									}
									else if (!this.rbFail.Checked || !(unitData.result != "FAIL"))
									{
										goto IL_129;
									}
									IL_2EC:
									k++;
									continue;
									IL_129:
									unitData.result == "FAIL";
									bool flag2 = false;
									if (unitData.result == "FAIL")
									{
										for (int l = 0; l < unitData.slSeq.Count; l++)
										{
											UnitResult unitResult = (UnitResult)unitData.slSeq.GetByIndex(l);
											if (unitResult.iPassCnt > 0)
											{
												flag2 = true;
											}
										}
									}
									if (this.cbStation.SelectedItem.ToString() != "ALL" && unitData.Station_id != this.cbStation.SelectedItem.ToString())
									{
										flag2 = true;
									}
									if (!flag2)
									{
										if (unitData.Station_id != string.Empty && list.IndexOf(unitData.Station_id) < 0)
										{
											list.Add(unitData.Station_id);
										}
										this.gridDetailUnitList.Rows.Insert(this.gridDetailUnitList.RowsCount);
										int row = this.gridDetailUnitList.RowsCount - 1;
										this.gridDetailUnitList[row, 0] = new Cell(num++);
										this.gridDetailUnitList[row, 1] = new Cell(unitData.Station_id);
										this.gridDetailUnitList[row, 2] = new Cell(unitData.SN);
										this.gridDetailUnitList[row, 3] = new Cell(lotData.Lotid);
										this.gridDetailUnitList[row, 4] = new Cell(lotData.Dcc);
										this.gridDetailUnitList[row, 5] = new Cell(unitData.Indate);
										this.gridDetailUnitList[row, 6] = new Cell(unitData.result);
										goto IL_2EC;
									}
									goto IL_2EC;
								}
							}
						}
					}
				}
				else
				{
					for (int m = 0; m < slData.Count; m++)
					{
						stationData = (StationData)slData.GetByIndex(m);
						for (int n = 0; n < stationData.slStationId.Count; n++)
						{
							stationIDData = (StationIDData)stationData.slStationId.GetByIndex(n);
							for (int num2 = 0; num2 < stationIDData.slLot.Count; num2++)
							{
								bool flag3 = true;
								lotData = (LotData)stationIDData.slLot.GetByIndex(num2);
								if (lotData.Lotid == this._sKeyLot && lotData.Dcc == this._sKeyDcc && stationIDData.StationID == this._sKeyStation)
								{
									flag3 = false;
								}
								if (!flag3)
								{
									int num3 = 0;
									while (num3 < lotData.slUnit.Count)
									{
										UnitData unitData2 = (UnitData)lotData.slUnit.GetByIndex(num3);
										if (this.rbPass.Checked)
										{
											if (!(unitData2.result != "PASS"))
											{
												goto IL_42F;
											}
										}
										else if (!this.rbFail.Checked || !(unitData2.result != "FAIL"))
										{
											goto IL_42F;
										}
										IL_5A2:
										num3++;
										continue;
										IL_42F:
										bool flag4 = false;
										if (unitData2.result == "FAIL")
										{
											for (int num4 = 0; num4 < unitData2.slSeq.Count; num4++)
											{
												UnitResult unitResult2 = (UnitResult)unitData2.slSeq.GetByIndex(num4);
												if (unitResult2.iPassCnt > 0)
												{
													flag4 = true;
												}
											}
										}
										if (!flag4)
										{
											if (unitData2.Station_id != string.Empty && list.IndexOf(unitData2.Station_id) < 0)
											{
												list.Add(unitData2.Station_id);
											}
											this.gridDetailUnitList.Rows.Insert(this.gridDetailUnitList.RowsCount);
											int row2 = this.gridDetailUnitList.RowsCount - 1;
											this.gridDetailUnitList[row2, 0] = new Cell(num++);
											this.gridDetailUnitList[row2, 1] = new Cell(stationIDData.StationID);
											this.gridDetailUnitList[row2, 2] = new Cell(unitData2.SN);
											this.gridDetailUnitList[row2, 3] = new Cell(lotData.Lotid);
											this.gridDetailUnitList[row2, 4] = new Cell(lotData.Dcc);
											this.gridDetailUnitList[row2, 5] = new Cell(unitData2.Indate);
											this.gridDetailUnitList[row2, 6] = new Cell(unitData2.result);
											goto IL_5A2;
										}
										goto IL_5A2;
									}
								}
							}
						}
					}
				}
				if (bResetComboBox)
				{
					this.cbStation.Items.Clear();
					this.cbStation.Items.Add("ALL");
					for (int num5 = 0; num5 < list.Count; num5++)
					{
						this.cbStation.Items.Add(list[num5]);
					}
					this.cbStation.SelectedItem = "ALL";
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000264C4 File Offset: 0x000246C4
		private void DetailLotViewer_FormClosing(object sender, FormClosingEventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x000264CD File Offset: 0x000246CD
		private void rbPass_Click(object sender, EventArgs e)
		{
			this.rbAll.Checked = false;
			this.rbFail.Checked = false;
			this.rbPass.Checked = true;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000264F3 File Offset: 0x000246F3
		private void rbFail_Click(object sender, EventArgs e)
		{
			this.rbAll.Checked = false;
			this.rbFail.Checked = true;
			this.rbPass.Checked = false;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00026519 File Offset: 0x00024719
		private void rbAll_Click(object sender, EventArgs e)
		{
			this.rbAll.Checked = true;
			this.rbFail.Checked = false;
			this.rbPass.Checked = false;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0002653F File Offset: 0x0002473F
		private void rbAll_CheckedChanged(object sender, EventArgs e)
		{
			this.iniUnitData(false);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00026548 File Offset: 0x00024748
		private void cbStation_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.iniUnitData(false);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00026551 File Offset: 0x00024751
		private void cmdUnitExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridDetailUnitList);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0002655F File Offset: 0x0002475F
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00026570 File Offset: 0x00024770
		private void saveExcel(Grid grid)
		{
			try
			{
				if (grid.RowsCount >= 2)
				{
					this.saveFileDialog.DefaultExt = ".xlsx";
					this.saveFileDialog.Filter = "Excel files|*.xlsx";
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						ExcelControl.Save(this.saveFileDialog.FileName, grid, true);
						Thread.Sleep(100);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x04000286 RID: 646
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x04000287 RID: 647
		private SortedList _slData = new SortedList();

		// Token: 0x04000288 RID: 648
		private string _sKeyStation = string.Empty;

		// Token: 0x04000289 RID: 649
		private string _sKeyLot = string.Empty;

		// Token: 0x0400028A RID: 650
		private string _sKeyDcc = string.Empty;

		// Token: 0x0400028B RID: 651
		private bool _bStatioanGathering;

		// Token: 0x0400028C RID: 652
		private bool _bContinueEvent;

		// Token: 0x0400028D RID: 653
		private Thread _thread;

		// Token: 0x0400028E RID: 654
		private BarPrograss _barPrograss;
	}
}
