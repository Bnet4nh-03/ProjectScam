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

namespace Amkor.CADModules.Maintenance.SubForm.ReportSubControl
{
	// Token: 0x02000018 RID: 24
	public class ReportUserInformation : UserControl
	{
		// Token: 0x060001C3 RID: 451 RVA: 0x0004957A File Offset: 0x0004777A
		private void pbLogin_MouseLeave(object sender, EventArgs e)
		{
			this.pbLogin.Image = Resources.login;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0004958D File Offset: 0x0004778D
		private void pbLogin_MouseEnter(object sender, EventArgs e)
		{
			this.pbLogin.Image = Resources.login_down;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x000495A0 File Offset: 0x000477A0
		private void pbMailList_MouseEnter(object sender, EventArgs e)
		{
			this.pbMailList.Image = Resources.mail_list_down;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000495B3 File Offset: 0x000477B3
		private void pbMailList_MouseLeave(object sender, EventArgs e)
		{
			this.pbMailList.Image = Resources.mail_list;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000495C6 File Offset: 0x000477C6
		public string getTeam()
		{
			return this.tbTeam.Text.Trim().ToUpper();
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000495DD File Offset: 0x000477DD
		public string getToMail()
		{
			return this.tbToList.Text.Trim();
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000495EF File Offset: 0x000477EF
		public string getCCMail()
		{
			return this.tbCCList.Text.Trim();
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00049601 File Offset: 0x00047801
		public string getName()
		{
			return this.tbName.Text.Trim();
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00049613 File Offset: 0x00047813
		public void setFactory(string factory)
		{
			this._factory = factory;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0004961C File Offset: 0x0004781C
		public void setCategory(string category)
		{
			this._category = category;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00049625 File Offset: 0x00047825
		public string fromMail()
		{
			return this.tbFrom.Text.Trim();
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00049637 File Offset: 0x00047837
		public void setReportInformation(ReportInformation ri)
		{
			this._ri = ri;
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00049640 File Offset: 0x00047840
		public ReportUserInformation(FactorySettings factorySettings)
		{
			this._ToEmailList.Clear();
			this._CCEmailList.Clear();
			this._factorySettings = factorySettings;
			this._queryMgr = new QueryMgr(factorySettings);
			this.InitializeComponent();
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x000496C5 File Offset: 0x000478C5
		public void clear()
		{
			this._ToEmailList.Clear();
			this._CCEmailList.Clear();
			this.tbCCList.Text = "";
			this.tbToList.Text = "";
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00049704 File Offset: 0x00047904
		private void getTeamFromDB()
		{
			this.cb_teamlist.Items.Clear();
			this._DeptMailList.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintTeamInfo]";
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
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

		// Token: 0x060001D2 RID: 466 RVA: 0x00049820 File Offset: 0x00047A20
		public void getToGroupList()
		{
			this._ToEmailList.Clear();
			this.tbToList.Text = "";
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintEmailGroup] @_Plant=N'" + this._factory + "'";
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
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

		// Token: 0x060001D3 RID: 467 RVA: 0x000499FC File Offset: 0x00047BFC
		public string getUserData(string sUserID)
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
			return userData_SubFunc;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00049B40 File Offset: 0x00047D40
		public void getCCMailList()
		{
			this._CCEmailList.Clear();
			this.tbCCList.Text = "";
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintEmailGroup]";
			text += " @_command=N'CCMail'";
			text = text + ", @_Category=N'" + this._category + "'";
			text = text + ", @_Plant=N'" + this._factory + "'";
			DataSet dataSet = this._queryMgr.queryCall(text);
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

		// Token: 0x060001D5 RID: 469 RVA: 0x00049D44 File Offset: 0x00047F44
		public bool checkTeam()
		{
			bool flag = this.cb_teamlist.Visible && this.cb_teamlist.SelectedIndex == -1;
			return !flag;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00049D80 File Offset: 0x00047F80
		private void pbMailList_Click(object sender, EventArgs e)
		{
			MailForm mailForm = new MailForm("To Mail List", this._category, this.tbTeam.Text, this._ToEmailList, this._CCEmailList, cFunction.getMailList(this._factorySettings, this._ri.getFactory()));
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

		// Token: 0x060001D7 RID: 471 RVA: 0x00049ED0 File Offset: 0x000480D0
		private void cb_teamlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tbTeam.Text = this.cb_teamlist.SelectedItem.ToString();
			this.tbFrom.Text = this._DeptMailList[this.tbTeam.Text.Trim()];
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00049F24 File Offset: 0x00048124
		private void pbLogin_Click(object sender, EventArgs e)
		{
			this.pbLogin.Image = Resources.login;
			Login login = new Login();
			bool flag = login.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				CIMitarLogin._id = login.id;
				this.getUserData(login.id);
			}
			login.Dispose();
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00049F78 File Offset: 0x00048178
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00049FB0 File Offset: 0x000481B0
		private void InitializeComponent()
		{
			this.groupBox3 = new GroupBox();
			this.panel5 = new Panel();
			this.groupBox5 = new GroupBox();
			this.panel6 = new Panel();
			this.pbLogin = new PictureBox();
			this.groupBox6 = new GroupBox();
			this.panel7 = new Panel();
			this.pbMailList = new PictureBox();
			this.tbFrom = new TextBox();
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
			this.groupBox3.Controls.Add(this.panel5);
			this.groupBox3.Controls.Add(this.panel4);
			this.groupBox3.Controls.Add(this.panel3);
			this.groupBox3.Controls.Add(this.panel2);
			this.groupBox3.Controls.Add(this.panel1);
			this.groupBox3.Dock = DockStyle.Fill;
			this.groupBox3.Location = new Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new Padding(0);
			this.groupBox3.Size = new Size(275, 287);
			this.groupBox3.TabIndex = 44;
			this.groupBox3.TabStop = false;
			this.panel5.Controls.Add(this.groupBox5);
			this.panel5.Controls.Add(this.groupBox6);
			this.panel5.Controls.Add(this.tbFrom);
			this.panel5.Dock = DockStyle.Top;
			this.panel5.Location = new Point(0, 221);
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size(275, 65);
			this.panel5.TabIndex = 11;
			this.groupBox5.Controls.Add(this.panel6);
			this.groupBox5.Dock = DockStyle.Right;
			this.groupBox5.Location = new Point(111, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new Size(82, 65);
			this.groupBox5.TabIndex = 72;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "User Info";
			this.groupBox5.Visible = false;
			this.panel6.Controls.Add(this.pbLogin);
			this.panel6.Location = new Point(23, 22);
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
			this.groupBox6.Location = new Point(193, 0);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new Size(82, 65);
			this.groupBox6.TabIndex = 73;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Mail List";
			this.panel7.Controls.Add(this.pbMailList);
			this.panel7.Location = new Point(21, 23);
			this.panel7.Name = "panel7";
			this.panel7.Size = new Size(39, 34);
			this.panel7.TabIndex = 74;
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
			this.tbFrom.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbFrom.Location = new Point(31, 24);
			this.tbFrom.Name = "tbFrom";
			this.tbFrom.Size = new Size(140, 25);
			this.tbFrom.TabIndex = 75;
			this.tbFrom.Visible = false;
			this.panel4.Controls.Add(this.tbCCList);
			this.panel4.Controls.Add(this.label12);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(0, 157);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new Padding(1);
			this.panel4.Size = new Size(275, 64);
			this.panel4.TabIndex = 79;
			this.tbCCList.BackColor = Color.Gainsboro;
			this.tbCCList.Dock = DockStyle.Fill;
			this.tbCCList.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbCCList.Location = new Point(48, 1);
			this.tbCCList.Multiline = true;
			this.tbCCList.Name = "tbCCList";
			this.tbCCList.ReadOnly = true;
			this.tbCCList.ScrollBars = ScrollBars.Vertical;
			this.tbCCList.Size = new Size(226, 62);
			this.tbCCList.TabIndex = 21;
			this.label12.Dock = DockStyle.Left;
			this.label12.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label12.Location = new Point(1, 1);
			this.label12.Name = "label12";
			this.label12.Size = new Size(47, 62);
			this.label12.TabIndex = 20;
			this.label12.Text = "CC List";
			this.panel3.Controls.Add(this.tbToList);
			this.panel3.Controls.Add(this.label11);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(0, 90);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new Padding(1);
			this.panel3.Size = new Size(275, 67);
			this.panel3.TabIndex = 78;
			this.tbToList.BackColor = Color.Gainsboro;
			this.tbToList.Dock = DockStyle.Fill;
			this.tbToList.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbToList.Location = new Point(48, 1);
			this.tbToList.Multiline = true;
			this.tbToList.Name = "tbToList";
			this.tbToList.ReadOnly = true;
			this.tbToList.ScrollBars = ScrollBars.Vertical;
			this.tbToList.Size = new Size(226, 65);
			this.tbToList.TabIndex = 18;
			this.label11.Dock = DockStyle.Left;
			this.label11.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label11.Location = new Point(1, 1);
			this.label11.Name = "label11";
			this.label11.Size = new Size(47, 65);
			this.label11.TabIndex = 19;
			this.label11.Text = "To List";
			this.panel2.Controls.Add(this.cb_teamlist);
			this.panel2.Controls.Add(this.tbTeam);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(0, 39);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new Padding(1);
			this.panel2.Size = new Size(275, 51);
			this.panel2.TabIndex = 77;
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
			this.cb_teamlist.Location = new Point(48, 1);
			this.cb_teamlist.Name = "cb_teamlist";
			this.cb_teamlist.Size = new Size(226, 23);
			this.cb_teamlist.TabIndex = 68;
			this.cb_teamlist.Visible = false;
			this.cb_teamlist.SelectedIndexChanged += this.cb_teamlist_SelectedIndexChanged;
			this.tbTeam.BackColor = Color.Gainsboro;
			this.tbTeam.Dock = DockStyle.Fill;
			this.tbTeam.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbTeam.Location = new Point(48, 1);
			this.tbTeam.Multiline = true;
			this.tbTeam.Name = "tbTeam";
			this.tbTeam.ReadOnly = true;
			this.tbTeam.Size = new Size(226, 49);
			this.tbTeam.TabIndex = 2;
			this.label2.Dock = DockStyle.Left;
			this.label2.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label2.Location = new Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new Size(47, 49);
			this.label2.TabIndex = 0;
			this.label2.Text = "Dept.";
			this.panel1.Controls.Add(this.tbName);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 14);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new Padding(1);
			this.panel1.Size = new Size(275, 25);
			this.panel1.TabIndex = 76;
			this.tbName.BackColor = Color.Gainsboro;
			this.tbName.Dock = DockStyle.Fill;
			this.tbName.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbName.Location = new Point(48, 1);
			this.tbName.Name = "tbName";
			this.tbName.ReadOnly = true;
			this.tbName.Size = new Size(226, 23);
			this.tbName.TabIndex = 4;
			this.label3.Dock = DockStyle.Left;
			this.label3.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label3.Location = new Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new Size(47, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Name";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.groupBox3);
			base.Name = "ReportUserInformation";
			base.Size = new Size(275, 287);
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
		}

		// Token: 0x04000376 RID: 886
		private QueryMgr _queryMgr;

		// Token: 0x04000377 RID: 887
		private Dictionary<string, string> _DeptMailList = new Dictionary<string, string>();

		// Token: 0x04000378 RID: 888
		private List<cEmailInfo> _ToEmailList = new List<cEmailInfo>();

		// Token: 0x04000379 RID: 889
		private List<cEmailInfo> _CCEmailList = new List<cEmailInfo>();

		// Token: 0x0400037A RID: 890
		private string _factory = string.Empty;

		// Token: 0x0400037B RID: 891
		private string _category = string.Empty;

		// Token: 0x0400037C RID: 892
		public ReportInformation _ri;

		// Token: 0x0400037D RID: 893
		private FactorySettings _factorySettings;

		// Token: 0x0400037E RID: 894
		private IContainer components = null;

		// Token: 0x0400037F RID: 895
		private GroupBox groupBox3;

		// Token: 0x04000380 RID: 896
		private GroupBox groupBox6;

		// Token: 0x04000381 RID: 897
		private PictureBox pbMailList;

		// Token: 0x04000382 RID: 898
		private GroupBox groupBox5;

		// Token: 0x04000383 RID: 899
		private PictureBox pbLogin;

		// Token: 0x04000384 RID: 900
		private ComboBox cb_teamlist;

		// Token: 0x04000385 RID: 901
		private TextBox tbName;

		// Token: 0x04000386 RID: 902
		private Label label3;

		// Token: 0x04000387 RID: 903
		private Label label12;

		// Token: 0x04000388 RID: 904
		private Label label2;

		// Token: 0x04000389 RID: 905
		private TextBox tbCCList;

		// Token: 0x0400038A RID: 906
		private TextBox tbTeam;

		// Token: 0x0400038B RID: 907
		private TextBox tbToList;

		// Token: 0x0400038C RID: 908
		private Label label11;

		// Token: 0x0400038D RID: 909
		private TextBox tbFrom;

		// Token: 0x0400038E RID: 910
		private Panel panel5;

		// Token: 0x0400038F RID: 911
		private Panel panel4;

		// Token: 0x04000390 RID: 912
		private Panel panel3;

		// Token: 0x04000391 RID: 913
		private Panel panel2;

		// Token: 0x04000392 RID: 914
		private Panel panel1;

		// Token: 0x04000393 RID: 915
		private Panel panel6;

		// Token: 0x04000394 RID: 916
		private Panel panel7;
	}
}
