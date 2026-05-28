using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x0200000C RID: 12
	public class Tab_EQ : Tab_Base
	{
		// Token: 0x0600006B RID: 107 RVA: 0x0000ED8D File Offset: 0x0000CF8D
		public Tab_EQ(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000EDA4 File Offset: 0x0000CFA4
		public void SetInfo(CTemp tempInfo, CEQ cEQ)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
			}
			if (cEQ != null && tempInfo != null)
			{
				this._cEQ = cEQ;
				this.tb_Activity.Text = this._cEQ.strActivity;
				this.tb_EquipmentType.Text = this._cEQ.strEquipmentType;
				this.tb_StGroup.Text = this._cEQ.strStGroup;
				this.tb_MfgBrand.Text = this._cEQ.strMfgBrand;
				this.tb_Model.Text = this._cEQ.strModel;
				this.tb_SerialNumber.Text = this._cEQ.strSerialNo;
				this.dtPicker_MfgYear.Value = this._cEQ.dtMfgYear;
				this.tb_LocAreaDescr.Text = this._cEQ.strLocAreaDescr;
				this.dtPicker_ConsignmentDate.Value = this._cEQ.dtConsignmentDate;
				this.tb_PackageDescr.Text = this._cEQ.strPackageDescr;
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000EEB0 File Offset: 0x0000D0B0
		public CEQ InputInfos()
		{
			CEQ ceq = new CEQ();
			if (ceq == null)
			{
				MessageBox.Show("No Info");
				return null;
			}
			ceq.strActivity = this.tb_Activity.Text;
			ceq.strEquipmentType = this.tb_EquipmentType.Text;
			ceq.strStGroup = this.tb_StGroup.Text;
			ceq.strMfgBrand = this.tb_MfgBrand.Text;
			ceq.strModel = this.tb_Model.Text;
			ceq.strSerialNo = this.tb_SerialNumber.Text;
			ceq.dtMfgYear = this.dtPicker_MfgYear.Value;
			ceq.strLocAreaDescr = this.tb_LocAreaDescr.Text;
			ceq.dtConsignmentDate = this.dtPicker_ConsignmentDate.Value;
			ceq.strPackageDescr = this.tb_PackageDescr.Text;
			return ceq;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000EF80 File Offset: 0x0000D180
		public void ClearItems()
		{
			this.tb_Activity.Text = "";
			this.tb_EquipmentType.Text = "";
			this.tb_StGroup.Text = "";
			this.tb_MfgBrand.Text = "";
			this.tb_Model.Text = "";
			this.tb_SerialNumber.Text = "";
			this.dtPicker_MfgYear.Value = DateTime.Now;
			this.tb_LocAreaDescr.Text = "";
			this.dtPicker_ConsignmentDate.Value = DateTime.Now;
			this.tb_PackageDescr.Text = "";
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000F02D File Offset: 0x0000D22D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000F04C File Offset: 0x0000D24C
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.dtPicker_MfgYear = new DateTimePicker();
			this.dtPicker_ConsignmentDate = new DateTimePicker();
			this.label6 = new Label();
			this.label5 = new Label();
			this.tb_MfgBrand = new TextBox();
			this.tb_Activity = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.tb_EquipmentType = new TextBox();
			this.label3 = new Label();
			this.tb_StGroup = new TextBox();
			this.tb_PackageDescr = new TextBox();
			this.label19 = new Label();
			this.label18 = new Label();
			this.tb_LocAreaDescr = new TextBox();
			this.label17 = new Label();
			this.label10 = new Label();
			this.tb_Model = new TextBox();
			this.label11 = new Label();
			this.tb_SerialNumber = new TextBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.groupBox1.Controls.Add(this.dtPicker_MfgYear);
			this.groupBox1.Controls.Add(this.dtPicker_ConsignmentDate);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.tb_MfgBrand);
			this.groupBox1.Controls.Add(this.tb_Activity);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tb_EquipmentType);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tb_StGroup);
			this.groupBox1.Controls.Add(this.tb_PackageDescr);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.tb_LocAreaDescr);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tb_Model);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tb_SerialNumber);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(1050, 248);
			this.groupBox1.TabIndex = 62;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input Fields";
			this.dtPicker_MfgYear.Format = DateTimePickerFormat.Custom;
			this.dtPicker_MfgYear.Location = new Point(486, 105);
			this.dtPicker_MfgYear.Name = "dtPicker_MfgYear";
			this.dtPicker_MfgYear.Size = new Size(200, 23);
			this.dtPicker_MfgYear.TabIndex = 59;
			this.dtPicker_ConsignmentDate.Format = DateTimePickerFormat.Custom;
			this.dtPicker_ConsignmentDate.Location = new Point(836, 51);
			this.dtPicker_ConsignmentDate.Name = "dtPicker_ConsignmentDate";
			this.dtPicker_ConsignmentDate.Size = new Size(200, 23);
			this.dtPicker_ConsignmentDate.TabIndex = 58;
			this.label6.AutoSize = true;
			this.label6.Location = new Point(360, 108);
			this.label6.Name = "label6";
			this.label6.Size = new Size(107, 15);
			this.label6.TabIndex = 54;
			this.label6.Text = "Manufactured Year";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(360, 27);
			this.label5.Name = "label5";
			this.label5.Size = new Size(113, 15);
			this.label5.TabIndex = 52;
			this.label5.Text = "Manufacturer Brand";
			this.tb_MfgBrand.Location = new Point(486, 24);
			this.tb_MfgBrand.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfgBrand.Name = "tb_MfgBrand";
			this.tb_MfgBrand.Size = new Size(200, 23);
			this.tb_MfgBrand.TabIndex = 30;
			this.tb_Activity.Location = new Point(139, 24);
			this.tb_Activity.Margin = new Padding(3, 5, 3, 5);
			this.tb_Activity.Name = "tb_Activity";
			this.tb_Activity.Size = new Size(200, 23);
			this.tb_Activity.TabIndex = 14;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(13, 27);
			this.label1.Name = "label1";
			this.label1.Size = new Size(47, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "Activity";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(13, 54);
			this.label2.Name = "label2";
			this.label2.Size = new Size(93, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Equipment Type";
			this.tb_EquipmentType.Location = new Point(139, 51);
			this.tb_EquipmentType.Margin = new Padding(3, 5, 3, 5);
			this.tb_EquipmentType.Name = "tb_EquipmentType";
			this.tb_EquipmentType.Size = new Size(200, 23);
			this.tb_EquipmentType.TabIndex = 16;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(13, 81);
			this.label3.Name = "label3";
			this.label3.Size = new Size(56, 15);
			this.label3.TabIndex = 17;
			this.label3.Text = "ST Group";
			this.tb_StGroup.Location = new Point(139, 78);
			this.tb_StGroup.Margin = new Padding(3, 5, 3, 5);
			this.tb_StGroup.Name = "tb_StGroup";
			this.tb_StGroup.Size = new Size(200, 23);
			this.tb_StGroup.TabIndex = 18;
			this.tb_PackageDescr.Location = new Point(836, 78);
			this.tb_PackageDescr.Margin = new Padding(3, 5, 3, 5);
			this.tb_PackageDescr.Name = "tb_PackageDescr";
			this.tb_PackageDescr.Size = new Size(200, 23);
			this.tb_PackageDescr.TabIndex = 50;
			this.label19.AutoSize = true;
			this.label19.Location = new Point(710, 81);
			this.label19.Name = "label19";
			this.label19.Size = new Size(83, 15);
			this.label19.TabIndex = 49;
			this.label19.Text = "Package Descr";
			this.label18.AutoSize = true;
			this.label18.Location = new Point(710, 54);
			this.label18.Name = "label18";
			this.label18.Size = new Size(106, 15);
			this.label18.TabIndex = 47;
			this.label18.Text = "Consignment Date";
			this.tb_LocAreaDescr.Location = new Point(836, 24);
			this.tb_LocAreaDescr.Margin = new Padding(3, 5, 3, 5);
			this.tb_LocAreaDescr.Name = "tb_LocAreaDescr";
			this.tb_LocAreaDescr.Size = new Size(200, 23);
			this.tb_LocAreaDescr.TabIndex = 46;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(710, 27);
			this.label17.Name = "label17";
			this.label17.Size = new Size(112, 15);
			this.label17.TabIndex = 45;
			this.label17.Text = "Location Area Descr";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(360, 54);
			this.label10.Name = "label10";
			this.label10.Size = new Size(41, 15);
			this.label10.TabIndex = 31;
			this.label10.Text = "Model";
			this.tb_Model.Location = new Point(486, 51);
			this.tb_Model.Margin = new Padding(3, 5, 3, 5);
			this.tb_Model.Name = "tb_Model";
			this.tb_Model.Size = new Size(200, 23);
			this.tb_Model.TabIndex = 32;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(360, 81);
			this.label11.Name = "label11";
			this.label11.Size = new Size(82, 15);
			this.label11.TabIndex = 33;
			this.label11.Text = "Serial Number";
			this.tb_SerialNumber.Location = new Point(486, 78);
			this.tb_SerialNumber.Margin = new Padding(3, 5, 3, 5);
			this.tb_SerialNumber.Name = "tb_SerialNumber";
			this.tb_SerialNumber.Size = new Size(200, 23);
			this.tb_SerialNumber.TabIndex = 34;
			base.Name = "Tab_EQ";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000098 RID: 152
		private CTemp _tempInfo;

		// Token: 0x04000099 RID: 153
		private CEQ _cEQ;

		// Token: 0x0400009A RID: 154
		private IContainer components;

		// Token: 0x0400009B RID: 155
		private GroupBox groupBox1;

		// Token: 0x0400009C RID: 156
		private TextBox tb_Activity;

		// Token: 0x0400009D RID: 157
		private Label label1;

		// Token: 0x0400009E RID: 158
		private Label label2;

		// Token: 0x0400009F RID: 159
		private TextBox tb_EquipmentType;

		// Token: 0x040000A0 RID: 160
		private Label label3;

		// Token: 0x040000A1 RID: 161
		private TextBox tb_StGroup;

		// Token: 0x040000A2 RID: 162
		private TextBox tb_PackageDescr;

		// Token: 0x040000A3 RID: 163
		private Label label19;

		// Token: 0x040000A4 RID: 164
		private Label label18;

		// Token: 0x040000A5 RID: 165
		private TextBox tb_LocAreaDescr;

		// Token: 0x040000A6 RID: 166
		private Label label17;

		// Token: 0x040000A7 RID: 167
		private Label label10;

		// Token: 0x040000A8 RID: 168
		private TextBox tb_Model;

		// Token: 0x040000A9 RID: 169
		private Label label11;

		// Token: 0x040000AA RID: 170
		private TextBox tb_SerialNumber;

		// Token: 0x040000AB RID: 171
		private Label label6;

		// Token: 0x040000AC RID: 172
		private Label label5;

		// Token: 0x040000AD RID: 173
		private TextBox tb_MfgBrand;

		// Token: 0x040000AE RID: 174
		private DateTimePicker dtPicker_ConsignmentDate;

		// Token: 0x040000AF RID: 175
		private DateTimePicker dtPicker_MfgYear;
	}
}
