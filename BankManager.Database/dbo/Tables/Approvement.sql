CREATE TABLE [dbo].[Approvement] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [ApprovementTypeId]    INT          NOT NULL,
    [ApproverId]           INT          NOT NULL,
    [ActionDate]           DATETIME     NULL,
    [Status]               INT          NULL,
    [ActionType]           NUMERIC (18) NULL,
    [CreationDate]         DATETIME     NOT NULL,
    [LastModificationDate] DATETIME     NULL,
    [CreatorId]            INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ApprovementTypeId]) REFERENCES [dbo].[ApprovementType] ([Id]),
    FOREIGN KEY ([ApproverId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([CreatorId]) REFERENCES [dbo].[Users] ([Id])
);

