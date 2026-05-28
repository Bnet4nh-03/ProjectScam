using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x02000017 RID: 23
	public class Tab_FT_SK : Tab_Base
	{
		// Token: 0x060000BC RID: 188 RVA: 0x00018BA2 File Offset: 0x00016DA2
		public Tab_FT_SK(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00018BB8 File Offset: 0x00016DB8
		public void SetInfo(CTemp tempInfo, CFT_SK cFT_SK)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
				this.tb_Package.Text = tempInfo.strPackage;
				this.tb_HdlModel.Text = tempInfo.strEquipModel;
			}
			if (cFT_SK != null && tempInfo != null)
			{
				this._cFT_SK = cFT_SK;
				this.tb_SockPartNo.Text = cFT_SK.strSockPartNo;
				this.tb_Package.Text = cFT_SK.strPackage;
				if (tempInfo.strPackage != cFT_SK.strPackage)
				{
					this.tb_Package.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_CapableTemp.Text = cFT_SK.strCapableTemp;
				this.tb_PinInsert.Text = cFT_SK.iPinInsert.ToString();
				this.tb_PinLifespan.Text = cFT_SK.iPinLifeSpan.ToString();
				this.tb_SockHousinInsert.Text = cFT_SK.iSockHousinInsert.ToString();
				this.tb_SockHousinLifespan.Text = cFT_SK.iSockHousinLifespan.ToString();
				this.tb_SockMfrName.Text = cFT_SK.strSockMfrName;
				this.tb_SockMfrPartNo.Text = cFT_SK.strSockMfrPartNo;
				this.tb_PinMfr.Text = cFT_SK.strPinMfr;
				this.tb_PinPartNo.Text = cFT_SK.strPinPartNo;
				this.tb_HdlModel.Text = cFT_SK.strHdlModel;
				if (tempInfo.strEquipModel != cFT_SK.strHdlModel)
				{
					this.tb_HdlModel.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_TesterModel.Text = cFT_SK.strTesterModel;
				this.tb_SkSupplier.Text = cFT_SK.strSkSupplier;
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00018D70 File Offset: 0x00016F70
		public CFT_SK InputInfos()
		{
			CFT_SK cft_SK = new CFT_SK();
			if (cft_SK == null)
			{
				MessageBox.Show("No Info");
				return null;
			}
			cft_SK.strSockPartNo = this.tb_SockPartNo.Text;
			cft_SK.strPackage = this.tb_Package.Text;
			cft_SK.strCapableTemp = this.tb_CapableTemp.Text;
			if (this.tb_PinInsert.Text != "")
			{
				if (!int.TryParse(this.tb_PinInsert.Text, out cft_SK.iPinInsert))
				{
					MessageBox.Show("Pin Insertion must be Integer!");
					return null;
				}
			}
			else
			{
				cft_SK.iPinInsert = 0;
			}
			if (this.tb_PinLifespan.Text != "")
			{
				if (!int.TryParse(this.tb_PinLifespan.Text, out cft_SK.iPinLifeSpan))
				{
					MessageBox.Show("Pin Liftspan must be Integer!");
					return null;
				}
			}
			else
			{
				cft_SK.iPinLifeSpan = 0;
			}
			if (this.tb_SockHousinInsert.Text != "")
			{
				if (!int.TryParse(this.tb_SockHousinInsert.Text, out cft_SK.iSockHousinInsert))
				{
					MessageBox.Show("Sock Housin' Insertion must be Integer!");
					return null;
				}
			}
			else
			{
				cft_SK.iSockHousinInsert = 0;
			}
			if (this.tb_SockHousinLifespan.Text != "")
			{
				if (!int.TryParse(this.tb_SockHousinLifespan.Text, out cft_SK.iSockHousinLifespan))
				{
					MessageBox.Show("Sock Housin' Lifespan must be Integer!");
					return null;
				}
			}
			else
			{
				cft_SK.iSockHousinLifespan = 0;
			}
			cft_SK.strSockMfrName = this.tb_SockMfrName.Text;
			cft_SK.strSockMfrPartNo = this.tb_SockMfrPartNo.Text;
			cft_SK.strPinMfr = this.tb_PinMfr.Text;
			cft_SK.strPinPartNo = this.tb_PinPartNo.Text;
			cft_SK.strHdlModel = this.tb_HdlModel.Text;
			cft_SK.strTesterModel = this.tb_TesterModel.Text;
			cft_SK.strSkSupplier = this.tb_SkSupplier.Text;
			return cft_SK;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00018F4C File Offset: 0x0001714C
		public void ClearItems()
		{
			this.tb_SockPartNo.Text = "";
			this.tb_Package.Text = "";
			this.tb_CapableTemp.Text = "";
			this.tb_PinInsert.Text = "";
			this.tb_PinLifespan.Text = "";
			this.tb_SockHousinInsert.Text = "";
			this.tb_SockHousinLifespan.Text = "";
			this.tb_SockMfrName.Text = "";
			this.tb_SockMfrPartNo.Text = "";
			this.tb_PinMfr.Text = "";
			this.tb_PinPartNo.Text = "";
			this.tb_HdlModel.Text = "";
			this.tb_TesterModel.Text = "";
			this.tb_SkSupplier.Text = "";
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0001903C File Offset: 0x0001723C
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

		// Token: 0x060000C1 RID: 193 RVA: 0x000190DC File Offset: 0x000172DC
		private void tb_HdlModel_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._tempInfo.strEquipModel != this.tb_HdlModel.Text && MessageBox.Show(string.Concat(new string[]
			{
				"Information is Different\nHCC: ",
				this._tempInfo.strEquipModel,
				"\nTHIS: ",
				this.tb_HdlModel.Text,
				"\nDo you want to change info from HCC?"
			}), "Different Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.tb_HdlModel.Text = this._tempInfo.strEquipModel;
				this.tb_HdlModel.BackColor = Color.White;
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00019179 File Offset: 0x00017379
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00019198 File Offset: 0x00017398
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.tb_SockPartNo = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.tb_Package = new TextBox();
			this.label3 = new Label();
			this.tb_CapableTemp = new TextBox();
			this.label4 = new Label();
			this.tb_PinInsert = new TextBox();
			this.label5 = new Label();
			this.tb_SkSupplier = new TextBox();
			this.tb_PinLifespan = new TextBox();
			this.label20 = new Label();
			this.tb_TesterModel = new TextBox();
			this.label19 = new Label();
			this.tb_HdlModel = new TextBox();
			this.label18 = new Label();
			this.tb_PinPartNo = new TextBox();
			this.label17 = new Label();
			this.label9 = new Label();
			this.tb_SockHousinInsert = new TextBox();
			this.label10 = new Label();
			this.tb_SockHousinLifespan = new TextBox();
			this.label11 = new Label();
			this.tb_SockMfrName = new TextBox();
			this.label12 = new Label();
			this.tb_PinMfr = new TextBox();
			this.tb_SockMfrPartNo = new TextBox();
			this.label13 = new Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.groupBox1.Controls.Add(this.tb_SockPartNo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tb_Package);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tb_CapableTemp);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tb_PinInsert);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.tb_SkSupplier);
			this.groupBox1.Controls.Add(this.tb_PinLifespan);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.tb_TesterModel);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.tb_HdlModel);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.tb_PinPartNo);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tb_SockHousinInsert);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tb_SockHousinLifespan);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tb_SockMfrName);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.tb_PinMfr);
			this.groupBox1.Controls.Add(this.tb_SockMfrPartNo);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(1050, 248);
			this.groupBox1.TabIndex = 62;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input Fields";
			this.tb_SockPartNo.Location = new Point(139, 24);
			this.tb_SockPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_SockPartNo.Name = "tb_SockPartNo";
			this.tb_SockPartNo.Size = new Size(200, 23);
			this.tb_SockPartNo.TabIndex = 14;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(13, 27);
			this.label1.Name = "label1";
			this.label1.Size = new Size(113, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "Socket Part Number";
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
			this.label3.AutoSize = true;
			this.label3.Location = new Point(13, 81);
			this.label3.Name = "label3";
			this.label3.Size = new Size(120, 15);
			this.label3.TabIndex = 17;
			this.label3.Text = "Capable Temperature";
			this.tb_CapableTemp.Location = new Point(139, 78);
			this.tb_CapableTemp.Margin = new Padding(3, 5, 3, 5);
			this.tb_CapableTemp.Name = "tb_CapableTemp";
			this.tb_CapableTemp.Size = new Size(200, 23);
			this.tb_CapableTemp.TabIndex = 18;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(13, 108);
			this.label4.Name = "label4";
			this.label4.Size = new Size(73, 15);
			this.label4.TabIndex = 19;
			this.label4.Text = "Pin Insertion";
			this.tb_PinInsert.Location = new Point(139, 105);
			this.tb_PinInsert.Margin = new Padding(3, 5, 3, 5);
			this.tb_PinInsert.Name = "tb_PinInsert";
			this.tb_PinInsert.Size = new Size(200, 23);
			this.tb_PinInsert.TabIndex = 20;
			this.label5.AutoSize = true;
			this.label5.Location = new Point(13, 135);
			this.label5.Name = "label5";
			this.label5.Size = new Size(71, 15);
			this.label5.TabIndex = 21;
			this.label5.Text = "Pin Lifespan";
			this.tb_SkSupplier.Location = new Point(836, 105);
			this.tb_SkSupplier.Margin = new Padding(3, 5, 3, 5);
			this.tb_SkSupplier.Name = "tb_SkSupplier";
			this.tb_SkSupplier.Size = new Size(200, 23);
			this.tb_SkSupplier.TabIndex = 52;
			this.tb_PinLifespan.Location = new Point(139, 132);
			this.tb_PinLifespan.Margin = new Padding(3, 5, 3, 5);
			this.tb_PinLifespan.Name = "tb_PinLifespan";
			this.tb_PinLifespan.Size = new Size(200, 23);
			this.tb_PinLifespan.TabIndex = 22;
			this.label20.AutoSize = true;
			this.label20.Location = new Point(710, 108);
			this.label20.Name = "label20";
			this.label20.Size = new Size(66, 15);
			this.label20.TabIndex = 51;
			this.label20.Text = "SK Supplier";
			this.tb_TesterModel.Location = new Point(836, 78);
			this.tb_TesterModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_TesterModel.Name = "tb_TesterModel";
			this.tb_TesterModel.Size = new Size(200, 23);
			this.tb_TesterModel.TabIndex = 50;
			this.label19.AutoSize = true;
			this.label19.Location = new Point(710, 81);
			this.label19.Name = "label19";
			this.label19.Size = new Size(75, 15);
			this.label19.TabIndex = 49;
			this.label19.Text = "Tester Model";
			this.tb_HdlModel.Location = new Point(836, 51);
			this.tb_HdlModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_HdlModel.Name = "tb_HdlModel";
			this.tb_HdlModel.Size = new Size(200, 23);
			this.tb_HdlModel.TabIndex = 48;
			this.tb_HdlModel.MouseDoubleClick += this.tb_HdlModel_MouseDoubleClick;
			this.label18.AutoSize = true;
			this.label18.Location = new Point(710, 54);
			this.label18.Name = "label18";
			this.label18.Size = new Size(86, 15);
			this.label18.TabIndex = 47;
			this.label18.Text = "Handler Model";
			this.tb_PinPartNo.Location = new Point(836, 24);
			this.tb_PinPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_PinPartNo.Name = "tb_PinPartNo";
			this.tb_PinPartNo.Size = new Size(200, 23);
			this.tb_PinPartNo.TabIndex = 46;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(710, 27);
			this.label17.Name = "label17";
			this.label17.Size = new Size(95, 15);
			this.label17.TabIndex = 45;
			this.label17.Text = "Pin Part Number";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(360, 27);
			this.label9.Name = "label9";
			this.label9.Size = new Size(111, 15);
			this.label9.TabIndex = 29;
			this.label9.Text = "Sock Housin' Insert.";
			this.tb_SockHousinInsert.Location = new Point(486, 24);
			this.tb_SockHousinInsert.Margin = new Padding(3, 5, 3, 5);
			this.tb_SockHousinInsert.Name = "tb_SockHousinInsert";
			this.tb_SockHousinInsert.Size = new Size(200, 23);
			this.tb_SockHousinInsert.TabIndex = 30;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(360, 54);
			this.label10.Name = "label10";
			this.label10.Size = new Size(118, 15);
			this.label10.TabIndex = 31;
			this.label10.Text = "Sock Housin' Lifepan";
			this.tb_SockHousinLifespan.Location = new Point(486, 51);
			this.tb_SockHousinLifespan.Margin = new Padding(3, 5, 3, 5);
			this.tb_SockHousinLifespan.Name = "tb_SockHousinLifespan";
			this.tb_SockHousinLifespan.Size = new Size(200, 23);
			this.tb_SockHousinLifespan.TabIndex = 32;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(360, 81);
			this.label11.Name = "label11";
			this.label11.Size = new Size(92, 15);
			this.label11.TabIndex = 33;
			this.label11.Text = "Sock Mfr. Name";
			this.tb_SockMfrName.Location = new Point(486, 78);
			this.tb_SockMfrName.Margin = new Padding(3, 5, 3, 5);
			this.tb_SockMfrName.Name = "tb_SockMfrName";
			this.tb_SockMfrName.Size = new Size(200, 23);
			this.tb_SockMfrName.TabIndex = 34;
			this.label12.AutoSize = true;
			this.label12.Location = new Point(360, 108);
			this.label12.Name = "label12";
			this.label12.Size = new Size(103, 15);
			this.label12.TabIndex = 35;
			this.label12.Text = "Sock Mfr. Part No.";
			this.tb_PinMfr.Location = new Point(486, 132);
			this.tb_PinMfr.Margin = new Padding(3, 5, 3, 5);
			this.tb_PinMfr.Name = "tb_PinMfr";
			this.tb_PinMfr.Size = new Size(200, 23);
			this.tb_PinMfr.TabIndex = 38;
			this.tb_SockMfrPartNo.Location = new Point(486, 105);
			this.tb_SockMfrPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_SockMfrPartNo.Name = "tb_SockMfrPartNo";
			this.tb_SockMfrPartNo.Size = new Size(200, 23);
			this.tb_SockMfrPartNo.TabIndex = 36;
			this.label13.AutoSize = true;
			this.label13.Location = new Point(360, 135);
			this.label13.Name = "label13";
			this.label13.Size = new Size(99, 15);
			this.label13.TabIndex = 37;
			this.label13.Text = "Pin Manufacturer";
			base.Name = "Tab_FT_SK";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000190 RID: 400
		private CTemp _tempInfo;

		// Token: 0x04000191 RID: 401
		private CFT_SK _cFT_SK;

		// Token: 0x04000192 RID: 402
		private IContainer components;

		// Token: 0x04000193 RID: 403
		private GroupBox groupBox1;

		// Token: 0x04000194 RID: 404
		private TextBox tb_SockPartNo;

		// Token: 0x04000195 RID: 405
		private Label label1;

		// Token: 0x04000196 RID: 406
		private Label label2;

		// Token: 0x04000197 RID: 407
		private TextBox tb_Package;

		// Token: 0x04000198 RID: 408
		private Label label3;

		// Token: 0x04000199 RID: 409
		private TextBox tb_CapableTemp;

		// Token: 0x0400019A RID: 410
		private Label label4;

		// Token: 0x0400019B RID: 411
		private TextBox tb_PinInsert;

		// Token: 0x0400019C RID: 412
		private Label label5;

		// Token: 0x0400019D RID: 413
		private TextBox tb_SkSupplier;

		// Token: 0x0400019E RID: 414
		private TextBox tb_PinLifespan;

		// Token: 0x0400019F RID: 415
		private Label label20;

		// Token: 0x040001A0 RID: 416
		private TextBox tb_TesterModel;

		// Token: 0x040001A1 RID: 417
		private Label label19;

		// Token: 0x040001A2 RID: 418
		private TextBox tb_HdlModel;

		// Token: 0x040001A3 RID: 419
		private Label label18;

		// Token: 0x040001A4 RID: 420
		private TextBox tb_PinPartNo;

		// Token: 0x040001A5 RID: 421
		private Label label17;

		// Token: 0x040001A6 RID: 422
		private Label label9;

		// Token: 0x040001A7 RID: 423
		private TextBox tb_SockHousinInsert;

		// Token: 0x040001A8 RID: 424
		private Label label10;

		// Token: 0x040001A9 RID: 425
		private TextBox tb_SockHousinLifespan;

		// Token: 0x040001AA RID: 426
		private Label label11;

		// Token: 0x040001AB RID: 427
		private TextBox tb_SockMfrName;

		// Token: 0x040001AC RID: 428
		private Label label12;

		// Token: 0x040001AD RID: 429
		private TextBox tb_PinMfr;

		// Token: 0x040001AE RID: 430
		private TextBox tb_SockMfrPartNo;

		// Token: 0x040001AF RID: 431
		private Label label13;
	}
}
