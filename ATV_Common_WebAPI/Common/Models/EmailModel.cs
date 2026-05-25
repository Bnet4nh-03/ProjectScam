namespace ATV_Common_WebAPI.Common.Models
{
    public class EmailModel
    {
        public class AttachmentModel
        {
            public required string Base64File { get; set; }
            public required string FileName { get; set; }
            public required string MimeType { get; set; }
        }

        public class SmtpConfigModel
        {
            public string SmtpDomain { get; set; }
            public string SmtpAccountName { get; set; }
            public string SmtpPassword { get; set; }
            public int SmtpPort { get; set; }
        }

        public class EmailRequestModel
        {
            public required string MailPriority { get; set; }
            public required string Sender { get; set; }
            public required string Subject { get; set; }
            public required string Body { get; set; }
            public required List<string> ToMailList { get; set; }
            public required List<string> CcMailList { get; set; }
            public required List<string> BccMailList { get; set; }
            public required List<AttachmentModel> AttachmentList { get; set; }
            public SmtpConfigModel SmtpConfig { get; set; }
        }

        public class EmailResponseModel
        {
            public required string Status { get; set; }
            public required string Message { get; set; }
        }
    }
}
