using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.Properties;
using Amkor.CADModules.Maintenance.SubForm.SubControl;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Action
{
	// Token: 0x0200002C RID: 44
	public class ActionUserInformation : UserControl
	{
		// Token: 0x060002CE RID: 718 RVA: 0x0005F7E4 File Offset: 0x0005D9E4
		public string getTeamString()
		{
			return this.tbTeam3.Text.Trim();
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0005F7F6 File Offset: 0x0005D9F6
		public string getNameString()
		{
			return this.tbName3.Text.Trim();
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0005F808 File Offset: 0x0005DA08
		public string getToString()
		{
			return this.tbToList3.Text.Trim();
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0005F81A File Offset: 0x0005DA1A
		public string getCCString()
		{
			return this.tbCCList3.Text.Trim();
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00052059 File Offset: 0x00050259
		private void pbLogin2_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.login_down;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00052092 File Offset: 0x00050292
		private void pbMailList2_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.mail_list_down;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0005207F File Offset: 0x0005027F
		private void pbMailList2_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.mail_list;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0005206C File Offset: 0x0005026C
		private void pbLogin2_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.login;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0005F82C File Offset: 0x0005DA2C
		public ActionUserInformation(cReportItem report, FactorySettings factorySettings, CIMitarAccount cimitarUser, RequestInformation ri, ApUserlInformation apri)
		{
			this._apri = apri;
			this._report = report;
			this._ri = ri;
			this._factorySettings = factorySettings;
			this._queryMgr = new QueryMgr(factorySettings);
			this.InitializeComponent();
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			bool flag = commandLineArgs.Length == 2 && commandLineArgs[1].ToUpper() == "DEBUG";
			if (flag)
			{
				cimitarUser._id = "jisyang01";
			}
			string[] array = report.sToEmail.Split(new char[]
			{
				';'
			});
			string[] array2 = report.sCCEmail.Split(new char[]
			{
				';'
			});
			for (int i = 0; i < array.Length - 1; i++)
			{
				cEmailInfo cEmailInfo = new cEmailInfo();
				cEmailInfo._sEmail = array[i];
				this._ToEmailList.Add(cEmailInfo);
			}
			for (int j = 0; j < array2.Length - 1; j++)
			{
				cEmailInfo cEmailInfo2 = new cEmailInfo();
				cEmailInfo2._sEmail = array2[j];
				this._CCEmailList.Add(cEmailInfo2);
			}
			bool flag2 = report.sReportStauts == "11";
			if (!flag2)
			{
				bool flag3 = report.sReportStauts == "12";
				if (flag3)
				{
					bool userData = cFunction.getUserData(this._report, cimitarUser._id);
					if (userData)
					{
						this.tbToList3.Text = report.sToEmail;
						this.tbCCList3.Text = report.sCCEmail;
						this.tbName3.Text = report.sActionName;
						this.tbTeam3.Text = report.sActionTeam;
					}
					else
					{
						this.tbTeam3.Visible = false;
						this.cb_teamlist3.Visible = true;
						this.gbMail3.Visible = false;
					}
				}
				else
				{
					bool flag4 = report.sReportStauts == "13" || report.sReportStauts == "14";
					if (flag4)
					{
						this.gbLogin3.Visible = false;
						this.gbMail3.Visible = false;
						this.tbToList3.Text = report.sToEmail;
						this.tbCCList3.Text = report.sCCEmail;
						this.tbName3.Text = report.sPMDoneName;
						this.tbTeam3.Text = report.sPMDoneTeam;
					}
					else
					{
						bool flag5 = report.sReportStauts == "97" || report.sReportStauts == "98";
						if (flag5)
						{
						}
					}
				}
			}
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0005FAFC File Offset: 0x0005DCFC
		private void pbLogin2_Click(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.login;
			Login login = new Login();
			bool flag = login.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				bool userData = cFunction.getUserData(this._report, login.id);
				if (userData)
				{
					CIMitarLogin._id = login.id;
					this.cb_teamlist3.Visible = false;
					this.tbName3.ReadOnly = true;
					this.tbTeam3.Visible = true;
					this.tbName3.BackColor = Color.Gainsboro;
					this.tbName3.Text = this._report.sPMDoneName;
					this.tbTeam3.Text = this._report.sPMDoneTeam;
				}
				else
				{
					cFunction.getTeam(this._factorySettings, this.cb_teamlist3, this._DeptMailList);
					this.cb_teamlist3.Visible = true;
					this.tbName3.ReadOnly = false;
					this.tbTeam3.Visible = false;
					this.tbName3.BackColor = Color.White;
				}
			}
			login.Dispose();
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0005FC18 File Offset: 0x0005DE18
		public bool checkTeam()
		{
			return this.cb_teamlist3.Visible && this.cb_teamlist3.SelectedIndex == -1;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0005FC54 File Offset: 0x0005DE54
		private void cb_teamlist3_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tbTeam3.Text = this.cb_teamlist3.SelectedItem.ToString();
			this._report.sMailActionForm = this._DeptMailList[this.tbTeam3.Text.Trim()];
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0005FCA4 File Offset: 0x0005DEA4
		private void pbMailList2_Click(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.mail_list;
			MailForm mailForm = new MailForm("To Mail List", this._ri.getCategory(), this._apri.getTeamString(), this._ToEmailList, this._CCEmailList, cFunction.getMailList(this._factorySettings, this._report.sFactory));
			bool flag = mailForm.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this._ToEmailList = (List<cEmailInfo>)mailForm.getEmailList();
				this._CCEmailList = (List<cEmailInfo>)mailForm.getCCEmailList();
				bool flag2 = ((PictureBox)sender).Equals(this.pbMailList2);
				if (flag2)
				{
					this.tbToList3.Text = string.Empty;
					this.tbCCList3.Text = string.Empty;
					for (int i = 0; i < this._ToEmailList.Count; i++)
					{
						TextBox textBox = this.tbToList3;
						textBox.Text = textBox.Text + this._ToEmailList[i]._sEmail.Trim() + ";" + Environment.NewLine;
					}
					for (int j = 0; j < this._CCEmailList.Count; j++)
					{
						TextBox textBox2 = this.tbCCList3;
						textBox2.Text = textBox2.Text + this._CCEmailList[j]._sEmail.Trim() + ";" + Environment.NewLine;
					}
				}
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0005FE28 File Offset: 0x0005E028
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0005FE60 File Offset: 0x0005E060
		private void InitializeComponent()
		{
			this.panel14 = new Panel();
			this.pnActionLogin = new Panel();
			this.gbLogin3 = new GroupBox();
			this.pbLogin2 = new PictureBox();
			this.gbMail3 = new GroupBox();
			this.pbMailList2 = new PictureBox();
			this.panel4 = new Panel();
			this.tbCCList3 = new TextBox();
			this.label23 = new Label();
			this.panel3 = new Panel();
			this.tbToList3 = new TextBox();
			this.label27 = new Label();
			this.panel2 = new Panel();
			this.cb_teamlist3 = new ComboBox();
			this.tbTeam3 = new TextBox();
			this.label14 = new Label();
			this.panel1 = new Panel();
			this.tbName3 = new TextBox();
			this.label22 = new Label();
			this.panel14.SuspendLayout();
			this.pnActionLogin.SuspendLayout();
			this.gbLogin3.SuspendLayout();
			((ISupportInitialize)this.pbLogin2).BeginInit();
			this.gbMail3.SuspendLayout();
			((ISupportInitialize)this.pbMailList2).BeginInit();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel14.Controls.Add(this.pnActionLogin);
			this.panel14.Controls.Add(this.panel4);
			this.panel14.Controls.Add(this.panel3);
			this.panel14.Controls.Add(this.panel2);
			this.panel14.Controls.Add(this.panel1);
			this.panel14.Dock = DockStyle.Fill;
			this.panel14.Location = new Point(0, 0);
			this.panel14.Name = "panel14";
			this.panel14.Size = new Size(299, 416);
			this.panel14.TabIndex = 88;
			this.pnActionLogin.Controls.Add(this.gbLogin3);
			this.pnActionLogin.Controls.Add(this.gbMail3);
			this.pnActionLogin.Dock = DockStyle.Top;
			this.pnActionLogin.Location = new Point(0, 271);
			this.pnActionLogin.Name = "pnActionLogin";
			this.pnActionLogin.Size = new Size(299, 71);
			this.pnActionLogin.TabIndex = 11;
			this.gbLogin3.Controls.Add(this.pbLogin2);
			this.gbLogin3.Dock = DockStyle.Right;
			this.gbLogin3.Location = new Point(137, 0);
			this.gbLogin3.Name = "gbLogin3";
			this.gbLogin3.Size = new Size(81, 71);
			this.gbLogin3.TabIndex = 89;
			this.gbLogin3.TabStop = false;
			this.gbLogin3.Text = "User Info";
			this.gbLogin3.Visible = false;
			this.pbLogin2.Cursor = Cursors.Hand;
			this.pbLogin2.Image = Resources.login;
			this.pbLogin2.Location = new Point(18, 20);
			this.pbLogin2.Name = "pbLogin2";
			this.pbLogin2.Size = new Size(44, 44);
			this.pbLogin2.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbLogin2.TabIndex = 10;
			this.pbLogin2.TabStop = false;
			this.pbLogin2.Click += this.pbLogin2_Click;
			this.pbLogin2.MouseEnter += this.pbLogin2_MouseEnter;
			this.pbLogin2.MouseLeave += this.pbLogin2_MouseLeave;
			this.gbMail3.Controls.Add(this.pbMailList2);
			this.gbMail3.Dock = DockStyle.Right;
			this.gbMail3.Location = new Point(218, 0);
			this.gbMail3.Name = "gbMail3";
			this.gbMail3.Size = new Size(81, 71);
			this.gbMail3.TabIndex = 80;
			this.gbMail3.TabStop = false;
			this.gbMail3.Text = "Mail List";
			this.pbMailList2.Cursor = Cursors.Hand;
			this.pbMailList2.Image = Resources.mail_list;
			this.pbMailList2.Location = new Point(19, 20);
			this.pbMailList2.Name = "pbMailList2";
			this.pbMailList2.Size = new Size(44, 44);
			this.pbMailList2.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbMailList2.TabIndex = 71;
			this.pbMailList2.TabStop = false;
			this.pbMailList2.Click += this.pbMailList2_Click;
			this.pbMailList2.MouseEnter += this.pbMailList2_MouseEnter;
			this.pbMailList2.MouseLeave += this.pbMailList2_MouseLeave;
			this.panel4.Controls.Add(this.tbCCList3);
			this.panel4.Controls.Add(this.label23);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(0, 171);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new Padding(0, 0, 0, 1);
			this.panel4.Size = new Size(299, 100);
			this.panel4.TabIndex = 92;
			this.tbCCList3.BackColor = Color.Gainsboro;
			this.tbCCList3.Dock = DockStyle.Fill;
			this.tbCCList3.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbCCList3.Location = new Point(47, 0);
			this.tbCCList3.Multiline = true;
			this.tbCCList3.Name = "tbCCList3";
			this.tbCCList3.ReadOnly = true;
			this.tbCCList3.ScrollBars = ScrollBars.Vertical;
			this.tbCCList3.Size = new Size(252, 99);
			this.tbCCList3.TabIndex = 42;
			this.label23.Dock = DockStyle.Left;
			this.label23.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label23.Location = new Point(0, 0);
			this.label23.Name = "label23";
			this.label23.Size = new Size(47, 99);
			this.label23.TabIndex = 41;
			this.label23.Text = "CC List";
			this.panel3.Controls.Add(this.tbToList3);
			this.panel3.Controls.Add(this.label27);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(0, 71);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new Padding(0, 0, 0, 1);
			this.panel3.Size = new Size(299, 100);
			this.panel3.TabIndex = 91;
			this.tbToList3.BackColor = Color.Gainsboro;
			this.tbToList3.Dock = DockStyle.Fill;
			this.tbToList3.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbToList3.Location = new Point(47, 0);
			this.tbToList3.Multiline = true;
			this.tbToList3.Name = "tbToList3";
			this.tbToList3.ReadOnly = true;
			this.tbToList3.ScrollBars = ScrollBars.Vertical;
			this.tbToList3.Size = new Size(252, 99);
			this.tbToList3.TabIndex = 39;
			this.label27.Dock = DockStyle.Left;
			this.label27.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label27.Location = new Point(0, 0);
			this.label27.Name = "label27";
			this.label27.Size = new Size(47, 99);
			this.label27.TabIndex = 40;
			this.label27.Text = "To List";
			this.panel2.Controls.Add(this.cb_teamlist3);
			this.panel2.Controls.Add(this.tbTeam3);
			this.panel2.Controls.Add(this.label14);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(0, 28);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new Padding(0, 0, 0, 1);
			this.panel2.Size = new Size(299, 43);
			this.panel2.TabIndex = 90;
			this.cb_teamlist3.Dock = DockStyle.Fill;
			this.cb_teamlist3.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_teamlist3.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cb_teamlist3.FormattingEnabled = true;
			this.cb_teamlist3.Location = new Point(47, 0);
			this.cb_teamlist3.Name = "cb_teamlist3";
			this.cb_teamlist3.Size = new Size(252, 23);
			this.cb_teamlist3.TabIndex = 70;
			this.cb_teamlist3.Visible = false;
			this.cb_teamlist3.SelectedIndexChanged += this.cb_teamlist3_SelectedIndexChanged;
			this.tbTeam3.BackColor = Color.Gainsboro;
			this.tbTeam3.Dock = DockStyle.Fill;
			this.tbTeam3.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbTeam3.Location = new Point(47, 0);
			this.tbTeam3.Multiline = true;
			this.tbTeam3.Name = "tbTeam3";
			this.tbTeam3.ReadOnly = true;
			this.tbTeam3.Size = new Size(252, 42);
			this.tbTeam3.TabIndex = 4;
			this.label14.Dock = DockStyle.Left;
			this.label14.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label14.Location = new Point(0, 0);
			this.label14.Name = "label14";
			this.label14.Size = new Size(47, 42);
			this.label14.TabIndex = 3;
			this.label14.Text = "Dept.";
			this.panel1.Controls.Add(this.tbName3);
			this.panel1.Controls.Add(this.label22);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(299, 28);
			this.panel1.TabIndex = 89;
			this.tbName3.BackColor = Color.Gainsboro;
			this.tbName3.Dock = DockStyle.Top;
			this.tbName3.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbName3.Location = new Point(46, 0);
			this.tbName3.Name = "tbName3";
			this.tbName3.ReadOnly = true;
			this.tbName3.Size = new Size(253, 23);
			this.tbName3.TabIndex = 24;
			this.label22.Dock = DockStyle.Left;
			this.label22.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label22.Location = new Point(0, 0);
			this.label22.Name = "label22";
			this.label22.Size = new Size(46, 28);
			this.label22.TabIndex = 23;
			this.label22.Text = "Name";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel14);
			base.Name = "ActionUserInformation";
			base.Size = new Size(299, 416);
			this.panel14.ResumeLayout(false);
			this.pnActionLogin.ResumeLayout(false);
			this.gbLogin3.ResumeLayout(false);
			((ISupportInitialize)this.pbLogin2).EndInit();
			this.gbMail3.ResumeLayout(false);
			((ISupportInitialize)this.pbMailList2).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000502 RID: 1282
		private QueryMgr _queryMgr;

		// Token: 0x04000503 RID: 1283
		private cReportItem _report;

		// Token: 0x04000504 RID: 1284
		private Dictionary<string, string> _DeptMailList = new Dictionary<string, string>();

		// Token: 0x04000505 RID: 1285
		private List<cEmailInfo> _ToEmailList = new List<cEmailInfo>();

		// Token: 0x04000506 RID: 1286
		private List<cEmailInfo> _CCEmailList = new List<cEmailInfo>();

		// Token: 0x04000507 RID: 1287
		private RequestInformation _ri;

		// Token: 0x04000508 RID: 1288
		private ApUserlInformation _apri;

		// Token: 0x04000509 RID: 1289
		private FactorySettings _factorySettings;

		// Token: 0x0400050A RID: 1290
		private IContainer components = null;

		// Token: 0x0400050B RID: 1291
		private Panel panel14;

		// Token: 0x0400050C RID: 1292
		private GroupBox gbLogin3;

		// Token: 0x0400050D RID: 1293
		private PictureBox pbLogin2;

		// Token: 0x0400050E RID: 1294
		private GroupBox gbMail3;

		// Token: 0x0400050F RID: 1295
		private PictureBox pbMailList2;

		// Token: 0x04000510 RID: 1296
		private TextBox tbToList3;

		// Token: 0x04000511 RID: 1297
		private ComboBox cb_teamlist3;

		// Token: 0x04000512 RID: 1298
		private Label label14;

		// Token: 0x04000513 RID: 1299
		private TextBox tbTeam3;

		// Token: 0x04000514 RID: 1300
		private Label label22;

		// Token: 0x04000515 RID: 1301
		private TextBox tbCCList3;

		// Token: 0x04000516 RID: 1302
		private TextBox tbName3;

		// Token: 0x04000517 RID: 1303
		private Label label23;

		// Token: 0x04000518 RID: 1304
		private Label label27;

		// Token: 0x04000519 RID: 1305
		private Panel panel2;

		// Token: 0x0400051A RID: 1306
		private Panel panel1;

		// Token: 0x0400051B RID: 1307
		private Panel panel4;

		// Token: 0x0400051C RID: 1308
		private Panel panel3;

		// Token: 0x0400051D RID: 1309
		private Panel pnActionLogin;
	}
}
