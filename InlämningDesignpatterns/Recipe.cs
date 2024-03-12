using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningDesignpatterns
{
    abstract class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public abstract bool IsVegetarian { get; }

        protected Recipe(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
