using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Amkor.CADModules.CarrierModule.Class
{
	// Token: 0x02000010 RID: 16
	internal sealed class AllowAllAssemblyVersionsDeserializationBinder : SerializationBinder
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00002724 File Offset: 0x00000924
		public override Type BindToType(string assemblyName, string typeName)
		{
			Type result = null;
			try
			{
				string fullName = Assembly.GetExecutingAssembly().FullName;
				assemblyName = fullName;
				result = Type.GetType(string.Format("{0}, {1}", typeName, assemblyName));
			}
			catch (Exception)
			{
			}
			return result;
		}
	}
}
