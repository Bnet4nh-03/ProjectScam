using System;
using System.Data;
using SourceGrid;

namespace CommonLibrary
{
	// Token: 0x02000011 RID: 17
	internal class CParsingGrid
	{
		// Token: 0x06000089 RID: 137 RVA: 0x00008310 File Offset: 0x00006510
		public DataTable ParseGrid(Grid grid)
		{
			DataTable dataTable = new DataTable();
			string text = string.Empty;
			for (int i = 1; i < grid.Columns.Count; i++)
			{
				for (int j = 0; j < grid.Rows.Count; j++)
				{
					if (j == 0)
					{
						if (grid[j, i].Value != null)
						{
							text = grid[j, i].Value.ToString();
						}
						if (!dataTable.Columns.Contains(text))
						{
							dataTable.Columns.Add(text);
						}
					}
					else
					{
						if (dataTable.Rows.Count < j)
						{
							dataTable.Rows.Add(Array.Empty<object>());
						}
						string value = string.Empty;
						if (grid[j, i].Value != null)
						{
							value = grid[j, i].Value.ToString();
						}
						if (grid[j, i].Image != null)
						{
							value = "1";
						}
						dataTable.Rows[j - 1][text] = value;
					}
				}
			}
			return dataTable;
		}
	}
}
