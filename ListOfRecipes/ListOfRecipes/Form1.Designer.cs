namespace ListOfRecipes
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewRecipes = new System.Windows.Forms.TreeView();
            this.buttonCreateCategory = new System.Windows.Forms.Button();
            this.buttonCreateRecipe = new System.Windows.Forms.Button();
            this.buttonDeleteCategory = new System.Windows.Forms.Button();
            this.buttonDeleteRecipe = new System.Windows.Forms.Button();
            this.buttonEditCategory = new System.Windows.Forms.Button();
            this.textBoxSearchByName = new System.Windows.Forms.TextBox();
            this.buttonSearchByName = new System.Windows.Forms.Button();
            this.buttonSearchByIngredient = new System.Windows.Forms.Button();
            this.textBoxSearchByIngredient = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewRecipes
            // 
            this.treeViewRecipes.Location = new System.Drawing.Point(12, 12);
            this.treeViewRecipes.Name = "treeViewRecipes";
            this.treeViewRecipes.Size = new System.Drawing.Size(267, 426);
            this.treeViewRecipes.TabIndex = 1;
            // 
            // buttonCreateCategory
            // 
            this.buttonCreateCategory.ForeColor = System.Drawing.Color.RoyalBlue;
            this.buttonCreateCategory.Location = new System.Drawing.Point(538, 12);
            this.buttonCreateCategory.Name = "buttonCreateCategory";
            this.buttonCreateCategory.Size = new System.Drawing.Size(250, 80);
            this.buttonCreateCategory.TabIndex = 5;
            this.buttonCreateCategory.Text = "Добавить категорию";
            this.buttonCreateCategory.UseVisualStyleBackColor = true;
            this.buttonCreateCategory.Click += new System.EventHandler(this.buttonCreateCategory_Click);
            // 
            // buttonCreateRecipe
            // 
            this.buttonCreateRecipe.ForeColor = System.Drawing.Color.RoyalBlue;
            this.buttonCreateRecipe.Location = new System.Drawing.Point(538, 98);
            this.buttonCreateRecipe.Name = "buttonCreateRecipe";
            this.buttonCreateRecipe.Size = new System.Drawing.Size(250, 80);
            this.buttonCreateRecipe.TabIndex = 6;
            this.buttonCreateRecipe.Text = "Добавить рецепт";
            this.buttonCreateRecipe.UseVisualStyleBackColor = true;
            this.buttonCreateRecipe.Click += new System.EventHandler(this.buttonCreateRecipe_Click);
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.ForeColor = System.Drawing.Color.Firebrick;
            this.buttonDeleteCategory.Location = new System.Drawing.Point(538, 358);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.Size = new System.Drawing.Size(250, 80);
            this.buttonDeleteCategory.TabIndex = 7;
            this.buttonDeleteCategory.Text = "Удалить категорию";
            this.buttonDeleteCategory.UseVisualStyleBackColor = true;
            this.buttonDeleteCategory.Click += new System.EventHandler(this.buttonDeleteCategory_Click);
            // 
            // buttonDeleteRecipe
            // 
            this.buttonDeleteRecipe.ForeColor = System.Drawing.Color.Firebrick;
            this.buttonDeleteRecipe.Location = new System.Drawing.Point(538, 272);
            this.buttonDeleteRecipe.Name = "buttonDeleteRecipe";
            this.buttonDeleteRecipe.Size = new System.Drawing.Size(250, 80);
            this.buttonDeleteRecipe.TabIndex = 8;
            this.buttonDeleteRecipe.Text = "Удалить рецепт";
            this.buttonDeleteRecipe.UseVisualStyleBackColor = true;
            this.buttonDeleteRecipe.Click += new System.EventHandler(this.buttonDeleteRecipe_Click);
            // 
            // buttonEditCategory
            // 
            this.buttonEditCategory.Location = new System.Drawing.Point(538, 184);
            this.buttonEditCategory.Name = "buttonEditCategory";
            this.buttonEditCategory.Size = new System.Drawing.Size(250, 82);
            this.buttonEditCategory.TabIndex = 9;
            this.buttonEditCategory.Text = "Редактировать название категории";
            this.buttonEditCategory.UseVisualStyleBackColor = true;
            this.buttonEditCategory.Click += new System.EventHandler(this.buttonEditCategory_Click);
            // 
            // textBoxSearchByName
            // 
            this.textBoxSearchByName.Location = new System.Drawing.Point(285, 12);
            this.textBoxSearchByName.Name = "textBoxSearchByName";
            this.textBoxSearchByName.Size = new System.Drawing.Size(247, 20);
            this.textBoxSearchByName.TabIndex = 10;
            // 
            // buttonSearchByName
            // 
            this.buttonSearchByName.Location = new System.Drawing.Point(285, 39);
            this.buttonSearchByName.Name = "buttonSearchByName";
            this.buttonSearchByName.Size = new System.Drawing.Size(247, 82);
            this.buttonSearchByName.TabIndex = 11;
            this.buttonSearchByName.Text = "Поиск по названию";
            this.buttonSearchByName.UseVisualStyleBackColor = true;
            this.buttonSearchByName.Click += new System.EventHandler(this.buttonSearchByName_Click);
            // 
            // buttonSearchByIngredient
            // 
            this.buttonSearchByIngredient.Location = new System.Drawing.Point(285, 184);
            this.buttonSearchByIngredient.Name = "buttonSearchByIngredient";
            this.buttonSearchByIngredient.Size = new System.Drawing.Size(247, 82);
            this.buttonSearchByIngredient.TabIndex = 12;
            this.buttonSearchByIngredient.Text = "Поиск по ингредиенту";
            this.buttonSearchByIngredient.UseVisualStyleBackColor = true;
            this.buttonSearchByIngredient.Click += new System.EventHandler(this.buttonSearchByIngredient_Click);
            // 
            // textBoxSearchByIngredient
            // 
            this.textBoxSearchByIngredient.Location = new System.Drawing.Point(285, 158);
            this.textBoxSearchByIngredient.Name = "textBoxSearchByIngredient";
            this.textBoxSearchByIngredient.Size = new System.Drawing.Size(247, 20);
            this.textBoxSearchByIngredient.TabIndex = 13;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(285, 272);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(247, 80);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Сохранить рецепты";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(285, 358);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(247, 80);
            this.buttonLoad.TabIndex = 15;
            this.buttonLoad.Text = "Загрузить рецепты";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxSearchByIngredient);
            this.Controls.Add(this.buttonSearchByIngredient);
            this.Controls.Add(this.buttonSearchByName);
            this.Controls.Add(this.textBoxSearchByName);
            this.Controls.Add(this.buttonEditCategory);
            this.Controls.Add(this.buttonDeleteRecipe);
            this.Controls.Add(this.buttonDeleteCategory);
            this.Controls.Add(this.buttonCreateRecipe);
            this.Controls.Add(this.buttonCreateCategory);
            this.Controls.Add(this.treeViewRecipes);
            this.Name = "Form1";
            this.Text = "Менеджер рецептов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeViewRecipes;
        private System.Windows.Forms.Button buttonCreateCategory;
        private System.Windows.Forms.Button buttonCreateRecipe;
        private System.Windows.Forms.Button buttonDeleteCategory;
        private System.Windows.Forms.Button buttonDeleteRecipe;
        private System.Windows.Forms.Button buttonEditCategory;
        private System.Windows.Forms.TextBox textBoxSearchByName;
        private System.Windows.Forms.Button buttonSearchByName;
        private System.Windows.Forms.Button buttonSearchByIngredient;
        private System.Windows.Forms.TextBox textBoxSearchByIngredient;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
    }
}

