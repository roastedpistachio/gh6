CREATE TABLE [dbo].[EmploymentEducation] (
    [EmploymentEducationID] INT            NOT NULL,
    [ProjectEntryID]        INT            NOT NULL,
    [PersonalID]            INT            NOT NULL,
    [InformationDate]       DATETIME       NOT NULL,
    [LastGradeCompleted]    NVARCHAR (50)  NULL,
    [SchoolStatus]          INT            NULL,
    [Employed]              INT            NOT NULL,
    [EmploymentType]        INT            NULL,
    [NotEmployedReason]     NVARCHAR (250) NULL,
    [DataCollectionStage]   INT            NOT NULL,
    [DateCreated]           DATETIME       NOT NULL,
    [DateUpdated]           DATETIME       NOT NULL,
    [UpdatedBy]             INT            NOT NULL,
    [DateDeleted]           DATETIME       NULL,
    CONSTRAINT [PK_EmploymentEducation] PRIMARY KEY CLUSTERED ([EmploymentEducationID] ASC),
    CONSTRAINT [FK_EmploymentEducation_Client] FOREIGN KEY ([PersonalID]) REFERENCES [dbo].[Client] ([UUID])
);

