using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ListOfRecipes.Form1;

namespace ListOfRecipes
{
    public partial class RecipeForm : Form
    {
        private Recipe recipe;
        private List<Ingredient> ingredients;
        private void RefreshDataGridView()
        {
            dataGridViewIngredients.DataSource = null;
            dataGridViewIngredients.DataSource = ingredients;
            dataGridViewIngredients.Columns["Name"].HeaderText = "Название";
            dataGridViewIngredients.Columns["Quantity"].HeaderText = "Количество";
            dataGridViewIngredients.Refresh();
        }
        public RecipeForm(Recipe recipe)
        {
            InitializeComponent();
            dataGridViewIngredients.ReadOnly = true;
            textBoxDescription.ReadOnly = true;
            textBoxRecipeName.ReadOnly = true;
            buttonAddIngredient.Visible = false;
            buttonDeleteIngredient.Visible = false;

            this.recipe = recipe;
            ingredients = recipe.Ingredients;

            // Установите название рецепта и описание на форме
            textBoxRecipeName.Text = recipe.Name;
            textBoxDescription.Text = recipe.Description;


            dataGridViewIngredients.DataSource = ingredients;
            RefreshDataGridView();
            // При новом рецепте
            if (string.IsNullOrEmpty(recipe.Description) && (ingredients == null || ingredients.Count == 0))
            {
                buttonEdit_Click(buttonEdit, EventArgs.Empty);
                textBoxRecipeName.ReadOnly = true;
                buttonDeleteIngredient.Visible = false;
            }
        }
        private void buttonAddIngredient_Click(object sender, EventArgs e)
        {
            string ingredientName = Interaction.InputBox("Введите название ингредиента:", "Добавление ингредиента");
            if (string.IsNullOrEmpty(ingredientName))
            {
                MessageBox.Show("Ингредиент не был добавлен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double quantity;
            if (!double.TryParse(Interaction.InputBox("Введите количество:", "Добавление ингредиента"), out quantity))
            {
                MessageBox.Show("Неверное количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Ingredient ingredient = new Ingredient(ingredientName, quantity);
            ingredients.Add(ingredient);

            RefreshDataGridView();
        }

        private void buttonDeleteIngredient_Click(object sender, EventArgs e)
        {

            if (dataGridViewIngredients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ингредиент не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Ingredient selectedIngredient = (Ingredient)dataGridViewIngredients.SelectedRows[0].DataBoundItem;
            ingredients.Remove(selectedIngredient);

            RefreshDataGridView();
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {

            recipe.Description = textBoxDescription.Text;
            recipe.Name = textBoxRecipeName.Text;

            // Проверка на пустое описание
            if (string.IsNullOrEmpty(textBoxDescription.Text))
            {
                MessageBox.Show("Введите описание рецепта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка на пустое название
            if (string.IsNullOrEmpty(textBoxRecipeName.Text))
            {
                MessageBox.Show("Введите название рецепта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка на пустой список ингредиентов
            if (ingredients == null || ingredients.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы один ингредиент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            this.Text = "Редактирование рецепта";
            buttonSave.Text = "Сохранить";
            buttonEdit.Visible = false;
            dataGridViewIngredients.ReadOnly = false;
            textBoxDescription.ReadOnly = false;
            buttonAddIngredient.Visible = true;
            buttonDeleteIngredient.Visible = true;
            textBoxRecipeName.ReadOnly = false;
        }
    }
}
