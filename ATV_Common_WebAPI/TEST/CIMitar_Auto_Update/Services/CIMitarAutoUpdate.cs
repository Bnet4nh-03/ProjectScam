using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ATV_Common_WebAPI.TEST.CIMitar_Auto_Update.Models;
using ATV_Common_WebAPI.TEST.CIMitar_Auto_Update.Interfaces;

namespace ATV_Common_WebAPI.TEST.CIMitar_Auto_Update.Services
{
    public class CIMitarAutoUpdate : ICIMitarAutoUpdateService
    {
        private readonly string _contentRootPath;
        private readonly string cimitarFolder = "ATV_CIMitar_Latest_Version";
        private readonly string versionFile = "version.txt";
        private readonly string versionPath;

        public CIMitarAutoUpdate(IWebHostEnvironment webHostEnvironment)
        {
            _contentRootPath = webHostEnvironment.ContentRootPath;
            versionPath = Path.Combine(cimitarFolder, versionFile);
        }

        public string GetVersion()
        {
            string version = "";
            try
            {
                string[] fileContentLines = File.ReadAllLines(Path.Combine(_contentRootPath, versionPath));
                foreach (string line in fileContentLines)
                {
                    if (line.Contains("latest="))
                    {
                        version = line.Split('=')[^1].Trim();
                        break;
                    }
                }
            }
            catch
            {
                version = "";
            }
            return version;
        }

        public string GetChangeLog()
        {
            string changelog = "";
            try
            {
                string[] fileContentLines = File.ReadAllLines(Path.Combine(_contentRootPath, versionPath));
                foreach (string line in fileContentLines)
                {
                    if (line.Contains("update_changelog="))
                    {
                        changelog = line.Split('=')[^1].Trim();
                        break;
                    }
                }
            }
            catch
            {
                changelog = "";
            }
            return changelog;
        }

        private string Clear7zFile()
        {
            string[] arr7zFiles = Directory.GetFiles(Path.Combine(_contentRootPath, cimitarFolder), "*.7z");
            try
            {
                foreach (string filePath in arr7zFiles)
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "Clear Done";
        }

        public IResult GetLatestATVCIMitar()
        {
            string cimitar7z = "";

            string[] arr7zFiles = Directory.GetFiles(Path.Combine(_contentRootPath, cimitarFolder), "*.7z");

            foreach (string filePath in arr7zFiles)
            {
                if (filePath.Contains(GetVersion()))
                {
                    cimitar7z = Path.GetFileName(filePath);
                    break;
                }
            }

            var stream = File.OpenRead(Path.Combine(_contentRootPath, cimitarFolder, cimitar7z));
            return Results.File(stream, "application/octet-stream", cimitar7z);
        }

        public async Task<IResult> UpdateLatestATVCIMitar(CIMitarUploadModel model)
        {
            if (model.File != null && model.File.FileName.EndsWith(".7z"))
            {
                string clear7zStatus = Clear7zFile();
                if (clear7zStatus != "Clear Done")
                {
                    return Results.BadRequest(clear7zStatus);
                }

                // Decode base64 string to byte array
                byte[] fileBytes = Convert.FromBase64String(model.File.Data);

                // Write bytes to file
                var filePath = Path.Combine(_contentRootPath, cimitarFolder, model.File.FileName);
                await File.WriteAllBytesAsync(filePath, fileBytes);

                // Update version
                var version = model.File.FileName.Split('.')[0].Split('_')[^1];
                string versionContent = $"latest={version}\nupdate_changelog={model.Changelog}";
                await File.WriteAllTextAsync(Path.Combine(_contentRootPath, versionPath), versionContent);
                return Results.Ok($"File {model.File.FileName} uploaded and version updated to {version}. Changelog: {model.Changelog}");
            }

            return Results.BadRequest("Invalid file. Please upload a .7z file.");
        }
    }
}