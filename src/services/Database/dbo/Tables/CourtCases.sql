CREATE TABLE [dbo].[CourtCases] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [CaseNumber]      NVARCHAR (100) NOT NULL,
    [Date]            DATE           NOT NULL,
    [InvolvedParties] NVARCHAR (MAX) NOT NULL,
    [CaseType]        NVARCHAR (100) NOT NULL,
    [Processed]       BIT            CONSTRAINT [DF_CourtCases_Processed] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CourtCases] PRIMARY KEY CLUSTERED ([Id] ASC)
);

