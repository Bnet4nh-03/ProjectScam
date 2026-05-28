using System;
using System.Collections;
using System.Text;
using System.Xml;
using ATDFW.Compenents.XMLData;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000009 RID: 9
	public class RuleSBLItem
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00003920 File Offset: 0x00001B20
		public void insertSBLS(string xmlstr)
		{
			if (this._sbls != null)
			{
				this._sbls.Clear();
				this._sbls = null;
			}
			this._sbls = new SortedList();
			if (xmlstr != "")
			{
				XMLManager xmlmanager = new XMLManager(xmlstr);
				XmlNode xmlNode = xmlmanager.FindSingleNode("SBINS");
				int num = 1;
				foreach (object obj in xmlNode.ChildNodes)
				{
					XmlNode xmlNode2 = (XmlNode)obj;
					SBLItem sblitem = new SBLItem();
					sblitem._no = num;
					if (xmlNode2.Attributes["no"] != null)
					{
						sblitem._binno = xmlNode2.Attributes["no"].Value;
					}
					if (xmlNode2.Attributes["climit"] != null)
					{
						sblitem._climit = Convert.ToInt32(xmlNode2.Attributes["climit"].Value);
					}
					if (xmlNode2.Attributes["cnlimit"] != null)
					{
						sblitem._cnlimit = Convert.ToInt32(xmlNode2.Attributes["cnlimit"].Value);
					}
					if (xmlNode2.Attributes["slimit"] != null)
					{
						sblitem._slimit = Convert.ToDouble(xmlNode2.Attributes["slimit"].Value);
					}
					if (xmlNode2.Attributes["plimit"] != null)
					{
						sblitem._plimit = Convert.ToDouble(xmlNode2.Attributes["plimit"].Value);
					}
					if (xmlNode2.Attributes["bslimit"] != null)
					{
						sblitem._bslimit = Convert.ToDouble(xmlNode2.Attributes["bslimit"].Value);
					}
					if (xmlNode2.Attributes["aclimit"] != null)
					{
						sblitem._aclimit = Convert.ToInt32(xmlNode2.Attributes["aclimit"].Value);
					}
					if (xmlNode2.Attributes["acnlimit"] != null)
					{
						sblitem._acnlimit = Convert.ToInt32(xmlNode2.Attributes["acnlimit"].Value);
					}
					if (xmlNode2.Attributes["aslimit"] != null)
					{
						sblitem._aslimit = Convert.ToDouble(xmlNode2.Attributes["aslimit"].Value);
					}
					if (xmlNode2.Attributes["aplimit"] != null)
					{
						sblitem._aplimit = Convert.ToDouble(xmlNode2.Attributes["aplimit"].Value);
					}
					if (xmlNode2.Attributes["abslimit"] != null)
					{
						sblitem._abslimit = Convert.ToDouble(xmlNode2.Attributes["abslimit"].Value);
					}
					if (xmlNode2.Attributes["basecount"] != null)
					{
						sblitem._basecount = Convert.ToInt32(xmlNode2.Attributes["basecount"].Value);
					}
					if (xmlNode2.Attributes["basepercent"] != null)
					{
						sblitem._basepercent = Convert.ToDouble(xmlNode2.Attributes["basepercent"].Value);
					}
					if (xmlNode2.Attributes["basesitecount"] != null)
					{
						sblitem._basecountsite = Convert.ToInt32(xmlNode2.Attributes["basesitecount"].Value);
					}
					if (xmlNode2.Attributes["ispass"] != null)
					{
						sblitem._ispass = Convert.ToInt32(xmlNode2.Attributes["ispass"].Value);
					}
					if (xmlNode2.Attributes["fwaferid"] != null)
					{
						sblitem._fwaferid = Convert.ToInt32(xmlNode2.Attributes["fwaferid"].Value);
					}
					if (xmlNode2.Attributes["opt"] != null)
					{
						sblitem._opt = xmlNode2.Attributes["opt"].Value;
					}
					if (xmlNode2.Attributes["fstatusid"] != null)
					{
						sblitem._fstatusid = xmlNode2.Attributes["fstatusid"].Value;
					}
					this._sbls.Add(sblitem._no, sblitem);
					num++;
				}
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003D88 File Offset: 0x00001F88
		public string makeXMLString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (this._sbls != null)
			{
				stringBuilder.AppendLine("<SBINS>");
				foreach (object obj in this._sbls)
				{
					SBLItem sblitem = (SBLItem)((DictionaryEntry)obj).Value;
					stringBuilder.Append(sblitem.MakeXMLString());
				}
				stringBuilder.AppendLine("</SBINS>");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003E24 File Offset: 0x00002024
		public RuleSBLItem ClonRuleSBLItem()
		{
			RuleSBLItem ruleSBLItem = new RuleSBLItem();
			ruleSBLItem._ruleID = this._ruleID;
			ruleSBLItem._typecode = this._typecode;
			ruleSBLItem._actioncode = this._actioncode;
			ruleSBLItem._userID = this._userID;
			ruleSBLItem._skey = this._skey;
			ruleSBLItem._skeysub1 = this._skeysub1;
			ruleSBLItem.insertSBLS(this.makeXMLString());
			ruleSBLItem._mailaddr = this._mailaddr;
			ruleSBLItem._active = this._active;
			ruleSBLItem._comment = this._comment;
			return ruleSBLItem;
		}

		// Token: 0x0400002B RID: 43
		public int _ruleID;

		// Token: 0x0400002C RID: 44
		public int _typecode;

		// Token: 0x0400002D RID: 45
		public int _actioncode;

		// Token: 0x0400002E RID: 46
		public string _userID;

		// Token: 0x0400002F RID: 47
		public string _skey;

		// Token: 0x04000030 RID: 48
		public string _skeysub1;

		// Token: 0x04000031 RID: 49
		public SortedList _sbls;

		// Token: 0x04000032 RID: 50
		public string _mailaddr;

		// Token: 0x04000033 RID: 51
		public int _active;

		// Token: 0x04000034 RID: 52
		public string _comment;
	}
}
