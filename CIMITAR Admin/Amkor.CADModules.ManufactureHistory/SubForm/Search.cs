using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.ManufactureHistory.Class;
using Amkor.CADModules.ManufactureHistory.GrobalConstMFG;
using Amkor.CADModules.ManufactureHistory.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.ManufactureHistory.SubForm
{
	// Token: 0x02000011 RID: 17
	public partial class Search : BaseWinView
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00005F18 File Offset: 0x00004118
		public Search(CIMitarAccount cimitarUser, FactorySettings factorySettings)
		{
			this._factorySettings = factorySettings;
			this._cimitarUser = cimitarUser;
			this.InitializeComponent();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00005F68 File Offset: 0x00004168
		private void InitGridCell()
		{
			Color color = Color.FromArgb(130, 179, 237);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader.BackColor = color;
			columnHeader.Border = RectangleBorder.NoBorder;
			columnHeader.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_header1 = new SourceGrid.Cells.Views.ColumnHeader();
			this.cell_header1.Background = columnHeader;
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.SetGridHeader();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00005FF0 File Offset: 0x000041F0
		private void SetGridHeader()
		{
			this.grid_history.Rows.Clear();
			this.grid_history.ColumnsCount = 12;
			this.grid_history.FixedRows = 1;
			this.grid_history.FixedColumns = 3;
			this.grid_history.Rows.Insert(0);
			this.grid_history[0, 0] = new SourceGrid.Cells.ColumnHeader("No.");
			this.grid_history[0, 0].View = this.cell_header1;
			this.grid_history.Columns[0].Visible = true;
			this.grid_history[0, 1] = new SourceGrid.Cells.ColumnHeader("Report");
			this.grid_history[0, 1].View = this.cell_header1;
			this.grid_history.Columns[1].Visible = true;
			this.grid_history[0, 2] = new SourceGrid.Cells.ColumnHeader("");
			this.grid_history[0, 2].View = this.cell_header1;
			this.grid_history.Columns[2].Visible = true;
			this.grid_history[0, 3] = new SourceGrid.Cells.ColumnHeader("Category");
			this.grid_history[0, 3].View = this.cell_header1;
			this.grid_history.Columns[3].Visible = true;
			this.grid_history[0, 4] = new SourceGrid.Cells.ColumnHeader("M/C No.");
			this.grid_history[0, 4].View = this.cell_header1;
			this.grid_history.Columns[4].Visible = true;
			this.grid_history[0, 5] = new SourceGrid.Cells.ColumnHeader("Model");
			this.grid_history[0, 5].View = this.cell_header1;
			this.grid_history.Columns[5].Visible = true;
			this.grid_history[0, 6] = new SourceGrid.Cells.ColumnHeader("Rsc Dec");
			this.grid_history[0, 6].View = this.cell_header1;
			this.grid_history.Columns[6].Visible = true;
			this.grid_history[0, 7] = new SourceGrid.Cells.ColumnHeader("Operation");
			this.grid_history[0, 7].View = this.cell_header1;
			this.grid_history.Columns[7].Visible = true;
			this.grid_history[0, 8] = new SourceGrid.Cells.ColumnHeader("CustName");
			this.grid_history[0, 8].View = this.cell_header1;
			this.grid_history.Columns[8].Visible = true;
			this.grid_history[0, 9] = new SourceGrid.Cells.ColumnHeader("Device");
			this.grid_history[0, 9].View = this.cell_header1;
			this.grid_history.Columns[9].Visible = true;
			this.grid_history[0, 10] = new SourceGrid.Cells.ColumnHeader("Shift");
			this.grid_history[0, 10].View = this.cell_header1;
			this.grid_history.Columns[10].Visible = true;
			this.grid_history[0, 11] = new SourceGrid.Cells.ColumnHeader("Content");
			this.grid_history[0, 11].View = this.cell_header1;
			this.grid_history.Columns[11].Visible = true;
			this.grid_history.AutoSizeCells();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000063CC File Offset: 0x000045CC
		private void InitListBox()
		{
			cFunction.setCategoryListBox(this.listboxCategory);
			cFunction.setCustListListBox(this.listBoxCustList, true);
			cFunction.setOperationListBox(this.listBoxOperation, true);
			this.listBoxCustList.SelectedIndex = 0;
			this.listBoxOperation.SelectedIndex = 0;
			this.listBoxShift.SelectedIndex = 0;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00006428 File Offset: 0x00004628
		private void listboxCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (((ListBox)sender).Equals(this.listboxCategory))
			{
				this.listBoxModel.Items.Clear();
				this.listBoxModel.Items.Add("(All)");
				this.listBoxModel.SelectedIndex = 0;
				if (this.listboxCategory.SelectedIndex != -1)
				{
					this._MachineModelList.Clear();
					DataSet machineNumber = cFunction.getMachineNumber(this.listboxCategory.SelectedItem.ToString());
					for (int i = 0; i < machineNumber.Tables[0].Rows.Count; i++)
					{
						string text = machineNumber.Tables[0].Rows[i]["Model"].ToString();
						string sSelectMachine = machineNumber.Tables[0].Rows[i]["Name"].ToString();
						MachineInfo machineInfo = new MachineInfo();
						machineInfo.sSelectMachine = sSelectMachine;
						machineInfo.sSelectModel = text;
						if (machineNumber.Tables[0].Columns.Contains("Rsc"))
						{
							machineInfo.sSelectRsc = machineNumber.Tables[0].Rows[i]["Rsc"].ToString();
						}
						this._MachineModelList.Add(machineInfo);
						if (!this.listBoxModel.Items.Contains(text))
						{
							this.listBoxModel.Items.Add(text);
						}
					}
				}
			}
			else if (((ListBox)sender).Equals(this.listBoxModel))
			{
				if (this.listBoxModel.SelectedIndex != -1)
				{
					this.listBoxEquipment.Items.Clear();
					this.listBoxEquipment.Items.Add("(All)");
					this.listBoxEquipment.SelectedIndex = 0;
					foreach (MachineInfo machineInfo2 in this._MachineModelList)
					{
						if (this.listBoxModel.SelectedItem != null && this.listBoxModel.SelectedItem.ToString() == machineInfo2.sSelectModel)
						{
							this.listBoxEquipment.Items.Add(machineInfo2.sSelectMachine);
						}
					}
				}
			}
			else if (((ListBox)sender).Equals(this.listBoxCustList))
			{
				if (this.listBoxCustList.SelectedIndex != -1)
				{
					cFunction.getNickNameListListBox(this.listBoxCustList.SelectedItem.ToString(), this.listBoxDevice, true);
					this.listBoxDevice.SelectedIndex = 0;
				}
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006750 File Offset: 0x00004950
		private void History_Shown(object sender, EventArgs e)
		{
			this.InitGridCell();
			this.InitListBox();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00006764 File Offset: 0x00004964
		private void btnSearch_Click(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.TableSearch;
			if (this.listboxCategory.SelectedIndex == -1)
			{
				MessageBox.Show("카테고리를 선택해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (this.listBoxModel.SelectedIndex == -1)
			{
				MessageBox.Show("모델을 선택해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (this.listBoxEquipment.SelectedIndex == -1)
			{
				MessageBox.Show("장비를 선택해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (this.listBoxOperation.SelectedIndex == -1)
			{
				MessageBox.Show("공정을 선택해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (this.listBoxCustList.SelectedIndex == -1)
			{
				MessageBox.Show("고객을 선택해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (this.listBoxDevice.SelectedIndex == -1)
			{
				MessageBox.Show("디바이스를 선택해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (this.listBoxShift.SelectedIndex == -1)
			{
				MessageBox.Show("Shift를 선택해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.SetGridHeader();
				string text = this.listBoxOperation.SelectedItem.ToString();
				DateTime startdate = new DateTime(this.dtStartDate.Value.Year, this.dtStartDate.Value.Month, this.dtStartDate.Value.Day, 0, 0, 0);
				DateTime enddate = new DateTime(this.dtEndDate.Value.Year, this.dtEndDate.Value.Month, this.dtEndDate.Value.Day, 23, 59, 59);
				if (text != "(All)")
				{
					text = text.Substring(text.IndexOf("(") + 1, text.IndexOf(")") - text.IndexOf("(") - 1);
				}
				DataSet dataSet = cFunction.searchReport(startdate, enddate, this.listboxCategory.SelectedItem.ToString(), this.listBoxModel.SelectedItem.ToString(), this.listBoxEquipment.SelectedItem.ToString(), (text == "(All)") ? 0 : Convert.ToInt32(text), this.listBoxCustList.SelectedItem.ToString(), this.listBoxDevice.SelectedItem.ToString(), this.tbKeyword.Text.Trim(), this.listBoxShift.SelectedItem.ToString());
				if (dataSet != null && dataSet.Tables.Count != 0)
				{
					this.cbCustomer.Items.Clear();
					this.cbDevice.Items.Clear();
					this.cbEquipment.Items.Clear();
					this.cbModel.Items.Clear();
					this.cbOperation.Items.Clear();
					this.cbShift.Items.Clear();
					this.cbCustomer.Items.Add("All");
					this.cbDevice.Items.Add("All");
					this.cbEquipment.Items.Add("All");
					this.cbModel.Items.Add("All");
					this.cbOperation.Items.Add("All");
					this.cbShift.Items.Add("All");
					this._ReportIist.Clear();
					for (int i = 0; i < dataSet.Tables[dataSet.Tables.Count - 1].Rows.Count; i++)
					{
						ReportInfo reportInfo = new ReportInfo(dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["Report"].ToString());
						reportInfo.Category = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["Category"].ToString();
						reportInfo.Equipment = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["Machine"].ToString();
						reportInfo.Model = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["Model"].ToString();
						reportInfo.RscDec = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["Type"].ToString();
						reportInfo.CustName = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["CustName"].ToString();
						reportInfo.Operation = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["Operation"].ToString();
						reportInfo.NickName = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["Nickname"].ToString();
						reportInfo.content = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["content1"].ToString();
						reportInfo.content2 = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["content2"].ToString();
						reportInfo.Shift = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["Shift"].ToString();
						this.grid_history.Rows.Insert(i + 1);
						this.grid_history[i + 1, 0] = new SourceGrid.Cells.Cell(i + 1);
						this.grid_history[i + 1, 1] = new SourceGrid.Cells.Cell(reportInfo.Title);
						this.grid_history[i + 1, 2] = new SourceGrid.Cells.Button("View");
						this.grid_history[i + 1, 3] = new SourceGrid.Cells.Cell(reportInfo.Category);
						this.grid_history[i + 1, 4] = new SourceGrid.Cells.Cell(reportInfo.Equipment);
						this.grid_history[i + 1, 5] = new SourceGrid.Cells.Cell(reportInfo.Model);
						this.grid_history[i + 1, 6] = new SourceGrid.Cells.Cell(reportInfo.RscDec);
						this.grid_history[i + 1, 7] = new SourceGrid.Cells.Cell(reportInfo.Operation);
						this.grid_history[i + 1, 8] = new SourceGrid.Cells.Cell(reportInfo.CustName);
						this.grid_history[i + 1, 9] = new SourceGrid.Cells.Cell(reportInfo.NickName);
						this.grid_history[i + 1, 10] = new SourceGrid.Cells.Cell(reportInfo.Shift);
						this.grid_history[i + 1, 11] = new SourceGrid.Cells.Cell(reportInfo.content);
						this._ReportIist.Add(reportInfo);
						if (!this.cbCustomer.Items.Contains(reportInfo.CustName) && !string.IsNullOrEmpty(reportInfo.CustName))
						{
							this.cbCustomer.Items.Add(reportInfo.CustName);
						}
						if (!this.cbModel.Items.Contains(reportInfo.Model) && !string.IsNullOrEmpty(reportInfo.Model))
						{
							this.cbModel.Items.Add(reportInfo.Model);
						}
						if (!this.cbEquipment.Items.Contains(reportInfo.Equipment) && !string.IsNullOrEmpty(reportInfo.Equipment))
						{
							this.cbEquipment.Items.Add(reportInfo.Equipment);
						}
						if (!this.cbOperation.Items.Contains(reportInfo.Operation) && !string.IsNullOrEmpty(reportInfo.Operation))
						{
							this.cbOperation.Items.Add(reportInfo.Operation);
						}
						if (!this.cbDevice.Items.Contains(reportInfo.NickName) && !string.IsNullOrEmpty(reportInfo.NickName))
						{
							this.cbDevice.Items.Add(reportInfo.NickName);
						}
						if (!this.cbShift.Items.Contains(reportInfo.Shift) && !string.IsNullOrEmpty(reportInfo.Shift))
						{
							this.cbShift.Items.Add(reportInfo.Shift);
						}
					}
					this.pnSubIdex.Visible = true;
					this.grid_history.AutoSizeCells();
					this.grid_history.Refresh();
					this.grid_history.Size = new Size(1, 1);
					this._bEventBlock = true;
					this.cbCustomer.SelectedIndex = 0;
					this.cbDevice.SelectedIndex = 0;
					this.cbEquipment.SelectedIndex = 0;
					this.cbModel.SelectedIndex = 0;
					this.cbOperation.SelectedIndex = 0;
					this.cbShift.SelectedIndex = 0;
					this._bEventBlock = false;
				}
				else
				{
					this.pnSubIdex.Visible = false;
				}
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00007200 File Offset: 0x00005400
		private void btnSearch_MouseLeave(object sender, EventArgs e)
		{
			if (((PictureBox)sender).Equals(this.btnSearch))
			{
				((PictureBox)sender).Image = Resources.TableSearch;
			}
			else if (((PictureBox)sender).Equals(this.btnExcel))
			{
				((PictureBox)sender).Image = Resources.SaveExcel;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00007268 File Offset: 0x00005468
		private void btnSearch_MouseEnter(object sender, EventArgs e)
		{
			if (((PictureBox)sender).Equals(this.btnSearch))
			{
				((PictureBox)sender).Image = Resources.TableSearch_Down;
			}
			else if (((PictureBox)sender).Equals(this.btnExcel))
			{
				((PictureBox)sender).Image = Resources.TableSave_Down;
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000072D0 File Offset: 0x000054D0
		private void grid_history_MouseClick(object sender, MouseEventArgs e)
		{
			Grid grid = (Grid)sender;
			int row = grid.MouseDownPosition.Row;
			int column = grid.MouseDownPosition.Column;
			if (column == 2 && row != 0)
			{
				Viewer viewer = new Viewer(grid[row, 1].DisplayText, this._cimitarUser);
				if (viewer.ShowDialog() == DialogResult.OK)
				{
					this.btnSearch_Click(this.btnSearch, null);
				}
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00007354 File Offset: 0x00005554
		private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.refreshGrid((System.Windows.Forms.ComboBox)sender);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00007364 File Offset: 0x00005564
		private void refreshGrid(System.Windows.Forms.ComboBox comboBox)
		{
			if (!this._bEventBlock)
			{
				this._bEventBlock = true;
				if (this.cbDevice.SelectedItem != null && this.cbModel.SelectedItem != null && this.cbEquipment.SelectedItem != null && this.cbOperation.SelectedItem != null && this.cbCustomer.SelectedItem != null && this.cbShift.SelectedItem != null)
				{
					string item = string.Empty;
					if (!comboBox.Equals(this.cbOperation) && comboBox.SelectedIndex != 0)
					{
						item = comboBox.SelectedItem.ToString();
						comboBox.Items.Clear();
						comboBox.Items.Add("All");
						comboBox.Items.Add(item);
						comboBox.SelectedIndex = 1;
					}
					if (!comboBox.Equals(this.cbShift) && comboBox.SelectedIndex != 0)
					{
						item = comboBox.SelectedItem.ToString();
						comboBox.Items.Clear();
						comboBox.Items.Add("All");
						comboBox.Items.Add(item);
						comboBox.SelectedIndex = 1;
					}
					if (comboBox.Equals(this.cbModel) || comboBox.Equals(this.cbEquipment))
					{
						if (this.cbModel.SelectedIndex == 0)
						{
							this.cbModel.Items.Clear();
						}
						if (this.cbEquipment.SelectedIndex == 0)
						{
							this.cbEquipment.Items.Clear();
						}
						if (!this.cbModel.Items.Contains("All"))
						{
							this.cbModel.Items.Add("All");
							this.cbModel.SelectedIndex = 0;
						}
						if (!this.cbEquipment.Items.Contains("All"))
						{
							this.cbEquipment.Items.Add("All");
							this.cbEquipment.SelectedIndex = 0;
						}
					}
					if (comboBox.Equals(this.cbCustomer) || comboBox.Equals(this.cbDevice))
					{
						if (this.cbCustomer.SelectedIndex == 0)
						{
							this.cbCustomer.Items.Clear();
						}
						if (this.cbDevice.SelectedIndex == 0)
						{
							this.cbDevice.Items.Clear();
						}
						if (!this.cbDevice.Items.Contains("All"))
						{
							this.cbDevice.Items.Add("All");
							this.cbDevice.SelectedIndex = 0;
						}
						if (!this.cbCustomer.Items.Contains("All"))
						{
							this.cbCustomer.Items.Add("All");
							this.cbCustomer.SelectedIndex = 0;
						}
					}
					int num = 0;
					this.SetGridHeader();
					foreach (ReportInfo reportInfo in this._ReportIist)
					{
						if ((this.cbDevice.SelectedIndex == 0 || (this.cbDevice.SelectedIndex > 0 && this.cbDevice.SelectedItem.ToString() == reportInfo.NickName)) && (this.cbModel.SelectedIndex == 0 || (this.cbModel.SelectedIndex > 0 && this.cbModel.SelectedItem.ToString() == reportInfo.Model)) && (this.cbEquipment.SelectedIndex == 0 || (this.cbEquipment.SelectedIndex > 0 && this.cbEquipment.SelectedItem.ToString() == reportInfo.Equipment)) && (this.cbOperation.SelectedIndex == 0 || (this.cbOperation.SelectedIndex > 0 && this.cbOperation.SelectedItem.ToString() == reportInfo.Operation)) && (this.cbCustomer.SelectedIndex == 0 || (this.cbCustomer.SelectedIndex > 0 && this.cbCustomer.SelectedItem.ToString() == reportInfo.CustName)) && (this.cbShift.SelectedIndex == 0 || (this.cbShift.SelectedIndex > 0 && this.cbShift.SelectedItem.ToString() == reportInfo.Shift)))
						{
							this.grid_history.Rows.Insert(num + 1);
							this.grid_history[num + 1, 0] = new SourceGrid.Cells.Cell(num + 1);
							this.grid_history[num + 1, 1] = new SourceGrid.Cells.Cell(reportInfo.Title);
							this.grid_history[num + 1, 2] = new SourceGrid.Cells.Button("View");
							this.grid_history[num + 1, 3] = new SourceGrid.Cells.Cell(reportInfo.Category);
							this.grid_history[num + 1, 4] = new SourceGrid.Cells.Cell(reportInfo.Equipment);
							this.grid_history[num + 1, 5] = new SourceGrid.Cells.Cell(reportInfo.Model);
							this.grid_history[num + 1, 6] = new SourceGrid.Cells.Cell(reportInfo.RscDec);
							this.grid_history[num + 1, 7] = new SourceGrid.Cells.Cell(reportInfo.Operation);
							this.grid_history[num + 1, 8] = new SourceGrid.Cells.Cell(reportInfo.CustName);
							this.grid_history[num + 1, 9] = new SourceGrid.Cells.Cell(reportInfo.NickName);
							this.grid_history[num + 1, 10] = new SourceGrid.Cells.Cell(reportInfo.Shift);
							this.grid_history[num + 1, 11] = new SourceGrid.Cells.Cell(reportInfo.content);
							if (!this.cbCustomer.Items.Contains(reportInfo.CustName))
							{
								this.cbCustomer.Items.Add(reportInfo.CustName);
							}
							if (!this.cbModel.Items.Contains(reportInfo.Model))
							{
								this.cbModel.Items.Add(reportInfo.Model);
							}
							if (!this.cbEquipment.Items.Contains(reportInfo.Equipment))
							{
								this.cbEquipment.Items.Add(reportInfo.Equipment);
							}
							if (!this.cbOperation.Items.Contains(reportInfo.Operation))
							{
								this.cbOperation.Items.Add(reportInfo.Operation);
							}
							if (!this.cbDevice.Items.Contains(reportInfo.NickName))
							{
								this.cbDevice.Items.Add(reportInfo.NickName);
							}
							num++;
						}
					}
					this.grid_history.AutoSizeCells();
					this._bEventBlock = false;
				}
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00007AEC File Offset: 0x00005CEC
		private void btnExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.grid_history);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00007AFC File Offset: 0x00005CFC
		private void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00007B0C File Offset: 0x00005D0C
		private void saveExcel(Grid grid)
		{
			try
			{
				if (grid.RowsCount > 1)
				{
					this.saveFileDialog.DefaultExt = ".xlsx";
					this.saveFileDialog.Filter = "Excel files|*.xlsx";
					this.saveFileDialog.FilterIndex = 1;
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						ExcelControl.Save(this.saveFileDialog.FileName, grid, true, null);
						this._barPrograss.setMax(100);
						this._barPrograss.setValue(100);
						Thread.Sleep(100);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
				}
				else
				{
					MessageBox.Show("data is not exist ", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x04000032 RID: 50
		private FactorySettings _factorySettings;

		// Token: 0x04000033 RID: 51
		private new CIMitarAccount _cimitarUser;

		// Token: 0x04000034 RID: 52
		private List<MachineInfo> _MachineModelList = new List<MachineInfo>();

		// Token: 0x04000035 RID: 53
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x04000036 RID: 54
		private List<ReportInfo> _ReportIist = new List<ReportInfo>();

		// Token: 0x04000037 RID: 55
		private bool _bEventBlock = false;

		// Token: 0x04000038 RID: 56
		private BarPrograss _barPrograss;

		// Token: 0x04000039 RID: 57
		private Thread _thread;
	}
}
