using System.Data;
using System.Data.SqlClient;
using CPUFramework;
using Microsoft.VisualBasic.ApplicationServices;
using CPUWindowsFormFramework;
using RecipeSystem;
namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        
        public frmSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            btnNew.Click += BtnNew_Click;
            WindowsFormsUtility.FormatGridForSearchResults(gRecipe);
            gRecipe.CellDoubleClick += GRecipe_CellDoubleClick;

        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1);
        }

        private void SearchForRecipe(string recipename)
        {
            DataTable dt =  Recipe.SearchRecipes(recipename);
            gRecipe.DataSource = dt;
            gRecipe.Columns["RecipeId"].Visible = false;
        }
        private void ShowRecipeForm(int rowindex)
        {
            //int id = (int)gRecipe.Rows[rowindex].Cells["RecipeId"].Value;
          

            
                int id = 0;

                if (rowindex > -1)
                {
                    id = (int)gRecipe.Rows[rowindex].Cells["RecipeId"].Value;
                }

                frmRecipe frm = new frmRecipe();
                frm.ShowForm(id);
            
        }
      
      private void GRecipe_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipeForm(e.RowIndex);
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchForRecipe(txtRecipeName.Text);
        }





    }
}

 