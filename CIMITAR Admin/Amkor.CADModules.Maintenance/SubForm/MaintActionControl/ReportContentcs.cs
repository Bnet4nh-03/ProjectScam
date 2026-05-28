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

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x0200004D RID: 77
	public class ReportContentcs : UserControl
	{
		// Token: 0x06000444 RID: 1092 RVA: 0x0007E8AA File Offset: 0x0007CAAA
		public string getCheckItemText()
		{
			return this.rbCheckItem.Text.Trim().Replace("'", "''");
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0007E8CB File Offset: 0x0007CACB
		public string getRequirementText()
		{
			return this.rbRequirement.Text.Trim().Replace("'", "''");
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0007E8EC File Offset: 0x0007CAEC
		public string getCheckItemRTF()
		{
			return this.rbCheckItem.Rtf;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0007E8F9 File Offset: 0x0007CAF9
		public string getRequirementRTF()
		{
			return this.rbRequirement.Rtf;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0007E908 File Offset: 0x0007CB08
		private void ReportContentcs_Resize(object sender, EventArgs e)
		{
			this.pnContent1.Height = (this.pnContent2.Height = base.Height / 2);
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0007E938 File Offset: 0x0007CB38
		public ReportContentcs(cReportItem report)
		{
			this.InitializeComponent();
			this.label34.Text = MessageLanguage.getMessage("label_email_size");
			this.ExcuteSevenZipReport(report.Comment, report.sCorrective);
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0007E984 File Offset: 0x0007CB84
		private void ExcuteSevenZipReport(string sBody, string sBdoy2)
		{
			SevenZipExtractor sevenZipExtractor = null;
			FileStream fileStream = null;
			FileStream fileStream2 = null;
			try
			{
				byte[] array = Convert.FromBase64String(sBody);
				byte[] array2 = Convert.FromBase64String(sBdoy2);
				string text = string.Empty;
				string text2 = string.Empty;
				bool flag = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\TempC.7z");
				if (flag)
				{
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\TempC.7z");
				}
				bool flag2 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.7z");
				if (flag2)
				{
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.7z");
				}
				text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\TempC.7z";
				text2 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.7z";
				fileStream = new FileStream(text, FileMode.Create);
				fileStream.Write(array, 0, array.Length);
				fileStream.Close();
				bool flag3 = array2.Length != 0;
				if (flag3)
				{
					fileStream2 = new FileStream(text2, FileMode.Create);
					fileStream2.Write(array2, 0, array2.Length);
					fileStream2.Close();
				}
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
				bool flag4 = File.Exists(text);
				if (flag4)
				{
					sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
				}
				bool flag5 = array2.Length != 0;
				if (flag5)
				{
					sevenZipExtractor = new SevenZipExtractor(text2);
					sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
				}
				bool flag6 = array.Length != 0 && File.Exists(text);
				if (flag6)
				{
					fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\TempC.rtf", FileMode.Open);
				}
				else
				{
					fileStream = null;
				}
				bool flag7 = array2.Length != 0 && File.Exists(text2);
				if (flag7)
				{
					fileStream2 = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.rtf", FileMode.Open);
				}
				else
				{
					fileStream2 = null;
				}
				bool flag8 = fileStream != null;
				if (flag8)
				{
					array = new byte[fileStream.Length];
					fileStream.Read(array, 0, array.Length);
					fileStream.Close();
					this.rbCheckItem.Rtf = Encoding.ASCII.GetString(array);
				}
				bool flag9 = fileStream2 != null;
				if (flag9)
				{
					array2 = new byte[fileStream2.Length];
					fileStream2.Read(array2, 0, array2.Length);
					fileStream2.Close();
					this.rbRequirement.Rtf = Encoding.ASCII.GetString(array2);
				}
			}
			catch (Exception ex)
			{
				this.rbCheckItem.Text = ex.Message.ToString();
				this.rbRequirement.Text = ex.Message.ToString();
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZipReport", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\MaintActionControl\\ReportContentcs.cs", 107);
			}
			finally
			{
				bool flag10 = sevenZipExtractor != null;
				if (flag10)
				{
					sevenZipExtractor.Dispose();
				}
				bool flag11 = fileStream != null;
				if (flag11)
				{
					fileStream.Dispose();
				}
				bool flag12 = fileStream2 != null;
				if (flag12)
				{
					fileStream2.Dispose();
				}
			}
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0007EC54 File Offset: 0x0007CE54
		private void ExcuteSevenZipMail(string sBody, bool action)
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
					if (action)
					{
						bool flag2 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action\\action.html");
						if (flag2)
						{
							File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action\\action.html");
						}
						bool flag3 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z");
						if (flag3)
						{
							File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z");
						}
						fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z", FileMode.Create);
						fileStream.Write(array, 0, array.Length);
						bool flag4 = fileStream != null;
						if (flag4)
						{
							fileStream.Close();
						}
						sevenZipExtractor = new SevenZipExtractor("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z");
						bool flag5 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z");
						if (flag5)
						{
							sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action");
						}
					}
					else
					{
						bool flag6 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report\\report.html");
						if (flag6)
						{
							File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report\\report.html");
						}
						bool flag7 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\MailForm.7z");
						if (flag7)
						{
							File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\MailForm.7z");
						}
						fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\MailForm.7z", FileMode.Create);
						fileStream.Write(array, 0, array.Length);
						bool flag8 = fileStream != null;
						if (flag8)
						{
							fileStream.Close();
						}
						sevenZipExtractor = new SevenZipExtractor("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\MailForm.7z");
						bool flag9 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\MailForm.7z");
						if (flag9)
						{
							sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report");
						}
					}
				}
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZipMail", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\MaintActionControl\\ReportContentcs.cs", 171);
			}
			finally
			{
				bool flag10 = sevenZipExtractor != null;
				if (flag10)
				{
					sevenZipExtractor.Dispose();
				}
				bool flag11 = fileStream != null;
				if (flag11)
				{
					fileStream.Dispose();
				}
			}
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0007EE68 File Offset: 0x0007D068
		public void EditMode()
		{
			this.rbCheckItem.ReadOnly = false;
			this.rbRequirement.ReadOnly = false;
			this.rbCheckItem.BackColor = Color.White;
			this.rbRequirement.BackColor = Color.White;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0007EEA7 File Offset: 0x0007D0A7
		public void SaveMode()
		{
			this.rbCheckItem.ReadOnly = true;
			this.rbRequirement.ReadOnly = true;
			this.rbCheckItem.BackColor = Color.Gainsboro;
			this.rbRequirement.BackColor = Color.Gainsboro;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0007EEE6 File Offset: 0x0007D0E6
		public void SaveContent(cReportItem report)
		{
			this.ExcuteSevenZipReport(report.Comment, report.sCorrective);
			this.ExcuteSevenZipMail(report.sMailForm, false);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0007EF0C File Offset: 0x0007D10C
		public byte[] MakeRFTFileReport(bool bCorrective)
		{
			string text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\TempC.rtf";
			string text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\TempC.7z";
			if (bCorrective)
			{
				text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Temp.rtf";
				text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Temp.7z";
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
			if (bCorrective)
			{
				this.rbRequirement.SaveFile(text);
			}
			else
			{
				this.rbCheckItem.SaveFile(text);
			}
			this.CreateSevenZipFile(text, text2, false);
			FileInfo fileInfo = new FileInfo(text2);
			return this.getBinarySevenFile(text2);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0007EFA4 File Offset: 0x0007D1A4
		private byte[] getBinarySevenFile(string sSevenZipFile)
		{
			FileStream fileStream = new FileStream(sSevenZipFile, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return array;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0007EFE0 File Offset: 0x0007D1E0
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
				cFunction.ErrorMessageBox(ex.Message.ToString(), "CreateSevenZipFile", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\MaintActionControl\\ReportContentcs.cs", 265);
			}
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0007F0A0 File Offset: 0x0007D2A0
		public byte[] MakeHTMLZipEdit()
		{
			this.CreateSevenZipFile("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\MailForm.7z", true);
			FileInfo fileInfo = new FileInfo("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\MailForm.7z");
			return this.getBinarySevenFile("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\MailForm.7z");
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0007F0DC File Offset: 0x0007D2DC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0007F114 File Offset: 0x0007D314
		private void InitializeComponent()
		{
			this.group_CommentBase = new GroupBox();
			this.panel8 = new Panel();
			this.pnContent2 = new Panel();
			this.panel15 = new Panel();
			this.panel99 = new Panel();
			this.btnCorrective = new Button();
			this.rbRequirement = new RichTextBox();
			this.panel14 = new Panel();
			this.lbRichText2 = new Label();
			this.pnContent1 = new Panel();
			this.panel11 = new Panel();
			this.rbCheckItem = new RichTextBox();
			this.panel12 = new Panel();
			this.button8 = new Button();
			this.panel10 = new Panel();
			this.label34 = new Label();
			this.lbContentText1 = new Label();
			this.group_CommentBase.SuspendLayout();
			this.panel8.SuspendLayout();
			this.pnContent2.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel99.SuspendLayout();
			this.panel14.SuspendLayout();
			this.pnContent1.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel10.SuspendLayout();
			base.SuspendLayout();
			this.group_CommentBase.Controls.Add(this.panel8);
			this.group_CommentBase.Dock = DockStyle.Fill;
			this.group_CommentBase.Location = new Point(0, 0);
			this.group_CommentBase.Margin = new Padding(0);
			this.group_CommentBase.Name = "group_CommentBase";
			this.group_CommentBase.Padding = new Padding(1, 0, 1, 0);
			this.group_CommentBase.Size = new Size(591, 585);
			this.group_CommentBase.TabIndex = 68;
			this.group_CommentBase.TabStop = false;
			this.panel8.AutoScroll = true;
			this.panel8.Controls.Add(this.pnContent2);
			this.panel8.Controls.Add(this.pnContent1);
			this.panel8.Dock = DockStyle.Fill;
			this.panel8.Location = new Point(1, 14);
			this.panel8.Margin = new Padding(0);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new Padding(0, 0, 0, 3);
			this.panel8.Size = new Size(589, 571);
			this.panel8.TabIndex = 71;
			this.pnContent2.Controls.Add(this.panel15);
			this.pnContent2.Controls.Add(this.panel14);
			this.pnContent2.Dock = DockStyle.Top;
			this.pnContent2.Location = new Point(0, 268);
			this.pnContent2.Name = "pnContent2";
			this.pnContent2.Padding = new Padding(3, 0, 0, 0);
			this.pnContent2.Size = new Size(589, 300);
			this.pnContent2.TabIndex = 1;
			this.panel15.Controls.Add(this.panel99);
			this.panel15.Controls.Add(this.rbRequirement);
			this.panel15.Dock = DockStyle.Fill;
			this.panel15.Location = new Point(3, 25);
			this.panel15.Name = "panel15";
			this.panel15.Size = new Size(586, 275);
			this.panel15.TabIndex = 1;
			this.panel99.Controls.Add(this.btnCorrective);
			this.panel99.Dock = DockStyle.Bottom;
			this.panel99.Location = new Point(0, 250);
			this.panel99.Name = "panel99";
			this.panel99.Size = new Size(586, 25);
			this.panel99.TabIndex = 1;
			this.panel99.Visible = false;
			this.btnCorrective.Dock = DockStyle.Right;
			this.btnCorrective.Font = new Font("Microsoft Sans Serif", 9.75f);
			this.btnCorrective.Location = new Point(517, 0);
			this.btnCorrective.Name = "btnCorrective";
			this.btnCorrective.Size = new Size(69, 25);
			this.btnCorrective.TabIndex = 65;
			this.btnCorrective.Text = "View";
			this.btnCorrective.UseVisualStyleBackColor = true;
			this.rbRequirement.BackColor = Color.Gainsboro;
			this.rbRequirement.Dock = DockStyle.Fill;
			this.rbRequirement.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rbRequirement.Location = new Point(0, 0);
			this.rbRequirement.Name = "rbRequirement";
			this.rbRequirement.ReadOnly = true;
			this.rbRequirement.Size = new Size(586, 275);
			this.rbRequirement.TabIndex = 64;
			this.rbRequirement.TabStop = false;
			this.rbRequirement.Text = "";
			this.panel14.Controls.Add(this.lbRichText2);
			this.panel14.Dock = DockStyle.Top;
			this.panel14.Location = new Point(3, 0);
			this.panel14.Name = "panel14";
			this.panel14.Size = new Size(586, 25);
			this.panel14.TabIndex = 0;
			this.lbRichText2.AutoSize = true;
			this.lbRichText2.Dock = DockStyle.Left;
			this.lbRichText2.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lbRichText2.Location = new Point(0, 0);
			this.lbRichText2.Name = "lbRichText2";
			this.lbRichText2.Size = new Size(82, 17);
			this.lbRichText2.TabIndex = 74;
			this.lbRichText2.Text = "Requirement";
			this.pnContent1.Controls.Add(this.panel11);
			this.pnContent1.Controls.Add(this.panel10);
			this.pnContent1.Dock = DockStyle.Top;
			this.pnContent1.Location = new Point(0, 0);
			this.pnContent1.Name = "pnContent1";
			this.pnContent1.Padding = new Padding(3, 0, 0, 0);
			this.pnContent1.Size = new Size(589, 268);
			this.pnContent1.TabIndex = 0;
			this.panel11.Controls.Add(this.rbCheckItem);
			this.panel11.Controls.Add(this.panel12);
			this.panel11.Dock = DockStyle.Fill;
			this.panel11.Location = new Point(3, 20);
			this.panel11.Name = "panel11";
			this.panel11.Size = new Size(586, 248);
			this.panel11.TabIndex = 13;
			this.rbCheckItem.BackColor = Color.Gainsboro;
			this.rbCheckItem.Dock = DockStyle.Fill;
			this.rbCheckItem.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rbCheckItem.Location = new Point(0, 0);
			this.rbCheckItem.Name = "rbCheckItem";
			this.rbCheckItem.ReadOnly = true;
			this.rbCheckItem.Size = new Size(586, 226);
			this.rbCheckItem.TabIndex = 12;
			this.rbCheckItem.TabStop = false;
			this.rbCheckItem.Text = "";
			this.panel12.Controls.Add(this.button8);
			this.panel12.Dock = DockStyle.Bottom;
			this.panel12.Location = new Point(0, 226);
			this.panel12.Name = "panel12";
			this.panel12.Size = new Size(586, 22);
			this.panel12.TabIndex = 16;
			this.panel12.Visible = false;
			this.button8.Dock = DockStyle.Right;
			this.button8.Font = new Font("Microsoft Sans Serif", 9.75f);
			this.button8.Location = new Point(517, 0);
			this.button8.Name = "button8";
			this.button8.Size = new Size(69, 22);
			this.button8.TabIndex = 62;
			this.button8.Text = "View";
			this.button8.UseVisualStyleBackColor = true;
			this.panel10.Controls.Add(this.label34);
			this.panel10.Controls.Add(this.lbContentText1);
			this.panel10.Dock = DockStyle.Top;
			this.panel10.Location = new Point(3, 0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new Size(586, 20);
			this.panel10.TabIndex = 12;
			this.label34.AutoSize = true;
			this.label34.Dock = DockStyle.Right;
			this.label34.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label34.Location = new Point(342, 0);
			this.label34.Name = "label34";
			this.label34.Size = new Size(244, 17);
			this.label34.TabIndex = 43;
			this.label34.Text = "※발송 메일의 용량은 1MB까지 입니다.";
			this.lbContentText1.AutoSize = true;
			this.lbContentText1.Dock = DockStyle.Left;
			this.lbContentText1.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lbContentText1.Location = new Point(0, 0);
			this.lbContentText1.Name = "lbContentText1";
			this.lbContentText1.Size = new Size(71, 17);
			this.lbContentText1.TabIndex = 11;
			this.lbContentText1.Text = "Check Item";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.group_CommentBase);
			base.Name = "ReportContentcs";
			base.Size = new Size(591, 585);
			base.Resize += this.ReportContentcs_Resize;
			this.group_CommentBase.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.pnContent2.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.panel99.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panel14.PerformLayout();
			this.pnContent1.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040006D8 RID: 1752
		private IContainer components = null;

		// Token: 0x040006D9 RID: 1753
		private GroupBox group_CommentBase;

		// Token: 0x040006DA RID: 1754
		private Panel panel8;

		// Token: 0x040006DB RID: 1755
		private Panel pnContent2;

		// Token: 0x040006DC RID: 1756
		private Panel panel15;

		// Token: 0x040006DD RID: 1757
		private Panel panel99;

		// Token: 0x040006DE RID: 1758
		private Button btnCorrective;

		// Token: 0x040006DF RID: 1759
		private RichTextBox rbRequirement;

		// Token: 0x040006E0 RID: 1760
		private Panel panel14;

		// Token: 0x040006E1 RID: 1761
		private Label lbRichText2;

		// Token: 0x040006E2 RID: 1762
		private Panel pnContent1;

		// Token: 0x040006E3 RID: 1763
		private Panel panel11;

		// Token: 0x040006E4 RID: 1764
		private RichTextBox rbCheckItem;

		// Token: 0x040006E5 RID: 1765
		private Panel panel12;

		// Token: 0x040006E6 RID: 1766
		private Button button8;

		// Token: 0x040006E7 RID: 1767
		private Panel panel10;

		// Token: 0x040006E8 RID: 1768
		private Label label34;

		// Token: 0x040006E9 RID: 1769
		private Label lbContentText1;
	}
}
