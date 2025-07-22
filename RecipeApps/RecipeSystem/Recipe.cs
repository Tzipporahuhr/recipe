using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using CPUFramework;
using System.ComponentModel.Design;

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
            if (recipeid == 0)
            {

                return SQLUtility.GetDataTable("SELECT * FROM Recipe WHERE 1 = 0");
            }
            else
            {
                SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeGet");
                cmd.Parameters["@RecipeId"].Value = recipeid;
                return SQLUtility.GetDataTable(cmd);
            }
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
            if (dtrecipe.Rows.Count == 0)
            {
                throw new Exception("cannot call Recipe save method because there are no rows in the Table");
            }

            DataRow r = dtrecipe.Rows[0];
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeUpdate");

            cmd.Parameters["@RecipeId"].Value = r["RecipeId"];
            cmd.Parameters["@StaffId"].Value = r["StaffId"];
            cmd.Parameters["@CuisineId"].Value = r["CuisineId"];
            cmd.Parameters["@RecipeName"].Value = r["RecipeName"];
            cmd.Parameters["@Calories"].Value = r["Calories"];

            cmd.Parameters["@DateDrafted"].Value = r["DateDrafted"] == DBNull.Value ? (object)DBNull.Value : Convert.ToDateTime(r["DateDrafted"]);
            cmd.Parameters["@DatePublished"].Value = r["DatePublished"] == DBNull.Value ? (object)DBNull.Value : Convert.ToDateTime(r["DatePublished"]);
            cmd.Parameters["@DateArchived"].Value = r["DateArchived"] == DBNull.Value ? (object)DBNull.Value : Convert.ToDateTime(r["DateArchived"]);

            cmd.Parameters["@Message"].Direction = ParameterDirection.InputOutput;

            SQLUtility.ExecuteSQL(cmd);

            string message = cmd.Parameters["@Message"].Value.ToString();
            if (!string.IsNullOrEmpty(message))
            {
                throw new Exception(message);
            }

            
            // {     if (dtrecipe.Rows.Count == 0)
            //     {
            //         throw new Exception("cannot call Recipe save method because there are no rows in the Table");
            //     } 
            //     DataRow r = dtrecipe.Rows[0];
            //     SQLUtility.SaveDataRow(r, "RecipeUpdate");
            //     string sql = string.Join(Environment.NewLine, $"update recipe set",
            //$"CuisineId='{r["CuisineId"]}',",
            //$"StaffId='{r["StaffId"]}',",             
            //$"RecipeName='{r["RecipeName"]}',",
            //$"Calories='{r["Calories"]}',",
            //$"DateDrafted='{r["DateDrafted"]}',",
            //$"DatePublished='{r["DatePublished"]}',",
            //$"DateArchived='{r["DateArchived"]}'",
            //$" where recipeId=   {r["recipeId"]}");
            //     Debug.Print("------------------");

            //     try
            //     {
            //         SQLUtility.ExecuteSQL(sql);   
            //     }
            //     catch (Exception ex)
            //     {
            //         throw;   
            //     }
           
        }
        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["recipeId"];
            SqlCommand cmd= SQLUtility.GetSqlCommand("RecipeDelete");
            cmd.Parameters["@RecipeId"].Value = id;
            cmd.Parameters["@Message"].Value = "";
            cmd.Parameters["@Message"].Direction = ParameterDirection.InputOutput;

            SQLUtility.ExecuteSQL(cmd);

            
            string msg = cmd.Parameters["@Message"].Value.ToString();
            if (!string.IsNullOrEmpty(msg))
            {
                throw new Exception(msg);
            }


            SQLUtility.ExecuteSQL(cmd);
             
        }

    }
}
