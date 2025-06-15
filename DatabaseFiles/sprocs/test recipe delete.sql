declare @Recipeid int

select top 1 @Recipeid=r.RecipeId 
from Recipe r
left join CourseMealRecipe c
on c.RecipeId= r.RecipeId
left join RecipeCookBook rc
on rc. RecipeId= r.RecipeId
where c.CourseMealId is null
and rc.RecipeCookBookId is null
order by r.RecipeId
 
 select * from Recipe r where r.RecipeId= @Recipeid

 exec RecipeDelete @RecipeId= @Recipeid

  
 select * from Recipe r where r.RecipeId= @Recipeid