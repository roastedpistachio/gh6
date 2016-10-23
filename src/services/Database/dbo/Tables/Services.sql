CREATE TABLE [dbo].[Services] (
    [ServicesID]        INT             NOT NULL,
    [ProjectEntryID]    INT             NOT NULL,
    [PersonalID]        INT             NOT NULL,
    [DateProvided]      DATE            NOT NULL,
    [RecordType]        INT             NOT NULL,
    [TypeProvided]      INT             NOT NULL,
    [OtherTypeProvided] INT             NULL,
    [SubTypeProvided]   INT             NULL,
    [FAAmount]          DECIMAL (16, 2) NULL,
    [ReferralOutcome]   NVARCHAR (50)   NULL,
    [DateCreated]       DATE            NOT NULL,
    [DateUpdated]       DATE            NOT NULL,
    [UpdatedBy]         INT             NOT NULL,
    [DateDeleted]       DATE            NULL,
    CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED ([ServicesID] ASC),
    CONSTRAINT [FK_Services_Client] FOREIGN KEY ([PersonalID]) REFERENCES [dbo].[Client] ([UUID])
);

