
--Note: some of these scripts are needed for specific items, when the instructions say "specific" pick one item in your data and specify it in the where clause using a unique value that identifies it, do not use the primary key.

--1) Sometimes when a staff member is fired. We need to eradicate everything from that user in our system.
-- Write the SQL to delete a specific user and all the user's related records.

delete rc
 --select * 
from RecipeCookBook rc
join cookbook c
on rc.CookBookId = c.CookBookId
join staff s
on s.staffid=c.staffid

delete c
 --select *
from CookBook c
join staff s
on s.StaffId= c.StaffId
where s.username='Psmith'

delete cmr
 --select *
from CourseMealRecipe cmr
join recipe r
on r.RecipeId=cmr.RecipeId
join staff s
on s.staffid=r.staffid
where s.UserName= 'Psmith'

delete cmr
 --select *
from CourseMealRecipe cmr
join CourseMeal m
on m.CourseMealId=cmr.CourseMealId
join meal l
on l.MealId = m.MealId
join staff s
on s.staffid=l.staffid
where s.UserName= 'Psmith'

delete cm
 --select *
from CourseMeal cm
join Meal m
on m.MealId= cm.MealId
join staff s
on s.StaffId= m.StaffId
where s.UserName= 'Psmith'

delete m
 --select *
from Meal m
join staff s
on s.StaffId= m.StaffId
where s.UserName= 'Psmith'
 
delete d
 --select * 
from Direction d
join recipe r
on r.RecipeId= d.RecipeId
join staff s
on s.StaffId =r.StaffId
where s.UserName= 'Psmith'

delete ri
 --select *
from RecipeIngredient ri
join Recipe r
on r.RecipeId= ri.RecipeId
join staff s
on s.StaffId= r.StaffId
where s.UserName= 'Psmith'

delete r
 --select *
from recipe r
join staff s
on r.StaffId= s.StaffId
where s.UserName= 'Psmith'

delete s
 --select *
from staff s
where s.UserName= 'Psmith'

 --2) Sometimes we want to clone a recipe as a starting point and then edit it. 
--For example we have a complex recipe (steps and ingredients) and want to make a modified version.
-- Write the SQL that clones a specific recipe, add " - clone" to its name.

insert Recipe ( StaffId, CuisineId, RecipeName, Calories, DateDrafted, DatePublished,  DateArchived)
select  r.staffid, r.cuisineid,  ClonedRecipe=concat(r.RecipeName, '-clone'), r.calories, r.datedrafted, r.datepublished, r.datearchived
from recipe r
where r.RecipeName= 'Potato Kugel'

insert RecipeIngredient(RecipeId, IngredientId,  MeasurementId, MeasurementQuantity, IngredientOrder )
select (select r.RecipeId from Recipe r where r.RecipeName='Potato Kugel-clone'),ri.IngredientId, ri.MeasurementId, ri.MeasurementQuantity, ri.IngredientOrder
from RecipeIngredient ri
join recipe r
on r.RecipeId= ri.RecipeId
where r.RecipeName= 'Potato kugel'

insert Direction(RecipeId, SequenceOrder, DirectionDesc)
select  (select r.RecipeId from Recipe r where r.RecipeName='Potato Kugel-clone'), d.sequenceOrder, d.directiondesc
from direction d
join recipe r
on d.recipeid= r.recipeid
where r.Recipename='potato kugel'

/*
3) We offer users an option to auto-create a recipe book containing all of their recipes. 
Write a SQL script that creates the book for a specific user and fills it with their recipes.
The name of the book should be Recipes by Firstname Lastname. 
The price should be the number of recipes multiplied by $1.33
Sequence the book by recipe name.

Tip: To get a unique sequential number for each row in the result set use the ROW_NUMBER() function. See Microsoft Docs.
	 The following can be a column in your select statement: Sequence = ROW_NUMBER() over (order by colum name) ,
	 -- replace column name with the name of the column that the row number should be sorted
*/ --I wasnt sure which result set  makes more sence here
; with x as (
select s.StaffId, RecipeCount=count(r.RecipeId) 
from staff s
left join recipe r 
on  r.StaffId = s.StaffId
where s.FirstName='Sara'
group by s.StaffId)

insert CookBook (StaffId, CookBookName,  Price , Datecreated)
select x.StaffId, RecipeStaff=concat('RecipesBy: ', s.FirstName, ' ',s.LastName), Price=count(x.RecipeCount)*1.33, getdate()
from x
join staff s
on s.StaffId= x.StaffId
where s.UserName='SSushi'
group by x.StaffId, s.FirstName, s.LastName


insert RecipeCookBook (CookBookId, RecipeId, RecipeCookBookSequence)
select c.CookBookId, r.RecipeId,  row_number() over(order by r.recipename)
from   Recipe r
join staff s
on s.StaffId= r.StaffId
join CookBook c
on c.StaffId = s.StaffId
where  c.CookBookName='RecipesBy: Sara Sushi'

/*
4) Sometimes the calorie count of of an ingredient changes and we need to change the calorie total for all recipes that use that ingredient.
Our staff nutritionist will specify the amount to change per measurement type, and of course multiply the amount by the quantity of the ingredient.
For example, the calorie count for butter went down by 2 per ounce, and 10 per stick of butter. 
Write an update statement that changes the number of calories of a recipe for a specific ingredient. 
The statement should include at least two measurement types, like the example above.
*/

update r
set Calories=  
case 

    when m.MeasurementType ='cup' then (r.Calories *6)* MeasurementQuantity
    when m.MeasurementType='TBSP' then (r.Calories *3)* MeasurementQuantity
else  r.Calories 
end
from Recipe r
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId
join  Ingredient i 
on i.IngredientId = ri.IngredientId
join Measurement m 
on m.MeasurementId = ri.MeasurementId
where i.IngredientName = 'flour'
 

/*
5) We need to send out alerts to users that have recipes sitting in draft longer the average amount of time that recipes have taken to be published.
Produce a result set that has 4 columns (Data values in brackets should be replaced with actual data)
	User First Name, 
	User Last Name, 
	email address (first initial + lastname@heartyhearth.com),
	Alert: 
		Your recipe [recipe name] is sitting in draft for [X] hours.
		That is [Z] hours more than the average [Y] hours all other recipes took to be published.
*/
; with x as(
select r.recipename, AvgHoursSittingInDrafted=avg(datediff(hour, r.DateDrafted, r.datepublished))
        from recipe r 
		group by r.RecipeName
          )
select  s.FirstName, s.LastName,   
Email = lower(concat(substring(s.FirstName, 1, 1), s.LastName, '@heartyhearth.com')),
Alert= concat( 'Your recipe ', r.RecipeName, ' is sitting in draft for ', datediff(hour, r.datedrafted, getdate()), ' hours. ', 'That is ',
datediff(hour, r.datedrafted, GETDATE()) - x.AvgHoursSittingInDrafted,' hours more than the average ', x.AvgHoursSittingInDrafted,' hours all other recipes took to be published.') 
from x
join recipe r
on x.RecipeName= r.RecipeName
join staff s 
on r.StaffId = s.StaffId
where RecipeStatus='drafted'
and x.AvgHoursSittingInDrafted <  datediff(hour, r.datedrafted, getdate())
 


/*
6) We want to send out marketing emails for books. Produce a result set with one row and one column "Email Body" as specified below.
The email should have a unique guid link to follow, which should be shown in the format specified. 

Email Body:
Order cookbooks from HeartyHearth.com! We have [X] books for sale, average price is [Y]. You can order them all and recieve a 25% discount, for a total of [Z].
Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order.
*/
 
select EmailBody=concat( 'Order cookbooks from HeartyHearth.com! We have', count(*), 'books for sale, average price is $', avg(c.price), 
'You can order them all and recieve a 25%, for a total of', sum(c.price*0.75),'Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order')
from CookBook c
 
 


