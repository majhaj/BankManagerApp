CREATE TABLE [dbo].[AccountTransactionApprovement] (
    [TransactionId] INT NOT NULL,
    [ApprovementId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([TransactionId] ASC, [ApprovementId] ASC),
    FOREIGN KEY ([ApprovementId]) REFERENCES [dbo].[Approvement] ([Id]),
    FOREIGN KEY ([TransactionId]) REFERENCES [dbo].[AccountTransaction] ([Id])
);

