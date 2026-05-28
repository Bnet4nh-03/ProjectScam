using System;
using System.IO;
using System.Net;
using ATDFW.Base.FrameWork;
using ATDFW.Compenents.EncryptionData;

namespace Amkor.CADModules.Maintenance.Class
{
	// Token: 0x02000054 RID: 84
	public class CIMitarLogin
	{
		// Token: 0x060005D7 RID: 1495 RVA: 0x00086E68 File Offset: 0x00085068
		public static int Login(string id, string pwd)
		{
			string str = EncryptionManager.BaseEncryption(pwd);
			string str2 = "http://cim_service.amkor.co.kr:8080/ysj/cimitar/get_user_info_0328/";
			string text = str2 + id + "," + str;
			bool flag = SolutionReflector.ServerAvailable(text);
			if (flag)
			{
				HttpWebRequest httpWebRequest = WebRequest.Create(text) as HttpWebRequest;
				using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
				{
					StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
					string text2 = streamReader.ReadLine();
					bool flag2 = text2.CompareTo("Error : Invalid ID") == 0;
					if (flag2)
					{
						return 1;
					}
					bool flag3 = text2.CompareTo("Error : Password incorrect") == 0;
					if (flag3)
					{
						return 2;
					}
					bool flag4 = text2.ToUpper().StartsWith("USERID");
					if (flag4)
					{
						text2 = streamReader.ReadLine();
						bool flag5 = text2.ToUpper().StartsWith(id.ToUpper());
						if (flag5)
						{
							return 0;
						}
					}
					else
					{
						bool flag6 = text2.CompareTo("Error : DB transaction exception") == 0;
						if (!flag6)
						{
							return 3;
						}
					}
				}
			}
			return 3;
		}

		// Token: 0x04000731 RID: 1841
		public static string _id = string.Empty;
	}
}
