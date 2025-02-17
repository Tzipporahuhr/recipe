using CPUFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }

        public void ShowForm(int recipeid)
        {
    string sql =
 
    "select   r.*, c.CuisineName, s.FirstName from Recipe r join Staff s on r.StaffId= s.StaffId join Cuisine c on r.CuisineId= c.CuisineId  where r.RecipeId=" + recipeid.ToString();

     DataTable dt = SQLUtility.GetDataTable(sql);
           lblstaff2.DataBindings.Add("Text", dt, "FirstName");
           lblCuisine2.DataBindings.Add("Text", dt, "CuisineName");
           txtRecipeName.DataBindings.Add("Text", dt, "RecipeName");
           txtCalories.DataBindings.Add("Text", dt, "Calories");
           txtDateDrafted.DataBindings.Add("Text", dt, "DateDrafted");
           txtDatePublished.DataBindings.Add("Text", dt, "DatePublished");
           txtDateArchived.DataBindings.Add("Text", dt, "DateArchived");
           txtRecipePic.DataBindings.Add("Text", dt, "RecipePic");
           txtRecipeStatus.DataBindings.Add("Text", dt, "RecipeStatus");

            this.Show();
        }
    }
}
