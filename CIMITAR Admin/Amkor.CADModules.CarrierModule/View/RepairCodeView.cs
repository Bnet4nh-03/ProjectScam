using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Control;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200004A RID: 74
	public partial class RepairCodeView : Form
	{
		// Token: 0x06000350 RID: 848 RVA: 0x000528AB File Offset: 0x00050AAB
		public RepairCodeView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000351 RID: 849 RVA: 0x000528CF File Offset: 0x00050ACF
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000352 RID: 850 RVA: 0x000528D7 File Offset: 0x00050AD7
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000353 RID: 851 RVA: 0x000528E5 File Offset: 0x00050AE5
		private void ResultView_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.initGrid();
			this.cmdCodeSearch_Click(null, null);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00052908 File Offset: 0x00050B08
		private void initGrid()
		{
			this.gridRepairCode.ColumnsCount = 7;
			this.gridRepairCode.RowsCount = 1;
			this.gridRepairCode.FixedRows = 1;
			this.gridRepairCode.FixedColumns = 2;
			this.gridRepairCode[0, 0] = new GridInfo.ColHeader("", false);
			this.gridRepairCode[0, 1] = new GridInfo.ColHeader("No", false);
			this.gridRepairCode[0, 2] = new GridInfo.ColHeader("Type", false);
			this.gridRepairCode[0, 3] = new GridInfo.ColHeader("Category", false);
			this.gridRepairCode[0, 4] = new GridInfo.ColHeader("Device", false);
			this.gridRepairCode[0, 5] = new GridInfo.ColHeader("Description", false);
			this.gridRepairCode[0, 6] = new GridInfo.ColHeader("DescriptionID", false);
			this.gridRepairCode.Columns[6].Visible = false;
			this.gridInfo.SetColumnCellColor(this.gridRepairCode, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridRepairCode);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x00052A38 File Offset: 0x00050C38
		private void cmbType_DropDown(object sender, EventArgs e)
		{
			this.cmbType.Items.Clear();
			this.cmbCategory.Items.Clear();
			this.cmbDevice.Items.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetReasonCode] @type = 'ReasonType'";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text = dataSet.Tables[0].Rows[i]["reasontype"].ToString();
					if (text == "Repair")
					{
						text = text.Replace("Repair", "Action");
					}
					if (text == "RepairFail")
					{
						text = text.Replace("RepairFail", "Cause");
					}
					this.cmbType.Items.Add(text);
				}
			}
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00052B50 File Offset: 0x00050D50
		private void cmbCategory_DropDown(object sender, EventArgs e)
		{
			this.cmbCategory.Items.Clear();
			this.cmbDevice.Items.Clear();
			if (this.cmbType.Text == string.Empty)
			{
				MessageBox.Show("select type please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetReasonCode] @type = 'ReasonCategory', @reasontype = '" + this.cmbType.Text + "'";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.cmbCategory.Items.Add(dataSet.Tables[0].Rows[i]["reasoncategory"].ToString());
				}
			}
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00052C50 File Offset: 0x00050E50
		private void cmbDevice_DropDown(object sender, EventArgs e)
		{
			this.cmbDevice.Items.Clear();
			if (this.cmbType.Text == string.Empty)
			{
				MessageBox.Show("select Type please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (this.cmbCategory.Text == string.Empty)
			{
				MessageBox.Show("select Category please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_GetReasonCode] @type = 'Device', @reasontype = '",
				this.cmbType.Text,
				"', @reasoncategory = '",
				this.cmbCategory.Text,
				"'"
			});
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.cmbDevice.Items.Add(dataSet.Tables[0].Rows[i]["device"].ToString());
				}
			}
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00052D94 File Offset: 0x00050F94
		private void cmbAddType_DropDown(object sender, EventArgs e)
		{
			this.cmbAddType.Items.Clear();
			this.cmbAddCategory.Items.Clear();
			this.cmbAddDevice.Items.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetReasonCode] @type = 'ReasonType'";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text = dataSet.Tables[0].Rows[i]["reasontype"].ToString();
					if (text == "Repair")
					{
						text = text.Replace("Repair", "Action");
					}
					if (text == "RepairFail")
					{
						text = text.Replace("RepairFail", "Cause");
					}
					this.cmbAddType.Items.Add(text);
				}
			}
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00052EAC File Offset: 0x000510AC
		private void cmbAddCategory_DropDown(object sender, EventArgs e)
		{
			this.cmbAddCategory.Items.Clear();
			this.cmbAddDevice.Items.Clear();
			if (this.cmbAddType.Text == string.Empty)
			{
				MessageBox.Show("select type please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetReasonCode] @type = 'ReasonCategory', @reasontype = '" + this.cmbAddType.Text + "'";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.cmbAddCategory.Items.Add(dataSet.Tables[0].Rows[i]["reasoncategory"].ToString());
				}
			}
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00052FAC File Offset: 0x000511AC
		private void cmbAddDevice_DropDown(object sender, EventArgs e)
		{
			this.cmbAddDevice.Items.Clear();
			if (this.cmbAddType.Text == string.Empty)
			{
				MessageBox.Show("select Type please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (this.cmbAddCategory.Text == string.Empty)
			{
				MessageBox.Show("select Category please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_GetReasonCode] @type = 'Device', @reasontype = '",
				this.cmbAddType.Text,
				"', @reasoncategory = '",
				this.cmbAddCategory.Text,
				"'"
			});
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.cmbAddDevice.Items.Add(dataSet.Tables[0].Rows[i]["device"].ToString());
				}
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x000530F0 File Offset: 0x000512F0
		private void cmdCodeSearch_Click(object sender, EventArgs e)
		{
			this.gridRepairCode.RowsCount = 1;
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_GetReasonCode] @type = 'Info', @reasontype = '",
				this.cmbType.Text,
				"', @reasoncategory = '",
				this.cmbCategory.Text,
				"', @device = '",
				this.cmbDevice.Text,
				"'"
			});
			this.dsReasonCode = this.queryMgr.queryCall(sQuery);
			if (this.dsReasonCode.Tables.Count > 0 && this.dsReasonCode.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < this.dsReasonCode.Tables[0].Rows.Count; i++)
				{
					this.gridRepairCode.Rows.Insert(this.gridRepairCode.RowsCount);
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 1] = new Cell((this.gridRepairCode.RowsCount - 1).ToString());
					string text = this.dsReasonCode.Tables[0].Rows[i]["reasontype"].ToString();
					if (text == "Repair")
					{
						text = text.Replace("Repair", "Action");
					}
					if (text == "RepairFail")
					{
						text = text.Replace("RepairFail", "Cause");
					}
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 2] = new Cell(text);
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 3] = new Cell(this.dsReasonCode.Tables[0].Rows[i]["reasoncategory"].ToString());
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 4] = new Cell(this.dsReasonCode.Tables[0].Rows[i]["device"].ToString());
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 5] = new Cell(this.dsReasonCode.Tables[0].Rows[i]["description"].ToString());
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 6] = new Cell(this.dsReasonCode.Tables[0].Rows[i]["reasoncodedescid"].ToString());
				}
				this.gridInfo.AutoSetGrid(this.gridRepairCode);
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00053408 File Offset: 0x00051608
		private void InitRepairData(string sString)
		{
			string empty = string.Empty;
			this.gridRepairCode.RowsCount = 1;
			string filterExpression = "[description] like '%" + sString + "%'";
			if (this.dsReasonCode.Tables.Count > 0 && this.dsReasonCode.Tables[0].Rows.Count > 0)
			{
				DataRow[] array = this.dsReasonCode.Tables[0].Select(filterExpression);
				for (int i = 0; i < array.Length; i++)
				{
					this.gridRepairCode.Rows.Insert(this.gridRepairCode.RowsCount);
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 1] = new Cell((this.gridRepairCode.RowsCount - 1).ToString());
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 2] = new Cell(array[i]["reasontype"].ToString());
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 3] = new Cell(array[i]["reasoncategory"].ToString());
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 4] = new Cell(array[i]["device"].ToString());
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 5] = new Cell(array[i]["description"].ToString());
					this.gridRepairCode[this.gridRepairCode.RowsCount - 1, 6] = new Cell(array[i]["reasoncodedescid"].ToString());
				}
				this.gridInfo.AutoSetGrid(this.gridRepairCode);
			}
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0005360F File Offset: 0x0005180F
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00053618 File Offset: 0x00051818
		private void cmdDownLoad_Click(object sender, EventArgs e)
		{
			this.saveFileDialog.DefaultExt = ".csv";
			this.saveFileDialog.Filter = "CSV files|*.csv";
			this.saveFileDialog.FilterIndex = 1;
			this.saveFileDialog.FileName = string.Empty;
			try
			{
				DialogResult dialogResult = this.saveFileDialog.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Downloading Format....");
					this._barPrograss.setValue(100);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					if (this.saveFileDialog.FilterIndex == 1)
					{
						ExcelControl.SaveCSV(this.saveFileDialog.FileName, this.gridRepairCode, this._cimitarUser._exeExcel);
					}
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00053754 File Offset: 0x00051954
		private void txtRepairCode_TextChanged(object sender, EventArgs e)
		{
			string text = this.txtRepairCode.Text;
			this.InitRepairData(text);
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00053774 File Offset: 0x00051974
		private void cmdAddCode_Click(object sender, EventArgs e)
		{
			if (this.cmbAddType.Text == string.Empty)
			{
				MessageBox.Show("select type please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (this.cmbAddCategory.Text.ToUpper().Trim() == string.Empty)
			{
				MessageBox.Show("select Category please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (this.txtAddCode.Text.Trim() == string.Empty)
			{
				MessageBox.Show("input Code please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if ((this.cmbAddType.Text.ToUpper().Trim() == "REPAIRFAIL" || this.cmbAddType.Text.ToUpper().Trim() == "CAUSE") && this.cmbAddDevice.Text.ToUpper().Trim() == string.Empty)
			{
				MessageBox.Show("select Device please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string text = this.cmbAddType.Text.Trim();
			if (text == "Action")
			{
				text = "Repair";
			}
			if (text == "Cause")
			{
				text = "RepairFail";
			}
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_SetReasonCode] @type = 'Insert', @reasontype = '",
				text,
				"', @reasoncategory = '",
				this.cmbAddCategory.Text,
				"', @device = '",
				this.cmbAddDevice.Text,
				"', @description = '",
				this.txtAddCode.Text,
				"'"
			});
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["ReturnCode"].ToString() == "-1")
			{
				MessageBox.Show("Fail : " + dataSet.Tables[0].Rows[0]["ReturnValue"].ToString(), "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			MessageBox.Show("Success", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			this.cmdCodeSearch_Click(null, null);
		}

		// Token: 0x06000361 RID: 865 RVA: 0x000539F0 File Offset: 0x00051BF0
		private void cmdDeleteCode_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			for (int i = 1; i < this.gridRepairCode.RowsCount; i++)
			{
				if ((bool)this.gridRepairCode[i, 0].Value)
				{
					text = text + this.gridRepairCode[i, 6].ToString() + ",";
				}
			}
			if (text == string.Empty)
			{
				MessageBox.Show("Check delete code item Please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			text = text.Substring(0, text.Length - 1);
			DialogResult dialogResult = MessageBox.Show("Do you want to delete code?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_SetReasonCode] @type = 'Delete', @descriptionid = '" + text + "'";
				this.queryMgr.queryCall(sQuery);
				this.cmdCodeSearch_Click(null, null);
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00053ABE File Offset: 0x00051CBE
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00053ADB File Offset: 0x00051CDB
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00053AF8 File Offset: 0x00051CF8
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00053B15 File Offset: 0x00051D15
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00053B22 File Offset: 0x00051D22
		private void cmdDownLoad_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdDownLoad.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00053B3F File Offset: 0x00051D3F
		private void cmdDownLoad_MouseLeave(object sender, EventArgs e)
		{
			this.cmdDownLoad.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00053B5C File Offset: 0x00051D5C
		private void cmdDownLoad_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdDownLoad.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00053B79 File Offset: 0x00051D79
		private void cmdDownLoad_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00053B86 File Offset: 0x00051D86
		private void cmdCodeSearch_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdCodeSearch.Image = Resources.Preview;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00053BA3 File Offset: 0x00051DA3
		private void cmdCodeSearch_MouseLeave(object sender, EventArgs e)
		{
			this.cmdCodeSearch.Image = Resources.Preview;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00053BC0 File Offset: 0x00051DC0
		private void cmdCodeSearch_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdCodeSearch.Image = Resources.Preview_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00053BDD File Offset: 0x00051DDD
		private void cmdCodeSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00053BEA File Offset: 0x00051DEA
		private void cmdAddCode_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdAddCode.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00053C07 File Offset: 0x00051E07
		private void cmdAddCode_MouseLeave(object sender, EventArgs e)
		{
			this.cmdAddCode.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00053C24 File Offset: 0x00051E24
		private void cmdAddCode_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdAddCode.Image = Resources.TableAdd_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00053C41 File Offset: 0x00051E41
		private void cmdAddCode_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00053C4E File Offset: 0x00051E4E
		private void cmdDeleteCode_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdDeleteCode.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00053C6B File Offset: 0x00051E6B
		private void cmdDeleteCode_MouseLeave(object sender, EventArgs e)
		{
			this.cmdDeleteCode.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00053C88 File Offset: 0x00051E88
		private void cmdDeleteCode_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdDeleteCode.Image = Resources.TableRemove_Donw;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00053CA5 File Offset: 0x00051EA5
		private void cmdDeleteCode_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00053CB2 File Offset: 0x00051EB2
		private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00053CB4 File Offset: 0x00051EB4
		private void cmbAddType_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x04000587 RID: 1415
		public FactorySettings _factorySetting;

		// Token: 0x04000588 RID: 1416
		public CIMitarAccount _cimitarUser;

		// Token: 0x04000589 RID: 1417
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x0400058A RID: 1418
		private DataSet dsReasonCode = new DataSet();

		// Token: 0x0400058B RID: 1419
		private QueryMgr queryMgr;

		// Token: 0x0400058C RID: 1420
		private Thread _thread;

		// Token: 0x0400058D RID: 1421
		private BarPrograss _barPrograss;

		// Token: 0x0200004B RID: 75
		public class GridColumn
		{
			// Token: 0x040005B7 RID: 1463
			public const int Check = 0;

			// Token: 0x040005B8 RID: 1464
			public const int No = 1;

			// Token: 0x040005B9 RID: 1465
			public const int Type = 2;

			// Token: 0x040005BA RID: 1466
			public const int Category = 3;

			// Token: 0x040005BB RID: 1467
			public const int Device = 4;

			// Token: 0x040005BC RID: 1468
			public const int Description = 5;

			// Token: 0x040005BD RID: 1469
			public const int DescriptionID = 6;
		}
	}
}
