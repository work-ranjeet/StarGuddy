// -------------------------------------------------------------------------------
// <copyright file="Accents.cs" company="StarGuddy India">
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
    /// Accent class
    /// </summary>
    public interface IAccents
    {
        long Id { get; set; }
        string Name { get; set; }
        string Code { get; set; }
        string LanguageCode { get; set; }
        string SelectedAccent { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
    }

}
