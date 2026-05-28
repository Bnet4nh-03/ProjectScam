using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x02000016 RID: 22
	public class Tab_FT_LK : Tab_Base
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x00017F74 File Offset: 0x00016174
		public Tab_FT_LK(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00017F8C File Offset: 0x0001618C
		public void SetInfo(CTemp tempInfo, CFT_LK cFT_LK)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
				this.tb_NumOfSites.Text = tempInfo.strNumOfSites.ToString();
			}
			if (cFT_LK != null && tempInfo != null)
			{
				this._cFT_LK = cFT_LK;
				this.tb_NumOfSites.Text = cFT_LK.strNumOfSites;
				if (tempInfo.strNumOfSites != cFT_LK.strNumOfSites)
				{
					this.tb_NumOfSites.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_SitePitch.Text = cFT_LK.strSitePitch;
				this.tb_HeadConfig.Text = cFT_LK.strHeadConfig;
				this.tb_DirectHeater.Text = cFT_LK.strDirectHeater;
				this.tb_HdlModel.Text = cFT_LK.strHdlModel;
				this.tb_KitMfrName.Text = cFT_LK.strKitMfrName;
				this.tb_MfrPartNo.Text = cFT_LK.strMfrPartNo;
				this.tb_KitSupplier.Text = cFT_LK.strKitSupplier;
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0001808C File Offset: 0x0001628C
		public CFT_LK InputInfos()
		{
			CFT_LK cft_LK = new CFT_LK();
			if (cft_LK == null)
			{
				return null;
			}
			cft_LK.strNumOfSites = this.tb_NumOfSites.Text;
			cft_LK.strSitePitch = this.tb_SitePitch.Text;
			cft_LK.strHeadConfig = this.tb_HeadConfig.Text;
			cft_LK.strDirectHeater = this.tb_DirectHeater.Text;
			cft_LK.strHdlModel = this.tb_HdlModel.Text;
			cft_LK.strKitMfrName = this.tb_KitMfrName.Text;
			cft_LK.strMfrPartNo = this.tb_MfrPartNo.Text;
			cft_LK.strKitSupplier = this.tb_KitSupplier.Text;
			return cft_LK;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00018130 File Offset: 0x00016330
		public void ClearItems()
		{
			this.tb_NumOfSites.Text = "";
			this.tb_SitePitch.Text = "";
			this.tb_HeadConfig.Text = "";
			this.tb_DirectHeater.Text = "";
			this.tb_HdlModel.Text = "";
			this.tb_KitMfrName.Text = "";
			this.tb_MfrPartNo.Text = "";
			this.tb_KitSupplier.Text = "";
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000181C0 File Offset: 0x000163C0
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

		// Token: 0x060000BA RID: 186 RVA: 0x0001825D File Offset: 0x0001645D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0001827C File Offset: 0x0001647C
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.tb_NumOfSites = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.tb_SitePitch = new TextBox();
			this.label3 = new Label();
			this.tb_HeadConfig = new TextBox();
			this.tb_KitSupplier = new TextBox();
			this.label18 = new Label();
			this.tb_MfrPartNo = new TextBox();
			this.label17 = new Label();
			this.label9 = new Label();
			this.tb_DirectHeater = new TextBox();
			this.label10 = new Label();
			this.tb_HdlModel = new TextBox();
			this.label11 = new Label();
			this.tb_KitMfrName = new TextBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.groupBox1.Controls.Add(this.tb_NumOfSites);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tb_SitePitch);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tb_HeadConfig);
			this.groupBox1.Controls.Add(this.tb_KitSupplier);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.tb_MfrPartNo);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tb_DirectHeater);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tb_HdlModel);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tb_KitMfrName);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(1050, 248);
			this.groupBox1.TabIndex = 63;
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
			this.label2.Size = new Size(56, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Site Pitch";
			this.tb_SitePitch.Location = new Point(139, 51);
			this.tb_SitePitch.Margin = new Padding(3, 5, 3, 5);
			this.tb_SitePitch.Name = "tb_SitePitch";
			this.tb_SitePitch.Size = new Size(200, 23);
			this.tb_SitePitch.TabIndex = 16;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(13, 81);
			this.label3.Name = "label3";
			this.label3.Size = new Size(74, 15);
			this.label3.TabIndex = 17;
			this.label3.Text = "Head Config";
			this.tb_HeadConfig.Location = new Point(139, 78);
			this.tb_HeadConfig.Margin = new Padding(3, 5, 3, 5);
			this.tb_HeadConfig.Name = "tb_HeadConfig";
			this.tb_HeadConfig.Size = new Size(200, 23);
			this.tb_HeadConfig.TabIndex = 18;
			this.tb_KitSupplier.Location = new Point(836, 51);
			this.tb_KitSupplier.Margin = new Padding(3, 5, 3, 5);
			this.tb_KitSupplier.Name = "tb_KitSupplier";
			this.tb_KitSupplier.Size = new Size(200, 23);
			this.tb_KitSupplier.TabIndex = 48;
			this.label18.AutoSize = true;
			this.label18.Location = new Point(710, 54);
			this.label18.Name = "label18";
			this.label18.Size = new Size(67, 15);
			this.label18.TabIndex = 47;
			this.label18.Text = "Kit Supplier";
			this.tb_MfrPartNo.Location = new Point(836, 24);
			this.tb_MfrPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfrPartNo.Name = "tb_MfrPartNo";
			this.tb_MfrPartNo.Size = new Size(200, 23);
			this.tb_MfrPartNo.TabIndex = 46;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(710, 27);
			this.label17.Name = "label17";
			this.label17.Size = new Size(100, 15);
			this.label17.TabIndex = 45;
			this.label17.Text = "Mfr. Part Number";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(360, 27);
			this.label9.Name = "label9";
			this.label9.Size = new Size(76, 15);
			this.label9.TabIndex = 29;
			this.label9.Text = "Direct Heater";
			this.tb_DirectHeater.Location = new Point(486, 24);
			this.tb_DirectHeater.Margin = new Padding(3, 5, 3, 5);
			this.tb_DirectHeater.Name = "tb_DirectHeater";
			this.tb_DirectHeater.Size = new Size(200, 23);
			this.tb_DirectHeater.TabIndex = 30;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(360, 54);
			this.label10.Name = "label10";
			this.label10.Size = new Size(86, 15);
			this.label10.TabIndex = 31;
			this.label10.Text = "Handler Model";
			this.tb_HdlModel.Location = new Point(486, 51);
			this.tb_HdlModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_HdlModel.Name = "tb_HdlModel";
			this.tb_HdlModel.Size = new Size(200, 23);
			this.tb_HdlModel.TabIndex = 32;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(360, 81);
			this.label11.Name = "label11";
			this.label11.Size = new Size(81, 15);
			this.label11.TabIndex = 33;
			this.label11.Text = "Kit Mfr. Name";
			this.tb_KitMfrName.Location = new Point(486, 78);
			this.tb_KitMfrName.Margin = new Padding(3, 5, 3, 5);
			this.tb_KitMfrName.Name = "tb_KitMfrName";
			this.tb_KitMfrName.Size = new Size(200, 23);
			this.tb_KitMfrName.TabIndex = 34;
			base.Name = "Tab_FT_LK";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400017C RID: 380
		private CTemp _tempInfo;

		// Token: 0x0400017D RID: 381
		private CFT_LK _cFT_LK;

		// Token: 0x0400017E RID: 382
		private IContainer components;

		// Token: 0x0400017F RID: 383
		private GroupBox groupBox1;

		// Token: 0x04000180 RID: 384
		private TextBox tb_NumOfSites;

		// Token: 0x04000181 RID: 385
		private Label label1;

		// Token: 0x04000182 RID: 386
		private Label label2;

		// Token: 0x04000183 RID: 387
		private TextBox tb_SitePitch;

		// Token: 0x04000184 RID: 388
		private Label label3;

		// Token: 0x04000185 RID: 389
		private TextBox tb_HeadConfig;

		// Token: 0x04000186 RID: 390
		private TextBox tb_KitSupplier;

		// Token: 0x04000187 RID: 391
		private Label label18;

		// Token: 0x04000188 RID: 392
		private TextBox tb_MfrPartNo;

		// Token: 0x04000189 RID: 393
		private Label label17;

		// Token: 0x0400018A RID: 394
		private Label label9;

		// Token: 0x0400018B RID: 395
		private TextBox tb_DirectHeater;

		// Token: 0x0400018C RID: 396
		private Label label10;

		// Token: 0x0400018D RID: 397
		private TextBox tb_HdlModel;

		// Token: 0x0400018E RID: 398
		private Label label11;

		// Token: 0x0400018F RID: 399
		private TextBox tb_KitMfrName;
	}
}
