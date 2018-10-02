// -------------------------------------------------------------------------------
// <copyright file="AddressRepository.cs" company="StarGuddy India">
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
namespace StarGuddy.Repository.Operations
{
    #region Imports
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
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
    /// Address Repository
    /// </summary>
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{StarGuddy.Data.Entities.UserAddress}" />
    /// <seealso cref="StarGuddy.Repository.Interfaces.IAddressRepository" />
    /// <seealso cref="StarGuddy.Data.Repository.RepositoryAbstract{StarGuddy.Data.Entities.UserAddress}" />
    /// <seealso cref="StarGuddy.Data.Repository.RepositoryAbstract" />
    /// <seealso cref="StarGuddy.Data.Repository.Interfaces.IAddressRepository" />
    public class AddressRepository : RepositoryAbstract<UserAddress>, IAddressRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository" /> class.
        /// </summary>
        /// <param name="configurationSingleton">The configuration singleton.</param>
        public AddressRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserAddress)
        {
        }

        /// <summary>
        /// Gets the user address asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// User Address
        /// </returns>
        public async Task<IUserAddress> GetAsync(Guid userId) => await FindActiveByUserIdAsync(userId);

        public async Task<bool> UpdateAsync(IUserAddress address)
        {
            try
            {


                using (var conn = await Connection.OpenConnectionAsync())
                {
                    //@UserId UNIQUEIDENTIFIER, @AppOrHouseName NVARCHAR(150), @CityOrTown NVARCHAR(100), @Country NVARCHAR(50), @Flat NVARCHAR(50), 
                    //@LandMark NVARCHAR(200), @LineOne NVARCHAR(200), @LineTwo NVARCHAR(200), @StateOrProvince NVARCHAR(100), @ZipOrPostalCode NVARCHAR(10)
                    var param = new
                    {
                        address.UserId,
                        address.AppOrHouseName,
                        address.CityOrTown,
                        address.Country,
                        address.Flat,
                        address.LandMark,
                        address.LineOne,
                        address.LineTwo,
                        address.StateOrProvince,
                        address.ZipOrPostalCode
                    };

                    await SqlMapper.ExecuteAsync(conn, SpNames.Address.InsertOrUpdateAddress, param, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
