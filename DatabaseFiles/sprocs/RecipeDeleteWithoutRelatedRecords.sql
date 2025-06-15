create or alter procedure dbo.RecipeDelete(
		@RecipeId int
)
as
  begin
       begin try
       begin tran

        delete from CourseMealRecipe   where RecipeId = @RecipeId;
        delete from RecipeCookBook     where RecipeId = @RecipeId;
		delete from Direction          where RecipeId=@RecipeId
		delete from RecipeIngredient   where RecipeId =@RecipeId;
        delete from Recipe             where RecipeId = @RecipeId;

        commit
        end try
        begin catch
        rollback;
        throw;
        end catch
end
go