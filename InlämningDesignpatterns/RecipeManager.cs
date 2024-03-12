using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningDesignpatterns
{
    class RecipeManager
    {
        private List<Recipe> recipes = new List<Recipe>();
        private Stack<ICommand> executedCommands = new Stack<ICommand>();
        private Stack<ICommand> undoneCommands = new Stack<ICommand>();

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            executedCommands.Push(new AddRecipeCommand(recipe, this));
            undoneCommands.Clear();
        }

        public void RemoveRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
        }

        public void Undo()
        {
            if (executedCommands.Count > 0)
            {
                ICommand command = executedCommands.Pop();
                command.Undo();
                undoneCommands.Push(command);
            }
            else
            {
                Console.WriteLine("Nothing more to undo.");
            }
        }

        public void Redo()
        {
            if (undoneCommands.Count > 0)
            {
                ICommand command = undoneCommands.Pop();
                command.Execute();
                executedCommands.Push(command);
            }
            else
            {
                Console.WriteLine("Nothing more to redo.");
            }
        }

        public void DisplayRecipes()
        {
            Console.WriteLine("Recipes:");
            foreach (var recipe in recipes)
            {
                string vegetarian = recipe.IsVegetarian ? "Vegetarian" : "Non-Vegetarian";
                Console.WriteLine($"- {recipe.Name}: {recipe.Description} ({vegetarian})");
            }
        }

        public void SortRecipes()
        {
            InsertionSort(recipes);
        }

        private void InsertionSort(List<Recipe> recipes)
        {
            int n = recipes.Count;
            for (int i = 1; i < n; ++i)
            {
                Recipe key = recipes[i];
                int j = i - 1;
                while (j >= 0 && Compare(recipes[j], key) > 0)
                {
                    recipes[j + 1] = recipes[j];
                    j = j - 1;
                }
                recipes[j + 1] = key;
            }
        }

        private int Compare(Recipe x, Recipe y)
        {
            int vegetarianComparison = CompareVegetarian(x.IsVegetarian, y.IsVegetarian);

            if (vegetarianComparison != 0)
            {
                return vegetarianComparison;
            }
            else
            {
                return StringComparer.OrdinalIgnoreCase.Compare(x.Name, y.Name);
            }
        }

        private int CompareVegetarian(bool isVegetarianX, bool isVegetarianY)
        {
            if (isVegetarianX && !isVegetarianY)
            {
                return -1;
            }
            else if (!isVegetarianX && isVegetarianY)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
