/****** Object:  StoredProcedure [dbo].[GetQtyReport]    Script Date: 3/16/2020 8:45:08 AM ******/
CREATE PROCEDURE [dbo].[GetQtyReport](@dateFrom  DATE, @dateTo  DATE, @userId INT, @vehicleId INT)

AS
BEGIN

	DECLARE @SQL VARCHAR(MAX)
	DECLARE @Statement NVARCHAR (MAX)


	SET @Statement = N' 
		WITH QtysTripsData AS(
		SELECT 
		COUNT(Trips.Id) AS QtyTrips
		,CASE WHEN Trips.IsActive = 1 THEN COUNT(Trips.Id) ELSE 0 END QtyActiveTrips
		,CASE WHEN Trips.IsActive = 0 THEN COUNT(Trips.Id) ELSE 0 END QtyClosedTrips
		,Vehicles.Id AS VehicleId
		,Vehicles.[Description] AS VehicleDescription
		,Vehicles.LicensePlate
		,vehicles.Driver
		FROM trips
		INNER JOIN TripDetails on trips.Id = TripDetails.TripId
		INNER JOIN Vehicles ON Trips.VehicleId = Vehicles.Id
		--INNER JOIN tolls on TripDetails.TollId = Tolls.Id AND TripDetails.TollId <> 0

		WHERE trips.UserId = ' + CAST(@UserId AS VARCHAR(MAX))+ '
		AND CAST(Trips.DateCreated AS DATE) BETWEEN '''+ CAST(@dateFrom AS VARCHAR(MAX))+''' AND '''+ CAST(@dateTo AS VARCHAR(MAX))+''' '

		IF(@vehicleId <> -1)
		BEGIN 
			SET @Statement+= N' AND Vehicles.Id = ' + CAST(@vehicleId AS VARCHAR(100))
		END

	SET @Statement +=N' GROUP BY Trips.IsActive
		,Vehicles.Id
		,Vehicles.[Description]
		,Vehicles.LicensePlate
		,vehicles.Driver
	)
	SELECT SUM(QtyTrips) as QtyTrips
	,SUM(QtyActiveTrips) as QtyActiveTrips
	,SUM(QtyClosedTrips) as QtyClosedTrips
	FROM QtysTripsData'
	 

	

set @SQL =  @Statement 
--print @SQL
execute (@SQL) 

END