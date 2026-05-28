using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x02000045 RID: 69
	public class ActionCustConfirmation : UserControl
	{
		// Token: 0x060003ED RID: 1005 RVA: 0x00074E5D File Offset: 0x0007305D
		public ActionCustConfirmation(cReportItem report)
		{
			this.InitializeComponent();
			this.InitializeGrid(report);
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00074E80 File Offset: 0x00073080
		private void InitializeGrid(cReportItem report)
		{
			DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			DataGridViewCheckBoxColumn dataGridViewColumn = new DataGridViewCheckBoxColumn();
			DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
			Font font = new Font("Segoe UI", 12f, FontStyle.Bold);
			dataGridViewCheckBoxColumn.FillWeight = 100f;
			this.dataGrid_confirm.MultiSelect = false;
			this.dataGrid_confirm.AutoSize = true;
			this.dataGrid_confirm.AutoGenerateColumns = false;
			this.dataGrid_confirm.Columns.Add("", "");
			this.dataGrid_confirm.Columns.Add(dataGridViewCheckBoxColumn);
			this.dataGrid_confirm.Columns.Add(dataGridViewColumn);
			this.dataGrid_confirm.Columns.Add("", "");
			bool flag = report.sFactory == "K5" && report.sModel.ToUpper() == "BOARD";
			if (flag)
			{
				this.dataGrid_confirm.Columns[0].HeaderText = "P/C VISUAL INSPECTION CHECK ITEM";
				this.dataGrid_confirm.Columns[1].HeaderText = "작업자";
				this.dataGrid_confirm.Columns[2].HeaderText = "검수자";
				this.dataGrid_confirm.Columns[3].HeaderText = "COMMENT";
			}
			else
			{
				this.dataGrid_confirm.Columns[0].HeaderText = "CHECK ITEM";
				this.dataGrid_confirm.Columns[1].HeaderText = "YES";
				this.dataGrid_confirm.Columns[2].HeaderText = "NO";
				this.dataGrid_confirm.Columns[3].HeaderText = "COMMENT";
			}
			this.dataGrid_confirm.Columns[0].ReadOnly = true;
			this.dataGrid_confirm.Columns[1].ReadOnly = true;
			this.dataGrid_confirm.Columns[2].ReadOnly = true;
			this.dataGrid_confirm.Columns[3].ReadOnly = true;
			for (int i = 0; i < this.dataGrid_confirm.ColumnCount; i++)
			{
				this.dataGrid_confirm.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				this.dataGrid_confirm.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
				this.dataGrid_confirm.Columns[i].HeaderCell.Style.Font = font;
				this.dataGrid_confirm.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
				this.dataGrid_confirm.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
			bool flag2 = report.sModel.ToUpper() == "BOARD";
			if (flag2)
			{
				this.dataGrid_confirm.ColumnHeadersHeight = 150;
				this.dataGrid_confirm.Columns[0].Width = 300;
				this.dataGrid_confirm.Columns[1].Width = 70;
				this.dataGrid_confirm.Columns[2].Width = 70;
			}
			else
			{
				this.dataGrid_confirm.RowCount = cConst.CustContents.Count;
				this.dataGrid_confirm.RowCount = this.dataGrid_confirm.RowCount + 1;
				this.dataGrid_confirm.Columns[0].Width = 630;
				this.dataGrid_confirm.Columns[1].Width = 50;
				this.dataGrid_confirm.Columns[2].Width = 50;
			}
			this.dataGrid_confirm.Columns[3].Width = 400;
			this.dataGrid_confirm.RowHeadersWidth = 65;
			for (int j = 0; j < this.dataGrid_confirm.RowCount; j++)
			{
				this.dataGrid_confirm.Rows[j].Height = 45;
				bool flag3 = j >= 1;
				if (flag3)
				{
					this.dataGrid_confirm.Rows[j].HeaderCell.Value = j.ToString();
					this.dataGrid_confirm.Rows[j].HeaderCell.Style.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
					this.dataGrid_confirm.Rows[j].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
					bool flag4 = report.sModel.ToUpper() == "BOARD";
					if (flag4)
					{
					}
				}
				else
				{
					this.dataGrid_confirm.Rows[j].Cells[0].Style.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
					this.dataGrid_confirm.Rows[j].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGrid_confirm.Rows[j].Cells[0].Value = "ST WI#";
					this.dataGrid_confirm.Rows[j].Cells[0].Style.BackColor = Color.SkyBlue;
					this.dataGrid_confirm.Rows[j].Cells[1].Style.BackColor = Color.SkyBlue;
					this.dataGrid_confirm.Rows[j].Cells[2].Style.BackColor = Color.SkyBlue;
					this.dataGrid_confirm.Rows[j].Cells[3].Style.BackColor = Color.SkyBlue;
				}
				this.dataGrid_confirm.Rows[j].Cells[1].Style.BackColor = Color.White;
				this.dataGrid_confirm.Rows[j].Cells[2].Style.BackColor = Color.White;
				this.dataGrid_confirm.Rows[j].Cells[3].Style.WrapMode = DataGridViewTriState.True;
				this.dataGrid_confirm.Rows[j].Cells[3].Style.Alignment = DataGridViewContentAlignment.TopLeft;
			}
			int num = 0;
			foreach (KeyValuePair<int, string> keyValuePair in cConst.listContents)
			{
				bool flag5 = report.sFactory == "K5" && report.sModel.ToUpper() == "BOARD";
				if (flag5)
				{
					this.dataGrid_confirm.Rows[num].Cells[1].Value = true;
					this.dataGrid_confirm.Rows[num].Cells[2].Value = true;
					this.dataGrid_confirm.Rows[num].Cells[3].Value = report.listDetails[keyValuePair.Key - 1];
				}
				else
				{
					bool flag6 = this.dataGrid_confirm.Rows.Count > 2;
					if (flag6)
					{
						this.dataGrid_confirm.Rows[num].Cells[3].Value = report.listDetails[keyValuePair.Key - 1];
						bool flag7 = string.IsNullOrEmpty(report.listDetails[keyValuePair.Key - 1]);
						if (flag7)
						{
							this.dataGrid_confirm.Rows[num].Cells[1].Value = false;
							this.dataGrid_confirm.Rows[num].Cells[2].Value = true;
						}
						else
						{
							this.dataGrid_confirm.Rows[num].Cells[1].Value = true;
							this.dataGrid_confirm.Rows[num].Cells[2].Value = false;
						}
					}
				}
				num++;
			}
			this.dataGrid_confirm.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
			this.dataGrid_confirm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGrid_confirm.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			this.dataGrid_confirm.Refresh();
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00075808 File Offset: 0x00073A08
		private void dataGrid_confirm_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			bool flag = e.RowIndex != 0;
			if (!flag)
			{
				e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
				e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00075840 File Offset: 0x00073A40
		private void dataGrid_confirm_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			bool flag = e.RowIndex == 0;
			if (flag)
			{
				DataGridViewCell dataGridViewCell = this.dataGrid_confirm.Rows[e.RowIndex].Cells[1];
				DataGridViewCheckBoxCell dataGridViewCheckBoxCell = dataGridViewCell as DataGridViewCheckBoxCell;
				dataGridViewCheckBoxCell.Value = false;
				dataGridViewCheckBoxCell.FlatStyle = FlatStyle.Flat;
				dataGridViewCheckBoxCell.Style.BackColor = Color.SkyBlue;
				dataGridViewCheckBoxCell.Style.ForeColor = Color.SkyBlue;
				dataGridViewCheckBoxCell.Style.SelectionBackColor = Color.SkyBlue;
				dataGridViewCheckBoxCell.Style.SelectionForeColor = Color.SkyBlue;
				dataGridViewCheckBoxCell.ReadOnly = true;
				dataGridViewCell.ReadOnly = true;
				dataGridViewCell = this.dataGrid_confirm.Rows[e.RowIndex].Cells[2];
				dataGridViewCheckBoxCell = (dataGridViewCell as DataGridViewCheckBoxCell);
				dataGridViewCheckBoxCell.Value = false;
				dataGridViewCheckBoxCell.FlatStyle = FlatStyle.Flat;
				dataGridViewCheckBoxCell.Style.BackColor = Color.SkyBlue;
				dataGridViewCheckBoxCell.Style.ForeColor = Color.SkyBlue;
				dataGridViewCheckBoxCell.Style.SelectionBackColor = Color.SkyBlue;
				dataGridViewCheckBoxCell.Style.SelectionForeColor = Color.SkyBlue;
				dataGridViewCheckBoxCell.ReadOnly = true;
				dataGridViewCell.ReadOnly = true;
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00075984 File Offset: 0x00073B84
		private void dataGrid_confirm_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = e.RowIndex == 0 && e.ColumnIndex != -1;
			if (flag)
			{
				this.dataGrid_confirm.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
				this.dataGrid_confirm.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00075A0C File Offset: 0x00073C0C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00075A44 File Offset: 0x00073C44
		private void InitializeComponent()
		{
			this.panel1 = new Panel();
			this.dataGrid_confirm = new DataGridView();
			this.panel1.SuspendLayout();
			((ISupportInitialize)this.dataGrid_confirm).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.dataGrid_confirm);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(857, 345);
			this.panel1.TabIndex = 0;
			this.dataGrid_confirm.AllowUserToAddRows = false;
			this.dataGrid_confirm.AllowUserToDeleteRows = false;
			this.dataGrid_confirm.AllowUserToResizeColumns = false;
			this.dataGrid_confirm.AllowUserToResizeRows = false;
			this.dataGrid_confirm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid_confirm.Dock = DockStyle.Fill;
			this.dataGrid_confirm.Location = new Point(0, 0);
			this.dataGrid_confirm.Name = "dataGrid_confirm";
			this.dataGrid_confirm.RowTemplate.Height = 23;
			this.dataGrid_confirm.Size = new Size(857, 345);
			this.dataGrid_confirm.TabIndex = 6;
			this.dataGrid_confirm.CellClick += this.dataGrid_confirm_CellClick;
			this.dataGrid_confirm.CellPainting += this.dataGrid_confirm_CellPainting;
			this.dataGrid_confirm.RowPostPaint += this.dataGrid_confirm_RowPostPaint;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel1);
			base.Name = "ActionCustConfirmation";
			base.Size = new Size(857, 345);
			this.panel1.ResumeLayout(false);
			((ISupportInitialize)this.dataGrid_confirm).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000636 RID: 1590
		private IContainer components = null;

		// Token: 0x04000637 RID: 1591
		private Panel panel1;

		// Token: 0x04000638 RID: 1592
		private DataGridView dataGrid_confirm;
	}
}
