create or alter procedure dbo.RecipeGet
	@RecipeId int = 0,
	@All bit = 0,
	@RecipeName varchar(100) = ''
as
begin
	select r.RecipeId, r.StaffId, r.CuisineId, r.RecipeName, r.Calories,
	       r.DateDrafted, r.DatePublished, r.DateArchived, r.RecipePic, r.RecipeStatus
	from Recipe r
	where 
		(@RecipeId = 0 or r.RecipeId = @RecipeId)
		and (@All = 1 or @All = 0)
		and (r.RecipeName like '%' + @RecipeName + '%' or @RecipeName = '')
	order by r.RecipeName
end
go
/*
exec RecipeGet

exec RecipeGet  @All=1
 
--exec RecipeGet @RecipeId=161

declare @id int
select top 1 @id=r.RecipeId from Recipe r
 exec RecipeGet @RecipeId=@id
*/
 

