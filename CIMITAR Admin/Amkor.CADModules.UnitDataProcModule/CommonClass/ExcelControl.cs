using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace Amkor.CADModules.UnitDataProcModule.CommonClass
{
	// Token: 0x02000009 RID: 9
	public static class ExcelControl
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000072E4 File Offset: 0x000054E4
		public static bool SaveExcel(ExcelInfo excelInfo, bool visibleFlag)
		{
			bool result;
			using (ExcelPackage excelPackage = new ExcelPackage())
			{
				if (excelInfo.slSheetList.Count > 0)
				{
					for (int i = 0; i < excelInfo.slSheetList.Count; i++)
					{
						SheetInfo sheetInfo = (SheetInfo)excelInfo.slSheetList.GetByIndex(i);
						ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(sheetInfo.Name);
						if (sheetInfo.slDataList.Count > 0)
						{
							int j = 0;
							while (j < sheetInfo.slDataList.Count)
							{
								SheetData sheetData = (SheetData)sheetInfo.slDataList.GetByIndex(j);
								if (sheetData.DataType == "Image")
								{
									using (Image image = Image.FromFile(sheetData.FileName))
									{
										ExcelPicture excelPicture = excelWorksheet.Drawings.AddPicture(sheetData.Name, image);
										excelPicture.SetPosition(1, 0, 1, 0);
										goto IL_1EE;
									}
									goto IL_C7;
								}
								goto IL_C7;
								IL_1EE:
								j++;
								continue;
								IL_C7:
								if (!(sheetData.DataType == "Table"))
								{
									goto IL_1EE;
								}
								DataTable table = sheetData.Table;
								int num = 1;
								int num2 = 1;
								if (table.Rows.Count > 0)
								{
									for (int k = 0; k < table.Columns.Count; k++)
									{
										excelWorksheet.Cells[num, num2].Value = table.Columns[k].ToString();
										excelWorksheet.Column(num2++).Width = 15.0;
									}
									num++;
									for (int l = 0; l < table.Rows.Count; l++)
									{
										num2 = 1;
										for (int m = 0; m < table.Columns.Count; m++)
										{
											if (table.Rows[l][m] != null)
											{
												excelWorksheet.Cells[num, num2].Value = table.Rows[l][m].ToString();
											}
											num2++;
										}
										num++;
									}
									goto IL_1EE;
								}
								goto IL_1EE;
							}
						}
					}
				}
				excelPackage.Workbook.Properties.Title = "Amkor";
				excelPackage.Workbook.Properties.Author = "Amkor";
				excelPackage.Workbook.Properties.Comments = "Amkor";
				excelPackage.Workbook.Properties.Company = "Amkor";
				FileInfo file = new FileInfo(excelInfo.FileName);
				excelPackage.SaveAs(file);
				result = true;
			}
			return result;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000075BC File Offset: 0x000057BC
		public static bool SaveExcel(string filepath, SortedList slList, bool visibleFlag)
		{
			bool result;
			using (ExcelPackage excelPackage = new ExcelPackage())
			{
				if (slList.Count > 0)
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
						if (dataTable.Rows.Count > 0)
						{
							num++;
							for (int k = 0; k < dataTable.Rows.Count; k++)
							{
								num2 = 1;
								for (int l = 0; l < dataTable.Columns.Count; l++)
								{
									if (dataTable.Rows[k][l] != null)
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

		// Token: 0x0600002E RID: 46 RVA: 0x000077A8 File Offset: 0x000059A8
		public static bool generateCSV(string filename, DataTable dt, bool visibleFlag)
		{
			if (dt != null)
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

		// Token: 0x0600002F RID: 47 RVA: 0x00007910 File Offset: 0x00005B10
		public static bool generateCSV(string filename, object[,] oData, bool visibleFlag)
		{
			bool result;
			try
			{
				if (oData.Length > 0)
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
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
