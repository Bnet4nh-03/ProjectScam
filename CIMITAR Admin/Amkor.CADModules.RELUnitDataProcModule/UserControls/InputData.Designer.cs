namespace Amkor.CADModules.RELUnitDataProcModule.UserControls
{
	// Token: 0x02000015 RID: 21
	public partial class InputData : global::Telerik.WinControls.UI.RadForm
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x0000EC34 File Offset: 0x0000CE34
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000EC6C File Offset: 0x0000CE6C
		private void InitializeComponent()
		{
			this.rdoSN = new global::Telerik.WinControls.UI.RadRadioButton();
			this.rdoLot = new global::Telerik.WinControls.UI.RadRadioButton();
			this.btnLoad = new global::Telerik.WinControls.UI.RadButton();
			this.radSplitContainer1 = new global::Telerik.WinControls.UI.RadSplitContainer();
			this.splitPanel1 = new global::Telerik.WinControls.UI.SplitPanel();
			this.gridView = new global::Telerik.WinControls.UI.RadGridView();
			this.openFileDialog1 = new global::System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.chkNewDoc = new global::Telerik.WinControls.UI.RadCheckBox();
			this.btnSearch = new global::Telerik.WinControls.UI.RadButton();
			this.tableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			this.radPanel12 = new global::Telerik.WinControls.UI.RadPanel();
			((global::System.ComponentModel.ISupportInitialize)this.rdoSN).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoLot).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnLoad).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radSplitContainer1).BeginInit();
			this.radSplitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitPanel1).BeginInit();
			this.splitPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.gridView).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.gridView.MasterTemplate).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.chkNewDoc).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel1).BeginInit();
			this.radPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel12).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this).BeginInit();
			base.SuspendLayout();
			this.rdoSN.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rdoSN.Location = new global::System.Drawing.Point(39, 3);
			this.rdoSN.Name = "rdoSN";
			this.rdoSN.Size = new global::System.Drawing.Size(39, 18);
			this.rdoSN.TabIndex = 162;
			this.rdoSN.TabStop = false;
			this.rdoSN.Text = "S/N";
			this.rdoSN.ThemeName = "CIMitarAdmin_Skin";
			this.rdoLot.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.rdoLot.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rdoLot.Location = new global::System.Drawing.Point(3, 3);
			this.rdoLot.Name = "rdoLot";
			this.rdoLot.Size = new global::System.Drawing.Size(36, 18);
			this.rdoLot.TabIndex = 161;
			this.rdoLot.Text = "Lot";
			this.rdoLot.ThemeName = "CIMitarAdmin_Skin";
			this.rdoLot.ToggleState = global::Telerik.WinControls.Enumerations.ToggleState.On;
			this.tableLayoutPanel1.SetColumnSpan(this.btnLoad, 2);
			this.btnLoad.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnLoad.Location = new global::System.Drawing.Point(167, 35);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new global::System.Drawing.Size(158, 26);
			this.btnLoad.TabIndex = 160;
			this.btnLoad.Text = "Load";
			this.btnLoad.ThemeName = "CIMitarAdmin_Skin";
			this.radSplitContainer1.Controls.Add(this.splitPanel1);
			this.radSplitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radSplitContainer1.Location = new global::System.Drawing.Point(0, 64);
			this.radSplitContainer1.Name = "radSplitContainer1";
			this.radSplitContainer1.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.radSplitContainer1.Size = new global::System.Drawing.Size(328, 398);
			this.radSplitContainer1.TabIndex = 165;
			this.radSplitContainer1.TabStop = false;
			this.radSplitContainer1.Text = "radSplitContainer1";
			this.radSplitContainer1.ThemeName = "CIMitarAdmin_Skin";
			this.splitPanel1.Controls.Add(this.gridView);
			this.splitPanel1.Location = new global::System.Drawing.Point(0, 0);
			this.splitPanel1.Name = "splitPanel1";
			this.splitPanel1.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.splitPanel1.Size = new global::System.Drawing.Size(328, 398);
			this.splitPanel1.SizeInfo.AutoSizeScale = new global::System.Drawing.SizeF(0.06530213f, 0f);
			this.splitPanel1.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(-67, 0);
			this.splitPanel1.TabIndex = 0;
			this.splitPanel1.TabStop = false;
			this.splitPanel1.Text = "splitPanel1";
			this.splitPanel1.ThemeName = "CIMitarAdmin_Skin";
			this.gridView.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridView.Location = new global::System.Drawing.Point(0, 0);
			this.gridView.MasterTemplate.MultiSelect = true;
			this.gridView.Name = "gridView";
			this.gridView.Size = new global::System.Drawing.Size(328, 398);
			this.gridView.TabIndex = 164;
			this.gridView.ThemeName = "CIMitarAdmin_Skin";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.chkNewDoc.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.chkNewDoc.Location = new global::System.Drawing.Point(249, 3);
			this.chkNewDoc.Name = "chkNewDoc";
			this.chkNewDoc.Padding = new global::System.Windows.Forms.Padding(4);
			this.chkNewDoc.Size = new global::System.Drawing.Size(74, 26);
			this.chkNewDoc.TabIndex = 163;
			this.chkNewDoc.Text = "New Doc";
			this.chkNewDoc.ThemeName = "CIMitarAdmin_Skin";
			this.tableLayoutPanel1.SetColumnSpan(this.btnSearch, 2);
			this.btnSearch.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnSearch.Location = new global::System.Drawing.Point(3, 35);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new global::System.Drawing.Size(158, 26);
			this.btnSearch.TabIndex = 163;
			this.btnSearch.Text = "Search";
			this.btnSearch.ThemeName = "CIMitarAdmin_Skin";
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 25f));
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 25f));
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 25f));
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 25f));
			this.tableLayoutPanel1.Controls.Add(this.btnLoad, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnSearch, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.radPanel1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.chkNewDoc, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.radPanel12, 0, 0);
			this.tableLayoutPanel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel1.Size = new global::System.Drawing.Size(328, 64);
			this.tableLayoutPanel1.TabIndex = 1;
			this.tableLayoutPanel1.SetColumnSpan(this.radPanel1, 2);
			this.radPanel1.Controls.Add(this.rdoSN);
			this.radPanel1.Controls.Add(this.rdoLot);
			this.radPanel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPanel1.Location = new global::System.Drawing.Point(85, 3);
			this.radPanel1.Name = "radPanel1";
			this.radPanel1.Padding = new global::System.Windows.Forms.Padding(3);
			this.radPanel1.Size = new global::System.Drawing.Size(158, 26);
			this.radPanel1.TabIndex = 1;
			this.radPanel1.ThemeName = "CIMitarAdmin_Skin";
			this.radPanel12.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPanel12.Location = new global::System.Drawing.Point(3, 3);
			this.radPanel12.Name = "radPanel12";
			this.radPanel12.Size = new global::System.Drawing.Size(76, 26);
			this.radPanel12.TabIndex = 3;
			this.radPanel12.Text = "Type";
			this.radPanel12.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.radPanel12.ThemeName = "CIMitarAdmin_Skin";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(328, 462);
			base.Controls.Add(this.radSplitContainer1);
			base.Controls.Add(this.tableLayoutPanel1);
			base.Name = "InputData";
			base.RootElement.ApplyShapeToControl = true;
			base.ShowIcon = false;
			this.Text = "Input Data";
			base.ThemeName = "CIMitarAdmin_Skin";
			((global::System.ComponentModel.ISupportInitialize)this.rdoSN).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoLot).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnLoad).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radSplitContainer1).EndInit();
			this.radSplitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitPanel1).EndInit();
			this.splitPanel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.gridView.MasterTemplate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.gridView).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.chkNewDoc).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel1).EndInit();
			this.radPanel1.ResumeLayout(false);
			this.radPanel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel12).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000CB RID: 203
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040000CC RID: 204
		private global::Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;

		// Token: 0x040000CD RID: 205
		private global::Telerik.WinControls.UI.SplitPanel splitPanel1;

		// Token: 0x040000CE RID: 206
		private global::Telerik.WinControls.UI.RadButton btnLoad;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.OpenFileDialog openFileDialog1;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x040000D1 RID: 209
		private global::Telerik.WinControls.UI.RadRadioButton rdoSN;

		// Token: 0x040000D2 RID: 210
		private global::Telerik.WinControls.UI.RadRadioButton rdoLot;

		// Token: 0x040000D3 RID: 211
		private global::Telerik.WinControls.UI.RadCheckBox chkNewDoc;

		// Token: 0x040000D4 RID: 212
		private global::Telerik.WinControls.UI.RadButton btnSearch;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

		// Token: 0x040000D6 RID: 214
		private global::Telerik.WinControls.UI.RadPanel radPanel1;

		// Token: 0x040000D7 RID: 215
		private global::Telerik.WinControls.UI.RadPanel radPanel12;

		// Token: 0x040000D8 RID: 216
		private global::Telerik.WinControls.UI.RadGridView gridView;
	}
}
