using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using OfficeOpenXml;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.RELUnitDataProcModule.CommonClass
{
	// Token: 0x0200001B RID: 27
	public static class ExcelControl
	{
		// Token: 0x06000107 RID: 263 RVA: 0x000105BC File Offset: 0x0000E7BC
		public static bool SaveExcel(string filepath, SortedList slList, bool visibleFlag)
		{
			bool result;
			using (ExcelPackage excelPackage = new ExcelPackage())
			{
				bool flag = slList.Count > 0;
				if (flag)
				{
					for (int i = 0; i < slList.Count; i++)
					{
						DataTable dataTable = (DataTable)slList.GetByIndex(i);
						ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(dataTable.TableName);
						int num = 1;
						int num2 = 1;
						for (int j = 0; j < dataTable.Columns.Count; j++)
						{
							excelWorksheet.Cells[num, num2].Value = dataTable.Columns[j].ToString();
							excelWorksheet.Column(num2++).Width = 15.0;
						}
						bool flag2 = dataTable.Rows.Count > 0;
						if (flag2)
						{
							num++;
							for (int k = 0; k < dataTable.Rows.Count; k++)
							{
								num2 = 1;
								for (int l = 0; l < dataTable.Columns.Count; l++)
								{
									bool flag3 = dataTable.Rows[k][l] != null;
									if (flag3)
									{
										excelWorksheet.Cells[num, num2].Value = dataTable.Rows[k][l].ToString();
									}
									num2++;
								}
								num++;
							}
						}
					}
				}
				excelPackage.Workbook.Properties.Title = "Amkor";
				excelPackage.Workbook.Properties.Author = "Amkor";
				excelPackage.Workbook.Properties.Comments = "Amkor";
				excelPackage.Workbook.Properties.Company = "Amkor";
				FileInfo file = new FileInfo(filepath);
				excelPackage.SaveAs(file);
				result = true;
			}
			return result;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000107F8 File Offset: 0x0000E9F8
		public static bool SaveExcel(string filepath, Dictionary<string, RadGridView> grids)
		{
			using (ExcelPackage excelPackage = new ExcelPackage())
			{
				foreach (string text in grids.Keys)
				{
					RadGridView radGridView = grids[text];
					ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(text);
					int num = 1;
					int num2 = 1;
					foreach (GridViewColumn gridViewColumn in radGridView.Columns)
					{
						bool isVisible = gridViewColumn.IsVisible;
						if (isVisible)
						{
							excelWorksheet.Cells[num, num2].Value = gridViewColumn.Name;
							excelWorksheet.Column(num2).Width = 15.0;
							num2++;
						}
					}
					foreach (GridViewRowInfo gridViewRowInfo in radGridView.Rows)
					{
						num++;
						num2 = 1;
						foreach (GridViewColumn gridViewColumn2 in radGridView.Columns)
						{
							bool isVisible2 = gridViewColumn2.IsVisible;
							if (isVisible2)
							{
								excelWorksheet.Cells[num, num2].Value = gridViewRowInfo.Cells[gridViewColumn2.Index].Value;
								num2++;
							}
						}
					}
				}
				excelPackage.Workbook.Properties.Title = "Amkor";
				excelPackage.Workbook.Properties.Author = "Amkor";
				excelPackage.Workbook.Properties.Comments = "Amkor";
				excelPackage.Workbook.Properties.Company = "Amkor";
				FileInfo file = new FileInfo(filepath);
				excelPackage.SaveAs(file);
			}
			return true;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00010A98 File Offset: 0x0000EC98
		public static bool generateCSV(string filename, DataTable dt, bool visibleFlag)
		{
			bool flag = dt != null;
			if (flag)
			{
				StreamWriter streamWriter = new StreamWriter(filename, false, Encoding.Default);
				foreach (object obj in dt.Columns)
				{
					DataColumn dataColumn = (DataColumn)obj;
					streamWriter.Write(dataColumn.ColumnName);
					streamWriter.Write(",");
				}
				streamWriter.WriteLine();
				foreach (object obj2 in dt.Rows)
				{
					DataRow dataRow = (DataRow)obj2;
					foreach (object obj3 in dt.Columns)
					{
						DataColumn dataColumn2 = (DataColumn)obj3;
						string text = dataRow[dataColumn2.ColumnName].ToString().Replace('\n', ' ');
						text = text.Replace(',', ' ');
						streamWriter.Write(text);
						streamWriter.Write(",");
					}
					streamWriter.WriteLine();
				}
				streamWriter.Close();
			}
			return true;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00010C24 File Offset: 0x0000EE24
		public static bool generateCSV(string filename, object[,] oData, bool visibleFlag)
		{
			bool result;
			try
			{
				bool flag = oData.Length > 0;
				if (flag)
				{
					Encoding encoding = Encoding.GetEncoding("euc-kr");
					StreamWriter streamWriter = new StreamWriter(filename, false, encoding);
					for (int i = 0; i < oData.GetLength(0); i++)
					{
						for (int j = 0; j < oData.GetLength(1); j++)
						{
							string text = oData[i, j].ToString().Replace('\n', ' ');
							text = text.Replace(',', ' ');
							streamWriter.Write(text);
							streamWriter.Write(",");
						}
						streamWriter.WriteLine();
					}
					streamWriter.Close();
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}
	}
}
