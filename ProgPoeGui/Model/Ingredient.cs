using System;
using System.Collections.Generic;

namespace ProgPoeGui.Model
{
    public class Ingredient
    {
        // Property to store the name of the ingredient
        public string Name { get; set; }

        // Property to store the quantity of the ingredient
        public double Quantity { get; set; }

        // Property to store the unit of measurement for the ingredient quantity
        public string Unit { get; set; }

        // Property to store the calories per quantity of the ingredient
        public double Calories { get; set; }

        // Property to store the food group of the ingredient
        public string FoodGroup { get; set; }

        // Property to store the scale factor of the ingredient (default is 1.0)
        public double ScaleFactor { get; set; } = 1.0;
    }
}
