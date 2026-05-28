namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000026 RID: 38
	public partial class CheckSeriesEnable : global::System.Windows.Forms.Form
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x000140BC File Offset: 0x000122BC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000140DC File Offset: 0x000122DC
		private void InitializeComponent()
		{
			this.pb_Save = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Save).BeginInit();
			base.SuspendLayout();
			this.pb_Save.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.pb_Save.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Save.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_Save.InitialImage = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_Save.Location = new global::System.Drawing.Point(289, 21);
			this.pb_Save.Name = "pb_Save";
			this.pb_Save.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Save.TabIndex = 46;
			this.pb_Save.TabStop = false;
			this.pb_Save.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_Save_MouseDown);
			this.pb_Save.MouseLeave += new global::System.EventHandler(this.pb_Save_MouseLeave);
			this.pb_Save.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pb_Save_MouseMove);
			this.pb_Save.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Save_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(333, 74);
			base.Controls.Add(this.pb_Save);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "CheckSeriesEnable";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CheckSeriesEnable";
			base.Load += new global::System.EventHandler(this.CheckSeriesEnable_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.CheckSeriesEnable_KeyDown);
			((global::System.ComponentModel.ISupportInitialize)this.pb_Save).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400019F RID: 415
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001A0 RID: 416
		private global::System.Windows.Forms.PictureBox pb_Save;
	}
}
