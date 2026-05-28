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
	// Token: 0x02000047 RID: 71
	public class ActionContent : UserControl
	{
		// Token: 0x060003FE RID: 1022 RVA: 0x00076664 File Offset: 0x00074864
		public ActionContent(cReportItem report)
		{
			this.InitializeComponent();
			this.clear();
			this.label33.Text = MessageLanguage.getMessage("label_email_size");
			this.pnContent3.Height = (this.pnContent4.Height = base.Height / 2);
			bool flag = report.sReportStauts == "1";
			if (flag)
			{
				this.rbContent3.BackColor = Color.White;
				this.rbContent4.BackColor = Color.White;
				this.ExcuteSevenZipMail(report.sMailForm, false);
			}
			else
			{
				bool flag2 = report.sReportStauts == "2";
				if (flag2)
				{
					this.rbContent3.BackColor = Color.Gainsboro;
					this.rbContent4.BackColor = Color.Gainsboro;
					this.ExcuteSevenZipAction(report.sProblem, report.sAection);
					this.ExcuteSevenZipMail(report.sMailForm, false);
					this.ExcuteSevenZipMail(report.sMailActionForm, true);
				}
				else
				{
					bool flag3 = report.sReportStauts == "3";
					if (flag3)
					{
						this.rbContent3.BackColor = Color.White;
						this.rbContent4.BackColor = Color.White;
					}
				}
			}
			this.ControlMode(report);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x000767DC File Offset: 0x000749DC
		private void ControlMode(cReportItem report)
		{
			bool readOnly = false;
			bool flag = report.sReportStauts.CompareTo("1") == 0;
			if (flag)
			{
				this.rbContent4.ReadOnly = readOnly;
				this.rbContent3.ReadOnly = readOnly;
			}
			else
			{
				bool flag2 = report.sReportStauts.CompareTo("2") == 0;
				if (flag2)
				{
					readOnly = true;
					this.rbContent4.ReadOnly = readOnly;
					this.rbContent3.ReadOnly = readOnly;
				}
				else
				{
					bool flag3 = report.sReportStauts.CompareTo("3") == 0;
					if (flag3)
					{
						readOnly = false;
						this.rbContent4.ReadOnly = readOnly;
					}
				}
			}
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00076880 File Offset: 0x00074A80
		public byte[] MakeRFTFile(bool bActionRichEditer)
		{
			string text = (!bActionRichEditer) ? "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Temp_Problem.rtf" : "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Temp_Action.rtf";
			string text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Problem.7z";
			if (bActionRichEditer)
			{
				text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Action.7z";
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
			if (bActionRichEditer)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(this.rbContent4.Rtf.Replace("\\pichgoal-", "\\pichgoal").Replace("\\picwgoal-", "\\picwgoal"));
				File.WriteAllBytes(text, bytes);
			}
			else
			{
				byte[] bytes2 = Encoding.UTF8.GetBytes(this.rbContent3.Rtf.Replace("\\pichgoal-", "\\pichgoal").Replace("\\picwgoal-", "\\picwgoal"));
				File.WriteAllBytes(text, bytes2);
			}
			this.CreateSevenZipFile(text, text2, false);
			return this.getBinarySevenFile(text2);
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00076974 File Offset: 0x00074B74
		private void ExcuteSevenZipAction(string sBody, string sBody2)
		{
			SevenZipExtractor sevenZipExtractor = null;
			FileStream fileStream = null;
			FileStream fileStream2 = null;
			try
			{
				byte[] array = Convert.FromBase64String(sBody);
				byte[] array2 = Convert.FromBase64String(sBody2);
				string text = string.Empty;
				string text2 = string.Empty;
				bool flag = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Problem.7z");
				if (flag)
				{
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Problem.7z");
				}
				bool flag2 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z");
				if (flag2)
				{
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z");
				}
				text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Problem.7z";
				text2 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z";
				fileStream = new FileStream(text, FileMode.Create);
				fileStream2 = null;
				fileStream.Write(array, 0, array.Length);
				fileStream.Close();
				fileStream2 = new FileStream(text2, FileMode.Create);
				fileStream2.Write(array2, 0, array2.Length);
				fileStream2.Close();
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
				bool flag3 = array.Length != 0 && File.Exists(text);
				if (flag3)
				{
					sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
				}
				bool flag4 = array2.Length != 0;
				if (flag4)
				{
					sevenZipExtractor = new SevenZipExtractor(text2);
					sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
				}
				bool flag5 = array.Length != 0 && File.Exists(text);
				if (flag5)
				{
					fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Problem.rtf", FileMode.Open);
					array = new byte[fileStream.Length];
				}
				else
				{
					fileStream = null;
				}
				bool flag6 = array2.Length != 0 && File.Exists(text2);
				if (flag6)
				{
					fileStream2 = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Action.rtf", FileMode.Open);
				}
				bool flag7 = array2.Length != 0;
				if (flag7)
				{
					array2 = new byte[fileStream2.Length];
				}
				bool flag8 = fileStream != null;
				if (flag8)
				{
					fileStream.Read(array, 0, array.Length);
				}
				bool flag9 = array2.Length != 0;
				if (flag9)
				{
					fileStream2.Read(array2, 0, array2.Length);
				}
				bool flag10 = fileStream != null;
				if (flag10)
				{
					fileStream.Close();
					this.rbContent3.Rtf = Encoding.ASCII.GetString(array);
				}
				bool flag11 = array2.Length != 0;
				if (flag11)
				{
					fileStream2.Close();
					this.rbContent4.Rtf = Encoding.ASCII.GetString(array2);
				}
			}
			catch (Exception ex)
			{
				this.rbContent3.Text = ex.Message.ToString();
				this.rbContent4.Text = ex.Message.ToString();
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZipAction", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\MaintActionControl\\ActionContent.cs", 182);
			}
			finally
			{
				bool flag12 = sevenZipExtractor != null;
				if (flag12)
				{
					sevenZipExtractor.Dispose();
				}
				bool flag13 = fileStream != null;
				if (flag13)
				{
					fileStream.Dispose();
				}
				bool flag14 = fileStream2 != null;
				if (flag14)
				{
					fileStream2.Dispose();
				}
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00076C68 File Offset: 0x00074E68
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
				cFunction.ErrorMessageBox(ex.Message.ToString(), "CreateSevenZipFile", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\MaintActionControl\\ActionContent.cs", 216);
			}
			finally
			{
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00076D38 File Offset: 0x00074F38
		private byte[] getBinarySevenFile(string sSevenZipFile)
		{
			FileStream fileStream = new FileStream(sSevenZipFile, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return array;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00076D74 File Offset: 0x00074F74
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
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZipMail", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\MaintActionControl\\ActionContent.cs", 289);
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

		// Token: 0x06000405 RID: 1029 RVA: 0x00076F88 File Offset: 0x00075188
		public string getProblemRTF()
		{
			return this.rbContent3.Rtf;
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00076F95 File Offset: 0x00075195
		public string getActionRTF()
		{
			return this.rbContent4.Rtf;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00076FA4 File Offset: 0x000751A4
		public string getProblemText()
		{
			bool flag = this.rbContent3.Text.CompareTo(this.sProblemComment) == 0 || this.rbContent3.Text.IndexOf(this.sProblemComment) != -1;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				result = this.rbContent3.Text.Trim().Replace("'", "''");
			}
			return result;
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00077018 File Offset: 0x00075218
		public string getActionText()
		{
			bool flag = this.rbContent4.Text.CompareTo(this.sActionComment) == 0 || this.rbContent4.Text.IndexOf(this.sActionComment) != -1;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				result = this.rbContent4.Text.Trim().Replace("'", "''");
			}
			return result;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0007708C File Offset: 0x0007528C
		public void clear()
		{
			this.rbContent4.Text = this.sActionComment;
			this.rbContent3.Text = this.sProblemComment;
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x000770B4 File Offset: 0x000752B4
		public byte[] MakeHTMLZip()
		{
			this.CreateSevenZipFile("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Action.7z", true);
			FileInfo fileInfo = new FileInfo("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Action.7z");
			return this.getBinarySevenFile("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Action.7z");
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x000770F0 File Offset: 0x000752F0
		private void rbContent3_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = this.rbContent3.Text == this.sProblemComment;
			if (flag)
			{
				this.rbContent3.Text = string.Empty;
			}
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0007712C File Offset: 0x0007532C
		private void rbContent4_MouseClick(object sender, MouseEventArgs e)
		{
			bool flag = this.rbContent4.Text == this.sActionComment;
			if (flag)
			{
				this.rbContent4.Text = string.Empty;
			}
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00077168 File Offset: 0x00075368
		private void ActionContent_Resize(object sender, EventArgs e)
		{
			this.pnContent3.Height = (this.pnContent4.Height = base.Height / 2);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00077198 File Offset: 0x00075398
		private void rbContent3_Enter(object sender, EventArgs e)
		{
			bool flag = this.rbContent3.Text == this.sProblemComment;
			if (flag)
			{
				this.rbContent3.Text = string.Empty;
			}
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x000771D4 File Offset: 0x000753D4
		private void rbContent4_Enter(object sender, EventArgs e)
		{
			bool flag = this.rbContent4.Text == this.sActionComment;
			if (flag)
			{
				this.rbContent4.Text = string.Empty;
			}
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00077210 File Offset: 0x00075410
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00077248 File Offset: 0x00075448
		private void InitializeComponent()
		{
			this.panel_CommentBase = new Panel();
			this.pnContent4 = new Panel();
			this.panel25 = new Panel();
			this.rbContent4 = new RichTextBox();
			this.panel26 = new Panel();
			this.btbAction = new Button();
			this.panel24 = new Panel();
			this.label23 = new Label();
			this.pnContent3 = new Panel();
			this.panel4444 = new Panel();
			this.rbContent3 = new RichTextBox();
			this.panel22 = new Panel();
			this.btnProblem = new Button();
			this.panel20 = new Panel();
			this.lbContent3 = new Label();
			this.label33 = new Label();
			this.panel_CommentBase.SuspendLayout();
			this.pnContent4.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel26.SuspendLayout();
			this.panel24.SuspendLayout();
			this.pnContent3.SuspendLayout();
			this.panel4444.SuspendLayout();
			this.panel22.SuspendLayout();
			this.panel20.SuspendLayout();
			base.SuspendLayout();
			this.panel_CommentBase.Controls.Add(this.pnContent4);
			this.panel_CommentBase.Controls.Add(this.pnContent3);
			this.panel_CommentBase.Dock = DockStyle.Fill;
			this.panel_CommentBase.Location = new Point(0, 0);
			this.panel_CommentBase.Name = "panel_CommentBase";
			this.panel_CommentBase.Padding = new Padding(3, 0, 0, 3);
			this.panel_CommentBase.Size = new Size(614, 366);
			this.panel_CommentBase.TabIndex = 89;
			this.pnContent4.Controls.Add(this.panel25);
			this.pnContent4.Controls.Add(this.panel24);
			this.pnContent4.Dock = DockStyle.Top;
			this.pnContent4.Location = new Point(3, 174);
			this.pnContent4.Name = "pnContent4";
			this.pnContent4.Size = new Size(611, 186);
			this.pnContent4.TabIndex = 2;
			this.panel25.Controls.Add(this.rbContent4);
			this.panel25.Controls.Add(this.panel26);
			this.panel25.Dock = DockStyle.Fill;
			this.panel25.Location = new Point(0, 15);
			this.panel25.Name = "panel25";
			this.panel25.Size = new Size(611, 171);
			this.panel25.TabIndex = 1;
			this.rbContent4.Dock = DockStyle.Fill;
			this.rbContent4.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rbContent4.Location = new Point(0, 0);
			this.rbContent4.Name = "rbContent4";
			this.rbContent4.Size = new Size(611, 145);
			this.rbContent4.TabIndex = 38;
			this.rbContent4.Text = "※ 장비를 정상화하기 위해 취한 조치내용을 상세히 기입해 주시기 바랍니다.";
			this.rbContent4.MouseClick += this.rbContent4_MouseClick;
			this.rbContent4.Enter += this.rbContent4_Enter;
			this.panel26.Controls.Add(this.btbAction);
			this.panel26.Dock = DockStyle.Bottom;
			this.panel26.Location = new Point(0, 145);
			this.panel26.Name = "panel26";
			this.panel26.Size = new Size(611, 26);
			this.panel26.TabIndex = 1;
			this.panel26.Visible = false;
			this.btbAction.Dock = DockStyle.Right;
			this.btbAction.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.btbAction.Location = new Point(543, 0);
			this.btbAction.Name = "btbAction";
			this.btbAction.Size = new Size(68, 26);
			this.btbAction.TabIndex = 63;
			this.btbAction.Text = "View";
			this.btbAction.UseVisualStyleBackColor = true;
			this.panel24.Controls.Add(this.label23);
			this.panel24.Dock = DockStyle.Top;
			this.panel24.Location = new Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new Size(611, 15);
			this.panel24.TabIndex = 0;
			this.label23.Dock = DockStyle.Top;
			this.label23.Font = new Font("Segoe UI Symbol", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label23.Location = new Point(0, 0);
			this.label23.Name = "label23";
			this.label23.Size = new Size(611, 17);
			this.label23.TabIndex = 37;
			this.label23.Text = "Corrective Action";
			this.pnContent3.Controls.Add(this.panel4444);
			this.pnContent3.Controls.Add(this.panel20);
			this.pnContent3.Dock = DockStyle.Top;
			this.pnContent3.Location = new Point(3, 0);
			this.pnContent3.Name = "pnContent3";
			this.pnContent3.Size = new Size(611, 174);
			this.pnContent3.TabIndex = 0;
			this.panel4444.Controls.Add(this.rbContent3);
			this.panel4444.Controls.Add(this.panel22);
			this.panel4444.Dock = DockStyle.Fill;
			this.panel4444.Location = new Point(0, 16);
			this.panel4444.Name = "panel4444";
			this.panel4444.Size = new Size(611, 158);
			this.panel4444.TabIndex = 1;
			this.rbContent3.Dock = DockStyle.Fill;
			this.rbContent3.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rbContent3.Location = new Point(0, 0);
			this.rbContent3.Name = "rbContent3";
			this.rbContent3.Size = new Size(611, 132);
			this.rbContent3.TabIndex = 36;
			this.rbContent3.Text = "※ 문제의 원인이 무엇인지 상세히 작성해 주시기 바랍니다.";
			this.rbContent3.Enter += this.rbContent3_Enter;
			this.rbContent3.MouseDown += this.rbContent3_MouseDown;
			this.panel22.Controls.Add(this.btnProblem);
			this.panel22.Dock = DockStyle.Bottom;
			this.panel22.Location = new Point(0, 132);
			this.panel22.Name = "panel22";
			this.panel22.Size = new Size(611, 26);
			this.panel22.TabIndex = 0;
			this.panel22.Visible = false;
			this.btnProblem.Dock = DockStyle.Right;
			this.btnProblem.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.btnProblem.Location = new Point(543, 0);
			this.btnProblem.Name = "btnProblem";
			this.btnProblem.Size = new Size(68, 26);
			this.btnProblem.TabIndex = 64;
			this.btnProblem.Text = "View";
			this.btnProblem.UseVisualStyleBackColor = true;
			this.panel20.Controls.Add(this.lbContent3);
			this.panel20.Controls.Add(this.label33);
			this.panel20.Dock = DockStyle.Top;
			this.panel20.Location = new Point(0, 0);
			this.panel20.Name = "panel20";
			this.panel20.Size = new Size(611, 16);
			this.panel20.TabIndex = 0;
			this.lbContent3.Dock = DockStyle.Top;
			this.lbContent3.Font = new Font("Segoe UI Symbol", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lbContent3.Location = new Point(0, 0);
			this.lbContent3.Name = "lbContent3";
			this.lbContent3.Size = new Size(388, 21);
			this.lbContent3.TabIndex = 35;
			this.lbContent3.Text = "Case of the Problem";
			this.label33.AutoSize = true;
			this.label33.Dock = DockStyle.Right;
			this.label33.Font = new Font("Segoe UI Symbol", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label33.Location = new Point(388, 0);
			this.label33.Name = "label33";
			this.label33.Size = new Size(223, 15);
			this.label33.TabIndex = 42;
			this.label33.Text = "※발송 메일의 용량은 1MB까지 입니다.";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel_CommentBase);
			base.Name = "ActionContent";
			base.Size = new Size(614, 366);
			base.Resize += this.ActionContent_Resize;
			this.panel_CommentBase.ResumeLayout(false);
			this.pnContent4.ResumeLayout(false);
			this.panel25.ResumeLayout(false);
			this.panel26.ResumeLayout(false);
			this.panel24.ResumeLayout(false);
			this.pnContent3.ResumeLayout(false);
			this.panel4444.ResumeLayout(false);
			this.panel22.ResumeLayout(false);
			this.panel20.ResumeLayout(false);
			this.panel20.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000646 RID: 1606
		private readonly string sProblemComment = MessageLanguage.getMessage("maint_problem_tip");

		// Token: 0x04000647 RID: 1607
		private readonly string sActionComment = MessageLanguage.getMessage("maint_action_tip");

		// Token: 0x04000648 RID: 1608
		private IContainer components = null;

		// Token: 0x04000649 RID: 1609
		private Panel panel_CommentBase;

		// Token: 0x0400064A RID: 1610
		private Panel pnContent4;

		// Token: 0x0400064B RID: 1611
		private Panel panel25;

		// Token: 0x0400064C RID: 1612
		private RichTextBox rbContent4;

		// Token: 0x0400064D RID: 1613
		private Panel panel26;

		// Token: 0x0400064E RID: 1614
		private Button btbAction;

		// Token: 0x0400064F RID: 1615
		private Panel panel24;

		// Token: 0x04000650 RID: 1616
		private Label label23;

		// Token: 0x04000651 RID: 1617
		private Panel pnContent3;

		// Token: 0x04000652 RID: 1618
		private Panel panel4444;

		// Token: 0x04000653 RID: 1619
		private RichTextBox rbContent3;

		// Token: 0x04000654 RID: 1620
		private Panel panel22;

		// Token: 0x04000655 RID: 1621
		private Button btnProblem;

		// Token: 0x04000656 RID: 1622
		private Panel panel20;

		// Token: 0x04000657 RID: 1623
		private Label label33;

		// Token: 0x04000658 RID: 1624
		private Label lbContent3;
	}
}
