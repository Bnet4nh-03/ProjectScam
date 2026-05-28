using System;
using System.Data;
using System.IO;
using System.Text;

namespace Amkor.CADModules.HccSTReportModule.Class
{
	// Token: 0x02000030 RID: 48
	internal class CSVControl
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x0001BC58 File Offset: 0x00019E58
		public bool generateCSV(string filename, DataTable dt)
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
	}
}
