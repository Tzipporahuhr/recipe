namespace RecipeWinForms
{
    partial class frmRecipe
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
            lblStaff = new Label();
            lblCuisine = new Label();
            lblRecipeName = new Label();
            lblCalories = new Label();
            lblDateDrafted = new Label();
            lblDatePublished = new Label();
            lblDateArchived = new Label();
            lblRecipePic = new Label();
            lblRecipeStatus = new Label();
            lblstaff2 = new Label();
            lblCuisine2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lblStaff, 0, 0);
            tblMain.Controls.Add(lblCuisine, 0, 1);
            tblMain.Controls.Add(lblRecipeName, 0, 2);
            tblMain.Controls.Add(lblCalories, 0, 3);
            tblMain.Controls.Add(lblDateDrafted, 0, 4);
            tblMain.Controls.Add(lblDatePublished, 0, 5);
            tblMain.Controls.Add(lblDateArchived, 0, 6);
            tblMain.Controls.Add(lblRecipePic, 0, 7);
            tblMain.Controls.Add(lblRecipeStatus, 0, 8);
            tblMain.Controls.Add(lblstaff2, 1, 0);
            tblMain.Controls.Add(lblCuisine2, 1, 1);
            tblMain.Controls.Add(textBox1, 1, 2);
            tblMain.Controls.Add(textBox2, 1, 3);
            tblMain.Controls.Add(textBox3, 1, 4);
            tblMain.Controls.Add(textBox4, 1, 5);
            tblMain.Controls.Add(textBox5, 1, 6);
            tblMain.Controls.Add(textBox6, 1, 7);
            tblMain.Controls.Add(textBox7, 1, 8);
            tblMain.Location = new Point(203, 23);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 9;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.Size = new Size(265, 372);
            tblMain.TabIndex = 0;
            // 
            // lblStaff
            // 
            lblStaff.Anchor = AnchorStyles.Left;
            lblStaff.AutoSize = true;
            lblStaff.Location = new Point(3, 9);
            lblStaff.Name = "lblStaff";
            lblStaff.Size = new Size(41, 21);
            lblStaff.TabIndex = 0;
            lblStaff.Text = "Staff";
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Left;
            lblCuisine.AutoSize = true;
            lblCuisine.Location = new Point(3, 49);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(61, 21);
            lblCuisine.TabIndex = 1;
            lblCuisine.Text = "Cuisine";
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(3, 89);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(98, 21);
            lblRecipeName.TabIndex = 2;
            lblRecipeName.Text = "RecipeName";
            // 
            // lblCalories
            // 
            lblCalories.Anchor = AnchorStyles.Left;
            lblCalories.AutoSize = true;
            lblCalories.Location = new Point(3, 129);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(66, 21);
            lblCalories.TabIndex = 3;
            lblCalories.Text = "Calories";
            // 
            // lblDateDrafted
            // 
            lblDateDrafted.Anchor = AnchorStyles.Left;
            lblDateDrafted.AutoSize = true;
            lblDateDrafted.Location = new Point(3, 169);
            lblDateDrafted.Name = "lblDateDrafted";
            lblDateDrafted.Size = new Size(94, 21);
            lblDateDrafted.TabIndex = 4;
            lblDateDrafted.Text = "DateDrafted";
            // 
            // lblDatePublished
            // 
            lblDatePublished.Anchor = AnchorStyles.Left;
            lblDatePublished.AutoSize = true;
            lblDatePublished.Location = new Point(3, 209);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(110, 21);
            lblDatePublished.TabIndex = 5;
            lblDatePublished.Text = "DatePublished";
            // 
            // lblDateArchived
            // 
            lblDateArchived.Anchor = AnchorStyles.Left;
            lblDateArchived.AutoSize = true;
            lblDateArchived.Location = new Point(3, 249);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(103, 21);
            lblDateArchived.TabIndex = 6;
            lblDateArchived.Text = "DateArchived";
            // 
            // lblRecipePic
            // 
            lblRecipePic.Anchor = AnchorStyles.Left;
            lblRecipePic.AutoSize = true;
            lblRecipePic.Location = new Point(3, 289);
            lblRecipePic.Name = "lblRecipePic";
            lblRecipePic.Size = new Size(76, 21);
            lblRecipePic.TabIndex = 7;
            lblRecipePic.Text = "RecipePic";
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.Anchor = AnchorStyles.Left;
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Location = new Point(3, 335);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(98, 21);
            lblRecipeStatus.TabIndex = 8;
            lblRecipeStatus.Text = "RecipeStatus";
            // 
            // lblstaff2
            // 
            lblstaff2.BackColor = Color.WhiteSmoke;
            lblstaff2.BorderStyle = BorderStyle.FixedSingle;
            lblstaff2.Dock = DockStyle.Fill;
            lblstaff2.Location = new Point(135, 0);
            lblstaff2.Name = "lblstaff2";
            lblstaff2.Size = new Size(127, 40);
            lblstaff2.TabIndex = 9;
            // 
            // lblCuisine2
            // 
            lblCuisine2.BackColor = Color.WhiteSmoke;
            lblCuisine2.BorderStyle = BorderStyle.FixedSingle;
            lblCuisine2.Dock = DockStyle.Fill;
            lblCuisine2.Location = new Point(135, 40);
            lblCuisine2.Name = "lblCuisine2";
            lblCuisine2.Size = new Size(127, 40);
            lblCuisine2.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(135, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(41, 29);
            textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(135, 123);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(58, 29);
            textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(135, 163);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(37, 29);
            textBox3.TabIndex = 13;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(135, 203);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(63, 29);
            textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(135, 243);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(59, 29);
            textBox5.TabIndex = 15;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(135, 283);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(86, 29);
            textBox6.TabIndex = 16;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(135, 323);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(72, 29);
            textBox7.TabIndex = 17;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 556);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblStaff;
        private Label lblCuisine;
        private Label lblRecipeName;
        private Label lblCalories;
        private Label lblDateDrafted;
        private Label lblDatePublished;
        private Label lblDateArchived;
        private Label lblRecipePic;
        private Label lblRecipeStatus;
        private Label lblstaff2;
        private Label lblCuisine2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
    }
}