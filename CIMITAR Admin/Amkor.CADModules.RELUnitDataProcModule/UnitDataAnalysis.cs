using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.RELUnitDataProcModule.CommonClass;
using Amkor.CADModules.RELUnitDataProcModule.UserControls;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace Amkor.CADModules.RELUnitDataProcModule
{
	// Token: 0x0200000E RID: 14
	public partial class UnitDataAnalysis : BaseWinView
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00003BE0 File Offset: 0x00001DE0
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
			this.SetEvent();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003CB8 File Offset: 0x00001EB8
		public UnitDataAnalysis(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.SetEvent();
			this.Text = this._cimitarMenu.name;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003D48 File Offset: 0x00001F48
		private void SetEvent()
		{
			this.btnLotSearch.Click += this.btnLotSearch_Click;
			this.btnLotSNLoad.Click += this.btnLotSNLoad_Click;
			this.txtLot.KeyPress += this.txtLot_KeyPress;
			this.rdoSN.ToggleStateChanged += this.rdoOption_ToggleStateChanged;
			this.rdoLot.ToggleStateChanged += this.rdoOption_ToggleStateChanged;
			this.rdoDate.ToggleStateChanged += this.rdoOption_ToggleStateChanged;
			this.btnNewDoc.Click += this.btnNewDoc_Click;
			base.FormClosing += this.UnitDataAnalysis_FormClosing;
			base.Load += this.UnitDataAnalysis_Load;
			this.grdLot.ViewCellFormatting += this.GrdCommon_ViewCellFormatting;
			this.radDock1.ActiveWindowChanged += this.RadDock1_ActiveWindowChanged;
			this.radDock1.DockWindowClosed += this.RadDock1_DockWindowClosed;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003E6C File Offset: 0x0000206C
		private void UnitDataAnalysis_Load(object sender, EventArgs e)
		{
			try
			{
				string text = string.Format("{0}\\Skin\\CIMitarAdmin_Skin.xml", Application.StartupPath);
				bool flag = File.Exists(text);
				if (flag)
				{
					ThemeResolutionService.LoadPackageFile(text);
				}
				this._CommonQry._factorySetting = this._factorySetting;
				RadMessageBox.ThemeName = "CIMitarAdmin_Skin";
				this.dtmStartTime.Value = DateTime.Now.AddDays(-7.0);
				this.dtmEndTime.Value = DateTime.Now;
				this.FilterActive("DATE");
				this.InitCombo();
				this.InitGrid();
				this.btnNewDoc_Click(null, null);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003F34 File Offset: 0x00002134
		private void RadDock1_DockWindowClosed(object sender, DockWindowEventArgs e)
		{
			bool flag = e.DockWindow != null;
			if (flag)
			{
				bool flag2 = this.dicDataResult.ContainsKey(e.DockWindow.Name);
				if (flag2)
				{
					this.dicDataResult.Remove(e.DockWindow.Name);
				}
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003F84 File Offset: 0x00002184
		private void RadDock1_ActiveWindowChanged(object sender, DockWindowEventArgs e)
		{
			bool flag = e.DockWindow != null;
			if (flag)
			{
				bool flag2 = this.dicDataResult.ContainsKey(e.DockWindow.Name);
				if (flag2)
				{
					this.SetDataResultCondBinding(e.DockWindow.Name);
				}
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003FD0 File Offset: 0x000021D0
		private void GrdCommon_ViewCellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement is GridRowHeaderCellElement && e.Row is GridViewDataRowInfo;
			if (flag)
			{
				e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
				e.CellElement.TextImageRelation = TextImageRelation.ImageBeforeText;
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.TextImageRelationProperty, ValueResetFlags.Local);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00004048 File Offset: 0x00002248
		private void txtLot_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == '\r';
			if (flag)
			{
				this.SearchLotList(false);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004070 File Offset: 0x00002270
		private void rdoOption_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			RadRadioButton radRadioButton = sender as RadRadioButton;
			bool flag = args.ToggleState == ToggleState.On;
			if (flag)
			{
				bool flag2 = radRadioButton.Name.Equals("rdoDate");
				if (flag2)
				{
					this.FilterActive("DATE");
				}
				bool flag3 = radRadioButton.Name.Equals("rdoLot");
				if (flag3)
				{
					this.FilterActive("LOT");
				}
				bool flag4 = radRadioButton.Name.Equals("rdoSN");
				if (flag4)
				{
					this.FilterActive("SN");
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000040F6 File Offset: 0x000022F6
		private void UnitDataAnalysis_FormClosing(object sender, FormClosingEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00004100 File Offset: 0x00002300
		private void btnNewDoc_Click(object sender, EventArgs e)
		{
			try
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				Type type = executingAssembly.GetType("Amkor.CADModules.RELUnitDataProcModule.UserControls.UnitDataResult");
				bool flag = type != null && type.BaseType.Name == "UserControl";
				if (flag)
				{
					object obj = Activator.CreateInstance(type);
					string text = string.Empty;
					foreach (RadCheckedListDataItem radCheckedListDataItem in this.cboProduct.CheckedItems)
					{
						string str = text;
						string str2 = "''";
						object value = radCheckedListDataItem.Value;
						text = str + str2 + ((value != null) ? value.ToString() : null) + "'',";
					}
					bool flag2 = !string.IsNullOrEmpty(text);
					if (flag2)
					{
						text = text.Substring(0, text.Length - 1);
					}
					DataTable value2 = null;
					bool flag3 = this.grdLot.DataSource != null;
					if (flag3)
					{
						EnumerableRowCollection<DataRow> source = from c in (this.grdLot.DataSource as DataTable).AsEnumerable()
						where c.Field("chk") == "True"
						select c;
						bool flag4 = source.Any<DataRow>();
						if (flag4)
						{
							value2 = source.CopyToDataTable<DataRow>();
						}
						else
						{
							value2 = (this.grdLot.DataSource as DataTable).Clone();
						}
					}
					PropertyInfo property = type.GetProperty("UserAccount");
					bool flag5 = property != null;
					if (flag5)
					{
						property.SetValue(obj, this._cimitarUser);
					}
					property = type.GetProperty("CommonQry");
					bool flag6 = property != null;
					if (flag6)
					{
						property.SetValue(obj, this._CommonQry);
					}
					property = type.GetProperty("Option");
					bool flag7 = property != null;
					if (flag7)
					{
						property.SetValue(obj, this._Option);
					}
					property = type.GetProperty("StartTime");
					bool flag8 = property != null;
					if (flag8)
					{
						property.SetValue(obj, this.dtmStartTime.Value);
					}
					property = type.GetProperty("EndTime");
					bool flag9 = property != null;
					if (flag9)
					{
						property.SetValue(obj, this.dtmEndTime.Value);
					}
					property = type.GetProperty("Lot");
					bool flag10 = property != null;
					if (flag10)
					{
						property.SetValue(obj, this.txtLot.Text);
					}
					property = type.GetProperty("SN");
					bool flag11 = property != null;
					if (flag11)
					{
						property.SetValue(obj, this.txtSN.Text);
					}
					property = type.GetProperty("LotList");
					bool flag12 = property != null;
					if (flag12)
					{
						property.SetValue(obj, value2);
					}
					DocumentWindow documentWindow = new DocumentWindow(type.Name);
					this.radDock1.AddDocument(documentWindow);
					UnitDataResult value3 = ((Control)obj) as UnitDataResult;
					documentWindow.Controls.Add(value3);
					documentWindow.Controls[0].Dock = DockStyle.Fill;
					this.radDock1.DocumentManager.DocumentArray[0].Select();
					this.dicDataResult.Add(documentWindow.Name, value3);
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000448C File Offset: 0x0000268C
		private void btnLotSearch_Click(object sender, EventArgs e)
		{
			this.SearchLotList(false);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004498 File Offset: 0x00002698
		private void btnLotSNLoad_Click(object sender, EventArgs e)
		{
			InputData inputData = new InputData();
			inputData.Owner = this;
			inputData.SearchType = this._Option;
			inputData.ChildFormEvent += this.EventMethod;
			inputData.Show();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000044DC File Offset: 0x000026DC
		public void EventMethod(bool isNewDoc, string searchType, string cond)
		{
			bool flag = searchType.Equals("LOT");
			if (flag)
			{
				this.rdoLot.IsChecked = true;
				this.FilterActive("LOT");
				this.txtLot.Text = cond;
			}
			else
			{
				this.rdoSN.IsChecked = true;
				this.FilterActive("SN");
				this.txtSN.Text = cond;
			}
			this.SearchLotList(true);
			DocumentWindow documentWindow = new DocumentWindow();
			if (isNewDoc)
			{
				this.btnNewDoc_Click(null, null);
				documentWindow = (DocumentWindow)this.radDock1.DocumentManager.DocumentArray[0];
			}
			else
			{
				documentWindow = (DocumentWindow)this.radDock1.DocumentManager.ActiveDocument;
			}
			this.SetDataResultCondBinding(documentWindow.Name);
			(documentWindow.Controls[0] as UnitDataResult).btnSearch_Click(null, null);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000045C4 File Offset: 0x000027C4
		private void InitGrid()
		{
			this.grdLot.MasterTemplate.MultiSelect = true;
			this.grdLot.AllowAddNewRow = false;
			this.grdLot.ShowGroupPanel = false;
			this.grdLot.EnableFiltering = false;
			this.grdLot.EnableSorting = true;
			this.grdLot.EnableGrouping = true;
			this.grdLot.MasterView.TableHeaderRow.IsVisible = true;
			this.grdLot.MasterTemplate.ShowHeaderCellButtons = true;
			this.grdLot.MasterTemplate.ShowFilteringRow = true;
			this.grdLot.MasterTemplate.AllowRowResize = false;
			this.grdLot.MasterTemplate.AllowDeleteRow = false;
			this.grdLot.SelectionMode = GridViewSelectionMode.CellSelect;
			this.grdLot.Columns.Add(this.cm.SetGridViewColumn("chk", "", true, 22, false, false, true, "CheckBox"));
			this.grdLot.Columns.Add(this.cm.SetGridViewColumn("lotid", "LotId", false, 80, true, false, false, "TextBox"));
			this.grdLot.Columns.Add(this.cm.SetGridViewColumn("lot", "Lot", true, 90, true, false, false, "TextBox"));
			this.grdLot.Columns.Add(this.cm.SetGridViewColumn("dcc", "Dcc", false, 80, true, false, false, "TextBox"));
			this.grdLot.Columns.Add(this.cm.SetGridViewColumn("sn", "sn", false, 80, true, false, false, "TextBox"));
			this.grdLot.Columns.Add(this.cm.SetGridViewColumn("operation", "Operation", true, 90, true, false, false, "TextBox"));
			this.grdLot.Columns.Add(this.cm.SetGridViewColumn("product", "Product", true, 90, true, false, false, "TextBox"));
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000047E8 File Offset: 0x000029E8
		private void InitCombo()
		{
			try
			{
				string sQuery = "EXEC [CIMitar_Unit].[dbo].[ADMIN_CMN_UnitCode_Select] @CodeGroupID = 'FamilyName'";
				DataSet dataSet = this._CommonQry.queryCall(sQuery);
				bool flag = dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0;
				if (flag)
				{
					this.cboProduct.CheckedMember = null;
					foreach (object obj in dataSet.Tables[0].Rows)
					{
						DataRow dataRow = (DataRow)obj;
						RadCheckedListDataItem radCheckedListDataItem = new RadCheckedListDataItem();
						radCheckedListDataItem.Checked = false;
						radCheckedListDataItem.Text = Convert.ToString(dataRow["CodeName"]);
						radCheckedListDataItem.Value = Convert.ToString(dataRow["CodeID"]);
						this.cboProduct.Items.Add(radCheckedListDataItem);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000491C File Offset: 0x00002B1C
		private void SearchLotList(bool isLoad = false)
		{
			string arg = string.Empty;
			string arg2 = string.Empty;
			string arg3 = string.Empty;
			string arg4 = string.Empty;
			string text = string.Empty;
			bool enabled = this.dtmStartTime.Enabled;
			if (enabled)
			{
				arg = this.dtmStartTime.Text;
			}
			bool enabled2 = this.dtmEndTime.Enabled;
			if (enabled2)
			{
				arg2 = this.dtmEndTime.Text;
			}
			bool enabled3 = this.txtLot.Enabled;
			if (enabled3)
			{
				arg3 = this.txtLot.Text;
			}
			bool enabled4 = this.txtSN.Enabled;
			if (enabled4)
			{
				arg4 = this.txtSN.Text;
			}
			bool enabled5 = this.cboProduct.Enabled;
			if (enabled5)
			{
				foreach (RadCheckedListDataItem radCheckedListDataItem in this.cboProduct.CheckedItems)
				{
					string str = text;
					string str2 = "''";
					object value = radCheckedListDataItem.Value;
					text = str + str2 + ((value != null) ? value.ToString() : null) + "'',";
				}
				bool flag = !string.IsNullOrEmpty(text);
				if (flag)
				{
					text = text.Substring(0, text.Length - 1);
				}
			}
			string text2 = "\r\n                                EXEC [CIMitar_Unit].[dbo].[ADMIN_UNIT_RELUnitData_Lot_Select] @isLoad = @VisLoad@\r\n                                                                                            , @startTime = @VstartTime@\r\n                                                                                            , @endTime = @VendTime@\r\n                                                                                            , @lot = @Vlot@\r\n                                                                                            , @sn = @Vsn@\r\n                                                                                            , @familyname = @Vfamilyname@\r\n                               ";
			text2 = text2.Replace("@VisLoad@", string.Format("'{0}'", isLoad ? "Y" : "N"));
			text2 = text2.Replace("@VstartTime@", string.Format("'{0}'", arg));
			text2 = text2.Replace("@VendTime@", string.Format("'{0}'", arg2));
			text2 = text2.Replace("@Vlot@", string.Format("'{0}'", arg3));
			text2 = text2.Replace("@Vsn@", string.Format("'{0}'", arg4));
			text2 = text2.Replace("@Vfamilyname@", string.Format("'{0}'", text));
			DataSet dataSet = this._CommonQry.queryCall(text2);
			this.cm.GridViewSetDataSource(this.grdLot, dataSet.Tables[0]);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00004B40 File Offset: 0x00002D40
		private void FilterActive(string option)
		{
			this._Option = option;
			if (!(option == "LOT"))
			{
				if (!(option == "SN"))
				{
					if (!(option == "DATE"))
					{
					}
					this.dtmStartTime.Enabled = true;
					this.dtmEndTime.Enabled = true;
					this.cboProduct.Enabled = true;
					this.txtLot.Enabled = false;
					this.txtSN.Enabled = false;
					this.btnLotSNLoad.Enabled = false;
					this.txtLot.Text = string.Empty;
					this.txtSN.Text = string.Empty;
				}
				else
				{
					this.txtSN.Enabled = true;
					this.btnLotSNLoad.Enabled = true;
					this.dtmStartTime.Enabled = false;
					this.dtmEndTime.Enabled = false;
					this.cboProduct.Enabled = false;
					this.txtLot.Enabled = false;
					this.txtLot.Text = string.Empty;
					this.cboProduct.CheckedItems.Clear();
				}
			}
			else
			{
				this.txtLot.Enabled = true;
				this.btnLotSNLoad.Enabled = true;
				this.dtmStartTime.Enabled = false;
				this.dtmEndTime.Enabled = false;
				this.cboProduct.Enabled = false;
				this.txtSN.Enabled = false;
				this.txtSN.Text = string.Empty;
				this.cboProduct.CheckedItems.Clear();
				this.cboProduct.Text = string.Empty;
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00004CF8 File Offset: 0x00002EF8
		private void SetDataResultCondBinding(string windowKey)
		{
			string text = string.Empty;
			foreach (RadCheckedListDataItem radCheckedListDataItem in this.cboProduct.CheckedItems)
			{
				string str = text;
				string str2 = "''";
				object value = radCheckedListDataItem.Value;
				text = str + str2 + ((value != null) ? value.ToString() : null) + "'',";
			}
			bool flag = !string.IsNullOrEmpty(text);
			if (flag)
			{
				text = text.Substring(0, text.Length - 1);
			}
			DataTable lotList = null;
			bool flag2 = this.grdLot.DataSource != null;
			if (flag2)
			{
				EnumerableRowCollection<DataRow> source = from c in (this.grdLot.DataSource as DataTable).AsEnumerable()
				where c.Field("chk") == "True"
				select c;
				bool flag3 = source.Any<DataRow>();
				if (flag3)
				{
					lotList = source.CopyToDataTable<DataRow>();
				}
				else
				{
					lotList = (this.grdLot.DataSource as DataTable).Clone();
				}
			}
			this.dicDataResult[windowKey].Option = this._Option;
			this.dicDataResult[windowKey].StartTime = this.dtmStartTime.Value;
			this.dicDataResult[windowKey].EndTime = this.dtmEndTime.Value;
			this.dicDataResult[windowKey].Lot = this.txtLot.Text;
			this.dicDataResult[windowKey].SN = this.txtSN.Text;
			this.dicDataResult[windowKey].Product = text;
			this.dicDataResult[windowKey].LotList = lotList;
		}

		// Token: 0x04000039 RID: 57
		private CommonQuery _CommonQry = new CommonQuery();

		// Token: 0x0400003A RID: 58
		private Thread _thread;

		// Token: 0x0400003B RID: 59
		private BarPrograss _barPrograss = new BarPrograss();

		// Token: 0x0400003C RID: 60
		private CommonMethod cm = new CommonMethod();

		// Token: 0x0400003D RID: 61
		private Dictionary<string, UnitDataResult> dicDataResult = new Dictionary<string, UnitDataResult>();

		// Token: 0x0400003E RID: 62
		private string _Option = string.Empty;
	}
}
