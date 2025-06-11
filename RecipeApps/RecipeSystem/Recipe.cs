using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using CPUFramework;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipes(string RecipeName)
        {
           DataTable dt = new();
           SqlCommand cmd=SQLUtility.GetSqlCommand("RecipeGet");
           cmd.Parameters["@RecipeName"].Value = RecipeName;
           dt = SQLUtility.GetDataTable(cmd);
           return dt;
        }
        

        public static DataTable Load(int recipeid)
        {
          DataTable dt =new();
          SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeGet");
          cmd.Parameters["@RecipeId"].Value=recipeid;
          dt = SQLUtility.GetDataTable(cmd);
          return dt;

            
        }

       public static DataTable GetCuisineList()
        {
            DataTable dt= new DataTable();
            SqlCommand cmd = SQLUtility.GetSqlCommand("CuisineGet");
            cmd.Parameters["@All"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetStaffList()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = SQLUtility.GetSqlCommand("StaffGet");
            cmd.Parameters["@All"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
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
            SqlCommand cmd= SQLUtility.GetSqlCommand("RecipeDelete");
            cmd.Parameters["@RecipeId"].Value = id;
          
            SQLUtility.ExecuteSQL(cmd);
             
        }

    }
}
