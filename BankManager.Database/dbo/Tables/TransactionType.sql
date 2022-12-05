CREATE TABLE [dbo].[TransactionType] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (50) NOT NULL,
    [CreationDate]         DATETIME      NOT NULL,
    [CreatorId]            INT           NULL,
    [Code]                 INT           NULL,
    [LastModificationDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CreatorId]) REFERENCES [dbo].[Users] ([Id])
);

