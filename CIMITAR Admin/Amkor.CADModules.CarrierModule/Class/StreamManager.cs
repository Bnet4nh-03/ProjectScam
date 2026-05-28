using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Amkor.CADModules.CarrierModule.Class
{
	// Token: 0x02000011 RID: 17
	public class StreamManager
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002774 File Offset: 0x00000974
		public static int ObjectToFile(object obj, string path, FileMode filemode)
		{
			try
			{
				byte[] array = StreamManager.ObjectToByteArray(obj);
				if (array == null)
				{
					return -1;
				}
				FileStream fileStream = new FileStream(path, filemode);
				fileStream.Write(array, 0, array.Length);
				fileStream.Close();
			}
			catch (Exception)
			{
			}
			return 0;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000027C8 File Offset: 0x000009C8
		public static object FileToObject(string path, FileMode filemode)
		{
			object result = null;
			try
			{
				if (File.Exists(path))
				{
					FileStream fileStream = new FileStream(path, filemode);
					byte[] buffer = new byte[fileStream.Length];
					fileStream.Read(buffer, 0, (int)fileStream.Length);
					result = StreamManager.ByteArrayToObject(buffer);
					fileStream.Close();
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000282C File Offset: 0x00000A2C
		public static byte[] ObjectToByteArray(object obj)
		{
			if (obj != null)
			{
				MemoryStream memoryStream = new MemoryStream(100000);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				try
				{
					binaryFormatter.Serialize(memoryStream, obj);
					byte[] result = memoryStream.ToArray();
					memoryStream.Close();
					return result;
				}
				catch (Exception)
				{
				}
			}
			return null;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002880 File Offset: 0x00000A80
		public static object ByteArrayToObject(byte[] buffer)
		{
			if (buffer.Length > 0)
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				MemoryStream serializationStream = new MemoryStream(buffer);
				binaryFormatter.Binder = new AllowAllAssemblyVersionsDeserializationBinder();
				try
				{
					return binaryFormatter.Deserialize(serializationStream);
				}
				catch (Exception)
				{
				}
			}
			return null;
		}
	}
}
