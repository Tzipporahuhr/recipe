create or alter procedure dbo.RecipeDelete(
    @RecipeId int, 
    @Message varchar(1000)= '' output
)
as
begin
    declare @return int = 0

    
    if not exists (select 1 from Recipe where RecipeId = @RecipeId 
          and (
              (DateArchived is not null and DateArchived <= dateadd(day, -30, getdate()))
              or (DatePublished is null and DateArchived is null)
              )
    )
    begin
        set @return = 1
        set @Message = 'Recipe cant be deleted unless it is either drafted or archived for more than 30 days.'
        return @return
    end

begin try
        begin tran

        delete from RecipeIngredient where RecipeId = @RecipeId;
        delete from Direction where RecipeId = @RecipeId;
        delete from Recipe where RecipeId = @RecipeId;

        commit
    end try
    begin catch
               if @@TRANCOUNT > 0 rollback;
        throw;
    end catch

    return @return
end
go

	   
 