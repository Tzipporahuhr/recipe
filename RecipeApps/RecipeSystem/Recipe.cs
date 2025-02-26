using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUFramework;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipes(string RecipeName)
        {
            string sql = "select RecipeId, RecipeName from recipe r where r.recipename like '%" + RecipeName + "%'";
            //changed txtrecipename.text to recipename

            DataTable dt = SQLUtility.GetDataTable(sql);
            return dt;
        }

        public static DataTable Load(int recipeid)
        {
            string sql =

   "select   r.*, c.CuisineName, s.FirstName from Recipe r join Staff s on r.StaffId= s.StaffId join Cuisine c on r.CuisineId= c.CuisineId  where r.RecipeId=" + recipeid.ToString();

           return SQLUtility.GetDataTable(sql);
        }

        public static DataTable GetCuisineList()
        {
           return  SQLUtility.GetDataTable("select CuisineId, CuisineName from Cuisine");
        }

       public static void Save(DataTable dtrecipe)
        {
            SQLUtility.DebugPrintDataTable(dtrecipe);
            DataRow r = dtrecipe.Rows[0];
            string sql = string.Join(Environment.NewLine, $"update recipe set",
                 //$"FirstName='{r["FirstName"]}'",
                 $"CuisineId='{r["CuisineId"]}',",
                 $"RecipeName='{r["RecipeName"]}',",
                 $"Calories='{r["Calories"]}',",
                 $"DateDrafted='{r["DateDrafted"]}',",
                 $"DatePublished='{r["DatePublished"]}',",
                        $"DateArchived='{r["DateArchived"]}'",
                // $"RecipePic='{r["RecipePic"]}',",
                ///$"RecipeStatus='{r["RecipeStatus"]}'",

                $" where recipeId=   {r["recipeId"]}");

            Debug.Print("------------------");
            ;
            SQLUtility.ExecuteSQL(sql);
            

        }

        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["recipeId"];
            string sql = "delete recipe where recipeId=" + id;
            SQLUtility.ExecuteSQL(sql);
             
        }

    }
}
