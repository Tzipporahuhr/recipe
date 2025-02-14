using System.Data;
using System.Data.SqlClient;
using CPUFramework;
using Microsoft.VisualBasic.ApplicationServices;
namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();

            btnSearch.Click += BtnSearch_Click;
            FormatGrid();
            gRecipe.CellDoubleClick += GRecipe_CellDoubleClick;
        }



        private void SearchForRecipe(string recipetype)
        {
            string sql = "select RecipeId, RecipeName from recipe r where r.recipename like '%" + txtRecipeName.Text + "%'";

            DataTable dt = SQLUtility.GetDataTable(sql);
            gRecipe.DataSource = dt;
            gRecipe.Columns["RecipeId"].Visible = false;
        }
        private void ShowRecipeForm(int rowindex)
        {
            int id = (int)gRecipe.Rows[rowindex].Cells["RecipeId"].Value;
            frmRecipe frm = new frmRecipe();
            frm.ShowForm(id);
        }
        private void FormatGrid()
        {
            gRecipe.AllowUserToAddRows = false;
            gRecipe.ReadOnly = true;
            gRecipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

 