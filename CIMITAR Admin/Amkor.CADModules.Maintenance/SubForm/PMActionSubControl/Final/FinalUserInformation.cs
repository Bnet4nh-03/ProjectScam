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
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Final
{
	// Token: 0x02000026 RID: 38
	public class FinalUserInformation : UserControl
	{
		// Token: 0x0600027A RID: 634 RVA: 0x0005206C File Offset: 0x0005026C
		private void pbLogin3_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.login;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00052059 File Offset: 0x00050259
		private void pbLogin3_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.login_down;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0005207F File Offset: 0x0005027F
		private void pbMailList3_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.mail_list;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00052092 File Offset: 0x00050292
		private void pbMailList3_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.mail_list_down;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x000575B7 File Offset: 0x000557B7
		public string getTeamString()
		{
			return this.tbTeam4.Text.Trim();
		}

		// Token: 0x0600027F RID: 639 RVA: 0x000575C9 File Offset: 0x000557C9
		public string getNameString()
		{
			return this.tbName4.Text.Trim();
		}

		// Token: 0x06000280 RID: 640 RVA: 0x000575DC File Offset: 0x000557DC
		public FinalUserInformation(cReportItem report, FactorySettings factorySetting, CIMitarAccount cimitarUser, RequestInformation ri)
		{
			this._ri = ri;
			this._report = report;
			this._queryMgr = new QueryMgr(factorySetting);
			this._factorySettings = factorySetting;
			this.InitializeComponent();
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
			bool userData = cFunction.getUserData(report, cimitarUser._id);
			if (userData)
			{
				this.tbName4.Text = report.sPMFinalName;
				this.tbTeam4.Text = report.sPMFinalTeam;
				this.tbToList4.Text = report.sCCEmail;
				this.tbCCList4.Text = report.sToEmail;
			}
			else
			{
				this.cb_teamlist4.Visible = true;
				this.tbTeam4.Visible = false;
			}
			bool flag = report.sReportStauts == "14";
			if (flag)
			{
				this.pnFinalSubFunction.Visible = false;
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00057780 File Offset: 0x00055980
		private void getTeam(ComboBox cb, Dictionary<string, string> DeptMailList)
		{
			cb.Items.Clear();
			this._DeptMailList.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintTeamInfo]";
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.cb_teamlist4.Items.Add(dataSet.Tables[0].Rows[i]["Name"].ToString());
					this._DeptMailList.Add(dataSet.Tables[0].Rows[i]["Name"].ToString(), dataSet.Tables[0].Rows[i]["Mail"].ToString());
				}
			}
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00057894 File Offset: 0x00055A94
		private void pbMailList3_Click(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.mail_list;
			MailForm mailForm = new MailForm("To Mail List", this._ri.getCategory(), this.tbTeam4.Text, this._ToEmailList, this._CCEmailList, cFunction.getMailList(this._factorySettings, this._report.sFactory));
			bool flag = mailForm.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this._ToEmailList = (List<cEmailInfo>)mailForm.getEmailList();
				this._CCEmailList = (List<cEmailInfo>)mailForm.getCCEmailList();
				this.tbToList4.Text = string.Empty;
				this.tbCCList4.Text = string.Empty;
				for (int i = 0; i < this._ToEmailList.Count; i++)
				{
					TextBox textBox = this.tbToList4;
					textBox.Text = textBox.Text + this._ToEmailList[i]._sEmail.Trim() + ";" + Environment.NewLine;
				}
				for (int j = 0; j < this._CCEmailList.Count; j++)
				{
					TextBox textBox2 = this.tbCCList4;
					textBox2.Text = textBox2.Text + this._CCEmailList[j]._sEmail.Trim() + ";" + Environment.NewLine;
				}
			}
		}

		// Token: 0x06000283 RID: 643 RVA: 0x000579FC File Offset: 0x00055BFC
		private void pbLogin3_Click(object sender, EventArgs e)
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
					this.cb_teamlist4.Visible = false;
					this.tbName4.ReadOnly = true;
					this.tbTeam4.Visible = true;
					this.tbName4.BackColor = Color.Gainsboro;
					this.tbName4.Text = this._report.sPMFinalName;
					this.tbTeam4.Text = this._report.sPMFinalTeam;
				}
				else
				{
					cFunction.getTeam(this._factorySettings, this.cb_teamlist4, this._DeptMailList);
					this.cb_teamlist4.Visible = true;
					this.tbName4.ReadOnly = false;
					this.tbTeam4.Visible = false;
					this.tbName4.BackColor = Color.White;
				}
			}
			login.Dispose();
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00057B18 File Offset: 0x00055D18
		private void cb_teamlist4_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tbName4.Text = this.cb_teamlist4.SelectedItem.ToString();
			this._report.sMailActionForm = this._DeptMailList[this.tbTeam4.Text.Trim()];
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00057B68 File Offset: 0x00055D68
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00057BA0 File Offset: 0x00055DA0
		private void InitializeComponent()
		{
			this.panel75 = new Panel();
			this.pnFinalSubFunction = new Panel();
			this.groupBox11 = new GroupBox();
			this.panel5 = new Panel();
			this.pbLogin3 = new PictureBox();
			this.groupBox12 = new GroupBox();
			this.panel6 = new Panel();
			this.pbMailList3 = new PictureBox();
			this.panel4 = new Panel();
			this.tbCCList4 = new TextBox();
			this.label57 = new Label();
			this.panel3 = new Panel();
			this.tbToList4 = new TextBox();
			this.label58 = new Label();
			this.panel2 = new Panel();
			this.cb_teamlist4 = new ComboBox();
			this.tbTeam4 = new TextBox();
			this.label55 = new Label();
			this.panel1 = new Panel();
			this.tbName4 = new TextBox();
			this.label56 = new Label();
			this.panel75.SuspendLayout();
			this.pnFinalSubFunction.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.panel5.SuspendLayout();
			((ISupportInitialize)this.pbLogin3).BeginInit();
			this.groupBox12.SuspendLayout();
			this.panel6.SuspendLayout();
			((ISupportInitialize)this.pbMailList3).BeginInit();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel75.Controls.Add(this.pnFinalSubFunction);
			this.panel75.Controls.Add(this.panel4);
			this.panel75.Controls.Add(this.panel3);
			this.panel75.Controls.Add(this.panel2);
			this.panel75.Controls.Add(this.panel1);
			this.panel75.Dock = DockStyle.Fill;
			this.panel75.Location = new Point(0, 0);
			this.panel75.Name = "panel75";
			this.panel75.Size = new Size(331, 407);
			this.panel75.TabIndex = 88;
			this.pnFinalSubFunction.Controls.Add(this.groupBox11);
			this.pnFinalSubFunction.Controls.Add(this.groupBox12);
			this.pnFinalSubFunction.Dock = DockStyle.Top;
			this.pnFinalSubFunction.Location = new Point(0, 319);
			this.pnFinalSubFunction.Name = "pnFinalSubFunction";
			this.pnFinalSubFunction.Size = new Size(331, 86);
			this.pnFinalSubFunction.TabIndex = 11;
			this.groupBox11.Controls.Add(this.panel5);
			this.groupBox11.Dock = DockStyle.Right;
			this.groupBox11.Location = new Point(169, 0);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new Size(81, 86);
			this.groupBox11.TabIndex = 89;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "User Info";
			this.groupBox11.Visible = false;
			this.panel5.Controls.Add(this.pbLogin3);
			this.panel5.Location = new Point(21, 24);
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size(44, 44);
			this.panel5.TabIndex = 90;
			this.pbLogin3.Cursor = Cursors.Hand;
			this.pbLogin3.Dock = DockStyle.Fill;
			this.pbLogin3.Image = Resources.login;
			this.pbLogin3.Location = new Point(0, 0);
			this.pbLogin3.Name = "pbLogin3";
			this.pbLogin3.Size = new Size(44, 44);
			this.pbLogin3.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbLogin3.TabIndex = 10;
			this.pbLogin3.TabStop = false;
			this.pbLogin3.Click += this.pbLogin3_Click;
			this.pbLogin3.MouseEnter += this.pbLogin3_MouseEnter;
			this.pbLogin3.MouseLeave += this.pbLogin3_MouseLeave;
			this.groupBox12.Controls.Add(this.panel6);
			this.groupBox12.Dock = DockStyle.Right;
			this.groupBox12.Location = new Point(250, 0);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new Size(81, 86);
			this.groupBox12.TabIndex = 80;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Mail List";
			this.panel6.Controls.Add(this.pbMailList3);
			this.panel6.Location = new Point(21, 24);
			this.panel6.Name = "panel6";
			this.panel6.Size = new Size(44, 44);
			this.panel6.TabIndex = 11;
			this.pbMailList3.Cursor = Cursors.Hand;
			this.pbMailList3.Dock = DockStyle.Fill;
			this.pbMailList3.Image = Resources.mail_list;
			this.pbMailList3.Location = new Point(0, 0);
			this.pbMailList3.Name = "pbMailList3";
			this.pbMailList3.Size = new Size(44, 44);
			this.pbMailList3.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbMailList3.TabIndex = 71;
			this.pbMailList3.TabStop = false;
			this.pbMailList3.Click += this.pbMailList3_Click;
			this.pbMailList3.MouseEnter += this.pbMailList3_MouseEnter;
			this.pbMailList3.MouseLeave += this.pbMailList3_MouseLeave;
			this.panel4.Controls.Add(this.tbCCList4);
			this.panel4.Controls.Add(this.label57);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(0, 219);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new Padding(0, 0, 0, 1);
			this.panel4.Size = new Size(331, 100);
			this.panel4.TabIndex = 25;
			this.tbCCList4.BackColor = Color.Gainsboro;
			this.tbCCList4.Dock = DockStyle.Fill;
			this.tbCCList4.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbCCList4.Location = new Point(47, 0);
			this.tbCCList4.Multiline = true;
			this.tbCCList4.Name = "tbCCList4";
			this.tbCCList4.ReadOnly = true;
			this.tbCCList4.ScrollBars = ScrollBars.Vertical;
			this.tbCCList4.Size = new Size(284, 99);
			this.tbCCList4.TabIndex = 42;
			this.label57.Dock = DockStyle.Left;
			this.label57.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label57.Location = new Point(0, 0);
			this.label57.Name = "label57";
			this.label57.Size = new Size(47, 99);
			this.label57.TabIndex = 41;
			this.label57.Text = "CC List";
			this.panel3.Controls.Add(this.tbToList4);
			this.panel3.Controls.Add(this.label58);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(0, 119);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new Padding(0, 0, 0, 1);
			this.panel3.Size = new Size(331, 100);
			this.panel3.TabIndex = 91;
			this.tbToList4.BackColor = Color.Gainsboro;
			this.tbToList4.Dock = DockStyle.Fill;
			this.tbToList4.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbToList4.Location = new Point(47, 0);
			this.tbToList4.Multiline = true;
			this.tbToList4.Name = "tbToList4";
			this.tbToList4.ReadOnly = true;
			this.tbToList4.ScrollBars = ScrollBars.Vertical;
			this.tbToList4.Size = new Size(284, 99);
			this.tbToList4.TabIndex = 39;
			this.label58.Dock = DockStyle.Left;
			this.label58.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label58.Location = new Point(0, 0);
			this.label58.Name = "label58";
			this.label58.Size = new Size(47, 99);
			this.label58.TabIndex = 40;
			this.label58.Text = "To List";
			this.panel2.Controls.Add(this.cb_teamlist4);
			this.panel2.Controls.Add(this.tbTeam4);
			this.panel2.Controls.Add(this.label55);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(0, 24);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new Padding(0, 0, 0, 1);
			this.panel2.Size = new Size(331, 95);
			this.panel2.TabIndex = 90;
			this.cb_teamlist4.Dock = DockStyle.Fill;
			this.cb_teamlist4.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_teamlist4.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cb_teamlist4.FormattingEnabled = true;
			this.cb_teamlist4.Location = new Point(46, 0);
			this.cb_teamlist4.Name = "cb_teamlist4";
			this.cb_teamlist4.Size = new Size(285, 23);
			this.cb_teamlist4.TabIndex = 70;
			this.cb_teamlist4.Visible = false;
			this.cb_teamlist4.SelectedIndexChanged += this.cb_teamlist4_SelectedIndexChanged;
			this.tbTeam4.BackColor = Color.Gainsboro;
			this.tbTeam4.Dock = DockStyle.Fill;
			this.tbTeam4.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbTeam4.Location = new Point(46, 0);
			this.tbTeam4.Multiline = true;
			this.tbTeam4.Name = "tbTeam4";
			this.tbTeam4.ReadOnly = true;
			this.tbTeam4.Size = new Size(285, 94);
			this.tbTeam4.TabIndex = 4;
			this.label55.Dock = DockStyle.Left;
			this.label55.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label55.Location = new Point(0, 0);
			this.label55.Name = "label55";
			this.label55.Size = new Size(46, 94);
			this.label55.TabIndex = 3;
			this.label55.Text = "Dept.";
			this.panel1.Controls.Add(this.tbName4);
			this.panel1.Controls.Add(this.label56);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new Padding(0, 0, 0, 1);
			this.panel1.Size = new Size(331, 24);
			this.panel1.TabIndex = 89;
			this.tbName4.BackColor = Color.Gainsboro;
			this.tbName4.Dock = DockStyle.Fill;
			this.tbName4.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbName4.Location = new Point(45, 0);
			this.tbName4.Name = "tbName4";
			this.tbName4.ReadOnly = true;
			this.tbName4.Size = new Size(286, 23);
			this.tbName4.TabIndex = 24;
			this.label56.Dock = DockStyle.Left;
			this.label56.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label56.Location = new Point(0, 0);
			this.label56.Name = "label56";
			this.label56.Size = new Size(45, 23);
			this.label56.TabIndex = 23;
			this.label56.Text = "Name";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel75);
			base.Name = "FinalUserInformation";
			base.Size = new Size(331, 407);
			this.panel75.ResumeLayout(false);
			this.pnFinalSubFunction.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			((ISupportInitialize)this.pbLogin3).EndInit();
			this.groupBox12.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			((ISupportInitialize)this.pbMailList3).EndInit();
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

		// Token: 0x0400047B RID: 1147
		private QueryMgr _queryMgr;

		// Token: 0x0400047C RID: 1148
		private List<cEmailInfo> _ToEmailList = new List<cEmailInfo>();

		// Token: 0x0400047D RID: 1149
		private List<cEmailInfo> _CCEmailList = new List<cEmailInfo>();

		// Token: 0x0400047E RID: 1150
		private Dictionary<string, string> _DeptMailList = new Dictionary<string, string>();

		// Token: 0x0400047F RID: 1151
		private RequestInformation _ri;

		// Token: 0x04000480 RID: 1152
		private cReportItem _report;

		// Token: 0x04000481 RID: 1153
		private FactorySettings _factorySettings;

		// Token: 0x04000482 RID: 1154
		private IContainer components = null;

		// Token: 0x04000483 RID: 1155
		private Panel panel75;

		// Token: 0x04000484 RID: 1156
		private Panel panel1;

		// Token: 0x04000485 RID: 1157
		private TextBox tbName4;

		// Token: 0x04000486 RID: 1158
		private Label label56;

		// Token: 0x04000487 RID: 1159
		private TextBox tbToList4;

		// Token: 0x04000488 RID: 1160
		private ComboBox cb_teamlist4;

		// Token: 0x04000489 RID: 1161
		private Label label55;

		// Token: 0x0400048A RID: 1162
		private TextBox tbTeam4;

		// Token: 0x0400048B RID: 1163
		private TextBox tbCCList4;

		// Token: 0x0400048C RID: 1164
		private Label label57;

		// Token: 0x0400048D RID: 1165
		private Label label58;

		// Token: 0x0400048E RID: 1166
		private Panel pnFinalSubFunction;

		// Token: 0x0400048F RID: 1167
		private GroupBox groupBox11;

		// Token: 0x04000490 RID: 1168
		private PictureBox pbLogin3;

		// Token: 0x04000491 RID: 1169
		private GroupBox groupBox12;

		// Token: 0x04000492 RID: 1170
		private PictureBox pbMailList3;

		// Token: 0x04000493 RID: 1171
		private Panel panel3;

		// Token: 0x04000494 RID: 1172
		private Panel panel2;

		// Token: 0x04000495 RID: 1173
		private Panel panel4;

		// Token: 0x04000496 RID: 1174
		private Panel panel5;

		// Token: 0x04000497 RID: 1175
		private Panel panel6;
	}
}
