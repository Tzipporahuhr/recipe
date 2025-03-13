 create or alter procedure dbo.StaffGet(@StaffId int=0,@UserName varchar (40)='', @All bit=0)
as
begin
	select @UserName= nullif(@UserName,'')
	select s.StaffId, s.UserName 
	from Staff s
	where s.StaffId=@StaffId
	or @All=1
	or s.UserName like '%' + @UserName + '%'
	order by s.UserName
end
go
/*
exec StaffGet

exec StaffGet @UserName= ''
exec StaffGet @UserName='a'
exec StaffGet @All=1

declare @StaffId int
select top 1 @StaffId= s.StaffId from Staff s
exec StaffGet @StaffId= @StaffId
*/
