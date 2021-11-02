CREATE TABLE [dbo].[Taxes] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Description]  NVARCHAR (MAX)  NULL,
    [CostTax]      DECIMAL (18, 3) NOT NULL,
    [DateCreated]  DATETIME2 (7)   NOT NULL,
    [DateModified] DATETIME2 (7)   NULL,
    [CreatedBy]    NVARCHAR (MAX)  NULL,
    [ModifiedBy]           NVARCHAR (MAX)  NULL,
    [IsActive]     BIT             NOT NULL,
    [TripDetailId] INT             NULL,
    CONSTRAINT [PK_Taxes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Taxes_TripDetails_TripDetailId] FOREIGN KEY ([TripDetailId]) REFERENCES [dbo].[TripDetails] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Taxes_TripDetailId]
    ON [dbo].[Taxes]([TripDetailId] ASC);

