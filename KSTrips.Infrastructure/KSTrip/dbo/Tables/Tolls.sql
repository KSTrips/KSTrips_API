CREATE TABLE [dbo].[Tolls]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Via_Code] VARCHAR(50)  NULL , --Codigo_via
	[Name] VARCHAR(200) NOT NULL, --Nombre
	[Territory] VARCHAR(200) NOT NULL, --Territorio
	[Sector] VARCHAR(500)  NULL, --Sector
	[Owner] VARCHAR(200) NOT NULL, --Administrador o consecionario
	[Location] VARCHAR(500) NOT NULL, -- Ubicacion
	[Road_Sense] VARCHAR(100) NOT NULL, -- Sentido del peaje (Sur-Norte)
	[Latitude] FLOAT NOT NULL,
	[Longitude] FLOAT NOT NULL,
	[PhoneToll] VARCHAR(200) NOT NULL, -- Telefono del peaje
	[PhoneCrane] VARCHAR(200) NULL, -- Telefono de la grua
	[CostCategory1] DECIMAL (18, 2) NULL,
    [CostCategory2] DECIMAL (18, 2) NULL,
    [CostCategory3] DECIMAL (18, 2) NULL,
    [CostCategory4] DECIMAL (18, 2) NULL,
    [CostCategory5] DECIMAL (18, 2) NULL,
    [CostCategory6] DECIMAL (18, 2) NULL,
    [CostCategory7] DECIMAL (18, 2) NULL,
    [CreatedBy]     NVARCHAR (MAX)  NULL,
	[ModifiedBy]           NVARCHAR (MAX)  NULL,
    [DateCreated]   DATETIME2 (7)   DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [DateModified]  DATETIME2 (7)   NULL,
    [IsActive]      BIT             DEFAULT ((0)) NOT NULL,
)
