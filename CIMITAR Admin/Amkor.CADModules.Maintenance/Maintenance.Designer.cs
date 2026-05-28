namespace Amkor.CADModules.Maintenance
{
	// Token: 0x02000002 RID: 2
	public partial class Maintenance : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000025F4 File Offset: 0x000007F4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000262C File Offset: 0x0000082C
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.lbTitle = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tpMain = new global::System.Windows.Forms.TabControl();
			this.tbReport = new global::System.Windows.Forms.TabPage();
			this.tpPM = new global::System.Windows.Forms.TabPage();
			this.tbStatus = new global::System.Windows.Forms.TabPage();
			this.tbSearch = new global::System.Windows.Forms.TabPage();
			this.tpAdmin = new global::System.Windows.Forms.TabPage();
			this.tpTrend = new global::System.Windows.Forms.TabPage();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tpMain.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = global::System.Drawing.Color.White;
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1498, 33);
			this.panel1.TabIndex = 0;
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new global::System.Drawing.Font("Segoe UI Symbol", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lbTitle.Location = new global::System.Drawing.Point(6, 6);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new global::System.Drawing.Size(110, 21);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Maintenance";
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 671);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1498, 28);
			this.panel2.TabIndex = 3;
			this.label2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.label2.Location = new global::System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(1498, 28);
			this.label2.TabIndex = 3;
			this.label2.Text = "Copyright ⓒ 2024 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.tpMain.Controls.Add(this.tbReport);
			this.tpMain.Controls.Add(this.tpPM);
			this.tpMain.Controls.Add(this.tbStatus);
			this.tpMain.Controls.Add(this.tbSearch);
			this.tpMain.Controls.Add(this.tpAdmin);
			this.tpMain.Controls.Add(this.tpTrend);
			this.tpMain.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tpMain.Location = new global::System.Drawing.Point(0, 33);
			this.tpMain.Name = "tpMain";
			this.tpMain.SelectedIndex = 0;
			this.tpMain.Size = new global::System.Drawing.Size(1498, 638);
			this.tpMain.TabIndex = 4;
			this.tpMain.Selected += new global::System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
			this.tbReport.AutoScroll = true;
			this.tbReport.BackColor = global::System.Drawing.Color.White;
			this.tbReport.Location = new global::System.Drawing.Point(4, 22);
			this.tbReport.Name = "tbReport";
			this.tbReport.Padding = new global::System.Windows.Forms.Padding(3);
			this.tbReport.Size = new global::System.Drawing.Size(1490, 612);
			this.tbReport.TabIndex = 0;
			this.tbReport.Text = "Maint' Request";
			this.tpPM.Location = new global::System.Drawing.Point(4, 22);
			this.tpPM.Name = "tpPM";
			this.tpPM.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpPM.Size = new global::System.Drawing.Size(1490, 612);
			this.tpPM.TabIndex = 6;
			this.tpPM.Text = "PM Request";
			this.tpPM.UseVisualStyleBackColor = true;
			this.tbStatus.AutoScroll = true;
			this.tbStatus.Location = new global::System.Drawing.Point(4, 22);
			this.tbStatus.Name = "tbStatus";
			this.tbStatus.Padding = new global::System.Windows.Forms.Padding(3);
			this.tbStatus.Size = new global::System.Drawing.Size(1490, 612);
			this.tbStatus.TabIndex = 1;
			this.tbStatus.Text = "Status";
			this.tbStatus.UseVisualStyleBackColor = true;
			this.tbSearch.Location = new global::System.Drawing.Point(4, 22);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Padding = new global::System.Windows.Forms.Padding(3);
			this.tbSearch.Size = new global::System.Drawing.Size(1490, 612);
			this.tbSearch.TabIndex = 5;
			this.tbSearch.Text = "Search";
			this.tbSearch.UseVisualStyleBackColor = true;
			this.tpAdmin.AutoScroll = true;
			this.tpAdmin.Location = new global::System.Drawing.Point(4, 22);
			this.tpAdmin.Name = "tpAdmin";
			this.tpAdmin.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpAdmin.Size = new global::System.Drawing.Size(1490, 612);
			this.tpAdmin.TabIndex = 3;
			this.tpAdmin.Text = "Admin Setting";
			this.tpAdmin.UseVisualStyleBackColor = true;
			this.tpTrend.Location = new global::System.Drawing.Point(4, 22);
			this.tpTrend.Name = "tpTrend";
			this.tpTrend.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpTrend.Size = new global::System.Drawing.Size(1490, 612);
			this.tpTrend.TabIndex = 4;
			this.tpTrend.Text = "Analysis Trend";
			this.tpTrend.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1498, 699);
			base.Controls.Add(this.tpMain);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Name = "Maintenance";
			this.Text = "Maintenance";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Maintenance_FormClosing);
			base.Shown += new global::System.EventHandler(this.Maintenance_Shown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.tpMain.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400000C RID: 12
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Label lbTitle;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.TabControl tpMain;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.TabPage tbReport;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.TabPage tbStatus;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.TabPage tpAdmin;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.TabPage tpTrend;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.TabPage tbSearch;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.TabPage tpPM;
	}
}
