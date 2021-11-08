CREATE TABLE [dbo].[Vehicles] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [Description]            NVARCHAR (MAX) NULL,
    [Driver]                 NVARCHAR (MAX) NULL,
    [LicensePlate]           NVARCHAR (MAX) NULL,
    [Model]                  INT NULL,   
    [UserId]                 INT            DEFAULT ((0)) NOT NULL,
    [NotificationKilometers] INT            DEFAULT ((0)) NOT NULL,
    [CarCategoryId]          INT            NOT NULL,
    [DateCreated]            DATETIME2 (7)  NOT NULL,
    [DateModified]           DATETIME2 (7)  NULL,
    [CreatedBy]              NVARCHAR (MAX) NULL,
    [ModifiedBy]             NVARCHAR (MAX)  NULL,
    [IsActive]               BIT            NOT NULL,
    
    CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Vehicles_CarCategories_CarCategoryId] FOREIGN KEY ([CarCategoryId]) REFERENCES [dbo].[CarCategories] ([Id]) 
);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicles_CarCategoryId]
    ON [dbo].[Vehicles]([CarCategoryId] ASC);

