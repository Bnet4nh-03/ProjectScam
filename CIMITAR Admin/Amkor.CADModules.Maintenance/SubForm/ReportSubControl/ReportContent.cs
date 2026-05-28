using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using SevenZip;

namespace Amkor.CADModules.Maintenance.SubForm.ReportSubControl
{
	// Token: 0x02000016 RID: 22
	public class ReportContent : UserControl
	{
		// Token: 0x06000191 RID: 401 RVA: 0x00045CD0 File Offset: 0x00043ED0
		public ReportContent()
		{
			this.InitializeComponent();
			this._fileSizeHTML = 0L;
			this._fileSizeRTF = 0L;
			this.rbCheckItem.Text = this._sCommentInit;
			this.rbRequirement.Text = this._sCorrective;
			this.label17.Text = MessageLanguage.getMessage("label_email_size");
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00045D70 File Offset: 0x00043F70
		private void rbCheckItem_MouseClick(object sender, MouseEventArgs e)
		{
			bool flag = this.rbCheckItem.Text.CompareTo(this._sCommentInit) == 0;
			if (flag)
			{
				this.rbCheckItem.Text = string.Empty;
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00045DAC File Offset: 0x00043FAC
		private void rbRequirement_MouseClick(object sender, MouseEventArgs e)
		{
			bool flag = this.rbRequirement.Text.CompareTo(this._sCorrective) == 0;
			if (flag)
			{
				this.rbRequirement.Text = string.Empty;
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00045DE8 File Offset: 0x00043FE8
		public string getCheckItemRTF()
		{
			return this.rbCheckItem.Rtf;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00045DF5 File Offset: 0x00043FF5
		public string getRequirmentRTF()
		{
			return this.rbRequirement.Rtf;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00045E04 File Offset: 0x00044004
		public string getCheckItemText()
		{
			bool flag = this.rbCheckItem.Text.CompareTo(this._sCommentInit) == 0 || this.rbCheckItem.Text.IndexOf(this._sCommentInit) != -1;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				result = this.rbCheckItem.Text.Trim().Replace("'", "''");
			}
			return result;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00045E78 File Offset: 0x00044078
		public string getRequirmentText()
		{
			bool flag = this.rbRequirement.Text.CompareTo(this._sCorrective) == 0 || this.rbRequirement.Text.IndexOf(this._sCorrective) != -1;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				result = this.rbRequirement.Text.Trim().Replace("'", "''");
			}
			return result;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00045EEC File Offset: 0x000440EC
		public void clear()
		{
			this._fileSizeHTML = 0L;
			this._fileSizeRTF = 0L;
			this.rbCheckItem.Text = this._sCommentInit;
			this.rbRequirement.Text = this._sCorrective;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00045F24 File Offset: 0x00044124
		public byte[] MakeRFTFile(bool bCorrective)
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
				byte[] bytes = Encoding.UTF8.GetBytes(this.rbRequirement.Rtf);
				File.WriteAllBytes(text, bytes);
			}
			else
			{
				byte[] bytes2 = Encoding.UTF8.GetBytes(this.rbCheckItem.Rtf);
				File.WriteAllBytes(text, bytes2);
			}
			this.CreateSevenZipFile(text, text2, false);
			FileInfo fileInfo = new FileInfo(text2);
			bool flag3 = fileInfo.Length > this._fileSizeRTF;
			if (flag3)
			{
				this._fileSizeRTF = fileInfo.Length;
			}
			return this.getBinarySevenFile(text2);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00046004 File Offset: 0x00044204
		public byte[] MakeHTMLZip()
		{
			this.CreateSevenZipFile("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\MailForm.7z", true);
			FileInfo fileInfo = new FileInfo("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\MailForm.7z");
			this._fileSizeHTML = fileInfo.Length;
			return this.getBinarySevenFile("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\MailForm.7z");
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0004604C File Offset: 0x0004424C
		private void CreateSevenZipFile(string sTargetFile, string sSevenZipFile, bool Dicrectory)
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
				if (Dicrectory)
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
				cFunction.ErrorMessageBox(ex.Message.ToString(), "CreateSevenZipFile", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\MaintReportControl\\ReportContent.cs", 144);
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0004610C File Offset: 0x0004430C
		private byte[] getBinarySevenFile(string sSevenZipFile)
		{
			FileStream fileStream = new FileStream(sSevenZipFile, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return array;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00046148 File Offset: 0x00044348
		private void ReportContent_Resize(object sender, EventArgs e)
		{
			this.pnContent1.Height = (this.pnContent2.Height = base.Height / 2);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00046178 File Offset: 0x00044378
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000461B0 File Offset: 0x000443B0
		private void InitializeComponent()
		{
			this.panel_CommentBase = new Panel();
			this.pnContent2 = new Panel();
			this.panel16 = new Panel();
			this.rbRequirement = new RichTextBox();
			this.panel14 = new Panel();
			this.label14 = new Label();
			this.pnContent1 = new Panel();
			this.panel12 = new Panel();
			this.rbCheckItem = new RichTextBox();
			this.panel11 = new Panel();
			this.label17 = new Label();
			this.lbContent1 = new Label();
			this.panel_CommentBase.SuspendLayout();
			this.pnContent2.SuspendLayout();
			this.panel16.SuspendLayout();
			this.panel14.SuspendLayout();
			this.pnContent1.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel11.SuspendLayout();
			base.SuspendLayout();
			this.panel_CommentBase.Controls.Add(this.pnContent2);
			this.panel_CommentBase.Controls.Add(this.pnContent1);
			this.panel_CommentBase.Dock = DockStyle.Fill;
			this.panel_CommentBase.Location = new Point(0, 0);
			this.panel_CommentBase.Name = "panel_CommentBase";
			this.panel_CommentBase.Padding = new Padding(3, 0, 0, 3);
			this.panel_CommentBase.Size = new Size(531, 320);
			this.panel_CommentBase.TabIndex = 70;
			this.pnContent2.Controls.Add(this.panel16);
			this.pnContent2.Controls.Add(this.panel14);
			this.pnContent2.Dock = DockStyle.Fill;
			this.pnContent2.Location = new Point(3, 160);
			this.pnContent2.Name = "pnContent2";
			this.pnContent2.Size = new Size(528, 157);
			this.pnContent2.TabIndex = 4;
			this.panel16.Controls.Add(this.rbRequirement);
			this.panel16.Dock = DockStyle.Fill;
			this.panel16.Location = new Point(0, 18);
			this.panel16.Margin = new Padding(0);
			this.panel16.Name = "panel16";
			this.panel16.Size = new Size(528, 139);
			this.panel16.TabIndex = 68;
			this.rbRequirement.Dock = DockStyle.Fill;
			this.rbRequirement.Font = new Font("굴림", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 129);
			this.rbRequirement.Location = new Point(0, 0);
			this.rbRequirement.Name = "rbRequirement";
			this.rbRequirement.Size = new Size(528, 139);
			this.rbRequirement.TabIndex = 64;
			this.rbRequirement.Text = "※ 구체적인 요청 사항을 기입해 주시기 바랍니다.";
			this.rbRequirement.MouseClick += this.rbRequirement_MouseClick;
			this.panel14.Controls.Add(this.label14);
			this.panel14.Dock = DockStyle.Top;
			this.panel14.Location = new Point(0, 0);
			this.panel14.Margin = new Padding(0);
			this.panel14.Name = "panel14";
			this.panel14.Size = new Size(528, 18);
			this.panel14.TabIndex = 67;
			this.label14.AutoSize = true;
			this.label14.Dock = DockStyle.Left;
			this.label14.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label14.Location = new Point(0, 0);
			this.label14.Margin = new Padding(0);
			this.label14.Name = "label14";
			this.label14.Size = new Size(82, 17);
			this.label14.TabIndex = 67;
			this.label14.Text = "Requirement";
			this.pnContent1.Controls.Add(this.panel12);
			this.pnContent1.Controls.Add(this.panel11);
			this.pnContent1.Dock = DockStyle.Top;
			this.pnContent1.Location = new Point(3, 0);
			this.pnContent1.Name = "pnContent1";
			this.pnContent1.Size = new Size(528, 160);
			this.pnContent1.TabIndex = 3;
			this.panel12.Controls.Add(this.rbCheckItem);
			this.panel12.Dock = DockStyle.Fill;
			this.panel12.Location = new Point(0, 20);
			this.panel12.Name = "panel12";
			this.panel12.Size = new Size(528, 140);
			this.panel12.TabIndex = 69;
			this.rbCheckItem.Dock = DockStyle.Fill;
			this.rbCheckItem.Font = new Font("굴림", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 129);
			this.rbCheckItem.Location = new Point(0, 0);
			this.rbCheckItem.Name = "rbCheckItem";
			this.rbCheckItem.Size = new Size(528, 140);
			this.rbCheckItem.TabIndex = 12;
			this.rbCheckItem.Text = "※ 확인하신 문제 내용 등을 자세히 기입해 주시면 정확하고 빠른 조치에 도움이 됩니다.";
			this.rbCheckItem.MouseClick += this.rbCheckItem_MouseClick;
			this.panel11.Controls.Add(this.label17);
			this.panel11.Controls.Add(this.lbContent1);
			this.panel11.Dock = DockStyle.Top;
			this.panel11.Location = new Point(0, 0);
			this.panel11.Name = "panel11";
			this.panel11.Size = new Size(528, 20);
			this.panel11.TabIndex = 67;
			this.label17.AutoSize = true;
			this.label17.Dock = DockStyle.Right;
			this.label17.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label17.Location = new Point(284, 0);
			this.label17.Name = "label17";
			this.label17.Size = new Size(244, 17);
			this.label17.TabIndex = 41;
			this.label17.Text = "※발송 메일의 용량은 1MB까지 입니다.";
			this.lbContent1.AutoSize = true;
			this.lbContent1.Dock = DockStyle.Left;
			this.lbContent1.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lbContent1.Location = new Point(0, 0);
			this.lbContent1.Name = "lbContent1";
			this.lbContent1.Size = new Size(71, 17);
			this.lbContent1.TabIndex = 11;
			this.lbContent1.Text = "Check Item";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel_CommentBase);
			base.Name = "ReportContent";
			base.Size = new Size(531, 320);
			base.Resize += this.ReportContent_Resize;
			this.panel_CommentBase.ResumeLayout(false);
			this.pnContent2.ResumeLayout(false);
			this.panel16.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panel14.PerformLayout();
			this.pnContent1.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400033C RID: 828
		private readonly string _sCommentInit = MessageLanguage.getMessage("maint_checkitem_tip");

		// Token: 0x0400033D RID: 829
		private readonly string _sCorrective = MessageLanguage.getMessage("maint_requirement_tip");

		// Token: 0x0400033E RID: 830
		private long _fileSizeHTML = 0L;

		// Token: 0x0400033F RID: 831
		private long _fileSizeRTF = 0L;

		// Token: 0x04000340 RID: 832
		private IContainer components = null;

		// Token: 0x04000341 RID: 833
		private Panel panel_CommentBase;

		// Token: 0x04000342 RID: 834
		private Panel pnContent2;

		// Token: 0x04000343 RID: 835
		private Panel panel16;

		// Token: 0x04000344 RID: 836
		private RichTextBox rbRequirement;

		// Token: 0x04000345 RID: 837
		private Panel panel14;

		// Token: 0x04000346 RID: 838
		private Label label14;

		// Token: 0x04000347 RID: 839
		private Panel pnContent1;

		// Token: 0x04000348 RID: 840
		private Panel panel12;

		// Token: 0x04000349 RID: 841
		private RichTextBox rbCheckItem;

		// Token: 0x0400034A RID: 842
		private Panel panel11;

		// Token: 0x0400034B RID: 843
		private Label label17;

		// Token: 0x0400034C RID: 844
		private Label lbContent1;
	}
}
