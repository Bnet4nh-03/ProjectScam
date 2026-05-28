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
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;
using SourceGrid;

namespace Amkor.CADModules.ManufactureHistory.Class
{
	// Token: 0x02000003 RID: 3
	internal class ExcelControl
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000021B0 File Offset: 0x000003B0
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

		// Token: 0x06000005 RID: 5 RVA: 0x0000232C File Offset: 0x0000052C
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
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000024CC File Offset: 0x000006CC
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
			Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			if (ExcelControl.<Save>o__SiteContainer0.<>p__Site1 == null)
			{
				ExcelControl.<Save>o__SiteContainer0.<>p__Site1 = CallSite<Func<CallSite, object, Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Worksheet), typeof(ExcelControl)));
			}
			Func<CallSite, object, Worksheet> target = ExcelControl.<Save>o__SiteContainer0.<>p__Site1.Target;
			CallSite <>p__Site = ExcelControl.<Save>o__SiteContainer0.<>p__Site1;
			if (ExcelControl.<Save>o__SiteContainer0.<>p__Site2 == null)
			{
				ExcelControl.<Save>o__SiteContainer0.<>p__Site2 = CallSite<Func<CallSite, Sheets, object, object, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "Add", null, typeof(ExcelControl), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			worksheet = target(<>p__Site, ExcelControl.<Save>o__SiteContainer0.<>p__Site2.Target(ExcelControl.<Save>o__SiteContainer0.<>p__Site2, workbook.Worksheets, Type.Missing, workbook.Worksheets[workbook.Worksheets.Count], Type.Missing, Type.Missing));
			worksheet.Name = "Reort History";
			if (sSheetName != string.Empty)
			{
				worksheet.Name = sSheetName;
			}
			try
			{
				if (ExcelControl.<Save>o__SiteContainer0.<>p__Site3 == null)
				{
					ExcelControl.<Save>o__SiteContainer0.<>p__Site3 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<Save>o__SiteContainer0.<>p__Site3.Target(ExcelControl.<Save>o__SiteContainer0.<>p__Site3, worksheet.Cells[1, 1]);
				if (ExcelControl.<Save>o__SiteContainer0.<>p__Site4 == null)
				{
					ExcelControl.<Save>o__SiteContainer0.<>p__Site4 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<Save>o__SiteContainer0.<>p__Site4.Target(ExcelControl.<Save>o__SiteContainer0.<>p__Site4, worksheet.Cells[num, count]);
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

		// Token: 0x06000007 RID: 7 RVA: 0x000029A4 File Offset: 0x00000BA4
		public static bool Save(string filepath, Grid grid, bool visibleFlag, SortedList slList)
		{
			int num = 0;
			for (int i = 0; i < grid.Columns.Count; i++)
			{
				if (grid.Columns[i].Visible)
				{
					num++;
				}
			}
			int rowsCount = grid.RowsCount;
			int columnsCount = grid.ColumnsCount;
			object[,] array = new object[rowsCount, num];
			RangeRegion rangeRegion = new RangeRegion();
			try
			{
				for (int i = 0; i < grid.RowsCount; i++)
				{
					int num2 = 0;
					for (int j = 0; j < columnsCount; j++)
					{
						if (grid.Columns[j].Visible)
						{
							if (grid[i, j].Range.Start != grid[i, j].Range.End)
							{
								rangeRegion.Add(grid[i, j].Range);
							}
							int num3 = grid[i, j].RowSpan - 1;
							int num4 = grid[i, j].ColumnSpan - 1;
							if (grid[i, j].Value != null)
							{
								string text = grid[i, j].Value.ToString().Trim();
								if (text.IndexOf("=") != -1)
								{
									text = text.Replace("=", "'=");
								}
								array[i, num2] = text;
							}
							num2++;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				return false;
			}
			_Worksheet worksheet = null;
			Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			if (ExcelControl.<Save>o__SiteContainer5.<>p__Site6 == null)
			{
				ExcelControl.<Save>o__SiteContainer5.<>p__Site6 = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
			}
			worksheet = ExcelControl.<Save>o__SiteContainer5.<>p__Site6.Target(ExcelControl.<Save>o__SiteContainer5.<>p__Site6, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
			try
			{
				if (ExcelControl.<Save>o__SiteContainer5.<>p__Site7 == null)
				{
					ExcelControl.<Save>o__SiteContainer5.<>p__Site7 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<Save>o__SiteContainer5.<>p__Site7.Target(ExcelControl.<Save>o__SiteContainer5.<>p__Site7, worksheet.Cells[1, 1]);
				if (ExcelControl.<Save>o__SiteContainer5.<>p__Site8 == null)
				{
					ExcelControl.<Save>o__SiteContainer5.<>p__Site8 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<Save>o__SiteContainer5.<>p__Site8.Target(ExcelControl.<Save>o__SiteContainer5.<>p__Site8, worksheet.Cells[rowsCount, num]);
				Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(cell, cell2);
				range.Value2 = array;
				range.Font.Name = "Arial";
				range.Font.Size = 10;
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
				range.Borders.Weight = XlBorderWeight.xlThin;
				range.EntireColumn.AutoFit();
				for (int i = 0; i < rangeRegion.Count; i++)
				{
					int num5 = rangeRegion[i].Start.Row + 1;
					int num6 = rangeRegion[i].Start.Column + 1;
					int num7 = rangeRegion[i].End.Row + 1;
					int num8 = rangeRegion[i].End.Column + 1;
					if (ExcelControl.<Save>o__SiteContainer5.<>p__Site9 == null)
					{
						ExcelControl.<Save>o__SiteContainer5.<>p__Site9 = CallSite<Action<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Merge", null, typeof(ExcelControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Action<CallSite, object, bool> target = ExcelControl.<Save>o__SiteContainer5.<>p__Site9.Target;
					CallSite <>p__Site = ExcelControl.<Save>o__SiteContainer5.<>p__Site9;
					if (ExcelControl.<Save>o__SiteContainer5.<>p__Sitea == null)
					{
						ExcelControl.<Save>o__SiteContainer5.<>p__Sitea = CallSite<Func<CallSite, _Worksheet, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "get_Range", null, typeof(ExcelControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					target(<>p__Site, ExcelControl.<Save>o__SiteContainer5.<>p__Sitea.Target(ExcelControl.<Save>o__SiteContainer5.<>p__Sitea, worksheet, worksheet.Cells[num5, num6], worksheet.Cells[num7, num8]), false);
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
				MessageBox.Show(ex.Message.ToString());
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

		// Token: 0x06000008 RID: 8 RVA: 0x00003044 File Offset: 0x00001244
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
				Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
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
						if (ExcelControl.<Save>o__SiteContainerb.<>p__Sitec == null)
						{
							ExcelControl.<Save>o__SiteContainerb.<>p__Sitec = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
						}
						worksheet = ExcelControl.<Save>o__SiteContainerb.<>p__Sitec.Target(ExcelControl.<Save>o__SiteContainerb.<>p__Sitec, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
						worksheet.Name = name;
						application.ActiveWindow.Zoom = 85;
						if (ExcelControl.<Save>o__SiteContainerb.<>p__Sited == null)
						{
							ExcelControl.<Save>o__SiteContainerb.<>p__Sited = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
						}
						Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<Save>o__SiteContainerb.<>p__Sited.Target(ExcelControl.<Save>o__SiteContainerb.<>p__Sited, worksheet.Cells[1, 1]);
						if (ExcelControl.<Save>o__SiteContainerb.<>p__Sitee == null)
						{
							ExcelControl.<Save>o__SiteContainerb.<>p__Sitee = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
						}
						Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<Save>o__SiteContainerb.<>p__Sitee.Target(ExcelControl.<Save>o__SiteContainerb.<>p__Sitee, worksheet.Cells[num, columnsCount]);
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
							if (ExcelControl.<Save>o__SiteContainerb.<>p__Sitef == null)
							{
								ExcelControl.<Save>o__SiteContainerb.<>p__Sitef = CallSite<Action<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Merge", null, typeof(ExcelControl), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							Action<CallSite, object, bool> target = ExcelControl.<Save>o__SiteContainerb.<>p__Sitef.Target;
							CallSite <>p__Sitef = ExcelControl.<Save>o__SiteContainerb.<>p__Sitef;
							if (ExcelControl.<Save>o__SiteContainerb.<>p__Site10 == null)
							{
								ExcelControl.<Save>o__SiteContainerb.<>p__Site10 = CallSite<Func<CallSite, _Worksheet, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "get_Range", null, typeof(ExcelControl), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							target(<>p__Sitef, ExcelControl.<Save>o__SiteContainerb.<>p__Site10.Target(ExcelControl.<Save>o__SiteContainerb.<>p__Site10, worksheet, worksheet.Cells[row, num4], worksheet.Cells[row2, num5]), false);
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

		// Token: 0x06000009 RID: 9 RVA: 0x000036D0 File Offset: 0x000018D0
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
			if (ExcelControl.<Save>o__SiteContainer11.<>p__Site12 == null)
			{
				ExcelControl.<Save>o__SiteContainer11.<>p__Site12 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
			}
			Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<Save>o__SiteContainer11.<>p__Site12.Target(ExcelControl.<Save>o__SiteContainer11.<>p__Site12, oWS.Cells[iRowIndex, iColIndex]);
			if (ExcelControl.<Save>o__SiteContainer11.<>p__Site13 == null)
			{
				ExcelControl.<Save>o__SiteContainer11.<>p__Site13 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
			}
			Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<Save>o__SiteContainer11.<>p__Site13.Target(ExcelControl.<Save>o__SiteContainer11.<>p__Site13, oWS.Cells[num2, num3]);
			Microsoft.Office.Interop.Excel.Range range = oWS.get_Range(cell, cell2);
			range.Value2 = array;
			range.Font.Name = "Arial";
			range.Font.Size = 10;
			range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
			range.Borders.Weight = XlBorderWeight.xlThin;
			range.EntireColumn.AutoFit();
			return true;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000038C0 File Offset: 0x00001AC0
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

		// Token: 0x02000017 RID: 23
		[CompilerGenerated]
		private static class <Save>o__SiteContainer0
		{
			// Token: 0x04000104 RID: 260
			public static CallSite<Func<CallSite, object, Worksheet>> <>p__Site1;

			// Token: 0x04000105 RID: 261
			public static CallSite<Func<CallSite, Sheets, object, object, object, object, object>> <>p__Site2;

			// Token: 0x04000106 RID: 262
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site3;

			// Token: 0x04000107 RID: 263
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site4;
		}

		// Token: 0x02000026 RID: 38
		[CompilerGenerated]
		private static class <Save>o__SiteContainer5
		{
			// Token: 0x0400011A RID: 282
			public static CallSite<Func<CallSite, object, _Worksheet>> <>p__Site6;

			// Token: 0x0400011B RID: 283
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site7;

			// Token: 0x0400011C RID: 284
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site8;

			// Token: 0x0400011D RID: 285
			public static CallSite<Action<CallSite, object, bool>> <>p__Site9;

			// Token: 0x0400011E RID: 286
			public static CallSite<Func<CallSite, _Worksheet, object, object, object>> <>p__Sitea;
		}

		// Token: 0x02000027 RID: 39
		[CompilerGenerated]
		private static class <Save>o__SiteContainerb
		{
			// Token: 0x0400011F RID: 287
			public static CallSite<Func<CallSite, object, _Worksheet>> <>p__Sitec;

			// Token: 0x04000120 RID: 288
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Sited;

			// Token: 0x04000121 RID: 289
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Sitee;

			// Token: 0x04000122 RID: 290
			public static CallSite<Action<CallSite, object, bool>> <>p__Sitef;

			// Token: 0x04000123 RID: 291
			public static CallSite<Func<CallSite, _Worksheet, object, object, object>> <>p__Site10;
		}

		// Token: 0x02000028 RID: 40
		[CompilerGenerated]
		private static class <Save>o__SiteContainer11
		{
			// Token: 0x04000124 RID: 292
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site12;

			// Token: 0x04000125 RID: 293
			public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> <>p__Site13;
		}
	}
}
