// -------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="StarGuddy India">
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
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using StarGuddy.Api.Models.Account;
    using StarGuddy.Api.Models.AppUser;
    using StarGuddy.Api.Models.Dto;
    using StarGuddy.Api.Models.Interface.Account;
    using StarGuddy.Business.Interface.Account;
    using StarGuddy.Core.Context;
    using StarGuddy.Data.Entities;
    using StarGuddy.Data.Entities.Interface;
    using StarGuddy.Repository.Interface;

    /// <summary>
    /// Sign-up Manager Class
    /// </summary>
    /// <seealso cref="ISignupManager" />
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IUserPhonesRepository _userPhonesRepository;
        private readonly IUserEmailsRepository _userEmailsRepository;
        private readonly IUserSettingsRepository _userSettingsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignupManager"/> class.
        /// </summary>
        /// <param name="signupManager">The user repository.</param>
        public UserManager(
            IUserRepository userRepository,
            IAddressRepository addressRepository,
            IUserDetailRepository userDetailRepository,
            IUserPhonesRepository userPhonesRepository,
            IUserEmailsRepository userEmailsRepository,
            IUserSettingsRepository userSettingsRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _userDetailRepository = userDetailRepository;
            _userPhonesRepository = userPhonesRepository;
            _userEmailsRepository = userEmailsRepository;
            _userSettingsRepository = userSettingsRepository;
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// User Object
        /// </returns>
        public async Task<bool> CreateAsync(IApplicationUser applicationUser)
        {
            return await Task.Factory.StartNew(() =>
            {
                var user = new User
                {
                    Id = applicationUser.UserId,
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    Gender = applicationUser.Gender,
                    IsCastingProfessional = applicationUser.IsCastingProfessional,
                    Designation = applicationUser.Designation,
                    OrgName = applicationUser.OrgName,
                    OrgWebsite = applicationUser.OrgWebsite,
                    UserName = applicationUser.Email,
                    PasswordHash = applicationUser.Password,
                    SecurityStamp = Convert.ToString(Guid.NewGuid()),
                    IsActive = true
                };

                return _userRepository.AddNewUser(user, applicationUser.Email);
            });
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// User Object
        /// </returns>
        public async Task<int> UpdateUser(IApplicationUser applicationUser)
        {
            return await Task.Factory.StartNew(() =>
            {
                var user = new User
                {
                    Id = applicationUser.UserId,
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    Gender = applicationUser.Gender,
                    IsCastingProfessional = applicationUser.IsCastingProfessional,
                    Designation = applicationUser.Designation,
                    OrgName = applicationUser.OrgName,
                    OrgWebsite = applicationUser.OrgWebsite,
                    UserName = applicationUser.Email,
                    PasswordHash = applicationUser.Password,
                    SecurityStamp = Convert.ToString(Guid.NewGuid())
                };

                return this._userRepository.UpdateUser(user);
            });
        }

        public async Task<IApplicationUser> FindByUserNameAsync(string userName)
        {
            var user = await _userRepository.FindByUserName(userName);
            if (user.IsNull())
            {
                return null;
            }

            return new ApplicationUser
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                IsCastingProfessional = user.IsCastingProfessional,
                Designation = user.Designation,
                OrgName = user.OrgName,
                OrgWebsite = user.OrgWebsite,
                UserName = user.UserName,
                SecurityStamp = user.SecurityStamp
            };
        }

        /// <summary>
        /// Finds the by identifier asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// IApplication User
        /// </returns>
        public async Task<IApplicationUser> FindByIdAsync(string userId)
        {
            return await Task.Factory.StartNew(() =>
            {
                return new ApplicationUser();
            });
        }

        public void ConfirmEmailAsync(string userId, string code)
        {

        }

        public async Task<AppUserDetail> GetUserDetails(Guid userId)
        {
            var appUserTask = _userRepository.FindByIdAsync(userId);
            var addressTask = _addressRepository.GetAsync(userId);
            var emalTask = _userEmailsRepository.GetUserEmailAsync(userId);
            var phoneTask = _userPhonesRepository.GetUserPhoneDetailByUserId(userId);
            var detailTask = _userDetailRepository.GetUserDetailByUserId(userId);

            var taskResult = Task.WhenAll(appUserTask, addressTask, emalTask, phoneTask, detailTask);
            try
            {
                await taskResult.ConfigureAwait(false);
                if (taskResult.IsCompletedSuccessfully)
                {
                    return new AppUserDetail
                    {
                        ApplicationUser = _mapper.Map<AppUserDto>(await appUserTask),
                        CurrentAddress = _mapper.Map<AddressDto>(await addressTask),
                        UserDetails = _mapper.Map<UserDetailDto>(await detailTask),
                        Email = _mapper.Map<EmailDto>(await emalTask),
                        Phone = _mapper.Map<PhoneDto>(await phoneTask)
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public async Task<AddressDto> GetCurrentAddress()
        {
            var addressTask = await _addressRepository.GetAsync(UserContext.Current.UserId);
            try
            {

                if (addressTask.IsNotNull())
                {
                    return _mapper.Map<AddressDto>(addressTask);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public async Task<bool> UpdateCurrentAddress(AddressDto address)
        {
            address.UserId = UserContext.Current.UserId;

            var userAddress = _mapper.Map<UserAddress>(address);
            if (userAddress.IsNotNull())
            {
                return await _addressRepository.UpdateAsync(userAddress);
            }

            return false;
        }
    }
}
