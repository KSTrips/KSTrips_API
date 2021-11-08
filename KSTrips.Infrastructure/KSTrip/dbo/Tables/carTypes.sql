CREATE TABLE [dbo].[carTypes] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [CarCategoryId] INT            NOT NULL,
    [DateCreated]   DATETIME2 (7)  NOT NULL,
    [DateModified]  DATETIME2 (7)  NULL,
    [CreatedBy]     NVARCHAR (MAX) NULL,
    [ModifiedBy]           NVARCHAR (MAX)  NULL,
    [IsActive]      BIT            NOT NULL,
    
    CONSTRAINT [PK_carTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_carTypes_CarCategories_CarCategoryId] FOREIGN KEY ([CarCategoryId]) REFERENCES [dbo].[CarCategories] ([Id]) 
);


GO
CREATE NONCLUSTERED INDEX [IX_carTypes_CarCategoryId]
    ON [dbo].[carTypes]([CarCategoryId] ASC);

