use RecipeDB

drop table if exists RecipeCookBook
go
drop table if exists CookBook
go
drop table if exists CourseMealRecipe
go
drop table if exists CourseMeal
go
drop table if exists Course
go
drop table if exists Meal
go
drop table if exists Direction
go
drop table if exists RecipeIngredient
go
drop table if exists Ingredient
go
drop table if exists Measurement
go
drop table if exists Recipe
go
drop table if exists Cuisine
go
drop table if exists Staff
go
 
Create table dbo.Staff(
    StaffId int not null identity primary key,
    FirstName varchar(50) not null
        constraint c_staff_Firstname_cannot_be_blank check (FirstName<> ''),
    LastName  varchar(50) not null
        constraint c_staff_Lastname_cannot_be_blank check (LastName<> ''),
    UserName varchar(50) not null constraint u_Staff_Username unique
         constraint c_staff_Username_cannot_be_blank check (UserName<> ''),
)
go

Create table dbo.Cuisine(
    CuisineId int not null identity primary key,
    CuisineName varchar(50) not null constraint u_Cuisine_CuisineName unique
        constraint c_Cuisine_CuisineName_cannot_be_blank check (CuisineName<> '')
)
go  

Create table dbo.Recipe (
    RecipeId int not null identity primary key,
    StaffId int not null constraint f_Staff_Recipe foreign key references Staff(StaffId),
    CuisineId int not null constraint f_Cuisine_Recipe foreign key references Cuisine(CuisineId),
    RecipeName varchar(50)  not null constraint u_Recipe_RecipeName unique
        constraint c_Recipe_RecipeName_cannot_be_blank check (RecipeName<> ''),
    Calories int not null
        constraint c_Recipe_Calories_bought_must_be_greater_than_zero check (calories >0),
    DateDrafted   date  null constraint d_Recipe_RecipeCreated default getdate(),
                constraint c_Recipe_DateDrafted_must_not_be_future check (DateDrafted <= GETDATE()),
    DatePublished date null
                constraint c_Recipe_DatePublished_must_not_be_future check (DatePublished is null or DatePublished <= GETDATE()),
    DateArchived  date null
                constraint c_Recipe_DateArchived_must_not_be_future check (DateArchived is null or DateArchived <= GETDATE()),
                constraint c_Recipe_DateDrafted_must_before_datePublished check  (DateDrafted< DatePublished),
                constraint c_Recipe_DateArchived_must_after_datedrafted_and_datepublished check (DateArchived> DateDrafted and DateArchived >DatePublished),
     RecipePic as concat('Recipe ', '_', replace(RecipeName, ' ','_'), '.jpg') persisted,
     RecipeStatus as
     case when datearchived is not null then 'Archived'
          when datepublished is not null then 'Published'
          else 'drafted'
          end persisted,
) 
go
 
Create table dbo.Measurement(
    MeasurementId int not null identity primary key,
    MeasurementType varchar(50) not null constraint u_Measurement_Measurement_Type unique
        constraint c_Measurement_MeasurementType_cannot_be_blank check (MeasurementType<> '')
)
go

Create table dbo.Ingredient(
    IngredientId int not null identity primary key,
    IngredientName varchar(75) constraint u_Ingredient_IngredientName unique
        constraint c_Ingredient_IngredientName_cannot_be_blank check (IngredientName<> ''),
    IngredientNamePic as  concat(IngredientName, '_', replace(IngredientName,' ', '_'),'.jpg') persisted
)
go
 
Create table dbo.RecipeIngredient(
    RecipeIngredientId int not null identity primary key,
    RecipeId      int not null constraint fk_RecipeIngredient_Recipe foreign key references Recipe (RecipeId),
    IngredientId  int not null constraint fk_RecipeIngredient_Ingredient foreign key references Ingredient(IngredientId),
    MeasurementId int not null constraint fk_RecipeIngredient_Measurement foreign key references Measurement(MeasurementId),
    MeasurementQuantity int
        constraint c_RecipeIngredient_MeasurementQuantity_must_be_greater_than_zero check (MeasurementQuantity >0),  
    IngredientOrder int
        constraint c_RecipeIngredient_IngredientOrder_must_be_greater_than_zero check (IngredientOrder >0),  
        constraint c_RecipeIngredient_RecipeId_and_IngredientId_must_be_unique unique (RecipeId, IngredientId)
)
go
 
Create table dbo. Direction(
    DirectionId int not null identity primary key,
    RecipeId int not null constraint f_Direction_Recipe foreign key references Recipe(RecipeId),
    SequenceOrder int not null
        constraint c_Direction_SequenceOrder_must_be_greater_than_zero check (SequenceOrder >0),  
    DirectionDesc varchar (200) not null
        constraint c_Direction_Directiondesc_cannot_be_blank check (DirectionDesc<> ''),
        constraint c_Direction_RecipeId_and_SequenceOrder_must_be_unique unique(RecipeId, SequenceOrder)
 )
go

Create table dbo.Meal(
    MealId    int not null identity primary key,
    StaffId   int   null constraint fk_Meal_Staff foreign key references Staff(StaffId),
    MealName  varchar  (50) not null constraint u_Meal_MealName unique
        constraint c_Meal_MealName_cannot_be_blank check (MealName<> ''), 
    DateInserted date 
        constraint d_Meal_DateInserted default getdate(),
        constraint c_Meal_DateInserted_must_not_be_future check (dateinserted<= getdate()),
    Active    bit not null constraint d_Meal_Active default 1,
    MealNamePic as concat(MealName, '_', replace(MealName,' ','_'), '.jpg') persisted
)
go 

Create table dbo.Course(
    CourseId   int not null identity primary key,
    CourseName varchar (50) not null constraint u_Course_CourseName unique
         constraint c_course_CourseName_cannot_be_blank check (CourseName<> ''),
    CourseSequence int not null constraint u_Course_CourseSequence unique
         constraint c_course_CourseSequence_must_be_greater_than_zero check (CourseSequence > 0) 
)
go

Create table dbo.CourseMeal(
    CourseMealId int not null identity primary key,
    CourseId int not null constraint f_CourseMeal_Course foreign key references Course(CourseId),
    MealId int not null constraint f_CourseMeal_Meal foreign key references Meal(MealId),
    IsMain bit not null constraint d_CourseMeal_IsMain default 1,
    constraint c_CourseMeal_CourseId_and_MealId_must_be_unique unique(CourseId, MealId),
)
go
 
Create table dbo.CourseMealRecipe(
    CourseMealRecipeId int not null identity primary key,
    CourseMealId int not null constraint f_CourseMealRecipe_CourseMeal foreign key references CourseMeal(CourseMealId),
    RecipeId int not null constraint f_CourseMealRecipe_Recipe foreign key references Recipe(RecipeId),
    constraint c_CourseMealRecipe_CourseMealId_and_RecipeId_must_be_unique unique(CourseMealId, RecipeId),
    IsMain bit not null constraint d_CourseMealRecipe_IsMain default 1
 )
go 

Create table dbo.CookBook(
    CookBookId      int not null identity primary key,
    StaffId         int not null constraint f_CookBook_Staff foreign key references Staff(StaffId),
    CookBookName    varchar (30) not null constraint u_CookBook_CookBookName unique
         constraint c_CookBook_CookBookName_cannot_be_blank check (CookBookName<> ''),
    Price           decimal (10,2)
        constraint c_CookBook_Price_must_be_greater_than_zero check (Price >0),
    Datecreated     date  constraint d_CookBook_DateCreated default getdate(),
    CookBookActive   bit not null constraint d_CookBook_CookBookActive default 1,
    CookBookNamePic as concat(CookBookName, '_', replace(cookbookname, ' ', '_'), '.jpg') persisted
)
go
  
Create table dbo.RecipeCookBook(
    RecipeCookBookId int not null identity primary key,
    CookBookId int not null constraint f_RecipeCookBook_CookBook foreign key references CookBook(CookBookId),
    RecipeId int not null constraint f_RecipeCookBook_Recipe foreign key references Recipe(RecipeId),
    RecipeCookBookSequence int not null
        constraint c_RecipeCookBook_RecipeCookBookSequence_must_be_greater_than_zero check (RecipeCookBookSequence >0),
        constraint u_RecipeCookBook_CookBookId_RecipeCookBookSequence unique (CookBookId, RecipeCookBookSequence),
        constraint u_RecipeCookBook_CookBookId_and_RecipeId unique(CookBookId, RecipeId)
)
go
 
     
 
   
        
   