namespace ATV_Common_WebAPI.Common.Utilities
{
    public class DirectoryUtility
    {
        public static void CreateFolderIfNotExist(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}
