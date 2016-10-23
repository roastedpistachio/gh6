CREATE TABLE [dbo].[HealthAndDV] (
    [HealthAndDVID]          INT  NOT NULL,
    [ProjectEntryID]         INT  NOT NULL,
    [PersonalID]             INT  NOT NULL,
    [InformationDate]        DATE NOT NULL,
    [DomesticViolenceVictim] INT  NOT NULL,
    [WhenOccurred]           INT  NULL,
    [CurrentlyFleeing]       BIT  NULL,
    [GeneralHealthStatus]    INT  NULL,
    [DentalHealthStatus]     INT  NULL,
    [MentalHealthStatus]     INT  NULL,
    [PregnancyStatus]        INT  NULL,
    [DueDate]                DATE NULL,
    [DataCollectionStage]    INT  NULL,
    [DateCreated]            DATE NOT NULL,
    [DateUpdated]            DATE NOT NULL,
    [UpdatedBy]              INT  NOT NULL,
    [DateDeleted]            DATE NULL,
    CONSTRAINT [PK_HealthAndDV] PRIMARY KEY CLUSTERED ([HealthAndDVID] ASC),
    CONSTRAINT [FK_HealthAndDV_Client] FOREIGN KEY ([PersonalID]) REFERENCES [dbo].[Client] ([UUID])
);

