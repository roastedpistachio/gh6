CREATE TABLE [dbo].[Funder] (
    [FunderID]    INT  NOT NULL,
    [ProjectID]   INT  NOT NULL,
    [Funder]      INT  NOT NULL,
    [GrandID]     INT  NULL,
    [StartDate]   DATE NOT NULL,
    [EndDate]     DATE NOT NULL,
    [DateCreated] DATE NOT NULL,
    [DateUpdated] DATE NOT NULL,
    [UpdatedBy]   INT  NOT NULL,
    [DateDeleted] DATE NULL,
    CONSTRAINT [PK_Funder] PRIMARY KEY CLUSTERED ([FunderID] ASC)
);

