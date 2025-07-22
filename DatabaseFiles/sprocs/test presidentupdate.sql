 
declare @Message varchar(500) = '', @return int, @partyid int, @num int, @presidentid int

select top 1 @partyid = partyId from Party
select @num = max(p.Num) + 1 from President p

 
exec @return = PresidentUpdate
    @PresidentId = @presidentid output,
    @PartyId = @partyid,
    @Num = @num,
    @FirstName = 'Will',
    @LastName = 'Sill',
    @DateBorn = '1/1/2090',
    @DateDied = null,
    @TermStart = 2130,
    @TermEnd = null,
    @Message = @Message output

 select @return, @Message, @presidentid

 select * from president p where PresidentId= @presidentid

 
delete from ExecutiveOrder where PresidentId = @presidentid;

 
delete from President where PresidentId = @presidentid;

 
if not exists (select 1 from President where PresidentId = @presidentid)
begin
    print 'President and related Executive Orders deleted successfully.'
end
else
begin
    print 'Deletion failed. President still exists.'
end