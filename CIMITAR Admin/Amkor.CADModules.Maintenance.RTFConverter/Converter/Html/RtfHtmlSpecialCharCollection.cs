using System;
using System.Collections.Generic;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000B3 RID: 179
	public class RtfHtmlSpecialCharCollection : Dictionary<RtfVisualSpecialCharKind, string>
	{
		// Token: 0x0600062E RID: 1582 RVA: 0x00013F28 File Offset: 0x00012128
		public RtfHtmlSpecialCharCollection()
		{
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x00013F32 File Offset: 0x00012132
		public RtfHtmlSpecialCharCollection(string settings)
		{
			this.LoadSettings(settings);
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x00013F44 File Offset: 0x00012144
		public void LoadSettings(string settings)
		{
			base.Clear();
			bool flag = string.IsNullOrEmpty(settings);
			if (!flag)
			{
				string[] array = settings.Split(new char[]
				{
					','
				});
				foreach (string text in array)
				{
					string[] array3 = text.Split(new char[]
					{
						'='
					});
					bool flag2 = array3.Length != 2;
					if (!flag2)
					{
						RtfVisualSpecialCharKind key = (RtfVisualSpecialCharKind)Enum.Parse(typeof(RtfVisualSpecialCharKind), array3[0]);
						base.Add(key, array3[1]);
					}
				}
			}
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x00013FE0 File Offset: 0x000121E0
		public string GetSettings()
		{
			bool flag = base.Count == 0;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (RtfVisualSpecialCharKind rtfVisualSpecialCharKind in base.Keys)
				{
					bool flag2 = stringBuilder.Length > 0;
					if (flag2)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(Enum.GetName(typeof(RtfVisualSpecialCharKind), rtfVisualSpecialCharKind));
					stringBuilder.Append('=');
					stringBuilder.Append(base[rtfVisualSpecialCharKind]);
				}
				result = stringBuilder.ToString();
			}
			return result;
		}
	}
}
