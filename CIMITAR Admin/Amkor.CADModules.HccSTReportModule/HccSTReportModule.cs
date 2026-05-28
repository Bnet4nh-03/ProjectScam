using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;
using Amkor.CADModules.HccSTReportModule.Properties;
using Amkor.CADModules.HccSTReportModule.SubForms;
using Amkor.CADModules.HccSTReportModule.SubForms.TabPages;
using ATDFW.Base.FrameWork;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.HccSTReportModule
{
	// Token: 0x02000003 RID: 3
	public partial class HccSTReportModule : BaseWinView
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public HccSTReportModule()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://testweb.amkor.co.kr/";
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this.InitializeComponent();
			this._cimitarUser._id = "dehlee";
			this._cimitarUser._badgeNo = "372463";
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020D4 File Offset: 0x000002D4
		public HccSTReportModule(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002128 File Offset: 0x00000328
		private void HccSTReportModule_Load(object sender, EventArgs e)
		{
			HccSTReportModule._instance = this;
			this._cComm = new CCommon(this._factorySetting._urlServer);
			this._cReportCtrl = new CReportCtrl();
			this.InitGridCell();
			this.SetPages();
			this.Init();
			this.ClearItems(false);
			this._iNowYear = DateTime.Now.Year;
			this._iNowWeek = WWDateManager.getworkweek(DateTime.Now.AddDays(-7.0), out this._iNowYear);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021B0 File Offset: 0x000003B0
		private void combo_Factory_SelectionChangeCommitted(object sender, EventArgs e)
		{
			this.ClearItems(true);
			if (this.combo_Factory.SelectedItem != null)
			{
				string a = this.combo_Factory.SelectedItem.ToString();
				if (a == "K3")
				{
					this.combo_PlantCode.SelectedIndex = 0;
					return;
				}
				if (a == "K5")
				{
					this.combo_PlantCode.SelectedIndex = 1;
				}
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002215 File Offset: 0x00000415
		private void combo_Category_SelectionChangeCommitted(object sender, EventArgs e)
		{
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002218 File Offset: 0x00000418
		private void combo_HwType_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.combo_HwType.SelectedItem != null)
			{
				string text = this.combo_HwType.SelectedItem.ToString();
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
				if (num <= 1841083372U)
				{
					if (num <= 1034062681U)
					{
						if (num != 245539861U)
						{
							if (num != 1034062681U)
							{
								return;
							}
							if (!(text == "CHANGE KIT"))
							{
								return;
							}
							this._hwTypeNo = 3;
							return;
						}
						else if (!(text == "PROBE CARD"))
						{
							return;
						}
					}
					else if (num != 1041414835U)
					{
						if (num != 1841083372U)
						{
							return;
						}
						if (!(text == "SOCKET"))
						{
							return;
						}
						this._hwTypeNo = 2;
						return;
					}
					else
					{
						if (!(text == "SLK"))
						{
							return;
						}
						this._hwTypeNo = 5;
						return;
					}
				}
				else if (num <= 2836036577U)
				{
					if (num != 2129096889U)
					{
						if (num != 2836036577U)
						{
							return;
						}
						if (!(text == "LOAD BOARD"))
						{
							return;
						}
					}
					else
					{
						if (!(text == "PROBER"))
						{
							return;
						}
						this._hwTypeNo = 7;
						return;
					}
				}
				else if (num != 2975113710U)
				{
					if (num != 4043086390U)
					{
						if (num != 4068083344U)
						{
							return;
						}
						if (!(text == "PIB BOARD"))
						{
							return;
						}
					}
					else
					{
						if (!(text == "TESTER"))
						{
							return;
						}
						this._hwTypeNo = 8;
						return;
					}
				}
				else if (!(text == "DUT BOARD"))
				{
					return;
				}
				this._hwTypeNo = 1;
				return;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002367 File Offset: 0x00000567
		private void pb_Search_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Search.Image = Resources.TableSearch_Down;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000237C File Offset: 0x0000057C
		private void pb_Search_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_Search.Image = Resources.TableSearch;
			if (this.combo_Factory.SelectedItem == null)
			{
				MessageBox.Show("Select Factory");
				return;
			}
			if (this.combo_HwType.SelectedItem == null)
			{
				MessageBox.Show("Select Hardware Type");
				return;
			}
			this.ClearItems(false);
			if (this.tb_Barcode.Text != "")
			{
				this._barcode = this.tb_Barcode.Text;
				if (this.GetInfo(this._barcode) == 1)
				{
					MessageBox.Show("The Barcode is not in DB");
					return;
				}
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002418 File Offset: 0x00000618
		private void tb_Barcode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Convert.ToInt32(e.KeyChar) == 13)
			{
				if (this.combo_Factory.SelectedItem == null)
				{
					MessageBox.Show("Select Factory");
					return;
				}
				if (this.combo_HwType.SelectedItem == null)
				{
					MessageBox.Show("Select Hardware Type");
					return;
				}
				this.ClearItems(false);
				if (this.tb_Barcode.Text != "")
				{
					this._barcode = this.tb_Barcode.Text;
					if (this.GetInfo(this._barcode) == 1)
					{
						MessageBox.Show("The Barcode is not in DB");
						return;
					}
				}
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000024B0 File Offset: 0x000006B0
		private void pb_Update_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Update.Image = Resources.TableSave_Down;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000024C4 File Offset: 0x000006C4
		private void pb_Update_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_Update.Image = Resources.TableSave;
			if (this._tempByBarcode == null)
			{
				MessageBox.Show("No Info");
				return;
			}
			if (this.combo_DataType.SelectedItem == null)
			{
				MessageBox.Show("Select DataType");
				return;
			}
			string dataType = this.combo_DataType.SelectedItem.ToString();
			this.UpdateInfo(dataType);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002526 File Offset: 0x00000726
		private void pb_Modify_MouseUp(object sender, MouseEventArgs e)
		{
			new ReportList().ShowDialog();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002534 File Offset: 0x00000734
		private void combo_DataType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.combo_DataType.SelectedItem != null)
			{
				string typeData = this.combo_DataType.SelectedItem.ToString();
				this.SetTypeData(typeData);
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002568 File Offset: 0x00000768
		private void tabCtrl_Report_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.tabCtrl_Report.SelectedIndex;
			if (selectedIndex == -1)
			{
				return;
			}
			this.combo_DataType.SelectedIndex = selectedIndex;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002592 File Offset: 0x00000792
		private void pb_Export_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Export.Image = Resources.SaveExcel_Down;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000025A4 File Offset: 0x000007A4
		private void pb_Export_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_Export.Image = Resources.SaveExcel;
			if (this.combo_Factory.SelectedItem != null)
			{
				string a = this.combo_Factory.SelectedItem.ToString();
				if (a == "K3")
				{
					this.combo_PlantCode.SelectedIndex = 0;
				}
				else if (a == "K5")
				{
					this.combo_PlantCode.SelectedIndex = 1;
				}
				string text = this.combo_PlantCode.SelectedItem.ToString();
				using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
				{
					if (folderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
					{
						this._cReportCtrl.Init(folderBrowserDialog.SelectedPath);
						this._cReportCtrl.GetData(text);
						this._cReportCtrl.MakeCSV(text);
						MessageBox.Show("Success to save CSV");
					}
				}
				return;
			}
			MessageBox.Show("Select Factory");
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000026A0 File Offset: 0x000008A0
		private void pb_FileSearch_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_FileSearch.Image = Resources.FileOpen_Down;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000026B4 File Offset: 0x000008B4
		private void pb_FileSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_FileSearch.Image = Resources.FileOpen;
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Title = "Search files";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Filter = "csv (*.csv)|*.csv";
			openFileDialog.FilterIndex = 2;
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string fileName = openFileDialog.FileName;
			string text = string.Empty;
			text = this.GetDataType(fileName);
			if (text != "")
			{
				new UploadList(text, fileName).ShowDialog();
				return;
			}
			MessageBox.Show("The file can't be identified");
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002760 File Offset: 0x00000960
		private void InitGridCell()
		{
			Color p_Color = Color.FromArgb(223, 230, 233);
			Color color = Color.FromArgb(130, 179, 237);
			new RectangleBorder(new BorderLine(color), new BorderLine(color));
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader.BackColor = color;
			columnHeader.Border = RectangleBorder.NoBorder;
			columnHeader.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this._cell_Header = new SourceGrid.Cells.Views.ColumnHeader();
			this._cell_Header.Background = columnHeader;
			this._cell_Header.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			Color white = Color.White;
			new RectangleBorder(new BorderLine(white), new BorderLine(p_Color));
			this._cell_Body1 = new Cell();
			this._cell_Body1.Background = new BackgroundSolid(white);
			this._cell_Body1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_Body1.Border = RectangleBorder.NoBorder;
			this._cell_Body1.ForeColor = Color.Black;
			this._checkBox_Normal1 = new CheckBoxBackColorAlternate(white, white);
			this._checkBox_Normal1.Border = RectangleBorder.NoBorder;
			Color color2 = Color.FromArgb(247, 240, 214);
			this._cell_Body2 = new Cell();
			this._cell_Body2.Background = new BackgroundSolid(color2);
			this._cell_Body2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_Body2.Border = RectangleBorder.NoBorder;
			this._cell_Body2.ForeColor = Color.Black;
			this._checkBox_Normal2 = new CheckBoxBackColorAlternate(color2, color2);
			this._checkBox_Normal2.Border = RectangleBorder.NoBorder;
			Color color3 = Color.FromArgb(243, 156, 18);
			this._cell_Body_OnFlag = new Cell();
			this._cell_Body_OnFlag.Background = new BackgroundSolid(color3);
			this._cell_Body_OnFlag.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_Body_OnFlag.Border = RectangleBorder.NoBorder;
			this._cell_Body_OnFlag.ForeColor = Color.Black;
			this._checkBox_OnFlag = new CheckBoxBackColorAlternate(color3, color3);
			this._checkBox_OnFlag.Border = RectangleBorder.NoBorder;
			Color color4 = Color.FromArgb(189, 195, 199);
			this._cell_Body_OnFlag_History = new Cell();
			this._cell_Body_OnFlag_History.Background = new BackgroundSolid(color4);
			this._cell_Body_OnFlag_History.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_Body_OnFlag_History.Border = RectangleBorder.NoBorder;
			this._cell_Body_OnFlag_History.ForeColor = Color.Black;
			this._checkBox_OnFlag_History = new CheckBoxBackColorAlternate(color4, color4);
			this._checkBox_OnFlag_History.Border = RectangleBorder.NoBorder;
			Color backcolor = Color.FromArgb(231, 76, 60);
			this._cell_Body_OnHold = new Cell();
			this._cell_Body_OnHold.Background = new BackgroundSolid(backcolor);
			this._cell_Body_OnHold.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_Body_OnHold.Border = RectangleBorder.NoBorder;
			this._cell_Body_OnHold.ForeColor = Color.Black;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002A6C File Offset: 0x00000C6C
		private void ClearItems(bool isUpdate)
		{
			this._barcode = string.Empty;
			this._tempByBarcode = null;
			this.dtPicker_RecvDate.Value = DateTime.Now;
			this.combo_DataType.SelectedIndex = 0;
			this.combo_Ownership.SelectedIndex = 0;
			this.l_DevFamily.Text = "";
			this.tb_Period.Text = "";
			this.tb_STDivName.Text = "";
			this.tb_STDivHwId.Text = "";
			this.tb_GobmAssetNo.Text = "";
			this.tb_OsatCodId.Text = "";
			this.tb_OsatCodSN.Text = "";
			this.tb_CondStatus.Text = "";
			this.dtPicker_LastStUpDate.Value = DateTime.Now;
			this.tb_TransTrackingNo.Text = "";
			this.tb_IncommChkReportNo.Text = "";
			this.tb_Remark.Text = "";
			this._cCommonVal = null;
			this._cEWS_PC = null;
			this._cEWS_PIB = null;
			this._cEWS_PT = null;
			this._cEWS_KIT = null;
			this._cFT_LB = null;
			this._cFT_CK = null;
			this._cFT_SK = null;
			this._cFT_HS = null;
			this._cFT_DUT = null;
			this._cFT_LK = null;
			this._cFT_DK = null;
			this._cEQ = null;
			if (isUpdate)
			{
				this._tab_EWS_PC.ClearItems();
				this._tab_EWS_PIB.ClearItems();
				this._tab_EWS_PT.ClearItems();
				this._tab_EWS_KIT.ClearItems();
				this._tab_FT_LB.ClearItems();
				this._tab_FT_CK.ClearItems();
				this._tab_FT_SK.ClearItems();
				this._tab_FT_HS.ClearItems();
				this._tab_FT_DUT.ClearItems();
				this._tab_FT_LK.ClearItems();
				this._tab_FT_DK.ClearItems();
				this._tab_EQ.ClearItems();
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002C58 File Offset: 0x00000E58
		private void SetPages()
		{
			foreach (object obj in this.tabCtrl_Report.TabPages)
			{
				HccSTReportModule.UnloadTabpage((TabPage)obj);
			}
			this.tabCtrl_Report.TabPages.Clear();
			this._tab_EWS_PC = new Tab_EWS_PC("EWS_PC");
			this.tabCtrl_Report.TabPages.Add(this._tab_EWS_PC);
			this._tab_EWS_PIB = new Tab_EWS_PIB("EWS_PIB");
			this.tabCtrl_Report.TabPages.Add(this._tab_EWS_PIB);
			this._tab_EWS_PT = new Tab_EWS_PT("EWS_PT");
			this.tabCtrl_Report.TabPages.Add(this._tab_EWS_PT);
			this._tab_EWS_KIT = new Tab_EWS_KIT("EWS_KIT");
			this.tabCtrl_Report.TabPages.Add(this._tab_EWS_KIT);
			this._tab_FT_LB = new Tab_FT_LB("FT_LB");
			this.tabCtrl_Report.TabPages.Add(this._tab_FT_LB);
			this._tab_FT_CK = new Tab_FT_CK("FT_CK");
			this.tabCtrl_Report.TabPages.Add(this._tab_FT_CK);
			this._tab_FT_SK = new Tab_FT_SK("FT_SK");
			this.tabCtrl_Report.TabPages.Add(this._tab_FT_SK);
			this._tab_FT_HS = new Tab_FT_HS("FT_HS");
			this.tabCtrl_Report.TabPages.Add(this._tab_FT_HS);
			this._tab_FT_DUT = new Tab_FT_DUT("FT_DUT");
			this.tabCtrl_Report.TabPages.Add(this._tab_FT_DUT);
			this._tab_FT_LK = new Tab_FT_LK("FT_LK");
			this.tabCtrl_Report.TabPages.Add(this._tab_FT_LK);
			this._tab_FT_DK = new Tab_FT_DK("FT_DK");
			this.tabCtrl_Report.TabPages.Add(this._tab_FT_DK);
			this._tab_EQ = new Tab_EQ("EQ");
			this.tabCtrl_Report.TabPages.Add(this._tab_EQ);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002E8C File Offset: 0x0000108C
		private void Init()
		{
			DataSet dataSet = new DataSet();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ST_Report_INIT_Ctrl] @flag = 'INIT'";
			dataSet = this._cComm.QueryCall(sQuery);
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					text = dataSet.Tables[0].Rows[i]["plant_code"].ToString();
					text2 = dataSet.Tables[0].Rows[i]["ownership"].ToString();
					text3 = dataSet.Tables[0].Rows[i]["hardware_type"].ToString();
					text4 = dataSet.Tables[0].Rows[i]["data_type"].ToString();
				}
			}
			foreach (string item in text.Split(new char[]
			{
				';'
			}))
			{
				this.combo_PlantCode.Items.Add(item);
			}
			this.combo_PlantCode.SelectedIndex = 0;
			foreach (string item2 in text2.Split(new char[]
			{
				';'
			}))
			{
				this.combo_Ownership.Items.Add(item2);
			}
			this.combo_Ownership.SelectedIndex = 0;
			foreach (string item3 in text3.Split(new char[]
			{
				';'
			}))
			{
				this.combo_HwType.Items.Add(item3);
			}
			foreach (string item4 in text4.Split(new char[]
			{
				';'
			}))
			{
				this.combo_DataType.Items.Add(item4);
			}
			this.combo_Factory.Items.Clear();
			this.combo_Factory.Items.Add("K3");
			this.combo_Factory.Items.Add("K5");
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000311C File Offset: 0x0000131C
		private int GetInfo(string barcode)
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_ST_Report_INIT_Ctrl] @flag = 'GET_HWINFO', @barcode = '",
				barcode,
				"', @hwtype_no = ",
				this._hwTypeNo.ToString(),
				", @factory = ",
				this.combo_Factory.Text
			});
			DataSet dataSet = this._cComm.QueryCall(sQuery);
			string text = string.Empty;
			DateTime now = DateTime.Now;
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			string text5 = string.Empty;
			string text6 = string.Empty;
			DateTime now2 = DateTime.Now;
			if (dataSet.Tables.Count > 0)
			{
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					return 1;
				}
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					text = dataSet.Tables[0].Rows[i]["device_family"].ToString();
					if (!DateTime.TryParse(dataSet.Tables[0].Rows[i]["receive_date"].ToString(), out now))
					{
						now = DateTime.Now;
					}
					text2 = dataSet.Tables[0].Rows[i]["hardware_type"].ToString();
					if (text2 == null)
					{
						text2 = "";
					}
					this._tempByBarcode = new CTemp();
					if (!int.TryParse(dataSet.Tables[0].Rows[i]["touch_down_count"].ToString(), out this._tempByBarcode.iTouchDownCnt))
					{
						this._tempByBarcode.iTouchDownCnt = 0;
					}
					this._tempByBarcode.strPackage = dataSet.Tables[0].Rows[i]["package"].ToString();
					this._tempByBarcode.strNumOfSites = dataSet.Tables[0].Rows[i]["no_of_sites"].ToString();
					this._tempByBarcode.strEquipModel = dataSet.Tables[0].Rows[i]["equip_model"].ToString();
					if (this._hwTypeNo == 1)
					{
						text3 = dataSet.Tables[0].Rows[i]["assetno"].ToString();
						if (text3 == null)
						{
							text3 = "";
						}
						text4 = dataSet.Tables[0].Rows[i]["assetOther"].ToString();
						if (text4 == null)
						{
							text4 = "";
						}
						text5 = dataSet.Tables[0].Rows[i]["bdno"].ToString();
						if (text5 == "" || text5 == null)
						{
							text5 = "N/A";
						}
					}
					if (!DateTime.TryParse(dataSet.Tables[0].Rows[i]["Lastdate"].ToString(), out now2))
					{
						now2 = DateTime.Now;
					}
					text6 = dataSet.Tables[0].Rows[i]["statusdesc"].ToString();
				}
				this.l_DevFamily.Text = text;
				this.tb_GobmAssetNo.Text = text3;
				this.tb_OsatCodSN.Text = text5;
				this.dtPicker_RecvDate.Value = now;
				this.combo_HwType.SelectedIndex = this.combo_HwType.FindString(text2);
				this.dtPicker_LastStUpDate.Value = now2;
				this.tb_TransTrackingNo.Text = text4;
				this.tb_CondStatus.Text = text6;
				if (dataSet.Tables[1].Rows.Count > 0)
				{
					this._cCommonVal = new CCommonVal();
					for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
					{
						this._cCommonVal.strPeriod = dataSet.Tables[1].Rows[j]["period"].ToString();
						this._cCommonVal.strPlantCode = dataSet.Tables[1].Rows[j]["plant_code"].ToString();
						this._cCommonVal.strOwnership = dataSet.Tables[1].Rows[j]["ownership"].ToString();
						this._cCommonVal.strHwType = dataSet.Tables[1].Rows[j]["hardware_type"].ToString();
						this._cCommonVal.strSTDivName = dataSet.Tables[1].Rows[j]["st_division_name"].ToString();
						this._cCommonVal.strSTDivHwId = dataSet.Tables[1].Rows[j]["st_division_hw_id"].ToString();
						this._cCommonVal.iGobmAssetNumber = int.Parse(dataSet.Tables[1].Rows[j]["gobm_asset_number"].ToString());
						this._cCommonVal.strOsatCodifiedId = dataSet.Tables[1].Rows[j]["osat_codified_id"].ToString();
						this._cCommonVal.strOsatCodifiedSn = dataSet.Tables[1].Rows[j]["osat_codified_sn"].ToString();
						this._cCommonVal.strConditionStatus = text6;
						this._cCommonVal.dtLastStatusUpDate = DateTime.Parse(dataSet.Tables[1].Rows[j]["last_status_update_date"].ToString());
						this._cCommonVal.strDevFamily = dataSet.Tables[1].Rows[j]["device_family"].ToString();
						this._cCommonVal.strLocation = dataSet.Tables[1].Rows[j]["location"].ToString();
						this._cCommonVal.dtRecvDate = DateTime.Parse(dataSet.Tables[1].Rows[j]["receive_date"].ToString());
						this._cCommonVal.strTransTrackingNo = dataSet.Tables[1].Rows[j]["transfer_tracking_no"].ToString();
						this._cCommonVal.strIncommChkReportNo = dataSet.Tables[1].Rows[j]["incomming_check_report_number"].ToString();
						this._cCommonVal.strRemark = dataSet.Tables[1].Rows[j]["remark"].ToString();
						this._cCommonVal.strDataType = dataSet.Tables[1].Rows[j]["datatype"].ToString();
						this._cCommonVal.iDataTypeId = int.Parse(dataSet.Tables[1].Rows[j]["datatype_id"].ToString());
						this.GetTypeData(this._cCommonVal.strDataType, this._cCommonVal.iDataTypeId);
					}
					this._isNewHw = false;
				}
				else
				{
					this._isNewHw = true;
				}
				if (this._cCommonVal == null)
				{
					this.SetCommonData(this._isNewHw);
					this.SetTypeData("");
				}
				else
				{
					this.SetCommonData(this._isNewHw);
					this.SetTypeData(this._cCommonVal.strDataType);
				}
			}
			return 0;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003970 File Offset: 0x00001B70
		private void GetTypeData(string dataType, int dataTypeId)
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ST_Report_INIT_Ctrl] @flag = 'GET_TYPEDATA', @sel_datatype = '" + dataType + "', @sel_datatype_id = " + dataTypeId.ToString();
			DataSet dataSet = this._cComm.QueryCall(sQuery);
			if (dataSet.Tables[0].Rows.Count > 0)
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
								this._cEWS_PIB = new CEWS_PIB();
								for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
								{
									this._cEWS_PIB.strNumOfSites = dataSet.Tables[0].Rows[i]["no_of_sites"].ToString();
									this._cEWS_PIB.strPcbId = dataSet.Tables[0].Rows[i]["pcb_id"].ToString();
									this._cEWS_PIB.strPcbRevision = dataSet.Tables[0].Rows[i]["pcb_revision"].ToString();
									this._cEWS_PIB.strMfrName = dataSet.Tables[0].Rows[i]["manufacturer_name"].ToString();
									this._cEWS_PIB.strMfrPartNo = dataSet.Tables[0].Rows[i]["manufacturer_part_number"].ToString();
									this._cEWS_PIB.strTesterModel = dataSet.Tables[0].Rows[i]["tester_model"].ToString();
								}
								return;
							}
							else
							{
								if (!(dataType == "EWS_KIT"))
								{
									return;
								}
								this._cEWS_KIT = new CEWS_KIT();
								for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
								{
									this._cEWS_KIT.strMfrName = dataSet.Tables[0].Rows[j]["manufacturer_name"].ToString();
									this._cEWS_KIT.strMfrPartNo = dataSet.Tables[0].Rows[j]["manufacturer_part_number"].ToString();
									this._cEWS_KIT.strMfrSerialNo = dataSet.Tables[0].Rows[j]["manufacturer_serial_number"].ToString();
									this._cEWS_KIT.strMfdYear = dataSet.Tables[0].Rows[j]["manufactured_year"].ToString();
									this._cEWS_KIT.strInstalledEquipModel = dataSet.Tables[0].Rows[j]["installed_equipment_model"].ToString();
									this._cEWS_KIT.strFreeProperty1 = dataSet.Tables[0].Rows[j]["free_property1"].ToString();
									this._cEWS_KIT.strFreeProperty2 = dataSet.Tables[0].Rows[j]["free_property2"].ToString();
									this._cEWS_KIT.strFreeProperty3 = dataSet.Tables[0].Rows[j]["free_property3"].ToString();
								}
								return;
							}
						}
						else
						{
							if (!(dataType == "EQ"))
							{
								return;
							}
							this._cEQ = new CEQ();
							for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
							{
								this._cEQ.strActivity = dataSet.Tables[0].Rows[k]["activity"].ToString();
								this._cEQ.strEquipmentType = dataSet.Tables[0].Rows[k]["equipment_type"].ToString();
								this._cEQ.strStGroup = dataSet.Tables[0].Rows[k]["st_group"].ToString();
								this._cEQ.strMfgBrand = dataSet.Tables[0].Rows[k]["manufacturer_brand"].ToString();
								this._cEQ.strModel = dataSet.Tables[0].Rows[k]["model"].ToString();
								this._cEQ.strSerialNo = dataSet.Tables[0].Rows[k]["serial_number"].ToString();
								this._cEQ.dtMfgYear = DateTime.Parse(dataSet.Tables[0].Rows[k]["manufactured_year"].ToString());
								this._cEQ.strLocAreaDescr = dataSet.Tables[0].Rows[k]["location_area_descr"].ToString();
								this._cEQ.dtConsignmentDate = DateTime.Parse(dataSet.Tables[0].Rows[k]["consignment_date"].ToString());
								this._cEQ.strPackageDescr = dataSet.Tables[0].Rows[k]["package_descr"].ToString();
							}
						}
					}
					else if (num != 1753135230U)
					{
						if (num != 2287356014U)
						{
							if (num != 2424387085U)
							{
								return;
							}
							if (!(dataType == "FT_DK"))
							{
								return;
							}
							this._cFT_DK = new CFT_DK();
							for (int l = 0; l < dataSet.Tables[0].Rows.Count; l++)
							{
								this._cFT_DK.strMfrName = dataSet.Tables[0].Rows[l]["manufacturer_name"].ToString();
								this._cFT_DK.strMfrPartNo = dataSet.Tables[0].Rows[l]["manufacturer_part_number"].ToString();
								this._cFT_DK.strMfrSerialNo = dataSet.Tables[0].Rows[l]["manufacturer_serial_number"].ToString();
								this._cFT_DK.strMfdYear = dataSet.Tables[0].Rows[l]["manufactured_year"].ToString();
								this._cFT_DK.strInstalledEquipModel = dataSet.Tables[0].Rows[l]["installed_equipment_model"].ToString();
								this._cFT_DK.strFreeProperty1 = dataSet.Tables[0].Rows[l]["free_property1"].ToString();
								this._cFT_DK.strFreeProperty2 = dataSet.Tables[0].Rows[l]["free_property2"].ToString();
								this._cFT_DK.strFreeProperty3 = dataSet.Tables[0].Rows[l]["free_property3"].ToString();
							}
							return;
						}
						else
						{
							if (!(dataType == "FT_SK"))
							{
								return;
							}
							this._cFT_SK = new CFT_SK();
							for (int m = 0; m < dataSet.Tables[0].Rows.Count; m++)
							{
								this._cFT_SK.strSockPartNo = dataSet.Tables[0].Rows[m]["socket_part_number"].ToString();
								this._cFT_SK.strPackage = dataSet.Tables[0].Rows[m]["package"].ToString();
								this._cFT_SK.strCapableTemp = dataSet.Tables[0].Rows[m]["capable_temperature"].ToString();
								this._cFT_SK.iPinInsert = int.Parse(dataSet.Tables[0].Rows[m]["pin_insertion"].ToString());
								this._cFT_SK.iPinLifeSpan = int.Parse(dataSet.Tables[0].Rows[m]["pin_lifespan"].ToString());
								this._cFT_SK.iSockHousinInsert = int.Parse(dataSet.Tables[0].Rows[m]["socket_housing_insertion"].ToString());
								this._cFT_SK.iSockHousinLifespan = int.Parse(dataSet.Tables[0].Rows[m]["socket_housing_lifespan"].ToString());
								this._cFT_SK.strSockMfrName = dataSet.Tables[0].Rows[m]["socket_manufacturer_name"].ToString();
								this._cFT_SK.strSockMfrPartNo = dataSet.Tables[0].Rows[m]["socket_manufacturer_part_number"].ToString();
								this._cFT_SK.strPinMfr = dataSet.Tables[0].Rows[m]["pin_manufacturer"].ToString();
								this._cFT_SK.strPinPartNo = dataSet.Tables[0].Rows[m]["pin_part_number"].ToString();
								this._cFT_SK.strHdlModel = dataSet.Tables[0].Rows[m]["handler_model"].ToString();
								this._cFT_SK.strTesterModel = dataSet.Tables[0].Rows[m]["tester_model"].ToString();
								this._cFT_SK.strSkSupplier = dataSet.Tables[0].Rows[m]["sk_supplier"].ToString();
							}
							return;
						}
					}
					else
					{
						if (!(dataType == "FT_CK"))
						{
							return;
						}
						this._cFT_CK = new CFT_CK();
						for (int n = 0; n < dataSet.Tables[0].Rows.Count; n++)
						{
							this._cFT_CK.strNumOfSites = dataSet.Tables[0].Rows[n]["no_of_sites"].ToString();
							this._cFT_CK.strPackage = dataSet.Tables[0].Rows[n]["package"].ToString();
							this._cFT_CK.strHdlModel = dataSet.Tables[0].Rows[n]["handler_model"].ToString();
							this._cFT_CK.strKitMfrName = dataSet.Tables[0].Rows[n]["kit_manufacturer_name"].ToString();
							this._cFT_CK.strMfrPartNo = dataSet.Tables[0].Rows[n]["manufacturer_part_number"].ToString();
							this._cFT_CK.strKitSupplier = dataSet.Tables[0].Rows[n]["kit_supplier"].ToString();
						}
						return;
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
								return;
							}
							if (!(dataType == "EWS_PT"))
							{
								return;
							}
							this._cEWS_PT = new CEWS_PT();
							for (int num2 = 0; num2 < dataSet.Tables[0].Rows.Count; num2++)
							{
								this._cEWS_PT.strMfrName = dataSet.Tables[0].Rows[num2]["manufacturer_name"].ToString();
								this._cEWS_PT.strMfrPartNo = dataSet.Tables[0].Rows[num2]["manufacturer_part_number"].ToString();
								this._cEWS_PT.strMfrSerialNo = dataSet.Tables[0].Rows[num2]["manufacturer_serial_number"].ToString();
								this._cEWS_PT.strMfdYear = dataSet.Tables[0].Rows[num2]["manufactured_year"].ToString();
								this._cEWS_PT.iPinCounter = int.Parse(dataSet.Tables[0].Rows[num2]["pin_counter"].ToString());
								this._cEWS_PT.strRfOptAvail = dataSet.Tables[0].Rows[num2]["rf_options_available"].ToString();
								this._cEWS_PT.strCompTesterModel = dataSet.Tables[0].Rows[num2]["compatible_tester_model"].ToString();
								this._cEWS_PT.strColdTestOptAvail = dataSet.Tables[0].Rows[num2]["cold_test_options_available"].ToString();
							}
							return;
						}
						else
						{
							if (!(dataType == "FT_HS"))
							{
								return;
							}
							this._cFT_HS = new CFT_HS();
							for (int num3 = 0; num3 < dataSet.Tables[0].Rows.Count; num3++)
							{
								this._cFT_HS.strTesterModel = dataSet.Tables[0].Rows[num3]["tester_model"].ToString();
								this._cFT_HS.strHandSetPartNo = dataSet.Tables[0].Rows[num3]["hand_set_part_number"].ToString();
								this._cFT_HS.strPackage = dataSet.Tables[0].Rows[num3]["package"].ToString();
								this._cFT_HS.strHandSetMfrName = dataSet.Tables[0].Rows[num3]["hand_set_manufacturer_name"].ToString();
								this._cFT_HS.strHandSetMfrPartNo = dataSet.Tables[0].Rows[num3]["hand_set_manufacturer_part_number"].ToString();
							}
							return;
						}
					}
					else
					{
						if (!(dataType == "EWS_PC"))
						{
							return;
						}
						this._cEWS_PC = new CEWS_PC();
						for (int num4 = 0; num4 < dataSet.Tables[0].Rows.Count; num4++)
						{
							this._cEWS_PC.strWscsPkgDesc = dataSet.Tables[0].Rows[num4]["wscs_package_description"].ToString();
							this._cEWS_PC.strNumOfSites = dataSet.Tables[0].Rows[num4]["no_of_sites"].ToString();
							this._cEWS_PC.iNumOfPins = int.Parse(dataSet.Tables[0].Rows[num4]["no_of_pins"].ToString());
							this._cEWS_PC.strPinType = dataSet.Tables[0].Rows[num4]["pin_type"].ToString();
							this._cEWS_PC.strCapableTemp = dataSet.Tables[0].Rows[num4]["capable_temperature"].ToString();
							this._cEWS_PC.strProbeCardType = dataSet.Tables[0].Rows[num4]["probe_card_type"].ToString();
							this._cEWS_PC.strSeperPcbBoard = dataSet.Tables[0].Rows[num4]["seperate_pcb_board"].ToString();
							this._cEWS_PC.strPcbId = dataSet.Tables[0].Rows[num4]["pcb_id"].ToString();
							this._cEWS_PC.strProbeHeadId = dataSet.Tables[0].Rows[num4]["probe_head_id"].ToString();
							this._cEWS_PC.strPairedPcbId = dataSet.Tables[0].Rows[num4]["paired_pcb_id"].ToString();
							this._cEWS_PC.strMfrName = dataSet.Tables[0].Rows[num4]["manufacturer_name"].ToString();
							this._cEWS_PC.strMfrPartNo = dataSet.Tables[0].Rows[num4]["manufacturer_part_number"].ToString();
							this._cEWS_PC.strRepairSupplier = dataSet.Tables[0].Rows[num4]["repair_supplier"].ToString();
							this._cEWS_PC.strTesterModel = dataSet.Tables[0].Rows[num4]["tester_model"].ToString();
							this._cEWS_PC.iIncommTipLg = int.Parse(dataSet.Tables[0].Rows[num4]["incomming_tip_lg"].ToString());
							this._cEWS_PC.iIncommTipDia = int.Parse(dataSet.Tables[0].Rows[num4]["incomming_tip_dia"].ToString());
							this._cEWS_PC.iCurTipLg = int.Parse(dataSet.Tables[0].Rows[num4]["current_tip_lg"].ToString());
							this._cEWS_PC.iCurTipDia = int.Parse(dataSet.Tables[0].Rows[num4]["current_tip_dia"].ToString());
							this._cEWS_PC.iTouchDownCnt = int.Parse(dataSet.Tables[0].Rows[num4]["touch_down_count"].ToString());
							this._cEWS_PC.iAccumTouchDown = int.Parse(dataSet.Tables[0].Rows[num4]["accumulated_touch_down"].ToString());
							this._cEWS_PC.iMinTipLgSpec = int.Parse(dataSet.Tables[0].Rows[num4]["min_tip_lg_spec"].ToString());
							this._cEWS_PC.iMinTipDiaSpec = int.Parse(dataSet.Tables[0].Rows[num4]["min_tip_dia_spec"].ToString());
							this._cEWS_PC.iExpectTouchDown = int.Parse(dataSet.Tables[0].Rows[num4]["expection_touch_down"].ToString());
						}
						return;
					}
				}
				else if (num != 3357361797U)
				{
					if (num != 3496771605U)
					{
						if (num != 3614214938U)
						{
							return;
						}
						if (!(dataType == "FT_LB"))
						{
							return;
						}
						this._cFT_LB = new CFT_LB();
						for (int num5 = 0; num5 < dataSet.Tables[0].Rows.Count; num5++)
						{
							this._cFT_LB.strNumOfSites = dataSet.Tables[0].Rows[num5]["no_of_sites"].ToString();
							this._cFT_LB.strCapableTemp = dataSet.Tables[0].Rows[num5]["capable_temperature"].ToString();
							this._cFT_LB.strPackage = dataSet.Tables[0].Rows[num5]["package"].ToString();
							this._cFT_LB.strSockMfr = dataSet.Tables[0].Rows[num5]["socket_manufacturer"].ToString();
							this._cFT_LB.strSockPartNo = dataSet.Tables[0].Rows[num5]["socket_part_number"].ToString();
							this._cFT_LB.strPcbCode = dataSet.Tables[0].Rows[num5]["pcb_code"].ToString();
							this._cFT_LB.strPcbRevision = dataSet.Tables[0].Rows[num5]["pcb_revision"].ToString();
							this._cFT_LB.iAccumInsert = int.Parse(dataSet.Tables[0].Rows[num5]["accumulated_insertion"].ToString());
							this._cFT_LB.strTesterModel = dataSet.Tables[0].Rows[num5]["tester_model"].ToString();
							this._cFT_LB.strMfrName = dataSet.Tables[0].Rows[num5]["manufacturer_name"].ToString();
							this._cFT_LB.strMfrPartNo = dataSet.Tables[0].Rows[num5]["manufacturer_part_number"].ToString();
						}
						return;
					}
					else
					{
						if (!(dataType == "FT_LK"))
						{
							return;
						}
						this._cFT_LK = new CFT_LK();
						for (int num6 = 0; num6 < dataSet.Tables[0].Rows.Count; num6++)
						{
							this._cFT_LK.strNumOfSites = dataSet.Tables[0].Rows[num6]["no_of_sites"].ToString();
							this._cFT_LK.strSitePitch = dataSet.Tables[0].Rows[num6]["site_pitch"].ToString();
							this._cFT_LK.strHeadConfig = dataSet.Tables[0].Rows[num6]["head_config"].ToString();
							this._cFT_LK.strDirectHeater = dataSet.Tables[0].Rows[num6]["direct_heater"].ToString();
							this._cFT_LK.strHdlModel = dataSet.Tables[0].Rows[num6]["handler_model"].ToString();
							this._cFT_LK.strKitMfrName = dataSet.Tables[0].Rows[num6]["kit_manufacturer_name"].ToString();
							this._cFT_LK.strMfrPartNo = dataSet.Tables[0].Rows[num6]["manufacturer_part_number"].ToString();
							this._cFT_LK.strKitSupplier = dataSet.Tables[0].Rows[num6]["kit_supplier"].ToString();
						}
						return;
					}
				}
				else
				{
					if (!(dataType == "FT_DUT"))
					{
						return;
					}
					this._cFT_DUT = new CFT_DUT();
					for (int num7 = 0; num7 < dataSet.Tables[0].Rows.Count; num7++)
					{
						this._cFT_DUT.strPackage = dataSet.Tables[0].Rows[num7]["package"].ToString();
						this._cFT_DUT.strInstalledEquipModel = dataSet.Tables[0].Rows[num7]["installed_equipment_model"].ToString();
						this._cFT_DUT.strFreeProperty1 = dataSet.Tables[0].Rows[num7]["free_property1"].ToString();
						this._cFT_DUT.strFreeProperty2 = dataSet.Tables[0].Rows[num7]["free_property2"].ToString();
						this._cFT_DUT.strFreeProperty3 = dataSet.Tables[0].Rows[num7]["free_property3"].ToString();
						this._cFT_DUT.strBoardMfrName = dataSet.Tables[0].Rows[num7]["board_manufacturer_name"].ToString();
						this._cFT_DUT.strBoardMfrPartNo = dataSet.Tables[0].Rows[num7]["board_manufacturer_part_number"].ToString();
						this._cFT_DUT.strBoardSupplier = dataSet.Tables[0].Rows[num7]["board_supplier"].ToString();
					}
					return;
				}
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00005470 File Offset: 0x00003670
		private void SetCommonData(bool isNewHw)
		{
			if (isNewHw)
			{
				this.tb_Period.Text = this._iNowYear.ToString() + this._iNowWeek.ToString("00");
				if (this._hwTypeNo < 7)
				{
					this.tb_OsatCodId.Text = this.combo_PlantCode.Text + "_" + this._barcode;
					return;
				}
			}
			else
			{
				this.tb_Period.Text = this._cCommonVal.strPeriod;
				this.tb_STDivName.Text = this._cCommonVal.strSTDivName;
				this.tb_STDivHwId.Text = this._cCommonVal.strSTDivHwId;
				this.tb_GobmAssetNo.Text = this._cCommonVal.iGobmAssetNumber.ToString();
				this.tb_OsatCodId.Text = this._cCommonVal.strOsatCodifiedId;
				this.tb_OsatCodSN.Text = this._cCommonVal.strOsatCodifiedSn;
				this.tb_CondStatus.Text = this._cCommonVal.strConditionStatus;
				this.dtPicker_LastStUpDate.Value = this._cCommonVal.dtLastStatusUpDate;
				this.tb_TransTrackingNo.Text = this._cCommonVal.strTransTrackingNo;
				this.tb_IncommChkReportNo.Text = this._cCommonVal.strIncommChkReportNo;
				this.tb_Remark.Text = this._cCommonVal.strRemark;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000055D8 File Offset: 0x000037D8
		private void SetTypeData(string dataType)
		{
			if (dataType == "")
			{
				dataType = this.combo_DataType.SelectedItem.ToString();
			}
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
							this.tabCtrl_Report.SelectedIndex = 1;
							this._tab_EWS_PIB.SetInfo(this._tempByBarcode, this._cEWS_PIB);
							return;
						}
						else
						{
							if (!(dataType == "EWS_KIT"))
							{
								return;
							}
							this.tabCtrl_Report.SelectedIndex = 3;
							this._tab_EWS_KIT.SetInfo(this._tempByBarcode, this._cEWS_KIT);
							return;
						}
					}
					else
					{
						if (!(dataType == "EQ"))
						{
							return;
						}
						this.tabCtrl_Report.SelectedIndex = 11;
						this._tab_EQ.SetInfo(this._tempByBarcode, this._cEQ);
						return;
					}
				}
				else if (num != 1753135230U)
				{
					if (num != 2287356014U)
					{
						if (num != 2424387085U)
						{
							return;
						}
						if (!(dataType == "FT_DK"))
						{
							return;
						}
						this.tabCtrl_Report.SelectedIndex = 10;
						this._tab_FT_DK.SetInfo(this._tempByBarcode, this._cFT_DK);
						return;
					}
					else
					{
						if (!(dataType == "FT_SK"))
						{
							return;
						}
						this.tabCtrl_Report.SelectedIndex = 6;
						this._tab_FT_SK.SetInfo(this._tempByBarcode, this._cFT_SK);
						return;
					}
				}
				else
				{
					if (!(dataType == "FT_CK"))
					{
						return;
					}
					this.tabCtrl_Report.SelectedIndex = 5;
					this._tab_FT_CK.SetInfo(this._tempByBarcode, this._cFT_CK);
					return;
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
							return;
						}
						if (!(dataType == "EWS_PT"))
						{
							return;
						}
						this.tabCtrl_Report.SelectedIndex = 2;
						this._tab_EWS_PT.SetInfo(this._tempByBarcode, this._cEWS_PT);
						return;
					}
					else
					{
						if (!(dataType == "FT_HS"))
						{
							return;
						}
						this.tabCtrl_Report.SelectedIndex = 7;
						this._tab_FT_HS.SetInfo(this._tempByBarcode, this._cFT_HS);
						return;
					}
				}
				else
				{
					if (!(dataType == "EWS_PC"))
					{
						return;
					}
					this.tabCtrl_Report.SelectedIndex = 0;
					this._tab_EWS_PC.SetInfo(this._tempByBarcode, this._cEWS_PC);
					return;
				}
			}
			else if (num != 3357361797U)
			{
				if (num != 3496771605U)
				{
					if (num != 3614214938U)
					{
						return;
					}
					if (!(dataType == "FT_LB"))
					{
						return;
					}
					this.tabCtrl_Report.SelectedIndex = 4;
					this._tab_FT_LB.SetInfo(this._tempByBarcode, this._cFT_LB);
					return;
				}
				else
				{
					if (!(dataType == "FT_LK"))
					{
						return;
					}
					this.tabCtrl_Report.SelectedIndex = 9;
					this._tab_FT_LK.SetInfo(this._tempByBarcode, this._cFT_LK);
					return;
				}
			}
			else
			{
				if (!(dataType == "FT_DUT"))
				{
					return;
				}
				this.tabCtrl_Report.SelectedIndex = 8;
				this._tab_FT_DUT.SetInfo(this._tempByBarcode, this._cFT_DUT);
				return;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00005920 File Offset: 0x00003B20
		private void UpdateInfo(string dataType)
		{
			DataSet dataSet = null;
			string text = string.Empty;
			if (this._cCommonVal == null)
			{
				this._cCommonVal = new CCommonVal();
			}
			this._cCommonVal.strPeriod = this.tb_Period.Text;
			this._cCommonVal.strPlantCode = this.combo_PlantCode.Text;
			this._cCommonVal.strOwnership = this.combo_Ownership.SelectedItem.ToString();
			this._cCommonVal.strHwType = this.combo_HwType.SelectedItem.ToString();
			this._cCommonVal.strSTDivName = this.tb_STDivName.Text;
			this._cCommonVal.strSTDivHwId = this.tb_STDivHwId.Text;
			if (!int.TryParse(this.tb_GobmAssetNo.Text, out this._cCommonVal.iGobmAssetNumber))
			{
				this._cCommonVal.iGobmAssetNumber = 0;
			}
			this._cCommonVal.strOsatCodifiedId = this.tb_OsatCodId.Text;
			this._cCommonVal.strOsatCodifiedSn = this.tb_OsatCodSN.Text;
			this._cCommonVal.strConditionStatus = this.tb_CondStatus.Text;
			this._cCommonVal.dtLastStatusUpDate = this.dtPicker_LastStUpDate.Value;
			this._cCommonVal.strDevFamily = this.l_DevFamily.Text;
			this._cCommonVal.strLocation = this._barcode;
			this._cCommonVal.dtRecvDate = this.dtPicker_RecvDate.Value;
			this._cCommonVal.strTransTrackingNo = this.tb_TransTrackingNo.Text;
			this._cCommonVal.strIncommChkReportNo = this.tb_IncommChkReportNo.Text;
			this._cCommonVal.strRemark = this.tb_Remark.Text;
			string text2 = string.Empty;
			if (dataType.IndexOf("EWS") != -1)
			{
				text2 = "[USP_ST_Report_EWS_Ctrl]";
			}
			else if (dataType.IndexOf("EQ") != -1)
			{
				text2 = "[USP_ST_Report_ETC_Ctrl]";
			}
			else
			{
				text2 = "[USP_ST_Report_FT_Ctrl]";
			}
			text = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].",
				text2,
				" @flag = '",
				dataType,
				"', @location = '",
				this._cCommonVal.strLocation,
				"', @hardware_type = '",
				this._cCommonVal.strHwType,
				"', @receive_date = '",
				this._cCommonVal.dtRecvDate.ToString("yyyy-MM-dd"),
				"', @device_family = '",
				this._cCommonVal.strDevFamily,
				"', @period = '",
				this._cCommonVal.strPeriod,
				"', @plant_code = '",
				this._cCommonVal.strPlantCode,
				"', @ownership = '",
				this._cCommonVal.strOwnership,
				"', @st_devision_name = '",
				this._cCommonVal.strSTDivName,
				"', @st_devision_hw_id = '",
				this._cCommonVal.strSTDivHwId,
				"', @gobm_asset_number = '",
				this._cCommonVal.iGobmAssetNumber.ToString(),
				"', @osat_codified_id = '",
				this._cCommonVal.strOsatCodifiedId,
				"', @osat_codified_sn = '",
				this._cCommonVal.strOsatCodifiedSn,
				"', @condition_status = '",
				this._cCommonVal.strConditionStatus,
				"', @last_status_update_date = '",
				this._cCommonVal.dtLastStatusUpDate.ToString("yyyy-MM-dd"),
				"', @transfer_tracking_no = '",
				this._cCommonVal.strTransTrackingNo,
				"', @incomming_check_report_number = '",
				this._cCommonVal.strIncommChkReportNo,
				"', @remark = '",
				this._cCommonVal.strRemark,
				"', @user_id = '",
				this._cimitarUser._id,
				"', @user_badge_no = '",
				this._cimitarUser._badgeNo,
				"'"
			});
			uint num = <PrivateImplementationDetails>.ComputeStringHash(dataType);
			if (num <= 2424387085U)
			{
				if (num <= 640541426U)
				{
					if (num != 600578307U)
					{
						if (num != 622880297U)
						{
							if (num == 640541426U)
							{
								if (dataType == "EWS_PIB")
								{
									CEWS_PIB cews_PIB = this._tab_EWS_PIB.InputInfos();
									if (cews_PIB == null)
									{
										return;
									}
									string str = string.Empty;
									str = string.Concat(new string[]
									{
										", @no_of_sites = '",
										cews_PIB.strNumOfSites,
										"', @pcb_id = '",
										cews_PIB.strPcbId,
										"', @pcb_revision = '",
										cews_PIB.strPcbRevision,
										"', @manufacturer_name = '",
										cews_PIB.strMfrName,
										"', @manufacturer_part_number = '",
										cews_PIB.strMfrPartNo,
										"', @tester_model = '",
										cews_PIB.strTesterModel,
										"'"
									});
									text += str;
									dataSet = this._cComm.QueryCall(text);
								}
							}
						}
						else if (dataType == "EWS_KIT")
						{
							CEWS_KIT cews_KIT = this._tab_EWS_KIT.InputInfos();
							if (cews_KIT == null)
							{
								return;
							}
							string str2 = string.Empty;
							str2 = string.Concat(new string[]
							{
								", @manufacturer_name = '",
								cews_KIT.strMfrName,
								"', @manufacturer_part_number = '",
								cews_KIT.strMfrPartNo,
								"', @manufacturer_serial_number = '",
								cews_KIT.strMfrSerialNo,
								"', @manufactured_year = '",
								cews_KIT.strMfdYear.ToString(),
								"', @installed_equipment_model = '",
								cews_KIT.strInstalledEquipModel,
								"', @free_property1 = '",
								cews_KIT.strFreeProperty1,
								"', @free_property2 = '",
								cews_KIT.strFreeProperty2,
								"', @free_property3 = '",
								cews_KIT.strFreeProperty3,
								"'"
							});
							text += str2;
							dataSet = this._cComm.QueryCall(text);
						}
					}
					else if (dataType == "EQ")
					{
						CEQ ceq = this._tab_EQ.InputInfos();
						if (ceq == null)
						{
							return;
						}
						string str3 = string.Empty;
						str3 = string.Concat(new string[]
						{
							", @activity = '",
							ceq.strActivity,
							"', @equipment_type = '",
							ceq.strEquipmentType,
							"', @st_group = '",
							ceq.strStGroup,
							"', @manufacturer_brand = '",
							ceq.strMfgBrand,
							"', @model = '",
							ceq.strModel,
							"', @serial_number = '",
							ceq.strSerialNo,
							"', @manufactured_year = '",
							ceq.dtMfgYear.ToString("yyyy-MM-dd"),
							"', @location_area_descr = '",
							ceq.strLocAreaDescr,
							"', @consignment_date = '",
							ceq.dtConsignmentDate.ToString("yyyy-MM-dd"),
							"', @package_descr = '",
							ceq.strPackageDescr,
							"'"
						});
						text += str3;
						dataSet = this._cComm.QueryCall(text);
					}
				}
				else if (num != 1753135230U)
				{
					if (num != 2287356014U)
					{
						if (num == 2424387085U)
						{
							if (dataType == "FT_DK")
							{
								CFT_DK cft_DK = this._tab_FT_DK.InputInfos();
								if (cft_DK == null)
								{
									return;
								}
								string str4 = string.Empty;
								str4 = string.Concat(new string[]
								{
									", @manufacturer_name = '",
									cft_DK.strMfrName,
									"', @manufacturer_part_number = '",
									cft_DK.strMfrPartNo,
									"', @manufacturer_serial_number = '",
									cft_DK.strMfrSerialNo,
									"', @manufactured_year = '",
									cft_DK.strMfdYear.ToString(),
									"', @installed_equipment_model = '",
									cft_DK.strInstalledEquipModel,
									"', @free_property1 = '",
									cft_DK.strFreeProperty1,
									"', @free_property2 = '",
									cft_DK.strFreeProperty2,
									"', @free_property3 = '",
									cft_DK.strFreeProperty3,
									"'"
								});
								text += str4;
								dataSet = this._cComm.QueryCall(text);
							}
						}
					}
					else if (dataType == "FT_SK")
					{
						CFT_SK cft_SK = this._tab_FT_SK.InputInfos();
						if (cft_SK == null)
						{
							return;
						}
						string str5 = string.Empty;
						str5 = string.Concat(new string[]
						{
							", @socket_part_number = '",
							cft_SK.strSockPartNo,
							"', @package = '",
							cft_SK.strPackage,
							"', @capable_temperature = '",
							cft_SK.strCapableTemp,
							"', @pin_insertion = '",
							cft_SK.iPinInsert.ToString(),
							"', @pin_lifespan = '",
							cft_SK.iPinLifeSpan.ToString(),
							"', @socket_housing_insertion = '",
							cft_SK.iSockHousinInsert.ToString(),
							"', @socket_housing_lifespan = '",
							cft_SK.iSockHousinLifespan.ToString(),
							"', @socket_manufacturer_name = '",
							cft_SK.strSockMfrName,
							"', @socket_manufacturer_part_number = '",
							cft_SK.strSockMfrPartNo,
							"', @pin_manufacturer = '",
							cft_SK.strPinMfr,
							"', @pin_part_number = '",
							cft_SK.strPinPartNo,
							"', @handler_model = '",
							cft_SK.strHdlModel,
							"', @tester_model = '",
							cft_SK.strTesterModel,
							"', @sk_supplier = '",
							cft_SK.strSkSupplier,
							"'"
						});
						text += str5;
						dataSet = this._cComm.QueryCall(text);
					}
				}
				else if (dataType == "FT_CK")
				{
					CFT_CK cft_CK = this._tab_FT_CK.InputInfos();
					if (cft_CK == null)
					{
						return;
					}
					string str6 = string.Empty;
					str6 = string.Concat(new string[]
					{
						", @no_of_sites = '",
						cft_CK.strNumOfSites,
						"', @package = '",
						cft_CK.strPackage,
						"', @handler_model = '",
						cft_CK.strHdlModel,
						"', @kit_manufacturer_name = '",
						cft_CK.strKitMfrName,
						"', @manufacturer_part_number = '",
						cft_CK.strMfrPartNo,
						"', @kit_supplier = '",
						cft_CK.strKitSupplier,
						"'"
					});
					text += str6;
					dataSet = this._cComm.QueryCall(text);
				}
			}
			else if (num <= 3095967907U)
			{
				if (num != 2911414098U)
				{
					if (num != 2959299417U)
					{
						if (num == 3095967907U)
						{
							if (dataType == "EWS_PT")
							{
								CEWS_PT cews_PT = this._tab_EWS_PT.InputInfos();
								if (cews_PT == null)
								{
									return;
								}
								string str7 = string.Empty;
								str7 = string.Concat(new string[]
								{
									", @manufacturer_name = '",
									cews_PT.strMfrName,
									"', @manufacturer_part_number = '",
									cews_PT.strMfrPartNo,
									"', @manufacturer_serial_number = '",
									cews_PT.strMfrSerialNo,
									"', @manufactured_year = '",
									cews_PT.strMfdYear.ToString(),
									"', @pin_counter = '",
									cews_PT.iPinCounter.ToString(),
									"', @rf_options_available = '",
									cews_PT.strRfOptAvail,
									"', @compatible_tester_model = '",
									cews_PT.strCompTesterModel,
									"', @cold_test_options_available = '",
									cews_PT.strColdTestOptAvail,
									"'"
								});
								text += str7;
								dataSet = this._cComm.QueryCall(text);
							}
						}
					}
					else if (dataType == "FT_HS")
					{
						CFT_HS cft_HS = this._tab_FT_HS.InputInfos();
						if (cft_HS == null)
						{
							return;
						}
						string str8 = string.Empty;
						str8 = string.Concat(new string[]
						{
							", @tester_model = '",
							cft_HS.strTesterModel,
							"', @hand_set_part_number = '",
							cft_HS.strHandSetPartNo,
							"', @package = '",
							cft_HS.strPackage,
							"', @hand_set_manufacturer_name = '",
							cft_HS.strHandSetMfrName,
							"', @hand_set_manufacturer_part_number = '",
							cft_HS.strHandSetMfrPartNo,
							"'"
						});
						text += str8;
						dataSet = this._cComm.QueryCall(text);
					}
				}
				else if (dataType == "EWS_PC")
				{
					CEWS_PC cews_PC = this._tab_EWS_PC.InputInfos();
					if (cews_PC == null)
					{
						return;
					}
					string str9 = string.Empty;
					str9 = string.Concat(new string[]
					{
						", @wscs_package_description = '",
						cews_PC.strWscsPkgDesc,
						"', @no_of_sites = '",
						cews_PC.strNumOfSites,
						"', @no_of_pins = '",
						cews_PC.iNumOfPins.ToString(),
						"', @pin_type = '",
						cews_PC.strPinType,
						"', @capable_temperature = '",
						cews_PC.strCapableTemp,
						"', @probe_card_type = '",
						cews_PC.strProbeCardType,
						"', @seperate_pcb_board = '",
						cews_PC.strSeperPcbBoard,
						"', @pcb_id = '",
						cews_PC.strPcbId,
						"', @probe_head_id = '",
						cews_PC.strProbeHeadId,
						"', @paired_pcb_id = '",
						cews_PC.strPairedPcbId,
						"', @manufacturer_name = '",
						cews_PC.strMfrName,
						"', @manufacturer_part_number = '",
						cews_PC.strMfrPartNo,
						"', @repair_supplier = '",
						cews_PC.strRepairSupplier,
						"', @tester_model = '",
						cews_PC.strTesterModel,
						"', @prober_model = '",
						cews_PC.strProberModel,
						"', @incomming_tip_lg = '",
						cews_PC.iIncommTipLg.ToString(),
						"', @incomming_tip_dia = '",
						cews_PC.iIncommTipDia.ToString(),
						"', @current_tip_lg = '",
						cews_PC.iCurTipLg.ToString(),
						"', @current_tip_dia = '",
						cews_PC.iCurTipDia.ToString(),
						"', @touch_down_count = '",
						cews_PC.iTouchDownCnt.ToString(),
						"', @accumulated_touch_down = '",
						cews_PC.iAccumTouchDown.ToString(),
						"', @min_tip_lg_spec = '",
						cews_PC.iMinTipLgSpec.ToString(),
						"', @min_tip_dia_spec = '",
						cews_PC.iMinTipDiaSpec.ToString(),
						"', @expection_touch_down = '",
						cews_PC.iExpectTouchDown.ToString(),
						"'"
					});
					text += str9;
					dataSet = this._cComm.QueryCall(text);
				}
			}
			else if (num != 3357361797U)
			{
				if (num != 3496771605U)
				{
					if (num == 3614214938U)
					{
						if (dataType == "FT_LB")
						{
							CFT_LB cft_LB = this._tab_FT_LB.InputInfos();
							if (cft_LB == null)
							{
								return;
							}
							string str10 = string.Empty;
							str10 = string.Concat(new string[]
							{
								", @no_of_sites = '",
								cft_LB.strNumOfSites,
								"', @capable_temperature = '",
								cft_LB.strCapableTemp,
								"', @package = '",
								cft_LB.strPackage,
								"', @socket_manufacturer = '",
								cft_LB.strSockMfr,
								"', @socket_part_number = '",
								cft_LB.strSockPartNo,
								"', @pcb_code = '",
								cft_LB.strPcbCode,
								"', @pcb_revision = '",
								cft_LB.strPcbRevision,
								"', @accumulated_insertion = '",
								cft_LB.iAccumInsert.ToString(),
								"', @tester_model = '",
								cft_LB.strTesterModel,
								"', @manufacturer_name = '",
								cft_LB.strMfrName,
								"', @manufacturer_part_number = '",
								cft_LB.strMfrPartNo,
								"'"
							});
							text += str10;
							dataSet = this._cComm.QueryCall(text);
						}
					}
				}
				else if (dataType == "FT_LK")
				{
					CFT_LK cft_LK = this._tab_FT_LK.InputInfos();
					if (cft_LK == null)
					{
						return;
					}
					string str11 = string.Empty;
					str11 = string.Concat(new string[]
					{
						", @no_of_sites = '",
						cft_LK.strNumOfSites,
						"', @site_pitch = '",
						cft_LK.strSitePitch,
						"', @head_config = '",
						cft_LK.strHeadConfig,
						"', @direct_heater = '",
						cft_LK.strDirectHeater,
						"', @handler_model = '",
						cft_LK.strHdlModel,
						"', @kit_manufacturer_name = '",
						cft_LK.strKitMfrName,
						"', @manufacturer_part_number = '",
						cft_LK.strMfrPartNo,
						"', @kit_supplier = '",
						cft_LK.strKitSupplier,
						"'"
					});
					text += str11;
					dataSet = this._cComm.QueryCall(text);
				}
			}
			else if (dataType == "FT_DUT")
			{
				CFT_DUT cft_DUT = this._tab_FT_DUT.InputInfos();
				if (cft_DUT == null)
				{
					return;
				}
				string str12 = string.Empty;
				str12 = string.Concat(new string[]
				{
					", @package = '",
					cft_DUT.strPackage,
					"', @installed_equipment_model = '",
					cft_DUT.strInstalledEquipModel,
					"', @free_property1 = '",
					cft_DUT.strFreeProperty1,
					"', @free_property2 = '",
					cft_DUT.strFreeProperty2,
					"', @free_property3 = '",
					cft_DUT.strFreeProperty3,
					"', @board_manufacturer_name = '",
					cft_DUT.strBoardMfrName,
					"', @board_manufacturer_part_number = '",
					cft_DUT.strBoardMfrPartNo,
					"', @board_supplier = '",
					cft_DUT.strBoardSupplier,
					"'"
				});
				text += str12;
				dataSet = this._cComm.QueryCall(text);
			}
			int num2 = 0;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					num2 = int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
				}
			}
			if (num2 == 0)
			{
				MessageBox.Show("Success to Update");
				this.ClearItems(true);
				return;
			}
			MessageBox.Show("Fail to Update");
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00006BF8 File Offset: 0x00004DF8
		public void UpdateInfo_FromCsv(string dataType, CCommonVal commonVal, object data)
		{
			DataSet dataSet = null;
			string text = string.Empty;
			string text2 = string.Empty;
			if (dataType.IndexOf("EWS") != -1)
			{
				text2 = "[USP_ST_Report_EWS_Ctrl]";
			}
			else if (dataType.IndexOf("FT") != -1)
			{
				text2 = "[USP_ST_Report_FT_Ctrl]";
			}
			else
			{
				text2 = "[USP_ST_Report_ETC_Ctrl]";
			}
			text = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].",
				text2,
				" @flag = '",
				dataType,
				"', @location = '",
				commonVal.strLocation,
				"', @hardware_type = '",
				commonVal.strHwType,
				"', @receive_date = '",
				commonVal.dtRecvDate.ToString("yyyy-MM-dd"),
				"', @device_family = '",
				commonVal.strDevFamily,
				"', @period = '",
				commonVal.strPeriod,
				"', @plant_code = '",
				commonVal.strPlantCode,
				"', @ownership = '",
				commonVal.strOwnership,
				"', @st_devision_name = '",
				commonVal.strSTDivName,
				"', @st_devision_hw_id = '",
				commonVal.strSTDivHwId,
				"', @gobm_asset_number = '",
				commonVal.iGobmAssetNumber.ToString(),
				"', @osat_codified_id = '",
				commonVal.strOsatCodifiedId,
				"', @osat_codified_sn = '",
				commonVal.strOsatCodifiedSn,
				"', @condition_status = '",
				commonVal.strConditionStatus,
				"', @last_status_update_date = '",
				commonVal.dtLastStatusUpDate.ToString("yyyy-MM-dd"),
				"', @transfer_tracking_no = '",
				commonVal.strTransTrackingNo,
				"', @incomming_check_report_number = '",
				commonVal.strIncommChkReportNo,
				"', @remark = '",
				commonVal.strRemark,
				"', @user_id = '",
				this._cimitarUser._id,
				"', @user_badge_no = '",
				this._cimitarUser._badgeNo,
				"'"
			});
			uint num = <PrivateImplementationDetails>.ComputeStringHash(dataType);
			if (num <= 2424387085U)
			{
				if (num <= 640541426U)
				{
					if (num != 600578307U)
					{
						if (num != 622880297U)
						{
							if (num == 640541426U)
							{
								if (dataType == "EWS_PIB")
								{
									CEWS_PIB cews_PIB = (CEWS_PIB)data;
									if (cews_PIB == null)
									{
										return;
									}
									string str = string.Empty;
									str = string.Concat(new string[]
									{
										", @no_of_sites = '",
										cews_PIB.strNumOfSites,
										"', @pcb_id = '",
										cews_PIB.strPcbId,
										"', @pcb_revision = '",
										cews_PIB.strPcbRevision,
										"', @manufacturer_name = '",
										cews_PIB.strMfrName,
										"', @manufacturer_part_number = '",
										cews_PIB.strMfrPartNo,
										"', @tester_model = '",
										cews_PIB.strTesterModel,
										"'"
									});
									text += str;
									dataSet = this._cComm.QueryCall(text);
								}
							}
						}
						else if (dataType == "EWS_KIT")
						{
							CEWS_KIT cews_KIT = (CEWS_KIT)data;
							if (cews_KIT == null)
							{
								return;
							}
							string str2 = string.Empty;
							str2 = string.Concat(new string[]
							{
								", @manufacturer_name = '",
								cews_KIT.strMfrName,
								"', @manufacturer_part_number = '",
								cews_KIT.strMfrPartNo,
								"', @manufacturer_serial_number = '",
								cews_KIT.strMfrSerialNo,
								"', @manufactured_year = '",
								cews_KIT.strMfdYear.ToString(),
								"', @installed_equipment_model = '",
								cews_KIT.strInstalledEquipModel,
								"', @free_property1 = '",
								cews_KIT.strFreeProperty1,
								"', @free_property2 = '",
								cews_KIT.strFreeProperty2,
								"', @free_property3 = '",
								cews_KIT.strFreeProperty3,
								"'"
							});
							text += str2;
							dataSet = this._cComm.QueryCall(text);
						}
					}
					else if (dataType == "EQ")
					{
						CEQ ceq = (CEQ)data;
						if (ceq == null)
						{
							return;
						}
						string str3 = string.Empty;
						str3 = string.Concat(new string[]
						{
							", @activity = '",
							ceq.strActivity,
							"', @equipment_type = '",
							ceq.strEquipmentType,
							"', @st_group = '",
							ceq.strStGroup,
							"', @manufacturer_brand = '",
							ceq.strMfgBrand,
							"', @model = '",
							ceq.strModel,
							"', @serial_number = '",
							ceq.strSerialNo,
							"', @manufactured_year = '",
							ceq.dtMfgYear.ToString("yyyy-MM-dd"),
							"', @location_area_descr = '",
							ceq.strLocAreaDescr,
							"', @consignment_date = '",
							ceq.dtConsignmentDate.ToString("yyyy-MM-dd"),
							"', @package_descr = '",
							ceq.strPackageDescr,
							"'"
						});
						text += str3;
						dataSet = this._cComm.QueryCall(text);
					}
				}
				else if (num != 1753135230U)
				{
					if (num != 2287356014U)
					{
						if (num == 2424387085U)
						{
							if (dataType == "FT_DK")
							{
								CFT_DK cft_DK = (CFT_DK)data;
								if (cft_DK == null)
								{
									return;
								}
								string str4 = string.Empty;
								str4 = string.Concat(new string[]
								{
									", @manufacturer_name = '",
									cft_DK.strMfrName,
									"', @manufacturer_part_number = '",
									cft_DK.strMfrPartNo,
									"', @manufacturer_serial_number = '",
									cft_DK.strMfrSerialNo,
									"', @manufactured_year = '",
									cft_DK.strMfdYear.ToString(),
									"', @installed_equipment_model = '",
									cft_DK.strInstalledEquipModel,
									"', @free_property1 = '",
									cft_DK.strFreeProperty1,
									"', @free_property2 = '",
									cft_DK.strFreeProperty2,
									"', @free_property3 = '",
									cft_DK.strFreeProperty3,
									"'"
								});
								text += str4;
								dataSet = this._cComm.QueryCall(text);
							}
						}
					}
					else if (dataType == "FT_SK")
					{
						CFT_SK cft_SK = (CFT_SK)data;
						if (cft_SK == null)
						{
							return;
						}
						string str5 = string.Empty;
						str5 = string.Concat(new string[]
						{
							", @socket_part_number = '",
							cft_SK.strSockPartNo,
							"', @package = '",
							cft_SK.strPackage,
							"', @capable_temperature = '",
							cft_SK.strCapableTemp,
							"', @pin_insertion = '",
							cft_SK.iPinInsert.ToString(),
							"', @pin_lifespan = '",
							cft_SK.iPinLifeSpan.ToString(),
							"', @socket_housing_insertion = '",
							cft_SK.iSockHousinInsert.ToString(),
							"', @socket_housing_lifespan = '",
							cft_SK.iSockHousinLifespan.ToString(),
							"', @socket_manufacturer_name = '",
							cft_SK.strSockMfrName,
							"', @socket_manufacturer_part_number = '",
							cft_SK.strSockMfrPartNo,
							"', @pin_manufacturer = '",
							cft_SK.strPinMfr,
							"', @pin_part_number = '",
							cft_SK.strPinPartNo,
							"', @handler_model = '",
							cft_SK.strHdlModel,
							"', @tester_model = '",
							cft_SK.strTesterModel,
							"', @sk_supplier = '",
							cft_SK.strSkSupplier,
							"'"
						});
						text += str5;
						dataSet = this._cComm.QueryCall(text);
					}
				}
				else if (dataType == "FT_CK")
				{
					CFT_CK cft_CK = (CFT_CK)data;
					if (cft_CK == null)
					{
						return;
					}
					string str6 = string.Empty;
					str6 = string.Concat(new string[]
					{
						", @no_of_sites = '",
						cft_CK.strNumOfSites,
						"', @package = '",
						cft_CK.strPackage,
						"', @handler_model = '",
						cft_CK.strHdlModel,
						"', @kit_manufacturer_name = '",
						cft_CK.strKitMfrName,
						"', @manufacturer_part_number = '",
						cft_CK.strMfrPartNo,
						"', @kit_supplier = '",
						cft_CK.strKitSupplier,
						"'"
					});
					text += str6;
					dataSet = this._cComm.QueryCall(text);
				}
			}
			else if (num <= 3095967907U)
			{
				if (num != 2911414098U)
				{
					if (num != 2959299417U)
					{
						if (num == 3095967907U)
						{
							if (dataType == "EWS_PT")
							{
								CEWS_PT cews_PT = (CEWS_PT)data;
								if (cews_PT == null)
								{
									return;
								}
								string str7 = string.Empty;
								str7 = string.Concat(new string[]
								{
									", @manufacturer_name = '",
									cews_PT.strMfrName,
									"', @manufacturer_part_number = '",
									cews_PT.strMfrPartNo,
									"', @manufacturer_serial_number = '",
									cews_PT.strMfrSerialNo,
									"', @manufactured_year = '",
									cews_PT.strMfdYear.ToString(),
									"', @pin_counter = '",
									cews_PT.iPinCounter.ToString(),
									"', @rf_options_available = '",
									cews_PT.strRfOptAvail,
									"', @compatible_tester_model = '",
									cews_PT.strCompTesterModel,
									"', @cold_test_options_available = '",
									cews_PT.strColdTestOptAvail,
									"'"
								});
								text += str7;
								dataSet = this._cComm.QueryCall(text);
							}
						}
					}
					else if (dataType == "FT_HS")
					{
						CFT_HS cft_HS = (CFT_HS)data;
						if (cft_HS == null)
						{
							return;
						}
						string str8 = string.Empty;
						str8 = string.Concat(new string[]
						{
							", @tester_model = '",
							cft_HS.strTesterModel,
							"', @hand_set_part_number = '",
							cft_HS.strHandSetPartNo,
							"', @package = '",
							cft_HS.strPackage,
							"', @hand_set_manufacturer_name = '",
							cft_HS.strHandSetMfrName,
							"', @hand_set_manufacturer_part_number = '",
							cft_HS.strHandSetMfrPartNo,
							"'"
						});
						text += str8;
						dataSet = this._cComm.QueryCall(text);
					}
				}
				else if (dataType == "EWS_PC")
				{
					CEWS_PC cews_PC = (CEWS_PC)data;
					if (cews_PC == null)
					{
						return;
					}
					string str9 = string.Empty;
					str9 = string.Concat(new string[]
					{
						", @wscs_package_description = '",
						cews_PC.strWscsPkgDesc,
						"', @no_of_sites = '",
						cews_PC.strNumOfSites,
						"', @no_of_pins = '",
						cews_PC.iNumOfPins.ToString(),
						"', @pin_type = '",
						cews_PC.strPinType,
						"', @capable_temperature = '",
						cews_PC.strCapableTemp,
						"', @probe_card_type = '",
						cews_PC.strProbeCardType,
						"', @seperate_pcb_board = '",
						cews_PC.strSeperPcbBoard,
						"', @pcb_id = '",
						cews_PC.strPcbId,
						"', @probe_head_id = '",
						cews_PC.strProbeHeadId,
						"', @paired_pcb_id = '",
						cews_PC.strPairedPcbId,
						"', @manufacturer_name = '",
						cews_PC.strMfrName,
						"', @manufacturer_part_number = '",
						cews_PC.strMfrPartNo,
						"', @repair_supplier = '",
						cews_PC.strRepairSupplier,
						"', @tester_model = '",
						cews_PC.strTesterModel,
						"', @prober_model = '",
						cews_PC.strProberModel,
						"', @incomming_tip_lg = '",
						cews_PC.iIncommTipLg.ToString(),
						"', @incomming_tip_dia = '",
						cews_PC.iIncommTipDia.ToString(),
						"', @current_tip_lg = '",
						cews_PC.iCurTipLg.ToString(),
						"', @current_tip_dia = '",
						cews_PC.iCurTipDia.ToString(),
						"', @touch_down_count = '",
						cews_PC.iTouchDownCnt.ToString(),
						"', @accumulated_touch_down = '",
						cews_PC.iAccumTouchDown.ToString(),
						"', @min_tip_lg_spec = '",
						cews_PC.iMinTipLgSpec.ToString(),
						"', @min_tip_dia_spec = '",
						cews_PC.iMinTipDiaSpec.ToString(),
						"', @expection_touch_down = '",
						cews_PC.iExpectTouchDown.ToString(),
						"'"
					});
					text += str9;
					dataSet = this._cComm.QueryCall(text);
				}
			}
			else if (num != 3357361797U)
			{
				if (num != 3496771605U)
				{
					if (num == 3614214938U)
					{
						if (dataType == "FT_LB")
						{
							CFT_LB cft_LB = (CFT_LB)data;
							if (cft_LB == null)
							{
								return;
							}
							string str10 = string.Empty;
							str10 = string.Concat(new string[]
							{
								", @no_of_sites = '",
								cft_LB.strNumOfSites,
								"', @capable_temperature = '",
								cft_LB.strCapableTemp,
								"', @package = '",
								cft_LB.strPackage,
								"', @socket_manufacturer = '",
								cft_LB.strSockMfr,
								"', @socket_part_number = '",
								cft_LB.strSockPartNo,
								"', @pcb_code = '",
								cft_LB.strPcbCode,
								"', @pcb_revision = '",
								cft_LB.strPcbRevision,
								"', @accumulated_insertion = '",
								cft_LB.iAccumInsert.ToString(),
								"', @tester_model = '",
								cft_LB.strTesterModel,
								"', @manufacturer_name = '",
								cft_LB.strMfrName,
								"', @manufacturer_part_number = '",
								cft_LB.strMfrPartNo,
								"'"
							});
							text += str10;
							dataSet = this._cComm.QueryCall(text);
						}
					}
				}
				else if (dataType == "FT_LK")
				{
					CFT_LK cft_LK = (CFT_LK)data;
					if (cft_LK == null)
					{
						return;
					}
					string str11 = string.Empty;
					str11 = string.Concat(new string[]
					{
						", @no_of_sites = '",
						cft_LK.strNumOfSites,
						"', @site_pitch = '",
						cft_LK.strSitePitch,
						"', @head_config = '",
						cft_LK.strHeadConfig,
						"', @direct_heater = '",
						cft_LK.strDirectHeater,
						"', @handler_model = '",
						cft_LK.strHdlModel,
						"', @kit_manufacturer_name = '",
						cft_LK.strKitMfrName,
						"', @manufacturer_part_number = '",
						cft_LK.strMfrPartNo,
						"', @kit_supplier = '",
						cft_LK.strKitSupplier,
						"'"
					});
					text += str11;
					dataSet = this._cComm.QueryCall(text);
				}
			}
			else if (dataType == "FT_DUT")
			{
				CFT_DUT cft_DUT = (CFT_DUT)data;
				if (cft_DUT == null)
				{
					return;
				}
				string str12 = string.Empty;
				str12 = string.Concat(new string[]
				{
					", @package = '",
					cft_DUT.strPackage,
					"', @installed_equipment_model = '",
					cft_DUT.strInstalledEquipModel,
					"', @free_property1 = '",
					cft_DUT.strFreeProperty1,
					"', @free_property2 = '",
					cft_DUT.strFreeProperty2,
					"', @free_property3 = '",
					cft_DUT.strFreeProperty3,
					"', @board_manufacturer_name = '",
					cft_DUT.strBoardMfrName,
					"', @board_manufacturer_part_number = '",
					cft_DUT.strBoardMfrPartNo,
					"', @board_supplier = '",
					cft_DUT.strBoardSupplier,
					"'"
				});
				text += str12;
				dataSet = this._cComm.QueryCall(text);
			}
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
				}
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00007C6C File Offset: 0x00005E6C
		public string GetDataType(string filePath)
		{
			string result = string.Empty;
			if (filePath.IndexOf("EWS-PC") != -1)
			{
				result = "EWS_PC";
			}
			else if (filePath.IndexOf("EWS-KIT") != -1)
			{
				result = "EWS_KIT";
			}
			else if (filePath.IndexOf("EWS-PIB") != -1)
			{
				result = "EWS_PIB";
			}
			else if (filePath.IndexOf("EWS-PT") != -1)
			{
				result = "EWS_PT";
			}
			else if (filePath.IndexOf("FT-CK") != -1)
			{
				result = "FT_CK";
			}
			else if (filePath.IndexOf("FT-DK") != -1)
			{
				result = "FT_DK";
			}
			else if (filePath.IndexOf("FT-DUT") != -1)
			{
				result = "FT_DUT";
			}
			else if (filePath.IndexOf("FT-HS") != -1)
			{
				result = "FT_HS";
			}
			else if (filePath.IndexOf("FT-LB") != -1)
			{
				result = "FT_LB";
			}
			else if (filePath.IndexOf("FT-LK") != -1)
			{
				result = "FT_LK";
			}
			else if (filePath.IndexOf("FT-SK") != -1)
			{
				result = "FT_SK";
			}
			else if (filePath.IndexOf("EQ") != -1)
			{
				result = "EQ";
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00007DA0 File Offset: 0x00005FA0
		public static void UnloadTabpage(TabPage page)
		{
			for (int i = page.Controls.Count - 1; i >= 0; i--)
			{
				page.Controls[i].Dispose();
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00007DD6 File Offset: 0x00005FD6
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x0400000A RID: 10
		public SourceGrid.Cells.Views.ColumnHeader _cell_Header;

		// Token: 0x0400000B RID: 11
		public Cell _cell_Body1;

		// Token: 0x0400000C RID: 12
		public Cell _cell_Body2;

		// Token: 0x0400000D RID: 13
		public Cell _cell_Body_OnFlag;

		// Token: 0x0400000E RID: 14
		public Cell _cell_Body_OnFlag_History;

		// Token: 0x0400000F RID: 15
		public Cell _cell_Body_OnHold;

		// Token: 0x04000010 RID: 16
		public CheckBoxBackColorAlternate _checkBox_Normal1;

		// Token: 0x04000011 RID: 17
		public CheckBoxBackColorAlternate _checkBox_Normal2;

		// Token: 0x04000012 RID: 18
		public CheckBoxBackColorAlternate _checkBox_OnFlag;

		// Token: 0x04000013 RID: 19
		public CheckBoxBackColorAlternate _checkBox_OnFlag_History;

		// Token: 0x04000014 RID: 20
		public CCommon _cComm;

		// Token: 0x04000015 RID: 21
		private string _barcode = string.Empty;

		// Token: 0x04000016 RID: 22
		private int _hwTypeNo;

		// Token: 0x04000017 RID: 23
		private CTemp _tempByBarcode;

		// Token: 0x04000018 RID: 24
		public static HccSTReportModule _instance;

		// Token: 0x04000019 RID: 25
		public BarPrograss _barPrograss;

		// Token: 0x0400001A RID: 26
		public Thread _thread;

		// Token: 0x0400001B RID: 27
		private Tab_EWS_PC _tab_EWS_PC;

		// Token: 0x0400001C RID: 28
		private Tab_EWS_PIB _tab_EWS_PIB;

		// Token: 0x0400001D RID: 29
		private Tab_EWS_PT _tab_EWS_PT;

		// Token: 0x0400001E RID: 30
		private Tab_EWS_KIT _tab_EWS_KIT;

		// Token: 0x0400001F RID: 31
		private Tab_FT_LB _tab_FT_LB;

		// Token: 0x04000020 RID: 32
		private Tab_FT_CK _tab_FT_CK;

		// Token: 0x04000021 RID: 33
		private Tab_FT_SK _tab_FT_SK;

		// Token: 0x04000022 RID: 34
		private Tab_FT_HS _tab_FT_HS;

		// Token: 0x04000023 RID: 35
		private Tab_FT_DUT _tab_FT_DUT;

		// Token: 0x04000024 RID: 36
		private Tab_FT_LK _tab_FT_LK;

		// Token: 0x04000025 RID: 37
		private Tab_FT_DK _tab_FT_DK;

		// Token: 0x04000026 RID: 38
		private Tab_EQ _tab_EQ;

		// Token: 0x04000027 RID: 39
		private CCommonVal _cCommonVal;

		// Token: 0x04000028 RID: 40
		private CEWS_PC _cEWS_PC;

		// Token: 0x04000029 RID: 41
		private CEWS_PIB _cEWS_PIB;

		// Token: 0x0400002A RID: 42
		private CEWS_PT _cEWS_PT;

		// Token: 0x0400002B RID: 43
		private CEWS_KIT _cEWS_KIT;

		// Token: 0x0400002C RID: 44
		private CFT_LB _cFT_LB;

		// Token: 0x0400002D RID: 45
		private CFT_CK _cFT_CK;

		// Token: 0x0400002E RID: 46
		private CFT_SK _cFT_SK;

		// Token: 0x0400002F RID: 47
		private CFT_HS _cFT_HS;

		// Token: 0x04000030 RID: 48
		private CFT_DUT _cFT_DUT;

		// Token: 0x04000031 RID: 49
		private CFT_LK _cFT_LK;

		// Token: 0x04000032 RID: 50
		private CFT_DK _cFT_DK;

		// Token: 0x04000033 RID: 51
		private CEQ _cEQ;

		// Token: 0x04000034 RID: 52
		private CReportCtrl _cReportCtrl;

		// Token: 0x04000035 RID: 53
		private int _iNowYear;

		// Token: 0x04000036 RID: 54
		private int _iNowWeek;

		// Token: 0x04000037 RID: 55
		private bool _isNewHw;
	}
}
