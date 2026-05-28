using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
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
using SevenZip;
using SourceGrid;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.Maintenance.SubForm.search
{
	// Token: 0x02000012 RID: 18
	public partial class SearchForm : BaseWinView
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000142 RID: 322 RVA: 0x0003E43B File Offset: 0x0003C63B
		// (set) Token: 0x06000141 RID: 321 RVA: 0x0003E432 File Offset: 0x0003C632
		public CheckBox checkWebView { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000144 RID: 324 RVA: 0x0003E44C File Offset: 0x0003C64C
		// (set) Token: 0x06000143 RID: 323 RVA: 0x0003E443 File Offset: 0x0003C643
		public Panel panelWebView { get; private set; }

		// Token: 0x06000145 RID: 325 RVA: 0x0003E454 File Offset: 0x0003C654
		private void btnSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.btnSearch.Image = Resources.TableSearch;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0003E467 File Offset: 0x0003C667
		private void btnSearch_MouseDown(object sender, MouseEventArgs e)
		{
			this.btnSearch.Image = Resources.TableSearch_Down;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0003E47A File Offset: 0x0003C67A
		private void btnExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.btnExcel.Image = Resources.SaveExcel_Down;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0003E48D File Offset: 0x0003C68D
		private void btnExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.btnExcel.Image = Resources.SaveExcel;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0003E4A0 File Offset: 0x0003C6A0
		private void btn_Close_Click(object sender, EventArgs e)
		{
			this.pnWebView.Visible = false;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0003E4AF File Offset: 0x0003C6AF
		private void refreshContents(bool bPrevious)
		{
			this.getSearchData(true, bPrevious);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0003E4BC File Offset: 0x0003C6BC
		private void tbContents_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == '\r';
			if (flag)
			{
				this.btnSearch_Click(null, null);
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0003E4E4 File Offset: 0x0003C6E4
		private void combo_Index_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.cbType.SelectedIndex;
			if (selectedIndex != 0)
			{
				if (selectedIndex == 1)
				{
					this.tbGridType.SelectedIndex = 1;
					cFunction.getCategoryList(this._factorySetting, this.cbPlant.SelectedItem.ToString(), this.cbCategory, false, true);
				}
			}
			else
			{
				this.tbGridType.SelectedIndex = 0;
				cFunction.getCategoryList(this._factorySetting, this.cbPlant.SelectedItem.ToString(), this.cbCategory, false, false);
			}
			cFunction.getCaseList(this.cbCase, true);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0003E57C File Offset: 0x0003C77C
		private void SearchForm_Shown(object sender, EventArgs e)
		{
			this.tbContents.Text = string.Empty;
			this.tbContents.TextAlign = HorizontalAlignment.Left;
			this._sFactor = string.Empty;
			cFunction.setPlant(this.cbPlant, this._factorySetting._factoryName);
			this.dtStartDate.Value = DateTime.Now.AddDays(-180.0);
			this.dtEndDate.Value = DateTime.Now;
			this.getUserData(this._sUserId);
			this._msv = new GridView(GridViewType.SEARCH_MAINT, this._factorySetting, this._cimitarUser, "No.,Status,Report No.,Request Time,Category,Model,M/C#(Location#),Rsc Dec(Board#),Case,Factor,Check Item,Requirement,Problem,Action", this, new EventHandler(this.btnSearch_Click));
			this._msv.Parent = this.tpStatus;
			this._psv = new GridView(GridViewType.SEARCH_PM, this._factorySetting, this._cimitarUser, "No.,Status,Report No.,Request Time,Category,Model,M/C#(Location#),Rsc Dec(Board#),Asset,Case,Factor,Work Type,Problems or Reason of use,Evidence (PCS pre-approval),Approval Comment,Action and Changes,Result and Evaluation,Comment,Final Comment", this, new EventHandler(this.btnSearch_Click));
			this._psv.Parent = this.tpPMStatus;
			this.tpStatus.Controls.Add(this._msv);
			this.tpPMStatus.Controls.Add(this._psv);
			this.cbPlant.SelectedIndex = 0;
			this.cbType.SelectedIndex = 0;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0003E6CC File Offset: 0x0003C8CC
		private void grid_search_MouseClick(object sender, MouseEventArgs e)
		{
			Grid grid = (Grid)sender;
			int row = grid.MouseDownPosition.Row;
			int column = grid.MouseDownPosition.Column;
			bool flag = column == 3 && row != 0;
			if (flag)
			{
				string displayText = grid[row, 1].DisplayText;
				string displayText2 = grid[row, 2].DisplayText;
				string displayText3 = grid[row, column - 1].DisplayText;
				bool flag2 = displayText == "PM(Request)" || displayText == "PM(Approval)" || displayText == "PM(Final)" || displayText == "PM(Done)" || displayText == "PM(Cancel)";
				bool flag3 = flag2;
				bool flag4 = flag3;
				if (flag4)
				{
					PMAction pmaction = new PMAction(displayText2, this._factorySetting, this._cimitarUser);
					pmaction.ShowDialog();
				}
				else
				{
					cAction cAction = new cAction(displayText2, this._factorySetting, this._cimitarUser);
					cAction.ShowDialog();
				}
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0003E7E4 File Offset: 0x0003C9E4
		private void grid_search_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Grid grid = (Grid)sender;
			int row = grid.MouseDownPosition.Row;
			int column = grid.MouseDownPosition.Column;
			bool flag = row == -1 || column == -1;
			if (!flag)
			{
				bool flag2 = row != 0;
				if (flag2)
				{
					string displayText = grid[row, 2].DisplayText;
					string displayText2 = grid[row, 1].DisplayText;
					bool @checked = this.cbWebView.Checked;
					if (@checked)
					{
						bool flag3 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action\\action.html");
						if (flag3)
						{
							File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action\\action.html");
						}
						bool flag4 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report\\report.html");
						if (flag4)
						{
							File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report\\report.html");
						}
						bool flag5 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content1.html");
						if (flag5)
						{
							File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content1.html");
						}
						bool flag6 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content2.html");
						if (flag6)
						{
							File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content2.html");
						}
						bool flag7 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content3.html");
						if (flag7)
						{
							File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content3.html");
						}
						bool flag8 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content4.html");
						if (flag8)
						{
							File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content4.html");
						}
						bool flag9 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content5.html");
						if (flag9)
						{
							File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content5.html");
						}
					}
					bool flag10 = displayText2.IndexOf("PM") != -1;
					bool flag11 = flag10;
					PMAction pmaction = null;
					cAction cAction = null;
					bool flag12 = flag11;
					if (flag12)
					{
						pmaction = new PMAction(displayText, this._factorySetting, this._cimitarUser);
					}
					else
					{
						cAction = new cAction(displayText, this._factorySetting, this._cimitarUser);
					}
					bool checked2 = this.cbWebView.Checked;
					if (checked2)
					{
						bool flag13 = displayText2.ToUpper().Trim().IndexOf("HOLD") == -1;
						if (flag13)
						{
							this.pnWebView.Visible = true;
							bool flag14 = displayText2.ToUpper().Trim().IndexOf("CLOSE") != -1;
							if (flag14)
							{
								this.loadMailForm(true, flag11);
							}
							else
							{
								this.loadMailForm(false, flag11);
							}
						}
						else
						{
							bool flag15 = flag11;
							if (flag15)
							{
								pmaction.ShowDialog();
							}
							else
							{
								cAction.ShowDialog();
							}
						}
					}
					else
					{
						bool flag16 = flag11;
						if (flag16)
						{
							pmaction.ShowDialog();
						}
						else
						{
							cAction.ShowDialog();
						}
					}
				}
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0003EA44 File Offset: 0x0003CC44
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
					radGridView = this._psv.gridView;
				}
			}
			else
			{
				radGridView = this._msv.gridView;
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
							ExcelControl.Save(this.saveFileDialog.FileName, radGridView, true, null);
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

		// Token: 0x06000151 RID: 337 RVA: 0x0003EC4C File Offset: 0x0003CE4C
		private void btnSearch_Click(object sender, EventArgs e)
		{
			bool flag = this.dtStartDate.Value > this.dtEndDate.Value;
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("check_period"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK);
			}
			else
			{
				DateTime d = new DateTime(this.dtStartDate.Value.Year, this.dtStartDate.Value.Month, this.dtStartDate.Value.Day, 0, 0, 0);
				DateTime d2 = new DateTime(this.dtEndDate.Value.Year, this.dtEndDate.Value.Month, this.dtEndDate.Value.Day, 23, 59, 59);
				TimeSpan timeSpan = d2 - d;
				bool flag2 = this.cbPlant.SelectedIndex == -1;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("select_search_factory"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					bool flag3 = this.cbCategory.SelectedIndex == -1;
					if (flag3)
					{
						MessageBox.Show(MessageLanguage.getMessage("select_search_category"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						bool flag4 = this.cbCase.SelectedIndex == -1;
						if (flag4)
						{
							MessageBox.Show(MessageLanguage.getMessage("select_search_case"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							bool flag5 = this.cbCase.SelectedIndex != 0 && this.cbFactor.SelectedIndex == -1;
							if (flag5)
							{
								MessageBox.Show(MessageLanguage.getMessage("select_search_factor"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
							else
							{
								bool flag6 = this.cbCase.SelectedIndex == 0 && string.IsNullOrEmpty(this.tbContents.Text.Trim());
								if (flag6)
								{
									MessageBox.Show(MessageLanguage.getMessage("select_search"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
								else
								{
									this._sStartDate = this.dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00");
									this._sEndDate = this.dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59");
									bool flag7 = this.cbFactor.SelectedItem != null;
									if (flag7)
									{
										this._sFactor = this.cbFactor.SelectedItem.ToString().Trim();
									}
									else
									{
										this._sFactor = string.Empty;
									}
									this.getSearchData(false, false);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0003EEF0 File Offset: 0x0003D0F0
		private void SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			bool flag = !this.cbFactor.Equals(comboBox);
			if (flag)
			{
				this.cbFactor.Items.Clear();
			}
			bool flag2 = comboBox.SelectedIndex == -1;
			if (!flag2)
			{
				bool flag3 = this.cbPlant.Equals(comboBox);
				if (flag3)
				{
					this.cbType.SelectedIndex = 0;
					this.cbCategory.SelectedIndex = -1;
					this.cbCase.SelectedIndex = -1;
					this.cbModel.Items.Clear();
					cFunction.getCategoryList(this._factorySetting, this.cbPlant.SelectedItem.ToString(), this.cbCategory, false, false);
				}
				else
				{
					bool flag4 = this.cbCategory.Equals(comboBox);
					if (flag4)
					{
						this.cbFactor.Enabled = false;
						this.cbCase.SelectedIndex = -1;
					}
					else
					{
						bool flag5 = this.cbModel.Equals(comboBox);
						if (!flag5)
						{
							bool flag6 = this.cbCase.Equals(comboBox);
							if (flag6)
							{
							}
						}
					}
				}
				bool flag7 = this.cbCategory.SelectedIndex == -1 || this.cbPlant.SelectedIndex == -1 || this.cbCase.SelectedIndex == 0;
				if (flag7)
				{
					this.cbFactor.Enabled = false;
				}
				else
				{
					this.cbFactor.Enabled = true;
					this.setComboFactor();
				}
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0003F060 File Offset: 0x0003D260
		public SearchForm()
		{
			this.InitializeComponent();
			base.Tag = MainPageType.Search;
			this.checkWebView = this.cbWebView;
			this.panelWebView = this.pnWebView;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0003F108 File Offset: 0x0003D308
		public SearchForm(CIMitarAccount _cimitarUser, FactorySettings factorySetting)
		{
			this._factorySetting = factorySetting;
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarMenu.menucode = 103001;
			this._queryMgr = new QueryMgr(this._factorySetting);
			this._sUserId = _cimitarUser._id;
			this._cimitarUser = _cimitarUser;
			this.InitializeComponent();
			base.Tag = MainPageType.Search;
			this.cbIndex.SelectedIndex = 0;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			this.pnExport.Visible = false;
			bool flag = commandLineArgs.Length == 2 && commandLineArgs[1].ToUpper() == "DEBUG";
			if (flag)
			{
				this.pnExport.Visible = true;
				this._sUserId = "jisyang01";
			}
			bool flag2 = _cimitarUser._userstring1 != null;
			if (flag2)
			{
				string text = _cimitarUser._userstring1.ToString();
				bool flag3 = text.IndexOf("CAD_MAINT_ADMIN") != -1;
				if (flag3)
				{
					this.pnExport.Visible = true;
				}
				bool flag4 = text.IndexOf("CAD_MAINT_MID") != -1;
				if (flag4)
				{
					this.pnExport.Visible = true;
				}
			}
			this.cbWebView.Checked = true;
			this.pnWebView.Visible = false;
			this.checkWebView = this.cbWebView;
			this.panelWebView = this.pnWebView;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0003F2C9 File Offset: 0x0003D4C9
		private void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0003F2D8 File Offset: 0x0003D4D8
		private void getMachineNumber(bool otherType)
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMachineList]  @SearchType = '" + this.cbCategory.SelectedItem.ToString() + "'";
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				int num = 0;
				string text = "";
				string[] array = new string[dataSet.Tables[0].Rows.Count];
				AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
				AutoCompleteStringCollection autoCompleteStringCollection2 = new AutoCompleteStringCollection();
				this._MachineModelList.Clear();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text2 = dataSet.Tables[0].Rows[i]["Type"].ToString();
					string sSelectRsc = string.Empty;
					bool flag2 = this.cbCategory.SelectedItem.ToString().CompareTo("EOL") == 0 || this.cbCategory.SelectedItem.ToString().CompareTo("STACK") == 0;
					if (flag2)
					{
						sSelectRsc = dataSet.Tables[0].Rows[i]["Rsc"].ToString();
					}
					MachineInfo machineInfo = new MachineInfo();
					machineInfo.sSelectModel = text2;
					machineInfo.sSelectRsc = sSelectRsc;
					this._MachineModelList.Add(machineInfo);
					bool flag3 = text.CompareTo(text2) != 0;
					if (flag3)
					{
						array[i] = text2;
						text = text2;
						num++;
					}
				}
				string[] array2 = new string[num];
				int num2 = 0;
				for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
				{
					bool flag4 = array[j] != null;
					if (flag4)
					{
						array2[num2++] = array[j];
					}
				}
				autoCompleteStringCollection2.AddRange(array2);
				this.cbModel.Items.Clear();
				this.cbModel.Items.Add("All");
				for (int k = 0; k < array2.Length; k++)
				{
					this.cbModel.Items.Add(array2[k]);
				}
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0003F540 File Offset: 0x0003D740
		private string ExcuteSevenZip(string binary)
		{
			FileStream fileStream = null;
			SevenZipExtractor sevenZipExtractor = null;
			string result;
			try
			{
				byte[] array = Convert.FromBase64String(binary);
				bool flag = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\test.7z");
				if (flag)
				{
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\test.7z");
				}
				fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\test.7z", FileMode.Create);
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
				bool flag2 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\test.7z");
				if (flag2)
				{
					bool flag3 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.rtf");
					if (flag3)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.rtf");
					}
					sevenZipExtractor = new SevenZipExtractor("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\test.7z");
					sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
				}
				bool flag4 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.rtf");
				if (flag4)
				{
					fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.rtf", FileMode.Open);
				}
				else
				{
					fileStream = null;
				}
				bool flag5 = fileStream != null;
				if (flag5)
				{
					array = new byte[fileStream.Length];
					fileStream.Read(array, 0, array.Length);
					fileStream.Close();
					result = Encoding.ASCII.GetString(array);
				}
				else
				{
					result = string.Empty;
				}
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZip", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\SearchForm.cs", 620);
				result = string.Empty;
			}
			finally
			{
				bool flag6 = sevenZipExtractor != null;
				if (flag6)
				{
					sevenZipExtractor.Dispose();
				}
				bool flag7 = fileStream != null;
				if (flag7)
				{
					fileStream.Dispose();
				}
			}
			return result;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0003F6FC File Offset: 0x0003D8FC
		private int checkPlant()
		{
			bool flag = this.cbPlant.SelectedItem.ToString() == "ATV";
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0003F734 File Offset: 0x0003D934
		private void setComboFactor()
		{
			cFunction.getFactorList(this._factorySetting, this.cbFactor, this.cbCategory.SelectedItem.ToString().Trim(), this.cbPlant.SelectedItem.ToString().Trim(), this._FactorList, true);
			this.pnFactor.Width = this.cbCase.Width;
			foreach (KeyValuePair<string, string> keyValuePair in this._FactorList)
			{
				bool flag = this.cbCase.SelectedItem != null && this.cbCase.SelectedItem.ToString().ToUpper() == keyValuePair.Value;
				if (flag)
				{
					this.cbFactor.Items.Add(keyValuePair.Key);
					bool flag2 = this.pnFactor.Width < keyValuePair.Key.Length * (int)this.cbFactor.Font.Size;
					if (flag2)
					{
						this.pnFactor.Width = keyValuePair.Key.Length * (int)this.cbFactor.Font.Size;
					}
				}
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0003F890 File Offset: 0x0003DA90
		private void getSearchData(bool bRefresh, bool bPrevious = false)
		{
			this._barPrograss = new BarPrograss();
			this._barPrograss.progress_labelheader_set("Search");
			this._barPrograss.setMax(100);
			this._barPrograss.setValue(1);
			this._thread = new Thread(new ThreadStart(this.BarPrograssView));
			this._thread.Start();
			bool flag = true;
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintDataSearch]";
			text = text + " @_keyword =N'" + this.tbContents.Text.Trim() + "'";
			text = text + ", @_plant =N'" + this.cbPlant.SelectedItem.ToString().Trim() + "'";
			text = text + ", @_category =N'" + this.cbCategory.SelectedItem.ToString().Trim() + "'";
			text = text + ", @_case =N'" + this.cbCase.SelectedItem.ToString().Trim() + "'";
			text = text + ", @_factor =N'" + this._sFactor + "'";
			text = text + ", @_Index=N'" + this.cbType.SelectedItem.ToString() + "'";
			text = text + ", @_SearchIndex=N'" + this.cbIndex.SelectedItem.ToString().Replace("'", string.Empty).ToUpper() + "'";
			bool flag2 = !string.IsNullOrEmpty(this._sStartDate) && !string.IsNullOrEmpty(this._sEndDate);
			if (flag2)
			{
				text = text + ", @_startDate =N'" + this.dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00") + "'";
				text = text + ", @_endDate =N'" + this.dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
			}
			text += ", @_flag =N'3'";
			DataSet dataSet = this._queryMgr.queryCall(text);
			bool flag3 = flag || (dataSet != null && dataSet.Tables.Count > 0);
			if (flag3)
			{
				this._reportList = new ReportList(dataSet.Tables);
				this._barPrograss.setMax(this._reportList.listReport.Count);
				this._reportList.listReport.Sort((ReportList.ReportObject x1, ReportList.ReportObject x2) => x2.RequestTime.CompareTo(x1.RequestTime));
				int selectedIndex = this.cbType.SelectedIndex;
				if (selectedIndex != 0)
				{
					if (selectedIndex == 1)
					{
						this._psv.SetGridInfo(this._reportList);
					}
				}
				else
				{
					this._msv.SetGridInfo(this._reportList);
				}
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

		// Token: 0x0600015B RID: 347 RVA: 0x0003FBA0 File Offset: 0x0003DDA0
		private void getUserData(string sUserID)
		{
			bool flag = !string.IsNullOrEmpty(CIMitarLogin._id);
			if (flag)
			{
				sUserID = CIMitarLogin._id;
			}
			string userData_SubFunc = cFunction.getUserData_SubFunc(sUserID);
			bool flag2 = userData_SubFunc.ToUpper().IndexOf("NOT EXIST") == -1;
			if (flag2)
			{
				string[] array = userData_SubFunc.Split(new char[]
				{
					';'
				});
				bool flag3 = array.Length != 0 && array.Length == 3;
				if (flag3)
				{
					string text = array[1];
					bool flag4 = text.IndexOf("K3") != -1;
					if (flag4)
					{
						this.cbPlant.SelectedIndex = 0;
					}
					else
					{
						bool flag5 = text.IndexOf("K5") != -1;
						if (flag5)
						{
							this.cbPlant.SelectedIndex = 1;
						}
						else
						{
							this.cbPlant.SelectedIndex = 0;
						}
					}
				}
				else
				{
					this.cbPlant.SelectedIndex = 0;
				}
			}
			else
			{
				this.cbPlant.SelectedIndex = 0;
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0003FC94 File Offset: 0x0003DE94
		public bool loadMailForm(bool action, bool isPM)
		{
			bool result;
			try
			{
				this.web_Viewer.Refresh();
				this.pnWebView.Dock = DockStyle.Fill;
				bool flag = action && !isPM;
				if (flag)
				{
					this.web_Viewer.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action\\action.html");
				}
				else if (isPM)
				{
					bool flag2 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content1.html");
					if (flag2)
					{
						this.web_Viewer.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content1.html");
					}
					bool flag3 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content5.html");
					if (flag3)
					{
						this.web_Viewer.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content5.html");
					}
					else
					{
						bool flag4 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content2.html");
						if (flag4)
						{
							this.web_Viewer.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content2.html");
						}
						bool flag5 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content3.html");
						if (flag5)
						{
							this.web_Viewer.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content3.html");
						}
						bool flag6 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content4.html");
						if (flag6)
						{
							this.web_Viewer.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content4.html");
						}
					}
				}
				else
				{
					this.web_Viewer.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report\\report.html");
				}
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		// Token: 0x040002B5 RID: 693
		private const string _defaultMaintHeader = "No.,Status,Report No.,Request Time,Category,Model,M/C#(Location#),Rsc Dec(Board#),Case,Factor,Check Item,Requirement,Problem,Action";

		// Token: 0x040002B6 RID: 694
		private const string _defaultPMHeader = "No.,Status,Report No.,Request Time,Category,Model,M/C#(Location#),Rsc Dec(Board#),Asset,Case,Factor,Work Type,Problems or Reason of use,Evidence (PCS pre-approval),Approval Comment,Action and Changes,Result and Evaluation,Comment,Final Comment";

		// Token: 0x040002B7 RID: 695
		private readonly int MAXIMUM_CONTENTS = 100000;

		// Token: 0x040002B8 RID: 696
		private QueryMgr _queryMgr;

		// Token: 0x040002B9 RID: 697
		private string _sUserId = string.Empty;

		// Token: 0x040002BA RID: 698
		private ReportList _reportList;

		// Token: 0x040002BB RID: 699
		private List<MachineInfo> _MachineModelList = new List<MachineInfo>();

		// Token: 0x040002BC RID: 700
		private BarPrograss _barPrograss;

		// Token: 0x040002BD RID: 701
		private Thread _thread;

		// Token: 0x040002BE RID: 702
		private Dictionary<string, string> _FactorList = new Dictionary<string, string>();

		// Token: 0x040002BF RID: 703
		private string _sStartDate = string.Empty;

		// Token: 0x040002C0 RID: 704
		private string _sEndDate = string.Empty;

		// Token: 0x040002C1 RID: 705
		private string _sFactor = string.Empty;

		// Token: 0x040002C2 RID: 706
		private GridView _msv = null;

		// Token: 0x040002C3 RID: 707
		private GridView _psv = null;
	}
}
