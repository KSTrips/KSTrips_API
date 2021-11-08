CREATE TABLE [dbo].[Users] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [UserName]             NVARCHAR (MAX) NULL,
    [Name]                 NVARCHAR (MAX) NULL,
    [Email]                NVARCHAR (MAX) NULL,
    [DateInitial]          DATETIME2 (7)  NULL,
    [DateUse]              DATETIME2 (7)  NULL,
    [Provider]             NVARCHAR (MAX) NULL,
    [NotificationDays]     INT            DEFAULT ((0)) NOT NULL,
    [DateEndSubscription]  DATETIME2 (7)  NULL,
    [DateInitSubscription] DATETIME2 (7)  NULL,
    [SubscriptionTypeId]   INT            NULL,
    [DateforPay]           DATETIME2 (7)  NULL,
    [DateCreated]          DATETIME2 (7)  NOT NULL,
    [DateModified]         DATETIME2 (7)  NULL,
    [CreatedBy]            NVARCHAR (MAX) NULL,
    [ModifiedBy]           NVARCHAR (MAX)  NULL,
    [IsActive]             BIT            NOT NULL,
    
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_SubscriptionTypes_SubscriptionTypeId] FOREIGN KEY ([SubscriptionTypeId]) REFERENCES [dbo].[SubscriptionTypes] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_SubscriptionTypeId]
    ON [dbo].[Users]([SubscriptionTypeId] ASC);

