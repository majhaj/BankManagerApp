CREATE TABLE [dbo].[Notifications] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [NotifiedByApp]        BIT           NULL,
    [NotifiedByService]    BIT           NULL,
    [Description]          NVARCHAR (50) NOT NULL,
    [CreatorId]            INT           NOT NULL,
    [CreationDate]         DATETIME      NOT NULL,
    [UserToNotifyId]       INT           NOT NULL,
    [LastModificationDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserToNotifyId]) REFERENCES [dbo].[Users] ([Id])
);

