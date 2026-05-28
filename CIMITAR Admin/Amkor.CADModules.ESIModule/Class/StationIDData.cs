using System;
using System.Collections;

namespace Amkor.CADModules.ESIModule.Class
{
	// Token: 0x02000016 RID: 22
	public class StationIDData
	{
		// Token: 0x0600001D RID: 29 RVA: 0x000028C4 File Offset: 0x00000AC4
		public string setStationID_Number()
		{
			string result = string.Empty;
			try
			{
				if (this.StationID != string.Empty)
				{
					string[] array = this.StationID.Split(new char[]
					{
						'_'
					});
					if (array.Length > 2)
					{
						result = array[2];
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return result;
		}

		// Token: 0x040000B5 RID: 181
		public string StationID = string.Empty;

		// Token: 0x040000B6 RID: 182
		public string StationID_Number = string.Empty;

		// Token: 0x040000B7 RID: 183
		public SortedList slLot = new SortedList();
	}
}
