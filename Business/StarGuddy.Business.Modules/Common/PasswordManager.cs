// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Modules.Common
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using StarGuddy.Api.Models.Interface.Account;
    using StarGuddy.Business.Interface.Common;
    using StarGuddy.Repository.Interface;

    /// <summary>
    /// Password Manager
    /// </summary>
    public class PasswordManager : IPasswordManager
    {
        #region /// Properties
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// The security manager
        /// </summary>
        private readonly ISecurityManager _securityManager;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SignupManager" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="securityManager">The security manager.</param>
        public PasswordManager(IUserRepository userRepository, ISecurityManager securityManager)
        {
            _userRepository = userRepository;
            _securityManager = securityManager;
        }

        /// <summary>
        /// Gets the hashed password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>string values</returns>
        public async Task<string> GetHashedPassword(string password)
        {
            return await _securityManager.GetHashPassword(password);
        }

        /// <summary>
        /// Determines whether [is valid password] [the specified user identifier].
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// boolean value
        /// </returns>
        public async Task<bool> IsValidPassword(Guid userId, string password)
        {
            var user = await _userRepository.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            return await _securityManager.VerifyHashedPassword(user.PasswordHash, password);
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="pwdModel">The password model.</param>
        /// <returns></returns>
        public async Task<bool> ChangePassword(IPasswordModel pwdModel)
        {
            return await Task.Factory.StartNew(() =>
            {
                if (pwdModel.NewPassword != pwdModel.ConfirmPassword)
                {
                    return false;
                }

                var isValidPwd = _userRepository.GetVerifiedUser(pwdModel.UserName, pwdModel.OldPassword).Where(x => !x.LockoutEnabled).Any();
                if (isValidPwd)
                {
                    var result = _userRepository.UpdatePassword(pwdModel.UserName, pwdModel.NewPassword);
                    return result > decimal.Zero;
                }

                return false;
            });
        }
    }
}
