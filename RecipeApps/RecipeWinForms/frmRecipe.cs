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
using RecipeSystem;

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
    

             dtrecipe = Recipe.Load(recipeid);

            DataTable dtCuisines = Recipe.GetCuisineList();
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
            Recipe.Save(dtrecipe);
            this.Close();
        }

        private void Delete()
        {
           Recipe.Delete(dtrecipe);
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
