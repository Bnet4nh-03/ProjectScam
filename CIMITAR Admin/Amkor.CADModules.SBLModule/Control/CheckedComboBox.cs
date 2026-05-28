using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Amkor.CADModules.SBLModule.Control
{
	// Token: 0x02000011 RID: 17
	public class CheckedComboBox : ComboBox
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00004943 File Offset: 0x00002B43
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000494B File Offset: 0x00002B4B
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
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00004954 File Offset: 0x00002B54
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00004966 File Offset: 0x00002B66
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
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00004979 File Offset: 0x00002B79
		// (set) Token: 0x06000042 RID: 66 RVA: 0x0000498B File Offset: 0x00002B8B
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
		// (get) Token: 0x06000043 RID: 67 RVA: 0x0000499E File Offset: 0x00002B9E
		public new CheckedListBox.ObjectCollection Items
		{
			get
			{
				return this.dropdown.List.Items;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000049B0 File Offset: 0x00002BB0
		public CheckedListBox.CheckedItemCollection CheckedItems
		{
			get
			{
				return this.dropdown.List.CheckedItems;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000049C2 File Offset: 0x00002BC2
		public CheckedListBox.CheckedIndexCollection CheckedIndices
		{
			get
			{
				return this.dropdown.List.CheckedIndices;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000049D4 File Offset: 0x00002BD4
		public bool ValueChanged
		{
			get
			{
				return this.dropdown.ValueChanged;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000047 RID: 71 RVA: 0x000049E4 File Offset: 0x00002BE4
		// (remove) Token: 0x06000048 RID: 72 RVA: 0x00004A1C File Offset: 0x00002C1C
		public event ItemCheckEventHandler ItemCheck;

		// Token: 0x06000049 RID: 73 RVA: 0x00004A51 File Offset: 0x00002C51
		public CheckedComboBox()
		{
			base.DrawMode = DrawMode.OwnerDrawVariable;
			this.valueSeparator = ", ";
			base.DropDownHeight = 1;
			base.DropDownStyle = ComboBoxStyle.DropDown;
			this.dropdown = new CheckedComboBox.Dropdown(this);
			this.CheckOnClick = true;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00004A8C File Offset: 0x00002C8C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004AAB File Offset: 0x00002CAB
		protected override void OnDropDown(EventArgs e)
		{
			base.OnDropDown(e);
			this.DoDropDown();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004ABC File Offset: 0x00002CBC
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

		// Token: 0x0600004D RID: 77 RVA: 0x00004B76 File Offset: 0x00002D76
		protected override void OnDropDownClosed(EventArgs e)
		{
			if (e is CheckedComboBox.Dropdown.CCBoxEventArgs)
			{
				base.OnDropDownClosed(e);
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004B88 File Offset: 0x00002D88
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				this.OnDropDown(null);
			}
			e.Handled = (!e.Alt && e.KeyCode != Keys.Tab && (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Home) && e.KeyCode != Keys.End);
			base.OnKeyDown(e);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004BF6 File Offset: 0x00002DF6
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			e.Handled = true;
			base.OnKeyPress(e);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004C06 File Offset: 0x00002E06
		public bool GetItemChecked(int index)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			return this.dropdown.List.GetItemChecked(index);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004C3C File Offset: 0x00002E3C
		public void SetItemChecked(int index, bool isChecked)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			this.dropdown.List.SetItemChecked(index, isChecked);
			this.Text = this.dropdown.GetCheckedItemsStringValue();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004C8E File Offset: 0x00002E8E
		public CheckState GetItemCheckState(int index)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			return this.dropdown.List.GetItemCheckState(index);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004CC4 File Offset: 0x00002EC4
		public void SetItemCheckState(int index, CheckState state)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			this.dropdown.List.SetItemCheckState(index, state);
			this.Text = this.dropdown.GetCheckedItemsStringValue();
		}

		// Token: 0x04000068 RID: 104
		private IContainer components;

		// Token: 0x04000069 RID: 105
		private CheckedComboBox.Dropdown dropdown;

		// Token: 0x0400006A RID: 106
		private string valueSeparator;

		// Token: 0x02000012 RID: 18
		internal class Dropdown : Form
		{
			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000054 RID: 84 RVA: 0x00004D18 File Offset: 0x00002F18
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
			// (get) Token: 0x06000055 RID: 85 RVA: 0x00004D71 File Offset: 0x00002F71
			// (set) Token: 0x06000056 RID: 86 RVA: 0x00004D79 File Offset: 0x00002F79
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

			// Token: 0x06000057 RID: 87 RVA: 0x00004D84 File Offset: 0x00002F84
			public Dropdown(CheckedComboBox ccbParent)
			{
				this.ccbParent = ccbParent;
				this.InitializeComponent();
				base.ShowInTaskbar = false;
				this.cclb.ItemCheck += this.cclb_ItemCheck;
			}

			// Token: 0x06000058 RID: 88 RVA: 0x00004DD4 File Offset: 0x00002FD4
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

			// Token: 0x06000059 RID: 89 RVA: 0x00004EDC File Offset: 0x000030DC
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

			// Token: 0x0600005A RID: 90 RVA: 0x00004F80 File Offset: 0x00003180
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

			// Token: 0x0600005B RID: 91 RVA: 0x00005014 File Offset: 0x00003214
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

			// Token: 0x0600005C RID: 92 RVA: 0x0000508C File Offset: 0x0000328C
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

			// Token: 0x0600005D RID: 93 RVA: 0x000050BE File Offset: 0x000032BE
			private void cclb_ItemCheck(object sender, ItemCheckEventArgs e)
			{
				if (this.ccbParent.ItemCheck != null)
				{
					this.ccbParent.ItemCheck(sender, e);
				}
			}

			// Token: 0x0400006C RID: 108
			private CheckedComboBox ccbParent;

			// Token: 0x0400006D RID: 109
			private string oldStrValue = "";

			// Token: 0x0400006E RID: 110
			private bool[] checkedStateArr;

			// Token: 0x0400006F RID: 111
			private bool dropdownClosed = true;

			// Token: 0x04000070 RID: 112
			private CheckedComboBox.Dropdown.CustomCheckedListBox cclb;

			// Token: 0x02000013 RID: 19
			internal class CCBoxEventArgs : EventArgs
			{
				// Token: 0x1700000D RID: 13
				// (get) Token: 0x0600005E RID: 94 RVA: 0x000050DF File Offset: 0x000032DF
				// (set) Token: 0x0600005F RID: 95 RVA: 0x000050E7 File Offset: 0x000032E7
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
				// (get) Token: 0x06000060 RID: 96 RVA: 0x000050F0 File Offset: 0x000032F0
				// (set) Token: 0x06000061 RID: 97 RVA: 0x000050F8 File Offset: 0x000032F8
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

				// Token: 0x06000062 RID: 98 RVA: 0x00005101 File Offset: 0x00003301
				public CCBoxEventArgs(EventArgs e, bool assignValues)
				{
					this.e = e;
					this.assignValues = assignValues;
				}

				// Token: 0x04000071 RID: 113
				private bool assignValues;

				// Token: 0x04000072 RID: 114
				private EventArgs e;
			}

			// Token: 0x02000014 RID: 20
			internal class CustomCheckedListBox : CheckedListBox
			{
				// Token: 0x06000063 RID: 99 RVA: 0x00005117 File Offset: 0x00003317
				public CustomCheckedListBox()
				{
					this.SelectionMode = SelectionMode.One;
					base.HorizontalScrollbar = true;
				}

				// Token: 0x06000064 RID: 100 RVA: 0x00005134 File Offset: 0x00003334
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

				// Token: 0x06000065 RID: 101 RVA: 0x000051D0 File Offset: 0x000033D0
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

				// Token: 0x04000073 RID: 115
				private int curSelIndex = -1;
			}
		}
	}
}
