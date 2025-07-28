using System.Data;
using CPUWindowsFormFramework;
using RecipeSystem;

namespace RecipeWinForms
{
    
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe = new DataTable();
        BindingSource bindsource = new BindingSource();

        public frmRecipe()
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }



        public void ShowForm(int recipeid)
        {
            if (recipeid == 0)
            {
                dtrecipe = Recipe.Load(0);       
                dtrecipe.Rows.Add();             

                
                txtDateDrafted.ReadOnly = true;
                txtDateDrafted.TabStop = false;
                txtDateDrafted.BackColor = SystemColors.Control;

                txtDatePublished.ReadOnly = true;
                txtDatePublished.TabStop = false;
                txtDatePublished.BackColor = SystemColors.Control;

                txtDateArchived.ReadOnly = true;
                txtDateArchived.TabStop = false;
                txtDateArchived.BackColor = SystemColors.Control;
            }
            else
            {
                dtrecipe = Recipe.Load(recipeid);
            }

            bindsource.DataSource = dtrecipe;

            DataTable dtCuisines = Recipe.GetCuisineList();
            WindowsFormsUtility.SetListBinding(lstCuisineName, dtCuisines, dtrecipe, "Cuisine");

            DataTable dtStaff = Recipe.GetStaffList();
            WindowsFormsUtility.SetListBinding(lstFirstName, dtStaff, dtrecipe, "Staff");

            WindowsFormsUtility.SetControlBinding(txtRecipeName, bindsource);
            WindowsFormsUtility.SetControlBinding(txtCalories, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateDrafted, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, bindsource);
            WindowsFormsUtility.SetControlBinding(txtRecipePic, bindsource);
            WindowsFormsUtility.SetControlBinding(txtRecipeStatus, bindsource);

            this.Show();
        }


        private void Save()
        {
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Save(dtrecipe);


            }
            catch (Exception ex)
            {

             

                MessageBox.Show(ex.Message,"Recipe");
            }
            finally
            {
               Application.UseWaitCursor = false;
            }
            this.Close();

        }

        private void Delete()
        {
            var response = MessageBox.Show("Are you sure you want to delete this Recipe?", "Recipe", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }

            Application.UseWaitCursor = true;
            try
            {
                Recipe.Delete(dtrecipe);
            }
            
             catch (Exception ex)
            {   if (string.IsNullOrEmpty(ex.Message))
                {
                    MessageBox.Show("Cannot delete recipe because it is part of a meal or cookbook.", "Recipe");
                }
                else
                {
                    MessageBox.Show(ex.Message, "Recipe");
                }
                   
            }
            finally
            {
                Application.UseWaitCursor = false;
            }

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
