namespace Amkor.CADModules.ManufactureHistory
{
	// Token: 0x02000005 RID: 5
	public partial class ManufactureHistory : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00003EB8 File Offset: 0x000020B8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003EF0 File Offset: 0x000020F0
		private void InitializeComponent()
		{
			this.tabControl = new global::System.Windows.Forms.TabControl();
			this.tpMaintenance = new global::System.Windows.Forms.TabPage();
			this.tpSearch = new global::System.Windows.Forms.TabPage();
			this.tpAdmin = new global::System.Windows.Forms.TabPage();
			this.tabControl.SuspendLayout();
			base.SuspendLayout();
			this.tabControl.Controls.Add(this.tpMaintenance);
			this.tabControl.Controls.Add(this.tpSearch);
			this.tabControl.Controls.Add(this.tpAdmin);
			this.tabControl.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new global::System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new global::System.Drawing.Size(1316, 581);
			this.tabControl.TabIndex = 0;
			this.tabControl.Selected += new global::System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
			this.tpMaintenance.Location = new global::System.Drawing.Point(4, 22);
			this.tpMaintenance.Name = "tpMaintenance";
			this.tpMaintenance.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpMaintenance.Size = new global::System.Drawing.Size(1308, 555);
			this.tpMaintenance.TabIndex = 0;
			this.tpMaintenance.Text = "Maintenance";
			this.tpMaintenance.UseVisualStyleBackColor = true;
			this.tpSearch.Location = new global::System.Drawing.Point(4, 22);
			this.tpSearch.Name = "tpSearch";
			this.tpSearch.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpSearch.Size = new global::System.Drawing.Size(1308, 555);
			this.tpSearch.TabIndex = 1;
			this.tpSearch.Text = "Search";
			this.tpSearch.UseVisualStyleBackColor = true;
			this.tpAdmin.Location = new global::System.Drawing.Point(4, 22);
			this.tpAdmin.Name = "tpAdmin";
			this.tpAdmin.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpAdmin.Size = new global::System.Drawing.Size(1308, 555);
			this.tpAdmin.TabIndex = 2;
			this.tpAdmin.Text = "AdminSetting";
			this.tpAdmin.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1316, 581);
			base.Controls.Add(this.tabControl);
			base.Name = "ManufactureHistory";
			this.Text = "Manufacture History";
			base.Shown += new global::System.EventHandler(this.ManufactureHistory_Shown);
			this.tabControl.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000008 RID: 8
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.TabControl tabControl;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.TabPage tpMaintenance;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.TabPage tpSearch;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.TabPage tpAdmin;
	}
}
