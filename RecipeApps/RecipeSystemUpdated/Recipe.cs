using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUFramework;
namespace RecipeSystemUpdated
{
   public class Recipe
    {
        public static DataTable SearchRecipes(string RecipeName)
        {

            string sql = "select RecipeId, RecipeName from recipe r where r.recipename like '%" + RecipeName + "%'";

            DataTable dt = SQLUtility.GetDataTable(sql);
            return dt;
        }
    }
}
