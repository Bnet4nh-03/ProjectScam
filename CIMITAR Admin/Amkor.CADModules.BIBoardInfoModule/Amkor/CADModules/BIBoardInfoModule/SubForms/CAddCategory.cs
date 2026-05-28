using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.BIBoardInfoModule.Properties;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000024 RID: 36
	public partial class CAddCategory : Form
	{
		// Token: 0x060000CA RID: 202 RVA: 0x000131B3 File Offset: 0x000113B3
		public CAddCategory(ArrayList alCategory)
		{
			this.InitializeComponent();
			this._alCategory = alCategory;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000131D3 File Offset: 0x000113D3
		private void CAddCategory_Load(object sender, EventArgs e)
		{
			this.SetCombos(this._alCategory);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000055FE File Offset: 0x000037FE
		private void CAddCategory_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000131E1 File Offset: 0x000113E1
		private void SetCombos(ArrayList alCategory)
		{
			this.combo_Category.Items.Clear();
			this.combo_Category.Items.AddRange(alCategory.ToArray());
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00013209 File Offset: 0x00011409
		private void pb_SaveSelection_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_SaveSelection.Image = Resources.TableSave;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00013226 File Offset: 0x00011426
		private void pb_SaveSelection_MouseMove(object sender, MouseEventArgs e)
		{
			this.pb_SaveSelection.Image = Resources.TableSave_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00013209 File Offset: 0x00011409
		private void pb_SaveSelection_MouseLeave(object sender, EventArgs e)
		{
			this.pb_SaveSelection.Image = Resources.TableSave;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00013243 File Offset: 0x00011443
		private void pb_SaveSelection_MouseUp(object sender, MouseEventArgs e)
		{
			this._selectedCategory = this.combo_Category.Text.Trim().ToUpper();
			if (string.IsNullOrEmpty(this._selectedCategory))
			{
				MessageBox.Show("Input contents");
				return;
			}
			base.DialogResult = DialogResult.OK;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00013280 File Offset: 0x00011480
		private void combo_Category_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.combo_Category.SelectedItem == null)
			{
				return;
			}
			if (this.combo_Category.SelectedItem.ToString() == "ETC")
			{
				this.combo_Category.DropDownStyle = ComboBoxStyle.DropDown;
				return;
			}
			this.combo_Category.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		// Token: 0x0400018F RID: 399
		private ArrayList _alCategory;

		// Token: 0x04000190 RID: 400
		public string _selectedCategory = string.Empty;
	}
}
