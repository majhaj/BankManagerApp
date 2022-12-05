CREATE TABLE [dbo].[BankAccount] (
    [Id]                   INT             IDENTITY (1, 1) NOT NULL,
    [CreationDate]         DATETIME        NOT NULL,
    [CreatorId]            INT             NOT NULL,
    [DeletionDate]         DATETIME        NULL,
    [BankId]               INT             NOT NULL,
    [Number]               NVARCHAR (50)   NOT NULL,
    [Balance]              NUMERIC (18, 2) NOT NULL,
    [Interest]             NUMERIC (18, 2) NOT NULL,
    [OwnerId]              INT             NULL,
    [CurrencyId]           INT             NULL,
    [LastModificationDate] DATETIME        NULL,
    CONSTRAINT [PK_BankAccount] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currency] ([Id]),
    FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_BankAccount_Bank] FOREIGN KEY ([BankId]) REFERENCES [dbo].[Bank] ([Id])
);

