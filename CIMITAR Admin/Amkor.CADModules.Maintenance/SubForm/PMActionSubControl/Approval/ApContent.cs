using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using SevenZip;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Approval
{
	// Token: 0x02000022 RID: 34
	public class ApContent : UserControl
	{
		// Token: 0x06000259 RID: 601 RVA: 0x00055BB6 File Offset: 0x00053DB6
		private void rbContent2_MouseDown(object sender, MouseEventArgs e)
		{
			this.rbContent2_Enter(null, null);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00055BC1 File Offset: 0x00053DC1
		public string getBase64String()
		{
			return cFunction.MakeRFTFile(this.rbContent2);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00055BCE File Offset: 0x00053DCE
		public void clear()
		{
			this.rbContent2.Text = this._sApprovalInit;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00055BE2 File Offset: 0x00053DE2
		public string getApprovalString()
		{
			return this.rbContent2.Text.Trim();
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00055BF4 File Offset: 0x00053DF4
		public string getApprovalRTF()
		{
			return this.rbContent2.Rtf;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00055C04 File Offset: 0x00053E04
		public ApContent(cReportItem report)
		{
			this.InitializeComponent();
			this.clear();
			this.label8.Text = MessageLanguage.getMessage("label_email_size");
			this.rbContent2.Tag = "2";
			bool flag = report.sReportStauts == "11";
			if (!flag)
			{
				bool flag2 = report.sReportStauts == "12";
				if (flag2)
				{
					this.rbContent2.ReadOnly = true;
				}
				else
				{
					bool flag3 = report.sReportStauts == "13" || report.sReportStauts == "14";
					if (flag3)
					{
						this.rbContent2.ReadOnly = true;
					}
					else
					{
						bool flag4 = report.sReportStauts == "97" || report.sReportStauts == "98" || report.sReportStauts == "96";
						if (flag4)
						{
							this.rbContent2.ReadOnly = true;
						}
					}
				}
			}
			bool flag5 = report.sReportStauts == "12" || report.sReportStauts == "13" || report.sReportStauts == "14" || report.sReportStauts == "96";
			if (flag5)
			{
				cFunction.ExcuteSevenZipReport(report.sBinary2, this.rbContent2);
				this.ExcuteSevenZipMail(report.sApprovalMail);
			}
			else
			{
				bool flag6 = report.sReportStauts == "97" || report.sReportStauts == "98";
				if (flag6)
				{
				}
			}
			bool flag7 = report.sReportStauts == "13" || report.sReportStauts == "14";
			if (flag7)
			{
			}
			bool flag8 = report.sReportStauts == "14";
			if (flag8)
			{
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00055E18 File Offset: 0x00054018
		private void ExcuteSevenZipMail(string sBody)
		{
			SevenZipExtractor sevenZipExtractor = null;
			FileStream fileStream = null;
			try
			{
				bool flag = string.IsNullOrEmpty(sBody);
				if (!flag)
				{
					byte[] array = Convert.FromBase64String(sBody);
					bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
					if (is64BitOperatingSystem)
					{
						SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x64.dll");
					}
					else
					{
						SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x86.dll");
					}
					bool flag2 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z");
					if (flag2)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z");
					}
					fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z", FileMode.Create);
					fileStream.Write(array, 0, array.Length);
					bool flag3 = fileStream != null;
					if (flag3)
					{
						fileStream.Close();
					}
					sevenZipExtractor = new SevenZipExtractor("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z");
					bool flag4 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z");
					if (flag4)
					{
						sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM");
					}
				}
			}
			catch (Exception ex)
			{
				bool flag5 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content2.html");
				if (flag5)
				{
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content2.html");
				}
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZipMail", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\PMActionControl\\Approval\\ApContent.cs", 114);
			}
			finally
			{
				bool flag6 = sevenZipExtractor != null;
				if (flag6)
				{
					sevenZipExtractor.Dispose();
				}
				bool flag7 = fileStream != null;
				if (flag7)
				{
					fileStream.Dispose();
				}
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00055F88 File Offset: 0x00054188
		public bool checkApprovalString()
		{
			return this.rbContent2.Text.Trim().Length == 0 || this.rbContent2.Text == this._sApprovalInit;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00055FD4 File Offset: 0x000541D4
		private void rbContent2_Enter(object sender, EventArgs e)
		{
			bool flag = this.rbContent2.Text == this._sApprovalInit;
			if (flag)
			{
				this.rbContent2.Text = string.Empty;
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00056010 File Offset: 0x00054210
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00056048 File Offset: 0x00054248
		private void InitializeComponent()
		{
			this.rbContent2 = new RichTextBox();
			this.panel13 = new Panel();
			this.label8 = new Label();
			this.label9 = new Label();
			this.panel13.SuspendLayout();
			base.SuspendLayout();
			this.rbContent2.Dock = DockStyle.Fill;
			this.rbContent2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rbContent2.Location = new Point(0, 21);
			this.rbContent2.Name = "rbContent2";
			this.rbContent2.Size = new Size(642, 277);
			this.rbContent2.TabIndex = 36;
			this.rbContent2.Text = "※ 장비 사용 승인과 관련 전달사항을 남겨 주시기 바랍니다.";
			this.rbContent2.Enter += this.rbContent2_Enter;
			this.rbContent2.MouseDown += this.rbContent2_MouseDown;
			this.panel13.Controls.Add(this.label8);
			this.panel13.Controls.Add(this.label9);
			this.panel13.Dock = DockStyle.Top;
			this.panel13.Location = new Point(0, 0);
			this.panel13.Name = "panel13";
			this.panel13.Size = new Size(642, 21);
			this.panel13.TabIndex = 2;
			this.label8.AutoSize = true;
			this.label8.Dock = DockStyle.Right;
			this.label8.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label8.Location = new Point(398, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(244, 17);
			this.label8.TabIndex = 42;
			this.label8.Text = "※발송 메일의 용량은 1MB까지 입니다.";
			this.label9.AutoEllipsis = true;
			this.label9.AutoSize = true;
			this.label9.Dock = DockStyle.Left;
			this.label9.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label9.Location = new Point(0, 0);
			this.label9.Name = "label9";
			this.label9.Size = new Size(121, 17);
			this.label9.TabIndex = 35;
			this.label9.Text = "Approval Comment";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.rbContent2);
			base.Controls.Add(this.panel13);
			base.Name = "ApContent";
			base.Size = new Size(642, 298);
			this.panel13.ResumeLayout(false);
			this.panel13.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000460 RID: 1120
		private readonly string _sApprovalInit = MessageLanguage.getMessage("pm_approval_tip");

		// Token: 0x04000461 RID: 1121
		private long _fileSizeRTF = 0L;

		// Token: 0x04000462 RID: 1122
		private IContainer components = null;

		// Token: 0x04000463 RID: 1123
		private RichTextBox rbContent2;

		// Token: 0x04000464 RID: 1124
		private Panel panel13;

		// Token: 0x04000465 RID: 1125
		private Label label8;

		// Token: 0x04000466 RID: 1126
		private Label label9;
	}
}
