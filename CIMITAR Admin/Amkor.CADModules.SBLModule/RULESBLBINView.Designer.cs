namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000016 RID: 22
	public partial class RULESBLBINView : global::System.Windows.Forms.Form
	{
		// Token: 0x06000086 RID: 134 RVA: 0x000087C2 File Offset: 0x000069C2
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000087E4 File Offset: 0x000069E4
		private void InitializeComponent()
		{
			this.grid_sbls = new global::SourceGrid.Grid();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.comboBox_OPT = new global::System.Windows.Forms.ComboBox();
			this.comboBox_statusid = new global::System.Windows.Forms.ComboBox();
			this.checkBox_ispass = new global::System.Windows.Forms.CheckBox();
			this.checkBox_fwaferid = new global::System.Windows.Forms.CheckBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.textBox_plimit = new global::System.Windows.Forms.TextBox();
			this.textBox_climit = new global::System.Windows.Forms.TextBox();
			this.textBox_slimit = new global::System.Windows.Forms.TextBox();
			this.textBox_cnlimit = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.textBox_aplimit = new global::System.Windows.Forms.TextBox();
			this.textBox_aclimit = new global::System.Windows.Forms.TextBox();
			this.textBox_aslimit = new global::System.Windows.Forms.TextBox();
			this.textBox_acnlimit = new global::System.Windows.Forms.TextBox();
			this.textBox_basecount = new global::System.Windows.Forms.TextBox();
			this.textBox_basepercent = new global::System.Windows.Forms.TextBox();
			this.textBox_basesitecount = new global::System.Windows.Forms.TextBox();
			this.textBox_bins = new global::System.Windows.Forms.TextBox();
			this.textBox_statusid = new global::System.Windows.Forms.TextBox();
			this.button_addstatusid = new global::System.Windows.Forms.Button();
			this.button_edit = new global::System.Windows.Forms.Button();
			this.button_save = new global::System.Windows.Forms.Button();
			this.button_cancle = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.button_delStatus = new global::System.Windows.Forms.Button();
			this.button_Close = new global::System.Windows.Forms.Button();
			this.panel_grid = new global::System.Windows.Forms.Panel();
			this.button_bulkInsert = new global::System.Windows.Forms.Button();
			this.button_NEW = new global::System.Windows.Forms.Button();
			this.label_mode = new global::System.Windows.Forms.Label();
			this.button_delete = new global::System.Windows.Forms.Button();
			this.openFileDialog_csv = new global::System.Windows.Forms.OpenFileDialog();
			this.button_Export = new global::System.Windows.Forms.Button();
			this.saveFileDialog_csv = new global::System.Windows.Forms.SaveFileDialog();
			this.textBox_bslimit = new global::System.Windows.Forms.TextBox();
			this.label15 = new global::System.Windows.Forms.Label();
			this.textBox_abslimit = new global::System.Windows.Forms.TextBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panel_grid.SuspendLayout();
			base.SuspendLayout();
			this.grid_sbls.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_sbls.EnableSort = true;
			this.grid_sbls.Location = new global::System.Drawing.Point(0, 0);
			this.grid_sbls.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.grid_sbls.Name = "grid_sbls";
			this.grid_sbls.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_sbls.SelectionMode = global::SourceGrid.GridSelectionMode.Row;
			this.grid_sbls.Size = new global::System.Drawing.Size(850, 301);
			this.grid_sbls.TabIndex = 0;
			this.grid_sbls.TabStop = true;
			this.grid_sbls.ToolTipText = "";
			this.grid_sbls.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_sbls_MouseClick);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(15, 58);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(43, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "SWBIN";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(32, 27);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(47, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "% Limit";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(225, 27);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(70, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Count Limit";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(23, 61);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(56, 15);
			this.label4.TabIndex = 1;
			this.label4.Text = "Site Limit";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(199, 61);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(96, 15);
			this.label5.TabIndex = 1;
			this.label5.Text = "Countinual Limit";
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(61, 31);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(65, 15);
			this.label10.TabIndex = 1;
			this.label10.Text = "base count";
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(72, 64);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(44, 15);
			this.label11.TabIndex = 1;
			this.label11.Text = "base %";
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(48, 99);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(104, 15);
			this.label12.TabIndex = 1;
			this.label12.Text = "base count for site";
			this.comboBox_OPT.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_OPT.FormattingEnabled = true;
			this.comboBox_OPT.Location = new global::System.Drawing.Point(157, 24);
			this.comboBox_OPT.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.comboBox_OPT.Name = "comboBox_OPT";
			this.comboBox_OPT.Size = new global::System.Drawing.Size(204, 23);
			this.comboBox_OPT.TabIndex = 2;
			this.comboBox_statusid.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_statusid.FormattingEnabled = true;
			this.comboBox_statusid.Location = new global::System.Drawing.Point(275, 96);
			this.comboBox_statusid.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.comboBox_statusid.Name = "comboBox_statusid";
			this.comboBox_statusid.Size = new global::System.Drawing.Size(87, 23);
			this.comboBox_statusid.TabIndex = 2;
			this.checkBox_ispass.AutoSize = true;
			this.checkBox_ispass.Enabled = false;
			this.checkBox_ispass.Location = new global::System.Drawing.Point(431, 55);
			this.checkBox_ispass.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.checkBox_ispass.Name = "checkBox_ispass";
			this.checkBox_ispass.Size = new global::System.Drawing.Size(61, 19);
			this.checkBox_ispass.TabIndex = 3;
			this.checkBox_ispass.Text = "IS Pass";
			this.checkBox_ispass.UseVisualStyleBackColor = true;
			this.checkBox_fwaferid.AutoSize = true;
			this.checkBox_fwaferid.Enabled = false;
			this.checkBox_fwaferid.Location = new global::System.Drawing.Point(520, 55);
			this.checkBox_fwaferid.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.checkBox_fwaferid.Name = "checkBox_fwaferid";
			this.checkBox_fwaferid.Size = new global::System.Drawing.Size(88, 19);
			this.checkBox_fwaferid.TabIndex = 3;
			this.checkBox_fwaferid.Text = "For WaferID";
			this.checkBox_fwaferid.UseVisualStyleBackColor = true;
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(58, 28);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(72, 15);
			this.label13.TabIndex = 1;
			this.label13.Text = "OPERATION";
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(63, 65);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(60, 15);
			this.label14.TabIndex = 1;
			this.label14.Text = "STATUSID";
			this.textBox_plimit.Location = new global::System.Drawing.Point(86, 24);
			this.textBox_plimit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_plimit.Name = "textBox_plimit";
			this.textBox_plimit.ReadOnly = true;
			this.textBox_plimit.Size = new global::System.Drawing.Size(100, 23);
			this.textBox_plimit.TabIndex = 4;
			this.textBox_climit.Location = new global::System.Drawing.Point(301, 24);
			this.textBox_climit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_climit.Name = "textBox_climit";
			this.textBox_climit.ReadOnly = true;
			this.textBox_climit.Size = new global::System.Drawing.Size(100, 23);
			this.textBox_climit.TabIndex = 4;
			this.textBox_slimit.Location = new global::System.Drawing.Point(86, 57);
			this.textBox_slimit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_slimit.Name = "textBox_slimit";
			this.textBox_slimit.ReadOnly = true;
			this.textBox_slimit.Size = new global::System.Drawing.Size(100, 23);
			this.textBox_slimit.TabIndex = 4;
			this.textBox_cnlimit.Location = new global::System.Drawing.Point(301, 57);
			this.textBox_cnlimit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_cnlimit.Name = "textBox_cnlimit";
			this.textBox_cnlimit.ReadOnly = true;
			this.textBox_cnlimit.Size = new global::System.Drawing.Size(100, 23);
			this.textBox_cnlimit.TabIndex = 4;
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(30, 29);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(47, 15);
			this.label6.TabIndex = 1;
			this.label6.Text = "% Limit";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(227, 29);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(70, 15);
			this.label7.TabIndex = 1;
			this.label7.Text = "Count Limit";
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(21, 61);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(56, 15);
			this.label8.TabIndex = 1;
			this.label8.Text = "Site Limit";
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(201, 61);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(96, 15);
			this.label9.TabIndex = 1;
			this.label9.Text = "Countinual Limit";
			this.textBox_aplimit.Location = new global::System.Drawing.Point(86, 24);
			this.textBox_aplimit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_aplimit.Name = "textBox_aplimit";
			this.textBox_aplimit.ReadOnly = true;
			this.textBox_aplimit.Size = new global::System.Drawing.Size(100, 23);
			this.textBox_aplimit.TabIndex = 4;
			this.textBox_aclimit.Location = new global::System.Drawing.Point(303, 24);
			this.textBox_aclimit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_aclimit.Name = "textBox_aclimit";
			this.textBox_aclimit.ReadOnly = true;
			this.textBox_aclimit.Size = new global::System.Drawing.Size(100, 23);
			this.textBox_aclimit.TabIndex = 4;
			this.textBox_aslimit.Location = new global::System.Drawing.Point(86, 57);
			this.textBox_aslimit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_aslimit.Name = "textBox_aslimit";
			this.textBox_aslimit.ReadOnly = true;
			this.textBox_aslimit.Size = new global::System.Drawing.Size(100, 23);
			this.textBox_aslimit.TabIndex = 4;
			this.textBox_acnlimit.Location = new global::System.Drawing.Point(303, 58);
			this.textBox_acnlimit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_acnlimit.Name = "textBox_acnlimit";
			this.textBox_acnlimit.ReadOnly = true;
			this.textBox_acnlimit.Size = new global::System.Drawing.Size(100, 23);
			this.textBox_acnlimit.TabIndex = 4;
			this.textBox_basecount.Location = new global::System.Drawing.Point(175, 28);
			this.textBox_basecount.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_basecount.Name = "textBox_basecount";
			this.textBox_basecount.Size = new global::System.Drawing.Size(158, 23);
			this.textBox_basecount.TabIndex = 4;
			this.textBox_basepercent.Location = new global::System.Drawing.Point(175, 62);
			this.textBox_basepercent.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_basepercent.Name = "textBox_basepercent";
			this.textBox_basepercent.Size = new global::System.Drawing.Size(158, 23);
			this.textBox_basepercent.TabIndex = 4;
			this.textBox_basesitecount.Location = new global::System.Drawing.Point(175, 96);
			this.textBox_basesitecount.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_basesitecount.Name = "textBox_basesitecount";
			this.textBox_basesitecount.Size = new global::System.Drawing.Size(158, 23);
			this.textBox_basesitecount.TabIndex = 4;
			this.textBox_bins.Location = new global::System.Drawing.Point(64, 52);
			this.textBox_bins.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_bins.Name = "textBox_bins";
			this.textBox_bins.ReadOnly = true;
			this.textBox_bins.Size = new global::System.Drawing.Size(354, 23);
			this.textBox_bins.TabIndex = 4;
			this.textBox_statusid.Location = new global::System.Drawing.Point(157, 61);
			this.textBox_statusid.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_statusid.Name = "textBox_statusid";
			this.textBox_statusid.ReadOnly = true;
			this.textBox_statusid.Size = new global::System.Drawing.Size(204, 23);
			this.textBox_statusid.TabIndex = 6;
			this.button_addstatusid.Location = new global::System.Drawing.Point(157, 95);
			this.button_addstatusid.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_addstatusid.Name = "button_addstatusid";
			this.button_addstatusid.Size = new global::System.Drawing.Size(59, 29);
			this.button_addstatusid.TabIndex = 7;
			this.button_addstatusid.Text = "<< Add";
			this.button_addstatusid.UseVisualStyleBackColor = true;
			this.button_addstatusid.Click += new global::System.EventHandler(this.button_addstatusid_Click);
			this.button_edit.Location = new global::System.Drawing.Point(505, 11);
			this.button_edit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_edit.Name = "button_edit";
			this.button_edit.Size = new global::System.Drawing.Size(75, 29);
			this.button_edit.TabIndex = 8;
			this.button_edit.Text = "EDIT";
			this.button_edit.UseVisualStyleBackColor = true;
			this.button_edit.Click += new global::System.EventHandler(this.button_edit_Click);
			this.button_save.Enabled = false;
			this.button_save.Location = new global::System.Drawing.Point(698, 11);
			this.button_save.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_save.Name = "button_save";
			this.button_save.Size = new global::System.Drawing.Size(75, 29);
			this.button_save.TabIndex = 8;
			this.button_save.Text = "SAVE";
			this.button_save.UseVisualStyleBackColor = true;
			this.button_save.Click += new global::System.EventHandler(this.button_save_Click);
			this.button_cancle.Enabled = false;
			this.button_cancle.Location = new global::System.Drawing.Point(779, 11);
			this.button_cancle.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_cancle.Name = "button_cancle";
			this.button_cancle.Size = new global::System.Drawing.Size(75, 29);
			this.button_cancle.TabIndex = 8;
			this.button_cancle.Text = "CANCEL";
			this.button_cancle.UseVisualStyleBackColor = true;
			this.button_cancle.Click += new global::System.EventHandler(this.button_cancle_Click);
			this.groupBox1.Controls.Add(this.textBox_bslimit);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.textBox_plimit);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBox_climit);
			this.groupBox1.Controls.Add(this.textBox_slimit);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBox_cnlimit);
			this.groupBox1.Location = new global::System.Drawing.Point(17, 86);
			this.groupBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Size = new global::System.Drawing.Size(417, 123);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "STOP Limit";
			this.groupBox2.Controls.Add(this.textBox_abslimit);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.textBox_aplimit);
			this.groupBox2.Controls.Add(this.textBox_aclimit);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.textBox_aslimit);
			this.groupBox2.Controls.Add(this.textBox_acnlimit);
			this.groupBox2.Location = new global::System.Drawing.Point(440, 86);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Size = new global::System.Drawing.Size(417, 123);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "ALARM Limit";
			this.groupBox3.Controls.Add(this.textBox_basecount);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.textBox_basepercent);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.textBox_basesitecount);
			this.groupBox3.Location = new global::System.Drawing.Point(13, 217);
			this.groupBox3.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox3.Size = new global::System.Drawing.Size(417, 136);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Base Limit";
			this.groupBox4.Controls.Add(this.button_delStatus);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.comboBox_OPT);
			this.groupBox4.Controls.Add(this.textBox_statusid);
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Controls.Add(this.comboBox_statusid);
			this.groupBox4.Controls.Add(this.button_addstatusid);
			this.groupBox4.Location = new global::System.Drawing.Point(440, 217);
			this.groupBox4.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Size = new global::System.Drawing.Size(417, 136);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Filter info";
			this.button_delStatus.Location = new global::System.Drawing.Point(216, 95);
			this.button_delStatus.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_delStatus.Name = "button_delStatus";
			this.button_delStatus.Size = new global::System.Drawing.Size(59, 29);
			this.button_delStatus.TabIndex = 8;
			this.button_delStatus.Text = "DEL >>";
			this.button_delStatus.UseVisualStyleBackColor = true;
			this.button_delStatus.Click += new global::System.EventHandler(this.button_delStatus_Click);
			this.button_Close.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.button_Close.Location = new global::System.Drawing.Point(585, 11);
			this.button_Close.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_Close.Name = "button_Close";
			this.button_Close.Size = new global::System.Drawing.Size(77, 29);
			this.button_Close.TabIndex = 13;
			this.button_Close.Text = "CLOSE";
			this.button_Close.UseVisualStyleBackColor = true;
			this.button_Close.Click += new global::System.EventHandler(this.button_Close_Click);
			this.panel_grid.AutoScroll = true;
			this.panel_grid.Controls.Add(this.grid_sbls);
			this.panel_grid.Location = new global::System.Drawing.Point(12, 407);
			this.panel_grid.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel_grid.Name = "panel_grid";
			this.panel_grid.Size = new global::System.Drawing.Size(850, 301);
			this.panel_grid.TabIndex = 14;
			this.button_bulkInsert.Location = new global::System.Drawing.Point(318, 11);
			this.button_bulkInsert.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_bulkInsert.Name = "button_bulkInsert";
			this.button_bulkInsert.Size = new global::System.Drawing.Size(100, 29);
			this.button_bulkInsert.TabIndex = 15;
			this.button_bulkInsert.Text = "Bulk Insert";
			this.button_bulkInsert.UseVisualStyleBackColor = true;
			this.button_bulkInsert.Click += new global::System.EventHandler(this.button_bulkInsert_Click);
			this.button_NEW.Location = new global::System.Drawing.Point(424, 11);
			this.button_NEW.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_NEW.Name = "button_NEW";
			this.button_NEW.Size = new global::System.Drawing.Size(75, 29);
			this.button_NEW.TabIndex = 16;
			this.button_NEW.Text = "NEW";
			this.button_NEW.UseVisualStyleBackColor = true;
			this.button_NEW.Click += new global::System.EventHandler(this.button_NEW_Click);
			this.label_mode.AutoSize = true;
			this.label_mode.Font = new global::System.Drawing.Font("굴림", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.label_mode.Location = new global::System.Drawing.Point(15, 18);
			this.label_mode.Name = "label_mode";
			this.label_mode.Size = new global::System.Drawing.Size(68, 12);
			this.label_mode.TabIndex = 17;
			this.label_mode.Text = "View SBL";
			this.button_delete.Enabled = false;
			this.button_delete.Location = new global::System.Drawing.Point(13, 361);
			this.button_delete.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_delete.Name = "button_delete";
			this.button_delete.Size = new global::System.Drawing.Size(110, 29);
			this.button_delete.TabIndex = 18;
			this.button_delete.Text = "Delete";
			this.button_delete.UseVisualStyleBackColor = true;
			this.button_delete.Click += new global::System.EventHandler(this.button_delete_Click);
			this.openFileDialog_csv.DefaultExt = "*.csv";
			this.openFileDialog_csv.FileName = "rules.csv";
			this.button_Export.Location = new global::System.Drawing.Point(129, 361);
			this.button_Export.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_Export.Name = "button_Export";
			this.button_Export.Size = new global::System.Drawing.Size(123, 29);
			this.button_Export.TabIndex = 19;
			this.button_Export.Text = "Export";
			this.button_Export.UseVisualStyleBackColor = true;
			this.button_Export.Click += new global::System.EventHandler(this.button_Export_Click);
			this.saveFileDialog_csv.DefaultExt = "csv";
			this.saveFileDialog_csv.Filter = "CSV|*.csv";
			this.textBox_bslimit.Location = new global::System.Drawing.Point(86, 88);
			this.textBox_bslimit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_bslimit.Name = "textBox_bslimit";
			this.textBox_bslimit.ReadOnly = true;
			this.textBox_bslimit.Size = new global::System.Drawing.Size(100, 23);
			this.textBox_bslimit.TabIndex = 6;
			this.label15.AutoSize = true;
			this.label15.Location = new global::System.Drawing.Point(3, 91);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(76, 15);
			this.label15.TabIndex = 5;
			this.label15.Text = "Bin Site Limit";
			this.textBox_abslimit.Location = new global::System.Drawing.Point(86, 88);
			this.textBox_abslimit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_abslimit.Name = "textBox_abslimit";
			this.textBox_abslimit.ReadOnly = true;
			this.textBox_abslimit.Size = new global::System.Drawing.Size(100, 23);
			this.textBox_abslimit.TabIndex = 8;
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(1, 91);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(76, 15);
			this.label16.TabIndex = 7;
			this.label16.Text = "Bin Site Limit";
			base.AcceptButton = this.button_edit;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.CancelButton = this.button_Close;
			base.ClientSize = new global::System.Drawing.Size(884, 721);
			base.Controls.Add(this.button_Export);
			base.Controls.Add(this.button_delete);
			base.Controls.Add(this.label_mode);
			base.Controls.Add(this.button_NEW);
			base.Controls.Add(this.button_bulkInsert);
			base.Controls.Add(this.panel_grid);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.button_Close);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.button_cancle);
			base.Controls.Add(this.button_save);
			base.Controls.Add(this.button_edit);
			base.Controls.Add(this.textBox_bins);
			base.Controls.Add(this.checkBox_fwaferid);
			base.Controls.Add(this.checkBox_ispass);
			base.Controls.Add(this.label1);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "RULESBLBINView";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "RULESBLBINView";
			base.Load += new global::System.EventHandler(this.RULESBLBINView_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.panel_grid.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400007C RID: 124
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400007D RID: 125
		private global::SourceGrid.Grid grid_sbls;

		// Token: 0x0400007E RID: 126
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400007F RID: 127
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.ComboBox comboBox_OPT;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.ComboBox comboBox_statusid;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.CheckBox checkBox_ispass;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.CheckBox checkBox_fwaferid;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.Label label14;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.TextBox textBox_plimit;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.TextBox textBox_climit;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.TextBox textBox_slimit;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.TextBox textBox_cnlimit;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.TextBox textBox_aplimit;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.TextBox textBox_aclimit;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.TextBox textBox_aslimit;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.TextBox textBox_acnlimit;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.TextBox textBox_basecount;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.TextBox textBox_basepercent;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.TextBox textBox_basesitecount;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.TextBox textBox_bins;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.TextBox textBox_statusid;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Button button_addstatusid;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.Button button_edit;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.Button button_save;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.Button button_cancle;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.Button button_Close;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.Panel panel_grid;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.Button button_bulkInsert;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.Button button_NEW;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.Label label_mode;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Button button_delete;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.OpenFileDialog openFileDialog_csv;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.Button button_delStatus;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.Button button_Export;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog_csv;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.TextBox textBox_bslimit;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.Label label15;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.TextBox textBox_abslimit;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.Label label16;
	}
}
