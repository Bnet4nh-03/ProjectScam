using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x0200000D RID: 13
	public class Tab_EWS_KIT : Tab_Base
	{
		// Token: 0x06000071 RID: 113 RVA: 0x0000FB55 File Offset: 0x0000DD55
		public Tab_EWS_KIT(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000FB6C File Offset: 0x0000DD6C
		public void SetInfo(CTemp tempInfo, CEWS_KIT cEWS_KIT)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
			}
			if (cEWS_KIT != null && tempInfo != null)
			{
				this._cEWS_KIT = cEWS_KIT;
				this.tb_MfrName.Text = cEWS_KIT.strMfrName;
				this.tb_MfrPartNo.Text = cEWS_KIT.strMfrPartNo;
				this.tb_MfrSerialNo.Text = cEWS_KIT.strMfrSerialNo;
				this.tb_MfdYear.Text = cEWS_KIT.strMfdYear.ToString();
				this.tb_InstalledEquipModel.Text = cEWS_KIT.strInstalledEquipModel;
				this.tb_FreeProperty1.Text = cEWS_KIT.strFreeProperty1;
				this.tb_FreeProperty2.Text = cEWS_KIT.strFreeProperty2;
				this.tb_FreeProperty3.Text = cEWS_KIT.strFreeProperty3;
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000FC2C File Offset: 0x0000DE2C
		public CEWS_KIT InputInfos()
		{
			CEWS_KIT cews_KIT = new CEWS_KIT();
			if (cews_KIT == null)
			{
				MessageBox.Show("No Info");
				return null;
			}
			cews_KIT.strMfrName = this.tb_MfrName.Text;
			cews_KIT.strMfrPartNo = this.tb_MfrPartNo.Text;
			cews_KIT.strMfrSerialNo = this.tb_MfrSerialNo.Text;
			cews_KIT.strMfdYear = this.tb_MfdYear.Text;
			cews_KIT.strInstalledEquipModel = this.tb_InstalledEquipModel.Text;
			cews_KIT.strFreeProperty1 = this.tb_FreeProperty1.Text;
			cews_KIT.strFreeProperty2 = this.tb_FreeProperty2.Text;
			cews_KIT.strFreeProperty3 = this.tb_FreeProperty3.Text;
			return cews_KIT;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000FCD8 File Offset: 0x0000DED8
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

		// Token: 0x06000075 RID: 117 RVA: 0x0000FD65 File Offset: 0x0000DF65
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000FD84 File Offset: 0x0000DF84
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
			this.groupBox1.TabIndex = 63;
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
			base.Name = "Tab_EWS_KIT";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040000B0 RID: 176
		private CTemp _tempInfo;

		// Token: 0x040000B1 RID: 177
		private CEWS_KIT _cEWS_KIT;

		// Token: 0x040000B2 RID: 178
		private IContainer components;

		// Token: 0x040000B3 RID: 179
		private GroupBox groupBox1;

		// Token: 0x040000B4 RID: 180
		private TextBox tb_MfrName;

		// Token: 0x040000B5 RID: 181
		private Label label1;

		// Token: 0x040000B6 RID: 182
		private Label label2;

		// Token: 0x040000B7 RID: 183
		private TextBox tb_MfrPartNo;

		// Token: 0x040000B8 RID: 184
		private Label label3;

		// Token: 0x040000B9 RID: 185
		private TextBox tb_MfrSerialNo;

		// Token: 0x040000BA RID: 186
		private TextBox tb_FreeProperty3;

		// Token: 0x040000BB RID: 187
		private Label label18;

		// Token: 0x040000BC RID: 188
		private TextBox tb_FreeProperty2;

		// Token: 0x040000BD RID: 189
		private Label label17;

		// Token: 0x040000BE RID: 190
		private Label label9;

		// Token: 0x040000BF RID: 191
		private TextBox tb_MfdYear;

		// Token: 0x040000C0 RID: 192
		private Label label10;

		// Token: 0x040000C1 RID: 193
		private TextBox tb_InstalledEquipModel;

		// Token: 0x040000C2 RID: 194
		private Label label11;

		// Token: 0x040000C3 RID: 195
		private TextBox tb_FreeProperty1;
	}
}
