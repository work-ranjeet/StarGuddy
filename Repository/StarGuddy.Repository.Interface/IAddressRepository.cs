// -------------------------------------------------------------------------------
// <copyright file="IAddressRepository.cs" company="StarGuddy India">
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
    /// Address Repository Interface
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        /// Gets the user address asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// User Address
        /// </returns>
        Task<IUserAddress> GetAsync(Guid userId);

        Task<bool> UpdateAsync(IUserAddress address);
    }
}
