CREATE TABLE [dbo].[ConsumptionItems] (
    [ConItemId]   INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Consumption] FLOAT (53)     NOT NULL,
    [ProsumerId]  INT            NOT NULL,
    CONSTRAINT [PK_dbo.ConsumptionItems] PRIMARY KEY CLUSTERED ([ConItemId] ASC),
    CONSTRAINT [FK_dbo.ConsumptionItems_dbo.Prosumers_ProsumerId] FOREIGN KEY ([ProsumerId]) REFERENCES [dbo].[Prosumers] ([ProsumerId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProsumerId]
    ON [dbo].[ConsumptionItems]([ProsumerId] ASC);

