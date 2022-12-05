CREATE TABLE [dbo].[ApprovementType] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (50) NOT NULL,
    [Code]                 INT           NULL,
    [CreationDate]         DATETIME      NOT NULL,
    [LastModificationDate] DATETIME      NULL,
    [CreatorId]            INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CreatorId]) REFERENCES [dbo].[Users] ([Id])
);

