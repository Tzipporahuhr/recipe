create or alter procedure dbo.RecipeGet(@RecipeId int=0,@All bit=0)
as
begin
	 select r.RecipeId, r.StaffId, r.CuisineId,  r.RecipeName, r.Calories, r.DateDrafted, r.DatePublished, r.DateArchived, r.RecipePic, r.RecipeStatus
	 from Recipe r
	 where r.RecipeId=@RecipeId
	 or @All=1
	 order by r.RecipeName, r.Calories, r.DateDrafted, r.DatePublished, r.DateArchived, r.RecipePic, r.RecipeStatus
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
 

