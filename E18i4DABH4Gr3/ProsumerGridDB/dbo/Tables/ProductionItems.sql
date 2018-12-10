CREATE TABLE [dbo].[ProductionItems] (
    [ProItemId]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [Production] FLOAT (53)     NOT NULL,
    [ProsumerId] INT            NOT NULL,
    CONSTRAINT [PK_dbo.ProductionItems] PRIMARY KEY CLUSTERED ([ProItemId] ASC),
    CONSTRAINT [FK_dbo.ProductionItems_dbo.Prosumers_ProsumerId] FOREIGN KEY ([ProsumerId]) REFERENCES [dbo].[Prosumers] ([ProsumerId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProsumerId]
    ON [dbo].[ProductionItems]([ProsumerId] ASC);

