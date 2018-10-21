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
    using StarGuddy.Business.Modules.Network.Sender;
    using StarGuddy.Core.Constants;
    using StarGuddy.Core.Context;
    using StarGuddy.Repository.Interface;

    public class EmailManager : IEmailManager
    {
        public IUserEmailsRepository _userEmailsRepository;
        public readonly ISettingsMasterRepository _settingsMaseterRepository;

        private int PortNumber { get; set; }
        private string Host { get; set; }

        public EmailManager(ISettingsMasterRepository settingsMaseterRepository, IUserEmailsRepository userEmailsRepository)
        {
            _settingsMaseterRepository = settingsMaseterRepository;
            _userEmailsRepository = userEmailsRepository;

            Host = settingsMaseterRepository.GetSettingsValue(SettingMaster.SendUnoReplyEmailHost).Result;
            PortNumber = Convert.ToInt32(settingsMaseterRepository.GetSettingsValue(SettingMaster.EndNoReplyEmailPortNumber).Result);
        }

        

        public async Task<bool> SendMail(string subject, string body, string emailTo)
        {
            string emailFrom = await _settingsMaseterRepository.GetSettingsValue(SettingMaster.SendNoReplyEmail);
            var password = await _settingsMaseterRepository.GetSettingsValue(SettingMaster.SendNoReplyEmailPassword);

            return await EmailSender.SendEmailAsyc(subject, body, emailFrom: emailFrom, emailTo: emailTo, host: Host, password: password, portNumber: PortNumber);
        }  
        
        public async Task<string> GetCurrentEmailAsync(Guid UserId)
        {
            var emailResult = await _userEmailsRepository.GetCurrentEmailAsync(UserId);
            return emailResult.Email;
        }

        public async Task<bool> ActivateEmailAsync(Guid userId, string emailId)
        {
            return await _userEmailsRepository.ActivsteEmailAsync(userId, emailId);
        }
    }
}
