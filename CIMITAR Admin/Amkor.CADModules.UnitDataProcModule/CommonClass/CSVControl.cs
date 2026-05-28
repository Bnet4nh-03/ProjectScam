using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using Amkor.CADModules.UnitDataProcModule.Controls;

namespace Amkor.CADModules.UnitDataProcModule.CommonClass
{
	// Token: 0x02000003 RID: 3
	public class CSVControl
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00006BE7 File Offset: 0x00004DE7
		public static void BarPrograssView()
		{
			CSVControl._barPrograss.ShowDialog();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00006BF4 File Offset: 0x00004DF4
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

		// Token: 0x0400002F RID: 47
		private static BarPrograss _barPrograss = new BarPrograss();

		// Token: 0x04000030 RID: 48
		private static Thread _thread;
	}
}
