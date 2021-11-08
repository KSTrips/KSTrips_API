CREATE TABLE [dbo].[SubscriptionTypes] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
     [Description]     NVARCHAR (MAX) NULL,
    [QtyAllowedUsers] INT            NOT NULL,
    [DateCreated]     DATETIME2 (7)  NOT NULL,
    [DateModified]    DATETIME2 (7)  NULL,
    [CreatedBy]       NVARCHAR (MAX) NULL,
    [ModifiedBy]           NVARCHAR (MAX)  NULL,
    [IsActive]        BIT            NOT NULL,
   
    CONSTRAINT [PK_SubscriptionTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

