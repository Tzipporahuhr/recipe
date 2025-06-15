create or alter procedure dbo.RecipeDelete(
	@RecipeId int
)
as 
begin
	  delete Recipe where RecipeId= @RecipeId
end
go