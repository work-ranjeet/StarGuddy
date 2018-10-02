// -------------------------------------------------------------------------------
// <copyright file="IPhysicalAppearanceRepository.cs" company="StarGuddy India">
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
    using StarGuddy.Data.Entities.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// IPhysical Appearance Repository
    /// </summary>
    public interface IPhysicalAppearanceRepository
    {
        Task<IPhysicalAppearance> GetPhysicalAppreanceById(Guid userId);
        Task<bool> PerformSaveOperation(IPhysicalAppearance physicalAppearance);
    }
}
