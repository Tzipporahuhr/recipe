using CPUFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPUWindowsFormFramework;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe;
        public frmRecipe()
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }

    

        public void ShowForm(int recipeid)
        {
    string sql =
 
    "select   r.*, c.CuisineName, s.FirstName from Recipe r join Staff s on r.StaffId= s.StaffId join Cuisine c on r.CuisineId= c.CuisineId  where r.RecipeId=" + recipeid.ToString();

             dtrecipe = SQLUtility.GetDataTable(sql);

            DataTable dtCuisines=SQLUtility.GetDataTable("select CuisineId, CuisineName from Cuisine");
            WindowsFormsUtility.SetListBinding(lstCuisineName, dtCuisines, dtrecipe, "Cuisine");
            WindowsFormsUtility.SetControlBinding(lblFirstName, dtrecipe);
           
            WindowsFormsUtility.SetControlBinding(txtRecipeName, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtCalories, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDateDrafted, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtRecipePic, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtRecipeStatus, dtrecipe);
           

            this.Show();
        }

      
        private void Save()
        {
            SQLUtility.DebugPrintDataTable(dtrecipe);
            DataRow r = dtrecipe.Rows[0];
            string sql = string.Join(Environment.NewLine,$"update recipe set",
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
            this.Close();

        }

        private void Delete()
        {
            int id = (int)dtrecipe.Rows[0]["recipeId"];
            string sql = "delete recipe where recipeId=" + id;
            SQLUtility.ExecuteSQL(sql);
            this.Close();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }
    }
}
