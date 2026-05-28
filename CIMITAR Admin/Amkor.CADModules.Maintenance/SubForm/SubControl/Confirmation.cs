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
	// Token: 0x02000031 RID: 49
	public partial class Confirmation : Form
	{
		// Token: 0x0600030E RID: 782 RVA: 0x0006358A File Offset: 0x0006178A
		public List<string> getDetailCommentList()
		{
			return this._listDetails;
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000310 RID: 784 RVA: 0x0006359B File Offset: 0x0006179B
		// (set) Token: 0x0600030F RID: 783 RVA: 0x00063592 File Offset: 0x00061792
		private int defaulCellHight { get; set; }

		// Token: 0x06000311 RID: 785 RVA: 0x000635A3 File Offset: 0x000617A3
		private void pbSubmit_MouseEnter(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit_down;
		}

		// Token: 0x06000312 RID: 786 RVA: 0x000635B6 File Offset: 0x000617B6
		private void pbSubmit_MouseLeave(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x000635C9 File Offset: 0x000617C9
		private void pbClear_MouseEnter(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clearn_down;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x000635DC File Offset: 0x000617DC
		private void pbClear_MouseLeave(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clear;
		}

		// Token: 0x06000315 RID: 789 RVA: 0x000635F0 File Offset: 0x000617F0
		public Confirmation(FactorySettings factorySettings, string factory, string content)
		{
			cConst.initContents(factorySettings, factory, content);
			this.DoubleBuffered = true;
			this.InitializeComponent();
			this.InitializeGrid();
			this.label1.Text = MessageLanguage.getMessage("confirmation_tip");
			base.Width = 1234;
			base.Height = 800;
			base.StartPosition = FormStartPosition.CenterScreen;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0006367C File Offset: 0x0006187C
		public Confirmation(FactorySettings factorySettings, cReportItem report)
		{
			bool flag = report.sCategory != "HCC";
			if (flag)
			{
				cConst.initContents(factorySettings, report.sFactory, report.sCategory);
			}
			else
			{
				cConst.initContents(factorySettings, report.sFactory, report.sModel);
			}
			this.InitializeComponent();
			this.InitializeGrid();
			this.DoubleBuffered = true;
			base.Width = 1234;
			base.Height = 800;
			base.StartPosition = FormStartPosition.CenterScreen;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00063724 File Offset: 0x00061924
		private void InitializeGrid()
		{
			DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			DataGridViewCheckBoxColumn dataGridViewColumn = new DataGridViewCheckBoxColumn();
			DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			Font font = new Font("Segoe UI", 12f, FontStyle.Bold);
			dataGridViewCheckBoxColumn.FillWeight = 100f;
			this.dataGrid_confirm.MultiSelect = false;
			this.dataGrid_confirm.AutoSize = true;
			this.dataGrid_confirm.Columns.Add("", "");
			this.dataGrid_confirm.Columns.Add(dataGridViewCheckBoxColumn);
			this.dataGrid_confirm.Columns.Add(dataGridViewColumn);
			this.dataGrid_confirm.Columns.Add("", "");
			this.dataGrid_confirm.Columns[0].HeaderText = "CHECK ITEM";
			this.dataGrid_confirm.Columns[1].HeaderText = "YES";
			this.dataGrid_confirm.Columns[2].HeaderText = "NO";
			this.dataGrid_confirm.Columns[3].HeaderText = "COMMENT";
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
				bool flag = i == 3;
				if (flag)
				{
				}
			}
			this.dataGrid_confirm.Columns[0].Width = 630;
			this.dataGrid_confirm.Columns[1].Width = 50;
			this.dataGrid_confirm.Columns[2].Width = 50;
			this.dataGrid_confirm.Columns[3].Width = 400;
			this.dataGrid_confirm.RowHeadersWidth = 65;
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
				this.dataGrid_confirm.Rows[num].Cells[3].Style.WrapMode = DataGridViewTriState.NotSet;
				this.dataGrid_confirm.Rows[num].Cells[3].Style.Alignment = DataGridViewContentAlignment.TopLeft;
				num++;
			}
			this.dataGrid_confirm.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
			this.dataGrid_confirm.Refresh();
			bool flag2 = this.dataGrid_confirm.Rows.Count != 0;
			if (flag2)
			{
				this.defaulCellHight = this.dataGrid_confirm.Rows[0].Height;
			}
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00063C9C File Offset: 0x00061E9C
		private void btnClear_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.dataGrid_confirm.RowCount; i++)
			{
				this.dataGrid_confirm.Rows[i].Cells[1].Value = false;
				this.dataGrid_confirm.Rows[i].Cells[2].Value = false;
				this.dataGrid_confirm.Rows[i].Cells[3].Value = string.Empty;
				this.dataGrid_confirm.Rows[i].Height = this.defaulCellHight;
			}
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00063D60 File Offset: 0x00061F60
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
					MessageBox.Show(MessageLanguage.getMessage("check_yesno_confirmation"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this._listDetails.Clear();
					flag = false;
					break;
				}
				bool flag3 = !(bool)this.dataGrid_confirm.Rows[i].Cells[1].Value && !(bool)this.dataGrid_confirm.Rows[i].Cells[2].Value;
				if (flag3)
				{
					MessageBox.Show(MessageLanguage.getMessage("check_yesno_confirmation"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this._listDetails.Clear();
					flag = false;
					break;
				}
				bool flag4 = (bool)this.dataGrid_confirm.Rows[i].Cells[1].Value || !(bool)this.dataGrid_confirm.Rows[i].Cells[2].Value;
				if (flag4)
				{
					bool flag5 = this.dataGrid_confirm.Rows[i].Cells[3].Value == null || (string)this.dataGrid_confirm.Rows[i].Cells[3].Value == string.Empty;
					if (flag5)
					{
						MessageBox.Show(MessageLanguage.getMessage("check_comment_confirmation"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this._listDetails.Clear();
						flag = false;
						break;
					}
				}
				KeyValuePair<int, string> keyValuePair = cConst.listContents.FirstOrDefault((KeyValuePair<int, string> x) => x.Value.Equals(this.dataGrid_confirm.Rows[i].Cells[0].Value.ToString()));
				bool flag6 = this.dataGrid_confirm.Rows[i].Cells[3].Value != null;
				if (flag6)
				{
					bool flag7 = (bool)this.dataGrid_confirm.Rows[i].Cells[1].Value;
					if (flag7)
					{
						bool flag8 = this.dataGrid_confirm.Rows[i].Cells[3].Value.ToString().Length < 10;
						if (flag8)
						{
							MessageBox.Show(MessageLanguage.getMessage("check_comment_length_confirmation"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							this._listDetails.Clear();
							flag = false;
							break;
						}
						this._listDetails[keyValuePair.Key - 1] = this.dataGrid_confirm.Rows[i].Cells[3].Value.ToString();
					}
					else
					{
						this._listDetails[keyValuePair.Key - 1] = string.Empty;
					}
				}
				else
				{
					this._listDetails[keyValuePair.Key - 1] = string.Empty;
				}
				j = i;
			}
			bool flag9 = flag;
			if (flag9)
			{
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0006419C File Offset: 0x0006239C
		private void dataGrid_confirm_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 0;
				if (flag2)
				{
					this.dataGrid_confirm.ClearSelection();
				}
				else
				{
					bool flag3 = e.ColumnIndex == 1;
					if (flag3)
					{
						this.dataGrid_confirm.Rows[e.RowIndex].Cells[1].Value = true;
						this.dataGrid_confirm.Rows[e.RowIndex].Cells[2].Value = false;
					}
					else
					{
						bool flag4 = e.ColumnIndex == 2;
						if (flag4)
						{
							this.dataGrid_confirm.Rows[e.RowIndex].Cells[2].Value = true;
							this.dataGrid_confirm.Rows[e.RowIndex].Cells[1].Value = false;
						}
						else
						{
							bool flag5 = e.ColumnIndex == 3;
							if (flag5)
							{
								bool flag6 = this.dataGrid_confirm.CurrentCell.EditType == typeof(DataGridViewTextBoxEditingControl);
								if (flag6)
								{
									this.dataGrid_confirm.BeginEdit(false);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000642FC File Offset: 0x000624FC
		private void dataGrid_confirm_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			bool flag = e.ColumnIndex == 1 || e.ColumnIndex == 2;
			if (flag)
			{
				bool flag2 = e.RowIndex >= 0;
				if (flag2)
				{
					e.PaintBackground(e.CellBounds, false);
					ControlPaint.DrawCheckBox(e.Graphics, e.CellBounds.X + 1, e.CellBounds.Y + 10, 45, 20, (e.Value != null && (bool)e.Value) ? ButtonState.Checked : ButtonState.Normal);
					e.Handled = true;
				}
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000643A0 File Offset: 0x000625A0
		private void dataGrid_confirm_SelectionChanged(object sender, EventArgs e)
		{
			bool flag = this._EnterMoveNext && Control.MouseButtons == MouseButtons.None;
			if (flag)
			{
				this._EnterMoveNext = false;
				bool flag2 = this._tempEditCell != null && this.dataGrid_confirm.CurrentCell != null;
				if (flag2)
				{
					this.dataGrid_confirm.CurrentCell = this.dataGrid_confirm[this._tempEditCell.ColumnIndex, this._tempEditCell.RowIndex];
					this.dataGrid_confirm.BeginEdit(false);
					this._tempTb.AppendText("\r\n");
					this._tempEditCell = null;
				}
			}
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0006443F File Offset: 0x0006263F
		private void panel2_Resize(object sender, EventArgs e)
		{
			this.dataGrid_confirm.Height = this.panel2.Height - 10;
			this.dataGrid_confirm.Width = this.panel2.Width - 10;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00064476 File Offset: 0x00062676
		private void pbSubmit_Click(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit;
			this.btnSumit_Click(null, null);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00064493 File Offset: 0x00062693
		private void pbClear_Click(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clear;
			this.btnClear_Click(null, null);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x000644B0 File Offset: 0x000626B0
		private void dataGrid_confirm_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			this.dataGrid_confirm.ClearSelection();
			e.Control.KeyPress += this.dataGridViewTextBox_KeyPress;
			this._tempTb = (DataGridViewTextBoxEditingControl)e.Control;
			this._tempTb.KeyPress += this.dataGridViewTextBox_KeyPress;
			this._tempTb.PreviewKeyDown += this.preKeyDonw;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00064524 File Offset: 0x00062724
		private void preKeyDonw(object sender, PreviewKeyDownEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right;
			if (flag)
			{
				this._keyBlock = true;
			}
			else
			{
				this._keyBlock = false;
			}
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00064574 File Offset: 0x00062774
		private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == '|';
			if (flag)
			{
				e.KeyChar = '\0';
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00064598 File Offset: 0x00062798
		private void dataGrid_confirm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = e.ColumnIndex == 3 && this._tempTb.Lines.Count<string>() >= 4;
			if (flag)
			{
				bool flag2 = !this._keyBlock;
				if (flag2)
				{
					this.dataGrid_confirm.CurrentRow.Height = this.defaulCellHight + this._tempTb.Font.Height * (this._tempTb.Lines.Count<string>() - 3);
				}
				else
				{
					bool flag3 = e.ColumnIndex == 3 && this._tempTb.Lines.Count<string>() <= 3;
					if (flag3)
					{
						this.dataGrid_confirm.CurrentRow.Height = this.defaulCellHight;
					}
				}
			}
			bool flag4 = e.ColumnIndex == 3 && !this._keyBlock;
			if (flag4)
			{
				this._tempEditCell = this.dataGrid_confirm[e.ColumnIndex, e.RowIndex];
				this._EnterMoveNext = true;
				this._keyBlock = true;
			}
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0006469C File Offset: 0x0006289C
		private void dataGrid_confirm_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			bool flag = e.ColumnIndex == -1 || e.RowIndex == -1;
			if (!flag)
			{
				this.dataGrid_confirm.CurrentCell = this.dataGrid_confirm[e.ColumnIndex, e.RowIndex];
				this._EnterMoveNext = false;
			}
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void dataGrid_confirm_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
		}

		// Token: 0x04000541 RID: 1345
		private List<string> _listDetails = new List<string>();

		// Token: 0x04000542 RID: 1346
		private DataGridViewCell _tempEditCell;

		// Token: 0x04000543 RID: 1347
		private bool _EnterMoveNext = false;

		// Token: 0x04000544 RID: 1348
		private bool _keyBlock = false;

		// Token: 0x04000545 RID: 1349
		private DataGridViewTextBoxEditingControl _tb;

		// Token: 0x04000546 RID: 1350
		private TextBox _tempTb;
	}
}
