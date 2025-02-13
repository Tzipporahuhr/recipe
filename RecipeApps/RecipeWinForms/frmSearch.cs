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
            FormatGrid();
        }
        private void SearchForRecipe(string recipetype)
        {
            string sql = "select RecipeId, RecipeName from recipe r where r.recipename like '%" + txtRecipeName + "%'";
            DataTable dt = GetDataTable(sql);
            gRecipe.DataSource = dt;
        }

        private void FormatGrid()
        {
            gRecipe.AllowUserToAddRows = false;
            gRecipe.ReadOnly = true;
            gRecipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchForRecipe(txtRecipeName.Text);
        }



        private string GetConnectionString()
        {
            var s = "Server=.\\SQLExpress;Database=RecipeDB;Trusted_Connection=true";

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

//private string GetConnectionString()
//{
//    string serverConnectionString;
//    if (rdbLocal.Checked)
//    {
//        serverConnectionString = "Server=.\\SQLExpress;";
//    }
//    else if (rdbAzure.Checked)
//    {
//        serverConnectionString = "Server=tcp:tzipporahuhr-cpu.database.windows.net,1433;";
//    }
//    else
//    {
//        throw new InvalidOperationException(" local/Azure");
//    }
//
//    string databaseConnectionString;
//    if (rdbRecordKeeper.Checked)
//    {
//        databaseConnectionString = "Database=RecordKeeperDB;";
//    }
//    else if (rdbRecipe.Checked)
//    {
//        databaseConnectionString = "Database=RecipeDB;";
//    }
//    else
//    {
//        throw new InvalidOperationException(" pls select database");
//    }
//
//    string authenticationString = rdbLocal.Checked ? "Trusted_Connection=true;" : "Persist Security Info=False;User ID=tzipporahuhr;Password=82bStormont;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
//    return serverConnectionString + databaseConnectionString + authenticationString;
//}
//
//private DataTable GetDataTable(string sqlStatement)
//{
//    DataTable dt = new();
//
//    using (var conn = new SqlConnection(GetConnectionString()))
//    {
//        conn.Open();
//        using (var cmd = new SqlCommand(sqlStatement, conn))
//        {
//            using (var dr = cmd.ExecuteReader())
//            {
//                dt.Load(dr);
//            }
//        }
//    }
//
//    return dt;
//}
//
//