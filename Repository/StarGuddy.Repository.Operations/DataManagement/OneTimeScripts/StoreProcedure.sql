IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetVarifiedUser') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE GetVarifiedUser
GO

CREATE PROCEDURE GetVarifiedUser (@UserName NVARCHAR(256), @Password NVARCHAR(max))
AS
BEGIN
	BEGIN TRY
		SELECT *
		FROM Users
		WHERE UserName = @UserName AND PasswordHash = @Password AND IsActive = 1 AND IsDeleted = 0
	END TRY

	BEGIN CATCH
		--INSERT INTO ErrorLog (
		--	ErrorType,
		--	ErrorName,
		--	CustomMesage,
		--	ErrorNumber,
		--	ErrorMessage
		--	)
		--VALUES (
		--	1,
		--	'Select20InterNews',
		--	'Error from Select20InterNews Store Procedure',
		--	ERROR_NUMBER(),
		--	ERROR_MESSAGE()
		--	)
	END CATCH
END
	--EXEC GetVarifiedUser 'er.ranjeetkumar@gmail.com' , 'janeman'
	------------------------------------------- Save User Address ---------------------------------------
GO

----------------------------------------- User table -----------------------------------------------
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'AddNewUser') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE AddNewUser
GO

CREATE PROCEDURE AddNewUser (@AccessFailedCount INT, @ConcurrencyStamp VARCHAR(max), @Email NVARCHAR(256), @FirstName NVARCHAR(100), @Gender NVARCHAR(10), @IsCastingProfessional BIT, @LastName NVARCHAR(100), @LockoutEnabled BIT, @LockoutEnd DATETIME, @Designation NVARCHAR(150), @OrgName NVARCHAR(150), @OrgWebsite NVARCHAR(150), @PasswordHash NVARCHAR(max), @SecurityStamp NVARCHAR(max), @IsTwoFactorEnabled BIT, @UserName NVARCHAR(256))
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

		DECLARE @userId UNIQUEIDENTIFIER;

		SELECT @userId = NEWID();

		INSERT INTO Users (Id, UserName, DisplayName, AccessFailedCount, ConcurrencyStamp, FirstName, Gender, IsCastingProfessional, LastName, LockoutEnabled, LockoutEnd, Designation, OrgName, OrgWebsite, PasswordHash, SecurityStamp, IsTwoFactorEnabled)
		VALUES (@userId, @UserName, @FirstName, @AccessFailedCount, @ConcurrencyStamp, @FirstName, @Gender, @IsCastingProfessional, @LastName, @LockoutEnabled, @LockoutEnd, @Designation, @OrgName, @OrgWebsite, @PasswordHash, @SecurityStamp, @IsTwoFactorEnabled)

		INSERT INTO UserEmails (UserId, Email, EmailConfirmed, IsActive, IsDeleted)
		VALUES (@userId, @Email, 0, 1, 0)

		INSERT INTO UserDetail(UserId)VALUES (@userId) 

		INSERT INTO UserSettings(UserId, ProfileUrl, Visibility, IsCommnetAlowed, IsActive, IsDeleted)
	    VALUES (@userId, NEWID(), 0, 0, 1, 0)

		DECLARE @imageUrl NVARCHAR(200) = (CASE WHEN @Gender ='M' THEN 'assets/css/icons/mail.png' WHEN @Gender ='F' THEN 'assets/css/icons/femail.png' ELSE 'assets/css/icons/other.png' END) 
		INSERT INTO UserImage(Id, UserId, Name, Caption, ImageUrl, DataUrl, ImageType, IsActive, IsDeleted)
	    VALUES (NEWID(), @userId, 'initial image', '', @imageUrl, '', 1, 1, 0)

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateUser') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UpdateUser
GO

CREATE PROCEDURE UpdateUser (@IsActive BIT, @IsDeleted BIT, @AccessFailedCount INT, @ConcurrencyStamp VARCHAR(max), @FirstName NVARCHAR(100), @Gender NVARCHAR(10), @IsCastingProfessional BIT, @LastName NVARCHAR(100), @LockoutEnabled BIT, @LockoutEnd DATETIME, @Designation NVARCHAR(150), @OrgName NVARCHAR(150), @OrgWebsite NVARCHAR(150), @PasswordHash NVARCHAR(max), @SecurityStamp NVARCHAR(max), @IsTwoFactorEnabled BIT, @UserName NVARCHAR(256))
AS
BEGIN
	BEGIN TRY
		UPDATE Users
		SET IsActive = @IsActive, IsDeleted = @IsDeleted, AccessFailedCount = @AccessFailedCount, ConcurrencyStamp = @ConcurrencyStamp, FirstName = @FirstName, Gender = @Gender, IsCastingProfessional = @IsCastingProfessional, LastName = @LastName, LockoutEnabled = @LockoutEnabled, LockoutEnd = @LockoutEnd, Designation = @Designation, OrgName = @OrgName, OrgWebsite = @OrgWebsite, PasswordHash = @PasswordHash, SecurityStamp = @SecurityStamp, IsTwoFactorEnabled = @IsTwoFactorEnabled
		WHERE UserName = @UserName
	END TRY

	BEGIN CATCH
		--INSERT INTO ErrorLog (
		--	ErrorType,
		--	ErrorName,
		--	CustomMesage,
		--	ErrorNumber,
		--	ErrorMessage
		--	)
		--VALUES (
		--	1,
		--	'Select20InterNews',
		--	'Error from Select20InterNews Store Procedure',
		--	ERROR_NUMBER(),
		--	ERROR_MESSAGE()
		--	)
	END CATCH
END
	-------------------------------------------------------------------- End User Table ----------------------------------------------------------------------------------
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateEmail') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UpdateEmail
GO

CREATE PROCEDURE UpdateEmail (@UserId UNIQUEIDENTIFIER, @UserEmail NVARCHAR(256))
AS
BEGIN
	BEGIN TRY
		DECLARE @id UNIQUEIDENTIFIER

		SELECT @id = id
		FROM UserEmails
		WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0

		UPDATE UserEmails
		SET IsActive = 0, IsDeleted = 0
		WHERE id = @id

		INSERT INTO UserEmails (UserId, Email)
		VALUES (@UserId, @UserEmail)
	END TRY

	BEGIN CATCH
	END CATCH
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'ActivateEmail') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE ActivateEmail
GO

CREATE PROCEDURE ActivateEmail (@UserId UNIQUEIDENTIFIER, @UserEmail NVARCHAR(256))
AS
BEGIN
	BEGIN TRY
		UPDATE UserEmails SET EmailConfirmed =1,  IsActive = 1, IsDeleted = 0, DttmModified = getutcdate()  WHERE UserId = @UserId AND Email = @UserEmail
	END TRY

	BEGIN CATCH
	END CATCH
END
GO

-------------------------------------------------------------------- End UpdateEmail ----------------------------------------------------------------------------------
-------------------------------------------------------------------- PhysicalAppreance --------------------------------------------------------------------------------
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'PhysicalAppearanceSaveUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE PhysicalAppearanceSaveUpdate
GO

CREATE PROCEDURE [PhysicalAppearanceSaveUpdate] (@UserId UNIQUEIDENTIFIER, @BodyType AS INT, @Chest AS INT, @EyeColor AS INT, @HairColor AS INT, @HairLength AS INT, @HairType AS INT, @SkinColor AS INT, @Height AS INT, @Weight AS INT, @West AS INT, @Ethnicity NVARCHAR(500))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF (
			EXISTS (
				SELECT TOP 1 Id
				FROM PhysicalAppearance
				WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0
				)
			)
	BEGIN
		UPDATE PhysicalAppearance
		SET BodyType = @BodyType, Chest = @Chest, EyeColor = @EyeColor, HairColor = @HairColor, HairLength = @HairLength, HairType = @HairType, SkinColor = @SkinColor, Height = @Height, [Weight] = @Weight, West = @West, Ethnicity = @Ethnicity, IsActive = 1, IsDeleted = 0, DttmModified = getutcdate()
		WHERE UserId = @UserId
	END
	ELSE
	BEGIN
		INSERT INTO PhysicalAppearance (UserId, BodyType, Chest, EyeColor, HairColor, HairLength, HairType, SkinColor, Height, [Weight], West, Ethnicity, IsActive, IsDeleted)
		VALUES (@UserId, @BodyType, @Chest, @EyeColor, @HairColor, @HairLength, @HairType, @SkinColor, @Height, @Weight, @West, @Ethnicity, 1, 0)
	END
END
GO

-------------------------------------------------------------------- End PhysicalAppreance ----------------------------------------------------------------------------
-------------------------------------------------------------------- Credits --------------------------------------------------------------------------------
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserCreditsSaveUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserCreditsSaveUpdate
GO

CREATE PROCEDURE UserCreditsSaveUpdate (@UserId UNIQUEIDENTIFIER, @Year INT, @WorkPlace NVARCHAR(150), @WorkDetail NVARCHAR(300))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF (
			EXISTS (
				SELECT TOP 1 Id
				FROM UserCredits
				WHERE UserId = @UserId AND [Year] = @Year AND IsActive = 1 AND IsDeleted = 0
				)
			)
	BEGIN
		UPDATE UserCredits
		SET [Year] = @Year, workPlace = @WorkPlace, WorkDetail = @WorkDetail, IsActive = 1, IsDeleted = 0, DttmModified = getutcdate()
		WHERE UserId = @UserId AND [Year] = @Year
	END
	ELSE
	BEGIN
		INSERT INTO UserCredits (UserId, [Year], workPlace, WorkDetail, IsActive, IsDeleted)
		VALUES (@UserId, @Year, @WorkPlace, @WorkDetail, 1, 0)
	END
END
GO

--------------------------------------------------------------------- Dancing -------------------------------------------------
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserDancingStyleClear') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserDancingStyleClear
GO

CREATE PROCEDURE UserDancingStyleClear (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	DECLARE @UserDancingId UNIQUEIDENTIFIER = NULL
	SELECT @UserDancingId = Id FROM UserDancing WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0
	
	IF @UserDancingId IS NOT NULL
	BEGIN
		DELETE FROM  UserDancingStyle WHERE UserDancingId = @UserDancingId
	END
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserDancingStyleSave') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserDancingStyleSave
GO

CREATE PROCEDURE UserDancingStyleSave (@UserId UNIQUEIDENTIFIER, @DancingStyleId BIGINT)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @UserDancingId UNIQUEIDENTIFIER  

	SELECT @UserDancingId = Id FROM	UserDancing WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0
	IF @UserDancingId IS NOT NULL
	BEGIN
		INSERT INTO UserDancingStyle (Id, UserDancingId, DancingStyleId)
		VALUES (newID(), @UserDancingId, @DancingStyleId)
	END
END
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserDancingSaveUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserDancingSaveUpdate
GO
CREATE PROCEDURE UserDancingSaveUpdate (
	@UserId UNIQUEIDENTIFIER, 
	@DanceAbilitiesCode INT = 1, 
	@ChoreographyAbilitiesCode INT =1, 
	@AgentNeedCode INT = 1,
	@IsAttendedSchool BIT = 0, 
	@IsAgent BIT = 0, 
	@Experiance NVARCHAR(2000))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF (EXISTS (SELECT TOP 1 Id	FROM UserDancing WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0))
	BEGIN
		UPDATE UserDancing
		SET DanceAbilitiesCode = @DanceAbilitiesCode, ChoreographyAbilitiesCode = @ChoreographyAbilitiesCode, AgentNeedCode = @AgentNeedCode, IsAttendedSchool = @IsAttendedSchool, IsAgent = @IsAgent, Experiance = @Experiance, DttmModified = getutcdate()
		WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0
	END
	ELSE
	BEGIN
		INSERT INTO UserDancing (Id, UserId, DanceAbilitiesCode, ChoreographyAbilitiesCode, AgentNeedCode, IsAttendedSchool, IsAgent, Experiance, IsActive, IsDeleted, DttmCreated, DttmModified)
		VALUES (NEWID(), @UserId, @DanceAbilitiesCode, @ChoreographyAbilitiesCode, @AgentNeedCode, @IsAttendedSchool, @IsAgent, @Experiance, 1, 0, getutcdate(), getutcdate())
	END
END
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'DancingStyleSelect') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE DancingStyleSelect
GO

CREATE PROCEDURE DancingStyleSelect (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	SELECT DS.Id, DS.Id AS Value, DS.Style, (CASE WHEN  UDS.DancingStyleId IS NULL then 0 else UDS.DancingStyleId END) AS SelectedValue
	FROM DancingStyle DS	
	LEFT JOIN UserDancing UD ON  Ud.IsActive = 1 AND UD.IsDeleted = 0 AND UD.UserId = @UserId
	LEFT JOIN UserDancingStyle UDS ON UDS.DancingStyleId = DS.Id AND UDS.UserDancingId = UD.Id
	WHERE DS.IsActive = 1 AND DS.IsDeleted = 0  order by Style
END
GO

----------------------------------------------------------------------User Acting -----------------------------------------------------------------------
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetUserActingDetail') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE GetUserActingDetail
GO

CREATE PROCEDURE GetUserActingDetail (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	--EXEC GetUserActingDetail 'D40B2C5D-2881-4E8B-844A-B503DEB090BE'
	SELECT UA.Id, UA.UserId, AE.Code AS ActingExperianceCode, AE.Name AS ActingExperiance, AN.Code AS AgentNeedCode, AN.[Type] AS AgentNeed, UA.Experiance, UA.IsActive, UA.IsDeleted, UA.DttmCreated, UA.DttmModified
	FROM UserActing UA
	LEFT JOIN Experience AE ON AE.Code = UA.ActingExperiance AND AE.IsActive = 1 AND AE.IsDeleted = 0 AND ExpTypeCode = 10001
	LEFT JOIN AgentNeed AN ON AN.Code = UA.AgentNeedCode AND AN.IsActive = 1 AND AN.IsDeleted = 0
	WHERE UA.UserId = @UserId AND UA.IsActive = 1 AND UA.IsDeleted = 0

	SELECT LAN.Id, LAN.Code, LAN.CountryCode, LAN.Name, (CASE WHEN LAN.Id = UL.LanguagesId THEN LAN.Code ELSE '' END) AS SelectedLanguageCode
	FROM Languages LAN
	LEFT JOIN UserLanguage UL ON UL.LanguagesId = LAN.Id AND UL.UserId = @UserId
	WHERE LAN.IsActive = 1 AND LAN.IsDeleted = 0

	SELECT ACC.Id, ACC.Code, ACC.Name, ACC.LanguageCode, (CASE WHEN ACC.Id = UACC.AccentsId THEN ACC.Code ELSE '' END) AS SelectedAccent
	FROM Accents ACC
	LEFT JOIN UserAccents UACC ON UACC.AccentsId = ACC.Id AND UACC.UserId = @UserId
	WHERE ACC.IsActive = 1 AND ACC.IsDeleted = 0

    SELECT JOB.Id, JOB.Code, JOB.Name, (CASE WHEN JOB.Id = UJOB.JobId THEN JOB.Code ELSE 0 END) AS SelectedCode
	FROM JobSubGroup JOB
	LEFT JOIN UserActingRoles UJOB ON UJOB.JobId = JOB.Id AND UJOB.UserId = @UserId
	WHERE JOB.IsActive = 1 AND JOB.IsDeleted = 0  AND JOB.JobGroupCode= 1001
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserActingSaveUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserActingSaveUpdate
GO
CREATE PROCEDURE UserActingSaveUpdate (@UserId UNIQUEIDENTIFIER, @ActingExpCode INT, @AgentNeedCode INT, @Experiance NVARCHAR(2000))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF (EXISTS (SELECT TOP 1 Id	FROM UserActing WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0))
	BEGIN
		UPDATE UserActing
		SET ActingExperiance = @ActingExpCode, AgentNeedCode =@AgentNeedCode, Experiance = @Experiance, IsActive = 1, IsDeleted = 0, DttmModified = getutcdate()
		WHERE UserId = @UserId 
	END
	ELSE
	BEGIN
		INSERT INTO UserActing (Id, UserId, ActingExperiance, AgentNeedCode, Experiance, IsActive, IsDeleted)
		VALUES (NEWID(), @UserId, @ActingExpCode, @AgentNeedCode, @Experiance, 1, 0)
	END
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserActingClear') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserActingClear
GO
CREATE PROCEDURE UserActingClear (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DELETE FROM  UserLanguage WHERE UserId = @UserId
	DELETE FROM  UserAccents WHERE UserId = @UserId
	DELETE FROM  UserActingRoles WHERE UserId = @UserId
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserLanguageSave') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserLanguageSave
GO
CREATE PROCEDURE UserLanguageSave (@UserId UNIQUEIDENTIFIER , @LanguageCode NVARCHAR(100))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @LanguageId BIGINT
	SELECT @LanguageId = Id FROM Languages where Code = @LanguageCode

	INSERT INTO UserLanguage(Id, UserId, LanguagesId, DttmCreated, DttmModified)
	VALUES (NEWID(), @UserId, @LanguageId, getutcdate(), getutcdate())
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserAccentSave') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserAccentSave
GO
CREATE PROCEDURE UserAccentSave (@UserId UNIQUEIDENTIFIER , @AccentCode NVARCHAR(100))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @AccentId BIGINT
	SELECT @AccentId = Id FROM Accents where Code = @AccentCode

	INSERT INTO UserAccents(Id, UserId, AccentsId, IsActive, IsDeleted, DttmCreated, DttmModified)
	VALUES (NEWID(), @UserId, @AccentId, 1, 0, getutcdate(), getutcdate())
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserActingRolesSave') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserActingRolesSave
GO
CREATE PROCEDURE UserActingRolesSave (@UserId UNIQUEIDENTIFIER , @JobCode INT)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @Id BIGINT
	SELECT @Id = Id FROM JobSubGroup where Code = @JobCode AND IsActive = 1 AND IsDeleted = 0

	INSERT INTO UserActingRoles(Id, UserId, JobId, DttmCreated, DttmModified)
	VALUES (NEWID(), @UserId, @Id, getutcdate(), getutcdate())
END
GO
------------------------------------------------------ Modeling --------------------------------------------------

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetUserModelingDetail') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE GetUserModelingDetail
GO

CREATE PROCEDURE GetUserModelingDetail (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	--EXEC GetUserModelingDetail 'D40B2C5D-2881-4E8B-844A-B503DEB090BE'
	SELECT UM.Id, UM.UserId, UM.ExpCode, EX.[Name] AS ExpText, AN.Code AS AgentNeedCode, UM.Experiance, UM.Website, EX.IsActive, EX.IsDeleted, EX.DttmCreated, EX.DttmModified	
	FROM UserModeling UM
	LEFT JOIN Experience EX ON EX.Code = UM.ExpCode AND EX.IsActive = 1 AND EX.IsDeleted = 0 AND EX.ExpTypeCode = 10002
	LEFT JOIN AgentNeed AN ON AN.Code = UM.AgentNeedCode AND AN.IsActive = 1 AND AN.IsDeleted = 0
	WHERE UM.UserId = @UserId AND UM.IsActive = 1 AND UM.IsDeleted = 0

	SELECT JSG.Id, JSG.Code, JSG.Name, (CASE WHEN JSG.Id = UMR.JobId THEN JSG.Code ELSE 0 END) AS SelectedCode, JSG.IsActive, JSG.IsDeleted
	FROM JobSubGroup JSG
	LEFT JOIN UserModelingRoles UMR ON UMR.JobId = JSG.Id AND UMR.UserId = @UserId
	WHERE JSG.IsActive = 1 AND JSG.IsDeleted = 0 AND JSG.JobGroupCode = 1002 
	Order by JSG.[Name]
END

GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserModelingSaveUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserModelingSaveUpdate
GO
CREATE PROCEDURE UserModelingSaveUpdate (@UserId UNIQUEIDENTIFIER, @ExpCode INT, @WebSite NVARCHAR(350), @AgentNeedCode INT, @Experiance NVARCHAR(2000))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF (EXISTS (SELECT TOP 1 Id	FROM UserModeling WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0))
	BEGIN
		UPDATE UserModeling
		SET ExpCode = @ExpCode, AgentNeedCode =@AgentNeedCode, WebSite =@WebSite, Experiance = @Experiance, IsActive = 1, IsDeleted = 0, DttmModified = getutcdate()
		WHERE UserId = @UserId 
	END
	ELSE
	BEGIN
		INSERT INTO UserModeling (Id, UserId, ExpCode, AgentNeedCode, WebSite, Experiance, IsActive, IsDeleted)
		VALUES (NEWID(), @UserId, @ExpCode, @AgentNeedCode, @WebSite, @Experiance, 1, 0)
	END
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserModelingClear') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserModelingClear
GO
CREATE PROCEDURE UserModelingClear (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	DELETE FROM  UserModelingRoles WHERE UserId = @UserId
END

GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserModelingRolesSave') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserModelingRolesSave
GO
CREATE PROCEDURE UserModelingRolesSave (@UserId UNIQUEIDENTIFIER , @JobCode INT)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @Id BIGINT
	SELECT @Id = Id FROM JobSubGroup where Code = @JobCode AND IsActive = 1 AND IsDeleted = 0

	INSERT INTO UserModelingRoles(Id, UserId, JobId, DttmCreated, DttmModified)
	VALUES (NEWID(), @UserId, @Id, getutcdate(), getutcdate())
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetUserJobGroup') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE GetUserJobGroup
GO
CREATE PROCEDURE GetUserJobGroup (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	--EXEC GetUserJobGroup 'D40B2C5D-2881-4E8B-844A-B503DEB090BE'
	SELECT JB.Id, JB.Name, JB.Code, JB.DisplayOrder, JB.IsActive, JB.IsDeleted, (CASE WHEN UJB.JobGroupId = JB.Id THEN JB.Code ELSE 0 END) AS SelectedCode
	FROM JobGroup JB
	LEFT JOIN UserJobGroup UJB ON UJB.JobGroupId = JB.Id
		AND UJB.UserId = @UserId
	WHERE JB.IsActive = 1
		AND JB.IsDeleted = 0
	ORDER BY JB.DisplayOrder
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserJobGroupsClear') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserJobGroupsClear
GO	
CREATE PROCEDURE UserJobGroupsClear (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DELETE FROM  UserJobGroup WHERE UserId = @UserId
END

GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserJobGroupSave') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserJobGroupSave
GO
CREATE PROCEDURE UserJobGroupSave (@UserId UNIQUEIDENTIFIER , @JobGroupId BIGINT)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	INSERT INTO UserJobGroup(Id, JobGroupId, UserId, DttmCreated, DttmModified)
	VALUES (NEWID(), @JobGroupId, @UserId, getutcdate(), getutcdate())
END

GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetProfileEditHeader') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE GetProfileEditHeader
GO
--EXEC GetProfileEditHeader 'D40B2C5D-2881-4E8B-844A-B503DEB090BE'
CREATE PROCEDURE GetProfileEditHeader (@UserId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	SELECT U.Id, U.FirstName, U.LastName, U.DisplayName, UA.CityOrTown, UA.StateOrProvince, UA.Country, UP.PhoneNumber, UE.Email, UD.About, UI.ImageUrl, UI.DataUrl, UI.StatusCode, APS.Name AS StatusText
	FROM Users U
	LEFT JOIN UserAddress UA ON UA.UserId = U.Id AND UA.IsActive = 1 AND UA.IsDeleted = 0
	LEFT JOIN UserPhones UP ON UP.UserId = U.Id AND UP.IsActive = 1 AND UP.IsDeleted = 0
	LEFT JOIN UserEmails UE ON UE.UserId = U.Id AND UE.IsActive = 1 AND UE.IsDeleted = 0
	LEFT JOIN UserDetail UD ON UD.UserId = U.Id AND UD.IsActive = 1 AND UD.IsDeleted = 0
	LEFT JOIN UserImage UI ON UI.UserId = U.Id AND UI.IsActive = 1 AND UI.IsDeleted = 0 AND UI.ImageType = 1
	LEFT JOIN ApprovalStatus APS ON APS.Code = UI.StatusCode AND APS.IsActive = 1 AND APS.IsDeleted = 0
	WHERE U.Id = @UserId

	EXEC GetUserJobGroup @UserId
END

GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetProfileHeader') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE GetProfileHeader
GO
--EXEC GetProfileHeader 'D40B2C5D-2881-4E8B-844A-B503DEB090BE'
CREATE PROCEDURE GetProfileHeader (@ProfileUrl NVARCHAR(350))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @UserId UNIQUEIDENTIFIER
	SELECT @UserId = UserId
	FROM UserSettings
	WHERE ProfileUrl = @ProfileUrl AND IsActive = 1 AND IsDeleted = 0

	DECLARE @Gender NVARCHAR(10)
	SELECT @Gender = Gender FROM Users WHERE Id =@UserId

	DECLARE @ImageUrl NVARCHAR(200)	
	SELECT @ImageUrl = (CASE WHEN @Gender ='M' THEN 'assets/css/icons/mail.png' 
							 WHEN @Gender ='F' THEN 'assets/css/icons/femail.png' 
							 ELSE 'assets/css/icons/other.png' END)  

	SELECT U.Id, U.FirstName, U.LastName, U.DisplayName, UA.CityOrTown, UA.StateOrProvince, UA.Country, UP.PhoneNumber, UE.Email, UD.About, 
	CASE WHEN UI.ImageUrl IS NUll OR UI.ImageUrl ='' THEN  @ImageUrl END AS ImageUrl, COALESCE( UI.DataUrl, '') AS DataUrl
	FROM users U
	LEFT JOIN UserAddress UA ON UA.UserId = U.Id AND UA.IsActive = 1 AND UA.IsDeleted = 0
	LEFT JOIN UserPhones UP ON UP.UserId = U.Id AND UP.IsActive = 1 AND UP.IsDeleted = 0
	LEFT JOIN UserEmails UE ON UE.UserId = U.Id AND UE.IsActive = 1 AND UE.IsDeleted = 0
	LEFT JOIN UserDetail UD ON UD.UserId = U.Id AND UD.IsActive = 1 AND UD.IsDeleted = 0
	LEFT JOIN UserImage UI ON UI.UserId = U.Id AND UI.IsActive = 1 AND UI.IsDeleted = 0 AND UI.ImageType = 1 AND UI.StatusCode = 111
	WHERE U.Id = @UserId

	EXEC GetUserJobGroup @UserId
END

GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateUserName') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UpdateUserName
GO
CREATE PROCEDURE UpdateUserName (
	@UserId UNIQUEIDENTIFIER , 
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@OrgName NVARCHAR(150),
	@DisplayName NVARCHAR(200))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	UPDATE Users SET FirstName =@FirstName, LastName = @LastName, OrgName = @OrgName, DisplayName =@DisplayName 
	WHERE	Id =@UserId
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateAboutAndProfileAddress') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UpdateAboutAndProfileAddress
GO

CREATE PROCEDURE UpdateAboutAndProfileAddress (
	@UserId UNIQUEIDENTIFIER , 
	@About NVARCHAR(1500),
	@ProfileAddress NVARCHAR(200))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	UPDATE UserDetail SET About =@About WHERE	UserId = @UserId
	UPDATE UserSettings SET ProfileUrl = @ProfileAddress WHERE	UserId = @UserId
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetProfileUserId') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE GetProfileUserId
GO
CREATE PROCEDURE GetProfileUserId (@ProfileUrl NVARCHAR(350))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	SELECT  UserId
	FROM UserSettings
	WHERE ProfileUrl = @ProfileUrl AND IsActive = 1 AND IsDeleted = 0	
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'InsertOrUpdateAddress') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE InsertOrUpdateAddress
GO

CREATE PROCEDURE InsertOrUpdateAddress (@UserId UNIQUEIDENTIFIER, @AppOrHouseName NVARCHAR(150), @CityOrTown NVARCHAR(100), @Country NVARCHAR(50), @Flat NVARCHAR(50), @LandMark NVARCHAR(200), @LineOne NVARCHAR(200), @LineTwo NVARCHAR(200), @StateOrProvince NVARCHAR(100), @ZipOrPostalCode NVARCHAR(10))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF (NOT EXISTS (SELECT TOP 1 Id FROM UserAddress WHERE UserId = @UserId AND IsActive =1 AND IsDeleted = 0) )
		BEGIN
			INSERT INTO UserAddress(Id, UserId, AppOrHouseName, CityOrTown, Country, Flat, LandMark, LineOne, LineTwo, StateOrProvince, ZipOrPostalCode, IsActive, IsDeleted)
			VALUES(NEWID(), @UserId, @AppOrHouseName, @CityOrTown, @Country, @Flat, @LandMark, @LineOne, @LineTwo, @StateOrProvince, @ZipOrPostalCode, 1, 0)
		END
	ELSE
		BEGIN
			UPDATE UserAddress
			SET AppOrHouseName = @AppOrHouseName, CityOrTown = @CityOrTown, Country = @Country, Flat = @Flat, LandMark = @LandMark, LineOne = @LineOne, LineTwo = @LineTwo, StateOrProvince = @StateOrProvince, ZipOrPostalCode = @ZipOrPostalCode, IsActive = 1, IsDeleted = 0, DttmModified = getutcdate()
			WHERE UserId = @UserId
		END
	END	
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetSettingsByKey') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE GetSettingsByKey
GO
CREATE PROCEDURE GetSettingsByKey (@Key NVARCHAR(350))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;	
	SELECT * FROM SettingsMaster WHERE [Key] = @Key 
END
------------------------------------------------------------------------------------------------------------------------------
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'GetTalentGroup') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE GetTalentGroup
GO
CREATE PROCEDURE GetTalentGroup
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	SELECT JB.Id, JB.Code, JB.Name, JB.Detail, JB.ImageUrl, JB.DisplayOrder, JB.IsActive, JB.IsDeleted, count(UJB.UserId) AS MemberCount
	FROM JobGroup JB
	LEFT JOIN UserJobGroup UJB ON UJB.JobGroupId = JB.Id
	WHERE JB.IsActive = 1
		AND JB.IsDeleted = 0
	GROUP BY JB.Id, JB.Code, JB.Name, JB.Detail, JB.ImageUrl, JB.DisplayOrder, JB.IsActive, JB.IsDeleted
	ORDER BY JB.DisplayOrder
END
GO
-------------------------------------------------------------------Image ------------------------------------------------

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'HeadShotImageSaveUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE HeadShotImageSaveUpdate
GO
CREATE PROCEDURE HeadShotImageSaveUpdate (@UserId UNIQUEIDENTIFIER, @Name NVARCHAR(450), @Caption NVARCHAR(200), @ImageUrl NVARCHAR(1000), @Size BIGINT, @DataUrl NVARCHAR(MAX))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF (EXISTS (SELECT TOP 1 Id  FROM UserImage WHERE UserId = @UserId AND IsActive = 1 AND IsDeleted = 0 AND ImageType = 1))
	BEGIN
		UPDATE UserImage
		SET Name = @Name, Caption = @Caption, ImageUrl = @ImageUrl, Size = @Size, DataUrl = @DataUrl, IsActive = 1, IsDeleted = 0, DttmModified = getutcdate()
		WHERE UserId = @UserId AND ImageType = 1
	END
	ELSE
	BEGIN
		INSERT INTO UserImage (Id, UserId, Name, Caption, ImageUrl, Size, DataUrl, ImageType, IsActive, IsDeleted, StatusCode)
		VALUES (NEWID(), @UserId, @Name, @Caption, @ImageUrl, @Size, @DataUrl, 1, 1, 0, 1)
	END
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserImageSave') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserImageSave
GO
CREATE PROCEDURE UserImageSave (@UserId UNIQUEIDENTIFIER, @Name NVARCHAR(450), @Caption NVARCHAR(200), @ImageUrl NVARCHAR(1000), @Size BIGINT, @DataUrl NVARCHAR(MAX), @ImageType INT)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;	
		INSERT INTO UserImage (Id, UserId, Name, Caption, ImageUrl, Size, DataUrl, ImageType, IsActive, IsDeleted, StatusCode)
		VALUES (NEWID(), @UserId, @Name, @Caption, @ImageUrl, @Size, @DataUrl, @ImageType, 1, 0, 1)
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserImageStatusUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserImageStatusUpdate
GO
CREATE PROCEDURE UserImageStatusUpdate (@ImageId UNIQUEIDENTIFIER, @StatusCode INT, @ApprovalId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
		UPDATE UserImage SET StatusCode = @StatusCode, ApprovalId = @ApprovalId
		WHERE Id = @ImageId 
END
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserImageCaptionUpdate') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserImageCaptionUpdate
GO
CREATE PROCEDURE UserImageCaptionUpdate (@ImageId UNIQUEIDENTIFIER, @Caption NVARCHAR(200))
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
		UPDATE UserImage SET Caption = @Caption	WHERE Id = @ImageId 
END

GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserImageDelete') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UserImageDelete
GO
CREATE PROCEDURE UserImageDelete (@ImageId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ImageType INT
	DECLARE @Gender NVARCHAR(10)	
	DECLARE @ImageUrl NVARCHAR(200)	
	DECLARE @UserId UNIQUEIDENTIFIER

	SELECT @ImageType = ImageType, @UserId = UserId FROM UserImage WHERE Id = @ImageId
	SELECT @Gender = Gender FROM Users WHERE Id = @UserId

	SELECT @ImageUrl = (CASE WHEN @Gender ='M' THEN 'assets/css/icons/mail.png' 
							 WHEN @Gender ='F' THEN 'assets/css/icons/femail.png' 
							 ELSE 'assets/css/icons/other.png' END)  

	IF (@ImageType =1) 
		BEGIN		
			UPDATE UserImage SET ImageUrl =@ImageUrl, DataUrl = NULL WHERE Id = @ImageId 
		END
	ELSE
		BEGIN
			UPDATE UserImage SET IsActive =1, IsDeleted =1	WHERE Id = @ImageId 
		END
END
----------------------------------------------------------End Image ------------------------------------------------------


	


	