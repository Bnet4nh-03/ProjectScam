using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x02000013 RID: 19
	public class Tab_FT_DUT : Tab_Base
	{
		// Token: 0x0600009D RID: 157 RVA: 0x000157C3 File Offset: 0x000139C3
		public Tab_FT_DUT(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000157D8 File Offset: 0x000139D8
		public void SetInfo(CTemp tempInfo, CFT_DUT cFT_DUT)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
				this.tb_Package.Text = tempInfo.strPackage;
			}
			if (cFT_DUT != null && tempInfo != null)
			{
				this._cFT_DUT = cFT_DUT;
				this.tb_Package.Text = cFT_DUT.strPackage;
				if (tempInfo.strPackage != cFT_DUT.strPackage)
				{
					this.tb_Package.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_InstalledEquipModel.Text = cFT_DUT.strInstalledEquipModel;
				this.tb_FreeProperty1.Text = cFT_DUT.strFreeProperty1;
				this.tb_FreeProperty2.Text = cFT_DUT.strFreeProperty2;
				this.tb_FreeProperty3.Text = cFT_DUT.strFreeProperty3;
				this.tb_BoardMfrName.Text = cFT_DUT.strBoardMfrName;
				this.tb_BoardMfrPartNo.Text = cFT_DUT.strBoardMfrPartNo;
				this.tb_BoardSupplier.Text = cFT_DUT.strBoardSupplier;
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000158D4 File Offset: 0x00013AD4
		public CFT_DUT InputInfos()
		{
			CFT_DUT cft_DUT = new CFT_DUT();
			if (cft_DUT == null)
			{
				MessageBox.Show("No Info");
				return null;
			}
			cft_DUT.strPackage = this.tb_Package.Text;
			cft_DUT.strInstalledEquipModel = this.tb_InstalledEquipModel.Text;
			cft_DUT.strFreeProperty1 = this.tb_FreeProperty1.Text;
			cft_DUT.strFreeProperty2 = this.tb_FreeProperty2.Text;
			cft_DUT.strFreeProperty3 = this.tb_FreeProperty3.Text;
			cft_DUT.strBoardMfrName = this.tb_BoardMfrName.Text;
			cft_DUT.strBoardMfrPartNo = this.tb_BoardMfrPartNo.Text;
			cft_DUT.strBoardSupplier = this.tb_BoardSupplier.Text;
			return cft_DUT;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00015980 File Offset: 0x00013B80
		public void ClearItems()
		{
			this.tb_Package.Text = "";
			this.tb_InstalledEquipModel.Text = "";
			this.tb_FreeProperty1.Text = "";
			this.tb_FreeProperty2.Text = "";
			this.tb_FreeProperty3.Text = "";
			this.tb_BoardMfrName.Text = "";
			this.tb_BoardMfrPartNo.Text = "";
			this.tb_BoardSupplier.Text = "";
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00015A10 File Offset: 0x00013C10
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

		// Token: 0x060000A2 RID: 162 RVA: 0x00015AAD File Offset: 0x00013CAD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00015ACC File Offset: 0x00013CCC
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.tb_Package = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.tb_InstalledEquipModel = new TextBox();
			this.label3 = new Label();
			this.tb_FreeProperty1 = new TextBox();
			this.tb_BoardSupplier = new TextBox();
			this.label18 = new Label();
			this.tb_BoardMfrPartNo = new TextBox();
			this.label17 = new Label();
			this.label9 = new Label();
			this.tb_FreeProperty2 = new TextBox();
			this.label10 = new Label();
			this.tb_FreeProperty3 = new TextBox();
			this.label11 = new Label();
			this.tb_BoardMfrName = new TextBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.groupBox1.Controls.Add(this.tb_Package);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tb_InstalledEquipModel);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tb_FreeProperty1);
			this.groupBox1.Controls.Add(this.tb_BoardSupplier);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.tb_BoardMfrPartNo);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tb_FreeProperty2);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tb_FreeProperty3);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tb_BoardMfrName);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(1050, 248);
			this.groupBox1.TabIndex = 64;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input Fields";
			this.tb_Package.Location = new Point(139, 24);
			this.tb_Package.Margin = new Padding(3, 5, 3, 5);
			this.tb_Package.Name = "tb_Package";
			this.tb_Package.Size = new Size(200, 23);
			this.tb_Package.TabIndex = 14;
			this.tb_Package.MouseDoubleClick += this.tb_Package_MouseDoubleClick;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(13, 27);
			this.label1.Name = "label1";
			this.label1.Size = new Size(51, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "Package";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(13, 54);
			this.label2.Name = "label2";
			this.label2.Size = new Size(121, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Installed Equip Model";
			this.tb_InstalledEquipModel.Location = new Point(139, 51);
			this.tb_InstalledEquipModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_InstalledEquipModel.Name = "tb_InstalledEquipModel";
			this.tb_InstalledEquipModel.Size = new Size(200, 23);
			this.tb_InstalledEquipModel.TabIndex = 16;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(13, 81);
			this.label3.Name = "label3";
			this.label3.Size = new Size(86, 15);
			this.label3.TabIndex = 17;
			this.label3.Text = "Free Property 1";
			this.tb_FreeProperty1.Location = new Point(139, 78);
			this.tb_FreeProperty1.Margin = new Padding(3, 5, 3, 5);
			this.tb_FreeProperty1.Name = "tb_FreeProperty1";
			this.tb_FreeProperty1.Size = new Size(200, 23);
			this.tb_FreeProperty1.TabIndex = 18;
			this.tb_BoardSupplier.Location = new Point(836, 51);
			this.tb_BoardSupplier.Margin = new Padding(3, 5, 3, 5);
			this.tb_BoardSupplier.Name = "tb_BoardSupplier";
			this.tb_BoardSupplier.Size = new Size(200, 23);
			this.tb_BoardSupplier.TabIndex = 48;
			this.label18.AutoSize = true;
			this.label18.Location = new Point(710, 54);
			this.label18.Name = "label18";
			this.label18.Size = new Size(84, 15);
			this.label18.TabIndex = 47;
			this.label18.Text = "Board Supplier";
			this.tb_BoardMfrPartNo.Location = new Point(836, 24);
			this.tb_BoardMfrPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_BoardMfrPartNo.Name = "tb_BoardMfrPartNo";
			this.tb_BoardMfrPartNo.Size = new Size(200, 23);
			this.tb_BoardMfrPartNo.TabIndex = 46;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(710, 27);
			this.label17.Name = "label17";
			this.label17.Size = new Size(109, 15);
			this.label17.TabIndex = 45;
			this.label17.Text = "Board Mfr. Part No.";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(360, 27);
			this.label9.Name = "label9";
			this.label9.Size = new Size(86, 15);
			this.label9.TabIndex = 29;
			this.label9.Text = "Free Property 2";
			this.tb_FreeProperty2.Location = new Point(486, 24);
			this.tb_FreeProperty2.Margin = new Padding(3, 5, 3, 5);
			this.tb_FreeProperty2.Name = "tb_FreeProperty2";
			this.tb_FreeProperty2.Size = new Size(200, 23);
			this.tb_FreeProperty2.TabIndex = 30;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(360, 54);
			this.label10.Name = "label10";
			this.label10.Size = new Size(86, 15);
			this.label10.TabIndex = 31;
			this.label10.Text = "Free Property 3";
			this.tb_FreeProperty3.Location = new Point(486, 51);
			this.tb_FreeProperty3.Margin = new Padding(3, 5, 3, 5);
			this.tb_FreeProperty3.Name = "tb_FreeProperty3";
			this.tb_FreeProperty3.Size = new Size(200, 23);
			this.tb_FreeProperty3.TabIndex = 32;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(360, 81);
			this.label11.Name = "label11";
			this.label11.Size = new Size(98, 15);
			this.label11.TabIndex = 33;
			this.label11.Text = "Board Mfr. Name";
			this.tb_BoardMfrName.Location = new Point(486, 78);
			this.tb_BoardMfrName.Margin = new Padding(3, 5, 3, 5);
			this.tb_BoardMfrName.Name = "tb_BoardMfrName";
			this.tb_BoardMfrName.Size = new Size(200, 23);
			this.tb_BoardMfrName.TabIndex = 34;
			base.Name = "Tab_FT_DUT";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000140 RID: 320
		private CTemp _tempInfo;

		// Token: 0x04000141 RID: 321
		private CFT_DUT _cFT_DUT;

		// Token: 0x04000142 RID: 322
		private IContainer components;

		// Token: 0x04000143 RID: 323
		private GroupBox groupBox1;

		// Token: 0x04000144 RID: 324
		private TextBox tb_Package;

		// Token: 0x04000145 RID: 325
		private Label label1;

		// Token: 0x04000146 RID: 326
		private Label label2;

		// Token: 0x04000147 RID: 327
		private TextBox tb_InstalledEquipModel;

		// Token: 0x04000148 RID: 328
		private Label label3;

		// Token: 0x04000149 RID: 329
		private TextBox tb_FreeProperty1;

		// Token: 0x0400014A RID: 330
		private TextBox tb_BoardSupplier;

		// Token: 0x0400014B RID: 331
		private Label label18;

		// Token: 0x0400014C RID: 332
		private TextBox tb_BoardMfrPartNo;

		// Token: 0x0400014D RID: 333
		private Label label17;

		// Token: 0x0400014E RID: 334
		private Label label9;

		// Token: 0x0400014F RID: 335
		private TextBox tb_FreeProperty2;

		// Token: 0x04000150 RID: 336
		private Label label10;

		// Token: 0x04000151 RID: 337
		private TextBox tb_FreeProperty3;

		// Token: 0x04000152 RID: 338
		private Label label11;

		// Token: 0x04000153 RID: 339
		private TextBox tb_BoardMfrName;
	}
}
