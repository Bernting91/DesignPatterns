using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningDesignpatterns
{
    class VegetarianRecipe : Recipe
    {
        public VegetarianRecipe(string name, string description) : base(name, description)
        {
        }

        public override bool IsVegetarian => true;
    }
}
