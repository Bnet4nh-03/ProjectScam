using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Amkor.CADModules.BoardCenterClient.Properties
{
	// Token: 0x02000007 RID: 7
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600003E RID: 62 RVA: 0x0000681F File Offset: 0x00004A1F
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00006827 File Offset: 0x00004A27
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Amkor.CADModules.BoardCenterClient.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00006853 File Offset: 0x00004A53
		// (set) Token: 0x06000041 RID: 65 RVA: 0x0000685A File Offset: 0x00004A5A
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00006862 File Offset: 0x00004A62
		internal static Bitmap SaveExcel
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("SaveExcel", Resources.resourceCulture);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000043 RID: 67 RVA: 0x0000687D File Offset: 0x00004A7D
		internal static Bitmap SaveExcel_Down
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("SaveExcel_Down", Resources.resourceCulture);
			}
		}

		// Token: 0x0400006D RID: 109
		private static ResourceManager resourceMan;

		// Token: 0x0400006E RID: 110
		private static CultureInfo resourceCulture;
	}
}
