namespace Amkor.CADModules.HccSTReportModule
{
	// Token: 0x02000003 RID: 3
	public partial class HccSTReportModule : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00007DE4 File Offset: 0x00005FE4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00007E04 File Offset: 0x00006004
		private void InitializeComponent()
		{
			this.l_subject = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.group_Index = new global::System.Windows.Forms.GroupBox();
			this.tb_Barcode = new global::System.Windows.Forms.TextBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.pb_Search = new global::System.Windows.Forms.PictureBox();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.combo_PlantCode = new global::System.Windows.Forms.ComboBox();
			this.combo_Ownership = new global::System.Windows.Forms.ComboBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.dtPicker_RecvDate = new global::System.Windows.Forms.DateTimePicker();
			this.combo_HwType = new global::System.Windows.Forms.ComboBox();
			this.combo_DataType = new global::System.Windows.Forms.ComboBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.l_DevFamily = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.tabCtrl_Report = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.tb_GobmAssetNo = new global::System.Windows.Forms.TextBox();
			this.dtPicker_LastStUpDate = new global::System.Windows.Forms.DateTimePicker();
			this.tb_Period = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.tb_STDivName = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.tb_STDivHwId = new global::System.Windows.Forms.TextBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.tb_OsatCodId = new global::System.Windows.Forms.TextBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.tb_OsatCodSN = new global::System.Windows.Forms.TextBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.tb_CondStatus = new global::System.Windows.Forms.TextBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.tb_TransTrackingNo = new global::System.Windows.Forms.TextBox();
			this.label26 = new global::System.Windows.Forms.Label();
			this.tb_IncommChkReportNo = new global::System.Windows.Forms.TextBox();
			this.label28 = new global::System.Windows.Forms.Label();
			this.tb_Remark = new global::System.Windows.Forms.TextBox();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.pb_Update = new global::System.Windows.Forms.PictureBox();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.combo_Factory = new global::System.Windows.Forms.ComboBox();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.pb_Modify = new global::System.Windows.Forms.PictureBox();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.pb_Export = new global::System.Windows.Forms.PictureBox();
			this.groupBox9 = new global::System.Windows.Forms.GroupBox();
			this.pb_FileSearch = new global::System.Windows.Forms.PictureBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.panel1.SuspendLayout();
			this.group_Index.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Search).BeginInit();
			this.groupBox3.SuspendLayout();
			this.tabCtrl_Report.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Update).BeginInit();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Modify).BeginInit();
			this.groupBox8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Export).BeginInit();
			this.groupBox9.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_FileSearch).BeginInit();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.l_subject.AutoSize = true;
			this.l_subject.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l_subject.Location = new global::System.Drawing.Point(12, 8);
			this.l_subject.Name = "l_subject";
			this.l_subject.Size = new global::System.Drawing.Size(161, 21);
			this.l_subject.TabIndex = 21;
			this.l_subject.Text = "ST Hardware Report";
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 661);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1098, 40);
			this.panel1.TabIndex = 22;
			this.label2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(376, 11);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(368, 15);
			this.label2.TabIndex = 0;
			this.label2.Text = "Copyright ⓒ 2019 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.group_Index.Controls.Add(this.tb_Barcode);
			this.group_Index.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.group_Index.Location = new global::System.Drawing.Point(322, 39);
			this.group_Index.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.group_Index.Name = "group_Index";
			this.group_Index.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.group_Index.Size = new global::System.Drawing.Size(185, 72);
			this.group_Index.TabIndex = 23;
			this.group_Index.TabStop = false;
			this.group_Index.Text = "Hardware Barcode(Location)";
			this.tb_Barcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tb_Barcode.Location = new global::System.Drawing.Point(21, 32);
			this.tb_Barcode.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_Barcode.Name = "tb_Barcode";
			this.tb_Barcode.Size = new global::System.Drawing.Size(143, 23);
			this.tb_Barcode.TabIndex = 12;
			this.tb_Barcode.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tb_Barcode_KeyPress);
			this.groupBox1.Controls.Add(this.pb_Search);
			this.groupBox1.Location = new global::System.Drawing.Point(513, 39);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(74, 72);
			this.groupBox1.TabIndex = 26;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			this.pb_Search.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Search.Image = global::Amkor.CADModules.HccSTReportModule.Properties.Resources.TableSearch;
			this.pb_Search.InitialImage = global::Amkor.CADModules.HccSTReportModule.Properties.Resources.TableSearch;
			this.pb_Search.Location = new global::System.Drawing.Point(21, 24);
			this.pb_Search.Name = "pb_Search";
			this.pb_Search.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Search.TabIndex = 0;
			this.pb_Search.TabStop = false;
			this.pb_Search.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_Search_MouseDown);
			this.pb_Search.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Search_MouseUp);
			this.groupBox3.Controls.Add(this.combo_PlantCode);
			this.groupBox3.Controls.Add(this.combo_Ownership);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.dtPicker_RecvDate);
			this.groupBox3.Controls.Add(this.combo_DataType);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.l_DevFamily);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox3.Location = new global::System.Drawing.Point(16, 120);
			this.groupBox3.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox3.Size = new global::System.Drawing.Size(1066, 85);
			this.groupBox3.TabIndex = 27;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Hardware Information";
			this.combo_PlantCode.BackColor = global::System.Drawing.Color.Gainsboro;
			this.combo_PlantCode.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_PlantCode.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.combo_PlantCode.FormattingEnabled = true;
			this.combo_PlantCode.Location = new global::System.Drawing.Point(623, 51);
			this.combo_PlantCode.Name = "combo_PlantCode";
			this.combo_PlantCode.Size = new global::System.Drawing.Size(105, 23);
			this.combo_PlantCode.TabIndex = 106;
			this.combo_Ownership.BackColor = global::System.Drawing.Color.Gainsboro;
			this.combo_Ownership.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Ownership.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.combo_Ownership.FormattingEnabled = true;
			this.combo_Ownership.Location = new global::System.Drawing.Point(623, 22);
			this.combo_Ownership.Name = "combo_Ownership";
			this.combo_Ownership.Size = new global::System.Drawing.Size(105, 23);
			this.combo_Ownership.TabIndex = 15;
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(541, 25);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(70, 15);
			this.label16.TabIndex = 103;
			this.label16.Text = "Ownership :";
			this.dtPicker_RecvDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtPicker_RecvDate.Location = new global::System.Drawing.Point(123, 22);
			this.dtPicker_RecvDate.Name = "dtPicker_RecvDate";
			this.dtPicker_RecvDate.Size = new global::System.Drawing.Size(103, 23);
			this.dtPicker_RecvDate.TabIndex = 13;
			this.combo_HwType.BackColor = global::System.Drawing.Color.Gainsboro;
			this.combo_HwType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_HwType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.combo_HwType.FormattingEnabled = true;
			this.combo_HwType.Location = new global::System.Drawing.Point(23, 32);
			this.combo_HwType.Name = "combo_HwType";
			this.combo_HwType.Size = new global::System.Drawing.Size(105, 23);
			this.combo_HwType.TabIndex = 12;
			this.combo_HwType.SelectionChangeCommitted += new global::System.EventHandler(this.combo_HwType_SelectionChangeCommitted);
			this.combo_DataType.BackColor = global::System.Drawing.Color.Gainsboro;
			this.combo_DataType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_DataType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.combo_DataType.FormattingEnabled = true;
			this.combo_DataType.Location = new global::System.Drawing.Point(375, 22);
			this.combo_DataType.Name = "combo_DataType";
			this.combo_DataType.Size = new global::System.Drawing.Size(105, 23);
			this.combo_DataType.TabIndex = 14;
			this.combo_DataType.SelectedIndexChanged += new global::System.EventHandler(this.combo_DataType_SelectedIndexChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(541, 54);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(71, 15);
			this.label6.TabIndex = 105;
			this.label6.Text = "Plant Code :";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(293, 25);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(65, 15);
			this.label5.TabIndex = 102;
			this.label5.Text = "Data Type :";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(23, 25);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(87, 15);
			this.label7.TabIndex = 101;
			this.label7.Text = "Received Date :";
			this.l_DevFamily.AutoSize = true;
			this.l_DevFamily.Location = new global::System.Drawing.Point(127, 54);
			this.l_DevFamily.Name = "l_DevFamily";
			this.l_DevFamily.Size = new global::System.Drawing.Size(363, 15);
			this.l_DevFamily.TabIndex = 16;
			this.l_DevFamily.Text = "V775 H  |  1825-0476  |  1825-0502  |  1825-0507  |  1822-3464  |  THOR";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(23, 54);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(86, 15);
			this.label4.TabIndex = 104;
			this.label4.Text = "Device Family :";
			this.tabCtrl_Report.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabCtrl_Report.Controls.Add(this.tabPage1);
			this.tabCtrl_Report.Controls.Add(this.tabPage2);
			this.tabCtrl_Report.Location = new global::System.Drawing.Point(16, 363);
			this.tabCtrl_Report.Name = "tabCtrl_Report";
			this.tabCtrl_Report.SelectedIndex = 0;
			this.tabCtrl_Report.Size = new global::System.Drawing.Size(1070, 290);
			this.tabCtrl_Report.TabIndex = 30;
			this.tabCtrl_Report.SelectedIndexChanged += new global::System.EventHandler(this.tabCtrl_Report_SelectedIndexChanged);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(1062, 262);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage2.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(1062, 262);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.tb_GobmAssetNo);
			this.groupBox4.Controls.Add(this.dtPicker_LastStUpDate);
			this.groupBox4.Controls.Add(this.tb_Period);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.tb_STDivName);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.tb_STDivHwId);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.tb_OsatCodId);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.tb_OsatCodSN);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.tb_CondStatus);
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Controls.Add(this.label15);
			this.groupBox4.Controls.Add(this.tb_TransTrackingNo);
			this.groupBox4.Controls.Add(this.label26);
			this.groupBox4.Controls.Add(this.tb_IncommChkReportNo);
			this.groupBox4.Controls.Add(this.label28);
			this.groupBox4.Controls.Add(this.tb_Remark);
			this.groupBox4.Location = new global::System.Drawing.Point(16, 212);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(1066, 145);
			this.groupBox4.TabIndex = 29;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Common Information";
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(13, 108);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(95, 15);
			this.label8.TabIndex = 37;
			this.label8.Text = "GOBM Asset No.";
			this.tb_GobmAssetNo.Location = new global::System.Drawing.Point(139, 105);
			this.tb_GobmAssetNo.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_GobmAssetNo.Name = "tb_GobmAssetNo";
			this.tb_GobmAssetNo.Size = new global::System.Drawing.Size(200, 23);
			this.tb_GobmAssetNo.TabIndex = 23;
			this.dtPicker_LastStUpDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtPicker_LastStUpDate.Location = new global::System.Drawing.Point(490, 105);
			this.dtPicker_LastStUpDate.Name = "dtPicker_LastStUpDate";
			this.dtPicker_LastStUpDate.Size = new global::System.Drawing.Size(200, 23);
			this.dtPicker_LastStUpDate.TabIndex = 32;
			this.tb_Period.Location = new global::System.Drawing.Point(139, 24);
			this.tb_Period.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_Period.Name = "tb_Period";
			this.tb_Period.Size = new global::System.Drawing.Size(200, 23);
			this.tb_Period.TabIndex = 14;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(13, 27);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(41, 15);
			this.label3.TabIndex = 13;
			this.label3.Text = "Period";
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(13, 54);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(100, 15);
			this.label9.TabIndex = 19;
			this.label9.Text = "ST Division Name";
			this.tb_STDivName.Location = new global::System.Drawing.Point(139, 51);
			this.tb_STDivName.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_STDivName.Name = "tb_STDivName";
			this.tb_STDivName.Size = new global::System.Drawing.Size(200, 23);
			this.tb_STDivName.TabIndex = 20;
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(13, 81);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(102, 15);
			this.label10.TabIndex = 21;
			this.label10.Text = "ST Division HW ID";
			this.tb_STDivHwId.Location = new global::System.Drawing.Point(139, 78);
			this.tb_STDivHwId.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_STDivHwId.Name = "tb_STDivHwId";
			this.tb_STDivHwId.Size = new global::System.Drawing.Size(200, 23);
			this.tb_STDivHwId.TabIndex = 22;
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(364, 27);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(98, 15);
			this.label11.TabIndex = 23;
			this.label11.Text = "OSAT Codified ID";
			this.tb_OsatCodId.Location = new global::System.Drawing.Point(490, 24);
			this.tb_OsatCodId.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_OsatCodId.Name = "tb_OsatCodId";
			this.tb_OsatCodId.Size = new global::System.Drawing.Size(200, 23);
			this.tb_OsatCodId.TabIndex = 24;
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(364, 54);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(102, 15);
			this.label12.TabIndex = 25;
			this.label12.Text = "OSAT Codified SN";
			this.tb_OsatCodSN.BackColor = global::System.Drawing.Color.White;
			this.tb_OsatCodSN.Location = new global::System.Drawing.Point(490, 51);
			this.tb_OsatCodSN.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_OsatCodSN.Name = "tb_OsatCodSN";
			this.tb_OsatCodSN.Size = new global::System.Drawing.Size(200, 23);
			this.tb_OsatCodSN.TabIndex = 26;
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(364, 81);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(95, 15);
			this.label13.TabIndex = 27;
			this.label13.Text = "Condition Status";
			this.tb_CondStatus.Location = new global::System.Drawing.Point(490, 78);
			this.tb_CondStatus.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_CondStatus.Name = "tb_CondStatus";
			this.tb_CondStatus.Size = new global::System.Drawing.Size(200, 23);
			this.tb_CondStatus.TabIndex = 28;
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(364, 108);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(105, 15);
			this.label14.TabIndex = 29;
			this.label14.Text = "Last Status UpDate";
			this.label15.AutoSize = true;
			this.label15.Location = new global::System.Drawing.Point(718, 27);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(126, 15);
			this.label15.TabIndex = 31;
			this.label15.Text = "TransferInTracking No.";
			this.tb_TransTrackingNo.Location = new global::System.Drawing.Point(844, 24);
			this.tb_TransTrackingNo.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_TransTrackingNo.Name = "tb_TransTrackingNo";
			this.tb_TransTrackingNo.Size = new global::System.Drawing.Size(200, 23);
			this.tb_TransTrackingNo.TabIndex = 33;
			this.label26.AutoSize = true;
			this.label26.Location = new global::System.Drawing.Point(718, 54);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(123, 15);
			this.label26.TabIndex = 33;
			this.label26.Text = "Incom chk Report No.";
			this.tb_IncommChkReportNo.Location = new global::System.Drawing.Point(844, 51);
			this.tb_IncommChkReportNo.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_IncommChkReportNo.Name = "tb_IncommChkReportNo";
			this.tb_IncommChkReportNo.Size = new global::System.Drawing.Size(200, 23);
			this.tb_IncommChkReportNo.TabIndex = 34;
			this.label28.AutoSize = true;
			this.label28.Location = new global::System.Drawing.Point(718, 81);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(47, 15);
			this.label28.TabIndex = 35;
			this.label28.Text = "Remark";
			this.tb_Remark.Location = new global::System.Drawing.Point(844, 78);
			this.tb_Remark.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_Remark.Name = "tb_Remark";
			this.tb_Remark.Size = new global::System.Drawing.Size(200, 23);
			this.tb_Remark.TabIndex = 36;
			this.groupBox5.Controls.Add(this.pb_Update);
			this.groupBox5.Location = new global::System.Drawing.Point(593, 39);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(74, 72);
			this.groupBox5.TabIndex = 31;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Update";
			this.pb_Update.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Update.Image = global::Amkor.CADModules.HccSTReportModule.Properties.Resources.TableSave;
			this.pb_Update.InitialImage = global::Amkor.CADModules.HccSTReportModule.Properties.Resources.TableSave;
			this.pb_Update.Location = new global::System.Drawing.Point(21, 24);
			this.pb_Update.Name = "pb_Update";
			this.pb_Update.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Update.TabIndex = 0;
			this.pb_Update.TabStop = false;
			this.pb_Update.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_Update_MouseDown);
			this.pb_Update.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Update_MouseUp);
			this.groupBox6.Controls.Add(this.combo_Factory);
			this.groupBox6.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox6.Location = new global::System.Drawing.Point(16, 39);
			this.groupBox6.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox6.Size = new global::System.Drawing.Size(147, 72);
			this.groupBox6.TabIndex = 32;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Factory";
			this.combo_Factory.BackColor = global::System.Drawing.Color.Gainsboro;
			this.combo_Factory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Factory.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.combo_Factory.FormattingEnabled = true;
			this.combo_Factory.Location = new global::System.Drawing.Point(21, 32);
			this.combo_Factory.Name = "combo_Factory";
			this.combo_Factory.Size = new global::System.Drawing.Size(105, 23);
			this.combo_Factory.TabIndex = 13;
			this.combo_Factory.SelectionChangeCommitted += new global::System.EventHandler(this.combo_Factory_SelectionChangeCommitted);
			this.groupBox7.Controls.Add(this.pb_Modify);
			this.groupBox7.Location = new global::System.Drawing.Point(1008, 39);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(74, 72);
			this.groupBox7.TabIndex = 33;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Modify";
			this.pb_Modify.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Modify.Image = global::Amkor.CADModules.HccSTReportModule.Properties.Resources.VOS;
			this.pb_Modify.InitialImage = global::Amkor.CADModules.HccSTReportModule.Properties.Resources.VOS;
			this.pb_Modify.Location = new global::System.Drawing.Point(21, 24);
			this.pb_Modify.Name = "pb_Modify";
			this.pb_Modify.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Modify.TabIndex = 0;
			this.pb_Modify.TabStop = false;
			this.pb_Modify.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Modify_MouseUp);
			this.groupBox8.Controls.Add(this.pb_Export);
			this.groupBox8.Location = new global::System.Drawing.Point(673, 39);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(74, 72);
			this.groupBox8.TabIndex = 34;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Export";
			this.pb_Export.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Export.Image = global::Amkor.CADModules.HccSTReportModule.Properties.Resources.SaveExcel;
			this.pb_Export.InitialImage = global::Amkor.CADModules.HccSTReportModule.Properties.Resources.SaveExcel;
			this.pb_Export.Location = new global::System.Drawing.Point(21, 24);
			this.pb_Export.Name = "pb_Export";
			this.pb_Export.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Export.TabIndex = 0;
			this.pb_Export.TabStop = false;
			this.pb_Export.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_Export_MouseDown);
			this.pb_Export.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Export_MouseUp);
			this.groupBox9.Controls.Add(this.pb_FileSearch);
			this.groupBox9.Location = new global::System.Drawing.Point(928, 39);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new global::System.Drawing.Size(74, 72);
			this.groupBox9.TabIndex = 35;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Search";
			this.pb_FileSearch.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_FileSearch.Image = global::Amkor.CADModules.HccSTReportModule.Properties.Resources.FileOpen;
			this.pb_FileSearch.InitialImage = global::Amkor.CADModules.HccSTReportModule.Properties.Resources.FileOpen;
			this.pb_FileSearch.Location = new global::System.Drawing.Point(21, 24);
			this.pb_FileSearch.Name = "pb_FileSearch";
			this.pb_FileSearch.Size = new global::System.Drawing.Size(32, 33);
			this.pb_FileSearch.TabIndex = 0;
			this.pb_FileSearch.TabStop = false;
			this.pb_FileSearch.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_FileSearch_MouseDown);
			this.pb_FileSearch.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_FileSearch_MouseUp);
			this.groupBox2.Controls.Add(this.combo_HwType);
			this.groupBox2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox2.Location = new global::System.Drawing.Point(169, 39);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Size = new global::System.Drawing.Size(147, 72);
			this.groupBox2.TabIndex = 36;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Hardware Type";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1098, 701);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox9);
			base.Controls.Add(this.groupBox8);
			base.Controls.Add(this.groupBox7);
			base.Controls.Add(this.groupBox6);
			base.Controls.Add(this.groupBox5);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.tabCtrl_Report);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.group_Index);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.l_subject);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "HccSTReportModule";
			this.Text = "HccSTReport";
			base.Load += new global::System.EventHandler(this.HccSTReportModule_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.group_Index.ResumeLayout(false);
			this.group_Index.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_Search).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabCtrl_Report.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_Update).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_Modify).EndInit();
			this.groupBox8.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_Export).EndInit();
			this.groupBox9.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_FileSearch).EndInit();
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000038 RID: 56
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.Label l_subject;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.GroupBox group_Index;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.TextBox tb_Barcode;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.PictureBox pb_Search;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.Label l_DevFamily;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.TabControl tabCtrl_Report;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x04000046 RID: 70
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.ComboBox combo_DataType;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.TextBox tb_Period;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.TextBox tb_STDivName;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.TextBox tb_STDivHwId;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.TextBox tb_OsatCodId;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.TextBox tb_OsatCodSN;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000056 RID: 86
		private global::System.Windows.Forms.TextBox tb_CondStatus;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.Label label15;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.TextBox tb_TransTrackingNo;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.Label label26;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.TextBox tb_IncommChkReportNo;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.Label label28;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.TextBox tb_Remark;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.ComboBox combo_HwType;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.DateTimePicker dtPicker_LastStUpDate;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.DateTimePicker dtPicker_RecvDate;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.ComboBox combo_Ownership;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.PictureBox pb_Update;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.TextBox tb_GobmAssetNo;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.ComboBox combo_Factory;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.PictureBox pb_Modify;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.ComboBox combo_PlantCode;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.PictureBox pb_Export;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.GroupBox groupBox9;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.PictureBox pb_FileSearch;

		// Token: 0x04000070 RID: 112
		private global::System.Windows.Forms.GroupBox groupBox2;
	}
}
