using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Interface;

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x0200004E RID: 78
	public class RequestInformation : UserControl, IHCC
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x0007FD4E File Offset: 0x0007DF4E
		public HCC _hCC { get; }

		// Token: 0x06000456 RID: 1110 RVA: 0x0007FD58 File Offset: 0x0007DF58
		public RequestInformation(cReportItem report, HCC hcc)
		{
			this._hCC = hcc;
			this.InitializeComponent();
			this.tbCategory.Text = report.sCategory;
			this.tbModel.Text = report.sModel;
			this.tbMC.Text = report.sMachineNo;
			this.tbType.Text = report.sType;
			string sCategory = report.sCategory;
			if (!(sCategory == "HCC"))
			{
				this.gbRequestInfor.Text = "Report Information";
				this.lbActionMC.Text = "M/C #";
				this.lbActionRsc.Text = "Rsc Dec";
				this.pnHardwareType.Visible = false;
				this.pnNickname.Visible = false;
				this.pnSiteNumber.Visible = false;
				this.pnHandlerType.Visible = false;
				this.pnPKGType.Visible = false;
				base.Height = 120;
			}
			else
			{
				this.gbRequestInfor.Text = " HCC Information";
				this.lbActionMC.Text = "Location";
				this.lbActionRsc.Text = "Board #";
				this._hCC.getInformation(report.sFactory, report.sModel, report.sMachineNo);
				this.tbHardwareType.Text = this._hCC.hCCParameter.boardType;
				this.tbNickName.Text = this._hCC.hCCParameter.nickname;
				this.tbSiteNumber.Text = this._hCC.hCCParameter.site;
				this.tbHandlerType.Text = this._hCC.hCCParameter.handlerType;
				this.tbPKGType.Text = this._hCC.hCCParameter.pkgType;
				report.sHCCNickname = this._hCC.hCCParameter.nickname;
				report.sHCCType = this._hCC.hCCParameter.boardType;
				report.sHCCSite = this._hCC.hCCParameter.site;
				report.sHCCHandlerType = this._hCC.hCCParameter.handlerType;
				report.sHCCPKGType = this._hCC.hCCParameter.pkgType;
			}
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0007FFB4 File Offset: 0x0007E1B4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0007FFEC File Offset: 0x0007E1EC
		private void InitializeComponent()
		{
			this.gbRequestInfor = new GroupBox();
			this.pnPKGType = new Panel();
			this.tbPKGType = new TextBox();
			this.label3 = new Label();
			this.pnHandlerType = new Panel();
			this.tbHandlerType = new TextBox();
			this.label2 = new Label();
			this.pnSiteNumber = new Panel();
			this.tbSiteNumber = new TextBox();
			this.label1 = new Label();
			this.pnNickname = new Panel();
			this.tbNickName = new TextBox();
			this.label9 = new Label();
			this.pnHardwareType = new Panel();
			this.tbHardwareType = new TextBox();
			this.label7 = new Label();
			this.panel51 = new Panel();
			this.tbType = new TextBox();
			this.lbActionRsc = new Label();
			this.panel50 = new Panel();
			this.tbMC = new TextBox();
			this.lbActionMC = new Label();
			this.panel49 = new Panel();
			this.tbModel = new TextBox();
			this.label29 = new Label();
			this.panel23 = new Panel();
			this.tbCategory = new TextBox();
			this.label5 = new Label();
			this.gbRequestInfor.SuspendLayout();
			this.pnPKGType.SuspendLayout();
			this.pnHandlerType.SuspendLayout();
			this.pnSiteNumber.SuspendLayout();
			this.pnNickname.SuspendLayout();
			this.pnHardwareType.SuspendLayout();
			this.panel51.SuspendLayout();
			this.panel50.SuspendLayout();
			this.panel49.SuspendLayout();
			this.panel23.SuspendLayout();
			base.SuspendLayout();
			this.gbRequestInfor.AutoSize = true;
			this.gbRequestInfor.Controls.Add(this.pnPKGType);
			this.gbRequestInfor.Controls.Add(this.pnHandlerType);
			this.gbRequestInfor.Controls.Add(this.pnSiteNumber);
			this.gbRequestInfor.Controls.Add(this.pnNickname);
			this.gbRequestInfor.Controls.Add(this.pnHardwareType);
			this.gbRequestInfor.Controls.Add(this.panel51);
			this.gbRequestInfor.Controls.Add(this.panel50);
			this.gbRequestInfor.Controls.Add(this.panel49);
			this.gbRequestInfor.Controls.Add(this.panel23);
			this.gbRequestInfor.Dock = DockStyle.Top;
			this.gbRequestInfor.Font = new Font("굴림", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gbRequestInfor.Location = new Point(0, 0);
			this.gbRequestInfor.Name = "gbRequestInfor";
			this.gbRequestInfor.Size = new Size(352, 237);
			this.gbRequestInfor.TabIndex = 78;
			this.gbRequestInfor.TabStop = false;
			this.gbRequestInfor.Text = "Report Information";
			this.pnPKGType.Controls.Add(this.tbPKGType);
			this.pnPKGType.Controls.Add(this.label3);
			this.pnPKGType.Dock = DockStyle.Top;
			this.pnPKGType.Location = new Point(3, 210);
			this.pnPKGType.Name = "pnPKGType";
			this.pnPKGType.Size = new Size(346, 24);
			this.pnPKGType.TabIndex = 85;
			this.tbPKGType.BackColor = Color.Gainsboro;
			this.tbPKGType.Dock = DockStyle.Fill;
			this.tbPKGType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbPKGType.Location = new Point(101, 0);
			this.tbPKGType.Name = "tbPKGType";
			this.tbPKGType.ReadOnly = true;
			this.tbPKGType.Size = new Size(245, 23);
			this.tbPKGType.TabIndex = 66;
			this.tbPKGType.TabStop = false;
			this.label3.Dock = DockStyle.Left;
			this.label3.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(101, 24);
			this.label3.TabIndex = 13;
			this.label3.Text = "PKG Type";
			this.pnHandlerType.Controls.Add(this.tbHandlerType);
			this.pnHandlerType.Controls.Add(this.label2);
			this.pnHandlerType.Dock = DockStyle.Top;
			this.pnHandlerType.Location = new Point(3, 186);
			this.pnHandlerType.Name = "pnHandlerType";
			this.pnHandlerType.Size = new Size(346, 24);
			this.pnHandlerType.TabIndex = 84;
			this.tbHandlerType.BackColor = Color.Gainsboro;
			this.tbHandlerType.Dock = DockStyle.Fill;
			this.tbHandlerType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHandlerType.Location = new Point(101, 0);
			this.tbHandlerType.Name = "tbHandlerType";
			this.tbHandlerType.ReadOnly = true;
			this.tbHandlerType.Size = new Size(245, 23);
			this.tbHandlerType.TabIndex = 66;
			this.tbHandlerType.TabStop = false;
			this.label2.Dock = DockStyle.Left;
			this.label2.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(101, 24);
			this.label2.TabIndex = 13;
			this.label2.Text = "Handler Type";
			this.pnSiteNumber.Controls.Add(this.tbSiteNumber);
			this.pnSiteNumber.Controls.Add(this.label1);
			this.pnSiteNumber.Dock = DockStyle.Top;
			this.pnSiteNumber.Location = new Point(3, 162);
			this.pnSiteNumber.Name = "pnSiteNumber";
			this.pnSiteNumber.Size = new Size(346, 24);
			this.pnSiteNumber.TabIndex = 83;
			this.tbSiteNumber.BackColor = Color.Gainsboro;
			this.tbSiteNumber.Dock = DockStyle.Fill;
			this.tbSiteNumber.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbSiteNumber.Location = new Point(101, 0);
			this.tbSiteNumber.Name = "tbSiteNumber";
			this.tbSiteNumber.ReadOnly = true;
			this.tbSiteNumber.Size = new Size(245, 23);
			this.tbSiteNumber.TabIndex = 66;
			this.tbSiteNumber.TabStop = false;
			this.label1.Dock = DockStyle.Left;
			this.label1.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(101, 24);
			this.label1.TabIndex = 13;
			this.label1.Text = "Number of Site";
			this.pnNickname.Controls.Add(this.tbNickName);
			this.pnNickname.Controls.Add(this.label9);
			this.pnNickname.Dock = DockStyle.Top;
			this.pnNickname.Location = new Point(3, 138);
			this.pnNickname.Name = "pnNickname";
			this.pnNickname.Size = new Size(346, 24);
			this.pnNickname.TabIndex = 82;
			this.tbNickName.BackColor = Color.Gainsboro;
			this.tbNickName.Dock = DockStyle.Fill;
			this.tbNickName.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbNickName.Location = new Point(101, 0);
			this.tbNickName.Name = "tbNickName";
			this.tbNickName.ReadOnly = true;
			this.tbNickName.Size = new Size(245, 23);
			this.tbNickName.TabIndex = 66;
			this.tbNickName.TabStop = false;
			this.label9.Dock = DockStyle.Left;
			this.label9.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label9.Location = new Point(0, 0);
			this.label9.Name = "label9";
			this.label9.Size = new Size(101, 24);
			this.label9.TabIndex = 13;
			this.label9.Text = "Nickname";
			this.pnHardwareType.Controls.Add(this.tbHardwareType);
			this.pnHardwareType.Controls.Add(this.label7);
			this.pnHardwareType.Dock = DockStyle.Top;
			this.pnHardwareType.Location = new Point(3, 114);
			this.pnHardwareType.Name = "pnHardwareType";
			this.pnHardwareType.Size = new Size(346, 24);
			this.pnHardwareType.TabIndex = 81;
			this.tbHardwareType.BackColor = Color.Gainsboro;
			this.tbHardwareType.Dock = DockStyle.Fill;
			this.tbHardwareType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHardwareType.Location = new Point(101, 0);
			this.tbHardwareType.Name = "tbHardwareType";
			this.tbHardwareType.ReadOnly = true;
			this.tbHardwareType.Size = new Size(245, 23);
			this.tbHardwareType.TabIndex = 66;
			this.tbHardwareType.TabStop = false;
			this.label7.Dock = DockStyle.Left;
			this.label7.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(101, 24);
			this.label7.TabIndex = 13;
			this.label7.Text = "Hardware Type";
			this.panel51.Controls.Add(this.tbType);
			this.panel51.Controls.Add(this.lbActionRsc);
			this.panel51.Dock = DockStyle.Top;
			this.panel51.Location = new Point(3, 90);
			this.panel51.Name = "panel51";
			this.panel51.Size = new Size(346, 24);
			this.panel51.TabIndex = 79;
			this.tbType.BackColor = Color.Gainsboro;
			this.tbType.Dock = DockStyle.Fill;
			this.tbType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbType.Location = new Point(101, 0);
			this.tbType.Name = "tbType";
			this.tbType.ReadOnly = true;
			this.tbType.Size = new Size(245, 23);
			this.tbType.TabIndex = 66;
			this.tbType.TabStop = false;
			this.lbActionRsc.Dock = DockStyle.Left;
			this.lbActionRsc.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lbActionRsc.Location = new Point(0, 0);
			this.lbActionRsc.Name = "lbActionRsc";
			this.lbActionRsc.Size = new Size(101, 24);
			this.lbActionRsc.TabIndex = 13;
			this.lbActionRsc.Text = "Rsc Dec";
			this.panel50.Controls.Add(this.tbMC);
			this.panel50.Controls.Add(this.lbActionMC);
			this.panel50.Dock = DockStyle.Top;
			this.panel50.Location = new Point(3, 66);
			this.panel50.Name = "panel50";
			this.panel50.Size = new Size(346, 24);
			this.panel50.TabIndex = 78;
			this.tbMC.BackColor = Color.Gainsboro;
			this.tbMC.Dock = DockStyle.Fill;
			this.tbMC.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbMC.Location = new Point(101, 0);
			this.tbMC.Name = "tbMC";
			this.tbMC.ReadOnly = true;
			this.tbMC.Size = new Size(245, 23);
			this.tbMC.TabIndex = 8;
			this.tbMC.TabStop = false;
			this.lbActionMC.Dock = DockStyle.Left;
			this.lbActionMC.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lbActionMC.Location = new Point(0, 0);
			this.lbActionMC.Name = "lbActionMC";
			this.lbActionMC.Size = new Size(101, 24);
			this.lbActionMC.TabIndex = 7;
			this.lbActionMC.Text = "M/C #";
			this.panel49.Controls.Add(this.tbModel);
			this.panel49.Controls.Add(this.label29);
			this.panel49.Dock = DockStyle.Top;
			this.panel49.Location = new Point(3, 42);
			this.panel49.Name = "panel49";
			this.panel49.Size = new Size(346, 24);
			this.panel49.TabIndex = 17;
			this.tbModel.BackColor = Color.Gainsboro;
			this.tbModel.Dock = DockStyle.Fill;
			this.tbModel.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbModel.Location = new Point(101, 0);
			this.tbModel.Name = "tbModel";
			this.tbModel.ReadOnly = true;
			this.tbModel.Size = new Size(245, 23);
			this.tbModel.TabIndex = 16;
			this.tbModel.TabStop = false;
			this.label29.Dock = DockStyle.Left;
			this.label29.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label29.Location = new Point(0, 0);
			this.label29.Name = "label29";
			this.label29.Size = new Size(101, 24);
			this.label29.TabIndex = 15;
			this.label29.Text = "Model";
			this.panel23.Controls.Add(this.tbCategory);
			this.panel23.Controls.Add(this.label5);
			this.panel23.Dock = DockStyle.Top;
			this.panel23.Location = new Point(3, 18);
			this.panel23.Name = "panel23";
			this.panel23.Size = new Size(346, 24);
			this.panel23.TabIndex = 77;
			this.tbCategory.BackColor = Color.Gainsboro;
			this.tbCategory.Dock = DockStyle.Fill;
			this.tbCategory.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbCategory.Location = new Point(101, 0);
			this.tbCategory.Name = "tbCategory";
			this.tbCategory.ReadOnly = true;
			this.tbCategory.Size = new Size(245, 23);
			this.tbCategory.TabIndex = 68;
			this.tbCategory.TabStop = false;
			this.label5.Dock = DockStyle.Left;
			this.label5.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(101, 24);
			this.label5.TabIndex = 5;
			this.label5.Text = "Category";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.gbRequestInfor);
			this.ForeColor = Color.Black;
			base.Name = "RequestInformation";
			base.Size = new Size(352, 235);
			this.gbRequestInfor.ResumeLayout(false);
			this.pnPKGType.ResumeLayout(false);
			this.pnPKGType.PerformLayout();
			this.pnHandlerType.ResumeLayout(false);
			this.pnHandlerType.PerformLayout();
			this.pnSiteNumber.ResumeLayout(false);
			this.pnSiteNumber.PerformLayout();
			this.pnNickname.ResumeLayout(false);
			this.pnNickname.PerformLayout();
			this.pnHardwareType.ResumeLayout(false);
			this.pnHardwareType.PerformLayout();
			this.panel51.ResumeLayout(false);
			this.panel51.PerformLayout();
			this.panel50.ResumeLayout(false);
			this.panel50.PerformLayout();
			this.panel49.ResumeLayout(false);
			this.panel49.PerformLayout();
			this.panel23.ResumeLayout(false);
			this.panel23.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040006EB RID: 1771
		private IContainer components = null;

		// Token: 0x040006EC RID: 1772
		private GroupBox gbRequestInfor;

		// Token: 0x040006ED RID: 1773
		private Panel pnNickname;

		// Token: 0x040006EE RID: 1774
		private TextBox tbNickName;

		// Token: 0x040006EF RID: 1775
		private Label label9;

		// Token: 0x040006F0 RID: 1776
		private Panel pnHardwareType;

		// Token: 0x040006F1 RID: 1777
		private TextBox tbHardwareType;

		// Token: 0x040006F2 RID: 1778
		private Label label7;

		// Token: 0x040006F3 RID: 1779
		private Panel panel51;

		// Token: 0x040006F4 RID: 1780
		private TextBox tbType;

		// Token: 0x040006F5 RID: 1781
		private Label lbActionRsc;

		// Token: 0x040006F6 RID: 1782
		private Panel panel50;

		// Token: 0x040006F7 RID: 1783
		private TextBox tbMC;

		// Token: 0x040006F8 RID: 1784
		private Label lbActionMC;

		// Token: 0x040006F9 RID: 1785
		private Panel panel49;

		// Token: 0x040006FA RID: 1786
		private TextBox tbModel;

		// Token: 0x040006FB RID: 1787
		private Label label29;

		// Token: 0x040006FC RID: 1788
		private Panel panel23;

		// Token: 0x040006FD RID: 1789
		private TextBox tbCategory;

		// Token: 0x040006FE RID: 1790
		private Label label5;

		// Token: 0x040006FF RID: 1791
		private Panel pnPKGType;

		// Token: 0x04000700 RID: 1792
		private TextBox tbPKGType;

		// Token: 0x04000701 RID: 1793
		private Label label3;

		// Token: 0x04000702 RID: 1794
		private Panel pnHandlerType;

		// Token: 0x04000703 RID: 1795
		private TextBox tbHandlerType;

		// Token: 0x04000704 RID: 1796
		private Label label2;

		// Token: 0x04000705 RID: 1797
		private Panel pnSiteNumber;

		// Token: 0x04000706 RID: 1798
		private TextBox tbSiteNumber;

		// Token: 0x04000707 RID: 1799
		private Label label1;
	}
}
