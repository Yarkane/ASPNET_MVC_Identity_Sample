CREATE TABLE [dbo].[ListeRegimes] (
    [RegimeId] INT            IDENTITY (1, 1) NOT NULL,
    [Nom]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ListeRegimes] PRIMARY KEY CLUSTERED ([RegimeId] ASC)
);

