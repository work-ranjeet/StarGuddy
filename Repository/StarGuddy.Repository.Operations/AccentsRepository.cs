// -------------------------------------------------------------------------------
// <copyright file="AccentsRepository.cs" company="StarGuddy India">
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
    using StarGuddy.Data.Entities;
    using StarGuddy.Repository.Base;
    using StarGuddy.Repository.Configuration;
    using StarGuddy.Repository.Interface;
    using StarGuddy.Repository.Opertions.Constants;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Accents Repository
    /// </summary>
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{StarGuddy.Data.Entities.Accents}" />
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{StarGuddy.Repository.Opertions.AccentsRepository}" />
    /// <seealso cref="StarGuddy.Repository.Interface.IAccentsRepository" />
    public class AccentsRepository : RepositoryAbstract<Accents>, IAccentsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccentsRepository" /> class.
        /// </summary>
        /// <param name="configurationSingleton">The configuration singleton.</param>
        public AccentsRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.Accents)
        {
        }
    }
}
