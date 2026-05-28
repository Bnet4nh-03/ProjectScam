namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x02000009 RID: 9
	public partial class Report : global::ATDFW.Controls.BaseWinForm.BaseWinView, global::Amkor.CADModules.Maintenance.GrobalConst.Interface.IHCC
	{
		// Token: 0x0600002B RID: 43 RVA: 0x000044E0 File Offset: 0x000026E0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00004518 File Offset: 0x00002718
		private void InitializeComponent()
		{
			this.btnClear = new global::System.Windows.Forms.Button();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.cbOutLook = new global::System.Windows.Forms.CheckBox();
			this.pnReportContent = new global::System.Windows.Forms.Panel();
			this.panel17 = new global::System.Windows.Forms.Panel();
			this.pnBoardInformation = new global::System.Windows.Forms.Panel();
			this.pnReportAttach = new global::System.Windows.Forms.Panel();
			this.pnHccInformation = new global::System.Windows.Forms.Panel();
			this.pnReportInformation = new global::System.Windows.Forms.Panel();
			this.pnUserInformation = new global::System.Windows.Forms.Panel();
			this.Panel99 = new global::System.Windows.Forms.Panel();
			this.pbClear = new global::System.Windows.Forms.PictureBox();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.pbSubmit = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel_Preview = new global::System.Windows.Forms.Panel();
			this.webBrowser1 = new global::System.Windows.Forms.WebBrowser();
			this.btn_Close = new global::System.Windows.Forms.Button();
			this.panel6.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panel17.SuspendLayout();
			this.Panel99.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbSubmit).BeginInit();
			this.panel_Preview.SuspendLayout();
			base.SuspendLayout();
			this.btnClear.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClear.Location = new global::System.Drawing.Point(937, 78);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new global::System.Drawing.Size(81, 26);
			this.btnClear.TabIndex = 36;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Visible = false;
			this.btnClear.Click += new global::System.EventHandler(this.btnClear_Click);
			this.panel6.Controls.Add(this.groupBox4);
			this.panel6.Controls.Add(this.pnHccInformation);
			this.panel6.Controls.Add(this.pnReportInformation);
			this.panel6.Controls.Add(this.pnUserInformation);
			this.panel6.Controls.Add(this.Panel99);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new global::System.Drawing.Point(0, 0);
			this.panel6.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(1837, 687);
			this.panel6.TabIndex = 76;
			this.groupBox4.Controls.Add(this.cbOutLook);
			this.groupBox4.Controls.Add(this.btnClear);
			this.groupBox4.Controls.Add(this.pnReportContent);
			this.groupBox4.Controls.Add(this.panel17);
			this.groupBox4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Location = new global::System.Drawing.Point(233, 144);
			this.groupBox4.Margin = new global::System.Windows.Forms.Padding(0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new global::System.Windows.Forms.Padding(3, 0, 3, 3);
			this.groupBox4.Size = new global::System.Drawing.Size(1604, 496);
			this.groupBox4.TabIndex = 73;
			this.groupBox4.TabStop = false;
			this.cbOutLook.AutoSize = true;
			this.cbOutLook.Location = new global::System.Drawing.Point(803, 277);
			this.cbOutLook.Name = "cbOutLook";
			this.cbOutLook.Size = new global::System.Drawing.Size(122, 21);
			this.cbOutLook.TabIndex = 41;
			this.cbOutLook.Text = "OutLook Display";
			this.cbOutLook.UseVisualStyleBackColor = true;
			this.cbOutLook.Visible = false;
			this.pnReportContent.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnReportContent.Location = new global::System.Drawing.Point(3, 18);
			this.pnReportContent.Name = "pnReportContent";
			this.pnReportContent.Padding = new global::System.Windows.Forms.Padding(3, 0, 0, 3);
			this.pnReportContent.Size = new global::System.Drawing.Size(1161, 475);
			this.pnReportContent.TabIndex = 69;
			this.panel17.Controls.Add(this.pnBoardInformation);
			this.panel17.Controls.Add(this.pnReportAttach);
			this.panel17.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel17.Location = new global::System.Drawing.Point(1164, 18);
			this.panel17.Name = "panel17";
			this.panel17.Padding = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.panel17.Size = new global::System.Drawing.Size(437, 475);
			this.panel17.TabIndex = 40;
			this.pnBoardInformation.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnBoardInformation.Font = new global::System.Drawing.Font("굴림", 9f);
			this.pnBoardInformation.Location = new global::System.Drawing.Point(3, 207);
			this.pnBoardInformation.Name = "pnBoardInformation";
			this.pnBoardInformation.Size = new global::System.Drawing.Size(434, 268);
			this.pnBoardInformation.TabIndex = 69;
			this.pnReportAttach.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnReportAttach.Font = new global::System.Drawing.Font("굴림", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.pnReportAttach.Location = new global::System.Drawing.Point(3, 0);
			this.pnReportAttach.Name = "pnReportAttach";
			this.pnReportAttach.Size = new global::System.Drawing.Size(434, 207);
			this.pnReportAttach.TabIndex = 72;
			this.pnHccInformation.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnHccInformation.Font = new global::System.Drawing.Font("굴림", 9f);
			this.pnHccInformation.Location = new global::System.Drawing.Point(233, 71);
			this.pnHccInformation.Name = "pnHccInformation";
			this.pnHccInformation.Size = new global::System.Drawing.Size(1604, 73);
			this.pnHccInformation.TabIndex = 79;
			this.pnReportInformation.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnReportInformation.Font = new global::System.Drawing.Font("굴림", 9f);
			this.pnReportInformation.Location = new global::System.Drawing.Point(233, 0);
			this.pnReportInformation.Name = "pnReportInformation";
			this.pnReportInformation.Size = new global::System.Drawing.Size(1604, 71);
			this.pnReportInformation.TabIndex = 78;
			this.pnUserInformation.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnUserInformation.Font = new global::System.Drawing.Font("굴림", 9f);
			this.pnUserInformation.Location = new global::System.Drawing.Point(0, 0);
			this.pnUserInformation.Name = "pnUserInformation";
			this.pnUserInformation.Size = new global::System.Drawing.Size(233, 640);
			this.pnUserInformation.TabIndex = 74;
			this.Panel99.Controls.Add(this.pbClear);
			this.Panel99.Controls.Add(this.panel18);
			this.Panel99.Controls.Add(this.pbSubmit);
			this.Panel99.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.Panel99.Location = new global::System.Drawing.Point(0, 640);
			this.Panel99.Margin = new global::System.Windows.Forms.Padding(0);
			this.Panel99.Name = "Panel99";
			this.Panel99.Size = new global::System.Drawing.Size(1837, 47);
			this.Panel99.TabIndex = 79;
			this.pbClear.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbClear.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbClear.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbClear.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbClear.Location = new global::System.Drawing.Point(1718, 0);
			this.pbClear.Name = "pbClear";
			this.pbClear.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbClear.Size = new global::System.Drawing.Size(48, 47);
			this.pbClear.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbClear.TabIndex = 41;
			this.pbClear.TabStop = false;
			this.pbClear.Click += new global::System.EventHandler(this.pbClear_Click);
			this.pbClear.MouseEnter += new global::System.EventHandler(this.pbClear_MouseEnter);
			this.pbClear.MouseLeave += new global::System.EventHandler(this.pbClear_MouseLeave);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel18.Location = new global::System.Drawing.Point(1766, 0);
			this.panel18.Name = "panel18";
			this.panel18.Size = new global::System.Drawing.Size(23, 47);
			this.panel18.TabIndex = 40;
			this.pbSubmit.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbSubmit.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbSubmit.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.submit;
			this.pbSubmit.Location = new global::System.Drawing.Point(1789, 0);
			this.pbSubmit.Name = "pbSubmit";
			this.pbSubmit.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbSubmit.Size = new global::System.Drawing.Size(48, 47);
			this.pbSubmit.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbSubmit.TabIndex = 10;
			this.pbSubmit.TabStop = false;
			this.pbSubmit.Click += new global::System.EventHandler(this.pbSubmit_Click);
			this.pbSubmit.MouseEnter += new global::System.EventHandler(this.pbSubmit_MouseEnter);
			this.pbSubmit.MouseLeave += new global::System.EventHandler(this.pbSubmit_MouseLeave);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1837, 687);
			this.panel1.TabIndex = 87;
			this.panel_Preview.Controls.Add(this.webBrowser1);
			this.panel_Preview.Controls.Add(this.btn_Close);
			this.panel_Preview.Location = new global::System.Drawing.Point(750, 229);
			this.panel_Preview.Name = "panel_Preview";
			this.panel_Preview.Size = new global::System.Drawing.Size(336, 229);
			this.panel_Preview.TabIndex = 89;
			this.panel_Preview.Visible = false;
			this.webBrowser1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new global::System.Drawing.Point(0, 0);
			this.webBrowser1.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new global::System.Drawing.Size(336, 190);
			this.webBrowser1.TabIndex = 0;
			this.btn_Close.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.btn_Close.Font = new global::System.Drawing.Font("Segoe UI Symbol", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btn_Close.Location = new global::System.Drawing.Point(0, 190);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new global::System.Drawing.Size(336, 39);
			this.btn_Close.TabIndex = 1;
			this.btn_Close.Text = "Close";
			this.btn_Close.UseVisualStyleBackColor = true;
			this.btn_Close.Click += new global::System.EventHandler(this.button2_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1837, 687);
			base.Controls.Add(this.panel_Preview);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.panel1);
			this.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Report";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Shown += new global::System.EventHandler(this.Report_Shown);
			this.panel6.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.panel17.ResumeLayout(false);
			this.Panel99.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbSubmit).EndInit();
			this.panel_Preview.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400002E RID: 46
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.Panel Panel99;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.PictureBox pbClear;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.PictureBox pbSubmit;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.Panel pnHccInformation;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.Panel pnReportInformation;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Panel pnUserInformation;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.Panel panel_Preview;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.WebBrowser webBrowser1;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.Button btn_Close;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.Panel pnReportAttach;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.Panel pnBoardInformation;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.Button btnClear;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.CheckBox cbOutLook;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.Panel pnReportContent;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.Panel panel17;
	}
}
