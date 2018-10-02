// -------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="StarGuddy India">
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
// ReSharper disable once CheckNamespace
namespace StarGuddy.Repository.Operations
{
    using System;
    #region Imports
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using StarGuddy.Data.Entities;
    using StarGuddy.Data.Entities.Interface;
    using StarGuddy.Repository.Base;
    using StarGuddy.Repository.Configuration;
    using StarGuddy.Repository.Interface;
    using StarGuddy.Repository.Opertions.Constants;
    #endregion

    /// <summary>
    /// User Repository
    /// </summary>
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{User}" />
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{User}" />
    /// <seealso cref="StarGuddy.Repository.Interfaces.IUserRepository" />
    public class UserRepository : RepositoryAbstract<User>, IUserRepository
    {

        private readonly IUserEmailsRepository _userEmailsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository" /> class.
        /// </summary>
        /// <param name="configurationSingleton">The configuration singleton.</param>
        /// <inheritdoc />
        public UserRepository(IConfigurationSingleton configurationSingleton, IUserEmailsRepository userEmailsRepository) : base(configurationSingleton, SqlTable.Users)
        {
            _userEmailsRepository = userEmailsRepository;
        }

        #region /// Select
        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Application User
        /// </returns>
        public async Task<User> FindByIdAsync(Guid id)
        {
            return await FindActiveByIdAsync(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Finds the by user name.
        /// </summary>
        /// <param name="userName">user name</param>
        /// <returns>
        /// User data object
        /// </returns>
        public async Task<IUser> FindByUserName(string userName)
        {
            var userObj =  await FindSingleAsync("SELECT * FROM Users WHERE UserName=@UserName", new { UserName = userName }).ConfigureAwait(false);
            if(userObj.IsNotNull())
            {
                var emailObj = await _userEmailsRepository.GetUserEmailAsync(userObj.Id).ConfigureAwait(false);
                if(emailObj.IsNotNull())
                {
                    userObj.Email = emailObj.Email;
                }
            }

            return userObj;
        }

        /// <summary>
        /// Gets the verified user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Application User
        /// </returns>
        public IEnumerable<IUser> GetVerifiedUser(string userName, string password)
        {
            var parameter = new
            {
                UserName = userName,
                Password = password
            };

            return this.GetProcedureData("GetVarifiedUser", parameter);
        }        

        public async Task<UserProfileHeader> GetUserProfileHeaderByProfilUrl(string profileUrl)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    var param = new { ProfileUrl = profileUrl };

                    using (var multi = await conn.QueryMultipleAsync(SpNames.User.GetProfileHeader, param, commandType: CommandType.StoredProcedure))
                    {
                        var header = multi.ReadFirstOrDefault<UserProfileHeader>();
                        if (header.IsNotNull())
                            header.JobGroups = multi.Read<JobGroup>();

                        return header;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<UserProfileHeader> GetUserProfileHeaderById(Guid userId)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    var param = new { UserId = userId };

                    using (var multi = await conn.QueryMultipleAsync(SpNames.User.GetProfileEditHeader, param, commandType: CommandType.StoredProcedure))
                    {
                        var header = multi.ReadFirstOrDefault<UserProfileHeader>();
                        if (header.IsNotNull())
                            header.JobGroups = multi.Read<JobGroup>();

                        return header;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region /// Insert
        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// Application User
        /// </returns>
        public bool AddNewUser(IUser user, string email)
        {
            try
            {
                using (var conn = this.OpenConnectionAsync)
                {
                    var parameter = new
                    {
                        AccessFailedCount = 0,
                        ConcurrencyStamp = Guid.NewGuid(),
                        LockoutEnd = DateTime.UtcNow.AddSeconds(-1),
                        IsTwoFactorEnabled = false,
                        Email = email,
                        user.FirstName,
                        user.Gender,
                        user.IsCastingProfessional,
                        user.LastName,
                        user.LockoutEnabled,
                        user.Designation,
                        user.OrgName,
                        user.OrgWebsite,
                        user.PasswordHash,
                        user.SecurityStamp,
                        user.UserName
                    };

                    conn.Execute(SpNames.User.AddNewUser, param: parameter, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region /// Update
        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// Application User
        /// </returns>
        public int UpdateUser(IUser user)
        {
            using (var conn = this.OpenConnectionAsync)
            {
                var parameter = user;
                parameter.AccessFailedCount = 0;
                parameter.ConcurrencyStamp = "b8c6e4a2-fb40-4706-b608-f05a4a6ff708";
                parameter.LockoutEnd = DateTime.UtcNow;
                parameter.IsTwoFactorEnabled = false;

                //var parameter = new
                //{
                //    AccessFailedCount = 0,
                //    ConcurrencyStamp = "b8c6e4a2-fb40-4706-b608-f05a4a6ff708",
                //    //Email = user.Email,
                //    //EmailConfirmed = user.EmailConfirmed,
                //    //FirstName = user.FirstName,
                //    //Gender = user.Gender,
                //    //IsCastingProfessional = user.IsCastingProfessional,
                //    //LastName = user.LastName,
                //    //LockoutEnabled = user.LockoutEnabled,
                //    LockoutEnd = DateTime.UtcNow,
                //    //NormalizedEmail = user.NormalizedEmail,
                //    //NormalizedUserName = user.NormalizedUserName,
                //    //Designation = user.Designation,
                //    //OrgName = user.OrgName,
                //    //OrgWebsite = user.OrgWebsite,
                //    //PasswordHash = user.PasswordHash,
                //    //PhoneNumber = user.PhoneNumber,
                //    //PhoneNumberConfirmed = false,
                //    //SecurityStamp = user.SecurityStamp,
                //    TwoFactorEnabled = false,
                //    //UserName = user.UserName
                //};

                return conn.Execute(SpNames.User.UpdateUser, param: parameter, commandType: CommandType.StoredProcedure);
            }

        }

        /// <summary>
        /// Updates the password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public int UpdatePassword(string userName, string password)
        {
            using (var conn = this.OpenConnectionAsync)
            {
                var query = string.Format("update Users set PasswordHash='{0}' where UserName = '{1}'", password, userName);
                return conn.Execute(query, commandType: CommandType.Text);
            }
        }

        public async Task<bool> UpdateNameDetails(IUser user)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    var param = new { UserId = user.Id, user.FirstName, user.LastName, user.DisplayName, user.OrgName };

                    await SqlMapper.ExecuteAsync(conn, SpNames.User.UpdateUserName, param, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
