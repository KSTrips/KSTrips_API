CREATE TABLE [dbo].[Providers] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [DateCreated]  DATETIME2 (7)  NOT NULL,
    [DateModified] DATETIME2 (7)  NULL,
    [CreatedBy]    NVARCHAR (MAX) NULL,
    [ModifiedBy]           NVARCHAR (MAX)  NULL,
    [IsActive]     BIT            NOT NULL,
    CONSTRAINT [PK_Providers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

