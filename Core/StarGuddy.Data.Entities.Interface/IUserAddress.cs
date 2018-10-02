// -------------------------------------------------------------------------------
// <copyright file="UserAddress.cs" company="StarGuddy India">
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
namespace StarGuddy.Data.Entities.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// User Address
    /// </summary>
     public interface IUserAddress
     {
         Guid Id { get; set; }

         Guid UserId { get; set; }

         Boolean IsActive { get; set; }

         Boolean IsDeleted { get; set; }

         String AppOrHouseName { get; set; }

         String CityOrTown { get; set; }

         String Country { get; set; }

         String Flat { get; set; }

         String LandMark { get; set; }

         String LineOne { get; set; }

         String LineTwo { get; set; }

         String StateOrProvince { get; set; }

         String ZipOrPostalCode { get; set; }

         DateTime DttmCreated { get; set; }

         DateTime DttmModified { get; set; }
    }
}
