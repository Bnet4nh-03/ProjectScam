using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Amkor.CADModules.UnitDataProcModule.CommonClass;

namespace Amkor.CADModules.UnitDataProcModule.DataClass
{
	// Token: 0x02000011 RID: 17
	public class cMainData
	{
		// Token: 0x06000066 RID: 102 RVA: 0x0000D33C File Offset: 0x0000B53C
		public cMainData()
		{
			this.sCustomerCode = string.Empty;
			this.sDevice = string.Empty;
			this.sOperation = string.Empty;
			this.sDateType = string.Empty;
			this.sSearchType = string.Empty;
			this.slItem = new SortedList();
			this.slLot = new SortedList();
			this.slChk_Lot = new SortedList();
			this.dtDevice = new DataTable("DEVICE");
			this.dtLot = new DataTable("LOT");
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000D464 File Offset: 0x0000B664
		public void clearData()
		{
			this.sCustomerCode = string.Empty;
			this.sDevice = string.Empty;
			this.sOperation = string.Empty;
			this.sDateType = string.Empty;
			this.chkProcessID = string.Empty;
			this.slItem.Clear();
			this.slLot.Clear();
			this.slChk_Lot.Clear();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000D4C9 File Offset: 0x0000B6C9
		public void clearDevice()
		{
			this.clearData();
			this.dtDevice = new DataTable();
			this.dtLot = new DataTable();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000D4E7 File Offset: 0x0000B6E7
		public void clearLot()
		{
			this.clearData();
			this.dtLot = new DataTable();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000D4FC File Offset: 0x0000B6FC
		public void setChkLot()
		{
			string filterExpression = "[check] = true";
			string text = "processid";
			DataRow[] array = this.dtLot.Select(filterExpression);
			int num = array.Length;
			DataTable dataTable = this.dtLot.Select(filterExpression).CopyToDataTable<DataRow>();
			DataTable dataTable2 = dataTable.DefaultView.ToTable(true, new string[]
			{
				text
			});
			this.slChk_Lot.Clear();
			this.chkProcessID = string.Empty;
			foreach (object obj in dataTable2.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				this.slChk_Lot.Add(dataRow["processid"].ToString(), dataRow["processid"].ToString());
				this.chkProcessID = this.chkProcessID + dataRow["processid"].ToString() + ",";
			}
			if (this.chkProcessID != string.Empty)
			{
				this.chkProcessID = this.chkProcessID.Substring(0, this.chkProcessID.Length - 1);
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000D640 File Offset: 0x0000B840
		public void setChkLotList()
		{
			string filterExpression = "[check] = true";
			string text = "processid";
			this.dtLot.Select(filterExpression);
			DataTable dataTable = this.dtLot.Select(filterExpression).CopyToDataTable<DataRow>();
			DataTable dataTable2 = dataTable.DefaultView.ToTable(true, new string[]
			{
				text
			});
			this.slChk_Lot.Clear();
			this.chkProcessID = string.Empty;
			foreach (object obj in dataTable2.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				this.slChk_Lot.Add(dataRow["processid"].ToString(), dataRow["processid"].ToString());
				this.chkProcessID = this.chkProcessID + dataRow["processid"].ToString() + ",";
			}
			if (this.chkProcessID != string.Empty)
			{
				this.chkProcessID = this.chkProcessID.Substring(0, this.chkProcessID.Length - 1);
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000D77C File Offset: 0x0000B97C
		public bool checkLot()
		{
			this.drsLot = null;
			this.slChk_Lot.Clear();
			this.chkProcessID = string.Empty;
			if (this.dtLot.Rows.Count == 0)
			{
				return false;
			}
			this.drsLot = this.dtLot.Select(this.sExpression);
			if (this.drsLot.Length == 0)
			{
				return false;
			}
			for (int i = 0; i < this.drsLot.Length; i++)
			{
				this.slChk_Lot.Add(this.drsLot[i]["lotid"].ToString(), this.drsLot[i]["lotid"].ToString());
				this.chkProcessID = this.chkProcessID + this.drsLot[i]["lotid"].ToString() + ",";
			}
			if (this.chkProcessID != string.Empty)
			{
				this.chkProcessID = this.chkProcessID.Substring(0, this.chkProcessID.Length - 1);
			}
			return true;
		}

		// Token: 0x040000D8 RID: 216
		public CommonQuery _CommonQry = new CommonQuery();

		// Token: 0x040000D9 RID: 217
		public string sLot = string.Empty;

		// Token: 0x040000DA RID: 218
		public string sDcc = string.Empty;

		// Token: 0x040000DB RID: 219
		public string sCustomerCode = string.Empty;

		// Token: 0x040000DC RID: 220
		public string sDevice = string.Empty;

		// Token: 0x040000DD RID: 221
		public string sOperation = string.Empty;

		// Token: 0x040000DE RID: 222
		public string sTester = string.Empty;

		// Token: 0x040000DF RID: 223
		public string sDateType = string.Empty;

		// Token: 0x040000E0 RID: 224
		public DateTime sDate_Start;

		// Token: 0x040000E1 RID: 225
		public DateTime sDate_End;

		// Token: 0x040000E2 RID: 226
		public SortedList slItem;

		// Token: 0x040000E3 RID: 227
		public SortedList slLot;

		// Token: 0x040000E4 RID: 228
		public SortedList slChk_Lot;

		// Token: 0x040000E5 RID: 229
		public DataTable dtDevice;

		// Token: 0x040000E6 RID: 230
		public DataTable dtLot;

		// Token: 0x040000E7 RID: 231
		public DataRow[] drsLot;

		// Token: 0x040000E8 RID: 232
		public string chkProcessID = string.Empty;

		// Token: 0x040000E9 RID: 233
		public string sSearchType = string.Empty;

		// Token: 0x040000EA RID: 234
		public SortedList slSearchSN = new SortedList();

		// Token: 0x040000EB RID: 235
		public string sInputData = string.Empty;

		// Token: 0x040000EC RID: 236
		public List<string> lInputData = new List<string>();

		// Token: 0x040000ED RID: 237
		public bool bNewDocFlag;

		// Token: 0x040000EE RID: 238
		public int iSelectedTabIndex;

		// Token: 0x040000EF RID: 239
		private string sExpression = "[Check] = true";
	}
}
