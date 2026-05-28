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
	// Token: 0x02000051 RID: 81
	public class MaintSearchView : UserControl
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x00082C1D File Offset: 0x00080E1D
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x00082C14 File Offset: 0x00080E14
		public int ColumnCount { get; private set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x00082C2E File Offset: 0x00080E2E
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x00082C25 File Offset: 0x00080E25
		public int RowCount { get; private set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x00082C3F File Offset: 0x00080E3F
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x00082C36 File Offset: 0x00080E36
		public RadGridView gridView { get; private set; }

		// Token: 0x06000475 RID: 1141 RVA: 0x00082C48 File Offset: 0x00080E48
		public MaintSearchView(FactorySettings factorySettings, CIMitarAccount cimitarUser, SearchForm topParent)
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

		// Token: 0x06000476 RID: 1142 RVA: 0x00082CD4 File Offset: 0x00080ED4
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

		// Token: 0x06000477 RID: 1143 RVA: 0x00082DBC File Offset: 0x00080FBC
		private void SetHeaderInfo()
		{
			this._dataTable = new DataTable();
			string[] array = "No.,Status,Report No.,Request Time,Category,Model,M/C#(Location#),Rsc Dec(Board#),Case,Factor,Check Item,Requirement,Problem,Action".Split(new char[]
			{
				','
			});
			foreach (string columnName in array)
			{
				DataColumn column = new DataColumn(columnName);
				this._dataTable.Columns.Add(column);
			}
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00082E20 File Offset: 0x00081020
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

		// Token: 0x06000479 RID: 1145 RVA: 0x00082EC0 File Offset: 0x000810C0
		private void BindToDataSet()
		{
			ConditionalFormattingObject conditionalFormattingObject = new ConditionalFormattingObject("Request", ConditionTypes.Equal, "Request", "", true);
			conditionalFormattingObject.RowBackColor = Color.FromArgb(242, 203, 98);
			this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject);
			ConditionalFormattingObject conditionalFormattingObject2 = new ConditionalFormattingObject("Close", ConditionTypes.Equal, "Close", "", true);
			conditionalFormattingObject2.RowBackColor = Color.Silver;
			this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject2);
			ConditionalFormattingObject conditionalFormattingObject3 = new ConditionalFormattingObject("Hold", ConditionTypes.Equal, "Hold", "", true);
			conditionalFormattingObject3.RowBackColor = Color.Yellow;
			this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject3);
			ConditionalFormattingObject conditionalFormattingObject4 = new ConditionalFormattingObject("Close(H)", ConditionTypes.Equal, "Close(H)", "", true);
			conditionalFormattingObject4.RowBackColor = Color.Silver;
			this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject4);
			this.radGridView.Columns["Report No."].AllowFiltering = false;
			this.radGridView.Columns["View"].AllowFiltering = false;
			this.radGridView.Columns["Request Time"].AllowFiltering = false;
			this.radGridView.Columns["Check Item"].AllowFiltering = false;
			this.radGridView.Columns["Requirement"].AllowFiltering = false;
			this.radGridView.Columns["Problem"].AllowFiltering = false;
			this.radGridView.Columns["Action"].AllowFiltering = false;
			this.radGridView.AutoSizeRows = true;
			this.ColumnCount = this.radGridView.Columns.Count;
			this.RowCount = this.radGridView.Rows.Count;
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x000830EC File Offset: 0x000812EC
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

		// Token: 0x0600047B RID: 1147 RVA: 0x000831E4 File Offset: 0x000813E4
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
					dataRow["Category"] = reportObject.Category;
					dataRow["M/C#(Location#)"] = reportObject.Machine;
					dataRow["Rsc Dec(Board#)"] = reportObject.RscDec;
					dataRow["Model"] = reportObject.Model;
					dataRow["Case"] = reportObject.Case;
					dataRow["Factor"] = reportObject.Factor;
					dataRow["Check Item"] = reportObject.CheckItem;
					dataRow["Requirement"] = reportObject.Requirment;
					dataRow["Problem"] = reportObject.Problem;
					dataRow["Action"] = reportObject.Action;
					this._dataTable.Rows.Add(dataRow);
				}
			}
			this._dataTable.EndLoadData();
			this.radGridView.DataSource = this._dataTable;
			this.makeViewButtonColumn();
			this.BindToDataSet();
			this.radGridView.MasterTemplate.BestFitColumns();
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void radGridView_FilterPopupInitialized(object sende, FilterPopupInitializedEventArgs e)
		{
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x000833E4 File Offset: 0x000815E4
		private void radGridView_FilterPopupRequired(object sender, FilterPopupRequiredEventArgs e)
		{
			RadListFilterPopup radListFilterPopup = e.FilterPopup as RadListFilterPopup;
			radListFilterPopup.TextBoxMenuItem.Font = new Font(radListFilterPopup.TextBoxMenuItem.Font.FontFamily, 15f);
			radListFilterPopup.TextBoxMenuItem.AutoSize = false;
			radListFilterPopup.TextBoxMenuItem.Size = new Size(radListFilterPopup.Width, 40);
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0008344C File Offset: 0x0008164C
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
							this._topParent.loadMailForm(true, false);
						}
						else
						{
							this._topParent.loadMailForm(false, false);
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

		// Token: 0x0600047F RID: 1151 RVA: 0x000835B8 File Offset: 0x000817B8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x000835F0 File Offset: 0x000817F0
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
			base.Name = "MaintSearchView";
			base.Size = new Size(881, 425);
			this.panel25.ResumeLayout(false);
			((ISupportInitialize)this.radGridView.MasterTemplate).EndInit();
			((ISupportInitialize)this.radGridView).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000722 RID: 1826
		private const string _defaultHeader2 = "No.,Status,Report No.,Request Time,Category,Model,M/C#(Location#),Rsc Dec(Board#),Case,Factor,Check Item,Requirement,Problem,Action";

		// Token: 0x04000723 RID: 1827
		private DataTable _dataTable = null;

		// Token: 0x04000724 RID: 1828
		private readonly FactorySettings _factorySettings;

		// Token: 0x04000725 RID: 1829
		private readonly CIMitarAccount _cimitarUser;

		// Token: 0x04000729 RID: 1833
		private readonly SearchForm _topParent;

		// Token: 0x0400072A RID: 1834
		private IContainer components = null;

		// Token: 0x0400072B RID: 1835
		private TelerikMetroBlueTheme telerikMetroBlueTheme1;

		// Token: 0x0400072C RID: 1836
		private Panel panel25;

		// Token: 0x0400072D RID: 1837
		private RadGridView radGridView;
	}
}
