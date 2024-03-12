using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningDesignpatterns
{
    class AddRecipeCommand : ICommand
    {
        private Recipe recipe;
        private RecipeManager recipeManager;

        public AddRecipeCommand(Recipe recipe, RecipeManager recipeManager)
        {
            this.recipe = recipe;
            this.recipeManager = recipeManager;
        }

        public void Execute()
        {
            recipeManager.AddRecipe(recipe);
        }

        public void Undo()
        {
            recipeManager.RemoveRecipe(recipe);
        }
    }
}
