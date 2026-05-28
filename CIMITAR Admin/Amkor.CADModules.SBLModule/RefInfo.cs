using System;
using System.Collections;
using System.Xml;
using ATDFW.Compenents.XMLData;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000006 RID: 6
	public class RefInfo
	{
		// Token: 0x0600001B RID: 27 RVA: 0x00003710 File Offset: 0x00001910
		public void MakeDeviceList()
		{
			if (this.DeviceXML != null)
			{
				XmlNode xmlNode = this.DeviceXML.FindSingleNode("DEVICES");
				if (xmlNode != null)
				{
					int num = 1;
					this.al_Device = new ArrayList();
					foreach (object obj in xmlNode.ChildNodes)
					{
						XmlNode xmlNode2 = (XmlNode)obj;
						DeviceList deviceList = new DeviceList();
						deviceList.no = num;
						deviceList.Devicename = xmlNode2.Attributes["name"].Value;
						deviceList.customername = xmlNode2.Attributes["cname"].Value;
						deviceList.customerID = xmlNode2.Attributes["ccode"].Value;
						this.al_Device.Add(deviceList);
						num++;
					}
				}
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000380C File Offset: 0x00001A0C
		public void MakeNickList()
		{
			if (this.NICKXML != null)
			{
				XmlNode xmlNode = this.NICKXML.FindSingleNode("NICKS");
				if (xmlNode != null)
				{
					int num = 1;
					this.al_Nick = new ArrayList();
					foreach (object obj in xmlNode.ChildNodes)
					{
						XmlNode xmlNode2 = (XmlNode)obj;
						NickList nickList = new NickList();
						nickList.no = num;
						nickList.NICK = xmlNode2.Attributes["name"].Value;
						nickList.customername = xmlNode2.Attributes["cname"].Value;
						nickList.customerID = xmlNode2.Attributes["ccode"].Value;
						this.al_Nick.Add(nickList);
						num++;
					}
				}
			}
		}

		// Token: 0x04000021 RID: 33
		public XMLManager DeviceXML;

		// Token: 0x04000022 RID: 34
		public XMLManager NICKXML;

		// Token: 0x04000023 RID: 35
		public ArrayList al_Device;

		// Token: 0x04000024 RID: 36
		public ArrayList al_Nick;

		// Token: 0x04000025 RID: 37
		public ArrayList al_Operation;

		// Token: 0x04000026 RID: 38
		public ArrayList al_StatusID;
	}
}
