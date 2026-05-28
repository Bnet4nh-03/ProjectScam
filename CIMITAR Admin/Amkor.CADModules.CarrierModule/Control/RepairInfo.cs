using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Properties;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.CarrierModule.Control
{
	// Token: 0x02000029 RID: 41
	public class RepairInfo : UserControl
	{
		// Token: 0x06000072 RID: 114 RVA: 0x000056EA File Offset: 0x000038EA
		public RepairInfo()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00005724 File Offset: 0x00003924
		public RepairInfo(string sType)
		{
			this.sRepairType = sType;
			this.sRepairCode1 = string.Empty;
			this.sRepairCode2 = string.Empty;
			this.InitializeComponent();
			this.initRepairControl();
			this.Dock = DockStyle.Fill;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00005794 File Offset: 0x00003994
		private void initRepairControl()
		{
			this.gridRepairCode.ColumnsCount = 4;
			this.gridRepairCode.RowsCount = 1;
			this.gridRepairCode.FixedRows = 1;
			this.gridRepairCode.FixedColumns = 3;
			this.gridRepairCode[0, 0] = new GridInfo.ColHeader("No", false);
			this.gridRepairCode[0, 1] = new GridInfo.ColHeader("S1", false);
			this.gridRepairCode[0, 2] = new GridInfo.ColHeader("S2", false);
			this.gridRepairCode[0, 3] = new GridInfo.ColHeader("Code", false);
			this.gridRepairCode.Columns[0].Width = 25;
			this.gridRepairCode.Columns[1].Width = 25;
			this.gridRepairCode.Columns[2].Width = 25;
			this.gridInfo.SetColumnCellColor(this.gridRepairCode, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridSelectedCode.ColumnsCount = 4;
			this.gridSelectedCode.RowsCount = 1;
			this.gridSelectedCode.FixedRows = 1;
			this.gridSelectedCode.FixedColumns = 3;
			this.gridSelectedCode[0, 0] = new GridInfo.ColHeader("No", false);
			this.gridSelectedCode[0, 1] = new GridInfo.ColHeader("S1", false);
			this.gridSelectedCode[0, 2] = new GridInfo.ColHeader("S2", false);
			this.gridSelectedCode[0, 3] = new GridInfo.ColHeader("Code", false);
			this.gridSelectedCode.Columns[0].Width = 25;
			this.gridSelectedCode.Columns[1].Width = 25;
			this.gridSelectedCode.Columns[2].Width = 25;
			this.gridInfo.SetColumnCellColor(this.gridSelectedCode, 0, this.gridInfo.CellColor.cell_gray_center);
			if (this.sRepairType == "DefectStart")
			{
				this.gridRepairCode.Columns[1].Visible = false;
				this.gridRepairCode.Columns[2].Visible = false;
				this.gridSelectedCode.Columns[1].Visible = false;
				this.gridSelectedCode.Columns[2].Visible = false;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00005A04 File Offset: 0x00003C04
		public void setRepairCode()
		{
			this.sRepairCode1 = string.Empty;
			this.sRepairCode2 = string.Empty;
			if (this.gridSelectedCode.RowsCount > 1)
			{
				for (int i = 1; i < this.gridSelectedCode.RowsCount; i++)
				{
					if ((bool)this.gridSelectedCode[i, 1].Value)
					{
						this.sRepairCode1 = this.sRepairCode1 + this.gridSelectedCode[i, 3].ToString() + ",";
					}
					if ((bool)this.gridSelectedCode[i, 2].Value)
					{
						this.sRepairCode2 = this.sRepairCode2 + this.gridSelectedCode[i, 3].ToString() + ",";
					}
				}
			}
			if (this.sRepairCode1 != string.Empty)
			{
				this.sRepairCode1 = this.sRepairCode1.Substring(0, this.sRepairCode1.Length - 1);
			}
			if (this.sRepairCode2 != string.Empty)
			{
				this.sRepairCode2 = this.sRepairCode2.Substring(0, this.sRepairCode2.Length - 1);
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00005B38 File Offset: 0x00003D38
		public string setDefectCode()
		{
			this.sRepairCode1 = string.Empty;
			if (this.gridSelectedCode.RowsCount > 1)
			{
				for (int i = 1; i < this.gridSelectedCode.RowsCount; i++)
				{
					this.sRepairCode1 = this.sRepairCode1 + this.gridSelectedCode[i, 3].ToString() + ",";
				}
			}
			if (this.sRepairCode1 != string.Empty)
			{
				this.sRepairCode1 = this.sRepairCode1.Substring(0, this.sRepairCode1.Length - 1);
			}
			return this.sRepairCode1;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00005BD4 File Offset: 0x00003DD4
		public string setDefectActionCode()
		{
			this.sRepairCode2 = string.Empty;
			if (this.gridSelectedCode.RowsCount > 1)
			{
				for (int i = 1; i < this.gridSelectedCode.RowsCount; i++)
				{
					this.sRepairCode2 = this.sRepairCode2 + this.gridSelectedCode[i, 3].ToString() + ",";
				}
			}
			if (this.sRepairCode2 != string.Empty)
			{
				this.sRepairCode2 = this.sRepairCode2.Substring(0, this.sRepairCode2.Length - 1);
			}
			return this.sRepairCode2;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00005C70 File Offset: 0x00003E70
		private void cmdRight_Click(object sender, EventArgs e)
		{
			RangeRegion rangeRegion = new RangeRegion();
			rangeRegion = this.gridRepairCode.Selection.GetSelectionRegion();
			for (int i = 0; i < rangeRegion.Count; i++)
			{
				for (int j = 0; j < rangeRegion[i].RowsCount; j++)
				{
					int row = rangeRegion[i].Start.Row + j;
					bool flag = true;
					for (int k = 0; k < this.gridSelectedCode.RowsCount; k++)
					{
						if (this.gridSelectedCode[k, 3].ToString() == this.gridRepairCode[row, 3].ToString())
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						this.gridSelectedCode.Rows.Insert(this.gridSelectedCode.RowsCount);
						this.gridSelectedCode[this.gridSelectedCode.RowsCount - 1, 0] = new Cell((this.gridSelectedCode.RowsCount - 1).ToString());
						this.gridSelectedCode[this.gridSelectedCode.RowsCount - 1, 1] = new SourceGrid.Cells.CheckBox(null, new bool?((bool)this.gridRepairCode[row, 1].Value));
						this.gridSelectedCode[this.gridSelectedCode.RowsCount - 1, 2] = new SourceGrid.Cells.CheckBox(null, new bool?((bool)this.gridRepairCode[row, 2].Value));
						this.gridSelectedCode[this.gridSelectedCode.RowsCount - 1, 3] = new Cell(this.gridRepairCode[row, 3].ToString());
						this.gridRepairCode[row, 3].View = this.gridInfo.CellColor.cell_back_yellow;
					}
				}
			}
			this.gridInfo.AutoSetGrid(this.gridSelectedCode);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00005E6C File Offset: 0x0000406C
		private void gridRepairCode_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.gridRepairCode.Selection.ActivePosition.Row > 0)
			{
				int row = this.gridRepairCode.Selection.ActivePosition.Row;
				int column = this.gridRepairCode.Selection.ActivePosition.Column;
				bool flag = true;
				for (int i = 0; i < this.gridSelectedCode.RowsCount; i++)
				{
					if (this.gridSelectedCode[i, 3].ToString() == this.gridRepairCode[row, 3].ToString())
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					this.gridSelectedCode.Rows.Insert(this.gridSelectedCode.RowsCount);
					this.gridSelectedCode[this.gridSelectedCode.RowsCount - 1, 0] = new Cell((this.gridSelectedCode.RowsCount - 1).ToString());
					this.gridSelectedCode[this.gridSelectedCode.RowsCount - 1, 1] = new SourceGrid.Cells.CheckBox(null, new bool?((bool)this.gridRepairCode[row, 1].Value));
					this.gridSelectedCode[this.gridSelectedCode.RowsCount - 1, 2] = new SourceGrid.Cells.CheckBox(null, new bool?((bool)this.gridRepairCode[row, 2].Value));
					this.gridSelectedCode[this.gridSelectedCode.RowsCount - 1, 3] = new Cell(this.gridRepairCode[row, 3].ToString());
					this.gridRepairCode[row, 3].View = this.gridInfo.CellColor.cell_back_yellow;
				}
				this.gridInfo.AutoSetGrid(this.gridSelectedCode);
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00006044 File Offset: 0x00004244
		private void gridSelectedCode_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.gridSelectedCode.Selection.ActivePosition.Row > 0)
			{
				int row = this.gridSelectedCode.Selection.ActivePosition.Row;
				int column = this.gridSelectedCode.Selection.ActivePosition.Column;
				for (int i = 0; i < this.gridRepairCode.Rows.Count; i++)
				{
					if (this.gridRepairCode[i, 3].ToString() == this.gridSelectedCode[row, 3].ToString())
					{
						this.gridRepairCode[i, 3].View = this.gridInfo.CellColor.cell_back_white;
					}
				}
				this.gridSelectedCode.Rows.Remove(row);
				this.gridInfo.AutoSetGrid(this.gridRepairCode);
				this.gridInfo.AutoSetGrid(this.gridSelectedCode);
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00006140 File Offset: 0x00004340
		public void getRepairCode(string sCode)
		{
			this.gridSelectedCode.RowsCount = 1;
			this.gridRepairCode.Selection.ResetSelection(false);
			for (int i = 1; i < this.gridRepairCode.Rows.Count; i++)
			{
				this.gridRepairCode[i, 3].View = this.gridInfo.CellColor.cell_back_white;
			}
			if (sCode != null && sCode != string.Empty)
			{
				string[] array = sCode.Split(new char[]
				{
					','
				});
				for (int j = 0; j < array.Length; j++)
				{
					for (int k = 0; k < this.gridRepairCode.Rows.Count; k++)
					{
						if (this.gridRepairCode[k, 3].ToString().ToUpper() == array[j].ToUpper())
						{
							this.gridRepairCode[k, 1] = new SourceGrid.Cells.CheckBox(null, new bool?(true));
							this.gridRepairCode.Selection.SelectRow(k, true);
							break;
						}
					}
				}
			}
			this.cmdRight_Click(null, null);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00006258 File Offset: 0x00004458
		public void getLastRepairCode(DataSet ds)
		{
			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				int j = 0;
				while (j < this.gridRepairCode.Rows.Count)
				{
					if (this.gridRepairCode[j, 3].ToString().ToUpper() == ds.Tables[0].Rows[i]["repaircode"].ToString().ToUpper())
					{
						if (ds.Tables[0].Rows[i]["site"].ToString() == "1")
						{
							this.gridRepairCode[j, 1] = new SourceGrid.Cells.CheckBox(null, new bool?(true));
							this.gridRepairCode.Selection.SelectRow(j, true);
							break;
						}
						if (ds.Tables[0].Rows[i]["site"].ToString() == "2")
						{
							this.gridRepairCode[j, 2] = new SourceGrid.Cells.CheckBox(null, new bool?(true));
							this.gridRepairCode.Selection.SelectRow(j, true);
							break;
						}
						break;
					}
					else
					{
						j++;
					}
				}
			}
			this.cmdRight_Click(null, null);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000063C0 File Offset: 0x000045C0
		public void InitRepairData(DataSet dsReasonCode, string sString, bool bClear)
		{
			this.gridRepairCode.RowsCount = 1;
			if (bClear)
			{
				this.gridSelectedCode.RowsCount = 1;
			}
			string filterExpression = "[description] like '%" + sString + "%'";
			if (dsReasonCode.Tables.Count > 0 && dsReasonCode.Tables[0].Rows.Count > 0)
			{
				DataRow[] array = dsReasonCode.Tables[0].Select(filterExpression);
				for (int i = 0; i < array.Length; i++)
				{
					bool flag = false;
					for (int j = 0; j < this.gridSelectedCode.RowsCount; j++)
					{
						if (this.gridSelectedCode[j, 3].ToString() == array[i]["description"].ToString())
						{
							flag = true;
							break;
						}
					}
					this.gridRepairCode.Rows.Insert(this.gridRepairCode.RowsCount);
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 0] = new Cell((this.gridRepairCode.RowsCount - 1).ToString());
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 1] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 2] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 3] = new Cell(array[i]["description"].ToString());
					if (flag)
					{
						this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 3].View = this.gridInfo.CellColor.cell_back_yellow;
					}
				}
				this.gridInfo.AutoSetGrid(this.gridRepairCode);
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000065A6 File Offset: 0x000047A6
		public void InitData()
		{
			this.gridRepairCode.RowsCount = 1;
			this.gridSelectedCode.RowsCount = 1;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000065C0 File Offset: 0x000047C0
		private void cmdRight_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdRight.Image = Resources.ArrowRight;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000065DD File Offset: 0x000047DD
		private void cmdRight_MouseLeave(object sender, EventArgs e)
		{
			this.cmdRight.Image = Resources.ArrowRight;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000065FA File Offset: 0x000047FA
		private void cmdRight_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdRight.Image = Resources.ArrowRight_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00006617 File Offset: 0x00004817
		private void cmdRight_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00006624 File Offset: 0x00004824
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00006644 File Offset: 0x00004844
		private void InitializeComponent()
		{
			this.panelRepairReason = new Panel();
			this.panel12 = new Panel();
			this.gridSelectedCode = new Grid();
			this.panel11 = new Panel();
			this.cmdRight = new PictureBox();
			this.panel7 = new Panel();
			this.gridRepairCode = new Grid();
			this.panelRepairReason.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel11.SuspendLayout();
			((ISupportInitialize)this.cmdRight).BeginInit();
			this.panel7.SuspendLayout();
			base.SuspendLayout();
			this.panelRepairReason.Controls.Add(this.panel12);
			this.panelRepairReason.Controls.Add(this.panel11);
			this.panelRepairReason.Controls.Add(this.panel7);
			this.panelRepairReason.Dock = DockStyle.Fill;
			this.panelRepairReason.Location = new Point(0, 0);
			this.panelRepairReason.Name = "panelRepairReason";
			this.panelRepairReason.Size = new Size(638, 167);
			this.panelRepairReason.TabIndex = 90;
			this.panel12.Controls.Add(this.gridSelectedCode);
			this.panel12.Dock = DockStyle.Fill;
			this.panel12.Location = new Point(364, 0);
			this.panel12.Name = "panel12";
			this.panel12.Size = new Size(274, 167);
			this.panel12.TabIndex = 91;
			this.gridSelectedCode.ClipboardMode = ClipboardMode.Copy;
			this.gridSelectedCode.Dock = DockStyle.Fill;
			this.gridSelectedCode.EnableSort = true;
			this.gridSelectedCode.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.gridSelectedCode.Location = new Point(0, 0);
			this.gridSelectedCode.Margin = new Padding(3, 4, 3, 4);
			this.gridSelectedCode.Name = "gridSelectedCode";
			this.gridSelectedCode.OptimizeMode = CellOptimizeMode.ForRows;
			this.gridSelectedCode.SelectionMode = GridSelectionMode.Cell;
			this.gridSelectedCode.Size = new Size(274, 167);
			this.gridSelectedCode.TabIndex = 14;
			this.gridSelectedCode.TabStop = true;
			this.gridSelectedCode.ToolTipText = "";
			this.gridSelectedCode.MouseDoubleClick += this.gridSelectedCode_MouseDoubleClick;
			this.panel11.Controls.Add(this.cmdRight);
			this.panel11.Dock = DockStyle.Left;
			this.panel11.Location = new Point(319, 0);
			this.panel11.Name = "panel11";
			this.panel11.Size = new Size(45, 167);
			this.panel11.TabIndex = 90;
			this.cmdRight.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
			this.cmdRight.Image = Resources.ArrowRight;
			this.cmdRight.Location = new Point(1, 37);
			this.cmdRight.Name = "cmdRight";
			this.cmdRight.Size = new Size(42, 42);
			this.cmdRight.SizeMode = PictureBoxSizeMode.StretchImage;
			this.cmdRight.TabIndex = 29;
			this.cmdRight.TabStop = false;
			this.cmdRight.Click += this.cmdRight_Click;
			this.cmdRight.MouseDown += this.cmdRight_MouseDown;
			this.cmdRight.MouseLeave += this.cmdRight_MouseLeave;
			this.cmdRight.MouseMove += this.cmdRight_MouseMove;
			this.cmdRight.MouseUp += this.cmdRight_MouseUp;
			this.panel7.Controls.Add(this.gridRepairCode);
			this.panel7.Dock = DockStyle.Left;
			this.panel7.Location = new Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new Size(319, 167);
			this.panel7.TabIndex = 89;
			this.gridRepairCode.ClipboardMode = ClipboardMode.Copy;
			this.gridRepairCode.Dock = DockStyle.Fill;
			this.gridRepairCode.EnableSort = true;
			this.gridRepairCode.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.gridRepairCode.Location = new Point(0, 0);
			this.gridRepairCode.Margin = new Padding(3, 4, 3, 4);
			this.gridRepairCode.Name = "gridRepairCode";
			this.gridRepairCode.OptimizeMode = CellOptimizeMode.ForRows;
			this.gridRepairCode.SelectionMode = GridSelectionMode.Row;
			this.gridRepairCode.Size = new Size(319, 167);
			this.gridRepairCode.TabIndex = 15;
			this.gridRepairCode.TabStop = true;
			this.gridRepairCode.ToolTipText = "";
			this.gridRepairCode.MouseDoubleClick += this.gridRepairCode_MouseDoubleClick;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panelRepairReason);
			base.Name = "RepairInfo";
			base.Size = new Size(638, 167);
			this.panelRepairReason.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			((ISupportInitialize)this.cmdRight).EndInit();
			this.panel7.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000158 RID: 344
		public string sRepairCode1 = string.Empty;

		// Token: 0x04000159 RID: 345
		public string sRepairCode2 = string.Empty;

		// Token: 0x0400015A RID: 346
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x0400015B RID: 347
		private string sRepairType = string.Empty;

		// Token: 0x0400015C RID: 348
		private IContainer components;

		// Token: 0x0400015D RID: 349
		private Panel panelRepairReason;

		// Token: 0x0400015E RID: 350
		private Panel panel12;

		// Token: 0x0400015F RID: 351
		private Grid gridSelectedCode;

		// Token: 0x04000160 RID: 352
		private Panel panel11;

		// Token: 0x04000161 RID: 353
		private PictureBox cmdRight;

		// Token: 0x04000162 RID: 354
		private Panel panel7;

		// Token: 0x04000163 RID: 355
		private Grid gridRepairCode;
	}
}
