CREATE TABLE [dbo].[Users] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]            NVARCHAR (50) NOT NULL,
    [LastName]             NVARCHAR (50) NOT NULL,
    [Email]                NVARCHAR (50) NOT NULL,
    [Birthday]             DATETIME      NOT NULL,
    [IsContractor]         BIT           NULL,
    [CreationDate]         DATETIME      NOT NULL,
    [LastModificationDate] DATETIME      NULL,
    [DeletionDate]         DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

