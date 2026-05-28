using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlteraSocketView.View;
using Amkor.CADModules.BIBoardInfoModule.Class;
using Amkor.CADModules.BIBoardInfoModule.Properties;
using ExcelControls;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000027 RID: 39
	public partial class SaveExcel_Sum : Form
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x000142BD File Offset: 0x000124BD
		public SaveExcel_Sum(string url)
		{
			this._url = url;
			this.InitializeComponent();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000142DD File Offset: 0x000124DD
		private void SaveExcel_Sum_Load(object sender, EventArgs e)
		{
			this._cGetData = new CGetData(this._url);
			this._excelCtrl = new ExcelControl();
			this._alProduct = this._cGetData.GetDevice();
			this.SetCombo();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000055FE File Offset: 0x000037FE
		private void SaveExcel_Sum_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00014312 File Offset: 0x00012512
		private void pb_SaveExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_SaveExcel.Image = Resources.SaveExcel_Down;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00014324 File Offset: 0x00012524
		private void pb_SaveExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_SaveExcel.Image = Resources.SaveExcel;
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			List<string> list = new List<string>();
			DialogResult dialogResult = DialogResult.Cancel;
			if (this.combo_Product.Text == "ALL")
			{
				foreach (object obj in this._alProduct)
				{
					string text = (string)obj;
					if (!(text == "ALL"))
					{
						this.combo_Product.Text = text;
						string text2 = string.Concat(new string[]
						{
							"ATK_PTE_",
							this.combo_Product.Text,
							" - AU_BIB_Report_",
							DateTime.Now.ToString("yyyyMMdd"),
							".xlsx"
						});
						saveFileDialog = new SaveFileDialog();
						saveFileDialog.Title = "Save File";
						saveFileDialog.FileName = text2;
						saveFileDialog.RestoreDirectory = true;
						saveFileDialog.Filter = "Excel Fils (*.xlsx)|*.xlsx";
						saveFileDialog.FilterIndex = 2;
						dialogResult = saveFileDialog.ShowDialog();
						if (dialogResult != DialogResult.OK)
						{
							this.combo_Product.Text = "ALL";
							break;
						}
						list.Add(saveFileDialog.FileName);
					}
				}
				if (dialogResult == DialogResult.OK)
				{
					foreach (object obj2 in this._alProduct)
					{
						string text3 = (string)obj2;
						if (!(text3 == "ALL"))
						{
							this.combo_Product.Text = text3;
							string text2 = list[this._alProduct.IndexOf(text3)];
							this.SetExcelData(text2);
						}
					}
					this.combo_Product.Text = "ALL";
					MessageBox.Show("Success to Save Excel File");
					base.Close();
					return;
				}
			}
			else
			{
				string text2 = string.Concat(new string[]
				{
					"ATK_PTE_",
					this.combo_Product.Text,
					" - AU_BIB_Report_",
					DateTime.Now.ToString("yyyyMMdd"),
					".xlsx"
				});
				saveFileDialog = new SaveFileDialog();
				saveFileDialog.Title = "Save File";
				saveFileDialog.FileName = text2;
				saveFileDialog.RestoreDirectory = true;
				saveFileDialog.Filter = "Excel Fils (*.xlsx)|*.xlsx";
				saveFileDialog.FilterIndex = 2;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					text2 = saveFileDialog.FileName;
					this.SetExcelData(text2);
					MessageBox.Show("Success to Save Excel File");
					base.Close();
				}
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000145C8 File Offset: 0x000127C8
		private void SetCombo()
		{
			foreach (object obj in this._alProduct)
			{
				string item = (string)obj;
				this.combo_Product.Items.Add(item);
			}
			this.combo_Product.Items.Add("ALL");
			this.combo_Product.SelectedIndex = this.combo_Product.FindString("ALL");
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00014660 File Offset: 0x00012860
		private void SetExcelData(string fileName)
		{
			string text = this.combo_Product.Text;
			this._barPrograss = new BarPrograss();
			this._barPrograss.progress_labelheader_set("Loading Data..");
			this._barPrograss.setMax(100);
			this._barPrograss.setValue(100);
			this._thread = new Thread(new ThreadStart(this.BarPrograssView));
			this._thread.Start();
			SortedList biboardSocketInfo = this._cGetData.GetBIBoardSocketInfo(text);
			DataTable summary = this._cGetData.GetSummary(text);
			DataTable summary_BIB = this._cGetData.GetSummary_BIB(text);
			DataTable pmhistory = this._cGetData.GetPMHistory(text);
			Thread.Sleep(10);
			if (this._barPrograss != null)
			{
				this._barPrograss._ischeck = true;
			}
			this._barPrograss = null;
			List<DataTable> list = new List<DataTable>();
			list.Add(pmhistory);
			list.Add(summary);
			list.Add(summary_BIB);
			this._excelCtrl.generateExcel_BIBoard(fileName, biboardSocketInfo, list);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00014757 File Offset: 0x00012957
		private void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x040001A1 RID: 417
		private BarPrograss _barPrograss;

		// Token: 0x040001A2 RID: 418
		private Thread _thread;

		// Token: 0x040001A3 RID: 419
		private string _url = string.Empty;

		// Token: 0x040001A4 RID: 420
		private CGetData _cGetData;

		// Token: 0x040001A5 RID: 421
		private ExcelControl _excelCtrl;

		// Token: 0x040001A6 RID: 422
		private ArrayList _alProduct;
	}
}
