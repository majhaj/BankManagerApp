CREATE TABLE [dbo].[Bank] (
    [Id]                   INT           NOT NULL,
    [Name]                 NVARCHAR (50) NOT NULL,
    [Bic]                  NCHAR (50)    NULL,
    [CreationDate]         DATETIME      NULL,
    [LastModificationDate] DATETIME      NULL,
    CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED ([Id] ASC)
);

