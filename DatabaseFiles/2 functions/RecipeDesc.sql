 
create or alter function dbo.RecipeDesc(@RecipeId int)
returns varchar(250)
as
begin

	declare @value varchar(250) = ''

	select @value = concat(
		r.RecipeName, ' (', c.CuisineName, ') has ',
		count(distinct ri.RecipeIngredientId), ' ingredients and ',
		count(distinct d.DirectionId), ' steps'
	)
	from Recipe r
	join Cuisine c 
	on r.CuisineId = c.CuisineId
	left join RecipeIngredient ri 
	on ri.RecipeId = r.RecipeId
	left join Direction d 
	on d.RecipeId = r.RecipeId
	where r.RecipeId = @RecipeId
	group by r.RecipeName, c.CuisineName

	return @value
end