using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst.Class;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Final
{
	// Token: 0x02000025 RID: 37
	public class FinalInformation : UserControl
	{
		// Token: 0x06000275 RID: 629 RVA: 0x000571CF File Offset: 0x000553CF
		public string getFinalTimeText()
		{
			return this.tbFinalTime.Text.Trim();
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000571E4 File Offset: 0x000553E4
		public void setFinalTime()
		{
			this.tbFinalTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00057210 File Offset: 0x00055410
		public FinalInformation(cReportItem report)
		{
			this.InitializeComponent();
			bool flag = report.sReportStauts == "14";
			if (flag)
			{
				this.tbFinalTime.Text = report.sPMFinalTime;
			}
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0005725C File Offset: 0x0005545C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00057294 File Offset: 0x00055494
		private void InitializeComponent()
		{
			this.pnFinalInfo = new Panel();
			this.pnFinalTime = new Panel();
			this.tbFinalTime = new TextBox();
			this.label39 = new Label();
			this.pnFinalInfo.SuspendLayout();
			this.pnFinalTime.SuspendLayout();
			base.SuspendLayout();
			this.pnFinalInfo.Controls.Add(this.pnFinalTime);
			this.pnFinalInfo.Dock = DockStyle.Top;
			this.pnFinalInfo.Location = new Point(0, 0);
			this.pnFinalInfo.Name = "pnFinalInfo";
			this.pnFinalInfo.Padding = new Padding(0, 0, 0, 3);
			this.pnFinalInfo.Size = new Size(922, 47);
			this.pnFinalInfo.TabIndex = 90;
			this.pnFinalTime.Controls.Add(this.tbFinalTime);
			this.pnFinalTime.Controls.Add(this.label39);
			this.pnFinalTime.Dock = DockStyle.Left;
			this.pnFinalTime.Location = new Point(0, 0);
			this.pnFinalTime.Name = "pnFinalTime";
			this.pnFinalTime.Padding = new Padding(0, 0, 3, 0);
			this.pnFinalTime.Size = new Size(212, 44);
			this.pnFinalTime.TabIndex = 87;
			this.tbFinalTime.BackColor = Color.Gainsboro;
			this.tbFinalTime.Dock = DockStyle.Fill;
			this.tbFinalTime.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbFinalTime.Location = new Point(0, 17);
			this.tbFinalTime.Name = "tbFinalTime";
			this.tbFinalTime.ReadOnly = true;
			this.tbFinalTime.Size = new Size(209, 23);
			this.tbFinalTime.TabIndex = 30;
			this.label39.AutoSize = true;
			this.label39.Dock = DockStyle.Top;
			this.label39.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label39.Location = new Point(0, 0);
			this.label39.Name = "label39";
			this.label39.Size = new Size(66, 17);
			this.label39.TabIndex = 29;
			this.label39.Text = "Final Time";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.pnFinalInfo);
			base.Name = "FinalInformation";
			base.Size = new Size(922, 50);
			this.pnFinalInfo.ResumeLayout(false);
			this.pnFinalTime.ResumeLayout(false);
			this.pnFinalTime.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000476 RID: 1142
		private IContainer components = null;

		// Token: 0x04000477 RID: 1143
		private Panel pnFinalInfo;

		// Token: 0x04000478 RID: 1144
		private Panel pnFinalTime;

		// Token: 0x04000479 RID: 1145
		private TextBox tbFinalTime;

		// Token: 0x0400047A RID: 1146
		private Label label39;
	}
}
