using System;
using System.IO;
using System.Net;
using ATDFW.Base.FrameWork;
using ATDFW.Compenents.EncryptionData;

namespace Amkor.CADModules.ManufactureHistory.Class
{
	// Token: 0x02000002 RID: 2
	public class CIMitarLogin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static int Login(string id, string pwd)
		{
			string str = EncryptionManager.BaseEncryption(pwd);
			string str2 = "http://cim_service.amkor.co.kr:8080/ysj/cimitar/get_user_info_0328/";
			string text = str2 + id + "," + str;
			if (SolutionReflector.ServerAvailable(text))
			{
				HttpWebRequest httpWebRequest = WebRequest.Create(text) as HttpWebRequest;
				using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
				{
					StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
					string text2 = streamReader.ReadLine();
					if (text2.CompareTo("Error : Invalid ID") == 0)
					{
						return 1;
					}
					if (text2.CompareTo("Error : Password incorrect") == 0)
					{
						return 2;
					}
					if (text2.ToUpper().StartsWith("USERID"))
					{
						text2 = streamReader.ReadLine();
						if (text2.ToUpper().StartsWith(id.ToUpper()))
						{
							return 0;
						}
					}
					else if (text2.CompareTo("Error : DB transaction exception") != 0)
					{
						return 3;
					}
				}
			}
			return 3;
		}

		// Token: 0x04000001 RID: 1
		public static string _id = string.Empty;
	}
}
