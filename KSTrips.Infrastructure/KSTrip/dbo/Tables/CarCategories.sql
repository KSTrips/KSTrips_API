CREATE TABLE [dbo].[CarCategories] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [Description]         NVARCHAR (MAX)  NULL,
    [CarTypes]            NVARCHAR (MAX)  NULL,
    [CostAproxByDistance] DECIMAL (18, 2) NULL,
    [CostAproxByWeigth]   DECIMAL (18, 2) NULL,
    [DateCreated]         DATETIME2 (7)   NOT NULL,
    [DateModified]        DATETIME2 (7)   NULL,
    [CreatedBy]           NVARCHAR (MAX)  NULL,
    [ModifiedBy]           NVARCHAR (MAX)  NULL,
    [IsActive]            BIT             NOT NULL,
  
    CONSTRAINT [PK_CarCategories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

