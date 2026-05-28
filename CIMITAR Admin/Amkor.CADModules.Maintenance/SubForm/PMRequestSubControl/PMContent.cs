using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using SevenZip;

namespace Amkor.CADModules.Maintenance.SubForm.PMRequestSubControl
{
	// Token: 0x0200001A RID: 26
	public class PMContent : UserControl
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x0004B978 File Offset: 0x00049B78
		private void panel4_Resize(object sender, EventArgs e)
		{
			this.panel_CheckBase.Height = (this.panel13.Height = base.Height / 2);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0004B9A8 File Offset: 0x00049BA8
		public string getContent1RTF()
		{
			return this.rbContent1.Rtf;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0004B9B5 File Offset: 0x00049BB5
		public string getContent8RTF()
		{
			return this.rbContent8.Rtf;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0004B9C2 File Offset: 0x00049BC2
		public string getContent1Text()
		{
			return this.rbContent1.Text.Trim();
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0004B9D4 File Offset: 0x00049BD4
		public string getContent8Text()
		{
			return this.rbContent8.Text.Trim();
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0004B9E6 File Offset: 0x00049BE6
		public string getProblem64String()
		{
			return cFunction.MakeRFTFile(this.rbContent1);
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0004B9F3 File Offset: 0x00049BF3
		public string getEvidence64String()
		{
			return cFunction.MakeRFTFile(this.rbContent8);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0004BA00 File Offset: 0x00049C00
		public PMContent()
		{
			this.InitializeComponent();
			this.clear();
			this.label17.Text = MessageLanguage.getMessage("label_email_size");
			this.rbContent1.Tag = "1";
			this.rbContent8.Tag = "8";
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0004BAA1 File Offset: 0x00049CA1
		public void clear()
		{
			this.rbContent1.Text = this._Content1Title;
			this.rbContent8.Text = this._Content8Title;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0004BAC8 File Offset: 0x00049CC8
		private void rbContent1_MouseClick(object sender, MouseEventArgs e)
		{
			bool flag = this.rbContent1.Text.Trim() == this._Content1Title;
			if (flag)
			{
				this.rbContent1.Text = string.Empty;
			}
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0004BB08 File Offset: 0x00049D08
		private void rbContent8_MouseClick(object sender, MouseEventArgs e)
		{
			bool flag = this.rbContent8.Text.Trim() == this._Content8Title;
			if (flag)
			{
				this.rbContent8.Text = string.Empty;
			}
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0004BB48 File Offset: 0x00049D48
		public byte[] MakeRFTFile(bool bContent8)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			bool flag = !bContent8;
			byte[] bytes;
			if (flag)
			{
				text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content1.rtf";
				text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content1.7z";
				bytes = Encoding.UTF8.GetBytes(this.rbContent1.Rtf.Replace("\\pichgoal-", "\\pichgoal").Replace("\\picwgoal-", "\\picwgoal"));
			}
			else
			{
				text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content8.rtf";
				text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content8.7z";
				bytes = Encoding.UTF8.GetBytes(this.rbContent8.Rtf.Replace("\\pichgoal-", "\\pichgoal").Replace("\\picwgoal-", "\\picwgoal"));
			}
			bool flag2 = File.Exists(text);
			if (flag2)
			{
				File.Delete(text);
			}
			bool flag3 = File.Exists(text2);
			if (flag3)
			{
				File.Delete(text2);
			}
			File.WriteAllBytes(text, bytes);
			this.CreateSevenZipFile(text, text2, false);
			FileInfo fileInfo = new FileInfo(text2);
			bool flag4 = fileInfo.Length > this._fileSizeRTF;
			if (flag4)
			{
				this._fileSizeRTF = fileInfo.Length;
			}
			return this.getBinarySevenFile(text2);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0004BC60 File Offset: 0x00049E60
		private byte[] getBinarySevenFile(string sSevenZipFile)
		{
			FileStream fileStream = new FileStream(sSevenZipFile, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return array;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0004BC9C File Offset: 0x00049E9C
		public byte[] MakeHTMLZip()
		{
			this.CreateSevenZipFile("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\pm.7z", true);
			FileInfo fileInfo = new FileInfo("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\pm.7z");
			this._fileSizeHTML = fileInfo.Length;
			return this.getBinarySevenFile("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\pm.7z");
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0004BCE4 File Offset: 0x00049EE4
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
				cFunction.ErrorMessageBox(ex.Message.ToString(), "CreateSevenZipFile", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\PMRequestControl\\PMContent.cs", 135);
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0004BDA4 File Offset: 0x00049FA4
		public bool isEmptyContent1()
		{
			return this.rbContent1.Text.Trim().Length == 0 || this.rbContent1.Text.Trim() == this._Content1Title;
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0004BDF4 File Offset: 0x00049FF4
		public bool isEmptyContent8()
		{
			return this.rbContent8.Text.Trim().Length == 0 || this.rbContent8.Text.Trim() == this._Content8Title;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0004BE44 File Offset: 0x0004A044
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0004BE7C File Offset: 0x0004A07C
		private void InitializeComponent()
		{
			this.panel4 = new Panel();
			this.panel13 = new Panel();
			this.panel14 = new Panel();
			this.rbContent8 = new RichTextBox();
			this.panel15 = new Panel();
			this.label15 = new Label();
			this.panel_CheckBase = new Panel();
			this.panel12 = new Panel();
			this.rbContent1 = new RichTextBox();
			this.panel11 = new Panel();
			this.label17 = new Label();
			this.label7 = new Label();
			this.panel4.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel_CheckBase.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel11.SuspendLayout();
			base.SuspendLayout();
			this.panel4.AutoScroll = true;
			this.panel4.Controls.Add(this.panel13);
			this.panel4.Controls.Add(this.panel_CheckBase);
			this.panel4.Dock = DockStyle.Fill;
			this.panel4.Location = new Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(777, 298);
			this.panel4.TabIndex = 4;
			this.panel4.Resize += this.panel4_Resize;
			this.panel13.Controls.Add(this.panel14);
			this.panel13.Controls.Add(this.panel15);
			this.panel13.Dock = DockStyle.Fill;
			this.panel13.Location = new Point(0, 129);
			this.panel13.Name = "panel13";
			this.panel13.Size = new Size(777, 169);
			this.panel13.TabIndex = 5;
			this.panel14.Controls.Add(this.rbContent8);
			this.panel14.Dock = DockStyle.Fill;
			this.panel14.Location = new Point(0, 20);
			this.panel14.Name = "panel14";
			this.panel14.Size = new Size(777, 149);
			this.panel14.TabIndex = 69;
			this.rbContent8.Dock = DockStyle.Fill;
			this.rbContent8.Font = new Font("굴림", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 129);
			this.rbContent8.Location = new Point(0, 0);
			this.rbContent8.Name = "rbContent8";
			this.rbContent8.Size = new Size(777, 149);
			this.rbContent8.TabIndex = 12;
			this.rbContent8.Text = "";
			this.rbContent8.MouseClick += this.rbContent8_MouseClick;
			this.panel15.Controls.Add(this.label15);
			this.panel15.Dock = DockStyle.Top;
			this.panel15.Location = new Point(0, 0);
			this.panel15.Name = "panel15";
			this.panel15.Size = new Size(777, 20);
			this.panel15.TabIndex = 67;
			this.label15.AutoSize = true;
			this.label15.Dock = DockStyle.Left;
			this.label15.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label15.Location = new Point(0, 0);
			this.label15.Name = "label15";
			this.label15.Size = new Size(174, 17);
			this.label15.TabIndex = 11;
			this.label15.Text = "Evidence (PCS pre-approval)";
			this.panel_CheckBase.Controls.Add(this.panel12);
			this.panel_CheckBase.Controls.Add(this.panel11);
			this.panel_CheckBase.Dock = DockStyle.Top;
			this.panel_CheckBase.Location = new Point(0, 0);
			this.panel_CheckBase.Name = "panel_CheckBase";
			this.panel_CheckBase.Size = new Size(777, 129);
			this.panel_CheckBase.TabIndex = 4;
			this.panel12.Controls.Add(this.rbContent1);
			this.panel12.Dock = DockStyle.Fill;
			this.panel12.Location = new Point(0, 20);
			this.panel12.Name = "panel12";
			this.panel12.Size = new Size(777, 109);
			this.panel12.TabIndex = 69;
			this.rbContent1.Dock = DockStyle.Fill;
			this.rbContent1.Font = new Font("굴림", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 129);
			this.rbContent1.Location = new Point(0, 0);
			this.rbContent1.Name = "rbContent1";
			this.rbContent1.Size = new Size(777, 109);
			this.rbContent1.TabIndex = 12;
			this.rbContent1.Text = "";
			this.rbContent1.MouseClick += this.rbContent1_MouseClick;
			this.panel11.Controls.Add(this.label17);
			this.panel11.Controls.Add(this.label7);
			this.panel11.Dock = DockStyle.Top;
			this.panel11.Location = new Point(0, 0);
			this.panel11.Name = "panel11";
			this.panel11.Size = new Size(777, 20);
			this.panel11.TabIndex = 67;
			this.label17.AutoSize = true;
			this.label17.Dock = DockStyle.Right;
			this.label17.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label17.Location = new Point(533, 0);
			this.label17.Name = "label17";
			this.label17.Size = new Size(244, 17);
			this.label17.TabIndex = 41;
			this.label17.Text = "※발송 메일의 용량은 1MB까지 입니다.";
			this.label7.AutoSize = true;
			this.label7.Dock = DockStyle.Left;
			this.label7.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(167, 17);
			this.label7.TabIndex = 11;
			this.label7.Text = "Problems or Reason of use";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel4);
			base.Name = "PMContent";
			base.Size = new Size(777, 298);
			this.panel4.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.panel15.PerformLayout();
			this.panel_CheckBase.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040003A1 RID: 929
		private long _fileSizeHTML = 0L;

		// Token: 0x040003A2 RID: 930
		private long _fileSizeRTF = 0L;

		// Token: 0x040003A3 RID: 931
		private readonly string _Content1Title = MessageLanguage.getMessage("pm_problem_tip");

		// Token: 0x040003A4 RID: 932
		private readonly string _Content8Title = MessageLanguage.getMessage("pm_evidence_tip").Replace("\r", string.Empty);

		// Token: 0x040003A5 RID: 933
		private IContainer components = null;

		// Token: 0x040003A6 RID: 934
		private Panel panel4;

		// Token: 0x040003A7 RID: 935
		private Panel panel13;

		// Token: 0x040003A8 RID: 936
		private Panel panel14;

		// Token: 0x040003A9 RID: 937
		private RichTextBox rbContent8;

		// Token: 0x040003AA RID: 938
		private Panel panel15;

		// Token: 0x040003AB RID: 939
		private Label label15;

		// Token: 0x040003AC RID: 940
		private Panel panel_CheckBase;

		// Token: 0x040003AD RID: 941
		private Panel panel12;

		// Token: 0x040003AE RID: 942
		private RichTextBox rbContent1;

		// Token: 0x040003AF RID: 943
		private Panel panel11;

		// Token: 0x040003B0 RID: 944
		private Label label17;

		// Token: 0x040003B1 RID: 945
		private Label label7;
	}
}
