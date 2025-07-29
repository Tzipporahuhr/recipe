 declare @id int

select top  1 @id= r.RecipeId from Recipe r

select @id
exec RecipeGet @RecipeId=@id