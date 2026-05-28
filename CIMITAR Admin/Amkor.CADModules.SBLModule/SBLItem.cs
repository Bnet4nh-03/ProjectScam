using System;
using System.Text;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x0200000A RID: 10
	public class SBLItem
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00003EB8 File Offset: 0x000020B8
		public SBLItem ClonSBLItem()
		{
			return new SBLItem
			{
				_no = this._no,
				_binno = this._binno,
				_climit = this._climit,
				_cnlimit = this._cnlimit,
				_slimit = this._slimit,
				_plimit = this._plimit,
				_bslimit = this._bslimit,
				_aclimit = this._aclimit,
				_acnlimit = this._acnlimit,
				_aslimit = this._aslimit,
				_aplimit = this._aplimit,
				_abslimit = this._abslimit,
				_basecount = this._basecount,
				_basepercent = this._basepercent,
				_basecountsite = this._basecountsite,
				_ispass = this._ispass,
				_fwaferid = this._fwaferid,
				_opt = this._opt,
				_fstatusid = this._fstatusid
			};
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003FB0 File Offset: 0x000021B0
		public string MakeXMLString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("<SBIN no=\"{0}\"", this._binno);
			stringBuilder.AppendFormat(" plimit=\"{0}\" climit=\"{1}\" slimit=\"{2}\" cnlimit=\"{3}\" bslimit=\"{4}\"", new object[]
			{
				this._plimit,
				this._climit,
				this._slimit,
				this._cnlimit,
				this._bslimit
			});
			stringBuilder.AppendFormat(" aplimit=\"{0}\" aclimit=\"{1}\" aslimit=\"{2}\" acnlimit=\"{3}\" abslimit=\"{4}\"", new object[]
			{
				this._aplimit,
				this._aclimit,
				this._aslimit,
				this._acnlimit,
				this._abslimit
			});
			stringBuilder.AppendFormat(" basecount=\"{0}\" basesitecount=\"{1}\" basepercent=\"{2}\" ispass=\"{3}\" fwaferid=\"{4}\"", new object[]
			{
				this._basecount,
				this._basecountsite,
				this._basepercent,
				this._ispass,
				this._fwaferid
			});
			stringBuilder.AppendFormat(" opt=\"{0}\" fstatusid=\"{1}\"/>", this._opt, this._fstatusid);
			stringBuilder.AppendLine();
			return stringBuilder.ToString();
		}

		// Token: 0x04000035 RID: 53
		public int _no;

		// Token: 0x04000036 RID: 54
		public string _binno = "";

		// Token: 0x04000037 RID: 55
		public int _climit = -1;

		// Token: 0x04000038 RID: 56
		public int _cnlimit = -1;

		// Token: 0x04000039 RID: 57
		public double _slimit = -1.0;

		// Token: 0x0400003A RID: 58
		public double _plimit = -1.0;

		// Token: 0x0400003B RID: 59
		public double _bslimit = -1.0;

		// Token: 0x0400003C RID: 60
		public int _aclimit = -1;

		// Token: 0x0400003D RID: 61
		public int _acnlimit = -1;

		// Token: 0x0400003E RID: 62
		public double _aslimit = -1.0;

		// Token: 0x0400003F RID: 63
		public double _aplimit = -1.0;

		// Token: 0x04000040 RID: 64
		public double _abslimit = -1.0;

		// Token: 0x04000041 RID: 65
		public int _basecount = -1;

		// Token: 0x04000042 RID: 66
		public double _basepercent = -1.0;

		// Token: 0x04000043 RID: 67
		public int _basecountsite = -1;

		// Token: 0x04000044 RID: 68
		public int _ispass;

		// Token: 0x04000045 RID: 69
		public int _fwaferid;

		// Token: 0x04000046 RID: 70
		public string _opt = "0";

		// Token: 0x04000047 RID: 71
		public string _fstatusid = "0";
	}
}
