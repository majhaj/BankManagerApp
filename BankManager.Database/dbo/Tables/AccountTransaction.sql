CREATE TABLE [dbo].[AccountTransaction] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [AccountId]            INT          NULL,
    [TransactionTypeId]    INT          NULL,
    [Amount]               NUMERIC (18) NOT NULL,
    [CreationDate]         DATETIME     NOT NULL,
    [CreatorId]            INT          NULL,
    [FromAccountId]        INT          NULL,
    [ToAccountId]          INT          NULL,
    [LastModificationDate] DATETIME     NULL,
    [DeletionDate]         DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AccountId]) REFERENCES [dbo].[BankAccount] ([Id]),
    FOREIGN KEY ([CreatorId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([TransactionTypeId]) REFERENCES [dbo].[TransactionType] ([Id])
);

