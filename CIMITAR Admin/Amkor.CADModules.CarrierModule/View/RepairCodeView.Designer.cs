namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200004A RID: 74
	public partial class RepairCodeView : global::System.Windows.Forms.Form
	{
		// Token: 0x06000378 RID: 888 RVA: 0x00053CB6 File Offset: 0x00051EB6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00053CD8 File Offset: 0x00051ED8
		private void InitializeComponent()
		{
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.gridRepairCode = new global::SourceGrid.Grid();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.txtRepairCode = new global::System.Windows.Forms.TextBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.cmdDeleteCode = new global::System.Windows.Forms.PictureBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.cmdDownLoad = new global::System.Windows.Forms.PictureBox();
			this.cmbDevice = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.groupBox10 = new global::System.Windows.Forms.GroupBox();
			this.cmdCodeSearch = new global::System.Windows.Forms.PictureBox();
			this.cmbCategory = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cmbType = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.richTextBox1 = new global::System.Windows.Forms.RichTextBox();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.cmdAddCode = new global::System.Windows.Forms.PictureBox();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.txtAddCode = new global::System.Windows.Forms.TextBox();
			this.cmbAddDevice = new global::System.Windows.Forms.ComboBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cmbAddCategory = new global::System.Windows.Forms.ComboBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.cmbAddType = new global::System.Windows.Forms.ComboBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDeleteCode).BeginInit();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDownLoad).BeginInit();
			this.groupBox10.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdCodeSearch).BeginInit();
			this.groupBox4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdAddCode).BeginInit();
			this.panel6.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			base.SuspendLayout();
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(798, 44);
			this.panel24.TabIndex = 18;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(168, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Repair Code View";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.label13);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 565);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(798, 32);
			this.panel25.TabIndex = 27;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(275, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(239, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2015 Amkor Technology Korea";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.richTextBox1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 44);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(798, 445);
			this.panel1.TabIndex = 29;
			this.panel4.Controls.Add(this.groupBox3);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new global::System.Drawing.Point(0, 61);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(798, 384);
			this.panel4.TabIndex = 2;
			this.groupBox3.Controls.Add(this.gridRepairCode);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new global::System.Drawing.Point(0, 44);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(798, 340);
			this.groupBox3.TabIndex = 30;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Repair Code List";
			this.gridRepairCode.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridRepairCode.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridRepairCode.EnableSort = true;
			this.gridRepairCode.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridRepairCode.Location = new global::System.Drawing.Point(3, 19);
			this.gridRepairCode.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridRepairCode.Name = "gridRepairCode";
			this.gridRepairCode.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridRepairCode.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridRepairCode.Size = new global::System.Drawing.Size(792, 318);
			this.gridRepairCode.TabIndex = 29;
			this.gridRepairCode.TabStop = true;
			this.gridRepairCode.ToolTipText = "";
			this.panel5.Controls.Add(this.label3);
			this.panel5.Controls.Add(this.txtRepairCode);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(798, 44);
			this.panel5.TabIndex = 3;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(12, 14);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(73, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Search Code";
			this.txtRepairCode.Location = new global::System.Drawing.Point(91, 11);
			this.txtRepairCode.Name = "txtRepairCode";
			this.txtRepairCode.Size = new global::System.Drawing.Size(328, 23);
			this.txtRepairCode.TabIndex = 0;
			this.txtRepairCode.TextChanged += new global::System.EventHandler(this.txtRepairCode_TextChanged);
			this.panel3.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.groupBox5);
			this.panel3.Controls.Add(this.groupBox1);
			this.panel3.Controls.Add(this.cmbDevice);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.groupBox10);
			this.panel3.Controls.Add(this.cmbCategory);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.cmbType);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(798, 61);
			this.panel3.TabIndex = 1;
			this.groupBox5.Controls.Add(this.cmdDeleteCode);
			this.groupBox5.Location = new global::System.Drawing.Point(667, 2);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(57, 57);
			this.groupBox5.TabIndex = 90;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Delete";
			this.cmdDeleteCode.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableRemove;
			this.cmdDeleteCode.Location = new global::System.Drawing.Point(13, 17);
			this.cmdDeleteCode.Name = "cmdDeleteCode";
			this.cmdDeleteCode.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDeleteCode.TabIndex = 86;
			this.cmdDeleteCode.TabStop = false;
			this.cmdDeleteCode.Click += new global::System.EventHandler(this.cmdDeleteCode_Click);
			this.cmdDeleteCode.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeleteCode_MouseDown);
			this.cmdDeleteCode.MouseLeave += new global::System.EventHandler(this.cmdDeleteCode_MouseLeave);
			this.cmdDeleteCode.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeleteCode_MouseMove);
			this.cmdDeleteCode.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdDeleteCode_MouseUp);
			this.groupBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox1.Controls.Add(this.cmdDownLoad);
			this.groupBox1.Location = new global::System.Drawing.Point(730, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(59, 57);
			this.groupBox1.TabIndex = 107;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Down";
			this.cmdDownLoad.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdDownLoad.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.SaveExcel;
			this.cmdDownLoad.Location = new global::System.Drawing.Point(13, 16);
			this.cmdDownLoad.Name = "cmdDownLoad";
			this.cmdDownLoad.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDownLoad.TabIndex = 103;
			this.cmdDownLoad.TabStop = false;
			this.cmdDownLoad.Click += new global::System.EventHandler(this.cmdDownLoad_Click);
			this.cmdDownLoad.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdDownLoad_MouseDown);
			this.cmdDownLoad.MouseLeave += new global::System.EventHandler(this.cmdDownLoad_MouseLeave);
			this.cmdDownLoad.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdDownLoad_MouseMove);
			this.cmdDownLoad.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdDownLoad_MouseUp);
			this.cmbDevice.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbDevice.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDevice.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbDevice.FormattingEnabled = true;
			this.cmbDevice.Location = new global::System.Drawing.Point(474, 19);
			this.cmbDevice.Name = "cmbDevice";
			this.cmbDevice.Size = new global::System.Drawing.Size(102, 23);
			this.cmbDevice.TabIndex = 89;
			this.cmbDevice.DropDown += new global::System.EventHandler(this.cmbDevice_DropDown);
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(426, 23);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(42, 15);
			this.label4.TabIndex = 88;
			this.label4.Text = "Device";
			this.groupBox10.Controls.Add(this.cmdCodeSearch);
			this.groupBox10.Location = new global::System.Drawing.Point(604, 2);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new global::System.Drawing.Size(57, 57);
			this.groupBox10.TabIndex = 47;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Search";
			this.cmdCodeSearch.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableSearch;
			this.cmdCodeSearch.Location = new global::System.Drawing.Point(12, 17);
			this.cmdCodeSearch.Name = "cmdCodeSearch";
			this.cmdCodeSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdCodeSearch.TabIndex = 25;
			this.cmdCodeSearch.TabStop = false;
			this.cmdCodeSearch.Click += new global::System.EventHandler(this.cmdCodeSearch_Click);
			this.cmdCodeSearch.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdCodeSearch_MouseDown);
			this.cmdCodeSearch.MouseLeave += new global::System.EventHandler(this.cmdCodeSearch_MouseLeave);
			this.cmdCodeSearch.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdCodeSearch_MouseMove);
			this.cmdCodeSearch.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdCodeSearch_MouseUp);
			this.cmbCategory.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbCategory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCategory.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbCategory.FormattingEnabled = true;
			this.cmbCategory.Location = new global::System.Drawing.Point(222, 19);
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.Size = new global::System.Drawing.Size(196, 23);
			this.cmbCategory.TabIndex = 44;
			this.cmbCategory.DropDown += new global::System.EventHandler(this.cmbCategory_DropDown);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(165, 23);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(55, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Category";
			this.cmbType.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Location = new global::System.Drawing.Point(45, 19);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new global::System.Drawing.Size(112, 23);
			this.cmbType.TabIndex = 46;
			this.cmbType.DropDown += new global::System.EventHandler(this.cmbType_DropDown);
			this.cmbType.SelectedIndexChanged += new global::System.EventHandler(this.cmbType_SelectedIndexChanged);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(6, 23);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(33, 15);
			this.label2.TabIndex = 45;
			this.label2.Text = "Type";
			this.richTextBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new global::System.Drawing.Point(0, 0);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new global::System.Drawing.Size(798, 445);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			this.openFileDialog.FileName = "openFileDialog1";
			this.groupBox4.Controls.Add(this.cmdAddCode);
			this.groupBox4.Location = new global::System.Drawing.Point(605, 10);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(57, 57);
			this.groupBox4.TabIndex = 87;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Add";
			this.cmdAddCode.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableAdd;
			this.cmdAddCode.Location = new global::System.Drawing.Point(13, 17);
			this.cmdAddCode.Name = "cmdAddCode";
			this.cmdAddCode.Size = new global::System.Drawing.Size(32, 32);
			this.cmdAddCode.TabIndex = 86;
			this.cmdAddCode.TabStop = false;
			this.cmdAddCode.Click += new global::System.EventHandler(this.cmdAddCode_Click);
			this.cmdAddCode.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdAddCode_MouseDown);
			this.cmdAddCode.MouseLeave += new global::System.EventHandler(this.cmdAddCode_MouseLeave);
			this.cmdAddCode.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdAddCode_MouseMove);
			this.cmdAddCode.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdAddCode_MouseUp);
			this.panel6.Controls.Add(this.groupBox2);
			this.panel6.Controls.Add(this.label8);
			this.panel6.Controls.Add(this.txtAddCode);
			this.panel6.Controls.Add(this.cmbAddDevice);
			this.panel6.Controls.Add(this.label5);
			this.panel6.Controls.Add(this.cmbAddCategory);
			this.panel6.Controls.Add(this.label6);
			this.panel6.Controls.Add(this.cmbAddType);
			this.panel6.Controls.Add(this.label7);
			this.panel6.Controls.Add(this.groupBox4);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel6.Location = new global::System.Drawing.Point(0, 489);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(798, 76);
			this.panel6.TabIndex = 31;
			this.groupBox2.Controls.Add(this.cmdClose);
			this.groupBox2.Location = new global::System.Drawing.Point(733, 10);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(57, 57);
			this.groupBox2.TabIndex = 99;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Close";
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(13, 17);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdClose.TabIndex = 98;
			this.cmdClose.TabStop = false;
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseDown);
			this.cmdClose.MouseLeave += new global::System.EventHandler(this.cmdClose_MouseLeave);
			this.cmdClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
			this.cmdClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseUp);
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(7, 47);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(35, 15);
			this.label8.TabIndex = 97;
			this.label8.Text = "Code";
			this.txtAddCode.Location = new global::System.Drawing.Point(60, 44);
			this.txtAddCode.Name = "txtAddCode";
			this.txtAddCode.Size = new global::System.Drawing.Size(517, 23);
			this.txtAddCode.TabIndex = 96;
			this.cmbAddDevice.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbAddDevice.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAddDevice.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbAddDevice.FormattingEnabled = true;
			this.cmbAddDevice.Location = new global::System.Drawing.Point(475, 10);
			this.cmbAddDevice.Name = "cmbAddDevice";
			this.cmbAddDevice.Size = new global::System.Drawing.Size(102, 23);
			this.cmbAddDevice.TabIndex = 95;
			this.cmbAddDevice.DropDown += new global::System.EventHandler(this.cmbAddDevice_DropDown);
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(427, 14);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(42, 15);
			this.label5.TabIndex = 94;
			this.label5.Text = "Device";
			this.cmbAddCategory.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbAddCategory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAddCategory.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbAddCategory.FormattingEnabled = true;
			this.cmbAddCategory.Location = new global::System.Drawing.Point(223, 10);
			this.cmbAddCategory.Name = "cmbAddCategory";
			this.cmbAddCategory.Size = new global::System.Drawing.Size(196, 23);
			this.cmbAddCategory.TabIndex = 91;
			this.cmbAddCategory.DropDown += new global::System.EventHandler(this.cmbAddCategory_DropDown);
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(166, 14);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(55, 15);
			this.label6.TabIndex = 90;
			this.label6.Text = "Category";
			this.cmbAddType.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbAddType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAddType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbAddType.FormattingEnabled = true;
			this.cmbAddType.Location = new global::System.Drawing.Point(60, 10);
			this.cmbAddType.Name = "cmbAddType";
			this.cmbAddType.Size = new global::System.Drawing.Size(98, 23);
			this.cmbAddType.TabIndex = 93;
			this.cmbAddType.DropDown += new global::System.EventHandler(this.cmbAddType_DropDown);
			this.cmbAddType.SelectedIndexChanged += new global::System.EventHandler(this.cmbAddType_SelectedIndexChanged);
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(7, 14);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(33, 15);
			this.label7.TabIndex = 92;
			this.label7.Text = "Type";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(798, 597);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "RepairCodeView";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Repair Code";
			base.Load += new global::System.EventHandler(this.ResultView_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdDeleteCode).EndInit();
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdDownLoad).EndInit();
			this.groupBox10.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdCodeSearch).EndInit();
			this.groupBox4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdAddCode).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400058E RID: 1422
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400058F RID: 1423
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x04000590 RID: 1424
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x04000591 RID: 1425
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000592 RID: 1426
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000593 RID: 1427
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000594 RID: 1428
		private global::System.Windows.Forms.RichTextBox richTextBox1;

		// Token: 0x04000595 RID: 1429
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000596 RID: 1430
		private global::System.Windows.Forms.PictureBox cmdDownLoad;

		// Token: 0x04000597 RID: 1431
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000598 RID: 1432
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000599 RID: 1433
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400059A RID: 1434
		private global::System.Windows.Forms.ComboBox cmbCategory;

		// Token: 0x0400059B RID: 1435
		private global::SourceGrid.Grid gridRepairCode;

		// Token: 0x0400059C RID: 1436
		private global::System.Windows.Forms.ComboBox cmbType;

		// Token: 0x0400059D RID: 1437
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400059E RID: 1438
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x0400059F RID: 1439
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x040005A0 RID: 1440
		private global::System.Windows.Forms.GroupBox groupBox10;

		// Token: 0x040005A1 RID: 1441
		private global::System.Windows.Forms.PictureBox cmdCodeSearch;

		// Token: 0x040005A2 RID: 1442
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x040005A3 RID: 1443
		private global::System.Windows.Forms.TextBox txtRepairCode;

		// Token: 0x040005A4 RID: 1444
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040005A5 RID: 1445
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040005A6 RID: 1446
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x040005A7 RID: 1447
		private global::System.Windows.Forms.PictureBox cmdAddCode;

		// Token: 0x040005A8 RID: 1448
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x040005A9 RID: 1449
		private global::System.Windows.Forms.PictureBox cmdDeleteCode;

		// Token: 0x040005AA RID: 1450
		private global::System.Windows.Forms.ComboBox cmbDevice;

		// Token: 0x040005AB RID: 1451
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040005AC RID: 1452
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040005AD RID: 1453
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040005AE RID: 1454
		private global::System.Windows.Forms.TextBox txtAddCode;

		// Token: 0x040005AF RID: 1455
		private global::System.Windows.Forms.ComboBox cmbAddDevice;

		// Token: 0x040005B0 RID: 1456
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040005B1 RID: 1457
		private global::System.Windows.Forms.ComboBox cmbAddCategory;

		// Token: 0x040005B2 RID: 1458
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040005B3 RID: 1459
		private global::System.Windows.Forms.ComboBox cmbAddType;

		// Token: 0x040005B4 RID: 1460
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040005B5 RID: 1461
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040005B6 RID: 1462
		private global::System.Windows.Forms.PictureBox cmdClose;
	}
}
