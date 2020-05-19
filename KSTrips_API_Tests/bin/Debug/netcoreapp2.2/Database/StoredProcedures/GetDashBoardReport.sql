CREATE PROCEDURE [dbo].[GetDashBoardReport] (@dateFrom DATE,@dateTo DATE, @UserId INT)
AS
BEGIN
		WITH InitialData AS(
		SELECT 
		Trips.Id
		,COUNT(Trips.Id) AS QtyTrips
		,CASE WHEN Trips.IsActive = 1 THEN COUNT(Trips.Id) ELSE 0 END QtyActiveTrips
		,CASE WHEN Trips.IsActive = 0 THEN COUNT(Trips.Id) ELSE 0 END QtyClosedTrips

		,SUM(Trips.TotalTrip) AS Ingresos
		,SUM(Trips.Debt) AS SaldoPendiente
		,SUM(Trips.TotalProfit) AS Ganancia
		,SUM(TotalTrip*8)/1000 AS Ica
		,SUM(TotalTrip*1)/100 AS Retefuente
		,SUM(Tolls.DistanceKm) AS Kilometers
		FROM trips
		LEFT JOIN TripDetails on trips.Id = TripDetails.TripId
		LEFT JOIN tolls on TripDetails.TollId = Tolls.Id AND TripDetails.TollId <> 0

		WHERE trips.UserId = @UserId
		AND CAST(Trips.DateCreated AS DATE) BETWEEN @dateFrom AND @dateTo 
		 GROUP BY 
		 Trips.Id,
		 Trips.IsActive

	)
	, DetailData AS (
		SELECT TripId,
		SUM(TotalExpense) AS Gastos
		FROM TripDetails
		GROUP BY TripId
		)
	SELECT 
	 CASE WHEN SUM(QtyTrips) IS NULL THEN 0 ELSE SUM(QtyTrips)  END QtyTrips
    ,CASE WHEN SUM(QtyActiveTrips) IS NULL THEN 0 ELSE SUM(QtyActiveTrips)  END QtyActiveTrips
	,CASE WHEN SUM(QtyClosedTrips) IS NULL THEN 0 ELSE SUM(QtyClosedTrips) END QtyClosedTrips
	,CASE WHEN SUM(InitialData.Ingresos) IS NULL THEN 0 ELSE SUM(InitialData.Ingresos) END Revenue -- Ingresos
	,CASE WHEN SUM(DetailData.Gastos) IS NULL THEN 0 ELSE SUM(DetailData.Gastos) END Expenses -- Gastos
	,CASE WHEN SUM(InitialData.SaldoPendiente) IS NULL THEN 0 ELSE SUM(InitialData.SaldoPendiente) END OutstandingBalance --Saldo Pendiente
	,CASE WHEN SUM(InitialData.Ganancia) IS NULL THEN 0 ELSE SUM(InitialData.Ganancia) END Profit --Ganancia
	,CASE WHEN SUM(InitialData.Ica) IS NULL THEN 0 ELSE SUM(InitialData.Ica) END IcaTax -- Ica impuesto
	,CASE WHEN SUM(InitialData.Retefuente) IS NULL THEN 0 ELSE SUM(InitialData.Retefuente) END RetefuenteTax -- RetefuenteImpuestp
	,CASE WHEN (SUM(InitialData.Ganancia) - SUM(InitialData.SaldoPendiente)) IS NULL THEN 0 ELSE (SUM(InitialData.Ganancia) - SUM(InitialData.SaldoPendiente)) END AccountBalance -- Saldo en cuenta
	,CASE WHEN SUM(InitialData.Kilometers) IS NULL THEN 0 ELSE SUM(InitialData.Kilometers) END Kilometers
	FROM DetailData
		INNER JOIN InitialData ON DetailData.TripId = InitialData.Id
	
	
	END

