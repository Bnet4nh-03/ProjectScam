using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Amkor.CADModules.SBLAnalysisModule.Control
{
	// Token: 0x0200000B RID: 11
	public class CheckedComboBox : ComboBox
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002928 File Offset: 0x00000B28
		// (set) Token: 0x0600001B RID: 27 RVA: 0x00002940 File Offset: 0x00000B40
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
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000294C File Offset: 0x00000B4C
		// (set) Token: 0x0600001D RID: 29 RVA: 0x0000296E File Offset: 0x00000B6E
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
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002984 File Offset: 0x00000B84
		// (set) Token: 0x0600001F RID: 31 RVA: 0x000029A6 File Offset: 0x00000BA6
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
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000029BC File Offset: 0x00000BBC
		public new CheckedListBox.ObjectCollection Items
		{
			get
			{
				return this.dropdown.List.Items;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000029E0 File Offset: 0x00000BE0
		public CheckedListBox.CheckedItemCollection CheckedItems
		{
			get
			{
				return this.dropdown.List.CheckedItems;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002A04 File Offset: 0x00000C04
		public CheckedListBox.CheckedIndexCollection CheckedIndices
		{
			get
			{
				return this.dropdown.List.CheckedIndices;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002A28 File Offset: 0x00000C28
		public bool ValueChanged
		{
			get
			{
				return this.dropdown.ValueChanged;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000024 RID: 36 RVA: 0x00002A48 File Offset: 0x00000C48
		// (remove) Token: 0x06000025 RID: 37 RVA: 0x00002A84 File Offset: 0x00000C84
		public event ItemCheckEventHandler ItemCheck;

		// Token: 0x06000026 RID: 38 RVA: 0x00002AC0 File Offset: 0x00000CC0
		public CheckedComboBox()
		{
			base.DrawMode = DrawMode.OwnerDrawVariable;
			this.valueSeparator = ", ";
			base.DropDownHeight = 1;
			base.DropDownStyle = ComboBoxStyle.DropDown;
			this.dropdown = new CheckedComboBox.Dropdown(this);
			this.CheckOnClick = true;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002B14 File Offset: 0x00000D14
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002B4C File Offset: 0x00000D4C
		protected override void OnDropDown(EventArgs e)
		{
			base.OnDropDown(e);
			this.DoDropDown();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002B60 File Offset: 0x00000D60
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

		// Token: 0x0600002A RID: 42 RVA: 0x00002C38 File Offset: 0x00000E38
		protected override void OnDropDownClosed(EventArgs e)
		{
			if (e is CheckedComboBox.Dropdown.CCBoxEventArgs)
			{
				base.OnDropDownClosed(e);
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002C60 File Offset: 0x00000E60
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				this.OnDropDown(null);
			}
			e.Handled = (!e.Alt && e.KeyCode != Keys.Tab && (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Home) && e.KeyCode != Keys.End);
			base.OnKeyDown(e);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002CDD File Offset: 0x00000EDD
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			e.Handled = true;
			base.OnKeyPress(e);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002CF0 File Offset: 0x00000EF0
		public bool GetItemChecked(int index)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			return this.dropdown.List.GetItemChecked(index);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002D44 File Offset: 0x00000F44
		public void SetItemChecked(int index, bool isChecked)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			this.dropdown.List.SetItemChecked(index, isChecked);
			this.Text = this.dropdown.GetCheckedItemsStringValue();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002DA8 File Offset: 0x00000FA8
		public CheckState GetItemCheckState(int index)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			return this.dropdown.List.GetItemCheckState(index);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002DFC File Offset: 0x00000FFC
		public void SetItemCheckState(int index, CheckState state)
		{
			if (index < 0 || index > this.Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", "value out of range");
			}
			this.dropdown.List.SetItemCheckState(index, state);
			this.Text = this.dropdown.GetCheckedItemsStringValue();
		}

		// Token: 0x04000043 RID: 67
		private IContainer components = null;

		// Token: 0x04000044 RID: 68
		private CheckedComboBox.Dropdown dropdown;

		// Token: 0x04000045 RID: 69
		private string valueSeparator;

		// Token: 0x0200000C RID: 12
		internal class Dropdown : Form
		{
			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000031 RID: 49 RVA: 0x00002E60 File Offset: 0x00001060
			public bool ValueChanged
			{
				get
				{
					string text = this.ccbParent.Text;
					bool result;
					if (this.oldStrValue.Length > 0 && text.Length > 0)
					{
						result = (this.oldStrValue.CompareTo(text) != 0);
					}
					else
					{
						result = (this.oldStrValue.Length != text.Length);
					}
					return result;
				}
			}

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x06000032 RID: 50 RVA: 0x00002ED0 File Offset: 0x000010D0
			// (set) Token: 0x06000033 RID: 51 RVA: 0x00002EE8 File Offset: 0x000010E8
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

			// Token: 0x06000034 RID: 52 RVA: 0x00002EF4 File Offset: 0x000010F4
			public Dropdown(CheckedComboBox ccbParent)
			{
				this.ccbParent = ccbParent;
				this.InitializeComponent();
				base.ShowInTaskbar = false;
				this.cclb.ItemCheck += this.cclb_ItemCheck;
			}

			// Token: 0x06000035 RID: 53 RVA: 0x00002F4C File Offset: 0x0000114C
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

			// Token: 0x06000036 RID: 54 RVA: 0x00003068 File Offset: 0x00001268
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

			// Token: 0x06000037 RID: 55 RVA: 0x00003120 File Offset: 0x00001320
			public void CloseDropdown(bool enactChanges)
			{
				if (!this.dropdownClosed)
				{
					Debug.WriteLine("CloseDropdown");
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
			}

			// Token: 0x06000038 RID: 56 RVA: 0x000031DC File Offset: 0x000013DC
			protected override void OnActivated(EventArgs e)
			{
				Debug.WriteLine("OnActivated");
				base.OnActivated(e);
				this.dropdownClosed = false;
				this.oldStrValue = this.ccbParent.Text;
				this.checkedStateArr = new bool[this.cclb.Items.Count];
				for (int i = 0; i < this.cclb.Items.Count; i++)
				{
					this.checkedStateArr[i] = this.cclb.GetItemChecked(i);
				}
			}

			// Token: 0x06000039 RID: 57 RVA: 0x00003268 File Offset: 0x00001468
			protected override void OnDeactivate(EventArgs e)
			{
				Debug.WriteLine("OnDeactivate");
				base.OnDeactivate(e);
				CheckedComboBox.Dropdown.CCBoxEventArgs ccboxEventArgs = e as CheckedComboBox.Dropdown.CCBoxEventArgs;
				if (ccboxEventArgs != null)
				{
					this.CloseDropdown(ccboxEventArgs.AssignValues);
				}
				else
				{
					this.CloseDropdown(true);
				}
			}

			// Token: 0x0600003A RID: 58 RVA: 0x000032B4 File Offset: 0x000014B4
			private void cclb_ItemCheck(object sender, ItemCheckEventArgs e)
			{
				if (this.ccbParent.ItemCheck != null)
				{
					this.ccbParent.ItemCheck(sender, e);
				}
			}

			// Token: 0x04000047 RID: 71
			private CheckedComboBox ccbParent;

			// Token: 0x04000048 RID: 72
			private string oldStrValue = "";

			// Token: 0x04000049 RID: 73
			private bool[] checkedStateArr;

			// Token: 0x0400004A RID: 74
			private bool dropdownClosed = true;

			// Token: 0x0400004B RID: 75
			private CheckedComboBox.Dropdown.CustomCheckedListBox cclb;

			// Token: 0x0200000D RID: 13
			internal class CCBoxEventArgs : EventArgs
			{
				// Token: 0x1700000D RID: 13
				// (get) Token: 0x0600003B RID: 59 RVA: 0x000032EC File Offset: 0x000014EC
				// (set) Token: 0x0600003C RID: 60 RVA: 0x00003304 File Offset: 0x00001504
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
				// (get) Token: 0x0600003D RID: 61 RVA: 0x00003310 File Offset: 0x00001510
				// (set) Token: 0x0600003E RID: 62 RVA: 0x00003328 File Offset: 0x00001528
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

				// Token: 0x0600003F RID: 63 RVA: 0x00003332 File Offset: 0x00001532
				public CCBoxEventArgs(EventArgs e, bool assignValues)
				{
					this.e = e;
					this.assignValues = assignValues;
				}

				// Token: 0x0400004C RID: 76
				private bool assignValues;

				// Token: 0x0400004D RID: 77
				private EventArgs e;
			}

			// Token: 0x0200000E RID: 14
			internal class CustomCheckedListBox : CheckedListBox
			{
				// Token: 0x06000040 RID: 64 RVA: 0x0000334B File Offset: 0x0000154B
				public CustomCheckedListBox()
				{
					this.SelectionMode = SelectionMode.One;
					base.HorizontalScrollbar = true;
				}

				// Token: 0x06000041 RID: 65 RVA: 0x00003370 File Offset: 0x00001570
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

				// Token: 0x06000042 RID: 66 RVA: 0x00003438 File Offset: 0x00001638
				protected override void OnMouseMove(MouseEventArgs e)
				{
					base.OnMouseMove(e);
					int num = base.IndexFromPoint(e.Location);
					Debug.WriteLine("Mouse over item: " + ((num >= 0) ? base.GetItemText(base.Items[num]) : "None"));
					if (num >= 0 && num != this.curSelIndex)
					{
						this.curSelIndex = num;
						base.SetSelected(num, true);
					}
				}

				// Token: 0x0400004E RID: 78
				private int curSelIndex = -1;
			}
		}
	}
}
