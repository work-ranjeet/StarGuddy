// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Interface.Common
{
    using StarGuddy.Api.Models.Interface.Account;
    using System.Threading.Tasks;

    /// <summary>
    /// Password Manager Interface
    /// </summary>
    public interface IPasswordManager
    {
        /// <summary>
        /// Gets the hashed password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>string values</returns>
        Task<string> GetHashedPassword(string password);

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="pwdModel">The password model.</param>
        /// <returns></returns>
        Task<bool> ChangePassword(IPasswordModel pwdModel);
    }
}
