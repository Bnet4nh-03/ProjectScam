namespace Amkor.CADModules.HccSTReportModule.SubForms
{
	// Token: 0x0200000A RID: 10
	public partial class UploadList : global::System.Windows.Forms.Form
	{
		// Token: 0x06000066 RID: 102 RVA: 0x0000E764 File Offset: 0x0000C964
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000E784 File Offset: 0x0000C984
		private void InitializeComponent()
		{
			this.l_subject = new global::System.Windows.Forms.Label();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.grid_Result = new global::SourceGrid.Grid();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.pb_Update = new global::System.Windows.Forms.PictureBox();
			this.groupBox2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Update).BeginInit();
			base.SuspendLayout();
			this.l_subject.AutoSize = true;
			this.l_subject.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l_subject.Location = new global::System.Drawing.Point(12, 9);
			this.l_subject.Name = "l_subject";
			this.l_subject.Size = new global::System.Drawing.Size(91, 21);
			this.l_subject.TabIndex = 30;
			this.l_subject.Text = "Report List";
			this.groupBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.panel2);
			this.groupBox2.Location = new global::System.Drawing.Point(16, 117);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(1147, 506);
			this.groupBox2.TabIndex = 124;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Hardware List";
			this.panel2.AutoScroll = true;
			this.panel2.Controls.Add(this.grid_Result);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(3, 19);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1141, 484);
			this.panel2.TabIndex = 0;
			this.grid_Result.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_Result.EnableSort = true;
			this.grid_Result.Location = new global::System.Drawing.Point(0, 0);
			this.grid_Result.Name = "grid_Result";
			this.grid_Result.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_Result.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_Result.Size = new global::System.Drawing.Size(1141, 484);
			this.grid_Result.TabIndex = 1;
			this.grid_Result.TabStop = true;
			this.grid_Result.ToolTipText = "";
			this.groupBox5.Controls.Add(this.pb_Update);
			this.groupBox5.Location = new global::System.Drawing.Point(16, 39);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(74, 72);
			this.groupBox5.TabIndex = 125;
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
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1171, 635);
			base.Controls.Add(this.groupBox5);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.l_subject);
			this.Font = new global::System.Drawing.Font("Segoe UI Emoji", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "UploadList";
			this.Text = "UploadList";
			base.Load += new global::System.EventHandler(this.UploadList_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.UploadList_KeyDown);
			this.groupBox2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_Update).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400008F RID: 143
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.Label l_subject;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000093 RID: 147
		private global::SourceGrid.Grid grid_Result;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.PictureBox pb_Update;
	}
}
