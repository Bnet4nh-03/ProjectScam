using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Control;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using Microsoft.Office.Interop.Excel;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000036 RID: 54
	public partial class AddSocket : Form
	{
		// Token: 0x06000211 RID: 529 RVA: 0x0003EB07 File Offset: 0x0003CD07
		public AddSocket()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0003EB20 File Offset: 0x0003CD20
		public AddSocket(CSocketInfo cSocketInfo)
		{
			this.InitializeComponent();
			this._cSocketInfo = cSocketInfo;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0003EB40 File Offset: 0x0003CD40
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0003EB50 File Offset: 0x0003CD50
		private void AddSocket_Load(object sender, EventArgs e)
		{
			this.lblTop.Text = this.sType + " " + this.Text;
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.GetCustomer();
			this.GetDevice();
			this.GetStatus();
			this.GetTester();
			this.GetSocketType();
			if (this.sType == "Create")
			{
				this.cmbStatus.Enabled = false;
				this.cmdCommand.Enabled = false;
			}
			else if (this.sType == "Modify")
			{
				this.txtBarcode.Enabled = false;
				this.txtBarcode.Text = this._cSocketInfo.Barcode;
				this.txtPkgType.Text = this._cSocketInfo.PkgType;
				this.txtMfg.Text = this._cSocketInfo.Mfg;
				this.txtPn.Text = this._cSocketInfo.Pn;
				this.txtMemo.Text = this._cSocketInfo.Memo;
				this.cmbCustomer.SelectedItem = this._cSocketInfo.Customer;
				this.cmbDevice.SelectedItem = this._cSocketInfo.Device;
				this.cmbStatus.SelectedItem = this._cSocketInfo.Status;
				this.cmbTester.SelectedItem = this._cSocketInfo.TesterName;
				this.cmbSocketType.SelectedItem = this._cSocketInfo.SocketType;
				this.txtPkgType.DeselectAll();
				this.txtPkgType.SelectionLength = 0;
				base.Focus();
			}
			this.l_copyright.Text = "Copyright © 2017-" + DateTime.Today.Year.ToString() + " Amkor Technology Korea, Inc. All Rights Reserved.";
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0003ED28 File Offset: 0x0003CF28
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

		// Token: 0x06000216 RID: 534 RVA: 0x0003EDD8 File Offset: 0x0003CFD8
		private void setInitComboText(ComboBox combo, string sText)
		{
			combo.Items.Add(sText);
			combo.Text = sText;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0003EDEE File Offset: 0x0003CFEE
		private void GetCustomer()
		{
			this.getTypeDefinitionList("CarrierCustomer", this.cmbCustomer);
			if (this.cmbCustomer.Items.Count > 0)
			{
				this.cmbCustomer.SelectedIndex = 0;
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0003EE21 File Offset: 0x0003D021
		private void GetDevice()
		{
			this.getTypeDefinitionList("CarrierProduct", this.cmbDevice);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0003EE35 File Offset: 0x0003D035
		private void GetStatus()
		{
			this.getTypeDefinitionList("SocketStatus", this.cmbStatus);
			if (this.cmbStatus.Items.Count > 0)
			{
				this.cmbStatus.SelectedIndex = 0;
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0003EE68 File Offset: 0x0003D068
		private void GetTester()
		{
			this.getTypeDefinitionList("CarrierTester", this.cmbTester);
			if (this.cmbTester.Items.Count > 0)
			{
				this.cmbTester.SelectedIndex = 0;
			}
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0003EE9B File Offset: 0x0003D09B
		private void GetSocketType()
		{
			this.getTypeDefinitionList("SocketType", this.cmbSocketType);
			if (this.cmbTester.Items.Count > 0)
			{
				this.cmbTester.SelectedIndex = 0;
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0003EED0 File Offset: 0x0003D0D0
		private bool checkValue()
		{
			bool result = false;
			if (this.txtBarcode.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Please input socket barcode", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.cmbStatus.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Please select Status", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.cmbDevice.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Please select device", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.txtPkgType.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Please input pkgtype", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.txtMfg.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Please input Mfg", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.txtPn.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Please input pn", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.cmbCustomer.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Please select customer", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.cmbTester.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Please select TesterName", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0003F07C File Offset: 0x0003D27C
		private bool CheckChangeValue()
		{
			bool result = false;
			if (!this._cSocketInfo.Device.Equals(this.cmbDevice.Text.Trim()))
			{
				result = true;
			}
			if (!this._cSocketInfo.Pn.Equals(this.txtPn.Text.Trim()))
			{
				result = true;
			}
			if (!this._cSocketInfo.Customer.Equals(this.cmbCustomer.Text.Trim()))
			{
				result = true;
			}
			if (!this._cSocketInfo.PkgType.Equals(this.txtPkgType.Text.Trim()))
			{
				result = true;
			}
			if (!this._cSocketInfo.Mfg.Equals(this.txtMfg.Text.Trim()))
			{
				result = true;
			}
			if (!this._cSocketInfo.Status.Equals(this.cmbStatus.Text.Trim()))
			{
				result = true;
			}
			if (!this._cSocketInfo.Memo.Equals(this.txtMemo.Text.Trim()))
			{
				result = true;
			}
			if (!this._cSocketInfo.TesterName.Equals(this.cmbTester.Text.Trim()))
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0003F1AC File Offset: 0x0003D3AC
		private string ConvertString(object oCell)
		{
			string result;
			if (!string.IsNullOrEmpty((string)oCell))
			{
				result = oCell.ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0003F1DC File Offset: 0x0003D3DC
		private bool setExcelData(SortedList slData)
		{
			try
			{
				Application application = new ApplicationClass();
				Workbook workbook = application.Workbooks.Open(this.openFileDialog.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				Worksheet worksheet = workbook.Worksheets[1] as Worksheet;
				Range usedRange = worksheet.UsedRange;
				object[,] array = (object[,])usedRange.get_Value(Missing.Value);
				for (int i = 2; i <= array.GetLength(0); i++)
				{
					if (array.GetLength(1) == 9)
					{
						CSocketInfo csocketInfo = new CSocketInfo();
						csocketInfo.Barcode = this.ConvertString(array[i, 1]);
						csocketInfo.Device = this.ConvertString(array[i, 2]);
						csocketInfo.SocketType = this.ConvertString(array[i, 3]);
						csocketInfo.Pn = this.ConvertString(array[i, 4]);
						csocketInfo.Customer = this.ConvertString(array[i, 5]);
						csocketInfo.PkgType = this.ConvertString(array[i, 6]);
						csocketInfo.Mfg = this.ConvertString(array[i, 7]);
						csocketInfo.TesterName = this.ConvertString(array[i, 8]);
						csocketInfo.Memo = this.ConvertString(array[i, 9]);
						string status = this.cmbStatus.Items[0].ToString();
						csocketInfo.Status = status;
						slData.Add(i, csocketInfo);
					}
				}
				workbook.Close(true, Missing.Value, Missing.Value);
				application.Quit();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return true;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0003F3F8 File Offset: 0x0003D5F8
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
				if (array2.Length < 9)
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
					if (array3.Length == 9)
					{
						CSocketInfo csocketInfo = new CSocketInfo();
						csocketInfo.Barcode = array3[0].ToUpper().Trim();
						csocketInfo.Device = array3[1].ToUpper().Trim();
						csocketInfo.SocketType = array3[2].ToUpper().Trim();
						csocketInfo.Pn = array3[3].ToUpper().Trim();
						csocketInfo.Customer = array3[4].ToUpper().Trim();
						csocketInfo.PkgType = array3[5].ToUpper().Trim();
						csocketInfo.Mfg = array3[6].ToUpper().Trim();
						csocketInfo.TesterName = array3[7].ToUpper().Trim();
						csocketInfo.Memo = array3[8].ToUpper().Trim();
						string status = this.cmbStatus.Items[0].ToString();
						csocketInfo.Status = status;
						slData.Add(i, csocketInfo);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return true;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0003F634 File Offset: 0x0003D834
		private void uploadData(SortedList slData)
		{
			if (slData.Count > 0)
			{
				this._barPrograss.progress_label_set("Uploading....");
				this._barPrograss.setMax(slData.Count);
				for (int i = 0; i < slData.Count; i++)
				{
					CSocketInfo csocketInfo = (CSocketInfo)slData.GetByIndex(i);
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_Admin_ApplySocket]  @type = 'Create', @barcode = '",
						csocketInfo.Barcode,
						"', @device = '",
						csocketInfo.Device,
						"', @sockettype = '",
						csocketInfo.SocketType,
						"', @pn = '",
						csocketInfo.Pn,
						"', @customer = '",
						csocketInfo.Customer,
						"', @pkgtype = '",
						csocketInfo.PkgType,
						"', @mfg = '",
						csocketInfo.Mfg,
						"', @status = '",
						csocketInfo.Status,
						"', @memo = N'",
						csocketInfo.Memo,
						"', @testername = '",
						csocketInfo.TesterName,
						"', @userid = '",
						this._cimitarUser._id,
						"'"
					});
					DataSet dataSet = this.queryMgr.queryCall(sQuery);
					if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
					{
						if (dataSet.Tables[0].Rows[0]["ReturnCode"].ToString() == "-1")
						{
							csocketInfo.Line = i + 1;
							csocketInfo.Result = "Fail";
							csocketInfo.Reason = dataSet.Tables[0].Rows[0]["ReturnValue"].ToString();
						}
						else
						{
							csocketInfo.Line = i + 1;
							csocketInfo.Result = "Success";
						}
					}
					this._barPrograss.setValue(i + 1);
				}
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0003F866 File Offset: 0x0003DA66
		private void cmdModify_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0003F883 File Offset: 0x0003DA83
		private void cmdModify_MouseLeave(object sender, EventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0003F8A0 File Offset: 0x0003DAA0
		private void cmdModify_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0003F8BD File Offset: 0x0003DABD
		private void cmdModify_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0003F8CC File Offset: 0x0003DACC
		private void cmdModify_Click(object sender, EventArgs e)
		{
			try
			{
				string sQuery = string.Empty;
				if (this.checkValue())
				{
					if (this.sType == "Modify" && !this.CheckChangeValue())
					{
						MessageBox.Show("No value changed.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						DialogResult dialogResult = MessageBox.Show("Do you want to " + this.sType + " socket?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (dialogResult == DialogResult.Yes)
						{
							sQuery = string.Concat(new string[]
							{
								"EXEC [CIMitar_Factory].[dbo].[USP_Admin_ApplySocket]  @type = '",
								this.sType,
								"', @barcode = '",
								this.txtBarcode.Text.Trim(),
								"', @device = '",
								this.cmbDevice.Text.Trim(),
								"', @sockettype = '",
								this.cmbSocketType.Text.Trim(),
								"', @pn = '",
								this.txtPn.Text.Trim(),
								"', @customer = '",
								this.cmbCustomer.Text.Trim(),
								"', @pkgtype = '",
								this.txtPkgType.Text.Trim(),
								"', @mfg = '",
								this.txtMfg.Text.Trim(),
								"', @status = '",
								this.cmbStatus.Text.Trim(),
								"', @memo = N'",
								this.txtMemo.Text.Trim(),
								"', @testername = N'",
								this.cmbTester.Text.Trim(),
								"', @userid = '",
								this._cimitarUser._id,
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
									MessageBox.Show("Socket" + this.sType + " Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
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

		// Token: 0x06000227 RID: 551 RVA: 0x0003FBC0 File Offset: 0x0003DDC0
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0003FBDD File Offset: 0x0003DDDD
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0003FBFA File Offset: 0x0003DDFA
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0003FC17 File Offset: 0x0003DE17
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			base.DialogResult = DialogResult.No;
			base.Close();
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0003FC26 File Offset: 0x0003DE26
		private void cmdDownLoad_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdDownLoad.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0003FC43 File Offset: 0x0003DE43
		private void cmdDownLoad_MouseLeave(object sender, EventArgs e)
		{
			this.cmdDownLoad.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0003FC60 File Offset: 0x0003DE60
		private void cmdDownLoad_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdDownLoad.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0003FC7D File Offset: 0x0003DE7D
		private void cmdDownLoad_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0003FC8C File Offset: 0x0003DE8C
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
					string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetDownLoadFormat] @type = 'Socket'";
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

		// Token: 0x06000230 RID: 560 RVA: 0x0003FE28 File Offset: 0x0003E028
		private void cmdUpload_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdUpload.Image = Resources.OpenTable_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0003FE45 File Offset: 0x0003E045
		private void cmdUpload_MouseLeave(object sender, EventArgs e)
		{
			this.cmdUpload.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0003FE62 File Offset: 0x0003E062
		private void cmdUpload_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdUpload.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0003FE7F File Offset: 0x0003E07F
		private void cmdUpload_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0003FE8C File Offset: 0x0003E08C
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
						new ResultSocketView
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

		// Token: 0x06000235 RID: 565 RVA: 0x00040014 File Offset: 0x0003E214
		private void cmdCommand_Click(object sender, EventArgs e)
		{
			new AnsSocketComment(this._cSocketInfo.SocketId, this._cSocketInfo.Barcode)
			{
				_factorySetting = this._factorySetting,
				_cimitarUser = this._cimitarUser
			}.ShowDialog();
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0004005C File Offset: 0x0003E25C
		private void cmdCommand_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdCommand.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00040079 File Offset: 0x0003E279
		private void cmdCommand_MouseLeave(object sender, EventArgs e)
		{
			this.cmdCommand.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00040096 File Offset: 0x0003E296
		private void cmdCommand_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdCommand.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x000400B3 File Offset: 0x0003E2B3
		private void cmdCommand_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x040003EC RID: 1004
		public FactorySettings _factorySetting;

		// Token: 0x040003ED RID: 1005
		public CIMitarAccount _cimitarUser;

		// Token: 0x040003EE RID: 1006
		public string sType;

		// Token: 0x040003EF RID: 1007
		private string _strFind = string.Empty;

		// Token: 0x040003F0 RID: 1008
		private QueryMgr queryMgr;

		// Token: 0x040003F1 RID: 1009
		private CSocketInfo _cSocketInfo;

		// Token: 0x040003F2 RID: 1010
		private Thread _thread;

		// Token: 0x040003F3 RID: 1011
		private BarPrograss _barPrograss;
	}
}
