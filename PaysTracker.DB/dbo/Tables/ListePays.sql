CREATE TABLE [dbo].[ListePays] (
    [Nom]        NVARCHAR (450) NOT NULL,
    [RegimeId]   INT            NOT NULL,
    [Dirigeant]  NVARCHAR (MAX) NULL,
    [Surface]    INT            NOT NULL,
    [Population] INT            NOT NULL,
    CONSTRAINT [PK_ListePays] PRIMARY KEY CLUSTERED ([Nom] ASC),
    CONSTRAINT [FK_ListePays_ListeRegimes_RegimeId] FOREIGN KEY ([RegimeId]) REFERENCES [dbo].[ListeRegimes] ([RegimeId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ListePays_RegimeId]
    ON [dbo].[ListePays]([RegimeId] ASC);

