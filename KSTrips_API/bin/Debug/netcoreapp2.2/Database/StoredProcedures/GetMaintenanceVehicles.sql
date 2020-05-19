CREATE PROCEDURE [dbo].[GetMaintenanceVehicles](@dateFrom DATE,@dateTo DATE, @UserId INT)
AS 
BEGIN
		SELECT DISTINCT
		Trips.Id AS TripId
		,Vehicles.LicensePlate
		,Vehicles.Driver
		,SUM(Tolls.DistanceKm) AS KilometersTraveled
		,Vehicles.NotificationKilometers
		FROM trips
		INNER JOIN TripDetails on trips.Id = TripDetails.TripId
		INNER JOIN Vehicles on trips.VehicleId = Vehicles.Id
		LEFT JOIN tolls on TripDetails.TollId = Tolls.Id AND TripDetails.IsToll = 1

		WHERE trips.UserId = @UserId
		AND CAST(Trips.DateCreated AS DATE) BETWEEN @dateFrom AND @dateTo 
		GROUP BY 
		Trips.Id
		,Vehicles.LicensePlate
		,Vehicles.Driver
		,Vehicles.NotificationKilometers

END