using System;
using System.Collections.Generic;
using ProgrammingPOE.Model;

namespace ProgrammingPOE.Util
{
    public class Print
    {
        public List<Recipe> recipes; // List of recipes

        // Constructor
        public Print()
        {
            recipes = new List<Recipe>(); // Initialize recipes list
        }

        // Method to add a recipe to the list
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        // Method to delete a recipe from the list
        public void DeleteRecipe(string recipeName)
        {
            Recipe recipeToDelete = GetRecipe(recipeName);
            if (recipeToDelete != null)
            {
                recipes.Remove(recipeToDelete);
            }
        }

        // Method to get a recipe from the list by name
        public Recipe GetRecipe(string recipeName)
        {
            return recipes.Find(r => r.Name.ToLower() == recipeName.ToLower());
        }

        // Method to display the list of recipes
        public void DisplayRecipeList()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nRecipes:");
            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nEnter 'back' to return to the main menu.");
        }

        // Method to display the details of a recipe
        public void DisplayRecipeDetails(string recipeName)
        {
            Recipe recipe = GetRecipe(recipeName);
            if (recipe != null)
            {
                recipe.DisplayRecipe();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Recipe not found!");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        }
    }
}
