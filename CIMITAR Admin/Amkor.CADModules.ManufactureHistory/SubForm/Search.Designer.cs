namespace Amkor.CADModules.ManufactureHistory.SubForm
{
	// Token: 0x02000011 RID: 17
	public partial class Search : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x06000064 RID: 100 RVA: 0x00007CBC File Offset: 0x00005EBC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00007CF4 File Offset: 0x00005EF4
		private void InitializeComponent()
		{
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel19 = new global::System.Windows.Forms.Panel();
			this.listBoxShift = new global::System.Windows.Forms.ListBox();
			this.panel20 = new global::System.Windows.Forms.Panel();
			this.label7 = new global::System.Windows.Forms.Label();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.listBoxOperation = new global::System.Windows.Forms.ListBox();
			this.panel14 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.grid5 = new global::SourceGrid.Grid();
			this.listBoxDevice = new global::System.Windows.Forms.ListBox();
			this.panel15 = new global::System.Windows.Forms.Panel();
			this.label6 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.listBoxCustList = new global::System.Windows.Forms.ListBox();
			this.panel13 = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.listBoxEquipment = new global::System.Windows.Forms.ListBox();
			this.panel12 = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.listBoxModel = new global::System.Windows.Forms.ListBox();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.listboxCategory = new global::System.Windows.Forms.ListBox();
			this.panel10 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.grid_history = new global::SourceGrid.Grid();
			this.pnSubIdex = new global::System.Windows.Forms.Panel();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.panel23 = new global::System.Windows.Forms.Panel();
			this.cbShift = new global::System.Windows.Forms.ComboBox();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label15 = new global::System.Windows.Forms.Label();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.panel_Operation = new global::System.Windows.Forms.Panel();
			this.cbOperation = new global::System.Windows.Forms.ComboBox();
			this.panel26 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.panel_Device = new global::System.Windows.Forms.Panel();
			this.cbDevice = new global::System.Windows.Forms.ComboBox();
			this.panel28 = new global::System.Windows.Forms.Panel();
			this.label14 = new global::System.Windows.Forms.Label();
			this.panel_Customer = new global::System.Windows.Forms.Panel();
			this.cbCustomer = new global::System.Windows.Forms.ComboBox();
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.label11 = new global::System.Windows.Forms.Label();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.panel_Equipment = new global::System.Windows.Forms.Panel();
			this.cbEquipment = new global::System.Windows.Forms.ComboBox();
			this.panel22 = new global::System.Windows.Forms.Panel();
			this.label9 = new global::System.Windows.Forms.Label();
			this.panel_Model = new global::System.Windows.Forms.Panel();
			this.cbModel = new global::System.Windows.Forms.ComboBox();
			this.panel21 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.groupBox_Export = new global::System.Windows.Forms.GroupBox();
			this.btnExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.btnSearch = new global::System.Windows.Forms.PictureBox();
			this.panel17 = new global::System.Windows.Forms.Panel();
			this.tbKeyword = new global::System.Windows.Forms.TextBox();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.panel16 = new global::System.Windows.Forms.Panel();
			this.dtEndDate = new global::System.Windows.Forms.DateTimePicker();
			this.label10 = new global::System.Windows.Forms.Label();
			this.dtStartDate = new global::System.Windows.Forms.DateTimePicker();
			this.label12 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel19.SuspendLayout();
			this.panel20.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panel8.SuspendLayout();
			this.grid5.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnSubIdex.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panel23.SuspendLayout();
			this.panel25.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel_Operation.SuspendLayout();
			this.panel26.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel_Device.SuspendLayout();
			this.panel28.SuspendLayout();
			this.panel_Customer.SuspendLayout();
			this.panel24.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel_Equipment.SuspendLayout();
			this.panel22.SuspendLayout();
			this.panel_Model.SuspendLayout();
			this.panel21.SuspendLayout();
			this.panel9.SuspendLayout();
			this.groupBox_Export.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnExcel).BeginInit();
			this.groupBox4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).BeginInit();
			this.panel17.SuspendLayout();
			this.panel16.SuspendLayout();
			base.SuspendLayout();
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.panel19);
			this.panel1.Controls.Add(this.panel7);
			this.panel1.Controls.Add(this.panel8);
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(253, 742);
			this.panel1.TabIndex = 0;
			this.panel19.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel19.Controls.Add(this.listBoxShift);
			this.panel19.Controls.Add(this.panel20);
			this.panel19.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel19.Location = new global::System.Drawing.Point(0, 727);
			this.panel19.Name = "panel19";
			this.panel19.Size = new global::System.Drawing.Size(236, 118);
			this.panel19.TabIndex = 10;
			this.listBoxShift.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listBoxShift.FormattingEnabled = true;
			this.listBoxShift.ItemHeight = 12;
			this.listBoxShift.Items.AddRange(new object[]
			{
				"(All)",
				"DAY",
				"SWING",
				"NIGHT"
			});
			this.listBoxShift.Location = new global::System.Drawing.Point(0, 24);
			this.listBoxShift.Name = "listBoxShift";
			this.listBoxShift.Size = new global::System.Drawing.Size(234, 92);
			this.listBoxShift.TabIndex = 8;
			this.panel20.BackColor = global::System.Drawing.Color.SkyBlue;
			this.panel20.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel20.Controls.Add(this.label7);
			this.panel20.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel20.Location = new global::System.Drawing.Point(0, 0);
			this.panel20.Name = "panel20";
			this.panel20.Size = new global::System.Drawing.Size(234, 24);
			this.panel20.TabIndex = 3;
			this.label7.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label7.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new global::System.Drawing.Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(232, 22);
			this.label7.TabIndex = 0;
			this.label7.Text = "Shift";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel7.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.listBoxOperation);
			this.panel7.Controls.Add(this.panel14);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new global::System.Drawing.Point(0, 609);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(236, 118);
			this.panel7.TabIndex = 5;
			this.listBoxOperation.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listBoxOperation.FormattingEnabled = true;
			this.listBoxOperation.ItemHeight = 12;
			this.listBoxOperation.Location = new global::System.Drawing.Point(0, 24);
			this.listBoxOperation.Name = "listBoxOperation";
			this.listBoxOperation.Size = new global::System.Drawing.Size(234, 92);
			this.listBoxOperation.TabIndex = 8;
			this.panel14.BackColor = global::System.Drawing.Color.SkyBlue;
			this.panel14.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel14.Controls.Add(this.label5);
			this.panel14.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel14.Location = new global::System.Drawing.Point(0, 0);
			this.panel14.Name = "panel14";
			this.panel14.Size = new global::System.Drawing.Size(234, 24);
			this.panel14.TabIndex = 3;
			this.label5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label5.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(232, 22);
			this.label5.TabIndex = 0;
			this.label5.Text = "Operation";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel8.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel8.Controls.Add(this.grid5);
			this.panel8.Controls.Add(this.panel15);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new global::System.Drawing.Point(0, 491);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(236, 118);
			this.panel8.TabIndex = 6;
			this.grid5.AutoSize = true;
			this.grid5.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid5.Controls.Add(this.listBoxDevice);
			this.grid5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid5.EnableSort = true;
			this.grid5.FixedRows = 1;
			this.grid5.Font = new global::System.Drawing.Font("굴림체", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.grid5.Location = new global::System.Drawing.Point(0, 24);
			this.grid5.Name = "grid5";
			this.grid5.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid5.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid5.Size = new global::System.Drawing.Size(234, 92);
			this.grid5.TabIndex = 20;
			this.grid5.TabStop = true;
			this.grid5.ToolTipText = "";
			this.listBoxDevice.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listBoxDevice.FormattingEnabled = true;
			this.listBoxDevice.ItemHeight = 12;
			this.listBoxDevice.Location = new global::System.Drawing.Point(0, 0);
			this.listBoxDevice.Name = "listBoxDevice";
			this.listBoxDevice.Size = new global::System.Drawing.Size(232, 90);
			this.listBoxDevice.TabIndex = 7;
			this.panel15.BackColor = global::System.Drawing.Color.SkyBlue;
			this.panel15.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel15.Controls.Add(this.label6);
			this.panel15.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel15.Location = new global::System.Drawing.Point(0, 0);
			this.panel15.Name = "panel15";
			this.panel15.Size = new global::System.Drawing.Size(234, 24);
			this.panel15.TabIndex = 3;
			this.label6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label6.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(0, 0);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(232, 22);
			this.label6.TabIndex = 0;
			this.label6.Text = "Device";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel6.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.listBoxCustList);
			this.panel6.Controls.Add(this.panel13);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new global::System.Drawing.Point(0, 373);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(236, 118);
			this.panel6.TabIndex = 4;
			this.listBoxCustList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listBoxCustList.FormattingEnabled = true;
			this.listBoxCustList.ItemHeight = 12;
			this.listBoxCustList.Location = new global::System.Drawing.Point(0, 24);
			this.listBoxCustList.Name = "listBoxCustList";
			this.listBoxCustList.Size = new global::System.Drawing.Size(234, 92);
			this.listBoxCustList.TabIndex = 6;
			this.listBoxCustList.SelectedIndexChanged += new global::System.EventHandler(this.listboxCategory_SelectedIndexChanged);
			this.panel13.BackColor = global::System.Drawing.Color.SkyBlue;
			this.panel13.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel13.Controls.Add(this.label4);
			this.panel13.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel13.Location = new global::System.Drawing.Point(0, 0);
			this.panel13.Name = "panel13";
			this.panel13.Size = new global::System.Drawing.Size(234, 24);
			this.panel13.TabIndex = 3;
			this.label4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label4.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(232, 22);
			this.label4.TabIndex = 0;
			this.label4.Text = "Customer";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel5.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.listBoxEquipment);
			this.panel5.Controls.Add(this.panel12);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(0, 255);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(236, 118);
			this.panel5.TabIndex = 3;
			this.listBoxEquipment.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listBoxEquipment.FormattingEnabled = true;
			this.listBoxEquipment.ItemHeight = 12;
			this.listBoxEquipment.Location = new global::System.Drawing.Point(0, 24);
			this.listBoxEquipment.Name = "listBoxEquipment";
			this.listBoxEquipment.Size = new global::System.Drawing.Size(234, 92);
			this.listBoxEquipment.TabIndex = 5;
			this.listBoxEquipment.SelectedIndexChanged += new global::System.EventHandler(this.listboxCategory_SelectedIndexChanged);
			this.panel12.BackColor = global::System.Drawing.Color.SkyBlue;
			this.panel12.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel12.Controls.Add(this.label3);
			this.panel12.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel12.Location = new global::System.Drawing.Point(0, 0);
			this.panel12.Name = "panel12";
			this.panel12.Size = new global::System.Drawing.Size(234, 24);
			this.panel12.TabIndex = 3;
			this.label3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(232, 22);
			this.label3.TabIndex = 0;
			this.label3.Text = "M/C#";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel4.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.listBoxModel);
			this.panel4.Controls.Add(this.panel11);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 137);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(236, 118);
			this.panel4.TabIndex = 2;
			this.listBoxModel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listBoxModel.FormattingEnabled = true;
			this.listBoxModel.ItemHeight = 12;
			this.listBoxModel.Location = new global::System.Drawing.Point(0, 24);
			this.listBoxModel.Name = "listBoxModel";
			this.listBoxModel.Size = new global::System.Drawing.Size(234, 92);
			this.listBoxModel.TabIndex = 4;
			this.listBoxModel.SelectedIndexChanged += new global::System.EventHandler(this.listboxCategory_SelectedIndexChanged);
			this.panel11.BackColor = global::System.Drawing.Color.SkyBlue;
			this.panel11.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel11.Controls.Add(this.label2);
			this.panel11.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel11.Location = new global::System.Drawing.Point(0, 0);
			this.panel11.Name = "panel11";
			this.panel11.Size = new global::System.Drawing.Size(234, 24);
			this.panel11.TabIndex = 3;
			this.label2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(232, 22);
			this.label2.TabIndex = 0;
			this.label2.Text = "Model";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel3.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.listboxCategory);
			this.panel3.Controls.Add(this.panel10);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(236, 137);
			this.panel3.TabIndex = 1;
			this.listboxCategory.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listboxCategory.FormattingEnabled = true;
			this.listboxCategory.ItemHeight = 12;
			this.listboxCategory.Location = new global::System.Drawing.Point(0, 24);
			this.listboxCategory.Name = "listboxCategory";
			this.listboxCategory.Size = new global::System.Drawing.Size(234, 111);
			this.listboxCategory.TabIndex = 3;
			this.listboxCategory.SelectedIndexChanged += new global::System.EventHandler(this.listboxCategory_SelectedIndexChanged);
			this.panel10.BackColor = global::System.Drawing.Color.SkyBlue;
			this.panel10.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel10.Controls.Add(this.label1);
			this.panel10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new global::System.Drawing.Point(0, 0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new global::System.Drawing.Size(234, 24);
			this.panel10.TabIndex = 2;
			this.label1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(232, 22);
			this.label1.TabIndex = 0;
			this.label1.Text = "Category";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.grid_history);
			this.panel2.Controls.Add(this.pnSubIdex);
			this.panel2.Controls.Add(this.panel9);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(253, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(985, 742);
			this.panel2.TabIndex = 1;
			this.grid_history.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_history.EnableSort = true;
			this.grid_history.FixedColumns = 2;
			this.grid_history.FixedRows = 1;
			this.grid_history.Font = new global::System.Drawing.Font("굴림체", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.grid_history.Location = new global::System.Drawing.Point(0, 119);
			this.grid_history.Name = "grid_history";
			this.grid_history.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_history.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_history.Size = new global::System.Drawing.Size(983, 621);
			this.grid_history.TabIndex = 17;
			this.grid_history.TabStop = true;
			this.grid_history.ToolTipText = "";
			this.grid_history.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_history_MouseClick);
			this.pnSubIdex.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnSubIdex.Controls.Add(this.groupBox5);
			this.pnSubIdex.Controls.Add(this.groupBox3);
			this.pnSubIdex.Controls.Add(this.groupBox2);
			this.pnSubIdex.Controls.Add(this.groupBox1);
			this.pnSubIdex.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnSubIdex.Location = new global::System.Drawing.Point(0, 57);
			this.pnSubIdex.Name = "pnSubIdex";
			this.pnSubIdex.Size = new global::System.Drawing.Size(983, 62);
			this.pnSubIdex.TabIndex = 18;
			this.pnSubIdex.Visible = false;
			this.groupBox5.AutoSize = true;
			this.groupBox5.Controls.Add(this.panel23);
			this.groupBox5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox5.Location = new global::System.Drawing.Point(727, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(151, 60);
			this.groupBox5.TabIndex = 24;
			this.groupBox5.TabStop = false;
			this.panel23.Controls.Add(this.cbShift);
			this.panel23.Controls.Add(this.panel25);
			this.panel23.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel23.Location = new global::System.Drawing.Point(3, 17);
			this.panel23.Name = "panel23";
			this.panel23.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel23.Size = new global::System.Drawing.Size(145, 40);
			this.panel23.TabIndex = 19;
			this.cbShift.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbShift.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbShift.FormattingEnabled = true;
			this.cbShift.Location = new global::System.Drawing.Point(0, 15);
			this.cbShift.Name = "cbShift";
			this.cbShift.Size = new global::System.Drawing.Size(142, 20);
			this.cbShift.TabIndex = 3;
			this.cbShift.SelectedIndexChanged += new global::System.EventHandler(this.cbModel_SelectedIndexChanged);
			this.panel25.Controls.Add(this.label15);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel25.Location = new global::System.Drawing.Point(0, 0);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(142, 15);
			this.panel25.TabIndex = 17;
			this.label15.AutoSize = true;
			this.label15.BackColor = global::System.Drawing.Color.White;
			this.label15.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.label15.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.label15.ForeColor = global::System.Drawing.Color.Black;
			this.label15.Location = new global::System.Drawing.Point(0, 0);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(33, 16);
			this.label15.TabIndex = 6;
			this.label15.Text = "Shift";
			this.groupBox3.AutoSize = true;
			this.groupBox3.Controls.Add(this.panel_Operation);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox3.Location = new global::System.Drawing.Point(576, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(151, 60);
			this.groupBox3.TabIndex = 23;
			this.groupBox3.TabStop = false;
			this.panel_Operation.Controls.Add(this.cbOperation);
			this.panel_Operation.Controls.Add(this.panel26);
			this.panel_Operation.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel_Operation.Location = new global::System.Drawing.Point(3, 17);
			this.panel_Operation.Name = "panel_Operation";
			this.panel_Operation.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel_Operation.Size = new global::System.Drawing.Size(145, 40);
			this.panel_Operation.TabIndex = 19;
			this.cbOperation.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbOperation.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOperation.FormattingEnabled = true;
			this.cbOperation.Location = new global::System.Drawing.Point(0, 15);
			this.cbOperation.Name = "cbOperation";
			this.cbOperation.Size = new global::System.Drawing.Size(142, 20);
			this.cbOperation.TabIndex = 3;
			this.cbOperation.SelectedIndexChanged += new global::System.EventHandler(this.cbModel_SelectedIndexChanged);
			this.panel26.Controls.Add(this.label13);
			this.panel26.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel26.Location = new global::System.Drawing.Point(0, 0);
			this.panel26.Name = "panel26";
			this.panel26.Size = new global::System.Drawing.Size(142, 15);
			this.panel26.TabIndex = 17;
			this.label13.AutoSize = true;
			this.label13.BackColor = global::System.Drawing.Color.White;
			this.label13.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.label13.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.label13.ForeColor = global::System.Drawing.Color.Black;
			this.label13.Location = new global::System.Drawing.Point(0, 0);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(67, 16);
			this.label13.TabIndex = 6;
			this.label13.Text = "Operation";
			this.groupBox2.AutoSize = true;
			this.groupBox2.Controls.Add(this.panel_Device);
			this.groupBox2.Controls.Add(this.panel_Customer);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox2.Location = new global::System.Drawing.Point(280, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(296, 60);
			this.groupBox2.TabIndex = 22;
			this.groupBox2.TabStop = false;
			this.panel_Device.Controls.Add(this.cbDevice);
			this.panel_Device.Controls.Add(this.panel28);
			this.panel_Device.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel_Device.Location = new global::System.Drawing.Point(148, 17);
			this.panel_Device.Name = "panel_Device";
			this.panel_Device.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel_Device.Size = new global::System.Drawing.Size(145, 40);
			this.panel_Device.TabIndex = 20;
			this.cbDevice.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbDevice.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDevice.FormattingEnabled = true;
			this.cbDevice.Location = new global::System.Drawing.Point(0, 15);
			this.cbDevice.Name = "cbDevice";
			this.cbDevice.Size = new global::System.Drawing.Size(142, 20);
			this.cbDevice.TabIndex = 3;
			this.cbDevice.SelectedIndexChanged += new global::System.EventHandler(this.cbModel_SelectedIndexChanged);
			this.panel28.Controls.Add(this.label14);
			this.panel28.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel28.Location = new global::System.Drawing.Point(0, 0);
			this.panel28.Name = "panel28";
			this.panel28.Size = new global::System.Drawing.Size(142, 15);
			this.panel28.TabIndex = 17;
			this.label14.AutoSize = true;
			this.label14.BackColor = global::System.Drawing.Color.White;
			this.label14.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.label14.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.label14.ForeColor = global::System.Drawing.Color.Black;
			this.label14.Location = new global::System.Drawing.Point(0, 0);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(51, 16);
			this.label14.TabIndex = 6;
			this.label14.Text = "Device";
			this.panel_Customer.Controls.Add(this.cbCustomer);
			this.panel_Customer.Controls.Add(this.panel24);
			this.panel_Customer.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel_Customer.Location = new global::System.Drawing.Point(3, 17);
			this.panel_Customer.Name = "panel_Customer";
			this.panel_Customer.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel_Customer.Size = new global::System.Drawing.Size(145, 40);
			this.panel_Customer.TabIndex = 18;
			this.cbCustomer.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbCustomer.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCustomer.FormattingEnabled = true;
			this.cbCustomer.Location = new global::System.Drawing.Point(0, 15);
			this.cbCustomer.Name = "cbCustomer";
			this.cbCustomer.Size = new global::System.Drawing.Size(142, 20);
			this.cbCustomer.TabIndex = 3;
			this.cbCustomer.SelectedIndexChanged += new global::System.EventHandler(this.cbModel_SelectedIndexChanged);
			this.panel24.Controls.Add(this.label11);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(142, 15);
			this.panel24.TabIndex = 17;
			this.label11.AutoSize = true;
			this.label11.BackColor = global::System.Drawing.Color.White;
			this.label11.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.label11.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.label11.ForeColor = global::System.Drawing.Color.Black;
			this.label11.Location = new global::System.Drawing.Point(0, 0);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(65, 16);
			this.label11.TabIndex = 6;
			this.label11.Text = "Customer";
			this.groupBox1.AutoSize = true;
			this.groupBox1.Controls.Add(this.panel_Equipment);
			this.groupBox1.Controls.Add(this.panel_Model);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(280, 60);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.panel_Equipment.Controls.Add(this.cbEquipment);
			this.panel_Equipment.Controls.Add(this.panel22);
			this.panel_Equipment.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel_Equipment.Location = new global::System.Drawing.Point(132, 17);
			this.panel_Equipment.Name = "panel_Equipment";
			this.panel_Equipment.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel_Equipment.Size = new global::System.Drawing.Size(145, 40);
			this.panel_Equipment.TabIndex = 17;
			this.cbEquipment.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbEquipment.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEquipment.FormattingEnabled = true;
			this.cbEquipment.Location = new global::System.Drawing.Point(0, 15);
			this.cbEquipment.Name = "cbEquipment";
			this.cbEquipment.Size = new global::System.Drawing.Size(142, 20);
			this.cbEquipment.TabIndex = 3;
			this.cbEquipment.SelectedIndexChanged += new global::System.EventHandler(this.cbModel_SelectedIndexChanged);
			this.panel22.Controls.Add(this.label9);
			this.panel22.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel22.Location = new global::System.Drawing.Point(0, 0);
			this.panel22.Name = "panel22";
			this.panel22.Size = new global::System.Drawing.Size(142, 15);
			this.panel22.TabIndex = 17;
			this.label9.AutoSize = true;
			this.label9.BackColor = global::System.Drawing.Color.White;
			this.label9.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.label9.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.label9.ForeColor = global::System.Drawing.Color.Black;
			this.label9.Location = new global::System.Drawing.Point(0, 0);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(72, 16);
			this.label9.TabIndex = 6;
			this.label9.Text = "Equipment";
			this.panel_Model.Controls.Add(this.cbModel);
			this.panel_Model.Controls.Add(this.panel21);
			this.panel_Model.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel_Model.Location = new global::System.Drawing.Point(3, 17);
			this.panel_Model.Name = "panel_Model";
			this.panel_Model.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel_Model.Size = new global::System.Drawing.Size(129, 40);
			this.panel_Model.TabIndex = 16;
			this.cbModel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbModel.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModel.FormattingEnabled = true;
			this.cbModel.Location = new global::System.Drawing.Point(0, 15);
			this.cbModel.Name = "cbModel";
			this.cbModel.Size = new global::System.Drawing.Size(126, 20);
			this.cbModel.TabIndex = 2;
			this.cbModel.SelectedIndexChanged += new global::System.EventHandler(this.cbModel_SelectedIndexChanged);
			this.panel21.Controls.Add(this.label8);
			this.panel21.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel21.Location = new global::System.Drawing.Point(0, 0);
			this.panel21.Name = "panel21";
			this.panel21.Size = new global::System.Drawing.Size(126, 15);
			this.panel21.TabIndex = 16;
			this.label8.AutoSize = true;
			this.label8.BackColor = global::System.Drawing.Color.White;
			this.label8.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.label8.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label8.ForeColor = global::System.Drawing.Color.Black;
			this.label8.Location = new global::System.Drawing.Point(0, 0);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(46, 17);
			this.label8.TabIndex = 5;
			this.label8.Text = "Model";
			this.panel9.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel9.Controls.Add(this.groupBox_Export);
			this.panel9.Controls.Add(this.groupBox4);
			this.panel9.Controls.Add(this.panel17);
			this.panel9.Controls.Add(this.panel16);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new global::System.Drawing.Point(0, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(983, 57);
			this.panel9.TabIndex = 2;
			this.groupBox_Export.Controls.Add(this.btnExcel);
			this.groupBox_Export.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox_Export.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.groupBox_Export.Location = new global::System.Drawing.Point(740, 0);
			this.groupBox_Export.Name = "groupBox_Export";
			this.groupBox_Export.Size = new global::System.Drawing.Size(80, 55);
			this.groupBox_Export.TabIndex = 56;
			this.groupBox_Export.TabStop = false;
			this.groupBox_Export.Text = "Excel";
			this.btnExcel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnExcel.Image = global::Amkor.CADModules.ManufactureHistory.Properties.Resources.SaveExcel;
			this.btnExcel.Location = new global::System.Drawing.Point(23, 16);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.Size = new global::System.Drawing.Size(36, 31);
			this.btnExcel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.btnExcel.TabIndex = 10;
			this.btnExcel.TabStop = false;
			this.btnExcel.Click += new global::System.EventHandler(this.btnExcel_Click);
			this.groupBox4.Controls.Add(this.btnSearch);
			this.groupBox4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox4.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.groupBox4.Location = new global::System.Drawing.Point(661, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(79, 55);
			this.groupBox4.TabIndex = 54;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Search";
			this.btnSearch.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnSearch.Image = global::Amkor.CADModules.ManufactureHistory.Properties.Resources.TableSearch;
			this.btnSearch.Location = new global::System.Drawing.Point(23, 16);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new global::System.Drawing.Size(36, 31);
			this.btnSearch.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.btnSearch.TabIndex = 10;
			this.btnSearch.TabStop = false;
			this.btnSearch.Click += new global::System.EventHandler(this.btnSearch_Click);
			this.btnSearch.MouseEnter += new global::System.EventHandler(this.btnSearch_MouseEnter);
			this.btnSearch.MouseLeave += new global::System.EventHandler(this.btnSearch_MouseLeave);
			this.panel17.Controls.Add(this.tbKeyword);
			this.panel17.Controls.Add(this.panel18);
			this.panel17.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel17.Location = new global::System.Drawing.Point(329, 0);
			this.panel17.Name = "panel17";
			this.panel17.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel17.Size = new global::System.Drawing.Size(332, 55);
			this.panel17.TabIndex = 53;
			this.tbKeyword.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tbKeyword.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbKeyword.Location = new global::System.Drawing.Point(0, 16);
			this.tbKeyword.Name = "tbKeyword";
			this.tbKeyword.Size = new global::System.Drawing.Size(329, 26);
			this.tbKeyword.TabIndex = 1;
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel18.Location = new global::System.Drawing.Point(0, 0);
			this.panel18.Name = "panel18";
			this.panel18.Size = new global::System.Drawing.Size(329, 16);
			this.panel18.TabIndex = 2;
			this.panel16.Controls.Add(this.dtEndDate);
			this.panel16.Controls.Add(this.label10);
			this.panel16.Controls.Add(this.dtStartDate);
			this.panel16.Controls.Add(this.label12);
			this.panel16.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel16.Location = new global::System.Drawing.Point(0, 0);
			this.panel16.Name = "panel16";
			this.panel16.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel16.Size = new global::System.Drawing.Size(329, 55);
			this.panel16.TabIndex = 52;
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
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(1238, 742);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Search";
			this.Text = "History";
			base.Shown += new global::System.EventHandler(this.History_Shown);
			this.panel1.ResumeLayout(false);
			this.panel19.ResumeLayout(false);
			this.panel20.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.grid5.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnSubIdex.ResumeLayout(false);
			this.pnSubIdex.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.panel23.ResumeLayout(false);
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.panel_Operation.ResumeLayout(false);
			this.panel26.ResumeLayout(false);
			this.panel26.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.panel_Device.ResumeLayout(false);
			this.panel28.ResumeLayout(false);
			this.panel28.PerformLayout();
			this.panel_Customer.ResumeLayout(false);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.panel_Equipment.ResumeLayout(false);
			this.panel22.ResumeLayout(false);
			this.panel22.PerformLayout();
			this.panel_Model.ResumeLayout(false);
			this.panel21.ResumeLayout(false);
			this.panel21.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.groupBox_Export.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnExcel).EndInit();
			this.groupBox4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).EndInit();
			this.panel17.ResumeLayout(false);
			this.panel17.PerformLayout();
			this.panel16.ResumeLayout(false);
			this.panel16.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400003A RID: 58
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.Panel panel14;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.Panel panel13;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000046 RID: 70
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.Panel panel12;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.Panel panel11;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x04000051 RID: 81
		private global::SourceGrid.Grid grid5;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.ListBox listboxCategory;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.ListBox listBoxModel;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.ListBox listBoxEquipment;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.ListBox listBoxCustList;

		// Token: 0x04000056 RID: 86
		private global::System.Windows.Forms.ListBox listBoxDevice;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.ListBox listBoxOperation;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.GroupBox groupBox_Export;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.PictureBox btnExcel;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.PictureBox btnSearch;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.Panel panel17;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.TextBox tbKeyword;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.Panel panel16;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.DateTimePicker dtEndDate;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.DateTimePicker dtStartDate;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000064 RID: 100
		private global::SourceGrid.Grid grid_history;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.Panel pnSubIdex;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.Panel panel_Device;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.ComboBox cbDevice;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.Panel panel28;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.Label label14;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.Panel panel_Operation;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.ComboBox cbOperation;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.Panel panel26;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.Panel panel_Customer;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.ComboBox cbCustomer;

		// Token: 0x04000070 RID: 112
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.Panel panel_Equipment;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.ComboBox cbEquipment;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.Panel panel22;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.Panel panel_Model;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.ComboBox cbModel;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.Panel panel21;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400007C RID: 124
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400007D RID: 125
		private global::System.Windows.Forms.Panel panel19;

		// Token: 0x0400007E RID: 126
		private global::System.Windows.Forms.ListBox listBoxShift;

		// Token: 0x0400007F RID: 127
		private global::System.Windows.Forms.Panel panel20;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.Panel panel23;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.ComboBox cbShift;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.Label label15;
	}
}
