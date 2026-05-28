using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.SubForm.SubControl;

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x0200004B RID: 75
	public class ReportAttachmentFile : UserControl
	{
		// Token: 0x06000438 RID: 1080 RVA: 0x0007D574 File Offset: 0x0007B774
		public ReportAttachmentFile(cReportItem report)
		{
			this.InitializeComponent();
			this._report = report;
			bool flag = !string.IsNullOrEmpty(report.Attachment.Trim()) && report.Attachment.Length > 1;
			if (flag)
			{
				this.gbReportAttachment.Visible = true;
				string[] array = report.Attachment.Split(new char[]
				{
					';'
				});
				this.dgAttachmentList.ColumnCount = 1;
				bool flag2 = array.Length != 0;
				if (flag2)
				{
					this.dgAttachmentList.RowCount = array.Length;
					for (int i = 0; i < array.Length; i++)
					{
						bool flag3 = array[i].Trim().Length > 0;
						if (flag3)
						{
							this.dgAttachmentList.Rows[i].Cells[0].Value = array[i].Substring(array[i].LastIndexOf('\\') + 1);
						}
					}
				}
			}
			else
			{
				this.gbReportAttachment.Visible = false;
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x0007D69F File Offset: 0x0007B89F
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x0007D6B0 File Offset: 0x0007B8B0
		private void dgAttachmentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
									"\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\Report\\",
									dateTime.Year.ToString(),
									"\\",
									dateTime.Month,
									"\\",
									dateTime.Day,
									"\\",
									this._report.sReportName.Replace("/", "_").Trim(),
									".zip"
								});
							}
							string text2 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\" + this._report.sReportName.Replace("/", "_").Trim() + ".zip";
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

		// Token: 0x0600043B RID: 1083 RVA: 0x0007DA84 File Offset: 0x0007BC84
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0007DABC File Offset: 0x0007BCBC
		private void InitializeComponent()
		{
			this.gbReportAttachment = new GroupBox();
			this.panel45 = new Panel();
			this.dgAttachmentList = new DataGridView();
			this.gbReportAttachment.SuspendLayout();
			((ISupportInitialize)this.dgAttachmentList).BeginInit();
			base.SuspendLayout();
			this.gbReportAttachment.Controls.Add(this.panel45);
			this.gbReportAttachment.Controls.Add(this.dgAttachmentList);
			this.gbReportAttachment.Dock = DockStyle.Top;
			this.gbReportAttachment.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gbReportAttachment.Location = new Point(0, 0);
			this.gbReportAttachment.Name = "gbReportAttachment";
			this.gbReportAttachment.Size = new Size(361, 135);
			this.gbReportAttachment.TabIndex = 103;
			this.gbReportAttachment.TabStop = false;
			this.gbReportAttachment.Text = "Attachment File";
			this.gbReportAttachment.Visible = false;
			this.panel45.Dock = DockStyle.Fill;
			this.panel45.Location = new Point(3, 129);
			this.panel45.Name = "panel45";
			this.panel45.Size = new Size(355, 3);
			this.panel45.TabIndex = 57;
			this.dgAttachmentList.AllowUserToDeleteRows = false;
			this.dgAttachmentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgAttachmentList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			this.dgAttachmentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgAttachmentList.ColumnHeadersVisible = false;
			this.dgAttachmentList.Dock = DockStyle.Top;
			this.dgAttachmentList.GridColor = Color.White;
			this.dgAttachmentList.Location = new Point(3, 21);
			this.dgAttachmentList.MultiSelect = false;
			this.dgAttachmentList.Name = "dgAttachmentList";
			this.dgAttachmentList.ReadOnly = true;
			this.dgAttachmentList.RowHeadersVisible = false;
			this.dgAttachmentList.RowTemplate.Height = 23;
			this.dgAttachmentList.Size = new Size(355, 108);
			this.dgAttachmentList.TabIndex = 44;
			this.dgAttachmentList.CellDoubleClick += this.dgAttachmentList_CellDoubleClick;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.gbReportAttachment);
			base.Name = "AttachmentFile";
			base.Size = new Size(361, 135);
			this.gbReportAttachment.ResumeLayout(false);
			((ISupportInitialize)this.dgAttachmentList).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040006BD RID: 1725
		private bool _bLockEvent = false;

		// Token: 0x040006BE RID: 1726
		private BarPrograss _barPrograss = null;

		// Token: 0x040006BF RID: 1727
		private Thread _thread = null;

		// Token: 0x040006C0 RID: 1728
		private cReportItem _report;

		// Token: 0x040006C1 RID: 1729
		private IContainer components = null;

		// Token: 0x040006C2 RID: 1730
		private GroupBox gbReportAttachment;

		// Token: 0x040006C3 RID: 1731
		private Panel panel45;

		// Token: 0x040006C4 RID: 1732
		private DataGridView dgAttachmentList;
	}
}
