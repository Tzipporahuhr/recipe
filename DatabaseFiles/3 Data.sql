use RecipeDB
go

delete RecipeCookBook
go
delete CookBook
go
delete CourseMealRecipe
go
go
delete CourseMeal
go
delete Course
go
delete Meal
go
delete Direction
go
delete RecipeIngredient
go
delete Ingredient
go
delete Measurement
go
delete Recipe
go
delete Cuisine
go
delete Staff
go


--Staff:
insert Staff (FirstName, LastName, UserName)
select 'Tzipporah','Uhr', 'tuhr'
union select 'Peter', 'Smith', 'Psmith'
union select 'John', 'Smithy', 'Jsmithy'
union select 'Hoppy', 'Jones', 'HJones'
union select 'Sori', 'Frys', 'SFrys'
union select 'Sara', 'Sushi', 'SSushi' 
union select 'Lanny', 'Lad', 'LLad'
 
--Cuisine:
insert Cuisine(CuisineName)
select 'American'
union select  'French'
union select  'English'
union select 'haymishe'
 
--Recipe:
insert Recipe(StaffId, CuisineId, RecipeName, Calories,   DateDrafted, DatePublished,  DateArchived)
select       (select s.Staffid from Staff s where s.FirstName= 'Tzipporah'), cuisineid, 'Chocolate Chip Cookies', 75,   '1732-03-22', '1732-04-22',  '1732-05-22' from Cuisine c where c.CuisineName= 'American'
union select (select s.Staffid from Staff s where s.FirstName= 'Peter'),     cuisineid, 'Apple Yogurt Smoothie',  50,   '1756-02-22', '1757-02-22',  '1758-02-22' from Cuisine c where c.CuisineName= 'French'
union select (select s.Staffid from Staff s where s.FirstName= 'John'),      cuisineid, 'Cheese Bread',           100,  '1761-02-22', '1762-02-22',  '1763-02-22' from Cuisine c where c.CuisineName= 'English'
union select (select s.Staffid from Staff s where s.FirstName= 'Hoppy'),     cuisineid, 'Butter Muffins',         150,  '1767-02-22',         null,          null from Cuisine c where c.CuisineName= 'American'
union select (select s.Staffid from Staff s where s.FirstName= 'Sori'),      cuisineid, 'Potato Kugel',           70,   '1767-03-22',  '1782-02-22',          null from Cuisine c where c.CuisineName= 'English'
union select (select s.Staffid from Staff s where s.FirstName= 'Sara'),      cuisineid, 'Pizza',                  200,  '1782-02-22', '1783-02-22',  '1784-02-22' from Cuisine c where c.CuisineName= 'American'
union select (select s.Staffid from Staff s where s.FirstName= 'Lanny'),     cuisineid, 'French Fries',           80,   '1767-04-22',          null,  '1790-02-22' from Cuisine c where c.CuisineName= 'French'
union select (select s.staffid from staff s where s.FirstName='Tzipporah'),  cuisineid, 'Bread',                  90,   '1800-03-23', '1801-03-23',   '1802-04-22' from cuisine c where c.CuisineName= 'haymishe'
union select (select s.staffid from staff s where s.FirstName='Tzipporah'),  cuisineid, 'Guacamole',              50,   '1768-02-22', '1801-03-23',          null  from cuisine c where c.CuisineName= 'American'
union select (select s.staffid from staff s where s.FirstName='Sori'),       cuisineid, 'RiceCakes and Cheese',   45,   '1800-03-23', '1801-03-23',   '1802-04-22' from cuisine c where c.CuisineName= 'American'
  
 
--:Measurement:
insert Measurement(MeasurementType)
select 'cup'
union select 'tbsp'
union select 'stick'
union select 'tsp'
union select 'oz'
union select 'clove'
union select 'Pinch'
union select 'handful'
union select 'drizzle'
union select ' half cup'
union select 'whole'
union select 'half tsp'
union select 'club'
union select 'clove'
union select 'quarter tsp'
union select 'slice'
 
--Ingredient:
insert Ingredient(IngredientName)
select 'sugar'
union select 'salt'
union select 'lemon juice'
union select 'Avocado'
union select 'garlic salt'
union select 'cheese' 
union select 'oil' 
union select 'eggs' 
union select 'Flour' 
union select ' vanilla sugar' 
union select 'baking powder' 
union select 'baking soda' 
union select ' chocolate chips' 
union select 'granny smith apples'
union select 'vanilla yogurt'
union select 'orange juice'
union select 'honey'
union select 'ice cubes'
union select 'bread'
union select 'butter'
union select 'shredded cheese'
union select 'garlic'
union select 'black pepper'
union select 'salt'
union select 'vanilla pudding'
union select 'cream cheese'
union select 'sour cream cheese'
union select 'Potato'
union select 'onion'
union select ' yeast'
union select 'tomato sauce'
union select 'water' 
  
--RecipeIngredient:
; with x as
(
select RecipeName='Chocolate Chip Cookies', IngredientName='sugar', MeasurementType='cup', MeasurementQuantity=1, IngredientOrder=1
union select 'Chocolate Chip Cookies', 'oil', 'half cup', 1, 2
union select 'Chocolate Chip Cookies', 'eggs', 'whole', 3, 3
union select 'Chocolate Chip Cookies', 'flour', 'cup', 2, 4
union select 'Chocolate Chip Cookies', ' vanilla sugar', 'tsp', 1, 5
union select 'Chocolate Chip Cookies', 'baking powder', 'tsp', 2, 6
union select 'Chocolate Chip Cookies', 'baking soda', ' half tsp', 1, 7
union select 'Chocolate Chip Cookies', 'chocolate chips', 'cup', 1, 8
union select 'Apple Yogurt Smoothie', 'granny smith apples', 'whole', 3, 1
union select 'Apple Yogurt Smoothie', 'vanilla yogurt', 'cup', 2, 2
union select 'Apple Yogurt Smoothie', 'sugar', 'tsp', 2, 3
union select 'Apple Yogurt Smoothie', 'orange juice', ' half cup', 1, 4
union select 'Apple Yogurt Smoothie', 'honey', 'tbsp', 2, 5
union select 'Apple Yogurt Smoothie', 'ice cubes', 'tbsp', 5, 6
union select 'Cheese Bread', 'bread', 'club', 1, 1
union select 'Cheese Bread', 'butter', 'oz', 4, 2
union select 'Cheese Bread',  'shredded cheese', 'oz', 8, 3
union select 'Cheese Bread',  'garlic', 'clove', 2, 4
union select 'Cheese Bread',  'black pepper', ' quarter tsp', 1, 5
union select 'Cheese Bread',  'salt', 'pinch', 1, 6
union select 'Butter Muffins', 'butter', 'stick', 1, 1
union select 'Butter Muffins', 'sugar', 'cup', 3, 2
union select 'Butter Muffins','vanilla pudding', 'tbsp', 2, 3
union select 'Butter Muffins', 'eggs', 'whole', 4, 4
union select 'Butter Muffins', 'cream cheese', 'cup', 1, 5
union select 'Butter Muffins', 'sour cream cheese', 'cup', 1, 6
union select 'Butter Muffins', 'Flour', 'cup', 1, 7
union select 'Butter Muffins', 'baking powder', 'tsp', 2, 8
union select 'Potato Kugel', 'Potato', 'whole', 6, 1
union select 'Potato Kugel','onion', 'whole', 1, 2
union select 'Potato Kugel', 'eggs' , 'whole', 3, 3
union select 'Potato Kugel', 'oil', 'half cup', 1, 4
union select 'Potato Kugel', ' salt', 'pinch', 1, 5
union select 'Potato Kugel', 'black pepper', 'pinch', 1, 6
union select 'Pizza', ' half cup', 'handful', 1, 1
union select 'Pizza', ' water', 'half cup', 1, 2
union select 'Pizza', ' flour', 'cup', 2, 3
union select 'Pizza', 'salt', 'teaspoon', 1, 4
union select 'Pizza', 'baking soda', 'teaspoon', 2, 5
union select 'Pizza', 'tomato sauce', 'half cup', 1, 6
union select 'Pizza', 'shredded cheese', 'handful', 1, 7
union select 'Pizza', 'oil', 'drizzle', 1, 8
union select 'French Fries', 'potatoes', 'whole potatoes', 5,1
union select 'French Fries', 'oil', 'drizzle', 5,2
union select 'French Fries', 'salt', 'pinch', 5,3
union select 'Bread', 'flour', 'cup', 1, 1
union select 'Bread', 'yeast', 'Tbsp', 2, 2
union select 'Bread', 'salt', 'teaspoon', 1,3
union select 'Bread', 'water', 'cup', 1,4
union select 'Bread', 'sugar', 'cup', 1,5
union select 'Guacamole', 'avocados', 'cup', 1, 1
union select 'Guacamole', 'Lemon Juice', 'Tbsp', 1, 2
union select 'Guacamole', 'garlic', 'teaspoon',1, 3
union select 'Guacamole', 'salt', 'teaspoon', 1, 4
union select 'Guacamole', 'black pepper', 'teaspoon', 1,5
union select 'RiceCakes and Cheese', 'cheese', 'slice', 1, 1
union select 'RiceCakes and Cheese', 'rice cakes', 'slice', 1, 2
union select 'RiceCakes and Cheese', 'garlic pinch', 'pinch', 1, 3
)
insert RecipeIngredient(RecipeId, IngredientId, MeasurementId, MeasurementQuantity, IngredientOrder)
select r.recipeid, i.ingredientid, m.MeasurementId, x.MeasurementQuantity, x.IngredientOrder
from x
join recipe r
on r.RecipeName= x.RecipeName
join Ingredient i
on i.IngredientName=x.IngredientName
join Measurement m
on m.MeasurementType=x.MeasurementType

--Direction:
; with x as
(
select RecipeName='Chocolate Chip Cookies', SequenceOrder=1,  DirectionDesc='First combine sugar, oil and eggs in a bowl'   
union select 'Chocolate Chip Cookies', 2,  'mix well' 
union select 'Chocolate Chip Cookies', 3,  'add flour, vanilla sugar, baking powder and baking soda'
union select 'Chocolate Chip Cookies', 4,  'beat for 5 minutes'
union select 'Chocolate Chip Cookies', 5,  'add chocolate chips'
union select 'Chocolate Chip Cookies', 6,  'freeze for 1-2 hours'      
union select 'Chocolate Chip Cookies', 7,  'roll into balls and place spread out on a cookie sheet'      
union select 'Chocolate Chip Cookies', 8,  ' bake on 350 for 10 min.'     
union select 'Apple Yogurt Smoothie',  1,  'Peel the apples and dice'              
union select 'Apple Yogurt Smoothie',  2,  'Combine all ingredients in bowl except for apples and ice cubes'
union select 'Apple Yogurt Smoothie',  3,  'mix until smooth'
union select 'Apple Yogurt Smoothie',  4,  'add apples and ice cubes'
union select 'Apple Yogurt Smoothie',  5,  'pour into glasses.'
union select  'Cheese Bread', 1,           'Slit bread every 3/4 inch'
union select  'Cheese Bread', 2,           ' Combine all ingredients in bowl'
union select  'Cheese Bread', 3,           'fill slits with cheese mixture'
union select  'Cheese Bread', 4,           ' wrap bread into a foil and bake for 30 minutes.'
union select  'Butter Muffins', 1,         'Cream butter with sugars'
union select  'Butter Muffins', 2,         'Add eggs and mix well'
union select  'Butter Muffins', 3,         'Slowly add rest of ingredients and mix well'
union select  'Butter Muffins', 4,         'fill muffin pans 3/4 full and bake for 30 minutes'
union select 'Potato Kugel', 1,            'shred potatoes and onions'
union select 'Potato Kugel', 2,            'quickly add the eggs and oil' 
union select 'Potato Kugel', 3,            'add salt and pepper'
union select 'Potato Kugel', 4,            'fill pan and bake for 36 min'
union select 'Pizza', 1,                   'mix yeast and water'
union select 'Pizza', 2,                   'add flour and salt and b.soda'
union select 'Pizza', 3,                   'let sit for an hour'
union select 'Pizza', 4,                   'roll out on a pan'
union select 'Pizza', 5,                   'spread out sauce'
union select 'Pizza',6,                    'sprinkle a handfull of cheese'
union select 'Pizza', 7,                   'drizzle some oil'
union select 'Pizza', 8,                   'bake on a high temp for 25 min'
union select 'Bread', 1,                   'mix yeast, and water'
union select 'Bread', 2,                   'add flour and sugar and salt'
union select 'Bread', 3,                   'let sit for an hour'
union select 'Bread', 4,                   ' braid'
union select 'Bread', 5,                   'bake 350 for 20'
union select 'Guacamole', 1,               'Mash up avocados'
union select 'Guacamole', 2,               'Add lemon juice, garlic, pepper'
union select 'Guacamole', 3,               'mix well'
union select 'RiceCakes and Cheese', 1,    'Place a slice of cheese on a ricecake'
union select 'RiceCakes and Cheese', 2,    'sprinkle garlic salt'
union select 'RiceCakes and Cheese', 3,    'put in microwave for thirty seconds'
)
insert Direction(RecipeId, SequenceOrder,  DirectionDesc)
select r.recipeid, sequenceOrder,  x.DirectionDesc
from x
join Recipe r
on r.RecipeName= x.RecipeName

--Meal:
insert Meal(StaffId, MealName, DateInserted)
select       staffId,  'Breakfast', '1740-02-22'  from staff s where s.FirstName= 'Tzipporah'
union select StaffId,  'Brunch',    '1740-02-22'  from staff s where s.FirstName= 'Lanny'
union select StaffId,  'snack',     '1745-02-22'  from staff s where s.FirstName= 'Peter'
union select StaffId,  'lunch',     '1750-02-22'  from staff s where s.FirstName= 'John'
union select StaffId,  'tea',       '1755-02-22'  from staff s where s.FirstName= 'Hoppy'
union select StaffId,  'supper',    '1760-02-22'  from staff s where s.FirstName= 'Sori'
union select StaffId,  'second snack', '1765-02-22'  from staff s where s.FirstName='Tzipporah'
union select StaffId,  'third snack', '1762-02-22' from staff s where s.FirstName='Sori'
union select staffid,   'Dinner',     '1800-02-23'  from staff s where s.FirstName='Sara'

--Course:  
insert Course(CourseName, CourseSequence)
select       'Starter',      1
union select 'Entree',       2
union select 'Appetizer',    3
union select  'Main course',  4
union select 'Dessert',        5
union select 'MidNight Snack',  6
union select 'Pre-Breakfast',  7
union select 'Dinner',         8

--CourseMeal:
; with x as
(
select CourseName='Starter',   MealName='Breakfast'
union select      'Entree',             'Brunch'
union select      'Appetizer',          'snack'
union select      'Main course',        'lunch'
union select      'Dessert',            'tea'
union select      'MidNight Snack',     'Supper'
union select      'Pre-Breakfast',      'Dinner'
)
insert CourseMeal(CourseId, MealId)
select CourseId, MealId
from x
join Course c
on c.CourseName=x.CourseName
join Meal m
on m.MealName= x.MealName

--CourseMealRecipe:  
 ; with x as ( 
select CourseName= 'Starter', RecipeName= 'Apple Yogurt Smoothie', MealName='Breakfast', IsMain = 0
union select 'Entree', 'Potato Kugel', 'lunch', 0
union select 'Appetizer', 'Pizza', 'Dinner', 0 
union select 'Main course', 'Cheese Bread', 'snack', 1
union select 'Dessert', 'Butter Muffins', 'Brunch', 0 
union select 'MidNight Snack', 'French Fries', 'supper', 0
union select 'Pre-Breakfast', 'Chocolate Chip Cookies', 'tea', 0
union select 'Main course', 'Bread', 'Lunch', 1
union select 'Pre-Breakfast', 'Guacamole', 'second snack', 0
union select 'Pre-Breakfast', 'RiceCakes and Cheese', 'third snack', 1
)
insert CourseMealRecipe(CourseMealId, RecipeId)
select cm.CourseMealId, r.RecipeId
from x
join Recipe r
on x.RecipeName=r.RecipeName
join Course c
on x.CourseName=c.CourseName
join Meal m
on x.MealName= m.MealName
join CourseMeal cm
on cm.CourseId=c.CourseId
  
--CookBook:
 ; with x as
(
select FirstName = 'Tzipporah', CookBookName = 'Treats for two', Price = 30.00 /*SequenceOrder = 1*/
union select  'Peter',   'Bais Yaakov', 40.00 
union select  'John',   'Dinner Done',   35.00 
union select  'Hoppy',   'Kosher by design', 25.00 
union select 'Sara', 'Silver Platter', 42.00 
union select 'Tzipporah', 'Set Your Table', 53.00
)
insert  CookBook (StaffId, CookBookName, Price)
select  s.staffid, x.CookBookName,  x.Price
from  x
join Staff s 
on  s.FirstName = x.FirstName

--RecipeCookBook:
 ; with x as(
     select CookBookName= 'Treats for two',  RecipeName='Chocolate Chip Cookies',  RecipeCookBookSequence= 1
     union select 'Bais Yaakov', 'Apple Yogurt Smoothie',2
     union select 'Bais Yaakov', 'Potato Kugel',3
     union select 'Dinner Done', 'Cheese Bread',4
     union select 'Kosher by design',  'Butter Muffins',5
     union select 'Silver Platter', 'Pizza', 6
     union select 'Set Your Table', 'bread', 7
     union select 'Kosher by design', 'Guacamole', 8
     union select 'Set Your Table', 'RiceCakes and Cheese', 9
 )
 insert RecipeCookBook(CookBookId, RecipeId,  RecipeCookBookSequence)
 select cb.CookBookId, r.RecipeId, x.RecipeCookBookSequence
 from x 
 join CookBook CB
 on CB.CookBookName= x.CookBookName
 join Recipe R
 on r.RecipeName=x.RecipeName

 

 
  
 
 
 
 
 


 
 