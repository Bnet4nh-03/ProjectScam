using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.Properties;
using Amkor.CADModules.Maintenance.SubForm.SubControl;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.PMRequestSubControl
{
	// Token: 0x0200001C RID: 28
	public class PMUserInformation : UserControl
	{
		// Token: 0x0600020D RID: 525 RVA: 0x0004F8E9 File Offset: 0x0004DAE9
		private void pbMailList_MouseEnter(object sender, EventArgs e)
		{
			this.pbMailList.Image = Resources.mail_list_down;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0004F8FC File Offset: 0x0004DAFC
		private void pbMailList_MouseLeave(object sender, EventArgs e)
		{
			this.pbMailList.Image = Resources.mail_list;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0004F90F File Offset: 0x0004DB0F
		private void pbLogin_MouseEnter(object sender, EventArgs e)
		{
			this.pbLogin.Image = Resources.login_down;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0004F922 File Offset: 0x0004DB22
		private void pbLogin_MouseLeave(object sender, EventArgs e)
		{
			this.pbLogin.Image = Resources.login;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0004F935 File Offset: 0x0004DB35
		public string getTeam()
		{
			return this.tbTeam.Text.Trim().ToUpper();
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0004F94C File Offset: 0x0004DB4C
		public string getToMail()
		{
			return this.tbToList.Text.Trim();
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0004F95E File Offset: 0x0004DB5E
		public string getCCMail()
		{
			return this.tbCCList.Text.Trim();
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0004F970 File Offset: 0x0004DB70
		public string getName()
		{
			return this.tbName.Text.Trim();
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0004F982 File Offset: 0x0004DB82
		public void setFactory(string factory)
		{
			this._factory = factory;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0004F98B File Offset: 0x0004DB8B
		public void setCategory(string category)
		{
			this._category = category;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0004F994 File Offset: 0x0004DB94
		public void setPMInformation(PMInformation pi)
		{
			this._pi = pi;
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0004F99D File Offset: 0x0004DB9D
		public string fromMail()
		{
			return this.tbFrom.Text.Trim();
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0004F9B0 File Offset: 0x0004DBB0
		public PMUserInformation(cReportItem report, FactorySettings factorySettings)
		{
			this._report = report;
			this._factorySettings = factorySettings;
			this.queryMgr = new QueryMgr(factorySettings);
			this.InitializeComponent();
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0004FA24 File Offset: 0x0004DC24
		public void setLogin(cReportItem report)
		{
			this.tbName.Text = report.sName;
			this.tbTeam.Text = report.sTeam;
			this.tbFrom.Text = report.sFrom;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0004FA5D File Offset: 0x0004DC5D
		public void clear()
		{
			this._ToEmailList.Clear();
			this._CCEmailList.Clear();
			this.tbCCList.Text = "";
			this.tbToList.Text = "";
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0004FA9C File Offset: 0x0004DC9C
		private void getTeamFromDB()
		{
			this.cb_teamlist.Items.Clear();
			this._DeptMailList.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintTeamInfo]";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.cb_teamlist.Items.Add(dataSet.Tables[0].Rows[i]["Name"].ToString());
					this._DeptMailList.Add(dataSet.Tables[0].Rows[i]["Name"].ToString(), dataSet.Tables[0].Rows[i]["Mail"].ToString());
				}
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0004FBB8 File Offset: 0x0004DDB8
		public void getToGroupList()
		{
			this._ToEmailList.Clear();
			this.tbToList.Text = "";
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintEmailGroup] @_Plant=N'" + this._factory + "'";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					cEmailInfo cEmailInfo = new cEmailInfo();
					bool flag2 = dataSet.Tables[0].Rows[i]["Category"].ToString().CompareTo(this._category) == 0 && dataSet.Tables[0].Rows[i]["Plant"].ToString().CompareTo(this._factory) == 0;
					if (flag2)
					{
						string[] array = dataSet.Tables[0].Rows[i]["MailList"].ToString().Split(new char[]
						{
							';'
						});
						for (int j = 0; j < array.Length; j++)
						{
							cEmailInfo._sEmail = array[j];
							this._ToEmailList.Add(cEmailInfo);
						}
					}
				}
				for (int k = 0; k < this._ToEmailList.Count; k++)
				{
					TextBox textBox = this.tbToList;
					textBox.Text = textBox.Text + this._ToEmailList[k]._sEmail.Trim() + ";" + Environment.NewLine;
				}
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0004FD94 File Offset: 0x0004DF94
		public void getUserData(string sUserID)
		{
			string userData_SubFunc = cFunction.getUserData_SubFunc(sUserID);
			bool flag = userData_SubFunc.ToUpper().IndexOf("NOT EXIST") == -1;
			if (flag)
			{
				string[] array = userData_SubFunc.Split(new char[]
				{
					';'
				});
				bool flag2 = array.Length != 0 && array.Length == 3;
				if (flag2)
				{
					this.tbName.Text = array[0];
					this.tbTeam.Text = array[1];
					this.tbFrom.Text = array[2];
					this._report.sReportName = array[0];
					this._report.sTeam = array[1];
					this.cb_teamlist.Visible = false;
					this.tbTeam.Visible = true;
					this.tbTeam.SelectionStart = 0;
					this.tbName.ReadOnly = true;
					this.tbName.BackColor = Color.Gainsboro;
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("emes_error"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				cFunction.getTeam(this._factorySettings, this.cb_teamlist, this._DeptMailList);
				this.cb_teamlist.Visible = true;
				this.tbTeam.Visible = false;
				this.tbName.ReadOnly = false;
				this.tbName.BackColor = Color.White;
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0004FEF0 File Offset: 0x0004E0F0
		public void manualLogin()
		{
			cFunction.getTeam(this._factorySettings, this.cb_teamlist, this._DeptMailList);
			this.cb_teamlist.Visible = true;
			this.tbTeam.Visible = false;
			this.tbName.ReadOnly = false;
			this.tbName.BackColor = Color.White;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0004FF50 File Offset: 0x0004E150
		public void getCCMailList()
		{
			this._CCEmailList.Clear();
			this.tbCCList.Text = "";
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintEmailGroup]";
			text += " @_command=N'CCMail'";
			text = text + ", @_Category=N'" + this._category + "'";
			text = text + ", @_Plant=N'" + this._factory + "'";
			DataSet dataSet = this.queryMgr.queryCall(text);
			bool flag = dataSet != null && dataSet.Tables.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					cEmailInfo cEmailInfo = new cEmailInfo();
					bool flag2 = dataSet.Tables[0].Rows[i]["Category"].ToString().CompareTo(this._category) == 0 && dataSet.Tables[0].Rows[i]["Plant"].ToString().CompareTo(this._factory) == 0;
					if (flag2)
					{
						string[] array = dataSet.Tables[0].Rows[i]["MailList"].ToString().Split(new char[]
						{
							';'
						});
						for (int j = 0; j < array.Length; j++)
						{
							cEmailInfo._sEmail = array[j];
							this._CCEmailList.Add(cEmailInfo);
						}
					}
				}
				for (int k = 0; k < this._CCEmailList.Count; k++)
				{
					TextBox textBox = this.tbCCList;
					textBox.Text = textBox.Text + this._CCEmailList[k]._sEmail.Trim() + ";" + Environment.NewLine;
				}
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00050154 File Offset: 0x0004E354
		public bool checkTeam()
		{
			return this.cb_teamlist.Visible && this.cb_teamlist.SelectedIndex == -1;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00050190 File Offset: 0x0004E390
		private void pbMailList_Click(object sender, EventArgs e)
		{
			MailForm mailForm = new MailForm("To Mail List", this._category, this.tbTeam.Text, this._ToEmailList, this._CCEmailList, cFunction.getMailList(this._factorySettings, this._pi.getFactory()));
			bool flag = mailForm.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.tbToList.Text = string.Empty;
				this.tbCCList.Text = string.Empty;
				this._ToEmailList = (List<cEmailInfo>)mailForm.getEmailList();
				this._CCEmailList = (List<cEmailInfo>)mailForm.getCCEmailList();
				for (int i = 0; i < this._ToEmailList.Count; i++)
				{
					TextBox textBox = this.tbToList;
					textBox.Text = textBox.Text + this._ToEmailList[i]._sEmail.Trim() + ";" + Environment.NewLine;
				}
				for (int j = 0; j < this._CCEmailList.Count; j++)
				{
					TextBox textBox2 = this.tbCCList;
					textBox2.Text = textBox2.Text + this._CCEmailList[j]._sEmail.Trim() + ";" + Environment.NewLine;
				}
			}
		}

		// Token: 0x06000223 RID: 547 RVA: 0x000502E0 File Offset: 0x0004E4E0
		private void cb_teamlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tbTeam.Text = this.cb_teamlist.SelectedItem.ToString();
			this.tbFrom.Text = this._DeptMailList[this.tbTeam.Text.Trim()];
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00050334 File Offset: 0x0004E534
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
					this.tbName.ReadOnly = true;
					this.tbTeam.Visible = true;
					this.tbName.BackColor = Color.Gainsboro;
					this.tbName.Text = this._report.sName;
					this.tbTeam.Text = this._report.sTeam;
				}
				else
				{
					cFunction.getTeam(this._factorySettings, this.cb_teamlist, this._DeptMailList);
					this.cb_teamlist.Visible = true;
					this.tbTeam.Visible = false;
					this.tbName.ReadOnly = false;
					this.tbName.BackColor = Color.White;
				}
			}
			login.Dispose();
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00050450 File Offset: 0x0004E650
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00050488 File Offset: 0x0004E688
		private void InitializeComponent()
		{
			this.groupBox3 = new GroupBox();
			this.panel5 = new Panel();
			this.tbFrom = new TextBox();
			this.groupBox5 = new GroupBox();
			this.panel6 = new Panel();
			this.pbLogin = new PictureBox();
			this.groupBox6 = new GroupBox();
			this.panel7 = new Panel();
			this.pbMailList = new PictureBox();
			this.panel4 = new Panel();
			this.tbCCList = new TextBox();
			this.label12 = new Label();
			this.panel3 = new Panel();
			this.tbToList = new TextBox();
			this.label11 = new Label();
			this.panel2 = new Panel();
			this.cb_teamlist = new ComboBox();
			this.tbTeam = new TextBox();
			this.label2 = new Label();
			this.panel1 = new Panel();
			this.tbName = new TextBox();
			this.label3 = new Label();
			this.groupBox3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panel6.SuspendLayout();
			((ISupportInitialize)this.pbLogin).BeginInit();
			this.groupBox6.SuspendLayout();
			this.panel7.SuspendLayout();
			((ISupportInitialize)this.pbMailList).BeginInit();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox3.AutoSize = true;
			this.groupBox3.Controls.Add(this.panel5);
			this.groupBox3.Controls.Add(this.panel4);
			this.groupBox3.Controls.Add(this.panel3);
			this.groupBox3.Controls.Add(this.panel2);
			this.groupBox3.Controls.Add(this.panel1);
			this.groupBox3.Dock = DockStyle.Fill;
			this.groupBox3.Location = new Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new Padding(3, 0, 3, 0);
			this.groupBox3.Size = new Size(284, 331);
			this.groupBox3.TabIndex = 45;
			this.groupBox3.TabStop = false;
			this.panel5.Controls.Add(this.tbFrom);
			this.panel5.Controls.Add(this.groupBox5);
			this.panel5.Controls.Add(this.groupBox6);
			this.panel5.Dock = DockStyle.Top;
			this.panel5.Location = new Point(3, 259);
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size(278, 69);
			this.panel5.TabIndex = 78;
			this.tbFrom.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbFrom.Location = new Point(47, 6);
			this.tbFrom.Name = "tbFrom";
			this.tbFrom.Size = new Size(16, 25);
			this.tbFrom.TabIndex = 75;
			this.tbFrom.Visible = false;
			this.groupBox5.Controls.Add(this.panel6);
			this.groupBox5.Dock = DockStyle.Right;
			this.groupBox5.Location = new Point(114, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new Size(82, 69);
			this.groupBox5.TabIndex = 72;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "User Info";
			this.groupBox5.Visible = false;
			this.panel6.Controls.Add(this.pbLogin);
			this.panel6.Location = new Point(21, 22);
			this.panel6.Name = "panel6";
			this.panel6.Size = new Size(39, 34);
			this.panel6.TabIndex = 11;
			this.pbLogin.Cursor = Cursors.Hand;
			this.pbLogin.Dock = DockStyle.Fill;
			this.pbLogin.Image = Resources.login;
			this.pbLogin.Location = new Point(0, 0);
			this.pbLogin.Name = "pbLogin";
			this.pbLogin.Size = new Size(39, 34);
			this.pbLogin.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbLogin.TabIndex = 10;
			this.pbLogin.TabStop = false;
			this.pbLogin.Click += this.pbLogin_Click;
			this.pbLogin.MouseEnter += this.pbLogin_MouseEnter;
			this.pbLogin.MouseLeave += this.pbLogin_MouseLeave;
			this.groupBox6.Controls.Add(this.panel7);
			this.groupBox6.Dock = DockStyle.Right;
			this.groupBox6.Location = new Point(196, 0);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new Size(82, 69);
			this.groupBox6.TabIndex = 73;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Mail List";
			this.panel7.Controls.Add(this.pbMailList);
			this.panel7.Location = new Point(22, 22);
			this.panel7.Name = "panel7";
			this.panel7.Size = new Size(39, 34);
			this.panel7.TabIndex = 46;
			this.pbMailList.Cursor = Cursors.Hand;
			this.pbMailList.Dock = DockStyle.Fill;
			this.pbMailList.Image = Resources.mail_list;
			this.pbMailList.Location = new Point(0, 0);
			this.pbMailList.Name = "pbMailList";
			this.pbMailList.Size = new Size(39, 34);
			this.pbMailList.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbMailList.TabIndex = 71;
			this.pbMailList.TabStop = false;
			this.pbMailList.Click += this.pbMailList_Click;
			this.pbMailList.MouseEnter += this.pbMailList_MouseEnter;
			this.pbMailList.MouseLeave += this.pbMailList_MouseLeave;
			this.panel4.Controls.Add(this.tbCCList);
			this.panel4.Controls.Add(this.label12);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(3, 159);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new Padding(0, 0, 0, 1);
			this.panel4.Size = new Size(278, 100);
			this.panel4.TabIndex = 77;
			this.tbCCList.BackColor = Color.Gainsboro;
			this.tbCCList.Dock = DockStyle.Fill;
			this.tbCCList.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbCCList.Location = new Point(47, 0);
			this.tbCCList.Multiline = true;
			this.tbCCList.Name = "tbCCList";
			this.tbCCList.ReadOnly = true;
			this.tbCCList.ScrollBars = ScrollBars.Vertical;
			this.tbCCList.Size = new Size(231, 99);
			this.tbCCList.TabIndex = 21;
			this.label12.Dock = DockStyle.Left;
			this.label12.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label12.Location = new Point(0, 0);
			this.label12.Name = "label12";
			this.label12.Size = new Size(47, 99);
			this.label12.TabIndex = 20;
			this.label12.Text = "CC List";
			this.panel3.Controls.Add(this.tbToList);
			this.panel3.Controls.Add(this.label11);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(3, 92);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new Padding(0, 0, 0, 1);
			this.panel3.Size = new Size(278, 67);
			this.panel3.TabIndex = 75;
			this.tbToList.BackColor = Color.Gainsboro;
			this.tbToList.Dock = DockStyle.Fill;
			this.tbToList.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbToList.Location = new Point(47, 0);
			this.tbToList.Multiline = true;
			this.tbToList.Name = "tbToList";
			this.tbToList.ReadOnly = true;
			this.tbToList.ScrollBars = ScrollBars.Vertical;
			this.tbToList.Size = new Size(231, 66);
			this.tbToList.TabIndex = 18;
			this.label11.Dock = DockStyle.Left;
			this.label11.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label11.Location = new Point(0, 0);
			this.label11.Name = "label11";
			this.label11.Size = new Size(47, 66);
			this.label11.TabIndex = 19;
			this.label11.Text = "To List";
			this.panel2.Controls.Add(this.cb_teamlist);
			this.panel2.Controls.Add(this.tbTeam);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(3, 39);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new Padding(0, 0, 0, 1);
			this.panel2.Size = new Size(278, 53);
			this.panel2.TabIndex = 46;
			this.cb_teamlist.Dock = DockStyle.Fill;
			this.cb_teamlist.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_teamlist.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cb_teamlist.FormattingEnabled = true;
			this.cb_teamlist.Items.AddRange(new object[]
			{
				"HARDWARE",
				"SOFTWARE",
				"OTHER"
			});
			this.cb_teamlist.Location = new Point(47, 0);
			this.cb_teamlist.Name = "cb_teamlist";
			this.cb_teamlist.Size = new Size(231, 23);
			this.cb_teamlist.TabIndex = 68;
			this.cb_teamlist.Visible = false;
			this.cb_teamlist.SelectedIndexChanged += this.cb_teamlist_SelectedIndexChanged;
			this.tbTeam.BackColor = Color.Gainsboro;
			this.tbTeam.Dock = DockStyle.Fill;
			this.tbTeam.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbTeam.Location = new Point(47, 0);
			this.tbTeam.Multiline = true;
			this.tbTeam.Name = "tbTeam";
			this.tbTeam.ReadOnly = true;
			this.tbTeam.Size = new Size(231, 52);
			this.tbTeam.TabIndex = 2;
			this.label2.Dock = DockStyle.Left;
			this.label2.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label2.Location = new Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(47, 52);
			this.label2.TabIndex = 0;
			this.label2.Text = "Dept.";
			this.panel1.Controls.Add(this.tbName);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(3, 14);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(278, 25);
			this.panel1.TabIndex = 74;
			this.tbName.BackColor = Color.Gainsboro;
			this.tbName.Dock = DockStyle.Fill;
			this.tbName.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbName.Location = new Point(47, 0);
			this.tbName.Name = "tbName";
			this.tbName.ReadOnly = true;
			this.tbName.Size = new Size(231, 23);
			this.tbName.TabIndex = 4;
			this.label3.Dock = DockStyle.Left;
			this.label3.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label3.Location = new Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(47, 25);
			this.label3.TabIndex = 3;
			this.label3.Text = "Name";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.groupBox3);
			base.Name = "PMUserInformation";
			base.Size = new Size(284, 331);
			this.groupBox3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			((ISupportInitialize)this.pbLogin).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			((ISupportInitialize)this.pbMailList).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040003ED RID: 1005
		private QueryMgr queryMgr;

		// Token: 0x040003EE RID: 1006
		private Dictionary<string, string> _DeptMailList = new Dictionary<string, string>();

		// Token: 0x040003EF RID: 1007
		private List<cEmailInfo> _ToEmailList = new List<cEmailInfo>();

		// Token: 0x040003F0 RID: 1008
		private List<cEmailInfo> _CCEmailList = new List<cEmailInfo>();

		// Token: 0x040003F1 RID: 1009
		private string _factory = string.Empty;

		// Token: 0x040003F2 RID: 1010
		private string _category = string.Empty;

		// Token: 0x040003F3 RID: 1011
		private cReportItem _report;

		// Token: 0x040003F4 RID: 1012
		private PMInformation _pi;

		// Token: 0x040003F5 RID: 1013
		private FactorySettings _factorySettings;

		// Token: 0x040003F6 RID: 1014
		private IContainer components = null;

		// Token: 0x040003F7 RID: 1015
		private GroupBox groupBox3;

		// Token: 0x040003F8 RID: 1016
		private GroupBox groupBox6;

		// Token: 0x040003F9 RID: 1017
		private PictureBox pbMailList;

		// Token: 0x040003FA RID: 1018
		private GroupBox groupBox5;

		// Token: 0x040003FB RID: 1019
		private PictureBox pbLogin;

		// Token: 0x040003FC RID: 1020
		private ComboBox cb_teamlist;

		// Token: 0x040003FD RID: 1021
		private TextBox tbName;

		// Token: 0x040003FE RID: 1022
		private Label label3;

		// Token: 0x040003FF RID: 1023
		private Label label12;

		// Token: 0x04000400 RID: 1024
		private Label label2;

		// Token: 0x04000401 RID: 1025
		private TextBox tbCCList;

		// Token: 0x04000402 RID: 1026
		private TextBox tbTeam;

		// Token: 0x04000403 RID: 1027
		private TextBox tbToList;

		// Token: 0x04000404 RID: 1028
		private Label label11;

		// Token: 0x04000405 RID: 1029
		private Panel panel2;

		// Token: 0x04000406 RID: 1030
		private Panel panel1;

		// Token: 0x04000407 RID: 1031
		private Panel panel3;

		// Token: 0x04000408 RID: 1032
		private Panel panel5;

		// Token: 0x04000409 RID: 1033
		private Panel panel6;

		// Token: 0x0400040A RID: 1034
		private Panel panel7;

		// Token: 0x0400040B RID: 1035
		private Panel panel4;

		// Token: 0x0400040C RID: 1036
		private TextBox tbFrom;
	}
}
