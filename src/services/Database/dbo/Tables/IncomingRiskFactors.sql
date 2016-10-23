﻿CREATE TABLE [dbo].[IncomingRiskFactors]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [FirstName] NVARCHAR(250) NULL, 
    [LastName] NVARCHAR(250) NULL, 
    [Address] NVARCHAR(500) NULL, 
    [City] NVARCHAR(250) NULL, 
    [State] NVARCHAR(150) NULL,
	[Zip] NVARCHAR(6) NULL,
	[YearOfBirth] INT NULL,
    [Details] NVARCHAR(MAX) NULL, 
    [Processed] BIT NULL, 
    [RiskType] NVARCHAR(250) NULL,
	[RiskRating] INT NULL,
	[CaseWorkerId] INT NULL,
	[CaseStatus] NVARCHAR (250) NULL,
	[CaseOverview] NVARCHAR(MAX) NULL,
	[Contacted] BIT NULL,
	[InformationObtained] BIT NULL,
	[HelpRequired] BIT NULL,
	[CreatedDate] DATETIME,
	[UpdatedDate] DATETIME,
	CONSTRAINT [PK_IncomingRiskFactors] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_IncomingRiskFactors_CaseWorkers] FOREIGN KEY ([CaseWorkerId]) REFERENCES [dbo].[CaseWorkers] ([Id])
)