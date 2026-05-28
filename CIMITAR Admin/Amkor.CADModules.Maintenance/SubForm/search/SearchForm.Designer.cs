namespace Amkor.CADModules.Maintenance.SubForm.search
{
	// Token: 0x02000012 RID: 18
	public partial class SearchForm : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x0600015D RID: 349 RVA: 0x0003FE0C File Offset: 0x0003E00C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0003FE44 File Offset: 0x0003E044
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.panel99 = new global::System.Windows.Forms.Panel();
			this.cbWebView = new global::System.Windows.Forms.CheckBox();
			this.pnExport = new global::System.Windows.Forms.Panel();
			this.groupBox_Export = new global::System.Windows.Forms.GroupBox();
			this.btnExcel = new global::System.Windows.Forms.PictureBox();
			this.pnanel88 = new global::System.Windows.Forms.Panel();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.btnSearch = new global::System.Windows.Forms.PictureBox();
			this.panel13 = new global::System.Windows.Forms.Panel();
			this.tbContents = new global::System.Windows.Forms.TextBox();
			this.panel16 = new global::System.Windows.Forms.Panel();
			this.panel20 = new global::System.Windows.Forms.Panel();
			this.cbIndex = new global::System.Windows.Forms.ComboBox();
			this.panel27 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.pnFactor = new global::System.Windows.Forms.Panel();
			this.cbFactor = new global::System.Windows.Forms.ComboBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.cbCase = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.cbModel = new global::System.Windows.Forms.ComboBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.cbCategory = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.cbType = new global::System.Windows.Forms.ComboBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.panel15 = new global::System.Windows.Forms.Panel();
			this.dtEndDate = new global::System.Windows.Forms.DateTimePicker();
			this.label10 = new global::System.Windows.Forms.Label();
			this.dtStartDate = new global::System.Windows.Forms.DateTimePicker();
			this.label12 = new global::System.Windows.Forms.Label();
			this.panel14 = new global::System.Windows.Forms.Panel();
			this.cbPlant = new global::System.Windows.Forms.ComboBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.pnWebView = new global::System.Windows.Forms.Panel();
			this.web_Viewer = new global::System.Windows.Forms.WebBrowser();
			this.btn_Close = new global::System.Windows.Forms.Button();
			this.tbGridType = new global::System.Windows.Forms.TabControl();
			this.tpStatus = new global::System.Windows.Forms.TabPage();
			this.tpPMStatus = new global::System.Windows.Forms.TabPage();
			this.groupBox2.SuspendLayout();
			this.panel99.SuspendLayout();
			this.pnExport.SuspendLayout();
			this.groupBox_Export.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnExcel).BeginInit();
			this.panel7.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).BeginInit();
			this.panel13.SuspendLayout();
			this.panel20.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnFactor.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel18.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel14.SuspendLayout();
			this.pnWebView.SuspendLayout();
			this.tbGridType.SuspendLayout();
			base.SuspendLayout();
			this.groupBox2.Controls.Add(this.panel99);
			this.groupBox2.Controls.Add(this.panel2);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox2.ForeColor = global::System.Drawing.Color.Black;
			this.groupBox2.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.groupBox2.Size = new global::System.Drawing.Size(1420, 119);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.panel99.AutoSize = true;
			this.panel99.Controls.Add(this.cbWebView);
			this.panel99.Controls.Add(this.pnExport);
			this.panel99.Controls.Add(this.pnanel88);
			this.panel99.Controls.Add(this.panel7);
			this.panel99.Controls.Add(this.panel13);
			this.panel99.Controls.Add(this.panel20);
			this.panel99.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel99.Location = new global::System.Drawing.Point(3, 62);
			this.panel99.Margin = new global::System.Windows.Forms.Padding(3, 3, 5, 3);
			this.panel99.Name = "panel99";
			this.panel99.Padding = new global::System.Windows.Forms.Padding(0, 0, 5, 2);
			this.panel99.Size = new global::System.Drawing.Size(1414, 54);
			this.panel99.TabIndex = 16;
			this.cbWebView.AutoSize = true;
			this.cbWebView.CheckAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.cbWebView.Checked = true;
			this.cbWebView.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.cbWebView.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.cbWebView.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.cbWebView.Location = new global::System.Drawing.Point(889, 0);
			this.cbWebView.Name = "cbWebView";
			this.cbWebView.Size = new global::System.Drawing.Size(85, 52);
			this.cbWebView.TabIndex = 23;
			this.cbWebView.Text = "Web View";
			this.cbWebView.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.cbWebView.UseVisualStyleBackColor = true;
			this.pnExport.Controls.Add(this.groupBox_Export);
			this.pnExport.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnExport.Location = new global::System.Drawing.Point(804, 0);
			this.pnExport.Name = "pnExport";
			this.pnExport.Size = new global::System.Drawing.Size(85, 52);
			this.pnExport.TabIndex = 22;
			this.pnExport.Visible = false;
			this.groupBox_Export.Controls.Add(this.btnExcel);
			this.groupBox_Export.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox_Export.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.groupBox_Export.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox_Export.Name = "groupBox_Export";
			this.groupBox_Export.Size = new global::System.Drawing.Size(85, 52);
			this.groupBox_Export.TabIndex = 16;
			this.groupBox_Export.TabStop = false;
			this.groupBox_Export.Text = "Excel";
			this.btnExcel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnExcel.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.SaveExcel;
			this.btnExcel.Location = new global::System.Drawing.Point(23, 16);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.Size = new global::System.Drawing.Size(36, 31);
			this.btnExcel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.btnExcel.TabIndex = 10;
			this.btnExcel.TabStop = false;
			this.btnExcel.Click += new global::System.EventHandler(this.btnExcel_Click);
			this.btnExcel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.btnExcel_MouseDown);
			this.btnExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.btnExcel_MouseUp);
			this.pnanel88.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnanel88.Location = new global::System.Drawing.Point(800, 0);
			this.pnanel88.Name = "pnanel88";
			this.pnanel88.Padding = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.pnanel88.Size = new global::System.Drawing.Size(4, 52);
			this.pnanel88.TabIndex = 21;
			this.panel7.Controls.Add(this.groupBox4);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel7.Location = new global::System.Drawing.Point(715, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(85, 52);
			this.panel7.TabIndex = 18;
			this.groupBox4.Controls.Add(this.btnSearch);
			this.groupBox4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.groupBox4.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(85, 52);
			this.groupBox4.TabIndex = 17;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Search";
			this.btnSearch.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnSearch.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.TableSearch;
			this.btnSearch.Location = new global::System.Drawing.Point(23, 16);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new global::System.Drawing.Size(36, 31);
			this.btnSearch.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.btnSearch.TabIndex = 10;
			this.btnSearch.TabStop = false;
			this.btnSearch.Click += new global::System.EventHandler(this.btnSearch_Click);
			this.btnSearch.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.btnSearch_MouseDown);
			this.btnSearch.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.btnSearch_MouseUp);
			this.panel13.Controls.Add(this.tbContents);
			this.panel13.Controls.Add(this.panel16);
			this.panel13.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel13.Location = new global::System.Drawing.Point(145, 0);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel13.Size = new global::System.Drawing.Size(570, 52);
			this.panel13.TabIndex = 20;
			this.tbContents.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tbContents.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbContents.Location = new global::System.Drawing.Point(0, 17);
			this.tbContents.Name = "tbContents";
			this.tbContents.Size = new global::System.Drawing.Size(567, 26);
			this.tbContents.TabIndex = 1;
			this.tbContents.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tbContents_KeyPress);
			this.panel16.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel16.Location = new global::System.Drawing.Point(0, 0);
			this.panel16.Name = "panel16";
			this.panel16.Size = new global::System.Drawing.Size(567, 17);
			this.panel16.TabIndex = 2;
			this.panel20.Controls.Add(this.cbIndex);
			this.panel20.Controls.Add(this.panel27);
			this.panel20.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel20.Location = new global::System.Drawing.Point(0, 0);
			this.panel20.Name = "panel20";
			this.panel20.Size = new global::System.Drawing.Size(145, 52);
			this.panel20.TabIndex = 24;
			this.cbIndex.BackColor = global::System.Drawing.SystemColors.Window;
			this.cbIndex.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbIndex.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbIndex.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.cbIndex.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.cbIndex.Items.AddRange(new object[]
			{
				"CONTENTS",
				"REPORT INFO'"
			});
			this.cbIndex.Location = new global::System.Drawing.Point(0, 17);
			this.cbIndex.Name = "cbIndex";
			this.cbIndex.Size = new global::System.Drawing.Size(145, 25);
			this.cbIndex.TabIndex = 9;
			this.panel27.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel27.Location = new global::System.Drawing.Point(0, 0);
			this.panel27.Name = "panel27";
			this.panel27.Size = new global::System.Drawing.Size(145, 17);
			this.panel27.TabIndex = 3;
			this.panel2.Controls.Add(this.pnFactor);
			this.panel2.Controls.Add(this.panel9);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.panel18);
			this.panel2.Controls.Add(this.panel15);
			this.panel2.Controls.Add(this.panel14);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(3, 15);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1414, 47);
			this.panel2.TabIndex = 15;
			this.pnFactor.Controls.Add(this.cbFactor);
			this.pnFactor.Controls.Add(this.label8);
			this.pnFactor.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnFactor.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.pnFactor.Location = new global::System.Drawing.Point(1072, 0);
			this.pnFactor.Name = "pnFactor";
			this.pnFactor.Size = new global::System.Drawing.Size(318, 47);
			this.pnFactor.TabIndex = 12;
			this.cbFactor.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbFactor.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFactor.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.cbFactor.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.cbFactor.Location = new global::System.Drawing.Point(0, 17);
			this.cbFactor.Name = "cbFactor";
			this.cbFactor.Size = new global::System.Drawing.Size(318, 25);
			this.cbFactor.TabIndex = 15;
			this.label8.AutoSize = true;
			this.label8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label8.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label8.Location = new global::System.Drawing.Point(0, 0);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(97, 17);
			this.label8.TabIndex = 14;
			this.label8.Text = "Problem Factor";
			this.panel9.Controls.Add(this.cbCase);
			this.panel9.Controls.Add(this.label1);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel9.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.panel9.Location = new global::System.Drawing.Point(950, 0);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel9.Size = new global::System.Drawing.Size(122, 47);
			this.panel9.TabIndex = 11;
			this.cbCase.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbCase.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCase.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.cbCase.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.cbCase.Location = new global::System.Drawing.Point(0, 17);
			this.cbCase.Name = "cbCase";
			this.cbCase.Size = new global::System.Drawing.Size(119, 25);
			this.cbCase.TabIndex = 13;
			this.cbCase.SelectedIndexChanged += new global::System.EventHandler(this.SelectedIndexChanged);
			this.label1.AutoSize = true;
			this.label1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label1.Location = new global::System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(36, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "Case";
			this.panel4.Controls.Add(this.cbModel);
			this.panel4.Controls.Add(this.label7);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel4.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.panel4.Location = new global::System.Drawing.Point(731, 0);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel4.Size = new global::System.Drawing.Size(219, 47);
			this.panel4.TabIndex = 10;
			this.panel4.Visible = false;
			this.cbModel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbModel.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModel.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.cbModel.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.cbModel.Location = new global::System.Drawing.Point(0, 17);
			this.cbModel.Name = "cbModel";
			this.cbModel.Size = new global::System.Drawing.Size(216, 25);
			this.cbModel.TabIndex = 12;
			this.cbModel.SelectedIndexChanged += new global::System.EventHandler(this.SelectedIndexChanged);
			this.label7.AutoSize = true;
			this.label7.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label7.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label7.Location = new global::System.Drawing.Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(46, 17);
			this.label7.TabIndex = 11;
			this.label7.Text = "Model";
			this.panel3.Controls.Add(this.cbCategory);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel3.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.panel3.Location = new global::System.Drawing.Point(531, 0);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new global::System.Windows.Forms.Padding(3, 0, 3, 0);
			this.panel3.Size = new global::System.Drawing.Size(200, 47);
			this.panel3.TabIndex = 9;
			this.cbCategory.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbCategory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCategory.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.cbCategory.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.cbCategory.Location = new global::System.Drawing.Point(3, 17);
			this.cbCategory.Name = "cbCategory";
			this.cbCategory.Size = new global::System.Drawing.Size(194, 25);
			this.cbCategory.TabIndex = 8;
			this.cbCategory.SelectedIndexChanged += new global::System.EventHandler(this.SelectedIndexChanged);
			this.label2.AutoSize = true;
			this.label2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label2.Location = new global::System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(61, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "Category";
			this.panel18.Controls.Add(this.cbType);
			this.panel18.Controls.Add(this.label14);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel18.Location = new global::System.Drawing.Point(398, 0);
			this.panel18.Name = "panel18";
			this.panel18.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel18.Size = new global::System.Drawing.Size(133, 47);
			this.panel18.TabIndex = 52;
			this.cbType.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbType.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.cbType.FormattingEnabled = true;
			this.cbType.Items.AddRange(new object[]
			{
				"Maint",
				"PM"
			});
			this.cbType.Location = new global::System.Drawing.Point(0, 17);
			this.cbType.Name = "cbType";
			this.cbType.Size = new global::System.Drawing.Size(130, 25);
			this.cbType.TabIndex = 0;
			this.cbType.SelectedIndexChanged += new global::System.EventHandler(this.combo_Index_SelectedIndexChanged);
			this.label14.AutoSize = true;
			this.label14.BackColor = global::System.Drawing.Color.White;
			this.label14.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label14.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label14.ForeColor = global::System.Drawing.Color.Black;
			this.label14.Location = new global::System.Drawing.Point(0, 0);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(36, 17);
			this.label14.TabIndex = 9;
			this.label14.Text = "Type";
			this.panel15.Controls.Add(this.dtEndDate);
			this.panel15.Controls.Add(this.label10);
			this.panel15.Controls.Add(this.dtStartDate);
			this.panel15.Controls.Add(this.label12);
			this.panel15.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel15.Location = new global::System.Drawing.Point(69, 0);
			this.panel15.Name = "panel15";
			this.panel15.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel15.Size = new global::System.Drawing.Size(329, 47);
			this.panel15.TabIndex = 51;
			this.dtEndDate.CalendarFont = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.dtEndDate.CustomFormat = "yyyy-MM-dd";
			this.dtEndDate.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.dtEndDate.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.dtEndDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtEndDate.Location = new global::System.Drawing.Point(167, 17);
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.Size = new global::System.Drawing.Size(155, 25);
			this.dtEndDate.TabIndex = 51;
			this.dtEndDate.TabStop = false;
			this.label10.AutoSize = true;
			this.label10.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.label10.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label10.Location = new global::System.Drawing.Point(150, 17);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(17, 17);
			this.label10.TabIndex = 52;
			this.label10.Text = "~";
			this.dtStartDate.CalendarFont = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.dtStartDate.CustomFormat = "yyyy-MM-dd";
			this.dtStartDate.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.dtStartDate.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.dtStartDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtStartDate.Location = new global::System.Drawing.Point(0, 17);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new global::System.Drawing.Size(150, 25);
			this.dtStartDate.TabIndex = 50;
			this.dtStartDate.TabStop = false;
			this.dtStartDate.Value = new global::System.DateTime(2020, 9, 25, 0, 0, 0, 0);
			this.label12.AutoSize = true;
			this.label12.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label12.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label12.Location = new global::System.Drawing.Point(0, 0);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(84, 17);
			this.label12.TabIndex = 47;
			this.label12.Text = "Select Period";
			this.label12.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.panel14.Controls.Add(this.cbPlant);
			this.panel14.Controls.Add(this.label9);
			this.panel14.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel14.Location = new global::System.Drawing.Point(0, 0);
			this.panel14.Name = "panel14";
			this.panel14.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel14.Size = new global::System.Drawing.Size(69, 47);
			this.panel14.TabIndex = 14;
			this.cbPlant.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbPlant.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPlant.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.cbPlant.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.cbPlant.Location = new global::System.Drawing.Point(0, 17);
			this.cbPlant.Margin = new global::System.Windows.Forms.Padding(3, 3, 10, 3);
			this.cbPlant.Name = "cbPlant";
			this.cbPlant.Size = new global::System.Drawing.Size(66, 25);
			this.cbPlant.TabIndex = 10;
			this.cbPlant.SelectedIndexChanged += new global::System.EventHandler(this.SelectedIndexChanged);
			this.label9.AutoSize = true;
			this.label9.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label9.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label9.Location = new global::System.Drawing.Point(0, 0);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(50, 17);
			this.label9.TabIndex = 11;
			this.label9.Text = "Factory";
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(61, 4);
			this.pnWebView.Controls.Add(this.web_Viewer);
			this.pnWebView.Controls.Add(this.btn_Close);
			this.pnWebView.Location = new global::System.Drawing.Point(517, 294);
			this.pnWebView.Name = "pnWebView";
			this.pnWebView.Size = new global::System.Drawing.Size(200, 100);
			this.pnWebView.TabIndex = 73;
			this.pnWebView.Visible = false;
			this.web_Viewer.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.web_Viewer.Location = new global::System.Drawing.Point(0, 0);
			this.web_Viewer.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.web_Viewer.Name = "web_Viewer";
			this.web_Viewer.Size = new global::System.Drawing.Size(200, 61);
			this.web_Viewer.TabIndex = 0;
			this.btn_Close.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.btn_Close.Font = new global::System.Drawing.Font("Segoe UI Symbol", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btn_Close.Location = new global::System.Drawing.Point(0, 61);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new global::System.Drawing.Size(200, 39);
			this.btn_Close.TabIndex = 1;
			this.btn_Close.Text = "Close";
			this.btn_Close.UseVisualStyleBackColor = true;
			this.btn_Close.Click += new global::System.EventHandler(this.btn_Close_Click);
			this.tbGridType.Controls.Add(this.tpStatus);
			this.tbGridType.Controls.Add(this.tpPMStatus);
			this.tbGridType.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbGridType.Location = new global::System.Drawing.Point(0, 119);
			this.tbGridType.Name = "tbGridType";
			this.tbGridType.SelectedIndex = 0;
			this.tbGridType.Size = new global::System.Drawing.Size(1420, 569);
			this.tbGridType.TabIndex = 74;
			this.tpStatus.Location = new global::System.Drawing.Point(4, 22);
			this.tpStatus.Name = "tpStatus";
			this.tpStatus.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpStatus.Size = new global::System.Drawing.Size(1412, 543);
			this.tpStatus.TabIndex = 0;
			this.tpStatus.Text = "Maint' Status";
			this.tpStatus.UseVisualStyleBackColor = true;
			this.tpPMStatus.Location = new global::System.Drawing.Point(4, 22);
			this.tpPMStatus.Name = "tpPMStatus";
			this.tpPMStatus.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpPMStatus.Size = new global::System.Drawing.Size(1412, 543);
			this.tpPMStatus.TabIndex = 1;
			this.tpPMStatus.Text = "PM Status";
			this.tpPMStatus.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1420, 688);
			base.Controls.Add(this.pnWebView);
			base.Controls.Add(this.tbGridType);
			base.Controls.Add(this.groupBox2);
			this.ForeColor = global::System.Drawing.Color.Black;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "SearchForm";
			this.Text = "SearchForm";
			base.Shown += new global::System.EventHandler(this.SearchForm_Shown);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel99.ResumeLayout(false);
			this.panel99.PerformLayout();
			this.pnExport.ResumeLayout(false);
			this.groupBox_Export.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnExcel).EndInit();
			this.panel7.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).EndInit();
			this.panel13.ResumeLayout(false);
			this.panel13.PerformLayout();
			this.panel20.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnFactor.ResumeLayout(false);
			this.pnFactor.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel18.ResumeLayout(false);
			this.panel18.PerformLayout();
			this.panel15.ResumeLayout(false);
			this.panel15.PerformLayout();
			this.panel14.ResumeLayout(false);
			this.panel14.PerformLayout();
			this.pnWebView.ResumeLayout(false);
			this.tbGridType.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040002C6 RID: 710
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002C7 RID: 711
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040002C8 RID: 712
		private global::System.Windows.Forms.ComboBox cbCategory;

		// Token: 0x040002C9 RID: 713
		private global::System.Windows.Forms.ComboBox cbPlant;

		// Token: 0x040002CA RID: 714
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040002CB RID: 715
		private global::System.Windows.Forms.ComboBox cbModel;

		// Token: 0x040002CC RID: 716
		private global::System.Windows.Forms.PictureBox btnExcel;

		// Token: 0x040002CD RID: 717
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x040002CE RID: 718
		private global::System.Windows.Forms.PictureBox btnSearch;

		// Token: 0x040002CF RID: 719
		private global::System.Windows.Forms.Panel panel99;

		// Token: 0x040002D0 RID: 720
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040002D1 RID: 721
		private global::System.Windows.Forms.Panel pnFactor;

		// Token: 0x040002D2 RID: 722
		private global::System.Windows.Forms.ComboBox cbFactor;

		// Token: 0x040002D3 RID: 723
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040002D4 RID: 724
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x040002D5 RID: 725
		private global::System.Windows.Forms.ComboBox cbCase;

		// Token: 0x040002D6 RID: 726
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002D7 RID: 727
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040002D8 RID: 728
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040002D9 RID: 729
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002DA RID: 730
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x040002DB RID: 731
		private global::System.Windows.Forms.Panel panel14;

		// Token: 0x040002DC RID: 732
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040002DD RID: 733
		private global::System.Windows.Forms.TextBox tbContents;

		// Token: 0x040002DE RID: 734
		private global::System.Windows.Forms.Panel panel13;

		// Token: 0x040002DF RID: 735
		private global::System.Windows.Forms.Panel pnanel88;

		// Token: 0x040002E0 RID: 736
		private global::System.Windows.Forms.Panel pnExport;

		// Token: 0x040002E1 RID: 737
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x040002E2 RID: 738
		private global::System.Windows.Forms.GroupBox groupBox_Export;

		// Token: 0x040002E3 RID: 739
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x040002E4 RID: 740
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x040002E5 RID: 741
		private global::System.Windows.Forms.DateTimePicker dtEndDate;

		// Token: 0x040002E6 RID: 742
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040002E7 RID: 743
		private global::System.Windows.Forms.DateTimePicker dtStartDate;

		// Token: 0x040002E8 RID: 744
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040002E9 RID: 745
		private global::System.Windows.Forms.Panel panel16;

		// Token: 0x040002EA RID: 746
		private global::System.Windows.Forms.CheckBox cbWebView;

		// Token: 0x040002EB RID: 747
		private global::System.Windows.Forms.Panel pnWebView;

		// Token: 0x040002EC RID: 748
		private global::System.Windows.Forms.WebBrowser web_Viewer;

		// Token: 0x040002ED RID: 749
		private global::System.Windows.Forms.Button btn_Close;

		// Token: 0x040002EE RID: 750
		private global::System.Windows.Forms.TabControl tbGridType;

		// Token: 0x040002EF RID: 751
		private global::System.Windows.Forms.TabPage tpStatus;

		// Token: 0x040002F0 RID: 752
		private global::System.Windows.Forms.TabPage tpPMStatus;

		// Token: 0x040002F1 RID: 753
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x040002F2 RID: 754
		private global::System.Windows.Forms.ComboBox cbType;

		// Token: 0x040002F3 RID: 755
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040002F4 RID: 756
		private global::System.Windows.Forms.Panel panel20;

		// Token: 0x040002F5 RID: 757
		private global::System.Windows.Forms.Panel panel27;

		// Token: 0x040002F6 RID: 758
		private global::System.Windows.Forms.ComboBox cbIndex;
	}
}
