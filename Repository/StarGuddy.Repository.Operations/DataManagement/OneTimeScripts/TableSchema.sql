
CREATE TABLE Users (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),	
	UserName NVARCHAR(256) UNIQUE NULL,	
	DisplayName NVARCHAR(256) NULL,	
	AccessFailedCount INT NOT NULL,
	ConcurrencyStamp NVARCHAR(max) NULL,	
	FirstName NVARCHAR(100) NULL,
	Gender NVARCHAR(10) NULL,
	LastName NVARCHAR(100) NULL,
	LockoutEnabled BIT NOT NULL,
	LockoutEnd DATETIMEOFFSET(7) NULL,
	Designation NVARCHAR(150) NULL,
	OrgName NVARCHAR(150) NULL,
	OrgWebsite NVARCHAR(150) NULL,
	PasswordHash NVARCHAR(max) NULL,
	SecurityStamp NVARCHAR(max) NULL,
	IsCastingProfessional BIT NOT NULL,
	IsActive BIT NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	DttmModified DATETIME NOT NULL DEFAULT(GETUTCDATE())
	)

Go
create table UserEmails
(
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
	UserId UNIQUEIDENTIFIER NOT NULL,
	Email NVARCHAR(256) NULL,
	EmailConfirmed BIT NOT NULL DEFAULT(0),	
	IsActive BIT NOT NULL DEFAULT(0),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	DttmModified DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
)
Go
create table UserPhones
(
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
	UserId UNIQUEIDENTIFIER NOT NULL,	
	PhoneNumber NVARCHAR(15) NOT NULL,
	PhoneNumberConfirmed BIT NOT NULL DEFAULT(0),
	TwoFactorCode INT,
	IsActive BIT NOT NULL DEFAULT(0),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	DttmModified DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
)

GO

CREATE TABLE UserAddress (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
	UserId UNIQUEIDENTIFIER UNIQUE NOT NULL,
	AppOrHouseName NVARCHAR(150) NULL,
	CityOrTown NVARCHAR(100) NOT NULL,
	Country NVARCHAR(50) NOT NULL,
	Flat NVARCHAR(50) NULL,
	LandMark NVARCHAR(200) NULL,
	LineOne NVARCHAR(200) NULL,
	LineTwo NVARCHAR(200) NULL,
	StateOrProvince NVARCHAR(100) NOT NULL,
	ZipOrPostalCode NVARCHAR(10) NOT NULL,			
	IsActive BIT NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	DttmModified DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
	)

GO
CREATE TABLE UserDetail (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),	
	UserId UNIQUEIDENTIFIER UNIQUE NOT NULL,	
	About NVARCHAR(1500) NULL,
	Age INT NULL,
	BloodGroup INT NULL,
	DateOfBirth DATETIME2(7) NULL,
	Disability NVARCHAR(max) NULL,
	HealthInfo NVARCHAR(200) NULL,
	MaritalStatus INT NULL,
	MotherTongue NVARCHAR(100) NULL,
	Nickname NVARCHAR(200) NULL,
	Religion NVARCHAR(100) NULL,
	IsActive BIT NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	DttmModified DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
	)
GO
CREATE TABLE PhysicalAppearance (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),	
	UserId UNIQUEIDENTIFIER NOT NULL,
	BodyType INT NOT NULL,
	Chest INT NOT NULL,
	EyeColor INT NOT NULL,
	HairColor INT NOT NULL,
	HairLength INT NOT NULL,
	HairType INT NOT NULL,
	SkinColor INT NOT NULL,
	Height INT NOT NULL,
	[Weight] INT NOT NULL,
	West INT NOT NULL,
	Ethnicity NVARCHAR(500),
	IsActive BIT NOT NULL DEFAULT(0),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2(7) NOT NULL  DEFAULT(GETUTCDATE()),
	DttmModified DATETIME2(7) NOT NULL  DEFAULT(GETUTCDATE()),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
	)
GO

CREATE TABLE Accents (
	Id BIGINT PRIMARY KEY NOT NULL IDENTITY(1, 1),	
	Name NVARCHAR(50) NULL,
	Code NVARCHAR(100) NULL,
	LanguageCode NVARCHAR(100) NULL,
	IsActive BIT NOT NULL DEFAULT(0),
	IsDeleted BIT NOT NULL DEFAULT(0)
	)
GO

CREATE TABLE UserAccents (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),	
	UserId UNIQUEIDENTIFIER NOT NULL,	
	AccentsId BIGINT NOT NULL,
	IsActive BIT NOT NULL DEFAULT(0),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	DttmModified DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	FOREIGN KEY (AccentsId) REFERENCES Accents(Id)
	)
GO


CREATE TABLE Languages (
	Id BIGINT PRIMARY KEY NOT NULL IDENTITY(1, 1),	
	[Name] NVARCHAR(50) NULL,
	Code NVARCHAR(100) NULL,
	CountryCode NVARCHAR(100) NULL,
	IsActive BIT NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0)
	)
GO

CREATE TABLE UserLanguage (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
	UserId UNIQUEIDENTIFIER NOT NULL,
	LanguagesId BIGINT NOT NULL,
	DttmCreated DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	DttmModified DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (LanguagesId) REFERENCES Languages(Id)
	)
GO
CREATE TABLE SocialAddress (
	Id BIGINT PRIMARY KEY NOT NULL IDENTITY(1, 1),	
	HelpUrl NVARCHAR(200) NULL,
	IconClass NVARCHAR(100) NULL,
	PostLabel NVARCHAR(200) NULL,
	PostUrl NVARCHAR(200) NULL,
	PreUrl NVARCHAR(200) NULL,
	SocialName NVARCHAR(200) NULL,
	[Status] INT NOT NULL,
	IsActive BIT NOT NULL DEFAULT(0),
	IsDeleted BIT NOT NULL DEFAULT(0)
	)
GO

CREATE TABLE UserSocialAddress (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
	UserId UNIQUEIDENTIFIER NOT NULL,
	SocialAddressId BIGINT NOT NULL,
	SocialUserName NVARCHAR(200) NULL,
	[Status] INT NOT NULL,
	IsActive BIT NOT NULL DEFAULT(0),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	DttmModified DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	FOREIGN KEY (SocialAddressId) REFERENCES SocialAddress(Id)
	)
GO

CREATE TABLE UserSettings (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
	UserId UNIQUEIDENTIFIER NOT NULL,
	Visibility INT NOT NULL,
	ProfileUrl NVARCHAR(450) UNIQUE NOT NULL,
	IsCommnetAlowed INT NOT NUll DEFAULT(1),
	IsActive BIT NOT NULL DEFAULT(0),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	DttmModified DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
	)
GO

CREATE TABLE UserCredits (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
	UserId UNIQUEIDENTIFIER NOT NULL,
	[Year] INT NOT NULL,
	WorkPlace NVARCHAR(150) NOT NULL,
	WorkDetail NVARCHAR(300) NOT NULL,
	IsActive BIT NOT NULL DEFAULT(0),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	DttmModified DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
	)
GO

CREATE TABLE DancingStyle(
	Id BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Style nvarchar(250) NOT NULL,
	Detail NVARCHAR(500) NULL,
	DisplayOrder int not null,
	IsActive BIT NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate())
)

GO
CREATE TABLE AgentNeed(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Code INT UNIQUE NOT NULL,
	[Type] NVARCHAR (250) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	IsActive bit NOT NULL DEFAULT(1),
	IsDeleted bit NOT NULL DEFAULT(0),
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate())
	)

GO
CREATE TABLE ExpertLavel(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Code INT UNIQUE NOT NULL,
	Lavel nvarchar(250) NOT NULL,
	Detail NVARCHAR(500) NULL,
	IsActive bit NOT NULL DEFAULT(1),
	IsDeleted bit NOT NULL DEFAULT(0),
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate())
)

GO
CREATE TABLE UserDancing(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	UserId UNIQUEIDENTIFIER NOT NULL,
	DanceAbilitiesCode INT NOT NULL,	
	ChoreographyAbilitiesCode INT NOT NULL,
	AgentNeedCode INT NOT NULL,
	IsAttendedSchool BIT NOT NULL DEFAULT(0),
	IsAgent BIT NOT NULL DEFAULT(0),	
	Experiance NVARCHAR(2000) NULL,
	IsActive bit NOT NULL DEFAULT(1),
	IsDeleted bit NOT NULL DEFAULT(0),
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate()),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
)

go
CREATE TABLE UserDancingStyle(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	UserDancingId UNIQUEIDENTIFIER NOT NULL,
	DancingStyleId BIGINT NOT NULL,
	FOREIGN KEY (UserDancingId) REFERENCES UserDancing(Id),
	FOREIGN KEY (DancingStyleId) REFERENCES DancingStyle(Id),
)
Go
CREATE TABLE JobGroup
(
	Id BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(300) NOT NULL,
	Code INT NOT NULL,
	Detail NVARCHAR(500) NULL,
	DisplayOrder int NOT null,
	ImageUrl nvarchar(350) null,
	IsActive BIT NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate())
)
GO
CREATE TABLE JobSubGroup
(
	Id BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	JobGroupCode INT NOT NULL,
	[Name] NVARCHAR(250) NOT NULL,
	Code INT NOT NULL,
	Detail NVARCHAR(500) NULL,
	DisplayOrder int not null,
	IsActive BIT NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate())
)
GO
CREATE TABLE UserJobGroup(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	JobGroupId BIGINT NOT NULL,
	UserId UNIQUEIDENTIFIER NOT NULL,
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate()),
	FOREIGN KEY (JobGroupId) REFERENCES JobGroup(Id),
	FOREIGN KEY (UserId) REFERENCES Users(Id),
)
GO

CREATE TABLE UserActingRoles(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	JobId BIGINT NOT NULL,
	UserId UNIQUEIDENTIFIER NOT NULL,
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate()),
	FOREIGN KEY (JobId) REFERENCES JobSubGroup(Id),
	FOREIGN KEY (UserId) REFERENCES Users(Id),
)

GO
CREATE TABLE ExperienceType
(
	Id BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Type] nvarchar(250) NOT NULL,
	Code int NOT NULL,
	Detail NVARCHAR(150),
	IsActive BIT NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate())
)
GO
CREATE TABLE Experience
(
	Id BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] nvarchar(250) NOT NULL,
	Code int NOT NULL,
	ExpTypeCode INT NOT NULL,
	Detail NVARCHAR(500) NULL,
	DisplayOrder int not null,
	IsActive BIT NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate())
)
GO
CREATE TABLE UserActing(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	UserId UNIQUEIDENTIFIER NOT NULL,
	ActingExperiance int NOT NUll,
	AgentNeedCode INT NOT NULL,	
	Experiance NVARCHAR(2000) NULL,
	IsActive bit NOT NULL DEFAULT(1),
	IsDeleted bit NOT NULL DEFAULT(0),
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate()),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
)
GO
CREATE TABLE UserModelingRoles(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	JobId BIGINT NOT NULL,
	UserId UNIQUEIDENTIFIER NOT NULL,
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate()),
	FOREIGN KEY (JobId) REFERENCES JobSubGroup(Id),
	FOREIGN KEY (UserId) REFERENCES Users(Id),
)
GO
CREATE TABLE UserModeling(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	UserId UNIQUEIDENTIFIER NOT NULL,
	ExpCode int NOT NUll,
	AgentNeedCode INT NOT NULL,	
	WebSite NVARCHAR(350), 
	Experiance NVARCHAR(2000) NULL,
	IsActive bit NOT NULL DEFAULT(1),
	IsDeleted bit NOT NULL DEFAULT(0),
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate()),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
)
GO
CREATE TABLE ImageType(
	Code INT PRIMARY KEY NOT NULL, 
	Name NVARCHAR(250) NOT NUll,	
	[Description] NVARCHAR(1000) NULL,
	IsActive bit NOT NULL DEFAULT(1),
	IsDeleted bit NOT NULL DEFAULT(0),
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate()),
)
GO
CREATE TABLE ApprovalStatus(
	Code INT PRIMARY KEY NOT NULL, 
	Name NVARCHAR(250) NOT NUll,	
	[Description] NVARCHAR(1000) NULL,
	IsActive bit NOT NULL DEFAULT(1),
	IsDeleted bit NOT NULL DEFAULT(0)
)
GO
CREATE TABLE UserImage(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	UserId UNIQUEIDENTIFIER NOT NULL,
	Name NVARCHAR(450) NOT NUll,
	Caption NVARCHAR(200), 
	ImageUrl NVARCHAR(1000) NULL,
	Size BIGINT NULL,
	DataUrl NVARCHAR(MAX) NULL,
	ImageType INT NOT NUll,
	IsActive bit NOT NULL DEFAULT(1),
	IsDeleted bit NOT NULL DEFAULT(0),
	StatusCode int NOT NULL DEFAULT(1),
	ApprovalId UNIQUEIDENTIFIER NULL,
	DttmCreated DATETIME2 DEFAULT (getutcdate()),
	DttmModified DATETIME2 DEFAULT (getutcdate()),
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	FOREIGN KEY (ApprovalId) REFERENCES Users(Id),
	FOREIGN KEY (StatusCode) REFERENCES ApprovalStatus(Code),
	FOREIGN KEY (ImageType) REFERENCES ImageType(Code)
)


GO
CREATE TABLE SettingsMaster (
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Key] NVARCHAR(350) UNIQUE NOT NULL,
	[Value] NVARCHAR(350) NOT NULL,
	[Description] NVARCHAR(400),
	DttmCreated DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	DttmModified DATETIME NOT NULL DEFAULT(GETUTCDATE())
)
