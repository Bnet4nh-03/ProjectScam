using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using Amkor.CADModules.DcolSummaryView.Controls;

namespace Amkor.CADModules.DcolSummaryView.CommonClass
{
	// Token: 0x02000003 RID: 3
	public class CSVControl
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000040CC File Offset: 0x000022CC
		public static void BarPrograssView()
		{
			CSVControl._barPrograss.ShowDialog();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000040DC File Offset: 0x000022DC
		public static bool generateCSV(string filename, DataTable dt)
		{
			bool result = false;
			try
			{
				CSVControl._barPrograss = new BarPrograss();
				CSVControl._barPrograss.progress_labelheader_set("Save Data....");
				CSVControl._barPrograss.setValue(0);
				CSVControl._thread = new Thread(new ThreadStart(CSVControl.BarPrograssView));
				CSVControl._thread.Start();
				if (dt != null)
				{
					CSVControl._barPrograss.setMax(dt.Rows.Count);
					StreamWriter streamWriter = new StreamWriter(filename, false, Encoding.Default);
					foreach (object obj in dt.Columns)
					{
						DataColumn dataColumn = (DataColumn)obj;
						streamWriter.Write(dataColumn.ColumnName);
						streamWriter.Write(",");
					}
					streamWriter.WriteLine();
					int num = 1;
					CSVControl._barPrograss.progress_labelheader_set("Create csv file....");
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
						CSVControl._barPrograss.setValue(num);
						num++;
					}
					streamWriter.Close();
				}
				Thread.Sleep(100);
				if (CSVControl._barPrograss != null)
				{
					CSVControl._barPrograss._ischeck = true;
				}
				CSVControl._barPrograss = null;
				result = true;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (CSVControl._barPrograss != null)
				{
					CSVControl._barPrograss._ischeck = true;
				}
				CSVControl._barPrograss = null;
				return false;
			}
			return result;
		}

		// Token: 0x0400001D RID: 29
		private static BarPrograss _barPrograss = new BarPrograss();

		// Token: 0x0400001E RID: 30
		private static Thread _thread;
	}
}
