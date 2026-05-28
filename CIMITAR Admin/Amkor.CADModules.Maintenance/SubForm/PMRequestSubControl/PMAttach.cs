using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.Properties;

namespace Amkor.CADModules.Maintenance.SubForm.PMRequestSubControl
{
	// Token: 0x02000019 RID: 25
	public class PMAttach : UserControl
	{
		// Token: 0x060001DB RID: 475 RVA: 0x0004B008 File Offset: 0x00049208
		public PMAttach()
		{
			this.InitializeComponent();
			this.label14.Text = MessageLanguage.getMessage("label_attachment_size");
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0004B060 File Offset: 0x00049260
		public void clear()
		{
			this._lFileList.Clear();
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0004B070 File Offset: 0x00049270
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.openFileDialog.FileName = string.Empty;
			bool flag = this.openFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				cFileList cFileList = new cFileList();
				int num = this.openFileDialog.FileName.LastIndexOf("\\") + 1;
				FileInfo fileInfo = new FileInfo(this.openFileDialog.FileName);
				bool flag2 = this._lTotalByte + fileInfo.Length > this._lMaximumByte;
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

		// Token: 0x060001DE RID: 478 RVA: 0x0004B224 File Offset: 0x00049424
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

		// Token: 0x060001DF RID: 479 RVA: 0x0004B37C File Offset: 0x0004957C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0004B3B4 File Offset: 0x000495B4
		private void InitializeComponent()
		{
			this.groupBox4 = new GroupBox();
			this.panel19 = new Panel();
			this.pictureBox1 = new PictureBox();
			this.panel18 = new Panel();
			this.pictureBox2 = new PictureBox();
			this.dgFailAtacth = new DataGridView();
			this.label14 = new Label();
			this.openFileDialog = new OpenFileDialog();
			this.groupBox4.SuspendLayout();
			this.panel19.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			((ISupportInitialize)this.dgFailAtacth).BeginInit();
			base.SuspendLayout();
			this.groupBox4.Controls.Add(this.panel19);
			this.groupBox4.Controls.Add(this.dgFailAtacth);
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Dock = DockStyle.Top;
			this.groupBox4.Location = new Point(0, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(520, 185);
			this.groupBox4.TabIndex = 70;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Attachment File";
			this.panel19.Controls.Add(this.pictureBox1);
			this.panel19.Controls.Add(this.panel18);
			this.panel19.Controls.Add(this.pictureBox2);
			this.panel19.Dock = DockStyle.Fill;
			this.panel19.Location = new Point(3, 142);
			this.panel19.Name = "panel19";
			this.panel19.Size = new Size(514, 40);
			this.panel19.TabIndex = 43;
			this.pictureBox1.Cursor = Cursors.Hand;
			this.pictureBox1.Dock = DockStyle.Right;
			this.pictureBox1.Image = Resources.add;
			this.pictureBox1.Location = new Point(420, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Padding = new Padding(3);
			this.pictureBox1.Size = new Size(35, 40);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 41;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += this.pictureBox1_Click;
			this.panel18.Dock = DockStyle.Right;
			this.panel18.Location = new Point(455, 0);
			this.panel18.Name = "panel18";
			this.panel18.Size = new Size(24, 40);
			this.panel18.TabIndex = 43;
			this.pictureBox2.Cursor = Cursors.Hand;
			this.pictureBox2.Dock = DockStyle.Right;
			this.pictureBox2.Image = Resources.minus;
			this.pictureBox2.Location = new Point(479, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Padding = new Padding(3);
			this.pictureBox2.Size = new Size(35, 40);
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
			this.dgFailAtacth.Size = new Size(514, 108);
			this.dgFailAtacth.TabIndex = 23;
			this.label14.AutoSize = true;
			this.label14.Dock = DockStyle.Top;
			this.label14.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label14.Location = new Point(3, 17);
			this.label14.Name = "label14";
			this.label14.Size = new Size(414, 17);
			this.label14.TabIndex = 40;
			this.label14.Text = "※첨부파일 총 용량은 10MB까지 입니다. 반드시 확인 부탁드립니다.";
			this.openFileDialog.FileName = "openFileDialog1";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.groupBox4);
			base.Name = "PMAttach";
			base.Size = new Size(520, 186);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.panel19.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox1).EndInit();
			((ISupportInitialize)this.pictureBox2).EndInit();
			((ISupportInitialize)this.dgFailAtacth).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000395 RID: 917
		private long _lTotalByte = 0L;

		// Token: 0x04000396 RID: 918
		private long _lMaximumByte = 10485760L;

		// Token: 0x04000397 RID: 919
		private List<cFileList> _lFileList = new List<cFileList>();

		// Token: 0x04000398 RID: 920
		private IContainer components = null;

		// Token: 0x04000399 RID: 921
		private GroupBox groupBox4;

		// Token: 0x0400039A RID: 922
		private Panel panel19;

		// Token: 0x0400039B RID: 923
		private PictureBox pictureBox1;

		// Token: 0x0400039C RID: 924
		private Panel panel18;

		// Token: 0x0400039D RID: 925
		private PictureBox pictureBox2;

		// Token: 0x0400039E RID: 926
		private DataGridView dgFailAtacth;

		// Token: 0x0400039F RID: 927
		private Label label14;

		// Token: 0x040003A0 RID: 928
		private OpenFileDialog openFileDialog;
	}
}
