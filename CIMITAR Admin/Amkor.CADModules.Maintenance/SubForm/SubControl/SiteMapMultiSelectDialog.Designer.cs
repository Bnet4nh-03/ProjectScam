namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000042 RID: 66
	public partial class SiteMapMultiSelectDialog : global::System.Windows.Forms.Form, global::Amkor.CADModules.Maintenance.GrobalConst.Interface.IHCC
	{
		// Token: 0x060003E4 RID: 996 RVA: 0x00072DDC File Offset: 0x00070FDC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00072E14 File Offset: 0x00071014
		private void InitializeComponent()
		{
			this.pnBase = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pnManualReject = new global::System.Windows.Forms.Panel();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.pnRejectReason = new global::System.Windows.Forms.Panel();
			this.tbFactor = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.tabPage3 = new global::System.Windows.Forms.TabPage();
			this.tabPage4 = new global::System.Windows.Forms.TabPage();
			this.rbManaulReject = new global::System.Windows.Forms.RadioButton();
			this.rbDisable = new global::System.Windows.Forms.RadioButton();
			this.rbSiteReject = new global::System.Windows.Forms.RadioButton();
			this.rbSiteGood = new global::System.Windows.Forms.RadioButton();
			this.lbTitle = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.pbOK = new global::System.Windows.Forms.PictureBox();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.pbCancel = new global::System.Windows.Forms.PictureBox();
			this.pnBase.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnManualReject.SuspendLayout();
			this.pnRejectReason.SuspendLayout();
			this.tbFactor.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbOK).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).BeginInit();
			base.SuspendLayout();
			this.pnBase.Controls.Add(this.panel1);
			this.pnBase.Controls.Add(this.panel2);
			this.pnBase.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnBase.Location = new global::System.Drawing.Point(0, 0);
			this.pnBase.Name = "pnBase";
			this.pnBase.Size = new global::System.Drawing.Size(318, 351);
			this.pnBase.TabIndex = 0;
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.pnManualReject);
			this.panel1.Controls.Add(this.pnRejectReason);
			this.panel1.Controls.Add(this.rbManaulReject);
			this.panel1.Controls.Add(this.rbDisable);
			this.panel1.Controls.Add(this.rbSiteReject);
			this.panel1.Controls.Add(this.rbSiteGood);
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(1);
			this.panel1.Size = new global::System.Drawing.Size(318, 302);
			this.panel1.TabIndex = 0;
			this.pnManualReject.Controls.Add(this.textBox1);
			this.pnManualReject.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnManualReject.Location = new global::System.Drawing.Point(1, 275);
			this.pnManualReject.Name = "pnManualReject";
			this.pnManualReject.Padding = new global::System.Windows.Forms.Padding(1);
			this.pnManualReject.Size = new global::System.Drawing.Size(314, 24);
			this.pnManualReject.TabIndex = 6;
			this.textBox1.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.textBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new global::System.Drawing.Point(1, 1);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(312, 22);
			this.textBox1.TabIndex = 0;
			this.pnRejectReason.AutoScroll = true;
			this.pnRejectReason.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnRejectReason.Controls.Add(this.tbFactor);
			this.pnRejectReason.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnRejectReason.Location = new global::System.Drawing.Point(1, 107);
			this.pnRejectReason.Name = "pnRejectReason";
			this.pnRejectReason.Padding = new global::System.Windows.Forms.Padding(1);
			this.pnRejectReason.Size = new global::System.Drawing.Size(314, 168);
			this.pnRejectReason.TabIndex = 3;
			this.pnRejectReason.Visible = false;
			this.tbFactor.Controls.Add(this.tabPage1);
			this.tbFactor.Controls.Add(this.tabPage2);
			this.tbFactor.Controls.Add(this.tabPage3);
			this.tbFactor.Controls.Add(this.tabPage4);
			this.tbFactor.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbFactor.Font = new global::System.Drawing.Font("휴먼둥근헤드라인", 9.75f);
			this.tbFactor.Location = new global::System.Drawing.Point(1, 1);
			this.tbFactor.Name = "tbFactor";
			this.tbFactor.SelectedIndex = 0;
			this.tbFactor.Size = new global::System.Drawing.Size(310, 164);
			this.tbFactor.TabIndex = 4;
			this.tabPage1.AutoScroll = true;
			this.tabPage1.Location = new global::System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(302, 137);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "HARDWARE";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage2.Location = new global::System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(302, 137);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "CONTACT";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.tabPage3.Location = new global::System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new global::System.Drawing.Size(302, 137);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "FUNCTION";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.tabPage4.Location = new global::System.Drawing.Point(4, 23);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new global::System.Drawing.Size(302, 137);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "OTHER";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.rbManaulReject.AutoSize = true;
			this.rbManaulReject.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.rbManaulReject.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.rbManaulReject.Font = new global::System.Drawing.Font("휴먼둥근헤드라인", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.rbManaulReject.Location = new global::System.Drawing.Point(1, 88);
			this.rbManaulReject.Name = "rbManaulReject";
			this.rbManaulReject.Padding = new global::System.Windows.Forms.Padding(1, 1, 0, 1);
			this.rbManaulReject.Size = new global::System.Drawing.Size(314, 19);
			this.rbManaulReject.TabIndex = 5;
			this.rbManaulReject.TabStop = true;
			this.rbManaulReject.Text = "Manual Reject";
			this.rbManaulReject.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.rbManaulReject.UseVisualStyleBackColor = true;
			this.rbManaulReject.Visible = false;
			this.rbDisable.AutoSize = true;
			this.rbDisable.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.rbDisable.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.rbDisable.Font = new global::System.Drawing.Font("휴먼둥근헤드라인", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.rbDisable.Location = new global::System.Drawing.Point(1, 69);
			this.rbDisable.Name = "rbDisable";
			this.rbDisable.Padding = new global::System.Windows.Forms.Padding(1, 1, 0, 1);
			this.rbDisable.Size = new global::System.Drawing.Size(314, 19);
			this.rbDisable.TabIndex = 4;
			this.rbDisable.TabStop = true;
			this.rbDisable.Text = "All Disable";
			this.rbDisable.UseVisualStyleBackColor = true;
			this.rbDisable.CheckedChanged += new global::System.EventHandler(this.rbDisable_CheckedChanged);
			this.rbSiteReject.AutoSize = true;
			this.rbSiteReject.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.rbSiteReject.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.rbSiteReject.Font = new global::System.Drawing.Font("휴먼둥근헤드라인", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.rbSiteReject.Location = new global::System.Drawing.Point(1, 50);
			this.rbSiteReject.Name = "rbSiteReject";
			this.rbSiteReject.Padding = new global::System.Windows.Forms.Padding(1, 1, 0, 1);
			this.rbSiteReject.Size = new global::System.Drawing.Size(314, 19);
			this.rbSiteReject.TabIndex = 1;
			this.rbSiteReject.TabStop = true;
			this.rbSiteReject.Text = "All Reject";
			this.rbSiteReject.UseVisualStyleBackColor = true;
			this.rbSiteReject.CheckedChanged += new global::System.EventHandler(this.rbSiteReject_CheckedChanged);
			this.rbSiteGood.AutoSize = true;
			this.rbSiteGood.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.rbSiteGood.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.rbSiteGood.Font = new global::System.Drawing.Font("휴먼둥근헤드라인", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.rbSiteGood.Location = new global::System.Drawing.Point(1, 31);
			this.rbSiteGood.Name = "rbSiteGood";
			this.rbSiteGood.Padding = new global::System.Windows.Forms.Padding(1, 1, 0, 1);
			this.rbSiteGood.Size = new global::System.Drawing.Size(314, 19);
			this.rbSiteGood.TabIndex = 0;
			this.rbSiteGood.TabStop = true;
			this.rbSiteGood.Text = "All Good";
			this.rbSiteGood.UseVisualStyleBackColor = true;
			this.rbSiteGood.CheckedChanged += new global::System.EventHandler(this.rbSiteGood_CheckedChanged);
			this.lbTitle.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.lbTitle.Font = new global::System.Drawing.Font("휴먼둥근헤드라인", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.lbTitle.Location = new global::System.Drawing.Point(1, 1);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new global::System.Drawing.Size(314, 30);
			this.lbTitle.TabIndex = 2;
			this.lbTitle.Text = "Select Site Status";
			this.lbTitle.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.pbOK);
			this.panel2.Controls.Add(this.panel18);
			this.panel2.Controls.Add(this.pbCancel);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 302);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(318, 49);
			this.panel2.TabIndex = 1;
			this.pbOK.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbOK.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbOK.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.apply;
			this.pbOK.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbOK.Location = new global::System.Drawing.Point(197, 0);
			this.pbOK.Name = "pbOK";
			this.pbOK.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbOK.Size = new global::System.Drawing.Size(48, 47);
			this.pbOK.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbOK.TabIndex = 51;
			this.pbOK.TabStop = false;
			this.pbOK.Click += new global::System.EventHandler(this.pbOK_Click);
			this.pbOK.MouseEnter += new global::System.EventHandler(this.pbOK_MouseEnter);
			this.pbOK.MouseLeave += new global::System.EventHandler(this.pbOK_MouseLeave);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel18.Location = new global::System.Drawing.Point(245, 0);
			this.panel18.Name = "panel18";
			this.panel18.Size = new global::System.Drawing.Size(23, 47);
			this.panel18.TabIndex = 52;
			this.pbCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbCancel.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbCancel.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.Location = new global::System.Drawing.Point(268, 0);
			this.pbCancel.Name = "pbCancel";
			this.pbCancel.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbCancel.Size = new global::System.Drawing.Size(48, 47);
			this.pbCancel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbCancel.TabIndex = 53;
			this.pbCancel.TabStop = false;
			this.pbCancel.Click += new global::System.EventHandler(this.pbCancel_Click);
			this.pbCancel.MouseEnter += new global::System.EventHandler(this.pbCancel_MouseEnter);
			this.pbCancel.MouseLeave += new global::System.EventHandler(this.pbCancel_MouseLeave);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(318, 351);
			base.Controls.Add(this.pnBase);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SiteMapMultiSelectDialog";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Site Status Dialog";
			this.pnBase.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnManualReject.ResumeLayout(false);
			this.pnManualReject.PerformLayout();
			this.pnRejectReason.ResumeLayout(false);
			this.tbFactor.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbOK).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400061D RID: 1565
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400061E RID: 1566
		private global::System.Windows.Forms.Panel pnBase;

		// Token: 0x0400061F RID: 1567
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000620 RID: 1568
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000621 RID: 1569
		private global::System.Windows.Forms.RadioButton rbSiteReject;

		// Token: 0x04000622 RID: 1570
		private global::System.Windows.Forms.RadioButton rbSiteGood;

		// Token: 0x04000623 RID: 1571
		private global::System.Windows.Forms.Label lbTitle;

		// Token: 0x04000624 RID: 1572
		private global::System.Windows.Forms.PictureBox pbOK;

		// Token: 0x04000625 RID: 1573
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000626 RID: 1574
		private global::System.Windows.Forms.PictureBox pbCancel;

		// Token: 0x04000627 RID: 1575
		private global::System.Windows.Forms.Panel pnRejectReason;

		// Token: 0x04000628 RID: 1576
		private global::System.Windows.Forms.RadioButton rbDisable;

		// Token: 0x04000629 RID: 1577
		private global::System.Windows.Forms.TabControl tbFactor;

		// Token: 0x0400062A RID: 1578
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x0400062B RID: 1579
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x0400062C RID: 1580
		private global::System.Windows.Forms.TabPage tabPage3;

		// Token: 0x0400062D RID: 1581
		private global::System.Windows.Forms.TabPage tabPage4;

		// Token: 0x0400062E RID: 1582
		private global::System.Windows.Forms.Panel pnManualReject;

		// Token: 0x0400062F RID: 1583
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x04000630 RID: 1584
		private global::System.Windows.Forms.RadioButton rbManaulReject;
	}
}
