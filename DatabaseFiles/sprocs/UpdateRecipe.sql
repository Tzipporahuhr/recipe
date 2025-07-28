create or alter proc dbo.RecipeUpdate
(
    @RecipeId int output,
    @StaffId int,
    @CuisineId int,
    @RecipeName varchar (100),
    @Calories int,
    @DateDrafted date=null,
    @DatePublished date=null,
    @DateArchived date =null,
    @Message varchar (500) = '' output
)
as
begin

    set @RecipeId= isnull(@RecipeId,0)  
     
 

if @RecipeId= 0
begin

insert Recipe (StaffId, CuisineId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
       values (@StaffId, @CuisineId, @RecipeName, @Calories,
	   Isnull(@DateDrafted, getdate()),  
	   @DatePublished, @DateArchived)

	   set @RecipeId= SCOPE_IDENTITY()
	   end 
	   else
	   begin

	   update Recipe 
	   set  
			StaffId = @StaffId,
            CuisineId = @CuisineId,
            RecipeName = @RecipeName,
            Calories = @Calories,
            DateDrafted = @DateDrafted,
            DatePublished = @DatePublished,
            DateArchived = @DateArchived
      where RecipeId = @RecipeId
      end 

		 finished:
		 return 0;
end 
go

 