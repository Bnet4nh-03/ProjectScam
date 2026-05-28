using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SourceGrid;

namespace CommonLibrary
{
	// Token: 0x02000004 RID: 4
	internal class CSVControl
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000036D4 File Offset: 0x000018D4
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

		// Token: 0x06000012 RID: 18 RVA: 0x00003830 File Offset: 0x00001A30
		public bool generateCSV(string filename, Grid grid)
		{
			StreamWriter streamWriter = null;
			bool result;
			try
			{
				streamWriter = new StreamWriter(filename, false, Encoding.Default);
				for (int i = 0; i < grid.Rows.Count; i++)
				{
					int num = 0;
					while (num < grid.Columns.Count && bool.Parse(grid.Columns[num].Tag.ToString()))
					{
						if (i == 0)
						{
							string value = grid[i, num].ToString();
							streamWriter.Write(value);
							streamWriter.Write(",");
						}
						else
						{
							string text = grid[i, num].ToString().Replace('\n', ' ');
							text = text.Replace(',', ' ');
							streamWriter.Write(text);
							streamWriter.Write(",");
						}
						num++;
					}
					streamWriter.WriteLine();
				}
				streamWriter.Close();
				result = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				if (streamWriter != null)
				{
					streamWriter.Close();
				}
				MessageBox.Show(ex.Message);
				result = false;
			}
			return result;
		}
	}
}
