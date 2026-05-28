using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Amkor.CADModules.CarrierModule.Control
{
	// Token: 0x02000023 RID: 35
	public class CheckedComboBox : ComboBox
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600003A RID: 58 RVA: 0x000034AA File Offset: 0x000016AA
		// (set) Token: 0x0600003B RID: 59 RVA: 0x000034B2 File Offset: 0x000016B2
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
		// (get) Token: 0x0600003C RID: 60 RVA: 0x000034BB File Offset: 0x000016BB
		// (set) Token: 0x0600003D RID: 61 RVA: 0x000034CD File Offset: 0x000016CD
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
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000034E0 File Offset: 0x000016E0
		// (set) Token: 0x0600003F RID: 63 RVA: 0x000034F2 File Offset: 0x000016F2
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
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00003505 File Offset: 0x00001705
		public new CheckedListBox.ObjectCollection Items
		{
			get
			{
				return this.dropdown.List.Items;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00003517 File Offset: 0x00001717
		public CheckedListBox.CheckedItemCollection CheckedItems
		{
			get
			{
				return this.dropdown.List.CheckedItems;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00003529 File Offset: 0x00001729
		public CheckedListBox.CheckedIndexCollection CheckedIndices
		{
			get
			{
				return this.dropdown.List.CheckedIndices;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000043 RID: 67 RVA: 0x0000353B File Offset: 0x0000173B
		public bool ValueChanged
		{
			get
			{
				return this.dropdown.ValueChanged;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000044 RID: 68 RVA: 0x00003548 File Offset: 0x00001748
		// (remove) Token: 0x06000045 RID: 69 RVA: 0x00003580 File Offset: 0x00001780
		public event ItemCheckEventHandler ItemCheck;

		// Token: 0x06000046 RID: 70 RVA: 0x000035B5 File Offset: 0x000017B5
		public CheckedComboBox()
		{
			base.DrawMode = DrawMode.OwnerDrawVariable;
			this.valueSeparator = ", ";
			base.DropDownHeight = 1;
			base.DropDownStyle = ComboBoxStyle.DropDown;
			this.dropdown = new CheckedComboBox.Dropdown(this);
			this.CheckOnClick = true;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000035F0 File Offset: 0x000017F0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000360F File Offset: 0x0000180F
		protected override void OnDropDown(EventArgs e)
		{
			base.OnDropDown(e);
			this.DoDropDown();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003620 File Offset: 0x00001820
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

		// Token: 0x0600004A RID: 74 RVA: 0x000036DA File Offset: 0x000018DA
		protected override void OnDropDownClosed(EventArgs e)
		{
			if (e is CheckedComboBox.Dropdown.CCBoxEventArgs)
			{
				base.OnDropDownClosed(e);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000036EC File Offset: 0x000018EC
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				this.OnDropDown(null);
			}
			e.Handled = (!e.Alt && e.KeyCode != Keys.Tab && (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Home) && e.KeyCode != Keys.End);
			base.OnKeyDown(e);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000375A File Offset: 0x0000195A
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			e.Handled = true;
			base.OnKeyPress(e);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000376A File Offset: 0x0000196A
		public bool GetItemChecked(int index)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			return this.dropdown.List.GetItemChecked(index);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000037A0 File Offset: 0x000019A0
		public void SetItemChecked(int index, bool isChecked)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			this.dropdown.List.SetItemChecked(index, isChecked);
			this.Text = this.dropdown.GetCheckedItemsStringValue();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000037F2 File Offset: 0x000019F2
		public CheckState GetItemCheckState(int index)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			return this.dropdown.List.GetItemCheckState(index);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003828 File Offset: 0x00001A28
		public void SetItemCheckState(int index, CheckState state)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			this.dropdown.List.SetItemCheckState(index, state);
			this.Text = this.dropdown.GetCheckedItemsStringValue();
		}

		// Token: 0x04000148 RID: 328
		private IContainer components;

		// Token: 0x04000149 RID: 329
		private CheckedComboBox.Dropdown dropdown;

		// Token: 0x0400014A RID: 330
		private string valueSeparator;

		// Token: 0x02000024 RID: 36
		internal class Dropdown : Form
		{
			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000051 RID: 81 RVA: 0x0000387C File Offset: 0x00001A7C
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
			// (get) Token: 0x06000052 RID: 82 RVA: 0x000038D5 File Offset: 0x00001AD5
			// (set) Token: 0x06000053 RID: 83 RVA: 0x000038DD File Offset: 0x00001ADD
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

			// Token: 0x06000054 RID: 84 RVA: 0x000038E8 File Offset: 0x00001AE8
			public Dropdown(CheckedComboBox ccbParent)
			{
				this.ccbParent = ccbParent;
				this.InitializeComponent();
				base.ShowInTaskbar = false;
				this.cclb.ItemCheck += this.cclb_ItemCheck;
			}

			// Token: 0x06000055 RID: 85 RVA: 0x00003938 File Offset: 0x00001B38
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
				this.cclb.TabIndex = 20;
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

			// Token: 0x06000056 RID: 86 RVA: 0x00003A40 File Offset: 0x00001C40
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

			// Token: 0x06000057 RID: 87 RVA: 0x00003AE4 File Offset: 0x00001CE4
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

			// Token: 0x06000058 RID: 88 RVA: 0x00003B78 File Offset: 0x00001D78
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

			// Token: 0x06000059 RID: 89 RVA: 0x00003BF0 File Offset: 0x00001DF0
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

			// Token: 0x0600005A RID: 90 RVA: 0x00003C22 File Offset: 0x00001E22
			private void cclb_ItemCheck(object sender, ItemCheckEventArgs e)
			{
				if (this.ccbParent.ItemCheck != null)
				{
					this.ccbParent.ItemCheck(sender, e);
				}
			}

			// Token: 0x0400014C RID: 332
			private CheckedComboBox ccbParent;

			// Token: 0x0400014D RID: 333
			private string oldStrValue = "";

			// Token: 0x0400014E RID: 334
			private bool[] checkedStateArr;

			// Token: 0x0400014F RID: 335
			private bool dropdownClosed = true;

			// Token: 0x04000150 RID: 336
			private CheckedComboBox.Dropdown.CustomCheckedListBox cclb;

			// Token: 0x02000025 RID: 37
			internal class CCBoxEventArgs : EventArgs
			{
				// Token: 0x1700000D RID: 13
				// (get) Token: 0x0600005B RID: 91 RVA: 0x00003C43 File Offset: 0x00001E43
				// (set) Token: 0x0600005C RID: 92 RVA: 0x00003C4B File Offset: 0x00001E4B
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
				// (get) Token: 0x0600005D RID: 93 RVA: 0x00003C54 File Offset: 0x00001E54
				// (set) Token: 0x0600005E RID: 94 RVA: 0x00003C5C File Offset: 0x00001E5C
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

				// Token: 0x0600005F RID: 95 RVA: 0x00003C65 File Offset: 0x00001E65
				public CCBoxEventArgs(EventArgs e, bool assignValues)
				{
					this.e = e;
					this.assignValues = assignValues;
				}

				// Token: 0x04000151 RID: 337
				private bool assignValues;

				// Token: 0x04000152 RID: 338
				private EventArgs e;
			}

			// Token: 0x02000026 RID: 38
			internal class CustomCheckedListBox : CheckedListBox
			{
				// Token: 0x06000060 RID: 96 RVA: 0x00003C7B File Offset: 0x00001E7B
				public CustomCheckedListBox()
				{
					this.SelectionMode = SelectionMode.One;
					base.HorizontalScrollbar = true;
				}

				// Token: 0x06000061 RID: 97 RVA: 0x00003C98 File Offset: 0x00001E98
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

				// Token: 0x06000062 RID: 98 RVA: 0x00003D34 File Offset: 0x00001F34
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

				// Token: 0x04000153 RID: 339
				private int curSelIndex = -1;
			}
		}
	}
}
