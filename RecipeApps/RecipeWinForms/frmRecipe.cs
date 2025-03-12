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
        DataTable dtRecipe;
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

           dtRecipe = SQLUtility.GetDataTable(sql);
             
             SetControlBinding(lblLastName, dtRecipe);
            SetControlBinding(lblCuisineName, dtRecipe);
            SetControlBinding(txtRecipeName, dtRecipe);
            SetControlBinding(txtDateDrafted, dtRecipe);
            SetControlBinding(txtDatePublished, dtRecipe);
            SetControlBinding(txtDateArchived, dtRecipe);
            SetControlBinding(txtRecipePic, dtRecipe);
            SetControlBinding(txtRecipeStatus, dtRecipe);
           

            this.Show();
        }

        public void SetControlBinding(Control ctrl, DataTable dtRecipe)
        {
            string propertyname = "";
            string columname = "";

            if (ctrl.Name == "lblLastName")
            {
                columname = "FirstName";
                propertyname = "Text";
            }

            else if (ctrl.Name == "lblCuisineName")
            {
                columname = "CuisineName";
                propertyname = "Text";

            }
            else
            {


                string controlname = ctrl.Name.ToLower();

                if (controlname.StartsWith("txt") || controlname.StartsWith("lbl"))
                {
                    propertyname = "Text";
                    columname = controlname.Substring(3);
                }
            }
            if (propertyname != "" && columname!= "")
            {
                ctrl.DataBindings.Add(propertyname, dtRecipe, columname, true, DataSourceUpdateMode.OnPropertyChanged);
            }
            
        }

        private void Save()
        {
            SQLUtility.DebugPrintDataTable(dtRecipe);
        }

        private void Delete()
        {

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
