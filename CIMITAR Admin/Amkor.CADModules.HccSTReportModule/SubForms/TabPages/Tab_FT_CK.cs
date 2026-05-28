using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x02000011 RID: 17
	public class Tab_FT_CK : Tab_Base
	{
		// Token: 0x0600008E RID: 142 RVA: 0x000140C7 File Offset: 0x000122C7
		public Tab_FT_CK(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000140DC File Offset: 0x000122DC
		public void SetInfo(CTemp tempInfo, CFT_CK cFT_CK)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
				this.tb_NumOfSites.Text = tempInfo.strNumOfSites.ToString();
				this.tb_Package.Text = tempInfo.strPackage;
				this.tb_HdlModel.Text = tempInfo.strEquipModel;
			}
			if (cFT_CK != null && tempInfo != null)
			{
				this._cFT_CK = cFT_CK;
				this.tb_NumOfSites.Text = cFT_CK.strNumOfSites;
				if (tempInfo.strNumOfSites != cFT_CK.strNumOfSites)
				{
					this.tb_NumOfSites.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_Package.Text = cFT_CK.strPackage;
				if (tempInfo.strPackage != cFT_CK.strPackage)
				{
					this.tb_Package.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_HdlModel.Text = cFT_CK.strHdlModel;
				if (tempInfo.strEquipModel != cFT_CK.strHdlModel)
				{
					this.tb_HdlModel.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_KitMfrName.Text = cFT_CK.strKitMfrName;
				this.tb_MfrPartNo.Text = cFT_CK.strMfrPartNo;
				this.tb_KitSupplier.Text = cFT_CK.strKitSupplier;
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00014240 File Offset: 0x00012440
		public CFT_CK InputInfos()
		{
			CFT_CK cft_CK = new CFT_CK();
			if (cft_CK == null)
			{
				MessageBox.Show("No Info");
				return null;
			}
			cft_CK.strNumOfSites = this.tb_NumOfSites.Text;
			cft_CK.strPackage = this.tb_Package.Text;
			cft_CK.strHdlModel = this.tb_HdlModel.Text;
			cft_CK.strKitMfrName = this.tb_KitMfrName.Text;
			cft_CK.strMfrPartNo = this.tb_MfrPartNo.Text;
			cft_CK.strKitSupplier = this.tb_KitSupplier.Text;
			return cft_CK;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000142CC File Offset: 0x000124CC
		public void ClearItems()
		{
			this.tb_NumOfSites.Text = "";
			this.tb_Package.Text = "";
			this.tb_HdlModel.Text = "";
			this.tb_KitMfrName.Text = "";
			this.tb_MfrPartNo.Text = "";
			this.tb_KitSupplier.Text = "";
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0001433C File Offset: 0x0001253C
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

		// Token: 0x06000093 RID: 147 RVA: 0x000143DC File Offset: 0x000125DC
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

		// Token: 0x06000094 RID: 148 RVA: 0x0001447C File Offset: 0x0001267C
		private void tb_HdlModel_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._tempInfo.strEquipModel != this._cFT_CK.strHdlModel && MessageBox.Show(string.Concat(new string[]
			{
				"Information is Different\nHCC: ",
				this._tempInfo.strEquipModel,
				"\nTHIS: ",
				this._cFT_CK.strHdlModel,
				"\nDo you want to change info from HCC?"
			}), "Different Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.tb_HdlModel.Text = this._tempInfo.strEquipModel;
				this.tb_HdlModel.BackColor = Color.White;
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00014519 File Offset: 0x00012719
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00014538 File Offset: 0x00012738
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.tb_NumOfSites = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.tb_Package = new TextBox();
			this.tb_KitSupplier = new TextBox();
			this.label18 = new Label();
			this.tb_MfrPartNo = new TextBox();
			this.label17 = new Label();
			this.label9 = new Label();
			this.tb_HdlModel = new TextBox();
			this.label10 = new Label();
			this.tb_KitMfrName = new TextBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.groupBox1.Controls.Add(this.tb_NumOfSites);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tb_Package);
			this.groupBox1.Controls.Add(this.tb_KitSupplier);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.tb_MfrPartNo);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tb_HdlModel);
			this.groupBox1.Controls.Add(this.label10);
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
			this.label2.Size = new Size(51, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Package";
			this.tb_Package.Location = new Point(139, 51);
			this.tb_Package.Margin = new Padding(3, 5, 3, 5);
			this.tb_Package.Name = "tb_Package";
			this.tb_Package.Size = new Size(200, 23);
			this.tb_Package.TabIndex = 16;
			this.tb_Package.MouseDoubleClick += this.tb_Package_MouseDoubleClick;
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
			this.label9.Size = new Size(86, 15);
			this.label9.TabIndex = 29;
			this.label9.Text = "Handler Model";
			this.tb_HdlModel.Location = new Point(486, 24);
			this.tb_HdlModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_HdlModel.Name = "tb_HdlModel";
			this.tb_HdlModel.Size = new Size(200, 23);
			this.tb_HdlModel.TabIndex = 30;
			this.tb_HdlModel.MouseDoubleClick += this.tb_HdlModel_MouseDoubleClick;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(360, 54);
			this.label10.Name = "label10";
			this.label10.Size = new Size(81, 15);
			this.label10.TabIndex = 31;
			this.label10.Text = "Kit Mfr. Name";
			this.tb_KitMfrName.Location = new Point(486, 51);
			this.tb_KitMfrName.Margin = new Padding(3, 5, 3, 5);
			this.tb_KitMfrName.Name = "tb_KitMfrName";
			this.tb_KitMfrName.Size = new Size(200, 23);
			this.tb_KitMfrName.TabIndex = 32;
			base.Name = "Tab_FT_CK";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400011C RID: 284
		private CTemp _tempInfo;

		// Token: 0x0400011D RID: 285
		private CFT_CK _cFT_CK;

		// Token: 0x0400011E RID: 286
		private IContainer components;

		// Token: 0x0400011F RID: 287
		private GroupBox groupBox1;

		// Token: 0x04000120 RID: 288
		private TextBox tb_NumOfSites;

		// Token: 0x04000121 RID: 289
		private Label label1;

		// Token: 0x04000122 RID: 290
		private Label label2;

		// Token: 0x04000123 RID: 291
		private TextBox tb_Package;

		// Token: 0x04000124 RID: 292
		private TextBox tb_KitSupplier;

		// Token: 0x04000125 RID: 293
		private Label label18;

		// Token: 0x04000126 RID: 294
		private TextBox tb_MfrPartNo;

		// Token: 0x04000127 RID: 295
		private Label label17;

		// Token: 0x04000128 RID: 296
		private Label label9;

		// Token: 0x04000129 RID: 297
		private TextBox tb_HdlModel;

		// Token: 0x0400012A RID: 298
		private Label label10;

		// Token: 0x0400012B RID: 299
		private TextBox tb_KitMfrName;
	}
}
