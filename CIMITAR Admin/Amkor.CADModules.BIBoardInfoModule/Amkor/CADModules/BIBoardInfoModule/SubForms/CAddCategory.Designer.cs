namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000024 RID: 36
	public partial class CAddCategory : global::System.Windows.Forms.Form
	{
		// Token: 0x060000D3 RID: 211 RVA: 0x000132D0 File Offset: 0x000114D0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000132F0 File Offset: 0x000114F0
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.pb_SaveSelection = new global::System.Windows.Forms.PictureBox();
			this.combo_Category = new global::System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_SaveSelection).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.pb_SaveSelection);
			this.groupBox1.Controls.Add(this.combo_Category);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(266, 60);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select Category";
			this.pb_SaveSelection.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_SaveSelection.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_SaveSelection.InitialImage = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_SaveSelection.Location = new global::System.Drawing.Point(227, 16);
			this.pb_SaveSelection.Name = "pb_SaveSelection";
			this.pb_SaveSelection.Size = new global::System.Drawing.Size(32, 33);
			this.pb_SaveSelection.TabIndex = 1;
			this.pb_SaveSelection.TabStop = false;
			this.pb_SaveSelection.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_SaveSelection_MouseDown);
			this.pb_SaveSelection.MouseLeave += new global::System.EventHandler(this.pb_SaveSelection_MouseLeave);
			this.pb_SaveSelection.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pb_SaveSelection_MouseMove);
			this.pb_SaveSelection.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_SaveSelection_MouseUp);
			this.combo_Category.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Category.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.combo_Category.FormattingEnabled = true;
			this.combo_Category.Location = new global::System.Drawing.Point(6, 22);
			this.combo_Category.Name = "combo_Category";
			this.combo_Category.Size = new global::System.Drawing.Size(215, 23);
			this.combo_Category.TabIndex = 0;
			this.combo_Category.SelectionChangeCommitted += new global::System.EventHandler(this.combo_Category_SelectionChangeCommitted);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(272, 66);
			base.Controls.Add(this.groupBox1);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "CAddCategory";
			base.Padding = new global::System.Windows.Forms.Padding(3);
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CAddCategory";
			base.Load += new global::System.EventHandler(this.CAddCategory_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.CAddCategory_KeyDown);
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_SaveSelection).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000191 RID: 401
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000192 RID: 402
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000193 RID: 403
		private global::System.Windows.Forms.PictureBox pb_SaveSelection;

		// Token: 0x04000194 RID: 404
		private global::System.Windows.Forms.ComboBox combo_Category;
	}
}
