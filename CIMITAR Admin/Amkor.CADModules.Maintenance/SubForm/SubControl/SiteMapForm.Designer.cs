namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x0200003B RID: 59
	public partial class SiteMapForm : global::System.Windows.Forms.Form, global::Amkor.CADModules.Maintenance.GrobalConst.Interface.IHCC
	{
		// Token: 0x060003C1 RID: 961 RVA: 0x00070178 File Offset: 0x0006E378
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x000701B0 File Offset: 0x0006E3B0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.Maintenance.SubForm.SubControl.SiteMapForm));
			this.pnBase = new global::System.Windows.Forms.Panel();
			this.pnSiteMapBase = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.lbHCCLocation = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.cbRejectView = new global::System.Windows.Forms.CheckBox();
			this.cbRealSiteMap = new global::System.Windows.Forms.CheckBox();
			this.rbAllSiteReject = new global::System.Windows.Forms.RadioButton();
			this.rbAllSiteGood = new global::System.Windows.Forms.RadioButton();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.pnDisableColor = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.pnAlreadyReject = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.pnRejectColor = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.pnGoodColor = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.pnSiteMapDirection = new global::System.Windows.Forms.PictureBox();
			this.lbSummary = new global::System.Windows.Forms.Label();
			this.pnSubBase = new global::System.Windows.Forms.Panel();
			this.pnSiteChart = new global::System.Windows.Forms.PictureBox();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.pbOK = new global::System.Windows.Forms.PictureBox();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.pbCancel = new global::System.Windows.Forms.PictureBox();
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.SiteMapLayout = new global::Amkor.CADModules.Maintenance.SubForm.SubControl.DoubleBufferTableLayoutPanel();
			this.pnBase.SuspendLayout();
			this.pnSiteMapBase.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.pnDisableColor.SuspendLayout();
			this.pnAlreadyReject.SuspendLayout();
			this.pnRejectColor.SuspendLayout();
			this.pnGoodColor.SuspendLayout();
			this.panel3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pnSiteMapDirection).BeginInit();
			this.pnSubBase.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pnSiteChart).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbOK).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).BeginInit();
			base.SuspendLayout();
			this.pnBase.Controls.Add(this.pnSiteMapBase);
			this.pnBase.Controls.Add(this.panel1);
			this.pnBase.Controls.Add(this.pnSubBase);
			this.pnBase.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnBase.Location = new global::System.Drawing.Point(0, 0);
			this.pnBase.Name = "pnBase";
			this.pnBase.Size = new global::System.Drawing.Size(1138, 535);
			this.pnBase.TabIndex = 0;
			this.pnSiteMapBase.AutoScroll = true;
			this.pnSiteMapBase.AutoSize = true;
			this.pnSiteMapBase.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnSiteMapBase.BackColor = global::System.Drawing.Color.White;
			this.pnSiteMapBase.Controls.Add(this.SiteMapLayout);
			this.pnSiteMapBase.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnSiteMapBase.Location = new global::System.Drawing.Point(0, 29);
			this.pnSiteMapBase.Name = "pnSiteMapBase";
			this.pnSiteMapBase.Size = new global::System.Drawing.Size(1138, 456);
			this.pnSiteMapBase.TabIndex = 4;
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(1);
			this.panel1.Size = new global::System.Drawing.Size(1138, 29);
			this.panel1.TabIndex = 5;
			this.tableLayoutPanel1.CellBorderStyle = global::System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 30.61728f));
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 69.38271f));
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 323f));
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 381f));
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 3, 0);
			this.tableLayoutPanel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new global::System.Drawing.Point(1, 1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel1.Size = new global::System.Drawing.Size(1136, 27);
			this.tableLayoutPanel1.TabIndex = 2;
			this.tableLayoutPanel1.Click += new global::System.EventHandler(this.rbAllSiteGood_CheckedChanged);
			this.panel4.Controls.Add(this.lbHCCLocation);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new global::System.Drawing.Point(1, 1);
			this.panel4.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(130, 25);
			this.panel4.TabIndex = 3;
			this.lbHCCLocation.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.lbHCCLocation.Location = new global::System.Drawing.Point(0, 0);
			this.lbHCCLocation.Name = "lbHCCLocation";
			this.lbHCCLocation.Size = new global::System.Drawing.Size(130, 25);
			this.lbHCCLocation.TabIndex = 0;
			this.lbHCCLocation.Text = "Location : ";
			this.lbHCCLocation.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.panel2.Controls.Add(this.cbRejectView);
			this.panel2.Controls.Add(this.cbRealSiteMap);
			this.panel2.Controls.Add(this.rbAllSiteReject);
			this.panel2.Controls.Add(this.rbAllSiteGood);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(132, 1);
			this.panel2.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new global::System.Windows.Forms.Padding(1);
			this.panel2.Size = new global::System.Drawing.Size(296, 25);
			this.panel2.TabIndex = 1;
			this.cbRejectView.AutoSize = true;
			this.cbRejectView.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.cbRejectView.Location = new global::System.Drawing.Point(291, 1);
			this.cbRejectView.Name = "cbRejectView";
			this.cbRejectView.Size = new global::System.Drawing.Size(91, 23);
			this.cbRejectView.TabIndex = 9;
			this.cbRejectView.Text = "Reject View";
			this.cbRejectView.UseVisualStyleBackColor = true;
			this.cbRejectView.Visible = false;
			this.cbRejectView.CheckedChanged += new global::System.EventHandler(this.cbRejectView_CheckedChanged);
			this.cbRealSiteMap.AutoSize = true;
			this.cbRealSiteMap.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.cbRealSiteMap.Location = new global::System.Drawing.Point(188, 1);
			this.cbRealSiteMap.Name = "cbRealSiteMap";
			this.cbRealSiteMap.Size = new global::System.Drawing.Size(103, 23);
			this.cbRealSiteMap.TabIndex = 10;
			this.cbRealSiteMap.Text = "Real Site Map";
			this.cbRealSiteMap.UseVisualStyleBackColor = true;
			this.cbRealSiteMap.CheckedChanged += new global::System.EventHandler(this.cbRealSiteMap_CheckedChanged);
			this.rbAllSiteReject.AutoSize = true;
			this.rbAllSiteReject.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.rbAllSiteReject.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbAllSiteReject.Location = new global::System.Drawing.Point(102, 1);
			this.rbAllSiteReject.Name = "rbAllSiteReject";
			this.rbAllSiteReject.Size = new global::System.Drawing.Size(86, 23);
			this.rbAllSiteReject.TabIndex = 8;
			this.rbAllSiteReject.TabStop = true;
			this.rbAllSiteReject.Text = "All Site Fail";
			this.rbAllSiteReject.UseVisualStyleBackColor = true;
			this.rbAllSiteReject.CheckedChanged += new global::System.EventHandler(this.rbAllSiteFail_CheckedChanged);
			this.rbAllSiteGood.AutoSize = true;
			this.rbAllSiteGood.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.rbAllSiteGood.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbAllSiteGood.Location = new global::System.Drawing.Point(1, 1);
			this.rbAllSiteGood.Name = "rbAllSiteGood";
			this.rbAllSiteGood.Padding = new global::System.Windows.Forms.Padding(5, 0, 0, 0);
			this.rbAllSiteGood.Size = new global::System.Drawing.Size(101, 23);
			this.rbAllSiteGood.TabIndex = 7;
			this.rbAllSiteGood.TabStop = true;
			this.rbAllSiteGood.Text = "All Site Good";
			this.rbAllSiteGood.UseVisualStyleBackColor = true;
			this.rbAllSiteGood.CheckedChanged += new global::System.EventHandler(this.rbAllSiteGood_CheckedChanged);
			this.panel5.Controls.Add(this.pnDisableColor);
			this.panel5.Controls.Add(this.pnAlreadyReject);
			this.panel5.Controls.Add(this.pnRejectColor);
			this.panel5.Controls.Add(this.pnGoodColor);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new global::System.Drawing.Point(429, 1);
			this.panel5.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new global::System.Windows.Forms.Padding(1);
			this.panel5.Size = new global::System.Drawing.Size(323, 25);
			this.panel5.TabIndex = 4;
			this.pnDisableColor.BackColor = global::System.Drawing.Color.Gray;
			this.pnDisableColor.Controls.Add(this.label5);
			this.pnDisableColor.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnDisableColor.Location = new global::System.Drawing.Point(266, 1);
			this.pnDisableColor.Name = "pnDisableColor";
			this.pnDisableColor.Padding = new global::System.Windows.Forms.Padding(2, 0, 0, 0);
			this.pnDisableColor.Size = new global::System.Drawing.Size(53, 23);
			this.pnDisableColor.TabIndex = 5;
			this.label5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label5.Font = new global::System.Drawing.Font("휴먼둥근헤드라인", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.label5.Location = new global::System.Drawing.Point(2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(51, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "D";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.label5, "Disable");
			this.pnAlreadyReject.BackColor = global::System.Drawing.Color.Red;
			this.pnAlreadyReject.Controls.Add(this.label4);
			this.pnAlreadyReject.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnAlreadyReject.Location = new global::System.Drawing.Point(107, 1);
			this.pnAlreadyReject.Name = "pnAlreadyReject";
			this.pnAlreadyReject.Padding = new global::System.Windows.Forms.Padding(2, 0, 0, 0);
			this.pnAlreadyReject.Size = new global::System.Drawing.Size(159, 23);
			this.pnAlreadyReject.TabIndex = 4;
			this.label4.BackColor = global::System.Drawing.Color.Orange;
			this.label4.Font = new global::System.Drawing.Font("휴먼둥근헤드라인", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.label4.Location = new global::System.Drawing.Point(2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(156, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "R(overlapped)";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.label4, "Reject(has a variety of Rejects)");
			this.pnRejectColor.BackColor = global::System.Drawing.Color.Red;
			this.pnRejectColor.Controls.Add(this.label3);
			this.pnRejectColor.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnRejectColor.Location = new global::System.Drawing.Point(54, 1);
			this.pnRejectColor.Name = "pnRejectColor";
			this.pnRejectColor.Padding = new global::System.Windows.Forms.Padding(2, 0, 0, 0);
			this.pnRejectColor.Size = new global::System.Drawing.Size(53, 23);
			this.pnRejectColor.TabIndex = 1;
			this.label3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new global::System.Drawing.Font("휴먼둥근헤드라인", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.label3.Location = new global::System.Drawing.Point(2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(51, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "R";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.label3, "Reject(has only one reject)");
			this.pnGoodColor.BackColor = global::System.Drawing.Color.Green;
			this.pnGoodColor.Controls.Add(this.label2);
			this.pnGoodColor.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnGoodColor.Location = new global::System.Drawing.Point(1, 1);
			this.pnGoodColor.Name = "pnGoodColor";
			this.pnGoodColor.Size = new global::System.Drawing.Size(53, 23);
			this.pnGoodColor.TabIndex = 0;
			this.label2.BackColor = global::System.Drawing.Color.LimeGreen;
			this.label2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new global::System.Drawing.Font("휴먼둥근헤드라인", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.label2.Location = new global::System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(53, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "G";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.label2, "Good");
			this.panel3.Controls.Add(this.pnSiteMapDirection);
			this.panel3.Controls.Add(this.lbSummary);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(753, 1);
			this.panel3.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(382, 25);
			this.panel3.TabIndex = 5;
			this.pnSiteMapDirection.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnSiteMapDirection.Location = new global::System.Drawing.Point(228, 0);
			this.pnSiteMapDirection.Name = "pnSiteMapDirection";
			this.pnSiteMapDirection.Size = new global::System.Drawing.Size(46, 25);
			this.pnSiteMapDirection.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pnSiteMapDirection.TabIndex = 5;
			this.pnSiteMapDirection.TabStop = false;
			this.pnSiteMapDirection.Visible = false;
			this.lbSummary.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.lbSummary.Location = new global::System.Drawing.Point(0, 0);
			this.lbSummary.Name = "lbSummary";
			this.lbSummary.Size = new global::System.Drawing.Size(228, 25);
			this.lbSummary.TabIndex = 0;
			this.lbSummary.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.pnSubBase.Controls.Add(this.pnSiteChart);
			this.pnSubBase.Controls.Add(this.panel6);
			this.pnSubBase.Controls.Add(this.pbOK);
			this.pnSubBase.Controls.Add(this.panel18);
			this.pnSubBase.Controls.Add(this.pbCancel);
			this.pnSubBase.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.pnSubBase.Location = new global::System.Drawing.Point(0, 485);
			this.pnSubBase.Name = "pnSubBase";
			this.pnSubBase.Size = new global::System.Drawing.Size(1138, 50);
			this.pnSubBase.TabIndex = 3;
			this.pnSiteChart.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pnSiteChart.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pnSiteChart.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.analysis;
			this.pnSiteChart.InitialImage = (global::System.Drawing.Image)componentResourceManager.GetObject("pnSiteChart.InitialImage");
			this.pnSiteChart.Location = new global::System.Drawing.Point(948, 0);
			this.pnSiteChart.Name = "pnSiteChart";
			this.pnSiteChart.Padding = new global::System.Windows.Forms.Padding(3);
			this.pnSiteChart.Size = new global::System.Drawing.Size(48, 50);
			this.pnSiteChart.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pnSiteChart.TabIndex = 56;
			this.pnSiteChart.TabStop = false;
			this.toolTip1.SetToolTip(this.pnSiteChart, "Site Reject Trend");
			this.pnSiteChart.Visible = false;
			this.pnSiteChart.Click += new global::System.EventHandler(this.pnSiteChart_Click);
			this.pnSiteChart.MouseEnter += new global::System.EventHandler(this.pnSiteChart_MouseEnter);
			this.pnSiteChart.MouseLeave += new global::System.EventHandler(this.pnSiteChart_MouseLeave);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel6.Location = new global::System.Drawing.Point(996, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(23, 50);
			this.panel6.TabIndex = 55;
			this.pbOK.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbOK.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbOK.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbOK.Image");
			this.pbOK.InitialImage = (global::System.Drawing.Image)componentResourceManager.GetObject("pbOK.InitialImage");
			this.pbOK.Location = new global::System.Drawing.Point(1019, 0);
			this.pbOK.Name = "pbOK";
			this.pbOK.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbOK.Size = new global::System.Drawing.Size(48, 50);
			this.pbOK.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbOK.TabIndex = 53;
			this.pbOK.TabStop = false;
			this.pbOK.Click += new global::System.EventHandler(this.pbOK_Click);
			this.pbOK.MouseEnter += new global::System.EventHandler(this.pbOK_MouseEnter);
			this.pbOK.MouseLeave += new global::System.EventHandler(this.pbOK_MouseLeave);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel18.Location = new global::System.Drawing.Point(1067, 0);
			this.panel18.Name = "panel18";
			this.panel18.Size = new global::System.Drawing.Size(23, 50);
			this.panel18.TabIndex = 54;
			this.pbCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbCancel.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbCancel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbCancel.Image");
			this.pbCancel.InitialImage = (global::System.Drawing.Image)componentResourceManager.GetObject("pbCancel.InitialImage");
			this.pbCancel.Location = new global::System.Drawing.Point(1090, 0);
			this.pbCancel.Name = "pbCancel";
			this.pbCancel.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbCancel.Size = new global::System.Drawing.Size(48, 50);
			this.pbCancel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbCancel.TabIndex = 47;
			this.pbCancel.TabStop = false;
			this.pbCancel.Click += new global::System.EventHandler(this.pbCancel_Click);
			this.pbCancel.MouseEnter += new global::System.EventHandler(this.pbCancel_MouseEnter);
			this.pbCancel.MouseLeave += new global::System.EventHandler(this.pbCancel_MouseLeave);
			this.SiteMapLayout.AutoSize = true;
			this.SiteMapLayout.CellBorderStyle = global::System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.SiteMapLayout.ColumnCount = 1;
			this.SiteMapLayout.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.SiteMapLayout.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.SiteMapLayout.Location = new global::System.Drawing.Point(0, 0);
			this.SiteMapLayout.Name = "SiteMapLayout";
			this.SiteMapLayout.RowCount = 1;
			this.SiteMapLayout.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.SiteMapLayout.Size = new global::System.Drawing.Size(1138, 2);
			this.SiteMapLayout.TabIndex = 0;
			this.SiteMapLayout.ControlAdded += new global::System.Windows.Forms.ControlEventHandler(this.SiteMapLayout_ControlAdded);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1138, 535);
			base.Controls.Add(this.pnBase);
			base.MinimizeBox = false;
			base.Name = "SiteMapForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SiteMap";
			base.Shown += new global::System.EventHandler(this.SiteMapForm_Shown);
			this.pnBase.ResumeLayout(false);
			this.pnBase.PerformLayout();
			this.pnSiteMapBase.ResumeLayout(false);
			this.pnSiteMapBase.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.pnDisableColor.ResumeLayout(false);
			this.pnAlreadyReject.ResumeLayout(false);
			this.pnRejectColor.ResumeLayout(false);
			this.pnGoodColor.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pnSiteMapDirection).EndInit();
			this.pnSubBase.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pnSiteChart).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbOK).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040005EC RID: 1516
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040005ED RID: 1517
		private global::System.Windows.Forms.PictureBox pbCancel;

		// Token: 0x040005EE RID: 1518
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

		// Token: 0x040005EF RID: 1519
		private global::System.Windows.Forms.RadioButton rbAllSiteReject;

		// Token: 0x040005F0 RID: 1520
		private global::System.Windows.Forms.RadioButton rbAllSiteGood;

		// Token: 0x040005F1 RID: 1521
		private global::System.Windows.Forms.Label lbHCCLocation;

		// Token: 0x040005F2 RID: 1522
		private global::System.Windows.Forms.Panel pnBase;

		// Token: 0x040005F3 RID: 1523
		private global::System.Windows.Forms.Panel pnSiteMapBase;

		// Token: 0x040005F4 RID: 1524
		private global::System.Windows.Forms.Panel pnSubBase;

		// Token: 0x040005F5 RID: 1525
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040005F6 RID: 1526
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040005F7 RID: 1527
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040005F8 RID: 1528
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x040005F9 RID: 1529
		private global::System.Windows.Forms.Panel pnRejectColor;

		// Token: 0x040005FA RID: 1530
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040005FB RID: 1531
		private global::System.Windows.Forms.Panel pnGoodColor;

		// Token: 0x040005FC RID: 1532
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040005FD RID: 1533
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x040005FE RID: 1534
		private global::System.Windows.Forms.PictureBox pbOK;

		// Token: 0x040005FF RID: 1535
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000600 RID: 1536
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000601 RID: 1537
		private global::System.Windows.Forms.Label lbSummary;

		// Token: 0x04000602 RID: 1538
		private global::System.Windows.Forms.CheckBox cbRejectView;

		// Token: 0x04000603 RID: 1539
		private global::System.Windows.Forms.Panel pnAlreadyReject;

		// Token: 0x04000604 RID: 1540
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000605 RID: 1541
		private global::System.Windows.Forms.PictureBox pnSiteMapDirection;

		// Token: 0x04000606 RID: 1542
		private global::System.Windows.Forms.CheckBox cbRealSiteMap;

		// Token: 0x04000607 RID: 1543
		private global::System.Windows.Forms.Panel pnDisableColor;

		// Token: 0x04000608 RID: 1544
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000609 RID: 1545
		private global::System.Windows.Forms.PictureBox pnSiteChart;

		// Token: 0x0400060A RID: 1546
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x0400060B RID: 1547
		private global::Amkor.CADModules.Maintenance.SubForm.SubControl.DoubleBufferTableLayoutPanel SiteMapLayout;
	}
}
