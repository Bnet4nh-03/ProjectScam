using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
	// Token: 0x02000026 RID: 38
	public partial class _2DList : Form
	{
		// Token: 0x06000090 RID: 144 RVA: 0x00005C50 File Offset: 0x00003E50
		public _2DList(FactorySettings factorySettings, string userID)
		{
			this._factorySettings = factorySettings;
			this._userID = userID;
			this.InitializeComponent();
			this.initGrid();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00005CAC File Offset: 0x00003EAC
		private void initGrid()
		{
			this.grid2DList.ColumnsCount = 14;
			this.grid2DList.RowsCount = 1;
			this.grid2DList.FixedRows = 1;
			this.grid2DList.Columns[0].Width = 30;
			this.grid2DList[0, 0] = new GridInfo.ColHeader("No.");
			this.grid2DList.Columns[1].Width = 50;
			this.grid2DList[0, 1] = new GridInfo.ColHeader("Check");
			this.grid2DList.Columns[2].Width = 180;
			this.grid2DList[0, 2] = new GridInfo.ColHeader("SN");
			this.grid2DList.Columns[3].Width = 70;
			this.grid2DList[0, 3] = new GridInfo.ColHeader("Status");
			this.grid2DList.Columns[4].Width = 60;
			this.grid2DList[0, 4] = new GridInfo.ColHeader("Config");
			this.grid2DList.Columns[5].Width = 60;
			this.grid2DList[0, 5] = new GridInfo.ColHeader("Dcc");
			this.grid2DList.Columns[6].Width = 60;
			this.grid2DList[0, 6] = new GridInfo.ColHeader("Product");
			this.grid2DList.Columns[7].Width = 150;
			this.grid2DList[0, 7] = new GridInfo.ColHeader("Test Station");
			this.grid2DList.Columns[8].Width = 150;
			this.grid2DList[0, 8] = new GridInfo.ColHeader("Station ID");
			this.grid2DList.Columns[9].Width = 150;
			this.grid2DList[0, 9] = new GridInfo.ColHeader("SW Version");
			this.grid2DList.Columns[10].Width = 150;
			this.grid2DList[0, 10] = new GridInfo.ColHeader("Start Time");
			this.grid2DList.Columns[11].Width = 150;
			this.grid2DList[0, 11] = new GridInfo.ColHeader("Stop Time");
			this.grid2DList.Columns[12].Width = 150;
			this.grid2DList[0, 12] = new GridInfo.ColHeader("Fail Tests");
			this.grid2DList.Columns[13].Width = 150;
			this.grid2DList[0, 13] = new GridInfo.ColHeader("Failing");
			this.gridInfo.SetColumnCellColor(this.grid2DList, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00005FB4 File Offset: 0x000041B4
		private DataSet queryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._factorySettings._urlServer + "CIMitarWebService/CIMitarWS.asmx";
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

		// Token: 0x06000093 RID: 147 RVA: 0x0000602C File Offset: 0x0000422C
		private UnitData getSN_Info(string sType, string sInputSN)
		{
			UnitData unitData = new UnitData();
			try
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetUnitData]  @type  = '",
					sType,
					"', @sn  = '",
					sInputSN.Trim(),
					"'"
				});
				DataSet dataSet = this.queryCall(sQuery);
				if (dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
				{
					return null;
				}
				unitData.UnitID = dataSet.Tables[0].Rows[0]["id"].ToString();
				unitData.SN = dataSet.Tables[0].Rows[0]["sn"].ToString();
				unitData.Status = dataSet.Tables[0].Rows[0]["status"].ToString();
				unitData.Product = dataSet.Tables[0].Rows[0]["product"].ToString();
				unitData.Test_station_name = dataSet.Tables[0].Rows[0]["test_station_name"].ToString();
				unitData.Station_id = dataSet.Tables[0].Rows[0]["station_id"].ToString();
				unitData.Sw_version = dataSet.Tables[0].Rows[0]["sw_version"].ToString();
				unitData.StartTime = dataSet.Tables[0].Rows[0]["start_time"].ToString();
				unitData.StopTime = dataSet.Tables[0].Rows[0]["stop_time"].ToString();
				unitData.Failing_tests = dataSet.Tables[0].Rows[0]["failing_tests"].ToString();
				unitData.Failure_message = dataSet.Tables[0].Rows[0]["failure_message"].ToString();
				unitData.CheckInFlag = dataSet.Tables[0].Rows[0]["checkinflag"].ToString();
				unitData.LotID = dataSet.Tables[0].Rows[0]["lotid"].ToString();
				unitData.Dcc = dataSet.Tables[0].Rows[0]["dcc"].ToString();
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				return null;
			}
			return unitData;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006354 File Offset: 0x00004554
		private void cmd_In_Search_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.openFileDialog.ShowDialog() == DialogResult.OK)
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Loading Data....");
					this._barPrograss.setValue(0);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					this.serialList.Clear();
					string fileName = this.openFileDialog.FileName;
					string safeFileName = this.openFileDialog.SafeFileName;
					string text = string.Empty;
					StreamReader streamReader = File.OpenText(fileName);
					while ((text = streamReader.ReadLine()) != null && text.Length != 0)
					{
						string[] array = text.Split(new char[]
						{
							','
						});
						if (array.Length > 1)
						{
							if (this._barPrograss != null)
							{
								this._barPrograss.setMax(100);
								this._barPrograss.setValue(100);
								Thread.Sleep(100);
								this._barPrograss._ischeck = true;
								this._barPrograss = null;
							}
							this.serialList.Clear();
							MessageBox.Show(safeFileName + " is wrong format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							break;
						}
						this.serialList.Add(array[0]);
					}
					streamReader.Close();
					this.refreshGrid(false);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					this._barPrograss._ischeck = true;
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006538 File Offset: 0x00004738
		private void refreshGrid(bool bRfresh)
		{
			bool flag = false;
			this._UnitDataList.Clear();
			if (this.serialList.Count != 0)
			{
				for (int i = 0; i < this.serialList.Count; i++)
				{
					UnitData sn_Info = this.getSN_Info("REQUEST", this.serialList[i]);
					if (sn_Info == null)
					{
						flag = false;
						if (this._barPrograss != null)
						{
							this._barPrograss.setMax(100);
							this._barPrograss.setValue(100);
							Thread.Sleep(100);
							this._barPrograss._ischeck = true;
							this._barPrograss = null;
						}
						MessageBox.Show(this.serialList[i] + " invalid S/N Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this._UnitDataList.Clear();
						break;
					}
					this._UnitDataList.Add(sn_Info);
					flag = true;
				}
				if (flag)
				{
					if (!bRfresh)
					{
						this.grid2DList.RowsCount = 1;
					}
					if (!bRfresh)
					{
						for (int j = 0; j < this._UnitDataList.Count; j++)
						{
							this.grid2DList.Rows.Insert(j + 1);
							this.grid2DList[j + 1, 0] = new Cell((j + 1).ToString());
							this.grid2DList[j + 1, 1] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
							this.grid2DList[j + 1, 2] = new Cell(this._UnitDataList[j].SN);
							this.grid2DList[j + 1, 5] = new Cell(this._UnitDataList[j].Dcc);
							this.grid2DList[j + 1, 4] = new Cell(this._UnitDataList[j].LotID);
							this.grid2DList[j + 1, 6] = new Cell(this._UnitDataList[j].Product);
							this.grid2DList[j + 1, 8] = new Cell(this._UnitDataList[j].Station_id);
							this.grid2DList[j + 1, 3] = new Cell(this._UnitDataList[j].Status);
							this.grid2DList[j + 1, 9] = new Cell(this._UnitDataList[j].Sw_version);
							this.grid2DList[j + 1, 7] = new Cell(this._UnitDataList[j].Test_station_name);
							this.grid2DList[j + 1, 10] = new Cell(this._UnitDataList[j].StartTime);
							this.grid2DList[j + 1, 11] = new Cell(this._UnitDataList[j].StopTime);
							this.grid2DList[j + 1, 12] = new Cell(this._UnitDataList[j].Failure_message);
							this.grid2DList[j + 1, 13] = new Cell(this._UnitDataList[j].Failing_tests);
						}
					}
					else
					{
						for (int k = 0; k < this._UnitDataList.Count; k++)
						{
							this.grid2DList[k + 1, 2].Value = this._UnitDataList[k].SN;
							this.grid2DList[k + 1, 5].Value = this._UnitDataList[k].Dcc;
							this.grid2DList[k + 1, 4].Value = this._UnitDataList[k].LotID;
							this.grid2DList[k + 1, 6].Value = this._UnitDataList[k].Product;
							this.grid2DList[k + 1, 8].Value = this._UnitDataList[k].Station_id;
							this.grid2DList[k + 1, 3].Value = this._UnitDataList[k].Status;
							this.grid2DList[k + 1, 9].Value = this._UnitDataList[k].Sw_version;
							this.grid2DList[k + 1, 7].Value = this._UnitDataList[k].Test_station_name;
							this.grid2DList[k + 1, 10].Value = this._UnitDataList[k].StartTime;
							this.grid2DList[k + 1, 11].Value = this._UnitDataList[k].StopTime;
							this.grid2DList[k + 1, 12].Value = this._UnitDataList[k].Failure_message;
							this.grid2DList[k + 1, 13].Value = this._UnitDataList[k].Failing_tests;
						}
					}
					this.grid2DList.AutoSizeCells();
					int num = 0;
					for (int l = 0; l < this.grid2DList.ColumnsCount; l++)
					{
						num += this.grid2DList.Columns[l].Width;
					}
					this.grid2DList.Width = num + 10;
					this.grid2DList.Height = this.grid2DList.Rows[0].Height * this.grid2DList.RowsCount + 10;
				}
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00006AE0 File Offset: 0x00004CE0
		private void cmd_In_Apply_Click(object sender, EventArgs e)
		{
			if (this._UnitDataList.Count == 0)
			{
				return;
			}
			try
			{
				CommentForm commentForm = new CommentForm();
				string comment = string.Empty;
				if (commentForm.ShowDialog() == DialogResult.Yes)
				{
					comment = commentForm._sComment;
				}
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Request Updating....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				for (int i = 0; i < this._UnitDataList.Count; i++)
				{
					if ((bool)this.grid2DList[i + 1, 1].Value)
					{
						this._UnitDataList[i].Status = "REQUEST";
						bool flag = this.SetCheckInOut(this._UnitDataList[i], comment, false);
						if (flag)
						{
							this.grid2DList[i + 1, 1].Value = false;
						}
						else
						{
							if (this._barPrograss != null)
							{
								this._barPrograss.setMax(100);
								this._barPrograss.setValue(100);
								Thread.Sleep(100);
								this._barPrograss._ischeck = true;
								this._barPrograss = null;
								break;
							}
							break;
						}
					}
				}
				this.refreshGrid(true);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					this._barPrograss._ischeck = true;
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006CC0 File Offset: 0x00004EC0
		private bool SetCheckInOut(UnitData unit, string comment, bool bDialog)
		{
			if (unit.SN == string.Empty)
			{
				MessageBox.Show("SN is not exist.", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (!(unit.SN != string.Empty))
			{
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					this._barPrograss._ischeck = true;
					this._barPrograss = null;
				}
				return false;
			}
			string sQuery = string.Concat(new string[]
			{
				"EXEC CIMitar_Factory.dbo.USP_ESI_SetUnitData_FA  @unitid  = '",
				unit.UnitID,
				"', @sn  = '",
				unit.SN,
				"', @status  = '",
				unit.Status,
				"', @product  = '",
				unit.Product,
				"', @test_station_name  = '",
				unit.Test_station_name,
				"', @station_id  = '",
				unit.Station_id,
				"', @comment  = '",
				comment,
				"', @userid  = '",
				this._userID,
				"'"
			});
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet == null || dataSet.Tables.Count <= 0)
			{
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					this._barPrograss._ischeck = true;
					this._barPrograss = null;
				}
				MessageBox.Show(unit.SN + " Request is failed. please cotact to TFA team", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					this._barPrograss._ischeck = true;
					this._barPrograss = null;
				}
				MessageBox.Show(unit.SN + " Request is failed. please cotact to TFA team", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			if (dataSet.Tables[0].Rows[0][0].ToString().Trim().ToUpper().CompareTo("OK") == 0)
			{
				if (bDialog)
				{
					MessageBox.Show(unit.SN + " " + unit.Status + " Completed", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				return true;
			}
			if (this._barPrograss != null)
			{
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				this._barPrograss._ischeck = true;
				this._barPrograss = null;
			}
			MessageBox.Show(unit.SN + " " + dataSet.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return false;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00006FCC File Offset: 0x000051CC
		private void cmd_In_Apply_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006FF8 File Offset: 0x000051F8
		private void cmd_In_Apply_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00007024 File Offset: 0x00005224
		private void cmd_In_Search_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.LoadExcel_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00007050 File Offset: 0x00005250
		private void cmd_In_Search_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.LoadExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000707A File Offset: 0x0000527A
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00007088 File Offset: 0x00005288
		private void cbAll_Click(object sender, EventArgs e)
		{
			if (this.cbAll.Checked)
			{
				if (this.grid2DList.Rows.Count > 1)
				{
					for (int i = 1; i < this.grid2DList.Rows.Count; i++)
					{
						this.grid2DList[i, 1].Value = true;
					}
					return;
				}
			}
			else if (this.grid2DList.Rows.Count > 1)
			{
				for (int j = 1; j < this.grid2DList.Rows.Count; j++)
				{
					this.grid2DList[j, 1].Value = false;
				}
			}
		}

		// Token: 0x04000103 RID: 259
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x04000104 RID: 260
		private FactorySettings _factorySettings;

		// Token: 0x04000105 RID: 261
		private List<string> serialList = new List<string>();

		// Token: 0x04000106 RID: 262
		private List<UnitData> _UnitDataList = new List<UnitData>();

		// Token: 0x04000107 RID: 263
		private string _userID = string.Empty;

		// Token: 0x04000108 RID: 264
		private Thread _thread;

		// Token: 0x04000109 RID: 265
		private BarPrograss _barPrograss;
	}
}
