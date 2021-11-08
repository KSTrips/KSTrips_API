CREATE TABLE [dbo].[TripDetails] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [TotalExpense]      DECIMAL (18, 2) NULL,
    [TripId]            INT             NOT NULL,
    [IsToll]            BIT             DEFAULT ((0)) NOT NULL,
    [TollId]            INT             DEFAULT ((0)) NOT NULL,
    [ExpenseCategoryId] INT             DEFAULT ((0)) NOT NULL,
    [Comments]          NVARCHAR (MAX)  NULL,
   
    
    CONSTRAINT [PK_TripDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TripDetails_Trips_TripId] FOREIGN KEY ([TripId]) REFERENCES [dbo].[Trips] ([Id]) 
);


GO
CREATE NONCLUSTERED INDEX [IX_TripDetails_TripId]
    ON [dbo].[TripDetails]([TripId] ASC);

