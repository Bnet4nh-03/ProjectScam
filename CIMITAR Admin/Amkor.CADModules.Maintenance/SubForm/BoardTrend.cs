using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Amkor.CADModules.Maintenance.Properties;

namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x02000008 RID: 8
	public class BoardTrend : UserControl
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00003357 File Offset: 0x00001557
		private void pnSiteChart_MouseEnter(object sender, EventArgs e)
		{
			this.pnSiteChart.Image = Resources.analysis_down;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000336A File Offset: 0x0000156A
		private void pnSiteChart_MouseLeave(object sender, EventArgs e)
		{
			this.pnSiteChart.Image = Resources.analysis;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000337D File Offset: 0x0000157D
		public BoardTrend()
		{
			this.InitializeComponent();
			this.clear();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000339C File Offset: 0x0000159C
		public void clear()
		{
			this.dtStartDate.Value = DateTime.Now;
			this.dtEndDate.Value = DateTime.Now;
			this.tbLocation.Text = string.Empty;
			this.cbDeviceSite.Checked = false;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000033EC File Offset: 0x000015EC
		private void pnSiteChart_Click(object sender, EventArgs e)
		{
			this.pnSiteChart.Image = Resources.analysis_down;
			DateTime dateTime = new DateTime(this.dtStartDate.Value.Year, this.dtStartDate.Value.Month, this.dtStartDate.Value.Day, 0, 0, 0);
			DateTime dateTime2 = new DateTime(this.dtEndDate.Value.Year, this.dtEndDate.Value.Month, this.dtEndDate.Value.Day, 23, 59, 59);
			bool flag = this.dtStartDate.Value > this.dtEndDate.Value;
			if (flag)
			{
				MessageBox.Show("Please check period", "Notification", MessageBoxButtons.OK);
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000034C8 File Offset: 0x000016C8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003500 File Offset: 0x00001700
		private void InitializeComponent()
		{
			ChartArea chartArea = new ChartArea();
			Legend legend = new Legend();
			Series series = new Series();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BoardTrend));
			this.panel1 = new Panel();
			this.panel3 = new Panel();
			this.splitContainer1 = new SplitContainer();
			this.chart1 = new Chart();
			this.panel15 = new Panel();
			this.panel20 = new Panel();
			this.panel21 = new Panel();
			this.pnSubIndex2 = new Panel();
			this.panel2 = new Panel();
			this.gbHccLocation = new GroupBox();
			this.cbDeviceSite = new CheckBox();
			this.tbLocation = new TextBox();
			this.pnDate = new Panel();
			this.panel4 = new Panel();
			this.panel6 = new Panel();
			this.dtEndDate = new DateTimePicker();
			this.dtStartDate = new DateTimePicker();
			this.label1 = new Label();
			this.pbSubIndex = new Panel();
			this.pnSubBase = new Panel();
			this.pnSiteChart = new PictureBox();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			((ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((ISupportInitialize)this.chart1).BeginInit();
			this.panel15.SuspendLayout();
			this.panel20.SuspendLayout();
			this.panel21.SuspendLayout();
			this.pnSubIndex2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.gbHccLocation.SuspendLayout();
			this.pnDate.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			this.pnSubBase.SuspendLayout();
			((ISupportInitialize)this.pnSiteChart).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1125, 580);
			this.panel1.TabIndex = 0;
			this.panel3.Controls.Add(this.splitContainer1);
			this.panel3.Dock = DockStyle.Fill;
			this.panel3.Location = new Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(1125, 580);
			this.panel3.TabIndex = 2;
			this.splitContainer1.Dock = DockStyle.Fill;
			this.splitContainer1.Location = new Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.pnSubBase);
			this.splitContainer1.Panel1.Controls.Add(this.panel15);
			this.splitContainer1.Panel2.Controls.Add(this.chart1);
			this.splitContainer1.Size = new Size(1125, 580);
			this.splitContainer1.SplitterDistance = 272;
			this.splitContainer1.TabIndex = 0;
			chartArea.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea);
			this.chart1.Dock = DockStyle.Fill;
			legend.Name = "Legend1";
			this.chart1.Legends.Add(legend);
			this.chart1.Location = new Point(0, 0);
			this.chart1.Name = "chart1";
			series.ChartArea = "ChartArea1";
			series.Legend = "Legend1";
			series.Name = "Series1";
			this.chart1.Series.Add(series);
			this.chart1.Size = new Size(849, 580);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.panel15.Controls.Add(this.panel20);
			this.panel15.Dock = DockStyle.Top;
			this.panel15.Location = new Point(0, 0);
			this.panel15.Name = "panel15";
			this.panel15.Size = new Size(272, 243);
			this.panel15.TabIndex = 1;
			this.panel20.Controls.Add(this.panel21);
			this.panel20.Controls.Add(this.pnDate);
			this.panel20.Dock = DockStyle.Fill;
			this.panel20.Location = new Point(0, 0);
			this.panel20.Name = "panel20";
			this.panel20.Size = new Size(272, 243);
			this.panel20.TabIndex = 0;
			this.panel21.AutoSize = true;
			this.panel21.Controls.Add(this.pnSubIndex2);
			this.panel21.Controls.Add(this.pbSubIndex);
			this.panel21.Dock = DockStyle.Fill;
			this.panel21.Location = new Point(0, 87);
			this.panel21.Name = "panel21";
			this.panel21.Size = new Size(272, 156);
			this.panel21.TabIndex = 49;
			this.pnSubIndex2.AutoSize = true;
			this.pnSubIndex2.Controls.Add(this.panel2);
			this.pnSubIndex2.Dock = DockStyle.Top;
			this.pnSubIndex2.Location = new Point(0, 0);
			this.pnSubIndex2.Name = "pnSubIndex2";
			this.pnSubIndex2.Size = new Size(272, 64);
			this.pnSubIndex2.TabIndex = 0;
			this.pnSubIndex2.Visible = false;
			this.panel2.Controls.Add(this.gbHccLocation);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(272, 64);
			this.panel2.TabIndex = 0;
			this.gbHccLocation.Controls.Add(this.cbDeviceSite);
			this.gbHccLocation.Controls.Add(this.tbLocation);
			this.gbHccLocation.Dock = DockStyle.Fill;
			this.gbHccLocation.Location = new Point(0, 0);
			this.gbHccLocation.Name = "gbHccLocation";
			this.gbHccLocation.Size = new Size(272, 64);
			this.gbHccLocation.TabIndex = 1;
			this.gbHccLocation.TabStop = false;
			this.gbHccLocation.Text = "Location";
			this.cbDeviceSite.AutoSize = true;
			this.cbDeviceSite.Dock = DockStyle.Right;
			this.cbDeviceSite.Location = new Point(207, 38);
			this.cbDeviceSite.Name = "cbDeviceSite";
			this.cbDeviceSite.Size = new Size(62, 23);
			this.cbDeviceSite.TabIndex = 1;
			this.cbDeviceSite.Text = "Device";
			this.cbDeviceSite.UseVisualStyleBackColor = true;
			this.tbLocation.Dock = DockStyle.Top;
			this.tbLocation.Location = new Point(3, 17);
			this.tbLocation.Name = "tbLocation";
			this.tbLocation.Size = new Size(266, 21);
			this.tbLocation.TabIndex = 0;
			this.pnDate.AutoSize = true;
			this.pnDate.BorderStyle = BorderStyle.FixedSingle;
			this.pnDate.Controls.Add(this.panel4);
			this.pnDate.Controls.Add(this.label1);
			this.pnDate.Dock = DockStyle.Top;
			this.pnDate.Location = new Point(0, 0);
			this.pnDate.Name = "pnDate";
			this.pnDate.Padding = new Padding(3);
			this.pnDate.Size = new Size(272, 87);
			this.pnDate.TabIndex = 48;
			this.panel4.AutoSize = true;
			this.panel4.Controls.Add(this.panel6);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(3, 26);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new Padding(3);
			this.panel4.Size = new Size(264, 56);
			this.panel4.TabIndex = 19;
			this.panel6.AutoSize = true;
			this.panel6.Controls.Add(this.dtEndDate);
			this.panel6.Controls.Add(this.dtStartDate);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(3, 3);
			this.panel6.Name = "panel6";
			this.panel6.Size = new Size(258, 50);
			this.panel6.TabIndex = 0;
			this.dtEndDate.CustomFormat = "'End Date' yyyy-MM-dd";
			this.dtEndDate.Dock = DockStyle.Top;
			this.dtEndDate.Font = new Font("Segoe UI Symbol", 9.75f);
			this.dtEndDate.Format = DateTimePickerFormat.Custom;
			this.dtEndDate.Location = new Point(0, 25);
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.Size = new Size(258, 25);
			this.dtEndDate.TabIndex = 18;
			this.dtEndDate.TabStop = false;
			this.dtStartDate.CustomFormat = "'Start Date' yyyy-MM-dd";
			this.dtStartDate.Dock = DockStyle.Top;
			this.dtStartDate.Font = new Font("Segoe UI Symbol", 9.75f);
			this.dtStartDate.Format = DateTimePickerFormat.Custom;
			this.dtStartDate.Location = new Point(0, 0);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new Size(258, 25);
			this.dtStartDate.TabIndex = 13;
			this.dtStartDate.TabStop = false;
			this.label1.BackColor = Color.SkyBlue;
			this.label1.Dock = DockStyle.Top;
			this.label1.Font = new Font("굴림", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.ForeColor = Color.Black;
			this.label1.Location = new Point(3, 3);
			this.label1.Margin = new Padding(3);
			this.label1.Name = "label1";
			this.label1.Padding = new Padding(3);
			this.label1.Size = new Size(264, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "Select Period";
			this.label1.TextAlign = ContentAlignment.MiddleCenter;
			this.pbSubIndex.AutoSize = true;
			this.pbSubIndex.Dock = DockStyle.Fill;
			this.pbSubIndex.Location = new Point(0, 0);
			this.pbSubIndex.Name = "pbSubIndex";
			this.pbSubIndex.Size = new Size(272, 156);
			this.pbSubIndex.TabIndex = 0;
			this.pnSubBase.Controls.Add(this.pnSiteChart);
			this.pnSubBase.Dock = DockStyle.Top;
			this.pnSubBase.Location = new Point(0, 243);
			this.pnSubBase.Name = "pnSubBase";
			this.pnSubBase.Size = new Size(272, 50);
			this.pnSubBase.TabIndex = 6;
			this.pnSiteChart.Cursor = Cursors.Hand;
			this.pnSiteChart.Dock = DockStyle.Right;
			this.pnSiteChart.Image = Resources.analysis;
			this.pnSiteChart.InitialImage = (Image)componentResourceManager.GetObject("pnSiteChart.InitialImage");
			this.pnSiteChart.Location = new Point(224, 0);
			this.pnSiteChart.Name = "pnSiteChart";
			this.pnSiteChart.Padding = new Padding(3);
			this.pnSiteChart.Size = new Size(48, 50);
			this.pnSiteChart.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pnSiteChart.TabIndex = 56;
			this.pnSiteChart.TabStop = false;
			this.pnSiteChart.Visible = false;
			this.pnSiteChart.Click += this.pnSiteChart_Click;
			this.pnSiteChart.MouseEnter += this.pnSiteChart_MouseEnter;
			this.pnSiteChart.MouseLeave += this.pnSiteChart_MouseLeave;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel1);
			base.Name = "BoardTrend";
			base.Size = new Size(1125, 580);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((ISupportInitialize)this.chart1).EndInit();
			this.panel15.ResumeLayout(false);
			this.panel20.ResumeLayout(false);
			this.panel20.PerformLayout();
			this.panel21.ResumeLayout(false);
			this.panel21.PerformLayout();
			this.pnSubIndex2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.gbHccLocation.ResumeLayout(false);
			this.gbHccLocation.PerformLayout();
			this.pnDate.ResumeLayout(false);
			this.pnDate.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.pnSubBase.ResumeLayout(false);
			((ISupportInitialize)this.pnSiteChart).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000018 RID: 24
		private IContainer components = null;

		// Token: 0x04000019 RID: 25
		private Panel panel1;

		// Token: 0x0400001A RID: 26
		private Panel panel3;

		// Token: 0x0400001B RID: 27
		private SplitContainer splitContainer1;

		// Token: 0x0400001C RID: 28
		private Chart chart1;

		// Token: 0x0400001D RID: 29
		private Panel panel15;

		// Token: 0x0400001E RID: 30
		private Panel panel20;

		// Token: 0x0400001F RID: 31
		private Panel panel21;

		// Token: 0x04000020 RID: 32
		private Panel pbSubIndex;

		// Token: 0x04000021 RID: 33
		private Panel pnSubIndex2;

		// Token: 0x04000022 RID: 34
		private Panel panel2;

		// Token: 0x04000023 RID: 35
		private GroupBox gbHccLocation;

		// Token: 0x04000024 RID: 36
		private CheckBox cbDeviceSite;

		// Token: 0x04000025 RID: 37
		private TextBox tbLocation;

		// Token: 0x04000026 RID: 38
		private Panel pnDate;

		// Token: 0x04000027 RID: 39
		private Panel panel4;

		// Token: 0x04000028 RID: 40
		private Panel panel6;

		// Token: 0x04000029 RID: 41
		private DateTimePicker dtEndDate;

		// Token: 0x0400002A RID: 42
		private DateTimePicker dtStartDate;

		// Token: 0x0400002B RID: 43
		private Label label1;

		// Token: 0x0400002C RID: 44
		private Panel pnSubBase;

		// Token: 0x0400002D RID: 45
		private PictureBox pnSiteChart;
	}
}
