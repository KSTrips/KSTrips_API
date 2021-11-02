CREATE TABLE [dbo].[UserRoles] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [UserId]       INT            NOT NULL,
    [RoleId]       INT            NOT NULL,
    [CreatedBy]    NVARCHAR (MAX) NULL,
    [ModifiedBy]           NVARCHAR (MAX)  NULL,
    [DateCreated]  DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [DateModified] DATETIME2 (7)  NULL,
    [IsActive]     BIT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

