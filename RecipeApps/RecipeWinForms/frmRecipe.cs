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
            }
            else
            {
                dtrecipe = Recipe.Load(recipeid);
            }


                txtDateDrafted.ReadOnly = true;
                txtDateDrafted.TabStop = false;
                txtDateDrafted.BackColor = SystemColors.Control;

                txtDatePublished.ReadOnly = true;
                txtDatePublished.TabStop = false;
                txtDatePublished.BackColor = SystemColors.Control;

                txtDateArchived.ReadOnly = true;
                txtDateArchived.TabStop = false;
                txtDateArchived.BackColor = SystemColors.Control;
            
          

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

            txtRecipePic.ReadOnly = true;
            txtRecipePic.TabStop = false;
            txtRecipePic.BackColor = SystemColors.Control;

            txtRecipeStatus.ReadOnly = true;
            txtRecipeStatus.TabStop = false;
            txtRecipeStatus.BackColor = SystemColors.Control;
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

               string usermessage= ErrorMessages(ex.Message);

                MessageBox.Show(ex.Message,"Recipe");
            }
            finally
            {
               Application.UseWaitCursor = false;
            }
            this.Close();

        }

        private string ErrorMessages(string message)
        {
            if (message.Contains("c_Recipe_RecipeName_cannot_be_blank"))
            {
                return "Recipe Name cannot be blank.";
            }
            else if (message.Contains("u_Recipe_RecipeName"))
            {
                return "Recipe Name must be unique.";
            }
            else if (message.Contains("c_Recipe_Calories_must_be_greater_than_zero"))
            {
                return "Calories must be greater than zero.";
            }
            else if (message.Contains("f_Staff_Recipe"))
            {
                return "The selected staff member does not exist.";
            }
            else if (message.Contains("f_Cuisine_Recipe"))
            {
                return "The selected cuisine does not exist.";
            }
            else if (message.Contains("DateDrafted") && message.Contains("future"))
            {
                return "Drafted date cannot be in the future.";
            }
            else if (message.Contains("DateDrafted") && message.Contains("before"))
            {
                return "Drafted date must be before the published date.";
            }
            else
            {
                return message; 
            }
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
