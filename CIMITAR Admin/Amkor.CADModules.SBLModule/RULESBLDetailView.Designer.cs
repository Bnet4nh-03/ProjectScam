namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000017 RID: 23
	public partial class RULESBLDetailView : global::System.Windows.Forms.Form
	{
		// Token: 0x060000A1 RID: 161 RVA: 0x0000BFF8 File Offset: 0x0000A1F8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000C018 File Offset: 0x0000A218
		private void InitializeComponent()
		{
			this.grid_sbls = new global::SourceGrid.Grid();
			this.button_editSBLS = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.checkBox_active = new global::System.Windows.Forms.CheckBox();
			this.comboBox_sbltype = new global::System.Windows.Forms.ComboBox();
			this.comboBox_actiontype = new global::System.Windows.Forms.ComboBox();
			this.textBox_mailaddr = new global::System.Windows.Forms.TextBox();
			this.textBox_comment = new global::System.Windows.Forms.TextBox();
			this.textBox_userid = new global::System.Windows.Forms.TextBox();
			this.textBox_DEVICE = new global::System.Windows.Forms.TextBox();
			this.textBox_NICK = new global::System.Windows.Forms.TextBox();
			this.textBox_CUSTOMER = new global::System.Windows.Forms.TextBox();
			this.button_Close = new global::System.Windows.Forms.Button();
			this.button_edit = new global::System.Windows.Forms.Button();
			this.button_save = new global::System.Windows.Forms.Button();
			this.button_cancle = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.button_change_nick = new global::System.Windows.Forms.Button();
			this.button_change_devie = new global::System.Windows.Forms.Button();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.label_MODE = new global::System.Windows.Forms.Label();
			this.label_modestr = new global::System.Windows.Forms.Label();
			this.panel_grid = new global::System.Windows.Forms.Panel();
			this.button_delete = new global::System.Windows.Forms.Button();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label_selectedSBL = new global::System.Windows.Forms.Label();
			this.button_delALL = new global::System.Windows.Forms.Button();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel_grid.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			base.SuspendLayout();
			this.grid_sbls.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_sbls.EnableSort = true;
			this.grid_sbls.Location = new global::System.Drawing.Point(0, 0);
			this.grid_sbls.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.grid_sbls.Name = "grid_sbls";
			this.grid_sbls.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_sbls.SelectionMode = global::SourceGrid.GridSelectionMode.Row;
			this.grid_sbls.Size = new global::System.Drawing.Size(550, 188);
			this.grid_sbls.TabIndex = 0;
			this.grid_sbls.TabStop = true;
			this.grid_sbls.ToolTipText = "";
			this.grid_sbls.DoubleClick += new global::System.EventHandler(this.grid_sbls_DoubleClick);
			this.grid_sbls.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_sbls_MouseClick);
			this.button_editSBLS.Enabled = false;
			this.button_editSBLS.Location = new global::System.Drawing.Point(340, 415);
			this.button_editSBLS.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_editSBLS.Name = "button_editSBLS";
			this.button_editSBLS.Size = new global::System.Drawing.Size(109, 29);
			this.button_editSBLS.TabIndex = 1;
			this.button_editSBLS.Text = "EDIT SBLS";
			this.button_editSBLS.UseVisualStyleBackColor = true;
			this.button_editSBLS.Click += new global::System.EventHandler(this.button_editSBLS_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(58, 25);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(42, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Device";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(7, 20);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(53, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "SBLTYPE";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(291, 20);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(71, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Action Type";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(25, 34);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(48, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "USER ID";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(198, 34);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(30, 15);
			this.label5.TabIndex = 2;
			this.label5.Text = "Mail";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(21, 71);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(61, 15);
			this.label6.TabIndex = 2;
			this.label6.Text = "Comment";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(62, 59);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(34, 15);
			this.label7.TabIndex = 2;
			this.label7.Text = "NICK";
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(42, 92);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(69, 15);
			this.label8.TabIndex = 2;
			this.label8.Text = "CUSTOMER";
			this.checkBox_active.AutoSize = true;
			this.checkBox_active.Enabled = false;
			this.checkBox_active.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_active.Location = new global::System.Drawing.Point(76, 13);
			this.checkBox_active.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.checkBox_active.Name = "checkBox_active";
			this.checkBox_active.Size = new global::System.Drawing.Size(67, 19);
			this.checkBox_active.TabIndex = 3;
			this.checkBox_active.Text = "Use SBL";
			this.checkBox_active.UseVisualStyleBackColor = true;
			this.comboBox_sbltype.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_sbltype.Enabled = false;
			this.comboBox_sbltype.FormattingEnabled = true;
			this.comboBox_sbltype.Location = new global::System.Drawing.Point(76, 15);
			this.comboBox_sbltype.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.comboBox_sbltype.Name = "comboBox_sbltype";
			this.comboBox_sbltype.Size = new global::System.Drawing.Size(196, 23);
			this.comboBox_sbltype.TabIndex = 4;
			this.comboBox_sbltype.SelectedIndexChanged += new global::System.EventHandler(this.comboBox_sbltype_SelectedIndexChanged);
			this.comboBox_actiontype.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_actiontype.Enabled = false;
			this.comboBox_actiontype.FormattingEnabled = true;
			this.comboBox_actiontype.Location = new global::System.Drawing.Point(376, 15);
			this.comboBox_actiontype.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.comboBox_actiontype.Name = "comboBox_actiontype";
			this.comboBox_actiontype.Size = new global::System.Drawing.Size(196, 23);
			this.comboBox_actiontype.TabIndex = 4;
			this.textBox_mailaddr.Location = new global::System.Drawing.Point(233, 29);
			this.textBox_mailaddr.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_mailaddr.Name = "textBox_mailaddr";
			this.textBox_mailaddr.ReadOnly = true;
			this.textBox_mailaddr.Size = new global::System.Drawing.Size(333, 23);
			this.textBox_mailaddr.TabIndex = 5;
			this.textBox_comment.Location = new global::System.Drawing.Point(90, 68);
			this.textBox_comment.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_comment.Multiline = true;
			this.textBox_comment.Name = "textBox_comment";
			this.textBox_comment.ReadOnly = true;
			this.textBox_comment.Size = new global::System.Drawing.Size(476, 62);
			this.textBox_comment.TabIndex = 5;
			this.textBox_userid.Location = new global::System.Drawing.Point(90, 29);
			this.textBox_userid.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_userid.Name = "textBox_userid";
			this.textBox_userid.ReadOnly = true;
			this.textBox_userid.Size = new global::System.Drawing.Size(101, 23);
			this.textBox_userid.TabIndex = 5;
			this.textBox_DEVICE.Location = new global::System.Drawing.Point(122, 20);
			this.textBox_DEVICE.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_DEVICE.Name = "textBox_DEVICE";
			this.textBox_DEVICE.ReadOnly = true;
			this.textBox_DEVICE.Size = new global::System.Drawing.Size(314, 23);
			this.textBox_DEVICE.TabIndex = 5;
			this.textBox_NICK.Location = new global::System.Drawing.Point(122, 54);
			this.textBox_NICK.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_NICK.Name = "textBox_NICK";
			this.textBox_NICK.ReadOnly = true;
			this.textBox_NICK.Size = new global::System.Drawing.Size(314, 23);
			this.textBox_NICK.TabIndex = 5;
			this.textBox_CUSTOMER.Location = new global::System.Drawing.Point(122, 88);
			this.textBox_CUSTOMER.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox_CUSTOMER.Name = "textBox_CUSTOMER";
			this.textBox_CUSTOMER.ReadOnly = true;
			this.textBox_CUSTOMER.Size = new global::System.Drawing.Size(187, 23);
			this.textBox_CUSTOMER.TabIndex = 5;
			this.button_Close.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.button_Close.Location = new global::System.Drawing.Point(513, 9);
			this.button_Close.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_Close.Name = "button_Close";
			this.button_Close.Size = new global::System.Drawing.Size(77, 29);
			this.button_Close.TabIndex = 6;
			this.button_Close.Text = "CLOSE";
			this.button_Close.UseVisualStyleBackColor = true;
			this.button_Close.Click += new global::System.EventHandler(this.button_Close_Click);
			this.button_edit.Location = new global::System.Drawing.Point(428, 9);
			this.button_edit.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_edit.Name = "button_edit";
			this.button_edit.Size = new global::System.Drawing.Size(77, 29);
			this.button_edit.TabIndex = 7;
			this.button_edit.Text = "EDIT";
			this.button_edit.UseVisualStyleBackColor = true;
			this.button_edit.Click += new global::System.EventHandler(this.button_edit_Click);
			this.button_save.Enabled = false;
			this.button_save.Location = new global::System.Drawing.Point(429, 45);
			this.button_save.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_save.Name = "button_save";
			this.button_save.Size = new global::System.Drawing.Size(77, 29);
			this.button_save.TabIndex = 8;
			this.button_save.Text = "SAVE";
			this.button_save.UseVisualStyleBackColor = true;
			this.button_save.Click += new global::System.EventHandler(this.button_save_Click);
			this.button_cancle.Enabled = false;
			this.button_cancle.Location = new global::System.Drawing.Point(512, 45);
			this.button_cancle.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_cancle.Name = "button_cancle";
			this.button_cancle.Size = new global::System.Drawing.Size(77, 29);
			this.button_cancle.TabIndex = 9;
			this.button_cancle.Text = "CANCEL";
			this.button_cancle.UseVisualStyleBackColor = true;
			this.button_cancle.Click += new global::System.EventHandler(this.button_cancle_Click);
			this.groupBox1.Controls.Add(this.button_change_nick);
			this.groupBox1.Controls.Add(this.button_change_devie);
			this.groupBox1.Controls.Add(this.textBox_DEVICE);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.textBox_NICK);
			this.groupBox1.Controls.Add(this.textBox_CUSTOMER);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 139);
			this.groupBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Size = new global::System.Drawing.Size(579, 122);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SKEY";
			this.button_change_nick.Enabled = false;
			this.button_change_nick.Location = new global::System.Drawing.Point(446, 52);
			this.button_change_nick.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_change_nick.Name = "button_change_nick";
			this.button_change_nick.Size = new global::System.Drawing.Size(111, 29);
			this.button_change_nick.TabIndex = 6;
			this.button_change_nick.Text = "Change";
			this.button_change_nick.UseVisualStyleBackColor = true;
			this.button_change_nick.Click += new global::System.EventHandler(this.button_change_nick_Click);
			this.button_change_devie.Enabled = false;
			this.button_change_devie.Location = new global::System.Drawing.Point(446, 19);
			this.button_change_devie.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_change_devie.Name = "button_change_devie";
			this.button_change_devie.Size = new global::System.Drawing.Size(111, 29);
			this.button_change_devie.TabIndex = 6;
			this.button_change_devie.Text = "Change";
			this.button_change_devie.UseVisualStyleBackColor = true;
			this.button_change_devie.Click += new global::System.EventHandler(this.button_change_devie_Click);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.textBox_mailaddr);
			this.groupBox2.Controls.Add(this.textBox_comment);
			this.groupBox2.Controls.Add(this.textBox_userid);
			this.groupBox2.Location = new global::System.Drawing.Point(12, 269);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Size = new global::System.Drawing.Size(579, 142);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Option Info";
			this.label_MODE.AutoSize = true;
			this.label_MODE.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.label_MODE.Location = new global::System.Drawing.Point(20, 20);
			this.label_MODE.Name = "label_MODE";
			this.label_MODE.Size = new global::System.Drawing.Size(39, 13);
			this.label_MODE.TabIndex = 12;
			this.label_MODE.Text = "NEW";
			this.label_modestr.AutoSize = true;
			this.label_modestr.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label_modestr.Location = new global::System.Drawing.Point(13, 14);
			this.label_modestr.Name = "label_modestr";
			this.label_modestr.Size = new global::System.Drawing.Size(32, 15);
			this.label_modestr.TabIndex = 13;
			this.label_modestr.Text = "View";
			this.panel_grid.AutoScroll = true;
			this.panel_grid.Controls.Add(this.grid_sbls);
			this.panel_grid.Location = new global::System.Drawing.Point(28, 451);
			this.panel_grid.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel_grid.Name = "panel_grid";
			this.panel_grid.Size = new global::System.Drawing.Size(550, 188);
			this.panel_grid.TabIndex = 14;
			this.button_delete.Enabled = false;
			this.button_delete.Location = new global::System.Drawing.Point(449, 415);
			this.button_delete.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_delete.Name = "button_delete";
			this.button_delete.Size = new global::System.Drawing.Size(70, 29);
			this.button_delete.TabIndex = 15;
			this.button_delete.Text = "Sel Del";
			this.button_delete.UseVisualStyleBackColor = true;
			this.button_delete.Click += new global::System.EventHandler(this.button_delete_Click);
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(26, 421);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(87, 15);
			this.label9.TabIndex = 16;
			this.label9.Text = "Selected Bin # :";
			this.label_selectedSBL.AutoSize = true;
			this.label_selectedSBL.Font = new global::System.Drawing.Font("굴림", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.label_selectedSBL.Location = new global::System.Drawing.Point(126, 421);
			this.label_selectedSBL.Name = "label_selectedSBL";
			this.label_selectedSBL.Size = new global::System.Drawing.Size(77, 12);
			this.label_selectedSBL.TabIndex = 16;
			this.label_selectedSBL.Text = "select bin#";
			this.button_delALL.Location = new global::System.Drawing.Point(519, 415);
			this.button_delALL.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_delALL.Name = "button_delALL";
			this.button_delALL.Size = new global::System.Drawing.Size(70, 29);
			this.button_delALL.TabIndex = 17;
			this.button_delALL.Text = "Del ALL";
			this.button_delALL.UseVisualStyleBackColor = true;
			this.button_delALL.Click += new global::System.EventHandler(this.button_delALL_Click);
			this.groupBox3.Controls.Add(this.label_modestr);
			this.groupBox3.Controls.Add(this.checkBox_active);
			this.groupBox3.Font = new global::System.Drawing.Font("Segoe UI", 1.5f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox3.Location = new global::System.Drawing.Point(12, 52);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(150, 44);
			this.groupBox3.TabIndex = 18;
			this.groupBox3.TabStop = false;
			this.groupBox4.Controls.Add(this.comboBox_sbltype);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.comboBox_actiontype);
			this.groupBox4.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox4.Location = new global::System.Drawing.Point(12, 95);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(579, 44);
			this.groupBox4.TabIndex = 19;
			this.groupBox4.TabStop = false;
			base.AcceptButton = this.button_edit;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = global::System.Drawing.Color.White;
			base.CancelButton = this.button_Close;
			base.ClientSize = new global::System.Drawing.Size(603, 652);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.button_delALL);
			base.Controls.Add(this.label_selectedSBL);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.button_delete);
			base.Controls.Add(this.panel_grid);
			base.Controls.Add(this.label_MODE);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.button_cancle);
			base.Controls.Add(this.button_save);
			base.Controls.Add(this.button_edit);
			base.Controls.Add(this.button_Close);
			base.Controls.Add(this.button_editSBLS);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "RULESBLDetailView";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "RULESBLDetailView";
			base.Load += new global::System.EventHandler(this.RULESBLDetailView_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel_grid.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000BF RID: 191
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000C0 RID: 192
		private global::SourceGrid.Grid grid_sbls;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.Button button_editSBLS;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.CheckBox checkBox_active;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.ComboBox comboBox_sbltype;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.ComboBox comboBox_actiontype;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.TextBox textBox_mailaddr;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.TextBox textBox_comment;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.TextBox textBox_userid;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.TextBox textBox_DEVICE;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.TextBox textBox_NICK;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.TextBox textBox_CUSTOMER;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.Button button_Close;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Button button_edit;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.Button button_save;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.Button button_cancle;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.Button button_change_nick;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.Button button_change_devie;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.Label label_MODE;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.Label label_modestr;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Panel panel_grid;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.Button button_delete;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.Label label_selectedSBL;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.Button button_delALL;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.GroupBox groupBox4;
	}
}
