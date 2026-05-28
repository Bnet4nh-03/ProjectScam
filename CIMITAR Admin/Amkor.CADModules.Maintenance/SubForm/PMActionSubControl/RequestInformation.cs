using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst.Class;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl
{
	// Token: 0x02000020 RID: 32
	public class RequestInformation : UserControl
	{
		// Token: 0x0600023E RID: 574 RVA: 0x000536E0 File Offset: 0x000518E0
		public RequestInformation(cReportItem report)
		{
			this.InitializeComponent();
			this.tbCategory.Text = report.sCategory;
			this.tbModel.Text = report.sModel;
			this.tbMC.Text = report.sMachineNo;
			this.tbType.Text = report.sType;
			this.tbWorkType.Text = report.sWorkType;
			this.cbPMDownTime.Checked = report.PMStatus;
			this.tbPlanedDate.Text = report.sPMPlanedDate;
			this.tbEstimatedTime.Text = report.sPMEstimatedTime + "(H)";
			bool flag = report.sHCCLocation.Trim().Length != 0;
			if (flag)
			{
				this.lbActionMC.Text = "Location";
				this.lbActionRsc.Text = "Board #";
			}
			else
			{
				this.lbActionMC.Text = "M/C #";
				this.lbActionRsc.Text = "Rsc Dec";
			}
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00053800 File Offset: 0x00051A00
		public string getCategory()
		{
			return this.tbCategory.Text.Trim();
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00053824 File Offset: 0x00051A24
		public string getMachine()
		{
			return this.tbMC.Text.Trim();
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00053848 File Offset: 0x00051A48
		public string getModel()
		{
			return this.tbModel.Text.Trim();
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0005386C File Offset: 0x00051A6C
		public string getType()
		{
			return this.tbType.Text.Trim();
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00053890 File Offset: 0x00051A90
		public string getPlenDate()
		{
			return this.tbPlanedDate.Text.Trim();
		}

		// Token: 0x06000244 RID: 580 RVA: 0x000538B4 File Offset: 0x00051AB4
		public string getEstimatedTime()
		{
			return this.tbEstimatedTime.Text.Trim();
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000538D8 File Offset: 0x00051AD8
		public string getWorkType()
		{
			return this.tbWorkType.Text.Trim();
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000538FC File Offset: 0x00051AFC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00053934 File Offset: 0x00051B34
		private void InitializeComponent()
		{
			this.groupBox6 = new GroupBox();
			this.gbPMStatus = new GroupBox();
			this.cbPMDownTime = new CheckBox();
			this.panel8 = new Panel();
			this.tbEstimatedTime = new TextBox();
			this.label40 = new Label();
			this.panel7 = new Panel();
			this.tbPlanedDate = new TextBox();
			this.label41 = new Label();
			this.panel5 = new Panel();
			this.panel6 = new Panel();
			this.tbWorkType = new TextBox();
			this.label7 = new Label();
			this.panel4 = new Panel();
			this.tbType = new TextBox();
			this.lbActionRsc = new Label();
			this.panel3 = new Panel();
			this.tbMC = new TextBox();
			this.lbActionMC = new Label();
			this.panel2 = new Panel();
			this.tbModel = new TextBox();
			this.label29 = new Label();
			this.panel1 = new Panel();
			this.tbCategory = new TextBox();
			this.label5 = new Label();
			this.groupBox6.SuspendLayout();
			this.gbPMStatus.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox6.Controls.Add(this.gbPMStatus);
			this.groupBox6.Controls.Add(this.panel8);
			this.groupBox6.Controls.Add(this.panel7);
			this.groupBox6.Controls.Add(this.panel5);
			this.groupBox6.Controls.Add(this.panel4);
			this.groupBox6.Controls.Add(this.panel3);
			this.groupBox6.Controls.Add(this.panel2);
			this.groupBox6.Controls.Add(this.panel1);
			this.groupBox6.Dock = DockStyle.Top;
			this.groupBox6.Location = new Point(0, 0);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new Size(329, 280);
			this.groupBox6.TabIndex = 78;
			this.groupBox6.TabStop = false;
			this.gbPMStatus.Controls.Add(this.cbPMDownTime);
			this.gbPMStatus.Dock = DockStyle.Top;
			this.gbPMStatus.Font = new Font("Segoe UI Symbol", 9.75f);
			this.gbPMStatus.Location = new Point(3, 189);
			this.gbPMStatus.Name = "gbPMStatus";
			this.gbPMStatus.Size = new Size(323, 51);
			this.gbPMStatus.TabIndex = 98;
			this.gbPMStatus.TabStop = false;
			this.gbPMStatus.Text = "PM Status";
			this.cbPMDownTime.AutoSize = true;
			this.cbPMDownTime.Dock = DockStyle.Left;
			this.cbPMDownTime.Enabled = false;
			this.cbPMDownTime.Location = new Point(3, 21);
			this.cbPMDownTime.Name = "cbPMDownTime";
			this.cbPMDownTime.Size = new Size(88, 27);
			this.cbPMDownTime.TabIndex = 0;
			this.cbPMDownTime.Text = "DownTime";
			this.cbPMDownTime.UseVisualStyleBackColor = true;
			this.panel8.Controls.Add(this.tbEstimatedTime);
			this.panel8.Controls.Add(this.label40);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(3, 156);
			this.panel8.Name = "panel8";
			this.panel8.Size = new Size(323, 33);
			this.panel8.TabIndex = 123;
			this.tbEstimatedTime.BackColor = Color.Gainsboro;
			this.tbEstimatedTime.Dock = DockStyle.Bottom;
			this.tbEstimatedTime.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbEstimatedTime.Location = new Point(80, 10);
			this.tbEstimatedTime.Name = "tbEstimatedTime";
			this.tbEstimatedTime.ReadOnly = true;
			this.tbEstimatedTime.Size = new Size(243, 23);
			this.tbEstimatedTime.TabIndex = 116;
			this.tbEstimatedTime.TabStop = false;
			this.label40.Dock = DockStyle.Left;
			this.label40.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label40.Location = new Point(0, 0);
			this.label40.Name = "label40";
			this.label40.Size = new Size(80, 33);
			this.label40.TabIndex = 117;
			this.label40.Text = "Estimated \r\nTime(H)";
			this.panel7.Controls.Add(this.tbPlanedDate);
			this.panel7.Controls.Add(this.label41);
			this.panel7.Dock = DockStyle.Top;
			this.panel7.Location = new Point(3, 132);
			this.panel7.Name = "panel7";
			this.panel7.Size = new Size(323, 24);
			this.panel7.TabIndex = 122;
			this.tbPlanedDate.BackColor = Color.Gainsboro;
			this.tbPlanedDate.Dock = DockStyle.Fill;
			this.tbPlanedDate.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbPlanedDate.Location = new Point(81, 0);
			this.tbPlanedDate.Name = "tbPlanedDate";
			this.tbPlanedDate.ReadOnly = true;
			this.tbPlanedDate.Size = new Size(242, 23);
			this.tbPlanedDate.TabIndex = 114;
			this.tbPlanedDate.TabStop = false;
			this.label41.Dock = DockStyle.Left;
			this.label41.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label41.Location = new Point(0, 0);
			this.label41.Name = "label41";
			this.label41.Size = new Size(81, 24);
			this.label41.TabIndex = 115;
			this.label41.Text = "Planed Date";
			this.panel5.Controls.Add(this.panel6);
			this.panel5.Controls.Add(this.tbWorkType);
			this.panel5.Controls.Add(this.label7);
			this.panel5.Dock = DockStyle.Top;
			this.panel5.Location = new Point(3, 109);
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size(323, 23);
			this.panel5.TabIndex = 121;
			this.panel6.Location = new Point(21, 26);
			this.panel6.Name = "panel6";
			this.panel6.Size = new Size(200, 100);
			this.panel6.TabIndex = 79;
			this.tbWorkType.BackColor = Color.Gainsboro;
			this.tbWorkType.Dock = DockStyle.Fill;
			this.tbWorkType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbWorkType.Location = new Point(81, 0);
			this.tbWorkType.Name = "tbWorkType";
			this.tbWorkType.ReadOnly = true;
			this.tbWorkType.Size = new Size(242, 23);
			this.tbWorkType.TabIndex = 102;
			this.tbWorkType.TabStop = false;
			this.label7.Dock = DockStyle.Left;
			this.label7.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(81, 23);
			this.label7.TabIndex = 107;
			this.label7.Text = "WorkType";
			this.panel4.Controls.Add(this.tbType);
			this.panel4.Controls.Add(this.lbActionRsc);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(3, 86);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new Padding(0, 0, 0, 1);
			this.panel4.Size = new Size(323, 23);
			this.panel4.TabIndex = 120;
			this.tbType.BackColor = Color.Gainsboro;
			this.tbType.Dock = DockStyle.Top;
			this.tbType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbType.Location = new Point(81, 0);
			this.tbType.Name = "tbType";
			this.tbType.ReadOnly = true;
			this.tbType.Size = new Size(242, 23);
			this.tbType.TabIndex = 66;
			this.tbType.TabStop = false;
			this.lbActionRsc.Dock = DockStyle.Left;
			this.lbActionRsc.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lbActionRsc.Location = new Point(0, 0);
			this.lbActionRsc.Name = "lbActionRsc";
			this.lbActionRsc.Size = new Size(81, 22);
			this.lbActionRsc.TabIndex = 13;
			this.lbActionRsc.Text = "Rsc Dec";
			this.panel3.Controls.Add(this.tbMC);
			this.panel3.Controls.Add(this.lbActionMC);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(3, 63);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new Padding(0, 0, 0, 1);
			this.panel3.Size = new Size(323, 23);
			this.panel3.TabIndex = 17;
			this.tbMC.BackColor = Color.Gainsboro;
			this.tbMC.Dock = DockStyle.Top;
			this.tbMC.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbMC.Location = new Point(81, 0);
			this.tbMC.Name = "tbMC";
			this.tbMC.ReadOnly = true;
			this.tbMC.Size = new Size(242, 23);
			this.tbMC.TabIndex = 8;
			this.tbMC.TabStop = false;
			this.lbActionMC.Dock = DockStyle.Left;
			this.lbActionMC.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lbActionMC.Location = new Point(0, 0);
			this.lbActionMC.Name = "lbActionMC";
			this.lbActionMC.Size = new Size(81, 22);
			this.lbActionMC.TabIndex = 7;
			this.lbActionMC.Text = "M/C #";
			this.panel2.Controls.Add(this.tbModel);
			this.panel2.Controls.Add(this.label29);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(3, 40);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new Padding(0, 0, 0, 1);
			this.panel2.Size = new Size(323, 23);
			this.panel2.TabIndex = 119;
			this.tbModel.BackColor = Color.Gainsboro;
			this.tbModel.Dock = DockStyle.Fill;
			this.tbModel.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbModel.Location = new Point(81, 0);
			this.tbModel.Name = "tbModel";
			this.tbModel.ReadOnly = true;
			this.tbModel.Size = new Size(242, 23);
			this.tbModel.TabIndex = 16;
			this.tbModel.TabStop = false;
			this.label29.Dock = DockStyle.Left;
			this.label29.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label29.Location = new Point(0, 0);
			this.label29.Name = "label29";
			this.label29.Size = new Size(81, 22);
			this.label29.TabIndex = 15;
			this.label29.Text = "Model";
			this.panel1.Controls.Add(this.tbCategory);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(3, 17);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new Padding(0, 0, 0, 1);
			this.panel1.Size = new Size(323, 23);
			this.panel1.TabIndex = 118;
			this.tbCategory.BackColor = Color.Gainsboro;
			this.tbCategory.Dock = DockStyle.Fill;
			this.tbCategory.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbCategory.Location = new Point(81, 0);
			this.tbCategory.Name = "tbCategory";
			this.tbCategory.ReadOnly = true;
			this.tbCategory.Size = new Size(242, 23);
			this.tbCategory.TabIndex = 68;
			this.tbCategory.TabStop = false;
			this.label5.Dock = DockStyle.Left;
			this.label5.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(81, 22);
			this.label5.TabIndex = 5;
			this.label5.Text = "Category";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.groupBox6);
			base.Name = "RequestInformation";
			base.Size = new Size(329, 241);
			this.groupBox6.ResumeLayout(false);
			this.gbPMStatus.ResumeLayout(false);
			this.gbPMStatus.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000438 RID: 1080
		private IContainer components = null;

		// Token: 0x04000439 RID: 1081
		private GroupBox groupBox6;

		// Token: 0x0400043A RID: 1082
		private TextBox tbEstimatedTime;

		// Token: 0x0400043B RID: 1083
		private Label label40;

		// Token: 0x0400043C RID: 1084
		private Label label41;

		// Token: 0x0400043D RID: 1085
		private TextBox tbPlanedDate;

		// Token: 0x0400043E RID: 1086
		private GroupBox gbPMStatus;

		// Token: 0x0400043F RID: 1087
		private CheckBox cbPMDownTime;

		// Token: 0x04000440 RID: 1088
		private TextBox tbCategory;

		// Token: 0x04000441 RID: 1089
		private Label label5;

		// Token: 0x04000442 RID: 1090
		private TextBox tbModel;

		// Token: 0x04000443 RID: 1091
		private Label label7;

		// Token: 0x04000444 RID: 1092
		private Label label29;

		// Token: 0x04000445 RID: 1093
		private TextBox tbWorkType;

		// Token: 0x04000446 RID: 1094
		private TextBox tbType;

		// Token: 0x04000447 RID: 1095
		private TextBox tbMC;

		// Token: 0x04000448 RID: 1096
		private Label lbActionMC;

		// Token: 0x04000449 RID: 1097
		private Label lbActionRsc;

		// Token: 0x0400044A RID: 1098
		private Panel panel1;

		// Token: 0x0400044B RID: 1099
		private Panel panel8;

		// Token: 0x0400044C RID: 1100
		private Panel panel7;

		// Token: 0x0400044D RID: 1101
		private Panel panel5;

		// Token: 0x0400044E RID: 1102
		private Panel panel6;

		// Token: 0x0400044F RID: 1103
		private Panel panel4;

		// Token: 0x04000450 RID: 1104
		private Panel panel3;

		// Token: 0x04000451 RID: 1105
		private Panel panel2;
	}
}
