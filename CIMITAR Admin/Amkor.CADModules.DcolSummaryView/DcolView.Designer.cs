namespace Amkor.CADModules.DcolSummaryView
{
	// Token: 0x0200000D RID: 13
	public partial class DcolView : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000061C6 File Offset: 0x000043C6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000061E8 File Offset: 0x000043E8
		private void InitializeComponent()
		{
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label12 = new global::System.Windows.Forms.Label();
			this.panel15 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.splitter8 = new global::System.Windows.Forms.Splitter();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.backgroundWorker1 = new global::System.ComponentModel.BackgroundWorker();
			this.radThemeManager1 = new global::Telerik.WinControls.RadThemeManager();
			this.documentWindow2 = new global::Telerik.WinControls.UI.Docking.DocumentWindow();
			this.documentTabStrip1 = new global::Telerik.WinControls.UI.Docking.DocumentTabStrip();
			this.documentWindow1 = new global::Telerik.WinControls.UI.Docking.DocumentWindow();
			this.telerikMetroTheme1 = new global::Telerik.WinControls.Themes.TelerikMetroTheme();
			this.office2010BlueTheme1 = new global::Telerik.WinControls.Themes.Office2010BlueTheme();
			this.telerikMetroBlueTheme1 = new global::Telerik.WinControls.Themes.TelerikMetroBlueTheme();
			this.toolTabStrip2 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.toolTabStrip1 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.toolTabStrip5 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.toolTabStrip6 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.openFileDialog1 = new global::System.Windows.Forms.OpenFileDialog();
			this.radPageView1 = new global::Telerik.WinControls.UI.RadPageView();
			this.radPanel2 = new global::Telerik.WinControls.UI.RadPanel();
			this.txtLot = new global::Telerik.WinControls.UI.RadTextBox();
			this.radLabel5 = new global::Telerik.WinControls.UI.RadLabel();
			this.radLabel3 = new global::Telerik.WinControls.UI.RadLabel();
			this.dateTimeEnd = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.dateTimeStart = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnSearch = new global::Telerik.WinControls.UI.RadButton();
			this.btnSave = new global::Telerik.WinControls.UI.RadButton();
			this.panel3.SuspendLayout();
			this.panel15.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.documentTabStrip1).BeginInit();
			this.documentTabStrip1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip5).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip6).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPageView1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel2).BeginInit();
			this.radPanel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.txtLot).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel5).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dateTimeEnd).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dateTimeStart).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnSave).BeginInit();
			base.SuspendLayout();
			this.panel3.Controls.Add(this.label12);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1384, 30);
			this.panel3.TabIndex = 15;
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold);
			this.label12.Location = new global::System.Drawing.Point(12, 5);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(123, 21);
			this.label12.TabIndex = 15;
			this.label12.Text = "Dcol Summary";
			this.panel15.Controls.Add(this.label13);
			this.panel15.Controls.Add(this.splitter8);
			this.panel15.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel15.Location = new global::System.Drawing.Point(0, 729);
			this.panel15.Name = "panel15";
			this.panel15.Size = new global::System.Drawing.Size(1384, 32);
			this.panel15.TabIndex = 21;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(524, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(368, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2018 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.splitter8.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter8.Location = new global::System.Drawing.Point(0, 0);
			this.splitter8.Name = "splitter8";
			this.splitter8.Size = new global::System.Drawing.Size(1384, 3);
			this.splitter8.TabIndex = 14;
			this.splitter8.TabStop = false;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.documentWindow2.CloseAction = global::Telerik.WinControls.UI.Docking.DockWindowCloseAction.Hide;
			this.documentWindow2.DesiredDockState = global::Telerik.WinControls.UI.Docking.DockState.Hidden;
			this.documentWindow2.DocumentButtons = global::Telerik.WinControls.UI.Docking.DocumentStripButtons.ActiveWindowList;
			this.documentWindow2.Location = new global::System.Drawing.Point(6, 29);
			this.documentWindow2.Name = "documentWindow2";
			this.documentWindow2.PreviousDockState = global::Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
			this.documentWindow2.Size = new global::System.Drawing.Size(752, 466);
			this.documentWindow2.Text = "documentWindow2";
			this.documentTabStrip1.CanUpdateChildIndex = true;
			this.documentTabStrip1.Controls.Add(this.documentWindow1);
			this.documentTabStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.documentTabStrip1.Name = "documentTabStrip1";
			this.documentTabStrip1.RootElement.MinSize = new global::System.Drawing.Size(25, 25);
			this.documentTabStrip1.SelectedIndex = 0;
			this.documentTabStrip1.Size = new global::System.Drawing.Size(742, 501);
			this.documentTabStrip1.TabIndex = 0;
			this.documentTabStrip1.TabStop = false;
			this.documentWindow1.DocumentButtons = global::Telerik.WinControls.UI.Docking.DocumentStripButtons.ActiveWindowList;
			this.documentWindow1.Location = new global::System.Drawing.Point(4, 4);
			this.documentWindow1.Name = "documentWindow1";
			this.documentWindow1.PreviousDockState = global::Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
			this.documentWindow1.Size = new global::System.Drawing.Size(734, 493);
			this.documentWindow1.Text = "documentWindow1";
			this.toolTabStrip2.CanUpdateChildIndex = true;
			this.toolTabStrip2.Location = new global::System.Drawing.Point(0, 0);
			this.toolTabStrip2.Name = "toolTabStrip2";
			this.toolTabStrip2.RootElement.MinSize = new global::System.Drawing.Size(25, 25);
			this.toolTabStrip2.SelectedIndex = 0;
			this.toolTabStrip2.Size = new global::System.Drawing.Size(200, 200);
			this.toolTabStrip2.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(296, 200);
			this.toolTabStrip2.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(96, 0);
			this.toolTabStrip2.TabIndex = 0;
			this.toolTabStrip2.TabStop = false;
			this.toolTabStrip2.ThemeName = "TelerikMetroBlue";
			this.toolTabStrip1.CanUpdateChildIndex = true;
			this.toolTabStrip1.CausesValidation = false;
			this.toolTabStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.toolTabStrip1.Name = "toolTabStrip1";
			this.toolTabStrip1.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.toolTabStrip1.Size = new global::System.Drawing.Size(296, 579);
			this.toolTabStrip1.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(296, 200);
			this.toolTabStrip1.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(96, 0);
			this.toolTabStrip1.TabIndex = 3;
			this.toolTabStrip1.TabStop = false;
			this.toolTabStrip1.ThemeName = "TelerikMetroBlue";
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.toolTabStrip1.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.FromArgb(0, 156, 20, 20);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.toolTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			this.toolTabStrip5.CanUpdateChildIndex = true;
			this.toolTabStrip5.Location = new global::System.Drawing.Point(0, 0);
			this.toolTabStrip5.Name = "toolTabStrip5";
			this.toolTabStrip5.RootElement.MinSize = new global::System.Drawing.Size(25, 25);
			this.toolTabStrip5.SelectedIndex = 0;
			this.toolTabStrip5.Size = new global::System.Drawing.Size(200, 200);
			this.toolTabStrip5.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(296, 200);
			this.toolTabStrip5.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(96, 0);
			this.toolTabStrip5.TabIndex = 0;
			this.toolTabStrip5.TabStop = false;
			this.toolTabStrip5.ThemeName = "TelerikMetroBlue";
			this.toolTabStrip6.CanUpdateChildIndex = true;
			this.toolTabStrip6.Location = new global::System.Drawing.Point(0, 0);
			this.toolTabStrip6.Name = "toolTabStrip6";
			this.toolTabStrip6.RootElement.MinSize = new global::System.Drawing.Size(25, 25);
			this.toolTabStrip6.SelectedIndex = 0;
			this.toolTabStrip6.Size = new global::System.Drawing.Size(200, 200);
			this.toolTabStrip6.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(106, 200);
			this.toolTabStrip6.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(-94, 0);
			this.toolTabStrip6.TabIndex = 0;
			this.toolTabStrip6.TabStop = false;
			this.toolTabStrip6.ThemeName = "TelerikMetroBlue";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.radPageView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPageView1.Location = new global::System.Drawing.Point(0, 71);
			this.radPageView1.Name = "radPageView1";
			this.radPageView1.Size = new global::System.Drawing.Size(1384, 658);
			this.radPageView1.TabIndex = 25;
			this.radPageView1.Text = "radPageView1";
			this.radPageView1.ThemeName = "TelerikMetroBlue";
			this.radPageView1.NewPageRequested += new global::System.EventHandler(this.radPageView1_NewPageRequested);
			((global::Telerik.WinControls.UI.RadPageViewStripElement)this.radPageView1.GetChildAt(0)).ItemDragMode = global::Telerik.WinControls.UI.PageViewItemDragMode.Preview;
			this.radPanel2.BackColor = global::System.Drawing.Color.White;
			this.radPanel2.Controls.Add(this.txtLot);
			this.radPanel2.Controls.Add(this.radLabel5);
			this.radPanel2.Controls.Add(this.radLabel3);
			this.radPanel2.Controls.Add(this.dateTimeEnd);
			this.radPanel2.Controls.Add(this.dateTimeStart);
			this.radPanel2.Controls.Add(this.label1);
			this.radPanel2.Controls.Add(this.btnSearch);
			this.radPanel2.Controls.Add(this.btnSave);
			this.radPanel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.radPanel2.Location = new global::System.Drawing.Point(0, 30);
			this.radPanel2.Name = "radPanel2";
			this.radPanel2.Size = new global::System.Drawing.Size(1384, 41);
			this.radPanel2.TabIndex = 26;
			this.radPanel2.Visible = false;
			this.txtLot.Location = new global::System.Drawing.Point(296, 12);
			this.txtLot.Name = "txtLot";
			this.txtLot.Size = new global::System.Drawing.Size(242, 20);
			this.txtLot.TabIndex = 174;
			this.radLabel5.Location = new global::System.Drawing.Point(268, 13);
			this.radLabel5.Name = "radLabel5";
			this.radLabel5.Size = new global::System.Drawing.Size(22, 18);
			this.radLabel5.TabIndex = 173;
			this.radLabel5.Text = "Lot";
			this.radLabel3.Location = new global::System.Drawing.Point(12, 13);
			this.radLabel3.Name = "radLabel3";
			this.radLabel3.Size = new global::System.Drawing.Size(30, 18);
			this.radLabel3.TabIndex = 172;
			this.radLabel3.Text = "Date";
			this.dateTimeEnd.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimeEnd.Location = new global::System.Drawing.Point(170, 12);
			this.dateTimeEnd.Name = "dateTimeEnd";
			this.dateTimeEnd.Size = new global::System.Drawing.Size(92, 20);
			this.dateTimeEnd.TabIndex = 170;
			this.dateTimeEnd.TabStop = false;
			this.dateTimeEnd.Text = "2020-04-03";
			this.dateTimeEnd.Value = new global::System.DateTime(2020, 4, 3, 15, 36, 44, 994);
			this.dateTimeStart.CustomFormat = "yyyy-MM-dd";
			this.dateTimeStart.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimeStart.Location = new global::System.Drawing.Point(51, 12);
			this.dateTimeStart.Name = "dateTimeStart";
			this.dateTimeStart.Size = new global::System.Drawing.Size(92, 20);
			this.dateTimeStart.TabIndex = 169;
			this.dateTimeStart.TabStop = false;
			this.dateTimeStart.Text = "2020-04-03";
			this.dateTimeStart.Value = new global::System.DateTime(2020, 4, 3, 0, 0, 0, 0);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(149, 14);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(15, 13);
			this.label1.TabIndex = 171;
			this.label1.Text = "~";
			this.btnSearch.Location = new global::System.Drawing.Point(544, 6);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new global::System.Drawing.Size(53, 29);
			this.btnSearch.TabIndex = 166;
			this.btnSearch.Text = "Search";
			this.btnSearch.ThemeName = "TelerikMetroBlue";
			this.btnSearch.Click += new global::System.EventHandler(this.btnSearch_Click);
			this.btnSave.Location = new global::System.Drawing.Point(603, 6);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new global::System.Drawing.Size(50, 29);
			this.btnSave.TabIndex = 164;
			this.btnSave.Text = "Save";
			this.btnSave.ThemeName = "TelerikMetroBlue";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1384, 761);
			base.Controls.Add(this.radPageView1);
			base.Controls.Add(this.radPanel2);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel15);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Name = "DcolView";
			this.Text = "Dcol Summary";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.UnitDataAnalysis_FormClosing);
			base.Load += new global::System.EventHandler(this.ParameterAnalysis_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel15.ResumeLayout(false);
			this.panel15.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.documentTabStrip1).EndInit();
			this.documentTabStrip1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip5).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip6).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPageView1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel2).EndInit();
			this.radPanel2.ResumeLayout(false);
			this.radPanel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.txtLot).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel5).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dateTimeEnd).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dateTimeStart).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnSave).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000046 RID: 70
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.Splitter splitter8;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x0400004D RID: 77
		private global::System.ComponentModel.BackgroundWorker backgroundWorker1;

		// Token: 0x0400004E RID: 78
		private global::Telerik.WinControls.RadThemeManager radThemeManager1;

		// Token: 0x0400004F RID: 79
		private global::Telerik.WinControls.UI.Docking.DocumentWindow documentWindow2;

		// Token: 0x04000050 RID: 80
		private global::Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;

		// Token: 0x04000051 RID: 81
		private global::Telerik.WinControls.UI.Docking.DocumentWindow documentWindow1;

		// Token: 0x04000052 RID: 82
		private global::Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;

		// Token: 0x04000053 RID: 83
		private global::Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;

		// Token: 0x04000054 RID: 84
		private global::Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;

		// Token: 0x04000055 RID: 85
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip2;

		// Token: 0x04000056 RID: 86
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip1;

		// Token: 0x04000057 RID: 87
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip5;

		// Token: 0x04000058 RID: 88
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip6;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.OpenFileDialog openFileDialog1;

		// Token: 0x0400005A RID: 90
		private global::Telerik.WinControls.UI.RadPageView radPageView1;

		// Token: 0x0400005B RID: 91
		private global::Telerik.WinControls.UI.RadPanel radPanel2;

		// Token: 0x0400005C RID: 92
		private global::Telerik.WinControls.UI.RadButton btnSearch;

		// Token: 0x0400005D RID: 93
		private global::Telerik.WinControls.UI.RadButton btnSave;

		// Token: 0x0400005E RID: 94
		private global::Telerik.WinControls.UI.RadLabel radLabel3;

		// Token: 0x0400005F RID: 95
		private global::Telerik.WinControls.UI.RadDateTimePicker dateTimeEnd;

		// Token: 0x04000060 RID: 96
		private global::Telerik.WinControls.UI.RadDateTimePicker dateTimeStart;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000062 RID: 98
		private global::Telerik.WinControls.UI.RadTextBox txtLot;

		// Token: 0x04000063 RID: 99
		private global::Telerik.WinControls.UI.RadLabel radLabel5;
	}
}
