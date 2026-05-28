using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x02000015 RID: 21
	public class Tab_FT_LB : Tab_Base
	{
		// Token: 0x060000AC RID: 172 RVA: 0x00016D7D File Offset: 0x00014F7D
		public Tab_FT_LB(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00016D94 File Offset: 0x00014F94
		public void SetInfo(CTemp tempInfo, CFT_LB cFT_LB)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
				this.tb_NumOfSites.Text = tempInfo.strNumOfSites.ToString();
				this.tb_Package.Text = tempInfo.strPackage;
				this.tb_TesterModel.Text = tempInfo.strEquipModel;
			}
			if (cFT_LB != null && tempInfo != null)
			{
				this._cFT_LB = cFT_LB;
				this.tb_NumOfSites.Text = cFT_LB.strNumOfSites;
				if (tempInfo.strNumOfSites != cFT_LB.strNumOfSites)
				{
					this.tb_NumOfSites.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_CapableTemp.Text = cFT_LB.strCapableTemp;
				this.tb_Package.Text = cFT_LB.strPackage;
				if (tempInfo.strPackage != cFT_LB.strPackage)
				{
					this.tb_Package.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_SockMfr.Text = cFT_LB.strSockMfr;
				this.tb_SockPartNo.Text = cFT_LB.strSockPartNo;
				this.tb_PcbCode.Text = cFT_LB.strPcbCode;
				this.tb_PcbRevision.Text = cFT_LB.strPcbRevision;
				this.tb_AccumInsert.Text = cFT_LB.iAccumInsert.ToString();
				this.tb_TesterModel.Text = cFT_LB.strTesterModel;
				if (tempInfo.strEquipModel != cFT_LB.strTesterModel)
				{
					this.tb_TesterModel.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_MfrName.Text = cFT_LB.strMfrName;
				this.tb_MfrPartNo.Text = cFT_LB.strMfrPartNo;
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00016F54 File Offset: 0x00015154
		public CFT_LB InputInfos()
		{
			CFT_LB cft_LB = new CFT_LB();
			if (cft_LB == null)
			{
				MessageBox.Show("No Info");
				return null;
			}
			cft_LB.strNumOfSites = this.tb_NumOfSites.Text;
			cft_LB.strCapableTemp = this.tb_CapableTemp.Text;
			cft_LB.strPackage = this.tb_Package.Text;
			cft_LB.strSockMfr = this.tb_SockMfr.Text;
			cft_LB.strSockPartNo = this.tb_SockPartNo.Text;
			cft_LB.strPcbCode = this.tb_PcbCode.Text;
			cft_LB.strPcbRevision = this.tb_PcbRevision.Text;
			if (this.tb_AccumInsert.Text != "")
			{
				if (!int.TryParse(this.tb_AccumInsert.Text, out cft_LB.iAccumInsert))
				{
					MessageBox.Show("Accum. Insertion must be Integer!");
					return null;
				}
			}
			else
			{
				cft_LB.iAccumInsert = 0;
			}
			cft_LB.strTesterModel = this.tb_TesterModel.Text;
			cft_LB.strMfrName = this.tb_MfrName.Text;
			cft_LB.strMfrPartNo = this.tb_MfrPartNo.Text;
			return cft_LB;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00017068 File Offset: 0x00015268
		public void ClearItems()
		{
			this.tb_NumOfSites.Text = "";
			this.tb_CapableTemp.Text = "";
			this.tb_SockMfr.Text = "";
			this.tb_SockPartNo.Text = "";
			this.tb_PcbCode.Text = "";
			this.tb_PcbRevision.Text = "";
			this.tb_AccumInsert.Text = "";
			this.tb_TesterModel.Text = "";
			this.tb_MfrName.Text = "";
			this.tb_MfrPartNo.Text = "";
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00017118 File Offset: 0x00015318
		private void tb_NumOfSites_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._tempInfo.strNumOfSites != this.tb_NumOfSites.Text && MessageBox.Show(string.Concat(new string[]
			{
				"Information is Different\nHCC: ",
				this._tempInfo.strNumOfSites,
				"\nTHIS: ",
				this.tb_NumOfSites.Text,
				"\nDo you want to change info from HCC?"
			}), "Different Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.tb_NumOfSites.Text = this._tempInfo.strNumOfSites;
				this.tb_NumOfSites.BackColor = Color.White;
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000171B8 File Offset: 0x000153B8
		private void tb_Package_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._tempInfo.strPackage != this.tb_Package.Text && MessageBox.Show(string.Concat(new string[]
			{
				"Information is Different\nHCC: ",
				this._tempInfo.strPackage,
				"\nTHIS: ",
				this.tb_Package.Text,
				"\nDo you want to change info from HCC?"
			}), "Different Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.tb_Package.Text = this._tempInfo.strPackage;
				this.tb_Package.BackColor = Color.White;
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00017258 File Offset: 0x00015458
		private void tb_TesterModel_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._tempInfo.strEquipModel != this.tb_TesterModel.Text && MessageBox.Show(string.Concat(new string[]
			{
				"Information is Different\nHCC: ",
				this._tempInfo.strEquipModel,
				"\nTHIS: ",
				this.tb_TesterModel.Text,
				"\nDo you want to change info from HCC?"
			}), "Different Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.tb_TesterModel.Text = this._tempInfo.strEquipModel;
				this.tb_TesterModel.BackColor = Color.White;
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000172F5 File Offset: 0x000154F5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00017314 File Offset: 0x00015514
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.label4 = new Label();
			this.tb_SockMfr = new TextBox();
			this.label6 = new Label();
			this.tb_AccumInsert = new TextBox();
			this.tb_NumOfSites = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.tb_CapableTemp = new TextBox();
			this.label3 = new Label();
			this.tb_Package = new TextBox();
			this.tb_MfrPartNo = new TextBox();
			this.label19 = new Label();
			this.tb_MfrName = new TextBox();
			this.label18 = new Label();
			this.tb_TesterModel = new TextBox();
			this.label17 = new Label();
			this.label9 = new Label();
			this.tb_SockPartNo = new TextBox();
			this.label10 = new Label();
			this.tb_PcbCode = new TextBox();
			this.label11 = new Label();
			this.tb_PcbRevision = new TextBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tb_SockMfr);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tb_AccumInsert);
			this.groupBox1.Controls.Add(this.tb_NumOfSites);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tb_CapableTemp);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tb_Package);
			this.groupBox1.Controls.Add(this.tb_MfrPartNo);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.tb_MfrName);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.tb_TesterModel);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tb_SockPartNo);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tb_PcbCode);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tb_PcbRevision);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(1050, 248);
			this.groupBox1.TabIndex = 62;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input Fields";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(13, 108);
			this.label4.Name = "label4";
			this.label4.Size = new Size(67, 15);
			this.label4.TabIndex = 51;
			this.label4.Text = "Socket Mfr.";
			this.tb_SockMfr.Location = new Point(139, 105);
			this.tb_SockMfr.Margin = new Padding(3, 5, 3, 5);
			this.tb_SockMfr.Name = "tb_SockMfr";
			this.tb_SockMfr.Size = new Size(200, 23);
			this.tb_SockMfr.TabIndex = 19;
			this.label6.AutoSize = true;
			this.label6.Location = new Point(360, 108);
			this.label6.Name = "label6";
			this.label6.Size = new Size(97, 15);
			this.label6.TabIndex = 53;
			this.label6.Text = "Accum. Insertion";
			this.tb_AccumInsert.Location = new Point(486, 105);
			this.tb_AccumInsert.Margin = new Padding(3, 5, 3, 5);
			this.tb_AccumInsert.Name = "tb_AccumInsert";
			this.tb_AccumInsert.Size = new Size(200, 23);
			this.tb_AccumInsert.TabIndex = 35;
			this.tb_NumOfSites.Location = new Point(139, 24);
			this.tb_NumOfSites.Margin = new Padding(3, 5, 3, 5);
			this.tb_NumOfSites.Name = "tb_NumOfSites";
			this.tb_NumOfSites.Size = new Size(200, 23);
			this.tb_NumOfSites.TabIndex = 14;
			this.tb_NumOfSites.MouseDoubleClick += this.tb_NumOfSites_MouseDoubleClick;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(13, 27);
			this.label1.Name = "label1";
			this.label1.Size = new Size(67, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "No. of Sites";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(13, 54);
			this.label2.Name = "label2";
			this.label2.Size = new Size(120, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Capable Temperature";
			this.tb_CapableTemp.Location = new Point(139, 51);
			this.tb_CapableTemp.Margin = new Padding(3, 5, 3, 5);
			this.tb_CapableTemp.Name = "tb_CapableTemp";
			this.tb_CapableTemp.Size = new Size(200, 23);
			this.tb_CapableTemp.TabIndex = 16;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(13, 81);
			this.label3.Name = "label3";
			this.label3.Size = new Size(51, 15);
			this.label3.TabIndex = 17;
			this.label3.Text = "Package";
			this.tb_Package.Location = new Point(139, 78);
			this.tb_Package.Margin = new Padding(3, 5, 3, 5);
			this.tb_Package.Name = "tb_Package";
			this.tb_Package.Size = new Size(200, 23);
			this.tb_Package.TabIndex = 18;
			this.tb_Package.MouseDoubleClick += this.tb_Package_MouseDoubleClick;
			this.tb_MfrPartNo.Location = new Point(836, 78);
			this.tb_MfrPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfrPartNo.Name = "tb_MfrPartNo";
			this.tb_MfrPartNo.Size = new Size(200, 23);
			this.tb_MfrPartNo.TabIndex = 50;
			this.label19.AutoSize = true;
			this.label19.Location = new Point(710, 81);
			this.label19.Name = "label19";
			this.label19.Size = new Size(100, 15);
			this.label19.TabIndex = 49;
			this.label19.Text = "Mfr. Part Number";
			this.tb_MfrName.Location = new Point(836, 51);
			this.tb_MfrName.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfrName.Name = "tb_MfrName";
			this.tb_MfrName.Size = new Size(200, 23);
			this.tb_MfrName.TabIndex = 48;
			this.label18.AutoSize = true;
			this.label18.Location = new Point(710, 54);
			this.label18.Name = "label18";
			this.label18.Size = new Size(64, 15);
			this.label18.TabIndex = 47;
			this.label18.Text = "Mfr. Name";
			this.tb_TesterModel.Location = new Point(836, 24);
			this.tb_TesterModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_TesterModel.Name = "tb_TesterModel";
			this.tb_TesterModel.Size = new Size(200, 23);
			this.tb_TesterModel.TabIndex = 46;
			this.tb_TesterModel.MouseDoubleClick += this.tb_TesterModel_MouseDoubleClick;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(710, 27);
			this.label17.Name = "label17";
			this.label17.Size = new Size(75, 15);
			this.label17.TabIndex = 45;
			this.label17.Text = "Tester Model";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(360, 27);
			this.label9.Name = "label9";
			this.label9.Size = new Size(113, 15);
			this.label9.TabIndex = 29;
			this.label9.Text = "Socket Part Number";
			this.tb_SockPartNo.Location = new Point(486, 24);
			this.tb_SockPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_SockPartNo.Name = "tb_SockPartNo";
			this.tb_SockPartNo.Size = new Size(200, 23);
			this.tb_SockPartNo.TabIndex = 30;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(360, 54);
			this.label10.Name = "label10";
			this.label10.Size = new Size(60, 15);
			this.label10.TabIndex = 31;
			this.label10.Text = "PCB Code";
			this.tb_PcbCode.Location = new Point(486, 51);
			this.tb_PcbCode.Margin = new Padding(3, 5, 3, 5);
			this.tb_PcbCode.Name = "tb_PcbCode";
			this.tb_PcbCode.Size = new Size(200, 23);
			this.tb_PcbCode.TabIndex = 32;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(360, 81);
			this.label11.Name = "label11";
			this.label11.Size = new Size(76, 15);
			this.label11.TabIndex = 33;
			this.label11.Text = "PCB Revision";
			this.tb_PcbRevision.Location = new Point(486, 78);
			this.tb_PcbRevision.Margin = new Padding(3, 5, 3, 5);
			this.tb_PcbRevision.Name = "tb_PcbRevision";
			this.tb_PcbRevision.Size = new Size(200, 23);
			this.tb_PcbRevision.TabIndex = 34;
			base.Name = "Tab_FT_LB";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000162 RID: 354
		private CTemp _tempInfo;

		// Token: 0x04000163 RID: 355
		private CFT_LB _cFT_LB;

		// Token: 0x04000164 RID: 356
		private IContainer components;

		// Token: 0x04000165 RID: 357
		private GroupBox groupBox1;

		// Token: 0x04000166 RID: 358
		private TextBox tb_NumOfSites;

		// Token: 0x04000167 RID: 359
		private Label label1;

		// Token: 0x04000168 RID: 360
		private Label label2;

		// Token: 0x04000169 RID: 361
		private TextBox tb_CapableTemp;

		// Token: 0x0400016A RID: 362
		private Label label3;

		// Token: 0x0400016B RID: 363
		private TextBox tb_Package;

		// Token: 0x0400016C RID: 364
		private TextBox tb_MfrPartNo;

		// Token: 0x0400016D RID: 365
		private Label label19;

		// Token: 0x0400016E RID: 366
		private TextBox tb_MfrName;

		// Token: 0x0400016F RID: 367
		private Label label18;

		// Token: 0x04000170 RID: 368
		private TextBox tb_TesterModel;

		// Token: 0x04000171 RID: 369
		private Label label17;

		// Token: 0x04000172 RID: 370
		private Label label9;

		// Token: 0x04000173 RID: 371
		private TextBox tb_SockPartNo;

		// Token: 0x04000174 RID: 372
		private Label label10;

		// Token: 0x04000175 RID: 373
		private TextBox tb_PcbCode;

		// Token: 0x04000176 RID: 374
		private Label label11;

		// Token: 0x04000177 RID: 375
		private TextBox tb_PcbRevision;

		// Token: 0x04000178 RID: 376
		private Label label4;

		// Token: 0x04000179 RID: 377
		private TextBox tb_SockMfr;

		// Token: 0x0400017A RID: 378
		private Label label6;

		// Token: 0x0400017B RID: 379
		private TextBox tb_AccumInsert;
	}
}
