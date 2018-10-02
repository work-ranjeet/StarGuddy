// -------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains properties of customer details.
// -------------------------------------------------------------------------------
// Author: Ranjeet Kumar
// Date Created: 01/01/2018
// -------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Interface.Account
{
    using StarGuddy.Api.Models.Account;
    using StarGuddy.Api.Models.AppUser;
    using StarGuddy.Api.Models.Dto;
    using StarGuddy.Api.Models.Interface.Account;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Sign up Manager Interface
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// User Object
        /// </returns>
        Task<bool> CreateAsync(IApplicationUser applicationUser);

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// User Object
        /// </returns>
        Task<int> UpdateUser(IApplicationUser applicationUser);

        /// <summary>
        /// Finds the by identifier asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// IApplication User
        /// </returns>
        Task<IApplicationUser> FindByIdAsync(string userId);

        Task<IApplicationUser> FindByUserNameAsync(string userName);

        Task<AppUserDetail> GetUserDetails(Guid userId);

        Task<AddressDto> GetCurrentAddress();

        Task<bool> UpdateCurrentAddress(AddressDto address);
    }
}
