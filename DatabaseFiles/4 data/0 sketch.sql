
 /*
 Staff
    StaffId
    First Name varchar(35)
    Last Name varchar(35)
    username varchar(50)
    unique first and last name

Cuisine
    CuisineId
    CuisineName varchar(50)
 
Recipe
    RecipeId
    StaffId(FK)
    CuisineId(FK)
    RecipeName varchar(100)unique
    calories int(1000)
    RecipeCreated date
    RecipePublished date
    ArchiveDraft date
    Published date
    Archive date
-computed column RecipeStatus varchar(100)
 
     

MeasurementType:
    MeasurementTypeId
    MeasurementType varchar(5o)
    

 
 Ingrediants:
    IngrediantId
    IngrediantName varchar(100)unique
    --IngrediantOrder varchar(50)unique
    --IngrediantDescription varchar(100)
    --steps int
    

RecipeIngrediant:
    RecipeId(FK)
    IngrediantId(FK)
    MeasurementId(Fk)
    --IngrediantOrder int

Direction
    DirectionId
    RecipeId(Fk)
    SequencenOrder int
    DirectionDesc varchar(200)

   
     
Meal
    MealId  
    StaffId(FK)
    MealMame varchar (50) unique
    date inserted date
    Active/NonActive default

Course:
    CourseId
    CourseName varchar(50)
    Course sequence int
     
CourseMeal:
    CourseMealId
    CourseId
    MealId(FK)

CourseMealRecipe:
    CourseMealId
    RecipeId

 
CookBook:
    CookBookId
    DirectionId(FK)
    StaffId(FK)
    RecipeId(FK)
    CookBookName varchar(25) unique
    Price int 
    RecipeName varchar(25) unique
    SequenceOrder int ???????????????????is this necessary
    Active/nonactive default

RecipeCookBook:
CookBookId
RecipeId

 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 jI dont understand these two Statements:
1) cusine,recipescuisine type-chinese or mediteranian - it can only be one or another?? Is this a default 
--AF I'm not sure I understand, where did you get these statements from?
     
2) use an x Pictures-name of picts according recipe/family/pizza
name of type
ingrediants/baby/carrot- name pics according to format 
--I dont understand what I am suppose to do regarding the 
--AF The image links should be added as a computed column for any tables whose data is supposed to have an image


HomeworkComments:

--use a x for recipe name from recipe table
    
-- Im am not sure which tables i can use an x for
what do you mean to use an x?
For which tables do I use the x to insert my data?
--AF There's not a blanket answer, sometimes data can be inserted with or without a cte depending on how you want to write it the insert statement.
When there are no related tables involved in the table you are inserting into, it's not generally helpful to use a cte.
When you are inserting data into a table with a foreign key to other tables, many times it's easier to use a cte to get some of that data

 --AF I think a clearer name for this table would be RecipeIngredient
     --AF This should be in the RecipeIngredient table
       --AF You already are recodimg the amount of the ingredient in the IngredientStatus table, no need for it here too