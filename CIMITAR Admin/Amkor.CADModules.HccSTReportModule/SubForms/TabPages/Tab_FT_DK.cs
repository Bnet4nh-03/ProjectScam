using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x02000012 RID: 18
	public class Tab_FT_DK : Tab_Base
	{
		// Token: 0x06000097 RID: 151 RVA: 0x00014C85 File Offset: 0x00012E85
		public Tab_FT_DK(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00014C9C File Offset: 0x00012E9C
		public void SetInfo(CTemp tempInfo, CFT_DK cFT_DK)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
			}
			if (cFT_DK != null && tempInfo != null)
			{
				this._cFT_DK = cFT_DK;
				this.tb_MfrName.Text = cFT_DK.strMfrName;
				this.tb_MfrPartNo.Text = cFT_DK.strMfrPartNo;
				this.tb_MfrSerialNo.Text = cFT_DK.strMfrSerialNo;
				this.tb_MfdYear.Text = cFT_DK.strMfdYear.ToString();
				this.tb_InstalledEquipModel.Text = cFT_DK.strInstalledEquipModel;
				this.tb_FreeProperty1.Text = cFT_DK.strFreeProperty1;
				this.tb_FreeProperty2.Text = cFT_DK.strFreeProperty2;
				this.tb_FreeProperty3.Text = cFT_DK.strFreeProperty3;
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00014D5C File Offset: 0x00012F5C
		public CFT_DK InputInfos()
		{
			CFT_DK cft_DK = new CFT_DK();
			if (cft_DK == null)
			{
				MessageBox.Show("No Info");
				return null;
			}
			cft_DK.strMfrName = this.tb_MfrName.Text;
			cft_DK.strMfrPartNo = this.tb_MfrPartNo.Text;
			cft_DK.strMfrSerialNo = this.tb_MfrSerialNo.Text;
			cft_DK.strMfdYear = this.tb_MfdYear.Text;
			cft_DK.strInstalledEquipModel = this.tb_InstalledEquipModel.Text;
			cft_DK.strFreeProperty1 = this.tb_FreeProperty1.Text;
			cft_DK.strFreeProperty2 = this.tb_FreeProperty2.Text;
			cft_DK.strFreeProperty3 = this.tb_FreeProperty3.Text;
			return cft_DK;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00014E08 File Offset: 0x00013008
		public void ClearItems()
		{
			this.tb_MfrName.Text = "";
			this.tb_MfrPartNo.Text = "";
			this.tb_MfrSerialNo.Text = "";
			this.tb_MfdYear.Text = "";
			this.tb_InstalledEquipModel.Text = "";
			this.tb_FreeProperty1.Text = "";
			this.tb_FreeProperty2.Text = "";
			this.tb_FreeProperty3.Text = "";
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00014E95 File Offset: 0x00013095
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00014EB4 File Offset: 0x000130B4
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.tb_MfrName = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.tb_MfrPartNo = new TextBox();
			this.label3 = new Label();
			this.tb_MfrSerialNo = new TextBox();
			this.tb_FreeProperty3 = new TextBox();
			this.label18 = new Label();
			this.tb_FreeProperty2 = new TextBox();
			this.label17 = new Label();
			this.label9 = new Label();
			this.tb_MfdYear = new TextBox();
			this.label10 = new Label();
			this.tb_InstalledEquipModel = new TextBox();
			this.label11 = new Label();
			this.tb_FreeProperty1 = new TextBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.groupBox1.Controls.Add(this.tb_MfrName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tb_MfrPartNo);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tb_MfrSerialNo);
			this.groupBox1.Controls.Add(this.tb_FreeProperty3);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.tb_FreeProperty2);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tb_MfdYear);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tb_InstalledEquipModel);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tb_FreeProperty1);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(1050, 248);
			this.groupBox1.TabIndex = 64;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input Fields";
			this.tb_MfrName.Location = new Point(139, 24);
			this.tb_MfrName.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfrName.Name = "tb_MfrName";
			this.tb_MfrName.Size = new Size(200, 23);
			this.tb_MfrName.TabIndex = 14;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(13, 27);
			this.label1.Name = "label1";
			this.label1.Size = new Size(64, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "Mfr. Name";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(13, 54);
			this.label2.Name = "label2";
			this.label2.Size = new Size(100, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Mfr. Part Number";
			this.tb_MfrPartNo.Location = new Point(139, 51);
			this.tb_MfrPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfrPartNo.Name = "tb_MfrPartNo";
			this.tb_MfrPartNo.Size = new Size(200, 23);
			this.tb_MfrPartNo.TabIndex = 16;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(13, 81);
			this.label3.Name = "label3";
			this.label3.Size = new Size(107, 15);
			this.label3.TabIndex = 17;
			this.label3.Text = "Mfr. Serial Number";
			this.tb_MfrSerialNo.Location = new Point(139, 78);
			this.tb_MfrSerialNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfrSerialNo.Name = "tb_MfrSerialNo";
			this.tb_MfrSerialNo.Size = new Size(200, 23);
			this.tb_MfrSerialNo.TabIndex = 18;
			this.tb_FreeProperty3.Location = new Point(836, 51);
			this.tb_FreeProperty3.Margin = new Padding(3, 5, 3, 5);
			this.tb_FreeProperty3.Name = "tb_FreeProperty3";
			this.tb_FreeProperty3.Size = new Size(200, 23);
			this.tb_FreeProperty3.TabIndex = 48;
			this.label18.AutoSize = true;
			this.label18.Location = new Point(710, 54);
			this.label18.Name = "label18";
			this.label18.Size = new Size(86, 15);
			this.label18.TabIndex = 47;
			this.label18.Text = "Free Property 3";
			this.tb_FreeProperty2.Location = new Point(836, 24);
			this.tb_FreeProperty2.Margin = new Padding(3, 5, 3, 5);
			this.tb_FreeProperty2.Name = "tb_FreeProperty2";
			this.tb_FreeProperty2.Size = new Size(200, 23);
			this.tb_FreeProperty2.TabIndex = 46;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(710, 27);
			this.label17.Name = "label17";
			this.label17.Size = new Size(86, 15);
			this.label17.TabIndex = 45;
			this.label17.Text = "Free Property 2";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(360, 27);
			this.label9.Name = "label9";
			this.label9.Size = new Size(57, 15);
			this.label9.TabIndex = 29;
			this.label9.Text = "Mfd. Year";
			this.tb_MfdYear.Location = new Point(486, 24);
			this.tb_MfdYear.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfdYear.Name = "tb_MfdYear";
			this.tb_MfdYear.Size = new Size(200, 23);
			this.tb_MfdYear.TabIndex = 30;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(360, 54);
			this.label10.Name = "label10";
			this.label10.Size = new Size(121, 15);
			this.label10.TabIndex = 31;
			this.label10.Text = "Installed Equip Model";
			this.tb_InstalledEquipModel.Location = new Point(486, 51);
			this.tb_InstalledEquipModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_InstalledEquipModel.Name = "tb_InstalledEquipModel";
			this.tb_InstalledEquipModel.Size = new Size(200, 23);
			this.tb_InstalledEquipModel.TabIndex = 32;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(360, 81);
			this.label11.Name = "label11";
			this.label11.Size = new Size(86, 15);
			this.label11.TabIndex = 33;
			this.label11.Text = "Free Property 1";
			this.tb_FreeProperty1.Location = new Point(486, 78);
			this.tb_FreeProperty1.Margin = new Padding(3, 5, 3, 5);
			this.tb_FreeProperty1.Name = "tb_FreeProperty1";
			this.tb_FreeProperty1.Size = new Size(200, 23);
			this.tb_FreeProperty1.TabIndex = 34;
			base.Name = "Tab_FT_DK";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400012C RID: 300
		private CTemp _tempInfo;

		// Token: 0x0400012D RID: 301
		private CFT_DK _cFT_DK;

		// Token: 0x0400012E RID: 302
		private IContainer components;

		// Token: 0x0400012F RID: 303
		private GroupBox groupBox1;

		// Token: 0x04000130 RID: 304
		private TextBox tb_MfrName;

		// Token: 0x04000131 RID: 305
		private Label label1;

		// Token: 0x04000132 RID: 306
		private Label label2;

		// Token: 0x04000133 RID: 307
		private TextBox tb_MfrPartNo;

		// Token: 0x04000134 RID: 308
		private Label label3;

		// Token: 0x04000135 RID: 309
		private TextBox tb_MfrSerialNo;

		// Token: 0x04000136 RID: 310
		private TextBox tb_FreeProperty3;

		// Token: 0x04000137 RID: 311
		private Label label18;

		// Token: 0x04000138 RID: 312
		private TextBox tb_FreeProperty2;

		// Token: 0x04000139 RID: 313
		private Label label17;

		// Token: 0x0400013A RID: 314
		private Label label9;

		// Token: 0x0400013B RID: 315
		private TextBox tb_MfdYear;

		// Token: 0x0400013C RID: 316
		private Label label10;

		// Token: 0x0400013D RID: 317
		private TextBox tb_InstalledEquipModel;

		// Token: 0x0400013E RID: 318
		private Label label11;

		// Token: 0x0400013F RID: 319
		private TextBox tb_FreeProperty1;
	}
}
