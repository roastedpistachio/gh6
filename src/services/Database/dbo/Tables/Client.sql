﻿CREATE TABLE [dbo].[Client] (
    [UUID]                            INT           IDENTITY (253000, 1) NOT NULL,
    [FirstName]                       NVARCHAR (50) NULL,
    [MiddleName]                      NVARCHAR (50) NULL,
    [LastName]                        NVARCHAR (50) NULL,
    [NameDataQuality]                 INT           NOT NULL,
    [SocialSecurityNumber]            INT           NULL,
    [SocialSecurityNumberDataQuality] INT           NOT NULL,
    [DateOfBirth]                     DATE          NULL,
    [DateOfBirthDataQuality]          INT           NOT NULL,
    [AmIndAKNative]                   BIT           NOT NULL,
    [Asian]                           BIT           NOT NULL,
    [Black]                           BIT           NOT NULL,
    [NativeHIOtherPacific]            BIT           NOT NULL,
    [White]                           BIT           NOT NULL,
    [RaceNone]                        BIT           NOT NULL,
    [Gender]                          INT           NULL,
    [OtherGender]                     BIT           NOT NULL,
    [VeterenStatus]                   BIT           NULL,
    [YearEnteredService]              INT           NULL,
    [YearSeparated]                   INT           NULL,
    [WorldWarII]                      BIT           NOT NULL,
    [KoreanWar]                       BIT           NOT NULL,
    [VietnamWar]                      BIT           NOT NULL,
    [DesertStorm]                     BIT           NOT NULL,
    [AfghanistanOEF]                  BIT           NOT NULL,
    [IraqOND]                         BIT           NOT NULL,
    [OtherTheater]                    BIT           NOT NULL,
    [MilitaryBranch]                  INT           NULL,
    [DischargeStatus]                 INT           NULL,
    [DateCreated]                     DATETIME      NULL,
    [DateUpdated]                     DATETIME      NULL,
    [UpdatedBy]                       INT           NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([UUID] ASC)
);
