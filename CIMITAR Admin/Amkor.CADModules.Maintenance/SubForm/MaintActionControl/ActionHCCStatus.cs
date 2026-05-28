using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Interface;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x02000046 RID: 70
	public class ActionHCCStatus : UserControl, IHCC
	{
		// Token: 0x060003F4 RID: 1012 RVA: 0x00075C6B File Offset: 0x00073E6B
		public bool getHCCPartial()
		{
			return this.rbHCCPartial.Checked;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00075C78 File Offset: 0x00073E78
		public bool getHCCStatusCheck()
		{
			return this.rbHCCGood.Checked != this.rbHCCCheck.Checked;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060003F6 RID: 1014 RVA: 0x00075C96 File Offset: 0x00073E96
		public HCC _hCC { get; }

		// Token: 0x060003F7 RID: 1015 RVA: 0x00075CA0 File Offset: 0x00073EA0
		public int getHCCStatus()
		{
			bool @checked = this.rbHCCGood.Checked;
			int result;
			if (@checked)
			{
				result = 1;
			}
			else
			{
				bool checked2 = this.rbHCCPartial.Checked;
				if (checked2)
				{
					result = 2;
				}
				else
				{
					bool checked3 = this.rbHCCBad.Checked;
					if (checked3)
					{
						result = 3;
					}
					else
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00075CEC File Offset: 0x00073EEC
		public ActionHCCStatus(FactorySettings factorySettings, cReportItem report, HCC hCC)
		{
			this._report = report;
			this._hCC = hCC;
			this._factorySettings = factorySettings;
			this.InitializeComponent();
			bool flag = this._report.sReportStauts == "2";
			if (flag)
			{
				this.gbHwStatus.Visible = false;
			}
			else
			{
				bool flag2 = this._report.sReportStauts == "1" || this._report.sReportStauts == "3";
				if (flag2)
				{
					this.gbHwStatus.Visible = true;
					this.rbHCCGood.Checked = false;
					this.rbHCCPartial.Checked = false;
					this.rbHCCBad.Checked = false;
					this.rbHCCCheck.Checked = true;
				}
			}
			bool flag3 = this._report.sHCCLocation.Trim().Length != 0;
			if (flag3)
			{
				bool flag4 = this._report.sFactory == "K3";
				if (flag4)
				{
					this._report.sHCCSite = this._hCC.hCCParameter.site;
					bool flag5 = this._report.sModel.ToUpper() == this._hCC.hCCContent.Board;
					if (flag5)
					{
						this.gbHCCDisableSite.Visible = true;
						this.rbHCCPartial.Visible = true;
					}
					else
					{
						this.rbHCCPartial.Visible = false;
					}
				}
			}
			this.setDisableSiteCount();
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00075E8C File Offset: 0x0007408C
		public string getDisableSite()
		{
			bool flag = this.tbHCCDisableSite == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				result = this.tbHCCDisableSite.Text.Trim();
			}
			return result;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00075EC4 File Offset: 0x000740C4
		public void setDisableSite(bool isGood)
		{
			bool flag = !isGood;
			if (flag)
			{
				this._iDisableSite++;
			}
			else
			{
				bool flag2 = this._report.sReportStauts.Trim() == "1" || this._report.sReportStauts.Trim() == "3";
				if (flag2)
				{
					this._iDisableSite--;
				}
			}
			bool flag3 = this._iDisableSite == 0;
			if (flag3)
			{
				this.rbHCCGood.Checked = true;
				this.rbHCCCheck.Checked = false;
				this.rbHCCPartial.Checked = false;
			}
			else
			{
				bool flag4 = this._MaximumnSite != this._iDisableSite;
				if (flag4)
				{
					this.rbHCCGood.Checked = false;
					this.rbHCCCheck.Checked = false;
					this.rbHCCPartial.Checked = true;
				}
				else
				{
					this.rbHCCGood.Checked = false;
					this.rbHCCCheck.Checked = true;
					this.rbHCCPartial.Checked = false;
				}
			}
			this.tbHCCDisableSite.Text = this._iDisableSite.ToString();
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00075FF3 File Offset: 0x000741F3
		public void setDisableSiteCount()
		{
			this.tbHCCDisableSite.Text = cFunction.getSitemapRejectCount(this._factorySettings, this._hCC.hCCParameter.location);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00076020 File Offset: 0x00074220
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00076058 File Offset: 0x00074258
		private void InitializeComponent()
		{
			this.gbHCCDisableSite = new GroupBox();
			this.tbHCCDisableSite = new TextBox();
			this.gbHwStatus = new GroupBox();
			this.rbHCCCheck = new RadioButton();
			this.rbHCCBad = new RadioButton();
			this.rbHCCPartial = new RadioButton();
			this.rbHCCGood = new RadioButton();
			this.gbHCCDisableSite.SuspendLayout();
			this.gbHwStatus.SuspendLayout();
			base.SuspendLayout();
			this.gbHCCDisableSite.Controls.Add(this.tbHCCDisableSite);
			this.gbHCCDisableSite.Dock = DockStyle.Top;
			this.gbHCCDisableSite.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.gbHCCDisableSite.Location = new Point(0, 0);
			this.gbHCCDisableSite.Name = "gbHCCDisableSite";
			this.gbHCCDisableSite.Size = new Size(173, 42);
			this.gbHCCDisableSite.TabIndex = 99;
			this.gbHCCDisableSite.TabStop = false;
			this.gbHCCDisableSite.Text = "Disable Site";
			this.gbHCCDisableSite.Visible = false;
			this.tbHCCDisableSite.Dock = DockStyle.Left;
			this.tbHCCDisableSite.Location = new Point(3, 17);
			this.tbHCCDisableSite.Name = "tbHCCDisableSite";
			this.tbHCCDisableSite.ReadOnly = true;
			this.tbHCCDisableSite.Size = new Size(162, 21);
			this.tbHCCDisableSite.TabIndex = 2;
			this.tbHCCDisableSite.Text = "0";
			this.tbHCCDisableSite.TextAlign = HorizontalAlignment.Center;
			this.gbHwStatus.Controls.Add(this.rbHCCCheck);
			this.gbHwStatus.Controls.Add(this.rbHCCBad);
			this.gbHwStatus.Controls.Add(this.rbHCCPartial);
			this.gbHwStatus.Controls.Add(this.rbHCCGood);
			this.gbHwStatus.Dock = DockStyle.Fill;
			this.gbHwStatus.Font = new Font("굴림", 9f);
			this.gbHwStatus.Location = new Point(0, 42);
			this.gbHwStatus.Name = "gbHwStatus";
			this.gbHwStatus.Size = new Size(173, 91);
			this.gbHwStatus.TabIndex = 100;
			this.gbHwStatus.TabStop = false;
			this.gbHwStatus.Text = "H/W Status";
			this.gbHwStatus.Visible = false;
			this.rbHCCCheck.AutoSize = true;
			this.rbHCCCheck.Dock = DockStyle.Top;
			this.rbHCCCheck.Enabled = false;
			this.rbHCCCheck.Font = new Font("굴림", 9f);
			this.rbHCCCheck.Location = new Point(3, 65);
			this.rbHCCCheck.Name = "rbHCCCheck";
			this.rbHCCCheck.Size = new Size(167, 16);
			this.rbHCCCheck.TabIndex = 4;
			this.rbHCCCheck.Text = "Need to Check";
			this.rbHCCCheck.UseVisualStyleBackColor = true;
			this.rbHCCBad.AutoSize = true;
			this.rbHCCBad.Cursor = Cursors.Hand;
			this.rbHCCBad.Dock = DockStyle.Top;
			this.rbHCCBad.Font = new Font("굴림", 9f);
			this.rbHCCBad.Location = new Point(3, 49);
			this.rbHCCBad.Name = "rbHCCBad";
			this.rbHCCBad.Size = new Size(167, 16);
			this.rbHCCBad.TabIndex = 3;
			this.rbHCCBad.Text = "Bad";
			this.rbHCCBad.UseVisualStyleBackColor = true;
			this.rbHCCPartial.AutoSize = true;
			this.rbHCCPartial.Cursor = Cursors.Hand;
			this.rbHCCPartial.Dock = DockStyle.Top;
			this.rbHCCPartial.Font = new Font("굴림", 9f);
			this.rbHCCPartial.Location = new Point(3, 33);
			this.rbHCCPartial.Name = "rbHCCPartial";
			this.rbHCCPartial.Size = new Size(167, 16);
			this.rbHCCPartial.TabIndex = 2;
			this.rbHCCPartial.Text = "Partial Good";
			this.rbHCCPartial.UseVisualStyleBackColor = true;
			this.rbHCCGood.AutoSize = true;
			this.rbHCCGood.Cursor = Cursors.Hand;
			this.rbHCCGood.Dock = DockStyle.Top;
			this.rbHCCGood.Font = new Font("굴림", 9f);
			this.rbHCCGood.Location = new Point(3, 17);
			this.rbHCCGood.Name = "rbHCCGood";
			this.rbHCCGood.Size = new Size(167, 16);
			this.rbHCCGood.TabIndex = 0;
			this.rbHCCGood.Text = "Good";
			this.rbHCCGood.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.gbHwStatus);
			base.Controls.Add(this.gbHCCDisableSite);
			base.Name = "ActionHCCStatus";
			base.Size = new Size(173, 133);
			this.gbHCCDisableSite.ResumeLayout(false);
			this.gbHCCDisableSite.PerformLayout();
			this.gbHwStatus.ResumeLayout(false);
			this.gbHwStatus.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000639 RID: 1593
		private int _iDisableSite = 0;

		// Token: 0x0400063A RID: 1594
		private cReportItem _report;

		// Token: 0x0400063B RID: 1595
		private int _MaximumnSite = 0;

		// Token: 0x0400063C RID: 1596
		private FactorySettings _factorySettings;

		// Token: 0x0400063E RID: 1598
		private IContainer components = null;

		// Token: 0x0400063F RID: 1599
		private GroupBox gbHCCDisableSite;

		// Token: 0x04000640 RID: 1600
		private TextBox tbHCCDisableSite;

		// Token: 0x04000641 RID: 1601
		private GroupBox gbHwStatus;

		// Token: 0x04000642 RID: 1602
		private RadioButton rbHCCGood;

		// Token: 0x04000643 RID: 1603
		private RadioButton rbHCCPartial;

		// Token: 0x04000644 RID: 1604
		private RadioButton rbHCCCheck;

		// Token: 0x04000645 RID: 1605
		private RadioButton rbHCCBad;
	}
}
