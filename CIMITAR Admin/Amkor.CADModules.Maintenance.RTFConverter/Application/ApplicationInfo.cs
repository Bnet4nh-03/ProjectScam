using System;
using System.Globalization;
using System.Reflection;

namespace Amkor.CADModules.Maintenance.RTFConverter.Application
{
	// Token: 0x0200005F RID: 95
	public static class ApplicationInfo
	{
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600028A RID: 650 RVA: 0x000066C8 File Offset: 0x000048C8
		public static Version Version
		{
			get
			{
				Assembly entryAssembly = Assembly.GetEntryAssembly();
				bool flag = entryAssembly == null;
				Version result;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = entryAssembly.GetName().Version;
				}
				return result;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600028B RID: 651 RVA: 0x000066FC File Offset: 0x000048FC
		public static string VersionName
		{
			get
			{
				Version version = ApplicationInfo.Version;
				bool flag = version == null;
				string result;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = version.ToString();
				}
				return result;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600028C RID: 652 RVA: 0x0000672C File Offset: 0x0000492C
		public static string ShortVersionName
		{
			get
			{
				Version version = ApplicationInfo.Version;
				bool flag = version == null;
				string result;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = version.Major.ToString(CultureInfo.InvariantCulture) + "." + version.Minor.ToString(CultureInfo.InvariantCulture);
				}
				return result;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600028D RID: 653 RVA: 0x00006784 File Offset: 0x00004984
		public static string Title
		{
			get
			{
				string result = null;
				Assembly entryAssembly = Assembly.GetEntryAssembly();
				AssemblyTitleAttribute[] array = entryAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false) as AssemblyTitleAttribute[];
				bool flag = array != null && array.Length == 1;
				if (flag)
				{
					result = array[0].Title;
				}
				return result;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600028E RID: 654 RVA: 0x000067D4 File Offset: 0x000049D4
		public static string Copyright
		{
			get
			{
				string result = null;
				Assembly entryAssembly = Assembly.GetEntryAssembly();
				AssemblyCopyrightAttribute[] array = entryAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false) as AssemblyCopyrightAttribute[];
				bool flag = array != null && array.Length == 1;
				if (flag)
				{
					result = array[0].Copyright;
				}
				return result;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600028F RID: 655 RVA: 0x00006824 File Offset: 0x00004A24
		public static string Caption
		{
			get
			{
				return ApplicationInfo.Title + " " + ApplicationInfo.VersionName;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000290 RID: 656 RVA: 0x0000684C File Offset: 0x00004A4C
		public static string ShortCaption
		{
			get
			{
				return ApplicationInfo.Title + " " + ApplicationInfo.ShortVersionName;
			}
		}
	}
}
