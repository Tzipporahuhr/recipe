create or alter procedure dbo.RecipeDelete(
	@RecipeId int
)
as 
  begin
       begin try
	   begin tran
	
	delete from RecipeIngredient where RecipeId = @RecipeId;
	delete from Direction where RecipeId = @RecipeId;
    delete from Recipe where RecipeId = @RecipeId;

	commit
end try
begin catch
			if @@TRANCOUNT> 0 rollback;
			throw;
			end catch
end
go

	   
 