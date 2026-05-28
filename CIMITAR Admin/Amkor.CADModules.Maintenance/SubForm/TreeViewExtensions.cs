using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x02000010 RID: 16
	public static class TreeViewExtensions
	{
		// Token: 0x0600013E RID: 318
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref TreeViewExtensions.TVITEM lParam);

		// Token: 0x0600013F RID: 319 RVA: 0x0003E3B8 File Offset: 0x0003C5B8
		public static void HideCheckBox(this TreeNode node)
		{
			TreeViewExtensions.TVITEM tvitem = default(TreeViewExtensions.TVITEM);
			tvitem.hItem = node.Handle;
			tvitem.mask = 8;
			tvitem.stateMask = 61440;
			tvitem.state = 0;
			TreeViewExtensions.SendMessage(node.TreeView.Handle, 4415, IntPtr.Zero, ref tvitem);
		}

		// Token: 0x040002B1 RID: 689
		private const int TVIF_STATE = 8;

		// Token: 0x040002B2 RID: 690
		private const int TVIS_STATEIMAGEMASK = 61440;

		// Token: 0x040002B3 RID: 691
		private const int TV_FIRST = 4352;

		// Token: 0x040002B4 RID: 692
		private const int TVM_SETITEM = 4415;

		// Token: 0x02000082 RID: 130
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 8)]
		private struct TVITEM
		{
			// Token: 0x040007DB RID: 2011
			public int mask;

			// Token: 0x040007DC RID: 2012
			public IntPtr hItem;

			// Token: 0x040007DD RID: 2013
			public int state;

			// Token: 0x040007DE RID: 2014
			public int stateMask;

			// Token: 0x040007DF RID: 2015
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszText;

			// Token: 0x040007E0 RID: 2016
			public int cchTextMax;

			// Token: 0x040007E1 RID: 2017
			public int iImage;

			// Token: 0x040007E2 RID: 2018
			public int iSelectedImage;

			// Token: 0x040007E3 RID: 2019
			public int cChildren;

			// Token: 0x040007E4 RID: 2020
			public IntPtr lParam;
		}
	}
}
