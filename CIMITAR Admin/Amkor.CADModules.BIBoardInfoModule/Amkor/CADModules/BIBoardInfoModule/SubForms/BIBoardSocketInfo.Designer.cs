namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000023 RID: 35
	public partial class BIBoardSocketInfo : global::System.Windows.Forms.Form
	{
		// Token: 0x060000C8 RID: 200 RVA: 0x00011AE5 File Offset: 0x0000FCE5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00011B04 File Offset: 0x0000FD04
		private void InitializeComponent()
		{
			this.l_subject = new global::System.Windows.Forms.Label();
			this.group_Info = new global::System.Windows.Forms.GroupBox();
			this.combo_CntOfSock = new global::System.Windows.Forms.ComboBox();
			this.chk_AllSocket30W = new global::System.Windows.Forms.CheckBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.combo_Warranty = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.combo_BIBGoldTab = new global::System.Windows.Forms.ComboBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.chk_BadBIB = new global::System.Windows.Forms.CheckBox();
			this.l_barcode = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.l_location = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.l_customer = new global::System.Windows.Forms.Label();
			this.l_device = new global::System.Windows.Forms.Label();
			this.l_bib_No = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.group_Export = new global::System.Windows.Forms.GroupBox();
			this.grid_Socket_Ovv = new global::SourceGrid.Grid();
			this.tabCtrl_SockInfo = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.grid_Socket_Indv = new global::SourceGrid.Grid();
			this.group_Update = new global::System.Windows.Forms.GroupBox();
			this.group_Search = new global::System.Windows.Forms.GroupBox();
			this.tb_biboardno = new global::System.Windows.Forms.TextBox();
			this.group_PM = new global::System.Windows.Forms.GroupBox();
			this.pb_UpdatePM = new global::System.Windows.Forms.PictureBox();
			this.pb_Search_Bdno = new global::System.Windows.Forms.PictureBox();
			this.pb_Update = new global::System.Windows.Forms.PictureBox();
			this.pb_excel = new global::System.Windows.Forms.PictureBox();
			this.group_Info.SuspendLayout();
			this.group_Export.SuspendLayout();
			this.tabCtrl_SockInfo.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.group_Update.SuspendLayout();
			this.group_Search.SuspendLayout();
			this.group_PM.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_UpdatePM).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Search_Bdno).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Update).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pb_excel).BeginInit();
			base.SuspendLayout();
			this.l_subject.AutoSize = true;
			this.l_subject.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l_subject.Location = new global::System.Drawing.Point(12, 8);
			this.l_subject.Name = "l_subject";
			this.l_subject.Size = new global::System.Drawing.Size(265, 21);
			this.l_subject.TabIndex = 22;
			this.l_subject.Text = "Burn In Board Socket Information";
			this.group_Info.Controls.Add(this.combo_CntOfSock);
			this.group_Info.Controls.Add(this.chk_AllSocket30W);
			this.group_Info.Controls.Add(this.label8);
			this.group_Info.Controls.Add(this.combo_Warranty);
			this.group_Info.Controls.Add(this.label2);
			this.group_Info.Controls.Add(this.combo_BIBGoldTab);
			this.group_Info.Controls.Add(this.label5);
			this.group_Info.Controls.Add(this.chk_BadBIB);
			this.group_Info.Controls.Add(this.l_barcode);
			this.group_Info.Controls.Add(this.label7);
			this.group_Info.Controls.Add(this.l_location);
			this.group_Info.Controls.Add(this.label6);
			this.group_Info.Controls.Add(this.l_customer);
			this.group_Info.Controls.Add(this.l_device);
			this.group_Info.Controls.Add(this.l_bib_No);
			this.group_Info.Controls.Add(this.label4);
			this.group_Info.Controls.Add(this.label3);
			this.group_Info.Controls.Add(this.label1);
			this.group_Info.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.group_Info.Location = new global::System.Drawing.Point(16, 120);
			this.group_Info.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.group_Info.Name = "group_Info";
			this.group_Info.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.group_Info.Size = new global::System.Drawing.Size(1076, 80);
			this.group_Info.TabIndex = 25;
			this.group_Info.TabStop = false;
			this.group_Info.Text = "BI Board Information";
			this.combo_CntOfSock.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_CntOfSock.FormattingEnabled = true;
			this.combo_CntOfSock.Location = new global::System.Drawing.Point(1015, 45);
			this.combo_CntOfSock.Name = "combo_CntOfSock";
			this.combo_CntOfSock.Size = new global::System.Drawing.Size(45, 23);
			this.combo_CntOfSock.TabIndex = 37;
			this.combo_CntOfSock.SelectionChangeCommitted += new global::System.EventHandler(this.combo_CntOfSock_SelectionChangeCommitted);
			this.chk_AllSocket30W.AutoSize = true;
			this.chk_AllSocket30W.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chk_AllSocket30W.Location = new global::System.Drawing.Point(919, 21);
			this.chk_AllSocket30W.Name = "chk_AllSocket30W";
			this.chk_AllSocket30W.Size = new global::System.Drawing.Size(110, 19);
			this.chk_AllSocket30W.TabIndex = 35;
			this.chk_AllSocket30W.Text = "All Socket 30W :";
			this.chk_AllSocket30W.UseVisualStyleBackColor = true;
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(906, 48);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(103, 15);
			this.label8.TabIndex = 36;
			this.label8.Text = "Count of Sockets :";
			this.combo_Warranty.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Warranty.FormattingEnabled = true;
			this.combo_Warranty.Location = new global::System.Drawing.Point(803, 45);
			this.combo_Warranty.Name = "combo_Warranty";
			this.combo_Warranty.Size = new global::System.Drawing.Size(61, 23);
			this.combo_Warranty.TabIndex = 34;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(686, 48);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(64, 15);
			this.label2.TabIndex = 33;
			this.label2.Text = "Warranty : ";
			this.combo_BIBGoldTab.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_BIBGoldTab.FormattingEnabled = true;
			this.combo_BIBGoldTab.Location = new global::System.Drawing.Point(803, 19);
			this.combo_BIBGoldTab.Name = "combo_BIBGoldTab";
			this.combo_BIBGoldTab.Size = new global::System.Drawing.Size(61, 23);
			this.combo_BIBGoldTab.TabIndex = 32;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(686, 22);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(79, 15);
			this.label5.TabIndex = 31;
			this.label5.Text = "BIB Gold Tab :";
			this.chk_BadBIB.AutoSize = true;
			this.chk_BadBIB.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chk_BadBIB.Location = new global::System.Drawing.Point(440, 47);
			this.chk_BadBIB.Name = "chk_BadBIB";
			this.chk_BadBIB.Size = new global::System.Drawing.Size(127, 19);
			this.chk_BadBIB.TabIndex = 11;
			this.chk_BadBIB.Text = "Bad Burn In Board :";
			this.chk_BadBIB.UseVisualStyleBackColor = true;
			this.l_barcode.AutoSize = true;
			this.l_barcode.Location = new global::System.Drawing.Point(545, 22);
			this.l_barcode.Name = "l_barcode";
			this.l_barcode.Size = new global::System.Drawing.Size(79, 15);
			this.l_barcode.TabIndex = 10;
			this.l_barcode.Text = "ABBURN IN-7";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(441, 22);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(56, 15);
			this.label7.TabIndex = 9;
			this.label7.Text = "Barcode :";
			this.l_location.AutoSize = true;
			this.l_location.Location = new global::System.Drawing.Point(298, 48);
			this.l_location.Name = "l_location";
			this.l_location.Size = new global::System.Drawing.Size(64, 15);
			this.l_location.TabIndex = 8;
			this.l_location.Text = "BURN IN-7";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(221, 48);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(59, 15);
			this.label6.TabIndex = 7;
			this.label6.Text = "Location :";
			this.l_customer.AutoSize = true;
			this.l_customer.Location = new global::System.Drawing.Point(298, 22);
			this.l_customer.Name = "l_customer";
			this.l_customer.Size = new global::System.Drawing.Size(77, 15);
			this.l_customer.TabIndex = 6;
			this.l_customer.Text = "QUALCOMM";
			this.l_device.AutoSize = true;
			this.l_device.Location = new global::System.Drawing.Point(74, 48);
			this.l_device.Name = "l_device";
			this.l_device.Size = new global::System.Drawing.Size(85, 15);
			this.l_device.TabIndex = 5;
			this.l_device.Text = "RADAGAST AU";
			this.l_bib_No.AutoSize = true;
			this.l_bib_No.Location = new global::System.Drawing.Point(74, 22);
			this.l_bib_No.Name = "l_bib_No";
			this.l_bib_No.Size = new global::System.Drawing.Size(38, 15);
			this.l_bib_No.TabIndex = 4;
			this.l_bib_No.Text = "#1029";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(221, 22);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(68, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "Customer : ";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(13, 48);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(51, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Device : ";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(13, 22);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(44, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "BIB ID :";
			this.group_Export.Controls.Add(this.pb_excel);
			this.group_Export.Location = new global::System.Drawing.Point(1178, 121);
			this.group_Export.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.group_Export.Name = "group_Export";
			this.group_Export.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.group_Export.Size = new global::System.Drawing.Size(73, 80);
			this.group_Export.TabIndex = 26;
			this.group_Export.TabStop = false;
			this.group_Export.Text = "Export";
			this.grid_Socket_Ovv.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_Socket_Ovv.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_Socket_Ovv.EnableSort = true;
			this.grid_Socket_Ovv.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.grid_Socket_Ovv.Location = new global::System.Drawing.Point(3, 3);
			this.grid_Socket_Ovv.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.grid_Socket_Ovv.Name = "grid_Socket_Ovv";
			this.grid_Socket_Ovv.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_Socket_Ovv.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_Socket_Ovv.Size = new global::System.Drawing.Size(1301, 429);
			this.grid_Socket_Ovv.TabIndex = 16;
			this.grid_Socket_Ovv.TabStop = true;
			this.grid_Socket_Ovv.ToolTipText = "";
			this.tabCtrl_SockInfo.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabCtrl_SockInfo.Controls.Add(this.tabPage1);
			this.tabCtrl_SockInfo.Controls.Add(this.tabPage2);
			this.tabCtrl_SockInfo.Location = new global::System.Drawing.Point(16, 207);
			this.tabCtrl_SockInfo.Name = "tabCtrl_SockInfo";
			this.tabCtrl_SockInfo.SelectedIndex = 0;
			this.tabCtrl_SockInfo.Size = new global::System.Drawing.Size(1315, 463);
			this.tabCtrl_SockInfo.TabIndex = 28;
			this.tabPage1.Controls.Add(this.grid_Socket_Ovv);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(1307, 435);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Overview";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage2.Controls.Add(this.grid_Socket_Indv);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(1307, 435);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Individual";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.grid_Socket_Indv.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_Socket_Indv.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_Socket_Indv.EnableSort = true;
			this.grid_Socket_Indv.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.grid_Socket_Indv.Location = new global::System.Drawing.Point(3, 3);
			this.grid_Socket_Indv.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.grid_Socket_Indv.Name = "grid_Socket_Indv";
			this.grid_Socket_Indv.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_Socket_Indv.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_Socket_Indv.Size = new global::System.Drawing.Size(1301, 429);
			this.grid_Socket_Indv.TabIndex = 17;
			this.grid_Socket_Indv.TabStop = true;
			this.grid_Socket_Indv.ToolTipText = "";
			this.group_Update.Controls.Add(this.pb_Update);
			this.group_Update.Location = new global::System.Drawing.Point(1098, 121);
			this.group_Update.Name = "group_Update";
			this.group_Update.Size = new global::System.Drawing.Size(74, 80);
			this.group_Update.TabIndex = 30;
			this.group_Update.TabStop = false;
			this.group_Update.Text = "Update";
			this.group_Search.Controls.Add(this.pb_Search_Bdno);
			this.group_Search.Controls.Add(this.tb_biboardno);
			this.group_Search.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.group_Search.Location = new global::System.Drawing.Point(16, 39);
			this.group_Search.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.group_Search.Name = "group_Search";
			this.group_Search.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.group_Search.Size = new global::System.Drawing.Size(219, 72);
			this.group_Search.TabIndex = 31;
			this.group_Search.TabStop = false;
			this.group_Search.Text = "BI Board No";
			this.tb_biboardno.Location = new global::System.Drawing.Point(16, 32);
			this.tb_biboardno.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_biboardno.Name = "tb_biboardno";
			this.tb_biboardno.Size = new global::System.Drawing.Size(143, 23);
			this.tb_biboardno.TabIndex = 12;
			this.tb_biboardno.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tb_biboardno_KeyDown);
			this.group_PM.Controls.Add(this.pb_UpdatePM);
			this.group_PM.Location = new global::System.Drawing.Point(1257, 121);
			this.group_PM.Name = "group_PM";
			this.group_PM.Size = new global::System.Drawing.Size(74, 80);
			this.group_PM.TabIndex = 32;
			this.group_PM.TabStop = false;
			this.group_PM.Text = "PM";
			this.pb_UpdatePM.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_UpdatePM.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_UpdatePM.InitialImage = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_UpdatePM.Location = new global::System.Drawing.Point(21, 28);
			this.pb_UpdatePM.Name = "pb_UpdatePM";
			this.pb_UpdatePM.Size = new global::System.Drawing.Size(32, 33);
			this.pb_UpdatePM.TabIndex = 0;
			this.pb_UpdatePM.TabStop = false;
			this.pb_UpdatePM.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_UpdatePM_MouseDown);
			this.pb_UpdatePM.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_UpdatePM_MouseUp);
			this.pb_Search_Bdno.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Search_Bdno.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.lothistory;
			this.pb_Search_Bdno.Location = new global::System.Drawing.Point(173, 27);
			this.pb_Search_Bdno.Name = "pb_Search_Bdno";
			this.pb_Search_Bdno.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Search_Bdno.TabIndex = 0;
			this.pb_Search_Bdno.TabStop = false;
			this.pb_Search_Bdno.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Search_Bdno_MouseUp);
			this.pb_Update.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Update.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_Update.InitialImage = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_Update.Location = new global::System.Drawing.Point(21, 28);
			this.pb_Update.Name = "pb_Update";
			this.pb_Update.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Update.TabIndex = 0;
			this.pb_Update.TabStop = false;
			this.pb_Update.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_Update_MouseDown);
			this.pb_Update.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Update_MouseUp);
			this.pb_excel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_excel.ErrorImage = null;
			this.pb_excel.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.SaveExcel;
			this.pb_excel.InitialImage = null;
			this.pb_excel.Location = new global::System.Drawing.Point(21, 28);
			this.pb_excel.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pb_excel.Name = "pb_excel";
			this.pb_excel.Size = new global::System.Drawing.Size(32, 33);
			this.pb_excel.TabIndex = 0;
			this.pb_excel.TabStop = false;
			this.pb_excel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_excel_MouseDown);
			this.pb_excel.MouseHover += new global::System.EventHandler(this.pb_excel_MouseHover);
			this.pb_excel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_excel_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1349, 682);
			base.Controls.Add(this.group_PM);
			base.Controls.Add(this.group_Search);
			base.Controls.Add(this.group_Update);
			base.Controls.Add(this.tabCtrl_SockInfo);
			base.Controls.Add(this.group_Export);
			base.Controls.Add(this.group_Info);
			base.Controls.Add(this.l_subject);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "BIBoardSocketInfo";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "BIBoardSocketInfo";
			base.Load += new global::System.EventHandler(this.BIBoardSocketInfo_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.BIBoardSocketInfo_KeyDown);
			this.group_Info.ResumeLayout(false);
			this.group_Info.PerformLayout();
			this.group_Export.ResumeLayout(false);
			this.tabCtrl_SockInfo.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.group_Update.ResumeLayout(false);
			this.group_Search.ResumeLayout(false);
			this.group_Search.PerformLayout();
			this.group_PM.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_UpdatePM).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Search_Bdno).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Update).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pb_excel).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400016C RID: 364
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400016D RID: 365
		private global::System.Windows.Forms.Label l_subject;

		// Token: 0x0400016E RID: 366
		private global::System.Windows.Forms.GroupBox group_Info;

		// Token: 0x0400016F RID: 367
		private global::System.Windows.Forms.Label l_barcode;

		// Token: 0x04000170 RID: 368
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000171 RID: 369
		private global::System.Windows.Forms.Label l_location;

		// Token: 0x04000172 RID: 370
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000173 RID: 371
		private global::System.Windows.Forms.Label l_customer;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.Label l_device;

		// Token: 0x04000175 RID: 373
		private global::System.Windows.Forms.Label l_bib_No;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.GroupBox group_Export;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.PictureBox pb_excel;

		// Token: 0x0400017B RID: 379
		private global::SourceGrid.Grid grid_Socket_Ovv;

		// Token: 0x0400017C RID: 380
		private global::System.Windows.Forms.TabControl tabCtrl_SockInfo;

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x0400017E RID: 382
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x0400017F RID: 383
		private global::SourceGrid.Grid grid_Socket_Indv;

		// Token: 0x04000180 RID: 384
		private global::System.Windows.Forms.CheckBox chk_BadBIB;

		// Token: 0x04000181 RID: 385
		private global::System.Windows.Forms.GroupBox group_Update;

		// Token: 0x04000182 RID: 386
		private global::System.Windows.Forms.PictureBox pb_Update;

		// Token: 0x04000183 RID: 387
		private global::System.Windows.Forms.ComboBox combo_BIBGoldTab;

		// Token: 0x04000184 RID: 388
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000185 RID: 389
		private global::System.Windows.Forms.ComboBox combo_Warranty;

		// Token: 0x04000186 RID: 390
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000187 RID: 391
		private global::System.Windows.Forms.GroupBox group_Search;

		// Token: 0x04000188 RID: 392
		private global::System.Windows.Forms.PictureBox pb_Search_Bdno;

		// Token: 0x04000189 RID: 393
		private global::System.Windows.Forms.TextBox tb_biboardno;

		// Token: 0x0400018A RID: 394
		private global::System.Windows.Forms.GroupBox group_PM;

		// Token: 0x0400018B RID: 395
		private global::System.Windows.Forms.PictureBox pb_UpdatePM;

		// Token: 0x0400018C RID: 396
		private global::System.Windows.Forms.CheckBox chk_AllSocket30W;

		// Token: 0x0400018D RID: 397
		private global::System.Windows.Forms.ComboBox combo_CntOfSock;

		// Token: 0x0400018E RID: 398
		private global::System.Windows.Forms.Label label8;
	}
}
