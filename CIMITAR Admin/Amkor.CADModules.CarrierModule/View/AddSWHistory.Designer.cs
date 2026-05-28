namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200004F RID: 79
	public partial class AddSWHistory : global::System.Windows.Forms.Form
	{
		// Token: 0x060003B6 RID: 950 RVA: 0x00056FEC File Offset: 0x000551EC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0005700C File Offset: 0x0005520C
		private void InitializeComponent()
		{
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.cmdApply = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.txtAttachFile = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.cmdUploadFile = new global::System.Windows.Forms.PictureBox();
			this.txtComment = new global::System.Windows.Forms.TextBox();
			this.dtpDoneDate = new global::System.Windows.Forms.DateTimePicker();
			this.dtpApprovalDate = new global::System.Windows.Forms.DateTimePicker();
			this.label43 = new global::System.Windows.Forms.Label();
			this.label44 = new global::System.Windows.Forms.Label();
			this.label45 = new global::System.Windows.Forms.Label();
			this.txtSWversion = new global::System.Windows.Forms.TextBox();
			this.label46 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).BeginInit();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUploadFile).BeginInit();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			base.SuspendLayout();
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(548, 44);
			this.panel24.TabIndex = 18;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(92, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Add S/W";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.label13);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 307);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(548, 32);
			this.panel25.TabIndex = 27;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(150, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(238, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2015 Amkor Technology Korea";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdApply.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdApply.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdApply.Location = new global::System.Drawing.Point(464, 9);
			this.cmdApply.Name = "cmdApply";
			this.cmdApply.Size = new global::System.Drawing.Size(32, 32);
			this.cmdApply.TabIndex = 24;
			this.cmdApply.TabStop = false;
			this.cmdApply.Click += new global::System.EventHandler(this.cmdApply_Click);
			this.cmdApply.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseDown);
			this.cmdApply.MouseLeave += new global::System.EventHandler(this.cmdApply_MouseLeave);
			this.cmdApply.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseMove);
			this.cmdApply.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseUp);
			this.panel1.Controls.Add(this.txtAttachFile);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cmdUploadFile);
			this.panel1.Controls.Add(this.txtComment);
			this.panel1.Controls.Add(this.dtpDoneDate);
			this.panel1.Controls.Add(this.dtpApprovalDate);
			this.panel1.Controls.Add(this.label43);
			this.panel1.Controls.Add(this.label44);
			this.panel1.Controls.Add(this.label45);
			this.panel1.Controls.Add(this.txtSWversion);
			this.panel1.Controls.Add(this.label46);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 44);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel1.Size = new global::System.Drawing.Size(548, 212);
			this.panel1.TabIndex = 29;
			this.txtAttachFile.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtAttachFile.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtAttachFile.Location = new global::System.Drawing.Point(134, 170);
			this.txtAttachFile.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtAttachFile.Name = "txtAttachFile";
			this.txtAttachFile.ReadOnly = true;
			this.txtAttachFile.Size = new global::System.Drawing.Size(358, 23);
			this.txtAttachFile.TabIndex = 109;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label2.Location = new global::System.Drawing.Point(19, 173);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(91, 15);
			this.label2.TabIndex = 108;
			this.label2.Text = "Attachment File";
			this.cmdUploadFile.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdUploadFile.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.OpenTable;
			this.cmdUploadFile.Location = new global::System.Drawing.Point(503, 167);
			this.cmdUploadFile.Name = "cmdUploadFile";
			this.cmdUploadFile.Size = new global::System.Drawing.Size(32, 32);
			this.cmdUploadFile.TabIndex = 104;
			this.cmdUploadFile.TabStop = false;
			this.cmdUploadFile.Click += new global::System.EventHandler(this.cmdUploadFile_Click);
			this.cmdUploadFile.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdUploadFile_MouseDown);
			this.cmdUploadFile.MouseLeave += new global::System.EventHandler(this.cmdUploadFile_MouseLeave);
			this.cmdUploadFile.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdUploadFile_MouseMove);
			this.cmdUploadFile.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdUploadFile_MouseUp);
			this.txtComment.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtComment.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtComment.Location = new global::System.Drawing.Point(134, 132);
			this.txtComment.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new global::System.Drawing.Size(358, 23);
			this.txtComment.TabIndex = 98;
			this.dtpDoneDate.CustomFormat = "yyyy-MM-dd";
			this.dtpDoneDate.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.dtpDoneDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDoneDate.Location = new global::System.Drawing.Point(134, 94);
			this.dtpDoneDate.Name = "dtpDoneDate";
			this.dtpDoneDate.Size = new global::System.Drawing.Size(200, 23);
			this.dtpDoneDate.TabIndex = 96;
			this.dtpApprovalDate.CustomFormat = "yyyy-MM-dd";
			this.dtpApprovalDate.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.dtpApprovalDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpApprovalDate.Location = new global::System.Drawing.Point(134, 58);
			this.dtpApprovalDate.Name = "dtpApprovalDate";
			this.dtpApprovalDate.Size = new global::System.Drawing.Size(200, 23);
			this.dtpApprovalDate.TabIndex = 97;
			this.label43.AutoSize = true;
			this.label43.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label43.Location = new global::System.Drawing.Point(19, 21);
			this.label43.Name = "label43";
			this.label43.Size = new global::System.Drawing.Size(70, 15);
			this.label43.TabIndex = 95;
			this.label43.Text = "S/W Version";
			this.label44.AutoSize = true;
			this.label44.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label44.Location = new global::System.Drawing.Point(19, 135);
			this.label44.Name = "label44";
			this.label44.Size = new global::System.Drawing.Size(61, 15);
			this.label44.TabIndex = 92;
			this.label44.Text = "Comment";
			this.label45.AutoSize = true;
			this.label45.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label45.Location = new global::System.Drawing.Point(19, 61);
			this.label45.Name = "label45";
			this.label45.Size = new global::System.Drawing.Size(82, 15);
			this.label45.TabIndex = 94;
			this.label45.Text = "Approval Date";
			this.txtSWversion.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtSWversion.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtSWversion.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtSWversion.Location = new global::System.Drawing.Point(134, 18);
			this.txtSWversion.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtSWversion.Name = "txtSWversion";
			this.txtSWversion.Size = new global::System.Drawing.Size(200, 23);
			this.txtSWversion.TabIndex = 91;
			this.label46.AutoSize = true;
			this.label46.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label46.Location = new global::System.Drawing.Point(19, 97);
			this.label46.Name = "label46";
			this.label46.Size = new global::System.Drawing.Size(109, 15);
			this.label46.TabIndex = 93;
			this.label46.Text = "Fan-Out Done Date";
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.cmdClose);
			this.panel2.Controls.Add(this.cmdApply);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 256);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(548, 51);
			this.panel2.TabIndex = 30;
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(502, 9);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdClose.TabIndex = 98;
			this.cmdClose.TabStop = false;
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseDown);
			this.cmdClose.MouseLeave += new global::System.EventHandler(this.cmdClose_MouseLeave);
			this.cmdClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
			this.cmdClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseUp);
			this.openFileDialog.FileName = "openFileDialog1";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(548, 339);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "AddSWHistory";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "S/W";
			base.Load += new global::System.EventHandler(this.AddSWHistory_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUploadFile).EndInit();
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040005E7 RID: 1511
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040005E8 RID: 1512
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x040005E9 RID: 1513
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x040005EA RID: 1514
		private global::System.Windows.Forms.PictureBox cmdApply;

		// Token: 0x040005EB RID: 1515
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x040005EC RID: 1516
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040005ED RID: 1517
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040005EE RID: 1518
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040005EF RID: 1519
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x040005F0 RID: 1520
		private global::System.Windows.Forms.TextBox txtComment;

		// Token: 0x040005F1 RID: 1521
		private global::System.Windows.Forms.DateTimePicker dtpDoneDate;

		// Token: 0x040005F2 RID: 1522
		private global::System.Windows.Forms.DateTimePicker dtpApprovalDate;

		// Token: 0x040005F3 RID: 1523
		private global::System.Windows.Forms.Label label43;

		// Token: 0x040005F4 RID: 1524
		private global::System.Windows.Forms.Label label44;

		// Token: 0x040005F5 RID: 1525
		private global::System.Windows.Forms.Label label45;

		// Token: 0x040005F6 RID: 1526
		private global::System.Windows.Forms.TextBox txtSWversion;

		// Token: 0x040005F7 RID: 1527
		private global::System.Windows.Forms.Label label46;

		// Token: 0x040005F8 RID: 1528
		private global::System.Windows.Forms.TextBox txtAttachFile;

		// Token: 0x040005F9 RID: 1529
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040005FA RID: 1530
		private global::System.Windows.Forms.PictureBox cmdUploadFile;

		// Token: 0x040005FB RID: 1531
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}
