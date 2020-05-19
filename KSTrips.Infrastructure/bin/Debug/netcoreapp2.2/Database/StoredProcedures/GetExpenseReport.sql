/****** Object:  StoredProcedure [dbo].[GetExpenseReport]    Script Date: 3/16/2020 8:38:27 AM ******/
CREATE PROCEDURE [dbo].[GetExpenseReport] (@dateFrom DATE,@dateTo DATE, @UserId INT, @vehicleId INT)
AS
BEGIN

	DECLARE @SQL VARCHAR(MAX)
	DECLARE @Statement NVARCHAR (MAX)

	SET @Statement = N' 
		WITH ExpenseData AS (
		SELECT 
		trips.Origin + '' - '' + trips.Destiny AS [Route]
		,TripDetails.TotalExpense
		,TripDetails.IsToll
		,CASE WHEN ExpenseCategory.Description IS NULL THEN ''Peajes'' ELSE ExpenseCategory.Description END [Description]
		,CASE WHEN ExpenseCategory.Id IS NULL THEN -1 ELSE ExpenseCategory.Id END ExpenseCategoryId
		,Vehicles.Id AS VehicleId
		,Vehicles.[Description] AS VehicleDescription
		,Vehicles.LicensePlate
		,vehicles.Driver
		FROM trips
		INNER JOIN TripDetails ON trips.Id = TripDetails.TripId
		INNER JOIN Vehicles ON Trips.VehicleId = Vehicles.Id
		LEFT JOIN ExpenseCategory ON TripDetails.ExpenseCategoryId = ExpenseCategory.Id
		LEFT JOIN tolls ON TripDetails.TollId = Tolls.Id 


		WHERE trips.UserId = ' + CAST(@UserId AS VARCHAR(MAX))+ '
			AND CAST(Trips.DateCreated AS DATE) BETWEEN '''+ CAST(@dateFrom AS VARCHAR(MAX))+''' AND '''+ CAST(@dateTo AS VARCHAR(MAX))+''' '

			IF(@vehicleId <> -1)
			BEGIN 
				SET @Statement+= N' AND Vehicles.Id = ' + CAST(@vehicleId AS VARCHAR(100))
			END
	 SET @Statement +=N' )
		SELECT 
		SUM(TotalExpense) AS AverageExpense
		,[Description]
		--,[Route]
		FROM ExpenseData
		GROUP BY [Description]'
	 

	

set @SQL =  @Statement 
--print @SQL
execute (@SQL) 

END