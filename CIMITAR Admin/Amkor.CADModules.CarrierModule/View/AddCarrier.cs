using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Control;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000037 RID: 55
	public partial class AddCarrier : Form
	{
		// Token: 0x0600023C RID: 572 RVA: 0x00041837 File Offset: 0x0003FA37
		public AddCarrier()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0004185B File Offset: 0x0003FA5B
		public AddCarrier(CarrierInfo carrierInfo, SortedList authList)
		{
			this.InitializeComponent();
			this.CarrierInfo = carrierInfo;
			this._slAuthList = authList;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00041890 File Offset: 0x0003FA90
		private void ModifyItem_Load(object sender, EventArgs e)
		{
			this.lblTop.Text = this.sType + " " + this.Text;
			this.queryMgr = new QueryMgr(this._factorySetting);
			if (this.sType == "Create")
			{
				this.cmbStatus.Enabled = false;
				this.txtCleanCnt.Enabled = false;
				this.txtRepairCnt.Enabled = false;
				this.txtTouchDownCnt.Enabled = false;
				this.setInitComboText(this.cmbStatus, "Create");
				this.setInitComboText(this.cmbCorrelation, "생산 가능");
				this.setInitComboText(this.cmbCustomer, "QUALCOMM");
				this.setInitComboText(this.cmbCarrierType, "CARRIER");
				this.setInitComboText(this.cmbOpCode, "SLT(984)");
			}
			else if (this.sType == "Modify")
			{
				this.txtBarcode.Enabled = false;
				this.txtBarcode.Text = this.CarrierInfo.Barcode;
				this.txtPkgType.Text = this.CarrierInfo.PkgType;
				this.txtCarrierNo.Text = this.CarrierInfo.CarrierNo;
				this.txtRepairCnt.Text = this.CarrierInfo.repairCnt;
				this.txtCleanCnt.Text = this.CarrierInfo.CleanCnt;
				this.txtLimitCleanCnt.Text = this.CarrierInfo.LimitCleanCnt;
				this.txtLimitRepairCnt.Text = this.CarrierInfo.LimitrepairCnt;
				this.txtTouchDownCnt.Text = this.CarrierInfo.TouchDownCnt;
				this.txtMemo.Text = this.CarrierInfo.Memo;
				this.txtRevision.Text = this.CarrierInfo.Revision;
				this.txtMCN.Text = this.CarrierInfo.MCN;
				this.setInitComboText(this.cmbDevice, this.CarrierInfo.Device);
				this.setInitComboText(this.cmbCustomer, this.CarrierInfo.Customer);
				this.setInitComboText(this.cmbOpCode, this.CarrierInfo.OperationCode);
				this.setInitComboText(this.cmbCarrierType, this.CarrierInfo.CarrierType);
				this.setInitComboText(this.cmbTester, this.CarrierInfo.TesterName);
				this.setInitComboText(this.cmbStatus, this.CarrierInfo.Status);
				this.setInitComboText(this.cmbCorrelation, this.CarrierInfo.Correlation);
				this.setInitComboText(this.cmbSite, this.CarrierInfo.Site);
				this.setInitComboText(this.cmbLoadTester, this.CarrierInfo.LoadTester);
				if (!this._slAuthList.ContainsKey("CAD_CARRIER_ADMIN") && !this._slAuthList.ContainsKey("CAD_CARRIER_REGISTER"))
				{
					foreach (object obj in this.grpCarrierInfo.Controls)
					{
						Control control = (Control)obj;
						if (control.GetType().Name.ToUpper() == "TEXTBOX" || control.GetType().Name.ToUpper() == "COMBOBOX")
						{
							control.Enabled = false;
						}
					}
					this.grpFormat.Enabled = false;
					this.grpUpload.Enabled = false;
					this.txtRevision.Enabled = true;
					this.txtMemo.Enabled = true;
					this.cmbCorrelation.Enabled = true;
					this.cmbStatus.Enabled = true;
					this.cmbLoadTester.Enabled = true;
					this.cmdClose.Enabled = true;
				}
			}
			this.l_copyright.Text = "Copyright © 2017-" + DateTime.Today.Year.ToString() + " Amkor Technology Korea, Inc. All Rights Reserved.";
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00041C94 File Offset: 0x0003FE94
		private void setInitComboText(ComboBox combo, string sText)
		{
			combo.Items.Add(sText);
			combo.Text = sText;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00041CAC File Offset: 0x0003FEAC
		private DataSet getTypeDefinitionList(string sTypeName)
		{
			DataSet result = new DataSet();
			try
			{
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTypeDefList] @typename = '" + sTypeName + "'";
				result = this.queryMgr.queryCall(sQuery);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return result;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00041D00 File Offset: 0x0003FF00
		private DataSet getTypeDefinitionList(string sTypeName, ComboBox comboBox)
		{
			DataSet dataSet = new DataSet();
			try
			{
				comboBox.Items.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTypeDefList] @typename = '" + sTypeName + "'";
				dataSet = this.queryMgr.queryCall(sQuery);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					comboBox.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return dataSet;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00041DB0 File Offset: 0x0003FFB0
		private void cmbCustomer_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierCustomer", this.cmbCustomer);
			if (this.cmbCustomer.Items.Count > 0)
			{
				this.cmbCustomer.SelectedIndex = 0;
			}
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00041DE3 File Offset: 0x0003FFE3
		private void cmbSite_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("Site", this.cmbSite);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00041DF7 File Offset: 0x0003FFF7
		private void cmbStatus_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierStatus", this.cmbStatus);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00041E0B File Offset: 0x0004000B
		private void cmbCorrelation_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierCorrelation", this.cmbCorrelation);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00041E1F File Offset: 0x0004001F
		private void cmbTester_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierTester", this.cmbTester);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00041E33 File Offset: 0x00040033
		private void cmbCarrierType_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierType", this.cmbCarrierType);
			if (this.cmbCarrierType.Items.Count > 0)
			{
				this.cmbCarrierType.SelectedIndex = 0;
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00041E66 File Offset: 0x00040066
		private void cmbDevice_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierProduct", this.cmbDevice);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00041E7A File Offset: 0x0004007A
		private void cmbOpCode_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("Opcode", this.cmbOpCode);
			if (this.cmbOpCode.Items.Count > 1)
			{
				this.cmbOpCode.SelectedIndex = 0;
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00041EB0 File Offset: 0x000400B0
		private bool checkValue()
		{
			bool result = false;
			if (this.txtBarcode.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Input carrier barcode please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.cmbDevice.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Input device please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.cmbOpCode.Text.Trim() == string.Empty)
			{
				MessageBox.Show("select opcode please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.cmbCustomer.Text.Trim() == string.Empty)
			{
				MessageBox.Show("select customer please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.cmbCarrierType.Text.Trim() == string.Empty)
			{
				MessageBox.Show("select carrier type please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.cmbCorrelation.Text.Trim() == string.Empty)
			{
				MessageBox.Show("select correlation please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00041FF4 File Offset: 0x000401F4
		private void cmdModify_Click(object sender, EventArgs e)
		{
			try
			{
				string text = string.Empty;
				string sQuery = string.Empty;
				if (this.checkValue())
				{
					DialogResult dialogResult = MessageBox.Show("Do you want to " + this.sType + " carrier?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Yes)
					{
						if (this.cmbCorrelation.Text != string.Empty)
						{
							if (this.cmbCorrelation.Text == "생산 가능")
							{
								text = "1";
							}
							else if (this.cmbCorrelation.Text == "생산 불가능")
							{
								text = "0";
							}
						}
						sQuery = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_ApplyCarrier]  @type = '",
							this.sType,
							"', @location = '",
							this.txtBarcode.Text.Trim(),
							"', @device = '",
							this.cmbDevice.Text.Trim(),
							"', @carrierno = '",
							this.txtCarrierNo.Text.Trim(),
							"', @operationcode = '",
							this.cmbOpCode.Text.Trim(),
							"', @carriertype = '",
							this.cmbCarrierType.Text,
							"', @customerid = '",
							this.cmbCustomer.Text,
							"', @site = '",
							this.cmbSite.Text,
							"', @testername = '",
							this.cmbTester.Text.Trim(),
							"', @pkgtype = '",
							this.txtPkgType.Text.Trim(),
							"', @status = '",
							this.cmbStatus.Text.Trim(),
							"', @touchdowncnt = '",
							this.txtTouchDownCnt.Text.Trim(),
							"', @cleancnt = '",
							this.txtCleanCnt.Text.Trim(),
							"', @repaircnt = '",
							this.txtRepairCnt.Text.Trim(),
							"', @limitcleancnt = '",
							this.txtLimitCleanCnt.Text.Trim(),
							"', @limitrepaircnt = '",
							this.txtLimitRepairCnt.Text.Trim(),
							"', @correlation = '",
							text,
							"', @memo = N'",
							this.txtMemo.Text.Trim(),
							"', @userid = '",
							this._cimitarUser._id,
							"', @revision = '",
							this.txtRevision.Text.Trim(),
							"', @loadtester = '",
							this.cmbLoadTester.Text.Trim(),
							"', @MCN = '",
							this.txtMCN.Text.Trim(),
							"'"
						});
						DataSet dataSet = this.queryMgr.queryCall(sQuery);
						if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
						{
							if (dataSet.Tables[0].Rows[0]["ReturnCode"].ToString() == "-1")
							{
								MessageBox.Show(dataSet.Tables[0].Rows[0]["ReturnValue"].ToString(), "Error");
							}
							else
							{
								MessageBox.Show("Carrier " + this.sType + " Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00042424 File Offset: 0x00040624
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
			base.Close();
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00042433 File Offset: 0x00040633
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00042441 File Offset: 0x00040641
		private void txtDevice_MouseDoubleClick(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00042443 File Offset: 0x00040643
		private void cmdModify_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00042460 File Offset: 0x00040660
		private void cmdModify_MouseLeave(object sender, EventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0004247D File Offset: 0x0004067D
		private void cmdModify_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0004249A File Offset: 0x0004069A
		private void cmdModify_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x000424A7 File Offset: 0x000406A7
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x000424C4 File Offset: 0x000406C4
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x000424E1 File Offset: 0x000406E1
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x000424FE File Offset: 0x000406FE
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0004250B File Offset: 0x0004070B
		private void cmdDownLoad_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdDownLoad.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00042528 File Offset: 0x00040728
		private void cmdDownLoad_MouseLeave(object sender, EventArgs e)
		{
			this.cmdDownLoad.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00042545 File Offset: 0x00040745
		private void cmdDownLoad_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdDownLoad.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00042562 File Offset: 0x00040762
		private void cmdDownLoad_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0004256F File Offset: 0x0004076F
		private void cmdUpload_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdUpload.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0004258C File Offset: 0x0004078C
		private void cmdUpload_MouseLeave(object sender, EventArgs e)
		{
			this.cmdUpload.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000425A9 File Offset: 0x000407A9
		private void cmdUpload_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdUpload.Image = Resources.OpenTable_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x000425C6 File Offset: 0x000407C6
		private void cmdUpload_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000425D4 File Offset: 0x000407D4
		private void cmdDownLoad_Click(object sender, EventArgs e)
		{
			this.saveFileDialog.DefaultExt = ".csv";
			this.saveFileDialog.Filter = "CSV files|*.csv|Excel files|*.xlsx";
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
					DataSet dataSet = new DataSet();
					string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetDownLoadFormat] @type = 'Carrier'";
					dataSet = this.queryMgr.queryCall(sQuery);
					if (this.saveFileDialog.FilterIndex == 1)
					{
						ExcelControl.SaveCSV(this.saveFileDialog.FileName, dataSet.Tables[0], this._cimitarUser._exeExcel);
					}
					else if (this.saveFileDialog.FilterIndex == 2)
					{
						ExcelControl.Save(this.saveFileDialog.FileName, dataSet.Tables[0], "UPLOAD", false, true);
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

		// Token: 0x06000260 RID: 608 RVA: 0x00042770 File Offset: 0x00040970
		private void cmdUpload_Click(object sender, EventArgs e)
		{
			SortedList sortedList = new SortedList();
			this.openFileDialog.DefaultExt = ".csv";
			this.openFileDialog.Filter = "CSV files|*.csv|Excel files|*.xlsx";
			this.openFileDialog.FilterIndex = 1;
			this.openFileDialog.FileName = string.Empty;
			try
			{
				DialogResult dialogResult = this.openFileDialog.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Uploading Format....");
					this._barPrograss.setValue(0);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					new DataSet();
					if (this.openFileDialog.FilterIndex == 1)
					{
						if (this.setCSVData(sortedList))
						{
							this.uploadData(sortedList);
						}
					}
					else if (this.openFileDialog.FilterIndex == 2 && this.setExcelData(sortedList))
					{
						this.uploadData(sortedList);
					}
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
					if (sortedList.Count > 0)
					{
						new ResultView
						{
							slResult = sortedList,
							sType = "View",
							Caption = "Upload Result"
						}.ShowDialog();
					}
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

		// Token: 0x06000261 RID: 609 RVA: 0x000428F8 File Offset: 0x00040AF8
		private bool setExcelData(SortedList slData)
		{
			try
			{
				OleDbConnection oleDbConnection = new OleDbConnection();
				string format = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.openFileDialog.FileName + ";Mode=ReadWrite|Share Deny None;Extended Properties='Excel 12.0; HDR=yes; IMEX=1';Persist Security Info=False";
				oleDbConnection = new OleDbConnection(string.Format(format, this.openFileDialog.FileName));
				oleDbConnection.Open();
				DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[]
				{
					null,
					null,
					null,
					"TABLE"
				});
				DataSet dataSet = new DataSet();
				if (oleDbSchemaTable.Rows.Count == 0)
				{
					MessageBox.Show("Uploading data does not exist.", "Error");
					return false;
				}
				for (int i = 0; i < oleDbSchemaTable.Rows.Count; i++)
				{
					if (oleDbSchemaTable.Rows[i]["TABLE_NAME"].ToString().ToUpper() == "UPLOAD$")
					{
						dataSet = new DataSet();
						string selectCommandText = "select * from [" + oleDbSchemaTable.Rows[i]["TABLE_NAME"] + "] where [location] <> '' ";
						OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(selectCommandText, oleDbConnection);
						oleDbDataAdapter.Fill(dataSet);
						if (dataSet.Tables[0].Rows.Count == 0)
						{
							MessageBox.Show("Uploading data does not exist.", "Error");
							return false;
						}
						for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
						{
							CarrierInfo carrierInfo = new CarrierInfo();
							carrierInfo.Barcode = dataSet.Tables[0].Rows[j][0].ToString().ToUpper().Trim();
							carrierInfo.Device = dataSet.Tables[0].Rows[j][1].ToString().ToUpper().Trim();
							carrierInfo.CarrierNo = dataSet.Tables[0].Rows[j][2].ToString().ToUpper().Trim();
							carrierInfo.OperationCode = dataSet.Tables[0].Rows[j][3].ToString().ToUpper().Trim();
							carrierInfo.CarrierType = dataSet.Tables[0].Rows[j][4].ToString().ToUpper().Trim();
							carrierInfo.Customer = dataSet.Tables[0].Rows[j][5].ToString().ToUpper().Trim();
							carrierInfo.Site = dataSet.Tables[0].Rows[j][6].ToString().ToUpper().Trim();
							carrierInfo.TesterName = dataSet.Tables[0].Rows[j][7].ToString().ToUpper().Trim();
							carrierInfo.PkgType = dataSet.Tables[0].Rows[j][8].ToString().ToUpper().Trim();
							carrierInfo.LimitCleanCnt = dataSet.Tables[0].Rows[j][10].ToString().ToUpper().Trim();
							carrierInfo.LimitrepairCnt = dataSet.Tables[0].Rows[j][11].ToString().ToUpper().Trim();
							carrierInfo.Memo = dataSet.Tables[0].Rows[j][13].ToString();
							carrierInfo.Revision = dataSet.Tables[0].Rows[j][14].ToString();
							carrierInfo.Status = "Create";
							carrierInfo.Correlation = "1";
							slData.Add(j + 1, carrierInfo);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				MessageBox.Show("Error : " + ex.Message.ToString(), "Error");
			}
			return true;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00042D94 File Offset: 0x00040F94
		private bool setCSVData(SortedList slData)
		{
			string text = string.Empty;
			try
			{
				using (StreamReader streamReader = new StreamReader(this.openFileDialog.FileName, Encoding.Default))
				{
					text = streamReader.ReadToEnd();
					streamReader.Close();
				}
				if (text == string.Empty)
				{
					MessageBox.Show("Uploading data does not exist.", "Error");
					return false;
				}
				string[] array = text.Split(new char[]
				{
					'\n'
				});
				string[] array2 = array[0].Split(new string[]
				{
					","
				}, StringSplitOptions.RemoveEmptyEntries);
				if (array2.Length < 15)
				{
					MessageBox.Show("Data format is wrong.", "Error");
					return false;
				}
				for (int i = 1; i < array.Length; i++)
				{
					string[] array3 = array[i].Split(new char[]
					{
						','
					});
					if (array3.Length == 15)
					{
						CarrierInfo carrierInfo = new CarrierInfo();
						carrierInfo.Barcode = array3[0].ToUpper().Trim();
						carrierInfo.Device = array3[1].ToUpper().Trim();
						carrierInfo.CarrierNo = array3[2].ToUpper().Trim();
						carrierInfo.OperationCode = array3[3].ToUpper().Trim();
						carrierInfo.CarrierType = array3[4].ToUpper().Trim();
						carrierInfo.Customer = array3[5].ToUpper().Trim();
						carrierInfo.Site = array3[6].ToUpper().Trim();
						carrierInfo.TesterName = array3[7].ToUpper().Trim();
						carrierInfo.PkgType = array3[8].ToUpper().Trim();
						carrierInfo.LimitCleanCnt = array3[10].ToUpper().Trim();
						carrierInfo.LimitrepairCnt = array3[11].ToUpper().Trim();
						carrierInfo.Memo = array3[13].Trim();
						carrierInfo.Revision = array3[14].Trim().Trim();
						carrierInfo.Status = "Create";
						carrierInfo.Correlation = "1";
						slData.Add(i, carrierInfo);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return true;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00043018 File Offset: 0x00041218
		private void uploadData(SortedList slData)
		{
			if (slData.Count > 0)
			{
				this._barPrograss.progress_label_set("Uploading....");
				this._barPrograss.setMax(slData.Count);
				for (int i = 0; i < slData.Count; i++)
				{
					CarrierInfo carrierInfo = (CarrierInfo)slData.GetByIndex(i);
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_Admin_ApplyCarrier]  @type = 'Create', @location = '",
						carrierInfo.Barcode,
						"', @device = '",
						carrierInfo.Device,
						"', @carrierno = '",
						carrierInfo.CarrierNo,
						"', @operationcode = '",
						carrierInfo.OperationCode,
						"', @carriertype = '",
						carrierInfo.CarrierType,
						"', @customerid = '",
						carrierInfo.Customer,
						"', @site = '",
						carrierInfo.Site,
						"', @testername = '",
						carrierInfo.TesterName,
						"', @pkgtype = '",
						carrierInfo.PkgType,
						"', @status = '",
						carrierInfo.Status,
						"', @limitcleancnt = '",
						carrierInfo.LimitCleanCnt,
						"', @limitrepaircnt = '",
						carrierInfo.LimitrepairCnt,
						"', @correlation = '",
						carrierInfo.Correlation,
						"', @memo = N'",
						carrierInfo.Memo,
						"', @userid = '",
						this._cimitarUser._id,
						"', @revision = '",
						carrierInfo.Revision,
						"'"
					});
					DataSet dataSet = this.queryMgr.queryCall(sQuery);
					if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
					{
						if (dataSet.Tables[0].Rows[0]["ReturnCode"].ToString() == "-1")
						{
							carrierInfo.Line = i + 1;
							carrierInfo.Result = "Fail";
							carrierInfo.Reason = dataSet.Tables[0].Rows[0]["ReturnValue"].ToString();
						}
						else
						{
							carrierInfo.Line = i + 1;
							carrierInfo.Result = "Success";
						}
					}
					this._barPrograss.setValue(i + 1);
				}
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000432B4 File Offset: 0x000414B4
		private void cmbLoadTester_DropDown(object sender, EventArgs e)
		{
			this.cmbLoadTester.Items.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTesterList]";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				this.cmbLoadTester.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00043338 File Offset: 0x00041538
		private void label7_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0400041A RID: 1050
		public FactorySettings _factorySetting;

		// Token: 0x0400041B RID: 1051
		public CIMitarAccount _cimitarUser;

		// Token: 0x0400041C RID: 1052
		public string sType;

		// Token: 0x0400041D RID: 1053
		private string _strFind = string.Empty;

		// Token: 0x0400041E RID: 1054
		private SortedList _slAuthList = new SortedList();

		// Token: 0x0400041F RID: 1055
		private QueryMgr queryMgr;

		// Token: 0x04000420 RID: 1056
		private CarrierInfo CarrierInfo;

		// Token: 0x04000421 RID: 1057
		private Thread _thread;

		// Token: 0x04000422 RID: 1058
		private BarPrograss _barPrograss;
	}
}
