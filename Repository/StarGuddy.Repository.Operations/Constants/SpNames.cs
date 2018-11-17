// -------------------------------------------------------------------------------
// <copyright file="SpNames.cs" company="StarGuddy India">
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
namespace StarGuddy.Repository.Opertions.Constants
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Store Procedure Name
    /// </summary>
    public partial class SpNames
    {
        /// <summary>
        /// User Structure
        /// </summary>
        public struct User
        {
            /// <summary>
            /// The add new user
            /// </summary>
            public const string AddNewUser = "AddNewUser";

            /// <summary>
            /// The update user
            /// </summary>
            public const string UpdateUser = "UpdateUser";

            public const string UpdateUserName = "UpdateUserName";

            /// <summary>
            /// The get verified user
            /// </summary>
            public const string GetVarifiedUser = "GetVarifiedUser";

            /// <summary>
            /// The get verified user
            /// </summary>
            public const string GetProfileEditHeader = "GetProfileEditHeader";

            /// <summary>
            /// The get verified user
            /// </summary>
            public const string GetProfileHeader = "GetProfileHeader";


            public const string EnableDisableTowFactor = "User_EnableDisableTowFactor";
        }

        public struct UserDetail
        {
            public const string UpdateAboutAndProfileAddress = "UpdateAboutAndProfileAddress";
        }

        public struct UserSettings
        {
            public const string GetProfileUserId = "GetProfileUserId";
            public const string SetVisibility = "Settings_SetVisibility";
            public const string ShowHideEmail = "Settings_ShowHideEmail";
            public const string ShowHideMobile = "Settings_ShowHideMobile";
            public const string ShowHideProfilePhoto = "Settings_ShowHideProfilePhoto";
            public const string AllowProfileComment = "Settings_AllowProfileComment";
        }

        public struct UserEmails
        {
            public const string UpdateEmail = "UpdateEmail";
            public const string ActivateEmail = "ActivateEmail";
        }

        public struct UserPhones
        {
            public const string UpdateMobile = "UpdateMobile";
        }

        public struct PhysicalAppearance
        {
            public const string PhysicalAppearanceSaveUpdate = "PhysicalAppearanceSaveUpdate";
        }

        public struct UserCredits
        {
            public const string UserCreditsSaveUpdate = "UserCreditsSaveUpdate";
        }

        public struct UserDancing
        {
            public const string SaveUpdate = "UserDancingSaveUpdate";
        }

        public struct UserDancingStyle
        {
            public const string Clear = "UserDancingStyleClear";
            public const string Save = "UserDancingStyleSave";
        }

        public struct DancingStyle
        {
            public const string Select = "DancingStyleSelect";
        }

        public struct UserActing
        {
            public const string SelectDetail = "GetUserActingDetail";
            public const string SaveUpdate = "UserActingSaveUpdate";
            public const string ClearActingDetail = "UserActingClear";
            public const string UserLanguageSave = "UserLanguageSave";
            public const string UserAccentSave = "UserAccentSave";
            public const string UserActingRolesSave = "UserActingRolesSave";
        }

        public struct UserModeling
        {
            public const string SelectDetail = "GetUserModelingDetail";
            public const string SaveUpdate = "UserModelingSaveUpdate";
            public const string ClearDetail = "UserModelingClear";
            public const string UserModelingRolesSave = "UserModelingRolesSave";
        }

        public struct JobGroup
        {
            public const string UserJobGroup = "GetUserJobGroup";
            public const string ClearJobGroups = "UserJobGroupsClear";
            public const string UserJobGroupSave = "UserJobGroupSave";
            public const string GetTalentGroup = "GetTalentGroup";
        }

        public struct Address
        {
            public const string InsertOrUpdateAddress = "InsertOrUpdateAddress";
        }

        public struct UserImage
        {
            public const string HeadShotImageSaveUpdate = "HeadShotImageSaveUpdate";
            public const string SaveImage = "UserImageSave";
            public const string UpdateStatus = "UserImageStatusUpdate";
            public const string UpdateCaption = "UserImageCaptionUpdate";
            public const string Delete = "UserImageDelete";
        }

        public struct SettingsMaaster
        {
            public const string GetSettingsByKey = "GetSettingsByKey";
        }

    }
}
