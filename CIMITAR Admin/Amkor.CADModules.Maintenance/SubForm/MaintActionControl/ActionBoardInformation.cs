using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Interface;
using Amkor.CADModules.Maintenance.Properties;
using Amkor.CADModules.Maintenance.SubForm.SubControl;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x0200004C RID: 76
	public class ActionBoardInformation : UserControl, IHCC
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x0007DDB0 File Offset: 0x0007BFB0
		public HCC _hCC { get; }

		// Token: 0x0600043E RID: 1086 RVA: 0x0007DDB8 File Offset: 0x0007BFB8
		public ActionBoardInformation(FactorySettings factorySettings, cReportItem report, ActionHCCStatus ah)
		{
			this._ah = ah;
			this._hCC = ah._hCC;
			this._report = report;
			this._factorySettings = factorySettings;
			this.InitializeComponent();
			this.tbHCCLot.Text = report.sHCCLotName;
			this.tbHCCMachine.Text = report.sHCCMachine;
			bool flag = report.sReportStauts == "2";
			if (flag)
			{
				this._siteMapCanEdit = false;
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0007DE42 File Offset: 0x0007C042
		private void pbBoardInforamtion_MouseEnter(object sender, EventArgs e)
		{
			this.pbBoardInforamtion.Image = Resources.board_down;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x0007DE55 File Offset: 0x0007C055
		private void pbBoardInforamtion_MouseLeave(object sender, EventArgs e)
		{
			this.pbBoardInforamtion.Image = Resources.board;
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x0007DE68 File Offset: 0x0007C068
		private void pbBoardInforamtion_Click(object sender, EventArgs e)
		{
			this.pbBoardInforamtion.Image = Resources.board;
			new SiteMapForm(this._factorySettings, this._report, this._hCC, this._siteMapCanEdit).ShowDialog();
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0007DEA0 File Offset: 0x0007C0A0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0007DED8 File Offset: 0x0007C0D8
		private void InitializeComponent()
		{
			this.gbBoardInfo = new GroupBox();
			this.panel21 = new Panel();
			this.pnBoardSite = new Panel();
			this.groupBox1 = new GroupBox();
			this.pbBoardInforamtion = new PictureBox();
			this.pnHCCSiteInfo = new Panel();
			this.panel37 = new Panel();
			this.panel47 = new Panel();
			this.tbHCCLot = new TextBox();
			this.label8 = new Label();
			this.panel48 = new Panel();
			this.tbHCCMachine = new TextBox();
			this.label22 = new Label();
			this.gbBoardInfo.SuspendLayout();
			this.panel21.SuspendLayout();
			this.pnBoardSite.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.pbBoardInforamtion).BeginInit();
			this.panel37.SuspendLayout();
			this.panel47.SuspendLayout();
			this.panel48.SuspendLayout();
			base.SuspendLayout();
			this.gbBoardInfo.Controls.Add(this.panel21);
			this.gbBoardInfo.Dock = DockStyle.Fill;
			this.gbBoardInfo.Font = new Font("굴림", 9.75f);
			this.gbBoardInfo.Location = new Point(0, 0);
			this.gbBoardInfo.Name = "gbBoardInfo";
			this.gbBoardInfo.Size = new Size(415, 147);
			this.gbBoardInfo.TabIndex = 104;
			this.gbBoardInfo.TabStop = false;
			this.gbBoardInfo.Text = "Board Information";
			this.panel21.Controls.Add(this.pnBoardSite);
			this.panel21.Controls.Add(this.pnHCCSiteInfo);
			this.panel21.Controls.Add(this.panel37);
			this.panel21.Controls.Add(this.panel48);
			this.panel21.Dock = DockStyle.Fill;
			this.panel21.Font = new Font("굴림", 9.75f);
			this.panel21.Location = new Point(3, 18);
			this.panel21.Name = "panel21";
			this.panel21.Size = new Size(409, 126);
			this.panel21.TabIndex = 0;
			this.pnBoardSite.Controls.Add(this.groupBox1);
			this.pnBoardSite.Dock = DockStyle.Right;
			this.pnBoardSite.Location = new Point(325, 54);
			this.pnBoardSite.Name = "pnBoardSite";
			this.pnBoardSite.Padding = new Padding(4, 1, 4, 3);
			this.pnBoardSite.Size = new Size(84, 72);
			this.pnBoardSite.TabIndex = 105;
			this.groupBox1.Controls.Add(this.pbBoardInforamtion);
			this.groupBox1.Dock = DockStyle.Top;
			this.groupBox1.Location = new Point(4, 1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new Padding(1, 1, 1, 3);
			this.groupBox1.Size = new Size(76, 68);
			this.groupBox1.TabIndex = 99;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Site Map";
			this.pbBoardInforamtion.Cursor = Cursors.Hand;
			this.pbBoardInforamtion.Dock = DockStyle.Fill;
			this.pbBoardInforamtion.Image = Resources.board;
			this.pbBoardInforamtion.InitialImage = null;
			this.pbBoardInforamtion.Location = new Point(1, 16);
			this.pbBoardInforamtion.Margin = new Padding(1);
			this.pbBoardInforamtion.Name = "pbBoardInforamtion";
			this.pbBoardInforamtion.Padding = new Padding(1);
			this.pbBoardInforamtion.Size = new Size(74, 49);
			this.pbBoardInforamtion.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbBoardInforamtion.TabIndex = 99;
			this.pbBoardInforamtion.TabStop = false;
			this.pbBoardInforamtion.Click += this.pbBoardInforamtion_Click;
			this.pbBoardInforamtion.MouseEnter += this.pbBoardInforamtion_MouseEnter;
			this.pbBoardInforamtion.MouseLeave += this.pbBoardInforamtion_MouseLeave;
			this.pnHCCSiteInfo.AutoScroll = true;
			this.pnHCCSiteInfo.AutoScrollMargin = new Size(100, 100);
			this.pnHCCSiteInfo.AutoScrollMinSize = new Size(0, 100);
			this.pnHCCSiteInfo.Font = new Font("굴림", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.pnHCCSiteInfo.Location = new Point(52, 75);
			this.pnHCCSiteInfo.Name = "pnHCCSiteInfo";
			this.pnHCCSiteInfo.Size = new Size(409, 42);
			this.pnHCCSiteInfo.TabIndex = 4;
			this.pnHCCSiteInfo.Visible = false;
			this.panel37.Controls.Add(this.panel47);
			this.panel37.Dock = DockStyle.Top;
			this.panel37.Location = new Point(0, 28);
			this.panel37.Name = "panel37";
			this.panel37.Size = new Size(409, 26);
			this.panel37.TabIndex = 1;
			this.panel47.Controls.Add(this.tbHCCLot);
			this.panel47.Controls.Add(this.label8);
			this.panel47.Dock = DockStyle.Top;
			this.panel47.Location = new Point(0, 0);
			this.panel47.Name = "panel47";
			this.panel47.Size = new Size(409, 28);
			this.panel47.TabIndex = 1;
			this.tbHCCLot.Dock = DockStyle.Fill;
			this.tbHCCLot.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCLot.Location = new Point(98, 0);
			this.tbHCCLot.Name = "tbHCCLot";
			this.tbHCCLot.ReadOnly = true;
			this.tbHCCLot.Size = new Size(311, 25);
			this.tbHCCLot.TabIndex = 15;
			this.label8.Dock = DockStyle.Left;
			this.label8.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label8.Location = new Point(0, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(98, 28);
			this.label8.TabIndex = 14;
			this.label8.Text = "Lot Number";
			this.label8.TextAlign = ContentAlignment.MiddleCenter;
			this.panel48.Controls.Add(this.tbHCCMachine);
			this.panel48.Controls.Add(this.label22);
			this.panel48.Dock = DockStyle.Top;
			this.panel48.Location = new Point(0, 0);
			this.panel48.Name = "panel48";
			this.panel48.Size = new Size(409, 28);
			this.panel48.TabIndex = 0;
			this.tbHCCMachine.Dock = DockStyle.Fill;
			this.tbHCCMachine.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCMachine.Location = new Point(98, 0);
			this.tbHCCMachine.Name = "tbHCCMachine";
			this.tbHCCMachine.ReadOnly = true;
			this.tbHCCMachine.Size = new Size(311, 25);
			this.tbHCCMachine.TabIndex = 15;
			this.label22.Dock = DockStyle.Left;
			this.label22.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label22.Location = new Point(0, 0);
			this.label22.Name = "label22";
			this.label22.Size = new Size(98, 28);
			this.label22.TabIndex = 14;
			this.label22.Text = "M/C #";
			this.label22.TextAlign = ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.gbBoardInfo);
			base.Name = "ActionBoardInformation";
			base.Size = new Size(415, 147);
			this.gbBoardInfo.ResumeLayout(false);
			this.panel21.ResumeLayout(false);
			this.pnBoardSite.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.pbBoardInforamtion).EndInit();
			this.panel37.ResumeLayout(false);
			this.panel47.ResumeLayout(false);
			this.panel47.PerformLayout();
			this.panel48.ResumeLayout(false);
			this.panel48.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040006C5 RID: 1733
		private readonly ActionHCCStatus _ah;

		// Token: 0x040006C6 RID: 1734
		private readonly cReportItem _report;

		// Token: 0x040006C7 RID: 1735
		public readonly bool _siteMapCanEdit = true;

		// Token: 0x040006C9 RID: 1737
		private FactorySettings _factorySettings;

		// Token: 0x040006CA RID: 1738
		private IContainer components = null;

		// Token: 0x040006CB RID: 1739
		private GroupBox gbBoardInfo;

		// Token: 0x040006CC RID: 1740
		private Panel panel21;

		// Token: 0x040006CD RID: 1741
		private Panel pnHCCSiteInfo;

		// Token: 0x040006CE RID: 1742
		private Panel panel37;

		// Token: 0x040006CF RID: 1743
		private Panel panel47;

		// Token: 0x040006D0 RID: 1744
		private TextBox tbHCCLot;

		// Token: 0x040006D1 RID: 1745
		private Label label8;

		// Token: 0x040006D2 RID: 1746
		private Panel panel48;

		// Token: 0x040006D3 RID: 1747
		private TextBox tbHCCMachine;

		// Token: 0x040006D4 RID: 1748
		private Label label22;

		// Token: 0x040006D5 RID: 1749
		private Panel pnBoardSite;

		// Token: 0x040006D6 RID: 1750
		private GroupBox groupBox1;

		// Token: 0x040006D7 RID: 1751
		private PictureBox pbBoardInforamtion;
	}
}
