using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.UnitDataProcModule.CommonClass
{
	// Token: 0x02000005 RID: 5
	public class CustomGridGroupContentCellElement : GridGroupContentCellElement
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00006F70 File Offset: 0x00005170
		public CustomGridGroupContentCellElement(GridViewColumn column, GridRowElement row) : base(column, row)
		{
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00006F9B File Offset: 0x0000519B
		protected override Type ThemeEffectiveType
		{
			get
			{
				return typeof(GridGroupContentCellElement);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00006FA8 File Offset: 0x000051A8
		protected override void CreateChildElements()
		{
			base.CreateChildElements();
			this.stack = new StackLayoutElement();
			this.stack.Orientation = Orientation.Horizontal;
			this.stack.StretchHorizontally = true;
			this.checkBoxElement.StretchHorizontally = false;
			this.checkBoxElement.CheckStateChanged += this.checkBoxElement_CheckStateChanged;
			this.textElement.TextAlignment = ContentAlignment.MiddleLeft;
			this.Children.Add(this.stack);
			this.stack.Children.Add(this.checkBoxElement);
			this.stack.Children.Add(this.textElement);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00007050 File Offset: 0x00005250
		private void checkBoxElement_CheckStateChanged(object sender, EventArgs e)
		{
			GridViewGroupRowInfo gridViewGroupRowInfo = this.RowInfo as GridViewGroupRowInfo;
			gridViewGroupRowInfo.Tag = this.checkBoxElement.Checked;
			base.GridViewElement.GridControl.BeginUpdate();
			int value = base.GridControl.TableElement.VScrollBar.Value;
			foreach (GridViewRowInfo gridViewRowInfo in this.RowInfo.ChildRows)
			{
				GridViewGroupRowInfo gridViewGroupRowInfo2 = gridViewRowInfo as GridViewGroupRowInfo;
				if (gridViewGroupRowInfo2 != null)
				{
					this.Toggle(gridViewGroupRowInfo2, this.checkBoxElement.Checked);
				}
				gridViewRowInfo.Cells["Check"].Value = this.checkBoxElement.Checked;
			}
			base.GridViewElement.GridControl.EndUpdate();
			base.GridViewElement.GridControl.TableElement.VScrollBar.Value = value;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00007154 File Offset: 0x00005354
		private void Toggle(GridViewGroupRowInfo groupRow, bool state)
		{
			groupRow.Tag = state;
			foreach (GridViewRowInfo gridViewRowInfo in groupRow.ChildRows)
			{
				GridViewGroupRowInfo gridViewGroupRowInfo = gridViewRowInfo as GridViewGroupRowInfo;
				if (gridViewGroupRowInfo != null)
				{
					this.Toggle(gridViewGroupRowInfo, state);
				}
				gridViewRowInfo.Cells["Check"].Value = state;
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000071D4 File Offset: 0x000053D4
		public override void SetContent()
		{
			base.SetContent();
			this.DrawText = false;
			this.textElement.Text = ((GridViewGroupRowInfo)this.RowInfo).HeaderText;
			this.checkBoxElement.CheckStateChanged -= this.checkBoxElement_CheckStateChanged;
			if (this.RowInfo.Tag != null)
			{
				this.checkBoxElement.Checked = (bool)this.RowInfo.Tag;
			}
			else
			{
				this.checkBoxElement.Checked = false;
			}
			this.checkBoxElement.CheckStateChanged += this.checkBoxElement_CheckStateChanged;
		}

		// Token: 0x04000032 RID: 50
		private RadCheckBoxElement checkBoxElement = new RadCheckBoxElement();

		// Token: 0x04000033 RID: 51
		private LightVisualElement textElement = new LightVisualElement();

		// Token: 0x04000034 RID: 52
		private StackLayoutElement stack = new StackLayoutElement();
	}
}
