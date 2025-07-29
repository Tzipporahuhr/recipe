namespace RecipeWinForms
{
    partial class frmSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tblMain = new TableLayoutPanel();
            tblOptions = new TableLayoutPanel();
            txtRecipeName = new TextBox();
            btnSearch = new Button();
            gRecipe = new DataGridView();
            btnNew = new Button();
            btnCalories = new Button();
            tblMain.SuspendLayout();
            tblOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipe).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 3;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(tblOptions, 0, 0);
            tblMain.Controls.Add(gRecipe, 0, 1);
            tblMain.Controls.Add(btnNew, 1, 0);
            tblMain.Controls.Add(btnCalories, 2, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 3;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(910, 706);
            tblMain.TabIndex = 0;
            // 
            // tblOptions
            // 
            tblOptions.AutoSize = true;
            tblOptions.ColumnCount = 2;
            tblOptions.ColumnStyles.Add(new ColumnStyle());
            tblOptions.ColumnStyles.Add(new ColumnStyle());
            tblOptions.Controls.Add(txtRecipeName, 0, 0);
            tblOptions.Controls.Add(btnSearch, 1, 0);
            tblOptions.Location = new Point(3, 3);
            tblOptions.Name = "tblOptions";
            tblOptions.RowCount = 1;
            tblOptions.RowStyles.Add(new RowStyle());
            tblOptions.Size = new Size(231, 48);
            tblOptions.TabIndex = 0;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRecipeName.Location = new Point(3, 3);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(91, 39);
            txtRecipeName.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Location = new Point(100, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(128, 42);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // gRecipe
            // 
            gRecipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblMain.SetColumnSpan(gRecipe, 3);
            gRecipe.Dock = DockStyle.Fill;
            gRecipe.Location = new Point(3, 57);
            gRecipe.Name = "gRecipe";
            gRecipe.Size = new Size(904, 626);
            gRecipe.TabIndex = 1;
            // 
            // btnNew
            // 
            btnNew.AutoSize = true;
            btnNew.Location = new Point(662, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(119, 48);
            btnNew.TabIndex = 2;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnCalories
            // 
            btnCalories.AutoSize = true;
            btnCalories.Location = new Point(787, 3);
            btnCalories.Name = "btnCalories";
            btnCalories.Size = new Size(120, 48);
            btnCalories.TabIndex = 3;
            btnCalories.Text = "Calories";
            btnCalories.UseVisualStyleBackColor = true;
            // 
            // frmSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 706);
            Controls.Add(tblMain);
            Name = "frmSearch";
            Text = "Recipe Search";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblOptions.ResumeLayout(false);
            tblOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipe).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblOptions;
        private TextBox txtRecipeName;
        private Button btnSearch;
        private DataGridView gRecipe;
        private Button btnNew;
        private Button btnCalories;
    }
}