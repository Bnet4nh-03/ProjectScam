namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x0200000C RID: 12
	public partial class cAction : global::System.Windows.Forms.Form, global::Amkor.CADModules.Maintenance.GrobalConst.Interface.IHCC
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x00022F20 File Offset: 0x00021120
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00022F58 File Offset: 0x00021158
		private void InitializeComponent()
		{
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.btnHold = new global::System.Windows.Forms.Button();
			this.btnSummit = new global::System.Windows.Forms.Button();
			this.label13 = new global::System.Windows.Forms.Label();
			this.tbReport = new global::System.Windows.Forms.TextBox();
			this.tbFrom = new global::System.Windows.Forms.TextBox();
			this.btnClear = new global::System.Windows.Forms.Button();
			this.tbFromAction = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tpReport = new global::System.Windows.Forms.TabPage();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.panel60 = new global::System.Windows.Forms.Panel();
			this.pnLeft = new global::System.Windows.Forms.Panel();
			this.pnAttachment = new global::System.Windows.Forms.Panel();
			this.pnRequestInformation = new global::System.Windows.Forms.Panel();
			this.pnUserInformation = new global::System.Windows.Forms.Panel();
			this.panel30 = new global::System.Windows.Forms.Panel();
			this.pnEdit = new global::System.Windows.Forms.Panel();
			this.pbEdite = new global::System.Windows.Forms.PictureBox();
			this.lbEdite = new global::System.Windows.Forms.Label();
			this.panel35 = new global::System.Windows.Forms.Panel();
			this.panel10 = new global::System.Windows.Forms.Panel();
			this.pbView = new global::System.Windows.Forms.PictureBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel36 = new global::System.Windows.Forms.Panel();
			this.pnDelete = new global::System.Windows.Forms.Panel();
			this.pbDelete = new global::System.Windows.Forms.PictureBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.pnRight = new global::System.Windows.Forms.Panel();
			this.tpAction = new global::System.Windows.Forms.TabPage();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.panel = new global::System.Windows.Forms.Panel();
			this.pnActionContent = new global::System.Windows.Forms.Panel();
			this.pnActionOtehr = new global::System.Windows.Forms.Panel();
			this.pnActionHcc = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.pnPart = new global::System.Windows.Forms.Panel();
			this.pnActionInformation = new global::System.Windows.Forms.Panel();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.pnBoardInformation = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel27 = new global::System.Windows.Forms.Panel();
			this.pbClear = new global::System.Windows.Forms.PictureBox();
			this.panel38 = new global::System.Windows.Forms.Panel();
			this.pbHold = new global::System.Windows.Forms.PictureBox();
			this.panel13 = new global::System.Windows.Forms.Panel();
			this.pbSubmit = new global::System.Windows.Forms.PictureBox();
			this.tpConfirmation = new global::System.Windows.Forms.TabPage();
			this.tbCase = new global::System.Windows.Forms.TextBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel_PDF = new global::System.Windows.Forms.Panel();
			this.web_Viewer = new global::System.Windows.Forms.WebBrowser();
			this.btn_close = new global::System.Windows.Forms.Button();
			this.gbBoardSiteMap = new global::System.Windows.Forms.GroupBox();
			this.pbBoardInforamtion = new global::System.Windows.Forms.PictureBox();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.tabControl1.SuspendLayout();
			this.tpReport.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel60.SuspendLayout();
			this.pnLeft.SuspendLayout();
			this.panel30.SuspendLayout();
			this.pnEdit.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbEdite).BeginInit();
			this.panel10.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbView).BeginInit();
			this.pnDelete.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbDelete).BeginInit();
			this.tpAction.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel.SuspendLayout();
			this.pnActionOtehr.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel27.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbHold).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbSubmit).BeginInit();
			this.panel1.SuspendLayout();
			this.panel_PDF.SuspendLayout();
			this.gbBoardSiteMap.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbBoardInforamtion).BeginInit();
			base.SuspendLayout();
			this.btnHold.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnHold.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnHold.Location = new global::System.Drawing.Point(861, 0);
			this.btnHold.Name = "btnHold";
			this.btnHold.Size = new global::System.Drawing.Size(111, 47);
			this.btnHold.TabIndex = 63;
			this.btnHold.Text = "Hold";
			this.btnHold.UseVisualStyleBackColor = true;
			this.btnHold.Visible = false;
			this.btnHold.Click += new global::System.EventHandler(this.btnHold_Click);
			this.btnSummit.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnSummit.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnSummit.Location = new global::System.Drawing.Point(972, 0);
			this.btnSummit.Name = "btnSummit";
			this.btnSummit.Size = new global::System.Drawing.Size(111, 47);
			this.btnSummit.TabIndex = 62;
			this.btnSummit.Text = "Submit";
			this.btnSummit.UseVisualStyleBackColor = true;
			this.btnSummit.Visible = false;
			this.btnSummit.Click += new global::System.EventHandler(this.btnSummit2_Click);
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.Location = new global::System.Drawing.Point(8, 4);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(60, 17);
			this.label13.TabIndex = 58;
			this.label13.Text = "Report #";
			this.tbReport.BackColor = global::System.Drawing.Color.Gainsboro;
			this.tbReport.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbReport.Location = new global::System.Drawing.Point(74, 3);
			this.tbReport.Name = "tbReport";
			this.tbReport.ReadOnly = true;
			this.tbReport.Size = new global::System.Drawing.Size(600, 23);
			this.tbReport.TabIndex = 59;
			this.tbReport.TabStop = false;
			this.tbFrom.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbFrom.Location = new global::System.Drawing.Point(1247, 5);
			this.tbFrom.Name = "tbFrom";
			this.tbFrom.Size = new global::System.Drawing.Size(140, 25);
			this.tbFrom.TabIndex = 61;
			this.tbFrom.Visible = false;
			this.btnClear.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnClear.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClear.Location = new global::System.Drawing.Point(750, 0);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new global::System.Drawing.Size(111, 47);
			this.btnClear.TabIndex = 44;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Visible = false;
			this.btnClear.Click += new global::System.EventHandler(this.btnClear_Click);
			this.tbFromAction.BackColor = global::System.Drawing.Color.Gainsboro;
			this.tbFromAction.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbFromAction.Location = new global::System.Drawing.Point(720, 2);
			this.tbFromAction.Name = "tbFromAction";
			this.tbFromAction.ReadOnly = true;
			this.tbFromAction.Size = new global::System.Drawing.Size(215, 25);
			this.tbFromAction.TabIndex = 59;
			this.tbFromAction.Visible = false;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(680, 5);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(38, 17);
			this.label2.TabIndex = 58;
			this.label2.Text = "From";
			this.label2.Visible = false;
			this.tabControl1.Controls.Add(this.tpReport);
			this.tabControl1.Controls.Add(this.tpAction);
			this.tabControl1.Controls.Add(this.tpConfirmation);
			this.tabControl1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Font = new global::System.Drawing.Font("Segoe UI Semibold", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl1.Location = new global::System.Drawing.Point(0, 33);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(1287, 841);
			this.tabControl1.TabIndex = 69;
			this.tpReport.Controls.Add(this.splitContainer1);
			this.tpReport.Font = new global::System.Drawing.Font("굴림", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.tpReport.Location = new global::System.Drawing.Point(4, 30);
			this.tpReport.Name = "tpReport";
			this.tpReport.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpReport.Size = new global::System.Drawing.Size(1279, 807);
			this.tpReport.TabIndex = 0;
			this.tpReport.Text = "Request Report";
			this.tpReport.UseVisualStyleBackColor = true;
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.panel60);
			this.splitContainer1.Panel1.Controls.Add(this.panel30);
			this.splitContainer1.Panel2.Controls.Add(this.pnRight);
			this.splitContainer1.Size = new global::System.Drawing.Size(1273, 801);
			this.splitContainer1.SplitterDistance = 337;
			this.splitContainer1.SplitterWidth = 3;
			this.splitContainer1.TabIndex = 72;
			this.panel60.AutoScroll = true;
			this.panel60.Controls.Add(this.pnLeft);
			this.panel60.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel60.Location = new global::System.Drawing.Point(0, 0);
			this.panel60.Name = "panel60";
			this.panel60.Size = new global::System.Drawing.Size(337, 733);
			this.panel60.TabIndex = 105;
			this.pnLeft.Controls.Add(this.pnAttachment);
			this.pnLeft.Controls.Add(this.pnRequestInformation);
			this.pnLeft.Controls.Add(this.pnUserInformation);
			this.pnLeft.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnLeft.Location = new global::System.Drawing.Point(0, 0);
			this.pnLeft.Name = "pnLeft";
			this.pnLeft.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.pnLeft.Size = new global::System.Drawing.Size(337, 617);
			this.pnLeft.TabIndex = 0;
			this.pnAttachment.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnAttachment.Location = new global::System.Drawing.Point(0, 274);
			this.pnAttachment.Name = "pnAttachment";
			this.pnAttachment.Size = new global::System.Drawing.Size(334, 134);
			this.pnAttachment.TabIndex = 109;
			this.pnRequestInformation.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnRequestInformation.Location = new global::System.Drawing.Point(0, 140);
			this.pnRequestInformation.Name = "pnRequestInformation";
			this.pnRequestInformation.Size = new global::System.Drawing.Size(334, 134);
			this.pnRequestInformation.TabIndex = 104;
			this.pnUserInformation.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnUserInformation.Location = new global::System.Drawing.Point(0, 0);
			this.pnUserInformation.Name = "pnUserInformation";
			this.pnUserInformation.Size = new global::System.Drawing.Size(334, 140);
			this.pnUserInformation.TabIndex = 106;
			this.panel30.Controls.Add(this.gbBoardSiteMap);
			this.panel30.Controls.Add(this.panel6);
			this.panel30.Controls.Add(this.pnEdit);
			this.panel30.Controls.Add(this.panel35);
			this.panel30.Controls.Add(this.panel10);
			this.panel30.Controls.Add(this.panel36);
			this.panel30.Controls.Add(this.pnDelete);
			this.panel30.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel30.Location = new global::System.Drawing.Point(0, 733);
			this.panel30.Name = "panel30";
			this.panel30.Size = new global::System.Drawing.Size(337, 68);
			this.panel30.TabIndex = 80;
			this.pnEdit.Controls.Add(this.pbEdite);
			this.pnEdit.Controls.Add(this.lbEdite);
			this.pnEdit.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pnEdit.Location = new global::System.Drawing.Point(178, 0);
			this.pnEdit.Name = "pnEdit";
			this.pnEdit.Size = new global::System.Drawing.Size(44, 68);
			this.pnEdit.TabIndex = 85;
			this.pbEdite.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbEdite.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pbEdite.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.edit;
			this.pbEdite.Location = new global::System.Drawing.Point(0, 21);
			this.pbEdite.Name = "pbEdite";
			this.pbEdite.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbEdite.Size = new global::System.Drawing.Size(44, 47);
			this.pbEdite.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbEdite.TabIndex = 81;
			this.pbEdite.TabStop = false;
			this.pbEdite.Tag = "Edit";
			this.pbEdite.Click += new global::System.EventHandler(this.pbEdite_Click);
			this.pbEdite.MouseEnter += new global::System.EventHandler(this.pbEdite_MouseEnter);
			this.pbEdite.MouseLeave += new global::System.EventHandler(this.pbEdite_MouseLeave);
			this.lbEdite.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.lbEdite.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.lbEdite.Location = new global::System.Drawing.Point(0, 0);
			this.lbEdite.Name = "lbEdite";
			this.lbEdite.Size = new global::System.Drawing.Size(44, 21);
			this.lbEdite.TabIndex = 85;
			this.lbEdite.Text = "Edit";
			this.panel35.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel35.Location = new global::System.Drawing.Point(222, 0);
			this.panel35.Name = "panel35";
			this.panel35.Size = new global::System.Drawing.Size(10, 68);
			this.panel35.TabIndex = 80;
			this.panel10.Controls.Add(this.pbView);
			this.panel10.Controls.Add(this.label3);
			this.panel10.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel10.Location = new global::System.Drawing.Point(232, 0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new global::System.Drawing.Size(44, 68);
			this.panel10.TabIndex = 87;
			this.pbView.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbView.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pbView.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.view;
			this.pbView.Location = new global::System.Drawing.Point(0, 21);
			this.pbView.Name = "pbView";
			this.pbView.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbView.Size = new global::System.Drawing.Size(44, 47);
			this.pbView.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbView.TabIndex = 83;
			this.pbView.TabStop = false;
			this.pbView.Click += new global::System.EventHandler(this.pbView_Click);
			this.pbView.MouseEnter += new global::System.EventHandler(this.pbView_MouseEnter);
			this.pbView.MouseLeave += new global::System.EventHandler(this.pbView_MouseLeave);
			this.label3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label3.Location = new global::System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(44, 21);
			this.label3.TabIndex = 84;
			this.label3.Text = "View";
			this.panel36.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel36.Location = new global::System.Drawing.Point(276, 0);
			this.panel36.Name = "panel36";
			this.panel36.Size = new global::System.Drawing.Size(10, 68);
			this.panel36.TabIndex = 82;
			this.pnDelete.Controls.Add(this.pbDelete);
			this.pnDelete.Controls.Add(this.label7);
			this.pnDelete.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pnDelete.Location = new global::System.Drawing.Point(286, 0);
			this.pnDelete.Name = "pnDelete";
			this.pnDelete.Size = new global::System.Drawing.Size(51, 68);
			this.pnDelete.TabIndex = 88;
			this.pbDelete.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbDelete.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pbDelete.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.delete;
			this.pbDelete.Location = new global::System.Drawing.Point(0, 21);
			this.pbDelete.Name = "pbDelete";
			this.pbDelete.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbDelete.Size = new global::System.Drawing.Size(51, 47);
			this.pbDelete.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbDelete.TabIndex = 79;
			this.pbDelete.TabStop = false;
			this.pbDelete.Click += new global::System.EventHandler(this.pbDelete_Click);
			this.pbDelete.MouseEnter += new global::System.EventHandler(this.pbDelete_MouseEnter);
			this.pbDelete.MouseLeave += new global::System.EventHandler(this.pbDelete_MouseLeave);
			this.label7.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label7.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label7.Location = new global::System.Drawing.Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(51, 21);
			this.label7.TabIndex = 86;
			this.label7.Text = "Delete";
			this.pnRight.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnRight.Location = new global::System.Drawing.Point(0, 0);
			this.pnRight.Name = "pnRight";
			this.pnRight.Size = new global::System.Drawing.Size(933, 801);
			this.pnRight.TabIndex = 68;
			this.tpAction.AutoScroll = true;
			this.tpAction.Controls.Add(this.panel4);
			this.tpAction.Controls.Add(this.panel27);
			this.tpAction.Location = new global::System.Drawing.Point(4, 30);
			this.tpAction.Name = "tpAction";
			this.tpAction.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpAction.Size = new global::System.Drawing.Size(1279, 807);
			this.tpAction.TabIndex = 1;
			this.tpAction.Text = "Action Report";
			this.tpAction.UseVisualStyleBackColor = true;
			this.panel4.Controls.Add(this.panel);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new global::System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1273, 751);
			this.panel4.TabIndex = 83;
			this.panel.Controls.Add(this.pnActionContent);
			this.panel.Controls.Add(this.pnActionOtehr);
			this.panel.Controls.Add(this.pnActionInformation);
			this.panel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new global::System.Drawing.Point(316, 0);
			this.panel.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel.Name = "panel";
			this.panel.Size = new global::System.Drawing.Size(957, 751);
			this.panel.TabIndex = 74;
			this.pnActionContent.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnActionContent.Font = new global::System.Drawing.Font("굴림", 9f);
			this.pnActionContent.Location = new global::System.Drawing.Point(0, 91);
			this.pnActionContent.Name = "pnActionContent";
			this.pnActionContent.Size = new global::System.Drawing.Size(539, 660);
			this.pnActionContent.TabIndex = 92;
			this.pnActionOtehr.AutoScroll = true;
			this.pnActionOtehr.Controls.Add(this.pnActionHcc);
			this.pnActionOtehr.Controls.Add(this.panel2);
			this.pnActionOtehr.Controls.Add(this.pnPart);
			this.pnActionOtehr.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pnActionOtehr.Location = new global::System.Drawing.Point(539, 91);
			this.pnActionOtehr.Name = "pnActionOtehr";
			this.pnActionOtehr.Padding = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.pnActionOtehr.Size = new global::System.Drawing.Size(418, 660);
			this.pnActionOtehr.TabIndex = 91;
			this.pnActionHcc.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnActionHcc.Font = new global::System.Drawing.Font("굴림", 9f);
			this.pnActionHcc.Location = new global::System.Drawing.Point(3, 290);
			this.pnActionHcc.Name = "pnActionHcc";
			this.pnActionHcc.Size = new global::System.Drawing.Size(415, 133);
			this.pnActionHcc.TabIndex = 72;
			this.panel2.AutoSize = true;
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(3, 290);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(415, 0);
			this.panel2.TabIndex = 69;
			this.pnPart.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnPart.Font = new global::System.Drawing.Font("굴림", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.pnPart.Location = new global::System.Drawing.Point(3, 0);
			this.pnPart.Name = "pnPart";
			this.pnPart.Size = new global::System.Drawing.Size(415, 290);
			this.pnPart.TabIndex = 70;
			this.pnActionInformation.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnActionInformation.Font = new global::System.Drawing.Font("굴림", 9f);
			this.pnActionInformation.Location = new global::System.Drawing.Point(0, 0);
			this.pnActionInformation.Margin = new global::System.Windows.Forms.Padding(0);
			this.pnActionInformation.Name = "pnActionInformation";
			this.pnActionInformation.Size = new global::System.Drawing.Size(957, 91);
			this.pnActionInformation.TabIndex = 88;
			this.panel5.Controls.Add(this.panel8);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel5.Location = new global::System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(316, 751);
			this.panel5.TabIndex = 73;
			this.panel8.Controls.Add(this.pnBoardInformation);
			this.panel8.Controls.Add(this.panel3);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new global::System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(316, 751);
			this.panel8.TabIndex = 88;
			this.pnBoardInformation.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnBoardInformation.Font = new global::System.Drawing.Font("굴림", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.pnBoardInformation.Location = new global::System.Drawing.Point(0, 329);
			this.pnBoardInformation.Name = "pnBoardInformation";
			this.pnBoardInformation.Size = new global::System.Drawing.Size(316, 422);
			this.pnBoardInformation.TabIndex = 111;
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Font = new global::System.Drawing.Font("굴림", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(316, 329);
			this.panel3.TabIndex = 88;
			this.panel27.Controls.Add(this.btnClear);
			this.panel27.Controls.Add(this.btnHold);
			this.panel27.Controls.Add(this.btnSummit);
			this.panel27.Controls.Add(this.pbClear);
			this.panel27.Controls.Add(this.panel38);
			this.panel27.Controls.Add(this.pbHold);
			this.panel27.Controls.Add(this.panel13);
			this.panel27.Controls.Add(this.pbSubmit);
			this.panel27.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel27.Font = new global::System.Drawing.Font("굴림", 9f);
			this.panel27.Location = new global::System.Drawing.Point(3, 754);
			this.panel27.Name = "panel27";
			this.panel27.Padding = new global::System.Windows.Forms.Padding(0, 0, 0, 3);
			this.panel27.Size = new global::System.Drawing.Size(1273, 50);
			this.panel27.TabIndex = 91;
			this.pbClear.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbClear.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbClear.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbClear.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbClear.Location = new global::System.Drawing.Point(1083, 0);
			this.pbClear.Name = "pbClear";
			this.pbClear.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbClear.Size = new global::System.Drawing.Size(48, 47);
			this.pbClear.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbClear.TabIndex = 68;
			this.pbClear.TabStop = false;
			this.pbClear.Click += new global::System.EventHandler(this.pbClear_Click);
			this.pbClear.MouseEnter += new global::System.EventHandler(this.pbClear_MouseEnter);
			this.pbClear.MouseLeave += new global::System.EventHandler(this.pbClear_MouseLeave);
			this.panel38.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel38.Location = new global::System.Drawing.Point(1131, 0);
			this.panel38.Name = "panel38";
			this.panel38.Size = new global::System.Drawing.Size(23, 47);
			this.panel38.TabIndex = 67;
			this.pbHold.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbHold.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbHold.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.hold;
			this.pbHold.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbHold.Location = new global::System.Drawing.Point(1154, 0);
			this.pbHold.Name = "pbHold";
			this.pbHold.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbHold.Size = new global::System.Drawing.Size(48, 47);
			this.pbHold.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbHold.TabIndex = 66;
			this.pbHold.TabStop = false;
			this.pbHold.Click += new global::System.EventHandler(this.pbHold_Click);
			this.pbHold.MouseEnter += new global::System.EventHandler(this.pbHold_MouseEnter);
			this.pbHold.MouseLeave += new global::System.EventHandler(this.pbHold_MouseLeave);
			this.panel13.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel13.Location = new global::System.Drawing.Point(1202, 0);
			this.panel13.Name = "panel13";
			this.panel13.Size = new global::System.Drawing.Size(23, 47);
			this.panel13.TabIndex = 69;
			this.pbSubmit.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbSubmit.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbSubmit.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.submit;
			this.pbSubmit.Location = new global::System.Drawing.Point(1225, 0);
			this.pbSubmit.Name = "pbSubmit";
			this.pbSubmit.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbSubmit.Size = new global::System.Drawing.Size(48, 47);
			this.pbSubmit.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbSubmit.TabIndex = 64;
			this.pbSubmit.TabStop = false;
			this.pbSubmit.Click += new global::System.EventHandler(this.pbSubmit_Click);
			this.pbSubmit.MouseEnter += new global::System.EventHandler(this.pbSubmit_MouseEnter);
			this.pbSubmit.MouseLeave += new global::System.EventHandler(this.pbSubmit_MouseLeave);
			this.tpConfirmation.Location = new global::System.Drawing.Point(4, 30);
			this.tpConfirmation.Name = "tpConfirmation";
			this.tpConfirmation.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpConfirmation.Size = new global::System.Drawing.Size(1279, 807);
			this.tpConfirmation.TabIndex = 2;
			this.tpConfirmation.Text = "Confirmation";
			this.tpConfirmation.UseVisualStyleBackColor = true;
			this.tbCase.BackColor = global::System.Drawing.Color.Gainsboro;
			this.tbCase.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbCase.Location = new global::System.Drawing.Point(977, 4);
			this.tbCase.Name = "tbCase";
			this.tbCase.ReadOnly = true;
			this.tbCase.Size = new global::System.Drawing.Size(213, 23);
			this.tbCase.TabIndex = 100;
			this.tbCase.TabStop = false;
			this.tbCase.Visible = false;
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.tbFrom);
			this.panel1.Controls.Add(this.tbFromAction);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.tbCase);
			this.panel1.Controls.Add(this.tbReport);
			this.panel1.Controls.Add(this.label13);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1287, 33);
			this.panel1.TabIndex = 68;
			this.panel_PDF.Controls.Add(this.web_Viewer);
			this.panel_PDF.Controls.Add(this.btn_close);
			this.panel_PDF.Location = new global::System.Drawing.Point(321, 261);
			this.panel_PDF.Name = "panel_PDF";
			this.panel_PDF.Size = new global::System.Drawing.Size(397, 155);
			this.panel_PDF.TabIndex = 87;
			this.panel_PDF.Visible = false;
			this.web_Viewer.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.web_Viewer.Location = new global::System.Drawing.Point(0, 0);
			this.web_Viewer.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.web_Viewer.Name = "web_Viewer";
			this.web_Viewer.Size = new global::System.Drawing.Size(397, 116);
			this.web_Viewer.TabIndex = 79;
			this.btn_close.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.btn_close.Font = new global::System.Drawing.Font("Segoe UI Symbol", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btn_close.Location = new global::System.Drawing.Point(0, 116);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new global::System.Drawing.Size(397, 39);
			this.btn_close.TabIndex = 80;
			this.btn_close.Text = "Exit";
			this.btn_close.UseVisualStyleBackColor = true;
			this.btn_close.Click += new global::System.EventHandler(this.btn_close_Click);
			this.gbBoardSiteMap.Controls.Add(this.pbBoardInforamtion);
			this.gbBoardSiteMap.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.gbBoardSiteMap.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.gbBoardSiteMap.Location = new global::System.Drawing.Point(93, 0);
			this.gbBoardSiteMap.Name = "gbBoardSiteMap";
			this.gbBoardSiteMap.Padding = new global::System.Windows.Forms.Padding(1, 1, 1, 3);
			this.gbBoardSiteMap.Size = new global::System.Drawing.Size(75, 68);
			this.gbBoardSiteMap.TabIndex = 102;
			this.gbBoardSiteMap.TabStop = false;
			this.gbBoardSiteMap.Text = "Site Map";
			this.gbBoardSiteMap.Visible = false;
			this.pbBoardInforamtion.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbBoardInforamtion.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pbBoardInforamtion.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.board;
			this.pbBoardInforamtion.InitialImage = null;
			this.pbBoardInforamtion.Location = new global::System.Drawing.Point(1, 19);
			this.pbBoardInforamtion.Margin = new global::System.Windows.Forms.Padding(1);
			this.pbBoardInforamtion.Name = "pbBoardInforamtion";
			this.pbBoardInforamtion.Padding = new global::System.Windows.Forms.Padding(1);
			this.pbBoardInforamtion.Size = new global::System.Drawing.Size(73, 46);
			this.pbBoardInforamtion.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbBoardInforamtion.TabIndex = 99;
			this.pbBoardInforamtion.TabStop = false;
			this.pbBoardInforamtion.Click += new global::System.EventHandler(this.pbBoardInforamtion_Click);
			this.pbBoardInforamtion.MouseEnter += new global::System.EventHandler(this.pbBoardInforamtion_MouseEnter);
			this.pbBoardInforamtion.MouseLeave += new global::System.EventHandler(this.pbBoardInforamtion_MouseLeave);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel6.Location = new global::System.Drawing.Point(168, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(10, 68);
			this.panel6.TabIndex = 103;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1287, 874);
			base.Controls.Add(this.panel_PDF);
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.panel1);
			base.MinimizeBox = false;
			base.Name = "cAction";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AectionForm";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.cAction_FormClosing);
			base.Shown += new global::System.EventHandler(this.cAction_Shown);
			this.tabControl1.ResumeLayout(false);
			this.tpReport.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel60.ResumeLayout(false);
			this.pnLeft.ResumeLayout(false);
			this.panel30.ResumeLayout(false);
			this.pnEdit.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbEdite).EndInit();
			this.panel10.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbView).EndInit();
			this.pnDelete.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbDelete).EndInit();
			this.tpAction.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.pnActionOtehr.ResumeLayout(false);
			this.pnActionOtehr.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel27.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbHold).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbSubmit).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel_PDF.ResumeLayout(false);
			this.gbBoardSiteMap.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbBoardInforamtion).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400019C RID: 412
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400019D RID: 413
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x0400019E RID: 414
		private global::System.Windows.Forms.Button btnHold;

		// Token: 0x0400019F RID: 415
		private global::System.Windows.Forms.Button btnSummit;

		// Token: 0x040001A0 RID: 416
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040001A1 RID: 417
		private global::System.Windows.Forms.TextBox tbReport;

		// Token: 0x040001A2 RID: 418
		private global::System.Windows.Forms.TextBox tbFrom;

		// Token: 0x040001A3 RID: 419
		private global::System.Windows.Forms.TextBox tbFromAction;

		// Token: 0x040001A4 RID: 420
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001A5 RID: 421
		private global::System.Windows.Forms.Button btnClear;

		// Token: 0x040001A6 RID: 422
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x040001A7 RID: 423
		private global::System.Windows.Forms.TabPage tpReport;

		// Token: 0x040001A8 RID: 424
		private global::System.Windows.Forms.TabPage tpAction;

		// Token: 0x040001A9 RID: 425
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040001AA RID: 426
		private global::System.Windows.Forms.Panel pnLeft;

		// Token: 0x040001AB RID: 427
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040001AC RID: 428
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x040001AD RID: 429
		private global::System.Windows.Forms.Panel panel27;

		// Token: 0x040001AE RID: 430
		private global::System.Windows.Forms.Panel pnActionOtehr;

		// Token: 0x040001AF RID: 431
		private global::System.Windows.Forms.Panel panel_PDF;

		// Token: 0x040001B0 RID: 432
		private global::System.Windows.Forms.WebBrowser web_Viewer;

		// Token: 0x040001B1 RID: 433
		private global::System.Windows.Forms.Button btn_close;

		// Token: 0x040001B2 RID: 434
		private global::System.Windows.Forms.PictureBox pbDelete;

		// Token: 0x040001B3 RID: 435
		private global::System.Windows.Forms.Panel panel30;

		// Token: 0x040001B4 RID: 436
		private global::System.Windows.Forms.PictureBox pbEdite;

		// Token: 0x040001B5 RID: 437
		private global::System.Windows.Forms.Panel panel35;

		// Token: 0x040001B6 RID: 438
		private global::System.Windows.Forms.PictureBox pbView;

		// Token: 0x040001B7 RID: 439
		private global::System.Windows.Forms.Panel panel36;

		// Token: 0x040001B8 RID: 440
		private global::System.Windows.Forms.PictureBox pbClear;

		// Token: 0x040001B9 RID: 441
		private global::System.Windows.Forms.Panel panel38;

		// Token: 0x040001BA RID: 442
		private global::System.Windows.Forms.PictureBox pbHold;

		// Token: 0x040001BB RID: 443
		private global::System.Windows.Forms.PictureBox pbSubmit;

		// Token: 0x040001BC RID: 444
		private global::System.Windows.Forms.TextBox tbCase;

		// Token: 0x040001BD RID: 445
		private global::System.Windows.Forms.Panel panel13;

		// Token: 0x040001BE RID: 446
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040001BF RID: 447
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040001C0 RID: 448
		private global::System.Windows.Forms.Panel pnRequestInformation;

		// Token: 0x040001C1 RID: 449
		private global::System.Windows.Forms.Panel panel60;

		// Token: 0x040001C2 RID: 450
		private global::System.Windows.Forms.Panel pnUserInformation;

		// Token: 0x040001C3 RID: 451
		private global::System.Windows.Forms.Panel pnAttachment;

		// Token: 0x040001C4 RID: 452
		private global::System.Windows.Forms.Panel pnRight;

		// Token: 0x040001C5 RID: 453
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x040001C6 RID: 454
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040001C7 RID: 455
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x040001C8 RID: 456
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040001C9 RID: 457
		private global::System.Windows.Forms.Panel pnEdit;

		// Token: 0x040001CA RID: 458
		private global::System.Windows.Forms.Label lbEdite;

		// Token: 0x040001CB RID: 459
		private global::System.Windows.Forms.Panel pnDelete;

		// Token: 0x040001CC RID: 460
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040001CD RID: 461
		private global::System.Windows.Forms.Panel panel;

		// Token: 0x040001CE RID: 462
		private global::System.Windows.Forms.Panel pnActionInformation;

		// Token: 0x040001CF RID: 463
		private global::System.Windows.Forms.Panel pnActionContent;

		// Token: 0x040001D0 RID: 464
		private global::System.Windows.Forms.Panel pnPart;

		// Token: 0x040001D1 RID: 465
		private global::System.Windows.Forms.Panel pnActionHcc;

		// Token: 0x040001D2 RID: 466
		private global::System.Windows.Forms.Panel pnBoardInformation;

		// Token: 0x040001D3 RID: 467
		private global::System.Windows.Forms.TabPage tpConfirmation;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.GroupBox gbBoardSiteMap;

		// Token: 0x040001D5 RID: 469
		private global::System.Windows.Forms.PictureBox pbBoardInforamtion;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.Panel panel6;
	}
}
