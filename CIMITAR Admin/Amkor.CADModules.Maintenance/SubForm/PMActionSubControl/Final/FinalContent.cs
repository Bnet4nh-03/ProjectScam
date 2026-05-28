using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using SevenZip;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Final
{
	// Token: 0x02000024 RID: 36
	public class FinalContent : UserControl
	{
		// Token: 0x0600026A RID: 618 RVA: 0x000569EE File Offset: 0x00054BEE
		public void clear()
		{
			this.rbContent6.Text = this._sFinalInit;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00056A02 File Offset: 0x00054C02
		public string getFinalText()
		{
			return this.rbContent6.Text.Trim();
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00056A14 File Offset: 0x00054C14
		public string getFinalRTF()
		{
			return this.rbContent6.Rtf.Trim();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00056A26 File Offset: 0x00054C26
		public string getFinal64String()
		{
			return cFunction.MakeRFTFile(this.rbContent6);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00056A34 File Offset: 0x00054C34
		public FinalContent(cReportItem report)
		{
			this.InitializeComponent();
			this.label42.Text = MessageLanguage.getMessage("label_email_size");
			this.rbContent6.Tag = "6";
			this.rbContent6.Text = this._sFinalInit;
			bool flag = report.sReportStauts == "14";
			if (flag)
			{
				this.rbContent6.ReadOnly = true;
				cFunction.ExcuteSevenZipReport(report.sBinary6, this.rbContent6);
				this.ExcuteSevenZipMail(report.sPMFinalMail);
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00056AE4 File Offset: 0x00054CE4
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
				bool flag5 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content4.html");
				if (flag5)
				{
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content4.html");
				}
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZipMail", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\PMActionControl\\Final\\FinalContent.cs", 68);
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

		// Token: 0x06000270 RID: 624 RVA: 0x00056C54 File Offset: 0x00054E54
		public bool checkFinalText()
		{
			return this.rbContent6.Text.Trim() == string.Empty || this.rbContent6.Text == this._sFinalInit;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00056CA4 File Offset: 0x00054EA4
		private void rbContent6_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = this.rbContent6.Text.Trim() == this._sFinalInit;
			if (flag)
			{
				this.rbContent6.Text = string.Empty;
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00056CE4 File Offset: 0x00054EE4
		private void rbContent6_Enter(object sender, EventArgs e)
		{
			bool flag = this.rbContent6.Text.Trim() == this._sFinalInit;
			if (flag)
			{
				this.rbContent6.Text = string.Empty;
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00056D24 File Offset: 0x00054F24
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00056D5C File Offset: 0x00054F5C
		private void InitializeComponent()
		{
			this.panel52 = new Panel();
			this.panel53 = new Panel();
			this.rbContent6 = new RichTextBox();
			this.panel56 = new Panel();
			this.label42 = new Label();
			this.label43 = new Label();
			this.panel52.SuspendLayout();
			this.panel53.SuspendLayout();
			this.panel56.SuspendLayout();
			base.SuspendLayout();
			this.panel52.Controls.Add(this.panel53);
			this.panel52.Controls.Add(this.panel56);
			this.panel52.Dock = DockStyle.Fill;
			this.panel52.Location = new Point(0, 0);
			this.panel52.Name = "panel52";
			this.panel52.Size = new Size(1028, 431);
			this.panel52.TabIndex = 1;
			this.panel53.Controls.Add(this.rbContent6);
			this.panel53.Dock = DockStyle.Fill;
			this.panel53.Location = new Point(0, 21);
			this.panel53.Name = "panel53";
			this.panel53.Size = new Size(1028, 410);
			this.panel53.TabIndex = 1;
			this.rbContent6.Dock = DockStyle.Fill;
			this.rbContent6.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rbContent6.Location = new Point(0, 0);
			this.rbContent6.Name = "rbContent6";
			this.rbContent6.Size = new Size(1028, 410);
			this.rbContent6.TabIndex = 36;
			this.rbContent6.Text = "";
			this.rbContent6.Enter += this.rbContent6_Enter;
			this.rbContent6.MouseDown += this.rbContent6_MouseDown;
			this.panel56.Controls.Add(this.label42);
			this.panel56.Controls.Add(this.label43);
			this.panel56.Dock = DockStyle.Top;
			this.panel56.Location = new Point(0, 0);
			this.panel56.Name = "panel56";
			this.panel56.Size = new Size(1028, 21);
			this.panel56.TabIndex = 0;
			this.label42.AutoSize = true;
			this.label42.Dock = DockStyle.Right;
			this.label42.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label42.Location = new Point(784, 0);
			this.label42.Name = "label42";
			this.label42.Size = new Size(244, 17);
			this.label42.TabIndex = 42;
			this.label42.Text = "※발송 메일의 용량은 1MB까지 입니다.";
			this.label43.AutoEllipsis = true;
			this.label43.Dock = DockStyle.Left;
			this.label43.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label43.Location = new Point(0, 0);
			this.label43.Name = "label43";
			this.label43.Size = new Size(154, 21);
			this.label43.TabIndex = 35;
			this.label43.Text = "Final Approval";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel52);
			base.Name = "FinalContent";
			base.Size = new Size(1028, 431);
			this.panel52.ResumeLayout(false);
			this.panel53.ResumeLayout(false);
			this.panel56.ResumeLayout(false);
			this.panel56.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400046E RID: 1134
		private readonly string _sFinalInit = MessageLanguage.getMessage("pm_final_approval_tip");

		// Token: 0x0400046F RID: 1135
		private IContainer components = null;

		// Token: 0x04000470 RID: 1136
		private Panel panel52;

		// Token: 0x04000471 RID: 1137
		private Panel panel53;

		// Token: 0x04000472 RID: 1138
		private RichTextBox rbContent6;

		// Token: 0x04000473 RID: 1139
		private Panel panel56;

		// Token: 0x04000474 RID: 1140
		private Label label42;

		// Token: 0x04000475 RID: 1141
		private Label label43;
	}
}
