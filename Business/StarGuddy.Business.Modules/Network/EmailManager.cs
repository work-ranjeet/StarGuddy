// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Modules.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;
    using StarGuddy.Business.Interface.Network;
    using StarGuddy.Repository.Interface;

    public class EmailManager : IEmailManager
    {
        public readonly ISettingsMasterRepository _settingsMaseterRepository;

        public EmailManager(ISettingsMasterRepository settingsMaseterRepository)
        {
            _settingsMaseterRepository = settingsMaseterRepository;
        }

        public async Task<bool> SendMail(string subject, string body, string emailTo)
        {
            return await SendEmail(subject, body, null, emailTo, isBodyHtml: true);
        }

        public async Task<bool> SendMail(string subject, string body, string emailFrom, string emailTo)
        {
            return await SendEmail(subject, body, emailFrom, emailTo, isBodyHtml: true);
        }

        public async Task<bool> SendMail(string subject, string body, string emailFrom, string emailTo, bool isHtml = true)
        {
            return await SendEmail(subject, body, emailFrom, emailTo, isBodyHtml: isHtml);
        }


        private async Task<bool> SendEmail(
            string subject, string body, string emailFrom, string emailTo,
            string host = null, string password = null, int portNumber = int.MinValue, bool isBodyHtml = true, bool enableSsl = false)
        {

            emailFrom = !string.IsNullOrWhiteSpace(emailFrom) ? emailFrom : await _settingsMaseterRepository.GetSettingsValue("send_no_reply_email");
            password = !string.IsNullOrWhiteSpace(password) ? password : await _settingsMaseterRepository.GetSettingsValue("send_no_reply_email_password");
            portNumber = portNumber != int.MinValue ? portNumber : Convert.ToInt32(await _settingsMaseterRepository.GetSettingsValue("send_no_reply_email_port_number"));
            host = !string.IsNullOrWhiteSpace(host) ? host : await _settingsMaseterRepository.GetSettingsValue("send_no_reply_email_host");

            using (MailMessage mailMessage = new MailMessage() { From = new MailAddress(emailFrom) })
            {

                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isBodyHtml;

                mailMessage.To.Add(new MailAddress(emailTo));

                var credentials = new NetworkCredential(emailFrom, password);
                SmtpClient smtp = new SmtpClient
                {
                    Host = host,
                    EnableSsl = enableSsl,
                    UseDefaultCredentials = true,
                    Credentials = credentials,
                    Port = portNumber
                };

                try
                {
                    await smtp.SendMailAsync(mailMessage);
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }

    }
}
