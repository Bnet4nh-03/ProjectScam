using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Interface;
using Amkor.CADModules.Maintenance.SubForm.MaintReportControl;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.ReportSubControl
{
	// Token: 0x02000017 RID: 23
	public class ReportInformation : UserControl, IHCC
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00046A46 File Offset: 0x00044C46
		public HCC _hCC { get; }

		// Token: 0x060001A1 RID: 417 RVA: 0x00046A4E File Offset: 0x00044C4E
		public void setHCCId(string id)
		{
			this.tbHCCId.Text = id;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00046A5D File Offset: 0x00044C5D
		public string getReport()
		{
			return this.tbReport.Text.Trim();
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00046A6F File Offset: 0x00044C6F
		public string getRequestTime()
		{
			return this.tbRequestTime.Text.Trim();
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00046A81 File Offset: 0x00044C81
		public string getCategory()
		{
			return this.cbCategory.SelectedItem.ToString().Trim().ToUpper();
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00046A9D File Offset: 0x00044C9D
		public string getMachine()
		{
			return this.tbMC.Text.Trim().ToUpper();
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00046AB4 File Offset: 0x00044CB4
		public string getModel()
		{
			return this.tbModel.Text.Trim().ToUpper();
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00046ACB File Offset: 0x00044CCB
		public string getHCCId()
		{
			return this.tbHCCId.Text.Trim().ToUpper();
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00046AE2 File Offset: 0x00044CE2
		public string getRscDec()
		{
			return this.tbRsc.Text.Trim().ToUpper();
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00046AF9 File Offset: 0x00044CF9
		public string getContent()
		{
			return this.combo_Content.SelectedItem.ToString().Trim();
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00046B10 File Offset: 0x00044D10
		public string getFactory()
		{
			return this.cbPlant.SelectedItem.ToString().Trim();
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00046B27 File Offset: 0x00044D27
		public int getCategoryIndex()
		{
			return this.cbCategory.SelectedIndex;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00046B34 File Offset: 0x00044D34
		public int getContentIndex()
		{
			return this.combo_Content.SelectedIndex;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00046B41 File Offset: 0x00044D41
		public int getFactoryIndex()
		{
			return this.cbPlant.SelectedIndex;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00046B4E File Offset: 0x00044D4E
		public bool existCategory()
		{
			return this.cbCategory.SelectedItem == null;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00046B61 File Offset: 0x00044D61
		public int isEmergency()
		{
			return this.cbEmergency.Checked ? 1 : 0;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00046B74 File Offset: 0x00044D74
		public ReportInformation(FactorySettings factorySettings, HCC hCC)
		{
			this._factory = factorySettings._factoryName;
			this._queryMgr = new QueryMgr(factorySettings);
			this._hCC = hCC;
			this._factorySettings = factorySettings;
			this.InitializeComponent();
			base.Tag = MainPageType.Maintenance;
			cFunction.setPlant(this.cbPlant, this._factory);
			this.cbPlant.SelectedIndex = 0;
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00046C00 File Offset: 0x00044E00
		public void autoSelectFactory()
		{
			bool flag = this._rui.getTeam().IndexOf("K3") != -1;
			if (flag)
			{
				this.cbPlant.SelectedIndex = 0;
			}
			else
			{
				bool flag2 = this._rui.getTeam().IndexOf("K5") != -1;
				if (flag2)
				{
					bool flag3 = this._factory == "ATK_K5_M";
					if (flag3)
					{
						this.cbPlant.SelectedIndex = 0;
					}
					else
					{
						this.cbPlant.SelectedIndex = 1;
					}
				}
				else
				{
					this.cbPlant.SelectedIndex = 0;
				}
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00046CA0 File Offset: 0x00044EA0
		public void clear()
		{
			this.cbCategory.SelectedIndex = -1;
			this.tbMC.Text = string.Empty;
			this.tbModel.Text = string.Empty;
			this.tbRsc.Text = string.Empty;
			this.combo_Content.SelectedIndex = -1;
			this.tbReport.Text = string.Empty;
			this.tbRequestTime.Text = string.Empty;
			this.tbHCCId.Text = string.Empty;
			bool flag = this._hi != null;
			if (flag)
			{
				this._hi.Parent.Visible = false;
			}
			this.tbMC.Enabled = true;
			this.panel_other.Visible = false;
			this.pnMC.Visible = true;
			this.pnModel.Visible = true;
			this.pnRsc.Visible = true;
			this.cbEmergency.Checked = false;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00046D9C File Offset: 0x00044F9C
		public string setReport()
		{
			this._RequestTime = DateTime.Now;
			string empty = string.Empty;
			bool flag = this.cbPlant.SelectedItem.ToString() == "ATV" || this.cbPlant.SelectedIndex == -1;
			if (flag)
			{
				this.tbReport.Text = "ATV_" + this._RequestTime.ToString("yyyyMMdd");
			}
			this.tbRequestTime.Text = this._RequestTime.ToString("yyyy-MM-dd HH:mm");
			return this.tbReport.Text.Trim();
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00046E44 File Offset: 0x00045044
		public void setReportFormat(int ReportNumber)
		{
			bool flag = this.cbCategory.SelectedItem.ToString().Trim().ToUpper() == "OTHER";
			if (flag)
			{
				this.tbReport.Text = string.Concat(new string[]
				{
					this.tbReport.Text,
					"_",
					this.tbMC.Text.Trim(),
					"_",
					this._rui.getTeam(),
					"_",
					string.Format("{0:D3}", ReportNumber)
				});
			}
			else
			{
				bool flag2 = this._hCC.Equals(this.cbCategory.SelectedItem.ToString());
				if (flag2)
				{
					bool flag3 = this.combo_Content.SelectedItem != null && this.combo_Content.SelectedItem.ToString() == this._hCC.hCCContent.Etc;
					if (flag3)
					{
						this.tbReport.Text = string.Concat(new string[]
						{
							this.tbReport.Text,
							"_",
							this.tbModel.Text.Trim(),
							"_",
							this._rui.getTeam(),
							"_",
							string.Format("{0:D3}", ReportNumber)
						});
					}
					else
					{
						this.tbReport.Text = string.Concat(new string[]
						{
							this.tbReport.Text,
							"_",
							this._hi.getLocation(),
							"_",
							this.tbModel.Text.Trim(),
							"_",
							this._rui.getTeam(),
							"_",
							string.Format("{0:D3}", ReportNumber)
						});
					}
				}
				else
				{
					this.tbReport.Text = string.Concat(new string[]
					{
						this.tbReport.Text,
						"_",
						this.tbMC.Text.Trim(),
						"_",
						this.tbModel.Text.Trim(),
						"_",
						this._rui.getTeam(),
						"_",
						string.Format("{0:D3}", ReportNumber)
					});
				}
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000470E5 File Offset: 0x000452E5
		public void setRequestTime(string time)
		{
			this.tbRequestTime.Text = time;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000470F4 File Offset: 0x000452F4
		private void cbPlant_SelectedValueChanged(object sender, EventArgs e)
		{
			cFunction.getCategoryList(this._factorySettings, this.cbPlant.SelectedItem.ToString(), this.cbCategory, false, false);
			this.cbCategory.SelectedIndex = -1;
			this.tbMC.Text = string.Empty;
			this.subItemClear();
			bool visible = this.panel_other.Visible;
			if (visible)
			{
				this.panel_other.Visible = false;
				this.combo_Content.SelectedIndex = -1;
				this.tbMC.Enabled = true;
				this.pnMC.Visible = true;
				this.pnModel.Visible = true;
				this.pnRsc.Visible = true;
			}
			bool flag = this._hi != null;
			if (flag)
			{
				this._hi.Visible = false;
			}
			bool flag2 = this._rui != null;
			if (flag2)
			{
				this._rui.clear();
				this._rui.setFactory(this.cbPlant.SelectedItem.ToString());
			}
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000471FC File Offset: 0x000453FC
		private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this._hi != null;
			if (flag)
			{
				this._hi.Visible = false;
			}
			bool flag2 = this.cbPlant.SelectedIndex == -1 || this.cbCategory.SelectedIndex == -1 || this.cbCategory.SelectedItem == null;
			if (!flag2)
			{
				bool flag3 = this._rbi != null;
				if (flag3)
				{
					this._rbi.Visible = false;
					this._rbi.visibleBoardInfo(false);
				}
				this.subItemClear();
				this.panel_other.Visible = false;
				bool flag4 = this.cbCategory.SelectedItem.ToString().Trim().ToUpper() == "OTHER" || this._hCC.Equals(this.cbCategory.SelectedItem.ToString());
				if (flag4)
				{
					this.panel_other.Visible = true;
					this.combo_Content.SelectedIndex = -1;
					this.tbMC.Enabled = false;
					bool visible = this.pnMC.Visible;
					if (visible)
					{
						this.pnMC.Visible = false;
						this.pnModel.Visible = false;
						this.pnRsc.Visible = false;
					}
					this.getMachineNumber(true);
				}
				else
				{
					this.combo_Content.SelectedIndex = -1;
					bool flag5 = !this.pnMC.Visible;
					if (flag5)
					{
						this.tbMC.Enabled = true;
						this.pnMC.Visible = true;
						this.pnModel.Visible = true;
						this.pnRsc.Visible = true;
					}
					this.getMachineNumber(false);
				}
				bool flag6 = this._rui != null;
				if (flag6)
				{
					this._rui.setCategory(this.cbCategory.SelectedItem.ToString().Trim());
					this._rui.getToGroupList();
					this._rui.getCCMailList();
				}
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000473F8 File Offset: 0x000455F8
		private void subItemClear()
		{
			this.tbMC.Text = "";
			this.tbModel.Text = "";
			this.tbRsc.Text = "";
			this.combo_Content.SelectedIndex = -1;
			this.cbEmergency.Checked = false;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00047454 File Offset: 0x00045654
		private void getMachineNumber(bool otherType)
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMachineList] @_Plant = '",
				this.cbPlant.SelectedItem.ToString(),
				"', @SearchType = '",
				this.cbCategory.SelectedItem.ToString(),
				"'"
			});
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				int num = 0;
				string text = "";
				string[] array = new string[dataSet.Tables[0].Rows.Count];
				string[] array2 = new string[dataSet.Tables[0].Rows.Count];
				AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
				AutoCompleteStringCollection autoCompleteStringCollection2 = new AutoCompleteStringCollection();
				this._MachineModelList.Clear();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text2 = dataSet.Tables[0].Rows[i]["Model"].ToString();
					string text3 = string.Empty;
					string sSelectRsc = string.Empty;
					bool flag2 = this.cbCategory.SelectedItem.ToString().CompareTo("EOL") == 0 || this.cbCategory.SelectedItem.ToString().CompareTo("STACK") == 0;
					if (flag2)
					{
						sSelectRsc = dataSet.Tables[0].Rows[i]["Rsc"].ToString();
						text3 = dataSet.Tables[0].Rows[i]["Plant"].ToString();
					}
					array[i] = dataSet.Tables[0].Rows[i]["Name"].ToString();
					MachineInfo machineInfo = new MachineInfo();
					machineInfo.sSelectMachine = array[i];
					machineInfo.sSelectModel = text2;
					machineInfo.sSelectRsc = sSelectRsc;
					this._MachineModelList.Add(machineInfo);
					bool flag3 = text.CompareTo(text2) != 0;
					if (flag3)
					{
						array2[i] = text2;
						text = text2;
						num++;
					}
				}
				string[] array3 = new string[num];
				int num2 = 0;
				for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
				{
					bool flag4 = array2[j] != null;
					if (flag4)
					{
						array3[num2++] = array2[j];
					}
				}
				autoCompleteStringCollection.AddRange(array);
				autoCompleteStringCollection2.AddRange(array3);
				this.tbModel.AutoCompleteCustomSource = autoCompleteStringCollection2;
				this.tbModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				this.tbModel.AutoCompleteSource = AutoCompleteSource.CustomSource;
				this.tbMC.AutoCompleteCustomSource = autoCompleteStringCollection;
				this.tbMC.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				this.tbMC.AutoCompleteSource = AutoCompleteSource.CustomSource;
				if (otherType)
				{
					this.combo_Content.Items.Clear();
					for (int k = 0; k < array.Length; k++)
					{
						this.combo_Content.Items.Add(array[k]);
					}
				}
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x000477C0 File Offset: 0x000459C0
		private void lbMC_TextChanged(object sender, EventArgs e)
		{
			this.tbModel.Text = "";
			this.tbRsc.Text = "";
			bool flag = this.cbCategory.SelectedItem == null || this.cbCategory.SelectedIndex == -1;
			if (!flag)
			{
				bool flag2 = this.cbCategory.SelectedItem.ToString().CompareTo("EOL") == 0 || this.cbCategory.SelectedItem.ToString().CompareTo("STACK") == 0;
				if (flag2)
				{
					for (int i = 0; i < this._MachineModelList.Count; i++)
					{
						string text = this._MachineModelList[i].sSelectMachine.ToUpper();
						bool flag3 = text.CompareTo(this.tbMC.Text) == 0;
						if (flag3)
						{
							this.tbModel.Text = this._MachineModelList[i].sSelectModel;
							this.tbRsc.Text = this._MachineModelList[i].sSelectRsc;
						}
					}
				}
				else
				{
					for (int j = 0; j < this._MachineModelList.Count; j++)
					{
						string text2 = this._MachineModelList[j].sSelectMachine.ToUpper();
						bool flag4 = text2.CompareTo(this.tbMC.Text) == 0;
						if (flag4)
						{
							this.tbModel.Text = this._MachineModelList[j].sSelectModel;
						}
					}
				}
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00047964 File Offset: 0x00045B64
		private void combo_Content_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.combo_Content.SelectedIndex != -1 && (this.cbPlant.SelectedItem.ToString().Trim() == "K3" || this.cbPlant.SelectedItem.ToString().Trim() == "K3_E") && !this._hCC.Equals(this.cbCategory.SelectedItem.ToString());
			if (!flag)
			{
				bool flag2 = this.combo_Content.SelectedIndex == -1;
				if (flag2)
				{
					bool flag3 = this._hi != null;
					if (flag3)
					{
						this._hi.initHCCContents(false);
					}
				}
				else
				{
					this.setContenttoMachine();
					this._rbi.clear();
					this._hi.getHCCLocationList(this);
					this._rbi.Visible = true;
					this.tbHCCId.Text = string.Empty;
					this._hi.Parent.Visible = true;
					this._hi.initHCCContents(true);
					bool flag4 = this.combo_Content.SelectedItem.ToString().Trim() == this._hCC.hCCContent.Board;
					if (flag4)
					{
						this._hi.setBoardNo(true);
					}
					else
					{
						this._hi.setBoardNo(false);
					}
					bool flag5 = this.cbPlant.SelectedItem.ToString().Trim() == "K3" || this.cbPlant.SelectedItem.ToString().Trim() == "K3_E" || this.cbPlant.SelectedItem.ToString().Trim() == "ATV";
					if (flag5)
					{
						bool flag6 = this.combo_Content.SelectedItem.ToString().Trim() == this._hCC.hCCContent.Etc;
						if (flag6)
						{
							this._rbi.setETCMode();
							this._hi.Visible = false;
							this._hi.clear();
						}
						else
						{
							this._hi.Visible = true;
							this._rbi.rbHwCheck.Checked = true;
							this._hi.setK3Board();
							bool flag7 = this.combo_Content.SelectedItem.ToString().Trim() == this._hCC.hCCContent.Board;
							if (flag7)
							{
								this._rbi.visibleBoardInfo(true);
							}
							else
							{
								this._rbi.visibleBoardInfo(false);
							}
						}
					}
					else
					{
						this._hi.Visible = true;
					}
				}
			}
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00047C1C File Offset: 0x00045E1C
		public void setContenttoMachine()
		{
			this.tbMC.Text = this.combo_Content.SelectedItem.ToString().Trim().ToUpper();
			this.tbModel.Text = this.combo_Content.SelectedItem.ToString().Trim().ToUpper();
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00047C76 File Offset: 0x00045E76
		public void setHcctoMachine(string location)
		{
			this.tbMC.Text = location;
			this.tbModel.Text = this.combo_Content.SelectedItem.ToString().Trim();
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00047CA8 File Offset: 0x00045EA8
		private void lbMC_MouseLeave(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(this.tbMC.Text.Trim().ToUpper()) || this.cbCategory.SelectedIndex == -1 || this.cbPlant.SelectedIndex == -1;
			if (!flag)
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintCheckStatus] @_Plant=N'",
					this.cbPlant.SelectedItem.ToString().Trim(),
					"', @_Category=N'",
					this.cbCategory.SelectedItem.ToString().Trim().ToUpper(),
					"',@_Machine=N'",
					this.tbMC.Text.Trim().ToUpper(),
					"',@_Model=N'",
					this.tbModel.Text.Trim().ToUpper(),
					"'"
				});
				DataSet dataSet = this._queryMgr.queryCall(sQuery);
				bool flag2 = dataSet != null && dataSet.Tables.Count > 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables.Count >= 1 && dataSet.Tables[0].Rows.Count != 0;
					if (flag3)
					{
						MessageBox.Show(MessageLanguage.getMessage("check_request_status"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					bool flag4 = dataSet.Tables.Count == 2 && dataSet.Tables[1].Rows.Count != 0;
					if (flag4)
					{
						MessageBox.Show(MessageLanguage.getMessage("check_pm_request_status"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00047E5C File Offset: 0x0004605C
		private void cbEmergency_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.cbEmergency.Checked;
			if (@checked)
			{
				Emergency emergency = new Emergency();
				emergency.ShowDialog();
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00047E88 File Offset: 0x00046088
		private void cbEmergency_Paint(object sender, PaintEventArgs e)
		{
			base.OnPaint(e);
			int num = this.cbEmergency.Parent.Height - 20;
			Rectangle rectangle = new Rectangle(new Point(0, 1), new Size(num, num));
			ControlPaint.DrawCheckBox(e.Graphics, rectangle, this.cbEmergency.Checked ? ButtonState.Checked : ButtonState.Normal);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00047EEC File Offset: 0x000460EC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00047F24 File Offset: 0x00046124
		private void InitializeComponent()
		{
			this.panel2 = new Panel();
			this.tbReport = new TextBox();
			this.label1 = new Label();
			this.tbRequestTime = new TextBox();
			this.label13 = new Label();
			this.groupBox1 = new GroupBox();
			this.pnEmergencyParent = new Panel();
			this.cbEmergency = new CheckBox();
			this.panel1 = new Panel();
			this.tbHCCId = new TextBox();
			this.panel20 = new Panel();
			this.cbCase = new ComboBox();
			this.label6 = new Label();
			this.pnRsc = new Panel();
			this.tbRsc = new TextBox();
			this.label8 = new Label();
			this.pnModel = new Panel();
			this.tbModel = new TextBox();
			this.label9 = new Label();
			this.panel_other = new Panel();
			this.combo_Content = new ComboBox();
			this.label16 = new Label();
			this.pnMC = new Panel();
			this.tbMC = new TextBox();
			this.label5 = new Label();
			this.panel7 = new Panel();
			this.cbCategory = new ComboBox();
			this.label4 = new Label();
			this.panel9 = new Panel();
			this.cbPlant = new ComboBox();
			this.label18 = new Label();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.pnEmergencyParent.SuspendLayout();
			this.panel20.SuspendLayout();
			this.pnRsc.SuspendLayout();
			this.pnModel.SuspendLayout();
			this.panel_other.SuspendLayout();
			this.pnMC.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel9.SuspendLayout();
			base.SuspendLayout();
			this.panel2.Controls.Add(this.tbReport);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.tbRequestTime);
			this.panel2.Controls.Add(this.label13);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(1457, 23);
			this.panel2.TabIndex = 42;
			this.tbReport.BackColor = Color.Gainsboro;
			this.tbReport.Dock = DockStyle.Left;
			this.tbReport.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbReport.Location = new Point(367, 0);
			this.tbReport.Name = "tbReport";
			this.tbReport.ReadOnly = true;
			this.tbReport.Size = new Size(466, 23);
			this.tbReport.TabIndex = 32;
			this.label1.Dock = DockStyle.Left;
			this.label1.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label1.Location = new Point(280, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(87, 23);
			this.label1.TabIndex = 39;
			this.label1.Text = "Request Time";
			this.label1.TextAlign = ContentAlignment.TopCenter;
			this.tbRequestTime.BackColor = Color.Gainsboro;
			this.tbRequestTime.Dock = DockStyle.Left;
			this.tbRequestTime.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbRequestTime.Location = new Point(60, 0);
			this.tbRequestTime.Name = "tbRequestTime";
			this.tbRequestTime.ReadOnly = true;
			this.tbRequestTime.Size = new Size(220, 23);
			this.tbRequestTime.TabIndex = 38;
			this.label13.Dock = DockStyle.Left;
			this.label13.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label13.Location = new Point(0, 0);
			this.label13.Name = "label13";
			this.label13.Size = new Size(60, 23);
			this.label13.TabIndex = 31;
			this.label13.Text = "Report #";
			this.label13.TextAlign = ContentAlignment.TopCenter;
			this.groupBox1.Controls.Add(this.pnEmergencyParent);
			this.groupBox1.Controls.Add(this.tbHCCId);
			this.groupBox1.Controls.Add(this.panel20);
			this.groupBox1.Controls.Add(this.pnRsc);
			this.groupBox1.Controls.Add(this.pnModel);
			this.groupBox1.Controls.Add(this.panel_other);
			this.groupBox1.Controls.Add(this.pnMC);
			this.groupBox1.Controls.Add(this.panel7);
			this.groupBox1.Controls.Add(this.panel9);
			this.groupBox1.Dock = DockStyle.Top;
			this.groupBox1.Location = new Point(0, 23);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new Padding(3, 0, 0, 2);
			this.groupBox1.Size = new Size(1457, 60);
			this.groupBox1.TabIndex = 71;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Index";
			this.pnEmergencyParent.Controls.Add(this.cbEmergency);
			this.pnEmergencyParent.Controls.Add(this.panel1);
			this.pnEmergencyParent.Dock = DockStyle.Left;
			this.pnEmergencyParent.Location = new Point(1331, 14);
			this.pnEmergencyParent.Name = "pnEmergencyParent";
			this.pnEmergencyParent.Padding = new Padding(1, 1, 3, 1);
			this.pnEmergencyParent.Size = new Size(122, 44);
			this.pnEmergencyParent.TabIndex = 98;
			this.cbEmergency.Dock = DockStyle.Fill;
			this.cbEmergency.Location = new Point(1, 17);
			this.cbEmergency.Name = "cbEmergency";
			this.cbEmergency.Size = new Size(118, 26);
			this.cbEmergency.TabIndex = 0;
			this.cbEmergency.Text = "Emergency";
			this.cbEmergency.TextAlign = ContentAlignment.MiddleCenter;
			this.cbEmergency.UseVisualStyleBackColor = true;
			this.cbEmergency.CheckedChanged += this.cbEmergency_CheckedChanged;
			this.cbEmergency.Paint += this.cbEmergency_Paint;
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(1, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(118, 16);
			this.panel1.TabIndex = 1;
			this.tbHCCId.BackColor = Color.Gainsboro;
			this.tbHCCId.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCId.Location = new Point(2400, 38);
			this.tbHCCId.Name = "tbHCCId";
			this.tbHCCId.ReadOnly = true;
			this.tbHCCId.Size = new Size(49, 23);
			this.tbHCCId.TabIndex = 97;
			this.tbHCCId.Visible = false;
			this.panel20.Controls.Add(this.cbCase);
			this.panel20.Controls.Add(this.label6);
			this.panel20.Dock = DockStyle.Left;
			this.panel20.Location = new Point(1143, 14);
			this.panel20.Name = "panel20";
			this.panel20.Padding = new Padding(0, 0, 3, 0);
			this.panel20.Size = new Size(188, 44);
			this.panel20.TabIndex = 82;
			this.panel20.Visible = false;
			this.cbCase.Dock = DockStyle.Fill;
			this.cbCase.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbCase.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbCase.FormattingEnabled = true;
			this.cbCase.Items.AddRange(new object[]
			{
				"HARDWARE",
				"SOFTWARE",
				"OTHER"
			});
			this.cbCase.Location = new Point(0, 17);
			this.cbCase.Name = "cbCase";
			this.cbCase.Size = new Size(185, 23);
			this.cbCase.TabIndex = 10;
			this.cbCase.Visible = false;
			this.label6.Dock = DockStyle.Top;
			this.label6.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label6.Location = new Point(0, 0);
			this.label6.Name = "label6";
			this.label6.Size = new Size(185, 17);
			this.label6.TabIndex = 9;
			this.label6.Text = "Case";
			this.label6.Visible = false;
			this.pnRsc.Controls.Add(this.tbRsc);
			this.pnRsc.Controls.Add(this.label8);
			this.pnRsc.Dock = DockStyle.Left;
			this.pnRsc.Location = new Point(959, 14);
			this.pnRsc.Name = "pnRsc";
			this.pnRsc.Padding = new Padding(0, 0, 3, 0);
			this.pnRsc.Size = new Size(184, 44);
			this.pnRsc.TabIndex = 81;
			this.tbRsc.BackColor = Color.Gainsboro;
			this.tbRsc.Dock = DockStyle.Fill;
			this.tbRsc.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbRsc.Location = new Point(0, 17);
			this.tbRsc.Name = "tbRsc";
			this.tbRsc.ReadOnly = true;
			this.tbRsc.Size = new Size(181, 23);
			this.tbRsc.TabIndex = 67;
			this.label8.Dock = DockStyle.Top;
			this.label8.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label8.Location = new Point(0, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(181, 17);
			this.label8.TabIndex = 13;
			this.label8.Text = "Rsc Dec";
			this.pnModel.Controls.Add(this.tbModel);
			this.pnModel.Controls.Add(this.label9);
			this.pnModel.Dock = DockStyle.Left;
			this.pnModel.Location = new Point(747, 14);
			this.pnModel.Name = "pnModel";
			this.pnModel.Padding = new Padding(0, 0, 3, 0);
			this.pnModel.Size = new Size(212, 44);
			this.pnModel.TabIndex = 80;
			this.tbModel.BackColor = Color.Gainsboro;
			this.tbModel.Dock = DockStyle.Fill;
			this.tbModel.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbModel.Location = new Point(0, 17);
			this.tbModel.Name = "tbModel";
			this.tbModel.ReadOnly = true;
			this.tbModel.Size = new Size(209, 23);
			this.tbModel.TabIndex = 16;
			this.label9.Dock = DockStyle.Top;
			this.label9.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label9.Location = new Point(0, 0);
			this.label9.Name = "label9";
			this.label9.Size = new Size(209, 17);
			this.label9.TabIndex = 15;
			this.label9.Text = "Model";
			this.panel_other.Controls.Add(this.combo_Content);
			this.panel_other.Controls.Add(this.label16);
			this.panel_other.Dock = DockStyle.Left;
			this.panel_other.Location = new Point(433, 14);
			this.panel_other.Name = "panel_other";
			this.panel_other.Size = new Size(314, 44);
			this.panel_other.TabIndex = 77;
			this.panel_other.Visible = false;
			this.combo_Content.Dock = DockStyle.Fill;
			this.combo_Content.DropDownStyle = ComboBoxStyle.DropDownList;
			this.combo_Content.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.combo_Content.Items.AddRange(new object[]
			{
				"HANDLER",
				"TESTER",
				"EOL",
				"STACK",
				"WAFER",
				"OTHER"
			});
			this.combo_Content.Location = new Point(0, 17);
			this.combo_Content.Name = "combo_Content";
			this.combo_Content.Size = new Size(314, 23);
			this.combo_Content.TabIndex = 7;
			this.combo_Content.SelectedIndexChanged += this.combo_Content_SelectedIndexChanged;
			this.label16.Dock = DockStyle.Top;
			this.label16.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label16.Location = new Point(0, 0);
			this.label16.Name = "label16";
			this.label16.Size = new Size(314, 17);
			this.label16.TabIndex = 8;
			this.label16.Text = "Contents";
			this.pnMC.Controls.Add(this.tbMC);
			this.pnMC.Controls.Add(this.label5);
			this.pnMC.Dock = DockStyle.Left;
			this.pnMC.Location = new Point(239, 14);
			this.pnMC.Name = "pnMC";
			this.pnMC.Padding = new Padding(0, 0, 3, 0);
			this.pnMC.Size = new Size(194, 44);
			this.pnMC.TabIndex = 88;
			this.tbMC.CharacterCasing = CharacterCasing.Upper;
			this.tbMC.Dock = DockStyle.Fill;
			this.tbMC.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbMC.Location = new Point(0, 17);
			this.tbMC.Name = "tbMC";
			this.tbMC.Size = new Size(191, 23);
			this.tbMC.TabIndex = 8;
			this.tbMC.TextChanged += this.lbMC_TextChanged;
			this.tbMC.MouseLeave += this.lbMC_MouseLeave;
			this.label5.Dock = DockStyle.Top;
			this.label5.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label5.Location = new Point(0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(191, 17);
			this.label5.TabIndex = 7;
			this.label5.Text = "M/C #";
			this.panel7.Controls.Add(this.cbCategory);
			this.panel7.Controls.Add(this.label4);
			this.panel7.Dock = DockStyle.Left;
			this.panel7.Location = new Point(77, 14);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new Padding(3, 0, 3, 0);
			this.panel7.Size = new Size(162, 44);
			this.panel7.TabIndex = 78;
			this.cbCategory.Dock = DockStyle.Fill;
			this.cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbCategory.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbCategory.Location = new Point(3, 17);
			this.cbCategory.Name = "cbCategory";
			this.cbCategory.Size = new Size(156, 23);
			this.cbCategory.TabIndex = 6;
			this.cbCategory.SelectedIndexChanged += this.cbCategory_SelectedIndexChanged;
			this.label4.Dock = DockStyle.Top;
			this.label4.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label4.Location = new Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(156, 17);
			this.label4.TabIndex = 5;
			this.label4.Text = "Category";
			this.panel9.Controls.Add(this.cbPlant);
			this.panel9.Controls.Add(this.label18);
			this.panel9.Dock = DockStyle.Left;
			this.panel9.Location = new Point(3, 14);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new Padding(3, 0, 3, 0);
			this.panel9.Size = new Size(74, 44);
			this.panel9.TabIndex = 83;
			this.cbPlant.Dock = DockStyle.Fill;
			this.cbPlant.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbPlant.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbPlant.Location = new Point(3, 17);
			this.cbPlant.Name = "cbPlant";
			this.cbPlant.Size = new Size(68, 23);
			this.cbPlant.TabIndex = 6;
			this.cbPlant.SelectedValueChanged += this.cbPlant_SelectedValueChanged;
			this.label18.Dock = DockStyle.Top;
			this.label18.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label18.Location = new Point(3, 0);
			this.label18.Name = "label18";
			this.label18.Size = new Size(68, 17);
			this.label18.TabIndex = 5;
			this.label18.Text = "Factory";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.panel2);
			base.Name = "ReportInformation";
			base.Padding = new Padding(0, 0, 0, 3);
			base.Size = new Size(1457, 83);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.pnEmergencyParent.ResumeLayout(false);
			this.panel20.ResumeLayout(false);
			this.pnRsc.ResumeLayout(false);
			this.pnRsc.PerformLayout();
			this.pnModel.ResumeLayout(false);
			this.pnModel.PerformLayout();
			this.panel_other.ResumeLayout(false);
			this.pnMC.ResumeLayout(false);
			this.pnMC.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400034D RID: 845
		private readonly QueryMgr _queryMgr;

		// Token: 0x0400034E RID: 846
		private List<MachineInfo> _MachineModelList = new List<MachineInfo>();

		// Token: 0x0400034F RID: 847
		private DateTime _RequestTime;

		// Token: 0x04000350 RID: 848
		public ReportBoardInformation _rbi;

		// Token: 0x04000351 RID: 849
		public ReportUserInformation _rui;

		// Token: 0x04000352 RID: 850
		public HCCInformation _hi;

		// Token: 0x04000354 RID: 852
		private readonly string _factory = string.Empty;

		// Token: 0x04000355 RID: 853
		private FactorySettings _factorySettings;

		// Token: 0x04000356 RID: 854
		private IContainer components = null;

		// Token: 0x04000357 RID: 855
		private Panel panel2;

		// Token: 0x04000358 RID: 856
		private TextBox tbReport;

		// Token: 0x04000359 RID: 857
		private TextBox tbRequestTime;

		// Token: 0x0400035A RID: 858
		private Label label1;

		// Token: 0x0400035B RID: 859
		private Label label13;

		// Token: 0x0400035C RID: 860
		private GroupBox groupBox1;

		// Token: 0x0400035D RID: 861
		private Panel pnEmergencyParent;

		// Token: 0x0400035E RID: 862
		private TextBox tbHCCId;

		// Token: 0x0400035F RID: 863
		private Panel panel20;

		// Token: 0x04000360 RID: 864
		private ComboBox cbCase;

		// Token: 0x04000361 RID: 865
		private Label label6;

		// Token: 0x04000362 RID: 866
		private Panel pnRsc;

		// Token: 0x04000363 RID: 867
		private TextBox tbRsc;

		// Token: 0x04000364 RID: 868
		private Label label8;

		// Token: 0x04000365 RID: 869
		private Panel pnModel;

		// Token: 0x04000366 RID: 870
		private TextBox tbModel;

		// Token: 0x04000367 RID: 871
		private Label label9;

		// Token: 0x04000368 RID: 872
		private Panel panel_other;

		// Token: 0x04000369 RID: 873
		private ComboBox combo_Content;

		// Token: 0x0400036A RID: 874
		private Label label16;

		// Token: 0x0400036B RID: 875
		private Panel pnMC;

		// Token: 0x0400036C RID: 876
		private TextBox tbMC;

		// Token: 0x0400036D RID: 877
		private Label label5;

		// Token: 0x0400036E RID: 878
		private Panel panel7;

		// Token: 0x0400036F RID: 879
		private ComboBox cbCategory;

		// Token: 0x04000370 RID: 880
		private Label label4;

		// Token: 0x04000371 RID: 881
		private Panel panel9;

		// Token: 0x04000372 RID: 882
		private ComboBox cbPlant;

		// Token: 0x04000373 RID: 883
		private Label label18;

		// Token: 0x04000374 RID: 884
		private CheckBox cbEmergency;

		// Token: 0x04000375 RID: 885
		private Panel panel1;
	}
}
