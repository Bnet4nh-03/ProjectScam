using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst.Class;

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x0200004F RID: 79
	public class RequestUserInformation : UserControl
	{
		// Token: 0x06000459 RID: 1113 RVA: 0x0008138C File Offset: 0x0007F58C
		public RequestUserInformation(cReportItem report)
		{
			this.InitializeComponent();
			this.tbName.Text = report.sName;
			this.tbTeam.Text = report.sTeam;
			string[] array = report.sToEmail.Trim().Split(new char[]
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
			array = report.sCCEmail.Trim().Split(new char[]
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

		// Token: 0x0600045A RID: 1114 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void panel52_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x000814D4 File Offset: 0x0007F6D4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0008150C File Offset: 0x0007F70C
		private void InitializeComponent()
		{
			this.groupBox7 = new GroupBox();
			this.panel55 = new Panel();
			this.tbCCList = new TextBox();
			this.label12 = new Label();
			this.panel54 = new Panel();
			this.tbToList = new TextBox();
			this.label11 = new Label();
			this.panel53 = new Panel();
			this.tbTeam = new TextBox();
			this.label26 = new Label();
			this.panel52 = new Panel();
			this.tbName = new TextBox();
			this.label10 = new Label();
			this.groupBox7.SuspendLayout();
			this.panel55.SuspendLayout();
			this.panel54.SuspendLayout();
			this.panel53.SuspendLayout();
			this.panel52.SuspendLayout();
			base.SuspendLayout();
			this.groupBox7.Controls.Add(this.panel55);
			this.groupBox7.Controls.Add(this.panel54);
			this.groupBox7.Controls.Add(this.panel53);
			this.groupBox7.Controls.Add(this.panel52);
			this.groupBox7.Dock = DockStyle.Top;
			this.groupBox7.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold);
			this.groupBox7.Location = new Point(0, 0);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new Size(393, 243);
			this.groupBox7.TabIndex = 79;
			this.groupBox7.TabStop = false;
			this.panel55.Controls.Add(this.tbCCList);
			this.panel55.Controls.Add(this.label12);
			this.panel55.Dock = DockStyle.Fill;
			this.panel55.Location = new Point(3, 149);
			this.panel55.Name = "panel55";
			this.panel55.Padding = new Padding(0, 0, 0, 3);
			this.panel55.Size = new Size(387, 91);
			this.panel55.TabIndex = 102;
			this.tbCCList.BackColor = Color.Gainsboro;
			this.tbCCList.Dock = DockStyle.Fill;
			this.tbCCList.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbCCList.Location = new Point(42, 0);
			this.tbCCList.Multiline = true;
			this.tbCCList.Name = "tbCCList";
			this.tbCCList.ReadOnly = true;
			this.tbCCList.ScrollBars = ScrollBars.Vertical;
			this.tbCCList.Size = new Size(345, 88);
			this.tbCCList.TabIndex = 82;
			this.tbCCList.TabStop = false;
			this.label12.Dock = DockStyle.Left;
			this.label12.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label12.Location = new Point(0, 0);
			this.label12.Name = "label12";
			this.label12.Size = new Size(42, 88);
			this.label12.TabIndex = 81;
			this.label12.Text = "CC List";
			this.panel54.Controls.Add(this.tbToList);
			this.panel54.Controls.Add(this.label11);
			this.panel54.Dock = DockStyle.Top;
			this.panel54.Location = new Point(3, 76);
			this.panel54.Name = "panel54";
			this.panel54.Padding = new Padding(0, 0, 0, 3);
			this.panel54.Size = new Size(387, 73);
			this.panel54.TabIndex = 101;
			this.tbToList.BackColor = Color.Gainsboro;
			this.tbToList.Dock = DockStyle.Fill;
			this.tbToList.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbToList.Location = new Point(42, 0);
			this.tbToList.Multiline = true;
			this.tbToList.Name = "tbToList";
			this.tbToList.ReadOnly = true;
			this.tbToList.ScrollBars = ScrollBars.Vertical;
			this.tbToList.Size = new Size(345, 70);
			this.tbToList.TabIndex = 79;
			this.tbToList.TabStop = false;
			this.label11.Dock = DockStyle.Left;
			this.label11.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label11.Location = new Point(0, 0);
			this.label11.Name = "label11";
			this.label11.Size = new Size(42, 70);
			this.label11.TabIndex = 80;
			this.label11.Text = "To List";
			this.panel53.Controls.Add(this.tbTeam);
			this.panel53.Controls.Add(this.label26);
			this.panel53.Dock = DockStyle.Top;
			this.panel53.Location = new Point(3, 44);
			this.panel53.Name = "panel53";
			this.panel53.Padding = new Padding(0, 0, 0, 3);
			this.panel53.Size = new Size(387, 32);
			this.panel53.TabIndex = 100;
			this.tbTeam.BackColor = Color.Gainsboro;
			this.tbTeam.Dock = DockStyle.Fill;
			this.tbTeam.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbTeam.Location = new Point(42, 0);
			this.tbTeam.Multiline = true;
			this.tbTeam.Name = "tbTeam";
			this.tbTeam.ReadOnly = true;
			this.tbTeam.Size = new Size(345, 29);
			this.tbTeam.TabIndex = 99;
			this.tbTeam.TabStop = false;
			this.label26.Dock = DockStyle.Left;
			this.label26.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label26.Location = new Point(0, 0);
			this.label26.Name = "label26";
			this.label26.Size = new Size(42, 29);
			this.label26.TabIndex = 75;
			this.label26.Text = "Dept.";
			this.panel52.Controls.Add(this.tbName);
			this.panel52.Controls.Add(this.label10);
			this.panel52.Dock = DockStyle.Top;
			this.panel52.Location = new Point(3, 21);
			this.panel52.Name = "panel52";
			this.panel52.Padding = new Padding(0, 0, 0, 3);
			this.panel52.Size = new Size(387, 23);
			this.panel52.TabIndex = 101;
			this.panel52.Paint += this.panel52_Paint;
			this.tbName.BackColor = Color.Gainsboro;
			this.tbName.Dock = DockStyle.Fill;
			this.tbName.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbName.Location = new Point(43, 0);
			this.tbName.Name = "tbName";
			this.tbName.ReadOnly = true;
			this.tbName.Size = new Size(344, 23);
			this.tbName.TabIndex = 78;
			this.tbName.TabStop = false;
			this.label10.Dock = DockStyle.Left;
			this.label10.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label10.Location = new Point(0, 0);
			this.label10.Name = "label10";
			this.label10.Size = new Size(43, 20);
			this.label10.TabIndex = 77;
			this.label10.Text = "Name";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.groupBox7);
			base.Name = "RequestUserInformation";
			base.Size = new Size(393, 251);
			this.groupBox7.ResumeLayout(false);
			this.panel55.ResumeLayout(false);
			this.panel55.PerformLayout();
			this.panel54.ResumeLayout(false);
			this.panel54.PerformLayout();
			this.panel53.ResumeLayout(false);
			this.panel53.PerformLayout();
			this.panel52.ResumeLayout(false);
			this.panel52.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000708 RID: 1800
		private IContainer components = null;

		// Token: 0x04000709 RID: 1801
		private GroupBox groupBox7;

		// Token: 0x0400070A RID: 1802
		private Panel panel55;

		// Token: 0x0400070B RID: 1803
		private TextBox tbCCList;

		// Token: 0x0400070C RID: 1804
		private Label label12;

		// Token: 0x0400070D RID: 1805
		private Panel panel54;

		// Token: 0x0400070E RID: 1806
		private TextBox tbToList;

		// Token: 0x0400070F RID: 1807
		private Label label11;

		// Token: 0x04000710 RID: 1808
		private Panel panel53;

		// Token: 0x04000711 RID: 1809
		private TextBox tbTeam;

		// Token: 0x04000712 RID: 1810
		private Label label26;

		// Token: 0x04000713 RID: 1811
		private Panel panel52;

		// Token: 0x04000714 RID: 1812
		private TextBox tbName;

		// Token: 0x04000715 RID: 1813
		private Label label10;
	}
}
