 create or alter procedure dbo.PartyGet(@PartyId int = 0, @PartyName varchar(35)='', @All bit=0)
 as
 begin
		select @PartyName=nullif(@PartyName, '')

		select p.PartyId, p.PartyName-- p.YearStart, p.PartyColor
		from Party p
		where p.PartyId= @PartyId
		or @All=1
		or p.PartyName like '%' +@PartyName +  '%'
		order by p.PartyName
end 
go 
/*
exec PartyGet

exec PartyGet @PartyName=''--no results

exec PartyGet @PartyName='u'

exec PartyGet @All=1

declare @PartyId int
select top 1 @PartyId= p.PartyId from Party p
exec PartyGet @PartyId= @PartyId

*/
