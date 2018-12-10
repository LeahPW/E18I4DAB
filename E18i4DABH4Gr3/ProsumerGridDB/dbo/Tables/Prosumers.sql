CREATE TABLE [dbo].[Prosumers] (
    [ProsumerId]   INT            IDENTITY (1, 1) NOT NULL,
    [Type]         NVARCHAR (MAX) NOT NULL,
    [Address]      NVARCHAR (MAX) NOT NULL,
    [SmartMeterId] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Prosumers] PRIMARY KEY CLUSTERED ([ProsumerId] ASC),
    CONSTRAINT [FK_dbo.Prosumers_dbo.SmartMeters_SmartMeterId] FOREIGN KEY ([SmartMeterId]) REFERENCES [dbo].[SmartMeters] ([SmartMeterId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SmartMeterId]
    ON [dbo].[Prosumers]([SmartMeterId] ASC);

