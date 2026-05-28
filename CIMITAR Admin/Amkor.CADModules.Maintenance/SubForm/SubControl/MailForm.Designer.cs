namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000035 RID: 53
	public partial class MailForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000358 RID: 856 RVA: 0x000677E0 File Offset: 0x000659E0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00067818 File Offset: 0x00065A18
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.Maintenance.SubForm.SubControl.MailForm));
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.pbApply = new global::System.Windows.Forms.PictureBox();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.pbCancel = new global::System.Windows.Forms.PictureBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.grid_TempMail = new global::SourceGrid.Grid();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnCCAppend = new global::System.Windows.Forms.Button();
			this.btnCCDelete = new global::System.Windows.Forms.Button();
			this.btnAppend = new global::System.Windows.Forms.Button();
			this.btnDelete = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.pnCCInfo = new global::System.Windows.Forms.Panel();
			this.pnCCFunction = new global::System.Windows.Forms.Panel();
			this.btnGridClose2 = new global::System.Windows.Forms.Button();
			this.rbCCInfo = new global::System.Windows.Forms.RichTextBox();
			this.grid1 = new global::SourceGrid.Grid();
			this.grid_CCMail = new global::SourceGrid.Grid();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.pnToInfo = new global::System.Windows.Forms.Panel();
			this.pnToFunciton = new global::System.Windows.Forms.Panel();
			this.btnGridClose = new global::System.Windows.Forms.Button();
			this.rbToInfo = new global::System.Windows.Forms.RichTextBox();
			this.grid_mail = new global::SourceGrid.Grid();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbApply).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.pnCCInfo.SuspendLayout();
			this.pnCCFunction.SuspendLayout();
			this.grid1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.pnToInfo.SuspendLayout();
			this.pnToFunciton.SuspendLayout();
			base.SuspendLayout();
			this.groupBox2.Controls.Add(this.pbApply);
			this.groupBox2.Controls.Add(this.panel18);
			this.groupBox2.Controls.Add(this.pbCancel);
			this.groupBox2.Controls.Add(this.btnOK);
			this.groupBox2.Controls.Add(this.btnClose);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.groupBox2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox2.Location = new global::System.Drawing.Point(0, 536);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(985, 71);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.pbApply.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbApply.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbApply.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbApply.Image");
			this.pbApply.Location = new global::System.Drawing.Point(855, 17);
			this.pbApply.Name = "pbApply";
			this.pbApply.Size = new global::System.Drawing.Size(52, 51);
			this.pbApply.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbApply.TabIndex = 94;
			this.pbApply.TabStop = false;
			this.pbApply.Click += new global::System.EventHandler(this.pbApply_Click);
			this.pbApply.MouseEnter += new global::System.EventHandler(this.pbApply_MouseEnter);
			this.pbApply.MouseLeave += new global::System.EventHandler(this.pbApply_MouseLeave);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel18.Location = new global::System.Drawing.Point(907, 17);
			this.panel18.Name = "panel18";
			this.panel18.Size = new global::System.Drawing.Size(23, 51);
			this.panel18.TabIndex = 93;
			this.pbCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbCancel.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbCancel.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.Location = new global::System.Drawing.Point(930, 17);
			this.pbCancel.Name = "pbCancel";
			this.pbCancel.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbCancel.Size = new global::System.Drawing.Size(52, 51);
			this.pbCancel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbCancel.TabIndex = 92;
			this.pbCancel.TabStop = false;
			this.pbCancel.Click += new global::System.EventHandler(this.pbCancel_Click);
			this.pbCancel.MouseEnter += new global::System.EventHandler(this.pbCancel_MouseEnter);
			this.pbCancel.MouseLeave += new global::System.EventHandler(this.pbCancel_MouseLeave);
			this.btnOK.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnOK.Location = new global::System.Drawing.Point(419, 17);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(99, 51);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "Apply";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Visible = false;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClose.Location = new global::System.Drawing.Point(518, 17);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(99, 51);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Cancel";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Visible = false;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox1.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(985, 536);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox4.Controls.Add(this.grid_TempMail);
			this.groupBox4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox4.Location = new global::System.Drawing.Point(549, 17);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(433, 516);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Mail List";
			this.grid_TempMail.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_TempMail.EnableSort = true;
			this.grid_TempMail.FixedColumns = 1;
			this.grid_TempMail.FixedRows = 1;
			this.grid_TempMail.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.grid_TempMail.Location = new global::System.Drawing.Point(3, 17);
			this.grid_TempMail.Name = "grid_TempMail";
			this.grid_TempMail.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_TempMail.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_TempMail.Size = new global::System.Drawing.Size(427, 496);
			this.grid_TempMail.TabIndex = 18;
			this.grid_TempMail.TabStop = true;
			this.grid_TempMail.ToolTipText = "";
			this.grid_TempMail.DoubleClick += new global::System.EventHandler(this.grid_TempMail_DoubleClick);
			this.panel1.Controls.Add(this.btnCCAppend);
			this.panel1.Controls.Add(this.btnCCDelete);
			this.panel1.Controls.Add(this.btnAppend);
			this.panel1.Controls.Add(this.btnDelete);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new global::System.Drawing.Point(435, 17);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(114, 516);
			this.panel1.TabIndex = 7;
			this.btnCCAppend.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnCCAppend.Location = new global::System.Drawing.Point(18, 368);
			this.btnCCAppend.Name = "btnCCAppend";
			this.btnCCAppend.Size = new global::System.Drawing.Size(75, 23);
			this.btnCCAppend.TabIndex = 7;
			this.btnCCAppend.Text = "◀";
			this.btnCCAppend.UseVisualStyleBackColor = true;
			this.btnCCAppend.Click += new global::System.EventHandler(this.btnCCAppend_Click);
			this.btnCCDelete.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnCCDelete.Location = new global::System.Drawing.Point(18, 419);
			this.btnCCDelete.Name = "btnCCDelete";
			this.btnCCDelete.Size = new global::System.Drawing.Size(75, 23);
			this.btnCCDelete.TabIndex = 8;
			this.btnCCDelete.Text = "▶";
			this.btnCCDelete.UseVisualStyleBackColor = true;
			this.btnCCDelete.Click += new global::System.EventHandler(this.btnCCDelete_Click);
			this.btnAppend.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnAppend.Location = new global::System.Drawing.Point(18, 96);
			this.btnAppend.Name = "btnAppend";
			this.btnAppend.Size = new global::System.Drawing.Size(75, 23);
			this.btnAppend.TabIndex = 1;
			this.btnAppend.Text = "◀";
			this.btnAppend.UseVisualStyleBackColor = true;
			this.btnAppend.Click += new global::System.EventHandler(this.btnAppend_Click);
			this.btnDelete.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnDelete.Location = new global::System.Drawing.Point(18, 147);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new global::System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 6;
			this.btnDelete.Text = "▶";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new global::System.EventHandler(this.btnDelete_Click);
			this.panel2.Controls.Add(this.groupBox5);
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new global::System.Drawing.Point(3, 17);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(432, 516);
			this.panel2.TabIndex = 4;
			this.groupBox5.Controls.Add(this.pnCCInfo);
			this.groupBox5.Controls.Add(this.grid1);
			this.groupBox5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox5.Location = new global::System.Drawing.Point(0, 256);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(432, 260);
			this.groupBox5.TabIndex = 5;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "CC Mail List";
			this.pnCCInfo.Controls.Add(this.pnCCFunction);
			this.pnCCInfo.Controls.Add(this.rbCCInfo);
			this.pnCCInfo.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnCCInfo.Location = new global::System.Drawing.Point(3, 17);
			this.pnCCInfo.Name = "pnCCInfo";
			this.pnCCInfo.Size = new global::System.Drawing.Size(426, 240);
			this.pnCCInfo.TabIndex = 24;
			this.pnCCFunction.Controls.Add(this.btnGridClose2);
			this.pnCCFunction.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnCCFunction.Location = new global::System.Drawing.Point(0, 199);
			this.pnCCFunction.Name = "pnCCFunction";
			this.pnCCFunction.Size = new global::System.Drawing.Size(426, 41);
			this.pnCCFunction.TabIndex = 23;
			this.btnGridClose2.BackColor = global::System.Drawing.Color.White;
			this.btnGridClose2.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnGridClose2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnGridClose2.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.btnGridClose2.Location = new global::System.Drawing.Point(367, 0);
			this.btnGridClose2.Name = "btnGridClose2";
			this.btnGridClose2.Size = new global::System.Drawing.Size(59, 41);
			this.btnGridClose2.TabIndex = 1;
			this.btnGridClose2.Text = "X";
			this.btnGridClose2.UseVisualStyleBackColor = false;
			this.btnGridClose2.Click += new global::System.EventHandler(this.btnGridClose2_Click);
			this.rbCCInfo.BackColor = global::System.Drawing.Color.White;
			this.rbCCInfo.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.rbCCInfo.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.rbCCInfo.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.rbCCInfo.Location = new global::System.Drawing.Point(0, 0);
			this.rbCCInfo.Name = "rbCCInfo";
			this.rbCCInfo.ReadOnly = true;
			this.rbCCInfo.Size = new global::System.Drawing.Size(426, 199);
			this.rbCCInfo.TabIndex = 21;
			this.rbCCInfo.Text = "-정비 의뢰 및 장비 사용 신청(Maintenance & Machine borrow) : 본인 소속 그룹 및 기타 공유 필요 그룹\n\n※ Request 과정에서 반드시, 준수해 주시기 바랍니다.";
			this.grid1.Controls.Add(this.grid_CCMail);
			this.grid1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid1.EnableSort = true;
			this.grid1.FixedColumns = 1;
			this.grid1.FixedRows = 1;
			this.grid1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.grid1.Location = new global::System.Drawing.Point(3, 17);
			this.grid1.Name = "grid1";
			this.grid1.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid1.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid1.Size = new global::System.Drawing.Size(426, 240);
			this.grid1.TabIndex = 18;
			this.grid1.TabStop = true;
			this.grid1.ToolTipText = "";
			this.grid_CCMail.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_CCMail.EnableSort = true;
			this.grid_CCMail.FixedColumns = 1;
			this.grid_CCMail.FixedRows = 1;
			this.grid_CCMail.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.grid_CCMail.Location = new global::System.Drawing.Point(0, 0);
			this.grid_CCMail.Name = "grid_CCMail";
			this.grid_CCMail.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_CCMail.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_CCMail.Size = new global::System.Drawing.Size(426, 240);
			this.grid_CCMail.TabIndex = 19;
			this.grid_CCMail.TabStop = true;
			this.grid_CCMail.ToolTipText = "";
			this.groupBox3.Controls.Add(this.pnToInfo);
			this.groupBox3.Controls.Add(this.grid_mail);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox3.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(432, 256);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "To Mail List";
			this.pnToInfo.Controls.Add(this.pnToFunciton);
			this.pnToInfo.Controls.Add(this.rbToInfo);
			this.pnToInfo.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnToInfo.Location = new global::System.Drawing.Point(3, 17);
			this.pnToInfo.Name = "pnToInfo";
			this.pnToInfo.Size = new global::System.Drawing.Size(426, 236);
			this.pnToInfo.TabIndex = 19;
			this.pnToFunciton.Controls.Add(this.btnGridClose);
			this.pnToFunciton.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnToFunciton.Location = new global::System.Drawing.Point(0, 199);
			this.pnToFunciton.Name = "pnToFunciton";
			this.pnToFunciton.Size = new global::System.Drawing.Size(426, 37);
			this.pnToFunciton.TabIndex = 22;
			this.btnGridClose.BackColor = global::System.Drawing.Color.White;
			this.btnGridClose.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnGridClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnGridClose.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.btnGridClose.Location = new global::System.Drawing.Point(367, 0);
			this.btnGridClose.Name = "btnGridClose";
			this.btnGridClose.Size = new global::System.Drawing.Size(59, 37);
			this.btnGridClose.TabIndex = 1;
			this.btnGridClose.Text = "X";
			this.btnGridClose.UseVisualStyleBackColor = false;
			this.btnGridClose.Click += new global::System.EventHandler(this.btnGridClose_Click);
			this.rbToInfo.BackColor = global::System.Drawing.Color.White;
			this.rbToInfo.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.rbToInfo.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.rbToInfo.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.rbToInfo.Location = new global::System.Drawing.Point(0, 0);
			this.rbToInfo.Name = "rbToInfo";
			this.rbToInfo.ReadOnly = true;
			this.rbToInfo.Size = new global::System.Drawing.Size(426, 199);
			this.rbToInfo.TabIndex = 20;
			this.rbToInfo.Text = "-정비 의뢰 신청(Maintenance) : 해당 PM파트 및 장비기술파트 그룹\n-장비 사용 신청(Machine borrow) : 해당 제조파트 쉽트장 및 장비 그룹\n  \n※ Request 과정에서 반드시, 준수해 주시기 바랍니다.";
			this.grid_mail.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_mail.EnableSort = true;
			this.grid_mail.FixedColumns = 1;
			this.grid_mail.FixedRows = 1;
			this.grid_mail.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.grid_mail.Location = new global::System.Drawing.Point(3, 17);
			this.grid_mail.Name = "grid_mail";
			this.grid_mail.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_mail.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_mail.Size = new global::System.Drawing.Size(426, 236);
			this.grid_mail.TabIndex = 18;
			this.grid_mail.TabStop = true;
			this.grid_mail.ToolTipText = "";
			this.grid_mail.DoubleClick += new global::System.EventHandler(this.grid_mail_DoubleClick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(985, 607);
			base.ControlBox = false;
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBox2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MailForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mail List";
			this.groupBox2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbApply).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.pnCCInfo.ResumeLayout(false);
			this.pnCCFunction.ResumeLayout(false);
			this.grid1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.pnToInfo.ResumeLayout(false);
			this.pnToFunciton.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000580 RID: 1408
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000581 RID: 1409
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000582 RID: 1410
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000583 RID: 1411
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000584 RID: 1412
		private global::System.Windows.Forms.Button btnDelete;

		// Token: 0x04000585 RID: 1413
		private global::System.Windows.Forms.Button btnAppend;

		// Token: 0x04000586 RID: 1414
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000587 RID: 1415
		private global::SourceGrid.Grid grid_TempMail;

		// Token: 0x04000588 RID: 1416
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000589 RID: 1417
		private global::SourceGrid.Grid grid_mail;

		// Token: 0x0400058A RID: 1418
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x0400058B RID: 1419
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400058C RID: 1420
		private global::System.Windows.Forms.Button btnCCAppend;

		// Token: 0x0400058D RID: 1421
		private global::System.Windows.Forms.Button btnCCDelete;

		// Token: 0x0400058E RID: 1422
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400058F RID: 1423
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x04000590 RID: 1424
		private global::SourceGrid.Grid grid1;

		// Token: 0x04000591 RID: 1425
		private global::SourceGrid.Grid grid_CCMail;

		// Token: 0x04000592 RID: 1426
		private global::System.Windows.Forms.PictureBox pbApply;

		// Token: 0x04000593 RID: 1427
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000594 RID: 1428
		private global::System.Windows.Forms.PictureBox pbCancel;

		// Token: 0x04000595 RID: 1429
		private global::System.Windows.Forms.Panel pnToInfo;

		// Token: 0x04000596 RID: 1430
		private global::System.Windows.Forms.Panel pnToFunciton;

		// Token: 0x04000597 RID: 1431
		private global::System.Windows.Forms.RichTextBox rbToInfo;

		// Token: 0x04000598 RID: 1432
		private global::System.Windows.Forms.Button btnGridClose;

		// Token: 0x04000599 RID: 1433
		private global::System.Windows.Forms.Panel pnCCInfo;

		// Token: 0x0400059A RID: 1434
		private global::System.Windows.Forms.Panel pnCCFunction;

		// Token: 0x0400059B RID: 1435
		private global::System.Windows.Forms.Button btnGridClose2;

		// Token: 0x0400059C RID: 1436
		private global::System.Windows.Forms.RichTextBox rbCCInfo;
	}
}
