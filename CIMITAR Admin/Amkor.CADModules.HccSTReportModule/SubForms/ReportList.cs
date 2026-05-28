using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;
using Amkor.CADModules.HccSTReportModule.Properties;
using DevAge.ComponentModel.Validator;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.HccSTReportModule.SubForms
{
	// Token: 0x02000009 RID: 9
	public partial class ReportList : Form
	{
		// Token: 0x06000045 RID: 69 RVA: 0x0000A8FB File Offset: 0x00008AFB
		public ReportList()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000A914 File Offset: 0x00008B14
		private void ReportList_Load(object sender, EventArgs e)
		{
			this._instance = HccSTReportModule._instance;
			this.Init();
			this.InitContextBox();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000A92D File Offset: 0x00008B2D
		private void ReportList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000A940 File Offset: 0x00008B40
		private void ResetGrid(Grid grid)
		{
			for (int i = grid.RowsCount - 1; i >= 0; i--)
			{
				grid.Rows.Remove(i);
			}
			grid.Selection.EnableMultiSelection = false;
			grid.BorderStyle = BorderStyle.FixedSingle;
			grid.SelectionMode = GridSelectionMode.Row;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000A988 File Offset: 0x00008B88
		private void SetHeaderInfo(string[] gridHeaders, Grid grid)
		{
			grid.ColumnsCount = gridHeaders.Length + 1;
			grid.FixedRows = 1;
			grid.FixedColumns = 1;
			grid.Rows.Insert(0);
			this.CreateColHeaderCheckBox(grid, new System.Windows.Forms.CheckBox());
			grid[0, 0] = new SourceGrid.Cells.ColumnHeader("");
			grid[0, 0].View = this._instance._cell_Header;
			for (int i = 0; i < gridHeaders.Length; i++)
			{
				grid[0, i + 1] = new SourceGrid.Cells.ColumnHeader(gridHeaders[i]);
				grid[0, i + 1].View = this._instance._cell_Header;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000AA2C File Offset: 0x00008C2C
		private void CreateColHeaderCheckBox(Grid grid, System.Windows.Forms.CheckBox checkBox)
		{
			try
			{
				Rectangle rectangle = grid.PositionToRectangle(new Position(0, 0));
				rectangle.Offset(8, 4);
				checkBox.Size = new Size(15, 15);
				checkBox.BackColor = Color.Transparent;
				checkBox.Location = rectangle.Location;
				checkBox.CheckedChanged += this.checkBox_CheckedChanged;
				grid.Controls.Add(checkBox);
				grid.Columns[0].MinimalWidth = 30;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000AAC8 File Offset: 0x00008CC8
		private void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
				if (((Grid)checkBox.Parent).RowsCount > 0)
				{
					for (int i = 1; i < ((Grid)checkBox.Parent).RowsCount; i++)
					{
						((Grid)checkBox.Parent)[i, 0].Value = checkBox.Checked;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000AB4C File Offset: 0x00008D4C
		public void SetGridInfo(List<CCommonVal> commonVals)
		{
			if (commonVals.Count == 0)
			{
				return;
			}
			this.ResetGrid(this.grid_Result);
			int num = 1;
			string text = "No,ID,Plant Code,Location,Hardware Type,Osat Codified ID, Osat Codified SN,Data Type";
			this.SetHeaderInfo(text.Split(new char[]
			{
				','
			}), this.grid_Result);
			this._instance._barPrograss = new BarPrograss();
			this._instance._barPrograss.progress_labelheader_set("Loading..");
			this._instance._barPrograss.setMax(commonVals.Count);
			this._instance._barPrograss.setValue(1);
			this._instance._thread = new Thread(new ThreadStart(this._instance.BarPrograssView));
			this._instance._thread.Start();
			List<CCommonVal> list = (from o in commonVals
			orderby o.dtLastStatusUpDate descending
			select o).ToList<CCommonVal>();
			try
			{
				if (list.Count != 0)
				{
					foreach (CCommonVal ccommonVal in list)
					{
						this.grid_Result.Rows.Insert(num);
						this.grid_Result[num, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
						this.grid_Result[num, 1] = new Cell(num);
						this.grid_Result[num, 2] = new Cell(ccommonVal.iId);
						this.grid_Result[num, 3] = new Cell(ccommonVal.strPlantCode);
						this.grid_Result[num, 4] = new Cell(ccommonVal.strLocation);
						this.grid_Result[num, 5] = new Cell(ccommonVal.strHwType);
						this.grid_Result[num, 6] = new Cell(ccommonVal.strOsatCodifiedId);
						this.grid_Result[num, 7] = new Cell(ccommonVal.strOsatCodifiedSn);
						this.grid_Result[num, 8] = new Cell(ccommonVal.strDataType);
						if (num % 2 != 0)
						{
							for (int i = 0; i < this.grid_Result.Columns.Count; i++)
							{
								if (i == 0)
								{
									this.grid_Result[num, i].View = this._instance._checkBox_Normal1;
								}
								else
								{
									this.grid_Result[num, i].View = this._instance._cell_Body1;
								}
							}
						}
						else
						{
							for (int i = 0; i < this.grid_Result.Columns.Count; i++)
							{
								if (i == 0)
								{
									this.grid_Result[num, i].View = this._instance._checkBox_Normal2;
								}
								else
								{
									this.grid_Result[num, i].View = this._instance._cell_Body2;
								}
							}
						}
						num++;
						this._instance._barPrograss.progress_increase();
					}
				}
				this.grid_Result.AutoSizeCells();
				Thread.Sleep(10);
				if (this._instance._barPrograss != null)
				{
					this._instance._barPrograss._ischeck = true;
				}
				this._instance._barPrograss = null;
			}
			catch (Exception ex)
			{
				Thread.Sleep(10);
				if (this._instance._barPrograss != null)
				{
					this._instance._barPrograss._ischeck = true;
				}
				this._instance._barPrograss = null;
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000AEF0 File Offset: 0x000090F0
		private void Init()
		{
			this.combo_Factory.Items.Clear();
			this.combo_Factory.Items.Add("K3");
			this.combo_Factory.Items.Add("K5");
			this.combo_Factory.SelectedIndex = 0;
			this._cCommonVals = this.GetList();
			this.SetGridInfo(this._cCommonVals);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000AF60 File Offset: 0x00009160
		private List<CCommonVal> GetList()
		{
			List<CCommonVal> list = new List<CCommonVal>();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ST_Report_INIT_Ctrl] @flag = 'GET_ALL', @factory = " + this.combo_Factory.Text;
			DataSet dataSet = this._instance._cComm.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					list.Add(new CCommonVal
					{
						iId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString()),
						strPeriod = dataSet.Tables[0].Rows[i]["period"].ToString(),
						strPlantCode = dataSet.Tables[0].Rows[i]["plant_code"].ToString(),
						strOwnership = dataSet.Tables[0].Rows[i]["ownership"].ToString(),
						strHwType = dataSet.Tables[0].Rows[i]["hardware_type"].ToString(),
						strSTDivName = dataSet.Tables[0].Rows[i]["st_division_name"].ToString(),
						strSTDivHwId = dataSet.Tables[0].Rows[i]["st_division_hw_id"].ToString(),
						iGobmAssetNumber = int.Parse(dataSet.Tables[0].Rows[i]["gobm_asset_number"].ToString()),
						strOsatCodifiedId = dataSet.Tables[0].Rows[i]["osat_codified_id"].ToString(),
						strOsatCodifiedSn = dataSet.Tables[0].Rows[i]["osat_codified_sn"].ToString(),
						strConditionStatus = dataSet.Tables[0].Rows[i]["condition_status"].ToString(),
						dtLastStatusUpDate = DateTime.Parse(dataSet.Tables[0].Rows[i]["last_status_update_date"].ToString()),
						strDevFamily = dataSet.Tables[0].Rows[i]["device_family"].ToString(),
						strLocation = dataSet.Tables[0].Rows[i]["location"].ToString(),
						dtRecvDate = DateTime.Parse(dataSet.Tables[0].Rows[i]["receive_date"].ToString()),
						strTransTrackingNo = dataSet.Tables[0].Rows[i]["transfer_tracking_no"].ToString(),
						strIncommChkReportNo = dataSet.Tables[0].Rows[i]["incomming_check_report_number"].ToString(),
						strRemark = dataSet.Tables[0].Rows[i]["remark"].ToString(),
						strDataType = dataSet.Tables[0].Rows[i]["datatype"].ToString(),
						iDataTypeId = int.Parse(dataSet.Tables[0].Rows[i]["datatype_id"].ToString())
					});
				}
			}
			return list;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000B3A0 File Offset: 0x000095A0
		private void InitContextBox()
		{
			this._cntxtMenu_SetOnFlag.Items.Clear();
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Delete");
			toolStripMenuItem.Image = Resources.TableRemove;
			toolStripMenuItem.Click += this._cntxtMenu_Delete_Click;
			this._cntxtMenu_SetOnFlag.Items.Add(toolStripMenuItem);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000B3F8 File Offset: 0x000095F8
		private void _cntxtMenu_Delete_Click(object sender, EventArgs e)
		{
			List<int> list = new List<int>();
			string str = string.Empty;
			for (int i = 1; i < this.grid_Result.Rows.Count; i++)
			{
				bool? @checked = ((SourceGrid.Cells.CheckBox)this.grid_Result[i, 0]).Checked;
				bool flag = true;
				if (@checked.GetValueOrDefault() == flag & @checked != null)
				{
					int item = int.Parse(this.grid_Result[i, 2].Value.ToString());
					str = this.grid_Result[i, 4].Value.ToString();
					list.Add(item);
				}
			}
			if (list.Count > 1)
			{
				MessageBox.Show("Select only one item");
				return;
			}
			DialogResult dialogResult = MessageBox.Show("Delete Barcode: " + str + "?", "Delete", MessageBoxButtons.YesNo);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ST_Report_INIT_Ctrl] @flag = 'DEL', @barcode = '" + str + "', @factory = " + this.combo_Factory.Text;
			DataSet dataSet = this._instance._cComm.QueryCall(sQuery);
			int num = 1;
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
				{
					num = int.Parse(dataSet.Tables[0].Rows[j]["result"].ToString());
				}
			}
			if (num == 0)
			{
				MessageBox.Show("Success to Delete");
				this._cCommonVals = this.GetList();
				this.SetGridInfo(this._cCommonVals);
				return;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000B5B8 File Offset: 0x000097B8
		private void grid_Result_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			this._cntxtMenu_SetOnFlag.Show(this.grid_Result, new Point(e.X, e.Y));
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000B5EA File Offset: 0x000097EA
		private void combo_Factory_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.combo_Factory.SelectedItem == null)
			{
				return;
			}
			this._cCommonVals = this.GetList();
			this.SetGridInfo(this._cCommonVals);
		}

		// Token: 0x0400007F RID: 127
		private HccSTReportModule _instance;

		// Token: 0x04000080 RID: 128
		private List<CCommonVal> _cCommonVals;

		// Token: 0x04000081 RID: 129
		private ContextMenuStrip _cntxtMenu_SetOnFlag = new ContextMenuStrip();
	}
}
