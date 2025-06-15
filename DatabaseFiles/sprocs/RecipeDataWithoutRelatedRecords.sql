 use RecipeDB
go

 

delete from Recipe;
delete from Staff;
delete from Cuisine;
 
insert into Staff (FirstName, LastName, UserName)
values 
('John', 'Doe', 'jdoe1'),
('Jane', 'Smith', 'jsmith1'),
('David', 'Lee', 'dlee1'),
('Sara', 'Miller', 'smiller1'),
('Rachel', 'Cohen', 'rcohen1'),
('Ben', 'Green', 'bgreen1'),
('Leah', 'Brown', 'lbrown1');
 
insert into Cuisine (CuisineName)
values
('Ashkenazi'),
('Sephardi'),
('Middle Eastern'),
('Dessert');

 
insert into Recipe (StaffId, CuisineId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
values 
((select StaffId from Staff where FirstName = 'John'),   (select CuisineId from Cuisine where CuisineName = 'Sephardi'),        'Cholent',      1000, '1761-02-22', '1762-02-22', '1763-02-22'),
((select StaffId from Staff where FirstName = 'Jane'),   (select CuisineId from Cuisine where CuisineName = 'Ashkenazi'),       'Chicken Soup',  50,  '1761-02-22', '1762-02-22', '1763-02-22'),
((select StaffId from Staff where FirstName = 'David'),  (select CuisineId from Cuisine where CuisineName = 'Dessert'),         'Challah',      200, '1761-02-22', '1762-02-22', '1763-02-22'),
((select StaffId from Staff where FirstName = 'Sara'),   (select CuisineId from Cuisine where CuisineName = 'Ashkenazi'),       'Chocolate Pie', 800, '1761-02-22', '1762-02-22', '1763-02-22'),
((select StaffId from Staff where FirstName = 'Rachel'), (select CuisineId from Cuisine where CuisineName = 'Sephardi'),        'Brownies',     350, '1761-02-22', '1762-02-22', '1763-02-22'),
((select StaffId from Staff where FirstName = 'Ben'),    (select CuisineId from Cuisine where CuisineName = 'Middle Eastern'),  'Ice Cream',    700, '1761-02-22', '1762-02-22', '1763-02-22'),
((select StaffId from Staff where FirstName = 'Leah'),   (select CuisineId from Cuisine where CuisineName = 'Dessert'),         'Lotus Cups',   500, '1761-02-22', '1762-02-22', '1763-02-22'),
((select StaffId from Staff where FirstName = 'John'),   (select CuisineId from Cuisine where CuisineName = 'Ashkenazi'),       'Chummus',       50, '1761-02-22', '1762-02-22', '1763-02-22'),
((select StaffId from Staff where FirstName = 'Jane'),   (select CuisineId from Cuisine where CuisineName = 'Sephardi'),        'eggplant',      30, '1761-02-22', '1762-02-22', '1763-02-22'),
((select StaffId from Staff where FirstName = 'David'),  (select CuisineId from Cuisine where CuisineName = 'Middle Eastern'),  'sour dough',  2000, '1761-02-22', '1762-02-22', '1763-02-22'),
((select StaffId from Staff where FirstName = 'Sara'),   (select CuisineId from Cuisine where CuisineName = 'Dessert'),         'fruit',         30, '1761-02-22', '1762-02-22', '1763-02-22');