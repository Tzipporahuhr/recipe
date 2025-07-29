/*
Our website development is underway! 
Below is the layout of the pages on our website, please provide the SQL to produce the necessary result sets.

Note: 
a) When the word 'specific' is used, pick one record (of the appropriate type, recipe, meal, etc.) for the query. 
    The way the website works is that a list of items are displayed and then the user picks one and navigates to the "details" page.
b) Whenever you have a record for a specific item include the name of the picture for that item. That is because the website will always show a picture of the item.
*/
/*
Home Page
    One result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
*/
select Item='Recipes', Count=count(RecipeId) 
from recipe r
union select Item='Meals', Count=count(MealId) 
from meal m
union select Item='Cookbooks', Count=COUNT(CookBookId) 
from CookBook c

/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. 
	Archived recipes should appear gray. Surround the archived recipe with <span style="color:gray">recipe name</span>
    In the resultset show the Recipe with its status, dates it was published and archived in mm/dd/yyyy format (blank if not archived), user, number of calories and number of ingredients.
    Tip: You'll need to use the convert function for the dates
*/  
select s.UserName, r.calories, NumberOfIngredient=count(distinct ri.IngredientId), r.recipestatus, 
RecipeName = case
when r.DateArchived is not null then  concat('<span style="color:gray">', r.RecipeName, '</span>')
else r.RecipeName 
end,
DatePublished=format(r.datepublished, 'mm/dd/yyyy'),
DateArchived = format(r.DateArchived, 'mm/dd/yyyy')
from Recipe r
join Staff s 
on s.staffid = r.staffid
join RecipeIngredient ri
on ri.recipeid = r.recipeid
where r.DatePublished is not null
or r.DateArchived is not null
group by r.RecipeName, r.DatePublished, s.UserName, r.calories, r.DateArchived, r.recipestatus
order by recipestatus desc

/*
Recipe details page:
    Show for a specific recipe (three result sets):
        a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
        b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
        c) List of prep steps sorted by sequence.
*/
select r.RecipeName, r.Calories, NumberOfIngredients=count (distinct ri.IngredientId), NumberOfDirections=count(distinct d.DirectionId), r.RecipePic
from Recipe r
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId 
join Direction d 
on d.RecipeId = r.RecipeId
where r.RecipeName = 'Butter Muffins'
group by r.RecipeName, r.Calories, r.RecipePic

select  Recipe=concat(ri.MeasurementQuantity, ' ', m.MeasurementType, ' ', i.IngredientName), r.RecipePic
from Ingredient i
join RecipeIngredient ri 
on ri.IngredientId = i.IngredientId
join Measurement m 
on m.MeasurementId = ri.MeasurementId
join Recipe r 
on r.RecipeId = ri.RecipeId
where r.RecipeName = 'Butter Muffins'
order by ri.IngredientOrder

select r.RecipeName, d.DirectionDesc, d.SequenceOrder, r.RecipePic
from direction d
join recipe r
on r.RecipeId= d.RecipeId
where r.RecipeName= 'Butter Muffins'
order by d.SequenceOrder

/*
Meal list page:
    For all active meals, show the meal name, user that created the meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/
select m.MealName, s.UserName, TotalCalories = sum (r.Calories), NumberOfCourses= count (distinct c.CourseId), NumberOfRecipes = count (distinct cmr.RecipeId) 
from Meal m
join Staff s 
on s.StaffId = m.StaffId
join CourseMeal cm 
ON cm.MealId = m.MealId
join Course c 
on c.CourseId = cm.CourseId
join CourseMealRecipe cmr 
on cmr.CourseMealId = cm.CourseMealId
join Recipe r 
on r.RecipeId = cmr.RecipeId
where m.Active = 1
group by m.MealName, s.UserName
order by m.MealName

/*
Meal details page:
    Show for a specific meal:
        a) Meal header: meal name, user, date created.
        b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
			Format for main course: CourseType: Main/Side dish - Recipe Name. 
            Format for non-main course: CourseType: Recipe Name
            Main dishes of the main course should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - Onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard


*/
select m.MealName, s.UserName, DateCreated = m.DateInserted, m.MealNamePic
from Meal m
join Staff s 
on s.StaffId = m.StaffId
where  m.MealName = 'Breakfast'

select c.coursename, 
RecipeDescription= Case
when  c.coursename = 'Main' and cmr.IsMain= 1 then concat('<b>', c.CourseName, ': Main Dish-', r.RecipeName,'</b>')  
when c.coursename='Main' and cmr.Ismain= 0 then concat('<b>', c.CourseName, ': Side dish - ', r.RecipeName , '</b>')
else c.coursename + ': '+ r.recipename
end
from meal m
join CourseMeal cm
on cm.MealId= m.MealId
join course c
on c.CourseId= cm.CourseId
join CourseMealRecipe cmr
on cmr.CourseMealId= cm.CourseMealId
join recipe r
on cmr.RecipeId= r.RecipeId
where c.CourseName='Starter'

 /*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/
select s.FirstName, s.LastName, NumberOfRecipes=Count (r.RecipeId), c.CookBookName
from CookBook c
join Staff s 
on c.StaffId = s.StaffId
join  Recipe r 
on s.StaffId = r.StaffId
where c.CookBookActive = 1
group by s.FirstName, s.LastName, c.CookBookName
order by c.CookBookName

/*
Cookbook details page:
    Show for specific cookbook:
    a) Cookbook header: cookbook name, user, date created, price, number of recipes.
    b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
        Note: User will click on recipe to see all ingredients and steps.
*/
select c.CookBookName, s.UserName, c.Datecreated, c.Price, NumberOfRecipes=count(r.RecipeName), c.CookBookNamePic
from CookBook c
join staff s
on s.StaffId= c.StaffId
join RecipeCookBook rc
on rc.CookBookId= c.CookBookId
join Recipe r
on r.RecipeId= rc.RecipeId
where c.CookBookName= 'Dinner Done'
group by c.CookBookName, s.UserName, c.Datecreated, c.Price, c.CookBookNamePic
 
select  r.RecipeName, cu.CuisineName, NumberOfIngredients= count(distinct ri.IngredientId), NumberOfSteps=count (distinct d.DirectionId), rc.RecipeCookBookSequence 
from CookBook c
join RecipeCookBook rc 
on  rc.CookBookId = c.CookBookId
join  Recipe r 
on r.RecipeId = rc.RecipeId
join Cuisine cu 
on  cu.CuisineId = r.CuisineId
join RecipeIngredient ri 
on  ri.RecipeId = r.RecipeId
join Direction d 
on d.RecipeId = r.RecipeId
where c.CookBookName = 'Dinner Done'
Group by r.RecipeName, cu.CuisineName, r.RecipeId, rc.RecipeCookBookSequence
order by rc.RecipeCookBookSequence

/*
April Fools Page:
    On April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. 
    The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
        There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
        Note: ".jpg" file extension must be at the end of the reversed picture name EX: Recipe_Seikooc_pihc_etalocohc.jpg
    b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
        Hint: Use CTE
*/
select ReversedRecipeName = concat (upper(left (reverse(lower(r.RecipeName)), 1)),substring(reverse(lower(r.RecipeName)), 2, len(r.RecipeName))),
ReversedPicName = concat('Recipe_', reverse(lower(r.RecipeName)), '.jpg')
from CookBook c
join RecipeCookBook rcb 
on rcb.CookBookId = c.CookBookId
join Recipe r 
on r.RecipeId = rcb.RecipeId;

; with x as (
    select r.RecipeName, Steps = d.DirectionDesc, d.SequenceOrder,
        RowNum =row_number()over(Partition by r.RecipeId order by d.SequenceOrder desc) 
    from Recipe r
    join Direction d 
    on r.RecipeId = d.RecipeId
    )
select x.RecipeName, x.Steps
from  x
join Recipe r 
on r.RecipeName=x.RecipeName
join Direction d
on d.RecipeId= r.RecipeId
where x.RowNum = 1
/*
For site administration page:
5 seperate reports
    a) List of how many recipes each user created per status. Show 0 if user has no recipes at all.
    b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
    c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    e) List of archived recipes that were never published, and how long it took for them to be archived.
*/
select s.UserName, NumberOfRecipes=count(r.RecipeId), r.recipestatus
from staff s
left join Recipe r
on s.StaffId= r.StaffId
group by s.UserName, r.Recipestatus

select s.UserName, NumberOfRecipesCreated=count(r.DateDrafted), AverageDaysToPublish=avg(datediff(day, r.DateDrafted, r.DatePublished))
from staff s
join Recipe r
on s.StaffId= r.StaffId
where r.DateDrafted is not null
and r.DatePublished is not null 
group by s.UserName, r.DateDrafted, r.DatePublished

select s.UserName,
    NumberOfMeals = count(m.MealId),
    NumberOfActiveMeals = sum(case when  m.Active = 1 then 1 else 0 end),
    NumberOfInactiveMeals = sum(case  when m.Active = 0 then 1 else 0 end)
from staff s
left join Meal m 
on  m.StaffId = s.StaffId
group by s.UserName
 
select s.UserName, NumberOfCookBooks=count(c.CookBookId), 
 TotalActiveCookBooks=sum
 (case
     when c.CookBookActive = 1 then 1 
     else 0 
end),
TotalNonActiveCookBooks=sum(case
     when c.CookBookActive = 0 then  1 
    else 0 
     end) 
from staff s
left join CookBook c 
on s.StaffId = c.StaffId
group by s.UserName
 
select r.DateArchived, r.RecipeName, ArchivedRecipes=datediff(day,r.DateDrafted,r.DateArchived)
from Recipe r
where r.DateArchived is not null
and r.DatePublished is null

/*
For user dashboard page:
    a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
        Tip: If you would like, you can use a CTE to get the User Id once instead of in each union select
    b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.
    
    OPTIONAL CHALLENGE QUESTION
    c) Show a list of cuisines and the count of recipes the user has per cuisine, 0 if none
        Hint: Start by writing a CTE to give you cuisines for which the user does have recipes. 
*/
select ItemName='Recipes', NumberOf=count(r.RecipeId) 
from Staff s
join Recipe r 
on r.StaffId = s.StaffId
where s.UserName = 'tuhr'

union select ItemName='Meals', NumberOf=count(m.MealId) 
from Staff s
join Meal m 
on  m.StaffId = s.StaffId
where s.UserName = 'tuhr'

union select ItemName='Cookbooks', NumberOf=count(c.CookBookId) 
from Staff s
join CookBook c 
on c.StaffId = s.StaffId
where s.UserName = 'tuhr'

--List of the user's recipes,
-- display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.

select s.UserName, r.RecipeName, 
NumberOfHoursTillDatePublished= case 
    when r.datepublished is not null then datediff(hour, datedrafted, datepublished)
 else ''
  end,
NumberOfHoursTillDateArchived= case when r.datearchived is not null then datediff(hour, datepublished, datearchived)
  else ''
  end
from staff s
join Recipe r
on s.StaffId=r.StaffId
 
 

 