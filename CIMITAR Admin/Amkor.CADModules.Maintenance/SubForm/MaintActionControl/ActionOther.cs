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

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x02000049 RID: 73
	public class ActionOther : UserControl
	{
		// Token: 0x06000419 RID: 1049 RVA: 0x00079CD0 File Offset: 0x00077ED0
		public ActionOther(cReportItem report)
		{
			this._lTotalByte = 0L;
			this._report = report;
			string[] array = report.sPart.Split(new char[]
			{
				';'
			});
			string[] array2 = report.sPartDescription.Split(new char[]
			{
				';'
			});
			for (int i = 0; i < array.Length; i++)
			{
				this._PartList.Add(array[i]);
			}
			for (int j = 0; j < array2.Length; j++)
			{
				this._PartDescription.Add(array2[j]);
			}
			this.InitializeComponent();
			this.partGridView.RowCount = this._PartList.Count;
			this.label32.Text = MessageLanguage.getMessage("label_attachment_size");
			for (int k = 0; k < this._PartList.Count; k++)
			{
				string[] array3 = this._PartList[k].Split(new char[]
				{
					'|'
				});
				this.partGridView.Rows[k].Cells[0].Value = this._PartDescription[k];
				this.partGridView.Rows[k].Cells[1].Value = ((array3[0] != null) ? array3[0] : "");
				bool flag = array3.Length > 1;
				if (flag)
				{
					this.partGridView.Rows[k].Cells[2].Value = ((array3[1] != null) ? array3[1] : "");
				}
			}
			bool flag2 = report.sReportStauts.CompareTo("1") == 0;
			if (flag2)
			{
				this.pbPartAdd.Enabled = true;
				this.pbAdd.Enabled = true;
				this.pbDalete2.Enabled = true;
				this.InitGrid(false);
			}
			else
			{
				bool flag3 = report.sReportStauts.CompareTo("2") == 0;
				if (flag3)
				{
					this.pbPartAdd.Enabled = false;
					this.pbAdd.Enabled = false;
					this.pbDalete2.Enabled = false;
					this.InitGrid(true);
					bool flag4 = !string.IsNullOrEmpty(report.ActionAttachment.Trim());
					if (flag4)
					{
						string[] array4 = report.ActionAttachment.Split(new char[]
						{
							';'
						});
						bool flag5 = array4.Length != 0;
						if (flag5)
						{
							this.dgAttachmentList.RowCount = array4.Length;
							for (int l = 0; l < array4.Length; l++)
							{
								bool flag6 = array4[l].Trim().Length > 0;
								if (flag6)
								{
									this.dgAttachmentList.Rows[l].Cells[0].Value = array4[l].Substring(array4[l].LastIndexOf('\\') + 1);
								}
							}
						}
					}
				}
				else
				{
					bool flag7 = report.sReportStauts.CompareTo("3") == 0;
					if (flag7)
					{
						this.pbPartAdd.Enabled = true;
						this.pbAdd.Enabled = true;
						this.pbDalete2.Enabled = true;
						this.InitGrid(false);
					}
				}
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0007A08D File Offset: 0x0007828D
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0007A09C File Offset: 0x0007829C
		public void clear()
		{
			this.partGridView.RowCount = 1;
			this.dgAttachmentList.RowCount = 1;
			this._lFileList.Clear();
			this._PartDescription.Clear();
			this._PartList.Clear();
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0007A0E8 File Offset: 0x000782E8
		public string getPartString()
		{
			string text = string.Empty;
			for (int i = 0; i < this._PartList.Count; i++)
			{
				bool flag = this._PartList[i] == string.Empty;
				if (!flag)
				{
					text = text + this._PartList[i].Trim().Replace("'", "''") + ";";
				}
			}
			return text;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0007A168 File Offset: 0x00078368
		public string getPartDesString()
		{
			string text = string.Empty;
			for (int i = 0; i < this._PartDescription.Count; i++)
			{
				bool flag = this._PartDescription[i] == string.Empty;
				if (!flag)
				{
					text = text + this._PartDescription[i].Trim().Replace("'", "''") + ";";
				}
			}
			return text;
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0007A1E8 File Offset: 0x000783E8
		private void pbPartAdd_Click(object sender, EventArgs e)
		{
			PartForm partForm = new PartForm(this._PartList, this._PartDescription, this._report.sReportStauts.CompareTo("2") != 0);
			bool flag = partForm.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this._PartList = partForm.getPartList();
				this._PartDescription = partForm.gePartDescription();
				bool flag2 = this._PartList.Count <= 0;
				if (flag2)
				{
					this.partGridView.RowCount = 1;
					this.partGridView.Rows[0].Cells[0].Value = "";
					this.partGridView.Rows[0].Cells[1].Value = "";
					this.partGridView.Rows[0].Cells[2].Value = "";
				}
				else
				{
					this.partGridView.RowCount = this._PartList.Count;
					for (int i = 0; i < this._PartList.Count; i++)
					{
						string[] array = this._PartList[i].Split(new char[]
						{
							'|'
						});
						this.partGridView.Rows[i].Cells[0].Value = this._PartDescription[i];
						this.partGridView.Rows[i].Cells[1].Value = ((array[0] != null) ? array[0] : "");
						bool flag3 = array.Length > 1;
						if (flag3)
						{
							this.partGridView.Rows[i].Cells[2].Value = ((array[1] != null) ? array[1] : "");
						}
					}
				}
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0007A3E7 File Offset: 0x000785E7
		public List<string> getPartList()
		{
			return this._PartList;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0007A3EF File Offset: 0x000785EF
		public List<string> getPartDesList()
		{
			return this._PartDescription;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0007A3F8 File Offset: 0x000785F8
		private void InitGrid(bool display)
		{
			if (display)
			{
				this.dgAttachmentList.ColumnCount = 1;
				this.dgAttachmentList.RowCount = 1;
				this.dgAttachmentList.ColumnHeadersVisible = false;
			}
			else
			{
				this.dgAttachmentList.ColumnCount = 2;
				this.dgAttachmentList.RowCount = 1;
				this.dgAttachmentList.ColumnHeadersVisible = true;
				this.dgAttachmentList.Columns[0].HeaderText = "File";
				this.dgAttachmentList.Columns[1].HeaderText = "Path";
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0007A498 File Offset: 0x00078698
		public bool isExistAttach()
		{
			bool flag = this.dgAttachmentList.Rows.Count > 0 && this.dgAttachmentList.Columns.Count > 0;
			bool result;
			if (flag)
			{
				bool flag2 = this.dgAttachmentList.Rows[0].Cells[1].Value == null || this.dgAttachmentList.Rows[0].Cells[1].Value.ToString().Trim().Length == 0;
				result = !flag2;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0007A544 File Offset: 0x00078744
		public string getAttachStringList()
		{
			string text = string.Empty;
			for (int i = 0; i < this.dgAttachmentList.RowCount; i++)
			{
				bool flag = this.dgAttachmentList.Rows[i].Cells[1].Value != null;
				if (flag)
				{
					text = text + this.dgAttachmentList.Rows[i].Cells[1].Value.ToString() + ";";
				}
			}
			return text;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0007A5D8 File Offset: 0x000787D8
		private void pbAdd_Click(object sender, EventArgs e)
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
					this.dgAttachmentList.RowCount = this.dgAttachmentList.RowCount + 1;
					for (int i = 0; i < this._lFileList.Count; i++)
					{
						cFileList = this._lFileList[i];
						this.dgAttachmentList.Rows[i].Cells[0].Value = cFileList.sFileName;
						this.dgAttachmentList.Rows[i].Cells[1].Value = cFileList.sFilePath;
					}
					this.dgAttachmentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
				}
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0007A78C File Offset: 0x0007898C
		private void pbDalete2_Click(object sender, EventArgs e)
		{
			bool flag = this.dgAttachmentList.RowCount >= 1;
			if (flag)
			{
				bool flag2 = this.dgAttachmentList.Rows[0].Cells[0].Value != null && this.dgAttachmentList.Rows[0].Cells[0].Value.ToString() != string.Empty;
				if (flag2)
				{
					foreach (cFileList cFileList in this._lFileList)
					{
						bool flag3 = cFileList.sFileName == this.dgAttachmentList.Rows[this.dgAttachmentList.RowCount - 2].Cells[0].Value.ToString();
						if (flag3)
						{
							this._lTotalByte -= cFileList.size;
							this._lFileList.Remove(cFileList);
							break;
						}
					}
					this.dgAttachmentList.RowCount = this.dgAttachmentList.RowCount - 1;
				}
				this.dgAttachmentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0007A8E4 File Offset: 0x00078AE4
		public List<cFileList> getAttachList()
		{
			return this._lFileList;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0007A8EC File Offset: 0x00078AEC
		private void dgFailAtacth_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = !this._bLockEvent;
			if (flag)
			{
				this._bLockEvent = true;
				bool flag2 = e.ColumnIndex == 0 && e.RowIndex >= 0;
				if (flag2)
				{
					bool flag3 = this.dgAttachmentList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && this.dgAttachmentList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().Length != 0;
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
							DateTime dateTime = Convert.ToDateTime(this._report.sRequestTime.Trim());
							string text = string.Empty;
							bool flag5 = this._report.sFactory == "ATV";
							if (flag5)
							{
								text = string.Concat(new object[]
								{
									"\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\Action\\",
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
							bool flag6 = !File.Exists(text2);
							if (flag6)
							{
								bool flag7 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\attach");
								if (flag7)
								{
									Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\download\\attach");
								}
								bool flag8 = File.Exists(text);
								if (flag8)
								{
									File.Copy(text, text2, true);
								}
								else
								{
									this._bLockEvent = false;
									MessageBox.Show(MessageLanguage.getMessage("check_attach_file_exist"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							bool flag9 = File.Exists(text2);
							if (flag9)
							{
								string text3 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\File\\" + this.dgAttachmentList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
								bool flag10 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\File");
								if (flag10)
								{
									Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\File");
								}
								bool flag11 = !File.Exists(text3);
								if (flag11)
								{
									ZipFile.ExtractToDirectory(text2, "C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\File");
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
						bool flag12 = this._barPrograss != null;
						if (flag12)
						{
							this._barPrograss.setMax(100);
							this._barPrograss.setValue(100);
							Thread.Sleep(10);
							bool flag13 = this._barPrograss != null;
							if (flag13)
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

		// Token: 0x06000428 RID: 1064 RVA: 0x0007ACC8 File Offset: 0x00078EC8
		private void cbNoReplacementParts_Paint(object sender, PaintEventArgs e)
		{
			base.OnPaint(e);
			int num = this.cbNoReplacementParts.Parent.Height - 1;
			Rectangle rectangle = new Rectangle(new Point(0, 0), new Size(num, num));
			ControlPaint.DrawCheckBox(e.Graphics, rectangle, this.cbNoReplacementParts.Checked ? ButtonState.Checked : ButtonState.Normal);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0007AD28 File Offset: 0x00078F28
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0007AD60 File Offset: 0x00078F60
		private void InitializeComponent()
		{
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			this.gbPart = new GroupBox();
			this.partGridView = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.label18 = new Label();
			this.panel39 = new Panel();
			this.cbNoReplacementParts = new CheckBox();
			this.panel1 = new Panel();
			this.pbPartAdd = new PictureBox();
			this.gbActionAttach = new GroupBox();
			this.dgAttachmentList = new DataGridView();
			this.panel40 = new Panel();
			this.pbAdd = new PictureBox();
			this.panel41 = new Panel();
			this.pbDalete2 = new PictureBox();
			this.label32 = new Label();
			this.openFileDialog = new OpenFileDialog();
			this.gbPart.SuspendLayout();
			((ISupportInitialize)this.partGridView).BeginInit();
			this.panel39.SuspendLayout();
			this.panel1.SuspendLayout();
			((ISupportInitialize)this.pbPartAdd).BeginInit();
			this.gbActionAttach.SuspendLayout();
			((ISupportInitialize)this.dgAttachmentList).BeginInit();
			this.panel40.SuspendLayout();
			((ISupportInitialize)this.pbAdd).BeginInit();
			((ISupportInitialize)this.pbDalete2).BeginInit();
			base.SuspendLayout();
			this.gbPart.Controls.Add(this.partGridView);
			this.gbPart.Controls.Add(this.label18);
			this.gbPart.Controls.Add(this.panel39);
			this.gbPart.Dock = DockStyle.Top;
			this.gbPart.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.gbPart.Location = new Point(0, 0);
			this.gbPart.Name = "gbPart";
			this.gbPart.Size = new Size(489, 170);
			this.gbPart.TabIndex = 66;
			this.gbPart.TabStop = false;
			this.gbPart.Text = "Change Parts";
			this.partGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.partGridView.Columns.AddRange(new DataGridViewColumn[]
			{
				this.Column1,
				this.Column2,
				this.Column3
			});
			this.partGridView.Dock = DockStyle.Fill;
			this.partGridView.Location = new Point(3, 21);
			this.partGridView.Name = "partGridView";
			this.partGridView.ReadOnly = true;
			this.partGridView.RowTemplate.Height = 23;
			this.partGridView.Size = new Size(483, 110);
			this.partGridView.TabIndex = 56;
			this.Column1.HeaderText = "Description";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column2.HeaderText = "Model";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			dataGridViewCellStyle.Format = "N0";
			dataGridViewCellStyle.NullValue = null;
			this.Column3.DefaultCellStyle = dataGridViewCellStyle;
			this.Column3.HeaderText = "Q'ty";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.label18.AutoSize = true;
			this.label18.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label18.Location = new Point(-136, 8);
			this.label18.Name = "label18";
			this.label18.Size = new Size(67, 17);
			this.label18.TabIndex = 27;
			this.label18.Text = "Start Time";
			this.panel39.Controls.Add(this.cbNoReplacementParts);
			this.panel39.Controls.Add(this.panel1);
			this.panel39.Dock = DockStyle.Bottom;
			this.panel39.Location = new Point(3, 131);
			this.panel39.Name = "panel39";
			this.panel39.Size = new Size(483, 36);
			this.panel39.TabIndex = 57;
			this.cbNoReplacementParts.Dock = DockStyle.Left;
			this.cbNoReplacementParts.Location = new Point(0, 0);
			this.cbNoReplacementParts.Name = "cbNoReplacementParts";
			this.cbNoReplacementParts.Size = new Size(201, 36);
			this.cbNoReplacementParts.TabIndex = 58;
			this.cbNoReplacementParts.Text = "No Replacement Parts";
			this.cbNoReplacementParts.TextAlign = ContentAlignment.MiddleCenter;
			this.cbNoReplacementParts.UseVisualStyleBackColor = true;
			this.cbNoReplacementParts.Visible = false;
			this.cbNoReplacementParts.Paint += this.cbNoReplacementParts_Paint;
			this.panel1.Controls.Add(this.pbPartAdd);
			this.panel1.Dock = DockStyle.Right;
			this.panel1.Location = new Point(448, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(35, 36);
			this.panel1.TabIndex = 57;
			this.pbPartAdd.Cursor = Cursors.Hand;
			this.pbPartAdd.Dock = DockStyle.Fill;
			this.pbPartAdd.Image = Resources.add;
			this.pbPartAdd.Location = new Point(0, 0);
			this.pbPartAdd.Name = "pbPartAdd";
			this.pbPartAdd.Padding = new Padding(3);
			this.pbPartAdd.Size = new Size(35, 36);
			this.pbPartAdd.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbPartAdd.TabIndex = 56;
			this.pbPartAdd.TabStop = false;
			this.pbPartAdd.Click += this.pbPartAdd_Click;
			this.gbActionAttach.Controls.Add(this.dgAttachmentList);
			this.gbActionAttach.Controls.Add(this.panel40);
			this.gbActionAttach.Controls.Add(this.label32);
			this.gbActionAttach.Dock = DockStyle.Fill;
			this.gbActionAttach.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.gbActionAttach.Location = new Point(0, 170);
			this.gbActionAttach.Name = "gbActionAttach";
			this.gbActionAttach.Size = new Size(489, 209);
			this.gbActionAttach.TabIndex = 68;
			this.gbActionAttach.TabStop = false;
			this.gbActionAttach.Text = "Attachment File";
			this.dgAttachmentList.AllowUserToDeleteRows = false;
			this.dgAttachmentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgAttachmentList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			this.dgAttachmentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgAttachmentList.Dock = DockStyle.Fill;
			this.dgAttachmentList.GridColor = Color.White;
			this.dgAttachmentList.Location = new Point(3, 44);
			this.dgAttachmentList.MultiSelect = false;
			this.dgAttachmentList.Name = "dgAttachmentList";
			this.dgAttachmentList.ReadOnly = true;
			this.dgAttachmentList.RowHeadersVisible = false;
			this.dgAttachmentList.RowTemplate.Height = 23;
			this.dgAttachmentList.Size = new Size(483, 126);
			this.dgAttachmentList.TabIndex = 44;
			this.dgAttachmentList.CellDoubleClick += this.dgFailAtacth_CellDoubleClick;
			this.panel40.Controls.Add(this.pbAdd);
			this.panel40.Controls.Add(this.panel41);
			this.panel40.Controls.Add(this.pbDalete2);
			this.panel40.Dock = DockStyle.Bottom;
			this.panel40.Location = new Point(3, 170);
			this.panel40.Name = "panel40";
			this.panel40.Size = new Size(483, 36);
			this.panel40.TabIndex = 57;
			this.pbAdd.Cursor = Cursors.Hand;
			this.pbAdd.Dock = DockStyle.Right;
			this.pbAdd.Image = Resources.add;
			this.pbAdd.Location = new Point(389, 0);
			this.pbAdd.Name = "pbAdd";
			this.pbAdd.Padding = new Padding(3);
			this.pbAdd.Size = new Size(35, 36);
			this.pbAdd.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbAdd.TabIndex = 56;
			this.pbAdd.TabStop = false;
			this.pbAdd.Click += this.pbAdd_Click;
			this.panel41.Dock = DockStyle.Right;
			this.panel41.Location = new Point(424, 0);
			this.panel41.Name = "panel41";
			this.panel41.Size = new Size(24, 36);
			this.panel41.TabIndex = 58;
			this.pbDalete2.Cursor = Cursors.Hand;
			this.pbDalete2.Dock = DockStyle.Right;
			this.pbDalete2.Image = Resources.minus;
			this.pbDalete2.Location = new Point(448, 0);
			this.pbDalete2.Name = "pbDalete2";
			this.pbDalete2.Padding = new Padding(3);
			this.pbDalete2.Size = new Size(35, 36);
			this.pbDalete2.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbDalete2.TabIndex = 57;
			this.pbDalete2.TabStop = false;
			this.pbDalete2.Click += this.pbDalete2_Click;
			this.label32.AutoSize = true;
			this.label32.Dock = DockStyle.Top;
			this.label32.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label32.Location = new Point(3, 21);
			this.label32.Margin = new Padding(3);
			this.label32.Name = "label32";
			this.label32.Padding = new Padding(3);
			this.label32.Size = new Size(420, 23);
			this.label32.TabIndex = 56;
			this.label32.Text = "※첨부파일 총 용량은 10MB까지 입니다. 반드시 확인 부탁드립니다.";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.gbActionAttach);
			base.Controls.Add(this.gbPart);
			base.Name = "ActionOther";
			base.Size = new Size(489, 379);
			this.gbPart.ResumeLayout(false);
			this.gbPart.PerformLayout();
			((ISupportInitialize)this.partGridView).EndInit();
			this.panel39.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((ISupportInitialize)this.pbPartAdd).EndInit();
			this.gbActionAttach.ResumeLayout(false);
			this.gbActionAttach.PerformLayout();
			((ISupportInitialize)this.dgAttachmentList).EndInit();
			this.panel40.ResumeLayout(false);
			((ISupportInitialize)this.pbAdd).EndInit();
			((ISupportInitialize)this.pbDalete2).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400067D RID: 1661
		private cReportItem _report;

		// Token: 0x0400067E RID: 1662
		private List<string> _PartList = new List<string>();

		// Token: 0x0400067F RID: 1663
		private List<string> _PartDescription = new List<string>();

		// Token: 0x04000680 RID: 1664
		private long _lTotalByte = 0L;

		// Token: 0x04000681 RID: 1665
		private readonly long _lMaximumByte = 10485760L;

		// Token: 0x04000682 RID: 1666
		private List<cFileList> _lFileList = new List<cFileList>();

		// Token: 0x04000683 RID: 1667
		private bool _bLockEvent = false;

		// Token: 0x04000684 RID: 1668
		private BarPrograss _barPrograss = null;

		// Token: 0x04000685 RID: 1669
		private Thread _thread = null;

		// Token: 0x04000686 RID: 1670
		private IContainer components = null;

		// Token: 0x04000687 RID: 1671
		private GroupBox gbPart;

		// Token: 0x04000688 RID: 1672
		private Panel panel39;

		// Token: 0x04000689 RID: 1673
		private PictureBox pbPartAdd;

		// Token: 0x0400068A RID: 1674
		private DataGridView partGridView;

		// Token: 0x0400068B RID: 1675
		private DataGridViewTextBoxColumn Column1;

		// Token: 0x0400068C RID: 1676
		private DataGridViewTextBoxColumn Column2;

		// Token: 0x0400068D RID: 1677
		private DataGridViewTextBoxColumn Column3;

		// Token: 0x0400068E RID: 1678
		private Label label18;

		// Token: 0x0400068F RID: 1679
		private GroupBox gbActionAttach;

		// Token: 0x04000690 RID: 1680
		private Panel panel40;

		// Token: 0x04000691 RID: 1681
		private PictureBox pbAdd;

		// Token: 0x04000692 RID: 1682
		private Panel panel41;

		// Token: 0x04000693 RID: 1683
		private PictureBox pbDalete2;

		// Token: 0x04000694 RID: 1684
		private DataGridView dgAttachmentList;

		// Token: 0x04000695 RID: 1685
		private Label label32;

		// Token: 0x04000696 RID: 1686
		private Panel panel1;

		// Token: 0x04000697 RID: 1687
		private OpenFileDialog openFileDialog;

		// Token: 0x04000698 RID: 1688
		private CheckBox cbNoReplacementParts;
	}
}
