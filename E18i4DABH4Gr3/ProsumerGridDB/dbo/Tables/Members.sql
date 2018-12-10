CREATE TABLE [dbo].[Members] (
    [MemberId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Members] PRIMARY KEY CLUSTERED ([MemberId] ASC)
);

