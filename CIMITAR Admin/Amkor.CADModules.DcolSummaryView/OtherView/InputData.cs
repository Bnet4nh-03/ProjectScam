using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.DcolSummaryView.Controls;
using Amkor.CADModules.DcolSummaryView.DataClass;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.DcolSummaryView.OtherView
{
	// Token: 0x0200000B RID: 11
	public partial class InputData : Form
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000026 RID: 38 RVA: 0x00004F18 File Offset: 0x00003118
		// (remove) Token: 0x06000027 RID: 39 RVA: 0x00004F50 File Offset: 0x00003150
		public event InputData.ChildFormSnedDataHandler ChildFormEvent;

		// Token: 0x06000028 RID: 40 RVA: 0x00004F85 File Offset: 0x00003185
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00004F93 File Offset: 0x00003193
		public InputData()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00004FAC File Offset: 0x000031AC
		private void InputData_Load(object sender, EventArgs e)
		{
			this.mData.lInputData.Clear();
			this.mData.sInputData = string.Empty;
			if (this.mData.sSearchType == "LOT")
			{
				this.rdoLot.CheckState = CheckState.Checked;
			}
			else
			{
				this.rdoSN.CheckState = CheckState.Checked;
			}
			this.gridView.TableElement.RowHeaderColumnWidth = 20;
			this.gridView.TableElement.CurrentRowHeaderImage = null;
			this.gridView.AllowAddNewRow = true;
			this.gridView.EnableGrouping = false;
			this.gridView.EnableSorting = false;
			this.gridView.EnableFiltering = false;
			this.gridView.ShowRowHeaderColumn = true;
			this.gridView.EnableHotTracking = false;
			this.gridView.RowCount = 15;
			this.gridView.ColumnCount = 1;
			this.gridView.SelectionMode = GridViewSelectionMode.CellSelect;
			this.gridView.MultiSelect = true;
			this.gridView.CurrentRow = this.gridView.Rows[0];
			this.gridView.Columns[0].Width = 250;
			this.gridView.Columns[0].HeaderText = this.mData.sSearchType;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00005100 File Offset: 0x00003300
		private void loadInputData()
		{
			this.mData.lInputData.Clear();
			this.mData.sInputData = string.Empty;
			this.openFileDialog1.Filter = "*.txt|*.TXT";
			this.openFileDialog1.FileName = string.Empty;
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				StreamReader streamReader = new StreamReader(this.openFileDialog1.FileName);
				string text = string.Empty;
				while ((text = streamReader.ReadLine()) != null)
				{
					string[] array = text.Split(new string[]
					{
						"\t"
					}, StringSplitOptions.RemoveEmptyEntries);
					if (array.Length > 0)
					{
						string text2 = array[0];
						this.mData.lInputData.Add(text2);
						cMainData cMainData = this.mData;
						cMainData.sInputData = cMainData.sInputData + text2 + ",";
					}
				}
				streamReader.Close();
				if (this.mData.sInputData != string.Empty)
				{
					this.mData.sInputData = this.mData.sInputData.Substring(0, this.mData.sInputData.Length - 1);
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00005220 File Offset: 0x00003420
		private void btnSearch_Click(object sender, EventArgs e)
		{
			this.mData.sInputData = string.Empty;
			this.mData.bNewDocFlag = this.chkNewDoc.Checked;
			for (int i = 0; i < this.gridView.RowCount; i++)
			{
				if (this.gridView.Rows[i].Cells[0].Value != null)
				{
					cMainData cMainData = this.mData;
					cMainData.sInputData = cMainData.sInputData + this.gridView.Rows[i].Cells[0].Value.ToString() + ",";
				}
			}
			if (this.mData.sInputData == string.Empty)
			{
				RadMessageBox.Show(this, "Check Input data please", "Warning", MessageBoxButtons.OK, RadMessageIcon.Error);
				return;
			}
			this.mData.sInputData = this.mData.sInputData.Substring(0, this.mData.sInputData.Length - 1);
			if (this.rdoLot.CheckState == CheckState.Checked)
			{
				this.mData.sSearchType = "LOT";
			}
			else
			{
				this.mData.sSearchType = "SN";
			}
			this.ChildFormEvent(this.mData);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00005368 File Offset: 0x00003568
		private void btnLoad_Click(object sender, EventArgs e)
		{
			this.loadInputData();
			if (this.mData.lInputData.Count == 0)
			{
				RadMessageBox.Show(this, "load Input data please", "Warning", MessageBoxButtons.OK, RadMessageIcon.Error);
				return;
			}
			if (this.mData.lInputData.Count > 300)
			{
				RadMessageBox.Show(this, "Check load Input data count : up to 300.", "Warning", MessageBoxButtons.OK, RadMessageIcon.Error);
				return;
			}
			this.gridView.Rows.Clear();
			this.gridView.RowCount = this.mData.lInputData.Count;
			for (int i = 0; i < this.mData.lInputData.Count; i++)
			{
				this.gridView.Rows[i].Cells[0].Value = this.mData.lInputData[i].ToString();
			}
		}

		// Token: 0x0400002E RID: 46
		public cMainData mData = new cMainData();

		// Token: 0x04000030 RID: 48
		private Thread _thread;

		// Token: 0x04000031 RID: 49
		private BarPrograss _barPrograss;

		// Token: 0x0200000C RID: 12
		// (Invoke) Token: 0x06000031 RID: 49
		public delegate void ChildFormSnedDataHandler(cMainData mData);
	}
}
