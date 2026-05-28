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

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl
{
	// Token: 0x0200001E RID: 30
	public class ApUserlInformation : UserControl
	{
		// Token: 0x0600022D RID: 557 RVA: 0x00052059 File Offset: 0x00050259
		private void pbLogin_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.login_down;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0005206C File Offset: 0x0005026C
		private void pbLogin_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.login;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0005207F File Offset: 0x0005027F
		private void pbMailList_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.mail_list;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00052092 File Offset: 0x00050292
		private void pbMailList_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.mail_list_down;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x000520A5 File Offset: 0x000502A5
		public string getTeamString()
		{
			return this.tbTeam2.Text.Trim();
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000520B7 File Offset: 0x000502B7
		public string getNameString()
		{
			return this.tbName2.Text.Trim();
		}

		// Token: 0x06000233 RID: 563 RVA: 0x000520C9 File Offset: 0x000502C9
		public string getToList()
		{
			return this.tbToList2.Text.Trim();
		}

		// Token: 0x06000234 RID: 564 RVA: 0x000520DB File Offset: 0x000502DB
		public string getCCList()
		{
			return this.tbCCList2.Text.Trim();
		}

		// Token: 0x06000235 RID: 565 RVA: 0x000520F0 File Offset: 0x000502F0
		public ApUserlInformation(FactorySettings factorySettings, cReportItem report, FactorySettings factorySetting, CIMitarAccount cimitarUser, RequestInformation ri)
		{
			this._queryMgr = new QueryMgr(factorySetting);
			this._report = report;
			this._ri = ri;
			this._factorySettings = factorySettings;
			this.InitializeComponent();
			try
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				string[] commandLineArgs = Environment.GetCommandLineArgs();
				bool flag = commandLineArgs.Length == 2 && commandLineArgs[1].ToUpper() == "DEBUG";
				if (flag)
				{
					cimitarUser._id = "jisyang01";
				}
				bool userData = cFunction.getUserData(this._report, cimitarUser._id);
				if (userData)
				{
					this.tbToList2.Text = report.sCCEmail;
					this.tbCCList2.Text = report.sToEmail;
					this.tbName2.Text = report.sApprovalName;
					this.tbTeam2.Text = report.sApprovalTeam;
				}
				else
				{
					this.cb_teamlist.Visible = true;
					this.tbTeam2.Visible = false;
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
					this._CCEmailList.Add(cEmailInfo);
				}
				for (int j = 0; j < array2.Length - 1; j++)
				{
					cEmailInfo cEmailInfo2 = new cEmailInfo();
					cEmailInfo2._sEmail = array2[j];
					this._ToEmailList.Add(cEmailInfo2);
				}
				bool flag2 = report.sReportStauts != "11" || report.sReportStauts == "96";
				if (flag2)
				{
					this.pnApLogin.Visible = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), MessageLanguage.getMessage("messagebox_error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0005233C File Offset: 0x0005053C
		private void pbMailList_Click(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.mail_list;
			MailForm mailForm = new MailForm("To Mail List", this._ri.getCategory(), this.tbTeam2.Text, this._ToEmailList, this._CCEmailList, cFunction.getMailList(this._factorySettings, this._report.sFactory));
			bool flag = mailForm.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this._ToEmailList = (List<cEmailInfo>)mailForm.getEmailList();
				this._CCEmailList = (List<cEmailInfo>)mailForm.getCCEmailList();
				bool flag2 = ((PictureBox)sender).Equals(this.pbMailList);
				if (flag2)
				{
					this.tbToList2.Text = string.Empty;
					this.tbCCList2.Text = string.Empty;
					for (int i = 0; i < this._ToEmailList.Count; i++)
					{
						TextBox textBox = this.tbToList2;
						textBox.Text = textBox.Text + this._ToEmailList[i]._sEmail.Trim() + ";" + Environment.NewLine;
					}
					for (int j = 0; j < this._CCEmailList.Count; j++)
					{
						TextBox textBox2 = this.tbCCList2;
						textBox2.Text = textBox2.Text + this._CCEmailList[j]._sEmail.Trim() + ";" + Environment.NewLine;
					}
				}
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000524C0 File Offset: 0x000506C0
		private void pbLogin_Click(object sender, EventArgs e)
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
					this.cb_teamlist.Visible = false;
					this.tbName2.ReadOnly = true;
					this.tbTeam2.Visible = true;
					this.tbName2.BackColor = Color.Gainsboro;
					this.tbTeam2.Text = this._report.sActionTeam;
					this.tbName2.Text = this._report.sActionName;
				}
				else
				{
					cFunction.getTeam(this._factorySettings, this.cb_teamlist, this._DeptMailList);
					this.cb_teamlist.Visible = true;
					this.tbName2.ReadOnly = false;
					this.tbTeam2.Visible = false;
					this.tbName2.BackColor = Color.White;
				}
			}
			login.Dispose();
		}

		// Token: 0x06000238 RID: 568 RVA: 0x000525DC File Offset: 0x000507DC
		private void cb_teamlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tbTeam2.Text = this.cb_teamlist.SelectedItem.ToString();
			this._report.sMailActionForm = this._DeptMailList[this.tbTeam2.Text.Trim()];
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0005262C File Offset: 0x0005082C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00052664 File Offset: 0x00050864
		private void InitializeComponent()
		{
			this.panel28 = new Panel();
			this.tbName2 = new TextBox();
			this.label16 = new Label();
			this.gbUserInfo = new GroupBox();
			this.pbLogin = new PictureBox();
			this.gbMailList = new GroupBox();
			this.pbMailList = new PictureBox();
			this.tbToList2 = new TextBox();
			this.cb_teamlist = new ComboBox();
			this.label15 = new Label();
			this.tbTeam2 = new TextBox();
			this.tbCCList2 = new TextBox();
			this.label24 = new Label();
			this.label25 = new Label();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.pnApLogin = new Panel();
			this.panel28.SuspendLayout();
			this.gbUserInfo.SuspendLayout();
			((ISupportInitialize)this.pbLogin).BeginInit();
			this.gbMailList.SuspendLayout();
			((ISupportInitialize)this.pbMailList).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnApLogin.SuspendLayout();
			base.SuspendLayout();
			this.panel28.Controls.Add(this.tbName2);
			this.panel28.Controls.Add(this.label16);
			this.panel28.Dock = DockStyle.Top;
			this.panel28.Location = new Point(0, 0);
			this.panel28.Name = "panel28";
			this.panel28.Padding = new Padding(0, 0, 0, 1);
			this.panel28.Size = new Size(303, 24);
			this.panel28.TabIndex = 87;
			this.tbName2.BackColor = Color.Gainsboro;
			this.tbName2.Dock = DockStyle.Fill;
			this.tbName2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbName2.Location = new Point(47, 0);
			this.tbName2.Name = "tbName2";
			this.tbName2.ReadOnly = true;
			this.tbName2.Size = new Size(256, 23);
			this.tbName2.TabIndex = 24;
			this.label16.Dock = DockStyle.Left;
			this.label16.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label16.Location = new Point(0, 0);
			this.label16.Name = "label16";
			this.label16.Size = new Size(47, 23);
			this.label16.TabIndex = 23;
			this.label16.Text = "Name";
			this.gbUserInfo.Controls.Add(this.pbLogin);
			this.gbUserInfo.Dock = DockStyle.Right;
			this.gbUserInfo.Location = new Point(141, 0);
			this.gbUserInfo.Name = "gbUserInfo";
			this.gbUserInfo.Size = new Size(81, 79);
			this.gbUserInfo.TabIndex = 89;
			this.gbUserInfo.TabStop = false;
			this.gbUserInfo.Text = "User Info";
			this.gbUserInfo.Visible = false;
			this.pbLogin.Cursor = Cursors.Hand;
			this.pbLogin.Image = Resources.login;
			this.pbLogin.Location = new Point(19, 24);
			this.pbLogin.Name = "pbLogin";
			this.pbLogin.Size = new Size(44, 44);
			this.pbLogin.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbLogin.TabIndex = 10;
			this.pbLogin.TabStop = false;
			this.pbLogin.Click += this.pbLogin_Click;
			this.pbLogin.MouseEnter += this.pbLogin_MouseEnter;
			this.pbLogin.MouseLeave += this.pbLogin_MouseLeave;
			this.gbMailList.Controls.Add(this.pbMailList);
			this.gbMailList.Dock = DockStyle.Right;
			this.gbMailList.Location = new Point(222, 0);
			this.gbMailList.Name = "gbMailList";
			this.gbMailList.Size = new Size(81, 79);
			this.gbMailList.TabIndex = 80;
			this.gbMailList.TabStop = false;
			this.gbMailList.Text = "Mail List";
			this.pbMailList.Cursor = Cursors.Hand;
			this.pbMailList.Image = Resources.mail_list;
			this.pbMailList.Location = new Point(19, 24);
			this.pbMailList.Name = "pbMailList";
			this.pbMailList.Size = new Size(44, 44);
			this.pbMailList.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbMailList.TabIndex = 71;
			this.pbMailList.TabStop = false;
			this.pbMailList.Click += this.pbMailList_Click;
			this.pbMailList.MouseEnter += this.pbMailList_MouseEnter;
			this.pbMailList.MouseLeave += this.pbMailList_MouseLeave;
			this.tbToList2.BackColor = Color.Gainsboro;
			this.tbToList2.Dock = DockStyle.Fill;
			this.tbToList2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbToList2.Location = new Point(47, 0);
			this.tbToList2.Multiline = true;
			this.tbToList2.Name = "tbToList2";
			this.tbToList2.ReadOnly = true;
			this.tbToList2.ScrollBars = ScrollBars.Vertical;
			this.tbToList2.Size = new Size(256, 99);
			this.tbToList2.TabIndex = 39;
			this.cb_teamlist.Dock = DockStyle.Fill;
			this.cb_teamlist.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_teamlist.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cb_teamlist.FormattingEnabled = true;
			this.cb_teamlist.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.cb_teamlist.Location = new Point(47, 0);
			this.cb_teamlist.Name = "cb_teamlist";
			this.cb_teamlist.Size = new Size(256, 23);
			this.cb_teamlist.TabIndex = 70;
			this.cb_teamlist.Visible = false;
			this.cb_teamlist.SelectedIndexChanged += this.cb_teamlist_SelectedIndexChanged;
			this.label15.Dock = DockStyle.Left;
			this.label15.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label15.Location = new Point(0, 0);
			this.label15.Name = "label15";
			this.label15.Size = new Size(47, 70);
			this.label15.TabIndex = 3;
			this.label15.Text = "Dept.";
			this.tbTeam2.BackColor = Color.Gainsboro;
			this.tbTeam2.Dock = DockStyle.Fill;
			this.tbTeam2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbTeam2.Location = new Point(47, 0);
			this.tbTeam2.Multiline = true;
			this.tbTeam2.Name = "tbTeam2";
			this.tbTeam2.ReadOnly = true;
			this.tbTeam2.Size = new Size(256, 70);
			this.tbTeam2.TabIndex = 4;
			this.tbCCList2.BackColor = Color.Gainsboro;
			this.tbCCList2.Dock = DockStyle.Fill;
			this.tbCCList2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbCCList2.Location = new Point(47, 0);
			this.tbCCList2.Multiline = true;
			this.tbCCList2.Name = "tbCCList2";
			this.tbCCList2.ReadOnly = true;
			this.tbCCList2.ScrollBars = ScrollBars.Vertical;
			this.tbCCList2.Size = new Size(256, 100);
			this.tbCCList2.TabIndex = 42;
			this.label24.Dock = DockStyle.Left;
			this.label24.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label24.Location = new Point(0, 0);
			this.label24.Name = "label24";
			this.label24.Size = new Size(47, 100);
			this.label24.TabIndex = 41;
			this.label24.Text = "CC List";
			this.label25.Dock = DockStyle.Left;
			this.label25.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label25.Location = new Point(0, 0);
			this.label25.Name = "label25";
			this.label25.Size = new Size(47, 99);
			this.label25.TabIndex = 40;
			this.label25.Text = "To List";
			this.panel1.Controls.Add(this.cb_teamlist);
			this.panel1.Controls.Add(this.tbTeam2);
			this.panel1.Controls.Add(this.label15);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new Padding(0, 0, 0, 1);
			this.panel1.Size = new Size(303, 71);
			this.panel1.TabIndex = 90;
			this.panel2.Controls.Add(this.tbToList2);
			this.panel2.Controls.Add(this.label25);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(0, 95);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new Padding(0, 0, 0, 1);
			this.panel2.Size = new Size(303, 100);
			this.panel2.TabIndex = 91;
			this.panel3.Controls.Add(this.tbCCList2);
			this.panel3.Controls.Add(this.label24);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(0, 195);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(303, 100);
			this.panel3.TabIndex = 92;
			this.pnApLogin.Controls.Add(this.gbUserInfo);
			this.pnApLogin.Controls.Add(this.gbMailList);
			this.pnApLogin.Dock = DockStyle.Top;
			this.pnApLogin.Location = new Point(0, 295);
			this.pnApLogin.Name = "pnApLogin";
			this.pnApLogin.Size = new Size(303, 79);
			this.pnApLogin.TabIndex = 93;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.pnApLogin);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel28);
			base.Name = "ApUserlInformation";
			base.Size = new Size(303, 376);
			this.panel28.ResumeLayout(false);
			this.panel28.PerformLayout();
			this.gbUserInfo.ResumeLayout(false);
			((ISupportInitialize)this.pbLogin).EndInit();
			this.gbMailList.ResumeLayout(false);
			((ISupportInitialize)this.pbMailList).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.pnApLogin.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400041B RID: 1051
		private QueryMgr _queryMgr;

		// Token: 0x0400041C RID: 1052
		private cReportItem _report;

		// Token: 0x0400041D RID: 1053
		private RequestInformation _ri;

		// Token: 0x0400041E RID: 1054
		private List<cEmailInfo> _ToEmailList = new List<cEmailInfo>();

		// Token: 0x0400041F RID: 1055
		private List<cEmailInfo> _CCEmailList = new List<cEmailInfo>();

		// Token: 0x04000420 RID: 1056
		private Dictionary<string, string> _DeptMailList = new Dictionary<string, string>();

		// Token: 0x04000421 RID: 1057
		private FactorySettings _factorySettings;

		// Token: 0x04000422 RID: 1058
		private IContainer components = null;

		// Token: 0x04000423 RID: 1059
		private Panel panel28;

		// Token: 0x04000424 RID: 1060
		private GroupBox gbUserInfo;

		// Token: 0x04000425 RID: 1061
		private PictureBox pbLogin;

		// Token: 0x04000426 RID: 1062
		private GroupBox gbMailList;

		// Token: 0x04000427 RID: 1063
		private PictureBox pbMailList;

		// Token: 0x04000428 RID: 1064
		private TextBox tbToList2;

		// Token: 0x04000429 RID: 1065
		private ComboBox cb_teamlist;

		// Token: 0x0400042A RID: 1066
		private Label label15;

		// Token: 0x0400042B RID: 1067
		private TextBox tbTeam2;

		// Token: 0x0400042C RID: 1068
		private Label label16;

		// Token: 0x0400042D RID: 1069
		private TextBox tbCCList2;

		// Token: 0x0400042E RID: 1070
		private TextBox tbName2;

		// Token: 0x0400042F RID: 1071
		private Label label24;

		// Token: 0x04000430 RID: 1072
		private Label label25;

		// Token: 0x04000431 RID: 1073
		private Panel panel1;

		// Token: 0x04000432 RID: 1074
		private Panel panel2;

		// Token: 0x04000433 RID: 1075
		private Panel panel3;

		// Token: 0x04000434 RID: 1076
		private Panel pnApLogin;
	}
}
