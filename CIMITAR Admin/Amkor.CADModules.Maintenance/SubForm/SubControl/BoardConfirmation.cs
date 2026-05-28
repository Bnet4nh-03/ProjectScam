using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.Properties;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000030 RID: 48
	public partial class BoardConfirmation : Form
	{
		// Token: 0x060002FA RID: 762 RVA: 0x00061F8A File Offset: 0x0006018A
		private void pbClear_MouseLeave(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clear;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00061F9D File Offset: 0x0006019D
		private void pbClear_MouseEnter(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clearn_down;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00061FB0 File Offset: 0x000601B0
		private void pbSubmit_MouseLeave(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit;
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00061FC3 File Offset: 0x000601C3
		private void pbSubmit_MouseEnter(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit_down;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00061FD6 File Offset: 0x000601D6
		public List<string> getDetailCommentList()
		{
			return this._listDetails;
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00061FE0 File Offset: 0x000601E0
		public BoardConfirmation(FactorySettings factorySettings, string factory, string content)
		{
			cConst.initContents(factorySettings, factory, content);
			this.InitializeComponent();
			this.label1.Text = MessageLanguage.getMessage("confirmation_tip");
			this.InitializeGrid(factory, content);
			base.Width = 950;
			base.StartPosition = FormStartPosition.CenterScreen;
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0006204C File Offset: 0x0006024C
		public BoardConfirmation(FactorySettings factorySettings, cReportItem report)
		{
			cConst.initContents(factorySettings, report.sFactory, report.sModel);
			this.InitializeComponent();
			this.InitializeGrid(report.sFactory, report.sModel);
			base.Width = 950;
			base.StartPosition = FormStartPosition.CenterScreen;
		}

		// Token: 0x06000301 RID: 769 RVA: 0x000620B4 File Offset: 0x000602B4
		private void InitializeGrid(string factory, string content)
		{
			DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
			DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
			Font font = new Font("Segoe UI", 12f, FontStyle.Bold);
			dataGridViewCheckBoxColumn.FillWeight = 100f;
			dataGridViewCheckBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCheckBoxColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dataGrid_confirm.MultiSelect = false;
			this.dataGrid_confirm.AutoSize = false;
			this.dataGrid_confirm.Columns.Add("", "");
			this.dataGrid_confirm.Columns.Add(dataGridViewCheckBoxColumn);
			this.dataGrid_confirm.Columns.Add(dataGridViewCheckBoxColumn2);
			this.dataGrid_confirm.Columns.Add("", "");
			bool flag = factory == "K5";
			if (flag)
			{
				bool flag2 = content == "BOARD";
				if (flag2)
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
			this.dataGrid_confirm.Columns[0].ReadOnly = true;
			this.dataGrid_confirm.Columns[1].ReadOnly = false;
			this.dataGrid_confirm.Columns[2].ReadOnly = false;
			this.dataGrid_confirm.Columns[3].ReadOnly = false;
			for (int i = 0; i < this.dataGrid_confirm.ColumnCount; i++)
			{
				this.dataGrid_confirm.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				this.dataGrid_confirm.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
				this.dataGrid_confirm.Columns[i].HeaderCell.Style.Font = font;
				this.dataGrid_confirm.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
				this.dataGrid_confirm.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
			this.dataGrid_confirm.ColumnHeadersHeight = 150;
			this.dataGrid_confirm.Columns[0].Width = 300;
			this.dataGrid_confirm.Columns[1].Width = 70;
			this.dataGrid_confirm.Columns[2].Width = 70;
			this.dataGrid_confirm.Columns[3].Width = 400;
			this.dataGrid_confirm.RowHeadersWidth = 65;
			this.dataGrid_confirm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGrid_confirm.AutoResizeColumns();
			this.dataGrid_confirm.RowCount = cConst.listContents.Count;
			font = new Font("Segoe UI", 18f, FontStyle.Bold);
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
			this.dataGrid_confirm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGrid_confirm.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0006268C File Offset: 0x0006088C
		private void pbSubmit_Click(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit;
			this.btnSumit_Click(null, null);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x000626A9 File Offset: 0x000608A9
		private void pbClear_Click(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clear;
			this.btnClear_Click(null, null);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x000626C8 File Offset: 0x000608C8
		private void btnClear_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.dataGrid_confirm.RowCount; i++)
			{
				this.dataGrid_confirm.Rows[i].Cells[1].Value = false;
				this.dataGrid_confirm.Rows[i].Cells[2].Value = false;
				this.dataGrid_confirm.Rows[i].Cells[3].Value = string.Empty;
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0006276C File Offset: 0x0006096C
		private void btnSumit_Click(object sender, EventArgs e)
		{
			bool flag = true;
			this._listDetails = new List<string>(cConst.listContents.Values);
			this.dataGrid_confirm.ClearSelection();
			this.dataGrid_confirm.Rows[0].Cells[0].Selected = true;
			int i;
			int j;
			for (i = 0; i < this.dataGrid_confirm.RowCount; i = j + 1)
			{
				bool flag2 = this.dataGrid_confirm.Rows[i].Cells[1].Value == null || this.dataGrid_confirm.Rows[i].Cells[2].Value == null;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("check_item_confirmation"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this._listDetails.Clear();
					flag = false;
					break;
				}
				bool flag3 = !(bool)this.dataGrid_confirm.Rows[i].Cells[1].Value || !(bool)this.dataGrid_confirm.Rows[i].Cells[2].Value;
				if (flag3)
				{
					MessageBox.Show(MessageLanguage.getMessage("check_item_confirmation"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this._listDetails.Clear();
					flag = false;
					break;
				}
				KeyValuePair<int, string> keyValuePair = cConst.listContents.FirstOrDefault((KeyValuePair<int, string> x) => x.Value.Equals(this.dataGrid_confirm.Rows[i].Cells[0].Value.ToString()));
				bool flag4 = this.dataGrid_confirm.Rows[i].Cells[3].Value != null;
				if (flag4)
				{
					this._listDetails[keyValuePair.Key - 1] = this.dataGrid_confirm.Rows[i].Cells[3].Value.ToString();
				}
				else
				{
					this._listDetails[keyValuePair.Key - 1] = string.Empty;
				}
				j = i;
			}
			bool flag5 = flag;
			if (flag5)
			{
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
		}

		// Token: 0x06000306 RID: 774 RVA: 0x000629E8 File Offset: 0x00060BE8
		private void dataGrid_confirm_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			bool flag = e.ColumnIndex == 1 || e.ColumnIndex == 2;
			if (flag)
			{
				bool flag2 = e.RowIndex >= 0;
				if (flag2)
				{
					e.PaintBackground(e.CellBounds, true);
					ControlPaint.DrawCheckBox(e.Graphics, e.CellBounds.X + 1, e.CellBounds.Y + 1, 45, 20, ((bool)e.FormattedValue) ? ButtonState.Checked : ButtonState.Normal);
					e.Handled = true;
				}
			}
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00062A80 File Offset: 0x00060C80
		private void dataGrid_confirm_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 1;
				if (flag2)
				{
					this.dataGrid_confirm.ClearSelection();
					this.dataGrid_confirm.Rows[e.RowIndex].Cells[1].Value = !Convert.ToBoolean(this.dataGrid_confirm.Rows[e.RowIndex].Cells[1].Value);
					this.dataGrid_confirm.Rows[0].Cells[0].Selected = true;
				}
				else
				{
					bool flag3 = e.ColumnIndex == 2;
					if (flag3)
					{
						this.dataGrid_confirm.ClearSelection();
						this.dataGrid_confirm.Rows[e.RowIndex].Cells[2].Value = !Convert.ToBoolean(this.dataGrid_confirm.Rows[e.RowIndex].Cells[2].Value);
						this.dataGrid_confirm.Rows[0].Cells[0].Selected = true;
					}
				}
			}
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00062BE0 File Offset: 0x00060DE0
		private void dataGrid_confirm_SelectionChanged(object sender, EventArgs e)
		{
			bool flag = this.dataGrid_confirm.CurrentCellAddress.X == 0 || this.dataGrid_confirm.Rows[0].Cells[0].Selected || this.dataGrid_confirm.CurrentCellAddress.X == 1 || this.dataGrid_confirm.CurrentCellAddress.X == 2;
			if (flag)
			{
				this.dataGrid_confirm.ClearSelection();
			}
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00062C68 File Offset: 0x00060E68
		private void dataGrid_confirm_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == '|';
			if (flag)
			{
				e.KeyChar = '\0';
			}
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00062C90 File Offset: 0x00060E90
		private void dataGrid_confirm_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = (DataGridViewTextBoxEditingControl)e.Control;
			dataGridViewTextBoxEditingControl.KeyPress += this.dataGridViewTextBox_KeyPress;
			e.Control.KeyPress += this.dataGridViewTextBox_KeyPress;
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00062CD8 File Offset: 0x00060ED8
		private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == '|';
			if (flag)
			{
				e.KeyChar = '\0';
			}
		}

		// Token: 0x04000536 RID: 1334
		private List<string> _listDetails = new List<string>();
	}
}
