using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst.Class;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Approval
{
	// Token: 0x02000023 RID: 35
	public class ApInformation : UserControl
	{
		// Token: 0x06000264 RID: 612 RVA: 0x00056398 File Offset: 0x00054598
		public void setApprovalTime()
		{
			this.tbApprovalTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
		}

		// Token: 0x06000265 RID: 613 RVA: 0x000563C3 File Offset: 0x000545C3
		public string getApprovalTime()
		{
			return this.tbApprovalTime.Text.Trim();
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000563D5 File Offset: 0x000545D5
		public string getRequestTime()
		{
			return this.tbRequestTime2.Text.Trim();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000563E8 File Offset: 0x000545E8
		public ApInformation(cReportItem report)
		{
			this.InitializeComponent();
			this.tbRequestTime2.Text = report.sRequestTime;
			this.pnApprovalTime.Visible = true;
			bool flag = report.sReportStauts == "11";
			if (flag)
			{
				this.pnApprovalTime.Visible = false;
			}
			else
			{
				bool flag2 = report.sReportStauts == "12" || report.sReportStauts == "96";
				if (flag2)
				{
					this.pnApprovalTime.Visible = true;
					this.tbApprovalTime.Text = report.sApprovalTime;
				}
				else
				{
					bool flag3 = report.sReportStauts == "13" || report.sReportStauts == "14";
					if (flag3)
					{
						this.pnApprovalTime.Visible = true;
						this.tbApprovalTime.Text = report.sApprovalTime;
					}
					else
					{
						bool flag4 = report.sReportStauts == "97" || report.sReportStauts == "98";
						if (flag4)
						{
							this.pnApprovalTime.Visible = false;
						}
					}
				}
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00056528 File Offset: 0x00054728
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00056560 File Offset: 0x00054760
		private void InitializeComponent()
		{
			this.pnApprovalTime = new Panel();
			this.tbApprovalTime = new TextBox();
			this.label37 = new Label();
			this.panel22 = new Panel();
			this.tbRequestTime2 = new TextBox();
			this.label20 = new Label();
			this.pnApprovalTime.SuspendLayout();
			this.panel22.SuspendLayout();
			base.SuspendLayout();
			this.pnApprovalTime.Controls.Add(this.tbApprovalTime);
			this.pnApprovalTime.Controls.Add(this.label37);
			this.pnApprovalTime.Dock = DockStyle.Left;
			this.pnApprovalTime.Location = new Point(212, 0);
			this.pnApprovalTime.Name = "pnApprovalTime";
			this.pnApprovalTime.Size = new Size(233, 42);
			this.pnApprovalTime.TabIndex = 35;
			this.pnApprovalTime.Visible = false;
			this.tbApprovalTime.BackColor = Color.Gainsboro;
			this.tbApprovalTime.Dock = DockStyle.Fill;
			this.tbApprovalTime.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbApprovalTime.Location = new Point(0, 17);
			this.tbApprovalTime.Name = "tbApprovalTime";
			this.tbApprovalTime.ReadOnly = true;
			this.tbApprovalTime.Size = new Size(233, 23);
			this.tbApprovalTime.TabIndex = 26;
			this.label37.AutoSize = true;
			this.label37.Dock = DockStyle.Top;
			this.label37.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label37.Location = new Point(0, 0);
			this.label37.Name = "label37";
			this.label37.Size = new Size(93, 17);
			this.label37.TabIndex = 25;
			this.label37.Text = "Approval Time";
			this.panel22.Controls.Add(this.tbRequestTime2);
			this.panel22.Controls.Add(this.label20);
			this.panel22.Dock = DockStyle.Left;
			this.panel22.Location = new Point(0, 0);
			this.panel22.Name = "panel22";
			this.panel22.Padding = new Padding(0, 0, 3, 0);
			this.panel22.Size = new Size(212, 42);
			this.panel22.TabIndex = 87;
			this.tbRequestTime2.BackColor = Color.Gainsboro;
			this.tbRequestTime2.Dock = DockStyle.Fill;
			this.tbRequestTime2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbRequestTime2.Location = new Point(0, 17);
			this.tbRequestTime2.Name = "tbRequestTime2";
			this.tbRequestTime2.ReadOnly = true;
			this.tbRequestTime2.Size = new Size(209, 23);
			this.tbRequestTime2.TabIndex = 30;
			this.label20.AutoSize = true;
			this.label20.Dock = DockStyle.Top;
			this.label20.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label20.Location = new Point(0, 0);
			this.label20.Name = "label20";
			this.label20.Size = new Size(87, 17);
			this.label20.TabIndex = 29;
			this.label20.Text = "Request Time";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.pnApprovalTime);
			base.Controls.Add(this.panel22);
			base.Name = "ApInformation";
			base.Size = new Size(453, 42);
			this.pnApprovalTime.ResumeLayout(false);
			this.pnApprovalTime.PerformLayout();
			this.panel22.ResumeLayout(false);
			this.panel22.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000467 RID: 1127
		private IContainer components = null;

		// Token: 0x04000468 RID: 1128
		private Panel pnApprovalTime;

		// Token: 0x04000469 RID: 1129
		private TextBox tbApprovalTime;

		// Token: 0x0400046A RID: 1130
		private Label label37;

		// Token: 0x0400046B RID: 1131
		private Panel panel22;

		// Token: 0x0400046C RID: 1132
		private TextBox tbRequestTime2;

		// Token: 0x0400046D RID: 1133
		private Label label20;
	}
}
