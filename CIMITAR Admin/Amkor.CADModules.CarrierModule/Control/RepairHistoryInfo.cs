using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.CarrierModule.Control
{
	// Token: 0x02000028 RID: 40
	public class RepairHistoryInfo : UserControl
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00005154 File Offset: 0x00003354
		public RepairHistoryInfo()
		{
			this.InitializeComponent();
			this.initRepairHistoryControl();
			this.Dock = DockStyle.Fill;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000517C File Offset: 0x0000337C
		private void initRepairHistoryControl()
		{
			this.gridRepairHistoryList.ColumnsCount = 6;
			this.gridRepairHistoryList.RowsCount = 1;
			this.gridRepairHistoryList.FixedRows = 1;
			this.gridRepairHistoryList.FixedColumns = 6;
			this.gridRepairHistoryList[0, 0] = new GridInfo.ColHeader("Status", false);
			this.gridRepairHistoryList[0, 1] = new GridInfo.ColHeader("Blacklist Cause", false);
			this.gridRepairHistoryList[0, 2] = new GridInfo.ColHeader("Date", false);
			this.gridRepairHistoryList[0, 3] = new GridInfo.ColHeader("RepairCode_site1", false);
			this.gridRepairHistoryList[0, 4] = new GridInfo.ColHeader("RepairCode_site2", false);
			this.gridRepairHistoryList[0, 5] = new GridInfo.ColHeader("memo", false);
			this.gridRepairHistoryList.Columns[0].Width = 65;
			this.gridRepairHistoryList.Columns[1].Width = 140;
			this.gridRepairHistoryList.Columns[2].Width = 130;
			this.gridRepairHistoryList.Columns[3].Width = 100;
			this.gridRepairHistoryList.Columns[4].Width = 100;
			this.gridRepairHistoryList.Columns[5].Width = 200;
			this.gridInfo.SetColumnCellColor(this.gridRepairHistoryList, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00005304 File Offset: 0x00003504
		public void setGridRepairHistory(CarrierInfo carrier, QueryMgr queryMgr)
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierRepairHistory] @location = '" + carrier.Barcode + "'";
			string cellValue = string.Empty;
			DataSet dataSet = queryMgr.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.gridRepairHistoryList.Rows.Insert(this.gridRepairHistoryList.RowsCount);
					this.gridRepairHistoryList[i + 1, 0] = new Cell(dataSet.Tables[0].Rows[i]["status"].ToString());
					cellValue = "Site 1 : " + dataSet.Tables[0].Rows[i]["blacklistcause"].ToString() + ", Site 2 : " + dataSet.Tables[0].Rows[i]["blacklistcause1"].ToString();
					this.gridRepairHistoryList[i + 1, 1] = new Cell(cellValue);
					this.gridRepairHistoryList[i + 1, 2] = new Cell(dataSet.Tables[0].Rows[i]["lasteventtime"].ToString());
					this.gridRepairHistoryList[i + 1, 3] = new Cell(dataSet.Tables[0].Rows[i]["repaircode"].ToString());
					this.gridRepairHistoryList[i + 1, 4] = new Cell(dataSet.Tables[0].Rows[i]["repaircode1"].ToString());
					this.gridRepairHistoryList[i + 1, 5] = new Cell(dataSet.Tables[0].Rows[i]["memo"].ToString());
				}
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00005537 File Offset: 0x00003737
		private void gridRepairHistoryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005539 File Offset: 0x00003739
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00005558 File Offset: 0x00003758
		private void InitializeComponent()
		{
			this.panel1 = new Panel();
			this.gridRepairHistoryList = new Grid();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.gridRepairHistoryList);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(548, 313);
			this.panel1.TabIndex = 0;
			this.gridRepairHistoryList.Dock = DockStyle.Fill;
			this.gridRepairHistoryList.EnableSort = true;
			this.gridRepairHistoryList.Location = new Point(0, 0);
			this.gridRepairHistoryList.Name = "gridRepairHistoryList";
			this.gridRepairHistoryList.OptimizeMode = CellOptimizeMode.ForRows;
			this.gridRepairHistoryList.SelectionMode = GridSelectionMode.Cell;
			this.gridRepairHistoryList.Size = new Size(548, 313);
			this.gridRepairHistoryList.TabIndex = 0;
			this.gridRepairHistoryList.TabStop = true;
			this.gridRepairHistoryList.ToolTipText = "";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.panel1);
			base.Name = "RepairHistoryInfo";
			base.Size = new Size(548, 313);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000154 RID: 340
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x04000155 RID: 341
		private IContainer components;

		// Token: 0x04000156 RID: 342
		private Panel panel1;

		// Token: 0x04000157 RID: 343
		private Grid gridRepairHistoryList;
	}
}
