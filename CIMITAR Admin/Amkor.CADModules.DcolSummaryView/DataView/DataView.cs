using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.DcolSummaryView.CommonClass;
using Amkor.CADModules.DcolSummaryView.Controls;
using Amkor.CADModules.DcolSummaryView.DataClass;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.DcolSummaryView.DataView
{
	// Token: 0x02000002 RID: 2
	public class DataView : UserControl
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x0000205E File Offset: 0x0000025E
		// (set) Token: 0x06000003 RID: 3 RVA: 0x00002066 File Offset: 0x00000266
		public cMainData Data
		{
			get
			{
				return this.mData;
			}
			set
			{
				this.mData = value;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002070 File Offset: 0x00000270
		public DataView()
		{
			this.InitializeComponent();
			this.Dock = DockStyle.Fill;
			this.dateTimeStart.Value = DateTime.Now.AddDays(-7.0);
			this.dateTimeEnd.Value = DateTime.Now;
			this.grid_Data.RowFormatting += this.grid_Data_RowFormatting;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002104 File Offset: 0x00000304
		private void grid_Data_RowFormatting(object sender, RowFormattingEventArgs e)
		{
			if ((string)e.RowElement.RowInfo.Cells["Result"].Value == "F")
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = GradientStyles.Solid;
				e.RowElement.BackColor = Color.Pink;
				return;
			}
			e.RowElement.ResetValue(VisualElement.BackColorProperty, ValueResetFlags.Local);
			e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
			e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021A4 File Offset: 0x000003A4
		private void initDataTable()
		{
			this.dtLot = null;
			this.dtLot = new DataTable();
			this.dtLot.Columns.Add("No", typeof(int));
			this.dtLot.Columns.Add("Floor", typeof(string));
			this.dtLot.Columns.Add("P/F", typeof(string));
			this.dtLot.Columns.Add("FileID", typeof(string));
			this.dtLot.Columns.Add("Tester", typeof(string));
			this.dtLot.Columns.Add("Lot", typeof(string));
			this.dtLot.Columns.Add("Oper", typeof(string));
			this.dtLot.Columns.Add("Dcc", typeof(string));
			this.dtLot.Columns.Add("Devcie", typeof(string));
			this.dtLot.Columns.Add("Program", typeof(string));
			this.dtLot.Columns.Add("Date", typeof(string));
			this.dtLotDcol = null;
			this.dtLotDcol = new DataTable();
			this.dtLotDcol.Columns.Add("Floor", typeof(string));
			this.dtLotDcol.Columns.Add("FileID", typeof(string));
			this.dtLotDcol.Columns.Add("Tester", typeof(string));
			this.dtLotDcol.Columns.Add("Lot", typeof(string));
			this.dtLotDcol.Columns.Add("Oper", typeof(string));
			this.dtLotDcol.Columns.Add("Dcc", typeof(string));
			this.dtLotDcol.Columns.Add("Devcie", typeof(string));
			this.dtLotDcol.Columns.Add("Program", typeof(string));
			this.dtLotDcol.Columns.Add("TestNo", typeof(string));
			this.dtLotDcol.Columns.Add("TestName", typeof(string));
			this.dtLotDcol.Columns.Add("MEAN", typeof(string));
			this.dtLotDcol.Columns.Add("SIGMA", typeof(string));
			this.dtLotDcol.Columns.Add("Low spec", typeof(string));
			this.dtLotDcol.Columns.Add("Low limit", typeof(string));
			this.dtLotDcol.Columns.Add("Result", typeof(string));
			this.dtLotDcol.Columns.Add("High limit", typeof(string));
			this.dtLotDcol.Columns.Add("High spec", typeof(string));
			this.dtLotDcol.Columns.Add("Unit", typeof(string));
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002578 File Offset: 0x00000778
		private void btnSearch_Click_1(object sender, EventArgs e)
		{
			this._barPrograss = new BarPrograss();
			this._barPrograss.progress_labelheader_set("Search data....");
			this._barPrograss.setValue(0);
			this._thread = new Thread(new ThreadStart(this.BarPrograssView));
			this._thread.Start();
			this._barPrograss.setMax(100);
			this.grid_Lot.DataSource = new object();
			this.grid_Data.DataSource = new object();
			this.grid_rawData.DataSource = new object();
			this.grid_Lot.Columns.Clear();
			this.grid_Data.Columns.Clear();
			try
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetDcolData] @startdate = '",
					this.dateTimeStart.Value.ToShortDateString(),
					"', @enddate = '",
					this.dateTimeEnd.Value.ToShortDateString(),
					"', @lot  = '",
					this.txtLot.Text,
					"'"
				});
				DataSet dataSet = this.mData._CommonQry.queryCall(sQuery);
				this._barPrograss.setValue(20);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					this.grid_Lot.Columns.Clear();
					this.grid_Lot.DataSource = dataSet.Tables[0];
					this._barPrograss.setValue(60);
					this.grid_Data.Columns.Clear();
					this.grid_Data.DataSource = dataSet.Tables[1];
					this._barPrograss.setValue(80);
					GridViewDataColumn gridViewDataColumn = new GridViewCommandColumn();
					((GridViewCommandColumn)gridViewDataColumn).TextAlignment = ContentAlignment.MiddleCenter;
					gridViewDataColumn.FieldName = "RawDataView";
					gridViewDataColumn.HeaderText = "RawData\nView";
					this.grid_Lot.Columns.Add(gridViewDataColumn);
					gridViewDataColumn = new GridViewCommandColumn();
					((GridViewCommandColumn)gridViewDataColumn).TextAlignment = ContentAlignment.MiddleCenter;
					gridViewDataColumn.FieldName = "RawDataDown";
					gridViewDataColumn.HeaderText = "RawData\nDownload";
					this.grid_Lot.Columns.Add(gridViewDataColumn);
					for (int i = 0; i < this.grid_Lot.Rows.Count; i++)
					{
						this.grid_Lot.Rows[i].Cells["RawDataDown"].Value = "Click";
						this.grid_Lot.Rows[i].Cells["RawDataView"].Value = "Click";
					}
					gridViewDataColumn = new GridViewCommandColumn();
					((GridViewCommandColumn)gridViewDataColumn).TextAlignment = ContentAlignment.MiddleCenter;
					gridViewDataColumn.FieldName = "RawDataView";
					gridViewDataColumn.HeaderText = "RawData\nView";
					this.grid_Data.Columns.Add(gridViewDataColumn);
					gridViewDataColumn = new GridViewCommandColumn();
					((GridViewCommandColumn)gridViewDataColumn).TextAlignment = ContentAlignment.MiddleCenter;
					gridViewDataColumn.FieldName = "RawDataDown";
					gridViewDataColumn.HeaderText = "RawData\nDownload";
					this.grid_Data.Columns.Add(gridViewDataColumn);
					for (int j = 0; j < this.grid_Data.Rows.Count; j++)
					{
						this.grid_Data.Rows[j].Cells["RawDataDown"].Value = "Click";
						this.grid_Data.Rows[j].Cells["RawDataView"].Value = "Click";
					}
					this._barPrograss.setValue(100);
					this.grid_Lot.AllowEditRow = false;
					this.grid_Lot.AllowAddNewRow = false;
					this.grid_Lot.ShowGroupPanel = false;
					this.grid_Lot.EnableFiltering = true;
					this.grid_Lot.EnableSorting = true;
					this.grid_Lot.EnableGrouping = true;
					this.grid_Lot.MasterView.TableHeaderRow.IsVisible = true;
					this.grid_Lot.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
					this.grid_Lot.Columns["Floor"].Width = 30;
					this.grid_Lot.Columns["P/F"].Width = 30;
					this.grid_Lot.Columns["FileID"].Width = 30;
					this.grid_Lot.Columns["TestType"].Width = 30;
					this.grid_Lot.Columns["Lot"].Width = 70;
					this.grid_Lot.Columns["DCC"].Width = 30;
					this.grid_Lot.Columns["Oper"].Width = 30;
					this.grid_Lot.Columns["Tester"].Width = 30;
					this.grid_Lot.Columns["Product"].Width = 80;
					this.grid_Lot.Columns["Device"].Width = 80;
					this.grid_Lot.Columns["Program"].Width = 100;
					this.grid_Data.AllowEditRow = false;
					this.grid_Data.AllowAddNewRow = false;
					this.grid_Data.ShowGroupPanel = false;
					this.grid_Data.EnableFiltering = true;
					this.grid_Data.EnableSorting = true;
					this.grid_Data.EnableGrouping = true;
					this.grid_Data.MasterView.TableHeaderRow.IsVisible = true;
					this.grid_Data.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
				else
				{
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
					RadMessageBox.Show(this, "Data does not exist", "CIMitarAnalysis", MessageBoxButtons.OK, RadMessageIcon.Error);
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

		// Token: 0x06000008 RID: 8 RVA: 0x00002BF0 File Offset: 0x00000DF0
		private void grid_Lot_CellClick(object sender, GridViewCellEventArgs e)
		{
			if (e.RowIndex > -1 && (e.Column.Name == "RawDataView" || e.Column.Name == "RawDataDown"))
			{
				string sFileID = this.grid_Lot.Rows[e.RowIndex].Cells["FileID"].Value.ToString();
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Search data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				if (e.Column.Name == "RawDataView")
				{
					this.grid_rawData.Columns.Clear();
					this.grid_rawData.DataSource = this.getDcolRawData(sFileID, string.Empty);
					this.grid_rawData.AllowEditRow = false;
					this.grid_rawData.AllowAddNewRow = false;
					this.grid_rawData.ShowGroupPanel = false;
					this.grid_rawData.EnableFiltering = true;
					this.grid_rawData.EnableSorting = true;
					this.grid_rawData.EnableGrouping = true;
					this.grid_rawData.MasterView.TableHeaderRow.IsVisible = true;
					this.grid_rawData.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
				}
				else if (e.Column.Name == "RawDataDown")
				{
					this.saveFileDialog.DefaultExt = ".csv";
					this.saveFileDialog.Filter = "csv files|*.csv";
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						DataTable dcolRawData = this.getDcolRawData(sFileID, string.Empty);
						ExcelControl.generateCSV(this.saveFileDialog.FileName, dcolRawData, false);
					}
				}
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002E08 File Offset: 0x00001008
		private void grid_Data_CellClick(object sender, GridViewCellEventArgs e)
		{
			if (e.RowIndex > -1 && (e.Column.Name == "RawDataView" || e.Column.Name == "RawDataDown"))
			{
				string sFileID = this.grid_Data.Rows[e.RowIndex].Cells["FileID"].Value.ToString();
				string sTestNo = this.grid_Data.Rows[e.RowIndex].Cells["TestNo"].Value.ToString();
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Search data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				if (e.Column.Name == "RawDataView")
				{
					this.grid_rawData.Columns.Clear();
					this.grid_rawData.DataSource = this.getDcolRawData(sFileID, sTestNo);
					this.grid_rawData.AllowEditRow = false;
					this.grid_rawData.AllowAddNewRow = false;
					this.grid_rawData.ShowGroupPanel = false;
					this.grid_rawData.EnableFiltering = true;
					this.grid_rawData.EnableSorting = true;
					this.grid_rawData.EnableGrouping = true;
					this.grid_rawData.MasterView.TableHeaderRow.IsVisible = true;
					this.grid_rawData.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
				}
				else if (e.Column.Name == "RawDataDown")
				{
					this.saveFileDialog.DefaultExt = ".csv";
					this.saveFileDialog.Filter = "csv files|*.csv";
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						DataTable dcolRawData = this.getDcolRawData(sFileID, sTestNo);
						ExcelControl.generateCSV(this.saveFileDialog.FileName, dcolRawData, false);
					}
				}
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00003048 File Offset: 0x00001248
		private DataTable getDcolRawData(string sFileID, string sTestNo)
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetDcolRawData] @fileid = '",
				sFileID,
				"', @testno = '",
				sTestNo,
				"'"
			});
			DataSet dataSet = this.mData._CommonQry.queryCall(sQuery);
			return dataSet.Tables[0];
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000030A4 File Offset: 0x000012A4
		private void grid_UnitList_SelectionChanged(object sender, EventArgs e)
		{
			SortedList sortedList = new SortedList();
			if (this.grid_Lot.SelectedRows.Count <= 0)
			{
				this.grid_Lot.ClearSelection();
				for (int i = 0; i < this.grid_Data.RowCount; i++)
				{
					this.grid_Data.Rows[i].IsVisible = true;
				}
				return;
			}
			string text = string.Empty;
			string empty = string.Empty;
			sortedList.Clear();
			for (int j = 0; j < this.grid_Lot.SelectedRows.Count; j++)
			{
				int index = this.grid_Lot.SelectedRows[j].Index;
				DataRowView dataRowView = (DataRowView)this.grid_Lot.SelectedRows[j].DataBoundItem;
				text = dataRowView["FileID"].ToString();
				sortedList.Add(text, text);
			}
			for (int k = 0; k < this.grid_Data.RowCount; k++)
			{
				string key = this.grid_Data.Rows[k].Cells["FileID"].Value.ToString();
				if (sortedList.ContainsKey(key))
				{
					this.grid_Data.Rows[k].IsVisible = true;
				}
				else
				{
					this.grid_Data.Rows[k].IsVisible = false;
				}
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00003204 File Offset: 0x00001404
		private void btnSave_Click(object sender, EventArgs e)
		{
			SortedList sortedList = new SortedList();
			sortedList.Add(0, (DataTable)this.grid_Data.DataSource);
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
				ExcelControl.SaveExcel(this.saveFileDialog.FileName, sortedList, true);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000032F2 File Offset: 0x000014F2
		private void radButton1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000032F4 File Offset: 0x000014F4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00003314 File Offset: 0x00001514
		private void InitializeComponent()
		{
			this.telerikMetroBlueTheme1 = new TelerikMetroBlueTheme();
			this.radThemeManager1 = new RadThemeManager();
			this.saveFileDialog = new SaveFileDialog();
			this.splitContainer1 = new SplitContainer();
			this.grid_Lot = new RadGridView();
			this.grid_Data = new RadGridView();
			this.radPanel2 = new RadPanel();
			this.radButton1 = new RadButton();
			this.txtLot = new RadTextBox();
			this.radLabel5 = new RadLabel();
			this.radLabel3 = new RadLabel();
			this.dateTimeEnd = new RadDateTimePicker();
			this.dateTimeStart = new RadDateTimePicker();
			this.label1 = new Label();
			this.btnSearch = new RadButton();
			this.btnSave = new RadButton();
			this.openFileDialog1 = new OpenFileDialog();
			this.radSplitContainer1 = new RadSplitContainer();
			this.splitPanel1 = new SplitPanel();
			this.splitPanel2 = new SplitPanel();
			this.grid_rawData = new RadGridView();
			((ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((ISupportInitialize)this.grid_Lot).BeginInit();
			((ISupportInitialize)this.grid_Lot.MasterTemplate).BeginInit();
			((ISupportInitialize)this.grid_Data).BeginInit();
			((ISupportInitialize)this.grid_Data.MasterTemplate).BeginInit();
			((ISupportInitialize)this.radPanel2).BeginInit();
			this.radPanel2.SuspendLayout();
			((ISupportInitialize)this.radButton1).BeginInit();
			((ISupportInitialize)this.txtLot).BeginInit();
			((ISupportInitialize)this.radLabel5).BeginInit();
			((ISupportInitialize)this.radLabel3).BeginInit();
			((ISupportInitialize)this.dateTimeEnd).BeginInit();
			((ISupportInitialize)this.dateTimeStart).BeginInit();
			((ISupportInitialize)this.btnSearch).BeginInit();
			((ISupportInitialize)this.btnSave).BeginInit();
			((ISupportInitialize)this.radSplitContainer1).BeginInit();
			this.radSplitContainer1.SuspendLayout();
			((ISupportInitialize)this.splitPanel1).BeginInit();
			this.splitPanel1.SuspendLayout();
			((ISupportInitialize)this.splitPanel2).BeginInit();
			this.splitPanel2.SuspendLayout();
			((ISupportInitialize)this.grid_rawData).BeginInit();
			((ISupportInitialize)this.grid_rawData.MasterTemplate).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = DockStyle.Fill;
			this.splitContainer1.Location = new Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = Orientation.Horizontal;
			this.splitContainer1.Panel1.Controls.Add(this.grid_Lot);
			this.splitContainer1.Panel2.Controls.Add(this.grid_Data);
			this.splitContainer1.Size = new Size(769, 572);
			this.splitContainer1.SplitterDistance = 286;
			this.splitContainer1.TabIndex = 2;
			this.grid_Lot.Dock = DockStyle.Fill;
			this.grid_Lot.Location = new Point(0, 0);
			this.grid_Lot.MasterTemplate.MultiSelect = true;
			this.grid_Lot.Name = "grid_Lot";
			this.grid_Lot.Size = new Size(769, 286);
			this.grid_Lot.TabIndex = 2;
			this.grid_Lot.SelectionChanged += this.grid_UnitList_SelectionChanged;
			this.grid_Lot.CellClick += this.grid_Lot_CellClick;
			this.grid_Data.Dock = DockStyle.Fill;
			this.grid_Data.Location = new Point(0, 0);
			this.grid_Data.MasterTemplate.MultiSelect = true;
			this.grid_Data.Name = "grid_Data";
			this.grid_Data.Size = new Size(769, 282);
			this.grid_Data.TabIndex = 3;
			this.grid_Data.CellClick += this.grid_Data_CellClick;
			this.radPanel2.BackColor = Color.White;
			this.radPanel2.Controls.Add(this.radButton1);
			this.radPanel2.Controls.Add(this.txtLot);
			this.radPanel2.Controls.Add(this.radLabel5);
			this.radPanel2.Controls.Add(this.radLabel3);
			this.radPanel2.Controls.Add(this.dateTimeEnd);
			this.radPanel2.Controls.Add(this.dateTimeStart);
			this.radPanel2.Controls.Add(this.label1);
			this.radPanel2.Controls.Add(this.btnSearch);
			this.radPanel2.Controls.Add(this.btnSave);
			this.radPanel2.Dock = DockStyle.Top;
			this.radPanel2.Location = new Point(0, 0);
			this.radPanel2.Name = "radPanel2";
			this.radPanel2.Size = new Size(1000, 41);
			this.radPanel2.TabIndex = 27;
			this.radButton1.Location = new Point(764, 8);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new Size(50, 29);
			this.radButton1.TabIndex = 175;
			this.radButton1.Text = "Save";
			this.radButton1.ThemeName = "TelerikMetroBlue";
			this.radButton1.Visible = false;
			this.radButton1.Click += this.radButton1_Click;
			this.txtLot.Location = new Point(321, 12);
			this.txtLot.Name = "txtLot";
			this.txtLot.Size = new Size(233, 20);
			this.txtLot.TabIndex = 174;
			this.radLabel5.Location = new Point(293, 13);
			this.radLabel5.Name = "radLabel5";
			this.radLabel5.Size = new Size(22, 18);
			this.radLabel5.TabIndex = 173;
			this.radLabel5.Text = "Lot";
			this.radLabel3.Location = new Point(12, 13);
			this.radLabel3.Name = "radLabel3";
			this.radLabel3.Size = new Size(30, 18);
			this.radLabel3.TabIndex = 172;
			this.radLabel3.Text = "Date";
			this.dateTimeEnd.Format = DateTimePickerFormat.Short;
			this.dateTimeEnd.Location = new Point(182, 12);
			this.dateTimeEnd.Name = "dateTimeEnd";
			this.dateTimeEnd.Size = new Size(92, 20);
			this.dateTimeEnd.TabIndex = 170;
			this.dateTimeEnd.TabStop = false;
			this.dateTimeEnd.Text = "2020-04-03";
			this.dateTimeEnd.Value = new DateTime(2020, 4, 3, 15, 36, 44, 994);
			this.dateTimeStart.CustomFormat = "yyyy-MM-dd";
			this.dateTimeStart.Format = DateTimePickerFormat.Short;
			this.dateTimeStart.Location = new Point(51, 12);
			this.dateTimeStart.Name = "dateTimeStart";
			this.dateTimeStart.Size = new Size(92, 20);
			this.dateTimeStart.TabIndex = 169;
			this.dateTimeStart.TabStop = false;
			this.dateTimeStart.Text = "2020-04-03";
			this.dateTimeStart.Value = new DateTime(2020, 4, 3, 0, 0, 0, 0);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(155, 15);
			this.label1.Name = "label1";
			this.label1.Size = new Size(15, 13);
			this.label1.TabIndex = 171;
			this.label1.Text = "~";
			this.btnSearch.Location = new Point(560, 6);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new Size(53, 29);
			this.btnSearch.TabIndex = 166;
			this.btnSearch.Text = "Search";
			this.btnSearch.ThemeName = "TelerikMetroBlue";
			this.btnSearch.Click += this.btnSearch_Click_1;
			this.btnSave.Location = new Point(619, 6);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new Size(50, 29);
			this.btnSave.TabIndex = 164;
			this.btnSave.Text = "Save";
			this.btnSave.ThemeName = "TelerikMetroBlue";
			this.btnSave.Click += this.btnSave_Click;
			this.openFileDialog1.FileName = "openFileDialog1";
			this.radSplitContainer1.Controls.Add(this.splitPanel1);
			this.radSplitContainer1.Controls.Add(this.splitPanel2);
			this.radSplitContainer1.Dock = DockStyle.Fill;
			this.radSplitContainer1.Location = new Point(0, 41);
			this.radSplitContainer1.Name = "radSplitContainer1";
			this.radSplitContainer1.RootElement.MinSize = new Size(25, 25);
			this.radSplitContainer1.Size = new Size(1000, 572);
			this.radSplitContainer1.TabIndex = 28;
			this.radSplitContainer1.TabStop = false;
			this.radSplitContainer1.Text = "radSplitContainer1";
			this.splitPanel1.Controls.Add(this.splitContainer1);
			this.splitPanel1.Location = new Point(0, 0);
			this.splitPanel1.Name = "splitPanel1";
			this.splitPanel1.RootElement.MinSize = new Size(25, 25);
			this.splitPanel1.Size = new Size(769, 572);
			this.splitPanel1.SizeInfo.AutoSizeScale = new SizeF(0.2722661f, 0f);
			this.splitPanel1.SizeInfo.SplitterCorrection = new Size(241, 0);
			this.splitPanel1.TabIndex = 0;
			this.splitPanel1.TabStop = false;
			this.splitPanel1.Text = "splitPanel1";
			this.splitPanel2.Controls.Add(this.grid_rawData);
			this.splitPanel2.Location = new Point(773, 0);
			this.splitPanel2.Name = "splitPanel2";
			this.splitPanel2.RootElement.MinSize = new Size(25, 25);
			this.splitPanel2.Size = new Size(227, 572);
			this.splitPanel2.SizeInfo.AutoSizeScale = new SizeF(-0.2722661f, 0f);
			this.splitPanel2.SizeInfo.SplitterCorrection = new Size(-241, 0);
			this.splitPanel2.TabIndex = 1;
			this.splitPanel2.TabStop = false;
			this.splitPanel2.Text = "splitPanel2";
			this.grid_rawData.Dock = DockStyle.Fill;
			this.grid_rawData.Location = new Point(0, 0);
			this.grid_rawData.MasterTemplate.MultiSelect = true;
			this.grid_rawData.Name = "grid_rawData";
			this.grid_rawData.Size = new Size(227, 572);
			this.grid_rawData.TabIndex = 4;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.radSplitContainer1);
			base.Controls.Add(this.radPanel2);
			base.Name = "DataView";
			base.Size = new Size(1000, 613);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((ISupportInitialize)this.grid_Lot.MasterTemplate).EndInit();
			((ISupportInitialize)this.grid_Lot).EndInit();
			((ISupportInitialize)this.grid_Data.MasterTemplate).EndInit();
			((ISupportInitialize)this.grid_Data).EndInit();
			((ISupportInitialize)this.radPanel2).EndInit();
			this.radPanel2.ResumeLayout(false);
			this.radPanel2.PerformLayout();
			((ISupportInitialize)this.radButton1).EndInit();
			((ISupportInitialize)this.txtLot).EndInit();
			((ISupportInitialize)this.radLabel5).EndInit();
			((ISupportInitialize)this.radLabel3).EndInit();
			((ISupportInitialize)this.dateTimeEnd).EndInit();
			((ISupportInitialize)this.dateTimeStart).EndInit();
			((ISupportInitialize)this.btnSearch).EndInit();
			((ISupportInitialize)this.btnSave).EndInit();
			((ISupportInitialize)this.radSplitContainer1).EndInit();
			this.radSplitContainer1.ResumeLayout(false);
			((ISupportInitialize)this.splitPanel1).EndInit();
			this.splitPanel1.ResumeLayout(false);
			((ISupportInitialize)this.splitPanel2).EndInit();
			this.splitPanel2.ResumeLayout(false);
			((ISupportInitialize)this.grid_rawData.MasterTemplate).EndInit();
			((ISupportInitialize)this.grid_rawData).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000001 RID: 1
		private cMainData mData = new cMainData();

		// Token: 0x04000002 RID: 2
		private DataSet _dsMain = new DataSet();

		// Token: 0x04000003 RID: 3
		private DataTable dtLot = new DataTable();

		// Token: 0x04000004 RID: 4
		private DataTable dtLotDcol = new DataTable();

		// Token: 0x04000005 RID: 5
		private Thread _thread;

		// Token: 0x04000006 RID: 6
		private BarPrograss _barPrograss;

		// Token: 0x04000007 RID: 7
		private IContainer components;

		// Token: 0x04000008 RID: 8
		private TelerikMetroBlueTheme telerikMetroBlueTheme1;

		// Token: 0x04000009 RID: 9
		private RadThemeManager radThemeManager1;

		// Token: 0x0400000A RID: 10
		private SaveFileDialog saveFileDialog;

		// Token: 0x0400000B RID: 11
		private SplitContainer splitContainer1;

		// Token: 0x0400000C RID: 12
		private RadGridView grid_Lot;

		// Token: 0x0400000D RID: 13
		private RadGridView grid_Data;

		// Token: 0x0400000E RID: 14
		private RadPanel radPanel2;

		// Token: 0x0400000F RID: 15
		private RadTextBox txtLot;

		// Token: 0x04000010 RID: 16
		private RadLabel radLabel5;

		// Token: 0x04000011 RID: 17
		private RadLabel radLabel3;

		// Token: 0x04000012 RID: 18
		private RadDateTimePicker dateTimeEnd;

		// Token: 0x04000013 RID: 19
		private RadDateTimePicker dateTimeStart;

		// Token: 0x04000014 RID: 20
		private Label label1;

		// Token: 0x04000015 RID: 21
		private RadButton btnSearch;

		// Token: 0x04000016 RID: 22
		private RadButton btnSave;

		// Token: 0x04000017 RID: 23
		private RadButton radButton1;

		// Token: 0x04000018 RID: 24
		private OpenFileDialog openFileDialog1;

		// Token: 0x04000019 RID: 25
		private RadSplitContainer radSplitContainer1;

		// Token: 0x0400001A RID: 26
		private SplitPanel splitPanel1;

		// Token: 0x0400001B RID: 27
		private SplitPanel splitPanel2;

		// Token: 0x0400001C RID: 28
		private RadGridView grid_rawData;
	}
}
