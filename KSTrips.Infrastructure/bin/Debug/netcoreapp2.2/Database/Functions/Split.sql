CREATE FUNCTION [dbo].[Split] (@String nvarchar (MAX), @Delimitador nvarchar (10)) 
                returns @ValueTable table (Id INT Identity(1,1),[Value] nvarchar(MAX))
BEGIN
 declare @NextString nvarchar(MAX)
 declare @Pos int
 declare @NextPos int
 declare @CommaCheck nvarchar(1)
  
 --Inicializa
 set @NextString = ''
 set @CommaCheck = right(@String,1) 
  
 set @String = @String + @Delimitador
  
 --Busca la posición del primer delimitador
 set @Pos = charindex(@Delimitador,@String)
 set @NextPos = 1
  
 --Itera mientras exista un delimitador en el string
 WHILE (@pos <> 0)  
 BEGIN
  set @NextString = substring(@String,1,@Pos - 1)
  
  insert into @ValueTable ( [Value]) Values (@NextString)
  
  set @String = substring(@String,@pos +1,len(@String))
   
  set @NextPos = @Pos
  set @pos  = charindex(@Delimitador,@String)
 END
  
 return
END