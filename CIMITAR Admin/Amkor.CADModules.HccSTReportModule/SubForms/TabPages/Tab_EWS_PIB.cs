using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x0200000F RID: 15
	public class Tab_EWS_PIB : Tab_Base
	{
		// Token: 0x06000080 RID: 128 RVA: 0x00012A89 File Offset: 0x00010C89
		public Tab_EWS_PIB(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00012AA0 File Offset: 0x00010CA0
		public void SetInfo(CTemp tempInfo, CEWS_PIB cEWS_PIB)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
				this.tb_NumOfSites.Text = tempInfo.strNumOfSites.ToString();
				this.tb_TesterModel.Text = tempInfo.strEquipModel;
			}
			if (cEWS_PIB != null && tempInfo != null)
			{
				this._cEWS_PIB = cEWS_PIB;
				this.tb_NumOfSites.Text = cEWS_PIB.strNumOfSites;
				if (tempInfo.strNumOfSites != cEWS_PIB.strNumOfSites)
				{
					this.tb_NumOfSites.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_PcbId.Text = cEWS_PIB.strPcbId;
				this.tb_PcbRevision.Text = cEWS_PIB.strPcbRevision;
				this.tb_MfrName.Text = cEWS_PIB.strMfrName;
				this.tb_MfrPartNo.Text = cEWS_PIB.strMfrPartNo;
				this.tb_TesterModel.Text = cEWS_PIB.strTesterModel;
				if (tempInfo.strEquipModel != cEWS_PIB.strTesterModel)
				{
					this.tb_TesterModel.BackColor = Color.FromArgb(246, 229, 141);
				}
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00012BC4 File Offset: 0x00010DC4
		public CEWS_PIB InputInfos()
		{
			CEWS_PIB cews_PIB = new CEWS_PIB();
			if (cews_PIB == null)
			{
				MessageBox.Show("No Info");
				return null;
			}
			cews_PIB.strNumOfSites = this.tb_NumOfSites.Text;
			cews_PIB.strPcbId = this.tb_PcbId.Text;
			cews_PIB.strPcbRevision = this.tb_PcbRevision.Text;
			cews_PIB.strMfrName = this.tb_MfrName.Text;
			cews_PIB.strMfrPartNo = this.tb_MfrPartNo.Text;
			cews_PIB.strTesterModel = this.tb_TesterModel.Text;
			return cews_PIB;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00012C50 File Offset: 0x00010E50
		public void ClearItems()
		{
			this.tb_NumOfSites.Text = "";
			this.tb_PcbId.Text = "";
			this.tb_PcbRevision.Text = "";
			this.tb_MfrName.Text = "";
			this.tb_MfrPartNo.Text = "";
			this.tb_TesterModel.Text = "";
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00012CC0 File Offset: 0x00010EC0
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

		// Token: 0x06000085 RID: 133 RVA: 0x00012D60 File Offset: 0x00010F60
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

		// Token: 0x06000086 RID: 134 RVA: 0x00012DFD File Offset: 0x00010FFD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00012E1C File Offset: 0x0001101C
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.tb_NumOfSites = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.tb_PcbId = new TextBox();
			this.label3 = new Label();
			this.tb_PcbRevision = new TextBox();
			this.tb_TesterModel = new TextBox();
			this.label17 = new Label();
			this.label9 = new Label();
			this.tb_MfrName = new TextBox();
			this.label10 = new Label();
			this.tb_MfrPartNo = new TextBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.groupBox1.Controls.Add(this.tb_NumOfSites);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tb_PcbId);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tb_PcbRevision);
			this.groupBox1.Controls.Add(this.tb_TesterModel);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tb_MfrName);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tb_MfrPartNo);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(1050, 248);
			this.groupBox1.TabIndex = 62;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input Fields";
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
			this.label2.Size = new Size(43, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "PCB ID";
			this.tb_PcbId.Location = new Point(139, 51);
			this.tb_PcbId.Margin = new Padding(3, 5, 3, 5);
			this.tb_PcbId.Name = "tb_PcbId";
			this.tb_PcbId.Size = new Size(200, 23);
			this.tb_PcbId.TabIndex = 16;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(360, 27);
			this.label3.Name = "label3";
			this.label3.Size = new Size(76, 15);
			this.label3.TabIndex = 17;
			this.label3.Text = "PCB Revision";
			this.tb_PcbRevision.Location = new Point(486, 24);
			this.tb_PcbRevision.Margin = new Padding(3, 5, 3, 5);
			this.tb_PcbRevision.Name = "tb_PcbRevision";
			this.tb_PcbRevision.Size = new Size(200, 23);
			this.tb_PcbRevision.TabIndex = 18;
			this.tb_TesterModel.Location = new Point(836, 51);
			this.tb_TesterModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_TesterModel.Name = "tb_TesterModel";
			this.tb_TesterModel.Size = new Size(200, 23);
			this.tb_TesterModel.TabIndex = 46;
			this.tb_TesterModel.MouseDoubleClick += this.tb_TesterModel_MouseDoubleClick;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(710, 54);
			this.label17.Name = "label17";
			this.label17.Size = new Size(75, 15);
			this.label17.TabIndex = 45;
			this.label17.Text = "Tester Model";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(360, 54);
			this.label9.Name = "label9";
			this.label9.Size = new Size(64, 15);
			this.label9.TabIndex = 29;
			this.label9.Text = "Mfr. Name";
			this.tb_MfrName.Location = new Point(486, 51);
			this.tb_MfrName.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfrName.Name = "tb_MfrName";
			this.tb_MfrName.Size = new Size(200, 23);
			this.tb_MfrName.TabIndex = 30;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(710, 27);
			this.label10.Name = "label10";
			this.label10.Size = new Size(100, 15);
			this.label10.TabIndex = 31;
			this.label10.Text = "Mfr. Part Number";
			this.tb_MfrPartNo.Location = new Point(836, 24);
			this.tb_MfrPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfrPartNo.Name = "tb_MfrPartNo";
			this.tb_MfrPartNo.Size = new Size(200, 23);
			this.tb_MfrPartNo.TabIndex = 32;
			base.Name = "Tab_EWS_PIB";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040000F8 RID: 248
		private CTemp _tempInfo;

		// Token: 0x040000F9 RID: 249
		private CEWS_PIB _cEWS_PIB;

		// Token: 0x040000FA RID: 250
		private IContainer components;

		// Token: 0x040000FB RID: 251
		private GroupBox groupBox1;

		// Token: 0x040000FC RID: 252
		private TextBox tb_NumOfSites;

		// Token: 0x040000FD RID: 253
		private Label label1;

		// Token: 0x040000FE RID: 254
		private Label label2;

		// Token: 0x040000FF RID: 255
		private TextBox tb_PcbId;

		// Token: 0x04000100 RID: 256
		private Label label3;

		// Token: 0x04000101 RID: 257
		private TextBox tb_PcbRevision;

		// Token: 0x04000102 RID: 258
		private TextBox tb_TesterModel;

		// Token: 0x04000103 RID: 259
		private Label label17;

		// Token: 0x04000104 RID: 260
		private Label label9;

		// Token: 0x04000105 RID: 261
		private TextBox tb_MfrName;

		// Token: 0x04000106 RID: 262
		private Label label10;

		// Token: 0x04000107 RID: 263
		private TextBox tb_MfrPartNo;
	}
}
