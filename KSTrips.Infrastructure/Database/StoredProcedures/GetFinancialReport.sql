/****** Object:  StoredProcedure [dbo].[GetFinancialReport]    Script Date: 3/16/2020 8:39:29 AM ******/
CREATE PROCEDURE [dbo].[GetFinancialReport] (@dateFrom  DATE , @dateTo DATE, @UserId INT, @vehicleId INT)
AS
BEGIN 

	DECLARE @SQL VARCHAR(MAX)
	DECLARE @Statement NVARCHAR (MAX)

	SET @Statement = N' 
		WITH InitialData AS (
		SELECT
		Trips.Id AS TripId,
		SUM(Trips.TotalTrip) AS Ingresos
		,SUM(Trips.Debt) AS SaldoPendiente
		,SUM(Trips.TotalProfit) AS Ganancia
		,SUM(TotalTrip*8)/1000 AS Ica
		,SUM(TotalTrip*1)/100 AS Retefuente
		,Vehicles.Id as VehicleId
		,Vehicles.[Description] AS VehicleDescription
		,Vehicles.LicensePlate
		,vehicles.Driver
		FROM Trips
		INNER JOIN Vehicles ON Trips.VehicleId = Vehicles.Id


		WHERE trips.UserId = ' + CAST(@UserId AS VARCHAR(MAX))+ '
			AND CAST(Trips.DateCreated AS DATE) BETWEEN '''+ CAST(@dateFrom AS VARCHAR(MAX))+''' AND '''+ CAST(@dateTo AS VARCHAR(MAX))+''' '

			IF(@vehicleId <> -1)
			BEGIN 
				SET @Statement+= N' AND Vehicles.Id = ' + CAST(@vehicleId AS VARCHAR(100))
			END
	 SET @Statement +=N' 
		GROUP BY Trips.Id
			,Vehicles.Id
			,Vehicles.[Description] 
			,Vehicles.LicensePlate
			,vehicles.Driver
		)
		, DetailData AS (
		SELECT TripId,
		SUM(TotalExpense) AS Gastos
		FROM TripDetails
		GROUP BY TripId
		)

		SELECT 
		SUM(InitialData.Ingresos) AS Revenue
		,SUM(DetailData.Gastos) AS Expenses
		,SUM(InitialData.SaldoPendiente) AS OutstandingBalance
		,SUM(InitialData.Ganancia) AS Profit
		,SUM(InitialData.Ica) AS IcaTax
		,SUM(InitialData.Retefuente) AS RetefuenteTax
		,(SUM(InitialData.Ganancia) - SUM(InitialData.SaldoPendiente)) AS AccountBalance

		FROM DetailData
		INNER JOIN InitialData ON DetailData.TripId = InitialData.TripId'

	set @SQL =  @Statement 
	--print @SQL
	execute (@SQL) 



END