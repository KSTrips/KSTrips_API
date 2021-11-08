CREATE TABLE [dbo].[Trips] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Origin]          NVARCHAR (MAX)  NULL,
    [Destiny]         NVARCHAR (MAX)  NULL,
    [TotalTrip]       DECIMAL (18, 2) NOT NULL,
    [Payment]         DECIMAL (18, 2) NOT NULL,
    [Debt]            DECIMAL (18, 2) NOT NULL,
    [ApplyTolls]      BIT             NOT NULL,
    [ApplyReteFuente] BIT             NOT NULL,
    [TotalProfit]     DECIMAL (18, 2) NULL,
    [ProviderId]      INT             NOT NULL,
    [UserId]          INT             NOT NULL,
    [ApplyIca]        BIT             DEFAULT ((0)) NOT NULL,
    [VehicleId]       INT             NOT NULL,
    [IsUrban]         BIT             DEFAULT ((0)) NOT NULL,
    [DateCreated]     DATETIME2 (7)   NOT NULL,
    [DateModified]    DATETIME2 (7)   NULL,
    [CreatedBy]       NVARCHAR (MAX)  NULL,
    [ModifiedBy]           NVARCHAR (MAX)  NULL,
    [IsActive]        BIT             NOT NULL,
   
    CONSTRAINT [PK_Trips] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Trips_Providers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[Providers] ([Id]),
    CONSTRAINT [FK_Trips_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicles] ([Id]) 
);


GO
CREATE NONCLUSTERED INDEX [IX_Trips_ProviderId]
    ON [dbo].[Trips]([ProviderId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Trips_VehicleId]
    ON [dbo].[Trips]([VehicleId] ASC);

