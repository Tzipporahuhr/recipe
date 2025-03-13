 create or alter procedure dbo.CuisineGet(@CuisineId int=0, @CuisineName varchar (40)='', @All bit=0)
as
begin
	select @CuisineName= nullif(@CuisineName,'')
	select c.CuisineId, c.CuisineName 
	from Cuisine c
	where c.CuisineId=@CuisineId
	or @All=1
	or c.CuisineName like '%' + @CuisineName + '%'
	order by c.CuisineName
end
go
/*
exec CuisineGet

exec CuisineGet @CuisineName= ''
exec CuisineGet @CuisineName='a'
exec CuisineGet @All=1

declare @CuisineId int
select top 1 @CuisineId= c.CuisineId from Cuisine c
exec CuisineGet @CuisineId= @CuisineId
*/
