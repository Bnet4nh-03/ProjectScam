namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000045 RID: 69
	public partial class ModifyDefect : global::System.Windows.Forms.Form
	{
		// Token: 0x06000327 RID: 807 RVA: 0x0004E9A6 File Offset: 0x0004CBA6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0004E9C8 File Offset: 0x0004CBC8
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.CarrierModule.View.ModifyDefect));
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.cmdApply = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.cmdUploadFile = new global::System.Windows.Forms.PictureBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.cmbDamage = new global::System.Windows.Forms.ComboBox();
			this.cmbSuspectCause = new global::System.Windows.Forms.ComboBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.cmdExcel = new global::System.Windows.Forms.PictureBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.grpApply = new global::System.Windows.Forms.GroupBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panelRepairCode = new global::System.Windows.Forms.Panel();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.grpRepairReason = new global::System.Windows.Forms.GroupBox();
			this.txtRepairCode = new global::System.Windows.Forms.TextBox();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.pbUploadImage = new global::System.Windows.Forms.PictureBox();
			this.txtMemo = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.txtRevision = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.txtAttachFile = new global::System.Windows.Forms.TextBox();
			this.label43 = new global::System.Windows.Forms.Label();
			this.txtBarcode = new global::System.Windows.Forms.TextBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.cmdDelete = new global::System.Windows.Forms.PictureBox();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.groupBox16 = new global::System.Windows.Forms.GroupBox();
			this.gridDefectList = new global::SourceGrid.Grid();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).BeginInit();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUploadFile).BeginInit();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdExcel).BeginInit();
			this.grpApply.SuspendLayout();
			this.panelRepairCode.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.grpRepairReason.SuspendLayout();
			this.panel4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbUploadImage).BeginInit();
			this.panel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDelete).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			this.panel3.SuspendLayout();
			this.groupBox16.SuspendLayout();
			base.SuspendLayout();
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(948, 38);
			this.panel24.TabIndex = 18;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 7);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(76, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Modify";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.label13);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 629);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(948, 32);
			this.panel25.TabIndex = 27;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(350, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(238, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2015 Amkor Technology Korea";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdApply.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdApply.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdApply.Location = new global::System.Drawing.Point(44, 3);
			this.cmdApply.Name = "cmdApply";
			this.cmdApply.Size = new global::System.Drawing.Size(32, 32);
			this.cmdApply.TabIndex = 24;
			this.cmdApply.TabStop = false;
			this.cmdApply.Click += new global::System.EventHandler(this.cmdApply_Click);
			this.cmdApply.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseDown);
			this.cmdApply.MouseLeave += new global::System.EventHandler(this.cmdApply_MouseLeave);
			this.cmdApply.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseMove);
			this.cmdApply.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseUp);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.cmdUploadFile);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.cmbDamage);
			this.panel1.Controls.Add(this.cmbSuspectCause);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.grpApply);
			this.panel1.Controls.Add(this.panelRepairCode);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.txtMemo);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.txtRevision);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtAttachFile);
			this.panel1.Controls.Add(this.label43);
			this.panel1.Controls.Add(this.txtBarcode);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 38);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel1.Size = new global::System.Drawing.Size(948, 316);
			this.panel1.TabIndex = 29;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label2.Location = new global::System.Drawing.Point(557, 88);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(59, 15);
			this.label2.TabIndex = 108;
			this.label2.Text = "Reference";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label8.Location = new global::System.Drawing.Point(752, 8);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(80, 15);
			this.label8.TabIndex = 122;
			this.label8.Text = "SuspectCause";
			this.cmdUploadFile.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.OpenTable;
			this.cmdUploadFile.Location = new global::System.Drawing.Point(909, 81);
			this.cmdUploadFile.Name = "cmdUploadFile";
			this.cmdUploadFile.Size = new global::System.Drawing.Size(32, 32);
			this.cmdUploadFile.TabIndex = 104;
			this.cmdUploadFile.TabStop = false;
			this.cmdUploadFile.Click += new global::System.EventHandler(this.cmdUploadFile_Click);
			this.cmdUploadFile.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdUploadFile_MouseDown);
			this.cmdUploadFile.MouseLeave += new global::System.EventHandler(this.cmdUploadFile_MouseLeave);
			this.cmdUploadFile.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdUploadFile_MouseMove);
			this.cmdUploadFile.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdUploadFile_MouseUp);
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label7.Location = new global::System.Drawing.Point(557, 8);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(51, 15);
			this.label7.TabIndex = 120;
			this.label7.Text = "Damage";
			this.cmbDamage.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbDamage.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDamage.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbDamage.FormattingEnabled = true;
			this.cmbDamage.Location = new global::System.Drawing.Point(618, 5);
			this.cmbDamage.Name = "cmbDamage";
			this.cmbDamage.Size = new global::System.Drawing.Size(133, 23);
			this.cmbDamage.TabIndex = 119;
			this.cmbDamage.DropDown += new global::System.EventHandler(this.cmbDamage_DropDown);
			this.cmbSuspectCause.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbSuspectCause.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSuspectCause.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbSuspectCause.FormattingEnabled = true;
			this.cmbSuspectCause.Location = new global::System.Drawing.Point(834, 5);
			this.cmbSuspectCause.Name = "cmbSuspectCause";
			this.cmbSuspectCause.Size = new global::System.Drawing.Size(107, 23);
			this.cmbSuspectCause.TabIndex = 121;
			this.cmbSuspectCause.DropDown += new global::System.EventHandler(this.cmbSuspectCause_DropDown);
			this.groupBox1.Controls.Add(this.cmdExcel);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Font = new global::System.Drawing.Font("Segoe UI", 1f);
			this.groupBox1.Location = new global::System.Drawing.Point(462, 1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(69, 38);
			this.groupBox1.TabIndex = 118;
			this.groupBox1.TabStop = false;
			this.cmdExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdExcel.Image");
			this.cmdExcel.Location = new global::System.Drawing.Point(33, 3);
			this.cmdExcel.Name = "cmdExcel";
			this.cmdExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdExcel.TabIndex = 99;
			this.cmdExcel.TabStop = false;
			this.cmdExcel.Click += new global::System.EventHandler(this.cmdExcel_Click);
			this.cmdExcel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseDown);
			this.cmdExcel.MouseLeave += new global::System.EventHandler(this.cmdExcel_MouseLeave);
			this.cmdExcel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseMove);
			this.cmdExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseUp);
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label5.Location = new global::System.Drawing.Point(1, 12);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(33, 15);
			this.label5.TabIndex = 102;
			this.label5.Text = "Excel";
			this.grpApply.Controls.Add(this.cmdApply);
			this.grpApply.Controls.Add(this.label1);
			this.grpApply.Font = new global::System.Drawing.Font("Segoe UI", 1f);
			this.grpApply.Location = new global::System.Drawing.Point(366, 1);
			this.grpApply.Name = "grpApply";
			this.grpApply.Size = new global::System.Drawing.Size(79, 38);
			this.grpApply.TabIndex = 117;
			this.grpApply.TabStop = false;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label1.Location = new global::System.Drawing.Point(1, 12);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(45, 15);
			this.label1.TabIndex = 102;
			this.label1.Text = "Modify";
			this.panelRepairCode.Controls.Add(this.tabControl1);
			this.panelRepairCode.Controls.Add(this.grpRepairReason);
			this.panelRepairCode.Location = new global::System.Drawing.Point(6, 31);
			this.panelRepairCode.Name = "panelRepairCode";
			this.panelRepairCode.Size = new global::System.Drawing.Size(548, 279);
			this.panelRepairCode.TabIndex = 117;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new global::System.Drawing.Point(0, 42);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(548, 237);
			this.tabControl1.TabIndex = 94;
			this.tabPage1.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(540, 209);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage2.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(540, 209);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.grpRepairReason.Controls.Add(this.txtRepairCode);
			this.grpRepairReason.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.grpRepairReason.Location = new global::System.Drawing.Point(0, 0);
			this.grpRepairReason.Name = "grpRepairReason";
			this.grpRepairReason.Padding = new global::System.Windows.Forms.Padding(5, 3, 5, 5);
			this.grpRepairReason.Size = new global::System.Drawing.Size(548, 42);
			this.grpRepairReason.TabIndex = 88;
			this.grpRepairReason.TabStop = false;
			this.grpRepairReason.Text = "Code";
			this.txtRepairCode.Location = new global::System.Drawing.Point(8, 15);
			this.txtRepairCode.Name = "txtRepairCode";
			this.txtRepairCode.Size = new global::System.Drawing.Size(253, 23);
			this.txtRepairCode.TabIndex = 2;
			this.txtRepairCode.TextChanged += new global::System.EventHandler(this.txtRepairCode_TextChanged);
			this.panel4.Controls.Add(this.pbUploadImage);
			this.panel4.Location = new global::System.Drawing.Point(560, 113);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(381, 197);
			this.panel4.TabIndex = 116;
			this.pbUploadImage.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbUploadImage.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pbUploadImage.Location = new global::System.Drawing.Point(0, 0);
			this.pbUploadImage.Name = "pbUploadImage";
			this.pbUploadImage.Size = new global::System.Drawing.Size(381, 197);
			this.pbUploadImage.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbUploadImage.TabIndex = 116;
			this.pbUploadImage.TabStop = false;
			this.pbUploadImage.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.pbUploadImage_MouseClick);
			this.pbUploadImage.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.pbUploadImage_MouseDoubleClick);
			this.txtMemo.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtMemo.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtMemo.Location = new global::System.Drawing.Point(618, 58);
			this.txtMemo.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtMemo.Name = "txtMemo";
			this.txtMemo.Size = new global::System.Drawing.Size(323, 23);
			this.txtMemo.TabIndex = 115;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label4.Location = new global::System.Drawing.Point(557, 61);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(42, 15);
			this.label4.TabIndex = 114;
			this.label4.Text = "Memo";
			this.txtRevision.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtRevision.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtRevision.Location = new global::System.Drawing.Point(618, 31);
			this.txtRevision.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtRevision.Name = "txtRevision";
			this.txtRevision.Size = new global::System.Drawing.Size(323, 23);
			this.txtRevision.TabIndex = 113;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label3.Location = new global::System.Drawing.Point(557, 34);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(51, 15);
			this.label3.TabIndex = 112;
			this.label3.Text = "Revision";
			this.txtAttachFile.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtAttachFile.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtAttachFile.Location = new global::System.Drawing.Point(618, 85);
			this.txtAttachFile.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtAttachFile.Name = "txtAttachFile";
			this.txtAttachFile.ReadOnly = true;
			this.txtAttachFile.Size = new global::System.Drawing.Size(285, 23);
			this.txtAttachFile.TabIndex = 109;
			this.label43.AutoSize = true;
			this.label43.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label43.Location = new global::System.Drawing.Point(10, 10);
			this.label43.Name = "label43";
			this.label43.Size = new global::System.Drawing.Size(50, 15);
			this.label43.TabIndex = 95;
			this.label43.Text = "Barcode";
			this.txtBarcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtBarcode.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtBarcode.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtBarcode.Location = new global::System.Drawing.Point(76, 7);
			this.txtBarcode.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.ReadOnly = true;
			this.txtBarcode.Size = new global::System.Drawing.Size(273, 23);
			this.txtBarcode.TabIndex = 91;
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.groupBox2);
			this.panel2.Controls.Add(this.cmdClose);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 590);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(948, 39);
			this.panel2.TabIndex = 30;
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.cmdDelete);
			this.groupBox2.Font = new global::System.Drawing.Font("Segoe UI", 1f);
			this.groupBox2.Location = new global::System.Drawing.Point(5, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(77, 38);
			this.groupBox2.TabIndex = 119;
			this.groupBox2.TabStop = false;
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label6.Location = new global::System.Drawing.Point(1, 12);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(40, 15);
			this.label6.TabIndex = 102;
			this.label6.Text = "Delete";
			this.cmdDelete.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableRemove;
			this.cmdDelete.Location = new global::System.Drawing.Point(42, 3);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDelete.TabIndex = 100;
			this.cmdDelete.TabStop = false;
			this.cmdDelete.Click += new global::System.EventHandler(this.cmdDelete_Click);
			this.cmdDelete.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdDelete_MouseDown);
			this.cmdDelete.MouseLeave += new global::System.EventHandler(this.cmdDelete_MouseLeave);
			this.cmdDelete.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdDelete_MouseMove);
			this.cmdDelete.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdDelete_MouseUp);
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(902, 2);
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
			this.panel3.Controls.Add(this.groupBox16);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 354);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel3.Size = new global::System.Drawing.Size(948, 236);
			this.panel3.TabIndex = 112;
			this.groupBox16.Controls.Add(this.gridDefectList);
			this.groupBox16.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox16.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox16.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox16.Size = new global::System.Drawing.Size(942, 230);
			this.groupBox16.TabIndex = 6;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "Defect Status List";
			this.gridDefectList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridDefectList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridDefectList.EnableSort = true;
			this.gridDefectList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridDefectList.Location = new global::System.Drawing.Point(3, 20);
			this.gridDefectList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridDefectList.Name = "gridDefectList";
			this.gridDefectList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridDefectList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridDefectList.Size = new global::System.Drawing.Size(936, 206);
			this.gridDefectList.TabIndex = 14;
			this.gridDefectList.TabStop = true;
			this.gridDefectList.ToolTipText = "";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(948, 661);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "ModifyDefect";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Modify Defect";
			base.Load += new global::System.EventHandler(this.ModifyDefect_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUploadFile).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdExcel).EndInit();
			this.grpApply.ResumeLayout(false);
			this.grpApply.PerformLayout();
			this.panelRepairCode.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.grpRepairReason.ResumeLayout(false);
			this.grpRepairReason.PerformLayout();
			this.panel4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbUploadImage).EndInit();
			this.panel2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDelete).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			this.panel3.ResumeLayout(false);
			this.groupBox16.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400051B RID: 1307
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400051C RID: 1308
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x0400051D RID: 1309
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x0400051E RID: 1310
		private global::System.Windows.Forms.PictureBox cmdApply;

		// Token: 0x0400051F RID: 1311
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000520 RID: 1312
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000521 RID: 1313
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000522 RID: 1314
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000523 RID: 1315
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x04000524 RID: 1316
		private global::System.Windows.Forms.Label label43;

		// Token: 0x04000525 RID: 1317
		private global::System.Windows.Forms.TextBox txtBarcode;

		// Token: 0x04000526 RID: 1318
		private global::System.Windows.Forms.TextBox txtAttachFile;

		// Token: 0x04000527 RID: 1319
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000528 RID: 1320
		private global::System.Windows.Forms.PictureBox cmdUploadFile;

		// Token: 0x04000529 RID: 1321
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x0400052A RID: 1322
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400052B RID: 1323
		private global::System.Windows.Forms.GroupBox groupBox16;

		// Token: 0x0400052C RID: 1324
		private global::System.Windows.Forms.TextBox txtMemo;

		// Token: 0x0400052D RID: 1325
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400052E RID: 1326
		private global::System.Windows.Forms.TextBox txtRevision;

		// Token: 0x0400052F RID: 1327
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000530 RID: 1328
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000531 RID: 1329
		private global::System.Windows.Forms.PictureBox pbUploadImage;

		// Token: 0x04000532 RID: 1330
		private global::SourceGrid.Grid gridDefectList;

		// Token: 0x04000533 RID: 1331
		private global::System.Windows.Forms.Panel panelRepairCode;

		// Token: 0x04000534 RID: 1332
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x04000535 RID: 1333
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x04000536 RID: 1334
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x04000537 RID: 1335
		private global::System.Windows.Forms.GroupBox grpRepairReason;

		// Token: 0x04000538 RID: 1336
		private global::System.Windows.Forms.TextBox txtRepairCode;

		// Token: 0x04000539 RID: 1337
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x0400053A RID: 1338
		private global::System.Windows.Forms.PictureBox cmdExcel;

		// Token: 0x0400053B RID: 1339
		private global::System.Windows.Forms.GroupBox grpApply;

		// Token: 0x0400053C RID: 1340
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400053D RID: 1341
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400053E RID: 1342
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400053F RID: 1343
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000540 RID: 1344
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000541 RID: 1345
		private global::System.Windows.Forms.PictureBox cmdDelete;

		// Token: 0x04000542 RID: 1346
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000543 RID: 1347
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000544 RID: 1348
		private global::System.Windows.Forms.ComboBox cmbDamage;

		// Token: 0x04000545 RID: 1349
		private global::System.Windows.Forms.ComboBox cmbSuspectCause;
	}
}
