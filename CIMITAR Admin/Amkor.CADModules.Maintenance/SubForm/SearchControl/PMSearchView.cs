using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.SubForm.search;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.Maintenance.SubForm.SearchControl
{
	// Token: 0x02000050 RID: 80
	public class PMSearchView : UserControl
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600045E RID: 1118 RVA: 0x00081EF7 File Offset: 0x000800F7
		// (set) Token: 0x0600045D RID: 1117 RVA: 0x00081EEE File Offset: 0x000800EE
		public int ColumnCount { get; private set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x00081F08 File Offset: 0x00080108
		// (set) Token: 0x0600045F RID: 1119 RVA: 0x00081EFF File Offset: 0x000800FF
		public int RowCount { get; private set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000462 RID: 1122 RVA: 0x00081F19 File Offset: 0x00080119
		// (set) Token: 0x06000461 RID: 1121 RVA: 0x00081F10 File Offset: 0x00080110
		public RadGridView gridView { get; private set; }

		// Token: 0x06000463 RID: 1123 RVA: 0x00081F24 File Offset: 0x00080124
		public PMSearchView(FactorySettings factorySettings, CIMitarAccount cimitarUser, SearchForm topParent)
		{
			this._factorySettings = factorySettings;
			this._cimitarUser = cimitarUser;
			this._topParent = topParent;
			this.InitializeComponent();
			this.InitializeGrid();
			this.Dock = DockStyle.Fill;
			this.gridView = this.radGridView;
			this.ColumnCount = this.radGridView.Columns.Count;
			this.RowCount = this.radGridView.Rows.Count;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00081FB0 File Offset: 0x000801B0
		private void InitializeGrid()
		{
			this.radGridView.ShowHeaderCellButtons = true;
			this.radGridView.EnableFiltering = true;
			this.radGridView.ShowFilteringRow = false;
			this.radGridView.MasterTemplate.AllowAddNewRow = false;
			this.radGridView.MultiSelect = false;
			this.radGridView.ColumnChooser.StartPosition = FormStartPosition.CenterParent;
			this.radGridView.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView.AllowEditRow = false;
			this.radGridView.SelectionMode = GridViewSelectionMode.CellSelect;
			this.radGridView.AllowColumnReorder = false;
			this.radGridView.AllowRowReorder = false;
			this.radGridView.AllowRowResize = false;
			this.radGridView.AllowDragToGroup = false;
			this.radGridView.ShowGroupPanel = false;
			this.radGridView.AllowColumnHeaderContextMenu = false;
			this.SetHeaderInfo();
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00082098 File Offset: 0x00080298
		private void SetHeaderInfo()
		{
			this._dataTable = new DataTable();
			string[] array = "No.,Status,Report No.,Request Time,Category,Model,M/C#(Location#),Rsc Dec(Board#),Asset,Case,Factor,Work Type,Problems or Reason of use,Evidence (PCS pre-approval),Approval Comment,Action and Changes,Result and Evaluation,Comment,Final Comment".Split(new char[]
			{
				','
			});
			foreach (string columnName in array)
			{
				DataColumn column = new DataColumn(columnName);
				this._dataTable.Columns.Add(column);
			}
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x000820FC File Offset: 0x000802FC
		private void clear()
		{
			this.ColumnCount = this.radGridView.Columns.Count;
			this.RowCount = this.radGridView.Rows.Count;
			this.radGridView.MasterTemplate.Columns.Clear();
			this.radGridView.GroupDescriptors.Clear();
			this.radGridView.SortDescriptors.Clear();
			this.radGridView.DataSource = null;
			this.radGridView.CommandCellClick -= this.radGridView_CommandCellClick;
			this.SetHeaderInfo();
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0008219C File Offset: 0x0008039C
		private void BindToDataSet()
		{
			ConditionalFormattingObject conditionalFormattingObject = new ConditionalFormattingObject("PM(Request)", ConditionTypes.Equal, "PM(Request)", "", true);
			ConditionalFormattingObject conditionalFormattingObject2 = new ConditionalFormattingObject("PM(Approval)", ConditionTypes.Equal, "PM(Approval)", "", true);
			ConditionalFormattingObject conditionalFormattingObject3 = new ConditionalFormattingObject("PM(Done)", ConditionTypes.Equal, "PM(Done)", "", true);
			ConditionalFormattingObject conditionalFormattingObject4 = new ConditionalFormattingObject("PM(Final)", ConditionTypes.Equal, "PM(Final)", "", true);
			ConditionalFormattingObject conditionalFormattingObject5 = new ConditionalFormattingObject("PM(Cancel)", ConditionTypes.Equal, "PM(Cancel)", "", true);
			conditionalFormattingObject.RowBackColor = (conditionalFormattingObject3.RowBackColor = (conditionalFormattingObject2.RowBackColor = Color.FromArgb(218, 217, 255)));
			this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject);
			this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject2);
			this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject3);
			conditionalFormattingObject4.RowBackColor = Color.Silver;
			this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject4);
			conditionalFormattingObject5.RowBackColor = Color.FromArgb(250, 224, 212);
			this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject5);
			this.radGridView.Columns["Report No."].AllowFiltering = false;
			this.radGridView.Columns["View"].AllowFiltering = false;
			this.radGridView.Columns["Request Time"].AllowFiltering = false;
			this.radGridView.Columns["Problems or Reason of use"].AllowFiltering = false;
			this.radGridView.Columns["Evidence (PCS pre-approval)"].AllowFiltering = false;
			this.radGridView.Columns["Approval Comment"].AllowFiltering = false;
			this.radGridView.Columns["Action and Changes"].AllowFiltering = false;
			this.radGridView.Columns["Result and Evaluation"].AllowFiltering = false;
			this.radGridView.Columns["Comment"].AllowFiltering = false;
			this.radGridView.Columns["Final Comment"].AllowFiltering = false;
			this.radGridView.AutoSizeRows = true;
			this.ColumnCount = this.radGridView.Columns.Count;
			this.RowCount = this.radGridView.Rows.Count;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00082474 File Offset: 0x00080674
		public void makeViewButtonColumn()
		{
			GridViewCommandColumn gridViewCommandColumn = new GridViewCommandColumn();
			gridViewCommandColumn.HeaderText = "View";
			gridViewCommandColumn.FieldName = "View";
			gridViewCommandColumn.TextAlignment = ContentAlignment.MiddleCenter;
			gridViewCommandColumn.Width = 40;
			gridViewCommandColumn.VisibleInColumnChooser = false;
			this.radGridView.CommandCellClick += this.radGridView_CommandCellClick;
			this.radGridView.MasterTemplate.Columns.Add(gridViewCommandColumn);
			this.radGridView.Columns.Move(this.radGridView.Columns.Count - 1, 3);
			foreach (GridViewRowInfo gridViewRowInfo in this.radGridView.Rows)
			{
				gridViewRowInfo.Cells["View"].Value = "View";
			}
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0008256C File Offset: 0x0008076C
		public void SetGridInfo(ReportList reportList)
		{
			this.clear();
			this._dataTable.BeginLoadData();
			bool flag = reportList.listReport.Count != 0;
			if (flag)
			{
				int num = 0;
				foreach (ReportList.ReportObject reportObject in reportList.listReport)
				{
					DataRow dataRow = this._dataTable.NewRow();
					DataRow dataRow2 = dataRow;
					string columnName = "No.";
					int num2;
					num = (num2 = num + 1);
					dataRow2[columnName] = num2.ToString();
					dataRow["Status"] = reportObject.Status;
					dataRow["Report No."] = reportObject.Report;
					dataRow["Request Time"] = reportObject.RequestTime;
					dataRow["Asset"] = reportObject.PMAsset;
					dataRow["Work Type"] = reportObject.PMWorkType;
					dataRow["Category"] = reportObject.Category;
					dataRow["M/C#(Location#)"] = reportObject.Machine;
					dataRow["Rsc Dec(Board#)"] = reportObject.RscDec;
					dataRow["Model"] = reportObject.Model;
					dataRow["Case"] = reportObject.Case;
					dataRow["Factor"] = reportObject.Factor;
					dataRow["Problems or Reason of use"] = reportObject.Content1;
					dataRow["Evidence (PCS pre-approval)"] = reportObject.Content8;
					dataRow["Approval Comment"] = reportObject.Content2;
					dataRow["Action and Changes"] = reportObject.Content3;
					dataRow["Result and Evaluation"] = reportObject.Content4;
					dataRow["Comment"] = reportObject.Content5;
					dataRow["Final Comment"] = reportObject.Content6;
					this._dataTable.Rows.Add(dataRow);
				}
			}
			this._dataTable.EndLoadData();
			this.radGridView.DataSource = this._dataTable;
			this.makeViewButtonColumn();
			this.BindToDataSet();
			this.radGridView.MasterTemplate.BestFitColumns();
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void radGridView_FilterPopupInitialized(object sende, FilterPopupInitializedEventArgs e)
		{
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x000827CC File Offset: 0x000809CC
		private void radGridView_FilterPopupRequired(object sender, FilterPopupRequiredEventArgs e)
		{
			RadListFilterPopup radListFilterPopup = e.FilterPopup as RadListFilterPopup;
			radListFilterPopup.TextBoxMenuItem.Font = new Font(radListFilterPopup.TextBoxMenuItem.Font.FontFamily, 15f);
			radListFilterPopup.TextBoxMenuItem.AutoSize = false;
			radListFilterPopup.TextBoxMenuItem.Size = new Size(radListFilterPopup.Width, 40);
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00082834 File Offset: 0x00080A34
		private void radGridView_CommandCellClick(object sender, EventArgs e)
		{
			GridViewRowInfo rowInfo = this.radGridView.SelectedCells[this.radGridView.SelectedCells.Count - 1].RowInfo;
			GridViewColumn columnInfo = this.radGridView.SelectedCells[this.radGridView.SelectedCells.Count - 1].ColumnInfo;
			bool flag = rowInfo.Index < 0 || columnInfo.Index < 0;
			if (!flag)
			{
				string sReport = rowInfo.Cells["Report No."].Value.ToString();
				string text = rowInfo.Cells["Status"].Value.ToString();
				cAction cAction = new cAction(sReport, this._factorySettings, this._cimitarUser);
				bool @checked = this._topParent.checkWebView.Checked;
				if (@checked)
				{
					bool flag2 = text.ToUpper().Trim().IndexOf("HOLD") == -1;
					if (flag2)
					{
						this._topParent.panelWebView.Visible = true;
						bool flag3 = text.ToUpper().Trim().IndexOf("CLOSE") != -1;
						if (flag3)
						{
							this._topParent.loadMailForm(true, true);
						}
						else
						{
							this._topParent.loadMailForm(false, true);
						}
					}
					else
					{
						cAction.ShowDialog();
					}
				}
				else
				{
					cAction.ShowDialog();
				}
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x000829A0 File Offset: 0x00080BA0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x000829D8 File Offset: 0x00080BD8
		private void InitializeComponent()
		{
			this.telerikMetroBlueTheme1 = new TelerikMetroBlueTheme();
			this.panel25 = new Panel();
			this.radGridView = new RadGridView();
			this.panel25.SuspendLayout();
			((ISupportInitialize)this.radGridView).BeginInit();
			((ISupportInitialize)this.radGridView.MasterTemplate).BeginInit();
			base.SuspendLayout();
			this.panel25.Controls.Add(this.radGridView);
			this.panel25.Dock = DockStyle.Fill;
			this.panel25.Location = new Point(0, 0);
			this.panel25.Name = "panel25";
			this.panel25.Size = new Size(881, 425);
			this.panel25.TabIndex = 22;
			this.radGridView.BackColor = SystemColors.ControlLightLight;
			this.radGridView.Dock = DockStyle.Fill;
			this.radGridView.Location = new Point(0, 0);
			this.radGridView.Name = "radGridView_Result";
			this.radGridView.RootElement.AccessibleDescription = null;
			this.radGridView.RootElement.AccessibleName = null;
			this.radGridView.RootElement.ControlBounds = new Rectangle(0, 0, 240, 150);
			this.radGridView.Size = new Size(881, 425);
			this.radGridView.TabIndex = 33;
			this.radGridView.ThemeName = "TelerikMetroBlue";
			this.radGridView.FilterPopupRequired += this.radGridView_FilterPopupRequired;
			this.radGridView.FilterPopupInitialized += this.radGridView_FilterPopupInitialized;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel25);
			base.Name = "MaintStatus";
			base.Size = new Size(881, 425);
			this.panel25.ResumeLayout(false);
			((ISupportInitialize)this.radGridView.MasterTemplate).EndInit();
			((ISupportInitialize)this.radGridView).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000716 RID: 1814
		private const string _defaultHeader2 = "No.,Status,Report No.,Request Time,Category,Model,M/C#(Location#),Rsc Dec(Board#),Asset,Case,Factor,Work Type,Problems or Reason of use,Evidence (PCS pre-approval),Approval Comment,Action and Changes,Result and Evaluation,Comment,Final Comment";

		// Token: 0x04000717 RID: 1815
		private DataTable _dataTable = null;

		// Token: 0x04000718 RID: 1816
		private readonly FactorySettings _factorySettings;

		// Token: 0x04000719 RID: 1817
		private readonly SearchForm _topParent;

		// Token: 0x0400071A RID: 1818
		private readonly CIMitarAccount _cimitarUser;

		// Token: 0x0400071E RID: 1822
		private IContainer components = null;

		// Token: 0x0400071F RID: 1823
		private TelerikMetroBlueTheme telerikMetroBlueTheme1;

		// Token: 0x04000720 RID: 1824
		private Panel panel25;

		// Token: 0x04000721 RID: 1825
		private RadGridView radGridView;
	}
}
