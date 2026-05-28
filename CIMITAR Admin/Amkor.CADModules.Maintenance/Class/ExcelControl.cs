using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using ATDFW.Classes.CIMitar;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;
using SevenZip;
using SourceGrid;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.Maintenance.Class
{
	// Token: 0x02000055 RID: 85
	internal class ExcelControl
	{
		// Token: 0x060005DA RID: 1498 RVA: 0x00086FAC File Offset: 0x000851AC
		public static bool SaveCSV(string path, DataTable dt, bool excuteExcel)
		{
			bool result;
			try
			{
				bool flag = dt != null;
				if (flag)
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

		// Token: 0x060005DB RID: 1499 RVA: 0x000870E4 File Offset: 0x000852E4
		public static bool SaveCSV(string path, Grid grid, bool excuteExcel)
		{
			bool result;
			try
			{
				bool flag = grid != null;
				if (flag)
				{
					Encoding encoding = Encoding.GetEncoding("euc-kr");
					StreamWriter streamWriter = new StreamWriter(path, false, encoding);
					for (int i = 0; i < grid.Rows.Count; i++)
					{
						for (int j = 0; j < grid.Columns.Count; j++)
						{
							bool visible = grid.Columns[j].Visible;
							if (visible)
							{
								bool flag2 = grid[i, j] == null;
								string text;
								if (flag2)
								{
									text = "";
								}
								else
								{
									bool flag3 = grid[i, j].Value == null;
									if (flag3)
									{
										text = "";
									}
									else
									{
										text = grid[i, j].Value.ToString();
									}
								}
								bool flag4 = text.Contains("\n");
								if (flag4)
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

		// Token: 0x060005DC RID: 1500 RVA: 0x0008727C File Offset: 0x0008547C
		public static bool Save(string fileName, RadGridView grid, string sSheetName, bool HeaderFlag, bool visibleFlag)
		{
			int num = grid.Rows.Count;
			int count = grid.Columns.Count;
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
						array[num2, i] = grid.Columns[i].HeaderText.ToString();
					}
					num2++;
				}
				for (int j = 0; j < grid.Rows.Count; j++)
				{
					for (int k = 0; k < count; k++)
					{
						array[num2, k] = grid.Rows[j].Cells[k].Value.ToString();
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
			if (ExcelControl.<>o__2.<>p__1 == null)
			{
				ExcelControl.<>o__2.<>p__1 = CallSite<Func<CallSite, object, Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Worksheet), typeof(ExcelControl)));
			}
			Func<CallSite, object, Worksheet> target = ExcelControl.<>o__2.<>p__1.Target;
			CallSite <>p__ = ExcelControl.<>o__2.<>p__1;
			if (ExcelControl.<>o__2.<>p__0 == null)
			{
				ExcelControl.<>o__2.<>p__0 = CallSite<Func<CallSite, Sheets, object, object, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "Add", null, typeof(ExcelControl), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			worksheet = target(<>p__, ExcelControl.<>o__2.<>p__0.Target(ExcelControl.<>o__2.<>p__0, workbook.Worksheets, Type.Missing, workbook.Worksheets[workbook.Worksheets.Count], Type.Missing, Type.Missing));
			worksheet.Name = "Reort History";
			bool flag = sSheetName != string.Empty;
			if (flag)
			{
				worksheet.Name = sSheetName;
			}
			try
			{
				if (ExcelControl.<>o__2.<>p__2 == null)
				{
					ExcelControl.<>o__2.<>p__2 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<>o__2.<>p__2.Target(ExcelControl.<>o__2.<>p__2, worksheet.Cells[1, 1]);
				if (ExcelControl.<>o__2.<>p__3 == null)
				{
					ExcelControl.<>o__2.<>p__3 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<>o__2.<>p__3.Target(ExcelControl.<>o__2.<>p__3, worksheet.Cells[num, count]);
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
			catch (Exception ex2)
			{
				workbook.Close(true, fileName, Type.Missing);
				application.Quit();
				bool flag2 = worksheet != null;
				if (flag2)
				{
					Marshal.ReleaseComObject(worksheet);
				}
				bool flag3 = workbook != null;
				if (flag3)
				{
					Marshal.ReleaseComObject(workbook);
				}
				bool flag4 = workbooks != null;
				if (flag4)
				{
					Marshal.ReleaseComObject(workbooks);
				}
				bool flag5 = application != null;
				if (flag5)
				{
					Marshal.ReleaseComObject(application);
				}
				return false;
			}
			return true;
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0008774C File Offset: 0x0008594C
		public static bool Save2(FactorySettings factorySettings, string filepath, RadGridView grid, bool visibleFlag, QueryMgr _queryMgr, string factory, string category, ReportList reportList)
		{
			int num = 0;
			int num2 = 7;
			List<string> list = cConst.sCategory;
			GridDataView gridDataView = grid.MasterTemplate.DataView as GridDataView;
			Dictionary<string, object[,]> dictionary = new Dictionary<string, object[,]>();
			Dictionary<string, RangeRegion> dictionary2 = new Dictionary<string, RangeRegion>();
			bool flag = gridDataView.ItemCount == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				foreach (object obj in gridDataView[gridDataView.ItemCount - 1].Cells)
				{
					GridViewCellInfo gridViewCellInfo = (GridViewCellInfo)obj;
					bool flag2 = gridViewCellInfo.ColumnInfo.IsVisible && gridViewCellInfo.ColumnInfo.HeaderText.ToUpper() != "VIEW";
					if (flag2)
					{
						num++;
					}
				}
				list.Remove("HCC");
				list.Remove("TEST(TFA)");
				bool flag3 = category == "All" || category == "HCC";
				if (flag3)
				{
					foreach (ReportList.ReportObject reportObject in reportList.listReport)
					{
						bool flag4 = reportObject.Category == "HCC";
						if (flag4)
						{
							bool flag5 = list.IndexOf(reportObject.Model) == -1;
							if (flag5)
							{
								list.Add(reportObject.Model);
							}
						}
					}
				}
				int index2;
				int index;
				for (index = 0; index < list.Count; index = index2 + 1)
				{
					bool flag6 = category != "All" && category != "HCC" && list[index] != category;
					if (!flag6)
					{
						cConst.initContents(factorySettings, factory, list[index]);
						int num3 = num + num2 + cConst.listContents.Count;
						RangeRegion rangeRegion = new RangeRegion();
						int num4 = gridDataView.Indexer.Items.Count((GridViewRowInfo x) => (x.Cells["Category"].Value.ToString() != "HCC") ? (x.Cells["Category"].Value.ToString() == list[index]) : (x.Cells["Model"].Value.ToString() == list[index])) + 1;
						bool flag7 = num4 <= 1;
						if (!flag7)
						{
							object[,] array = new object[num4, num3];
							string str = string.Empty;
							try
							{
								array[0, num] = "Hold Department";
								array[0, num + 1] = "Hold Name";
								array[0, num + 2] = "Hold Comment";
								array[0, num + 3] = "Check Item";
								array[0, num + 4] = "Requirement";
								array[0, num + 5] = "Case of the Problem";
								array[0, num + 6] = "Corrective Action";
								for (int i = 0; i < cConst.listContents.Count; i++)
								{
									array[0, num + num2 + i] = cConst.listContents[i + 1];
								}
								array[0, num3 - 1] = "Attachment";
								int num5 = 1;
								bool flag8 = false;
								int j = 0;
								while (j < gridDataView.ItemCount)
								{
									int num6 = 0;
									bool flag9 = gridDataView[j].Cells["Category"].Value.ToString() != "HCC";
									if (flag9)
									{
										bool flag10 = list[index] != gridDataView[j].Cells["Category"].Value.ToString();
										if (!flag10)
										{
											goto IL_44F;
										}
									}
									else
									{
										bool flag11 = gridDataView[j].Cells["Category"].Value.ToString() == "HCC";
										if (!flag11)
										{
											goto IL_44F;
										}
										bool flag12 = list[index] != gridDataView[j].Cells["Model"].Value.ToString();
										if (!flag12)
										{
											goto IL_44F;
										}
									}
									IL_A91:
									j++;
									continue;
									IL_44F:
									rangeRegion.Add(new Position(j, num + num2 + cConst.listContents.Count));
									for (int k = 0; k < gridDataView[j].Cells.Count; k++)
									{
										bool flag13 = gridDataView[j].Cells[k].ColumnInfo.IsVisible && gridDataView[j].Cells[k].ColumnInfo.HeaderText.ToUpper() != "VIEW";
										if (flag13)
										{
											bool flag14 = num5 == 1;
											if (flag14)
											{
												array[0, num6] = gridDataView[j].Cells[k].ColumnInfo.HeaderText;
											}
											array[num5, num6] = gridDataView[j].Cells[k].Value.ToString();
											bool flag15 = gridDataView[j].Cells[k].ColumnInfo.HeaderText.ToUpper() == "REPORT NO.";
											if (flag15)
											{
												bool flag16 = gridDataView[j].Cells[k].Value != null;
												if (flag16)
												{
													str = gridDataView[j].Cells[k].Value.ToString();
													string text = gridDataView[j].Cells[k].Value.ToString();
													string text2 = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintReportInfo] @_Report= N'" + str + "'";
													bool flag17 = text.IndexOf("PM") != -1;
													if (flag17)
													{
														text2 += ", @_Mode=N'PMEXCEL'";
													}
													else
													{
														text2 += ", @_Mode=N'EXCEL'";
													}
													DataSet dataSet = _queryMgr.queryCall(text2);
													bool flag18 = dataSet != null;
													if (flag18)
													{
														bool flag19 = dataSet.Tables != null && dataSet.Tables.Count != 0;
														if (flag19)
														{
															bool flag20 = dataSet.Tables[0].Rows.Count != 0;
															if (flag20)
															{
																for (int l = 0; l < dataSet.Tables[0].Rows.Count; l++)
																{
																	string text3 = dataSet.Tables[0].Rows[l]["Comment"].ToString();
																	string text4 = dataSet.Tables[0].Rows[l]["Corrective"].ToString();
																	string text5 = dataSet.Tables[0].Rows[l]["Problem"].ToString();
																	string text6 = dataSet.Tables[0].Rows[l]["Action"].ToString();
																	string text7 = dataSet.Tables[0].Rows[l]["Holdteam"].ToString();
																	string text8 = dataSet.Tables[0].Rows[l]["Holdname"].ToString();
																	string text9 = dataSet.Tables[0].Rows[l]["HoldComment"].ToString();
																	string text10 = dataSet.Tables[0].Rows[l]["HoldComment"].ToString();
																	string text11 = dataSet.Tables[0].Rows[l]["AttachmentFile"].ToString();
																	string text12 = dataSet.Tables[0].Rows[l]["ActionAttachmentFile"].ToString();
																	string[] array2 = dataSet.Tables[0].Rows[l]["DetailComment"].ToString().Split(new char[]
																	{
																		'|'
																	});
																	array[num5, num] = text7;
																	array[num5, num + 1] = text8;
																	array[num5, num + 2] = text9;
																	for (int m = 0; m < cConst.listContents.Count; m++)
																	{
																		bool flag21 = m >= array2.Length;
																		if (flag21)
																		{
																			break;
																		}
																		array[num5, num + num2 + m] = array2[m];
																	}
																	bool flag22 = text3.IndexOf("=") != -1;
																	if (flag22)
																	{
																		text3 = text3.Replace("=", "'=");
																	}
																	array[num5, num + 3] = text3;
																	bool flag23 = text4.IndexOf("=") != -1;
																	if (flag23)
																	{
																		text4 = text4.Replace("=", "'=");
																	}
																	array[num5, num + 4] = text4;
																	bool flag24 = text5.IndexOf("=") != -1;
																	if (flag24)
																	{
																		text5 = text5.Replace("=", "'=");
																	}
																	array[num5, num + 5] = text5;
																	bool flag25 = text6.IndexOf("=") != -1;
																	if (flag25)
																	{
																		text6 = text6.Replace("=", "'=");
																	}
																	array[num5, num + 6] = text6;
																	bool flag26 = text11.Trim() == "0" && text12.Trim() == "0";
																	if (flag26)
																	{
																		array[num5, num3 - 1] = "No";
																	}
																	else
																	{
																		array[num5, num3 - 1] = "Yes";
																	}
																}
															}
														}
													}
												}
												else
												{
													array[num5, num6] = "N/A";
												}
												flag8 = true;
											}
											num6++;
										}
									}
									bool flag27 = flag8;
									if (flag27)
									{
										num5++;
										flag8 = false;
									}
									goto IL_A91;
								}
							}
							catch (Exception ex)
							{
								ex.Message.ToString();
								return false;
							}
							dictionary.Add(list[index], array);
							dictionary2.Add(list[index], rangeRegion);
						}
					}
					index2 = index;
				}
				_Worksheet worksheet = null;
				Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
				Workbooks workbooks = application.Workbooks;
				_Workbook workbook = workbooks.Add(Missing.Value);
				application.DisplayAlerts = false;
				foreach (KeyValuePair<string, object[,]> keyValuePair in dictionary)
				{
					RangeRegion rangeRegion2 = dictionary2[keyValuePair.Key];
					if (ExcelControl.<>o__3.<>p__1 == null)
					{
						ExcelControl.<>o__3.<>p__1 = CallSite<Func<CallSite, object, Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Worksheet), typeof(ExcelControl)));
					}
					Func<CallSite, object, Worksheet> target = ExcelControl.<>o__3.<>p__1.Target;
					CallSite <>p__ = ExcelControl.<>o__3.<>p__1;
					if (ExcelControl.<>o__3.<>p__0 == null)
					{
						ExcelControl.<>o__3.<>p__0 = CallSite<Func<CallSite, Sheets, object, Missing, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "Add", null, typeof(ExcelControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					worksheet = target(<>p__, ExcelControl.<>o__3.<>p__0.Target(ExcelControl.<>o__3.<>p__0, workbook.Worksheets, workbook.Worksheets[workbook.Worksheets.Count], Missing.Value, Type.Missing, Type.Missing));
					worksheet.Name = keyValuePair.Key;
					try
					{
						if (ExcelControl.<>o__3.<>p__2 == null)
						{
							ExcelControl.<>o__3.<>p__2 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
						}
						Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<>o__3.<>p__2.Target(ExcelControl.<>o__3.<>p__2, worksheet.Cells[1, 1]);
						if (ExcelControl.<>o__3.<>p__3 == null)
						{
							ExcelControl.<>o__3.<>p__3 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
						}
						Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<>o__3.<>p__3.Target(ExcelControl.<>o__3.<>p__3, worksheet.Cells[keyValuePair.Value.GetLength(0), keyValuePair.Value.GetLength(1)]);
						Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(cell, cell2);
						range.Value2 = keyValuePair.Value;
						range.Font.Name = "Arial";
						range.Font.Size = 10;
						range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
						range.Borders.Weight = XlBorderWeight.xlThin;
						range.EntireColumn.AutoFit();
						for (int n = 0; n < rangeRegion2.Count; n++)
						{
							int num7 = rangeRegion2[n].Start.Row + 1;
							int num8 = rangeRegion2[n].Start.Column + 1;
							int num9 = rangeRegion2[n].End.Row + 1;
							int num10 = rangeRegion2[n].End.Column + 1;
						}
						Marshal.ReleaseComObject(worksheet);
					}
					catch (Exception ex2)
					{
						workbook.Close(true, filepath, Type.Missing);
						application.Quit();
						bool flag28 = worksheet != null;
						if (flag28)
						{
							Marshal.ReleaseComObject(worksheet);
						}
						bool flag29 = workbook != null;
						if (flag29)
						{
							Marshal.ReleaseComObject(workbook);
						}
						bool flag30 = workbooks != null;
						if (flag30)
						{
							Marshal.ReleaseComObject(workbooks);
						}
						bool flag31 = application != null;
						if (flag31)
						{
							Marshal.ReleaseComObject(application);
						}
						return false;
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
				Marshal.ReleaseComObject(workbook);
				Marshal.ReleaseComObject(workbooks);
				Marshal.ReleaseComObject(application);
				result = true;
			}
			return result;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0008879C File Offset: 0x0008699C
		public static bool Save3(FactorySettings factorySettings, string filepath, RadGridView grid, bool visibleFlag, QueryMgr _queryMgr, string factory, string category, ReportList reportList)
		{
			ExcelControl.<>c__DisplayClass4_0 CS$<>8__locals1 = new ExcelControl.<>c__DisplayClass4_0();
			int num = 0;
			CS$<>8__locals1.list = cConst.sCategory;
			GridDataView gridDataView = grid.MasterTemplate.DataView as GridDataView;
			Dictionary<string, object[,]> dictionary = new Dictionary<string, object[,]>();
			Dictionary<string, RangeRegion> dictionary2 = new Dictionary<string, RangeRegion>();
			int num2 = 30;
			bool flag = false;
			RangeRegion rangeRegion = new RangeRegion();
			CS$<>8__locals1.list.Remove("HCC");
			CS$<>8__locals1.list.Remove("TEST(TFA)");
			bool flag2 = category == "All" || category == "HCC";
			if (flag2)
			{
				foreach (ReportList.ReportObject reportObject in reportList.listReport)
				{
					bool flag3 = reportObject.Category == "HCC";
					if (flag3)
					{
						bool flag4 = CS$<>8__locals1.list.IndexOf(reportObject.Model) == -1;
						if (flag4)
						{
							CS$<>8__locals1.list.Add(reportObject.Model);
						}
					}
				}
			}
			foreach (object obj in gridDataView[gridDataView.ItemCount - 1].Cells)
			{
				GridViewCellInfo gridViewCellInfo = (GridViewCellInfo)obj;
				bool flag5 = gridViewCellInfo.ColumnInfo.HeaderText.ToUpper() == "STATUS" || gridViewCellInfo.ColumnInfo.HeaderText.ToUpper() == "REPORT NO.";
				if (flag5)
				{
					num++;
				}
			}
			int index;
			int index2;
			for (index = 0; index < CS$<>8__locals1.list.Count; index = index2 + 1)
			{
				bool flag6 = category != "All" && category != "HCC" && CS$<>8__locals1.list[index] != category;
				if (!flag6)
				{
					cConst.initContents(factorySettings, factory, CS$<>8__locals1.list[index]);
					DataTable dataTable = (DataTable)grid.DataSource;
					int num3 = num + num2 + cConst.listContents.Count;
					int num4 = gridDataView.Indexer.Items.Count((GridViewRowInfo x) => (x.Cells["Category"].Value.ToString() != "HCC") ? (x.Cells["Category"].Value.ToString() == CS$<>8__locals1.list[index]) : (x.Cells["Model"].Value.ToString() == CS$<>8__locals1.list[index])) + 1;
					num3++;
					bool flag7 = num4 <= 1;
					if (!flag7)
					{
						object[,] array = new object[num4, num3];
						try
						{
							int num5 = 1;
							array[0, 0] = "Status";
							array[0, 1] = "Report No.";
							array[0, num] = "Category";
							array[0, num + 1] = "Model";
							array[0, num + 2] = "M/C No.";
							array[0, num + 3] = "Rsc Dec";
							array[0, num + 4] = "Asset";
							array[0, num + 5] = "Case";
							array[0, num + 6] = "Factor";
							array[0, num + 7] = "Work Type";
							array[0, num + 8] = "Vendor";
							array[0, num + 9] = "Difficulty";
							array[0, num + 10] = "Requester Team";
							array[0, num + 11] = "Requester Name";
							array[0, num + 12] = "Request Time";
							array[0, num + 13] = "Approval Team";
							array[0, num + 14] = "Approval Name";
							array[0, num + 15] = "Approval Time";
							array[0, num + 16] = "Done Team";
							array[0, num + 17] = "Done Name";
							array[0, num + 18] = "Start Time";
							array[0, num + 19] = "Done Time";
							array[0, num + 20] = "Final Team";
							array[0, num + 21] = "Final Name";
							array[0, num + 22] = "Final Time";
							array[0, num + 23] = "Problems or Reason of use";
							array[0, num + 24] = "Evidence (PCS pre-approval)";
							array[0, num + 25] = "Approval Comment";
							array[0, num + 26] = "Actions and Changes";
							array[0, num + 27] = "Result and Evaluation";
							array[0, num + 28] = "Comment";
							array[0, num + 29] = "Final Comment";
							array[0, num + 30] = "Cancel Comment";
							for (int i = 0; i < cConst.listContents.Count; i++)
							{
								array[0, num + num2 + i] = cConst.listContents[i + 1];
							}
							array[0, num3 - 1] = "Attachment";
							int j = 0;
							while (j < gridDataView.ItemCount)
							{
								bool flag8 = gridDataView[j].Cells["Category"].Value.ToString() != "HCC";
								if (flag8)
								{
									bool flag9 = CS$<>8__locals1.list[index] != grid.Rows[j].Cells["Category"].Value.ToString();
									if (!flag9)
									{
										goto IL_612;
									}
								}
								else
								{
									bool flag10 = gridDataView[j].Cells["Category"].Value.ToString() == "HCC";
									if (!flag10)
									{
										goto IL_612;
									}
									bool flag11 = CS$<>8__locals1.list[index] != grid.Rows[j].Cells["Model"].Value.ToString();
									if (!flag11)
									{
										goto IL_612;
									}
								}
								IL_121B:
								j++;
								continue;
								IL_612:
								int num6 = 0;
								Position pCell = new Position(j, num + num2 + cConst.listContents.Count);
								rangeRegion.Add(pCell);
								for (int k = 0; k < gridDataView[j].Cells.Count; k++)
								{
									bool flag12 = gridDataView[j].Cells[k].ColumnInfo.HeaderText.ToUpper() == "STATUS" || gridDataView[j].Cells[k].ColumnInfo.HeaderText.ToUpper() == "REPORT NO.";
									if (flag12)
									{
										array[num5, num6] = gridDataView[j].Cells[k].Value.ToString();
										Debug.WriteLine(string.Concat(new string[]
										{
											"i : ",
											j.ToString(),
											" j : ",
											k.ToString(),
											" ibind :",
											num6.ToString()
										}));
										bool flag13 = gridDataView[j].Cells[k].ColumnInfo.HeaderText.ToUpper() == "REPORT NO.";
										if (flag13)
										{
											bool flag14 = gridDataView[j].Cells[k].Value != null;
											if (flag14)
											{
												string str = gridDataView[j].Cells[k].Value.ToString();
												string text = gridDataView[j].Cells["Status"].Value.ToString();
												string text2 = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintReportInfo] @_Report= N'" + str + "'";
												bool flag15 = text.IndexOf("PM") != -1;
												if (flag15)
												{
													text2 += ", @_Mode=N'PMEXCEL'";
												}
												else
												{
													text2 += ", @_Mode=N'EXCEL'";
												}
												DataSet dataSet = _queryMgr.queryCall(text2);
												bool flag16 = dataSet != null;
												if (flag16)
												{
													bool flag17 = dataSet.Tables != null && dataSet.Tables.Count != 0;
													if (flag17)
													{
														bool flag18 = dataSet.Tables[0].Rows.Count != 0;
														if (flag18)
														{
															for (int l = 0; l < dataSet.Tables[0].Rows.Count; l++)
															{
																string text3 = dataSet.Tables[0].Rows[l]["content1"].ToString();
																string text4 = dataSet.Tables[0].Rows[l]["content2"].ToString();
																string text5 = dataSet.Tables[0].Rows[l]["content3"].ToString();
																string text6 = dataSet.Tables[0].Rows[l]["content4"].ToString();
																string text7 = dataSet.Tables[0].Rows[l]["content5"].ToString();
																string text8 = dataSet.Tables[0].Rows[l]["content6"].ToString();
																string text9 = dataSet.Tables[0].Rows[l]["content7"].ToString();
																string text10 = dataSet.Tables[0].Rows[l]["content8"].ToString();
																string text11 = "0";
																string text12 = "0";
																string text13 = dataSet.Tables[0].Rows[l]["ApprovalTime"].ToString();
																string text14 = dataSet.Tables[0].Rows[l]["DoneTime"].ToString();
																string text15 = dataSet.Tables[0].Rows[l]["FinalTime"].ToString();
																string text16 = dataSet.Tables[0].Rows[l]["StartTime"].ToString();
																array[num5, num] = dataSet.Tables[0].Rows[l]["Category"].ToString();
																array[num5, num + 1] = dataSet.Tables[0].Rows[l]["Model"].ToString();
																array[num5, num + 2] = dataSet.Tables[0].Rows[l]["Machine"].ToString();
																array[num5, num + 3] = dataSet.Tables[0].Rows[l]["Type"].ToString();
																array[num5, num + 4] = dataSet.Tables[0].Rows[l]["Asset"].ToString();
																array[num5, num + 5] = dataSet.Tables[0].Rows[l]["Case"].ToString();
																array[num5, num + 6] = dataSet.Tables[0].Rows[l]["Factor"].ToString();
																array[num5, num + 7] = dataSet.Tables[0].Rows[l]["WorkType"].ToString();
																array[num5, num + 8] = dataSet.Tables[0].Rows[l]["Vendor"].ToString();
																array[num5, num + 9] = dataSet.Tables[0].Rows[l]["diff"].ToString();
																array[num5, num + 10] = dataSet.Tables[0].Rows[l]["Team"].ToString();
																array[num5, num + 11] = dataSet.Tables[0].Rows[l]["Name"].ToString();
																array[num5, num + 12] = dataSet.Tables[0].Rows[l]["RequestTime"].ToString();
																array[num5, num + 13] = dataSet.Tables[0].Rows[l]["ApprovalTeam"].ToString();
																array[num5, num + 14] = dataSet.Tables[0].Rows[l]["ApprovalName"].ToString();
																array[num5, num + 15] = ((text13.IndexOf("1900") != -1) ? string.Empty : text13);
																array[num5, num + 16] = dataSet.Tables[0].Rows[l]["DoneTeam"].ToString();
																array[num5, num + 17] = dataSet.Tables[0].Rows[l]["DoneName"].ToString();
																array[num5, num + 18] = ((text16.IndexOf("1900") != -1) ? string.Empty : text16);
																array[num5, num + 19] = ((text14.IndexOf("1900") != -1) ? string.Empty : text14);
																array[num5, num + 20] = dataSet.Tables[0].Rows[l]["FinalTeam"].ToString();
																array[num5, num + 21] = dataSet.Tables[0].Rows[l]["FinalName"].ToString();
																array[num5, num + 22] = ((text15.IndexOf("1900") != -1) ? string.Empty : text15);
																bool flag19 = text3.IndexOf("=") != -1;
																if (flag19)
																{
																	text3 = text3.Replace("=", "'=");
																}
																array[num5, num + 23] = text3;
																bool flag20 = text10.IndexOf("=") != -1;
																if (flag20)
																{
																	text10 = text10.Replace("=", "'=");
																}
																array[num5, num + 24] = text10;
																bool flag21 = text4.IndexOf("=") != -1;
																if (flag21)
																{
																	text4 = text4.Replace("=", "'=");
																}
																array[num5, num + 25] = text4;
																bool flag22 = text5.IndexOf("=") != -1;
																if (flag22)
																{
																	text5 = text5.Replace("=", "'=");
																}
																array[num5, num + 26] = text5;
																bool flag23 = text6.IndexOf("=") != -1;
																if (flag23)
																{
																	text6 = text6.Replace("=", "'=");
																}
																array[num5, num + 27] = text6;
																bool flag24 = text7.IndexOf("=") != -1;
																if (flag24)
																{
																	text7 = text7.Replace("=", "'=");
																}
																array[num5, num + 28] = text7;
																bool flag25 = text8.IndexOf("=") != -1;
																if (flag25)
																{
																	text8 = text7.Replace("=", "'=");
																}
																array[num5, num + 29] = text8;
																bool flag26 = text9.IndexOf("=") != -1;
																if (flag26)
																{
																	text9 = text9.Replace("=", "'=");
																}
																array[num5, num + 30] = text9;
																string[] array2 = dataSet.Tables[0].Rows[l]["DetailComment"].ToString().Split(new char[]
																{
																	'|'
																});
																for (int m = 0; m < cConst.listContents.Count; m++)
																{
																	bool flag27 = m >= array2.Length;
																	if (flag27)
																	{
																		break;
																	}
																	array[num5, num + num2 + m] = array2[m];
																}
																bool flag28 = text12.Trim() == "0" && text11.Trim() == "0";
																if (flag28)
																{
																	array[num5, num3 - 1] = "No";
																}
																else
																{
																	array[num5, num3 - 1] = "Yes";
																}
															}
														}
													}
												}
											}
											else
											{
												array[num5, num6] = "N/A";
											}
											flag = true;
										}
										num6++;
									}
								}
								bool flag29 = flag;
								if (flag29)
								{
									num5++;
									flag = false;
								}
								goto IL_121B;
							}
						}
						catch (Exception ex)
						{
							ex.Message.ToString();
							return false;
						}
						dictionary.Add(CS$<>8__locals1.list[index], array);
						dictionary2.Add(CS$<>8__locals1.list[index], rangeRegion);
					}
				}
				index2 = index;
			}
			_Worksheet worksheet = null;
			Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
			Workbooks workbooks = application.Workbooks;
			_Workbook workbook = workbooks.Add(Missing.Value);
			application.DisplayAlerts = false;
			foreach (KeyValuePair<string, object[,]> keyValuePair in dictionary)
			{
				RangeRegion rangeRegion2 = dictionary2[keyValuePair.Key];
				if (ExcelControl.<>o__4.<>p__1 == null)
				{
					ExcelControl.<>o__4.<>p__1 = CallSite<Func<CallSite, object, Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Worksheet), typeof(ExcelControl)));
				}
				Func<CallSite, object, Worksheet> target = ExcelControl.<>o__4.<>p__1.Target;
				CallSite <>p__ = ExcelControl.<>o__4.<>p__1;
				if (ExcelControl.<>o__4.<>p__0 == null)
				{
					ExcelControl.<>o__4.<>p__0 = CallSite<Func<CallSite, Sheets, object, Missing, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "Add", null, typeof(ExcelControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				worksheet = target(<>p__, ExcelControl.<>o__4.<>p__0.Target(ExcelControl.<>o__4.<>p__0, workbook.Worksheets, workbook.Worksheets[workbook.Worksheets.Count], Missing.Value, Type.Missing, Type.Missing));
				worksheet.Name = keyValuePair.Key;
				try
				{
					if (ExcelControl.<>o__4.<>p__2 == null)
					{
						ExcelControl.<>o__4.<>p__2 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
					}
					Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<>o__4.<>p__2.Target(ExcelControl.<>o__4.<>p__2, worksheet.Cells[1, 1]);
					if (ExcelControl.<>o__4.<>p__3 == null)
					{
						ExcelControl.<>o__4.<>p__3 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
					}
					Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<>o__4.<>p__3.Target(ExcelControl.<>o__4.<>p__3, worksheet.Cells[keyValuePair.Value.GetLength(0), keyValuePair.Value.GetLength(1)]);
					Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(cell, cell2);
					range.Value2 = keyValuePair.Value;
					range.Font.Name = "Arial";
					range.Font.Size = 10;
					range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
					range.Borders.Weight = XlBorderWeight.xlThin;
					range.EntireColumn.AutoFit();
					Marshal.ReleaseComObject(worksheet);
				}
				catch (Exception ex2)
				{
					workbook.Close(true, filepath, Type.Missing);
					application.Quit();
					bool flag30 = worksheet != null;
					if (flag30)
					{
						Marshal.ReleaseComObject(worksheet);
					}
					bool flag31 = workbook != null;
					if (flag31)
					{
						Marshal.ReleaseComObject(workbook);
					}
					bool flag32 = workbooks != null;
					if (flag32)
					{
						Marshal.ReleaseComObject(workbooks);
					}
					bool flag33 = application != null;
					if (flag33)
					{
						Marshal.ReleaseComObject(application);
					}
					return false;
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
			Marshal.ReleaseComObject(workbook);
			Marshal.ReleaseComObject(workbooks);
			Marshal.ReleaseComObject(application);
			return true;
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x00089ED4 File Offset: 0x000880D4
		public static bool Save2HCC(FactorySettings factorySettings, string filepath, Grid grid, bool visibleFlag, QueryMgr _queryMgr, string factory, string category)
		{
			int num = 18;
			int num2 = grid.RowsCount;
			num2 = 0;
			for (int i = 0; i < grid.Rows.Count; i++)
			{
				bool flag = grid[i, 8].Value.ToString().IndexOf("HCC") != -1;
				if (flag)
				{
					num2++;
				}
			}
			num2++;
			cConst.initContents(factorySettings, factory, "HCC");
			int num3 = 9;
			int num4 = num + num3 + cConst.listContents.Count;
			RangeRegion rangeRegion = new RangeRegion();
			object[,] array = new object[num2, num4 + 10];
			string str = string.Empty;
			try
			{
				int num5 = 0;
				array[0, 9] = "Location";
				array[0, 10] = "Board#";
				array[0, 11] = "Hardware Type";
				array[0, 12] = "Nick name";
				array[0, 13] = "Number of Site";
				array[0, 14] = "Handler Type";
				array[0, 15] = "PKG Type";
				array[0, 16] = "M/C#";
				array[0, 17] = "Lot#";
				array[0, num] = "Case";
				array[0, num + 1] = "Factor";
				array[0, num + 2] = "Hold Department";
				array[0, num + 3] = "Hold Name";
				array[0, num + 4] = "Hold Comment";
				array[0, num + 5] = "Check Item";
				array[0, num + 6] = "Requirement";
				array[0, num + 7] = "Case of the Problem";
				array[0, num + 8] = "Corrective Action";
				for (int j = 0; j < cConst.listContents.Count; j++)
				{
					array[0, num + num3 + j] = cConst.listContents[j];
				}
				for (int k = 0; k < 10; k++)
				{
					str = string.Empty;
					bool visible = grid.Columns[k].Visible;
					if (visible)
					{
						bool flag2 = num5 >= num;
						if (flag2)
						{
							break;
						}
						int num6 = 0;
						int l = 0;
						while (l < grid.RowsCount)
						{
							bool flag3 = l > 0;
							if (!flag3)
							{
								goto IL_28A;
							}
							bool flag4 = grid[l, 8].Value.ToString().IndexOf("HCC") == -1;
							if (!flag4)
							{
								str = grid[l, 1].Value.ToString();
								goto IL_28A;
							}
							IL_A8D:
							l++;
							continue;
							IL_28A:
							bool flag5 = grid[l, k].Range.Start != grid[l, k].Range.End;
							if (flag5)
							{
								rangeRegion.Add(grid[l, k].Range);
							}
							int num7 = grid[l, k].RowSpan - 1;
							int num8 = grid[l, k].ColumnSpan - 1;
							array[num6, num5] = grid[l, k].Value;
							bool flag6 = l == 0 && k == 10;
							if (flag6)
							{
								array[num6, k] = "Location";
							}
							else
							{
								bool flag7 = l > 0 && k == 10;
								if (flag7)
								{
									array[num6, num5] = "'" + grid[l, k].Value.ToString();
								}
								else
								{
									array[num6, num5] = grid[l, k].Value;
								}
							}
							bool flag8 = l > 0 && k == 2;
							if (flag8)
							{
								bool flag9 = grid[l, k].Value != null;
								if (flag9)
								{
									string text = grid[l, k - 1].Value.ToString();
									string text2 = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintReportInfo] @_Report= N'" + str + "'";
									bool flag10 = text.IndexOf("PM") != -1;
									if (flag10)
									{
										text2 += ", @_Mode=N'PMEXCEL'";
									}
									else
									{
										text2 += ", @_Mode=N'EXCEL'";
									}
									DataSet dataSet = _queryMgr.queryCall(text2);
									bool flag11 = dataSet != null;
									if (flag11)
									{
										bool flag12 = dataSet.Tables != null && dataSet.Tables.Count != 0;
										if (flag12)
										{
											bool flag13 = dataSet.Tables[0].Rows.Count != 0;
											if (flag13)
											{
												for (int m = 0; m < dataSet.Tables[0].Rows.Count; m++)
												{
													string empty = string.Empty;
													string text3 = string.Empty;
													string text4 = string.Empty;
													string text5 = string.Empty;
													string text6 = string.Empty;
													string empty2 = string.Empty;
													string empty3 = string.Empty;
													string text7 = string.Empty;
													string text8 = string.Empty;
													string text9 = string.Empty;
													string text10 = string.Empty;
													string text11 = string.Empty;
													string text12 = string.Empty;
													array[num6, 9] = dataSet.Tables[0].Rows[m]["Location"].ToString();
													array[num6, 10] = dataSet.Tables[0].Rows[m]["Board#"].ToString();
													array[num6, 11] = dataSet.Tables[0].Rows[m]["Handlertype"].ToString();
													array[num6, 12] = dataSet.Tables[0].Rows[m]["Nickname"].ToString();
													array[num6, 13] = dataSet.Tables[0].Rows[m]["Site"].ToString();
													array[num6, 14] = dataSet.Tables[0].Rows[m]["Type"].ToString();
													array[num6, 15] = dataSet.Tables[0].Rows[m]["PKGtype"].ToString();
													array[num6, 16] = dataSet.Tables[0].Rows[m]["Machine"].ToString();
													array[num6, 17] = dataSet.Tables[0].Rows[m]["Lotname"].ToString();
													array[num6, num] = dataSet.Tables[0].Rows[m]["Case"].ToString();
													array[num6, num + 1] = dataSet.Tables[0].Rows[m]["Factor"].ToString();
													text3 = dataSet.Tables[0].Rows[m]["Comment"].ToString();
													text4 = dataSet.Tables[0].Rows[m]["Corrective"].ToString();
													text5 = dataSet.Tables[0].Rows[m]["Problem"].ToString();
													text6 = dataSet.Tables[0].Rows[m]["Action"].ToString();
													text7 = dataSet.Tables[0].Rows[m]["Holdteam"].ToString();
													text8 = dataSet.Tables[0].Rows[m]["Holdname"].ToString();
													text9 = dataSet.Tables[0].Rows[m]["HoldComment"].ToString();
													text10 = dataSet.Tables[0].Rows[m]["HoldComment"].ToString();
													text11 = dataSet.Tables[0].Rows[m]["AttachmentFile"].ToString();
													text12 = dataSet.Tables[0].Rows[m]["ActionAttachmentFile"].ToString();
													array[num6, num + 2] = text7;
													array[num6, num + 3] = text8;
													array[num6, num + 4] = text9;
													for (int n = 0; n < cConst.listContents.Count; n++)
													{
														array[num6, num + num3 + n] = dataSet.Tables[0].Rows[m]["DetailConfirmation" + (n + 1).ToString()].ToString();
													}
													bool flag14 = text3.IndexOf("=") != -1;
													if (flag14)
													{
														text3 = text3.Replace("=", "'=");
													}
													array[num6, num + 5] = text3;
													bool flag15 = text4.IndexOf("=") != -1;
													if (flag15)
													{
														text4 = text4.Replace("=", "'=");
													}
													array[num6, num + 6] = text4;
													bool flag16 = text5.IndexOf("=") != -1;
													if (flag16)
													{
														text5 = text5.Replace("=", "'=");
													}
													array[num6, num + 7] = text5;
													bool flag17 = text6.IndexOf("=") != -1;
													if (flag17)
													{
														text6 = text6.Replace("=", "'=");
													}
													array[num6, num + 8] = text6;
												}
											}
										}
									}
								}
							}
							num6++;
							goto IL_A8D;
						}
						num5++;
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
			if (ExcelControl.<>o__5.<>p__0 == null)
			{
				ExcelControl.<>o__5.<>p__0 = CallSite<Func<CallSite, object, Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Worksheet), typeof(ExcelControl)));
			}
			worksheet = ExcelControl.<>o__5.<>p__0.Target(ExcelControl.<>o__5.<>p__0, workbook.Worksheets.get_Item(1));
			worksheet.Name = "Report History";
			try
			{
				if (ExcelControl.<>o__5.<>p__1 == null)
				{
					ExcelControl.<>o__5.<>p__1 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<>o__5.<>p__1.Target(ExcelControl.<>o__5.<>p__1, worksheet.Cells[1, 1]);
				if (ExcelControl.<>o__5.<>p__2 == null)
				{
					ExcelControl.<>o__5.<>p__2 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
				}
				Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<>o__5.<>p__2.Target(ExcelControl.<>o__5.<>p__2, worksheet.Cells[num2, num4]);
				Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(cell, cell2);
				range.Value2 = array;
				range.Font.Name = "Arial";
				range.Font.Size = 10;
				range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
				range.Borders.Weight = XlBorderWeight.xlThin;
				range.EntireColumn.AutoFit();
				for (int num9 = 0; num9 < rangeRegion.Count; num9++)
				{
					int num10 = rangeRegion[num9].Start.Row + 1;
					int num11 = rangeRegion[num9].Start.Column + 1;
					int num12 = rangeRegion[num9].End.Row + 1;
					int num13 = rangeRegion[num9].End.Column + 1;
					if (ExcelControl.<>o__5.<>p__4 == null)
					{
						ExcelControl.<>o__5.<>p__4 = CallSite<Action<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Merge", null, typeof(ExcelControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Action<CallSite, object, bool> target = ExcelControl.<>o__5.<>p__4.Target;
					CallSite <>p__ = ExcelControl.<>o__5.<>p__4;
					if (ExcelControl.<>o__5.<>p__3 == null)
					{
						ExcelControl.<>o__5.<>p__3 = CallSite<Func<CallSite, _Worksheet, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "get_Range", null, typeof(ExcelControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					target(<>p__, ExcelControl.<>o__5.<>p__3.Target(ExcelControl.<>o__5.<>p__3, worksheet, worksheet.Cells[num10, num11], worksheet.Cells[num12, num13]), false);
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
			catch (Exception ex2)
			{
				workbook.Close(true, filepath, Type.Missing);
				application.Quit();
				bool flag18 = worksheet != null;
				if (flag18)
				{
					Marshal.ReleaseComObject(worksheet);
				}
				bool flag19 = workbook != null;
				if (flag19)
				{
					Marshal.ReleaseComObject(workbook);
				}
				bool flag20 = workbooks != null;
				if (flag20)
				{
					Marshal.ReleaseComObject(workbooks);
				}
				bool flag21 = application != null;
				if (flag21)
				{
					Marshal.ReleaseComObject(application);
				}
				return false;
			}
			return true;
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0008AE6C File Offset: 0x0008906C
		public static bool Save(string filepath, RadGridView grid, bool visibleFlag, SortedList slList)
		{
			int num = 0;
			RangeRegion rangeRegion = new RangeRegion();
			GridDataView gridDataView = grid.MasterTemplate.DataView as GridDataView;
			bool flag = gridDataView.ItemCount == 0;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				foreach (object obj in gridDataView[0].Cells)
				{
					GridViewCellInfo gridViewCellInfo = (GridViewCellInfo)obj;
					bool isVisible = gridViewCellInfo.ColumnInfo.IsVisible;
					if (isVisible)
					{
						num++;
					}
				}
				object[,] array = new object[gridDataView.ItemCount + 1, num - 1];
				try
				{
					for (int i = 0; i < gridDataView.ItemCount; i++)
					{
						int num2 = 0;
						for (int j = 0; j < gridDataView[i].Cells.Count; j++)
						{
							bool flag2 = gridDataView[i].Cells[j].ColumnInfo.IsVisible && gridDataView[i].Cells[j].ColumnInfo.HeaderText.ToUpper() != "VIEW";
							if (flag2)
							{
								array[0, num2] = gridDataView[i].Cells[j].ColumnInfo.HeaderText;
								rangeRegion.Add(new Position(i, num));
								bool flag3 = gridDataView[i].Cells[j].Value != null;
								if (flag3)
								{
									string text = gridDataView[i].Cells[j].Value.ToString().Trim();
									bool flag4 = text.IndexOf("=") != -1;
									if (flag4)
									{
										text = text.Replace("=", "'=");
									}
									array[i + 1, num2] = text;
								}
								else
								{
									array[i + 1, num2] = "N/A";
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
				if (ExcelControl.<>o__6.<>p__0 == null)
				{
					ExcelControl.<>o__6.<>p__0 = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
				}
				worksheet = ExcelControl.<>o__6.<>p__0.Target(ExcelControl.<>o__6.<>p__0, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
				try
				{
					if (ExcelControl.<>o__6.<>p__1 == null)
					{
						ExcelControl.<>o__6.<>p__1 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
					}
					Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<>o__6.<>p__1.Target(ExcelControl.<>o__6.<>p__1, worksheet.Cells[1, 1]);
					if (ExcelControl.<>o__6.<>p__2 == null)
					{
						ExcelControl.<>o__6.<>p__2 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
					}
					Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<>o__6.<>p__2.Target(ExcelControl.<>o__6.<>p__2, worksheet.Cells[gridDataView.ItemCount + 1, num]);
					Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(cell, cell2);
					range.Value2 = array;
					range.Font.Name = "Arial";
					range.Font.Size = 10;
					range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
					range.Borders.Weight = XlBorderWeight.xlThin;
					range.EntireColumn.AutoFit();
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
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message.ToString());
					workbook.Close(true, filepath, Type.Missing);
					application.Quit();
					bool flag5 = worksheet != null;
					if (flag5)
					{
						Marshal.ReleaseComObject(worksheet);
					}
					bool flag6 = workbook != null;
					if (flag6)
					{
						Marshal.ReleaseComObject(workbook);
					}
					bool flag7 = workbooks != null;
					if (flag7)
					{
						Marshal.ReleaseComObject(workbooks);
					}
					bool flag8 = application != null;
					if (flag8)
					{
						Marshal.ReleaseComObject(application);
					}
					return false;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0008B408 File Offset: 0x00089608
		public static bool Save(string filepath, SortedList slList, bool visibleFlag)
		{
			bool flag = slList.Count == 0;
			bool result;
			if (flag)
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
								bool flag2 = grid[i, j] == null;
								if (flag2)
								{
									array[i - 1, j] = string.Empty;
								}
								else
								{
									bool flag3 = grid[i, j].Range.Start != grid[i, j].Range.End;
									if (flag3)
									{
										rangeRegion.Add(grid[i, j].Range);
									}
									int num2 = grid[i, j].RowSpan - 1;
									int num3 = grid[i, j].ColumnSpan - 1;
									array[i - 1, j] = grid[i, j].Value;
								}
							}
						}
						if (ExcelControl.<>o__7.<>p__0 == null)
						{
							ExcelControl.<>o__7.<>p__0 = CallSite<Func<CallSite, object, _Worksheet>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(_Worksheet), typeof(ExcelControl)));
						}
						worksheet = ExcelControl.<>o__7.<>p__0.Target(ExcelControl.<>o__7.<>p__0, workbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value));
						worksheet.Name = name;
						application.ActiveWindow.Zoom = 85;
						if (ExcelControl.<>o__7.<>p__1 == null)
						{
							ExcelControl.<>o__7.<>p__1 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
						}
						Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<>o__7.<>p__1.Target(ExcelControl.<>o__7.<>p__1, worksheet.Cells[1, 1]);
						if (ExcelControl.<>o__7.<>p__2 == null)
						{
							ExcelControl.<>o__7.<>p__2 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
						}
						Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<>o__7.<>p__2.Target(ExcelControl.<>o__7.<>p__2, worksheet.Cells[num, columnsCount]);
						Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(cell, cell2);
						range.Value2 = array;
						range.Font.Name = "Arial";
						range.Font.Size = 10;
						range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
						range.Borders.Weight = XlBorderWeight.xlThin;
						range.EntireColumn.AutoFit();
						for (int k = 0; k < rangeRegion.Count; k++)
						{
							int row = rangeRegion[k].Start.Row;
							int num4 = rangeRegion[k].Start.Column + 1;
							int row2 = rangeRegion[k].End.Row;
							int num5 = rangeRegion[k].End.Column + 1;
							if (ExcelControl.<>o__7.<>p__4 == null)
							{
								ExcelControl.<>o__7.<>p__4 = CallSite<Action<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Merge", null, typeof(ExcelControl), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							Action<CallSite, object, bool> target = ExcelControl.<>o__7.<>p__4.Target;
							CallSite <>p__ = ExcelControl.<>o__7.<>p__4;
							if (ExcelControl.<>o__7.<>p__3 == null)
							{
								ExcelControl.<>o__7.<>p__3 = CallSite<Func<CallSite, _Worksheet, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "get_Range", null, typeof(ExcelControl), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							target(<>p__, ExcelControl.<>o__7.<>p__3.Target(ExcelControl.<>o__7.<>p__3, worksheet, worksheet.Cells[row, num4], worksheet.Cells[row2, num5]), false);
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
					bool flag4 = worksheet != null;
					if (flag4)
					{
						Marshal.ReleaseComObject(worksheet);
					}
					bool flag5 = workbook != null;
					if (flag5)
					{
						Marshal.ReleaseComObject(workbook);
					}
					bool flag6 = workbooks != null;
					if (flag6)
					{
						Marshal.ReleaseComObject(workbooks);
					}
					bool flag7 = application != null;
					if (flag7)
					{
						Marshal.ReleaseComObject(application);
					}
					return false;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0008BA6C File Offset: 0x00089C6C
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
			if (ExcelControl.<>o__8.<>p__0 == null)
			{
				ExcelControl.<>o__8.<>p__0 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
			}
			Microsoft.Office.Interop.Excel.Range cell = ExcelControl.<>o__8.<>p__0.Target(ExcelControl.<>o__8.<>p__0, oWS.Cells[iRowIndex, iColIndex]);
			if (ExcelControl.<>o__8.<>p__1 == null)
			{
				ExcelControl.<>o__8.<>p__1 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Microsoft.Office.Interop.Excel.Range), typeof(ExcelControl)));
			}
			Microsoft.Office.Interop.Excel.Range cell2 = ExcelControl.<>o__8.<>p__1.Target(ExcelControl.<>o__8.<>p__1, oWS.Cells[num2, num3]);
			Microsoft.Office.Interop.Excel.Range range = oWS.get_Range(cell, cell2);
			range.Value2 = array;
			range.Font.Name = "Arial";
			range.Font.Size = 10;
			range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
			range.Borders.Weight = XlBorderWeight.xlThin;
			range.EntireColumn.AutoFit();
			return true;
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0008BC68 File Offset: 0x00089E68
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

		// Token: 0x060005E4 RID: 1508 RVA: 0x0008BD1C File Offset: 0x00089F1C
		private static string ExcuteSevenZip(string ReportName, string Comment)
		{
			SevenZipExtractor sevenZipExtractor = null;
			FileStream fileStream = null;
			string result;
			try
			{
				byte[] array = Convert.FromBase64String(Comment);
				fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\CSV\\download\\Problem.7z", FileMode.Create);
				fileStream.Write(array, 0, array.Length);
				fileStream.Close();
				bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
				if (is64BitOperatingSystem)
				{
					SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x64.dll");
				}
				else
				{
					SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x86.dll");
				}
				sevenZipExtractor = new SevenZipExtractor("C:\\Temp\\CimitarAdmin\\CSV\\download\\Problem.7z");
				bool flag = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\CSV\\download\\Problem.7z");
				if (flag)
				{
					sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\CSV\\download");
				}
				fileStream = null;
				bool flag2 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp_Problem.rtf");
				if (flag2)
				{
					fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp_Problem.rtf", FileMode.Open);
					array = new byte[fileStream.Length];
				}
				bool flag3 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp_Action.rtf");
				if (flag3)
				{
					fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp_Action.rtf", FileMode.Open);
					array = new byte[fileStream.Length];
				}
				bool flag4 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\CSV\\download\\TempC.rtf");
				if (flag4)
				{
					fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\CSV\\download\\TempC.rtf", FileMode.Open);
					array = new byte[fileStream.Length];
				}
				bool flag5 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp.rtf");
				if (flag5)
				{
					fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp.rtf", FileMode.Open);
					array = new byte[fileStream.Length];
				}
				bool flag6 = fileStream != null;
				if (flag6)
				{
					fileStream.Read(array, 0, array.Length);
				}
				bool flag7 = fileStream != null;
				if (flag7)
				{
					fileStream.Close();
					RichTextBox richTextBox = new RichTextBox();
					richTextBox.Rtf = Encoding.ASCII.GetString(array);
					string text = richTextBox.Text.Trim();
					richTextBox.Dispose();
					File.Delete("C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp_Problem.rtf");
					File.Delete("C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp_Action.rtf");
					File.Delete("C:\\Temp\\CimitarAdmin\\CSV\\download\\TempC.rtf");
					File.Delete("C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp.rtf");
					result = text;
				}
				else
				{
					result = null;
				}
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZip", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\Class\\ExcelControl.cs", 1688);
				result = string.Empty;
			}
			finally
			{
				bool flag8 = sevenZipExtractor != null;
				if (flag8)
				{
					sevenZipExtractor.Dispose();
				}
				bool flag9 = fileStream != null;
				if (flag9)
				{
					fileStream.Dispose();
				}
			}
			return result;
		}
	}
}
