// -------------------------------------------------------------------------------
// <copyright file="AccountManager.cs" company="StarGuddy India">
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
namespace StarGuddy.Business.Modules.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using StarGuddy.Business.Interface.Account;
    using StarGuddy.Repository.Interface;

    /// <summary>
    /// Account Manager
    /// </summary>
    /// <seealso cref="StarGuddy.Data.Business.Interfaces.IAccountManager" />
    public class AccountManager : IAccountManager
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManager"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public AccountManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
    }
}