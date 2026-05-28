using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using SourceGrid;

namespace Amkor.CADModules.CarrierModule.Control
{
	// Token: 0x02000027 RID: 39
	internal class ExcelControl
	{
		// Token: 0x06000063 RID: 99 RVA: 0x00003D74 File Offset: 0x00001F74
		public static bool SaveCSV(string path, DataTable dt, bool excuteExcel)
		{
			bool result;
			try
			{
				if (dt != null)
				{
					StreamWriter streamWriter = new StreamWriter(path, false, Encoding.GetEncoding("euc-kr"));
					foreach (object obj in dt.Rows)
					{
						DataRow dataRow = (DataRow)obj;
						foreach (object obj2 in dt.Columns)
						{
							DataColumn dataColumn = (DataColumn)obj2;
							streamWriter.Write(dataRow[dataColumn.ColumnName].ToString());
							streamWriter.Write(",");
						}
						streamWriter.WriteLine();
					}
					streamWriter.Close();
					if (excuteExcel)
					{
						Process.Start("Excel", "\"" + path + "\"");
					}
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

		// Token: 0x06000064 RID: 100 RVA: 0x00003E94 File Offset: 0x00002094
		public static bool SaveCSV(string path, Grid grid, bool excuteExcel)
		{
			bool result;
			try
			{
				if (grid != null)
				{
					Encoding encoding = Encoding.GetEncoding("euc-kr");
					StreamWriter streamWriter = new StreamWriter(path, false, encoding);
					for (int i = 0; i < grid.Rows.Count; i++)
					{
						for (int j = 0; j < grid.Columns.Count; j++)
						{
							if (grid.Columns[j].Visible)
							{
								string text;
								if (grid[i, j] == null)
								{
									text = "";
								}
								else if (grid[i, j].Value == null)
								{
									text = "";
								}
								else
								{
									text = grid[i, j].Value.ToString();
								}
								if (text.Contains("\n"))
								{
									text = text.Replace("\n", "");
								}
								streamWriter.Write(text + ",");
							}
						}
						streamWriter.Write("\n");
					}
					streamWriter.Close();
					if (excuteExcel)
					{
						Process.Start("Excel", "\"" + path + "\"");
					}
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

		// Token: 0x06000065 RID: 101 RVA: 0x00003FDC File Offset: 0x000021DC
		public static bool Save(string fileName, DataTable dt, string sSheetName, bool HeaderFlag, bool visibleFlag)
		{
			int num = dt.Rows.Count;
			int count = dt.Columns.Count;
			int num2 = 0;
			if (HeaderFlag)
			{
				num++;
			}
			object[,] array = new object[num, count];
			try
			{
				if (HeaderFlag)
				{
					for (int i = 0; i < count; i++)
					{
						array[num2, i] = dt.Columns[i].ToString();
					}
					num2++;
				}
				for (int j = 0; j < dt.Rows.Count; j++)
				{
					for (int k = 0; k < count; k++)
					{
						array[num2, k] = dt.Rows[j][k].ToString();
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				return false;
			}
			_Worksheet worksheet = null;
			Application application = new ApplicationClass();
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			worksheet = (_Worksheet)workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
			if (sSheetName != string.Empty)
			{
				worksheet.Name = sSheetName;
			}
			try
			{
				Range range = (Range)worksheet.Cells.get__Default(1, 1);
				Range range2 = (Range)worksheet.Cells.get__Default(num, count);
				Range range3 = worksheet.get_Range(range, range2);
				range3.Value2 = array;
				range3.Font.Name = "Arial";
				range3.Font.Size = 10;
				range3.HorizontalAlignment = -4108;
				range3.Borders.Weight = 2;
				range3.EntireColumn.AutoFit();
				workbook.SaveAs(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, 1, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				if (visibleFlag)
				{
					application.Visible = true;
					application.ActiveWindow.Zoom = 85;
				}
				else
				{
					workbook.Close(true, fileName, Type.Missing);
					application.Quit();
				}
				Marshal.ReleaseComObject(worksheet);
				Marshal.ReleaseComObject(workbook);
				Marshal.ReleaseComObject(workbooks);
				Marshal.ReleaseComObject(application);
			}
			catch (Exception)
			{
				workbook.Close(true, fileName, Type.Missing);
				application.Quit();
				if (worksheet != null)
				{
					Marshal.ReleaseComObject(worksheet);
				}
				if (workbook != null)
				{
					Marshal.ReleaseComObject(workbook);
				}
				if (workbooks != null)
				{
					Marshal.ReleaseComObject(workbooks);
				}
				if (application != null)
				{
					Marshal.ReleaseComObject(application);
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000042D8 File Offset: 0x000024D8
		public static bool Save(string filepath, Grid grid, bool visibleFlag)
		{
			int rowsCount = grid.RowsCount;
			int columnsCount = grid.ColumnsCount;
			object[,] array = new object[rowsCount, columnsCount];
			RangeRegion rangeRegion = new RangeRegion();
			try
			{
				for (int i = 0; i < grid.RowsCount; i++)
				{
					for (int j = 0; j < grid.Columns.Count; j++)
					{
						if (grid[i, j].Range.Start != grid[i, j].Range.End)
						{
							rangeRegion.Add(grid[i, j].Range);
						}
						int rowSpan = grid[i, j].RowSpan;
						int columnSpan = grid[i, j].ColumnSpan;
						array[i, j] = grid[i, j].Value;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				return false;
			}
			_Worksheet worksheet = null;
			Application application = new ApplicationClass();
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			worksheet = (_Worksheet)workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
			try
			{
				Range range = (Range)worksheet.Cells.get__Default(1, 1);
				Range range2 = (Range)worksheet.Cells.get__Default(rowsCount, columnsCount);
				Range range3 = worksheet.get_Range(range, range2);
				range3.Value2 = array;
				range3.Font.Name = "Arial";
				range3.Font.Size = 10;
				range3.HorizontalAlignment = -4108;
				range3.Borders.Weight = 2;
				range3.EntireColumn.AutoFit();
				for (int k = 0; k < rangeRegion.Count; k++)
				{
					int num = rangeRegion[k].Start.Row + 1;
					int num2 = rangeRegion[k].Start.Column + 1;
					int num3 = rangeRegion[k].End.Row + 1;
					int num4 = rangeRegion[k].End.Column + 1;
					worksheet.get_Range(worksheet.Cells.get__Default(num, num2), worksheet.Cells.get__Default(num3, num4)).Merge(false);
				}
				workbook.SaveAs(filepath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, 1, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				if (visibleFlag)
				{
					application.Visible = true;
					application.ActiveWindow.Zoom = 85;
				}
				else
				{
					workbook.Close(true, filepath, Type.Missing);
					application.Quit();
				}
				Marshal.ReleaseComObject(worksheet);
				Marshal.ReleaseComObject(workbook);
				Marshal.ReleaseComObject(workbooks);
				Marshal.ReleaseComObject(application);
			}
			catch (Exception)
			{
				workbook.Close(true, filepath, Type.Missing);
				application.Quit();
				if (worksheet != null)
				{
					Marshal.ReleaseComObject(worksheet);
				}
				if (workbook != null)
				{
					Marshal.ReleaseComObject(workbook);
				}
				if (workbooks != null)
				{
					Marshal.ReleaseComObject(workbooks);
				}
				if (application != null)
				{
					Marshal.ReleaseComObject(application);
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000046CC File Offset: 0x000028CC
		public static bool Save(string filepath, Grid grid, bool visibleFlag, SortedList slList)
		{
			int rowsCount = grid.RowsCount;
			int columnsCount = grid.ColumnsCount;
			object[,] array = new object[rowsCount, columnsCount];
			RangeRegion rangeRegion = new RangeRegion();
			try
			{
				for (int i = 0; i < grid.RowsCount; i++)
				{
					for (int j = 0; j < grid.Columns.Count; j++)
					{
						if (grid[i, j].Range.Start != grid[i, j].Range.End)
						{
							rangeRegion.Add(grid[i, j].Range);
						}
						int rowSpan = grid[i, j].RowSpan;
						int columnSpan = grid[i, j].ColumnSpan;
						array[i, j] = grid[i, j].Value;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				return false;
			}
			_Worksheet worksheet = null;
			Application application = new ApplicationClass();
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			worksheet = (_Worksheet)workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
			try
			{
				Range range = (Range)worksheet.Cells.get__Default(1, 1);
				Range range2 = (Range)worksheet.Cells.get__Default(rowsCount, columnsCount);
				Range range3 = worksheet.get_Range(range, range2);
				range3.Value2 = array;
				range3.Font.Name = "Arial";
				range3.Font.Size = 10;
				range3.HorizontalAlignment = -4108;
				range3.Borders.Weight = 2;
				range3.EntireColumn.AutoFit();
				for (int k = 0; k < rangeRegion.Count; k++)
				{
					int num = rangeRegion[k].Start.Row + 1;
					int num2 = rangeRegion[k].Start.Column + 1;
					int num3 = rangeRegion[k].End.Row + 1;
					int num4 = rangeRegion[k].End.Column + 1;
					worksheet.get_Range(worksheet.Cells.get__Default(num, num2), worksheet.Cells.get__Default(num3, num4)).Merge(false);
				}
				workbook.SaveAs(filepath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, 1, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				if (visibleFlag)
				{
					application.Visible = true;
					application.ActiveWindow.Zoom = 85;
				}
				else
				{
					workbook.Close(true, filepath, Type.Missing);
					application.Quit();
				}
				Marshal.ReleaseComObject(worksheet);
				Marshal.ReleaseComObject(workbook);
				Marshal.ReleaseComObject(workbooks);
				Marshal.ReleaseComObject(application);
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message.ToString());
				workbook.Close(true, filepath, Type.Missing);
				application.Quit();
				if (worksheet != null)
				{
					Marshal.ReleaseComObject(worksheet);
				}
				if (workbook != null)
				{
					Marshal.ReleaseComObject(workbook);
				}
				if (workbooks != null)
				{
					Marshal.ReleaseComObject(workbooks);
				}
				if (application != null)
				{
					Marshal.ReleaseComObject(application);
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004ADC File Offset: 0x00002CDC
		public static bool Save(string filepath, SortedList slList, bool visibleFlag)
		{
			if (slList.Count == 0)
			{
				return false;
			}
			_Worksheet worksheet = null;
			Application application = new ApplicationClass();
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			RangeRegion rangeRegion = new RangeRegion();
			try
			{
				foreach (object obj in slList)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					Grid grid = (Grid)dictionaryEntry.Value;
					string name = dictionaryEntry.Key.ToString();
					int num = grid.RowsCount - 1;
					int columnsCount = grid.ColumnsCount;
					object[,] array = new object[num, columnsCount];
					for (int i = 1; i < grid.RowsCount; i++)
					{
						for (int j = 0; j < grid.ColumnsCount; j++)
						{
							if (grid[i, j] == null)
							{
								array[i - 1, j] = string.Empty;
							}
							else
							{
								if (grid[i, j].Range.Start != grid[i, j].Range.End)
								{
									rangeRegion.Add(grid[i, j].Range);
								}
								int rowSpan = grid[i, j].RowSpan;
								int columnSpan = grid[i, j].ColumnSpan;
								array[i - 1, j] = grid[i, j].Value;
							}
						}
					}
					worksheet = (_Worksheet)workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
					worksheet.Name = name;
					application.ActiveWindow.Zoom = 85;
					Range range = (Range)worksheet.Cells.get__Default(1, 1);
					Range range2 = (Range)worksheet.Cells.get__Default(num, columnsCount);
					Range range3 = worksheet.get_Range(range, range2);
					range3.Value2 = array;
					range3.Font.Name = "Arial";
					range3.Font.Size = 10;
					range3.HorizontalAlignment = -4108;
					range3.Borders.Weight = 2;
					range3.EntireColumn.AutoFit();
					for (int k = 0; k < rangeRegion.Count; k++)
					{
						int row = rangeRegion[k].Start.Row;
						int num2 = rangeRegion[k].Start.Column + 1;
						int row2 = rangeRegion[k].End.Row;
						int num3 = rangeRegion[k].End.Column + 1;
						worksheet.get_Range(worksheet.Cells.get__Default(row, num2), worksheet.Cells.get__Default(row2, num3)).Merge(false);
					}
				}
				workbook.SaveAs(filepath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, 1, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				if (visibleFlag)
				{
					application.Visible = true;
					application.ActiveWindow.Zoom = 85;
				}
				else
				{
					workbook.Close(true, filepath, Type.Missing);
					application.Quit();
				}
				Marshal.ReleaseComObject(worksheet);
				Marshal.ReleaseComObject(workbook);
				Marshal.ReleaseComObject(workbooks);
				Marshal.ReleaseComObject(application);
			}
			catch (Exception)
			{
				workbook.Close(true, filepath, Type.Missing);
				application.Quit();
				if (worksheet != null)
				{
					Marshal.ReleaseComObject(worksheet);
				}
				if (workbook != null)
				{
					Marshal.ReleaseComObject(workbook);
				}
				if (workbooks != null)
				{
					Marshal.ReleaseComObject(workbooks);
				}
				if (application != null)
				{
					Marshal.ReleaseComObject(application);
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004F4C File Offset: 0x0000314C
		public static bool Save(_Worksheet oWS, DataTable dt, int iRowIndex = 1, int iColIndex = 1)
		{
			int num = dt.Rows.Count + 1;
			int count = dt.Columns.Count;
			object[,] array = new object[num, count];
			for (int i = 0; i < count; i++)
			{
				array[0, i] = dt.Columns[i].ToString();
			}
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				for (int k = 0; k < count; k++)
				{
					array[j + 1, k] = dt.Rows[j][k].ToString();
				}
			}
			int num2 = num + iRowIndex - 1;
			int num3 = count + iColIndex - 1;
			Range range = (Range)oWS.Cells.get__Default(iRowIndex, iColIndex);
			Range range2 = (Range)oWS.Cells.get__Default(num2, num3);
			Range range3 = oWS.get_Range(range, range2);
			range3.Value2 = array;
			range3.Font.Name = "Arial";
			range3.Font.Size = 10;
			range3.HorizontalAlignment = -4108;
			range3.Borders.Weight = 2;
			range3.EntireColumn.AutoFit();
			return true;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000050A4 File Offset: 0x000032A4
		public static void WriteArray(object[,] oArray, string sStartRowIndex, string sEndRowIndex, _Worksheet worksheet, string sStartCol, string sEndCol)
		{
			try
			{
				Range range = worksheet.get_Range(sStartCol + sStartRowIndex, sEndCol + sEndRowIndex);
				range.Font.Name = "Arial";
				range.Font.Size = 10;
				range.HorizontalAlignment = -4108;
				range.Borders.Weight = 2;
				range.Interior.Color = Color.Transparent;
				range.Value2 = oArray;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}
	}
}
