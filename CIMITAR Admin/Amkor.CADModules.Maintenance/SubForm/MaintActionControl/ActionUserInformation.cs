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

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x0200004A RID: 74
	public class ActionUserInformation : UserControl
	{
		// Token: 0x0600042B RID: 1067 RVA: 0x0007B9E1 File Offset: 0x00079BE1
		private void pbMailList_MouseEnter(object sender, EventArgs e)
		{
			this.pbMailList.Image = Resources.mail_list_down;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0007B9F4 File Offset: 0x00079BF4
		private void pbMailList_MouseLeave(object sender, EventArgs e)
		{
			this.pbMailList.Image = Resources.mail_list;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0007BA07 File Offset: 0x00079C07
		private void pbActionView_MouseEnter(object sender, EventArgs e)
		{
			this.pbActionView.Image = Resources.view_down;
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0007BA1A File Offset: 0x00079C1A
		private void pbActionView_MouseLeave(object sender, EventArgs e)
		{
			this.pbActionView.Image = Resources.view;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0007BA2D File Offset: 0x00079C2D
		private void pbLogin_MouseEnter(object sender, EventArgs e)
		{
			this.pbLogin.Image = Resources.login_down;
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0007BA40 File Offset: 0x00079C40
		private void pbLogin_MouseLeave(object sender, EventArgs e)
		{
			this.pbLogin.Image = Resources.login;
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x0007BA54 File Offset: 0x00079C54
		public ActionUserInformation(FactorySettings factorySetting, CIMitarAccount cimitarUser, cReportItem report)
		{
			this._queryMgr = new QueryMgr(factorySetting);
			this._factorySetting = factorySetting;
			this.report = report;
			this._cimitarUser = cimitarUser;
			this.InitializeComponent();
			this.tbName2.ReadOnly = true;
			this.tbTeam2.Visible = true;
			this.tbName2.BackColor = Color.Gainsboro;
			this.tbToList2.ReadOnly = true;
			this.tbCCList2.ReadOnly = true;
			bool flag = report.sReportStauts.CompareTo("1") == 0 || report.sReportStauts.CompareTo("3") == 0;
			if (flag)
			{
				this.getUserData(this._cimitarUser._id);
				this.tbToList2.Text = report.sCCEmail;
				this.tbCCList2.Text = report.sToEmail;
				this.tbName2.Text = report.sActionName;
				this.tbTeam2.Text = report.sActionTeam;
				this.tbFromAction.Text = report.sFromAction;
				this.pnView.Visible = false;
				this.pnMail.Visible = true;
			}
			else
			{
				bool flag2 = report.sReportStauts.CompareTo("2") == 0;
				if (flag2)
				{
					this.tbToList2.Text = report.sActionToList;
					this.tbCCList2.Text = report.sActionCCList;
					this.tbTeam2.Text = report.sActionTeam;
					this.tbName2.Text = report.sActionName;
					this.pnMail.Visible = false;
					this.pnView.Visible = true;
				}
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
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0007BCE0 File Offset: 0x00079EE0
		private void cb_teamlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tbTeam2.Text = this.cb_teamlist.SelectedItem.ToString();
			this.tbFromAction.Text = this._DeptMailList[this.tbTeam2.Text.Trim()];
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0007BD34 File Offset: 0x00079F34
		private void pbLogin_Click(object sender, EventArgs e)
		{
			this.pbLogin.Image = Resources.login;
			Login login = new Login();
			bool flag = login.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				CIMitarLogin._id = login.id;
				this.getUserData(login.id);
				this.tbTeam2.Text = this.report.sActionTeam;
				this.tbName2.Text = this.report.sActionName;
				this.tbFromAction.Text = this.report.sFromAction;
			}
			login.Dispose();
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0007BDCC File Offset: 0x00079FCC
		public void getUserData(string sUserID)
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			bool flag = commandLineArgs.Length == 2 && commandLineArgs[1].ToUpper() == "DEBUG";
			if (flag)
			{
				sUserID = "jisyang01";
			}
			bool flag2 = !string.IsNullOrEmpty(CIMitarLogin._id);
			if (flag2)
			{
				sUserID = CIMitarLogin._id;
			}
			string userData_SubFunc = cFunction.getUserData_SubFunc(sUserID);
			bool flag3 = userData_SubFunc.ToUpper().IndexOf("NOT EXIST") == -1;
			if (flag3)
			{
				string[] array = userData_SubFunc.Split(new char[]
				{
					';'
				});
				bool flag4 = array.Length != 0 && array.Length == 3;
				if (flag4)
				{
					this.report.sActionName = array[0];
					this.report.sActionTeam = array[1];
					this.report.sFromAction = array[2];
					this.cb_teamlist.Visible = false;
					this.tbName2.ReadOnly = true;
					this.tbTeam2.Visible = true;
					this.tbName2.BackColor = Color.Gainsboro;
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("emes_error"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				cFunction.getTeam(this._factorySetting, this.cb_teamlist, this._DeptMailList);
				this.cb_teamlist.Visible = true;
				this.tbName2.ReadOnly = false;
				this.tbTeam2.Visible = false;
				this.tbName2.BackColor = Color.White;
			}
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0007BF4C File Offset: 0x0007A14C
		private void pbMailList_Click(object sender, EventArgs e)
		{
			this.pbMailList.Image = Resources.mail_list;
			MailForm mailForm = new MailForm("To Mail List", this.report.sCategory, this.tbTeam2.Text, this._ToEmailList, this._CCEmailList, cFunction.getMailList(this._factorySetting, this.report.sFactory));
			bool flag = mailForm.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.tbToList2.Text = string.Empty;
				this.tbCCList2.Text = string.Empty;
				this._ToEmailList = (List<cEmailInfo>)mailForm.getEmailList();
				this._CCEmailList = (List<cEmailInfo>)mailForm.getCCEmailList();
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

		// Token: 0x06000436 RID: 1078 RVA: 0x0007C0B4 File Offset: 0x0007A2B4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0007C0EC File Offset: 0x0007A2EC
		private void InitializeComponent()
		{
			this.group_ActionInfo = new GroupBox();
			this.panel28 = new Panel();
			this.panel4 = new Panel();
			this.tbCCList2 = new TextBox();
			this.label24 = new Label();
			this.panel3 = new Panel();
			this.tbToList2 = new TextBox();
			this.label25 = new Label();
			this.panel2 = new Panel();
			this.cb_teamlist = new ComboBox();
			this.tbTeam2 = new TextBox();
			this.label15 = new Label();
			this.panel1 = new Panel();
			this.tbName2 = new TextBox();
			this.label16 = new Label();
			this.panel5 = new Panel();
			this.tbFromAction = new TextBox();
			this.panel6 = new Panel();
			this.pbLogin = new PictureBox();
			this.label1 = new Label();
			this.panel9 = new Panel();
			this.pnMail = new Panel();
			this.pbMailList = new PictureBox();
			this.label2 = new Label();
			this.panel10 = new Panel();
			this.pnView = new Panel();
			this.pbActionView = new PictureBox();
			this.label3 = new Label();
			this.group_ActionInfo.SuspendLayout();
			this.panel28.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			((ISupportInitialize)this.pbLogin).BeginInit();
			this.pnMail.SuspendLayout();
			((ISupportInitialize)this.pbMailList).BeginInit();
			this.pnView.SuspendLayout();
			((ISupportInitialize)this.pbActionView).BeginInit();
			base.SuspendLayout();
			this.group_ActionInfo.Controls.Add(this.panel28);
			this.group_ActionInfo.Controls.Add(this.panel5);
			this.group_ActionInfo.Dock = DockStyle.Fill;
			this.group_ActionInfo.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.group_ActionInfo.Location = new Point(0, 0);
			this.group_ActionInfo.Name = "group_ActionInfo";
			this.group_ActionInfo.Padding = new Padding(3, 0, 3, 3);
			this.group_ActionInfo.Size = new Size(368, 352);
			this.group_ActionInfo.TabIndex = 69;
			this.group_ActionInfo.TabStop = false;
			this.panel28.Controls.Add(this.panel4);
			this.panel28.Controls.Add(this.panel3);
			this.panel28.Controls.Add(this.panel2);
			this.panel28.Controls.Add(this.panel1);
			this.panel28.Dock = DockStyle.Fill;
			this.panel28.Location = new Point(3, 18);
			this.panel28.Name = "panel28";
			this.panel28.Padding = new Padding(0, 0, 3, 0);
			this.panel28.Size = new Size(362, 277);
			this.panel28.TabIndex = 73;
			this.panel4.Controls.Add(this.tbCCList2);
			this.panel4.Controls.Add(this.label24);
			this.panel4.Dock = DockStyle.Fill;
			this.panel4.Location = new Point(0, 163);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new Padding(0, 1, 0, 0);
			this.panel4.Size = new Size(359, 114);
			this.panel4.TabIndex = 86;
			this.tbCCList2.BackColor = Color.Gainsboro;
			this.tbCCList2.Dock = DockStyle.Fill;
			this.tbCCList2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbCCList2.Location = new Point(47, 1);
			this.tbCCList2.Multiline = true;
			this.tbCCList2.Name = "tbCCList2";
			this.tbCCList2.ReadOnly = true;
			this.tbCCList2.ScrollBars = ScrollBars.Vertical;
			this.tbCCList2.Size = new Size(312, 113);
			this.tbCCList2.TabIndex = 42;
			this.label24.Dock = DockStyle.Left;
			this.label24.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label24.Location = new Point(0, 1);
			this.label24.Name = "label24";
			this.label24.Size = new Size(47, 113);
			this.label24.TabIndex = 41;
			this.label24.Text = "CC List";
			this.panel3.Controls.Add(this.tbToList2);
			this.panel3.Controls.Add(this.label25);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(0, 70);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new Padding(0, 1, 0, 0);
			this.panel3.Size = new Size(359, 93);
			this.panel3.TabIndex = 92;
			this.tbToList2.BackColor = Color.Gainsboro;
			this.tbToList2.Dock = DockStyle.Fill;
			this.tbToList2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbToList2.Location = new Point(47, 1);
			this.tbToList2.Multiline = true;
			this.tbToList2.Name = "tbToList2";
			this.tbToList2.ReadOnly = true;
			this.tbToList2.ScrollBars = ScrollBars.Vertical;
			this.tbToList2.Size = new Size(312, 92);
			this.tbToList2.TabIndex = 39;
			this.label25.Dock = DockStyle.Left;
			this.label25.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label25.Location = new Point(0, 1);
			this.label25.Name = "label25";
			this.label25.Size = new Size(47, 92);
			this.label25.TabIndex = 40;
			this.label25.Text = "To List";
			this.panel2.Controls.Add(this.cb_teamlist);
			this.panel2.Controls.Add(this.tbTeam2);
			this.panel2.Controls.Add(this.label15);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(0, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(359, 46);
			this.panel2.TabIndex = 91;
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
			this.cb_teamlist.Size = new Size(312, 23);
			this.cb_teamlist.TabIndex = 70;
			this.cb_teamlist.Visible = false;
			this.cb_teamlist.SelectedIndexChanged += this.cb_teamlist_SelectedIndexChanged;
			this.tbTeam2.BackColor = Color.Gainsboro;
			this.tbTeam2.Dock = DockStyle.Fill;
			this.tbTeam2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbTeam2.Location = new Point(47, 0);
			this.tbTeam2.Multiline = true;
			this.tbTeam2.Name = "tbTeam2";
			this.tbTeam2.ReadOnly = true;
			this.tbTeam2.Size = new Size(312, 46);
			this.tbTeam2.TabIndex = 4;
			this.label15.Dock = DockStyle.Left;
			this.label15.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label15.Location = new Point(0, 0);
			this.label15.Name = "label15";
			this.label15.Size = new Size(47, 46);
			this.label15.TabIndex = 3;
			this.label15.Text = "Dept.";
			this.panel1.Controls.Add(this.tbName2);
			this.panel1.Controls.Add(this.label16);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(359, 24);
			this.panel1.TabIndex = 90;
			this.tbName2.BackColor = Color.Gainsboro;
			this.tbName2.Dock = DockStyle.Fill;
			this.tbName2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbName2.Location = new Point(47, 0);
			this.tbName2.Name = "tbName2";
			this.tbName2.ReadOnly = true;
			this.tbName2.Size = new Size(312, 23);
			this.tbName2.TabIndex = 24;
			this.label16.Dock = DockStyle.Left;
			this.label16.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label16.Location = new Point(0, 0);
			this.label16.Name = "label16";
			this.label16.Size = new Size(47, 24);
			this.label16.TabIndex = 23;
			this.label16.Text = "Name";
			this.panel5.Controls.Add(this.tbFromAction);
			this.panel5.Controls.Add(this.panel6);
			this.panel5.Controls.Add(this.panel9);
			this.panel5.Controls.Add(this.pnMail);
			this.panel5.Controls.Add(this.panel10);
			this.panel5.Controls.Add(this.pnView);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(3, 295);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new Padding(0, 0, 3, 3);
			this.panel5.Size = new Size(362, 54);
			this.panel5.TabIndex = 93;
			this.tbFromAction.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbFromAction.Location = new Point(47, 30);
			this.tbFromAction.Name = "tbFromAction";
			this.tbFromAction.Size = new Size(140, 25);
			this.tbFromAction.TabIndex = 62;
			this.tbFromAction.Visible = false;
			this.panel6.Controls.Add(this.pbLogin);
			this.panel6.Controls.Add(this.label1);
			this.panel6.Dock = DockStyle.Right;
			this.panel6.ImeMode = ImeMode.NoControl;
			this.panel6.Location = new Point(222, 0);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new Padding(0, 0, 1, 0);
			this.panel6.Size = new Size(39, 51);
			this.panel6.TabIndex = 90;
			this.panel6.Visible = false;
			this.pbLogin.Cursor = Cursors.Hand;
			this.pbLogin.Dock = DockStyle.Fill;
			this.pbLogin.Image = Resources.login;
			this.pbLogin.Location = new Point(0, 13);
			this.pbLogin.Name = "pbLogin";
			this.pbLogin.Size = new Size(38, 38);
			this.pbLogin.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbLogin.TabIndex = 10;
			this.pbLogin.TabStop = false;
			this.pbLogin.Click += this.pbLogin_Click;
			this.pbLogin.MouseEnter += this.pbLogin_MouseEnter;
			this.pbLogin.MouseLeave += this.pbLogin_MouseLeave;
			this.label1.Dock = DockStyle.Top;
			this.label1.Font = new Font("Segoe UI Symbol", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(38, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Login";
			this.panel9.Dock = DockStyle.Right;
			this.panel9.Location = new Point(261, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new Size(10, 51);
			this.panel9.TabIndex = 91;
			this.pnMail.Controls.Add(this.pbMailList);
			this.pnMail.Controls.Add(this.label2);
			this.pnMail.Dock = DockStyle.Right;
			this.pnMail.Location = new Point(271, 0);
			this.pnMail.Name = "pnMail";
			this.pnMail.Size = new Size(38, 51);
			this.pnMail.TabIndex = 72;
			this.pbMailList.Cursor = Cursors.Hand;
			this.pbMailList.Dock = DockStyle.Fill;
			this.pbMailList.Image = Resources.mail_list;
			this.pbMailList.Location = new Point(0, 13);
			this.pbMailList.Name = "pbMailList";
			this.pbMailList.Size = new Size(38, 38);
			this.pbMailList.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbMailList.TabIndex = 71;
			this.pbMailList.TabStop = false;
			this.pbMailList.Click += this.pbMailList_Click;
			this.pbMailList.MouseEnter += this.pbMailList_MouseEnter;
			this.pbMailList.MouseLeave += this.pbMailList_MouseLeave;
			this.label2.Dock = DockStyle.Top;
			this.label2.Font = new Font("Segoe UI Symbol", 9f);
			this.label2.Location = new Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(38, 13);
			this.label2.TabIndex = 72;
			this.label2.Text = "Mail";
			this.panel10.Dock = DockStyle.Right;
			this.panel10.Location = new Point(309, 0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new Size(10, 51);
			this.panel10.TabIndex = 92;
			this.pnView.Controls.Add(this.pbActionView);
			this.pnView.Controls.Add(this.label3);
			this.pnView.Dock = DockStyle.Right;
			this.pnView.Location = new Point(319, 0);
			this.pnView.Name = "pnView";
			this.pnView.Size = new Size(40, 51);
			this.pnView.TabIndex = 84;
			this.pbActionView.Cursor = Cursors.Hand;
			this.pbActionView.Dock = DockStyle.Fill;
			this.pbActionView.Image = Resources.view;
			this.pbActionView.Location = new Point(0, 12);
			this.pbActionView.Name = "pbActionView";
			this.pbActionView.Padding = new Padding(3);
			this.pbActionView.Size = new Size(40, 39);
			this.pbActionView.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbActionView.TabIndex = 83;
			this.pbActionView.TabStop = false;
			this.pbActionView.MouseEnter += this.pbActionView_MouseEnter;
			this.pbActionView.MouseLeave += this.pbActionView_MouseLeave;
			this.label3.Dock = DockStyle.Top;
			this.label3.Font = new Font("Segoe UI Symbol", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(40, 12);
			this.label3.TabIndex = 84;
			this.label3.Text = "View";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.group_ActionInfo);
			base.Name = "ActionUserInformation";
			base.Size = new Size(368, 352);
			this.group_ActionInfo.ResumeLayout(false);
			this.panel28.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel6.ResumeLayout(false);
			((ISupportInitialize)this.pbLogin).EndInit();
			this.pnMail.ResumeLayout(false);
			((ISupportInitialize)this.pbMailList).EndInit();
			this.pnView.ResumeLayout(false);
			((ISupportInitialize)this.pbActionView).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000699 RID: 1689
		private Dictionary<string, string> _DeptMailList = new Dictionary<string, string>();

		// Token: 0x0400069A RID: 1690
		private List<cEmailInfo> _ToEmailList = new List<cEmailInfo>();

		// Token: 0x0400069B RID: 1691
		private List<cEmailInfo> _CCEmailList = new List<cEmailInfo>();

		// Token: 0x0400069C RID: 1692
		private QueryMgr _queryMgr = null;

		// Token: 0x0400069D RID: 1693
		private CIMitarAccount _cimitarUser;

		// Token: 0x0400069E RID: 1694
		private cReportItem report;

		// Token: 0x0400069F RID: 1695
		private FactorySettings _factorySetting;

		// Token: 0x040006A0 RID: 1696
		private IContainer components = null;

		// Token: 0x040006A1 RID: 1697
		private GroupBox group_ActionInfo;

		// Token: 0x040006A2 RID: 1698
		private TextBox tbFromAction;

		// Token: 0x040006A3 RID: 1699
		private Panel panel28;

		// Token: 0x040006A4 RID: 1700
		private PictureBox pbLogin;

		// Token: 0x040006A5 RID: 1701
		private PictureBox pbMailList;

		// Token: 0x040006A6 RID: 1702
		private Panel panel4;

		// Token: 0x040006A7 RID: 1703
		private Label label24;

		// Token: 0x040006A8 RID: 1704
		private Panel panel3;

		// Token: 0x040006A9 RID: 1705
		private Label label25;

		// Token: 0x040006AA RID: 1706
		private Panel panel2;

		// Token: 0x040006AB RID: 1707
		private Label label15;

		// Token: 0x040006AC RID: 1708
		private Panel panel1;

		// Token: 0x040006AD RID: 1709
		private Label label16;

		// Token: 0x040006AE RID: 1710
		private Panel panel6;

		// Token: 0x040006AF RID: 1711
		private Panel pnMail;

		// Token: 0x040006B0 RID: 1712
		private Panel pnView;

		// Token: 0x040006B1 RID: 1713
		private Label label1;

		// Token: 0x040006B2 RID: 1714
		private Label label2;

		// Token: 0x040006B3 RID: 1715
		private Panel panel9;

		// Token: 0x040006B4 RID: 1716
		private Label label3;

		// Token: 0x040006B5 RID: 1717
		private Panel panel10;

		// Token: 0x040006B6 RID: 1718
		public PictureBox pbActionView;

		// Token: 0x040006B7 RID: 1719
		private Panel panel5;

		// Token: 0x040006B8 RID: 1720
		public ComboBox cb_teamlist;

		// Token: 0x040006B9 RID: 1721
		public TextBox tbTeam2;

		// Token: 0x040006BA RID: 1722
		public TextBox tbName2;

		// Token: 0x040006BB RID: 1723
		public TextBox tbCCList2;

		// Token: 0x040006BC RID: 1724
		public TextBox tbToList2;
	}
}
