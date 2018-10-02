// -------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="StarGuddy India">
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
namespace StarGuddy.Repository.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using StarGuddy.Data.Entities;
    using StarGuddy.Data.Entities.Interface;

    /// <summary>
    /// User Repository Interface
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Finds the by email identifier.
        /// </summary>
        /// <param name="id">The email identifier.</param>
        /// <returns>
        /// Application User
        /// </returns>
        Task<User> FindByIdAsync(Guid id);

        /// <summary>
        /// Finds the name of the by user.
        /// </summary>
        /// <param name="username">The user name.</param>
        /// <returns>User details</returns>
        Task<IUser> FindByUserName(string userName);

        /// <summary>
        /// Gets the verified user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Application User
        /// </returns>
        IEnumerable<IUser> GetVerifiedUser(string userName, string password);

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// Application User
        /// </returns>
        bool AddNewUser(IUser user, string email);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// Application User
        /// </returns>
        int UpdateUser(IUser user);


        /// <summary>
        /// Updates the password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        int UpdatePassword(string userName, string password);

        Task<bool> UpdateNameDetails(IUser user);

        Task<UserProfileHeader> GetUserProfileHeaderByProfilUrl(string profileUrl);

        Task<UserProfileHeader> GetUserProfileHeaderById(Guid userId);
    }
}
