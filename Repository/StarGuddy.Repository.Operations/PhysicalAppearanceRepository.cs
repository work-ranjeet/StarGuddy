// -------------------------------------------------------------------------------
// <copyright file="PhysicalAppearanceRepository.cs" company="StarGuddy India">
// Copyright (c) 2018. All rights reserved.
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
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Threading.Tasks;
    using Dapper;
    using StarGuddy.Data.Entities;
    using StarGuddy.Data.Entities.Interface;
    using StarGuddy.Repository.Base;
    using StarGuddy.Repository.Configuration;
    using StarGuddy.Repository.Interface;
    using StarGuddy.Repository.Opertions.Constants;

    /// <summary>
    /// Physical Appearance Repository
    /// </summary>
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{StarGuddy.Data.Entities.PhysicalAppearance}" />
    /// <seealso cref="StarGuddy.Repository.Interface.IPhysicalAppearanceRepository" />
    public class PhysicalAppearanceRepository : RepositoryAbstract<PhysicalAppearance>, IPhysicalAppearanceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalAppearanceRepository"/> class.
        /// </summary>
        /// <param name="configurationSingleton">The configuration singleton.</param>
        public PhysicalAppearanceRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.PhysicalAppearance)
        {

        }

        public async Task<bool> PerformSaveOperation(IPhysicalAppearance physicalAppearance)
        {
            try
            {
                using (var conn = base.OpenConnectionAsync)
                {
                    var param = new
                    {
                        physicalAppearance.UserId,
                        physicalAppearance.BodyType,
                        physicalAppearance.Chest,
                        physicalAppearance.EyeColor,
                        physicalAppearance.HairColor,
                        physicalAppearance.HairLength,
                        physicalAppearance.HairType,
                        physicalAppearance.SkinColor,
                        physicalAppearance.Height,
                        physicalAppearance.Weight,
                        physicalAppearance.West,
                        physicalAppearance.Ethnicity
                    };

                    return await SqlMapper.ExecuteAsync(conn, SpNames.PhysicalAppearance.PhysicalAppearanceSaveUpdate, param, commandType: CommandType.StoredProcedure) > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPhysicalAppearance> GetPhysicalAppreanceById(Guid userId)
        {
            return await base.FindActiveByUserIdAsync(userId);
        }
    }
}
