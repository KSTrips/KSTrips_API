CREATE TABLE [dbo].[ErrorLog]
(
	[Id]			  INT IDENTITY (1, 1) NOT NULL,
	[Message]	      NVARCHAR (MAX)  NULL,
	[Exception]       NVARCHAR (MAX)  NULL,
	[Module]		  NVARCHAR(MAX) NULL,
	[CreatedBy]       NVARCHAR (MAX)  NULL,
	[ModifiedBy]           NVARCHAR (MAX)  NULL,
	[DateCreated]     DATETIME2 (7)   DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
	[DateModified]    DATETIME2 (7)   NULL,
)
