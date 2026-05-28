using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using AlteraSocketView.View;
using DATA;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;

namespace ExcelControls
{
	// Token: 0x02000003 RID: 3
	internal class ExcelControl
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002640 File Offset: 0x00000840
		public bool generateExcel(string filename, DataTable dt)
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
			Application application = (Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			if (ExcelControl.<>o__2.<>p__0 == null)
			{
				ExcelControl.<>o__2.<>p__0 = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
			}
			worksheet = ExcelControl.<>o__2.<>p__0.Target(ExcelControl.<>o__2.<>p__0, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
			try
			{
				if (ExcelControl.<>o__2.<>p__1 == null)
				{
					ExcelControl.<>o__2.<>p__1 = CallSite<Func<CallSite, object, Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Range), typeof(ExcelControl)));
				}
				Range cell = ExcelControl.<>o__2.<>p__1.Target(ExcelControl.<>o__2.<>p__1, worksheet.Cells[1, 1]);
				if (ExcelControl.<>o__2.<>p__2 == null)
				{
					ExcelControl.<>o__2.<>p__2 = CallSite<Func<CallSite, object, Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Range), typeof(ExcelControl)));
				}
				Range cell2 = ExcelControl.<>o__2.<>p__2.Target(ExcelControl.<>o__2.<>p__2, worksheet.Cells[num, count]);
				Range range = worksheet.get_Range(cell, cell2);
				range.Value2 = array;
				range.Font.Name = "Arial";
				range.Font.Size = 10;
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
				range.Borders.Weight = XlBorderWeight.xlThin;
				range.EntireColumn.AutoFit();
				workbook.SaveAs(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				workbook.Close(true, filename, Type.Missing);
				application.Quit();
				Marshal.ReleaseComObject(worksheet);
				Marshal.ReleaseComObject(workbook);
				Marshal.ReleaseComObject(workbooks);
				Marshal.ReleaseComObject(application);
			}
			catch (Exception)
			{
				workbook.Close(true, filename, Type.Missing);
				application.Quit();
				Marshal.ReleaseComObject(worksheet);
				Marshal.ReleaseComObject(workbook);
				Marshal.ReleaseComObject(workbooks);
				Marshal.ReleaseComObject(application);
				return false;
			}
			return true;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000299C File Offset: 0x00000B9C
		public bool generateExcel_BIBoard(string filename, SortedList slData, DataTable dtSum)
		{
			Application application = (Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			_Worksheet worksheet = null;
			try
			{
				int max = slData.Count + 2;
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Making Excel File..");
				this._barPrograss.setMax(max);
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				foreach (object obj in slData)
				{
					CBIBoardInfo cbiboardInfo = (CBIBoardInfo)((DictionaryEntry)obj).Value;
					string strBibNo = cbiboardInfo.strBibNo;
					DataTable dataTSocket = cbiboardInfo.dataTSocket;
					int num = dataTSocket.Rows.Count + 1;
					int count = dataTSocket.Columns.Count;
					object[,] array = new object[num, count];
					for (int i = 0; i < count; i++)
					{
						array[0, i] = dataTSocket.Columns[i].ToString();
					}
					for (int j = 0; j < dataTSocket.Rows.Count; j++)
					{
						for (int k = 0; k < count; k++)
						{
							array[j + 1, k] = dataTSocket.Rows[j][k].ToString();
						}
					}
					if (ExcelControl.<>o__3.<>p__0 == null)
					{
						ExcelControl.<>o__3.<>p__0 = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
					}
					worksheet = ExcelControl.<>o__3.<>p__0.Target(ExcelControl.<>o__3.<>p__0, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
					worksheet.Name = strBibNo;
					if (ExcelControl.<>o__3.<>p__1 == null)
					{
						ExcelControl.<>o__3.<>p__1 = CallSite<Func<CallSite, object, Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Range), typeof(ExcelControl)));
					}
					Range cell = ExcelControl.<>o__3.<>p__1.Target(ExcelControl.<>o__3.<>p__1, worksheet.Cells[1, 1]);
					if (ExcelControl.<>o__3.<>p__2 == null)
					{
						ExcelControl.<>o__3.<>p__2 = CallSite<Func<CallSite, object, Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Range), typeof(ExcelControl)));
					}
					Range cell2 = ExcelControl.<>o__3.<>p__2.Target(ExcelControl.<>o__3.<>p__2, worksheet.Cells[num, count]);
					Range range = worksheet.get_Range(cell, cell2);
					range.Value2 = array;
					range.Font.Name = "맑은 고딕";
					range.Font.Size = 10;
					range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
					range.EntireColumn.AutoFit();
					this._barPrograss.progress_increase();
				}
				int num2 = dtSum.Rows.Count + 1;
				int count2 = dtSum.Columns.Count;
				object[,] array2 = new object[num2, count2];
				for (int l = 0; l < count2; l++)
				{
					array2[0, l] = dtSum.Columns[l].ToString();
				}
				for (int m = 0; m < dtSum.Rows.Count; m++)
				{
					for (int n = 0; n < count2; n++)
					{
						array2[m + 1, n] = dtSum.Rows[m][n].ToString();
					}
				}
				if (ExcelControl.<>o__3.<>p__3 == null)
				{
					ExcelControl.<>o__3.<>p__3 = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
				}
				worksheet = ExcelControl.<>o__3.<>p__3.Target(ExcelControl.<>o__3.<>p__3, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
				worksheet.Name = "Summary";
				if (ExcelControl.<>o__3.<>p__4 == null)
				{
					ExcelControl.<>o__3.<>p__4 = CallSite<Func<CallSite, object, Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Range), typeof(ExcelControl)));
				}
				Range cell3 = ExcelControl.<>o__3.<>p__4.Target(ExcelControl.<>o__3.<>p__4, worksheet.Cells[1, 1]);
				if (ExcelControl.<>o__3.<>p__5 == null)
				{
					ExcelControl.<>o__3.<>p__5 = CallSite<Func<CallSite, object, Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Range), typeof(ExcelControl)));
				}
				Range cell4 = ExcelControl.<>o__3.<>p__5.Target(ExcelControl.<>o__3.<>p__5, worksheet.Cells[num2, count2]);
				Range range2 = worksheet.get_Range(cell3, cell4);
				range2.Value2 = array2;
				range2.Font.Name = "맑은 고딕";
				range2.Font.Size = 10;
				range2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
				range2.EntireColumn.AutoFit();
				this._barPrograss.progress_increase();
				workbook.SaveAs(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				workbook.Close(true, filename, Type.Missing);
				application.Quit();
				Marshal.ReleaseComObject(worksheet);
				Marshal.ReleaseComObject(workbook);
				Marshal.ReleaseComObject(workbooks);
				Marshal.ReleaseComObject(application);
			}
			catch (Exception)
			{
				workbook.Close(true, filename, Type.Missing);
				application.Quit();
				Marshal.ReleaseComObject(worksheet);
				Marshal.ReleaseComObject(workbook);
				Marshal.ReleaseComObject(workbooks);
				Marshal.ReleaseComObject(application);
				Thread.Sleep(10);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
				return false;
			}
			Thread.Sleep(10);
			if (this._barPrograss != null)
			{
				this._barPrograss._ischeck = true;
			}
			this._barPrograss = null;
			return true;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00003004 File Offset: 0x00001204
		public bool generateExcel_BIBoard(string filename, SortedList slData, List<DataTable> dtSum)
		{
			Application application = (Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			_Worksheet worksheet = null;
			try
			{
				int max = slData.Count + 2;
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Making Excel File..");
				this._barPrograss.setMax(max);
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				foreach (object obj in slData)
				{
					CBIBoardInfo cbiboardInfo = (CBIBoardInfo)((DictionaryEntry)obj).Value;
					string strBibNo = cbiboardInfo.strBibNo;
					DataTable dataTSocket = cbiboardInfo.dataTSocket;
					int num = dataTSocket.Rows.Count + 1;
					int count = dataTSocket.Columns.Count;
					object[,] array = new object[num, count];
					for (int i = 0; i < count; i++)
					{
						array[0, i] = dataTSocket.Columns[i].ToString();
					}
					for (int j = 0; j < dataTSocket.Rows.Count; j++)
					{
						for (int k = 0; k < count; k++)
						{
							array[j + 1, k] = dataTSocket.Rows[j][k].ToString();
						}
					}
					if (ExcelControl.<>o__4.<>p__0 == null)
					{
						ExcelControl.<>o__4.<>p__0 = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
					}
					worksheet = ExcelControl.<>o__4.<>p__0.Target(ExcelControl.<>o__4.<>p__0, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
					worksheet.Name = strBibNo;
					if (ExcelControl.<>o__4.<>p__1 == null)
					{
						ExcelControl.<>o__4.<>p__1 = CallSite<Func<CallSite, object, Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Range), typeof(ExcelControl)));
					}
					Range cell = ExcelControl.<>o__4.<>p__1.Target(ExcelControl.<>o__4.<>p__1, worksheet.Cells[1, 1]);
					if (ExcelControl.<>o__4.<>p__2 == null)
					{
						ExcelControl.<>o__4.<>p__2 = CallSite<Func<CallSite, object, Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Range), typeof(ExcelControl)));
					}
					Range cell2 = ExcelControl.<>o__4.<>p__2.Target(ExcelControl.<>o__4.<>p__2, worksheet.Cells[num, count]);
					Range range = worksheet.get_Range(cell, cell2);
					range.Value2 = array;
					range.Font.Name = "맑은 고딕";
					range.Font.Size = 10;
					range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
					range.EntireColumn.AutoFit();
					this._barPrograss.progress_increase();
				}
				foreach (DataTable dataTable in dtSum)
				{
					DataTable dataTable2 = dataTable;
					int num2 = dataTable2.Rows.Count + 1;
					int count2 = dataTable2.Columns.Count;
					object[,] array2 = new object[num2, count2];
					for (int l = 0; l < count2; l++)
					{
						array2[0, l] = dataTable2.Columns[l].ToString();
					}
					for (int m = 0; m < dataTable2.Rows.Count; m++)
					{
						for (int n = 0; n < count2; n++)
						{
							array2[m + 1, n] = dataTable2.Rows[m][n].ToString();
						}
					}
					if (ExcelControl.<>o__4.<>p__3 == null)
					{
						ExcelControl.<>o__4.<>p__3 = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
					}
					worksheet = ExcelControl.<>o__4.<>p__3.Target(ExcelControl.<>o__4.<>p__3, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
					worksheet.Name = dataTable.TableName;
					if (ExcelControl.<>o__4.<>p__4 == null)
					{
						ExcelControl.<>o__4.<>p__4 = CallSite<Func<CallSite, object, Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Range), typeof(ExcelControl)));
					}
					Range cell3 = ExcelControl.<>o__4.<>p__4.Target(ExcelControl.<>o__4.<>p__4, worksheet.Cells[1, 1]);
					if (ExcelControl.<>o__4.<>p__5 == null)
					{
						ExcelControl.<>o__4.<>p__5 = CallSite<Func<CallSite, object, Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Range), typeof(ExcelControl)));
					}
					Range cell4 = ExcelControl.<>o__4.<>p__5.Target(ExcelControl.<>o__4.<>p__5, worksheet.Cells[num2, count2]);
					Range range2 = worksheet.get_Range(cell3, cell4);
					range2.Value2 = array2;
					range2.Font.Name = "맑은 고딕";
					range2.Font.Size = 10;
					range2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
					range2.EntireColumn.AutoFit();
					this._barPrograss.progress_increase();
				}
				workbook.SaveAs(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				workbook.Close(true, filename, Type.Missing);
				application.Quit();
				Marshal.ReleaseComObject(worksheet);
				Marshal.ReleaseComObject(workbook);
				Marshal.ReleaseComObject(workbooks);
				Marshal.ReleaseComObject(application);
			}
			catch (Exception)
			{
				workbook.Close(true, filename, Type.Missing);
				application.Quit();
				Marshal.ReleaseComObject(worksheet);
				Marshal.ReleaseComObject(workbook);
				Marshal.ReleaseComObject(workbooks);
				Marshal.ReleaseComObject(application);
				Thread.Sleep(10);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
				return false;
			}
			Thread.Sleep(10);
			if (this._barPrograss != null)
			{
				this._barPrograss._ischeck = true;
			}
			this._barPrograss = null;
			return true;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000036BC File Offset: 0x000018BC
		private void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x0400000C RID: 12
		private BarPrograss _barPrograss;

		// Token: 0x0400000D RID: 13
		private Thread _thread;
	}
}
