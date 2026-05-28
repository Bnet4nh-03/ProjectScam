namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000036 RID: 54
	public partial class AddSocket : global::System.Windows.Forms.Form
	{
		// Token: 0x0600023A RID: 570 RVA: 0x000400C0 File Offset: 0x0003E2C0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000400E0 File Offset: 0x0003E2E0
		private void InitializeComponent()
		{
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.cmdCommand = new global::System.Windows.Forms.PictureBox();
			this.cmbTester = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.txtPn = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtMfg = new global::System.Windows.Forms.TextBox();
			this.cmbDevice = new global::System.Windows.Forms.ComboBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.cmdUpload = new global::System.Windows.Forms.PictureBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.cmdDownLoad = new global::System.Windows.Forms.PictureBox();
			this.txtBarcode = new global::System.Windows.Forms.TextBox();
			this.cmbStatus = new global::System.Windows.Forms.ComboBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.cmbCustomer = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.txtPkgType = new global::System.Windows.Forms.TextBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.txtMemo = new global::System.Windows.Forms.TextBox();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.cmdModify = new global::System.Windows.Forms.PictureBox();
			this.label20 = new global::System.Windows.Forms.Label();
			this.label22 = new global::System.Windows.Forms.Label();
			this.label23 = new global::System.Windows.Forms.Label();
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.l_copyright = new global::System.Windows.Forms.Label();
			this.splitter10 = new global::System.Windows.Forms.Splitter();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cmbSocketType = new global::System.Windows.Forms.ComboBox();
			this.panel3.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdCommand).BeginInit();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUpload).BeginInit();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDownLoad).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdModify).BeginInit();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			base.SuspendLayout();
			this.panel3.Controls.Add(this.groupBox3);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 44);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new global::System.Windows.Forms.Padding(5, 0, 5, 0);
			this.panel3.Size = new global::System.Drawing.Size(647, 342);
			this.panel3.TabIndex = 5;
			this.groupBox3.Controls.Add(this.cmbSocketType);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Controls.Add(this.cmbTester);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.txtPn);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.txtMfg);
			this.groupBox3.Controls.Add(this.cmbDevice);
			this.groupBox3.Controls.Add(this.groupBox2);
			this.groupBox3.Controls.Add(this.groupBox1);
			this.groupBox3.Controls.Add(this.txtBarcode);
			this.groupBox3.Controls.Add(this.cmbStatus);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.cmbCustomer);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.txtPkgType);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.txtMemo);
			this.groupBox3.Controls.Add(this.cmdClose);
			this.groupBox3.Controls.Add(this.cmdModify);
			this.groupBox3.Controls.Add(this.label20);
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Controls.Add(this.label23);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new global::System.Drawing.Point(5, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(637, 342);
			this.groupBox3.TabIndex = 41;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Socket Info";
			this.groupBox4.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox4.Controls.Add(this.cmdCommand);
			this.groupBox4.Location = new global::System.Drawing.Point(134, 277);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(77, 59);
			this.groupBox4.TabIndex = 107;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Comment";
			this.cmdCommand.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdCommand.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableSearch;
			this.cmdCommand.Location = new global::System.Drawing.Point(22, 18);
			this.cmdCommand.Name = "cmdCommand";
			this.cmdCommand.Size = new global::System.Drawing.Size(32, 32);
			this.cmdCommand.TabIndex = 113;
			this.cmdCommand.TabStop = false;
			this.cmdCommand.Click += new global::System.EventHandler(this.cmdCommand_Click);
			this.cmdCommand.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdCommand_MouseDown);
			this.cmdCommand.MouseLeave += new global::System.EventHandler(this.cmdCommand_MouseLeave);
			this.cmdCommand.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdCommand_MouseMove);
			this.cmdCommand.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdCommand_MouseUp);
			this.cmbTester.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbTester.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbTester.FormattingEnabled = true;
			this.cmbTester.Location = new global::System.Drawing.Point(393, 125);
			this.cmbTester.Name = "cmbTester";
			this.cmbTester.Size = new global::System.Drawing.Size(236, 23);
			this.cmbTester.TabIndex = 56;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(328, 128);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(38, 15);
			this.label2.TabIndex = 55;
			this.label2.Text = "Tester";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(3, 128);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(28, 15);
			this.label3.TabIndex = 112;
			this.label3.Text = "P/N";
			this.txtPn.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtPn.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtPn.Location = new global::System.Drawing.Point(68, 125);
			this.txtPn.Name = "txtPn";
			this.txtPn.Size = new global::System.Drawing.Size(235, 23);
			this.txtPn.TabIndex = 4;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(3, 94);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(32, 15);
			this.label1.TabIndex = 110;
			this.label1.Text = "MFG";
			this.txtMfg.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtMfg.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtMfg.Location = new global::System.Drawing.Point(68, 91);
			this.txtMfg.Name = "txtMfg";
			this.txtMfg.Size = new global::System.Drawing.Size(235, 23);
			this.txtMfg.TabIndex = 3;
			this.cmbDevice.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbDevice.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDevice.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbDevice.FormattingEnabled = true;
			this.cmbDevice.Location = new global::System.Drawing.Point(393, 58);
			this.cmbDevice.Name = "cmbDevice";
			this.cmbDevice.Size = new global::System.Drawing.Size(235, 23);
			this.cmbDevice.TabIndex = 6;
			this.groupBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox2.Controls.Add(this.cmdUpload);
			this.groupBox2.Location = new global::System.Drawing.Point(69, 277);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(59, 59);
			this.groupBox2.TabIndex = 106;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Upload";
			this.cmdUpload.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdUpload.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.OpenTable;
			this.cmdUpload.Location = new global::System.Drawing.Point(13, 18);
			this.cmdUpload.Name = "cmdUpload";
			this.cmdUpload.Size = new global::System.Drawing.Size(32, 32);
			this.cmdUpload.TabIndex = 104;
			this.cmdUpload.TabStop = false;
			this.cmdUpload.Click += new global::System.EventHandler(this.cmdUpload_Click);
			this.cmdUpload.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdUpload_MouseDown);
			this.cmdUpload.MouseLeave += new global::System.EventHandler(this.cmdUpload_MouseLeave);
			this.cmdUpload.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdUpload_MouseMove);
			this.cmdUpload.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdUpload_MouseUp);
			this.groupBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox1.Controls.Add(this.cmdDownLoad);
			this.groupBox1.Location = new global::System.Drawing.Point(4, 277);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(59, 59);
			this.groupBox1.TabIndex = 105;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Format";
			this.cmdDownLoad.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdDownLoad.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.SaveExcel;
			this.cmdDownLoad.Location = new global::System.Drawing.Point(13, 18);
			this.cmdDownLoad.Name = "cmdDownLoad";
			this.cmdDownLoad.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDownLoad.TabIndex = 103;
			this.cmdDownLoad.TabStop = false;
			this.cmdDownLoad.Click += new global::System.EventHandler(this.cmdDownLoad_Click);
			this.cmdDownLoad.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdDownLoad_MouseDown);
			this.cmdDownLoad.MouseLeave += new global::System.EventHandler(this.cmdDownLoad_MouseLeave);
			this.cmdDownLoad.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdDownLoad_MouseMove);
			this.cmdDownLoad.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdDownLoad_MouseUp);
			this.txtBarcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtBarcode.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtBarcode.Location = new global::System.Drawing.Point(68, 25);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new global::System.Drawing.Size(235, 23);
			this.txtBarcode.TabIndex = 1;
			this.cmbStatus.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbStatus.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatus.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbStatus.FormattingEnabled = true;
			this.cmbStatus.Location = new global::System.Drawing.Point(479, 91);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.Size = new global::System.Drawing.Size(149, 23);
			this.cmbStatus.TabIndex = 7;
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(328, 94);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(77, 15);
			this.label10.TabIndex = 46;
			this.label10.Text = "Socket Status";
			this.cmbCustomer.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbCustomer.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCustomer.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbCustomer.FormattingEnabled = true;
			this.cmbCustomer.Location = new global::System.Drawing.Point(393, 25);
			this.cmbCustomer.Name = "cmbCustomer";
			this.cmbCustomer.Size = new global::System.Drawing.Size(235, 23);
			this.cmbCustomer.TabIndex = 5;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(3, 61);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(55, 15);
			this.label4.TabIndex = 32;
			this.label4.Text = "Pkg Type";
			this.txtPkgType.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtPkgType.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtPkgType.Location = new global::System.Drawing.Point(68, 58);
			this.txtPkgType.Name = "txtPkgType";
			this.txtPkgType.Size = new global::System.Drawing.Size(235, 23);
			this.txtPkgType.TabIndex = 2;
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(3, 195);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(42, 15);
			this.label16.TabIndex = 22;
			this.label16.Text = "Memo";
			this.txtMemo.Location = new global::System.Drawing.Point(68, 195);
			this.txtMemo.Multiline = true;
			this.txtMemo.Name = "txtMemo";
			this.txtMemo.Size = new global::System.Drawing.Size(560, 73);
			this.txtMemo.TabIndex = 8;
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(589, 299);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdClose.TabIndex = 23;
			this.cmdClose.TabStop = false;
			this.cmdClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseDown);
			this.cmdClose.MouseLeave += new global::System.EventHandler(this.cmdClose_MouseLeave);
			this.cmdClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
			this.cmdClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseUp);
			this.cmdModify.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdModify.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdModify.Location = new global::System.Drawing.Point(551, 299);
			this.cmdModify.Name = "cmdModify";
			this.cmdModify.Size = new global::System.Drawing.Size(32, 32);
			this.cmdModify.TabIndex = 22;
			this.cmdModify.TabStop = false;
			this.cmdModify.Click += new global::System.EventHandler(this.cmdModify_Click);
			this.cmdModify.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseDown);
			this.cmdModify.MouseLeave += new global::System.EventHandler(this.cmdModify_MouseLeave);
			this.cmdModify.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseMove);
			this.cmdModify.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseUp);
			this.label20.AutoSize = true;
			this.label20.Location = new global::System.Drawing.Point(328, 28);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(59, 15);
			this.label20.TabIndex = 10;
			this.label20.Text = "Customer";
			this.label22.AutoSize = true;
			this.label22.Location = new global::System.Drawing.Point(328, 61);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(42, 15);
			this.label22.TabIndex = 6;
			this.label22.Text = "Device";
			this.label23.AutoSize = true;
			this.label23.Location = new global::System.Drawing.Point(3, 28);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(50, 15);
			this.label23.TabIndex = 4;
			this.label23.Text = "Barcode";
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(647, 44);
			this.panel24.TabIndex = 17;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(72, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Socket";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.l_copyright);
			this.panel25.Controls.Add(this.splitter10);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 386);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(647, 32);
			this.panel25.TabIndex = 23;
			this.l_copyright.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.l_copyright.AutoSize = true;
			this.l_copyright.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.l_copyright.Location = new global::System.Drawing.Point(127, 8);
			this.l_copyright.Name = "l_copyright";
			this.l_copyright.Size = new global::System.Drawing.Size(398, 15);
			this.l_copyright.TabIndex = 15;
			this.l_copyright.Text = "Copyright © 2017-2018 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.l_copyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.splitter10.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter10.Location = new global::System.Drawing.Point(0, 0);
			this.splitter10.Name = "splitter10";
			this.splitter10.Size = new global::System.Drawing.Size(647, 3);
			this.splitter10.TabIndex = 14;
			this.splitter10.TabStop = false;
			this.openFileDialog.FileName = "openFileDialog1";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(328, 160);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(32, 15);
			this.label5.TabIndex = 113;
			this.label5.Text = "Type";
			this.cmbSocketType.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbSocketType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSocketType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbSocketType.FormattingEnabled = true;
			this.cmbSocketType.Location = new global::System.Drawing.Point(479, 157);
			this.cmbSocketType.Name = "cmbSocketType";
			this.cmbSocketType.Size = new global::System.Drawing.Size(149, 23);
			this.cmbSocketType.TabIndex = 114;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(647, 418);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.Name = "AddSocket";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Socket Information";
			base.Load += new global::System.EventHandler(this.AddSocket_Load);
			this.panel3.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdCommand).EndInit();
			this.groupBox2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdUpload).EndInit();
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdDownLoad).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdModify).EndInit();
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040003F4 RID: 1012
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040003F5 RID: 1013
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040003F6 RID: 1014
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x040003F7 RID: 1015
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x040003F8 RID: 1016
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x040003F9 RID: 1017
		private global::System.Windows.Forms.Label l_copyright;

		// Token: 0x040003FA RID: 1018
		private global::System.Windows.Forms.Splitter splitter10;

		// Token: 0x040003FB RID: 1019
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x040003FC RID: 1020
		private global::System.Windows.Forms.PictureBox cmdModify;

		// Token: 0x040003FD RID: 1021
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040003FE RID: 1022
		private global::System.Windows.Forms.Label label16;

		// Token: 0x040003FF RID: 1023
		private global::System.Windows.Forms.TextBox txtMemo;

		// Token: 0x04000400 RID: 1024
		private global::System.Windows.Forms.Label label20;

		// Token: 0x04000401 RID: 1025
		private global::System.Windows.Forms.Label label22;

		// Token: 0x04000402 RID: 1026
		private global::System.Windows.Forms.Label label23;

		// Token: 0x04000403 RID: 1027
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000404 RID: 1028
		private global::System.Windows.Forms.TextBox txtPkgType;

		// Token: 0x04000405 RID: 1029
		private global::System.Windows.Forms.ComboBox cmbCustomer;

		// Token: 0x04000406 RID: 1030
		private global::System.Windows.Forms.ComboBox cmbStatus;

		// Token: 0x04000407 RID: 1031
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000408 RID: 1032
		private global::System.Windows.Forms.TextBox txtBarcode;

		// Token: 0x04000409 RID: 1033
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400040A RID: 1034
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400040B RID: 1035
		private global::System.Windows.Forms.PictureBox cmdDownLoad;

		// Token: 0x0400040C RID: 1036
		private global::System.Windows.Forms.PictureBox cmdUpload;

		// Token: 0x0400040D RID: 1037
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x0400040E RID: 1038
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x0400040F RID: 1039
		private global::System.Windows.Forms.ComboBox cmbDevice;

		// Token: 0x04000410 RID: 1040
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000411 RID: 1041
		private global::System.Windows.Forms.TextBox txtPn;

		// Token: 0x04000412 RID: 1042
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000413 RID: 1043
		private global::System.Windows.Forms.TextBox txtMfg;

		// Token: 0x04000414 RID: 1044
		private global::System.Windows.Forms.ComboBox cmbTester;

		// Token: 0x04000415 RID: 1045
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000416 RID: 1046
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000417 RID: 1047
		private global::System.Windows.Forms.PictureBox cmdCommand;

		// Token: 0x04000418 RID: 1048
		private global::System.Windows.Forms.ComboBox cmbSocketType;

		// Token: 0x04000419 RID: 1049
		private global::System.Windows.Forms.Label label5;
	}
}
