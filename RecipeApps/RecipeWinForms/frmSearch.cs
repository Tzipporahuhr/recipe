using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();

            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        { 
        }

        private void SearchForRecipe(string recipetype )
        {
            string sql = "select * from recipe r where";
        }

        private string GetConnectionString( )
        {
            var s = "Server=.\\SQLExpress;Database=RecordKeeperDB;Trusted_Connection=true";
           
            return s;
        }

        private DataTable GetDataTable(string sqlstatement)
        {
            DataTable dt = new();
            SqlConnection conn = new();
            conn.ConnectionString = GetConnectionString();
            conn.Open();
            
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sqlstatement; ;
            var dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }


    }
}
