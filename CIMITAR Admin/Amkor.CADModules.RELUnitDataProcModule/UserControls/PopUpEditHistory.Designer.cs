namespace Amkor.CADModules.RELUnitDataProcModule.UserControls
{
	// Token: 0x02000013 RID: 19
	public partial class PopUpEditHistory : global::Telerik.WinControls.UI.RadForm
	{
		// Token: 0x0600009D RID: 157 RVA: 0x000088B4 File Offset: 0x00006AB4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000088EC File Offset: 0x00006AEC
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel9 = new global::System.Windows.Forms.TableLayoutPanel();
			this.btnSearch = new global::Telerik.WinControls.UI.RadButton();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.txtSN = new global::Telerik.WinControls.UI.RadTextBox();
			this.radPanel2 = new global::Telerik.WinControls.UI.RadPanel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel8 = new global::System.Windows.Forms.TableLayoutPanel();
			this.radPanel15 = new global::Telerik.WinControls.UI.RadPanel();
			this.txtLot = new global::Telerik.WinControls.UI.RadTextBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel4 = new global::System.Windows.Forms.TableLayoutPanel();
			this.dtmEndTime = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel3 = new global::System.Windows.Forms.TableLayoutPanel();
			this.dtmStartTime = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.radPanel12 = new global::Telerik.WinControls.UI.RadPanel();
			this.grdUnitHist = new global::Telerik.WinControls.UI.RadGridView();
			this.splitter1 = new global::System.Windows.Forms.Splitter();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel6.SuspendLayout();
			this.tableLayoutPanel9.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).BeginInit();
			this.panel5.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.txtSN).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel2).BeginInit();
			this.panel4.SuspendLayout();
			this.tableLayoutPanel8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel15).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.txtLot).BeginInit();
			this.panel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dtmEndTime).BeginInit();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dtmStartTime).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel12).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.grdUnitHist).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.grdUnitHist.MasterTemplate).BeginInit();
			this.panel7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(328, 670);
			this.panel1.TabIndex = 111;
			this.panel6.Controls.Add(this.tableLayoutPanel9);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new global::System.Drawing.Point(0, 128);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(328, 32);
			this.panel6.TabIndex = 117;
			this.tableLayoutPanel9.ColumnCount = 2;
			this.tableLayoutPanel9.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel9.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel9.Controls.Add(this.btnSearch, 0, 0);
			this.tableLayoutPanel9.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel9.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 1;
			this.tableLayoutPanel9.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel9.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel9.Size = new global::System.Drawing.Size(328, 32);
			this.tableLayoutPanel9.TabIndex = 0;
			this.tableLayoutPanel9.SetColumnSpan(this.btnSearch, 2);
			this.btnSearch.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnSearch.Location = new global::System.Drawing.Point(3, 3);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new global::System.Drawing.Size(322, 26);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Search";
			this.btnSearch.ThemeName = "CIMitarAdmin_Skin";
			this.panel5.Controls.Add(this.tableLayoutPanel1);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(0, 96);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(328, 32);
			this.panel5.TabIndex = 116;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel1.Controls.Add(this.txtSN, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.radPanel2, 0, 0);
			this.tableLayoutPanel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel1.Size = new global::System.Drawing.Size(328, 32);
			this.tableLayoutPanel1.TabIndex = 0;
			this.txtSN.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.txtSN.Location = new global::System.Drawing.Point(167, 3);
			this.txtSN.Name = "txtSN";
			this.txtSN.Padding = new global::System.Windows.Forms.Padding(2, 4, 2, 4);
			this.txtSN.Size = new global::System.Drawing.Size(158, 26);
			this.txtSN.TabIndex = 114;
			this.txtSN.ThemeName = "CIMitarAdmin_Skin";
			this.radPanel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPanel2.Location = new global::System.Drawing.Point(3, 3);
			this.radPanel2.Name = "radPanel2";
			this.radPanel2.Size = new global::System.Drawing.Size(158, 26);
			this.radPanel2.TabIndex = 5;
			this.radPanel2.Text = "S/N";
			this.radPanel2.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.radPanel2.ThemeName = "CIMitarAdmin_Skin";
			this.panel4.Controls.Add(this.tableLayoutPanel8);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 64);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(328, 32);
			this.panel4.TabIndex = 115;
			this.tableLayoutPanel8.ColumnCount = 2;
			this.tableLayoutPanel8.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel8.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel8.Controls.Add(this.radPanel15, 0, 0);
			this.tableLayoutPanel8.Controls.Add(this.txtLot, 1, 0);
			this.tableLayoutPanel8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel8.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 1;
			this.tableLayoutPanel8.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel8.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel8.Size = new global::System.Drawing.Size(328, 32);
			this.tableLayoutPanel8.TabIndex = 0;
			this.radPanel15.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPanel15.Location = new global::System.Drawing.Point(3, 3);
			this.radPanel15.Name = "radPanel15";
			this.radPanel15.Size = new global::System.Drawing.Size(158, 26);
			this.radPanel15.TabIndex = 5;
			this.radPanel15.Text = "Lot";
			this.radPanel15.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.radPanel15.ThemeName = "CIMitarAdmin_Skin";
			this.txtLot.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.txtLot.Location = new global::System.Drawing.Point(167, 3);
			this.txtLot.Name = "txtLot";
			this.txtLot.Padding = new global::System.Windows.Forms.Padding(2, 4, 2, 4);
			this.txtLot.Size = new global::System.Drawing.Size(158, 26);
			this.txtLot.TabIndex = 113;
			this.txtLot.ThemeName = "CIMitarAdmin_Skin";
			this.panel3.Controls.Add(this.tableLayoutPanel4);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 32);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(328, 32);
			this.panel3.TabIndex = 114;
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel4.Controls.Add(this.dtmEndTime, 1, 0);
			this.tableLayoutPanel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel4.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel4.Size = new global::System.Drawing.Size(328, 32);
			this.tableLayoutPanel4.TabIndex = 0;
			this.dtmEndTime.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dtmEndTime.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.dtmEndTime.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtmEndTime.Location = new global::System.Drawing.Point(167, 3);
			this.dtmEndTime.Name = "dtmEndTime";
			this.dtmEndTime.Padding = new global::System.Windows.Forms.Padding(2, 3, 2, 2);
			this.dtmEndTime.Size = new global::System.Drawing.Size(158, 26);
			this.dtmEndTime.TabIndex = 85;
			this.dtmEndTime.TabStop = false;
			this.dtmEndTime.Text = "2020-04-03";
			this.dtmEndTime.ThemeName = "CIMitarAdmin_Skin";
			this.dtmEndTime.Value = new global::System.DateTime(2020, 4, 3, 15, 36, 44, 994);
			this.panel2.Controls.Add(this.tableLayoutPanel3);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(328, 32);
			this.panel2.TabIndex = 113;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel3.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel3.Controls.Add(this.dtmStartTime, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.radPanel12, 0, 0);
			this.tableLayoutPanel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel3.Size = new global::System.Drawing.Size(328, 32);
			this.tableLayoutPanel3.TabIndex = 0;
			this.dtmStartTime.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dtmStartTime.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.dtmStartTime.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtmStartTime.Location = new global::System.Drawing.Point(167, 3);
			this.dtmStartTime.Name = "dtmStartTime";
			this.dtmStartTime.Padding = new global::System.Windows.Forms.Padding(2, 3, 2, 2);
			this.dtmStartTime.Size = new global::System.Drawing.Size(158, 26);
			this.dtmStartTime.TabIndex = 118;
			this.dtmStartTime.TabStop = false;
			this.dtmStartTime.Text = "2020-04-03";
			this.dtmStartTime.ThemeName = "CIMitarAdmin_Skin";
			this.dtmStartTime.Value = new global::System.DateTime(2020, 4, 3, 15, 36, 44, 994);
			this.radPanel12.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPanel12.Location = new global::System.Drawing.Point(3, 3);
			this.radPanel12.Name = "radPanel12";
			this.radPanel12.Size = new global::System.Drawing.Size(158, 26);
			this.radPanel12.TabIndex = 2;
			this.radPanel12.Text = "Date";
			this.radPanel12.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.radPanel12.ThemeName = "CIMitarAdmin_Skin";
			this.grdUnitHist.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grdUnitHist.Location = new global::System.Drawing.Point(333, 0);
			this.grdUnitHist.MasterTemplate.MultiSelect = true;
			this.grdUnitHist.Name = "grdUnitHist";
			this.grdUnitHist.Size = new global::System.Drawing.Size(1070, 672);
			this.grdUnitHist.TabIndex = 164;
			this.grdUnitHist.ThemeName = "CIMitarAdmin_Skin";
			this.splitter1.Location = new global::System.Drawing.Point(330, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new global::System.Drawing.Size(3, 672);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			this.panel7.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.panel1);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel7.Location = new global::System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(330, 672);
			this.panel7.TabIndex = 118;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1403, 672);
			base.Controls.Add(this.grdUnitHist);
			base.Controls.Add(this.splitter1);
			base.Controls.Add(this.panel7);
			base.Name = "PopUpEditHistory";
			base.RootElement.ApplyShapeToControl = true;
			base.ShowIcon = false;
			this.Text = "Edit History";
			base.ThemeName = "CIMitarAdmin_Skin";
			this.panel1.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.tableLayoutPanel9.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).EndInit();
			this.panel5.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.txtSN).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel2).EndInit();
			this.panel4.ResumeLayout(false);
			this.tableLayoutPanel8.ResumeLayout(false);
			this.tableLayoutPanel8.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel15).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.txtLot).EndInit();
			this.panel3.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dtmEndTime).EndInit();
			this.panel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dtmStartTime).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel12).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.grdUnitHist.MasterTemplate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.grdUnitHist).EndInit();
			this.panel7.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400007D RID: 125
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400007E RID: 126
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;

		// Token: 0x0400007F RID: 127
		private global::Telerik.WinControls.UI.RadPanel radPanel15;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

		// Token: 0x04000081 RID: 129
		private global::Telerik.WinControls.UI.RadPanel radPanel2;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;

		// Token: 0x04000083 RID: 131
		private global::Telerik.WinControls.UI.RadButton btnSearch;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;

		// Token: 0x04000086 RID: 134
		private global::Telerik.WinControls.UI.RadPanel radPanel12;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;

		// Token: 0x04000088 RID: 136
		private global::Telerik.WinControls.UI.RadDateTimePicker dtmEndTime;

		// Token: 0x04000089 RID: 137
		private global::Telerik.WinControls.UI.RadGridView grdUnitHist;

		// Token: 0x0400008A RID: 138
		private global::Telerik.WinControls.UI.RadTextBox txtLot;

		// Token: 0x0400008B RID: 139
		private global::Telerik.WinControls.UI.RadTextBox txtSN;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000091 RID: 145
		private global::Telerik.WinControls.UI.RadDateTimePicker dtmStartTime;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.Splitter splitter1;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.Panel panel7;
	}
}
