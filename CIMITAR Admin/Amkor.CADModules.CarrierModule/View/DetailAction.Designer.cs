namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000043 RID: 67
	public partial class DetailAction : global::System.Windows.Forms.Form
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x0004C239 File Offset: 0x0004A439
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0004C258 File Offset: 0x0004A458
		private void InitializeComponent()
		{
			global::System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new global::System.Windows.Forms.DataVisualization.Charting.ChartArea();
			global::System.Windows.Forms.DataVisualization.Charting.Legend legend = new global::System.Windows.Forms.DataVisualization.Charting.Legend();
			global::System.Windows.Forms.DataVisualization.Charting.Title title = new global::System.Windows.Forms.DataVisualization.Charting.Title();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.CarrierModule.View.DetailAction));
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.chart_CarrierView = new global::System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.cmdExcel = new global::System.Windows.Forms.PictureBox();
			this.cmdApply = new global::System.Windows.Forms.PictureBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.gridActionList = new global::SourceGrid.Grid();
			this.splitter1 = new global::System.Windows.Forms.Splitter();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.chart_CarrierView).BeginInit();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdExcel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).BeginInit();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(1058, 44);
			this.panel24.TabIndex = 18;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(70, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Action";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.label13);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 529);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(1058, 32);
			this.panel25.TabIndex = 27;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(405, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(238, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2015 Amkor Technology Korea";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel1.Controls.Add(this.chart_CarrierView);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 44);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(638, 440);
			this.panel1.TabIndex = 29;
			this.chart_CarrierView.BackGradientStyle = global::System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chart_CarrierView.BackSecondaryColor = global::System.Drawing.Color.White;
			this.chart_CarrierView.BorderlineColor = global::System.Drawing.Color.Silver;
			this.chart_CarrierView.BorderlineDashStyle = global::System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea.Area3DStyle.Inclination = 5;
			chartArea.Area3DStyle.IsClustered = true;
			chartArea.Area3DStyle.Rotation = 0;
			chartArea.Area3DStyle.WallWidth = 0;
			chartArea.AxisX.LineColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea.AxisX.Maximum = 100.0;
			chartArea.AxisY.IsLabelAutoFit = false;
			chartArea.AxisY.LabelStyle.Font = new global::System.Drawing.Font("Arial", 8f);
			chartArea.AxisY.LineColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea.AxisY.Maximum = 100.0;
			chartArea.AxisY.MaximumAutoSize = 100f;
			chartArea.AxisY.Minimum = 0.0;
			chartArea.BackColor = global::System.Drawing.Color.White;
			chartArea.BackSecondaryColor = global::System.Drawing.Color.White;
			chartArea.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea.BorderDashStyle = global::System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea.Name = "ChartArea1";
			chartArea.ShadowColor = global::System.Drawing.Color.Transparent;
			this.chart_CarrierView.ChartAreas.Add(chartArea);
			this.chart_CarrierView.Dock = global::System.Windows.Forms.DockStyle.Fill;
			legend.Alignment = global::System.Drawing.StringAlignment.Center;
			legend.BackColor = global::System.Drawing.Color.Transparent;
			legend.BorderColor = global::System.Drawing.Color.Transparent;
			legend.Docking = global::System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			legend.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			legend.IsTextAutoFit = false;
			legend.Name = "Legend1";
			this.chart_CarrierView.Legends.Add(legend);
			this.chart_CarrierView.Location = new global::System.Drawing.Point(0, 0);
			this.chart_CarrierView.Name = "chart_CarrierView";
			this.chart_CarrierView.Size = new global::System.Drawing.Size(638, 440);
			this.chart_CarrierView.TabIndex = 148;
			this.chart_CarrierView.Text = "chart_Tester";
			title.BackColor = global::System.Drawing.Color.Transparent;
			title.BackImageAlignment = global::System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
			title.BackImageWrapMode = global::System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
			title.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			title.Name = "Title1";
			title.ShadowColor = global::System.Drawing.Color.Silver;
			title.Text = "Action";
			this.chart_CarrierView.Titles.Add(title);
			this.panel2.Controls.Add(this.cmdExcel);
			this.panel2.Controls.Add(this.cmdApply);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 484);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1058, 45);
			this.panel2.TabIndex = 30;
			this.cmdExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdExcel.Image");
			this.cmdExcel.Location = new global::System.Drawing.Point(12, 7);
			this.cmdExcel.Name = "cmdExcel";
			this.cmdExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdExcel.TabIndex = 81;
			this.cmdExcel.TabStop = false;
			this.cmdExcel.Click += new global::System.EventHandler(this.cmdExcel_Click);
			this.cmdExcel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseDown);
			this.cmdExcel.MouseLeave += new global::System.EventHandler(this.cmdExcel_MouseLeave);
			this.cmdExcel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseMove);
			this.cmdExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseUp);
			this.cmdApply.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdApply.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdApply.Location = new global::System.Drawing.Point(1014, 7);
			this.cmdApply.Name = "cmdApply";
			this.cmdApply.Size = new global::System.Drawing.Size(32, 32);
			this.cmdApply.TabIndex = 26;
			this.cmdApply.TabStop = false;
			this.cmdApply.Click += new global::System.EventHandler(this.cmdApply_Click);
			this.cmdApply.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseDown);
			this.cmdApply.MouseLeave += new global::System.EventHandler(this.cmdApply_MouseLeave);
			this.cmdApply.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseMove);
			this.cmdApply.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseUp);
			this.panel3.Controls.Add(this.gridActionList);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new global::System.Drawing.Point(642, 44);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(416, 440);
			this.panel3.TabIndex = 31;
			this.gridActionList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridActionList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridActionList.EnableSort = true;
			this.gridActionList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridActionList.Location = new global::System.Drawing.Point(0, 0);
			this.gridActionList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridActionList.Name = "gridActionList";
			this.gridActionList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridActionList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridActionList.Size = new global::System.Drawing.Size(416, 440);
			this.gridActionList.TabIndex = 28;
			this.gridActionList.TabStop = true;
			this.gridActionList.ToolTipText = "";
			this.splitter1.BackColor = global::System.Drawing.SystemColors.Control;
			this.splitter1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new global::System.Drawing.Point(638, 44);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new global::System.Drawing.Size(4, 440);
			this.splitter1.TabIndex = 32;
			this.splitter1.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1058, 561);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.splitter1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "DetailAction";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Detail Action";
			base.Load += new global::System.EventHandler(this.DetailAction_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.chart_CarrierView).EndInit();
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdExcel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).EndInit();
			this.panel3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000501 RID: 1281
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000502 RID: 1282
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x04000503 RID: 1283
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x04000504 RID: 1284
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000505 RID: 1285
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000506 RID: 1286
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000507 RID: 1287
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000508 RID: 1288
		private global::System.Windows.Forms.PictureBox cmdApply;

		// Token: 0x04000509 RID: 1289
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400050A RID: 1290
		private global::SourceGrid.Grid gridActionList;

		// Token: 0x0400050B RID: 1291
		private global::System.Windows.Forms.DataVisualization.Charting.Chart chart_CarrierView;

		// Token: 0x0400050C RID: 1292
		private global::System.Windows.Forms.Splitter splitter1;

		// Token: 0x0400050D RID: 1293
		private global::System.Windows.Forms.PictureBox cmdExcel;

		// Token: 0x0400050E RID: 1294
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;
	}
}
