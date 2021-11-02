	CREATE PROCEDURE GetMonthlyDashboard (@UserId INT ,@DateFrom DATE , @DateTo DATE)
	AS
	BEGIN
		WITH DataMensual AS(
		 SELECT 
			COUNT (DISTINCT	Trips.Id) AS QtyTrips
			,SUM(Trips.Debt) AS SaldoPendiente
			,SUM(Trips.TotalProfit) AS Ganancia
			,trips.Id
		FROM 
		Trips
		WHERE  
		Trips.UserId = @UserId AND
		CAST(Trips.DateCreated AS DATE) BETWEEN @DateFrom AND @DateTo
		GROUP by  Trips.Id
		)
		, Gastos AS(

		SELECT DataMensual.*
		,SUM(TripDetails.TotalExpense) AS Gastos 
		FROM DataMensual
		INNER JOIN TripDetails ON DataMensual.Id = TripDetails.Id
		Group By DataMensual.Id,DataMensual.QtyTrips,DataMensual.SaldoPendiente,DataMensual.Ganancia
		)
		SELECT * FROM Gastos
	END
	

