using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.DcolSummaryView.CommonClass
{
	// Token: 0x02000005 RID: 5
	public class CustomGridGroupContentCellElement : GridGroupContentCellElement
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00004458 File Offset: 0x00002658
		public CustomGridGroupContentCellElement(GridViewColumn column, GridRowElement row) : base(column, row)
		{
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00004483 File Offset: 0x00002683
		protected override Type ThemeEffectiveType
		{
			get
			{
				return typeof(GridGroupContentCellElement);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00004490 File Offset: 0x00002690
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

		// Token: 0x0600001A RID: 26 RVA: 0x00004538 File Offset: 0x00002738
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

		// Token: 0x0600001B RID: 27 RVA: 0x0000463C File Offset: 0x0000283C
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

		// Token: 0x0600001C RID: 28 RVA: 0x000046BC File Offset: 0x000028BC
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

		// Token: 0x04000020 RID: 32
		private RadCheckBoxElement checkBoxElement = new RadCheckBoxElement();

		// Token: 0x04000021 RID: 33
		private LightVisualElement textElement = new LightVisualElement();

		// Token: 0x04000022 RID: 34
		private StackLayoutElement stack = new StackLayoutElement();
	}
}
