using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x02000014 RID: 20
	public class Tab_FT_HS : Tab_Base
	{
		// Token: 0x060000A4 RID: 164 RVA: 0x000163F2 File Offset: 0x000145F2
		public Tab_FT_HS(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00016408 File Offset: 0x00014608
		public void SetInfo(CTemp tempInfo, CFT_HS cFT_HS)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
				this.tb_Package.Text = tempInfo.strPackage;
				this.tb_TesterModel.Text = tempInfo.strEquipModel;
			}
			if (cFT_HS != null && tempInfo != null)
			{
				this._cFT_HS = cFT_HS;
				this.tb_TesterModel.Text = cFT_HS.strTesterModel;
				if (tempInfo.strEquipModel != cFT_HS.strTesterModel)
				{
					this.tb_TesterModel.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_HandSetMfrPartNo.Text = cFT_HS.strHandSetMfrPartNo;
				this.tb_Package.Text = cFT_HS.strPackage;
				if (tempInfo.strPackage != cFT_HS.strPackage)
				{
					this.tb_Package.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_HandSetMfrName.Text = cFT_HS.strHandSetMfrName;
				this.tb_HandSetPartNo.Text = cFT_HS.strHandSetPartNo;
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00016514 File Offset: 0x00014714
		public CFT_HS InputInfos()
		{
			CFT_HS cft_HS = new CFT_HS();
			if (cft_HS == null)
			{
				MessageBox.Show("No Info");
				return null;
			}
			cft_HS.strTesterModel = this.tb_TesterModel.Text;
			cft_HS.strHandSetMfrPartNo = this.tb_HandSetMfrPartNo.Text;
			cft_HS.strPackage = this.tb_Package.Text;
			cft_HS.strHandSetMfrName = this.tb_HandSetMfrName.Text;
			cft_HS.strHandSetPartNo = this.tb_HandSetPartNo.Text;
			return cft_HS;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00016590 File Offset: 0x00014790
		public void ClearItems()
		{
			this.tb_TesterModel.Text = "";
			this.tb_HandSetMfrPartNo.Text = "";
			this.tb_Package.Text = "";
			this.tb_HandSetMfrName.Text = "";
			this.tb_HandSetPartNo.Text = "";
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000165F0 File Offset: 0x000147F0
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

		// Token: 0x060000A9 RID: 169 RVA: 0x00016690 File Offset: 0x00014890
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

		// Token: 0x060000AA RID: 170 RVA: 0x0001672D File Offset: 0x0001492D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0001674C File Offset: 0x0001494C
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.tb_TesterModel = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.tb_HandSetPartNo = new TextBox();
			this.tb_HandSetMfrPartNo = new TextBox();
			this.label17 = new Label();
			this.label9 = new Label();
			this.tb_Package = new TextBox();
			this.label10 = new Label();
			this.tb_HandSetMfrName = new TextBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.groupBox1.Controls.Add(this.tb_TesterModel);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tb_HandSetPartNo);
			this.groupBox1.Controls.Add(this.tb_HandSetMfrPartNo);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tb_Package);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tb_HandSetMfrName);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(1050, 248);
			this.groupBox1.TabIndex = 63;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input Fields";
			this.tb_TesterModel.Location = new Point(139, 24);
			this.tb_TesterModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_TesterModel.Name = "tb_TesterModel";
			this.tb_TesterModel.Size = new Size(200, 23);
			this.tb_TesterModel.TabIndex = 14;
			this.tb_TesterModel.MouseDoubleClick += this.tb_TesterModel_MouseDoubleClick;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(13, 27);
			this.label1.Name = "label1";
			this.label1.Size = new Size(75, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "Tester Model";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(13, 54);
			this.label2.Name = "label2";
			this.label2.Size = new Size(126, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Hand Set Part Number";
			this.tb_HandSetPartNo.Location = new Point(139, 51);
			this.tb_HandSetPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_HandSetPartNo.Name = "tb_HandSetPartNo";
			this.tb_HandSetPartNo.Size = new Size(200, 23);
			this.tb_HandSetPartNo.TabIndex = 16;
			this.tb_HandSetMfrPartNo.Location = new Point(836, 24);
			this.tb_HandSetMfrPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_HandSetMfrPartNo.Name = "tb_HandSetMfrPartNo";
			this.tb_HandSetMfrPartNo.Size = new Size(200, 23);
			this.tb_HandSetMfrPartNo.TabIndex = 46;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(710, 27);
			this.label17.Name = "label17";
			this.label17.Size = new Size(126, 15);
			this.label17.TabIndex = 45;
			this.label17.Text = "Hand Set Mfr. Part No.";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(360, 27);
			this.label9.Name = "label9";
			this.label9.Size = new Size(51, 15);
			this.label9.TabIndex = 29;
			this.label9.Text = "Package";
			this.tb_Package.Location = new Point(486, 24);
			this.tb_Package.Margin = new Padding(3, 5, 3, 5);
			this.tb_Package.Name = "tb_Package";
			this.tb_Package.Size = new Size(200, 23);
			this.tb_Package.TabIndex = 30;
			this.tb_Package.MouseDoubleClick += this.tb_Package_MouseDoubleClick;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(360, 54);
			this.label10.Name = "label10";
			this.label10.Size = new Size(115, 15);
			this.label10.TabIndex = 31;
			this.label10.Text = "Hand Set Mfr. Name";
			this.tb_HandSetMfrName.Location = new Point(486, 51);
			this.tb_HandSetMfrName.Margin = new Padding(3, 5, 3, 5);
			this.tb_HandSetMfrName.Name = "tb_HandSetMfrName";
			this.tb_HandSetMfrName.Size = new Size(200, 23);
			this.tb_HandSetMfrName.TabIndex = 32;
			base.Name = "Tab_FT_HS";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000154 RID: 340
		private CTemp _tempInfo;

		// Token: 0x04000155 RID: 341
		private CFT_HS _cFT_HS;

		// Token: 0x04000156 RID: 342
		private IContainer components;

		// Token: 0x04000157 RID: 343
		private GroupBox groupBox1;

		// Token: 0x04000158 RID: 344
		private TextBox tb_TesterModel;

		// Token: 0x04000159 RID: 345
		private Label label1;

		// Token: 0x0400015A RID: 346
		private Label label2;

		// Token: 0x0400015B RID: 347
		private TextBox tb_HandSetPartNo;

		// Token: 0x0400015C RID: 348
		private TextBox tb_HandSetMfrPartNo;

		// Token: 0x0400015D RID: 349
		private Label label17;

		// Token: 0x0400015E RID: 350
		private Label label9;

		// Token: 0x0400015F RID: 351
		private TextBox tb_Package;

		// Token: 0x04000160 RID: 352
		private Label label10;

		// Token: 0x04000161 RID: 353
		private TextBox tb_HandSetMfrName;
	}
}
