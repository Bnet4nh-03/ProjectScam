using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x02000010 RID: 16
	public class Tab_EWS_PT : Tab_Base
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00013552 File Offset: 0x00011752
		public Tab_EWS_PT(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00013568 File Offset: 0x00011768
		public void SetInfo(CTemp tempInfo, CEWS_PT cEWS_PT)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
			}
			if (cEWS_PT != null && tempInfo != null)
			{
				this._cEWS_PT = cEWS_PT;
				this.tb_MfrName.Text = cEWS_PT.strMfrName;
				this.tb_MfrPartNo.Text = cEWS_PT.strMfrPartNo;
				this.tb_MfrSerialNo.Text = cEWS_PT.strMfrSerialNo;
				this.tb_MfdYear.Text = cEWS_PT.strMfdYear.ToString();
				this.tb_PinCounter.Text = cEWS_PT.iPinCounter.ToString();
				this.tb_RfOptAvail.Text = cEWS_PT.strRfOptAvail;
				this.tb_CompTesterModel.Text = cEWS_PT.strCompTesterModel;
				this.tb_ColdTestOptAvail.Text = cEWS_PT.strColdTestOptAvail;
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0001362C File Offset: 0x0001182C
		public CEWS_PT InputInfos()
		{
			CEWS_PT cews_PT = new CEWS_PT();
			if (cews_PT == null)
			{
				MessageBox.Show("No Info");
				return null;
			}
			cews_PT.strMfrName = this.tb_MfrName.Text;
			cews_PT.strMfrPartNo = this.tb_MfrPartNo.Text;
			cews_PT.strMfrSerialNo = this.tb_MfrSerialNo.Text;
			cews_PT.strMfdYear = this.tb_MfdYear.Text;
			if (this.tb_PinCounter.Text != "")
			{
				if (!int.TryParse(this.tb_PinCounter.Text, out cews_PT.iPinCounter))
				{
					MessageBox.Show("Pin Counter must be Integer!");
					return null;
				}
			}
			else
			{
				cews_PT.iPinCounter = 0;
			}
			cews_PT.strRfOptAvail = this.tb_RfOptAvail.Text;
			cews_PT.strCompTesterModel = this.tb_CompTesterModel.Text;
			cews_PT.strColdTestOptAvail = this.tb_ColdTestOptAvail.Text;
			return cews_PT;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0001370C File Offset: 0x0001190C
		public void ClearItems()
		{
			this.tb_MfrName.Text = "";
			this.tb_MfrPartNo.Text = "";
			this.tb_MfrSerialNo.Text = "";
			this.tb_MfdYear.Text = "";
			this.tb_PinCounter.Text = "";
			this.tb_RfOptAvail.Text = "";
			this.tb_CompTesterModel.Text = "";
			this.tb_ColdTestOptAvail.Text = "";
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00013799 File Offset: 0x00011999
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000137B8 File Offset: 0x000119B8
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.tb_MfrName = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.tb_MfrPartNo = new TextBox();
			this.label3 = new Label();
			this.tb_MfrSerialNo = new TextBox();
			this.tb_ColdTestOptAvail = new TextBox();
			this.label18 = new Label();
			this.tb_CompTesterModel = new TextBox();
			this.label17 = new Label();
			this.label9 = new Label();
			this.tb_MfdYear = new TextBox();
			this.label10 = new Label();
			this.tb_PinCounter = new TextBox();
			this.label11 = new Label();
			this.tb_RfOptAvail = new TextBox();
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
			this.groupBox1.Controls.Add(this.tb_ColdTestOptAvail);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.tb_CompTesterModel);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tb_MfdYear);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tb_PinCounter);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tb_RfOptAvail);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(1050, 248);
			this.groupBox1.TabIndex = 62;
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
			this.tb_ColdTestOptAvail.Location = new Point(836, 51);
			this.tb_ColdTestOptAvail.Margin = new Padding(3, 5, 3, 5);
			this.tb_ColdTestOptAvail.Name = "tb_ColdTestOptAvail";
			this.tb_ColdTestOptAvail.Size = new Size(200, 23);
			this.tb_ColdTestOptAvail.TabIndex = 48;
			this.label18.AutoSize = true;
			this.label18.Location = new Point(710, 54);
			this.label18.Name = "label18";
			this.label18.Size = new Size(111, 15);
			this.label18.TabIndex = 47;
			this.label18.Text = "Cold Test Opt Avail.";
			this.tb_CompTesterModel.Location = new Point(836, 24);
			this.tb_CompTesterModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_CompTesterModel.Name = "tb_CompTesterModel";
			this.tb_CompTesterModel.Size = new Size(200, 23);
			this.tb_CompTesterModel.TabIndex = 46;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(710, 27);
			this.label17.Name = "label17";
			this.label17.Size = new Size(114, 15);
			this.label17.TabIndex = 45;
			this.label17.Text = "Comp. Tester Model";
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
			this.label10.Size = new Size(70, 15);
			this.label10.TabIndex = 31;
			this.label10.Text = "Pin Counter";
			this.tb_PinCounter.Location = new Point(486, 51);
			this.tb_PinCounter.Margin = new Padding(3, 5, 3, 5);
			this.tb_PinCounter.Name = "tb_PinCounter";
			this.tb_PinCounter.Size = new Size(200, 23);
			this.tb_PinCounter.TabIndex = 32;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(360, 81);
			this.label11.Name = "label11";
			this.label11.Size = new Size(75, 15);
			this.label11.TabIndex = 33;
			this.label11.Text = "RF Opt Avail.";
			this.tb_RfOptAvail.Location = new Point(486, 78);
			this.tb_RfOptAvail.Margin = new Padding(3, 5, 3, 5);
			this.tb_RfOptAvail.Name = "tb_RfOptAvail";
			this.tb_RfOptAvail.Size = new Size(200, 23);
			this.tb_RfOptAvail.TabIndex = 34;
			base.Name = "Tab_EWS_PT";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000108 RID: 264
		private CTemp _tempInfo;

		// Token: 0x04000109 RID: 265
		private CEWS_PT _cEWS_PT;

		// Token: 0x0400010A RID: 266
		private IContainer components;

		// Token: 0x0400010B RID: 267
		private GroupBox groupBox1;

		// Token: 0x0400010C RID: 268
		private TextBox tb_MfrName;

		// Token: 0x0400010D RID: 269
		private Label label1;

		// Token: 0x0400010E RID: 270
		private Label label2;

		// Token: 0x0400010F RID: 271
		private TextBox tb_MfrPartNo;

		// Token: 0x04000110 RID: 272
		private Label label3;

		// Token: 0x04000111 RID: 273
		private TextBox tb_MfrSerialNo;

		// Token: 0x04000112 RID: 274
		private TextBox tb_ColdTestOptAvail;

		// Token: 0x04000113 RID: 275
		private Label label18;

		// Token: 0x04000114 RID: 276
		private TextBox tb_CompTesterModel;

		// Token: 0x04000115 RID: 277
		private Label label17;

		// Token: 0x04000116 RID: 278
		private Label label9;

		// Token: 0x04000117 RID: 279
		private TextBox tb_MfdYear;

		// Token: 0x04000118 RID: 280
		private Label label10;

		// Token: 0x04000119 RID: 281
		private TextBox tb_PinCounter;

		// Token: 0x0400011A RID: 282
		private Label label11;

		// Token: 0x0400011B RID: 283
		private TextBox tb_RfOptAvail;
	}
}
