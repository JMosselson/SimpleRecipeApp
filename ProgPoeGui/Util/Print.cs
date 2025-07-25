using System;
using System.Collections.Generic;
using System.Windows;
using ProgPoeGui.Model;

namespace ProgPoeGui.Util
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
            string recipeNames = "";
            foreach (Recipe recipe in recipes)
            {
                recipeNames += recipe.Name + "\n";
            }
            OutputDialog.ShowDialog(recipeNames, "Recipes");
        }

        // Method to display the details of a recipe
        public void DisplayRecipeDetails(string recipeName)
        {
            Recipe recipe = GetRecipe(recipeName);
            if (recipe != null)
            {
                string recipeDetails = $"Recipe: {recipe.Name}\n\nIngredients:\n";
                foreach (var ingredient in recipe.Ingredients)
                {
                    recipeDetails += $"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories) - {ingredient.FoodGroup}\n";
                }
                recipeDetails += "\nSteps:\n";
                for (int i = 0; i < recipe.Steps.Count; i++)
                {
                    recipeDetails += $"{i + 1}. {recipe.Steps[i]}\n";
                }
                OutputDialog.ShowDialog(recipeDetails, "Recipe Details");
            }
            else
            {
                OutputDialog.ShowDialog("Recipe not found!", "Error");
            }
        }
    }
}
