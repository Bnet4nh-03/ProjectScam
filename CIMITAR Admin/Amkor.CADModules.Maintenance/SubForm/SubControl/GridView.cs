using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.SubForm.search;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000036 RID: 54
	public class GridView : UserControl
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600035A RID: 858 RVA: 0x00068F64 File Offset: 0x00067164
		// (remove) Token: 0x0600035B RID: 859 RVA: 0x00068F9C File Offset: 0x0006719C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private event EventHandler _SearchClick;

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00068FDA File Offset: 0x000671DA
		// (set) Token: 0x0600035C RID: 860 RVA: 0x00068FD1 File Offset: 0x000671D1
		public int ColumnCount { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600035F RID: 863 RVA: 0x00068FEB File Offset: 0x000671EB
		// (set) Token: 0x0600035E RID: 862 RVA: 0x00068FE2 File Offset: 0x000671E2
		public int RowCount { get; private set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000361 RID: 865 RVA: 0x00068FFC File Offset: 0x000671FC
		// (set) Token: 0x06000360 RID: 864 RVA: 0x00068FF3 File Offset: 0x000671F3
		public RadGridView gridView { get; private set; }

		// Token: 0x06000362 RID: 866 RVA: 0x00069004 File Offset: 0x00067204
		public GridView(GridViewType type, FactorySettings factorySettings, CIMitarAccount cimitarUser, string defaultHeader, EventHandler clickEvent)
		{
			this._factorySettings = factorySettings;
			this._cimitarUser = cimitarUser;
			this._defaultHeader = defaultHeader;
			this._SearchClick = clickEvent;
			this.InitializeComponent();
			this.InitializeGrid();
			this.Dock = DockStyle.Fill;
			this._type = type;
			this.gridView = this.radGridView;
			this.ColumnCount = this.radGridView.Columns.Count;
			this.RowCount = this.radGridView.Rows.Count;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x000690C8 File Offset: 0x000672C8
		public GridView(GridViewType type, FactorySettings factorySettings, CIMitarAccount cimitarUser, string defaultHeader, SearchForm topParent, EventHandler clickEvent)
		{
			this._factorySettings = factorySettings;
			this._cimitarUser = cimitarUser;
			this._defaultHeader = defaultHeader;
			this._topParent = topParent;
			this._SearchClick = clickEvent;
			this.InitializeComponent();
			this.InitializeGrid();
			this._type = type;
			this.Dock = DockStyle.Fill;
			this.gridView = this.radGridView;
			this.ColumnCount = this.radGridView.Columns.Count;
			this.RowCount = this.radGridView.Rows.Count;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00069194 File Offset: 0x00067394
		private void InitializeGrid()
		{
			this.radGridView.ShowHeaderCellButtons = true;
			this.radGridView.EnableFiltering = true;
			this.radGridView.ShowFilteringRow = false;
			this.radGridView.MasterTemplate.AllowAddNewRow = false;
			this.radGridView.MultiSelect = false;
			this.radGridView.ColumnChooser.StartPosition = FormStartPosition.CenterParent;
			this.radGridView.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView.SelectionMode = GridViewSelectionMode.CellSelect;
			this.radGridView.AllowDragToGroup = false;
			this.radGridView.ShowGroupPanel = false;
			this.radGridView.AllowEditRow = false;
			this.radGridView.AllowColumnReorder = true;
			this.radGridView.AllowRowReorder = false;
			this.radGridView.AllowRowResize = false;
			this.radGridView.AllowColumnHeaderContextMenu = true;
			this.radGridView.MasterTemplate.ShowRowHeaderColumn = false;
			this.radGridView.AutoSizeRows = true;
			this.SetHeaderInfo();
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0006929C File Offset: 0x0006749C
		private void SetHeaderInfo()
		{
			this._dataTable = new DataTable();
			string[] array = this._defaultHeader.Split(new char[]
			{
				','
			});
			foreach (string columnName in array)
			{
				DataColumn column = new DataColumn(columnName);
				this._dataTable.Columns.Add(column);
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00069300 File Offset: 0x00067500
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

		// Token: 0x06000367 RID: 871 RVA: 0x000693A0 File Offset: 0x000675A0
		private void BindToDataSet()
		{
			bool flag = this._type == GridViewType.HISTORY_MAINT || this._type == GridViewType.SEARCH_MAINT;
			if (flag)
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
			}
			else
			{
				ConditionalFormattingObject conditionalFormattingObject5 = new ConditionalFormattingObject("PM(Request)", ConditionTypes.Equal, "PM(Request)", "", true);
				ConditionalFormattingObject conditionalFormattingObject6 = new ConditionalFormattingObject("PM(Approval)", ConditionTypes.Equal, "PM(Approval)", "", true);
				ConditionalFormattingObject conditionalFormattingObject7 = new ConditionalFormattingObject("PM(Done)", ConditionTypes.Equal, "PM(Done)", "", true);
				ConditionalFormattingObject conditionalFormattingObject8 = new ConditionalFormattingObject("PM(Final)", ConditionTypes.Equal, "PM(Final)", "", true);
				ConditionalFormattingObject conditionalFormattingObject9 = new ConditionalFormattingObject("PM(Cancel)", ConditionTypes.Equal, "PM(Cancel)", "", true);
				conditionalFormattingObject5.RowBackColor = (conditionalFormattingObject7.RowBackColor = (conditionalFormattingObject6.RowBackColor = Color.FromArgb(218, 217, 255)));
				this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject5);
				this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject6);
				this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject7);
				conditionalFormattingObject8.RowBackColor = Color.Silver;
				this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject8);
				conditionalFormattingObject9.RowBackColor = Color.FromArgb(250, 224, 212);
				this.radGridView.Columns["Status"].ConditionalFormattingObjectList.Add(conditionalFormattingObject9);
			}
			bool flag2 = this.radGridView.Columns.Contains("Report No.");
			if (flag2)
			{
				this.radGridView.Columns["Report No."].AllowFiltering = false;
				this.radGridView.Columns["Report No."].AllowHide = false;
			}
			bool flag3 = this.radGridView.Columns.Contains("View");
			if (flag3)
			{
				this.radGridView.Columns["View"].AllowFiltering = false;
				this.radGridView.Columns["View"].AllowHide = false;
			}
			bool flag4 = this.radGridView.Columns.Contains("Request Time");
			if (flag4)
			{
				this.radGridView.Columns["Request Time"].AllowFiltering = false;
			}
			bool flag5 = this.radGridView.Columns.Contains("Start Time");
			if (flag5)
			{
				this.radGridView.Columns["Start Time"].AllowFiltering = false;
			}
			bool flag6 = this.radGridView.Columns.Contains("End Time");
			if (flag6)
			{
				this.radGridView.Columns["End Time"].AllowFiltering = false;
			}
			bool flag7 = this.radGridView.Columns.Contains("Hold Time");
			if (flag7)
			{
				this.radGridView.Columns["Hold Time"].AllowFiltering = false;
			}
			bool flag8 = this.radGridView.Columns.Contains("Approval Time");
			if (flag8)
			{
				this.radGridView.Columns["Approval Time"].AllowFiltering = false;
			}
			bool flag9 = this.radGridView.Columns.Contains("Done Time");
			if (flag9)
			{
				this.radGridView.Columns["Done Time"].AllowFiltering = false;
			}
			bool flag10 = this.radGridView.Columns.Contains("Final Time");
			if (flag10)
			{
				this.radGridView.Columns["Final Time"].AllowFiltering = false;
			}
			bool flag11 = this.radGridView.Columns.Contains("Check Item");
			if (flag11)
			{
				this.radGridView.Columns["Check Item"].AllowFiltering = false;
			}
			bool flag12 = this.radGridView.Columns.Contains("Requirement");
			if (flag12)
			{
				this.radGridView.Columns["Requirement"].AllowFiltering = false;
			}
			bool flag13 = this.radGridView.Columns.Contains("Problem");
			if (flag13)
			{
				this.radGridView.Columns["Problem"].AllowFiltering = false;
			}
			bool flag14 = this.radGridView.Columns.Contains("Action");
			if (flag14)
			{
				this.radGridView.Columns["Action"].AllowFiltering = false;
			}
			bool flag15 = this.radGridView.Columns.Contains("Problems or Reason of use");
			if (flag15)
			{
				this.radGridView.Columns["Problems or Reason of use"].AllowFiltering = false;
			}
			bool flag16 = this.radGridView.Columns.Contains("Evidence (PCS pre-approval)");
			if (flag16)
			{
				this.radGridView.Columns["Evidence (PCS pre-approval)"].AllowFiltering = false;
			}
			bool flag17 = this.radGridView.Columns.Contains("Approval Comment");
			if (flag17)
			{
				this.radGridView.Columns["Approval Comment"].AllowFiltering = false;
			}
			bool flag18 = this.radGridView.Columns.Contains("Action and Changes");
			if (flag18)
			{
				this.radGridView.Columns["Action and Changes"].AllowFiltering = false;
			}
			bool flag19 = this.radGridView.Columns.Contains("Result and Evaluation");
			if (flag19)
			{
				this.radGridView.Columns["Result and Evaluation"].AllowFiltering = false;
			}
			bool flag20 = this.radGridView.Columns.Contains("Comment");
			if (flag20)
			{
				this.radGridView.Columns["Comment"].AllowFiltering = false;
			}
			bool flag21 = this.radGridView.Columns.Contains("Final Comment");
			if (flag21)
			{
				this.radGridView.Columns["Final Comment"].AllowFiltering = false;
			}
			this.ColumnCount = this.radGridView.Columns.Count;
			this.RowCount = this.radGridView.Rows.Count;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00069B28 File Offset: 0x00067D28
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
			bool flag = this._type == GridViewType.HISTORY_MAINT || this._type == GridViewType.SEARCH_MAINT || this._type == GridViewType.SEARCH_PM;
			if (flag)
			{
				this.radGridView.Columns.Move(this.radGridView.Columns.Count - 1, 3);
			}
			else
			{
				this.radGridView.Columns.Move(this.radGridView.Columns.Count - 1, 2);
			}
			foreach (GridViewRowInfo gridViewRowInfo in this.radGridView.Rows)
			{
				gridViewRowInfo.Cells["View"].Value = "View";
			}
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00069C68 File Offset: 0x00067E68
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
					bool flag2 = this._dataTable.Columns.Contains("Priority");
					if (flag2)
					{
						dataRow["Priority"] = cConst.convertPriority(reportObject.Priority);
					}
					bool flag3 = this._dataTable.Columns.Contains("Requester");
					if (flag3)
					{
						dataRow["Requester"] = reportObject.requester;
					}
					bool flag4 = this._dataTable.Columns.Contains("Status");
					if (flag4)
					{
						dataRow["Status"] = reportObject.Status;
					}
					bool flag5 = this._dataTable.Columns.Contains("Report No.");
					if (flag5)
					{
						dataRow["Report No."] = reportObject.Report;
					}
					bool flag6 = this._dataTable.Columns.Contains("Request Time");
					if (flag6)
					{
						dataRow["Request Time"] = reportObject.RequestTime;
					}
					bool flag7 = this._dataTable.Columns.Contains("Start Time");
					if (flag7)
					{
						dataRow["Start Time"] = reportObject.StartTime;
					}
					bool flag8 = this._dataTable.Columns.Contains("End Time");
					if (flag8)
					{
						dataRow["End Time"] = reportObject.EndTime;
					}
					bool flag9 = this._dataTable.Columns.Contains("Hold Time");
					if (flag9)
					{
						dataRow["Hold Time"] = reportObject.HoldTime;
					}
					bool flag10 = this._dataTable.Columns.Contains("Department");
					if (flag10)
					{
						dataRow["Department"] = reportObject.Part_Team;
					}
					bool flag11 = this._dataTable.Columns.Contains("Category");
					if (flag11)
					{
						dataRow["Category"] = reportObject.Category;
					}
					bool flag12 = this._dataTable.Columns.Contains("Model");
					if (flag12)
					{
						dataRow["Model"] = reportObject.Model;
					}
					bool flag13 = this._dataTable.Columns.Contains("M/C#(Location#)");
					if (flag13)
					{
						dataRow["M/C#(Location#)"] = reportObject.Machine;
					}
					bool flag14 = this._dataTable.Columns.Contains("Rsc Dec(Board#)");
					if (flag14)
					{
						dataRow["Rsc Dec(Board#)"] = reportObject.RscDec;
					}
					bool flag15 = this._dataTable.Columns.Contains("Case");
					if (flag15)
					{
						dataRow["Case"] = reportObject.Case;
					}
					bool flag16 = this._dataTable.Columns.Contains("Factor");
					if (flag16)
					{
						dataRow["Factor"] = reportObject.Factor;
					}
					bool flag17 = this._dataTable.Columns.Contains("Difficulty");
					if (flag17)
					{
						dataRow["Difficulty"] = reportObject.Difficult;
					}
					bool flag18 = this._dataTable.Columns.Contains("Approval Time");
					if (flag18)
					{
						dataRow["Approval Time"] = reportObject.PMApprovalTime;
					}
					bool flag19 = this._dataTable.Columns.Contains("Done Time");
					if (flag19)
					{
						dataRow["Done Time"] = reportObject.EndTime;
					}
					bool flag20 = this._dataTable.Columns.Contains("Final Time");
					if (flag20)
					{
						dataRow["Final Time"] = reportObject.FinalTime;
					}
					bool flag21 = this._dataTable.Columns.Contains("Asset");
					if (flag21)
					{
						dataRow["Asset"] = reportObject.PMAsset;
					}
					bool flag22 = this._dataTable.Columns.Contains("Work Type");
					if (flag22)
					{
						dataRow["Work Type"] = reportObject.PMWorkType;
					}
					bool flag23 = this._dataTable.Columns.Contains("Vendor");
					if (flag23)
					{
						dataRow["Vendor"] = reportObject.PMVendor;
					}
					bool flag24 = this._dataTable.Columns.Contains("No.");
					if (flag24)
					{
						DataRow dataRow2 = dataRow;
						string columnName = "No.";
						int num2;
						num = (num2 = num + 1);
						dataRow2[columnName] = num2.ToString();
					}
					bool flag25 = this._dataTable.Columns.Contains("Check Item");
					if (flag25)
					{
						dataRow["Check Item"] = reportObject.CheckItem;
					}
					bool flag26 = this._dataTable.Columns.Contains("Requirement");
					if (flag26)
					{
						dataRow["Requirement"] = reportObject.Requirment;
					}
					bool flag27 = this._dataTable.Columns.Contains("Problem");
					if (flag27)
					{
						dataRow["Problem"] = reportObject.Problem;
					}
					bool flag28 = this._dataTable.Columns.Contains("Action");
					if (flag28)
					{
						dataRow["Action"] = reportObject.Action;
					}
					bool flag29 = this._dataTable.Columns.Contains("Problems or Reason of use");
					if (flag29)
					{
						dataRow["Problems or Reason of use"] = reportObject.Content1;
					}
					bool flag30 = this._dataTable.Columns.Contains("Evidence (PCS pre-approval)");
					if (flag30)
					{
						dataRow["Evidence (PCS pre-approval)"] = reportObject.Content8;
					}
					bool flag31 = this._dataTable.Columns.Contains("Approval Comment");
					if (flag31)
					{
						dataRow["Approval Comment"] = reportObject.Content2;
					}
					bool flag32 = this._dataTable.Columns.Contains("Action and Changes");
					if (flag32)
					{
						dataRow["Action and Changes"] = reportObject.Content3;
					}
					bool flag33 = this._dataTable.Columns.Contains("Result and Evaluation");
					if (flag33)
					{
						dataRow["Result and Evaluation"] = reportObject.Content4;
					}
					bool flag34 = this._dataTable.Columns.Contains("Comment");
					if (flag34)
					{
						dataRow["Comment"] = reportObject.Content5;
					}
					bool flag35 = this._dataTable.Columns.Contains("Final Comment");
					if (flag35)
					{
						dataRow["Final Comment"] = reportObject.Content6;
					}
					this._dataTable.Rows.Add(dataRow);
				}
			}
			this._dataTable.EndLoadData();
			this.radGridView.DataSource = this._dataTable;
			this.makeViewButtonColumn();
			this.BindToDataSet();
			this.radGridView.MasterTemplate.BestFitColumns();
			using (MemoryStream memoryStream = new MemoryStream())
			{
				this.radGridView.SaveLayout(memoryStream);
				this._defaultLayout = Encoding.ASCII.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
			}
			bool flag36 = cFunction.loadLayout(this._factorySettings, this._cimitarUser._id, this._type, out this._layout);
			if (flag36)
			{
				bool flag37 = this._layout != string.Empty;
				if (flag37)
				{
					this.radGridView.LoadLayout(new MemoryStream(Encoding.ASCII.GetBytes(this._layout)));
				}
			}
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void radGridView_FilterPopupInitialized(object sende, FilterPopupInitializedEventArgs e)
		{
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0006A440 File Offset: 0x00068640
		private void radGridView_FilterPopupRequired(object sender, FilterPopupRequiredEventArgs e)
		{
			RadListFilterPopup radListFilterPopup = e.FilterPopup as RadListFilterPopup;
			radListFilterPopup.TextBoxMenuItem.Font = new Font(radListFilterPopup.TextBoxMenuItem.Font.FontFamily, 15f);
			radListFilterPopup.TextBoxMenuItem.AutoSize = false;
			radListFilterPopup.TextBoxMenuItem.Size = new Size(200, 40);
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0006A4A8 File Offset: 0x000686A8
		private void radGridView_CommandCellClick(object sender, EventArgs e)
		{
			GridViewRowInfo rowInfo = this.radGridView.SelectedCells[0].RowInfo;
			GridViewColumn columnInfo = this.radGridView.SelectedCells[0].ColumnInfo;
			bool flag = rowInfo.Index < 0 || columnInfo.Index < 0;
			if (!flag)
			{
				string text = rowInfo.Cells["Report No."].Value.ToString();
				bool flag2 = this._type == GridViewType.HISTORY_PM || this._type == GridViewType.SEARCH_PM;
				Form form;
				if (flag2)
				{
					form = new PMAction(text, this._factorySettings, this._cimitarUser);
				}
				else
				{
					form = new cAction(text, this._factorySettings, this._cimitarUser);
				}
				bool flag3 = form != null && this._topParent != null;
				if (flag3)
				{
					string text2 = rowInfo.Cells["Status"].Value.ToString();
					bool @checked = this._topParent.checkWebView.Checked;
					if (@checked)
					{
						bool flag4 = text2.ToUpper().Trim().IndexOf("HOLD") == -1;
						if (flag4)
						{
							this._topParent.panelWebView.Visible = true;
							bool flag5 = text2.ToUpper().Trim().IndexOf("CLOSE") != -1;
							if (flag5)
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
							bool flag6 = form.ShowDialog() == DialogResult.OK;
							if (flag6)
							{
								this._SearchClick(null, null);
							}
						}
					}
					else
					{
						bool flag7 = form.ShowDialog() == DialogResult.OK;
						if (flag7)
						{
							this._SearchClick(null, null);
						}
					}
				}
				else
				{
					bool flag8 = form != null && form.ShowDialog() == DialogResult.OK;
					if (flag8)
					{
						this._SearchClick(null, null);
					}
				}
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0000AE4C File Offset: 0x0000904C
		public void saveLayout()
		{
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0006A694 File Offset: 0x00068894
		private void radGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
		{
			foreach (RadItem radItem in e.ContextMenu.Items)
			{
				bool flag = radItem.Text.ToUpper().Contains("SORT") || radItem.Text.ToUpper().Contains("GROUP") || radItem.Text.ToUpper().Contains("CONDITIONAL");
				if (flag)
				{
					radItem.Visibility = ElementVisibility.Collapsed;
				}
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0006A738 File Offset: 0x00068938
		private void defaultItemClick(object sender, EventArgs e)
		{
			this.radGridView.FilterDescriptors.Clear();
			this.radGridView.SortDescriptors.Clear();
			this.radGridView.LoadLayout(new MemoryStream(Encoding.ASCII.GetBytes(this._defaultLayout)));
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0006A78C File Offset: 0x0006898C
		private void saveItemClick(object sender, EventArgs e)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				this.radGridView.SaveLayout(memoryStream);
				this._layout = Encoding.ASCII.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
				cFunction.saveLayout(this._factorySettings, this._cimitarUser._id, this._type, this._layout);
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0006A810 File Offset: 0x00068A10
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0006A848 File Offset: 0x00068A48
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
			this.radGridView.ContextMenuOpening += this.radGridView_ContextMenuOpening;
			this.radGridView.FilterPopupRequired += this.radGridView_FilterPopupRequired;
			this.radGridView.FilterPopupInitialized += this.radGridView_FilterPopupInitialized;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel25);
			base.Name = "GridView";
			base.Size = new Size(881, 425);
			this.panel25.ResumeLayout(false);
			((ISupportInitialize)this.radGridView.MasterTemplate).EndInit();
			((ISupportInitialize)this.radGridView).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400059D RID: 1437
		private readonly string _defaultHeader = string.Empty;

		// Token: 0x0400059E RID: 1438
		private DataTable _dataTable = null;

		// Token: 0x0400059F RID: 1439
		private readonly FactorySettings _factorySettings;

		// Token: 0x040005A0 RID: 1440
		private readonly CIMitarAccount _cimitarUser;

		// Token: 0x040005A1 RID: 1441
		private readonly SearchForm _topParent = null;

		// Token: 0x040005A3 RID: 1443
		private string _layout = string.Empty;

		// Token: 0x040005A4 RID: 1444
		private string _defaultLayout = string.Empty;

		// Token: 0x040005A5 RID: 1445
		private readonly GridViewType _type;

		// Token: 0x040005A9 RID: 1449
		private IContainer components = null;

		// Token: 0x040005AA RID: 1450
		private TelerikMetroBlueTheme telerikMetroBlueTheme1;

		// Token: 0x040005AB RID: 1451
		private Panel panel25;

		// Token: 0x040005AC RID: 1452
		private RadGridView radGridView;
	}
}
