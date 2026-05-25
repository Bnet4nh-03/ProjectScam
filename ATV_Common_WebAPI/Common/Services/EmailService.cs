using System.Net.Mail;
using System.Text;
using ATV_Common_WebAPI.Common.Interfaces;
using ATV_Common_WebAPI.Common.Models;

namespace ATV_Common_WebAPI.Common.Services
{
    public class EmailService : IEmailService
    {
        private readonly AppSettingsModel.SmtpSettingModel _smtpSetting;

        public EmailService(AppSettingsModel.SmtpSettingModel smtpSetting)
        {
            _smtpSetting = smtpSetting;
        }

        public async Task<IResult> SendEmail(EmailModel.EmailRequestModel emailContentInfo)
        {
            MailMessage mailMessage = new MailMessage();
            MailAddress fromAddress = new MailAddress(emailContentInfo.Sender);
            mailMessage.Priority = SelectMailPriority(emailContentInfo.MailPriority);
            mailMessage.From = fromAddress;

            InputEmailData(ref mailMessage, emailContentInfo.ToMailList, "To");
            InputEmailData(ref mailMessage, emailContentInfo.CcMailList, "Cc");
            InputEmailData(ref mailMessage, emailContentInfo.BccMailList, "Bcc");
            InputAttachments(ref mailMessage, emailContentInfo.AttachmentList);

            mailMessage.Subject = emailContentInfo.Subject;
            mailMessage.SubjectEncoding = Encoding.UTF8;

            mailMessage.Body = emailContentInfo.Body;
            mailMessage.IsBodyHtml = true;

            string smtpDomainConfig = _smtpSetting.SmtpDomain;
            int smtpPortConfig = _smtpSetting.SmtpPort["Default"].Port;
            AppSettingsModel.SmtpAccountModel smtpAccountConfig = _smtpSetting.SmtpAccount["atvtfa_notice"];

            if (emailContentInfo.SmtpConfig != null)
            {
                smtpDomainConfig = !string.IsNullOrEmpty(emailContentInfo.SmtpConfig.SmtpDomain)
                    ? emailContentInfo.SmtpConfig.SmtpDomain
                    : _smtpSetting.SmtpDomain;

                smtpPortConfig = emailContentInfo.SmtpConfig.SmtpPort != 0
                    ? emailContentInfo.SmtpConfig.SmtpPort
                    : _smtpSetting.SmtpPort["Default"].Port;

                if (!string.IsNullOrEmpty(emailContentInfo.SmtpConfig.SmtpAccountName) &&
                    !string.IsNullOrEmpty(emailContentInfo.SmtpConfig.SmtpPassword))
                {
                    smtpAccountConfig = new AppSettingsModel.SmtpAccountModel
                    {
                        Account = emailContentInfo.SmtpConfig.SmtpAccountName,
                        Password = emailContentInfo.SmtpConfig.SmtpPassword
                    };
                }
                else if (_smtpSetting.SmtpAccount.ContainsKey(emailContentInfo.SmtpConfig.SmtpAccountName))
                {
                    smtpAccountConfig = _smtpSetting.SmtpAccount[emailContentInfo.SmtpConfig.SmtpAccountName];
                }
            }

            SmtpClient smtpClient = SMTPWithCredential(smtpDomainConfig, smtpPortConfig, smtpAccountConfig);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new EmailModel.EmailResponseModel { Status = "NG", Message = $"Email send fail - {ex.Message}" });
            }
            finally
            {
                smtpClient.Dispose();
            }

            return Results.Ok(new EmailModel.EmailResponseModel { Status = "OK", Message = "Email sent successfully" });
        }

        private static SmtpClient SMTPWithCredential(string smtpDomain, int smtpPort, AppSettingsModel.SmtpAccountModel smtpAccount)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            SmtpClient smtpClient = new SmtpClient(smtpDomain)
            {
                Port = smtpPort,
                Credentials = new System.Net.NetworkCredential(smtpAccount.Account, smtpAccount.Password),
                EnableSsl = true
            };
            
            return smtpClient;
        }

        private static void InputEmailData(ref MailMessage mailMessage, List<string> lstEmailInfo, string strInfoType)
        {
            if (lstEmailInfo == null || lstEmailInfo.Count == 0) return;

            foreach (var emailInfo in lstEmailInfo)
            {
                if (string.IsNullOrWhiteSpace(emailInfo)) continue;

                switch (strInfoType)
                {
                    case "To":
                        mailMessage.To.Add(emailInfo);
                        break;
                    case "Cc":
                        mailMessage.CC.Add(emailInfo);
                        break;
                    case "Bcc":
                        mailMessage.Bcc.Add(emailInfo);
                        break;
                }
            }
        }

        private static void InputAttachments(ref MailMessage mailMessage, List<EmailModel.AttachmentModel> attachmentList)
        {
            if (attachmentList == null || attachmentList.Count == 0) return;

            foreach (var attachmentModel in attachmentList)
            {
                byte[] fileBytes = Convert.FromBase64String(attachmentModel.Base64File);
                MemoryStream ms = new MemoryStream(fileBytes);
                Attachment attachment = new Attachment(ms, attachmentModel.FileName, attachmentModel.MimeType);
                mailMessage.Attachments.Add(attachment);
            }
        }

        private static MailPriority SelectMailPriority(string mailPriority)
        {
            return mailPriority.ToUpper() switch
            {
                "LOW" => MailPriority.Low,
                "NORMAL" => MailPriority.Normal,
                "HIGH" => MailPriority.High,
                _ => MailPriority.Normal,
            };
        }
    }
}