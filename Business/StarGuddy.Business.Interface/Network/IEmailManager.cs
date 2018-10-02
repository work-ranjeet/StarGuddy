// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Interface.Network
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEmailManager
    {
        Task<bool> SendMail(string subject, string body, string emailTo);

        Task<bool> SendMail(string subject, string body, string emailFrom, string emailTo);

        Task<bool> SendMail(string subject, string body, string emailFrom, string emailTo, bool isHtml = true);
    }
}
