// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Interface.Common
{
    using StarGuddy.Api.Models.Interface.Account;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface ISecurityManager
    {
        Task<string> GetSettingsValue(string key); 
        
        Task<string> GetHashPassword(string password);

        //Task<string> GetJwtSecurityTokenAsync(IApplicationUser appUser);

        Task<bool> VerifyHashedPassword(string hashedPassword, string password);

        Task<IJwtPacket> CreateJwtPacketAsync(IApplicationUser applicationUser);

        Task<string> GetEmailVerificationCodeAsync(IApplicationUser applicationUser);
    }
}
