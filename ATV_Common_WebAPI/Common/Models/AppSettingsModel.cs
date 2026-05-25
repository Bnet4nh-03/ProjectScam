
namespace ATV_Common_WebAPI.Common.Models
{
    public class AppSettingsModel
    {
        public class SmtpSettingModel
        {
            public string SmtpDomain { get; set; }
            public string SmtpIp { get; set; }
            public Dictionary<string, SmtpPortModel> SmtpPort { get; set; }
            public Dictionary<string, SmtpAccountModel> SmtpAccount { get; set; }
        }

        public class SmtpPortModel
        {
            public int Port { get; set; }
        }

        public class SmtpAccountModel
        {
            public string Account { get; set; }
            public string Password { get; set; }
        }

        }

    public class FileServiceSettings
    {
        public string DirectoryStartWith { get; set; }
        public Dictionary<string, string> AppDirectoryMappings { get; set; }
    }
}

