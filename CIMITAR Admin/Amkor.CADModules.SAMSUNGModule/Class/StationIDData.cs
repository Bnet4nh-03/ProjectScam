using System;
using System.Collections;

namespace Amkor.CADModules.SAMSUNGModule.Class
{
	// Token: 0x02000011 RID: 17
	public class StationIDData
	{
		// Token: 0x06000018 RID: 24 RVA: 0x0000287C File Offset: 0x00000A7C
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

		// Token: 0x04000075 RID: 117
		public string StationID = string.Empty;

		// Token: 0x04000076 RID: 118
		public string StationID_Number = string.Empty;

		// Token: 0x04000077 RID: 119
		public SortedList slLot = new SortedList();
	}
}
