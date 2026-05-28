using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Amkor.CADModules.ESIModule.Control
{
	// Token: 0x0200001B RID: 27
	public class CheckedComboBox : ComboBox
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00003428 File Offset: 0x00001628
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00003430 File Offset: 0x00001630
		public string ValueSeparator
		{
			get
			{
				return this.valueSeparator;
			}
			set
			{
				this.valueSeparator = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00003439 File Offset: 0x00001639
		// (set) Token: 0x0600002E RID: 46 RVA: 0x0000344B File Offset: 0x0000164B
		public bool CheckOnClick
		{
			get
			{
				return this.dropdown.List.CheckOnClick;
			}
			set
			{
				this.dropdown.List.CheckOnClick = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002F RID: 47 RVA: 0x0000345E File Offset: 0x0000165E
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00003470 File Offset: 0x00001670
		public new string DisplayMember
		{
			get
			{
				return this.dropdown.List.DisplayMember;
			}
			set
			{
				this.dropdown.List.DisplayMember = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00003483 File Offset: 0x00001683
		public new CheckedListBox.ObjectCollection Items
		{
			get
			{
				return this.dropdown.List.Items;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00003495 File Offset: 0x00001695
		public CheckedListBox.CheckedItemCollection CheckedItems
		{
			get
			{
				return this.dropdown.List.CheckedItems;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000034A7 File Offset: 0x000016A7
		public CheckedListBox.CheckedIndexCollection CheckedIndices
		{
			get
			{
				return this.dropdown.List.CheckedIndices;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000034B9 File Offset: 0x000016B9
		public bool ValueChanged
		{
			get
			{
				return this.dropdown.ValueChanged;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000035 RID: 53 RVA: 0x000034C8 File Offset: 0x000016C8
		// (remove) Token: 0x06000036 RID: 54 RVA: 0x00003500 File Offset: 0x00001700
		public event ItemCheckEventHandler ItemCheck;

		// Token: 0x06000037 RID: 55 RVA: 0x00003535 File Offset: 0x00001735
		public CheckedComboBox()
		{
			base.DrawMode = DrawMode.OwnerDrawVariable;
			this.valueSeparator = ", ";
			base.DropDownHeight = 1;
			base.DropDownStyle = ComboBoxStyle.DropDown;
			this.dropdown = new CheckedComboBox.Dropdown(this);
			this.CheckOnClick = true;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003570 File Offset: 0x00001770
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000358F File Offset: 0x0000178F
		protected override void OnDropDown(EventArgs e)
		{
			base.OnDropDown(e);
			this.DoDropDown();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000035A0 File Offset: 0x000017A0
		private void DoDropDown()
		{
			if (!this.dropdown.Visible)
			{
				Rectangle rectangle = base.RectangleToScreen(base.ClientRectangle);
				this.dropdown.Location = new Point(rectangle.X, rectangle.Y + base.Size.Height);
				int num = this.dropdown.List.Items.Count;
				if (num > base.MaxDropDownItems)
				{
					num = base.MaxDropDownItems;
				}
				else if (num == 0)
				{
					num = 1;
				}
				this.dropdown.Size = new Size(base.DropDownWidth, this.dropdown.List.ItemHeight * num + 2);
				this.dropdown.Show(this);
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000365A File Offset: 0x0000185A
		protected override void OnDropDownClosed(EventArgs e)
		{
			if (e is CheckedComboBox.Dropdown.CCBoxEventArgs)
			{
				base.OnDropDownClosed(e);
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000366C File Offset: 0x0000186C
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				this.OnDropDown(null);
			}
			e.Handled = (!e.Alt && e.KeyCode != Keys.Tab && (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Home) && e.KeyCode != Keys.End);
			base.OnKeyDown(e);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000036DA File Offset: 0x000018DA
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			e.Handled = true;
			base.OnKeyPress(e);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000036EA File Offset: 0x000018EA
		public bool GetItemChecked(int index)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			return this.dropdown.List.GetItemChecked(index);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003720 File Offset: 0x00001920
		public void SetItemChecked(int index, bool isChecked)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			this.dropdown.List.SetItemChecked(index, isChecked);
			this.Text = this.dropdown.GetCheckedItemsStringValue();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003772 File Offset: 0x00001972
		public CheckState GetItemCheckState(int index)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			return this.dropdown.List.GetItemCheckState(index);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000037A8 File Offset: 0x000019A8
		public void SetItemCheckState(int index, CheckState state)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			this.dropdown.List.SetItemCheckState(index, state);
			this.Text = this.dropdown.GetCheckedItemsStringValue();
		}

		// Token: 0x040000F5 RID: 245
		private IContainer components;

		// Token: 0x040000F6 RID: 246
		private CheckedComboBox.Dropdown dropdown;

		// Token: 0x040000F7 RID: 247
		private string valueSeparator;

		// Token: 0x0200001C RID: 28
		internal class Dropdown : Form
		{
			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000042 RID: 66 RVA: 0x000037FC File Offset: 0x000019FC
			public bool ValueChanged
			{
				get
				{
					string text = this.ccbParent.Text;
					if (this.oldStrValue.Length > 0 && text.Length > 0)
					{
						return this.oldStrValue.CompareTo(text) != 0;
					}
					return this.oldStrValue.Length != text.Length;
				}
			}

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x06000043 RID: 67 RVA: 0x00003855 File Offset: 0x00001A55
			// (set) Token: 0x06000044 RID: 68 RVA: 0x0000385D File Offset: 0x00001A5D
			public CheckedComboBox.Dropdown.CustomCheckedListBox List
			{
				get
				{
					return this.cclb;
				}
				set
				{
					this.cclb = value;
				}
			}

			// Token: 0x06000045 RID: 69 RVA: 0x00003868 File Offset: 0x00001A68
			public Dropdown(CheckedComboBox ccbParent)
			{
				this.ccbParent = ccbParent;
				this.InitializeComponent();
				base.ShowInTaskbar = false;
				this.cclb.ItemCheck += this.cclb_ItemCheck;
			}

			// Token: 0x06000046 RID: 70 RVA: 0x000038B8 File Offset: 0x00001AB8
			private void InitializeComponent()
			{
				this.cclb = new CheckedComboBox.Dropdown.CustomCheckedListBox();
				base.SuspendLayout();
				this.cclb.BorderStyle = BorderStyle.None;
				this.cclb.Dock = DockStyle.Fill;
				this.cclb.FormattingEnabled = true;
				this.cclb.Location = new Point(0, 0);
				this.cclb.Name = "cclb";
				this.cclb.Size = new Size(47, 15);
				this.cclb.TabIndex = 0;
				base.AutoScaleDimensions = new SizeF(6f, 13f);
				base.AutoScaleMode = AutoScaleMode.Font;
				this.BackColor = SystemColors.Menu;
				base.ClientSize = new Size(47, 16);
				base.ControlBox = false;
				base.Controls.Add(this.cclb);
				this.ForeColor = SystemColors.ControlText;
				base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
				base.MinimizeBox = false;
				base.Name = "ccbParent";
				base.StartPosition = FormStartPosition.Manual;
				base.ResumeLayout(false);
			}

			// Token: 0x06000047 RID: 71 RVA: 0x000039BC File Offset: 0x00001BBC
			public string GetCheckedItemsStringValue()
			{
				StringBuilder stringBuilder = new StringBuilder("");
				for (int i = 0; i < this.cclb.CheckedItems.Count; i++)
				{
					stringBuilder.Append(this.cclb.GetItemText(this.cclb.CheckedItems[i])).Append(this.ccbParent.ValueSeparator);
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Remove(stringBuilder.Length - this.ccbParent.ValueSeparator.Length, this.ccbParent.ValueSeparator.Length);
				}
				return stringBuilder.ToString();
			}

			// Token: 0x06000048 RID: 72 RVA: 0x00003A60 File Offset: 0x00001C60
			public void CloseDropdown(bool enactChanges)
			{
				if (this.dropdownClosed)
				{
					return;
				}
				if (enactChanges)
				{
					this.ccbParent.SelectedIndex = -1;
					this.ccbParent.Text = this.GetCheckedItemsStringValue();
				}
				else
				{
					for (int i = 0; i < this.cclb.Items.Count; i++)
					{
						this.cclb.SetItemChecked(i, this.checkedStateArr[i]);
					}
				}
				this.dropdownClosed = true;
				this.ccbParent.Focus();
				base.Hide();
				this.ccbParent.OnDropDownClosed(new CheckedComboBox.Dropdown.CCBoxEventArgs(null, false));
			}

			// Token: 0x06000049 RID: 73 RVA: 0x00003AF4 File Offset: 0x00001CF4
			protected override void OnActivated(EventArgs e)
			{
				base.OnActivated(e);
				this.dropdownClosed = false;
				this.oldStrValue = this.ccbParent.Text;
				this.checkedStateArr = new bool[this.cclb.Items.Count];
				for (int i = 0; i < this.cclb.Items.Count; i++)
				{
					this.checkedStateArr[i] = this.cclb.GetItemChecked(i);
				}
			}

			// Token: 0x0600004A RID: 74 RVA: 0x00003B6C File Offset: 0x00001D6C
			protected override void OnDeactivate(EventArgs e)
			{
				base.OnDeactivate(e);
				CheckedComboBox.Dropdown.CCBoxEventArgs ccboxEventArgs = e as CheckedComboBox.Dropdown.CCBoxEventArgs;
				if (ccboxEventArgs != null)
				{
					this.CloseDropdown(ccboxEventArgs.AssignValues);
					return;
				}
				this.CloseDropdown(true);
			}

			// Token: 0x0600004B RID: 75 RVA: 0x00003B9E File Offset: 0x00001D9E
			private void cclb_ItemCheck(object sender, ItemCheckEventArgs e)
			{
				if (this.ccbParent.ItemCheck != null)
				{
					this.ccbParent.ItemCheck(sender, e);
				}
			}

			// Token: 0x040000F9 RID: 249
			private CheckedComboBox ccbParent;

			// Token: 0x040000FA RID: 250
			private string oldStrValue = "";

			// Token: 0x040000FB RID: 251
			private bool[] checkedStateArr;

			// Token: 0x040000FC RID: 252
			private bool dropdownClosed = true;

			// Token: 0x040000FD RID: 253
			private CheckedComboBox.Dropdown.CustomCheckedListBox cclb;

			// Token: 0x0200001D RID: 29
			internal class CCBoxEventArgs : EventArgs
			{
				// Token: 0x1700000D RID: 13
				// (get) Token: 0x0600004C RID: 76 RVA: 0x00003BBF File Offset: 0x00001DBF
				// (set) Token: 0x0600004D RID: 77 RVA: 0x00003BC7 File Offset: 0x00001DC7
				public bool AssignValues
				{
					get
					{
						return this.assignValues;
					}
					set
					{
						this.assignValues = value;
					}
				}

				// Token: 0x1700000E RID: 14
				// (get) Token: 0x0600004E RID: 78 RVA: 0x00003BD0 File Offset: 0x00001DD0
				// (set) Token: 0x0600004F RID: 79 RVA: 0x00003BD8 File Offset: 0x00001DD8
				public EventArgs EventArgs
				{
					get
					{
						return this.e;
					}
					set
					{
						this.e = value;
					}
				}

				// Token: 0x06000050 RID: 80 RVA: 0x00003BE1 File Offset: 0x00001DE1
				public CCBoxEventArgs(EventArgs e, bool assignValues)
				{
					this.e = e;
					this.assignValues = assignValues;
				}

				// Token: 0x040000FE RID: 254
				private bool assignValues;

				// Token: 0x040000FF RID: 255
				private EventArgs e;
			}

			// Token: 0x0200001E RID: 30
			internal class CustomCheckedListBox : CheckedListBox
			{
				// Token: 0x06000051 RID: 81 RVA: 0x00003BF7 File Offset: 0x00001DF7
				public CustomCheckedListBox()
				{
					this.SelectionMode = SelectionMode.One;
					base.HorizontalScrollbar = true;
				}

				// Token: 0x06000052 RID: 82 RVA: 0x00003C14 File Offset: 0x00001E14
				protected override void OnKeyDown(KeyEventArgs e)
				{
					if (e.KeyCode == Keys.Return)
					{
						((CheckedComboBox.Dropdown)base.Parent).OnDeactivate(new CheckedComboBox.Dropdown.CCBoxEventArgs(null, true));
						e.Handled = true;
					}
					else if (e.KeyCode == Keys.Escape)
					{
						((CheckedComboBox.Dropdown)base.Parent).OnDeactivate(new CheckedComboBox.Dropdown.CCBoxEventArgs(null, false));
						e.Handled = true;
					}
					else if (e.KeyCode == Keys.Delete)
					{
						for (int i = 0; i < base.Items.Count; i++)
						{
							base.SetItemChecked(i, e.Shift);
						}
						e.Handled = true;
					}
					base.OnKeyDown(e);
				}

				// Token: 0x06000053 RID: 83 RVA: 0x00003CB0 File Offset: 0x00001EB0
				protected override void OnMouseMove(MouseEventArgs e)
				{
					base.OnMouseMove(e);
					int num = base.IndexFromPoint(e.Location);
					if (num >= 0 && num != this.curSelIndex)
					{
						this.curSelIndex = num;
						base.SetSelected(num, true);
					}
				}

				// Token: 0x04000100 RID: 256
				private int curSelIndex = -1;
			}
		}
	}
}
