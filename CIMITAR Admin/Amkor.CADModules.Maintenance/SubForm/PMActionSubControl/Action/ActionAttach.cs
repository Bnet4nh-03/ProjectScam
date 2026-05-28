using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.Properties;
using Amkor.CADModules.Maintenance.SubForm.SubControl;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Action
{
	// Token: 0x02000027 RID: 39
	public class ActionAttach : UserControl
	{
		// Token: 0x06000287 RID: 647 RVA: 0x00058B1E File Offset: 0x00056D1E
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00058B2C File Offset: 0x00056D2C
		public List<cFileList> getFileList()
		{
			return this._lFileList;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00058B34 File Offset: 0x00056D34
		public ActionAttach(cReportItem report, ActionInformation ai)
		{
			this._ai = ai;
			this._report = report;
			this.InitializeComponent();
			this.label32.Text = MessageLanguage.getMessage("label_attachment_size");
			this.dgFailAtacth.ColumnCount = 2;
			this.dgFailAtacth.RowCount = 1;
			this.dgFailAtacth.Columns[0].HeaderText = "File";
			this.dgFailAtacth.Columns[1].HeaderText = "Path";
			bool flag = report.sReportStauts == "13" || report.sReportStauts == "14";
			if (flag)
			{
				this.dgFailAtacth.ColumnCount = 1;
				this.dgFailAtacth.RowCount = 1;
				this.dgFailAtacth.ColumnHeadersVisible = false;
				this.dgFailAtacth.Columns[0].HeaderText = "File";
			}
			else
			{
				this.dgFailAtacth.ColumnCount = 2;
				this.dgFailAtacth.RowCount = 1;
				this.dgFailAtacth.ColumnHeadersVisible = true;
				this.dgFailAtacth.Columns[0].HeaderText = "File";
				this.dgFailAtacth.Columns[1].HeaderText = "Path";
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00058CC8 File Offset: 0x00056EC8
		public void clear()
		{
			this._lFileList.Clear();
			this.dgFailAtacth.RowCount = (this.dgFailAtacth.RowCount = 1);
			this.dgFailAtacth.Rows[0].Cells[0].Value = "";
			this.dgFailAtacth.Rows[0].Cells[1].Value = "";
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00058D4C File Offset: 0x00056F4C
		private void pbAdd_Click(object sender, EventArgs e)
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

		// Token: 0x0600028C RID: 652 RVA: 0x00058F00 File Offset: 0x00057100
		private void pbDalete2_Click(object sender, EventArgs e)
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

		// Token: 0x0600028D RID: 653 RVA: 0x00059058 File Offset: 0x00057258
		private void dgFailAtacth_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = !this._bLockEvent;
			if (flag)
			{
				this._bLockEvent = true;
				bool flag2 = e.ColumnIndex == 0 && e.RowIndex >= 0;
				if (flag2)
				{
					bool flag3 = this.dgFailAtacth.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && this.dgFailAtacth.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().Length != 0;
					if (flag3)
					{
						try
						{
							bool flag4 = this._barPrograss == null;
							if (flag4)
							{
								this._barPrograss = new BarPrograss();
								this._barPrograss.progress_labelheader_set("");
								this._barPrograss.setMax(100);
								this._barPrograss.setValue(1);
								this._thread = new Thread(new ThreadStart(this.BarPrograssView));
								this._thread.Start();
							}
							DateTime dateTime = Convert.ToDateTime(this._ai.getRequestTime());
							string text = string.Empty;
							bool flag5 = this._report.sFactory == "ATV";
							if (flag5)
							{
								text = string.Concat(new object[]
								{
									"\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\PMAction\\",
									dateTime.Year.ToString(),
									"\\",
									dateTime.Month,
									"\\",
									dateTime.Day,
									"\\",
									this._report.sReportName.Replace("/", "_").Trim(),
									"_Action.zip"
								});
							}
							string text2 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\" + this._report.sReportName.Replace("/", "_").Trim() + "_Action.zip";
							string text3 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\ActionFile\\" + this.dgFailAtacth.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
							bool flag6 = !File.Exists(text2);
							if (flag6)
							{
								bool flag7 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\ActionFile");
								if (flag7)
								{
									Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\ActionFile");
								}
								bool flag8 = File.Exists(text);
								if (flag8)
								{
									File.Copy(text, text2, true);
								}
								else
								{
									MessageBox.Show(MessageLanguage.getMessage("check_attach_file_exist"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							bool flag9 = File.Exists(text2);
							if (flag9)
							{
								bool flag10 = !File.Exists(text3);
								if (flag10)
								{
									ZipFile.ExtractToDirectory(text2, "C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\ActionFile");
									File.Delete(text2);
								}
								Process.Start(text3);
							}
						}
						catch (Exception ex)
						{
							this._bLockEvent = false;
							MessageBox.Show(ex.Message.ToString(), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						bool flag11 = this._barPrograss != null;
						if (flag11)
						{
							this._barPrograss.setMax(100);
							this._barPrograss.setValue(100);
							Thread.Sleep(10);
							bool flag12 = this._barPrograss != null;
							if (flag12)
							{
								this._barPrograss._ischeck = true;
							}
							this._barPrograss = null;
						}
					}
				}
				this._bLockEvent = false;
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00059400 File Offset: 0x00057600
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00059438 File Offset: 0x00057638
		private void InitializeComponent()
		{
			this.gbActionAttach = new GroupBox();
			this.pnPMAttachFunction = new Panel();
			this.pbAdd = new PictureBox();
			this.panel41 = new Panel();
			this.pbDalete2 = new PictureBox();
			this.dgFailAtacth = new DataGridView();
			this.label32 = new Label();
			this.openFileDialog = new OpenFileDialog();
			this.gbActionAttach.SuspendLayout();
			this.pnPMAttachFunction.SuspendLayout();
			((ISupportInitialize)this.pbAdd).BeginInit();
			((ISupportInitialize)this.pbDalete2).BeginInit();
			((ISupportInitialize)this.dgFailAtacth).BeginInit();
			base.SuspendLayout();
			this.gbActionAttach.Controls.Add(this.pnPMAttachFunction);
			this.gbActionAttach.Controls.Add(this.dgFailAtacth);
			this.gbActionAttach.Controls.Add(this.label32);
			this.gbActionAttach.Dock = DockStyle.Top;
			this.gbActionAttach.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.gbActionAttach.Location = new Point(0, 0);
			this.gbActionAttach.Name = "gbActionAttach";
			this.gbActionAttach.Size = new Size(468, 185);
			this.gbActionAttach.TabIndex = 68;
			this.gbActionAttach.TabStop = false;
			this.gbActionAttach.Text = "Attachment File";
			this.pnPMAttachFunction.Controls.Add(this.pbAdd);
			this.pnPMAttachFunction.Controls.Add(this.panel41);
			this.pnPMAttachFunction.Controls.Add(this.pbDalete2);
			this.pnPMAttachFunction.Dock = DockStyle.Fill;
			this.pnPMAttachFunction.Location = new Point(3, 146);
			this.pnPMAttachFunction.Name = "pnPMAttachFunction";
			this.pnPMAttachFunction.Size = new Size(462, 36);
			this.pnPMAttachFunction.TabIndex = 57;
			this.pbAdd.Cursor = Cursors.Hand;
			this.pbAdd.Dock = DockStyle.Right;
			this.pbAdd.Image = Resources.add;
			this.pbAdd.Location = new Point(368, 0);
			this.pbAdd.Name = "pbAdd";
			this.pbAdd.Padding = new Padding(3);
			this.pbAdd.Size = new Size(35, 36);
			this.pbAdd.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbAdd.TabIndex = 56;
			this.pbAdd.TabStop = false;
			this.pbAdd.Click += this.pbAdd_Click;
			this.panel41.Dock = DockStyle.Right;
			this.panel41.Location = new Point(403, 0);
			this.panel41.Name = "panel41";
			this.panel41.Size = new Size(24, 36);
			this.panel41.TabIndex = 58;
			this.pbDalete2.Cursor = Cursors.Hand;
			this.pbDalete2.Dock = DockStyle.Right;
			this.pbDalete2.Image = Resources.minus;
			this.pbDalete2.Location = new Point(427, 0);
			this.pbDalete2.Name = "pbDalete2";
			this.pbDalete2.Padding = new Padding(3);
			this.pbDalete2.Size = new Size(35, 36);
			this.pbDalete2.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbDalete2.TabIndex = 57;
			this.pbDalete2.TabStop = false;
			this.pbDalete2.Click += this.pbDalete2_Click;
			this.dgFailAtacth.AllowUserToDeleteRows = false;
			this.dgFailAtacth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgFailAtacth.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			this.dgFailAtacth.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgFailAtacth.Dock = DockStyle.Top;
			this.dgFailAtacth.GridColor = Color.White;
			this.dgFailAtacth.Location = new Point(3, 38);
			this.dgFailAtacth.MultiSelect = false;
			this.dgFailAtacth.Name = "dgFailAtacth";
			this.dgFailAtacth.ReadOnly = true;
			this.dgFailAtacth.RowHeadersVisible = false;
			this.dgFailAtacth.RowTemplate.Height = 23;
			this.dgFailAtacth.Size = new Size(462, 108);
			this.dgFailAtacth.TabIndex = 44;
			this.dgFailAtacth.CellDoubleClick += this.dgFailAtacth_CellDoubleClick;
			this.label32.AutoSize = true;
			this.label32.Dock = DockStyle.Top;
			this.label32.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label32.Location = new Point(3, 21);
			this.label32.Name = "label32";
			this.label32.Size = new Size(414, 17);
			this.label32.TabIndex = 56;
			this.label32.Text = "※첨부파일 총 용량은 10MB까지 입니다. 반드시 확인 부탁드립니다.";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.gbActionAttach);
			base.Name = "ActionAttach";
			base.Size = new Size(468, 186);
			this.gbActionAttach.ResumeLayout(false);
			this.gbActionAttach.PerformLayout();
			this.pnPMAttachFunction.ResumeLayout(false);
			((ISupportInitialize)this.pbAdd).EndInit();
			((ISupportInitialize)this.pbDalete2).EndInit();
			((ISupportInitialize)this.dgFailAtacth).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000498 RID: 1176
		private long _lTotalByte = 0L;

		// Token: 0x04000499 RID: 1177
		private const long _lMaximumByte = 10485760L;

		// Token: 0x0400049A RID: 1178
		private List<cFileList> _lFileList = new List<cFileList>();

		// Token: 0x0400049B RID: 1179
		private BarPrograss _barPrograss = null;

		// Token: 0x0400049C RID: 1180
		private bool _bLockEvent = false;

		// Token: 0x0400049D RID: 1181
		private Thread _thread = null;

		// Token: 0x0400049E RID: 1182
		private cReportItem _report;

		// Token: 0x0400049F RID: 1183
		private ActionInformation _ai;

		// Token: 0x040004A0 RID: 1184
		private IContainer components = null;

		// Token: 0x040004A1 RID: 1185
		private GroupBox gbActionAttach;

		// Token: 0x040004A2 RID: 1186
		private Panel pnPMAttachFunction;

		// Token: 0x040004A3 RID: 1187
		private PictureBox pbAdd;

		// Token: 0x040004A4 RID: 1188
		private Panel panel41;

		// Token: 0x040004A5 RID: 1189
		private PictureBox pbDalete2;

		// Token: 0x040004A6 RID: 1190
		private DataGridView dgFailAtacth;

		// Token: 0x040004A7 RID: 1191
		private Label label32;

		// Token: 0x040004A8 RID: 1192
		private OpenFileDialog openFileDialog;
	}
}
