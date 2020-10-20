---- //CATEGORIAS -----*****************
-----------------------*****************
CREATE TABLE #CarCategories ([Description] nvarchar(max), DateCreated DATETIME, [CreatedBy] nvarchar(max), IsActive bit, CarTypes varchar(max));


-- INSERT THE GIVEN PERMISSIONS ACCORDING TO THE ROLE
insert into #CarCategories ([Description] , DateCreated , [CreatedBy] , IsActive , CarTypes )values('Categoria 1',GETDATE(),'Administrator',1,'Automóviles, camperos, camionetas, microbuses con ejes de llanta sencilla')
insert into #CarCategories ([Description] , DateCreated , [CreatedBy] , IsActive , CarTypes )values('Categoria 2',GETDATE(),'Administrator',1,'Buses, busetas, microbuses con eje trasero de doble llanta y camiones de dos ejes')
insert into #CarCategories ([Description] , DateCreated , [CreatedBy] , IsActive , CarTypes )values('Categoria 3',GETDATE(),'Administrator',1,'Vehículos de pasajeros y de carga de tres y cuatro ejes')
insert into #CarCategories ([Description] , DateCreated , [CreatedBy] , IsActive , CarTypes )values('Categoria 4',GETDATE(),'Administrator',1,'Vehículos de carga de cinco ejes')
insert into #CarCategories ([Description] , DateCreated , [CreatedBy] , IsActive , CarTypes )values('Categoria 5',GETDATE(),'Administrator',1,'Vehículos de carga de seis ejes')


--MERGE INTO FOR ROLE PERMISSIONS
MERGE INTO CarCategories AS TARGET
USING #CarCategories AS SOURCE ON ( SOURCE.[Description] = TARGET.[Description])

WHEN MATCHED THEN
--  "update" 
	UPDATE SET 
	TARGET.[Description] = SOURCE.[Description]
	,TARGET.CarTypes = SOURCE.CarTypes
	,TARGET.DateModified = GETDATE()


WHEN NOT MATCHED BY TARGET THEN
--  "insert" 
INSERT ([Description] , DateCreated , [CreatedBy] , IsActive , CarTypes )
VALUES ( SOURCE.[Description] , SOURCE.DateCreated , SOURCE.[CreatedBy] , SOURCE.IsActive , SOURCE.CarTypes )
OUTPUT $ACTION;
DROP TABLE #CarCategories

--------------------***************
--------------------***************



----//ROLESS-------------------------------**************
-------------------------------------------**************
CREATE TABLE #Roles ([Name] nvarchar(max), DateCreated DATETIME, [CreatedBy] nvarchar(max), IsActive bit);


-- INSERT THE GIVEN PERMISSIONS ACCORDING TO THE ROLE
insert into #Roles ([Name] , DateCreated , [CreatedBy] , IsActive  )values('Administrador',GETDATE(),'Administrator',1)
insert into #Roles ([Name] , DateCreated , [CreatedBy] , IsActive  )values('Conductor',GETDATE(),'Administrator',1)



--MERGE INTO FOR ROLE PERMISSIONS
MERGE INTO Roles AS TARGET
USING #Roles AS SOURCE ON ( SOURCE.[Name] = TARGET.[Name])

WHEN MATCHED THEN
--  "update" 
	UPDATE SET 
	TARGET.[Name] = SOURCE.[Name]
	,TARGET.DateModified = GETDATE()


WHEN NOT MATCHED BY TARGET THEN
--  "insert" 
INSERT ([Name] , DateCreated , [CreatedBy] , IsActive )
VALUES ( SOURCE.[Name] , SOURCE.DateCreated , SOURCE.[CreatedBy] , SOURCE.IsActive )
OUTPUT $ACTION;
DROP TABLE #Roles

-------------------------------------------**************
-------------------------------------------**************



----//SMTP-------------------------------------------**************
-----------------------------------------------------**************

CREATE TABLE #SMTPServer (SMTPServer nvarchar(50), [Port] int, Host nvarchar(50), Email nvarchar(50), [Password] nvarchar(50));


-- INSERT THE GIVEN PERMISSIONS ACCORDING TO THE ROLE
insert into #SMTPServer (SMTPServer , [Port] , Host , Email,[Password]  )values('smtp.gmail.com',587 ,'Gmail','soporte@ks-trips.com','soportekstransvm371')


--MERGE INTO FOR ROLE PERMISSIONS
MERGE INTO SMTPServer AS TARGET
USING #SMTPServer AS SOURCE ON ( SOURCE.SMTPServer = TARGET.SMTPServer)

WHEN MATCHED THEN
--  "update" 
	UPDATE SET 
	TARGET.SMTPServer = SOURCE.SMTPServer
	,TARGET.Host = SOURCE.Host
	,TARGET.[Port] = SOURCE.[Port]


WHEN NOT MATCHED BY TARGET THEN
--  "insert" 
INSERT (SMTPServer , [Port] , Host , Email,[Password]  )
VALUES ( SOURCE.SMTPServer , SOURCE.[Port] , SOURCE.Host , SOURCE.Email, SOURCE.[Password] )
OUTPUT $ACTION;
DROP TABLE #SMTPServer

-------------------------------------------**************
-------------------------------------------**************



----//Subscripcion-------------------------------------------**************
-------------------------------------------------------------**************

CREATE TABLE #SubscriptionTypes ([Description] nvarchar(max), QtyAllowedUsers integer , DateCreated DATETIME, [CreatedBy] nvarchar(max), IsActive bit );


-- INSERT THE GIVEN PERMISSIONS ACCORDING TO THE ROLE
insert into #SubscriptionTypes ([Description] ,QtyAllowedUsers, DateCreated , [CreatedBy] , IsActive )values('Personal',1,GETDATE(),'Administrator',1)
insert into #SubscriptionTypes ([Description] ,QtyAllowedUsers, DateCreated , [CreatedBy] , IsActive )values('Emprendedor',3,GETDATE(),'Administrator',1)
insert into #SubscriptionTypes ([Description] ,QtyAllowedUsers, DateCreated , [CreatedBy] , IsActive )values('Pyme',10,GETDATE(),'Administrator',1)
insert into #SubscriptionTypes ([Description] ,QtyAllowedUsers, DateCreated , [CreatedBy] , IsActive )values('Empresarial',20,GETDATE(),'Administrator',1)
insert into #SubscriptionTypes ([Description] ,QtyAllowedUsers, DateCreated , [CreatedBy] , IsActive )values('Premiun',50,GETDATE(),'Administrator',1)
insert into #SubscriptionTypes ([Description] ,QtyAllowedUsers, DateCreated , [CreatedBy] , IsActive )values('Gold',100,GETDATE(),'Administrator',1)


--MERGE INTO FOR ROLE PERMISSIONS
MERGE INTO SubscriptionTypes AS TARGET
USING #SubscriptionTypes AS SOURCE ON ( SOURCE.[Description] = TARGET.[Description])

WHEN MATCHED THEN
--  "update" 
	UPDATE SET 
	TARGET.[Description] = SOURCE.[Description]
	,TARGET.QtyAllowedUsers = SOURCE.QtyAllowedUsers
	,TARGET.DateModified = GETDATE()


WHEN NOT MATCHED BY TARGET THEN
--  "insert" 
INSERT ([Description] ,QtyAllowedUsers , DateCreated , [CreatedBy] , IsActive  )
VALUES ( SOURCE.[Description] , SOURCE.QtyAllowedUsers , SOURCE.DateCreated , SOURCE.[CreatedBy] , SOURCE.IsActive  )
OUTPUT $ACTION;
DROP TABLE #SubscriptionTypes


-------------------------------------------**************
-------------------------------------------**************




----//Impuestos(Taxes)-------------------------------------------**************
-----------------------------------------------------------------**************

CREATE TABLE #Taxes ([Description] nvarchar(max), costTax decimal(18,3) , DateCreated DATETIME, [CreatedBy] nvarchar(max), IsActive bit, );


-- INSERT THE GIVEN PERMISSIONS ACCORDING TO THE ROLE
insert into #Taxes ([Description] ,costTax, DateCreated , [CreatedBy] , IsActive )values('Retefuente',1,GETDATE(),'Administrator',1)
insert into #Taxes ([Description] ,costTax, DateCreated , [CreatedBy] , IsActive )values('Ica',8,GETDATE(),'Administrator',1)
insert into #Taxes ([Description] ,costTax, DateCreated , [CreatedBy] , IsActive )values('Abono al 60%',65,GETDATE(),'Administrator',1)
insert into #Taxes ([Description] ,costTax, DateCreated , [CreatedBy] , IsActive )values('Abono al 70%',70,GETDATE(),'Administrator',1)
insert into #Taxes ([Description] ,costTax, DateCreated , [CreatedBy] , IsActive )values('Abono al 80%',80,GETDATE(),'Administrator',1)
insert into #Taxes ([Description] ,costTax, DateCreated , [CreatedBy] , IsActive )values('Papeleria',4,GETDATE(),'Administrator',1)
insert into #Taxes ([Description] ,costTax, DateCreated , [CreatedBy] , IsActive )values('Otros (Seguros)',3,GETDATE(),'Administrator',1)


--MERGE INTO FOR ROLE PERMISSIONS
MERGE INTO Taxes AS TARGET
USING #Taxes AS SOURCE ON ( SOURCE.[Description] = TARGET.[Description])

WHEN MATCHED THEN
--  "update" 
	UPDATE SET 
	TARGET.[Description] = SOURCE.[Description]
	,TARGET.CostTax = SOURCE.CostTax
	,TARGET.DateModified = GETDATE()


WHEN NOT MATCHED BY TARGET THEN
--  "insert" 
INSERT ([Description] ,costTax , DateCreated , [CreatedBy] , IsActive  )
VALUES ( SOURCE.[Description] , SOURCE.costTax , SOURCE.DateCreated , SOURCE.[CreatedBy] , SOURCE.IsActive )
OUTPUT $ACTION;
DROP TABLE #Taxes


-------------------------------------------**************
-------------------------------------------**************



----//CAR TYPES-------------------------------------------**************
-----------------------------------------------------------------**************

CREATE TABLE #CarTypes ([Description] nvarchar(max), carCategoryId int , DateCreated DATETIME, [CreatedBy] nvarchar(max), IsActive bit, );


-- INSERT THE GIVEN PERMISSIONS ACCORDING TO THE ROLE
insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Automóviles',1,GETDATE(),'Administrator',1)
insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Camperos',1,GETDATE(),'Administrator',1)
insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Camionetas',1,GETDATE(),'Administrator',1)
insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Microbuses con ejes de llanta sencilla',1,GETDATE(),'Administrator',1)

insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Buses',2,GETDATE(),'Administrator',1)
insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Busetas',2,GETDATE(),'Administrator',1)
insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Microbuses con eje trasero de doble llanta',2,GETDATE(),'Administrator',1)
insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Camiones de dos ejes',2,GETDATE(),'Administrator',1)

insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Vehículos de pasajeros',3,GETDATE(),'Administrator',1)
insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Vehículos de carga de tres',3,GETDATE(),'Administrator',1)
insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Vehículos de carga de cuatro ejes',3,GETDATE(),'Administrator',1)

insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Vehículos de carga de cinco ejes',4,GETDATE(),'Administrator',1)
insert into #CarTypes ([Description] ,carCategoryId, DateCreated , [CreatedBy] , IsActive )values('Vehículos de carga de seis ejes',5,GETDATE(),'Administrator',1)


--MERGE INTO FOR ROLE PERMISSIONS
MERGE INTO CarTypes AS TARGET
USING #CarTypes AS SOURCE ON ( SOURCE.[Description] = TARGET.[Description])

WHEN MATCHED THEN
--  "update" 
	UPDATE SET 
	TARGET.[Description] = SOURCE.[Description]
	,TARGET.carCategoryId = SOURCE.carCategoryId
	,TARGET.DateModified = GETDATE()


WHEN NOT MATCHED BY TARGET THEN
--  "insert" 
INSERT ([Description] ,carCategoryId , DateCreated , [CreatedBy] , IsActive  )
VALUES ( SOURCE.[Description] , SOURCE.carCategoryId , SOURCE.DateCreated , SOURCE.[CreatedBy] , SOURCE.IsActive )
OUTPUT $ACTION;
DROP TABLE #CarTypes


-------------------------------------------**************
-------------------------------------------**************