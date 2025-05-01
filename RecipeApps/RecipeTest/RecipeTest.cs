using NUnit.Framework.Legacy;
using System.Data;
using System.Data.SqlClient;

namespace RecipeTest
{
    public class RecipeTest
    {
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString("Server=tcp:tzipporahuhr-cpu.database.windows.net,1433;Initial Catalog=RecipeDB;Persist Security Info=False;User ID=tzipporahuhr;Password=Recipe123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        [Test]

        public void ChangeExistingRecipeName()
        {
           
            
            int RecipeId = GetExistingRecipeId();
            Assume.That(RecipeId > 0, "No Recipes in DB, cant run test");
            string RecipeName = SQLUtility.GetFirstColumnFirstRowValue("select RecipeName from Recipe where RecipeId=" + RecipeId).ToString();
            TestContext.WriteLine("Yearborn for RecipeId " + RecipeId + "is " +  RecipeName);

            string currenttime = DateTime.Now.ToString("yyyy-MM-dd. HHmmss");
            string newrecipename = RecipeName + "-" + currenttime;
            TestContext.WriteLine("change RecipeName to " + RecipeName);

            DataTable dt = Recipe.Load(RecipeId);
            dt.Rows[0]["RecipeName"] = RecipeName;

            //star
            DateTime drafted = Convert.ToDateTime(dt.Rows[0]["DateDrafted"]);
            if (drafted > DateTime.Today)
            {
                dt.Rows[0]["DateDrafted"] = DateTime.Today;
            }
            //finish
            Recipe.Save(dt);

            string updatedrecipename  = SQLUtility.GetFirstColumnFirstRowValue("select RecipeName from Recipe where RecipeId=" + RecipeId).ToString();
            ClassicAssert.IsTrue(updatedrecipename==RecipeName, "RecipeName for Recipe(" + RecipeId + ")=" + newrecipename);
            TestContext.WriteLine("RecipeName for Recipe(" + RecipeId +")=" + newrecipename);
        }
        [Test]


        public void DeleteRecipe()
        { DataTable dt = SQLUtility.GetDataTable("select top 1 r.RecipeId, r.Calories, r.RecipeName  from Recipe r left join staff s on s.staffid=r.staffid");
            int RecipeId = 0;
            string recipedesc = "";
            if (dt.Rows.Count > 0)
            {
                RecipeId= (int)dt.Rows[0]["RecipeId"];
                recipedesc = dt.Rows[0]["Calories"] + " " + dt.Rows[0]["RecipeName"];
            }
                
            Assume.That(RecipeId > 0, "No recipes without staff in DB, cant run test");
            TestContext.WriteLine("existing recipe without staff, with id=" + RecipeId+" " + recipedesc);
            TestContext.WriteLine("ensure that app can delete" + RecipeId);

            SQLUtility.ExecuteSQL("delete from RecipeCookbook where RecipeId=" + RecipeId);
            SQLUtility.ExecuteSQL("delete from CourseMealRecipe where RecipeId=" + RecipeId);
            SQLUtility.ExecuteSQL("delete from Direction where RecipeId="+ RecipeId);
            SQLUtility.ExecuteSQL("delete from RecipeIngredient where RecipeId= " + RecipeId);
            SQLUtility.ExecuteSQL("delete from Recipe where RecipeId=" + RecipeId);
             
            DataTable dtafterdelete = SQLUtility.GetDataTable("select * from recipe where RecipeId =" + RecipeId);
            ClassicAssert.IsTrue(dtafterdelete.Rows.Count == 0, "Record with RecipeId" + RecipeId + "exists in db");
            TestContext.WriteLine("Record with RecipeId" + RecipeId + "does not exist in DB");
        }

        [Test]
        public void RecipeCaloriesMustBeGreaterThanZero()
        { 
        DataTable dt = Recipe.Load(GetExistingRecipeId());
            dt.Rows[0]["Calories"] = 0;

            var ex= Assert.Throws<Exception>(()=> Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
            StringAssert.Contains("Recipe Calories bought must be greater than zero", ex.Message);


        }
        [Test]
        public void RecipeNameMustNotBeBlank()
        {
            DataTable dt= Recipe.Load(GetExistingRecipeId());
            dt.Rows[0]["RecipeName"] = "";
            var ex= Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
            StringAssert.Contains("Recipe RecipeName cannot be blank", ex.Message);
        }

        [Test]

        public void RecipeDateDraftedCannotBeInFuture()
        {
            DataTable dt= Recipe.Load(GetExistingRecipeId());
            dt.Rows[0]["DateDrafted"] = DateTime.Today.AddDays(1);
            var ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
            StringAssert.Contains("Recipe DateDrafted must not be future", ex.Message);
        }

        

        [Test]
        public void LoadRecipe()
        {
            int RecipeId = GetExistingRecipeId();
            Assume.That(RecipeId > 0, "No recipes in DB, cant run test");
            TestContext.WriteLine("existing recipe with id = " + RecipeId);
            TestContext.WriteLine("Ensure that app loads recipe" + RecipeId);
            DataTable dt = Recipe.Load(RecipeId);
            int loadedid = 0;
            if (dt.Rows.Count > 0)
            {
                loadedid = (int)dt.Rows[0]["recipeid"];
            }
         
            ClassicAssert.IsTrue(loadedid==RecipeId, loadedid + "< >" + RecipeId);
            TestContext.WriteLine("Loaded recipe (" + loadedid + ")" );

        }

        [Test]
        public void SearchRecipes()
        {
            string criteria = "a";
            int num = SQLUtility.GetFirstColumnFirstRowValue("select total= count (*) from recipe where RecipeName like '%" + criteria + "%'");
            Assume.That(num> 0, "there no recipes that match the search for " +num); 
            TestContext.WriteLine(num + "presidents that match" + criteria);
            TestContext.WriteLine("Ensure that recipe search returns" + num + "rows");
         
            DataTable dt =Recipe.SearchRecipes(criteria);
            int results = dt.Rows.Count;
            ClassicAssert.IsTrue(results==num,"Results of recipe search does not match number of recipes," + results +"<>" +num);
            TestContext.WriteLine("Number of rows returned by recipe search is " + results);
        
        }

        [Test]
        public void GetListOfCuisines()
        {
            
            int cuisinecount = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from cuisine");
            Assume.That(cuisinecount > 0, "No cuisines in DB, cant test");
            TestContext.WriteLine("Num of cuisines in DB=" + cuisinecount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + cuisinecount);


           DataTable dt = Recipe.GetCuisineList();
            ClassicAssert.IsTrue(dt.Rows.Count ==cuisinecount, "num rows returned by app (" + dt.Rows.Count+")<>" + cuisinecount);
            TestContext.WriteLine("Number of rows in Cuisines returned by app=" + dt.Rows.Count);
        }

        private int GetExistingRecipeId()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 RecipeId from recipe");
        }
    }
}