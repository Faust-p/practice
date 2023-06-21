using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using static ListOfRecipes.Form1;

namespace ListOfRecipes
{
    public partial class Form1 : Form
    {
        public class Recipe
        {
            public string Name { get; set; }
            public List<Ingredient> Ingredients { get; set; }
            public string Description { get; set; }
            public string GroupName { get; set; }

            public Recipe(string name, List<Ingredient> ingredients, string description, string groupName)
            {
                Name = name;
                Ingredients = ingredients;
                Description = description;
                GroupName = groupName;
            }
        }

        public class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }

            public Ingredient(string name, double quantity)
            {
                Name = name;
                Quantity = quantity;
            }
        }

        public class RecipeCategory
        {
            public string Name { get; set; }
            public List<Recipe> Recipes { get; set; }

            public RecipeCategory(string name, List<Recipe> recipes)
            {
                Name = name;
                Recipes = recipes;
            }
        }

        private List<RecipeCategory> recipeGroups;
        public Form1()
        {
            InitializeComponent();
            // Инициализация списка рецептов и групп
            recipeGroups = new List<RecipeCategory>(){};

            // Добавление узла для отображения всех рецептов
            TreeNode allRecipesNode = new TreeNode("Все рецепты");
            treeViewRecipes.Nodes.Add(allRecipesNode);

            // Отображение дерева рецептов
            foreach (RecipeCategory recipeGroup in recipeGroups)
            {
                TreeNode groupNode = new TreeNode(recipeGroup.Name);

                foreach (Recipe recipe in recipeGroup.Recipes)
                {
                    TreeNode recipeNode = new TreeNode(recipe.Name);
                    groupNode.Nodes.Add(recipeNode);

                    // Добавление рецепта в узел "Все рецепты"
                    TreeNode allRecipesRecipeNode = new TreeNode(recipe.Name);
                    allRecipesNode.Nodes.Add(allRecipesRecipeNode);
                }

                treeViewRecipes.Nodes.Add(groupNode);
            }

            // Подключение обработчика события AfterSelect для treeViewRecipes
            treeViewRecipes.NodeMouseDoubleClick += treeViewRecipes_NodeMouseDoubleClick;
        }

        private void treeViewRecipes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null) // Если выбран узел рецепта
            {
                string recipeName = e.Node.Text;
                Recipe selectedRecipe = null;

                // Поиск выбранного рецепта
                foreach (RecipeCategory recipeGroup in recipeGroups)
                {
                    selectedRecipe = recipeGroup.Recipes.Find(r => r.Name == recipeName);
                    if (selectedRecipe != null) break;
                }

                // Открытие формы RecipeForm с выбранным рецептом
                RecipeForm recipeForm = new RecipeForm(selectedRecipe);
                recipeForm.ShowDialog(); 
                treeViewRecipes.SelectedNode.Text = selectedRecipe.Name;

                // Поиск узла "Все рецепты" и замена названия
                TreeNode allRecipesNode = treeViewRecipes.Nodes[0]; // Получаем узел "Все рецепты"
                TreeNode allRecipesRecipeNode = allRecipesNode.Nodes.OfType<TreeNode>().FirstOrDefault(node => node.Text == recipeName);
                if (allRecipesRecipeNode != null)
                    allRecipesRecipeNode.Text = selectedRecipe.Name;

                // Обновление названия рецепта в других категориях
                foreach (TreeNode groupNode in treeViewRecipes.Nodes)
                {
                    if (groupNode != allRecipesNode)
                    {
                        TreeNode recipeNodeToUpdate = groupNode.Nodes.OfType<TreeNode>().FirstOrDefault(node => node.Text == recipeName);
                        if (recipeNodeToUpdate != null)
                            recipeNodeToUpdate.Text = selectedRecipe.Name;
                    }
                }
            }
        }

        private void buttonCreateCategory_Click(object sender, EventArgs e)
        {
            // Открытие диалогового окна для получения имени новой категории
            string groupName = Interaction.InputBox("Введите название новой категории:", "Создание новой категории");

            // Проверка на нажатие кнопки "Отмена" или пустой ввод
            if (string.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("Категория не была создана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Выходим из метода, если была нажата кнопка "Отмена" или введена пустая строка
            }

            // Создание новой категории с пустым списком рецептов
            RecipeCategory newGroup = new RecipeCategory(groupName, new List<Recipe>());

            // Добавление новой категории в список recipeGroups
            recipeGroups.Add(newGroup);

            // Добавление новой категории в дерево рецептов
            TreeNode groupNode = new TreeNode(groupName);
            treeViewRecipes.Nodes.Add(groupNode);
        }

        private void buttonCreateRecipe_Click(object sender, EventArgs e)
        {
            // Проверка, выбрана ли категория в дереве рецептов
            if (treeViewRecipes.SelectedNode == null)
            {
                MessageBox.Show("Выберите категорию для добавления нового рецепта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Открытие диалогового окна для получения информации о новом рецепте 
            string recipeName = Interaction.InputBox("Введите название нового рецепта:", "Создание нового рецепта");
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Рецепт не был создан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получение выбранной категории
            string groupName = treeViewRecipes.SelectedNode.Text;
            RecipeCategory selectedGroup = recipeGroups.FirstOrDefault(group => group.Name == groupName);

            if (selectedGroup == null)
            {
                MessageBox.Show("Ошибка при поиске выбранной категории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Создание нового рецепта и добавление его в выбранную категорию
            Recipe newRecipe = new Recipe(recipeName, new List<Ingredient>(), "", groupName);
            selectedGroup.Recipes.Add(newRecipe);

            // Добавление нового рецепта в дерево рецептов
            TreeNode recipeNode = new TreeNode(recipeName);
            treeViewRecipes.SelectedNode.Nodes.Add(recipeNode);

            // Добавление нового рецепта в узел "Все рецепты"
            TreeNode allRecipesRecipeNode = new TreeNode(recipeName);
            treeViewRecipes.Nodes[0].Nodes.Add(allRecipesRecipeNode);

            RecipeForm recipeForm = new RecipeForm(newRecipe);

            recipeForm.ShowDialog();
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            // Проверка, выбрана ли категория в дереве рецептов
            if (treeViewRecipes.SelectedNode == null || treeViewRecipes.SelectedNode.Parent != null)
            {
                MessageBox.Show("Выберите категорию для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получение выбранной категории
            string groupName = treeViewRecipes.SelectedNode.Text;
            RecipeCategory selectedGroup = recipeGroups.FirstOrDefault(group => group.Name == groupName);

            if (selectedGroup == null)
            {
                MessageBox.Show("Ошибка при поиске выбранной категории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Удаление выбранной категории из списка recipeGroups
            recipeGroups.Remove(selectedGroup);

            // Удаление выбранной категории из дерева рецептов
            treeViewRecipes.Nodes.Remove(treeViewRecipes.SelectedNode);

            // Удаление всех рецептов выбранной категории из узла "Все рецепты"
            TreeNode allRecipesNode = treeViewRecipes.Nodes[0]; // Получаем узел "Все рецепты"

            foreach (Recipe recipe in selectedGroup.Recipes)
            {
                TreeNode recipeNodeToRemove = allRecipesNode.Nodes.OfType<TreeNode>().FirstOrDefault(node => node.Text == recipe.Name); // Находим узел рецепта для удаления

                if (recipeNodeToRemove != null)
                allRecipesNode.Nodes.Remove(recipeNodeToRemove);
            }
        }

        private void buttonDeleteRecipe_Click(object sender, EventArgs e)
        {
            // Проверка, выбран ли рецепт в дереве рецептов
            if (treeViewRecipes.SelectedNode == null || treeViewRecipes.SelectedNode.Parent == null)
            {
                MessageBox.Show("Выберите рецепт для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получение выбранного рецепта
            string recipeName = treeViewRecipes.SelectedNode.Text;
            Recipe selectedRecipe = null;

            // Поиск выбранного рецепта
            foreach (RecipeCategory recipeGroup in recipeGroups)
            {
                selectedRecipe = recipeGroup.Recipes.Find(r => r.Name == recipeName);
                if (selectedRecipe != null) break;
            }

            if (selectedRecipe == null)
            {
                MessageBox.Show("Ошибка при поиске выбранного рецепта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получение выбранной категории
            string groupName = treeViewRecipes.SelectedNode.Parent.Text;
            RecipeCategory selectedGroup = recipeGroups.FirstOrDefault(group => group.Name == groupName);

            if (selectedGroup == null)
            {
                MessageBox.Show("Ошибка при поиске выбранной категории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Удаление выбранного рецепта из выбранной категории
            selectedGroup.Recipes.Remove(selectedRecipe);

            // Удаление выбранного рецепта из дерева рецептов
            treeViewRecipes.SelectedNode.Parent.Nodes.Remove(treeViewRecipes.SelectedNode);

            // Удаление выбранного рецепта из узла "Все рецепты"
            TreeNode allRecipesNode = treeViewRecipes.Nodes[0]; // Получаем узел "Все рецепты"
            TreeNode recipeNodeToRemove = allRecipesNode.Nodes.OfType<TreeNode>().FirstOrDefault(node => node.Text == recipeName); // Находим узел рецепта для удаления

            if (recipeNodeToRemove != null)
                allRecipesNode.Nodes.Remove(recipeNodeToRemove); // Удаляем узел рецепта

        }

        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            // Проверка, выбрана ли категория в дереве рецептов
            if (treeViewRecipes.SelectedNode == null || treeViewRecipes.SelectedNode.Parent != null)
            {
                MessageBox.Show("Выберите категорию для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получение выбранной категории
            string groupName = treeViewRecipes.SelectedNode.Text;
            RecipeCategory selectedGroup = recipeGroups.FirstOrDefault(group => group.Name == groupName);

            if (selectedGroup == null)
            {
                MessageBox.Show("Ошибка при поиске выбранной категории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Открытие диалогового окна для редактирования названия категории
            string newGroupName = Interaction.InputBox("Введите новое название категории:", "Редактирование категории", groupName);
            if (string.IsNullOrEmpty(newGroupName))
            {
                MessageBox.Show("Название категории не может быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Обновление названия категории
            selectedGroup.Name = newGroupName;
            treeViewRecipes.SelectedNode.Text = newGroupName;
        }

        private void buttonSearchByName_Click(object sender, EventArgs e)
        {
            string searchQuery = textBoxSearchByName.Text;
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("Введите название рецепта для поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Recipe foundRecipe = null;

            foreach (RecipeCategory recipeGroup in recipeGroups)
            {
                foundRecipe = recipeGroup.Recipes.Find(r => r.Name.Equals(searchQuery, StringComparison.OrdinalIgnoreCase));
                if (foundRecipe != null)
                break;
            }

            if (foundRecipe != null)
            {
                RecipeForm recipeForm = new RecipeForm(foundRecipe);
                recipeForm.ShowDialog();

                // Обновление названия рецепта в выбранной категории
                TreeNode selectedNode = treeViewRecipes.SelectedNode;
                if (selectedNode.Parent != null)
                selectedNode.Text = foundRecipe.Name;

                // Обновление названия рецепта в узле "Все рецепты"
                TreeNode allRecipesNode = treeViewRecipes.Nodes[0]; // Получаем узел "Все рецепты"
                TreeNode allRecipesRecipeNode = allRecipesNode.Nodes.OfType<TreeNode>().FirstOrDefault(node => node.Text == searchQuery);
                if (allRecipesRecipeNode != null)
                allRecipesRecipeNode.Text = foundRecipe.Name;

                // Обновление названия рецепта в других категориях
                foreach (TreeNode groupNode in treeViewRecipes.Nodes)
                    if (groupNode != allRecipesNode)
                        foreach (TreeNode recipeNodeToUpdate in groupNode.Nodes)
                            if (recipeNodeToUpdate.Text == searchQuery)
                            {
                                recipeNodeToUpdate.Text = foundRecipe.Name;
                                break;
                            }
            }
            else
                MessageBox.Show("Рецепт не найден", "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSearchByIngredient_Click(object sender, EventArgs e)
        {
            string searchQuery = textBoxSearchByIngredient.Text;
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("Введите ингредиент для поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Recipe> searchResults = new List<Recipe>();

            foreach (RecipeCategory recipeGroup in recipeGroups)
            {
                List<Recipe> recipes = recipeGroup.Recipes.Where(r => r.Ingredients.Any(i => i.Name.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
                searchResults.AddRange(recipes);
            }

            DisplaySearchResults(searchResults);
        }
        private void DisplaySearchResults(List<Recipe> searchResults)
        {
            if (searchResults.Count == 0)
            {
                MessageBox.Show("По вашему запросу ничего не найдено", "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string resultMessage = $"Найдено {searchResults.Count} рецептов:\n\n";

            foreach (Recipe recipe in searchResults)
            {
                resultMessage += $"- {recipe.Name}\n";
            }

            MessageBox.Show(resultMessage, "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public class RecipeManager
        {
            public void SaveRecipeCategories(List<RecipeCategory> recipeCategories, string filePath)
            {
                string json = JsonConvert.SerializeObject(recipeCategories, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }

            public List<RecipeCategory> LoadRecipeCategories(string filePath)
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<RecipeCategory>>(json);
                }
                else
                {
                    return new List<RecipeCategory>();
                }
            }
        }
        private RecipeManager recipeManager = new RecipeManager();
        private void buttonSave_Click(object sender, EventArgs e)
        {

            // Получаем категории рецептов из поля recipeGroups формы
            List<RecipeCategory> recipeCategories = recipeGroups;

            // Сохраняем категории рецептов в файл
            recipeManager.SaveRecipeCategories(recipeCategories, "recipes.json");
            MessageBox.Show("Рецепты сохранены", "Статус сохранения", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // Загрузка категорий рецептов из файла
            List<RecipeCategory> loadedRecipeCategories = recipeManager.LoadRecipeCategories("recipes.json");

            // Обновление поля recipeGroups формы
            recipeGroups = loadedRecipeCategories;

            // Очистка узлов в treeViewRecipes
            treeViewRecipes.Nodes.Clear();

            // Добавление узла для отображения всех рецептов
            TreeNode allRecipesNode = new TreeNode("Все рецепты");
            treeViewRecipes.Nodes.Add(allRecipesNode);

            // Отображение дерева рецептов
            foreach (RecipeCategory recipeGroup in recipeGroups)
            {
                TreeNode groupNode = new TreeNode(recipeGroup.Name);

                foreach (Recipe recipe in recipeGroup.Recipes)
                {
                    TreeNode recipeNode = new TreeNode(recipe.Name);
                    groupNode.Nodes.Add(recipeNode);

                    // Добавление рецепта в узел "Все рецепты"
                    TreeNode allRecipesRecipeNode = new TreeNode(recipe.Name);
                    allRecipesNode.Nodes.Add(allRecipesRecipeNode);
                }

                treeViewRecipes.Nodes.Add(groupNode);
            }
            MessageBox.Show("Рецепты загружены", "Статус загрузки", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
