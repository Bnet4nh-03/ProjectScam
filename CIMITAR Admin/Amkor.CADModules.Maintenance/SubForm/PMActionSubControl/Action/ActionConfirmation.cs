using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Action
{
	// Token: 0x02000028 RID: 40
	public class ActionConfirmation : UserControl
	{
		// Token: 0x06000290 RID: 656 RVA: 0x00059A64 File Offset: 0x00057C64
		public ActionConfirmation(FactorySettings factorySettings, cReportItem report)
		{
			this.InitializeComponent();
			bool flag = report.sCategory == "HCC";
			if (flag)
			{
				cConst.initContents(factorySettings, report.sFactory, report.sModel);
			}
			else
			{
				cConst.initContents(factorySettings, report.sFactory, report.sCategory);
			}
			DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			DataGridViewCheckBoxColumn dataGridViewColumn = new DataGridViewCheckBoxColumn();
			DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
			Font font = new Font("Segoe UI", 12f, FontStyle.Bold);
			dataGridViewCheckBoxColumn.FillWeight = 100f;
			this.dataGrid_confirm.MultiSelect = false;
			this.dataGrid_confirm.Columns.Add("", "");
			this.dataGrid_confirm.Columns.Add(dataGridViewCheckBoxColumn);
			this.dataGrid_confirm.Columns.Add(dataGridViewColumn);
			this.dataGrid_confirm.Columns.Add("", "");
			bool flag2 = report.sModel.ToUpper() == "BOARD";
			if (flag2)
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
			this.dataGrid_confirm.RowCount = cConst.listContents.Count;
			bool flag3 = report.sModel.ToUpper() == "BOARD";
			if (flag3)
			{
				this.dataGrid_confirm.ColumnHeadersHeight = 150;
				this.dataGrid_confirm.Columns[0].Width = 300;
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
			this.dataGrid_confirm.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
			bool flag4 = report.sModel.ToUpper() == "BOARD";
			if (flag4)
			{
				bool flag5 = this.dataGrid_confirm.Rows.Count > 1;
				if (flag5)
				{
					int j;
					int k;
					for (k = 0; k < this.dataGrid_confirm.Rows.Count; k = j + 1)
					{
						KeyValuePair<int, string> keyValuePair2 = cConst.listContents.FirstOrDefault((KeyValuePair<int, string> x) => x.Value.Equals(this.dataGrid_confirm.Rows[k].Cells[0].Value.ToString()));
						bool flag6 = keyValuePair2.Key > report.listDetails.Count;
						if (flag6)
						{
							this.dataGrid_confirm.Rows[k].Cells[1].Value = false;
							this.dataGrid_confirm.Rows[k].Cells[2].Value = false;
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
				bool flag7 = this.dataGrid_confirm.Rows.Count > 1;
				if (flag7)
				{
					int j;
					int k;
					for (k = 0; k < this.dataGrid_confirm.Rows.Count; k = j + 1)
					{
						KeyValuePair<int, string> keyValuePair3 = cConst.listContents.FirstOrDefault((KeyValuePair<int, string> x) => x.Value.Contains(this.dataGrid_confirm.Rows[k].Cells[0].Value.ToString()));
						bool flag8 = keyValuePair3.Key > report.listDetails.Count;
						if (flag8)
						{
							this.dataGrid_confirm.Rows[k].Cells[1].Value = false;
							this.dataGrid_confirm.Rows[k].Cells[2].Value = true;
						}
						else
						{
							this.dataGrid_confirm.Rows[k].Cells[3].Value = report.listDetails[keyValuePair3.Key - 1];
							bool flag9 = string.IsNullOrEmpty(report.listDetails[keyValuePair3.Key - 1]);
							if (flag9)
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
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0005A4E0 File Offset: 0x000586E0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0005A518 File Offset: 0x00058718
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
			this.dataGrid_confirm.Size = new Size(850, 502);
			this.dataGrid_confirm.TabIndex = 5;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.dataGrid_confirm);
			base.Name = "ActionConfirmation";
			base.Size = new Size(850, 502);
			((ISupportInitialize)this.dataGrid_confirm).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040004A9 RID: 1193
		private IContainer components = null;

		// Token: 0x040004AA RID: 1194
		private DataGridView dataGrid_confirm;
	}
}
