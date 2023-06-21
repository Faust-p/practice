namespace ListOfRecipes
{
    partial class RecipeForm
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
            this.labelRecipeName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewIngredients = new System.Windows.Forms.DataGridView();
            this.buttonAddIngredient = new System.Windows.Forms.Button();
            this.buttonDeleteIngredient = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.textBoxRecipeName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRecipeName
            // 
            this.labelRecipeName.AutoSize = true;
            this.labelRecipeName.Location = new System.Drawing.Point(12, 9);
            this.labelRecipeName.Name = "labelRecipeName";
            this.labelRecipeName.Size = new System.Drawing.Size(101, 13);
            this.labelRecipeName.TabIndex = 0;
            this.labelRecipeName.Text = "Название рецепта";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(12, 80);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(380, 300);
            this.textBoxDescription.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Описание рецепта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ингредиенты";
            // 
            // dataGridViewIngredients
            // 
            this.dataGridViewIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIngredients.Location = new System.Drawing.Point(408, 80);
            this.dataGridViewIngredients.Name = "dataGridViewIngredients";
            this.dataGridViewIngredients.ReadOnly = true;
            this.dataGridViewIngredients.Size = new System.Drawing.Size(380, 300);
            this.dataGridViewIngredients.TabIndex = 5;
            // 
            // buttonAddIngredient
            // 
            this.buttonAddIngredient.Location = new System.Drawing.Point(15, 415);
            this.buttonAddIngredient.Name = "buttonAddIngredient";
            this.buttonAddIngredient.Size = new System.Drawing.Size(330, 23);
            this.buttonAddIngredient.TabIndex = 6;
            this.buttonAddIngredient.Text = "Добавить ингредиент";
            this.buttonAddIngredient.UseVisualStyleBackColor = true;
            this.buttonAddIngredient.Click += new System.EventHandler(this.buttonAddIngredient_Click);
            // 
            // buttonDeleteIngredient
            // 
            this.buttonDeleteIngredient.Location = new System.Drawing.Point(351, 415);
            this.buttonDeleteIngredient.Name = "buttonDeleteIngredient";
            this.buttonDeleteIngredient.Size = new System.Drawing.Size(330, 23);
            this.buttonDeleteIngredient.TabIndex = 7;
            this.buttonDeleteIngredient.Text = "Удалить ингредиент";
            this.buttonDeleteIngredient.UseVisualStyleBackColor = true;
            this.buttonDeleteIngredient.Click += new System.EventHandler(this.buttonDeleteIngredient_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(687, 415);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(101, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Закрыть";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(12, 386);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(776, 23);
            this.buttonEdit.TabIndex = 9;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // textBoxRecipeName
            // 
            this.textBoxRecipeName.Location = new System.Drawing.Point(15, 25);
            this.textBoxRecipeName.Name = "textBoxRecipeName";
            this.textBoxRecipeName.Size = new System.Drawing.Size(157, 20);
            this.textBoxRecipeName.TabIndex = 10;
            // 
            // RecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxRecipeName);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDeleteIngredient);
            this.Controls.Add(this.buttonAddIngredient);
            this.Controls.Add(this.dataGridViewIngredients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelRecipeName);
            this.Name = "RecipeForm";
            this.Text = "Информация о рецепте";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIngredients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRecipeName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewIngredients;
        private System.Windows.Forms.Button buttonAddIngredient;
        private System.Windows.Forms.Button buttonDeleteIngredient;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TextBox textBoxRecipeName;
    }
}