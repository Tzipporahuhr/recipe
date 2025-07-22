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

    set @RecipeId= isnull(@RecipeId,0)  ----
    declare @return int = 0

	if isnull (Ltrim(rtrim(@RecipeName)), '') = ''----
	begin 
	     set @return=1  ----
		 set @Message = 'Recipe RecipeName cannot be blank'---
		 goto finished--
end--

if @Calories <=0
begin
	set @return=1
	set @message= 'Recipe Calories must be greater than zero'
	goto finished
end

if @DateDrafted >getdate()
begin
	set @return = 1
	set @Message= 'Recipe DateDrafted cannot be in the future'
goto finished
end

if @DateDrafted is not null and @DatePublished is not null
begin
    if @DateDrafted > @DatePublished
    begin
        set @return = 1;
        set @Message = 'Recipe DateDrafted must be before DatePublished';
        goto finished;
    end
end

if @RecipeId= 0
begin

insert Recipe (StaffId, CuisineId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
       values (@StaffId, @CuisineId, @RecipeName, @Calories, @DateDrafted, @DatePublished, @DateArchived)

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
		 return @return
end 
go





    