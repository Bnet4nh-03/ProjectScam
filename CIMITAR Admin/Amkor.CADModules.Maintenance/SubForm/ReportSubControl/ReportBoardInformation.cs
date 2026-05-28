using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Interface;
using Amkor.CADModules.Maintenance.Properties;
using Amkor.CADModules.Maintenance.SubForm.SubControl;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.ReportSubControl
{
	// Token: 0x02000014 RID: 20
	public class ReportBoardInformation : UserControl, IHCC
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000166 RID: 358 RVA: 0x00042B1D File Offset: 0x00040D1D
		public HCC _hCC { get; }

		// Token: 0x06000167 RID: 359 RVA: 0x00042B25 File Offset: 0x00040D25
		private void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00042B34 File Offset: 0x00040D34
		public ReportBoardInformation(FactorySettings factorySettings, HCC hCC, cReportItem reportItem)
		{
			this._factorySettings = factorySettings;
			this._hCC = hCC;
			this._queryMgr = new QueryMgr(this._factorySettings);
			this._reportItem = reportItem;
			this.InitializeComponent();
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00042B88 File Offset: 0x00040D88
		public void clear()
		{
			this.tbHCCMachine.Text = string.Empty;
			this.tbHCCLot.Text = string.Empty;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00042BB0 File Offset: 0x00040DB0
		private void getMachineNumberByHCC()
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMachineList] @_Plant = 'K3', @SearchType = 'TESTER'";
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
					bool flag2 = this._ri.getCategory() == "EOL" || this._ri.getCategory() == "STACK";
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
				this.tbHCCMachine.AutoCompleteCustomSource = autoCompleteStringCollection;
				this.tbHCCMachine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				this.tbHCCMachine.AutoCompleteSource = AutoCompleteSource.CustomSource;
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00042E54 File Offset: 0x00041054
		private void getMachineNumber(bool otherType)
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMachineList] @_Plant = '",
				this._ri.getFactory(),
				"', @SearchType = '",
				this._ri.getCategory(),
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
					bool flag2 = this._ri.getCategory() == "EOL" || this._ri.getCategory() == "STACK";
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
				this.tbHCCMachine.AutoCompleteCustomSource = autoCompleteStringCollection;
				this.tbHCCMachine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				this.tbHCCMachine.AutoCompleteSource = AutoCompleteSource.CustomSource;
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00043134 File Offset: 0x00041334
		public bool checkStatus()
		{
			return !this.rbHwCheck.Checked && !this.rbHwGood.Checked;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0004316D File Offset: 0x0004136D
		public string getMachine()
		{
			return this.tbHCCMachine.Text.Trim();
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0004317F File Offset: 0x0004137F
		public string getLot()
		{
			return this.tbHCCLot.Text.Trim();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00043194 File Offset: 0x00041394
		public int checkGood()
		{
			bool @checked = this.rbHwGood.Checked;
			int result;
			if (@checked)
			{
				result = 1;
			}
			else
			{
				bool checked2 = this.rbHwCheck.Checked;
				if (checked2)
				{
					result = 2;
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000431D0 File Offset: 0x000413D0
		public void visibleBoardInfo(bool visible)
		{
			this.gbHwStatus.Visible = true;
			bool flag = this._ri.getFactory() == "K3";
			if (flag)
			{
				this.rbHwGood.Visible = false;
			}
			else
			{
				this.rbHwGood.Visible = true;
			}
			this.gbBoardInfo.Visible = visible;
			this.pnBoardSite.Visible = visible;
			if (visible)
			{
				this.getMachineNumberByHCC();
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00043248 File Offset: 0x00041448
		public void setETCMode()
		{
			this.gbHwStatus.Visible = false;
			this.gbBoardInfo.Visible = false;
			this.pnBoardSite.Visible = false;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000AE4C File Offset: 0x0000904C
		public void addBoardList(bool bMachineName)
		{
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00043274 File Offset: 0x00041474
		private void getLotNumber()
		{
			bool flag = string.IsNullOrEmpty(this._hCC.hCCParameter.location);
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("input_board_location"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Search");
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(1);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintGetLot] @_factory = N'K3', @_location= N'" + this._hCC.hCCParameter.location + "'";
				DataSet dataSet = this._queryMgr.queryCall(sQuery);
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				bool flag2 = this._barPrograss != null;
				if (flag2)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
				bool flag3 = dataSet != null && dataSet.Tables.Count > 0;
				if (flag3)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						bool flag4 = dataSet.Tables[0].Columns.Contains("lotname");
						if (flag4)
						{
							string text = dataSet.Tables[0].Rows[i]["lotname"].ToString();
							string text2 = dataSet.Tables[0].Rows[i]["dcc"].ToString();
							string text3 = dataSet.Tables[0].Rows[i]["device"].ToString();
							string text4 = dataSet.Tables[0].Rows[i]["testername"].ToString();
							string text5 = dataSet.Tables[0].Rows[i]["handername"].ToString();
							this.tbHCCLot.Text = text.Trim().ToUpper();
							this.tbHCCMachine.Text = text4.Trim().ToUpper();
						}
						else
						{
							bool flag5 = dataSet.Tables[0].Columns.Contains("ERROR");
							if (flag5)
							{
								MessageBox.Show(dataSet.Tables[0].Rows[i]["ERROR"].ToString(), MessageLanguage.getMessage("messagebox_error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("can_not_find_lot"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0004357E File Offset: 0x0004177E
		private void pbImport_MouseLeave(object sender, EventArgs e)
		{
			this.pbImport.Image = Resources.import;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00043591 File Offset: 0x00041791
		private void pbImport_MouseEnter(object sender, EventArgs e)
		{
			this.pbImport.Image = Resources.import_down;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000435A4 File Offset: 0x000417A4
		private void pbImport_MouseClick(object sender, MouseEventArgs e)
		{
			this.pbImport.Image = Resources.import;
			this.getLotNumber();
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000435BF File Offset: 0x000417BF
		private void pbBoardInforamtion_MouseEnter(object sender, EventArgs e)
		{
			this.pbBoardInforamtion.Image = Resources.board_down;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000435D2 File Offset: 0x000417D2
		private void pbBoardInforamtion_MouseLeave(object sender, EventArgs e)
		{
			this.pbBoardInforamtion.Image = Resources.board;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000435E8 File Offset: 0x000417E8
		private void pbBoardInforamtion_Click(object sender, EventArgs e)
		{
			this.pbBoardInforamtion.Image = Resources.board;
			this._hi.setLocationLeave();
			bool flag = string.IsNullOrEmpty(this._hCC.hCCParameter.location.Trim());
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("input_board_location"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				bool flag2 = this._hCC.hCCParameter == null;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("can_not_find_sitemap"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					bool flag3 = string.IsNullOrEmpty(this._hCC.hCCParameter.site) || this._hCC.hCCParameter.siteRow == 0 || this._hCC.hCCParameter.siteCol == 0;
					if (flag3)
					{
						MessageBox.Show(MessageLanguage.getMessage("wrong_information_sitemap"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						this._reportItem.sFactory = this._ri.getFactory();
						new SiteMapForm(this._factorySettings, this._reportItem, this._hCC, true).ShowDialog();
					}
				}
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00043720 File Offset: 0x00041920
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00043758 File Offset: 0x00041958
		private void InitializeComponent()
		{
			this.gbHwStatus = new GroupBox();
			this.rbHwCheck = new RadioButton();
			this.rbHwGood = new RadioButton();
			this.gbBoardInfo = new GroupBox();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.panel25 = new Panel();
			this.tbHCCLot = new TextBox();
			this.label25 = new Label();
			this.panel23 = new Panel();
			this.tbHCCMachine = new TextBox();
			this.label22 = new Label();
			this.panel24 = new Panel();
			this.pbImport = new PictureBox();
			this.groupBox1 = new GroupBox();
			this.pbBoardInforamtion = new PictureBox();
			this.pnBoardSite = new Panel();
			this.gbHwStatus.SuspendLayout();
			this.gbBoardInfo.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel23.SuspendLayout();
			this.panel24.SuspendLayout();
			((ISupportInitialize)this.pbImport).BeginInit();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.pbBoardInforamtion).BeginInit();
			this.pnBoardSite.SuspendLayout();
			base.SuspendLayout();
			this.gbHwStatus.Controls.Add(this.rbHwCheck);
			this.gbHwStatus.Controls.Add(this.rbHwGood);
			this.gbHwStatus.Dock = DockStyle.Top;
			this.gbHwStatus.Font = new Font("Segoe UI Symbol", 9.75f);
			this.gbHwStatus.Location = new Point(0, 0);
			this.gbHwStatus.Name = "gbHwStatus";
			this.gbHwStatus.Size = new Size(439, 72);
			this.gbHwStatus.TabIndex = 97;
			this.gbHwStatus.TabStop = false;
			this.gbHwStatus.Text = "H/W Status";
			this.gbHwStatus.Visible = false;
			this.rbHwCheck.AutoSize = true;
			this.rbHwCheck.Checked = true;
			this.rbHwCheck.Cursor = Cursors.Hand;
			this.rbHwCheck.Dock = DockStyle.Top;
			this.rbHwCheck.Location = new Point(3, 42);
			this.rbHwCheck.Name = "rbHwCheck";
			this.rbHwCheck.Size = new Size(433, 21);
			this.rbHwCheck.TabIndex = 1;
			this.rbHwCheck.TabStop = true;
			this.rbHwCheck.Text = "Need to Check";
			this.rbHwCheck.UseVisualStyleBackColor = true;
			this.rbHwGood.AutoSize = true;
			this.rbHwGood.Cursor = Cursors.Hand;
			this.rbHwGood.Dock = DockStyle.Top;
			this.rbHwGood.Location = new Point(3, 21);
			this.rbHwGood.Name = "rbHwGood";
			this.rbHwGood.Size = new Size(433, 21);
			this.rbHwGood.TabIndex = 0;
			this.rbHwGood.TabStop = true;
			this.rbHwGood.Text = "Good";
			this.rbHwGood.UseVisualStyleBackColor = true;
			this.gbBoardInfo.Controls.Add(this.panel1);
			this.gbBoardInfo.Dock = DockStyle.Left;
			this.gbBoardInfo.Location = new Point(0, 72);
			this.gbBoardInfo.Name = "gbBoardInfo";
			this.gbBoardInfo.Size = new Size(356, 118);
			this.gbBoardInfo.TabIndex = 98;
			this.gbBoardInfo.TabStop = false;
			this.gbBoardInfo.Text = "Board Information";
			this.gbBoardInfo.Visible = false;
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.panel24);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(3, 17);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(350, 98);
			this.panel1.TabIndex = 7;
			this.panel2.Controls.Add(this.panel25);
			this.panel2.Controls.Add(this.panel23);
			this.panel2.Dock = DockStyle.Fill;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new Padding(0, 0, 1, 0);
			this.panel2.Size = new Size(293, 98);
			this.panel2.TabIndex = 2;
			this.panel25.Controls.Add(this.tbHCCLot);
			this.panel25.Controls.Add(this.label25);
			this.panel25.Dock = DockStyle.Fill;
			this.panel25.Location = new Point(0, 50);
			this.panel25.Name = "panel25";
			this.panel25.Size = new Size(292, 48);
			this.panel25.TabIndex = 1;
			this.tbHCCLot.CharacterCasing = CharacterCasing.Upper;
			this.tbHCCLot.Dock = DockStyle.Fill;
			this.tbHCCLot.Location = new Point(0, 25);
			this.tbHCCLot.Name = "tbHCCLot";
			this.tbHCCLot.Size = new Size(292, 21);
			this.tbHCCLot.TabIndex = 15;
			this.label25.Dock = DockStyle.Top;
			this.label25.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label25.Location = new Point(0, 0);
			this.label25.Name = "label25";
			this.label25.Size = new Size(292, 25);
			this.label25.TabIndex = 14;
			this.label25.Text = "Lot Number";
			this.label25.TextAlign = ContentAlignment.MiddleCenter;
			this.panel23.Controls.Add(this.tbHCCMachine);
			this.panel23.Controls.Add(this.label22);
			this.panel23.Dock = DockStyle.Top;
			this.panel23.Location = new Point(0, 0);
			this.panel23.Name = "panel23";
			this.panel23.Size = new Size(292, 50);
			this.panel23.TabIndex = 0;
			this.tbHCCMachine.CharacterCasing = CharacterCasing.Upper;
			this.tbHCCMachine.Dock = DockStyle.Fill;
			this.tbHCCMachine.Location = new Point(0, 25);
			this.tbHCCMachine.Name = "tbHCCMachine";
			this.tbHCCMachine.Size = new Size(292, 21);
			this.tbHCCMachine.TabIndex = 15;
			this.label22.Dock = DockStyle.Top;
			this.label22.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label22.Location = new Point(0, 0);
			this.label22.Name = "label22";
			this.label22.Size = new Size(292, 25);
			this.label22.TabIndex = 14;
			this.label22.Text = "M/C#";
			this.label22.TextAlign = ContentAlignment.MiddleCenter;
			this.panel24.Controls.Add(this.pbImport);
			this.panel24.Dock = DockStyle.Right;
			this.panel24.Location = new Point(293, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new Size(57, 98);
			this.panel24.TabIndex = 1;
			this.pbImport.Cursor = Cursors.Hand;
			this.pbImport.Dock = DockStyle.Top;
			this.pbImport.Image = Resources.import;
			this.pbImport.Location = new Point(0, 0);
			this.pbImport.Name = "pbImport";
			this.pbImport.Size = new Size(57, 50);
			this.pbImport.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbImport.TabIndex = 0;
			this.pbImport.TabStop = false;
			this.pbImport.MouseClick += this.pbImport_MouseClick;
			this.pbImport.MouseEnter += this.pbImport_MouseEnter;
			this.pbImport.MouseLeave += this.pbImport_MouseLeave;
			this.groupBox1.Controls.Add(this.pbBoardInforamtion);
			this.groupBox1.Dock = DockStyle.Top;
			this.groupBox1.Location = new Point(1, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new Padding(1, 0, 0, 0);
			this.groupBox1.Size = new Size(82, 67);
			this.groupBox1.TabIndex = 99;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Site Map";
			this.pbBoardInforamtion.Cursor = Cursors.Hand;
			this.pbBoardInforamtion.Dock = DockStyle.Fill;
			this.pbBoardInforamtion.Image = Resources.board;
			this.pbBoardInforamtion.InitialImage = null;
			this.pbBoardInforamtion.Location = new Point(1, 14);
			this.pbBoardInforamtion.Name = "pbBoardInforamtion";
			this.pbBoardInforamtion.Size = new Size(81, 53);
			this.pbBoardInforamtion.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbBoardInforamtion.TabIndex = 99;
			this.pbBoardInforamtion.TabStop = false;
			this.pbBoardInforamtion.Click += this.pbBoardInforamtion_Click;
			this.pbBoardInforamtion.MouseEnter += this.pbBoardInforamtion_MouseEnter;
			this.pbBoardInforamtion.MouseLeave += this.pbBoardInforamtion_MouseLeave;
			this.pnBoardSite.Controls.Add(this.groupBox1);
			this.pnBoardSite.Dock = DockStyle.Fill;
			this.pnBoardSite.Location = new Point(356, 72);
			this.pnBoardSite.Name = "pnBoardSite";
			this.pnBoardSite.Padding = new Padding(1, 0, 0, 0);
			this.pnBoardSite.Size = new Size(83, 118);
			this.pnBoardSite.TabIndex = 100;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.pnBoardSite);
			base.Controls.Add(this.gbBoardInfo);
			base.Controls.Add(this.gbHwStatus);
			base.Name = "ReportBoardInformation";
			base.Size = new Size(439, 190);
			this.gbHwStatus.ResumeLayout(false);
			this.gbHwStatus.PerformLayout();
			this.gbBoardInfo.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel23.ResumeLayout(false);
			this.panel23.PerformLayout();
			this.panel24.ResumeLayout(false);
			((ISupportInitialize)this.pbImport).EndInit();
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.pbBoardInforamtion).EndInit();
			this.pnBoardSite.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000303 RID: 771
		private QueryMgr _queryMgr;

		// Token: 0x04000304 RID: 772
		private List<MachineInfo> _MachineModelList = new List<MachineInfo>();

		// Token: 0x04000305 RID: 773
		private BarPrograss _barPrograss;

		// Token: 0x04000306 RID: 774
		private Thread _thread;

		// Token: 0x04000307 RID: 775
		public ReportInformation _ri;

		// Token: 0x04000308 RID: 776
		public HCCInformation _hi;

		// Token: 0x0400030A RID: 778
		private cReportItem _reportItem;

		// Token: 0x0400030B RID: 779
		private FactorySettings _factorySettings;

		// Token: 0x0400030C RID: 780
		private IContainer components = null;

		// Token: 0x0400030D RID: 781
		private GroupBox gbHwStatus;

		// Token: 0x0400030E RID: 782
		private RadioButton rbHwGood;

		// Token: 0x0400030F RID: 783
		private GroupBox gbBoardInfo;

		// Token: 0x04000310 RID: 784
		private Panel panel1;

		// Token: 0x04000311 RID: 785
		private Panel panel2;

		// Token: 0x04000312 RID: 786
		private Panel panel25;

		// Token: 0x04000313 RID: 787
		private TextBox tbHCCLot;

		// Token: 0x04000314 RID: 788
		private Label label25;

		// Token: 0x04000315 RID: 789
		private Panel panel23;

		// Token: 0x04000316 RID: 790
		private TextBox tbHCCMachine;

		// Token: 0x04000317 RID: 791
		private Label label22;

		// Token: 0x04000318 RID: 792
		private Panel panel24;

		// Token: 0x04000319 RID: 793
		private PictureBox pbImport;

		// Token: 0x0400031A RID: 794
		public RadioButton rbHwCheck;

		// Token: 0x0400031B RID: 795
		private GroupBox groupBox1;

		// Token: 0x0400031C RID: 796
		private PictureBox pbBoardInforamtion;

		// Token: 0x0400031D RID: 797
		private Panel pnBoardSite;
	}
}
