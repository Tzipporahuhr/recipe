 create or alter procedure dbo.StaffGet(@StaffId int=0,@FirstName varchar (40)=' ', @All bit=0)
as
begin
	select @FirstName= nullif(@FirstName,'')
	select s.StaffId, s.FirstName 
	from Staff s
	where s.StaffId=@StaffId
	or @All=1
	or s.FirstName like '%' + @FirstName + '%'
	order by s.FirstName
end
go
/*
exec StaffGet

exec StaffGet @FirstName= ''
exec StaffGet @FirstName='a'
exec StaffGet @All=1

declare @StaffId int
select top 1 @StaffId= s.StaffId from Staff s
exec StaffGet @StaffId= @StaffId
*/
