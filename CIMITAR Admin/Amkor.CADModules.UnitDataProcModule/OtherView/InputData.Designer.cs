namespace Amkor.CADModules.UnitDataProcModule.OtherView
{
	// Token: 0x0200000E RID: 14
	public partial class InputData : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00008B21 File Offset: 0x00006D21
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00008B40 File Offset: 0x00006D40
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
			this.radPanel2 = new global::Telerik.WinControls.UI.RadPanel();
			this.btnSearch = new global::Telerik.WinControls.UI.RadButton();
			this.radGroupBox1 = new global::Telerik.WinControls.UI.RadGroupBox();
			this.radGroupBox2 = new global::Telerik.WinControls.UI.RadGroupBox();
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
			((global::System.ComponentModel.ISupportInitialize)this.radPanel2).BeginInit();
			this.radPanel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radGroupBox1).BeginInit();
			this.radGroupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radGroupBox2).BeginInit();
			this.radGroupBox2.SuspendLayout();
			base.SuspendLayout();
			this.rdoSN.Location = new global::System.Drawing.Point(66, 21);
			this.rdoSN.Name = "rdoSN";
			this.rdoSN.Size = new global::System.Drawing.Size(35, 18);
			this.rdoSN.TabIndex = 162;
			this.rdoSN.TabStop = false;
			this.rdoSN.Text = "SN";
			this.rdoLot.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.rdoLot.Location = new global::System.Drawing.Point(15, 21);
			this.rdoLot.Name = "rdoLot";
			this.rdoLot.Size = new global::System.Drawing.Size(36, 18);
			this.rdoLot.TabIndex = 161;
			this.rdoLot.Text = "Lot";
			this.rdoLot.ToggleState = global::Telerik.WinControls.Enumerations.ToggleState.On;
			this.btnLoad.Location = new global::System.Drawing.Point(270, 11);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new global::System.Drawing.Size(54, 32);
			this.btnLoad.TabIndex = 160;
			this.btnLoad.Text = "Load";
			this.btnLoad.ThemeName = "TelerikMetroBlue";
			this.btnLoad.Click += new global::System.EventHandler(this.btnLoad_Click);
			this.radSplitContainer1.Controls.Add(this.splitPanel1);
			this.radSplitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radSplitContainer1.Location = new global::System.Drawing.Point(0, 50);
			this.radSplitContainer1.Name = "radSplitContainer1";
			this.radSplitContainer1.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.radSplitContainer1.Size = new global::System.Drawing.Size(328, 412);
			this.radSplitContainer1.TabIndex = 165;
			this.radSplitContainer1.TabStop = false;
			this.radSplitContainer1.Text = "radSplitContainer1";
			this.splitPanel1.Controls.Add(this.gridView);
			this.splitPanel1.Location = new global::System.Drawing.Point(0, 0);
			this.splitPanel1.Name = "splitPanel1";
			this.splitPanel1.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.splitPanel1.Size = new global::System.Drawing.Size(328, 412);
			this.splitPanel1.SizeInfo.AutoSizeScale = new global::System.Drawing.SizeF(0.06530213f, 0f);
			this.splitPanel1.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(-67, 0);
			this.splitPanel1.TabIndex = 0;
			this.splitPanel1.TabStop = false;
			this.splitPanel1.Text = "splitPanel1";
			this.gridView.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridView.Location = new global::System.Drawing.Point(0, 0);
			this.gridView.MasterTemplate.MultiSelect = true;
			this.gridView.Name = "gridView";
			this.gridView.Size = new global::System.Drawing.Size(328, 412);
			this.gridView.TabIndex = 1;
			this.gridView.Text = "radGridView1";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.chkNewDoc.Location = new global::System.Drawing.Point(5, 21);
			this.chkNewDoc.Name = "chkNewDoc";
			this.chkNewDoc.Size = new global::System.Drawing.Size(66, 18);
			this.chkNewDoc.TabIndex = 163;
			this.chkNewDoc.Text = "New Doc";
			this.radPanel2.BackColor = global::System.Drawing.Color.White;
			this.radPanel2.Controls.Add(this.btnSearch);
			this.radPanel2.Controls.Add(this.btnLoad);
			this.radPanel2.Controls.Add(this.radGroupBox1);
			this.radPanel2.Controls.Add(this.radGroupBox2);
			this.radPanel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.radPanel2.Location = new global::System.Drawing.Point(0, 0);
			this.radPanel2.Name = "radPanel2";
			this.radPanel2.Size = new global::System.Drawing.Size(328, 50);
			this.radPanel2.TabIndex = 166;
			this.btnSearch.Location = new global::System.Drawing.Point(210, 11);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new global::System.Drawing.Size(54, 32);
			this.btnSearch.TabIndex = 163;
			this.btnSearch.Text = "Search";
			this.btnSearch.ThemeName = "TelerikMetroBlue";
			this.btnSearch.Click += new global::System.EventHandler(this.btnSearch_Click);
			this.radGroupBox1.AccessibleRole = global::System.Windows.Forms.AccessibleRole.Grouping;
			this.radGroupBox1.Controls.Add(this.chkNewDoc);
			this.radGroupBox1.HeaderText = "       ";
			this.radGroupBox1.Location = new global::System.Drawing.Point(129, 4);
			this.radGroupBox1.Name = "radGroupBox1";
			this.radGroupBox1.Size = new global::System.Drawing.Size(75, 42);
			this.radGroupBox1.TabIndex = 162;
			this.radGroupBox1.Text = "       ";
			this.radGroupBox1.ThemeName = "TelerikMetroBlue";
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopColor = global::System.Drawing.Color.FromArgb(240, 110, 170);
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopShadowColor = global::System.Drawing.Color.FromArgb(240, 110, 170);
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.Default;
			this.radGroupBox2.AccessibleRole = global::System.Windows.Forms.AccessibleRole.Grouping;
			this.radGroupBox2.Controls.Add(this.rdoSN);
			this.radGroupBox2.Controls.Add(this.rdoLot);
			this.radGroupBox2.HeaderText = "Type";
			this.radGroupBox2.Location = new global::System.Drawing.Point(6, 4);
			this.radGroupBox2.Name = "radGroupBox2";
			this.radGroupBox2.Size = new global::System.Drawing.Size(117, 42);
			this.radGroupBox2.TabIndex = 156;
			this.radGroupBox2.Text = "Type";
			this.radGroupBox2.ThemeName = "TelerikMetroBlue";
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopColor = global::System.Drawing.Color.FromArgb(240, 110, 170);
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopShadowColor = global::System.Drawing.Color.FromArgb(240, 110, 170);
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.Default;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(328, 462);
			base.Controls.Add(this.radSplitContainer1);
			base.Controls.Add(this.radPanel2);
			base.Name = "InputData";
			this.Text = "Input Data";
			base.Load += new global::System.EventHandler(this.InputData_Load);
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
			((global::System.ComponentModel.ISupportInitialize)this.radPanel2).EndInit();
			this.radPanel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radGroupBox1).EndInit();
			this.radGroupBox1.ResumeLayout(false);
			this.radGroupBox1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radGroupBox2).EndInit();
			this.radGroupBox2.ResumeLayout(false);
			this.radGroupBox2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000089 RID: 137
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400008A RID: 138
		private global::Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;

		// Token: 0x0400008B RID: 139
		private global::Telerik.WinControls.UI.SplitPanel splitPanel1;

		// Token: 0x0400008C RID: 140
		private global::Telerik.WinControls.UI.RadButton btnLoad;

		// Token: 0x0400008D RID: 141
		private global::Telerik.WinControls.UI.RadGridView gridView;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.OpenFileDialog openFileDialog1;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x04000090 RID: 144
		private global::Telerik.WinControls.UI.RadRadioButton rdoSN;

		// Token: 0x04000091 RID: 145
		private global::Telerik.WinControls.UI.RadRadioButton rdoLot;

		// Token: 0x04000092 RID: 146
		private global::Telerik.WinControls.UI.RadCheckBox chkNewDoc;

		// Token: 0x04000093 RID: 147
		private global::Telerik.WinControls.UI.RadPanel radPanel2;

		// Token: 0x04000094 RID: 148
		private global::Telerik.WinControls.UI.RadGroupBox radGroupBox1;

		// Token: 0x04000095 RID: 149
		private global::Telerik.WinControls.UI.RadGroupBox radGroupBox2;

		// Token: 0x04000096 RID: 150
		private global::Telerik.WinControls.UI.RadButton btnSearch;
	}
}
