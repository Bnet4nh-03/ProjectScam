using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.RELUnitDataProcModule.UserControls
{
	// Token: 0x02000015 RID: 21
	public partial class InputData : RadForm
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000CA RID: 202 RVA: 0x0000E650 File Offset: 0x0000C850
		// (set) Token: 0x060000CB RID: 203 RVA: 0x0000E658 File Offset: 0x0000C858
		public string SearchType
		{
			get
			{
				return this._searchType;
			}
			set
			{
				this._searchType = value;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000CC RID: 204 RVA: 0x0000E664 File Offset: 0x0000C864
		// (remove) Token: 0x060000CD RID: 205 RVA: 0x0000E69C File Offset: 0x0000C89C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event InputData.ChildFormSnedDataHandler ChildFormEvent;

		// Token: 0x060000CE RID: 206 RVA: 0x0000E6D1 File Offset: 0x0000C8D1
		public InputData()
		{
			this.InitializeComponent();
			this.InitControl();
			this.SetEvent();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000E6F8 File Offset: 0x0000C8F8
		private void SetEvent()
		{
			this.btnLoad.Click += this.btnLoad_Click;
			this.btnSearch.Click += this.btnSearch_Click;
			base.Load += this.InputData_Load;
			this.rdoSN.CheckStateChanged += this.RdoSN_CheckStateChanged;
			this.rdoLot.CheckStateChanged += this.RdoLot_CheckStateChanged;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000E77C File Offset: 0x0000C97C
		private void RdoLot_CheckStateChanged(object sender, EventArgs e)
		{
			this._searchType = "LOT";
			bool flag = this.gridView.Columns.Count > 0;
			if (flag)
			{
				this.gridView.Columns[0].HeaderText = "LOT";
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000E7C8 File Offset: 0x0000C9C8
		private void RdoSN_CheckStateChanged(object sender, EventArgs e)
		{
			this._searchType = "SN";
			bool flag = this.gridView.Columns.Count > 0;
			if (flag)
			{
				this.gridView.Columns[0].HeaderText = "SN";
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000E814 File Offset: 0x0000CA14
		private void InputData_Load(object sender, EventArgs e)
		{
			this.gridView.Columns[0].HeaderText = this._searchType;
			bool flag = this._searchType.Equals("LOT");
			if (flag)
			{
				this.rdoLot.CheckState = CheckState.Checked;
			}
			else
			{
				this.rdoSN.CheckState = CheckState.Checked;
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000E870 File Offset: 0x0000CA70
		private void btnSearch_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			bool flag = this.gridView.Rows.Count == 0;
			if (flag)
			{
				RadMessageBox.Show(this, "Check Input data please", "Warning", MessageBoxButtons.OK, RadMessageIcon.Error);
			}
			else
			{
				foreach (GridViewRowInfo gridViewRowInfo in this.gridView.Rows)
				{
					GridViewDataRowInfo gridViewDataRowInfo = (GridViewDataRowInfo)gridViewRowInfo;
					bool flag2 = !string.IsNullOrEmpty(Convert.ToString(gridViewDataRowInfo.Cells[0].Value));
					if (flag2)
					{
						string str = text;
						object value = gridViewDataRowInfo.Cells[0].Value;
						text = str + ((value != null) ? value.ToString() : null) + ",";
					}
				}
				bool flag3 = !string.IsNullOrEmpty(text);
				if (flag3)
				{
					text = text.Substring(0, text.Length - 1);
				}
				this.ChildFormEvent(this.chkNewDoc.Checked, this._searchType, text);
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000E988 File Offset: 0x0000CB88
		private void btnLoad_Click(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			this.openFileDialog1.Filter = "*.txt|*.TXT";
			this.openFileDialog1.FileName = string.Empty;
			bool flag = this.openFileDialog1.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				using (StreamReader streamReader = new StreamReader(this.openFileDialog1.FileName))
				{
					string text = string.Empty;
					while ((text = streamReader.ReadLine()) != null)
					{
						string[] array = text.Split(new string[]
						{
							"\t"
						}, StringSplitOptions.RemoveEmptyEntries);
						bool flag2 = array.Length != 0;
						if (flag2)
						{
							list.Add(array[0]);
						}
					}
					streamReader.Close();
				}
			}
			bool flag3 = list.Count == 0;
			if (flag3)
			{
				RadMessageBox.Show(this, "load Input data please", "Warning", MessageBoxButtons.OK, RadMessageIcon.Error);
			}
			else
			{
				bool flag4 = list.Count > 300;
				if (flag4)
				{
					RadMessageBox.Show(this, "Check load Input data count : up to 300.", "Warning", MessageBoxButtons.OK, RadMessageIcon.Error);
				}
				else
				{
					this.gridView.Rows.Clear();
					this.gridView.RowCount = list.Count;
					for (int i = 0; i < list.Count; i++)
					{
						this.gridView.Rows[i].Cells[0].Value = list[i].ToString();
					}
				}
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000EB14 File Offset: 0x0000CD14
		private void InitControl()
		{
			this.gridView.TableElement.RowHeaderColumnWidth = 20;
			this.gridView.TableElement.CurrentRowHeaderImage = null;
			this.gridView.AllowAddNewRow = true;
			this.gridView.EnableGrouping = false;
			this.gridView.EnableSorting = false;
			this.gridView.EnableFiltering = false;
			this.gridView.ShowRowHeaderColumn = true;
			this.gridView.EnableHotTracking = false;
			this.gridView.MasterTemplate.AllowRowResize = false;
			this.gridView.RowCount = 15;
			this.gridView.ColumnCount = 1;
			this.gridView.SelectionMode = GridViewSelectionMode.CellSelect;
			this.gridView.MultiSelect = true;
			this.gridView.CurrentRow = this.gridView.Rows[0];
			this.gridView.Columns[0].Name = "Value";
			this.gridView.Columns[0].Width = 250;
		}

		// Token: 0x040000C9 RID: 201
		private string _searchType;

		// Token: 0x02000023 RID: 35
		// (Invoke) Token: 0x06000142 RID: 322
		public delegate void ChildFormSnedDataHandler(bool isNewDoc, string searchType, string cond);
	}
}
