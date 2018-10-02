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
namespace StarGuddy.Data.Entities
{
    using System;
    using StarGuddy.Data.Entities.Interface;

    /// <summary>
    /// Accent class
    /// </summary>
    public class Accents : IAccents
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string LanguageCode { get; set; }

        public string SelectedAccent { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
    
}
