namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x0200000D RID: 13
	public partial class PMRequest : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x060000E3 RID: 227 RVA: 0x000267B8 File Offset: 0x000249B8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000267F0 File Offset: 0x000249F0
		private void InitializeComponent()
		{
			this.pnMain = new global::System.Windows.Forms.Panel();
			this.pnContent = new global::System.Windows.Forms.Panel();
			this.pnAttach = new global::System.Windows.Forms.Panel();
			this.pnPMInformation = new global::System.Windows.Forms.Panel();
			this.pnUserInformation = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel22 = new global::System.Windows.Forms.Panel();
			this.tbPMReport = new global::System.Windows.Forms.TextBox();
			this.pbClear = new global::System.Windows.Forms.PictureBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.pbPM = new global::System.Windows.Forms.PictureBox();
			this.panel_Preview = new global::System.Windows.Forms.Panel();
			this.webBrowser1 = new global::System.Windows.Forms.WebBrowser();
			this.btn_Close = new global::System.Windows.Forms.Button();
			this.pnMain.SuspendLayout();
			this.panel22.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbPM).BeginInit();
			this.panel_Preview.SuspendLayout();
			base.SuspendLayout();
			this.pnMain.Controls.Add(this.pnContent);
			this.pnMain.Controls.Add(this.pnAttach);
			this.pnMain.Controls.Add(this.pnPMInformation);
			this.pnMain.Controls.Add(this.pnUserInformation);
			this.pnMain.Controls.Add(this.panel1);
			this.pnMain.Controls.Add(this.panel22);
			this.pnMain.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnMain.Location = new global::System.Drawing.Point(0, 0);
			this.pnMain.Name = "pnMain";
			this.pnMain.Size = new global::System.Drawing.Size(1487, 510);
			this.pnMain.TabIndex = 0;
			this.pnContent.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnContent.Location = new global::System.Drawing.Point(282, 153);
			this.pnContent.Name = "pnContent";
			this.pnContent.Size = new global::System.Drawing.Size(768, 309);
			this.pnContent.TabIndex = 8;
			this.pnAttach.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pnAttach.Location = new global::System.Drawing.Point(1050, 153);
			this.pnAttach.Name = "pnAttach";
			this.pnAttach.Padding = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.pnAttach.Size = new global::System.Drawing.Size(437, 309);
			this.pnAttach.TabIndex = 41;
			this.pnAttach.Visible = false;
			this.pnPMInformation.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnPMInformation.Location = new global::System.Drawing.Point(282, 0);
			this.pnPMInformation.Name = "pnPMInformation";
			this.pnPMInformation.Size = new global::System.Drawing.Size(1205, 153);
			this.pnPMInformation.TabIndex = 76;
			this.pnUserInformation.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnUserInformation.Location = new global::System.Drawing.Point(0, 0);
			this.pnUserInformation.Name = "pnUserInformation";
			this.pnUserInformation.Size = new global::System.Drawing.Size(282, 462);
			this.pnUserInformation.TabIndex = 2;
			this.panel1.AutoSize = true;
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1487, 0);
			this.panel1.TabIndex = 0;
			this.panel22.Controls.Add(this.tbPMReport);
			this.panel22.Controls.Add(this.pbClear);
			this.panel22.Controls.Add(this.panel2);
			this.panel22.Controls.Add(this.pbPM);
			this.panel22.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel22.Location = new global::System.Drawing.Point(0, 462);
			this.panel22.Name = "panel22";
			this.panel22.Size = new global::System.Drawing.Size(1487, 48);
			this.panel22.TabIndex = 7;
			this.tbPMReport.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbPMReport.Location = new global::System.Drawing.Point(269, 3);
			this.tbPMReport.Name = "tbPMReport";
			this.tbPMReport.Size = new global::System.Drawing.Size(140, 25);
			this.tbPMReport.TabIndex = 75;
			this.tbPMReport.Visible = false;
			this.pbClear.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbClear.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbClear.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbClear.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbClear.Location = new global::System.Drawing.Point(1368, 0);
			this.pbClear.Name = "pbClear";
			this.pbClear.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbClear.Size = new global::System.Drawing.Size(48, 48);
			this.pbClear.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbClear.TabIndex = 51;
			this.pbClear.TabStop = false;
			this.pbClear.Click += new global::System.EventHandler(this.pbClear_Click);
			this.pbClear.MouseEnter += new global::System.EventHandler(this.pbClear_MouseEnter);
			this.pbClear.MouseLeave += new global::System.EventHandler(this.pbClear_MouseLeave);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new global::System.Drawing.Point(1416, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(23, 48);
			this.panel2.TabIndex = 50;
			this.pbPM.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbPM.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbPM.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.pm;
			this.pbPM.Location = new global::System.Drawing.Point(1439, 0);
			this.pbPM.Name = "pbPM";
			this.pbPM.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbPM.Size = new global::System.Drawing.Size(48, 48);
			this.pbPM.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbPM.TabIndex = 65;
			this.pbPM.TabStop = false;
			this.pbPM.Click += new global::System.EventHandler(this.pbPM_Click);
			this.pbPM.MouseEnter += new global::System.EventHandler(this.pbPM_MouseEnter);
			this.pbPM.MouseLeave += new global::System.EventHandler(this.pbPM_MouseLeave);
			this.panel_Preview.Controls.Add(this.webBrowser1);
			this.panel_Preview.Controls.Add(this.btn_Close);
			this.panel_Preview.Location = new global::System.Drawing.Point(892, 437);
			this.panel_Preview.Name = "panel_Preview";
			this.panel_Preview.Size = new global::System.Drawing.Size(200, 100);
			this.panel_Preview.TabIndex = 74;
			this.panel_Preview.Visible = false;
			this.webBrowser1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new global::System.Drawing.Point(0, 0);
			this.webBrowser1.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new global::System.Drawing.Size(200, 61);
			this.webBrowser1.TabIndex = 0;
			this.btn_Close.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.btn_Close.Font = new global::System.Drawing.Font("Segoe UI Symbol", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btn_Close.Location = new global::System.Drawing.Point(0, 61);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new global::System.Drawing.Size(200, 39);
			this.btn_Close.TabIndex = 1;
			this.btn_Close.Text = "Close";
			this.btn_Close.UseVisualStyleBackColor = true;
			this.btn_Close.Click += new global::System.EventHandler(this.btn_Close_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(1487, 510);
			base.Controls.Add(this.panel_Preview);
			base.Controls.Add(this.pnMain);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "PMRequest";
			this.Text = "PM";
			this.pnMain.ResumeLayout(false);
			this.pnMain.PerformLayout();
			this.panel22.ResumeLayout(false);
			this.panel22.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbPM).EndInit();
			this.panel_Preview.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040001E6 RID: 486
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040001E7 RID: 487
		private global::System.Windows.Forms.Panel pnMain;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.Panel pnUserInformation;

		// Token: 0x040001E9 RID: 489
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040001EA RID: 490
		private global::System.Windows.Forms.Panel panel22;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.PictureBox pbClear;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040001ED RID: 493
		private global::System.Windows.Forms.Panel panel_Preview;

		// Token: 0x040001EE RID: 494
		private global::System.Windows.Forms.WebBrowser webBrowser1;

		// Token: 0x040001EF RID: 495
		private global::System.Windows.Forms.Button btn_Close;

		// Token: 0x040001F0 RID: 496
		private global::System.Windows.Forms.TextBox tbPMReport;

		// Token: 0x040001F1 RID: 497
		private global::System.Windows.Forms.PictureBox pbPM;

		// Token: 0x040001F2 RID: 498
		private global::System.Windows.Forms.Panel pnContent;

		// Token: 0x040001F3 RID: 499
		private global::System.Windows.Forms.Panel pnAttach;

		// Token: 0x040001F4 RID: 500
		private global::System.Windows.Forms.Panel pnPMInformation;
	}
}
