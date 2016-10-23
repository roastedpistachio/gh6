CREATE TABLE [dbo].[RiskNotes]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[RiskId] INT NOT NULL,
    [Author] NVARCHAR(250) NOT NULL, 
    [Message] NVARCHAR(MAX) NOT NULL, 
    [CreatedDate] DATETIME NOT NULL,
	CONSTRAINT [PK_RiskNotes] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_RiskNotes_IncomingRiskFactors] FOREIGN KEY ([RiskId]) REFERENCES [dbo].[IncomingRiskFactors] ([Id])
)
