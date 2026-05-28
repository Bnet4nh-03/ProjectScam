using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;
using Amkor.CADModules.HccSTReportModule.Properties;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.HccSTReportModule.SubForms
{
	// Token: 0x0200000A RID: 10
	public partial class UploadList : Form
	{
		// Token: 0x06000055 RID: 85 RVA: 0x0000BB30 File Offset: 0x00009D30
		public UploadList()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000BB54 File Offset: 0x00009D54
		public UploadList(string dataType, string filePath)
		{
			this.InitializeComponent();
			this._dataType = dataType;
			this._filePath = filePath;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000BB86 File Offset: 0x00009D86
		private void UploadList_Load(object sender, EventArgs e)
		{
			this._instance = HccSTReportModule._instance;
			this._cCsvDatas = new List<CCsvData>();
			this._htHeader = new Hashtable();
			this.Identify(this._dataType, this._filePath);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000BBBB File Offset: 0x00009DBB
		private void UploadList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000BBD0 File Offset: 0x00009DD0
		private void ResetGrid(Grid grid)
		{
			for (int i = grid.RowsCount - 1; i >= 0; i--)
			{
				grid.Rows.Remove(i);
			}
			grid.Selection.EnableMultiSelection = false;
			grid.BorderStyle = BorderStyle.FixedSingle;
			grid.SelectionMode = GridSelectionMode.Row;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000BC18 File Offset: 0x00009E18
		private void SetHeaderInfo(Hashtable gridHeader, Grid grid)
		{
			UploadList.<>c__DisplayClass10_0 CS$<>8__locals1 = new UploadList.<>c__DisplayClass10_0();
			CS$<>8__locals1.gridHeader = gridHeader;
			grid.ColumnsCount = CS$<>8__locals1.gridHeader.Count + 1;
			grid.FixedRows = 1;
			grid.FixedColumns = 1;
			grid.Rows.Insert(0);
			grid[0, 0] = new SourceGrid.Cells.ColumnHeader("No");
			grid[0, 0].View = this._instance._cell_Header;
			int i;
			int j;
			for (i = 0; i < CS$<>8__locals1.gridHeader.Count; i = j + 1)
			{
				string text = CS$<>8__locals1.gridHeader.Keys.OfType<string>().FirstOrDefault((string o) => (int)CS$<>8__locals1.gridHeader[o] == i);
				grid[0, i + 1] = new SourceGrid.Cells.ColumnHeader(text.ToString());
				grid[0, i + 1].View = this._instance._cell_Header;
				j = i;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000BD2C File Offset: 0x00009F2C
		private void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
				if (((Grid)checkBox.Parent).RowsCount > 0)
				{
					for (int i = 1; i < ((Grid)checkBox.Parent).RowsCount; i++)
					{
						((Grid)checkBox.Parent)[i, 0].Value = checkBox.Checked;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000BDB0 File Offset: 0x00009FB0
		public void SetGridInfo(Hashtable htHeader, List<string> lines)
		{
			this.ResetGrid(this.grid_Result);
			this.SetHeaderInfo(htHeader, this.grid_Result);
			int num = 1;
			this._instance._barPrograss = new BarPrograss();
			this._instance._barPrograss.progress_labelheader_set("Loading..");
			this._instance._barPrograss.setMax(lines.Count);
			this._instance._barPrograss.setValue(1);
			this._instance._thread = new Thread(new ThreadStart(this._instance.BarPrograssView));
			this._instance._thread.Start();
			try
			{
				for (int i = 1; i < lines.Count; i++)
				{
					string[] array = lines[i].Trim().Split(new char[]
					{
						','
					});
					if (!(array[0] == ""))
					{
						this.grid_Result.Rows.Insert(num);
						this.grid_Result[num, 0] = new Cell(num);
						for (int j = 0; j < array.Length; j++)
						{
							this.grid_Result[num, j + 1] = new Cell(array[j]);
						}
						if (num % 2 != 0)
						{
							for (int k = 0; k < this.grid_Result.Columns.Count; k++)
							{
								this.grid_Result[num, k].View = this._instance._cell_Body1;
							}
						}
						else
						{
							for (int l = 0; l < this.grid_Result.Columns.Count; l++)
							{
								this.grid_Result[num, l].View = this._instance._cell_Body2;
							}
						}
						num++;
						this._instance._barPrograss.progress_increase();
					}
				}
				this.grid_Result.AutoSizeCells();
				Thread.Sleep(10);
				if (this._instance._barPrograss != null)
				{
					this._instance._barPrograss._ischeck = true;
				}
				this._instance._barPrograss = null;
			}
			catch (Exception ex)
			{
				Thread.Sleep(10);
				if (this._instance._barPrograss != null)
				{
					this._instance._barPrograss._ischeck = true;
				}
				this._instance._barPrograss = null;
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000C018 File Offset: 0x0000A218
		private void pb_Update_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Update.Image = Resources.TableSave_Down;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000C02A File Offset: 0x0000A22A
		private void pb_Update_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_Update.Image = Resources.TableSave;
			if (this._cCsvDatas.Count != 0)
			{
				this.UpdateInfo(this._dataType, this._cCsvDatas);
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000C05C File Offset: 0x0000A25C
		public void Identify(string dataType, string filePath)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(dataType);
			if (num <= 2424387085U)
			{
				if (num <= 640541426U)
				{
					if (num != 600578307U)
					{
						if (num != 622880297U)
						{
							if (num != 640541426U)
							{
								return;
							}
							if (!(dataType == "EWS_PIB"))
							{
								return;
							}
							this.ReadFile_EWS_PIB(filePath);
							return;
						}
						else
						{
							if (!(dataType == "EWS_KIT"))
							{
								return;
							}
							this.ReadFile_EWS_KIT(filePath);
							return;
						}
					}
					else
					{
						if (!(dataType == "EQ"))
						{
							return;
						}
						this.ReadFile_EQ(filePath);
						return;
					}
				}
				else
				{
					if (num == 1753135230U)
					{
						dataType == "FT_CK";
						return;
					}
					if (num == 2287356014U)
					{
						dataType == "FT_SK";
						return;
					}
					if (num != 2424387085U)
					{
						return;
					}
					dataType == "FT_DK";
					return;
				}
			}
			else if (num <= 3095967907U)
			{
				if (num != 2911414098U)
				{
					if (num == 2959299417U)
					{
						dataType == "FT_HS";
						return;
					}
					if (num != 3095967907U)
					{
						return;
					}
					if (!(dataType == "EWS_PT"))
					{
						return;
					}
					this.ReadFile_EWS_PT(filePath);
					return;
				}
				else
				{
					if (!(dataType == "EWS_PC"))
					{
						return;
					}
					this.ReadFile_EWS_PC(filePath);
					return;
				}
			}
			else
			{
				if (num == 3357361797U)
				{
					dataType == "FT_DUT";
					return;
				}
				if (num == 3496771605U)
				{
					dataType == "FT_LK";
					return;
				}
				if (num != 3614214938U)
				{
					return;
				}
				dataType == "FT_LB";
				return;
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000C1D8 File Offset: 0x0000A3D8
		public void ReadFile_EWS_PC(string filePath)
		{
			this._cCsvDatas.Clear();
			this._htHeader.Clear();
			Path.GetFileNameWithoutExtension(filePath);
			Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			List<string> list = new List<string>();
			using (StreamReader streamReader = new StreamReader(stream, Encoding.Default))
			{
				string item = string.Empty;
				while ((item = streamReader.ReadLine()) != null)
				{
					list.Add(item);
				}
			}
			if (list.Count != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					string[] array = list[i].Trim().Split(new char[]
					{
						','
					});
					if (i == 0)
					{
						for (int j = 0; j < array.Length; j++)
						{
							this._htHeader[array[j].Trim()] = j;
						}
					}
					else
					{
						if (this._htHeader.Count == 0)
						{
							break;
						}
						if (this._htHeader.Count != array.Length)
						{
							MessageBox.Show("Contents contains ','");
							break;
						}
						CCsvData ccsvData = new CCsvData();
						try
						{
							ccsvData.cCommonVal = new CCommonVal();
							ccsvData.cCommonVal.strPeriod = array[(int)this._htHeader["Period"]].Trim();
							if (!(ccsvData.cCommonVal.strPeriod == ""))
							{
								ccsvData.cCommonVal.strPlantCode = array[(int)this._htHeader["Plant Code"]].Trim();
								ccsvData.cCommonVal.strOwnership = array[(int)this._htHeader["Ownership"]].Trim();
								ccsvData.cCommonVal.strHwType = array[(int)this._htHeader["Hardware Type"]].Trim();
								ccsvData.cCommonVal.strSTDivName = array[(int)this._htHeader["ST Division Name"]].Trim();
								ccsvData.cCommonVal.strSTDivHwId = array[(int)this._htHeader["ST Division HW ID"]].Trim();
								if (!int.TryParse(array[(int)this._htHeader["GOBM Asset Number"]], out ccsvData.cCommonVal.iGobmAssetNumber))
								{
									ccsvData.cCommonVal.iGobmAssetNumber = 0;
								}
								ccsvData.cCommonVal.strOsatCodifiedId = array[(int)this._htHeader["OSAT Codified ID"]].Trim();
								ccsvData.cCommonVal.strOsatCodifiedSn = array[(int)this._htHeader["OSAT Codified SN"]].Trim();
								ccsvData.cCommonVal.strConditionStatus = array[(int)this._htHeader["Condition Status"]].Trim();
								ccsvData.cCommonVal.dtLastStatusUpDate = DateTime.Parse(array[(int)this._htHeader["Last Status Update Date"]]);
								ccsvData.cCommonVal.strDevFamily = array[(int)this._htHeader["Device Family"]].Trim();
								ccsvData.cCommonVal.strLocation = array[(int)this._htHeader["Location"]].Trim();
								ccsvData.cCommonVal.dtRecvDate = DateTime.Parse(array[(int)this._htHeader["Receive Date"]].Trim());
								ccsvData.cCommonVal.strTransTrackingNo = array[(int)this._htHeader["TransferInTracking No"]].Trim();
								ccsvData.cCommonVal.strIncommChkReportNo = array[(int)this._htHeader["Incomming check report number"]].Trim();
								ccsvData.cCommonVal.strRemark = array[(int)this._htHeader["Remark"]].Trim();
								if (!(ccsvData.cCommonVal.strLocation == ""))
								{
									ccsvData.cEWS_PC = new CEWS_PC();
									ccsvData.cEWS_PC.strWscsPkgDesc = array[(int)this._htHeader["WLCSP Package Description"]].Trim();
									ccsvData.cEWS_PC.strNumOfSites = array[(int)this._htHeader["No. Of Sites"]].Trim();
									if (!int.TryParse(array[(int)this._htHeader["No. Of Pins"]], out ccsvData.cEWS_PC.iNumOfPins))
									{
										ccsvData.cEWS_PC.iNumOfPins = 0;
									}
									ccsvData.cEWS_PC.strPinType = array[(int)this._htHeader["Pin Type"]].Trim();
									ccsvData.cEWS_PC.strCapableTemp = array[(int)this._htHeader["Capable Temperature"]].Trim();
									ccsvData.cEWS_PC.strProbeCardType = array[(int)this._htHeader["Probe Card Type"]].Trim();
									ccsvData.cEWS_PC.strSeperPcbBoard = array[(int)this._htHeader["Seperate PCB Board"]].Trim();
									ccsvData.cEWS_PC.strPcbId = array[(int)this._htHeader["PCB ID"]].Trim();
									ccsvData.cEWS_PC.strProbeHeadId = array[(int)this._htHeader["Probe Head ID"]].Trim();
									ccsvData.cEWS_PC.strPairedPcbId = array[(int)this._htHeader["Paired PCB ID"]].Trim();
									ccsvData.cEWS_PC.strMfrName = array[(int)this._htHeader["Manufacturer name"]].Trim();
									ccsvData.cEWS_PC.strMfrPartNo = array[(int)this._htHeader["Manufacturer Part number"]].Trim();
									ccsvData.cEWS_PC.strRepairSupplier = array[(int)this._htHeader["Repair Supplier"]].Trim();
									ccsvData.cEWS_PC.strTesterModel = array[(int)this._htHeader["Tester Model"]].Trim();
									ccsvData.cEWS_PC.strProberModel = array[(int)this._htHeader["Prober Model"]].Trim();
									if (!int.TryParse(array[(int)this._htHeader["Incomming Tip Lg"]], out ccsvData.cEWS_PC.iIncommTipLg))
									{
										ccsvData.cEWS_PC.iIncommTipLg = 0;
									}
									if (!int.TryParse(array[(int)this._htHeader["Incomming Tip Dia"]], out ccsvData.cEWS_PC.iIncommTipDia))
									{
										ccsvData.cEWS_PC.iIncommTipDia = 0;
									}
									if (!int.TryParse(array[(int)this._htHeader["Current Tip Lg"]], out ccsvData.cEWS_PC.iCurTipLg))
									{
										ccsvData.cEWS_PC.iCurTipLg = 0;
									}
									if (!int.TryParse(array[(int)this._htHeader["Current Tip Dia"]], out ccsvData.cEWS_PC.iCurTipDia))
									{
										ccsvData.cEWS_PC.iCurTipDia = 0;
									}
									if (!int.TryParse(array[(int)this._htHeader["Touch Down Count"]], out ccsvData.cEWS_PC.iTouchDownCnt))
									{
										ccsvData.cEWS_PC.iTouchDownCnt = 0;
									}
									if (!int.TryParse(array[(int)this._htHeader["Accumulated Touch Down"]], out ccsvData.cEWS_PC.iAccumTouchDown))
									{
										ccsvData.cEWS_PC.iAccumTouchDown = 0;
									}
									if (!int.TryParse(array[(int)this._htHeader["Min Tip Lg Spec"]], out ccsvData.cEWS_PC.iMinTipLgSpec))
									{
										ccsvData.cEWS_PC.iMinTipLgSpec = 0;
									}
									if (!int.TryParse(array[(int)this._htHeader["Min Tip Dia Spec"]], out ccsvData.cEWS_PC.iMinTipDiaSpec))
									{
										ccsvData.cEWS_PC.iMinTipDiaSpec = 0;
									}
									if (!int.TryParse(array[(int)this._htHeader["Expection Touch Down"]], out ccsvData.cEWS_PC.iExpectTouchDown))
									{
										ccsvData.cEWS_PC.iExpectTouchDown = 0;
									}
									if (!int.TryParse(array[(int)this._htHeader["Accumulated Touch Down"]], out ccsvData.cEWS_PC.iAccumTouchDown))
									{
										ccsvData.cEWS_PC.iAccumTouchDown = 0;
									}
									this._cCsvDatas.Add(ccsvData);
								}
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Wrong format: " + ex.Message);
							return;
						}
					}
				}
				this.SetGridInfo(this._htHeader, list);
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000CB20 File Offset: 0x0000AD20
		public void ReadFile_EWS_PIB(string filePath)
		{
			this._cCsvDatas.Clear();
			this._htHeader.Clear();
			Path.GetFileNameWithoutExtension(filePath);
			Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			List<string> list = new List<string>();
			using (StreamReader streamReader = new StreamReader(stream, Encoding.Default))
			{
				string item = string.Empty;
				while ((item = streamReader.ReadLine()) != null)
				{
					list.Add(item);
				}
			}
			if (list.Count != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					string[] array = list[i].Trim().Split(new char[]
					{
						','
					});
					if (i == 0)
					{
						for (int j = 0; j < array.Length; j++)
						{
							this._htHeader[array[j].Trim()] = j;
						}
					}
					else
					{
						if (this._htHeader.Count == 0)
						{
							break;
						}
						if (this._htHeader.Count != array.Length)
						{
							MessageBox.Show("Contents contains ','");
							break;
						}
						CCsvData ccsvData = new CCsvData();
						try
						{
							ccsvData.cCommonVal = new CCommonVal();
							ccsvData.cCommonVal.strPeriod = array[(int)this._htHeader["Period"]].Trim();
							if (!(ccsvData.cCommonVal.strPeriod == ""))
							{
								ccsvData.cCommonVal.strPlantCode = array[(int)this._htHeader["Plant Code"]].Trim();
								ccsvData.cCommonVal.strOwnership = array[(int)this._htHeader["Ownership"]].Trim();
								ccsvData.cCommonVal.strHwType = array[(int)this._htHeader["Hardware Type"]].Trim();
								ccsvData.cCommonVal.strSTDivName = array[(int)this._htHeader["ST Division Name"]].Trim();
								ccsvData.cCommonVal.strSTDivHwId = array[(int)this._htHeader["ST Division HW ID"]].Trim();
								if (!int.TryParse(array[(int)this._htHeader["GOBM Asset Number"]], out ccsvData.cCommonVal.iGobmAssetNumber))
								{
									ccsvData.cCommonVal.iGobmAssetNumber = 0;
								}
								ccsvData.cCommonVal.strOsatCodifiedId = array[(int)this._htHeader["OSAT Codified ID"]].Trim();
								ccsvData.cCommonVal.strOsatCodifiedSn = array[(int)this._htHeader["OSAT Codified SN"]].Trim();
								ccsvData.cCommonVal.strConditionStatus = array[(int)this._htHeader["Condition Status"]].Trim();
								ccsvData.cCommonVal.dtLastStatusUpDate = DateTime.Parse(array[(int)this._htHeader["Last Status Update Date"]]);
								ccsvData.cCommonVal.strDevFamily = array[(int)this._htHeader["Device Family"]].Trim();
								ccsvData.cCommonVal.strLocation = array[(int)this._htHeader["Location"]].Trim();
								ccsvData.cCommonVal.dtRecvDate = DateTime.Parse(array[(int)this._htHeader["Receive Date"]].Trim());
								ccsvData.cCommonVal.strTransTrackingNo = array[(int)this._htHeader["TransferInTracking No"]].Trim();
								ccsvData.cCommonVal.strIncommChkReportNo = array[(int)this._htHeader["Incomming check report number"]].Trim();
								ccsvData.cCommonVal.strRemark = array[(int)this._htHeader["Remark"]].Trim();
								if (!(ccsvData.cCommonVal.strLocation == ""))
								{
									ccsvData.cEWS_PIB = new CEWS_PIB();
									ccsvData.cEWS_PIB.strNumOfSites = array[(int)this._htHeader["No. Of Sites"]].Trim();
									ccsvData.cEWS_PIB.strPcbId = array[(int)this._htHeader["PCB ID"]].Trim();
									ccsvData.cEWS_PIB.strPcbRevision = array[(int)this._htHeader["PCB Revision"]].Trim();
									ccsvData.cEWS_PIB.strMfrName = array[(int)this._htHeader["Manufacturer name"]].Trim();
									ccsvData.cEWS_PIB.strMfrPartNo = array[(int)this._htHeader["Manufacturer Part number"]].Trim();
									ccsvData.cEWS_PIB.strTesterModel = array[(int)this._htHeader["Tester Model"]].Trim();
									this._cCsvDatas.Add(ccsvData);
								}
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Wrong format: " + ex.Message);
							return;
						}
					}
				}
				this.SetGridInfo(this._htHeader, list);
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000D0B8 File Offset: 0x0000B2B8
		public void ReadFile_EWS_PT(string filePath)
		{
			this._cCsvDatas.Clear();
			this._htHeader.Clear();
			Path.GetFileNameWithoutExtension(filePath);
			Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			List<string> list = new List<string>();
			using (StreamReader streamReader = new StreamReader(stream, Encoding.Default))
			{
				string item = string.Empty;
				while ((item = streamReader.ReadLine()) != null)
				{
					list.Add(item);
				}
			}
			if (list.Count != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					string[] array = list[i].Trim().Split(new char[]
					{
						','
					});
					if (i == 0)
					{
						for (int j = 0; j < array.Length; j++)
						{
							this._htHeader[array[j].Trim()] = j;
						}
					}
					else
					{
						if (this._htHeader.Count == 0)
						{
							break;
						}
						if (this._htHeader.Count != array.Length)
						{
							MessageBox.Show("Contents contains ','");
							break;
						}
						CCsvData ccsvData = new CCsvData();
						try
						{
							ccsvData.cCommonVal = new CCommonVal();
							ccsvData.cCommonVal.strPeriod = array[(int)this._htHeader["Period"]].Trim();
							if (!(ccsvData.cCommonVal.strPeriod == ""))
							{
								ccsvData.cCommonVal.strPlantCode = array[(int)this._htHeader["Plant Code"]].Trim();
								ccsvData.cCommonVal.strOwnership = array[(int)this._htHeader["Ownership"]].Trim();
								ccsvData.cCommonVal.strHwType = array[(int)this._htHeader["Hardware Type"]].Trim();
								ccsvData.cCommonVal.strSTDivName = array[(int)this._htHeader["ST Division Name"]].Trim();
								ccsvData.cCommonVal.strSTDivHwId = array[(int)this._htHeader["ST Division HW ID"]].Trim();
								if (!int.TryParse(array[(int)this._htHeader["GOBM Asset Number"]], out ccsvData.cCommonVal.iGobmAssetNumber))
								{
									ccsvData.cCommonVal.iGobmAssetNumber = 0;
								}
								ccsvData.cCommonVal.strOsatCodifiedId = array[(int)this._htHeader["OSAT Codified ID"]].Trim();
								ccsvData.cCommonVal.strOsatCodifiedSn = array[(int)this._htHeader["OSAT Codified SN"]].Trim();
								ccsvData.cCommonVal.strConditionStatus = array[(int)this._htHeader["Condition Status"]].Trim();
								ccsvData.cCommonVal.dtLastStatusUpDate = DateTime.Parse(array[(int)this._htHeader["Last Status Update Date"]]);
								ccsvData.cCommonVal.strDevFamily = array[(int)this._htHeader["Device Family"]].Trim();
								ccsvData.cCommonVal.strLocation = array[(int)this._htHeader["Location"]].Trim();
								ccsvData.cCommonVal.dtRecvDate = DateTime.Parse(array[(int)this._htHeader["Receive Date"]].Trim());
								ccsvData.cCommonVal.strTransTrackingNo = array[(int)this._htHeader["TransferInTracking No"]].Trim();
								ccsvData.cCommonVal.strIncommChkReportNo = array[(int)this._htHeader["Incomming check report number"]].Trim();
								ccsvData.cCommonVal.strRemark = array[(int)this._htHeader["Remark"]].Trim();
								if (!(ccsvData.cCommonVal.strLocation == ""))
								{
									ccsvData.cEWS_PT = new CEWS_PT();
									ccsvData.cEWS_PT.strMfrName = array[(int)this._htHeader["Manufacturer name"]].Trim();
									ccsvData.cEWS_PT.strMfrPartNo = array[(int)this._htHeader["Manufacturer Part number"]].Trim();
									ccsvData.cEWS_PT.strMfrSerialNo = array[(int)this._htHeader["Manufacturer Serial number"]].Trim();
									ccsvData.cEWS_PT.strMfdYear = array[(int)this._htHeader["MANUFACTURED_YEAR"]].Trim();
									if (!int.TryParse(array[(int)this._htHeader["Pin counter"]], out ccsvData.cEWS_PT.iPinCounter))
									{
										ccsvData.cEWS_PT.iPinCounter = 0;
									}
									ccsvData.cEWS_PT.strRfOptAvail = array[(int)this._htHeader["RF options available"]].Trim();
									ccsvData.cEWS_PT.strCompTesterModel = array[(int)this._htHeader["Compatible Tester Model"]].Trim();
									ccsvData.cEWS_PT.strColdTestOptAvail = array[(int)this._htHeader["Cold test options available"]].Trim();
									this._cCsvDatas.Add(ccsvData);
								}
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Wrong format: " + ex.Message);
							return;
						}
					}
				}
				this.SetGridInfo(this._htHeader, list);
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000D6B4 File Offset: 0x0000B8B4
		public void ReadFile_EWS_KIT(string filePath)
		{
			this._cCsvDatas.Clear();
			this._htHeader.Clear();
			Path.GetFileNameWithoutExtension(filePath);
			Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			List<string> list = new List<string>();
			using (StreamReader streamReader = new StreamReader(stream, Encoding.Default))
			{
				string item = string.Empty;
				while ((item = streamReader.ReadLine()) != null)
				{
					list.Add(item);
				}
			}
			if (list.Count != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					string[] array = list[i].Trim().Split(new char[]
					{
						','
					});
					if (i == 0)
					{
						for (int j = 0; j < array.Length; j++)
						{
							this._htHeader[array[j].Trim()] = j;
						}
					}
					else
					{
						if (this._htHeader.Count == 0)
						{
							break;
						}
						if (this._htHeader.Count != array.Length)
						{
							MessageBox.Show("Contents contains ','");
							break;
						}
						CCsvData ccsvData = new CCsvData();
						try
						{
							ccsvData.cCommonVal = new CCommonVal();
							ccsvData.cCommonVal.strPeriod = array[(int)this._htHeader["Period"]].Trim();
							if (!(ccsvData.cCommonVal.strPeriod == ""))
							{
								ccsvData.cCommonVal.strPlantCode = array[(int)this._htHeader["Plant Code"]].Trim();
								ccsvData.cCommonVal.strOwnership = array[(int)this._htHeader["Ownership"]].Trim();
								ccsvData.cCommonVal.strHwType = array[(int)this._htHeader["Hardware Type"]].Trim();
								ccsvData.cCommonVal.strSTDivName = array[(int)this._htHeader["ST Division Name"]].Trim();
								ccsvData.cCommonVal.strSTDivHwId = array[(int)this._htHeader["ST Division HW ID"]].Trim();
								if (!int.TryParse(array[(int)this._htHeader["GOBM Asset Number"]], out ccsvData.cCommonVal.iGobmAssetNumber))
								{
									ccsvData.cCommonVal.iGobmAssetNumber = 0;
								}
								ccsvData.cCommonVal.strOsatCodifiedId = array[(int)this._htHeader["OSAT Codified ID"]].Trim();
								ccsvData.cCommonVal.strOsatCodifiedSn = array[(int)this._htHeader["OSAT Codified SN"]].Trim();
								ccsvData.cCommonVal.strConditionStatus = array[(int)this._htHeader["Condition Status"]].Trim();
								ccsvData.cCommonVal.dtLastStatusUpDate = DateTime.Parse(array[(int)this._htHeader["Last Status Update Date"]]);
								ccsvData.cCommonVal.strDevFamily = array[(int)this._htHeader["Device Family"]].Trim();
								ccsvData.cCommonVal.strLocation = array[(int)this._htHeader["Location"]].Trim();
								ccsvData.cCommonVal.dtRecvDate = DateTime.Parse(array[(int)this._htHeader["Receive Date"]].Trim());
								ccsvData.cCommonVal.strTransTrackingNo = array[(int)this._htHeader["TransferInTracking No"]].Trim();
								ccsvData.cCommonVal.strIncommChkReportNo = array[(int)this._htHeader["Incomming check report number"]].Trim();
								ccsvData.cCommonVal.strRemark = array[(int)this._htHeader["Remark"]].Trim();
								if (!(ccsvData.cCommonVal.strLocation == ""))
								{
									ccsvData.cEWS_KIT = new CEWS_KIT();
									ccsvData.cEWS_KIT.strMfrName = array[(int)this._htHeader["Manufacturer name"]].Trim();
									ccsvData.cEWS_KIT.strMfrPartNo = array[(int)this._htHeader["Manufacturer Part number"]].Trim();
									ccsvData.cEWS_KIT.strMfrSerialNo = array[(int)this._htHeader["Manufacturer Serial number"]].Trim();
									ccsvData.cEWS_KIT.strMfdYear = array[(int)this._htHeader["MANUFACTURED_YEAR"]].Trim();
									ccsvData.cEWS_KIT.strInstalledEquipModel = array[(int)this._htHeader["Installed Equipment Model"]].Trim();
									ccsvData.cEWS_KIT.strFreeProperty1 = array[(int)this._htHeader["Free Property 1"]].Trim();
									ccsvData.cEWS_KIT.strFreeProperty2 = array[(int)this._htHeader["Free Property 2"]].Trim();
									ccsvData.cEWS_KIT.strFreeProperty3 = array[(int)this._htHeader["Free Property 3"]].Trim();
									this._cCsvDatas.Add(ccsvData);
								}
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Wrong format: " + ex.Message);
							return;
						}
					}
				}
				this.SetGridInfo(this._htHeader, list);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000DCA0 File Offset: 0x0000BEA0
		public void ReadFile_EQ(string filePath)
		{
			this._cCsvDatas.Clear();
			this._htHeader.Clear();
			Path.GetFileNameWithoutExtension(filePath);
			Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			List<string> list = new List<string>();
			using (StreamReader streamReader = new StreamReader(stream, Encoding.Default))
			{
				string item = string.Empty;
				while ((item = streamReader.ReadLine()) != null)
				{
					list.Add(item);
				}
			}
			if (list.Count != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					string[] array = list[i].Trim().Split(new char[]
					{
						','
					});
					if (i == 0)
					{
						for (int j = 0; j < array.Length; j++)
						{
							this._htHeader[array[j].Trim()] = j;
						}
					}
					else
					{
						if (this._htHeader.Count == 0)
						{
							break;
						}
						if (this._htHeader.Count != array.Length)
						{
							MessageBox.Show("Contents contains ','");
							break;
						}
						CCsvData ccsvData = new CCsvData();
						try
						{
							ccsvData.cCommonVal = new CCommonVal();
							ccsvData.cCommonVal.strPeriod = array[(int)this._htHeader["PERIOD"]].Trim();
							if (!(ccsvData.cCommonVal.strPeriod == ""))
							{
								ccsvData.cCommonVal.strPlantCode = array[(int)this._htHeader["PLANT_CODE"]].Trim();
								ccsvData.cCommonVal.strOwnership = array[(int)this._htHeader["OWNERSHIP"]].Trim();
								ccsvData.cCommonVal.strSTDivName = array[(int)this._htHeader["ST_DIVISION"]].Trim();
								if (!int.TryParse(array[(int)this._htHeader["GOBM_ASSET_NUMBER"]], out ccsvData.cCommonVal.iGobmAssetNumber))
								{
									ccsvData.cCommonVal.iGobmAssetNumber = 0;
								}
								ccsvData.cCommonVal.strOsatCodifiedId = array[(int)this._htHeader["OSAT_CODIFIED_ID_NAME"]].Trim();
								ccsvData.cCommonVal.strOsatCodifiedSn = array[(int)this._htHeader["OSAT_CODIFIED_SN"]].Trim();
								ccsvData.cCommonVal.strLocation = array[(int)this._htHeader["OSAT_CODIFIED_SN"]].Trim();
								ccsvData.cCommonVal.strConditionStatus = array[(int)this._htHeader["STATUS"]].Trim();
								ccsvData.cCommonVal.dtLastStatusUpDate = DateTime.Parse(array[(int)this._htHeader["LAST_STATUS_UPDATE_DATE"]]);
								ccsvData.cCommonVal.strIncommChkReportNo = array[(int)this._htHeader["Incoming check report number"]].Trim();
								ccsvData.cCommonVal.strRemark = array[(int)this._htHeader["REMARK"]].Trim();
								ccsvData.cCommonVal.strHwType = array[(int)this._htHeader["EQUIPMENT_TPYE"]].Trim().ToUpper();
								ccsvData.cCommonVal.dtRecvDate = DateTime.Parse(array[(int)this._htHeader["CONSIGNMENT_DATE"]].Trim());
								ccsvData.cEQ = new CEQ();
								ccsvData.cEQ.strActivity = array[(int)this._htHeader["ACTIVITY"]].Trim();
								ccsvData.cEQ.strEquipmentType = array[(int)this._htHeader["EQUIPMENT_TPYE"]].Trim();
								ccsvData.cEQ.strStGroup = array[(int)this._htHeader["ST_GROUP"]].Trim();
								ccsvData.cEQ.strMfgBrand = array[(int)this._htHeader["MANUFACTURER_BRAND"]].Trim();
								ccsvData.cEQ.strModel = array[(int)this._htHeader["MODEL"]].Trim();
								ccsvData.cEQ.strSerialNo = array[(int)this._htHeader["SERIAL_NUMBER"]].Trim();
								ccsvData.cEQ.dtMfgYear = DateTime.Parse(array[(int)this._htHeader["MANUFACTURED_YEAR"]].Trim());
								ccsvData.cEQ.strLocAreaDescr = array[(int)this._htHeader["LOCATION_AREA_DESCR"]].Trim();
								ccsvData.cEQ.dtConsignmentDate = DateTime.Parse(array[(int)this._htHeader["CONSIGNMENT_DATE"]].Trim());
								ccsvData.cEQ.strPackageDescr = array[(int)this._htHeader["PACKAGE_DESCR"]].Trim();
								this._cCsvDatas.Add(ccsvData);
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Wrong format: " + ex.Message);
							return;
						}
					}
				}
				this.SetGridInfo(this._htHeader, list);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000E254 File Offset: 0x0000C454
		public void UpdateInfo(string dataType, List<CCsvData> cCsvDatas)
		{
			this._instance._barPrograss = new BarPrograss();
			this._instance._barPrograss.progress_labelheader_set("Loading..");
			this._instance._barPrograss.setMax(cCsvDatas.Count);
			this._instance._barPrograss.setValue(1);
			this._instance._thread = new Thread(new ThreadStart(this._instance.BarPrograssView));
			this._instance._thread.Start();
			try
			{
				uint num = <PrivateImplementationDetails>.ComputeStringHash(dataType);
				if (num <= 2424387085U)
				{
					if (num <= 640541426U)
					{
						if (num != 600578307U)
						{
							if (num != 622880297U)
							{
								if (num != 640541426U)
								{
									goto IL_3F7;
								}
								if (!(dataType == "EWS_PIB"))
								{
									goto IL_3F7;
								}
							}
							else
							{
								if (!(dataType == "EWS_KIT"))
								{
									goto IL_3F7;
								}
								goto IL_33F;
							}
						}
						else
						{
							if (!(dataType == "EQ"))
							{
								goto IL_3F7;
							}
							goto IL_39B;
						}
					}
					else if (num != 1753135230U)
					{
						if (num != 2287356014U)
						{
							if (num != 2424387085U)
							{
								goto IL_3F7;
							}
							if (!(dataType == "FT_DK"))
							{
								goto IL_3F7;
							}
							goto IL_3F7;
						}
						else
						{
							if (!(dataType == "FT_SK"))
							{
								goto IL_3F7;
							}
							goto IL_3F7;
						}
					}
					else
					{
						if (!(dataType == "FT_CK"))
						{
							goto IL_3F7;
						}
						goto IL_3F7;
					}
				}
				else if (num <= 3095967907U)
				{
					if (num != 2911414098U)
					{
						if (num != 2959299417U)
						{
							if (num != 3095967907U)
							{
								goto IL_3F7;
							}
							if (!(dataType == "EWS_PT"))
							{
								goto IL_3F7;
							}
							goto IL_2E0;
						}
						else
						{
							if (!(dataType == "FT_HS"))
							{
								goto IL_3F7;
							}
							goto IL_3F7;
						}
					}
					else
					{
						if (!(dataType == "EWS_PC"))
						{
							goto IL_3F7;
						}
						using (List<CCsvData>.Enumerator enumerator = cCsvDatas.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								CCsvData ccsvData = enumerator.Current;
								CCommonVal cCommonVal = ccsvData.cCommonVal;
								CEWS_PC cEWS_PC = ccsvData.cEWS_PC;
								if (cEWS_PC != null)
								{
									this._instance.UpdateInfo_FromCsv(dataType, cCommonVal, cEWS_PC);
									this._instance._barPrograss.progress_increase();
								}
							}
							goto IL_3F7;
						}
					}
				}
				else if (num != 3357361797U)
				{
					if (num != 3496771605U)
					{
						if (num != 3614214938U)
						{
							goto IL_3F7;
						}
						if (!(dataType == "FT_LB"))
						{
							goto IL_3F7;
						}
						goto IL_3F7;
					}
					else
					{
						if (!(dataType == "FT_LK"))
						{
							goto IL_3F7;
						}
						goto IL_3F7;
					}
				}
				else
				{
					if (!(dataType == "FT_DUT"))
					{
						goto IL_3F7;
					}
					goto IL_3F7;
				}
				using (List<CCsvData>.Enumerator enumerator = cCsvDatas.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CCsvData ccsvData2 = enumerator.Current;
						CCommonVal cCommonVal2 = ccsvData2.cCommonVal;
						CEWS_PIB cEWS_PIB = ccsvData2.cEWS_PIB;
						if (cEWS_PIB != null)
						{
							this._instance.UpdateInfo_FromCsv(dataType, cCommonVal2, cEWS_PIB);
							this._instance._barPrograss.progress_increase();
						}
					}
					goto IL_3F7;
				}
				IL_2E0:
				using (List<CCsvData>.Enumerator enumerator = cCsvDatas.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CCsvData ccsvData3 = enumerator.Current;
						CCommonVal cCommonVal3 = ccsvData3.cCommonVal;
						CEWS_PT cEWS_PT = ccsvData3.cEWS_PT;
						if (cEWS_PT != null)
						{
							this._instance.UpdateInfo_FromCsv(dataType, cCommonVal3, cEWS_PT);
							this._instance._barPrograss.progress_increase();
						}
					}
					goto IL_3F7;
				}
				IL_33F:
				using (List<CCsvData>.Enumerator enumerator = cCsvDatas.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CCsvData ccsvData4 = enumerator.Current;
						CCommonVal cCommonVal4 = ccsvData4.cCommonVal;
						CEWS_KIT cEWS_KIT = ccsvData4.cEWS_KIT;
						if (cEWS_KIT != null)
						{
							this._instance.UpdateInfo_FromCsv(dataType, cCommonVal4, cEWS_KIT);
							this._instance._barPrograss.progress_increase();
						}
					}
					goto IL_3F7;
				}
				IL_39B:
				foreach (CCsvData ccsvData5 in cCsvDatas)
				{
					CCommonVal cCommonVal5 = ccsvData5.cCommonVal;
					CEQ cEQ = ccsvData5.cEQ;
					if (cEQ != null)
					{
						this._instance.UpdateInfo_FromCsv(dataType, cCommonVal5, cEQ);
						this._instance._barPrograss.progress_increase();
					}
				}
				IL_3F7:
				Thread.Sleep(10);
				if (this._instance._barPrograss != null)
				{
					this._instance._barPrograss._ischeck = true;
				}
				this._instance._barPrograss = null;
				MessageBox.Show("Update Completed");
				base.Close();
			}
			catch (Exception)
			{
				Thread.Sleep(10);
				if (this._instance._barPrograss != null)
				{
					this._instance._barPrograss._ischeck = true;
				}
				this._instance._barPrograss = null;
			}
		}

		// Token: 0x0400008A RID: 138
		private string _dataType = string.Empty;

		// Token: 0x0400008B RID: 139
		private string _filePath = string.Empty;

		// Token: 0x0400008C RID: 140
		private HccSTReportModule _instance;

		// Token: 0x0400008D RID: 141
		private List<CCsvData> _cCsvDatas;

		// Token: 0x0400008E RID: 142
		private Hashtable _htHeader;
	}
}
