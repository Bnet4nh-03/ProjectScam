namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000052 RID: 82
	public partial class DeviceView : global::System.Windows.Forms.Form
	{
		// Token: 0x06000406 RID: 1030 RVA: 0x0005B13B File Offset: 0x0005933B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0005B15C File Offset: 0x0005935C
		private void InitializeComponent()
		{
			this.lstDevice = new global::System.Windows.Forms.ListView();
			this.txtDevice = new global::System.Windows.Forms.TextBox();
			this.panel14 = new global::System.Windows.Forms.Panel();
			this.grpMenu = new global::System.Windows.Forms.GroupBox();
			this.rdoNickName = new global::System.Windows.Forms.RadioButton();
			this.rdoDevice = new global::System.Windows.Forms.RadioButton();
			this.cmbCustomer = new global::System.Windows.Forms.ComboBox();
			this.label20 = new global::System.Windows.Forms.Label();
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.lstSelectedDevice = new global::System.Windows.Forms.ListView();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.cmdRight = new global::System.Windows.Forms.PictureBox();
			this.cmdDeviceClose = new global::System.Windows.Forms.PictureBox();
			this.cmdDeviceApply = new global::System.Windows.Forms.PictureBox();
			this.cmdDeviceSearch = new global::System.Windows.Forms.PictureBox();
			this.cmdLeft = new global::System.Windows.Forms.PictureBox();
			this.panel14.SuspendLayout();
			this.grpMenu.SuspendLayout();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdRight).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDeviceClose).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDeviceApply).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDeviceSearch).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdLeft).BeginInit();
			base.SuspendLayout();
			this.lstDevice.Font = new global::System.Drawing.Font("Segoe UI", 8.25f);
			this.lstDevice.Location = new global::System.Drawing.Point(12, 19);
			this.lstDevice.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.lstDevice.Name = "lstDevice";
			this.lstDevice.Size = new global::System.Drawing.Size(190, 396);
			this.lstDevice.TabIndex = 1;
			this.lstDevice.UseCompatibleStateImageBehavior = false;
			this.lstDevice.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.lstDevice_MouseDoubleClick);
			this.txtDevice.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtDevice.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtDevice.Location = new global::System.Drawing.Point(169, 50);
			this.txtDevice.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtDevice.Name = "txtDevice";
			this.txtDevice.Size = new global::System.Drawing.Size(230, 23);
			this.txtDevice.TabIndex = 4;
			this.txtDevice.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtDevice_KeyPress);
			this.panel14.Controls.Add(this.cmdDeviceSearch);
			this.panel14.Controls.Add(this.grpMenu);
			this.panel14.Controls.Add(this.txtDevice);
			this.panel14.Controls.Add(this.cmbCustomer);
			this.panel14.Controls.Add(this.label20);
			this.panel14.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel14.Location = new global::System.Drawing.Point(0, 44);
			this.panel14.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel14.Name = "panel14";
			this.panel14.Size = new global::System.Drawing.Size(449, 83);
			this.panel14.TabIndex = 13;
			this.grpMenu.Controls.Add(this.rdoNickName);
			this.grpMenu.Controls.Add(this.rdoDevice);
			this.grpMenu.Location = new global::System.Drawing.Point(8, 37);
			this.grpMenu.Name = "grpMenu";
			this.grpMenu.Size = new global::System.Drawing.Size(156, 40);
			this.grpMenu.TabIndex = 4;
			this.grpMenu.TabStop = false;
			this.rdoNickName.AutoSize = true;
			this.rdoNickName.Location = new global::System.Drawing.Point(71, 14);
			this.rdoNickName.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdoNickName.Name = "rdoNickName";
			this.rdoNickName.Size = new global::System.Drawing.Size(81, 19);
			this.rdoNickName.TabIndex = 20;
			this.rdoNickName.Text = "NickName";
			this.rdoNickName.UseVisualStyleBackColor = true;
			this.rdoDevice.AutoSize = true;
			this.rdoDevice.Checked = true;
			this.rdoDevice.Location = new global::System.Drawing.Point(10, 14);
			this.rdoDevice.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdoDevice.Name = "rdoDevice";
			this.rdoDevice.Size = new global::System.Drawing.Size(60, 19);
			this.rdoDevice.TabIndex = 21;
			this.rdoDevice.TabStop = true;
			this.rdoDevice.Text = "Device";
			this.rdoDevice.UseVisualStyleBackColor = true;
			this.cmbCustomer.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbCustomer.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCustomer.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbCustomer.FormattingEnabled = true;
			this.cmbCustomer.Location = new global::System.Drawing.Point(103, 14);
			this.cmbCustomer.Name = "cmbCustomer";
			this.cmbCustomer.Size = new global::System.Drawing.Size(296, 23);
			this.cmbCustomer.TabIndex = 45;
			this.cmbCustomer.DropDown += new global::System.EventHandler(this.cmbCustomer_DropDown);
			this.cmbCustomer.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.cmbCustomer_KeyPress);
			this.label20.AutoSize = true;
			this.label20.Location = new global::System.Drawing.Point(15, 17);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(59, 15);
			this.label20.TabIndex = 44;
			this.label20.Text = "Customer";
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(449, 44);
			this.panel24.TabIndex = 18;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(127, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Select Device";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lstSelectedDevice.Font = new global::System.Drawing.Font("Segoe UI", 8.25f);
			this.lstSelectedDevice.Location = new global::System.Drawing.Point(256, 19);
			this.lstSelectedDevice.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.lstSelectedDevice.Name = "lstSelectedDevice";
			this.lstSelectedDevice.Size = new global::System.Drawing.Size(181, 396);
			this.lstSelectedDevice.TabIndex = 26;
			this.lstSelectedDevice.UseCompatibleStateImageBehavior = false;
			this.lstSelectedDevice.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.lstSelectedDevice_MouseDoubleClick);
			this.panel25.Controls.Add(this.label13);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 593);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(449, 32);
			this.panel25.TabIndex = 27;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(100, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(239, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2015 Amkor Technology Korea";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel1.Controls.Add(this.cmdLeft);
			this.panel1.Controls.Add(this.cmdRight);
			this.panel1.Controls.Add(this.lstSelectedDevice);
			this.panel1.Controls.Add(this.lstDevice);
			this.panel1.Controls.Add(this.cmdDeviceClose);
			this.panel1.Controls.Add(this.cmdDeviceApply);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 127);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(449, 466);
			this.panel1.TabIndex = 28;
			this.cmdRight.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdRight.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.ArrowRight;
			this.cmdRight.Location = new global::System.Drawing.Point(213, 166);
			this.cmdRight.Name = "cmdRight";
			this.cmdRight.Size = new global::System.Drawing.Size(32, 32);
			this.cmdRight.TabIndex = 27;
			this.cmdRight.TabStop = false;
			this.cmdRight.Click += new global::System.EventHandler(this.cmdRight_Click);
			this.cmdRight.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdRight_MouseDown);
			this.cmdRight.MouseLeave += new global::System.EventHandler(this.cmdRight_MouseLeave);
			this.cmdRight.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdRight_MouseMove);
			this.cmdRight.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdRight_MouseUp);
			this.cmdDeviceClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdDeviceClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdDeviceClose.Location = new global::System.Drawing.Point(405, 422);
			this.cmdDeviceClose.Name = "cmdDeviceClose";
			this.cmdDeviceClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDeviceClose.TabIndex = 25;
			this.cmdDeviceClose.TabStop = false;
			this.cmdDeviceClose.Click += new global::System.EventHandler(this.cmdDeviceClose_Click);
			this.cmdDeviceClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeviceClose_MouseDown);
			this.cmdDeviceClose.MouseLeave += new global::System.EventHandler(this.cmdDeviceClose_MouseLeave);
			this.cmdDeviceClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeviceClose_MouseMove);
			this.cmdDeviceClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeviceClose_MouseUp);
			this.cmdDeviceApply.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdDeviceApply.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdDeviceApply.Location = new global::System.Drawing.Point(367, 422);
			this.cmdDeviceApply.Name = "cmdDeviceApply";
			this.cmdDeviceApply.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDeviceApply.TabIndex = 24;
			this.cmdDeviceApply.TabStop = false;
			this.cmdDeviceApply.Click += new global::System.EventHandler(this.cmdDeviceApply_Click);
			this.cmdDeviceApply.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeviceApply_MouseDown);
			this.cmdDeviceApply.MouseLeave += new global::System.EventHandler(this.cmdDeviceApply_MouseLeave);
			this.cmdDeviceApply.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeviceApply_MouseMove);
			this.cmdDeviceApply.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeviceApply_MouseUp);
			this.cmdDeviceSearch.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdDeviceSearch.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableSearch;
			this.cmdDeviceSearch.Location = new global::System.Drawing.Point(405, 45);
			this.cmdDeviceSearch.Name = "cmdDeviceSearch";
			this.cmdDeviceSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDeviceSearch.TabIndex = 47;
			this.cmdDeviceSearch.TabStop = false;
			this.cmdDeviceSearch.Click += new global::System.EventHandler(this.cmdDeviceSearch_Click);
			this.cmdDeviceSearch.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeviceSearch_MouseDown);
			this.cmdDeviceSearch.MouseLeave += new global::System.EventHandler(this.cmdDeviceSearch_MouseLeave);
			this.cmdDeviceSearch.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeviceSearch_MouseMove);
			this.cmdDeviceSearch.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeviceSearch_MouseUp);
			this.cmdLeft.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdLeft.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.ArrowLeft;
			this.cmdLeft.Location = new global::System.Drawing.Point(213, 214);
			this.cmdLeft.Name = "cmdLeft";
			this.cmdLeft.Size = new global::System.Drawing.Size(32, 32);
			this.cmdLeft.TabIndex = 28;
			this.cmdLeft.TabStop = false;
			this.cmdLeft.Click += new global::System.EventHandler(this.cmdLeft_Click);
			this.cmdLeft.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdLeft_MouseDown);
			this.cmdLeft.MouseLeave += new global::System.EventHandler(this.cmdLeft_MouseLeave);
			this.cmdLeft.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdLeft_MouseMove);
			this.cmdLeft.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdLeft_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(449, 625);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel14);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "DeviceView";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Device";
			base.Load += new global::System.EventHandler(this.FilterView_Load);
			this.panel14.ResumeLayout(false);
			this.panel14.PerformLayout();
			this.grpMenu.ResumeLayout(false);
			this.grpMenu.PerformLayout();
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdRight).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDeviceClose).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDeviceApply).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDeviceSearch).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdLeft).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000631 RID: 1585
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000632 RID: 1586
		private global::System.Windows.Forms.ListView lstDevice;

		// Token: 0x04000633 RID: 1587
		private global::System.Windows.Forms.TextBox txtDevice;

		// Token: 0x04000634 RID: 1588
		private global::System.Windows.Forms.Panel panel14;

		// Token: 0x04000635 RID: 1589
		private global::System.Windows.Forms.RadioButton rdoDevice;

		// Token: 0x04000636 RID: 1590
		private global::System.Windows.Forms.RadioButton rdoNickName;

		// Token: 0x04000637 RID: 1591
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x04000638 RID: 1592
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x04000639 RID: 1593
		private global::System.Windows.Forms.GroupBox grpMenu;

		// Token: 0x0400063A RID: 1594
		private global::System.Windows.Forms.ComboBox cmbCustomer;

		// Token: 0x0400063B RID: 1595
		private global::System.Windows.Forms.Label label20;

		// Token: 0x0400063C RID: 1596
		private global::System.Windows.Forms.PictureBox cmdDeviceSearch;

		// Token: 0x0400063D RID: 1597
		private global::System.Windows.Forms.PictureBox cmdDeviceClose;

		// Token: 0x0400063E RID: 1598
		private global::System.Windows.Forms.PictureBox cmdDeviceApply;

		// Token: 0x0400063F RID: 1599
		private global::System.Windows.Forms.ListView lstSelectedDevice;

		// Token: 0x04000640 RID: 1600
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000641 RID: 1601
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000642 RID: 1602
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000643 RID: 1603
		private global::System.Windows.Forms.PictureBox cmdRight;

		// Token: 0x04000644 RID: 1604
		private global::System.Windows.Forms.PictureBox cmdLeft;
	}
}
