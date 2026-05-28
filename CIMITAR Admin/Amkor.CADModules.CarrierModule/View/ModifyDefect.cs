using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Control;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000045 RID: 69
	public partial class ModifyDefect : Form
	{
		// Token: 0x060002F7 RID: 759 RVA: 0x0004CDF8 File Offset: 0x0004AFF8
		public ModifyDefect()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0004CE48 File Offset: 0x0004B048
		public ModifyDefect(CCarrierDataHistory history)
		{
			this.InitializeComponent();
			this.carrierhistory = history;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0004CE9F File Offset: 0x0004B09F
		// (set) Token: 0x060002FA RID: 762 RVA: 0x0004CEAC File Offset: 0x0004B0AC
		public string Caption
		{
			get
			{
				return this.lblTop.Text;
			}
			set
			{
				this.lblTop.Text = value;
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0004CEBA File Offset: 0x0004B0BA
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0004CEC8 File Offset: 0x0004B0C8
		private void ModifyDefect_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.initControl();
			this.getData();
			this.loadData();
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0004CEF0 File Offset: 0x0004B0F0
		private void loadData()
		{
			this.tabControl1.TabPages.Clear();
			this.addTabPage("TP1", "Reason");
			this.tabControl1.TabPages[0].Controls.Add(new RepairInfo("DefectStart"));
			this.addTabPage("TP2", "Action");
			this.tabControl1.TabPages[1].Controls.Add(new RepairInfo("DefectStart"));
			this.dsFailCode = this.getReasonCodeList("RepairFail", string.Empty, string.Empty, "TP1");
			this.dsRepairCode = this.getReasonCodeList("Repair", string.Empty, string.Empty, "TP2");
			this.getTypeDefinitionList("SIB_Damage", this.cmbDamage);
			this.getTypeDefinitionList("SIB_SuspectCause", this.cmbSuspectCause);
			if (this.carrierhistory.strid != null && this.carrierhistory.strid != string.Empty)
			{
				this.txtBarcode.Text = this.carrierhistory.strbarcode;
				this.txtRevision.Text = this.carrierhistory.strrevision;
				this.txtMemo.Text = this.carrierhistory.strmemo;
				this.cmbDamage.Text = this.carrierhistory.strdamage;
				this.cmbSuspectCause.Text = this.carrierhistory.strsuspectcause;
				DataSet deviceRepairCoe = this.getDeviceRepairCoe(this.dsFailCode, this.carrierhistory.strdevice);
				this.findRepairInfo("TP1").InitRepairData(deviceRepairCoe, "", true);
				this.findRepairInfo("TP1").getRepairCode(this.carrierhistory.strrepaircode);
				this.findRepairInfo("TP2").InitRepairData(this.dsRepairCode, "", true);
				this.findRepairInfo("TP2").getRepairCode(this.carrierhistory.strrepaircode1);
			}
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0004D0F4 File Offset: 0x0004B2F4
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

		// Token: 0x060002FF RID: 767 RVA: 0x0004D1A4 File Offset: 0x0004B3A4
		private void addTabPage(string sPageName, string sPageText)
		{
			TabPage tabPage = new TabPage();
			tabPage.Location = new Point(4, 22);
			tabPage.Name = sPageName;
			tabPage.Text = sPageText;
			tabPage.Padding = new Padding(3);
			tabPage.Size = new Size(1, 1);
			tabPage.Font = new Font("Segoe UI", 8.25f);
			tabPage.TabIndex = 0;
			tabPage.UseVisualStyleBackColor = true;
			this.tabControl1.TabPages.Add(tabPage);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0004D220 File Offset: 0x0004B420
		private DataSet getReasonCodeList(string sReasonType, string sReasonCategory, string sDevice, string sPageName)
		{
			DataSet dataSet = new DataSet();
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_GetReasonCode] @type = 'Info', @reasontype = '",
				sReasonType,
				"', @reasoncategory = '",
				sReasonCategory,
				"', @device = '",
				sDevice,
				"'"
			});
			return this.queryMgr.queryCall(sQuery);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0004D27C File Offset: 0x0004B47C
		private DataSet getDeviceRepairCoe(DataSet dsCode, string sDevice)
		{
			DataSet dataSet = new DataSet();
			string filterExpression = string.Empty;
			if (sDevice != null && sDevice != string.Empty)
			{
				filterExpression = "[device] = '" + sDevice + "'";
			}
			if (dsCode.Tables.Count > 0 && dsCode.Tables[0].Rows.Count > 0)
			{
				dataSet = dsCode.Clone();
				DataRow[] array = dsCode.Tables[0].Select(filterExpression);
				foreach (DataRow row in array)
				{
					dataSet.Tables[0].ImportRow(row);
				}
			}
			return dataSet;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0004D328 File Offset: 0x0004B528
		private void initControl()
		{
			this.gridDefectList.ColumnsCount = 15;
			this.gridDefectList.RowsCount = 1;
			this.gridDefectList.FixedRows = 1;
			this.gridDefectList.FixedColumns = 1;
			this.gridDefectList[0, 0] = new GridInfo.ColHeader("", false);
			this.gridDefectList[0, 1] = new GridInfo.ColHeader("No", false);
			this.gridDefectList[0, 2] = new GridInfo.ColHeader("Date", false);
			this.gridDefectList[0, 3] = new GridInfo.ColHeader("Barcode", false);
			this.gridDefectList[0, 4] = new GridInfo.ColHeader("Rev", false);
			this.gridDefectList[0, 5] = new GridInfo.ColHeader("Defect Code", false);
			this.gridDefectList[0, 6] = new GridInfo.ColHeader("Damage", false);
			this.gridDefectList[0, 7] = new GridInfo.ColHeader("Suspect Cause", false);
			this.gridDefectList[0, 8] = new GridInfo.ColHeader("Action", false);
			this.gridDefectList[0, 9] = new GridInfo.ColHeader("Remark", false);
			this.gridDefectList[0, 10] = new GridInfo.ColHeader("FileName", false);
			this.gridDefectList[0, 11] = new GridInfo.ColHeader("Reference", false);
			this.gridDefectList[0, 12] = new GridInfo.ColHeader("HistoryID", false);
			this.gridDefectList[0, 13] = new GridInfo.ColHeader("CarrierID", false);
			this.gridDefectList[0, 14] = new GridInfo.ColHeader("Device", false);
			this.gridDefectList.Columns[11].Visible = false;
			this.gridDefectList.Columns[12].Visible = false;
			this.gridDefectList.Columns[13].Visible = false;
			this.gridDefectList.Columns[14].Visible = false;
			CustomEvents customEvents = new CustomEvents();
			customEvents.Click += this.gridDefectList_CellClickEvent;
			this.gridDefectList.Controller.AddController(customEvents);
			this.gridInfo.SetColumnCellColor(this.gridDefectList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridDefectList);
			this.menuGrid = new ContextMenu();
			this.menuGrid.MenuItems.Clear();
			this.menuGrid.MenuItems.Add("Delete History", new EventHandler(this.deleteHistory));
			this.menuGrid.MenuItems.Add("Download File", new EventHandler(this.downloadFile));
			this.gridDefectList.ContextMenu = this.menuGrid;
			this.menupb = new ContextMenu();
			this.menupb.MenuItems.Clear();
			this.menupb.MenuItems.Add("Download File", new EventHandler(this.downloadFile));
			this.pbUploadImage.ContextMenu = this.menupb;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0004D650 File Offset: 0x0004B850
		private void getData()
		{
			this.gridDefectList.RowsCount = 1;
			string text = string.Empty;
			for (int i = 0; i < this.slDefectList.Count; i++)
			{
				CCarrierData ccarrierData = (CCarrierData)this.slDefectList.GetByIndex(i);
				for (int j = 0; j < ccarrierData.slCarrierDataHistory.Count; j++)
				{
					CCarrierDataHistory ccarrierDataHistory = (CCarrierDataHistory)ccarrierData.slCarrierDataHistory.GetByIndex(j);
					text = text + ccarrierDataHistory.strid + ",";
				}
			}
			if (text != string.Empty)
			{
				text = text.Substring(0, text.Length - 1);
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetDefectHistory]  @historyid = '" + text + "'";
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
				{
					byte[] array = Convert.FromBase64String(dataSet.Tables[0].Rows[k]["reference"].ToString());
					this.gridDefectList.Rows.Insert(this.gridDefectList.RowsCount);
					this.gridDefectList[k + 1, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
					this.gridDefectList[k + 1, 1] = new Cell(k + 1);
					this.gridDefectList[k + 1, 2] = new Cell(dataSet.Tables[0].Rows[k]["lasteventtime"].ToString());
					this.gridDefectList[k + 1, 3] = new Cell(dataSet.Tables[0].Rows[k]["barcode"].ToString());
					this.gridDefectList[k + 1, 4] = new Cell(dataSet.Tables[0].Rows[k]["revision"].ToString());
					this.gridDefectList[k + 1, 5] = new Cell(dataSet.Tables[0].Rows[k]["repaircode"].ToString());
					this.gridDefectList[k + 1, 6] = new Cell(dataSet.Tables[0].Rows[k]["damage"].ToString());
					this.gridDefectList[k + 1, 7] = new Cell(dataSet.Tables[0].Rows[k]["suspectcause"].ToString());
					this.gridDefectList[k + 1, 8] = new Cell(dataSet.Tables[0].Rows[k]["repaircode1"].ToString());
					this.gridDefectList[k + 1, 9] = new Cell(dataSet.Tables[0].Rows[k]["memo"].ToString());
					this.gridDefectList[k + 1, 10] = new Cell(dataSet.Tables[0].Rows[k]["name"].ToString());
					this.gridDefectList[k + 1, 11] = new Cell(array);
					this.gridDefectList[k + 1, 12] = new Cell(dataSet.Tables[0].Rows[k]["historyid"].ToString());
					this.gridDefectList[k + 1, 13] = new Cell(dataSet.Tables[0].Rows[k]["carrierid"].ToString());
					this.gridDefectList[k + 1, 14] = new Cell(dataSet.Tables[0].Rows[k]["device"].ToString());
					if (this.carrierhistory.strid == dataSet.Tables[0].Rows[k]["historyid"].ToString())
					{
						this.txtBarcode.Text = dataSet.Tables[0].Rows[k]["barcode"].ToString();
						this.txtRevision.Text = dataSet.Tables[0].Rows[k]["revision"].ToString();
						this.txtMemo.Text = dataSet.Tables[0].Rows[k]["memo"].ToString();
						this.txtAttachFile.Text = dataSet.Tables[0].Rows[k]["name"].ToString();
						if (array != null)
						{
							System.Drawing.Image image = (System.Drawing.Image)StreamManager.ByteArrayToObject(array);
							this.pbUploadImage.Image = image;
						}
					}
				}
				this.gridInfo.AutoSetGrid(this.gridDefectList);
			}
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0004DBF8 File Offset: 0x0004BDF8
		private void cmdUploadFile_Click(object sender, EventArgs e)
		{
			this.openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
			this.openFileDialog.FilterIndex = 1;
			this.openFileDialog.FileName = string.Empty;
			DialogResult dialogResult = this.openFileDialog.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				string a = Path.GetExtension(this.openFileDialog.FileName).ToUpper();
				if (a != ".BMP" && a != ".JPG" && a != ".GIF")
				{
					MessageBox.Show("Invalid file extension.\nOnly bmp, jpg, gif are available.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.openFileDialog.FileName = string.Empty;
					return;
				}
				System.Drawing.Image image = System.Drawing.Image.FromFile(this.openFileDialog.FileName);
				if (image.Size.Height > 800 || image.Size.Width > 800)
				{
					MessageBox.Show("Invalid file size.\nMax 800x800 image size are available.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.openFileDialog.FileName = string.Empty;
					return;
				}
				this.txtAttachFile.Text = this.openFileDialog.SafeFileName;
				this.pbUploadImage.Image = null;
				this.pbUploadImage.Image = image;
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0004DD34 File Offset: 0x0004BF34
		private void cmdApply_Click(object sender, EventArgs e)
		{
			if (this.txtBarcode.Text == string.Empty)
			{
				MessageBox.Show("Input barcode please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (this.cmbDamage.Text == string.Empty && this.cmbSuspectCause.Text != string.Empty)
			{
				MessageBox.Show("Input SIB Damage please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (this.cmbDamage.Text != string.Empty && this.cmbSuspectCause.Text == string.Empty)
			{
				MessageBox.Show("Input SIB Suspect Cause please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string text = string.Empty;
			if (this.pbUploadImage.Image != null)
			{
				byte[] array = StreamManager.ObjectToByteArray(this.pbUploadImage.Image);
				if (array != null)
				{
					text = Convert.ToBase64String(array);
				}
			}
			this.carrierhistory.strbarcode = this.txtBarcode.Text;
			this.carrierhistory.strrevision = this.txtRevision.Text;
			this.carrierhistory.strmemo = this.txtMemo.Text;
			this.carrierhistory.strdamage = this.cmbDamage.Text;
			this.carrierhistory.strsuspectcause = this.cmbSuspectCause.Text;
			this.carrierhistory.strrepaircode = this.findRepairInfo("TP1").setDefectCode();
			this.carrierhistory.strrepaircode1 = this.findRepairInfo("TP2").setDefectActionCode();
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetDefectHistory]  @historyid = '",
				this.carrierhistory.strid,
				"', @repaircode = '",
				this.carrierhistory.strrepaircode,
				"', @repaircode1 = '",
				this.carrierhistory.strrepaircode1,
				"', @revision = '",
				this.carrierhistory.strrevision,
				"', @memo = N'",
				this.carrierhistory.strmemo,
				"', @userid = '",
				this._cimitarUser._id,
				"', @filename = '",
				this.txtAttachFile.Text,
				"', @reference = '",
				text,
				"', @damage = '",
				this.carrierhistory.strdamage,
				"', @suspectcause = '",
				this.carrierhistory.strsuspectcause,
				"'"
			});
			this.queryMgr.queryCall(sQuery);
			MessageBox.Show("Modify success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			this.getData();
			this.gridDefectList.Refresh();
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0004DFE8 File Offset: 0x0004C1E8
		private void pbUploadImage_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				this.menupb.Show(this.pbUploadImage, new Point(e.X, e.Y));
			}
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0004E01C File Offset: 0x0004C21C
		private void gridDefectList_CellClickEvent(object sender, EventArgs e)
		{
			MouseEventArgs mouseEventArgs = (MouseEventArgs)e;
			if (mouseEventArgs.Button == MouseButtons.Right)
			{
				this.menuGrid.Show(this.gridDefectList, new Point(mouseEventArgs.X, mouseEventArgs.Y));
				return;
			}
			CellContext cellContext = (CellContext)sender;
			try
			{
				int row = cellContext.Position.Row;
				int column = cellContext.Position.Column;
				if (row > 0)
				{
					this.txtBarcode.Text = this.gridDefectList[row, 3].ToString();
					this.txtRevision.Text = this.gridDefectList[row, 4].ToString();
					this.txtMemo.Text = this.gridDefectList[row, 9].ToString();
					this.txtAttachFile.Text = this.gridDefectList[row, 10].ToString();
					this.cmbDamage.SelectedIndex = -1;
					this.cmbSuspectCause.SelectedIndex = -1;
					this.cmbDamage.Text = this.gridDefectList[row, 6].ToString();
					this.cmbSuspectCause.Text = this.gridDefectList[row, 7].ToString();
					this.carrierhistory.strid = this.gridDefectList[row, 12].ToString();
					this.carrierhistory.strdevice = this.gridDefectList[row, 14].ToString();
					DataSet deviceRepairCoe = this.getDeviceRepairCoe(this.dsFailCode, this.carrierhistory.strdevice);
					TabPage tabPage = (TabPage)base.Controls.Find("TP1", true)[0];
					RepairInfo repairInfo = (RepairInfo)tabPage.Controls[0];
					repairInfo.InitRepairData(deviceRepairCoe, "", true);
					repairInfo.getRepairCode(this.gridDefectList[row, 5].ToString());
					tabPage = (TabPage)base.Controls.Find("TP2", true)[0];
					repairInfo = (RepairInfo)tabPage.Controls[0];
					repairInfo.InitRepairData(this.dsRepairCode, "", true);
					repairInfo.getRepairCode(this.gridDefectList[row, 8].ToString());
					this.pbUploadImage.Image = null;
					byte[] buffer = (byte[])this.gridDefectList[row, 11].Value;
					System.Drawing.Image image = (System.Drawing.Image)StreamManager.ByteArrayToObject(buffer);
					this.pbUploadImage.Image = image;
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0004E2C4 File Offset: 0x0004C4C4
		private void pbUploadImage_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.pbUploadImage.Image != null)
			{
				DialogResult dialogResult = MessageBox.Show("Do you want to download image?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					this.downloadFile(null, null);
				}
			}
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0004E300 File Offset: 0x0004C500
		private void downloadFile(object sender, EventArgs e)
		{
			try
			{
				if (this.pbUploadImage.Image == null)
				{
					MessageBox.Show("download file is not exist", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					this.saveFileDialog.DefaultExt = ".jpg";
					this.saveFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
					this.saveFileDialog.FilterIndex = 1;
					this.saveFileDialog.FileName = this.txtAttachFile.Text;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this.pbUploadImage.Image.Save(this.saveFileDialog.FileName);
						MessageBox.Show("download complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						Process.Start(this.saveFileDialog.FileName);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				MessageBox.Show("download fail", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0004E3F8 File Offset: 0x0004C5F8
		private void deleteHistory(object sender, EventArgs e)
		{
			this.cmdDelete_Click(null, null);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0004E404 File Offset: 0x0004C604
		private void txtRepairCode_TextChanged(object sender, EventArgs e)
		{
			if (this.carrierhistory.strid != null && this.carrierhistory.strid != string.Empty)
			{
				string text = this.txtRepairCode.Text;
				DataSet deviceRepairCoe = this.getDeviceRepairCoe(this.dsFailCode, this.carrierhistory.strdevice);
				this.findRepairInfo("TP1").InitRepairData(deviceRepairCoe, text, false);
				this.findRepairInfo("TP2").InitRepairData(this.dsRepairCode, text, false);
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0004E484 File Offset: 0x0004C684
		private void saveExcel(Grid grid)
		{
			if (grid.RowsCount > 1)
			{
				this.saveFileDialog.DefaultExt = ".xlsx";
				this.saveFileDialog.Filter = "Excel files|*.xlsx|CSV files|*.csv";
				this.saveFileDialog.FilterIndex = 1;
				this.saveFileDialog.FileName = string.Empty;
				DialogResult dialogResult = this.saveFileDialog.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					if (this.saveFileDialog.FilterIndex == 1)
					{
						ExcelControl.Save(this.saveFileDialog.FileName, grid, true);
						return;
					}
					if (this.saveFileDialog.FilterIndex == 2)
					{
						ExcelControl.SaveCSV(this.saveFileDialog.FileName, grid, this._cimitarUser._exeExcel);
						return;
					}
				}
			}
			else
			{
				MessageBox.Show("data is not exist ", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0004E54A File Offset: 0x0004C74A
		private void cmdExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridDefectList);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0004E558 File Offset: 0x0004C758
		private void cmdDelete_Click(object sender, EventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 1; i < this.gridDefectList.RowsCount; i++)
			{
				if ((bool)this.gridDefectList[i, 0].Value)
				{
					arrayList.Add(this.gridDefectList[i, 12].ToString());
				}
			}
			if (arrayList.Count == 0)
			{
				MessageBox.Show("Check the defect history want to delete.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			DialogResult dialogResult = MessageBox.Show("Do you want to delete checked defect history?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				new DataSet();
				for (int j = 0; j < arrayList.Count; j++)
				{
					string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_DeleteDefectHistory]  @historyid = '" + arrayList[j] + "'";
					this.queryMgr.queryCall(sQuery);
					for (int k = 0; k < this.slDefectList.Count; k++)
					{
						CCarrierData ccarrierData = (CCarrierData)this.slDefectList.GetByIndex(k);
						for (int l = 0; l < ccarrierData.slCarrierDataHistory.Count; l++)
						{
							CCarrierDataHistory ccarrierDataHistory = (CCarrierDataHistory)ccarrierData.slCarrierDataHistory.GetByIndex(l);
							if (ccarrierDataHistory.strid == arrayList[j].ToString())
							{
								ccarrierData.slCarrierDataHistory.RemoveAt(l);
								break;
							}
						}
					}
				}
				this.txtBarcode.Text = string.Empty;
				this.txtAttachFile.Text = string.Empty;
				this.txtMemo.Text = string.Empty;
				this.txtRepairCode.Text = string.Empty;
				this.txtRevision.Text = string.Empty;
				this.carrierhistory.init();
				this.pbUploadImage.Image = null;
				this.findRepairInfo("TP1").InitData();
				this.findRepairInfo("TP2").InitData();
				this.getData();
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0004E748 File Offset: 0x0004C948
		private RepairInfo findRepairInfo(string sName)
		{
			return (RepairInfo)((TabPage)base.Controls.Find(sName, true)[0]).Controls[0];
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0004E77B File Offset: 0x0004C97B
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0004E78A File Offset: 0x0004C98A
		private void cmdApply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0004E7A7 File Offset: 0x0004C9A7
		private void cmdApply_MouseLeave(object sender, EventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0004E7C4 File Offset: 0x0004C9C4
		private void cmdApply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0004E7E1 File Offset: 0x0004C9E1
		private void cmdApply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0004E7EE File Offset: 0x0004C9EE
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0004E80B File Offset: 0x0004CA0B
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0004E828 File Offset: 0x0004CA28
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0004E845 File Offset: 0x0004CA45
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0004E852 File Offset: 0x0004CA52
		private void cmdUploadFile_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdUploadFile.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0004E86F File Offset: 0x0004CA6F
		private void cmdUploadFile_MouseLeave(object sender, EventArgs e)
		{
			this.cmdUploadFile.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0004E88C File Offset: 0x0004CA8C
		private void cmdUploadFile_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdUploadFile.Image = Resources.OpenTable_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0004E8A9 File Offset: 0x0004CAA9
		private void cmdUploadFile_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0004E8B6 File Offset: 0x0004CAB6
		private void cmdExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0004E8D3 File Offset: 0x0004CAD3
		private void cmdExcel_MouseLeave(object sender, EventArgs e)
		{
			this.cmdExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0004E8F0 File Offset: 0x0004CAF0
		private void cmdExcel_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdExcel.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0004E90D File Offset: 0x0004CB0D
		private void cmdExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0004E91A File Offset: 0x0004CB1A
		private void cmdDelete_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdDelete.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0004E937 File Offset: 0x0004CB37
		private void cmdDelete_MouseLeave(object sender, EventArgs e)
		{
			this.cmdDelete.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0004E954 File Offset: 0x0004CB54
		private void cmdDelete_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdDelete.Image = Resources.TableRemove_Donw;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0004E971 File Offset: 0x0004CB71
		private void cmdDelete_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0004E97E File Offset: 0x0004CB7E
		private void cmbDamage_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("SIB_Damage", this.cmbDamage);
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0004E992 File Offset: 0x0004CB92
		private void cmbSuspectCause_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("SIB_SuspectCause", this.cmbSuspectCause);
		}

		// Token: 0x0400050F RID: 1295
		public FactorySettings _factorySetting;

		// Token: 0x04000510 RID: 1296
		public CIMitarAccount _cimitarUser;

		// Token: 0x04000511 RID: 1297
		private QueryMgr queryMgr;

		// Token: 0x04000512 RID: 1298
		private Thread _thread;

		// Token: 0x04000513 RID: 1299
		private BarPrograss _barPrograss;

		// Token: 0x04000514 RID: 1300
		public SortedList slDefectList = new SortedList();

		// Token: 0x04000515 RID: 1301
		private CCarrierDataHistory carrierhistory = new CCarrierDataHistory();

		// Token: 0x04000516 RID: 1302
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x04000517 RID: 1303
		private ContextMenu menuGrid;

		// Token: 0x04000518 RID: 1304
		private ContextMenu menupb;

		// Token: 0x04000519 RID: 1305
		private DataSet dsFailCode = new DataSet();

		// Token: 0x0400051A RID: 1306
		private DataSet dsRepairCode = new DataSet();

		// Token: 0x02000046 RID: 70
		public class DefectListColumn
		{
			// Token: 0x04000546 RID: 1350
			public const int Check = 0;

			// Token: 0x04000547 RID: 1351
			public const int No = 1;

			// Token: 0x04000548 RID: 1352
			public const int Date = 2;

			// Token: 0x04000549 RID: 1353
			public const int Barcode = 3;

			// Token: 0x0400054A RID: 1354
			public const int Rev = 4;

			// Token: 0x0400054B RID: 1355
			public const int DefectCode = 5;

			// Token: 0x0400054C RID: 1356
			public const int Damage = 6;

			// Token: 0x0400054D RID: 1357
			public const int SuspectCause = 7;

			// Token: 0x0400054E RID: 1358
			public const int Action = 8;

			// Token: 0x0400054F RID: 1359
			public const int Remark = 9;

			// Token: 0x04000550 RID: 1360
			public const int FileName = 10;

			// Token: 0x04000551 RID: 1361
			public const int Reference = 11;

			// Token: 0x04000552 RID: 1362
			public const int HistoryID = 12;

			// Token: 0x04000553 RID: 1363
			public const int CarrierID = 13;

			// Token: 0x04000554 RID: 1364
			public const int Device = 14;
		}
	}
}
