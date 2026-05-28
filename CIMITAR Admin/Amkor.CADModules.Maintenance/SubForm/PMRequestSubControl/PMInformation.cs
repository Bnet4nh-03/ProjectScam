using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.PMRequestSubControl
{
	// Token: 0x0200001B RID: 27
	public class PMInformation : UserControl
	{
		// Token: 0x060001F4 RID: 500 RVA: 0x0004C6D8 File Offset: 0x0004A8D8
		public string getFactory()
		{
			return this.cbPlant.SelectedItem.ToString().Trim();
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0004C6EF File Offset: 0x0004A8EF
		public string getMachine()
		{
			return this.tbMC.Text.Trim();
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0004C701 File Offset: 0x0004A901
		public string getModel()
		{
			return this.tbModel.Text.Trim();
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0004C713 File Offset: 0x0004A913
		public string getEstimatedTime()
		{
			return this.tbEstimatedTime.Text.Trim();
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0004C725 File Offset: 0x0004A925
		public string getWorkType()
		{
			return this.comboWorkType.SelectedItem.ToString().ToUpper().Trim();
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0004C741 File Offset: 0x0004A941
		public string getCategory()
		{
			return this.cbCategory.SelectedItem.ToString().ToUpper().Trim();
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0004C75D File Offset: 0x0004A95D
		public string getRscDec()
		{
			return this.tbRsc.Text.Trim();
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0004C770 File Offset: 0x0004A970
		public string getPlanDate()
		{
			return this.dtPlanedDate.Value.ToString("yyyy-MM-dd HH:mm");
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0004C795 File Offset: 0x0004A995
		public string getAsset()
		{
			return this.tbAsset.Text.Trim();
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0004C7A7 File Offset: 0x0004A9A7
		public bool checkPMDown()
		{
			return this.cbPMDownTime.Checked;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0004C7B4 File Offset: 0x0004A9B4
		public int getFactoryIndex()
		{
			return this.cbPlant.SelectedIndex;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0004C7C4 File Offset: 0x0004A9C4
		public PMInformation(FactorySettings factorySetting, PMUserInformation pui)
		{
			this._factorySetting = factorySetting;
			this._pui = pui;
			this._queryMgr = new QueryMgr(factorySetting);
			this.InitializeComponent();
			ComboBox.ObjectCollection items = this.comboWorkType.Items;
			object[] sWorkType = cConst.sWorkType;
			items.AddRange(sWorkType);
			this.dtPlanedDate.Value = DateTime.Now;
			base.Tag = MainPageType.PreventMaintenance;
			cFunction.setPlant(this.cbPlant, this._factorySetting._factoryName);
			this.cbPlant.SelectedIndex = 0;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0004C868 File Offset: 0x0004AA68
		public void clear()
		{
			this.tbAsset.Text = string.Empty;
			this.tbModel.Text = string.Empty;
			this.tbRsc.Text = string.Empty;
			this.tbMC.Text = string.Empty;
			this.cbCategory.SelectedIndex = -1;
			this.tbMC.Text = string.Empty;
			this.tbModel.Text = string.Empty;
			this.tbRsc.Text = string.Empty;
			this.tbAsset.Text = string.Empty;
			this.tbEstimatedTime.Text = string.Empty;
			this.dtPlanedDate.Value = DateTime.Now;
			this.comboWorkType.SelectedIndex = -1;
			this.cbPMDownTime.Checked = false;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0004C948 File Offset: 0x0004AB48
		private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.cbPlant.SelectedIndex == -1 || this.cbCategory.SelectedIndex == -1 || this.cbCategory.SelectedItem == null;
			if (!flag)
			{
				this.comboWorkType.SelectedIndex = -1;
				this.tbAsset.Text = string.Empty;
				this.tbModel.Text = string.Empty;
				this.tbRsc.Text = string.Empty;
				this.tbMC.Text = string.Empty;
				this.tbEstimatedTime.Text = string.Empty;
				this.dtPlanedDate.Value = DateTime.Now;
				this.getMachineNumber(false);
				this._pui.getToGroupList();
				this._pui.getCCMailList();
				bool flag2 = this.cbCategory.SelectedItem.ToString().ToUpper() == "HCC";
				if (flag2)
				{
					this.lbMC.Text = "Location";
					this.pnHCCInformation.Visible = true;
					this.pnModel.Visible = false;
					this.pnRsc.Visible = false;
				}
				else
				{
					this.lbMC.Text = "M/C #";
					this.pnHCCInformation.Visible = false;
					this.pnModel.Visible = true;
					this.pnRsc.Visible = true;
				}
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0004CAB8 File Offset: 0x0004ACB8
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
				string text = string.Empty;
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
			}
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0004CDD8 File Offset: 0x0004AFD8
		private void tbMC_TextChanged(object sender, EventArgs e)
		{
			this.tbModel.Text = string.Empty;
			this.tbRsc.Text = string.Empty;
			this.tbAsset.Text = string.Empty;
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
							break;
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
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0004CF90 File Offset: 0x0004B190
		public bool isCategoryNull()
		{
			return this.cbCategory.SelectedItem == null;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0004CFBC File Offset: 0x0004B1BC
		public bool checkPlanDate()
		{
			DateTime now = DateTime.Now;
			return now > this.dtPlanedDate.Value;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0004CFF0 File Offset: 0x0004B1F0
		public bool isWorkTypeNULL()
		{
			return this.comboWorkType.SelectedItem == null;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0004D01C File Offset: 0x0004B21C
		private void tbEstimatedTime_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b' || e.KeyChar == '.';
			if (flag)
			{
				e.KeyChar = e.KeyChar;
			}
			else
			{
				e.KeyChar = '\0';
			}
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0004D070 File Offset: 0x0004B270
		private void tbMC_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = this.cbCategory.SelectedItem.ToString() == "HCC";
			if (flag)
			{
				bool flag2 = e.KeyValue == 13;
				if (flag2)
				{
					HCCParameter hccparameter = null;
					cFunction.getHCCInfo(this._factorySetting, this.getFactory(), this.combo_Content.SelectedItem.ToString(), this.tbMC.Text.Trim(), out hccparameter);
				}
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0004D0E4 File Offset: 0x0004B2E4
		private void cbPlant_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboWorkType.SelectedIndex = -1;
			this.tbAsset.Text = string.Empty;
			this.tbModel.Text = string.Empty;
			this.tbRsc.Text = string.Empty;
			this.tbMC.Text = string.Empty;
			this.tbEstimatedTime.Text = string.Empty;
			this.dtPlanedDate.Value = DateTime.Now;
			cFunction.getCategoryList(this._factorySetting, this.cbPlant.SelectedItem.ToString(), this.cbCategory, false, true);
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0004D18C File Offset: 0x0004B38C
		private void cbPMDownTime_Paint(object sender, PaintEventArgs e)
		{
			base.OnPaint(e);
			int num = this.cbPMDownTime.Parent.Height - 20;
			Rectangle rectangle = new Rectangle(new Point(0, 0), new Size(num, num));
			ControlPaint.DrawCheckBox(e.Graphics, rectangle, this.cbPMDownTime.Checked ? ButtonState.Checked : ButtonState.Normal);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0004D1F0 File Offset: 0x0004B3F0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0004D228 File Offset: 0x0004B428
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.pnHCCInformation = new Panel();
			this.panel1 = new Panel();
			this.tbHCCPKGType = new TextBox();
			this.label21 = new Label();
			this.pnHCCHandlerType = new Panel();
			this.tbHCCHanlderType = new TextBox();
			this.label24 = new Label();
			this.pnHCCSite = new Panel();
			this.tbHCCSite = new TextBox();
			this.label7 = new Label();
			this.pnNickname = new Panel();
			this.tbHCCNickname = new TextBox();
			this.lbNickname = new Label();
			this.pnHCCType = new Panel();
			this.tbHCCBoardType = new TextBox();
			this.label20 = new Label();
			this.pnBoardNo = new Panel();
			this.tbHCCBoardNo = new TextBox();
			this.label23 = new Label();
			this.panel_other = new Panel();
			this.combo_Content = new ComboBox();
			this.label16 = new Label();
			this.pnRsc = new Panel();
			this.tbRsc = new TextBox();
			this.label8 = new Label();
			this.panel21 = new Panel();
			this.tbAsset = new TextBox();
			this.label22 = new Label();
			this.pnModel = new Panel();
			this.tbModel = new TextBox();
			this.label9 = new Label();
			this.pnMC = new Panel();
			this.tbMC = new TextBox();
			this.lbMC = new Label();
			this.panel7 = new Panel();
			this.cbCategory = new ComboBox();
			this.label4 = new Label();
			this.panel9 = new Panel();
			this.cbPlant = new ComboBox();
			this.label18 = new Label();
			this.panel24 = new Panel();
			this.panel6 = new Panel();
			this.cbPMDownTime = new CheckBox();
			this.label6 = new Label();
			this.panel5 = new Panel();
			this.comboWorkType = new ComboBox();
			this.label1 = new Label();
			this.panel8 = new Panel();
			this.tbEstimatedTime = new TextBox();
			this.label10 = new Label();
			this.panel10 = new Panel();
			this.dtPlanedDate = new DateTimePicker();
			this.label13 = new Label();
			this.groupBox1.SuspendLayout();
			this.pnHCCInformation.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnHCCHandlerType.SuspendLayout();
			this.pnHCCSite.SuspendLayout();
			this.pnNickname.SuspendLayout();
			this.pnHCCType.SuspendLayout();
			this.pnBoardNo.SuspendLayout();
			this.panel_other.SuspendLayout();
			this.pnRsc.SuspendLayout();
			this.panel21.SuspendLayout();
			this.pnModel.SuspendLayout();
			this.pnMC.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel24.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel10.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.pnHCCInformation);
			this.groupBox1.Controls.Add(this.pnRsc);
			this.groupBox1.Controls.Add(this.panel21);
			this.groupBox1.Controls.Add(this.pnModel);
			this.groupBox1.Controls.Add(this.pnMC);
			this.groupBox1.Controls.Add(this.panel7);
			this.groupBox1.Controls.Add(this.panel9);
			this.groupBox1.Dock = DockStyle.Top;
			this.groupBox1.Location = new Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new Padding(3, 0, 0, 3);
			this.groupBox1.Size = new Size(1441, 76);
			this.groupBox1.TabIndex = 73;
			this.groupBox1.TabStop = false;
			this.pnHCCInformation.AutoScroll = true;
			this.pnHCCInformation.Controls.Add(this.panel1);
			this.pnHCCInformation.Controls.Add(this.pnHCCHandlerType);
			this.pnHCCInformation.Controls.Add(this.pnHCCSite);
			this.pnHCCInformation.Controls.Add(this.pnNickname);
			this.pnHCCInformation.Controls.Add(this.pnHCCType);
			this.pnHCCInformation.Controls.Add(this.pnBoardNo);
			this.pnHCCInformation.Controls.Add(this.panel_other);
			this.pnHCCInformation.Dock = DockStyle.Fill;
			this.pnHCCInformation.Location = new Point(1041, 14);
			this.pnHCCInformation.Name = "pnHCCInformation";
			this.pnHCCInformation.Padding = new Padding(3, 0, 0, 0);
			this.pnHCCInformation.Size = new Size(400, 59);
			this.pnHCCInformation.TabIndex = 103;
			this.pnHCCInformation.Visible = false;
			this.panel1.Controls.Add(this.tbHCCPKGType);
			this.panel1.Controls.Add(this.label21);
			this.panel1.Dock = DockStyle.Left;
			this.panel1.Location = new Point(1183, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new Padding(0, 0, 3, 0);
			this.panel1.Size = new Size(274, 42);
			this.panel1.TabIndex = 95;
			this.tbHCCPKGType.BackColor = Color.Gainsboro;
			this.tbHCCPKGType.Dock = DockStyle.Fill;
			this.tbHCCPKGType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCPKGType.Location = new Point(0, 17);
			this.tbHCCPKGType.Name = "tbHCCPKGType";
			this.tbHCCPKGType.ReadOnly = true;
			this.tbHCCPKGType.Size = new Size(271, 23);
			this.tbHCCPKGType.TabIndex = 67;
			this.label21.Dock = DockStyle.Top;
			this.label21.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label21.Location = new Point(0, 0);
			this.label21.Name = "label21";
			this.label21.Size = new Size(271, 17);
			this.label21.TabIndex = 13;
			this.label21.Text = "PKG Type";
			this.pnHCCHandlerType.Controls.Add(this.tbHCCHanlderType);
			this.pnHCCHandlerType.Controls.Add(this.label24);
			this.pnHCCHandlerType.Dock = DockStyle.Left;
			this.pnHCCHandlerType.Location = new Point(909, 0);
			this.pnHCCHandlerType.Name = "pnHCCHandlerType";
			this.pnHCCHandlerType.Padding = new Padding(0, 0, 3, 0);
			this.pnHCCHandlerType.Size = new Size(274, 42);
			this.pnHCCHandlerType.TabIndex = 94;
			this.tbHCCHanlderType.BackColor = Color.Gainsboro;
			this.tbHCCHanlderType.Dock = DockStyle.Fill;
			this.tbHCCHanlderType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCHanlderType.Location = new Point(0, 17);
			this.tbHCCHanlderType.Name = "tbHCCHanlderType";
			this.tbHCCHanlderType.ReadOnly = true;
			this.tbHCCHanlderType.Size = new Size(271, 23);
			this.tbHCCHanlderType.TabIndex = 67;
			this.label24.Dock = DockStyle.Top;
			this.label24.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label24.Location = new Point(0, 0);
			this.label24.Name = "label24";
			this.label24.Size = new Size(271, 17);
			this.label24.TabIndex = 13;
			this.label24.Text = "Handler Type";
			this.pnHCCSite.Controls.Add(this.tbHCCSite);
			this.pnHCCSite.Controls.Add(this.label7);
			this.pnHCCSite.Dock = DockStyle.Left;
			this.pnHCCSite.Location = new Point(808, 0);
			this.pnHCCSite.Name = "pnHCCSite";
			this.pnHCCSite.Padding = new Padding(0, 0, 3, 0);
			this.pnHCCSite.Size = new Size(101, 42);
			this.pnHCCSite.TabIndex = 92;
			this.pnHCCSite.Visible = false;
			this.tbHCCSite.BackColor = Color.Gainsboro;
			this.tbHCCSite.Dock = DockStyle.Fill;
			this.tbHCCSite.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCSite.Location = new Point(0, 17);
			this.tbHCCSite.Name = "tbHCCSite";
			this.tbHCCSite.ReadOnly = true;
			this.tbHCCSite.Size = new Size(98, 23);
			this.tbHCCSite.TabIndex = 67;
			this.label7.Dock = DockStyle.Top;
			this.label7.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label7.Location = new Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(98, 17);
			this.label7.TabIndex = 13;
			this.label7.Text = "Number of Site";
			this.pnNickname.Controls.Add(this.tbHCCNickname);
			this.pnNickname.Controls.Add(this.lbNickname);
			this.pnNickname.Dock = DockStyle.Left;
			this.pnNickname.Location = new Point(624, 0);
			this.pnNickname.Name = "pnNickname";
			this.pnNickname.Padding = new Padding(0, 0, 3, 0);
			this.pnNickname.Size = new Size(184, 42);
			this.pnNickname.TabIndex = 89;
			this.tbHCCNickname.BackColor = Color.Gainsboro;
			this.tbHCCNickname.Dock = DockStyle.Fill;
			this.tbHCCNickname.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCNickname.Location = new Point(0, 17);
			this.tbHCCNickname.Name = "tbHCCNickname";
			this.tbHCCNickname.ReadOnly = true;
			this.tbHCCNickname.Size = new Size(181, 23);
			this.tbHCCNickname.TabIndex = 67;
			this.lbNickname.Dock = DockStyle.Top;
			this.lbNickname.Font = new Font("Segoe UI Symbol", 9.75f);
			this.lbNickname.Location = new Point(0, 0);
			this.lbNickname.Name = "lbNickname";
			this.lbNickname.Size = new Size(181, 17);
			this.lbNickname.TabIndex = 13;
			this.lbNickname.Text = "Nickname";
			this.pnHCCType.Controls.Add(this.tbHCCBoardType);
			this.pnHCCType.Controls.Add(this.label20);
			this.pnHCCType.Dock = DockStyle.Left;
			this.pnHCCType.Location = new Point(440, 0);
			this.pnHCCType.Name = "pnHCCType";
			this.pnHCCType.Padding = new Padding(0, 0, 3, 0);
			this.pnHCCType.Size = new Size(184, 42);
			this.pnHCCType.TabIndex = 88;
			this.tbHCCBoardType.BackColor = Color.Gainsboro;
			this.tbHCCBoardType.Dock = DockStyle.Fill;
			this.tbHCCBoardType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCBoardType.Location = new Point(0, 17);
			this.tbHCCBoardType.Name = "tbHCCBoardType";
			this.tbHCCBoardType.ReadOnly = true;
			this.tbHCCBoardType.Size = new Size(181, 23);
			this.tbHCCBoardType.TabIndex = 67;
			this.label20.Dock = DockStyle.Top;
			this.label20.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label20.Location = new Point(0, 0);
			this.label20.Name = "label20";
			this.label20.Size = new Size(181, 17);
			this.label20.TabIndex = 13;
			this.label20.Text = "Hardware Type";
			this.pnBoardNo.Controls.Add(this.tbHCCBoardNo);
			this.pnBoardNo.Controls.Add(this.label23);
			this.pnBoardNo.Dock = DockStyle.Left;
			this.pnBoardNo.Location = new Point(317, 0);
			this.pnBoardNo.Name = "pnBoardNo";
			this.pnBoardNo.Padding = new Padding(0, 0, 3, 0);
			this.pnBoardNo.Size = new Size(123, 42);
			this.pnBoardNo.TabIndex = 91;
			this.pnBoardNo.Visible = false;
			this.tbHCCBoardNo.BackColor = Color.Gainsboro;
			this.tbHCCBoardNo.Dock = DockStyle.Fill;
			this.tbHCCBoardNo.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCBoardNo.Location = new Point(0, 17);
			this.tbHCCBoardNo.Name = "tbHCCBoardNo";
			this.tbHCCBoardNo.ReadOnly = true;
			this.tbHCCBoardNo.Size = new Size(120, 23);
			this.tbHCCBoardNo.TabIndex = 67;
			this.label23.Dock = DockStyle.Top;
			this.label23.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label23.Location = new Point(0, 0);
			this.label23.Name = "label23";
			this.label23.Size = new Size(120, 17);
			this.label23.TabIndex = 13;
			this.label23.Text = "Board No.";
			this.panel_other.Controls.Add(this.combo_Content);
			this.panel_other.Controls.Add(this.label16);
			this.panel_other.Dock = DockStyle.Left;
			this.panel_other.Location = new Point(3, 0);
			this.panel_other.Name = "panel_other";
			this.panel_other.Size = new Size(314, 42);
			this.panel_other.TabIndex = 96;
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
			this.label16.AutoSize = true;
			this.label16.Dock = DockStyle.Top;
			this.label16.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label16.Location = new Point(0, 0);
			this.label16.Name = "label16";
			this.label16.Size = new Size(59, 17);
			this.label16.TabIndex = 8;
			this.label16.Text = "Contents";
			this.pnRsc.Controls.Add(this.tbRsc);
			this.pnRsc.Controls.Add(this.label8);
			this.pnRsc.Dock = DockStyle.Left;
			this.pnRsc.Location = new Point(857, 14);
			this.pnRsc.Name = "pnRsc";
			this.pnRsc.Padding = new Padding(0, 0, 3, 0);
			this.pnRsc.Size = new Size(184, 59);
			this.pnRsc.TabIndex = 81;
			this.tbRsc.BackColor = Color.Gainsboro;
			this.tbRsc.Dock = DockStyle.Fill;
			this.tbRsc.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbRsc.Location = new Point(0, 17);
			this.tbRsc.Name = "tbRsc";
			this.tbRsc.ReadOnly = true;
			this.tbRsc.Size = new Size(181, 23);
			this.tbRsc.TabIndex = 67;
			this.label8.AutoSize = true;
			this.label8.Dock = DockStyle.Top;
			this.label8.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label8.Location = new Point(0, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(54, 17);
			this.label8.TabIndex = 13;
			this.label8.Text = "Rsc Dec";
			this.panel21.Controls.Add(this.tbAsset);
			this.panel21.Controls.Add(this.label22);
			this.panel21.Dock = DockStyle.Left;
			this.panel21.Location = new Point(645, 14);
			this.panel21.Name = "panel21";
			this.panel21.Padding = new Padding(0, 0, 3, 0);
			this.panel21.Size = new Size(212, 59);
			this.panel21.TabIndex = 102;
			this.panel21.Visible = false;
			this.tbAsset.BackColor = Color.Gainsboro;
			this.tbAsset.Dock = DockStyle.Fill;
			this.tbAsset.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbAsset.Location = new Point(0, 17);
			this.tbAsset.Name = "tbAsset";
			this.tbAsset.ReadOnly = true;
			this.tbAsset.Size = new Size(209, 23);
			this.tbAsset.TabIndex = 16;
			this.label22.AutoSize = true;
			this.label22.Dock = DockStyle.Top;
			this.label22.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label22.Location = new Point(0, 0);
			this.label22.Name = "label22";
			this.label22.Size = new Size(51, 17);
			this.label22.TabIndex = 15;
			this.label22.Text = "Asset #";
			this.pnModel.Controls.Add(this.tbModel);
			this.pnModel.Controls.Add(this.label9);
			this.pnModel.Dock = DockStyle.Left;
			this.pnModel.Location = new Point(433, 14);
			this.pnModel.Name = "pnModel";
			this.pnModel.Padding = new Padding(0, 0, 3, 0);
			this.pnModel.Size = new Size(212, 59);
			this.pnModel.TabIndex = 80;
			this.tbModel.BackColor = Color.Gainsboro;
			this.tbModel.Dock = DockStyle.Fill;
			this.tbModel.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbModel.Location = new Point(0, 17);
			this.tbModel.Name = "tbModel";
			this.tbModel.ReadOnly = true;
			this.tbModel.Size = new Size(209, 23);
			this.tbModel.TabIndex = 16;
			this.label9.AutoSize = true;
			this.label9.Dock = DockStyle.Top;
			this.label9.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label9.Location = new Point(0, 0);
			this.label9.Name = "label9";
			this.label9.Size = new Size(46, 17);
			this.label9.TabIndex = 15;
			this.label9.Text = "Model";
			this.pnMC.Controls.Add(this.tbMC);
			this.pnMC.Controls.Add(this.lbMC);
			this.pnMC.Dock = DockStyle.Left;
			this.pnMC.Location = new Point(239, 14);
			this.pnMC.Name = "pnMC";
			this.pnMC.Padding = new Padding(0, 0, 3, 0);
			this.pnMC.Size = new Size(194, 59);
			this.pnMC.TabIndex = 88;
			this.tbMC.CharacterCasing = CharacterCasing.Upper;
			this.tbMC.Dock = DockStyle.Fill;
			this.tbMC.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbMC.Location = new Point(0, 17);
			this.tbMC.Name = "tbMC";
			this.tbMC.Size = new Size(191, 23);
			this.tbMC.TabIndex = 8;
			this.tbMC.TextChanged += this.tbMC_TextChanged;
			this.tbMC.KeyDown += this.tbMC_KeyDown;
			this.lbMC.AutoSize = true;
			this.lbMC.Dock = DockStyle.Top;
			this.lbMC.Font = new Font("Segoe UI Symbol", 9.75f);
			this.lbMC.Location = new Point(0, 0);
			this.lbMC.Name = "lbMC";
			this.lbMC.Size = new Size(45, 17);
			this.lbMC.TabIndex = 7;
			this.lbMC.Text = "M/C #";
			this.panel7.Controls.Add(this.cbCategory);
			this.panel7.Controls.Add(this.label4);
			this.panel7.Dock = DockStyle.Left;
			this.panel7.Location = new Point(77, 14);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new Padding(3, 0, 3, 0);
			this.panel7.Size = new Size(162, 59);
			this.panel7.TabIndex = 78;
			this.cbCategory.Dock = DockStyle.Fill;
			this.cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbCategory.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbCategory.Location = new Point(3, 17);
			this.cbCategory.Name = "cbCategory";
			this.cbCategory.Size = new Size(156, 23);
			this.cbCategory.TabIndex = 6;
			this.cbCategory.SelectedIndexChanged += this.cbCategory_SelectedIndexChanged;
			this.label4.AutoSize = true;
			this.label4.Dock = DockStyle.Top;
			this.label4.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label4.Location = new Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(61, 17);
			this.label4.TabIndex = 5;
			this.label4.Text = "Category";
			this.panel9.Controls.Add(this.cbPlant);
			this.panel9.Controls.Add(this.label18);
			this.panel9.Dock = DockStyle.Left;
			this.panel9.Location = new Point(3, 14);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new Padding(3, 0, 3, 0);
			this.panel9.Size = new Size(74, 59);
			this.panel9.TabIndex = 83;
			this.cbPlant.Dock = DockStyle.Fill;
			this.cbPlant.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbPlant.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbPlant.Location = new Point(3, 17);
			this.cbPlant.Name = "cbPlant";
			this.cbPlant.Size = new Size(68, 23);
			this.cbPlant.TabIndex = 6;
			this.cbPlant.SelectedIndexChanged += this.cbPlant_SelectedIndexChanged;
			this.label18.AutoSize = true;
			this.label18.Dock = DockStyle.Top;
			this.label18.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label18.Location = new Point(3, 0);
			this.label18.Name = "label18";
			this.label18.Size = new Size(50, 17);
			this.label18.TabIndex = 5;
			this.label18.Text = "Factory";
			this.panel24.Controls.Add(this.panel6);
			this.panel24.Controls.Add(this.panel5);
			this.panel24.Controls.Add(this.panel8);
			this.panel24.Controls.Add(this.panel10);
			this.panel24.Dock = DockStyle.Fill;
			this.panel24.Location = new Point(0, 76);
			this.panel24.Name = "panel24";
			this.panel24.Padding = new Padding(3, 0, 3, 0);
			this.panel24.Size = new Size(1441, 57);
			this.panel24.TabIndex = 84;
			this.panel6.Controls.Add(this.cbPMDownTime);
			this.panel6.Controls.Add(this.label6);
			this.panel6.Dock = DockStyle.Left;
			this.panel6.Location = new Point(509, 0);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new Padding(1, 1, 3, 1);
			this.panel6.Size = new Size(142, 57);
			this.panel6.TabIndex = 105;
			this.cbPMDownTime.Dock = DockStyle.Top;
			this.cbPMDownTime.Location = new Point(1, 16);
			this.cbPMDownTime.Name = "cbPMDownTime";
			this.cbPMDownTime.Size = new Size(138, 21);
			this.cbPMDownTime.TabIndex = 9;
			this.cbPMDownTime.Text = "PM Down Time";
			this.cbPMDownTime.TextAlign = ContentAlignment.MiddleCenter;
			this.cbPMDownTime.UseVisualStyleBackColor = true;
			this.cbPMDownTime.Paint += this.cbPMDownTime_Paint;
			this.label6.Dock = DockStyle.Top;
			this.label6.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label6.Location = new Point(1, 1);
			this.label6.Name = "label6";
			this.label6.Size = new Size(138, 15);
			this.label6.TabIndex = 8;
			this.label6.Text = "PM Status";
			this.panel5.Controls.Add(this.comboWorkType);
			this.panel5.Controls.Add(this.label1);
			this.panel5.Dock = DockStyle.Left;
			this.panel5.Location = new Point(297, 0);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new Padding(0, 0, 3, 0);
			this.panel5.Size = new Size(212, 57);
			this.panel5.TabIndex = 104;
			this.comboWorkType.BackColor = SystemColors.Window;
			this.comboWorkType.Dock = DockStyle.Fill;
			this.comboWorkType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboWorkType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.comboWorkType.FormattingEnabled = true;
			this.comboWorkType.Location = new Point(0, 17);
			this.comboWorkType.Name = "comboWorkType";
			this.comboWorkType.Size = new Size(209, 23);
			this.comboWorkType.TabIndex = 70;
			this.label1.AutoSize = true;
			this.label1.Dock = DockStyle.Top;
			this.label1.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label1.Location = new Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(71, 17);
			this.label1.TabIndex = 15;
			this.label1.Text = "Work Type";
			this.panel8.Controls.Add(this.tbEstimatedTime);
			this.panel8.Controls.Add(this.label10);
			this.panel8.Dock = DockStyle.Left;
			this.panel8.Location = new Point(164, 0);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new Padding(3, 0, 3, 0);
			this.panel8.Size = new Size(133, 57);
			this.panel8.TabIndex = 106;
			this.tbEstimatedTime.CharacterCasing = CharacterCasing.Upper;
			this.tbEstimatedTime.Dock = DockStyle.Fill;
			this.tbEstimatedTime.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbEstimatedTime.Location = new Point(3, 17);
			this.tbEstimatedTime.MaxLength = 5;
			this.tbEstimatedTime.Name = "tbEstimatedTime";
			this.tbEstimatedTime.Size = new Size(127, 23);
			this.tbEstimatedTime.TabIndex = 9;
			this.tbEstimatedTime.KeyPress += this.tbEstimatedTime_KeyPress;
			this.label10.AutoSize = true;
			this.label10.Dock = DockStyle.Top;
			this.label10.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label10.Location = new Point(3, 0);
			this.label10.Name = "label10";
			this.label10.Size = new Size(114, 17);
			this.label10.TabIndex = 8;
			this.label10.Text = "Estimated Time(H)";
			this.panel10.Controls.Add(this.dtPlanedDate);
			this.panel10.Controls.Add(this.label13);
			this.panel10.Dock = DockStyle.Left;
			this.panel10.Location = new Point(3, 0);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new Padding(3, 0, 3, 0);
			this.panel10.Size = new Size(161, 57);
			this.panel10.TabIndex = 107;
			this.dtPlanedDate.CalendarFont = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtPlanedDate.CustomFormat = "yyyy-MM-dd HH:mm";
			this.dtPlanedDate.Dock = DockStyle.Fill;
			this.dtPlanedDate.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtPlanedDate.Format = DateTimePickerFormat.Custom;
			this.dtPlanedDate.Location = new Point(3, 17);
			this.dtPlanedDate.Name = "dtPlanedDate";
			this.dtPlanedDate.Size = new Size(155, 23);
			this.dtPlanedDate.TabIndex = 52;
			this.dtPlanedDate.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.label13.AutoSize = true;
			this.label13.Dock = DockStyle.Top;
			this.label13.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label13.Location = new Point(3, 0);
			this.label13.Name = "label13";
			this.label13.Size = new Size(78, 17);
			this.label13.TabIndex = 8;
			this.label13.Text = "Planed Date";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel24);
			base.Controls.Add(this.groupBox1);
			base.Name = "PMInformation";
			base.Size = new Size(1441, 133);
			this.groupBox1.ResumeLayout(false);
			this.pnHCCInformation.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnHCCHandlerType.ResumeLayout(false);
			this.pnHCCHandlerType.PerformLayout();
			this.pnHCCSite.ResumeLayout(false);
			this.pnHCCSite.PerformLayout();
			this.pnNickname.ResumeLayout(false);
			this.pnNickname.PerformLayout();
			this.pnHCCType.ResumeLayout(false);
			this.pnHCCType.PerformLayout();
			this.pnBoardNo.ResumeLayout(false);
			this.pnBoardNo.PerformLayout();
			this.panel_other.ResumeLayout(false);
			this.panel_other.PerformLayout();
			this.pnRsc.ResumeLayout(false);
			this.pnRsc.PerformLayout();
			this.panel21.ResumeLayout(false);
			this.panel21.PerformLayout();
			this.pnModel.ResumeLayout(false);
			this.pnModel.PerformLayout();
			this.pnMC.ResumeLayout(false);
			this.pnMC.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel24.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040003B2 RID: 946
		private PMUserInformation _pui;

		// Token: 0x040003B3 RID: 947
		private QueryMgr _queryMgr;

		// Token: 0x040003B4 RID: 948
		private List<MachineInfo> _MachineModelList = new List<MachineInfo>();

		// Token: 0x040003B5 RID: 949
		private FactorySettings _factorySetting;

		// Token: 0x040003B6 RID: 950
		private IContainer components = null;

		// Token: 0x040003B7 RID: 951
		private GroupBox groupBox1;

		// Token: 0x040003B8 RID: 952
		private Panel pnRsc;

		// Token: 0x040003B9 RID: 953
		private TextBox tbRsc;

		// Token: 0x040003BA RID: 954
		private Label label8;

		// Token: 0x040003BB RID: 955
		private Panel panel21;

		// Token: 0x040003BC RID: 956
		private TextBox tbAsset;

		// Token: 0x040003BD RID: 957
		private Label label22;

		// Token: 0x040003BE RID: 958
		private Panel pnModel;

		// Token: 0x040003BF RID: 959
		private TextBox tbModel;

		// Token: 0x040003C0 RID: 960
		private Label label9;

		// Token: 0x040003C1 RID: 961
		private Panel pnMC;

		// Token: 0x040003C2 RID: 962
		private TextBox tbMC;

		// Token: 0x040003C3 RID: 963
		private Label lbMC;

		// Token: 0x040003C4 RID: 964
		private Panel panel7;

		// Token: 0x040003C5 RID: 965
		private ComboBox cbCategory;

		// Token: 0x040003C6 RID: 966
		private Label label4;

		// Token: 0x040003C7 RID: 967
		private Panel panel9;

		// Token: 0x040003C8 RID: 968
		private ComboBox cbPlant;

		// Token: 0x040003C9 RID: 969
		private Label label18;

		// Token: 0x040003CA RID: 970
		private Panel panel24;

		// Token: 0x040003CB RID: 971
		private Panel panel6;

		// Token: 0x040003CC RID: 972
		private Label label6;

		// Token: 0x040003CD RID: 973
		private Panel panel5;

		// Token: 0x040003CE RID: 974
		private ComboBox comboWorkType;

		// Token: 0x040003CF RID: 975
		private Label label1;

		// Token: 0x040003D0 RID: 976
		private Panel panel8;

		// Token: 0x040003D1 RID: 977
		private TextBox tbEstimatedTime;

		// Token: 0x040003D2 RID: 978
		private Label label10;

		// Token: 0x040003D3 RID: 979
		private Panel panel10;

		// Token: 0x040003D4 RID: 980
		private DateTimePicker dtPlanedDate;

		// Token: 0x040003D5 RID: 981
		private Label label13;

		// Token: 0x040003D6 RID: 982
		private Panel pnHCCInformation;

		// Token: 0x040003D7 RID: 983
		private Panel panel1;

		// Token: 0x040003D8 RID: 984
		private TextBox tbHCCPKGType;

		// Token: 0x040003D9 RID: 985
		private Label label21;

		// Token: 0x040003DA RID: 986
		private Panel pnHCCHandlerType;

		// Token: 0x040003DB RID: 987
		private TextBox tbHCCHanlderType;

		// Token: 0x040003DC RID: 988
		private Label label24;

		// Token: 0x040003DD RID: 989
		private Panel pnHCCSite;

		// Token: 0x040003DE RID: 990
		private TextBox tbHCCSite;

		// Token: 0x040003DF RID: 991
		private Label label7;

		// Token: 0x040003E0 RID: 992
		private Panel pnNickname;

		// Token: 0x040003E1 RID: 993
		private TextBox tbHCCNickname;

		// Token: 0x040003E2 RID: 994
		private Label lbNickname;

		// Token: 0x040003E3 RID: 995
		private Panel pnHCCType;

		// Token: 0x040003E4 RID: 996
		private TextBox tbHCCBoardType;

		// Token: 0x040003E5 RID: 997
		private Label label20;

		// Token: 0x040003E6 RID: 998
		private Panel pnBoardNo;

		// Token: 0x040003E7 RID: 999
		private TextBox tbHCCBoardNo;

		// Token: 0x040003E8 RID: 1000
		private Label label23;

		// Token: 0x040003E9 RID: 1001
		private Panel panel_other;

		// Token: 0x040003EA RID: 1002
		private ComboBox combo_Content;

		// Token: 0x040003EB RID: 1003
		private Label label16;

		// Token: 0x040003EC RID: 1004
		private CheckBox cbPMDownTime;
	}
}
