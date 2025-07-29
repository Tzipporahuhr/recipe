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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecipe));
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
            txtRecipeName = new TextBox();
            txtCalories = new TextBox();
            txtDateDrafted = new TextBox();
            txtDatePublished = new TextBox();
            txtDateArchived = new TextBox();
            txtRecipePic = new TextBox();
            txtRecipeStatus = new TextBox();
            lstCuisineName = new ComboBox();
            lstFirstName = new ComboBox();
            tsMain = new ToolStrip();
            btnSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tblMain.SuspendLayout();
            tsMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(lblStaff, 0, 0);
            tblMain.Controls.Add(lblCuisine, 0, 1);
            tblMain.Controls.Add(lblRecipeName, 0, 2);
            tblMain.Controls.Add(lblCalories, 0, 3);
            tblMain.Controls.Add(lblDateDrafted, 0, 4);
            tblMain.Controls.Add(lblDatePublished, 0, 5);
            tblMain.Controls.Add(lblDateArchived, 0, 6);
            tblMain.Controls.Add(lblRecipePic, 0, 7);
            tblMain.Controls.Add(lblRecipeStatus, 0, 8);
            tblMain.Controls.Add(txtRecipeName, 1, 2);
            tblMain.Controls.Add(txtCalories, 1, 3);
            tblMain.Controls.Add(txtDateDrafted, 1, 4);
            tblMain.Controls.Add(txtDatePublished, 1, 5);
            tblMain.Controls.Add(txtDateArchived, 1, 6);
            tblMain.Controls.Add(txtRecipePic, 1, 7);
            tblMain.Controls.Add(txtRecipeStatus, 1, 8);
            tblMain.Controls.Add(lstCuisineName, 1, 1);
            tblMain.Controls.Add(lstFirstName, 1, 0);
            tblMain.Location = new Point(0, 31);
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
            tblMain.Size = new Size(342, 380);
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
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Location = new Point(3, 327);
            lblRecipeStatus.Margin = new Padding(3, 7, 3, 0);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(98, 21);
            lblRecipeStatus.TabIndex = 8;
            lblRecipeStatus.Text = "RecipeStatus";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(201, 83);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(138, 29);
            txtRecipeName.TabIndex = 11;
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(201, 123);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(138, 29);
            txtCalories.TabIndex = 12;
            // 
            // txtDateDrafted
            // 
            txtDateDrafted.Dock = DockStyle.Fill;
            txtDateDrafted.Location = new Point(201, 163);
            txtDateDrafted.Name = "txtDateDrafted";
            txtDateDrafted.Size = new Size(138, 29);
            txtDateDrafted.TabIndex = 13;
            // 
            // txtDatePublished
            // 
            txtDatePublished.Dock = DockStyle.Fill;
            txtDatePublished.Location = new Point(201, 203);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.Size = new Size(138, 29);
            txtDatePublished.TabIndex = 14;
            // 
            // txtDateArchived
            // 
            txtDateArchived.Dock = DockStyle.Fill;
            txtDateArchived.Location = new Point(201, 243);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.Size = new Size(138, 29);
            txtDateArchived.TabIndex = 15;
            // 
            // txtRecipePic
            // 
            txtRecipePic.Dock = DockStyle.Fill;
            txtRecipePic.Location = new Point(201, 283);
            txtRecipePic.Name = "txtRecipePic";
            txtRecipePic.Size = new Size(138, 29);
            txtRecipePic.TabIndex = 16;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Dock = DockStyle.Fill;
            txtRecipeStatus.Location = new Point(201, 323);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.Size = new Size(138, 29);
            txtRecipeStatus.TabIndex = 17;
            // 
            // lstCuisineName
            // 
            lstCuisineName.FormattingEnabled = true;
            lstCuisineName.Location = new Point(201, 43);
            lstCuisineName.Name = "lstCuisineName";
            lstCuisineName.Size = new Size(138, 29);
            lstCuisineName.TabIndex = 18;
            // 
            // lstFirstName
            // 
            lstFirstName.FormattingEnabled = true;
            lstFirstName.Location = new Point(201, 3);
            lstFirstName.Name = "lstFirstName";
            lstFirstName.Size = new Size(138, 29);
            lstFirstName.TabIndex = 19;
            // 
            // tsMain
            // 
            tsMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsMain.Items.AddRange(new ToolStripItem[] { btnSave, toolStripSeparator1, btnDelete, toolStripSeparator2 });
            tsMain.Location = new Point(0, 0);
            tsMain.Name = "tsMain";
            tsMain.Size = new Size(354, 28);
            tsMain.TabIndex = 1;
            tsMain.Text = "toolStrip1";
            // 
            // btnSave
            // 
            btnSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageTransparentColor = Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(47, 25);
            btnSave.Text = "&Save";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 28);
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(58, 25);
            btnDelete.Text = "&Delete";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 28);
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 458);
            Controls.Add(tsMain);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private TextBox txtDateDrafted;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private TextBox txtRecipePic;
        private TextBox txtRecipeStatus;
        private ToolStrip tsMain;
        private ToolStripButton btnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ComboBox lstCuisineName;
        private ComboBox lstFirstName;
        private ToolStripButton btnDelete;
    }
}