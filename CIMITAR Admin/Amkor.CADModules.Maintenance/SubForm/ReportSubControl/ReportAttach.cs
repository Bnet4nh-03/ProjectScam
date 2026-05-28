using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.Properties;

namespace Amkor.CADModules.Maintenance.SubForm.ReportSubControl
{
	// Token: 0x02000013 RID: 19
	public class ReportAttach : UserControl
	{
		// Token: 0x0600015F RID: 351 RVA: 0x00042100 File Offset: 0x00040300
		public ReportAttach()
		{
			this.InitializeComponent();
			this.dgFailAtacth.ColumnCount = 2;
			this.dgFailAtacth.RowCount = 1;
			this.dgFailAtacth.Columns[0].HeaderText = "File";
			this.dgFailAtacth.Columns[1].HeaderText = "Path";
			this.label10.Text = MessageLanguage.getMessage("label_attachment_size");
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000421A0 File Offset: 0x000403A0
		public void clear()
		{
			this._lFileList.Clear();
			this.dgFailAtacth.RowCount = (this.dgFailAtacth.RowCount = 1);
			this.dgFailAtacth.Rows[0].Cells[0].Value = "";
			this.dgFailAtacth.Rows[0].Cells[1].Value = "";
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00042224 File Offset: 0x00040424
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.openFileDialog.FileName = string.Empty;
			bool flag = this.openFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				cFileList cFileList = new cFileList();
				int num = this.openFileDialog.FileName.LastIndexOf("\\") + 1;
				FileInfo fileInfo = new FileInfo(this.openFileDialog.FileName);
				bool flag2 = this._lTotalByte + fileInfo.Length > 10485760L;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("check_atttach_file_size"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					this._lTotalByte += fileInfo.Length;
					cFileList.sFileName = this.openFileDialog.FileName.Substring(num, this.openFileDialog.FileName.Length - num);
					cFileList.sFilePath = this.openFileDialog.FileName;
					cFileList.size = fileInfo.Length;
					this._lFileList.Add(cFileList);
					this.dgFailAtacth.RowCount = this.dgFailAtacth.RowCount + 1;
					for (int i = 0; i < this._lFileList.Count; i++)
					{
						cFileList = this._lFileList[i];
						this.dgFailAtacth.Rows[i].Cells[0].Value = cFileList.sFileName;
						this.dgFailAtacth.Rows[i].Cells[1].Value = cFileList.sFilePath;
					}
					this.dgFailAtacth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
				}
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000423D8 File Offset: 0x000405D8
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			bool flag = this.dgFailAtacth.RowCount >= 1;
			if (flag)
			{
				bool flag2 = this.dgFailAtacth.Rows[0].Cells[0].Value != null && this.dgFailAtacth.Rows[0].Cells[0].Value.ToString() != string.Empty;
				if (flag2)
				{
					foreach (cFileList cFileList in this._lFileList)
					{
						bool flag3 = cFileList.sFileName == this.dgFailAtacth.Rows[this.dgFailAtacth.RowCount - 2].Cells[0].Value.ToString();
						if (flag3)
						{
							this._lTotalByte -= cFileList.size;
							this._lFileList.Remove(cFileList);
							break;
						}
					}
					this.dgFailAtacth.RowCount = this.dgFailAtacth.RowCount - 1;
				}
				this.dgFailAtacth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00042530 File Offset: 0x00040730
		public List<cFileList> getFileList()
		{
			return this._lFileList;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00042538 File Offset: 0x00040738
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00042570 File Offset: 0x00040770
		private void InitializeComponent()
		{
			this.groupBox2 = new GroupBox();
			this.panel19 = new Panel();
			this.pictureBox1 = new PictureBox();
			this.panel21 = new Panel();
			this.pictureBox2 = new PictureBox();
			this.dgFailAtacth = new DataGridView();
			this.label10 = new Label();
			this.openFileDialog = new OpenFileDialog();
			this.groupBox2.SuspendLayout();
			this.panel19.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			((ISupportInitialize)this.dgFailAtacth).BeginInit();
			base.SuspendLayout();
			this.groupBox2.Controls.Add(this.panel19);
			this.groupBox2.Controls.Add(this.dgFailAtacth);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Dock = DockStyle.Fill;
			this.groupBox2.Location = new Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(426, 153);
			this.groupBox2.TabIndex = 69;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Attachment File";
			this.panel19.Controls.Add(this.pictureBox1);
			this.panel19.Controls.Add(this.panel21);
			this.panel19.Controls.Add(this.pictureBox2);
			this.panel19.Dock = DockStyle.Top;
			this.panel19.Location = new Point(3, 112);
			this.panel19.Name = "panel19";
			this.panel19.Size = new Size(420, 39);
			this.panel19.TabIndex = 43;
			this.pictureBox1.Cursor = Cursors.Hand;
			this.pictureBox1.Dock = DockStyle.Right;
			this.pictureBox1.Image = Resources.add;
			this.pictureBox1.Location = new Point(318, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Padding = new Padding(3);
			this.pictureBox1.Size = new Size(39, 39);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 41;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += this.pictureBox1_Click;
			this.panel21.Dock = DockStyle.Right;
			this.panel21.Location = new Point(357, 0);
			this.panel21.Name = "panel21";
			this.panel21.Size = new Size(24, 39);
			this.panel21.TabIndex = 43;
			this.pictureBox2.Cursor = Cursors.Hand;
			this.pictureBox2.Dock = DockStyle.Right;
			this.pictureBox2.Image = Resources.minus;
			this.pictureBox2.Location = new Point(381, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Padding = new Padding(3);
			this.pictureBox2.Size = new Size(39, 39);
			this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 42;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += this.pictureBox2_Click;
			this.dgFailAtacth.AllowUserToDeleteRows = false;
			this.dgFailAtacth.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgFailAtacth.Dock = DockStyle.Top;
			this.dgFailAtacth.Location = new Point(3, 34);
			this.dgFailAtacth.Name = "dgFailAtacth";
			this.dgFailAtacth.ReadOnly = true;
			this.dgFailAtacth.RowTemplate.Height = 23;
			this.dgFailAtacth.Size = new Size(420, 78);
			this.dgFailAtacth.TabIndex = 23;
			this.label10.AutoSize = true;
			this.label10.Dock = DockStyle.Top;
			this.label10.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label10.Location = new Point(3, 17);
			this.label10.Name = "label10";
			this.label10.Size = new Size(414, 17);
			this.label10.TabIndex = 40;
			this.label10.Text = "※첨부파일 총 용량은 10MB까지 입니다. 반드시 확인 부탁드립니다.";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.groupBox2);
			base.Name = "ReportAttach";
			base.Size = new Size(426, 153);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel19.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox1).EndInit();
			((ISupportInitialize)this.pictureBox2).EndInit();
			((ISupportInitialize)this.dgFailAtacth).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040002F7 RID: 759
		private long _lTotalByte = 0L;

		// Token: 0x040002F8 RID: 760
		private const long _lMaximumByte = 10485760L;

		// Token: 0x040002F9 RID: 761
		private List<cFileList> _lFileList = new List<cFileList>();

		// Token: 0x040002FA RID: 762
		private IContainer components = null;

		// Token: 0x040002FB RID: 763
		private GroupBox groupBox2;

		// Token: 0x040002FC RID: 764
		private Panel panel19;

		// Token: 0x040002FD RID: 765
		private PictureBox pictureBox1;

		// Token: 0x040002FE RID: 766
		private Panel panel21;

		// Token: 0x040002FF RID: 767
		private PictureBox pictureBox2;

		// Token: 0x04000300 RID: 768
		private DataGridView dgFailAtacth;

		// Token: 0x04000301 RID: 769
		private Label label10;

		// Token: 0x04000302 RID: 770
		private OpenFileDialog openFileDialog;
	}
}
