using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningDesignpatterns
{
    class RecipeBuilder
    {
        private string name;
        private string description;
        private bool isVegetarian;

        public RecipeBuilder(string name)
        {
            this.name = name;
            description = "";
            isVegetarian = false;
        }

        public RecipeBuilder AddDescription(string description)
        {
            this.description = description;
            return this;
        }

        public RecipeBuilder SetVegetarian(bool isVegetarian)
        {
            this.isVegetarian = isVegetarian;
            return this;
        }

        public Recipe Build()
        {
            return RecipeFactory.CreateRecipe(name, description, isVegetarian);
        }
    }
}
