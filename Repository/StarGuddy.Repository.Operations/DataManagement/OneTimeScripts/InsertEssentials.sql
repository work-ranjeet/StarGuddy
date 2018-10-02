--Users
--INSERT into Users ( AccessFailedCount, ConcurrencyStamp, Dob, Email, EmailConfirmed, FirstName, Gender, IsCastingProfessional, LastName, LockoutEnabled, LockoutEnd, NormalizedEmail, NormalizedUserName, Designation, OrgName, OrgWebsite, PasswordHash, PhoneNumber, PhoneNumberConfirmed, SecurityStamp, TwoFactorEnabled, UserName)
--VALUES ( 0, N'b8c6e4a2-fb40-4706-b608-f05a4a6ff708', CAST(0x0700000000006D0D0B AS DATETIME2), N'er.ranjeetkumar@gmail.com', 1, N'Ranjeet', N'M', 0, N'Kumar', 0, NULL, N'ER.RANJEETKUMAR@GMAIL.COM', N'ER.RANJEETKUMAR@GMAIL.COM', NULL, NULL, NULL, N'janeman', N'9535304488', 1, N'39d292dc-8713-4f03-9cfb-90784159f854', 0, N'er.ranjeetkumar@gmail.com')
--Users---------------------
INSERT into Users ( AccessFailedCount, ConcurrencyStamp, FirstName, Gender, IsCastingProfessional, LastName, LockoutEnabled, LockoutEnd, Designation, OrgName, OrgWebsite, PasswordHash, SecurityStamp, IsTwoFactorEnabled, UserName)
VALUES ( 0, N'b8c6e4a2-fb40-4706-b608-f05a4a6ff708', N'Ranjeet', N'M', 0, N'Kumar', 0, NULL, NULL, NULL, NULL, N'janeman', N'39d292dc-8713-4f03-9cfb-90784159f854', 0, N'er.ranjeetkumar@gmail.com')

insert into SettingsMaster (id, [key], value, [description]) values (NEWID(), 'send_no_reply_email', 'donotreply@starguddy.com', 'send mail')
insert into SettingsMaster (id, [key], value, [description]) values (NEWID(), 'send_no_reply_email_password', 'dnr_sguddy_1783', 'send mail password')
insert into SettingsMaster (id, [key], value, [description]) values (NEWID(), 'send_no_reply_email_port_number', '25', 'port number')
insert into SettingsMaster (id, [key], value, [description]) values (NEWID(), 'relay-hostimg.secureserver.net', '25', 'host')

INSERT INTO JobGroup (Name, Code, Detail, DisplayOrder) values('Acting', 1001, 'Acting group', 1)
INSERT INTO JobGroup (Name, Code, Detail, DisplayOrder) values('Modeling', 1002, 'Modeling group', 2)
INSERT INTO JobGroup (Name, Code, Detail, DisplayOrder) values('Extras', 1003, 'Extras group', 3)
INSERT INTO JobGroup (Name, Code, Detail, DisplayOrder) values('Presenter', 1004, 'Presenter group', 4)
INSERT INTO JobGroup (Name, Code, Detail, DisplayOrder) values('Musician', 1005, 'Musician group', 5)
INSERT INTO JobGroup (Name, Code, Detail, DisplayOrder) values('Photography', 1006, 'Photography group', 6)
INSERT INTO JobGroup (Name, Code, Detail, DisplayOrder) values('TV & Reality', 1007, 'TV and Reality group', 7)
INSERT INTO JobGroup (Name, Code, Detail, DisplayOrder) values('Dancing', 1008, 'Dancing group', 8)
INSERT INTO JobGroup (Name, Code, Detail, DisplayOrder) values('Film & Stage Crew', 1009, 'Film & Stage Crew group', 9)
INSERT INTO JobGroup (Name, Code, Detail, DisplayOrder) values('Hair, Makeup, & Styling', 1010, 'Hair, Makeup, & Styling group', 10)
INSERT INTO JobGroup (Name, Code, Detail, DisplayOrder) values('Survival Jobs', 1011, 'Survival Jobs group', 11)



INSERT INTO AgentNeed(Code, [Type], [Description]) VALUES (100,'I don''t have an agent', 'No need of agent')
INSERT INTO AgentNeed(Code, [Type], [Description]) VALUES (101,'I want an agent', 'I want an agent')
INSERT INTO AgentNeed(Code, [Type], [Description]) VALUES (102,'I have an agent', 'I have an agent')

INSERT INTO DancingStyle (Style, Detail, DisplayOrder) VALUES('Ballet','Ballet', 1)
INSERT INTO DancingStyle (Style, Detail, DisplayOrder) VALUES('Bollywood','Bollywood', 2)
INSERT INTO DancingStyle (Style, Detail, DisplayOrder) VALUES('Country','Country', 3)
INSERT INTO DancingStyle (Style, Detail, DisplayOrder) VALUES('Hip Hop','Hip Hop', 4)


INSERT INTO ExpertLavel(Code, Lavel, Detail) VALUES (1,'Beginner', 'Beginner')
INSERT INTO ExpertLavel(Code, Lavel, Detail) VALUES (2,'Intermediate', 'Intermediate')
INSERT INTO ExpertLavel(Code, Lavel, Detail) VALUES (3,'Expert', 'Expert')
-------------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO ImageType(Code,Name,[Description]) VALUES(1, 'HeadShotActive', 'Head Shot Active image to show in profile')

---------------------------------------------Experience-----------------------------------------------------------------------------------
----Exp Type-
insert into ExperienceType([Type], Code) values('ModelingExperiance', 10002)
insert into ExperienceType([Type], Code) values('ActingExperiance', 10001)

----Acting
INSERT INTO Experience (Name, Code, ExpTypeCode, Detail, DisplayOrder) values('No previous acting experience',200, 10001, 'No previous acting experience', 1)
INSERT INTO Experience (Name, Code, ExpTypeCode, Detail, DisplayOrder) values('Credits',201, 10001, 'Credits', 2)
INSERT INTO Experience (Name, Code, ExpTypeCode, Detail, DisplayOrder) values('Previous paid speaking roles',202, 10001, 'Previous paid speaking roles', 3)
INSERT INTO Experience (Name, Code, ExpTypeCode, Detail, DisplayOrder) values('Previous unpaid speaking roles',203, 10001, 'Previous unpaid speaking roles', 4)

----Modeling
INSERT INTO Experience (Name, Code, ExpTypeCode, Detail, DisplayOrder) values('Beginner, starting out',300, 10002, 'Beginner, starting out', 1)
INSERT INTO Experience (Name, Code, ExpTypeCode, Detail, DisplayOrder) values('Part-time model - paid commercial work',301, 10002, 'Part-time model - paid commercial work', 2)
INSERT INTO Experience (Name, Code, ExpTypeCode, Detail, DisplayOrder) values('Full-time model - paid commercial work',302, 10002, 'Full-time model - paid commercial work', 3)


---------------------------------------------Acting AuditionsAndJobs--------------------------------------------------------------------
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'Agency Scouts',101,'Acting Agency Scouts', 1)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'Entertainers',102,'Entertainers', 2)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'Events & Promotions',103,'Events & Promotions', 3)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'Feature Films',104,'Feature Films', 4)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'Music videos',105,'Music videos', 5)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'Presenters',106,'Presenters', 6)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'Short Films',107,'Short Films',7)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'Theater & Musicals',108,'Theater & Musicals', 8)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'TV commercials',109,'TV commercials',9)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'TV Series',110,' TV Series', 10)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'Voice-over & Radio',111,'Voice-over & Radio', 11)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'Web',112,'Web', 12)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1001, 'Others',113,'Others', 13)
---------------------------------------------Modeling Roles--------------------------------------------------------------------
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1002, 'Agency Scouts',201,'Modeling Agency Scouts', 1)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1002, 'Entertainers',202,'Entertainers', 2)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1002, 'Events & Promotions',203,'Events & Promotions', 3)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1002, 'Feature Films',204,'Feature Films', 4)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1002, 'Music videos',205,'Music videos', 5)
INSERT INTO JobSubGroup (JobGroupCode, Name, Code, Detail, DisplayOrder) values(1002, 'Presenters',206,'Presenters', 6)


----------------------------------------Languages--------------------------------------------------------------------------------------
INSERT INTO Languages (Name, Code, CountryCode) values('English',1001,'')
INSERT INTO Languages (Name, Code, CountryCode) values('Hindi',1002,'')
INSERT INTO Languages (Name, Code, CountryCode) values('Urdu',1003,'')

--------------------------------------Accents----------------------------------------
INSERT INTO Accents (Name, Code, LanguageCode) values('Indian',2000,'')
INSERT INTO Accents (Name, Code, LanguageCode) values('German',2001,'')
INSERT INTO Accents (Name, Code, LanguageCode) values('French',2002,'')
INSERT INTO Accents (Name, Code, LanguageCode) values('Magahi',2003,'')