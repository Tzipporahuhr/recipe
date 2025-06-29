insert Recipe (StaffId, CuisineId, RecipeName, Calories, DateDrafted)
values
((select top 1 StaffId from Staff),(select top 1 CuisineId from Cuisine),'Falafel', 130, getdate()),
((select top 1 StaffId from Staff),(select top 1 CuisineId from Cuisine),'Noodles', 220, getdate()),
((select top 1 StaffId from Staff),(select top 1 CuisineId from Cuisine),'CarrotSoup', 95, getdate()),
((select top 1 StaffId from Staff),(select top 1 CuisineId from Cuisine),'Eggplant Dip', 150, getdate()),
((select top 1 StaffId from Staff),(select top 1 CuisineId from Cuisine),'Crumble', 180, getdate()),
((select top 1 StaffId from Staff),(select top 1 CuisineId from Cuisine),'Pancakes', 110, getdate()),
((select top 1 StaffId from Staff),(select top 1 CuisineId from Cuisine),'Stir Fry', 210, getdate()),
((select top 1 StaffId from Staff),(select top 1 CuisineId from Cuisine),'Hummus', 140, getdate()),
((select top 1 StaffId from Staff),(select top 1 CuisineId from Cuisine),'Cabbage', 80, getdate()),
((select top 1 StaffId from Staff),(select top 1 CuisineId from Cuisine),'Sweet Potato Fries', 160, getdate());
 