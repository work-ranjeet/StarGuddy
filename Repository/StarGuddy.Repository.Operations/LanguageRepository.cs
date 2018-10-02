using System;
// -------------------------------------------------------------------------------
// <copyright file="LanguageRepository.cs" company="StarGuddy India">
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
    using System.Collections.Generic;
    using System.Text;
    using StarGuddy.Data.Entities;
    using StarGuddy.Repository.Base;
    using StarGuddy.Repository.Configuration;
    using StarGuddy.Repository.Interface;
    using StarGuddy.Repository.Opertions.Constants;

    /// <summary>
    /// Language Repository
    /// </summary>
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{StarGuddy.Data.Entities.Language}" />
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{StarGuddy.Repository.Opertions.LanguageRepository}" />
    /// <seealso cref="StarGuddy.Repository.Interface.ILanguageRepository" />
    public class LanguageRepository : RepositoryAbstract<Language>, ILanguageRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageRepository" /> class.
        /// </summary>
        /// <param name="configurationSingleton">The configuration singleton.</param>
        public LanguageRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.Languages)
        {
        }
    }
}
