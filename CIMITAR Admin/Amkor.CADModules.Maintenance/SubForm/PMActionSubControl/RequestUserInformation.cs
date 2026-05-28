using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst.Class;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl
{
	// Token: 0x0200001D RID: 29
	public class RequestUserInformation : UserControl
	{
		// Token: 0x06000227 RID: 551 RVA: 0x000514E8 File Offset: 0x0004F6E8
		public RequestUserInformation(cReportItem report)
		{
			this.InitializeComponent();
			this.tbName.Text = report.sName;
			this.tbTeam.Text = report.sTeam;
			this.tbToList.Text = report.sToEmail;
			this.tbCCList.Text = report.sCCEmail;
			string[] array = this.tbToList.Text.Trim().Split(new char[]
			{
				';'
			});
			string text = string.Empty;
			foreach (string text2 in array)
			{
				bool flag = text2 != string.Empty;
				if (flag)
				{
					text = text + text2 + ";" + Environment.NewLine;
				}
			}
			bool flag2 = text != string.Empty;
			if (flag2)
			{
				this.tbToList.Text = text;
			}
			text = string.Empty;
			array = this.tbCCList.Text.Trim().Split(new char[]
			{
				';'
			});
			foreach (string text3 in array)
			{
				bool flag3 = text3 != string.Empty;
				if (flag3)
				{
					text = text + text3 + ";" + Environment.NewLine;
				}
			}
			bool flag4 = text != string.Empty;
			if (flag4)
			{
				this.tbCCList.Text = text;
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00051661 File Offset: 0x0004F861
		public string getTeamText()
		{
			return this.tbTeam.Text.Trim();
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00051673 File Offset: 0x0004F873
		public string getNameText()
		{
			return this.tbName.Text.Trim();
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000AE4C File Offset: 0x0000904C
		public void clear()
		{
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00051688 File Offset: 0x0004F888
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000516C0 File Offset: 0x0004F8C0
		private void InitializeComponent()
		{
			this.groupBox7 = new GroupBox();
			this.panel4 = new Panel();
			this.tbCCList = new TextBox();
			this.label12 = new Label();
			this.panel3 = new Panel();
			this.tbToList = new TextBox();
			this.label11 = new Label();
			this.panel2 = new Panel();
			this.tbTeam = new TextBox();
			this.label26 = new Label();
			this.panel1 = new Panel();
			this.tbName = new TextBox();
			this.label10 = new Label();
			this.groupBox7.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox7.Controls.Add(this.panel4);
			this.groupBox7.Controls.Add(this.panel3);
			this.groupBox7.Controls.Add(this.panel2);
			this.groupBox7.Controls.Add(this.panel1);
			this.groupBox7.Dock = DockStyle.Top;
			this.groupBox7.Location = new Point(0, 0);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new Size(368, 233);
			this.groupBox7.TabIndex = 79;
			this.groupBox7.TabStop = false;
			this.panel4.Controls.Add(this.tbCCList);
			this.panel4.Controls.Add(this.label12);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(3, 150);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(362, 77);
			this.panel4.TabIndex = 102;
			this.tbCCList.BackColor = Color.Gainsboro;
			this.tbCCList.Dock = DockStyle.Fill;
			this.tbCCList.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbCCList.Location = new Point(47, 0);
			this.tbCCList.Multiline = true;
			this.tbCCList.Name = "tbCCList";
			this.tbCCList.ReadOnly = true;
			this.tbCCList.ScrollBars = ScrollBars.Vertical;
			this.tbCCList.Size = new Size(315, 77);
			this.tbCCList.TabIndex = 82;
			this.tbCCList.TabStop = false;
			this.label12.Dock = DockStyle.Left;
			this.label12.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label12.Location = new Point(0, 0);
			this.label12.Name = "label12";
			this.label12.Size = new Size(47, 77);
			this.label12.TabIndex = 81;
			this.label12.Text = "CC List";
			this.panel3.Controls.Add(this.tbToList);
			this.panel3.Controls.Add(this.label11);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(3, 68);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new Padding(0, 0, 0, 1);
			this.panel3.Size = new Size(362, 82);
			this.panel3.TabIndex = 101;
			this.tbToList.BackColor = Color.Gainsboro;
			this.tbToList.Dock = DockStyle.Fill;
			this.tbToList.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbToList.Location = new Point(47, 0);
			this.tbToList.Multiline = true;
			this.tbToList.Name = "tbToList";
			this.tbToList.ReadOnly = true;
			this.tbToList.ScrollBars = ScrollBars.Vertical;
			this.tbToList.Size = new Size(315, 81);
			this.tbToList.TabIndex = 79;
			this.tbToList.TabStop = false;
			this.label11.Dock = DockStyle.Left;
			this.label11.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label11.Location = new Point(0, 0);
			this.label11.Name = "label11";
			this.label11.Size = new Size(47, 81);
			this.label11.TabIndex = 80;
			this.label11.Text = "To List";
			this.panel2.Controls.Add(this.tbTeam);
			this.panel2.Controls.Add(this.label26);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(3, 40);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new Padding(0, 0, 0, 1);
			this.panel2.Size = new Size(362, 28);
			this.panel2.TabIndex = 100;
			this.tbTeam.BackColor = Color.Gainsboro;
			this.tbTeam.Dock = DockStyle.Fill;
			this.tbTeam.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbTeam.Location = new Point(47, 0);
			this.tbTeam.Multiline = true;
			this.tbTeam.Name = "tbTeam";
			this.tbTeam.ReadOnly = true;
			this.tbTeam.Size = new Size(315, 27);
			this.tbTeam.TabIndex = 99;
			this.tbTeam.TabStop = false;
			this.label26.Dock = DockStyle.Left;
			this.label26.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label26.Location = new Point(0, 0);
			this.label26.Name = "label26";
			this.label26.Size = new Size(47, 27);
			this.label26.TabIndex = 75;
			this.label26.Text = "Dept.";
			this.panel1.Controls.Add(this.tbName);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(3, 17);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new Padding(0, 0, 0, 1);
			this.panel1.Size = new Size(362, 23);
			this.panel1.TabIndex = 80;
			this.tbName.BackColor = Color.Gainsboro;
			this.tbName.Dock = DockStyle.Fill;
			this.tbName.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbName.Location = new Point(47, 0);
			this.tbName.Name = "tbName";
			this.tbName.ReadOnly = true;
			this.tbName.Size = new Size(315, 23);
			this.tbName.TabIndex = 78;
			this.tbName.TabStop = false;
			this.label10.Dock = DockStyle.Left;
			this.label10.Font = new Font("굴림", 9f);
			this.label10.Location = new Point(0, 0);
			this.label10.Name = "label10";
			this.label10.Size = new Size(47, 22);
			this.label10.TabIndex = 77;
			this.label10.Text = "Name";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.groupBox7);
			base.Name = "RequestUserInformation";
			base.Size = new Size(368, 234);
			this.groupBox7.ResumeLayout(false);
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

		// Token: 0x0400040D RID: 1037
		private IContainer components = null;

		// Token: 0x0400040E RID: 1038
		private GroupBox groupBox7;

		// Token: 0x0400040F RID: 1039
		private Label label26;

		// Token: 0x04000410 RID: 1040
		private TextBox tbCCList;

		// Token: 0x04000411 RID: 1041
		private TextBox tbTeam;

		// Token: 0x04000412 RID: 1042
		private Label label12;

		// Token: 0x04000413 RID: 1043
		private TextBox tbName;

		// Token: 0x04000414 RID: 1044
		private Label label10;

		// Token: 0x04000415 RID: 1045
		private TextBox tbToList;

		// Token: 0x04000416 RID: 1046
		private Label label11;

		// Token: 0x04000417 RID: 1047
		private Panel panel1;

		// Token: 0x04000418 RID: 1048
		private Panel panel4;

		// Token: 0x04000419 RID: 1049
		private Panel panel3;

		// Token: 0x0400041A RID: 1050
		private Panel panel2;
	}
}
