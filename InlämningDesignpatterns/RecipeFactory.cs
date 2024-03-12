using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningDesignpatterns
{
    static class RecipeFactory
    {
        public static Recipe CreateRecipe(string name, string description, bool isVegetarian)
        {
            if (isVegetarian)
            {
                return new VegetarianRecipe(name, description);
            }
            else
            {
                return new NonVegetarianRecipe(name, description);
            }
        }
    }
}
