CREATE TABLE [dbo].[SmartMeters] (
    [SmartMeterId] INT            IDENTITY (1, 1) NOT NULL,
    [IpAddress]    NVARCHAR (MAX) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.SmartMeters] PRIMARY KEY CLUSTERED ([SmartMeterId] ASC)
);

