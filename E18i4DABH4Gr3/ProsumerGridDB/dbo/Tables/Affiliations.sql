CREATE TABLE [dbo].[Affiliations] (
    [AffiliationId] INT IDENTITY (1, 1) NOT NULL,
    [MemberId]      INT NOT NULL,
    [ProsumerId]    INT NOT NULL,
    CONSTRAINT [PK_dbo.Affiliations] PRIMARY KEY CLUSTERED ([AffiliationId] ASC),
    CONSTRAINT [FK_dbo.Affiliations_dbo.Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Members] ([MemberId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Affiliations_dbo.Prosumers_ProsumerId] FOREIGN KEY ([ProsumerId]) REFERENCES [dbo].[Prosumers] ([ProsumerId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_MemberId]
    ON [dbo].[Affiliations]([MemberId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProsumerId]
    ON [dbo].[Affiliations]([ProsumerId] ASC);

