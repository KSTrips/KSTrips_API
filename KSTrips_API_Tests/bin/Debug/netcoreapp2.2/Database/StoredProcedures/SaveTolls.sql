CREATE PROCEDURE SaveTolls (@JsonData NVARCHAR(MAX))
AS
BEGIN

CREATE TABLE #JsonData(
	[Name] [nvarchar](max) NULL, [TotalTolls] [int] NOT NULL,[DistanceKm] [int] NOT NULL,[ApproximateTime] [nvarchar](max) NULL,
	[TotalCategory1] [decimal](18, 2) NULL,	[TotalCategory2] [decimal](18, 2) NULL,	[TotalCategory3] [decimal](18, 2) NULL,
	[TotalCategory4] [decimal](18, 2) NULL,	[TotalCategory5] [decimal](18, 2) NULL,	[TotalCategory6] [decimal](18, 2) NULL,
	[TotalCategory7] [decimal](18, 2) NULL,	[PageId] [int] NOT NULL
)

CREATE TABLE #JsonDetail(
	[NameToll] [nvarchar](MAX) NULL,
	[costCat1] [decimal](18, 2) NULL, [costCat2] [decimal](18, 2) NULL,	[costCat3] [decimal](18, 2) NULL,
	[costCat4] [decimal](18, 2) NULL, [costCat5] [decimal](18, 2) NULL,	[costCat6] [decimal](18, 2) NULL,
	[costCat7] [decimal](18, 2) NULL, [IdPeajePage] [int] NOT NULL
)

DECLARE @Tolls NVARCHAR(MAX)= @JsonData

----INSERTAMOS LOS DATOS DE MANERA TEMPORAL
INSERT INTO #JsonData(
	[Name] ,	[TotalTolls] ,	[DistanceKm] ,	[ApproximateTime],
	[TotalCategory1] , [TotalCategory2] , [TotalCategory3] , [TotalCategory4] ,	[TotalCategory5] ,	
	[TotalCategory6] , [TotalCategory7] , [PageId])
  SELECT DISTINCT
	   x.[Name] , x.numeroPeajes , x.distanciaKm , y.tiempoAprox
	   ,CAST(x.totalcat1 AS MONEY)AS totalcat1
	   ,CAST(x.totalcat2 AS MONEY)AS totalcat2
	   ,CAST(x.totalcat3 AS MONEY)AS totalcat3
	   ,CAST(x.totalcat4 AS MONEY)AS totalcat4
	   ,CAST(x.totalcat5 AS MONEY)AS totalcat5
	   ,CAST(x.totalcat6 AS MONEY)AS totalcat6
	   ,CAST(x.totalcat7 AS MONEY)AS totalcat7	 
	   ,x.Id

    FROM OPENJSON(@Tolls) 	
    WITH (Id int '$.id', Name VARCHAR(200) '$.name', numeroPeajes int '$.numeroPeajes', 
    distanciaKm INT '$.distanciaKm', href VARCHAR(200) '$.href'
	,totalcat1 VARCHAR(200) '$.totalcat1' ,totalcat2 VARCHAR(200) '$.totalcat2' ,totalcat3 VARCHAR(200) '$.totalcat3' ,totalcat4 VARCHAR(200) '$.totalcat4' 
	,totalcat5 VARCHAR(200) '$.totalcat5' ,totalcat6 VARCHAR(200) '$.totalcat6' ,totalcat7 VARCHAR(200) '$.totalcat7' 
	,categoriasCostos nvarchar(max) '$.categoriasCostos' AS JSON) AS x

    CROSS APPLY OPENJSON (x.categoriasCostos) 
	WITH ( tiempoAprox VARCHAR(10) '$.tiempoAprox'
	,costcat1 VARCHAR(200) '$.costcat1' ,costcat2 VARCHAR(200) '$.costcat2' ,costcat3 VARCHAR(200) '$.costcat3' ,costcat4 VARCHAR(200) '$.costcat4' 
	,costcat5 VARCHAR(200) '$.costcat5' ,costcat6 VARCHAR(200) '$.costcat6' ,costcat7 VARCHAR(200) '$.costcat7' ,namePorPeaje VARCHAR(MAX) '$.namePorPeaje'
	) as y
	Order by x.Id;

	----INSERTAMOS EL DETALLE DE MANERA TEMPORAL
	INSERT INTO #JsonDetail(
	[NameToll],
	[costCat1] , [costCat2] , [costCat3] ,
	[costCat4] , [costCat5] , [costCat6] ,
	[costCat7] , [IdPeajePage] )
	  SELECT 
	   y.namePorPeaje	
	   ,CASE WHEN TRY_CAST(y.costcat1 AS MONEY) IS NULL THEN 0 ELSE CAST(y.costcat1 AS MONEY) END costcat1
	   ,CASE WHEN TRY_CAST(y.costcat2 AS MONEY) IS NULL THEN 0 ELSE CAST(y.costcat2 AS MONEY) END costcat2
	   ,CASE WHEN TRY_CAST(y.costcat3 AS MONEY) IS NULL THEN 0 ELSE CAST(y.costcat3 AS MONEY) END costcat3
	   ,CASE WHEN TRY_CAST(y.costcat4 AS MONEY) IS NULL THEN 0 ELSE CAST(y.costcat4 AS MONEY) END costcat4
	   ,CASE WHEN TRY_CAST(y.costcat5 AS MONEY) IS NULL THEN 0 ELSE CAST(y.costcat5 AS MONEY) END costcat5
	   ,CASE WHEN TRY_CAST(y.costcat6 AS MONEY) IS NULL THEN 0 ELSE CAST(y.costcat6 AS MONEY) END costcat6
	   ,CASE WHEN TRY_CAST(y.costcat7 AS MONEY) IS NULL THEN 0 ELSE CAST(y.costcat7 AS MONEY) END costcat7
	   ,y.IdPeaje
    FROM OPENJSON(@Tolls) 	
    WITH (Id int '$.id', categoriasCostos nvarchar(max) '$.categoriasCostos' AS JSON) AS x
    CROSS APPLY OPENJSON (x.categoriasCostos) 
	WITH ( tiempoAprox VARCHAR(10) '$.tiempoAprox'
	,costcat1 VARCHAR(200) '$.costcat1' ,costcat2 VARCHAR(200) '$.costcat2' ,costcat3 VARCHAR(200) '$.costcat3' ,costcat4 VARCHAR(200) '$.costcat4' 
	,costcat5 VARCHAR(200) '$.costcat5' ,costcat6 VARCHAR(200) '$.costcat6' ,costcat7 VARCHAR(200) '$.costcat7' ,namePorPeaje VARCHAR(MAX) '$.namePorPeaje'
	,IdPeaje INT '$.IdPeaje'
	) as y
	Order by y.IdPeaje;

	----REALIZAMOS EL MERGE PARA ACTUALIZAR O INSERTAR LOS DATOS DEL PEAJE
	MERGE Tolls AS T
		USING #JsonData AS S ON (T.[Name] = S.[Name]) 
		--When records are matched, update the records if there is any change
		WHEN MATCHED 
		THEN UPDATE SET 
		T.[TotalQtyTolls] = S.[TotalTolls] , T.[DistanceKm] = S.[DistanceKm] ,	T.[ApproximateTime] = S.[ApproximateTime],
		T.[TotalCategory1] = S.[TotalCategory1] , T.[TotalCategory2] = S.[TotalCategory2] ,	T.[TotalCategory3] = S.[TotalCategory3] ,	
		T.[TotalCategory4] = S.[TotalCategory4] , T.[TotalCategory5] = S.[TotalCategory5] ,	
		T.[TotalCategory6] = S.[TotalCategory6] , T.[TotalCategory7] = S.[TotalCategory7] ,
		T.[PageId] = S.[PageId]
		--When no records are matched, insert the incoming records from S table to T table
		WHEN NOT MATCHED BY TARGET
		THEN INSERT ([Name] ,	[TotalQtyTolls] ,	[DistanceKm] ,	[ApproximateTime],
				[TotalCategory1] ,	[TotalCategory2] ,	[TotalCategory3] ,	[TotalCategory4] ,	[TotalCategory5] ,	
				[TotalCategory6] ,	[TotalCategory7],[PageId]) 
			VALUES (S.[Name] , S.[TotalTolls] ,	S.[DistanceKm] , S.[ApproximateTime],
				S.[TotalCategory1] , S.[TotalCategory2] , S.[TotalCategory3] , S.[TotalCategory4] ,	s.[TotalCategory5] ,	
				S.[TotalCategory6] , S.[TotalCategory7] , S.[PageId])
		OUTPUT $action;


	----REALIZAMOS EL MERGE PARA ACTUALIZAR O INSERTAR LOS DATOS DEL DETALLE DE CADA PEAJE

	MERGE TollDetails AS T
		USING #JsonDetail AS S ON (T.[NameToll] = S.[NameToll] AND T.[TollId] = (SELECT Id FROM Tolls WHERE PageId = S.[IdPeajePage])) 
		--When records are matched, update the records if there is any change
		WHEN MATCHED 
		THEN UPDATE SET 
		T.[NameToll] = S.[NameToll] , 
		T.[CostCategory1] = S.[costcat1] , T.[CostCategory2] = S.[costcat2] ,	T.[CostCategory3] = S.[costcat3] ,	
		T.[CostCategory4] = S.[costcat4] , T.[CostCategory5] = S.[costcat5] ,	
		T.[CostCategory6] = S.[costcat6] , T.[CostCategory7] = S.[costcat7] 
		--When no records are matched, insert the incoming records from S table to T table
		WHEN NOT MATCHED BY TARGET
		THEN INSERT ([NameToll] , [TollId] , [CostCategory1] , [CostCategory2] 
					, [CostCategory3] , [CostCategory4] , [CostCategory5] , [CostCategory6] , [CostCategory7]) 
			VALUES (S.[NameToll] , (SELECT Id FROM Tolls WHERE PageId = S.[IdPeajePage]) 
					, S.[costcat1] , S.[costcat2]  , S.[costcat3] , S.[costcat4] , S.[costcat5] , S.[costcat6] , S.[costcat7])
		OUTPUT $action;


	DROP TABLE #JsonData
	DROP TABLE #JsonDetail

END