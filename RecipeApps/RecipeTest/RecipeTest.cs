using System.Data;

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
            SQLUtility.ExecuteSQL("delete from RecipeIngredient where RecipeId= " + RecipeId);
            SQLUtility.ExecuteSQL("delete from Recipe where RecipeId=" + RecipeId);
            //Recipe.Delete(dt);
            DataTable dtafterdelete = SQLUtility.GetDataTable("select * from recipe where RecipeId =" + RecipeId);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "Record with RecipeId" + RecipeId + "exists in db");
            TestContext.WriteLine("Record with RecipeId" + RecipeId + "does not exist in DB");
        }

        [Test]
        public void LoadRecipe()
        {
            int RecipeId = SQLUtility.GetFirstColumnFirstRowValue("select top 1 RecipeId from recipe");
            Assume.That(RecipeId > 0, "No recipes in DB, cant run test");
            TestContext.WriteLine("existing recipe with id = " + RecipeId);
            TestContext.WriteLine("Ensure that app loads recipe" + RecipeId);
            DataTable dt = Recipe.Load(RecipeId);
            int loadedid= (int)dt.Rows[0]["RecipeId"];
            Assert.IsTrue(loadedid==RecipeId, (int)dt.Rows[0]["RecipeId"] + "< >" + RecipeId);
            TestContext.WriteLine("Loaded recipe (" + loadedid + ")" );

        }

        [Test]
        public void GetListOfCuisines()
        {
            
            int cuisinecount = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from cuisine");
            Assume.That(cuisinecount > 0, "No parties in DB, cant test");
            TestContext.WriteLine("Num of cuisines in DB=" + cuisinecount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + cuisinecount);


            DataTable dt = Recipe.GetCuisineList();
            Assert.IsTrue(dt.Rows.Count ==cuisinecount, "num rows returned by app (" + dt.Rows.Count+")<>" + cuisinecount);
            TestContext.WriteLine("Number of rows in Cuisines returned by app=" + dt.Rows.Count);
        }
    }
}