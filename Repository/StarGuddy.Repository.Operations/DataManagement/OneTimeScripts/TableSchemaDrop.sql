IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserImage') AND type IN (N'U')
		)
	DROP TABLE UserImage
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'ImageType') AND type IN (N'U')
		)
	DROP TABLE ImageType
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserJobGroup') AND type IN (N'U')
		)
	DROP TABLE UserJobGroup
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'JobSubGroup') AND type IN (N'U')
		)
	DROP TABLE JobSubGroup
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'JobGroup') AND type IN (N'U')
		)
	DROP TABLE JobGroup

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserModelingRoles') AND type IN (N'U')
		)
	DROP TABLE UserModelingRoles
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserActing') AND type IN (N'U')
		)
	DROP TABLE UserActing
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserActingRoles') AND type IN (N'U')
		)
	DROP TABLE UserActingRoles
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Experience') AND type IN (N'U')
		)
	DROP TABLE Experience
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserDancingStyle') AND type IN (N'U')
		)
	DROP TABLE UserDancingStyle
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserDancing') AND type IN (N'U')
		)
	DROP TABLE UserDancing
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'ExpertLavel') AND type IN (N'U')
		)
	DROP TABLE ExpertLavel
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'AgentNeed') AND type IN (N'U')
		)
	DROP TABLE AgentNeed
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'DancingStyle') AND type IN (N'U')
		)
	DROP TABLE DancingStyle
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserCredits') AND type IN (N'U')
		)
	DROP TABLE UserCredits
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserSettings') AND type IN (N'U')
		)
	DROP TABLE UserSettings
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserEmails') AND type IN (N'U')
		)
	DROP TABLE UserEmails
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserPhones') AND type IN (N'U')
		)
	DROP TABLE UserPhones
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserSocialAddress') AND type IN (N'U')
		)
	DROP TABLE UserSocialAddress
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SocialAddress') AND type IN (N'U')
		)
	DROP TABLE SocialAddress
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserLanguage') AND type IN (N'U')
		)
	DROP TABLE UserLanguage
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Languages') AND type IN (N'U')
		)
	DROP TABLE Languages
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserAccents') AND type IN (N'U')
		)
	DROP TABLE UserAccents
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Accents') AND type IN (N'U')
		)
	DROP TABLE Accents
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'PhysicalAppearance') AND type IN (N'U')
		)
	DROP TABLE PhysicalAppearance
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserDetail') AND type IN (N'U')
		)
	DROP TABLE UserDetail
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserAddress') AND type IN (N'U')
		)
	DROP TABLE UserAddress
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserModeling') AND type IN (N'U')
		)
	DROP TABLE UserModeling
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'ExperienceType') AND type IN (N'U')
		)
	DROP TABLE ExperienceType
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Users') AND type IN (N'U')
		)
	DROP TABLE Users
GO

