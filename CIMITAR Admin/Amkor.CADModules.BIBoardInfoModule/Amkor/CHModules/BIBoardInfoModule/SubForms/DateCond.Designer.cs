namespace Amkor.CHModules.BIBoardInfoModule.SubForms
{
	// Token: 0x0200001A RID: 26
	public partial class DateCond : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00005819 File Offset: 0x00003A19
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005838 File Offset: 0x00003A38
		private void InitializeComponent()
		{
			this.dtPicker_DateFrom = new global::System.Windows.Forms.DateTimePicker();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.dtPicker_DateTo = new global::System.Windows.Forms.DateTimePicker();
			this.pb_SearchInfo_All = new global::System.Windows.Forms.PictureBox();
			this.btn_threeMonth = new global::System.Windows.Forms.Button();
			this.btn_aMonth = new global::System.Windows.Forms.Button();
			this.btn_aWeek = new global::System.Windows.Forms.Button();
			this.btn_sixMonth = new global::System.Windows.Forms.Button();
			this.btn_oneYear = new global::System.Windows.Forms.Button();
			((global::System.ComponentModel.ISupportInitialize)this.pb_SearchInfo_All).BeginInit();
			base.SuspendLayout();
			this.dtPicker_DateFrom.CustomFormat = "yyyy-MM-dd";
			this.dtPicker_DateFrom.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtPicker_DateFrom.Location = new global::System.Drawing.Point(59, 50);
			this.dtPicker_DateFrom.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dtPicker_DateFrom.Name = "dtPicker_DateFrom";
			this.dtPicker_DateFrom.Size = new global::System.Drawing.Size(129, 23);
			this.dtPicker_DateFrom.TabIndex = 102;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 54);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(42, 16);
			this.label1.TabIndex = 103;
			this.label1.Text = "From :";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(194, 54);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(16, 16);
			this.label2.TabIndex = 104;
			this.label2.Text = "~";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(209, 54);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(28, 16);
			this.label3.TabIndex = 106;
			this.label3.Text = "To :";
			this.dtPicker_DateTo.CustomFormat = "yyyy-MM-dd";
			this.dtPicker_DateTo.Enabled = false;
			this.dtPicker_DateTo.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtPicker_DateTo.Location = new global::System.Drawing.Point(242, 50);
			this.dtPicker_DateTo.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dtPicker_DateTo.Name = "dtPicker_DateTo";
			this.dtPicker_DateTo.Size = new global::System.Drawing.Size(129, 23);
			this.dtPicker_DateTo.TabIndex = 105;
			this.pb_SearchInfo_All.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_SearchInfo_All.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSearch;
			this.pb_SearchInfo_All.InitialImage = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSearch;
			this.pb_SearchInfo_All.Location = new global::System.Drawing.Point(382, 44);
			this.pb_SearchInfo_All.Name = "pb_SearchInfo_All";
			this.pb_SearchInfo_All.Size = new global::System.Drawing.Size(32, 32);
			this.pb_SearchInfo_All.TabIndex = 107;
			this.pb_SearchInfo_All.TabStop = false;
			this.pb_SearchInfo_All.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_SearchInfo_All_MouseDown);
			this.pb_SearchInfo_All.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_SearchInfo_All_MouseUp);
			this.btn_threeMonth.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_threeMonth.Location = new global::System.Drawing.Point(177, 10);
			this.btn_threeMonth.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btn_threeMonth.Name = "btn_threeMonth";
			this.btn_threeMonth.Size = new global::System.Drawing.Size(75, 29);
			this.btn_threeMonth.TabIndex = 110;
			this.btn_threeMonth.Text = "3 Month";
			this.btn_threeMonth.UseVisualStyleBackColor = true;
			this.btn_threeMonth.Click += new global::System.EventHandler(this.btn_threeMonth_Click);
			this.btn_aMonth.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_aMonth.Location = new global::System.Drawing.Point(96, 10);
			this.btn_aMonth.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btn_aMonth.Name = "btn_aMonth";
			this.btn_aMonth.Size = new global::System.Drawing.Size(75, 29);
			this.btn_aMonth.TabIndex = 109;
			this.btn_aMonth.Text = "1 Month";
			this.btn_aMonth.UseVisualStyleBackColor = true;
			this.btn_aMonth.Click += new global::System.EventHandler(this.btn_aMonth_Click);
			this.btn_aWeek.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_aWeek.Location = new global::System.Drawing.Point(15, 10);
			this.btn_aWeek.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btn_aWeek.Name = "btn_aWeek";
			this.btn_aWeek.Size = new global::System.Drawing.Size(75, 29);
			this.btn_aWeek.TabIndex = 108;
			this.btn_aWeek.Text = "1 Week";
			this.btn_aWeek.UseVisualStyleBackColor = true;
			this.btn_aWeek.Click += new global::System.EventHandler(this.btn_aWeek_Click);
			this.btn_sixMonth.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_sixMonth.Location = new global::System.Drawing.Point(258, 10);
			this.btn_sixMonth.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btn_sixMonth.Name = "btn_sixMonth";
			this.btn_sixMonth.Size = new global::System.Drawing.Size(75, 29);
			this.btn_sixMonth.TabIndex = 111;
			this.btn_sixMonth.Text = "6 Month";
			this.btn_sixMonth.UseVisualStyleBackColor = true;
			this.btn_sixMonth.Click += new global::System.EventHandler(this.btn_sixMonth_Click);
			this.btn_oneYear.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_oneYear.Location = new global::System.Drawing.Point(339, 10);
			this.btn_oneYear.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btn_oneYear.Name = "btn_oneYear";
			this.btn_oneYear.Size = new global::System.Drawing.Size(75, 29);
			this.btn_oneYear.TabIndex = 112;
			this.btn_oneYear.Text = "1 Year";
			this.btn_oneYear.UseVisualStyleBackColor = true;
			this.btn_oneYear.Click += new global::System.EventHandler(this.btn_oneYear_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(428, 84);
			base.Controls.Add(this.btn_oneYear);
			base.Controls.Add(this.btn_sixMonth);
			base.Controls.Add(this.btn_threeMonth);
			base.Controls.Add(this.btn_aMonth);
			base.Controls.Add(this.btn_aWeek);
			base.Controls.Add(this.pb_SearchInfo_All);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.dtPicker_DateTo);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.dtPicker_DateFrom);
			this.Font = new global::System.Drawing.Font("Segoe UI Emoji", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "DateCond";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DateCond";
			base.Load += new global::System.EventHandler(this.DateCond_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.DateCond_KeyDown);
			((global::System.ComponentModel.ISupportInitialize)this.pb_SearchInfo_All).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000C0 RID: 192
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.DateTimePicker dtPicker_DateFrom;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.DateTimePicker dtPicker_DateTo;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.PictureBox pb_SearchInfo_All;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.Button btn_threeMonth;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.Button btn_aMonth;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.Button btn_aWeek;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.Button btn_sixMonth;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Button btn_oneYear;
	}
}
