// -------------------------------------------------------------------------------
// <copyright file="Language.cs" company="StarGuddy India">
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
namespace StarGuddy.Data.Entities.Interface
{
    using System;

    /// <summary>
    /// Languages class
    /// </summary>
    public interface ILanguage
    {
         long Id { get; set; }
         string Name { get; set; }
         string Code { get; set; }
         string SelectedLanguageCode { get; set; }
         string CountryCode { get; set; }
         bool IsActive { get; set; }
         bool IsDeleted { get; set; }
    }
}

