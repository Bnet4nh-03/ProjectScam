using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using SevenZip;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Action
{
	// Token: 0x02000029 RID: 41
	public class ActionContent : UserControl
	{
		// Token: 0x06000293 RID: 659 RVA: 0x0005A663 File Offset: 0x00058863
		public string getActionRTF()
		{
			return this.rbContent3.Rtf;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0005A670 File Offset: 0x00058870
		public string getActionText()
		{
			return this.rbContent3.Text.Trim();
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0005A682 File Offset: 0x00058882
		public string getResultRTF()
		{
			return this.rbContent4.Rtf;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0005A68F File Offset: 0x0005888F
		public string getResultText()
		{
			return this.rbContent4.Text.Trim();
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0005A6A1 File Offset: 0x000588A1
		public string getCommentRTF()
		{
			return this.rbContent5.Rtf;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0005A6AE File Offset: 0x000588AE
		public string getCommentText()
		{
			return this.rbContent5.Text.Trim();
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0005A6C0 File Offset: 0x000588C0
		public string getAction64String()
		{
			return cFunction.MakeRFTFile(this.rbContent3);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0005A6CD File Offset: 0x000588CD
		public string getResult64String()
		{
			return cFunction.MakeRFTFile(this.rbContent4);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0005A6DA File Offset: 0x000588DA
		public string getComment64String()
		{
			return cFunction.MakeRFTFile(this.rbContent5);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0005A6E8 File Offset: 0x000588E8
		private void ActionContent_Resize(object sender, EventArgs e)
		{
			this.pnContent3.Height = (this.pnContent4.Height = (this.pnContent5.Height = base.Height / 3));
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0005A728 File Offset: 0x00058928
		public ActionContent(cReportItem report)
		{
			this.InitializeComponent();
			this.label33.Text = MessageLanguage.getMessage("label_email_size");
			this.rbContent3.Tag = "3";
			this.rbContent4.Tag = "4";
			this.rbContent5.Tag = "5";
			bool flag = report.sReportStauts == "12";
			if (flag)
			{
				this.rbContent3.Text = this._sActionInit;
				this.rbContent4.Text = this._sResultInit;
				this.rbContent5.Text = this._sCommentInit;
			}
			else
			{
				bool flag2 = report.sReportStauts == "13" || report.sReportStauts == "14";
				if (flag2)
				{
					cFunction.ExcuteSevenZipReport(report.sBinary3, this.rbContent3);
					cFunction.ExcuteSevenZipReport(report.sBinary4, this.rbContent4);
					cFunction.ExcuteSevenZipReport(report.sBinary5, this.rbContent5);
					this.ExcuteSevenZipMail(report.sPMDoneMail);
					this.rbContent3.ReadOnly = (this.rbContent4.ReadOnly = (this.rbContent5.ReadOnly = true));
					this.rbContent3.BackColor = (this.rbContent4.BackColor = (this.rbContent5.BackColor = Color.Gainsboro));
				}
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0005A8EC File Offset: 0x00058AEC
		public void clear()
		{
			this.rbContent3.Text = this._sActionInit;
			this.rbContent4.Text = this._sResultInit;
			this.rbContent5.Text = this._sCommentInit;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0005A928 File Offset: 0x00058B28
		private void ExcuteSevenZipMail(string sBody)
		{
			SevenZipExtractor sevenZipExtractor = null;
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
					FileStream fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z", FileMode.Create);
					fileStream.Write(array, 0, array.Length);
					bool flag3 = fileStream != null;
					if (flag3)
					{
						fileStream.Close();
					}
					sevenZipExtractor = new SevenZipExtractor("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z");
					bool flag4 = sevenZipExtractor == null;
					if (flag4)
					{
						throw new Exception("ZipExtractor(ExcuteSevenZipMail) Error");
					}
					bool flag5 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z");
					if (flag5)
					{
						sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM");
					}
				}
			}
			catch (Exception ex)
			{
				bool flag6 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content3.html");
				if (flag6)
				{
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content3.html");
				}
			}
			finally
			{
				bool flag7 = sevenZipExtractor != null;
				if (flag7)
				{
					sevenZipExtractor.Dispose();
				}
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0005AA64 File Offset: 0x00058C64
		private void ExcuteSevenZipReport(string sBody, RichTextBox rb)
		{
			SevenZipExtractor sevenZipExtractor = null;
			FileStream fileStream = null;
			try
			{
				bool flag = string.IsNullOrEmpty(sBody);
				if (!flag)
				{
					byte[] array = Convert.FromBase64String(sBody);
					string text = string.Empty;
					bool flag2 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.7z");
					if (flag2)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.7z");
					}
					bool flag3 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content2.7z");
					if (flag3)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content2.7z");
					}
					bool flag4 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.7z");
					if (flag4)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.7z");
					}
					bool flag5 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.7z");
					if (flag5)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.7z");
					}
					bool flag6 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.7z");
					if (flag6)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.7z");
					}
					bool flag7 = rb != null;
					if (flag7)
					{
						bool flag8 = rb.Equals(this.rbContent3);
						if (flag8)
						{
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.7z";
						}
						bool flag9 = rb.Equals(this.rbContent4);
						if (flag9)
						{
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.7z";
						}
						bool flag10 = rb.Equals(this.rbContent5);
						if (flag10)
						{
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.7z";
						}
					}
					else
					{
						fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.7z", FileMode.Create);
						text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.7z";
					}
					bool flag11 = fileStream != null;
					if (flag11)
					{
						fileStream.Write(array, 0, array.Length);
						fileStream.Close();
						bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
						if (is64BitOperatingSystem)
						{
							SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x64.dll");
						}
						else
						{
							SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x86.dll");
						}
						sevenZipExtractor = new SevenZipExtractor(text);
						bool flag12 = File.Exists(text);
						if (flag12)
						{
							sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
						}
						bool flag13 = rb != null;
						if (flag13)
						{
							bool flag14 = array.Length != 0 && File.Exists(text);
							if (flag14)
							{
								bool flag15 = rb.Equals(this.rbContent3);
								if (flag15)
								{
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.rtf", FileMode.Open);
								}
								bool flag16 = rb.Equals(this.rbContent4);
								if (flag16)
								{
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.rtf", FileMode.Open);
								}
								bool flag17 = rb.Equals(this.rbContent5);
								if (flag17)
								{
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.rtf", FileMode.Open);
								}
							}
							else
							{
								fileStream = null;
							}
							bool flag18 = fileStream != null;
							if (flag18)
							{
								array = new byte[fileStream.Length];
								fileStream.Read(array, 0, array.Length);
								fileStream.Close();
								rb.Rtf = Encoding.ASCII.GetString(array);
							}
							else
							{
								rb.Text = string.Empty;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				rb.Text = string.Empty;
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZipReport", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\PMActionControl\\Action\\ActionContent.cs", 220);
			}
			finally
			{
				bool flag19 = sevenZipExtractor != null;
				if (flag19)
				{
					sevenZipExtractor.Dispose();
				}
				bool flag20 = fileStream != null;
				if (flag20)
				{
					fileStream.Dispose();
				}
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0005AD8C File Offset: 0x00058F8C
		private void rbContent3_Enter(object sender, EventArgs e)
		{
			RichTextBox richTextBox = (RichTextBox)sender;
			bool flag = richTextBox.Equals(this.rbContent3) && richTextBox.Text == this._sActionInit;
			if (flag)
			{
				this.rbContent3.Text = string.Empty;
			}
			else
			{
				bool flag2 = richTextBox.Equals(this.rbContent4) && richTextBox.Text == this._sResultInit;
				if (flag2)
				{
					this.rbContent4.Text = string.Empty;
				}
				else
				{
					bool flag3 = richTextBox.Equals(this.rbContent5) && richTextBox.Text == this._sCommentInit;
					if (flag3)
					{
						this.rbContent5.Text = string.Empty;
					}
				}
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0005AE4C File Offset: 0x0005904C
		public bool isProblemEmpty()
		{
			return this.rbContent3.Text.Length == 0 || this.rbContent3.Text == this._sActionInit;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0005AE94 File Offset: 0x00059094
		public bool isResultEmpty()
		{
			return this.rbContent4.Text.Length == 0 || this.rbContent4.Text == this._sResultInit;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0005AEDC File Offset: 0x000590DC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0005AF14 File Offset: 0x00059114
		private void InitializeComponent()
		{
			this.pnContent5 = new Panel();
			this.panel33 = new Panel();
			this.rbContent5 = new RichTextBox();
			this.panel34 = new Panel();
			this.label31 = new Label();
			this.pnContent4 = new Panel();
			this.panel26 = new Panel();
			this.rbContent4 = new RichTextBox();
			this.panel27 = new Panel();
			this.label21 = new Label();
			this.pnContent3 = new Panel();
			this.panel4444 = new Panel();
			this.rbContent3 = new RichTextBox();
			this.panel20 = new Panel();
			this.label33 = new Label();
			this.lbContent3 = new Label();
			this.pnContent5.SuspendLayout();
			this.panel33.SuspendLayout();
			this.panel34.SuspendLayout();
			this.pnContent4.SuspendLayout();
			this.panel26.SuspendLayout();
			this.panel27.SuspendLayout();
			this.pnContent3.SuspendLayout();
			this.panel4444.SuspendLayout();
			this.panel20.SuspendLayout();
			base.SuspendLayout();
			this.pnContent5.Controls.Add(this.panel33);
			this.pnContent5.Controls.Add(this.panel34);
			this.pnContent5.Dock = DockStyle.Top;
			this.pnContent5.Location = new Point(0, 360);
			this.pnContent5.Name = "pnContent5";
			this.pnContent5.Size = new Size(933, 199);
			this.pnContent5.TabIndex = 2;
			this.panel33.Controls.Add(this.rbContent5);
			this.panel33.Dock = DockStyle.Fill;
			this.panel33.Location = new Point(0, 21);
			this.panel33.Name = "panel33";
			this.panel33.Size = new Size(933, 178);
			this.panel33.TabIndex = 1;
			this.rbContent5.Dock = DockStyle.Fill;
			this.rbContent5.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rbContent5.Location = new Point(0, 0);
			this.rbContent5.Name = "rbContent5";
			this.rbContent5.Size = new Size(933, 178);
			this.rbContent5.TabIndex = 36;
			this.rbContent5.Text = "";
			this.rbContent5.Enter += this.rbContent3_Enter;
			this.panel34.Controls.Add(this.label31);
			this.panel34.Dock = DockStyle.Top;
			this.panel34.Location = new Point(0, 0);
			this.panel34.Name = "panel34";
			this.panel34.Size = new Size(933, 21);
			this.panel34.TabIndex = 0;
			this.label31.AutoEllipsis = true;
			this.label31.Dock = DockStyle.Left;
			this.label31.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label31.Location = new Point(0, 0);
			this.label31.Name = "label31";
			this.label31.Size = new Size(154, 21);
			this.label31.TabIndex = 35;
			this.label31.Text = "Comment";
			this.pnContent4.Controls.Add(this.panel26);
			this.pnContent4.Controls.Add(this.panel27);
			this.pnContent4.Dock = DockStyle.Top;
			this.pnContent4.Location = new Point(0, 180);
			this.pnContent4.Name = "pnContent4";
			this.pnContent4.Size = new Size(933, 180);
			this.pnContent4.TabIndex = 1;
			this.panel26.Controls.Add(this.rbContent4);
			this.panel26.Dock = DockStyle.Fill;
			this.panel26.Location = new Point(0, 21);
			this.panel26.Name = "panel26";
			this.panel26.Size = new Size(933, 159);
			this.panel26.TabIndex = 1;
			this.rbContent4.Dock = DockStyle.Fill;
			this.rbContent4.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rbContent4.Location = new Point(0, 0);
			this.rbContent4.Name = "rbContent4";
			this.rbContent4.Size = new Size(933, 159);
			this.rbContent4.TabIndex = 36;
			this.rbContent4.Text = "";
			this.rbContent4.Enter += this.rbContent3_Enter;
			this.panel27.Controls.Add(this.label21);
			this.panel27.Dock = DockStyle.Top;
			this.panel27.Location = new Point(0, 0);
			this.panel27.Name = "panel27";
			this.panel27.Size = new Size(933, 21);
			this.panel27.TabIndex = 0;
			this.label21.AutoEllipsis = true;
			this.label21.Dock = DockStyle.Left;
			this.label21.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label21.Location = new Point(0, 0);
			this.label21.Name = "label21";
			this.label21.Size = new Size(154, 21);
			this.label21.TabIndex = 35;
			this.label21.Text = "Result and Evaluation";
			this.pnContent3.Controls.Add(this.panel4444);
			this.pnContent3.Controls.Add(this.panel20);
			this.pnContent3.Dock = DockStyle.Top;
			this.pnContent3.Location = new Point(0, 0);
			this.pnContent3.Name = "pnContent3";
			this.pnContent3.Size = new Size(933, 180);
			this.pnContent3.TabIndex = 0;
			this.panel4444.Controls.Add(this.rbContent3);
			this.panel4444.Dock = DockStyle.Fill;
			this.panel4444.Location = new Point(0, 21);
			this.panel4444.Name = "panel4444";
			this.panel4444.Size = new Size(933, 159);
			this.panel4444.TabIndex = 1;
			this.rbContent3.Dock = DockStyle.Fill;
			this.rbContent3.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rbContent3.Location = new Point(0, 0);
			this.rbContent3.Name = "rbContent3";
			this.rbContent3.Size = new Size(933, 159);
			this.rbContent3.TabIndex = 36;
			this.rbContent3.Text = "";
			this.rbContent3.Enter += this.rbContent3_Enter;
			this.panel20.Controls.Add(this.label33);
			this.panel20.Controls.Add(this.lbContent3);
			this.panel20.Dock = DockStyle.Top;
			this.panel20.Location = new Point(0, 0);
			this.panel20.Name = "panel20";
			this.panel20.Size = new Size(933, 21);
			this.panel20.TabIndex = 0;
			this.label33.AutoSize = true;
			this.label33.Dock = DockStyle.Right;
			this.label33.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label33.Location = new Point(689, 0);
			this.label33.Name = "label33";
			this.label33.Size = new Size(244, 17);
			this.label33.TabIndex = 42;
			this.label33.Text = "※발송 메일의 용량은 1MB까지 입니다.";
			this.lbContent3.AutoEllipsis = true;
			this.lbContent3.Dock = DockStyle.Left;
			this.lbContent3.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lbContent3.Location = new Point(0, 0);
			this.lbContent3.Name = "lbContent3";
			this.lbContent3.Size = new Size(154, 21);
			this.lbContent3.TabIndex = 35;
			this.lbContent3.Text = "Actions and changes";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.pnContent5);
			base.Controls.Add(this.pnContent4);
			base.Controls.Add(this.pnContent3);
			base.Name = "ActionContent";
			base.Size = new Size(933, 562);
			base.Resize += this.ActionContent_Resize;
			this.pnContent5.ResumeLayout(false);
			this.panel33.ResumeLayout(false);
			this.panel34.ResumeLayout(false);
			this.pnContent4.ResumeLayout(false);
			this.panel26.ResumeLayout(false);
			this.panel27.ResumeLayout(false);
			this.pnContent3.ResumeLayout(false);
			this.panel4444.ResumeLayout(false);
			this.panel20.ResumeLayout(false);
			this.panel20.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040004AB RID: 1195
		private readonly string _sActionInit = MessageLanguage.getMessage("pm_action_tip");

		// Token: 0x040004AC RID: 1196
		private readonly string _sResultInit = MessageLanguage.getMessage("pm_result_tip");

		// Token: 0x040004AD RID: 1197
		private readonly string _sCommentInit = MessageLanguage.getMessage("pm_comment_tip");

		// Token: 0x040004AE RID: 1198
		private long _fileSizeRTF = 0L;

		// Token: 0x040004AF RID: 1199
		private IContainer components = null;

		// Token: 0x040004B0 RID: 1200
		private Panel pnContent5;

		// Token: 0x040004B1 RID: 1201
		private Panel panel33;

		// Token: 0x040004B2 RID: 1202
		private RichTextBox rbContent5;

		// Token: 0x040004B3 RID: 1203
		private Panel panel34;

		// Token: 0x040004B4 RID: 1204
		private Label label31;

		// Token: 0x040004B5 RID: 1205
		private Panel pnContent4;

		// Token: 0x040004B6 RID: 1206
		private Panel panel26;

		// Token: 0x040004B7 RID: 1207
		private RichTextBox rbContent4;

		// Token: 0x040004B8 RID: 1208
		private Panel panel27;

		// Token: 0x040004B9 RID: 1209
		private Label label21;

		// Token: 0x040004BA RID: 1210
		private Panel pnContent3;

		// Token: 0x040004BB RID: 1211
		private Panel panel4444;

		// Token: 0x040004BC RID: 1212
		private RichTextBox rbContent3;

		// Token: 0x040004BD RID: 1213
		private Panel panel20;

		// Token: 0x040004BE RID: 1214
		private Label label33;

		// Token: 0x040004BF RID: 1215
		private Label lbContent3;
	}
}
