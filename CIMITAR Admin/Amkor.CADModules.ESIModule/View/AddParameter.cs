using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.ESIModule.CIMitarAdminWS;
using Amkor.CADModules.ESIModule.Properties;
using ATDFW.Classes.CIMitar;
using OfficeOpenXml;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.ESIModule.View
{
	// Token: 0x02000027 RID: 39
	public partial class AddParameter : Form
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x00007830 File Offset: 0x00005A30
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000783E File Offset: 0x00005A3E
		public AddParameter()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00007870 File Offset: 0x00005A70
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

		// Token: 0x060000A3 RID: 163 RVA: 0x000078E8 File Offset: 0x00005AE8
		private void AddParameter_Load(object sender, EventArgs e)
		{
			this.btnSearch_Click(null, null);
			this.btnSearch_SettingUnit_Click(null, null);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000078FA File Offset: 0x00005AFA
		private void btnSearch_Click(object sender, EventArgs e)
		{
			this.getTestGroup();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00007904 File Offset: 0x00005B04
		private void getTestGroup()
		{
			this.dtGroup = new DataTable();
			this.dtGroup.Columns.Add(new DataColumn("Check", typeof(bool)));
			this.dtGroup.Columns.Add(new DataColumn("Seq", typeof(string)));
			this.dtGroup.Columns.Add(new DataColumn("Device", typeof(string)));
			this.dtGroup.Columns.Add(new DataColumn("GroupID", typeof(string)));
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetTesterParameterGroup] ";
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.dtGroup.Rows.Add(new string[]
					{
						"false",
						(i + 1).ToString(),
						dataSet.Tables[0].Rows[i]["groupname"].ToString(),
						dataSet.Tables[0].Rows[i]["parametergroupid"].ToString()
					});
				}
			}
			this.grid_Reg_Device.Columns.Clear();
			this.grid_Reg_Device.DataSource = this.dtGroup;
			GridViewCheckBoxColumn gridViewCheckBoxColumn = new GridViewCheckBoxColumn();
			gridViewCheckBoxColumn = (GridViewCheckBoxColumn)this.grid_Reg_Device.Columns[0];
			gridViewCheckBoxColumn.HeaderText = "";
			gridViewCheckBoxColumn.Name = "Check";
			gridViewCheckBoxColumn.Width = 20;
			gridViewCheckBoxColumn.EnableHeaderCheckBox = true;
			this.grid_Reg_Device.AllowAddNewRow = false;
			this.grid_Reg_Device.ShowGroupPanel = false;
			this.grid_Reg_Device.EnableFiltering = true;
			this.grid_Reg_Device.EnableSorting = true;
			this.grid_Reg_Device.EnableGrouping = true;
			this.grid_Reg_Device.MasterView.TableHeaderRow.IsVisible = true;
			this.grid_Reg_Device.AllowEditRow = true;
			this.grid_Reg_Device.Columns["Check"].AllowSort = false;
			this.grid_Reg_Device.Columns["Check"].HeaderText = string.Empty;
			this.grid_Reg_Device.Columns["Check"].Width = 20;
			this.grid_Reg_Device.Columns["Device"].Width = 150;
			this.grid_Reg_Device.Columns["GroupID"].IsVisible = false;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00007BE8 File Offset: 0x00005DE8
		private void grid_Reg_Device_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}
			this._barPrograss = new BarPrograss();
			this._barPrograss.progress_labelheader_set("Search Data....");
			this._barPrograss.setValue(100);
			this._thread = new Thread(new ThreadStart(this.BarPrograssView));
			this._thread.Start();
			string str = string.Empty;
			string text = string.Empty;
			str = this.grid_Reg_Device.Rows[e.RowIndex].Cells[3].Value.ToString();
			text = this.grid_Reg_Device.Rows[e.RowIndex].Cells[2].Value.ToString();
			GridViewCheckBoxColumn gridViewCheckBoxColumn = new GridViewCheckBoxColumn();
			gridViewCheckBoxColumn.HeaderText = "";
			gridViewCheckBoxColumn.Name = "Check";
			gridViewCheckBoxColumn.Width = 20;
			gridViewCheckBoxColumn.EnableHeaderCheckBox = true;
			this.dtTestName = new DataTable();
			this.dtTestName.Columns.Add(new DataColumn("Seq", typeof(int)));
			this.dtTestName.Columns.Add(new DataColumn("TestNo", typeof(int)));
			this.dtTestName.Columns.Add(new DataColumn("TestName", typeof(string)));
			this.dtTestName.Columns.Add(new DataColumn("LSL", typeof(string)));
			this.dtTestName.Columns.Add(new DataColumn("USL", typeof(string)));
			this.dtTestName.Columns.Add(new DataColumn("R_LSL", typeof(string)));
			this.dtTestName.Columns.Add(new DataColumn("R_USL", typeof(string)));
			this.dtTestName.Columns.Add(new DataColumn("Unit", typeof(string)));
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetTesterParameterInfo]  @groupid = '" + str + "'";
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				int num = 1;
				this.txtNewGroupName.Text = text;
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.dtTestName.Rows.Add(new string[]
					{
						num++.ToString(),
						dataSet.Tables[0].Rows[i]["parameterno"].ToString(),
						dataSet.Tables[0].Rows[i]["parameter"].ToString(),
						dataSet.Tables[0].Rows[i]["lsl"].ToString(),
						dataSet.Tables[0].Rows[i]["usl"].ToString(),
						dataSet.Tables[0].Rows[i]["R_lsl"].ToString(),
						dataSet.Tables[0].Rows[i]["R_usl"].ToString(),
						dataSet.Tables[0].Rows[i]["unit"].ToString()
					});
				}
			}
			this.grid_Parameter.Columns.Clear();
			this.grid_Parameter.DataSource = this.dtTestName;
			this.grid_Parameter.AllowAddNewRow = false;
			this.grid_Parameter.ShowGroupPanel = false;
			this.grid_Parameter.EnableFiltering = true;
			this.grid_Parameter.EnableSorting = true;
			this.grid_Parameter.EnableGrouping = true;
			this.grid_Parameter.MasterView.TableHeaderRow.IsVisible = true;
			this.grid_Parameter.Columns["Seq"].Width = 50;
			this.grid_Parameter.Columns["TestNo"].Width = 80;
			this.grid_Parameter.Columns["TestName"].Width = 200;
			this.grid_Parameter.Columns["LSL"].Width = 100;
			this.grid_Parameter.Columns["USL"].Width = 100;
			this.grid_Parameter.Columns["R_LSL"].Width = 100;
			this.grid_Parameter.Columns["R_USL"].Width = 100;
			this.grid_Parameter.Columns["Unit"].Width = 80;
			Thread.Sleep(100);
			if (this._barPrograss != null)
			{
				this._barPrograss._ischeck = true;
			}
			this._barPrograss = null;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00008164 File Offset: 0x00006364
		private void btnDelete_Click(object sender, EventArgs e)
		{
			string filterExpression = "[Check] = true";
			DataRow[] array = this.dtGroup.Select(filterExpression);
			if (array.Length == 0)
			{
				RadMessageBox.Show(this, "Select the device to be deleted.", "ESI Module", MessageBoxButtons.OK, RadMessageIcon.Error);
				return;
			}
			if (array.Length > 1)
			{
				RadMessageBox.Show(this, "Only 1 device select", "ESI Module", MessageBoxButtons.OK, RadMessageIcon.Error);
				return;
			}
			DialogResult dialogResult = RadMessageBox.Show(this, "Do you want to delete seleted parameter data", "ESI Module", MessageBoxButtons.YesNo, RadMessageIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				string str = array[0]["GroupID"].ToString();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_DeleteTesterParameter]  @groupid = '" + str + "'";
				this.queryCall(sQuery);
				RadMessageBox.Show(this, "Delete success", "ESI Module", MessageBoxButtons.OK, RadMessageIcon.Info);
				this.getTestGroup();
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00008218 File Offset: 0x00006418
		private bool SaveCSV(string filename, DataTable dt)
		{
			bool result = false;
			try
			{
				if (dt != null)
				{
					StreamWriter streamWriter = new StreamWriter(filename, false, Encoding.Default);
					foreach (object obj in dt.Columns)
					{
						DataColumn dataColumn = (DataColumn)obj;
						streamWriter.Write(dataColumn.ColumnName);
						streamWriter.Write(",");
					}
					streamWriter.WriteLine();
					int num = 1;
					this._barPrograss.progress_labelheader_set("Create csv file....");
					foreach (object obj2 in dt.Rows)
					{
						DataRow dataRow = (DataRow)obj2;
						this._barPrograss.setValue(num);
						foreach (object obj3 in dt.Columns)
						{
							DataColumn dataColumn2 = (DataColumn)obj3;
							string text = dataRow[dataColumn2.ColumnName].ToString().Replace('\n', ' ');
							text = text.Replace(',', ' ');
							text = text.Replace('\r', ' ');
							streamWriter.Write(text);
							streamWriter.Write(",");
						}
						streamWriter.WriteLine();
						num++;
					}
					streamWriter.Close();
				}
				result = true;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				return false;
			}
			return result;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000840C File Offset: 0x0000660C
		private bool SaveExcel(string filepath, SortedList slList, bool visibleFlag)
		{
			bool result;
			using (ExcelPackage excelPackage = new ExcelPackage())
			{
				if (slList.Count > 0)
				{
					for (int i = 0; i < slList.Count; i++)
					{
						DataTable dataTable = (DataTable)slList.GetByIndex(i);
						ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Parameter");
						int num = 1;
						int num2 = 1;
						for (int j = 0; j < dataTable.Columns.Count; j++)
						{
							excelWorksheet.Cells[num, num2].Value = dataTable.Columns[j].ToString();
							excelWorksheet.Column(num2++).Width = 15.0;
						}
						if (dataTable.Rows.Count > 0)
						{
							num++;
							for (int k = 0; k < dataTable.Rows.Count; k++)
							{
								num2 = 1;
								this._barPrograss.setValue(num - 1);
								for (int l = 0; l < dataTable.Columns.Count; l++)
								{
									if (dataTable.Rows[k][l] != null)
									{
										if (dataTable.Columns[l].DataType.Name == "Int32")
										{
											excelWorksheet.Cells[num, num2].Value = int.Parse(dataTable.Rows[k][l].ToString());
										}
										else if (dataTable.Columns[l].DataType.Name == "Double")
										{
											excelWorksheet.Cells[num, num2].Value = double.Parse(dataTable.Rows[k][l].ToString());
										}
										else
										{
											excelWorksheet.Cells[num, num2].Value = dataTable.Rows[k][l].ToString();
										}
									}
									num2++;
								}
								num++;
							}
						}
					}
				}
				excelPackage.Workbook.Properties.Title = "Amkor";
				excelPackage.Workbook.Properties.Author = "Amkor";
				excelPackage.Workbook.Properties.Comments = "Amkor";
				excelPackage.Workbook.Properties.Company = "Amkor";
				FileInfo file = new FileInfo(filepath);
				excelPackage.SaveAs(file);
				result = true;
			}
			return result;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000086D0 File Offset: 0x000068D0
		private void btnFileOpen_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			try
			{
				this.openFileDialog1.Filter = "*.csv|*.CSV";
				this.openFileDialog1.FileName = string.Empty;
				if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Save Data....");
					this._barPrograss.setValue(0);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					using (StreamReader streamReader = new StreamReader(this.openFileDialog1.FileName, Encoding.Default))
					{
						text = streamReader.ReadToEnd();
						streamReader.Close();
					}
					if (text == string.Empty)
					{
						RadMessageBox.Show(this, "Uploading data does not exist", "ESI Module", MessageBoxButtons.OK, RadMessageIcon.Error);
					}
					else
					{
						string[] array = text.Split(new char[]
						{
							'\n'
						});
						string[] array2 = array[0].Split(new string[]
						{
							","
						}, StringSplitOptions.RemoveEmptyEntries);
						if (array2.Length != 8)
						{
							RadMessageBox.Show(this, "Uploading data format is wrong (8 field). \nPlease download format", "ESI Module", MessageBoxButtons.OK, RadMessageIcon.Error);
							Thread.Sleep(100);
							if (this._barPrograss != null)
							{
								this._barPrograss._ischeck = true;
							}
							this._barPrograss = null;
							return;
						}
						this.dtTestName = new DataTable();
						this.dtTestName.Columns.Add(new DataColumn("Seq", typeof(int)));
						this.dtTestName.Columns.Add(new DataColumn("TestNo", typeof(int)));
						this.dtTestName.Columns.Add(new DataColumn("TestName", typeof(string)));
						this.dtTestName.Columns.Add(new DataColumn("LSL", typeof(string)));
						this.dtTestName.Columns.Add(new DataColumn("USL", typeof(string)));
						this.dtTestName.Columns.Add(new DataColumn("R_LSL", typeof(string)));
						this.dtTestName.Columns.Add(new DataColumn("R_USL", typeof(string)));
						this.dtTestName.Columns.Add(new DataColumn("Unit", typeof(string)));
						for (int i = 1; i < array.Length; i++)
						{
							if (array[i].Trim() != string.Empty)
							{
								string[] values = array[i].Split(new char[]
								{
									','
								});
								this.dtTestName.Rows.Add(values);
							}
						}
						this.grid_Parameter.Columns.Clear();
						this.grid_Parameter.DataSource = this.dtTestName;
						this.grid_Parameter.AllowAddNewRow = false;
						this.grid_Parameter.ShowGroupPanel = false;
						this.grid_Parameter.EnableFiltering = true;
						this.grid_Parameter.EnableSorting = true;
						this.grid_Parameter.EnableGrouping = true;
						this.grid_Parameter.MasterView.TableHeaderRow.IsVisible = true;
						this.grid_Parameter.Columns["Seq"].Width = 50;
						this.grid_Parameter.Columns["TestNo"].Width = 80;
						this.grid_Parameter.Columns["TestName"].Width = 200;
						this.grid_Parameter.Columns["LSL"].Width = 100;
						this.grid_Parameter.Columns["USL"].Width = 100;
						this.grid_Parameter.Columns["R_LSL"].Width = 100;
						this.grid_Parameter.Columns["R_USL"].Width = 100;
						this.grid_Parameter.Columns["Unit"].Width = 80;
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
				RadMessageBox.Show(this, ex.Message.ToString(), "ESI Module", MessageBoxButtons.OK, RadMessageIcon.Error);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			finally
			{
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00008BE0 File Offset: 0x00006DE0
		private void btnUpload_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			string text2 = this.txtNewGroupName.Text.Trim();
			if (text2 == string.Empty)
			{
				RadMessageBox.Show(this, "Input Device name", "ESI Module", MessageBoxButtons.OK, RadMessageIcon.Error);
				return;
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetTesterParameterGroup]   @groupname = '" + text2 + "'";
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				DialogResult dialogResult = RadMessageBox.Show(this, text2 + " device is already registered.\nDo you want to delete and register again?", "ESI Module", MessageBoxButtons.YesNo, RadMessageIcon.Question);
				if (dialogResult != DialogResult.Yes)
				{
					return;
				}
			}
			sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_SetTesterParameterGroup]  @groupname = '" + text2 + "'";
			DataSet dataSet2 = this.queryCall(sQuery);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				text = dataSet2.Tables[0].Rows[0]["groupid"].ToString();
				if (this.dtTestName.Rows.Count > 0)
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Save Data....");
					this._barPrograss.setValue(0);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					this._barPrograss.setMax(this.dtTestName.Rows.Count);
					int num = 1;
					for (int i = 0; i < this.dtTestName.Rows.Count; i++)
					{
						string text3 = this.dtTestName.Rows[i]["TestNo"].ToString();
						string text4 = this.dtTestName.Rows[i]["TestName"].ToString();
						string text5 = this.dtTestName.Rows[i]["LSL"].ToString();
						string text6 = this.dtTestName.Rows[i]["USL"].ToString();
						string text7 = this.dtTestName.Rows[i]["R_LSL"].ToString();
						string text8 = this.dtTestName.Rows[i]["R_USL"].ToString();
						string text9 = this.dtTestName.Rows[i]["Unit"].ToString();
						sQuery = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_ESI_SetTesterParameter]  @groupid = '",
							text,
							"', @parameterno = '",
							text3,
							"', @parametername = '",
							text4,
							"', @seq = '",
							(i + 1).ToString(),
							"', @lsl = '",
							text5,
							"', @usl = '",
							text6,
							"', @r_lsl = '",
							text7,
							"', @r_usl = '",
							text8,
							"', @unit = '",
							text9,
							"'"
						});
						this.queryCall(sQuery);
						this._barPrograss.setValue(num++);
					}
					this.getTestGroup();
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00008F64 File Offset: 0x00007164
		private void btnDownload_Click(object sender, EventArgs e)
		{
			if (this.dtTestName.Rows.Count == 0)
			{
				this.dtTestName.TableName = "TestNo";
				this.dtTestName = new DataTable();
				this.dtTestName.Columns.Add(new DataColumn("Seq", typeof(int)));
				this.dtTestName.Columns.Add(new DataColumn("TestNo", typeof(int)));
				this.dtTestName.Columns.Add(new DataColumn("TestName", typeof(string)));
				this.dtTestName.Columns.Add(new DataColumn("LSL", typeof(string)));
				this.dtTestName.Columns.Add(new DataColumn("USL", typeof(string)));
				this.dtTestName.Columns.Add(new DataColumn("R_LSL", typeof(string)));
				this.dtTestName.Columns.Add(new DataColumn("R_USL", typeof(string)));
				this.dtTestName.Columns.Add(new DataColumn("Unit", typeof(string)));
			}
			this.saveFileDialog.DefaultExt = ".csv";
			this.saveFileDialog.Filter = "CSV files|*.csv|Excel files|*.xlsx";
			this.saveFileDialog.FilterIndex = 1;
			this.saveFileDialog.FileName = string.Empty;
			DialogResult dialogResult = this.saveFileDialog.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Save Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				this._barPrograss.setMax(this.dtTestName.Rows.Count);
				if (this.saveFileDialog.FilterIndex == 1)
				{
					this.SaveCSV(this.saveFileDialog.FileName, this.dtTestName);
				}
				else
				{
					SortedList sortedList = new SortedList();
					sortedList.Add(0, this.dtTestName);
					this.SaveExcel(this.saveFileDialog.FileName, sortedList, true);
				}
				this._barPrograss.setMax(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000091F8 File Offset: 0x000073F8
		private void btnSearch_SettingUnit_Click(object sender, EventArgs e)
		{
			this.dtSettingUnit = new DataTable();
			this.dtSettingUnit.Columns.Add(new DataColumn("Seq", typeof(int)));
			this.dtSettingUnit.Columns.Add(new DataColumn("X_COORD", typeof(int)));
			this.dtSettingUnit.Columns.Add(new DataColumn("Y_COORD", typeof(int)));
			this.dtSettingUnit.Columns.Add(new DataColumn("UpdateTime", typeof(string)));
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetParameterXY_Def] ";
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.dtSettingUnit.Rows.Add(new string[]
					{
						dataSet.Tables[0].Rows[i]["seq"].ToString(),
						dataSet.Tables[0].Rows[i]["x_coord"].ToString(),
						dataSet.Tables[0].Rows[i]["y_coord"].ToString(),
						dataSet.Tables[0].Rows[i]["updatetime"].ToString()
					});
				}
			}
			this.grid_SettingUnit.Columns.Clear();
			this.grid_SettingUnit.DataSource = this.dtSettingUnit;
			this.grid_SettingUnit.AllowAddNewRow = false;
			this.grid_SettingUnit.ShowGroupPanel = false;
			this.grid_SettingUnit.EnableFiltering = true;
			this.grid_SettingUnit.EnableSorting = true;
			this.grid_SettingUnit.EnableGrouping = true;
			this.grid_SettingUnit.MasterView.TableHeaderRow.IsVisible = true;
			this.grid_SettingUnit.AllowEditRow = true;
			this.grid_SettingUnit.Columns["Seq"].Width = 50;
			this.grid_SettingUnit.Columns["X_COORD"].Width = 80;
			this.grid_SettingUnit.Columns["Y_COORD"].Width = 80;
			this.grid_SettingUnit.Columns["UpdateTime"].Width = 120;
			this.grid_SettingUnit.Columns["X_COORD"].TextAlignment = ContentAlignment.MiddleCenter;
			this.grid_SettingUnit.Columns["Y_COORD"].TextAlignment = ContentAlignment.MiddleCenter;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000094E8 File Offset: 0x000076E8
		private void btnApply_SettingUnit_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = RadMessageBox.Show(this, "Do you want to apply data", "ESI Module", MessageBoxButtons.YesNo, RadMessageIcon.Question);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			for (int i = 0; i < this.grid_SettingUnit.Rows.Count; i++)
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_ESI_SetParameterXY_Def]   @x_coord = '",
					this.grid_SettingUnit.Rows[i].Cells["x_coord"].Value.ToString(),
					"', @y_coord = '",
					this.grid_SettingUnit.Rows[i].Cells["y_coord"].Value.ToString(),
					"', @seq = '",
					this.grid_SettingUnit.Rows[i].Cells["seq"].Value.ToString(),
					"'"
				});
				this.queryCall(sQuery);
			}
			this.btnSearch_SettingUnit_Click(null, null);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000095F3 File Offset: 0x000077F3
		private void btnSearch_MouseDown(object sender, MouseEventArgs e)
		{
			this.btnSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00009610 File Offset: 0x00007810
		private void btnSearch_MouseLeave(object sender, EventArgs e)
		{
			this.btnSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000962D File Offset: 0x0000782D
		private void btnSearch_MouseMove(object sender, MouseEventArgs e)
		{
			this.btnSearch.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000964A File Offset: 0x0000784A
		private void btnSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00009657 File Offset: 0x00007857
		private void btnDelete_MouseDown(object sender, MouseEventArgs e)
		{
			this.btnDelete.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00009674 File Offset: 0x00007874
		private void btnDelete_MouseLeave(object sender, EventArgs e)
		{
			this.btnDelete.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00009691 File Offset: 0x00007891
		private void btnDelete_MouseMove(object sender, MouseEventArgs e)
		{
			this.btnDelete.Image = Resources.TableRemove_Donw;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000096AE File Offset: 0x000078AE
		private void btnDelete_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000096BB File Offset: 0x000078BB
		private void btnFileOpen_MouseDown(object sender, MouseEventArgs e)
		{
			this.btnFileOpen.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000096D8 File Offset: 0x000078D8
		private void btnFileOpen_MouseLeave(object sender, EventArgs e)
		{
			this.btnFileOpen.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000096F5 File Offset: 0x000078F5
		private void btnFileOpen_MouseMove(object sender, MouseEventArgs e)
		{
			this.btnFileOpen.Image = Resources.OpenTable_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00009712 File Offset: 0x00007912
		private void btnFileOpen_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000971F File Offset: 0x0000791F
		private void btnUpload_MouseDown(object sender, MouseEventArgs e)
		{
			this.btnUpload.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000973C File Offset: 0x0000793C
		private void btnUpload_MouseLeave(object sender, EventArgs e)
		{
			this.btnUpload.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00009759 File Offset: 0x00007959
		private void btnUpload_MouseMove(object sender, MouseEventArgs e)
		{
			this.btnUpload.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00009776 File Offset: 0x00007976
		private void btnUpload_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00009783 File Offset: 0x00007983
		private void btnDownload_MouseDown(object sender, MouseEventArgs e)
		{
			this.btnDownload.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000097A0 File Offset: 0x000079A0
		private void btnDownload_MouseLeave(object sender, EventArgs e)
		{
			this.btnDownload.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000097BD File Offset: 0x000079BD
		private void btnDownload_MouseMove(object sender, MouseEventArgs e)
		{
			this.btnDownload.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000097DA File Offset: 0x000079DA
		private void btnDownload_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000097E7 File Offset: 0x000079E7
		private void btnSearch_SettingUnit_MouseDown(object sender, MouseEventArgs e)
		{
			this.btnSearch_SettingUnit.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00009804 File Offset: 0x00007A04
		private void btnSearch_SettingUnit_MouseLeave(object sender, EventArgs e)
		{
			this.btnSearch_SettingUnit.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00009821 File Offset: 0x00007A21
		private void btnSearch_SettingUnit_MouseMove(object sender, MouseEventArgs e)
		{
			this.btnSearch_SettingUnit.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000983E File Offset: 0x00007A3E
		private void btnSearch_SettingUnit_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000984B File Offset: 0x00007A4B
		private void btnApply_SettingUnit_MouseDown(object sender, MouseEventArgs e)
		{
			this.btnApply_SettingUnit.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00009868 File Offset: 0x00007A68
		private void btnApply_SettingUnit_MouseLeave(object sender, EventArgs e)
		{
			this.btnApply_SettingUnit.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00009885 File Offset: 0x00007A85
		private void btnApply_SettingUnit_MouseMove(object sender, MouseEventArgs e)
		{
			this.btnApply_SettingUnit.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000098A2 File Offset: 0x00007AA2
		private void btnApply_SettingUnit_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x04000115 RID: 277
		public FactorySettings _factorySettings;

		// Token: 0x04000116 RID: 278
		private DataTable dtGroup = new DataTable();

		// Token: 0x04000117 RID: 279
		private DataTable dtTestName = new DataTable();

		// Token: 0x04000118 RID: 280
		private DataTable dtSettingUnit = new DataTable();

		// Token: 0x04000119 RID: 281
		private Thread _thread;

		// Token: 0x0400011A RID: 282
		private BarPrograss _barPrograss;
	}
}
