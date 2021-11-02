CREATE TABLE [dbo].[SMTPServer] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [SMTPServer]   NVARCHAR (MAX) NULL,
    [Port]         INT            NOT NULL,
    [Host]         NVARCHAR (MAX) NULL,
    [Email]        NVARCHAR (MAX) NULL,
    [Password]     NVARCHAR (MAX) NULL,
    [CreatedBy]    NVARCHAR (MAX) NULL,
    [ModifiedBy]           NVARCHAR (MAX)  NULL,
    [DateCreated]  DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [DateModified] DATETIME2 (7)  NULL,
    [IsActive]     BIT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SMTPServer] PRIMARY KEY CLUSTERED ([Id] ASC)
);

