namespace InlämningDesignpatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();

            var pizzaRecipe = RecipeFactory.CreateRecipe("Pizza", "Delicious Italian pizza with cheese and tomato sauce.", false);
            var saladRecipe = RecipeFactory.CreateRecipe("Salad", "Healthy salad with fresh vegetables and dressing.", true);

            recipeManager.AddRecipe(pizzaRecipe);
            recipeManager.AddRecipe(saladRecipe);
            recipeManager.DisplayRecipes();

            AddRecipesFromUserInput(recipeManager);
            recipeManager.SortRecipes();
            recipeManager.DisplayRecipes();
        }

        static void AddRecipesFromUserInput(RecipeManager recipeManager)
        {
            while (true)
            {
                Console.WriteLine("\nDo you want to add a new recipe? (yes/no)");
                string response = Console.ReadLine().ToLower();

                if (response == "no")
                {
                    PerformUndoRedoActions(recipeManager);
                    break;
                }
                else if (response == "yes")
                {
                    Console.WriteLine("Enter recipe name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter recipe description:");
                    string description = Console.ReadLine();

                    Console.WriteLine("Is it vegetarian? (yes/no)");
                    bool isVegetarian = Console.ReadLine().ToLower() == "yes";

                    Recipe newRecipe = RecipeFactory.CreateRecipe(name, description, isVegetarian);

                    recipeManager.AddRecipe(newRecipe);
                }
                else
                {
                    Console.WriteLine("Invalid response. Please enter 'yes' or 'no'.");
                    continue;
                }
            }
        }
        
        static void PerformUndoRedoActions(RecipeManager recipeManager)
        {
            while (true)
            {
                Console.WriteLine("\nDo you want to undo, redo, show all recipes, or exit the program? (undo/redo/recipes/exit)");
                string response = Console.ReadLine().ToLower();

                if (response == "undo")
                {
                    recipeManager.Undo();
                }
                else if (response == "redo")
                {
                    recipeManager.Redo();
                }
                else if (response == "recipes")
                {
                    recipeManager.DisplayRecipes();
                }
                else if (response == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid response. Please enter 'undo', 'redo', 'recipes', or 'exit'.");
                }
            }
        }
    }
}