using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;
using SourceGrid;

namespace Amkor.CADModules.SBLAnalysisModule.Control
{
	// Token: 0x0200000F RID: 15
	internal class ExcelControl
	{
		// Token: 0x06000043 RID: 67 RVA: 0x000034B0 File Offset: 0x000016B0
		public static bool SaveCSV(string path, DataTable dt, bool excuteExcel)
		{
			bool result;
			try
			{
				if (dt != null)
				{
					StreamWriter streamWriter = new StreamWriter(path, false);
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
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000362C File Offset: 0x0000182C
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
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000037B0 File Offset: 0x000019B0
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
					for (int i = 0; i < count; i++)
					{
						array[num2, i] = dt.Rows[j][i].ToString();
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				return false;
			}
			_Worksheet worksheet = null;
			Application application = (Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			if (ExcelControl.<Save>o__SiteContainer0.<>p__Site1 == null)
			{
				ExcelControl.<Save>o__SiteContainer0.<>p__Site1 = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
			}
			worksheet = ExcelControl.<Save>o__SiteContainer0.<>p__Site1.Target(ExcelControl.<Save>o__SiteContainer0.<>p__Site1, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
			if (sSheetName != string.Empty)
			{
				worksheet.Name = sSheetName;
			}
			try
			{
				if (ExcelControl.<Save>o__SiteContainer0.<>p__Site2 == null)
				{
					ExcelControl.<Save>o__SiteContainer0.<>p__Site2 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<Save>o__SiteContainer0.<>p__Site2.Target(ExcelControl.<Save>o__SiteContainer0.<>p__Site2, worksheet.Cells[1, 1]);
				if (ExcelControl.<Save>o__SiteContainer0.<>p__Site3 == null)
				{
					ExcelControl.<Save>o__SiteContainer0.<>p__Site3 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<Save>o__SiteContainer0.<>p__Site3.Target(ExcelControl.<Save>o__SiteContainer0.<>p__Site3, worksheet.Cells[num, count]);
				Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(cell, cell2);
				range.Value2 = array;
				range.Font.Name = "Arial";
				range.Font.Size = 10;
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
				range.Borders.Weight = XlBorderWeight.xlThin;
				range.EntireColumn.AutoFit();
				workbook.SaveAs(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
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
			catch (Exception ex)
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

		// Token: 0x06000046 RID: 70 RVA: 0x00003BEC File Offset: 0x00001DEC
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
						int num = grid[i, j].RowSpan - 1;
						int num2 = grid[i, j].ColumnSpan - 1;
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
			Application application = (Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			if (ExcelControl.<Save>o__SiteContainer4.<>p__Site5 == null)
			{
				ExcelControl.<Save>o__SiteContainer4.<>p__Site5 = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
			}
			worksheet = ExcelControl.<Save>o__SiteContainer4.<>p__Site5.Target(ExcelControl.<Save>o__SiteContainer4.<>p__Site5, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
			try
			{
				if (ExcelControl.<Save>o__SiteContainer4.<>p__Site6 == null)
				{
					ExcelControl.<Save>o__SiteContainer4.<>p__Site6 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<Save>o__SiteContainer4.<>p__Site6.Target(ExcelControl.<Save>o__SiteContainer4.<>p__Site6, worksheet.Cells[1, 1]);
				if (ExcelControl.<Save>o__SiteContainer4.<>p__Site7 == null)
				{
					ExcelControl.<Save>o__SiteContainer4.<>p__Site7 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<Save>o__SiteContainer4.<>p__Site7.Target(ExcelControl.<Save>o__SiteContainer4.<>p__Site7, worksheet.Cells[rowsCount, columnsCount]);
				Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(cell, cell2);
				range.Value2 = array;
				range.Font.Name = "Arial";
				range.Font.Size = 10;
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
				range.Borders.Weight = XlBorderWeight.xlThin;
				range.EntireColumn.AutoFit();
				for (int i = 0; i < rangeRegion.Count; i++)
				{
					int num3 = rangeRegion[i].Start.Row + 1;
					int num4 = rangeRegion[i].Start.Column + 1;
					int num5 = rangeRegion[i].End.Row + 1;
					int num6 = rangeRegion[i].End.Column + 1;
					if (ExcelControl.<Save>o__SiteContainer4.<>p__Site8 == null)
					{
						ExcelControl.<Save>o__SiteContainer4.<>p__Site8 = CallSite<Action<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Merge", null, typeof(ExcelControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Action<CallSite, object, bool> target = ExcelControl.<Save>o__SiteContainer4.<>p__Site8.Target;
					CallSite <>p__Site = ExcelControl.<Save>o__SiteContainer4.<>p__Site8;
					if (ExcelControl.<Save>o__SiteContainer4.<>p__Site9 == null)
					{
						ExcelControl.<Save>o__SiteContainer4.<>p__Site9 = CallSite<Func<CallSite, _Worksheet, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "get_Range", null, typeof(ExcelControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					target(<>p__Site, ExcelControl.<Save>o__SiteContainer4.<>p__Site9.Target(ExcelControl.<Save>o__SiteContainer4.<>p__Site9, worksheet, worksheet.Cells[num3, num4], worksheet.Cells[num5, num6]), false);
				}
				workbook.SaveAs(filepath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
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
			catch (Exception ex)
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

		// Token: 0x06000047 RID: 71 RVA: 0x000041D0 File Offset: 0x000023D0
		public static bool Save(string filepath, SortedList slList, bool visibleFlag)
		{
			bool result;
			if (slList.Count == 0)
			{
				result = false;
			}
			else
			{
				_Worksheet worksheet = null;
				Application application = (Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
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
									int num2 = grid[i, j].RowSpan - 1;
									int num3 = grid[i, j].ColumnSpan - 1;
									array[i - 1, j] = grid[i, j].Value;
								}
							}
						}
						if (ExcelControl.<Save>o__SiteContainera.<>p__Siteb == null)
						{
							ExcelControl.<Save>o__SiteContainera.<>p__Siteb = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
						}
						worksheet = ExcelControl.<Save>o__SiteContainera.<>p__Siteb.Target(ExcelControl.<Save>o__SiteContainera.<>p__Siteb, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
						worksheet.Name = name;
						application.ActiveWindow.Zoom = 85;
						if (ExcelControl.<Save>o__SiteContainera.<>p__Sitec == null)
						{
							ExcelControl.<Save>o__SiteContainera.<>p__Sitec = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
						}
						Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<Save>o__SiteContainera.<>p__Sitec.Target(ExcelControl.<Save>o__SiteContainera.<>p__Sitec, worksheet.Cells[1, 1]);
						if (ExcelControl.<Save>o__SiteContainera.<>p__Sited == null)
						{
							ExcelControl.<Save>o__SiteContainera.<>p__Sited = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
						}
						Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<Save>o__SiteContainera.<>p__Sited.Target(ExcelControl.<Save>o__SiteContainera.<>p__Sited, worksheet.Cells[num, columnsCount]);
						Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(cell, cell2);
						range.Value2 = array;
						range.Font.Name = "Arial";
						range.Font.Size = 10;
						range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
						range.Borders.Weight = XlBorderWeight.xlThin;
						range.EntireColumn.AutoFit();
						for (int i = 0; i < rangeRegion.Count; i++)
						{
							int row = rangeRegion[i].Start.Row;
							int num4 = rangeRegion[i].Start.Column + 1;
							int row2 = rangeRegion[i].End.Row;
							int num5 = rangeRegion[i].End.Column + 1;
							if (ExcelControl.<Save>o__SiteContainera.<>p__Sitee == null)
							{
								ExcelControl.<Save>o__SiteContainera.<>p__Sitee = CallSite<Action<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Merge", null, typeof(ExcelControl), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							Action<CallSite, object, bool> target = ExcelControl.<Save>o__SiteContainera.<>p__Sitee.Target;
							CallSite <>p__Sitee = ExcelControl.<Save>o__SiteContainera.<>p__Sitee;
							if (ExcelControl.<Save>o__SiteContainera.<>p__Sitef == null)
							{
								ExcelControl.<Save>o__SiteContainera.<>p__Sitef = CallSite<Func<CallSite, _Worksheet, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "get_Range", null, typeof(ExcelControl), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							target(<>p__Sitee, ExcelControl.<Save>o__SiteContainera.<>p__Sitef.Target(ExcelControl.<Save>o__SiteContainera.<>p__Sitef, worksheet, worksheet.Cells[row, num4], worksheet.Cells[row2, num5]), false);
						}
					}
					workbook.SaveAs(filepath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
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
				catch (Exception ex)
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
				result = true;
			}
			return result;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000485C File Offset: 0x00002A5C
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
				for (int i = 0; i < count; i++)
				{
					array[j + 1, i] = dt.Rows[j][i].ToString();
				}
			}
			int num2 = num + iRowIndex - 1;
			int num3 = count + iColIndex - 1;
			if (ExcelControl.<Save>o__SiteContainer10.<>p__Site11 == null)
			{
				ExcelControl.<Save>o__SiteContainer10.<>p__Site11 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
			}
			Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<Save>o__SiteContainer10.<>p__Site11.Target(ExcelControl.<Save>o__SiteContainer10.<>p__Site11, oWS.Cells[iRowIndex, iColIndex]);
			if (ExcelControl.<Save>o__SiteContainer10.<>p__Site12 == null)
			{
				ExcelControl.<Save>o__SiteContainer10.<>p__Site12 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
			}
			Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<Save>o__SiteContainer10.<>p__Site12.Target(ExcelControl.<Save>o__SiteContainer10.<>p__Site12, oWS.Cells[num2, num3]);
			Microsoft.Office.Interop.Excel.Range range = oWS.get_Range(cell, cell2);
			range.Value2 = array;
			range.Font.Name = "Arial";
			range.Font.Size = 10;
			range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
			range.Borders.Weight = XlBorderWeight.xlThin;
			range.EntireColumn.AutoFit();
			return true;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004A4C File Offset: 0x00002C4C
		public static void WriteArray(object[,] oArray, string sStartRowIndex, string sEndRowIndex, _Worksheet worksheet, string sStartCol, string sEndCol)
		{
			try
			{
				Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(sStartCol + sStartRowIndex, sEndCol + sEndRowIndex);
				range.Font.Name = "Arial";
				range.Font.Size = 10;
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
				range.Borders.Weight = XlBorderWeight.xlThin;
				range.Interior.Color = Color.Transparent;
				range.Value2 = oArray;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0200001F RID: 31
		[CompilerGenerated]
		private static class <Save>o__SiteContainer0
		{
			// Token: 0x040000B6 RID: 182
			public static CallSite<Func<CallSite, object, _Worksheet>> <>p__Site1;

			// Token: 0x040000B7 RID: 183
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site2;

			// Token: 0x040000B8 RID: 184
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site3;
		}

		// Token: 0x0200002D RID: 45
		[CompilerGenerated]
		private static class <Save>o__SiteContainer4
		{
			// Token: 0x040000CB RID: 203
			public static CallSite<Func<CallSite, object, _Worksheet>> <>p__Site5;

			// Token: 0x040000CC RID: 204
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site6;

			// Token: 0x040000CD RID: 205
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site7;

			// Token: 0x040000CE RID: 206
			public static CallSite<Action<CallSite, object, bool>> <>p__Site8;

			// Token: 0x040000CF RID: 207
			public static CallSite<Func<CallSite, _Worksheet, object, object, object>> <>p__Site9;
		}

		// Token: 0x0200002E RID: 46
		[CompilerGenerated]
		private static class <Save>o__SiteContainera
		{
			// Token: 0x040000D0 RID: 208
			public static CallSite<Func<CallSite, object, _Worksheet>> <>p__Siteb;

			// Token: 0x040000D1 RID: 209
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Sitec;

			// Token: 0x040000D2 RID: 210
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Sited;

			// Token: 0x040000D3 RID: 211
			public static CallSite<Action<CallSite, object, bool>> <>p__Sitee;

			// Token: 0x040000D4 RID: 212
			public static CallSite<Func<CallSite, _Worksheet, object, object, object>> <>p__Sitef;
		}

		// Token: 0x0200002F RID: 47
		[CompilerGenerated]
		private static class <Save>o__SiteContainer10
		{
			// Token: 0x040000D5 RID: 213
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site11;

			// Token: 0x040000D6 RID: 214
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site12;
		}
	}
}
