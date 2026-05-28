using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x02000043 RID: 67
	public class ActionConfirmation : UserControl
	{
		// Token: 0x060003E6 RID: 998 RVA: 0x00073DE8 File Offset: 0x00071FE8
		public ActionConfirmation(FactorySettings factorySettings, cReportItem report, HCC hCC)
		{
			this._hCC = hCC;
			bool flag = report.sCategory == this._hCC.Name;
			if (flag)
			{
				cConst.initContents(factorySettings, report.sFactory, report.sModel);
			}
			else
			{
				cConst.initContents(factorySettings, report.sFactory, report.sCategory);
			}
			this.InitializeComponent();
			DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			DataGridViewCheckBoxColumn dataGridViewColumn = new DataGridViewCheckBoxColumn();
			DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
			Font font = new Font("Segoe UI", 12f, FontStyle.Bold);
			dataGridViewCheckBoxColumn.FillWeight = 100f;
			this.dataGrid_confirm.MultiSelect = false;
			this.dataGrid_confirm.AutoSize = false;
			this.dataGrid_confirm.Columns.Add("", "");
			this.dataGrid_confirm.Columns.Add(dataGridViewCheckBoxColumn);
			this.dataGrid_confirm.Columns.Add(dataGridViewColumn);
			this.dataGrid_confirm.Columns.Add("", "");
			bool flag2 = report.sFactory == "K5" && (report.sModel.ToUpper() == this._hCC.hCCContent.Board || report.sModel.ToUpper() == this._hCC.hCCContent.Socket);
			if (flag2)
			{
				this.dataGrid_confirm.Columns[0].Width = 630;
				this.dataGrid_confirm.Columns[1].Width = 70;
				this.dataGrid_confirm.Columns[2].Width = 70;
			}
			else
			{
				this.dataGrid_confirm.Columns[0].Width = 630;
				this.dataGrid_confirm.Columns[1].Width = 50;
				this.dataGrid_confirm.Columns[2].Width = 50;
			}
			this.dataGrid_confirm.Columns[3].Width = 400;
			this.dataGrid_confirm.RowHeadersWidth = 65;
			for (int i = 0; i < this.dataGrid_confirm.ColumnCount; i++)
			{
				this.dataGrid_confirm.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				this.dataGrid_confirm.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
				this.dataGrid_confirm.Columns[i].HeaderCell.Style.Font = font;
				this.dataGrid_confirm.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
				this.dataGrid_confirm.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
			bool flag3 = report.sFactory == "K5" && (report.sModel.ToUpper() == this._hCC.hCCContent.Board || report.sModel.ToUpper() == this._hCC.hCCContent.Socket);
			if (flag3)
			{
				bool flag4 = report.sModel.ToUpper() == this._hCC.hCCContent.Board;
				if (flag4)
				{
					this.dataGrid_confirm.Columns[0].HeaderText = "P/C VISUAL INSPECTION CHECK ITEM";
				}
				else
				{
					this.dataGrid_confirm.Columns[0].HeaderText = "CHECK ITEM";
				}
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
			this.dataGrid_confirm.RowCount = cConst.listContents.Count;
			int num = 0;
			foreach (KeyValuePair<int, string> keyValuePair in cConst.listContents)
			{
				this.dataGrid_confirm.Rows[num].Height = 45;
				this.dataGrid_confirm.Rows[num].HeaderCell.Value = (num + 1).ToString();
				this.dataGrid_confirm.Rows[num].HeaderCell.Style.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
				this.dataGrid_confirm.Rows[num].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
				this.dataGrid_confirm.Rows[num].Cells[0].Value = keyValuePair.Value;
				this.dataGrid_confirm.Rows[num].Cells[0].Style.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
				this.dataGrid_confirm.Rows[num].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				this.dataGrid_confirm.Rows[num].Cells[1].Style.BackColor = Color.White;
				this.dataGrid_confirm.Rows[num].Cells[2].Style.BackColor = Color.White;
				this.dataGrid_confirm.Rows[num].Cells[3].Style.WrapMode = DataGridViewTriState.True;
				this.dataGrid_confirm.Rows[num].Cells[3].Style.Alignment = DataGridViewContentAlignment.TopLeft;
				num++;
			}
			bool flag5 = report.sFactory == "K5" && (report.sModel.ToUpper() == this._hCC.hCCContent.Board || report.sModel.ToUpper() == this._hCC.hCCContent.Socket);
			if (flag5)
			{
				bool flag6 = this.dataGrid_confirm.Rows.Count >= 1;
				if (flag6)
				{
					int j;
					int k;
					for (k = 0; k < this.dataGrid_confirm.Rows.Count; k = j + 1)
					{
						KeyValuePair<int, string> keyValuePair2 = cConst.listContents.FirstOrDefault((KeyValuePair<int, string> x) => x.Value.Equals(this.dataGrid_confirm.Rows[k].Cells[0].Value.ToString()));
						bool flag7 = keyValuePair2.Key > report.listDetails.Count;
						if (flag7)
						{
							this.dataGrid_confirm.Rows[k].Cells[1].Value = true;
							this.dataGrid_confirm.Rows[k].Cells[2].Value = true;
						}
						else
						{
							this.dataGrid_confirm.Rows[k].Cells[1].Value = true;
							this.dataGrid_confirm.Rows[k].Cells[2].Value = true;
							this.dataGrid_confirm.Rows[k].Cells[3].Value = report.listDetails[keyValuePair2.Key - 1];
						}
						j = k;
					}
				}
			}
			else
			{
				bool flag8 = this.dataGrid_confirm.Rows.Count >= 1;
				if (flag8)
				{
					int j;
					int k;
					for (k = 0; k < this.dataGrid_confirm.Rows.Count; k = j + 1)
					{
						KeyValuePair<int, string> keyValuePair3 = cConst.listContents.FirstOrDefault((KeyValuePair<int, string> x) => x.Value.Contains(this.dataGrid_confirm.Rows[k].Cells[0].Value.ToString()));
						bool flag9 = keyValuePair3.Key > report.listDetails.Count;
						if (flag9)
						{
							this.dataGrid_confirm.Rows[k].Cells[1].Value = false;
							this.dataGrid_confirm.Rows[k].Cells[2].Value = true;
						}
						else
						{
							this.dataGrid_confirm.Rows[k].Cells[3].Value = report.listDetails[keyValuePair3.Key - 1];
							bool flag10 = string.IsNullOrEmpty(report.listDetails[keyValuePair3.Key - 1]);
							if (flag10)
							{
								this.dataGrid_confirm.Rows[k].Cells[1].Value = false;
								this.dataGrid_confirm.Rows[k].Cells[2].Value = true;
							}
							else
							{
								this.dataGrid_confirm.Rows[k].DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
								this.dataGrid_confirm.Rows[k].Cells[1].Value = true;
								this.dataGrid_confirm.Rows[k].Cells[2].Value = false;
							}
						}
						j = k;
					}
				}
			}
			this.dataGrid_confirm.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
			this.dataGrid_confirm.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			Size size = this.dataGrid_confirm.Size;
			this.dataGrid_confirm.Size = new Size(1, 1);
			this.dataGrid_confirm.Size = size;
			this.dataGrid_confirm.Refresh();
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void dataGrid_confirm_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x000749D8 File Offset: 0x00072BD8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00074A10 File Offset: 0x00072C10
		private void InitializeComponent()
		{
			this.dataGrid_confirm = new DataGridView();
			((ISupportInitialize)this.dataGrid_confirm).BeginInit();
			base.SuspendLayout();
			this.dataGrid_confirm.AllowUserToAddRows = false;
			this.dataGrid_confirm.AllowUserToDeleteRows = false;
			this.dataGrid_confirm.AllowUserToResizeColumns = false;
			this.dataGrid_confirm.AllowUserToResizeRows = false;
			this.dataGrid_confirm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid_confirm.Dock = DockStyle.Fill;
			this.dataGrid_confirm.Location = new Point(0, 0);
			this.dataGrid_confirm.Name = "dataGrid_confirm";
			this.dataGrid_confirm.RowTemplate.Height = 23;
			this.dataGrid_confirm.Size = new Size(760, 482);
			this.dataGrid_confirm.TabIndex = 5;
			this.dataGrid_confirm.CellPainting += this.dataGrid_confirm_CellPainting;
			base.AutoScaleMode = AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = Color.White;
			base.Controls.Add(this.dataGrid_confirm);
			base.Name = "ActionConfirmation";
			base.Size = new Size(760, 482);
			((ISupportInitialize)this.dataGrid_confirm).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000631 RID: 1585
		private readonly HCC _hCC;

		// Token: 0x04000632 RID: 1586
		private IContainer components = null;

		// Token: 0x04000633 RID: 1587
		private DataGridView dataGrid_confirm;
	}
}
