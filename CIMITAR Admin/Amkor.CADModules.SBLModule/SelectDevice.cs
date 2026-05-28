using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000002 RID: 2
	public partial class SelectDevice : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public SelectDevice(RefInfo refinfo)
		{
			this._refInfo = refinfo;
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002065 File Offset: 0x00000265
		private void SelectDevice_Load(object sender, EventArgs e)
		{
			this.SetGrid(this._refInfo.al_Device);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002078 File Offset: 0x00000278
		protected override Point ScrollToControl(Control activeControl)
		{
			return this.DisplayRectangle.Location;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002094 File Offset: 0x00000294
		private void ResetGrid()
		{
			this.grid_device.Rows.Clear();
			this.grid_device.Selection.EnableMultiSelection = false;
			this.grid_device.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_device.CustomSort = true;
			this.grid_device.Rows.Clear();
			this.grid_device.Selection.EnableMultiSelection = false;
			this.grid_device.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_device.CustomSort = true;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002114 File Offset: 0x00000314
		private void SetGrid(ArrayList alist)
		{
			this.ResetGrid();
			SourceGrid.Cells.Views.Cell cell = new SourceGrid.Cells.Views.Cell();
			cell.BackColor = Color.FromArgb(130, 179, 237);
			cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			SourceGrid.Cells.Views.Cell cell2 = new SourceGrid.Cells.Views.Cell();
			cell2.BackColor = Color.FromArgb(255, 192, 203);
			this.grid_device.ColumnsCount = 3;
			this.grid_device.FixedRows = 1;
			this.grid_device.Rows.Insert(0);
			this.grid_device[0, 0] = new SourceGrid.Cells.ColumnHeader("#");
			this.grid_device[0, 0].View = cell;
			this.grid_device[0, 1] = new SourceGrid.Cells.ColumnHeader("Device");
			this.grid_device[0, 1].View = cell;
			this.grid_device[0, 2] = new SourceGrid.Cells.ColumnHeader("Customer");
			this.grid_device[0, 2].View = cell;
			int num = 1;
			if (alist != null)
			{
				foreach (object obj in alist)
				{
					DeviceList deviceList = (DeviceList)obj;
					this.grid_device.Rows.Insert(num);
					this.grid_device[num, 0] = new SourceGrid.Cells.Cell(deviceList.no);
					this.grid_device[num, 0].Tag = deviceList;
					this.grid_device[num, 1] = new SourceGrid.Cells.Cell(deviceList.Devicename);
					this.grid_device[num, 2] = new SourceGrid.Cells.Cell(deviceList.customername);
					num++;
				}
			}
			this.grid_device.AutoSizeCells();
			int num2 = 0;
			int num3 = 0;
			foreach (object obj2 in ((IEnumerable)this.grid_device.Columns))
			{
				GridColumn gridColumn = (GridColumn)obj2;
				num2 += gridColumn.Width;
			}
			foreach (RowInfo rowInfo in this.grid_device.Rows)
			{
				GridRow gridRow = (GridRow)rowInfo;
				num3 += gridRow.Height;
			}
			this.panel_grid.Height = num3 + 20;
			this.panel_grid.Width = num2 + 20;
			base.Width = this.panel_grid.Width + 50;
			if (base.Width < 350)
			{
				base.Width = 350;
			}
			if (this.panel_grid.Height > 350)
			{
				this.panel_grid.Height = 350;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000240C File Offset: 0x0000060C
		private void grid_device_MouseClick(object sender, MouseEventArgs e)
		{
			Grid grid = (Grid)sender;
			string empty = string.Empty;
			int row = grid.MouseDownPosition.Row;
			if (row >= 0 && this.grid_device[row, 0].Tag != null)
			{
				this._selectDevice = (DeviceList)this.grid_device[row, 0].Tag;
				this.label_selectedDevice.Text = this._selectDevice.Devicename;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002480 File Offset: 0x00000680
		private void button_Search_Click(object sender, EventArgs e)
		{
			if (this.textBox_filter.Text != "")
			{
				string value = this.textBox_filter.Text.ToUpper();
				ArrayList arrayList = new ArrayList();
				foreach (object obj in this._refInfo.al_Device)
				{
					DeviceList deviceList = (DeviceList)obj;
					if (deviceList.Devicename.ToUpper().Contains(value))
					{
						arrayList.Add(deviceList);
					}
					else if (deviceList.customername.ToUpper().Contains(value))
					{
						arrayList.Add(deviceList);
					}
				}
				this.SetGrid(arrayList);
				this.issearch = true;
				return;
			}
			if (this.issearch)
			{
				this.SetGrid(this._refInfo.al_Device);
				this.issearch = false;
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002574 File Offset: 0x00000774
		private void grid_device_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Grid grid = (Grid)sender;
			string empty = string.Empty;
			int row = grid.MouseDownPosition.Row;
			if (row >= 0 && this.grid_device[row, 0].Tag != null)
			{
				this._selectDevice = (DeviceList)this.grid_device[row, 0].Tag;
				this.label_selectedDevice.Text = this._selectDevice.Devicename;
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000025F5 File Offset: 0x000007F5
		private void button_select_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002604 File Offset: 0x00000804
		private void button_CF_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x04000001 RID: 1
		private bool issearch;

		// Token: 0x04000002 RID: 2
		public DeviceList _selectDevice;

		// Token: 0x04000003 RID: 3
		private RefInfo _refInfo;
	}
}
