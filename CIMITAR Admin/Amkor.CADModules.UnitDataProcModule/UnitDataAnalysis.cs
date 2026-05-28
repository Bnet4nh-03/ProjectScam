using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.UnitDataProcModule.AnalysisView;
using Amkor.CADModules.UnitDataProcModule.CommonClass;
using Amkor.CADModules.UnitDataProcModule.Controls;
using Amkor.CADModules.UnitDataProcModule.DataClass;
using Amkor.CADModules.UnitDataProcModule.OtherView;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace Amkor.CADModules.UnitDataProcModule
{
	// Token: 0x02000010 RID: 16
	public partial class UnitDataAnalysis : BaseWinView
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00009544 File Offset: 0x00007744
		public UnitDataAnalysis()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://10.101.5.190/";
			this._factorySetting._startHour = 6;
			this._factorySetting._startMin = 0;
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarMenu.menucode = 103001;
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this._cimitarUser._id = "wogud0609";
			this.InitializeComponent();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000960C File Offset: 0x0000780C
		public UnitDataAnalysis(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000968D File Offset: 0x0000788D
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000969C File Offset: 0x0000789C
		private void ParameterAnalysis_Load(object sender, EventArgs e)
		{
			try
			{
				this._CommonQry._factorySetting = this._factorySetting;
				this.m_Data._CommonQry = this._CommonQry;
				this.dateTimeStart.Value = DateTime.Now.AddDays(-7.0);
				this.dateTimeEnd.Value = DateTime.Now;
				this.m_Data.sDate_Start = this.dateTimeStart.Value;
				this.m_Data.sDate_End = this.dateTimeEnd.Value;
				this.radcmb_DateType.Items.Add("Start_T");
				this.radcmb_DateType.Items.Add("End_T");
				this.radcmb_DateType.SelectedIndex = 1;
				this.btnLotLoad.Enabled = false;
				this.btnSNLoad.Enabled = false;
				this.m_Data.sSearchType = "DATE";
				this.initGetData();
				this.initViewerContorl();
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000097B4 File Offset: 0x000079B4
		private void initGetData()
		{
			this.getProduct();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000097BC File Offset: 0x000079BC
		private void initViewerContorl()
		{
			try
			{
				try
				{
					Assembly executingAssembly = Assembly.GetExecutingAssembly();
					for (int i = this.aFunction.Count - 1; i >= 0; i--)
					{
						string str = this.aFunction[i].ToString();
						Type type = executingAssembly.GetType("Amkor.CADModules.UnitDataProcModule.AnalysisView." + str);
						if (type != null && type.BaseType.Name == "UserControl")
						{
							object obj = Activator.CreateInstance(type);
							PropertyInfo property = type.GetProperty("Data");
							if (property != null)
							{
								property.SetValue(obj, this.m_Data);
								DocumentWindow documentWindow = new DocumentWindow(type.Name);
								this.radDock1.AddDocument(documentWindow);
								documentWindow.Controls.Add((Control)obj);
								documentWindow.Controls[0].Dock = DockStyle.Fill;
							}
						}
					}
				}
				catch (Exception ex)
				{
					ex.Message.ToString();
				}
			}
			catch (Exception ex2)
			{
				ex2.Message.ToString();
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000098E4 File Offset: 0x00007AE4
		private void initComboSet(RadDropDownList combo)
		{
			if (combo.Items.Count > 0)
			{
				combo.SelectedIndex = 0;
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000098FC File Offset: 0x00007AFC
		private void getCustomer()
		{
			DataSet dataSet = new DataSet();
			string text = string.Empty;
			string text2 = string.Empty;
			try
			{
				string sQuery = "EXEC [CIMitar_Report].[dbo].[USP_CR_GetCustomer]";
				dataSet = this._CommonQry.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					this.radchkcmb_Customer.CheckedMember = null;
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						text = dataSet.Tables[0].Rows[i][0].ToString();
						text2 = dataSet.Tables[0].Rows[i][1].ToString();
						text = text2 + "  :  " + text;
						RadCheckedListDataItem radCheckedListDataItem = new RadCheckedListDataItem();
						radCheckedListDataItem.Checked = false;
						radCheckedListDataItem.Text = text;
						radCheckedListDataItem.Tag = text2.ToString();
						this.radchkcmb_Customer.Items.Add(radCheckedListDataItem);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00009A4C File Offset: 0x00007C4C
		private void getProduct()
		{
			DataSet dataSet = new DataSet();
			try
			{
				string sQuery = "EXEC [CIMitar_Unit].[dbo].[USP_UNIT_GetProdct]";
				dataSet = this._CommonQry.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					this.chkcmb_Product.CheckedMember = null;
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string text = dataSet.Tables[0].Rows[i][0].ToString();
						RadCheckedListDataItem radCheckedListDataItem = new RadCheckedListDataItem();
						radCheckedListDataItem.Checked = false;
						radCheckedListDataItem.Text = text;
						this.chkcmb_Product.Items.Add(radCheckedListDataItem);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00009B38 File Offset: 0x00007D38
		private void btnDeviceSearch_Click(object sender, EventArgs e)
		{
			DataSet dataSet = new DataSet();
			string text = string.Empty;
			string text2 = this.txtDevice.Text.ToUpper().Trim();
			string text3 = string.Empty;
			try
			{
				if (this.radchkcmb_Customer.CheckedItems.Count == 0)
				{
					RadMessageBox.SetThemeName(this.telerikMetroBlueTheme1.ThemeName);
					RadMessageBox.Show(this, "Select Customer Name Please", "Warning", MessageBoxButtons.OK, RadMessageIcon.Info);
				}
				else
				{
					for (int i = 0; i < this.radchkcmb_Customer.CheckedItems.Count; i++)
					{
						RadCheckedListDataItem radCheckedListDataItem = this.radchkcmb_Customer.CheckedItems[i];
						text = text + radCheckedListDataItem.Tag.ToString() + ",";
					}
					text = text.Substring(0, text.Length - 1);
					if (this.rdoDevice.CheckState == CheckState.Checked)
					{
						text3 = "DEVICE";
					}
					else if (this.rdoENick.CheckState == CheckState.Checked)
					{
						text3 = "ENICK";
					}
					else
					{
						text3 = "PRODUCT";
					}
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Report].[dbo].[USP_CR_GetDevice] @customercode = '",
						text,
						"', @devicename = '",
						text2,
						"', @flag = '",
						text3,
						"'"
					});
					dataSet = this._CommonQry.queryCall(sQuery);
					if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Ready....");
						this._barPrograss.setValue(0);
						this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						this.m_Data.dtDevice = dataSet.Tables[0];
						GridViewCheckBoxColumn gridViewCheckBoxColumn = new GridViewCheckBoxColumn();
						gridViewCheckBoxColumn.HeaderText = "";
						gridViewCheckBoxColumn.Name = "Check";
						gridViewCheckBoxColumn.Width = 25;
						gridViewCheckBoxColumn.EnableHeaderCheckBox = true;
						this.grid_Device.Columns.Clear();
						this.grid_Device.Columns.Insert(0, gridViewCheckBoxColumn);
						this.grid_Device.AllowAddNewRow = false;
						this.grid_Device.ShowGroupPanel = false;
						this.grid_Device.DataSource = this.m_Data.dtDevice;
						this.grid_Device.Columns["devicename"].Width = 100;
						this.grid_Device.Columns["pkg"].Width = 30;
						this.grid_Device.Columns["dms"].Width = 30;
						this.grid_Device.Columns["lead"].Width = 30;
						this.grid_Device.Columns["deviceid"].IsVisible = false;
						this.grid_Device.Columns["pinnumber"].IsVisible = false;
						this.grid_Device.Columns["customercode"].IsVisible = false;
						this.grid_Device.Columns["cycletime"].IsVisible = false;
						this.grid_Device.Columns["testtype"].IsVisible = false;
						this.grid_Device.Columns["sitevarlimit"].IsVisible = false;
						this.grid_Device.Columns["lowyldlimit"].IsVisible = false;
						this.grid_Device.Columns["direction"].IsVisible = false;
						this.grid_Device.Columns["productname"].IsVisible = false;
					}
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
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00009F8C File Offset: 0x0000818C
		private void initGrid()
		{
			this.m_Data.clearLot();
			this.m_Data.dtLot.Columns.Add("Check", typeof(bool));
			this.m_Data.dtLot.Columns.Add("No", typeof(int));
			this.m_Data.dtLot.Columns.Add("Lot", typeof(string));
			this.m_Data.dtLot.Columns.Add("Dcc", typeof(string));
			this.m_Data.dtLot.Columns.Add("Operation", typeof(string));
			this.m_Data.dtLot.Columns.Add("Product", typeof(string));
			this.m_Data.dtLot.Columns.Add("LotId", typeof(int));
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000A0A8 File Offset: 0x000082A8
		private void setLotListGrid()
		{
			this.grid_Lot.DataSource = this.m_Data.dtLot;
			this.grid_Lot.AllowAddNewRow = false;
			this.grid_Lot.ShowGroupPanel = false;
			this.grid_Lot.EnableFiltering = true;
			this.grid_Lot.EnableSorting = true;
			this.grid_Lot.EnableGrouping = true;
			this.grid_Lot.MasterView.TableHeaderRow.IsVisible = true;
			this.grid_Lot.MasterTemplate.ShowHeaderCellButtons = true;
			this.grid_Lot.MasterTemplate.ShowFilteringRow = false;
			GridViewCheckBoxColumn gridViewCheckBoxColumn = new GridViewCheckBoxColumn();
			gridViewCheckBoxColumn = (GridViewCheckBoxColumn)this.grid_Lot.Columns[0];
			gridViewCheckBoxColumn.HeaderText = "";
			gridViewCheckBoxColumn.Name = "Check";
			gridViewCheckBoxColumn.Width = 55;
			gridViewCheckBoxColumn.EnableHeaderCheckBox = true;
			this.grid_Lot.Columns["Check"].AllowSort = false;
			this.grid_Lot.Columns["Check"].Width = 30;
			this.grid_Lot.Columns["No"].Width = 40;
			this.grid_Lot.Columns["Lot"].Width = 80;
			this.grid_Lot.Columns["Dcc"].Width = 40;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000A20C File Offset: 0x0000840C
		private void btnLotSearch_Click(object sender, EventArgs e)
		{
			this.initGrid();
			this.getLotList("");
			this.setLotListGrid();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000A228 File Offset: 0x00008428
		private void getLotList(string sValue = "")
		{
			this.m_Data.slSearchSN = new SortedList();
			string str = string.Empty;
			if (this.rdoLot.CheckState == CheckState.Checked)
			{
				if (sValue == string.Empty && this.txtLot.Text.Trim() != string.Empty)
				{
					sValue = this.txtLot.Text.Trim();
				}
				else if (sValue == string.Empty && this.txtLot.Text.Trim() == string.Empty)
				{
					RadMessageBox.Show(this, "Input LotID please", "Warning", MessageBoxButtons.OK, RadMessageIcon.Error);
					return;
				}
				str = ", @lot = '" + sValue + "'";
			}
			else if (this.rdoSN.CheckState == CheckState.Checked)
			{
				if (sValue == string.Empty && this.txtSN.Text.Trim() != string.Empty)
				{
					sValue = this.txtSN.Text.Trim();
				}
				else if (sValue == string.Empty && this.txtSN.Text.Trim() == string.Empty)
				{
					RadMessageBox.Show(this, "Input SN please", "Warning", MessageBoxButtons.OK, RadMessageIcon.Error);
					return;
				}
				str = ", @sn = '" + sValue + "'";
			}
			else if (this.rdoDate.CheckState == CheckState.Checked)
			{
				string text = string.Empty;
				for (int i = 0; i < this.chkcmb_Product.CheckedItems.Count; i++)
				{
					RadCheckedListDataItem radCheckedListDataItem = this.chkcmb_Product.CheckedItems[i];
					text = text + radCheckedListDataItem.ToString() + ",";
				}
				if (text != string.Empty)
				{
					text = text.Substring(0, text.Length - 1);
					str = ", @product = '" + text + "'";
				}
			}
			string text2 = string.Concat(new string[]
			{
				"EXEC [CIMitar_Unit].[dbo].[USP_UNIT_GetLotList] @startdate = '",
				this.dateTimeStart.Value.ToShortDateString(),
				"', @enddate = '",
				this.dateTimeEnd.Value.ToShortDateString(),
				"', @type = '",
				this.m_Data.sSearchType,
				"'"
			});
			text2 += str;
			DataSet dataSet = this._CommonQry.queryCall(text2);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
				{
					if (this.m_Data.sSearchType == "SN")
					{
						if (this.m_Data.slSearchSN.ContainsKey(dataSet.Tables[0].Rows[j]["lotid"].ToString()))
						{
							ArrayList arrayList = (ArrayList)this.m_Data.slSearchSN[dataSet.Tables[0].Rows[j]["lotid"].ToString()];
							arrayList.Add(dataSet.Tables[0].Rows[j]["sn"].ToString());
						}
						else
						{
							this.m_Data.dtLot.Rows.Add(new string[]
							{
								"false",
								(j + 1).ToString(),
								dataSet.Tables[0].Rows[j]["lot"].ToString(),
								dataSet.Tables[0].Rows[j]["dcc"].ToString(),
								dataSet.Tables[0].Rows[j]["operation"].ToString(),
								dataSet.Tables[0].Rows[j]["product"].ToString(),
								dataSet.Tables[0].Rows[j]["lotid"].ToString()
							});
							this.m_Data.slSearchSN.Add(dataSet.Tables[0].Rows[j]["lotid"].ToString(), new ArrayList
							{
								dataSet.Tables[0].Rows[j]["sn"].ToString()
							});
						}
					}
					else
					{
						this.m_Data.dtLot.Rows.Add(new string[]
						{
							"false",
							(j + 1).ToString(),
							dataSet.Tables[0].Rows[j]["lot"].ToString(),
							dataSet.Tables[0].Rows[j]["dcc"].ToString(),
							dataSet.Tables[0].Rows[j]["operation"].ToString(),
							dataSet.Tables[0].Rows[j]["product"].ToString(),
							dataSet.Tables[0].Rows[j]["lotid"].ToString()
						});
					}
				}
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000A860 File Offset: 0x00008A60
		private void radchkcmb_Customer_ItemCheckedChanged(object sender, RadCheckedListDataItemEventArgs e)
		{
			this.m_Data.clearDevice();
			this.grid_Device.DataSource = new object();
			this.grid_Lot.Relations.Clear();
			this.grid_Lot.DataSource = new object();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000A89D File Offset: 0x00008A9D
		private void txtLot_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnLotSearch_Click(null, null);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000A8B1 File Offset: 0x00008AB1
		private void grid_Lot_CellClick(object sender, GridViewCellEventArgs e)
		{
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000A8B3 File Offset: 0x00008AB3
		private void UnitDataAnalysis_FormClosing(object sender, FormClosingEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000A8BB File Offset: 0x00008ABB
		private void toolTabStrip4_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000A8BD File Offset: 0x00008ABD
		private void rdoDate_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			if (args.ToggleState == ToggleState.On)
			{
				this.m_Data.sSearchType = "DATE";
				this.btnLotLoad.Enabled = false;
				this.btnSNLoad.Enabled = false;
				this.chkcmb_Product.Enabled = true;
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000A8FC File Offset: 0x00008AFC
		private void rdoLot_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			if (args.ToggleState == ToggleState.On)
			{
				this.m_Data.sSearchType = "LOT";
				this.btnLotLoad.Enabled = true;
				this.btnSNLoad.Enabled = false;
				this.chkcmb_Product.Enabled = false;
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000A93B File Offset: 0x00008B3B
		private void rdoSN_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			if (args.ToggleState == ToggleState.On)
			{
				this.m_Data.sSearchType = "SN";
				this.btnLotLoad.Enabled = false;
				this.btnSNLoad.Enabled = true;
				this.chkcmb_Product.Enabled = false;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000A97C File Offset: 0x00008B7C
		public void EventMethod(cMainData main)
		{
			if (this.m_Data.sSearchType == "LOT")
			{
				this.rdoLot.CheckState = CheckState.Checked;
			}
			else if (this.m_Data.sSearchType == "SN")
			{
				this.rdoSN.CheckState = CheckState.Checked;
			}
			this.initGrid();
			this.getLotList(main.sInputData);
			this.setLotListGrid();
			for (int i = 0; i < this.m_Data.dtLot.Rows.Count; i++)
			{
				this.m_Data.dtLot.Rows[i][0] = true;
			}
			if (this.m_Data.bNewDocFlag)
			{
				this.btnNewDoc_Click(null, null);
				DocumentWindow documentWindow = (DocumentWindow)this.radDock1.DocumentManager.DocumentArray[0];
				(documentWindow.Controls[0] as UnitDataResult).btnSearch_Click(null, null);
				return;
			}
			DocumentWindow documentWindow2 = (DocumentWindow)this.radDock1.DocumentManager.ActiveDocument;
			(documentWindow2.Controls[0] as UnitDataResult).btnSearch_Click(null, null);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000AAA0 File Offset: 0x00008CA0
		private void btnLotLoad_Click(object sender, EventArgs e)
		{
			InputData inputData = new InputData();
			inputData.Owner = this;
			inputData.mData = this.m_Data;
			inputData.ChildFormEvent += this.EventMethod;
			inputData.Show();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000AAE0 File Offset: 0x00008CE0
		private void btnLoad_Click(object sender, EventArgs e)
		{
			InputData inputData = new InputData();
			inputData.Owner = this;
			inputData.mData = this.m_Data;
			inputData.ChildFormEvent += this.EventMethod;
			inputData.Show();
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000AB20 File Offset: 0x00008D20
		private void btnNewDoc_Click(object sender, EventArgs e)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			for (int i = this.aFunction.Count - 1; i >= 0; i--)
			{
				string str = this.aFunction[i].ToString();
				Type type = executingAssembly.GetType("Amkor.CADModules.UnitDataProcModule.AnalysisView." + str);
				if (type != null && type.BaseType.Name == "UserControl")
				{
					object obj = Activator.CreateInstance(type);
					PropertyInfo property = type.GetProperty("Data");
					if (property != null)
					{
						property.SetValue(obj, this.m_Data);
						DocumentWindow documentWindow = new DocumentWindow(type.Name);
						this.radDock1.AddDocument(documentWindow);
						documentWindow.Controls.Add((Control)obj);
						documentWindow.Controls[0].Dock = DockStyle.Fill;
						this.radDock1.DocumentManager.DocumentArray[0].Select();
					}
				}
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000AC20 File Offset: 0x00008E20
		private void btnRawData_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000AC22 File Offset: 0x00008E22
		private void dateTimeStart_ValueChanged(object sender, EventArgs e)
		{
			this.m_Data.sDate_Start = this.dateTimeStart.Value;
			this.m_Data.sDate_End = this.dateTimeEnd.Value;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000AC50 File Offset: 0x00008E50
		private void dateTimeEnd_ValueChanged(object sender, EventArgs e)
		{
			this.m_Data.sDate_Start = this.dateTimeStart.Value;
			this.m_Data.sDate_End = this.dateTimeEnd.Value;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000AC80 File Offset: 0x00008E80
		private void chkcmb_Product_SelectedValueChanged(object sender, EventArgs e)
		{
			string text = string.Empty;
			for (int i = 0; i < this.chkcmb_Product.CheckedItems.Count; i++)
			{
				RadCheckedListDataItem radCheckedListDataItem = this.chkcmb_Product.CheckedItems[i];
				text = text + radCheckedListDataItem.ToString() + ",";
			}
			if (text != string.Empty)
			{
				text = text.Substring(0, text.Length - 1);
			}
			this.m_Data.sDevice = text;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000ACFC File Offset: 0x00008EFC
		private void chkcmb_Product_ItemCheckedChanged(object sender, RadCheckedListDataItemEventArgs e)
		{
			string text = string.Empty;
			for (int i = 0; i < this.chkcmb_Product.CheckedItems.Count; i++)
			{
				RadCheckedListDataItem radCheckedListDataItem = this.chkcmb_Product.CheckedItems[i];
				text = text + radCheckedListDataItem.ToString() + ",";
			}
			if (text != string.Empty)
			{
				text = text.Substring(0, text.Length - 1);
			}
			this.m_Data.sDevice = text;
		}

		// Token: 0x04000097 RID: 151
		public cMainData m_Data = new cMainData();

		// Token: 0x04000098 RID: 152
		public CommonQuery _CommonQry = new CommonQuery();

		// Token: 0x04000099 RID: 153
		private Thread _thread;

		// Token: 0x0400009A RID: 154
		private BarPrograss _barPrograss = new BarPrograss();

		// Token: 0x0400009B RID: 155
		private ArrayList aFunction = new ArrayList
		{
			"UnitDataResult"
		};
	}
}
