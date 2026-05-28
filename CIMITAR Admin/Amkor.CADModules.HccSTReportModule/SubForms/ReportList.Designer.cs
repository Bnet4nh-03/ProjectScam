namespace Amkor.CADModules.HccSTReportModule.SubForms
{
	// Token: 0x02000009 RID: 9
	public partial class ReportList : global::System.Windows.Forms.Form
	{
		// Token: 0x06000053 RID: 83 RVA: 0x0000B612 File Offset: 0x00009812
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000B634 File Offset: 0x00009834
		private void InitializeComponent()
		{
			this.l_subject = new global::System.Windows.Forms.Label();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.combo_Factory = new global::System.Windows.Forms.ComboBox();
			this.validatorTypeConverter1 = new global::DevAge.ComponentModel.Validator.ValidatorTypeConverter();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.grid_Result = new global::SourceGrid.Grid();
			this.groupBox6.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.l_subject.AutoSize = true;
			this.l_subject.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l_subject.Location = new global::System.Drawing.Point(12, 9);
			this.l_subject.Name = "l_subject";
			this.l_subject.Size = new global::System.Drawing.Size(91, 21);
			this.l_subject.TabIndex = 29;
			this.l_subject.Text = "Report List";
			this.groupBox6.Controls.Add(this.combo_Factory);
			this.groupBox6.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox6.Location = new global::System.Drawing.Point(12, 39);
			this.groupBox6.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox6.Size = new global::System.Drawing.Size(147, 72);
			this.groupBox6.TabIndex = 33;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Factory";
			this.combo_Factory.BackColor = global::System.Drawing.Color.Gainsboro;
			this.combo_Factory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Factory.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.combo_Factory.FormattingEnabled = true;
			this.combo_Factory.Location = new global::System.Drawing.Point(21, 32);
			this.combo_Factory.Name = "combo_Factory";
			this.combo_Factory.Size = new global::System.Drawing.Size(105, 23);
			this.combo_Factory.TabIndex = 13;
			this.combo_Factory.SelectionChangeCommitted += new global::System.EventHandler(this.combo_Factory_SelectionChangeCommitted);
			this.groupBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.panel2);
			this.groupBox2.Location = new global::System.Drawing.Point(12, 119);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(776, 431);
			this.groupBox2.TabIndex = 123;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Hardware List";
			this.panel2.AutoScroll = true;
			this.panel2.Controls.Add(this.grid_Result);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(3, 19);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(770, 409);
			this.panel2.TabIndex = 0;
			this.grid_Result.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_Result.EnableSort = true;
			this.grid_Result.Location = new global::System.Drawing.Point(0, 0);
			this.grid_Result.Name = "grid_Result";
			this.grid_Result.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_Result.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_Result.Size = new global::System.Drawing.Size(770, 409);
			this.grid_Result.TabIndex = 1;
			this.grid_Result.TabStop = true;
			this.grid_Result.ToolTipText = "";
			this.grid_Result.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.grid_Result_MouseDown);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(800, 562);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox6);
			base.Controls.Add(this.l_subject);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "ReportList";
			this.Text = "ReportList";
			base.Load += new global::System.EventHandler(this.ReportList_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.ReportList_KeyDown);
			this.groupBox6.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000082 RID: 130
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.Label l_subject;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.ComboBox combo_Factory;

		// Token: 0x04000086 RID: 134
		private global::DevAge.ComponentModel.Validator.ValidatorTypeConverter validatorTypeConverter1;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000089 RID: 137
		private global::SourceGrid.Grid grid_Result;
	}
}
