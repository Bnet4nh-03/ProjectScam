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

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl
{
	// Token: 0x02000021 RID: 33
	public class PMRequestContent : UserControl
	{
		// Token: 0x06000248 RID: 584 RVA: 0x00054ABA File Offset: 0x00052CBA
		public string getProblemString()
		{
			return this.rbContent1.Text.Trim();
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00054ACC File Offset: 0x00052CCC
		public string getProblemRTF()
		{
			return this.rbContent1.Rtf;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00054AD9 File Offset: 0x00052CD9
		public string getEvidenceString()
		{
			return this.rbContent8.Text.Trim();
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00054AEB File Offset: 0x00052CEB
		public string getEvidenceRTF()
		{
			return this.rbContent8.Rtf;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00054AF8 File Offset: 0x00052CF8
		private void panel8_Resize(object sender, EventArgs e)
		{
			this.panel_CheckBase.Height = (this.panel47.Height = base.Height / 2);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00054B28 File Offset: 0x00052D28
		public string getProblem64String()
		{
			return cFunction.MakeRFTFile(this.rbContent1);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00054B35 File Offset: 0x00052D35
		public string getEvidence64String()
		{
			return cFunction.MakeRFTFile(this.rbContent8);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00054B44 File Offset: 0x00052D44
		public PMRequestContent(cReportItem report)
		{
			this._report = report;
			this.InitializeComponent();
			this.label34.Text = MessageLanguage.getMessage("label_email_size");
			this.rbContent1.Tag = "1";
			this.rbContent8.Tag = "8";
			bool flag = report.sReportStauts == "11";
			if (flag)
			{
				this.rbContent1.ReadOnly = true;
				this.rbContent8.ReadOnly = true;
			}
			else
			{
				bool flag2 = report.sReportStauts == "12";
				if (flag2)
				{
					this.rbContent1.ReadOnly = true;
					this.rbContent8.ReadOnly = true;
				}
				else
				{
					bool flag3 = report.sReportStauts == "13" || report.sReportStauts == "14";
					if (flag3)
					{
						this.rbContent1.ReadOnly = true;
						this.rbContent8.ReadOnly = true;
					}
					else
					{
						bool flag4 = report.sReportStauts == "97" || report.sReportStauts == "98" || report.sReportStauts == "96";
						if (flag4)
						{
							this.rbContent1.ReadOnly = true;
							this.rbContent8.ReadOnly = true;
						}
					}
				}
			}
			cFunction.ExcuteSevenZipReport(report.sBinary1, this.rbContent1);
			cFunction.ExcuteSevenZipReport(report.sBinary8, this.rbContent8);
			this.ExcuteSevenZipMail(report.sMailForm);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00054CF0 File Offset: 0x00052EF0
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
					bool flag7 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content6.7z");
					if (flag7)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content6.7z");
					}
					bool flag8 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.7z");
					if (flag8)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.7z");
					}
					bool flag9 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.7z");
					if (flag9)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.7z");
					}
					bool flag10 = rb != null;
					if (flag10)
					{
						bool flag11 = rb.Equals(this.rbContent1);
						if (flag11)
						{
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.7z";
						}
						bool flag12 = rb.Equals(this.rbContent8);
						if (flag12)
						{
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.7z";
						}
					}
					else
					{
						fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.7z", FileMode.Create);
						text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.7z";
					}
					bool flag13 = fileStream != null;
					if (flag13)
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
						bool flag14 = File.Exists(text);
						if (flag14)
						{
							sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
						}
						bool flag15 = rb != null;
						if (flag15)
						{
							bool flag16 = array.Length != 0 && File.Exists(text);
							if (flag16)
							{
								bool flag17 = rb.Equals(this.rbContent1);
								if (flag17)
								{
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.rtf", FileMode.Open);
								}
								bool flag18 = rb.Equals(this.rbContent8);
								if (flag18)
								{
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.rtf", FileMode.Open);
								}
							}
							else
							{
								fileStream = null;
							}
							bool flag19 = fileStream != null;
							if (flag19)
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
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZipReport", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\PMActionControl\\Approval\\Request\\PMRequestContent.cs", 178);
			}
			finally
			{
				bool flag20 = sevenZipExtractor != null;
				if (flag20)
				{
					sevenZipExtractor.Dispose();
				}
				bool flag21 = fileStream != null;
				if (flag21)
				{
					fileStream.Dispose();
				}
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00055024 File Offset: 0x00053224
		private void ExcuteSevenZipMail(string sBody)
		{
			bool flag = string.IsNullOrEmpty(sBody);
			if (!flag)
			{
				SevenZipExtractor sevenZipExtractor = null;
				FileStream fileStream = null;
				try
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
				catch (Exception ex)
				{
					bool flag5 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content1.html");
					if (flag5)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content1.html");
					}
					cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZipMail", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\PMActionControl\\Approval\\Request\\PMRequestContent.cs", 220);
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
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00055180 File Offset: 0x00053380
		public void readOnly(bool enable)
		{
			if (enable)
			{
				this.rbContent1.ReadOnly = true;
				this.rbContent8.ReadOnly = true;
				this.rbContent1.BackColor = Color.Gainsboro;
				this.rbContent8.BackColor = Color.Gainsboro;
			}
			else
			{
				this.rbContent1.ReadOnly = false;
				this.rbContent8.ReadOnly = false;
				this.rbContent1.BackColor = Color.White;
				this.rbContent8.BackColor = Color.White;
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00055211 File Offset: 0x00053411
		public void reloadContent()
		{
			cFunction.ExcuteSevenZipReport(this._report.sBinary1, this.rbContent1);
			cFunction.ExcuteSevenZipReport(this._report.sBinary8, this.rbContent8);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00055244 File Offset: 0x00053444
		public byte[] MakeRFTFile(bool isProblem)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			RichTextBox richTextBox;
			if (isProblem)
			{
				text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content1.rtf";
				text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content1.7z";
				richTextBox = this.rbContent1;
			}
			else
			{
				text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content8.rtf";
				text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content8.7z";
				richTextBox = this.rbContent8;
			}
			bool flag = File.Exists(text);
			if (flag)
			{
				File.Delete(text);
			}
			bool flag2 = File.Exists(text2);
			if (flag2)
			{
				File.Delete(text2);
			}
			byte[] bytes = Encoding.UTF8.GetBytes(richTextBox.Rtf.Replace("\\pichgoal-", "\\pichgoal").Replace("\\picwgoal-", "\\picwgoal"));
			File.WriteAllBytes(text, bytes);
			this.CreateSevenZipFile(text, text2, false);
			FileInfo fileInfo = new FileInfo(text2);
			bool flag3 = fileInfo.Length > this._fileSizeRTF;
			if (flag3)
			{
				this._fileSizeRTF = fileInfo.Length;
			}
			return this.getBinarySevenFile(text2);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00055330 File Offset: 0x00053530
		private void CreateSevenZipFile(string sTargetFile, string sSevenZipFile, bool Directory)
		{
			try
			{
				bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
				if (is64BitOperatingSystem)
				{
					SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x64.dll");
				}
				else
				{
					SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x86.dll");
				}
				SevenZipCompressor sevenZipCompressor = new SevenZipCompressor();
				sevenZipCompressor.CompressionMethod = CompressionMethod.Lzma;
				sevenZipCompressor.CompressionMode = CompressionMode.Create;
				sevenZipCompressor.CompressionLevel = CompressionLevel.Ultra;
				if (Directory)
				{
					sevenZipCompressor.CompressDirectory(sTargetFile, sSevenZipFile);
				}
				else
				{
					sevenZipCompressor.CompressFiles(sSevenZipFile, new string[]
					{
						sTargetFile
					});
				}
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), "CreateSevenZipFile", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\PMActionControl\\Approval\\Request\\PMRequestContent.cs", 311);
			}
		}

		// Token: 0x06000256 RID: 598 RVA: 0x000553F0 File Offset: 0x000535F0
		private byte[] getBinarySevenFile(string sSevenZipFile)
		{
			FileStream fileStream = new FileStream(sSevenZipFile, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return array;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0005542C File Offset: 0x0005362C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00055464 File Offset: 0x00053664
		private void InitializeComponent()
		{
			this.panel8 = new Panel();
			this.panel47 = new Panel();
			this.rbContent8 = new RichTextBox();
			this.panel49 = new Panel();
			this.label45 = new Label();
			this.panel_CheckBase = new Panel();
			this.rbContent1 = new RichTextBox();
			this.panel10 = new Panel();
			this.label34 = new Label();
			this.lbContentText1 = new Label();
			this.panel8.SuspendLayout();
			this.panel47.SuspendLayout();
			this.panel49.SuspendLayout();
			this.panel_CheckBase.SuspendLayout();
			this.panel10.SuspendLayout();
			base.SuspendLayout();
			this.panel8.AutoScroll = true;
			this.panel8.Controls.Add(this.panel47);
			this.panel8.Controls.Add(this.panel_CheckBase);
			this.panel8.Dock = DockStyle.Fill;
			this.panel8.Location = new Point(0, 0);
			this.panel8.Margin = new Padding(0);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new Padding(0, 0, 0, 3);
			this.panel8.Size = new Size(736, 471);
			this.panel8.TabIndex = 72;
			this.panel8.Resize += this.panel8_Resize;
			this.panel47.Controls.Add(this.rbContent8);
			this.panel47.Controls.Add(this.panel49);
			this.panel47.Dock = DockStyle.Fill;
			this.panel47.Location = new Point(0, 213);
			this.panel47.Name = "panel47";
			this.panel47.Padding = new Padding(3, 0, 0, 0);
			this.panel47.Size = new Size(736, 255);
			this.panel47.TabIndex = 1;
			this.rbContent8.Dock = DockStyle.Fill;
			this.rbContent8.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rbContent8.Location = new Point(3, 20);
			this.rbContent8.Name = "rbContent8";
			this.rbContent8.Size = new Size(733, 235);
			this.rbContent8.TabIndex = 37;
			this.rbContent8.Text = "";
			this.panel49.Controls.Add(this.label45);
			this.panel49.Dock = DockStyle.Top;
			this.panel49.Location = new Point(3, 0);
			this.panel49.Name = "panel49";
			this.panel49.Size = new Size(733, 20);
			this.panel49.TabIndex = 12;
			this.label45.AutoSize = true;
			this.label45.Dock = DockStyle.Left;
			this.label45.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label45.Location = new Point(0, 0);
			this.label45.Name = "label45";
			this.label45.Size = new Size(174, 17);
			this.label45.TabIndex = 11;
			this.label45.Text = "Evidence (PCS pre-approval)";
			this.panel_CheckBase.Controls.Add(this.rbContent1);
			this.panel_CheckBase.Controls.Add(this.panel10);
			this.panel_CheckBase.Dock = DockStyle.Top;
			this.panel_CheckBase.Location = new Point(0, 0);
			this.panel_CheckBase.Name = "panel_CheckBase";
			this.panel_CheckBase.Padding = new Padding(3, 0, 0, 0);
			this.panel_CheckBase.Size = new Size(736, 213);
			this.panel_CheckBase.TabIndex = 0;
			this.rbContent1.Dock = DockStyle.Fill;
			this.rbContent1.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rbContent1.Location = new Point(3, 20);
			this.rbContent1.Name = "rbContent1";
			this.rbContent1.Size = new Size(733, 193);
			this.rbContent1.TabIndex = 37;
			this.rbContent1.Text = "";
			this.panel10.Controls.Add(this.label34);
			this.panel10.Controls.Add(this.lbContentText1);
			this.panel10.Dock = DockStyle.Top;
			this.panel10.Location = new Point(3, 0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new Size(733, 20);
			this.panel10.TabIndex = 12;
			this.label34.AutoSize = true;
			this.label34.Dock = DockStyle.Right;
			this.label34.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label34.Location = new Point(489, 0);
			this.label34.Name = "label34";
			this.label34.Size = new Size(244, 17);
			this.label34.TabIndex = 43;
			this.label34.Text = "※발송 메일의 용량은 1MB까지 입니다.";
			this.lbContentText1.AutoSize = true;
			this.lbContentText1.Dock = DockStyle.Left;
			this.lbContentText1.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lbContentText1.Location = new Point(0, 0);
			this.lbContentText1.Name = "lbContentText1";
			this.lbContentText1.Size = new Size(167, 17);
			this.lbContentText1.TabIndex = 11;
			this.lbContentText1.Text = "Problems or Reason of use";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel8);
			base.Name = "PMRequestContent";
			base.Size = new Size(736, 471);
			this.panel8.ResumeLayout(false);
			this.panel47.ResumeLayout(false);
			this.panel49.ResumeLayout(false);
			this.panel49.PerformLayout();
			this.panel_CheckBase.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000452 RID: 1106
		private long _lTotalByte = 0L;

		// Token: 0x04000453 RID: 1107
		private long _fileSizeRTF = 0L;

		// Token: 0x04000454 RID: 1108
		private cReportItem _report;

		// Token: 0x04000455 RID: 1109
		private IContainer components = null;

		// Token: 0x04000456 RID: 1110
		private Panel panel8;

		// Token: 0x04000457 RID: 1111
		private Panel panel47;

		// Token: 0x04000458 RID: 1112
		private RichTextBox rbContent8;

		// Token: 0x04000459 RID: 1113
		private Panel panel49;

		// Token: 0x0400045A RID: 1114
		private Label label45;

		// Token: 0x0400045B RID: 1115
		private Panel panel_CheckBase;

		// Token: 0x0400045C RID: 1116
		private RichTextBox rbContent1;

		// Token: 0x0400045D RID: 1117
		private Panel panel10;

		// Token: 0x0400045E RID: 1118
		private Label label34;

		// Token: 0x0400045F RID: 1119
		private Label lbContentText1;
	}
}
