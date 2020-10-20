/****** Object:  StoredProcedure [dbo].[GetDetailReport]    Script Date: 3/16/2020 8:37:09 AM ******/

CREATE PROCEDURE [dbo].[GetDetailReport](@dateFrom DATE, @dateTo DATE, @UserId INT, @vehicleId INT)
AS 
BEGIN

	DECLARE @SQL VARCHAR(MAX)
	DECLARE @Statement NVARCHAR (MAX)
	DECLARE @Where NVARCHAR(MAX)

	SET @Statement = N' 
	SELECT 
	Trips.Id AS TripId
	,CarCategories.Id AS CarCategoryId
	,Trips.Origin + '' - ''+ Trips.Destiny AS [Route]
	,TripDetails.IsToll
	,CarCategories.[Description]  AS CarCategory
	,CarCategories.CarTypes
	--,Tolls.[Name]
	--,CASE WHEN Tolls.TotalQtyTolls IS NULL THEN 0 ELSE Tolls.TotalQtyTolls END TotalQtyTolls
	,CASE WHEN ExpenseCategory.[Description] IS NULL THEN ''Peajes'' ELSE ExpenseCategory.[Description] END Expense
	,TripDetails.TotalExpense
	,Trips.TotalProfit
	,Trips.Debt
	,Users.[Name] AS UserName
	,Providers.[Description] AS ProviderName
	,CAST(Trips.DateCreated AS DATE) AS DateCreated
	,CAST(users.DateforPay AS DATE) AS DateForPay
	,trips.IsACtive
	,Vehicles.Id AS VehicleId
	,Vehicles.[Description]
	,Vehicles.LicensePlate
	,vehicles.Driver
	FROM 
	Trips
	INNER JOIN TripDetails ON Trips.Id = TripDetails.TripId
	INNER JOIN Vehicles ON Trips.VehicleId = Vehicles.Id
	--LEFT JOIN  Tolls ON TripDetails.TollId = Tolls.Id  
	LEFT JOIN ExpenseCategory ON TripDetails.ExpenseCategoryId = ExpenseCategory.Id
	INNER JOIN CarCategories ON Vehicles.CarCategoryId = CarCategories.Id
	INNER JOIN Users ON Trips.UserId = Users.Id
	INNER JOIN Providers ON Trips.ProviderId = Providers.Id'

	SET @Where = N' 
	WHERE trips.UserId = ' + CAST(@UserId AS VARCHAR(MAX))+ '
	AND CAST(Trips.DateCreated AS DATE) BETWEEN '''+ CAST(@dateFrom AS VARCHAR(MAX))+''' AND '''+ CAST(@dateTo AS VARCHAR(MAX))+''' '

	IF(@vehicleId <> -1)
	BEGIN 
		SET @where+= N' AND Vehicles.Id = ' + CAST(@vehicleId AS VARCHAR(100))
	END

set @SQL =  @Statement + ' ' +@Where 
--print @SQL
execute (@SQL) 

END