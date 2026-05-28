using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using SourceGrid;

namespace Amkor.CADModules.SAMSUNGModule.Control
{
	// Token: 0x0200001A RID: 26
	internal class ExcelControl
	{
		// Token: 0x0600004F RID: 79 RVA: 0x00003CC8 File Offset: 0x00001EC8
		public static bool Save(string fileName, DataTable dt, bool visibleFlag)
		{
			int num = dt.Rows.Count + 1;
			int count = dt.Columns.Count;
			object[,] array = new object[num, count];
			try
			{
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

		// Token: 0x06000050 RID: 80 RVA: 0x00003F9C File Offset: 0x0000219C
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

		// Token: 0x06000051 RID: 81 RVA: 0x00004390 File Offset: 0x00002590
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
			new RangeRegion();
			try
			{
				for (int i = 0; i < slList.Count; i++)
				{
					SortedList sortedList = (SortedList)slList.GetByIndex(i);
					int count = sortedList.Count;
					int count2 = (sortedList[1] as ArrayList).Count;
					object[,] array = new object[count, count2];
					string name = slList.GetKey(i).ToString();
					try
					{
						for (int j = 0; j < sortedList.Count; j++)
						{
							ArrayList arrayList = (ArrayList)sortedList.GetByIndex(j);
							for (int k = 0; k < arrayList.Count; k++)
							{
								array[j, k] = arrayList[k].ToString();
							}
						}
					}
					catch (Exception ex)
					{
						ex.Message.ToString();
					}
					worksheet = (_Worksheet)workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
					worksheet.Name = name;
					application.ActiveWindow.Zoom = 85;
					Range range = (Range)worksheet.Cells.get__Default(1, 1);
					Range range2 = (Range)worksheet.Cells.get__Default(count, count2);
					Range range3 = worksheet.get_Range(range, range2);
					range3.Value2 = array;
					range3.Font.Name = "Arial";
					range3.Font.Size = 10;
					range3.Borders.Weight = 2;
					range3.EntireColumn.AutoFit();
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

		// Token: 0x06000052 RID: 82 RVA: 0x00004680 File Offset: 0x00002880
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
				ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects(Missing.Value);
				ChartObject chartObject = chartObjects.Add(40.0, 1000.0, 700.0, 350.0);
				chartObject.Chart.HasTitle = true;
				SeriesCollection seriesCollection = (SeriesCollection)chartObject.Chart.SeriesCollection(Missing.Value);
				chartObject.Chart.ChartTitle.Text = "Trend";
				Range range4 = (Range)worksheet.Rows[grid.RowsCount + 2, Missing.Value];
				worksheet.Shapes.Item(1).Top = (float)((double)range4.Top);
				range4 = (Range)worksheet.Columns[1, Missing.Value];
				worksheet.Shapes.Item(1).Left = (float)((double)range4.Left);
				worksheet.Shapes.Item(1).Width = 1000f;
				worksheet.Shapes.Item(1).Height = 400f;
				workbook.SaveAs(filepath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, 1, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				for (int l = 0; l < slList.Count; l++)
				{
				}
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

		// Token: 0x06000053 RID: 83 RVA: 0x00004BD8 File Offset: 0x00002DD8
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

		// Token: 0x06000054 RID: 84 RVA: 0x00004D30 File Offset: 0x00002F30
		public static bool Save(string filepath, Grid grid, bool visibleFlag, ArrayList arrColor)
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
				for (int l = 0; l < arrColor.Count; l++)
				{
					int[] array2 = (int[])arrColor[l];
					worksheet.get_Range(worksheet.Cells.get__Default(array2[0], array2[1]), worksheet.Cells.get__Default(array2[0], array2[1])).Interior.ColorIndex = 43;
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
	}
}
