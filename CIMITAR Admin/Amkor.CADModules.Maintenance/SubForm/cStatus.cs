using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.Properties;
using Amkor.CADModules.Maintenance.SubForm.SubControl;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using SevenZip;
using SourceGrid.Cells.Views;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x0200000E RID: 14
	public partial class cStatus : BaseWinView
	{
		// Token: 0x060000E5 RID: 229 RVA: 0x00027194 File Offset: 0x00025394
		private void btnSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.btnSearch.Image = Resources.TableSearch;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000271A7 File Offset: 0x000253A7
		private void btnSearch_MouseDown(object sender, MouseEventArgs e)
		{
			this.btnSearch.Image = Resources.TableSearch_Down;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000271BA File Offset: 0x000253BA
		private void btnExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.btnExcel.Image = Resources.SaveExcel;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000271CD File Offset: 0x000253CD
		private void btnExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.btnExcel.Image = Resources.SaveExcel_Down;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000271E0 File Offset: 0x000253E0
		private void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000271F0 File Offset: 0x000253F0
		public cStatus(CIMitarAccount _cimitarUser, FactorySettings factorySetting)
		{
			this._factorySetting = factorySetting;
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarMenu.menucode = 103001;
			this._queryMgr = new QueryMgr(this._factorySetting);
			this._sUserID = _cimitarUser._id;
			this._cimitarUser = _cimitarUser;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			this.InitializeComponent();
			this._ms = new GridView(GridViewType.HISTORY_MAINT, this._factorySetting, _cimitarUser, "Priority,Status,Report No.,Request Time,Start Time,End Time,Hold Time,Department,Requester,Category,Model,M/C#(Location#),Rsc Dec(Board#),Case,Factor,Difficulty", new EventHandler(this.pictureBox1_Click));
			this._ps = new GridView(GridViewType.HISTORY_PM, this._factorySetting, _cimitarUser, "Status,Report No.,Request Time,Approval Time,Start Time,Done Time,Final Time,Department,Requester,Category,Model,M/C#(Location#),Rsc Dec(Board#),Asset,Case,Factor,Difficulty,Work Type,Vendor", new EventHandler(this.pictureBox1_Click));
			this.tpMaintStatus.Controls.Add(this._ms);
			this.tpPMStatus.Controls.Add(this._ps);
			base.Tag = MainPageType.History;
			bool flag = commandLineArgs.Length == 2 && commandLineArgs[1].ToUpper() == "DEBUG";
			if (flag)
			{
				this._isAdmin = true;
				this.groupBox_Export.Visible = this._isAdmin;
			}
			bool flag2 = _cimitarUser._userstring1 != null;
			if (flag2)
			{
				string text = _cimitarUser._userstring1.ToString();
				bool flag3 = text.IndexOf("CAD_MAINT_ADMIN") != -1;
				if (flag3)
				{
					this._isAdmin = true;
					this.groupBox_Export.Visible = this._isAdmin;
				}
				bool flag4 = text.IndexOf("CAD_MAINT_MID") != -1;
				if (flag4)
				{
					this._isMiddle = true;
					this.groupBox_Export.Visible = this._isMiddle;
				}
			}
			this.dtStartDate.Value = DateTime.Now.AddDays(-60.0);
			this.dtEndDate.Value = DateTime.Now;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000273F0 File Offset: 0x000255F0
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
			Color backColor = Color.FromArgb(242, 203, 98);
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader2 = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader2.BackColor = backColor;
			columnHeader2.Border = RectangleBorder.NoBorder;
			columnHeader2.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_Report = new Cell();
			this.cell_Report.Background = columnHeader2;
			this.cell_Report.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			Color yellow = Color.Yellow;
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader3 = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader3.BackColor = yellow;
			columnHeader3.Border = RectangleBorder.NoBorder;
			columnHeader3.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_HoldReport = new Cell();
			this.cell_HoldReport.Background = columnHeader3;
			this.cell_HoldReport.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			Color silver = Color.Silver;
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader4 = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader4.BackColor = silver;
			columnHeader4.Border = RectangleBorder.NoBorder;
			columnHeader4.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_CloseReport = new Cell();
			this.cell_CloseReport.Background = columnHeader4;
			this.cell_CloseReport.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			Color backColor2 = Color.FromArgb(218, 217, 255);
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader5 = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader5.BackColor = backColor2;
			columnHeader5.Border = RectangleBorder.NoBorder;
			columnHeader5.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_PMReport = new Cell();
			this.cell_PMReport.Background = columnHeader5;
			this.cell_PMReport.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			Color backColor3 = Color.FromArgb(250, 224, 212);
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader6 = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader6.BackColor = backColor3;
			columnHeader6.Border = RectangleBorder.NoBorder;
			columnHeader6.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_CancelReport = new Cell();
			this.cell_CancelReport.Background = columnHeader6;
			this.cell_CancelReport.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00027640 File Offset: 0x00025840
		private void cStatus_Shown(object sender, EventArgs e)
		{
			this._bInitPlant = true;
			this.InitGridCell();
			cFunction.setPlant(this.combo_Plant, this._factorySetting._factoryName);
			bool flag = this.combo_Plant.Items.Count > 0;
			if (flag)
			{
				this.combo_Plant.SelectedIndex = 0;
			}
			this.combo_Index.SelectedIndex = 0;
			this._bInitPlant = false;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000276AC File Offset: 0x000258AC
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			DateTime d = new DateTime(this.dtStartDate.Value.Year, this.dtStartDate.Value.Month, this.dtStartDate.Value.Day, 0, 0, 0);
			DateTime d2 = new DateTime(this.dtEndDate.Value.Year, this.dtEndDate.Value.Month, this.dtEndDate.Value.Day, 23, 59, 59);
			TimeSpan timeSpan = d2 - d;
			bool flag = this.dtStartDate.Value > this.dtEndDate.Value;
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("check_period"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK);
			}
			else
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Search");
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(1);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				int selectedIndex = this.combo_Index.SelectedIndex;
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintHistory] @_Plant=N'",
					this.combo_Plant.SelectedItem.ToString().Trim(),
					"', @_StartDate=N'",
					this.dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00"),
					"', @_EndDate=N'",
					this.dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59"),
					"', @_Type=N'",
					this.combo_SearchStatus.SelectedItem.ToString().Trim(),
					"', @_Category=N'",
					this.combo_Category.SelectedItem.ToString().Trim(),
					"', @_Index=N'",
					(selectedIndex == 0) ? "Maint" : "PM",
					"'"
				});
				DataSet dataSet = this._queryMgr.queryCall(sQuery);
				bool flag2 = dataSet != null && dataSet.Tables.Count > 0;
				if (flag2)
				{
					this._reportList = new ReportList(dataSet.Tables);
					int num = selectedIndex;
					if (num != 0)
					{
						if (num == 1)
						{
							this._ps.SetGridInfo(this._reportList);
						}
					}
					else
					{
						this._ms.SetGridInfo(this._reportList);
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("no_data"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				bool flag3 = this._barPrograss != null;
				if (flag3)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void grid_history_MouseDoubleClick(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000279B4 File Offset: 0x00025BB4
		private void btnExcel_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.tbGridType.SelectedIndex;
			RadGridView radGridView;
			if (selectedIndex != 0)
			{
				if (selectedIndex != 1)
				{
					radGridView = null;
				}
				else
				{
					radGridView = this._ps.gridView;
				}
			}
			else
			{
				radGridView = this._ms.gridView;
			}
			bool flag = radGridView == null;
			if (!flag)
			{
				try
				{
					bool flag2 = radGridView.Rows.Count >= 1;
					if (flag2)
					{
						this.saveFileDialog.DefaultExt = ".xlsx";
						this.saveFileDialog.Filter = "Excel files|*.xlsx";
						this.saveFileDialog.FilterIndex = 1;
						this.saveFileDialog.FileName = string.Empty;
						DialogResult dialogResult = this.saveFileDialog.ShowDialog();
						bool flag3 = dialogResult == DialogResult.OK;
						if (flag3)
						{
							this._barPrograss = new BarPrograss();
							this._barPrograss.progress_labelheader_set("Save Data....");
							this._barPrograss.setValue(100);
							this._thread = new Thread(new ThreadStart(this.BarPrograssView));
							this._thread.Start();
							int selectedIndex2 = this.tbGridType.SelectedIndex;
							if (selectedIndex2 != 0)
							{
								if (selectedIndex2 == 1)
								{
									ExcelControl.Save3(this._factorySetting, this.saveFileDialog.FileName, this._ps.gridView, true, this._queryMgr, this.combo_Plant.SelectedItem.ToString().Trim(), this.combo_Category.SelectedItem.ToString().Trim(), this._reportList);
								}
							}
							else
							{
								ExcelControl.Save2(this._factorySetting, this.saveFileDialog.FileName, this._ms.gridView, true, this._queryMgr, this.combo_Plant.SelectedItem.ToString().Trim(), this.combo_Category.SelectedItem.ToString().Trim(), this._reportList);
							}
							this._barPrograss.setMax(100);
							this._barPrograss.setValue(100);
							Thread.Sleep(100);
							bool flag4 = this._barPrograss != null;
							if (flag4)
							{
								this._barPrograss._ischeck = true;
							}
							this._barPrograss = null;
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("no_data"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				catch (Exception ex)
				{
					ex.ToString();
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					bool flag5 = this._barPrograss != null;
					if (flag5)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00027C7C File Offset: 0x00025E7C
		private void combo_Plant_SelectedValueChanged(object sender, EventArgs e)
		{
			bool flag = !this._bInitPlant;
			if (flag)
			{
				this.combo_Index.SelectedIndex = -1;
				this.combo_Index.SelectedIndex = 0;
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00027CB4 File Offset: 0x00025EB4
		private string ExcuteSevenZip(string idx, string name, string Comment, DateTime dt)
		{
			FileStream fileStream = null;
			SevenZipExtractor sevenZipExtractor = null;
			string empty;
			try
			{
				byte[] array = Convert.FromBase64String(Comment);
				string str = "C:\\temp\\CimitarAdmin\\Maint\\";
				fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z", FileMode.Create);
				fileStream.Write(array, 0, array.Length);
				fileStream.Close();
				bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
				if (is64BitOperatingSystem)
				{
					SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x64.dll");
				}
				else
				{
					SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x86.dll");
				}
				sevenZipExtractor = new SevenZipExtractor("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z");
				bool flag = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z");
				if (flag)
				{
					sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
				}
				fileStream = null;
				bool flag2 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Problem.rtf");
				if (flag2)
				{
					bool flag3 = Directory.Exists("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp_Problem");
					if (flag3)
					{
						Directory.Delete("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp_Problem", true);
					}
					Process process = Process.Start(new ProcessStartInfo
					{
						WindowStyle = ProcessWindowStyle.Hidden,
						FileName = "C:\\Users\\jisyang\\Desktop\\RtfConverter_v1.7.0 (2)\\bin\\Release\\Rtf2Html.exe",
						Arguments = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Problem.rtf C:\\temp\\CimitarAdmin\\Maint\\download\\Temp_Problem /ID:image /DS:body,content"
					});
					process.WaitForExit();
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Problem.rtf");
					File.Delete(str + "\\" + idx + "_Temp_Problem.zip");
					bool flag4 = Directory.Exists("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp_Problem");
					if (flag4)
					{
						ZipFile.CreateFromDirectory("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp_Problem", str + "\\" + idx + "_Temp_Problem.zip");
					}
					fileStream = new FileStream(str + "\\" + idx + "_Temp_Problem.zip", FileMode.Open);
					bool flag5 = fileStream != null;
					if (flag5)
					{
						byte[] array2 = new byte[fileStream.Length];
						fileStream.Read(array2, 0, array2.Length);
						fileStream.Close();
						string sQuery = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetWebMaintData] @_Report= N'",
							name,
							"', @_TempProblem=N'",
							Convert.ToBase64String(array2),
							"'"
						});
						DataSet dataSet = this._queryMgr.queryCall(sQuery);
					}
				}
				bool flag6 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Action.rtf");
				if (flag6)
				{
					bool flag7 = Directory.Exists("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp_Action");
					if (flag7)
					{
						Directory.Delete("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp_Action", true);
					}
					Process process2 = Process.Start(new ProcessStartInfo
					{
						WindowStyle = ProcessWindowStyle.Hidden,
						FileName = "C:\\Users\\jisyang\\Desktop\\RtfConverter_v1.7.0 (2)\\bin\\Release\\Rtf2Html.exe",
						Arguments = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Action.rtf C:\\temp\\CimitarAdmin\\Maint\\download\\Temp_Action /ID:image /DS:body,content"
					});
					process2.WaitForExit();
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Action.rtf");
					File.Delete(str + "\\" + idx + "_Temp_Action.zip");
					bool flag8 = Directory.Exists("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp_Action");
					if (flag8)
					{
						ZipFile.CreateFromDirectory("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp_Action", str + "\\" + idx + "_Temp_Action.zip");
					}
					fileStream = new FileStream(str + "\\" + idx + "_Temp_Action.zip", FileMode.Open);
					bool flag9 = fileStream != null;
					if (flag9)
					{
						byte[] array3 = new byte[fileStream.Length];
						fileStream.Read(array3, 0, array3.Length);
						fileStream.Close();
						string sQuery2 = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetWebMaintData] @_Report= N'",
							name,
							"', @_TempAction=N'",
							Convert.ToBase64String(array3),
							"'"
						});
						DataSet dataSet2 = this._queryMgr.queryCall(sQuery2);
					}
				}
				bool flag10 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\TempC.rtf");
				if (flag10)
				{
					bool flag11 = Directory.Exists("C:\\temp\\CimitarAdmin\\Maint\\download\\TempC");
					if (flag11)
					{
						Directory.Delete("C:\\temp\\CimitarAdmin\\Maint\\download\\TempC", true);
					}
					Process process3 = Process.Start(new ProcessStartInfo
					{
						WindowStyle = ProcessWindowStyle.Hidden,
						FileName = "\"C:\\Users\\jisyang\\Desktop\\RtfConverter_v1.7.0 (2)\\bin\\Release\\Rtf2Html.exe\"",
						Arguments = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\TempC.rtf C:\\temp\\CimitarAdmin\\Maint\\download\\TempC /ID:image /DS:body,content"
					});
					process3.WaitForExit();
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\TempC.rtf");
					File.Delete(str + "\\" + idx + "_TempC.zip");
					bool flag12 = Directory.Exists("C:\\temp\\CimitarAdmin\\Maint\\download\\TempC");
					if (flag12)
					{
						ZipFile.CreateFromDirectory("C:\\temp\\CimitarAdmin\\Maint\\download\\TempC", str + "\\" + idx + "_TempC.zip");
					}
					fileStream = new FileStream(str + "\\" + idx + "_TempC.zip", FileMode.Open);
					bool flag13 = fileStream != null;
					if (flag13)
					{
						byte[] array4 = new byte[fileStream.Length];
						fileStream.Read(array4, 0, array4.Length);
						fileStream.Close();
						string sQuery3 = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetWebMaintData] @_Report= N'",
							name,
							"', @_TempC=N'",
							Convert.ToBase64String(array4),
							"'"
						});
						DataSet dataSet3 = this._queryMgr.queryCall(sQuery3);
					}
				}
				bool flag14 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.rtf");
				if (flag14)
				{
					bool flag15 = Directory.Exists("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp");
					if (flag15)
					{
						Directory.Delete("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp", true);
					}
					Process process4 = Process.Start(new ProcessStartInfo
					{
						WindowStyle = ProcessWindowStyle.Hidden,
						FileName = "C:\\Users\\jisyang\\Desktop\\RtfConverter_v1.7.0 (2)\\bin\\Release\\Rtf2Html.exe",
						Arguments = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.rtf C:\\temp\\CimitarAdmin\\Maint\\download\\Temp /ID:image /DS:body,content"
					});
					process4.WaitForExit();
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.rtf");
					File.Delete(str + "\\" + idx + "_Temp.zip");
					bool flag16 = Directory.Exists("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp");
					if (flag16)
					{
						ZipFile.CreateFromDirectory("C:\\temp\\CimitarAdmin\\Maint\\download\\Temp", str + "\\" + idx + "_Temp.zip");
					}
					fileStream = new FileStream(str + "\\" + idx + "_Temp.zip", FileMode.Open);
					bool flag17 = fileStream != null;
					if (flag17)
					{
						byte[] array5 = new byte[fileStream.Length];
						fileStream.Read(array5, 0, array5.Length);
						fileStream.Close();
						string sQuery4 = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetWebMaintData] @_Report= N'",
							name,
							"', @_Temp=N'",
							Convert.ToBase64String(array5),
							"'"
						});
						DataSet dataSet4 = this._queryMgr.queryCall(sQuery4);
					}
				}
				bool flag18 = fileStream != null;
				if (flag18)
				{
					fileStream.Close();
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Problem.rtf");
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Action.rtf");
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\TempC.rtf");
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.rtf");
					empty = string.Empty;
				}
				else
				{
					empty = string.Empty;
				}
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZip", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\History.cs", 620);
				empty = string.Empty;
			}
			finally
			{
				bool flag19 = sevenZipExtractor != null;
				if (flag19)
				{
					sevenZipExtractor.Dispose();
				}
				bool flag20 = fileStream != null;
				if (flag20)
				{
					fileStream.Dispose();
				}
			}
			return empty;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0002835C File Offset: 0x0002655C
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.combo_Index.SelectedIndex;
			if (selectedIndex != 0)
			{
				if (selectedIndex == 1)
				{
					this.combo_SearchStatus.Items.Clear();
					this.combo_SearchStatus.Items.Add("All");
					this.combo_SearchStatus.Items.Add("PM Request");
					this.combo_SearchStatus.Items.Add("PM Approval");
					this.combo_SearchStatus.Items.Add("PM Done");
					this.combo_SearchStatus.Items.Add("PM Final");
					this.combo_SearchStatus.Items.Add("PM Cancel");
					cFunction.getCategoryList(this._factorySetting, this.combo_Plant.SelectedItem.ToString(), this.combo_Category, true, true);
					this.combo_SearchStatus.SelectedIndex = 0;
					this.combo_Category.SelectedIndex = 0;
					this.tbGridType.SelectedIndex = 1;
				}
			}
			else
			{
				this.combo_SearchStatus.Items.Clear();
				this.combo_SearchStatus.Items.Add("All");
				this.combo_SearchStatus.Items.Add("Request");
				this.combo_SearchStatus.Items.Add("Closed");
				this.combo_SearchStatus.Items.Add("Hold");
				this.combo_SearchStatus.SelectedIndex = 0;
				cFunction.getCategoryList(this._factorySetting, this.combo_Plant.SelectedItem.ToString(), this.combo_Category, true, false);
				this.combo_Category.SelectedIndex = 0;
				this.tbGridType.SelectedIndex = 0;
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00028522 File Offset: 0x00026722
		private void pbLayout_Click(object sender, EventArgs e)
		{
			this._ms.saveLayout();
		}

		// Token: 0x040001F5 RID: 501
		private Cell cell_header1;

		// Token: 0x040001F6 RID: 502
		private Cell cell_Report;

		// Token: 0x040001F7 RID: 503
		private Cell cell_HoldReport;

		// Token: 0x040001F8 RID: 504
		private Cell cell_CloseReport;

		// Token: 0x040001F9 RID: 505
		private Cell cell_PMReport;

		// Token: 0x040001FA RID: 506
		private Cell cell_CancelReport;

		// Token: 0x040001FB RID: 507
		private string _sUserID = string.Empty;

		// Token: 0x040001FC RID: 508
		private BarPrograss _barPrograss;

		// Token: 0x040001FD RID: 509
		private Thread _thread;

		// Token: 0x040001FE RID: 510
		private QueryMgr _queryMgr;

		// Token: 0x040001FF RID: 511
		private ReportList _reportList;

		// Token: 0x04000200 RID: 512
		private GridView _ms;

		// Token: 0x04000201 RID: 513
		private GridView _ps;

		// Token: 0x04000202 RID: 514
		private bool _isAdmin = false;

		// Token: 0x04000203 RID: 515
		private bool _isMiddle = false;

		// Token: 0x04000204 RID: 516
		private bool _bInitPlant = false;

		// Token: 0x04000205 RID: 517
		private const string _defaultMaintHeader = "Priority,Status,Report No.,Request Time,Start Time,End Time,Hold Time,Department,Requester,Category,Model,M/C#(Location#),Rsc Dec(Board#),Case,Factor,Difficulty";

		// Token: 0x04000206 RID: 518
		private const string _defaultPMHeader = "Status,Report No.,Request Time,Approval Time,Start Time,Done Time,Final Time,Department,Requester,Category,Model,M/C#(Location#),Rsc Dec(Board#),Asset,Case,Factor,Difficulty,Work Type,Vendor";
	}
}
