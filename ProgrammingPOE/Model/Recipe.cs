using System;
using System.Collections.Generic;
using System.Linq;
using ProgrammingPOE.ExceptionHandling;
using ProgrammingPOE.Util;

namespace ProgrammingPOE.Model
{
    public class Recipe
    {
        // Properties
        public List<Ingredient> Ingredients { get; private set; } // List of ingredients
        public List<string> Steps { get; private set; } // List of steps
        public string Name { get; private set; } // Name of the recipe

        // Constructor
        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>(); // Initialize ingredients list
            Steps = new List<string>(); // Initialize steps list
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
        }

        // Method to add a step to the recipe
        public void AddStep(string description)
        {
            Steps.Add(description);
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in Ingredients)
            {
                double adjustedCalories = ingredient.Calories; // Consider adjusting calories here if needed
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({adjustedCalories} calories) - {ingredient.FoodGroup}");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nTotal Calories: {CalculateTotalCalories()}");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        // Method to scale the recipe by a given factor
        public void ScaleRecipeByFactor(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                // Scale quantity
                ingredient.Quantity *= factor;
                // Scale calories (if needed)
                ingredient.Calories *= factor;
            }
        }

        // Method to reset ingredient quantities (used for reverting scaled recipes)
        public void ResetQuantities(List<Ingredient> originalIngredients)
        {
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].Quantity = originalIngredients[i].Quantity;
                // Reset any other properties as needed
            }
        }

        // Method to calculate total calories of the recipe
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                // Calculate total calories for each ingredient
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        // Method to clone the recipe
        public Recipe Clone()
        {
            Recipe clonedRecipe = new Recipe(this.Name);

            foreach (Ingredient ingredient in this.Ingredients)
            {
                clonedRecipe.AddIngredient(ingredient.Name, ingredient.Quantity, ingredient.Unit, ingredient.Calories, ingredient.FoodGroup);
            }

            foreach (string step in this.Steps)
            {
                clonedRecipe.AddStep(step);
            }

            return clonedRecipe;
        }

        // Method to create a recipe
        public static void CreateRecipe(InputHandler inputHandler, Print print)
        {
            Console.WriteLine(RecipeConstants.RECIPE_CREATION_HEADER);
            Console.WriteLine("==================");

            // Get recipe name
            string recipeName = inputHandler.GetNonEmptyInput(RecipeConstants.RECIPE_NAME_PROMPT, "Recipe name");
            Recipe originalRecipe = new Recipe(recipeName);

            // Get ingredients
            int numIngredients = inputHandler.GetPositiveIntInput(RecipeConstants.NUM_INGREDIENTS_PROMPT);
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine(string.Format(RecipeConstants.INGREDIENT_DETAIL_PROMPT, i + 1));
                string name = inputHandler.GetNonEmptyInput(RecipeConstants.INGREDIENT_NAME_PROMPT, "Ingredient name");
                double quantity = double.Parse(inputHandler.GetNonEmptyInput(RecipeConstants.QUANTITY_PROMPT, "Quantity"));
                string unit = inputHandler.GetNonEmptyInput(RecipeConstants.UNIT_PROMPT, "Unit");
                double calories = double.Parse(inputHandler.GetNonEmptyInput(RecipeConstants.CALORIES_PROMPT, "Calories"));

                // Display food group options
                Console.WriteLine(RecipeConstants.FOOD_GROUP_PROMPT);
                for (int j = 0; j < RecipeConstants.FOOD_GROUPS.Length; j++)
                {
                    Console.WriteLine($"{j + 1}. {RecipeConstants.FOOD_GROUPS[j]}");
                }

                // Get food group input
                int foodGroupOption = inputHandler.GetFoodGroupOption("Enter the food group option:");
                string foodGroup = RecipeConstants.FOOD_GROUPS[foodGroupOption - 1];

                originalRecipe.AddIngredient(name, quantity, unit, calories, foodGroup);
            }

            // Get steps
            int numSteps = inputHandler.GetPositiveIntInput(RecipeConstants.NUM_STEPS_PROMPT);
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine(string.Format(RecipeConstants.STEP_PROMPT, i + 1));
                string description = inputHandler.GetNonEmptyInput("Description:", "Step description");
                originalRecipe.AddStep(description);
            }

            Recipe scaledRecipe = originalRecipe.Clone(); // Create a clone of original recipe to scale

            // Display original recipe details
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nOriginal Recipe created successfully!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            originalRecipe.DisplayRecipe();

            // Check if the original recipe exceeds 300 calories and notify the user
            NotifyIfExceedsCalories(originalRecipe, (totalCalories) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format(RecipeConstants.CALORIES_EXCEED_LIMIT_WARNING, totalCalories));
                Console.ForegroundColor = ConsoleColor.Cyan;
            });

            // Offer save, scale, or reset option
            string saveOrScale;
            do
            {
                saveOrScale = inputHandler.GetNonEmptyInput(RecipeConstants.SAVE_OR_SCALE_PROMPT, "Save or Scale option").ToLower();
                if (saveOrScale != "save" && saveOrScale != "scale")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Please enter either 'save' or 'scale'.");
                }
            } while (saveOrScale != "save" && saveOrScale != "scale");

            if (saveOrScale == "scale")
            {
                ScaleRecipe(scaledRecipe, inputHandler);

                string saveOrRevert;
                do
                {
                    saveOrRevert = inputHandler.GetNonEmptyInput(RecipeConstants.SAVE_OR_REVERT_PROMPT, "Save or Revert option").ToLower();
                    if (saveOrRevert != "save" && saveOrRevert != "revert")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Please enter either 'save' or 'revert'.");
                    }
                } while (saveOrRevert != "save" && saveOrRevert != "revert");

                if (saveOrRevert == "revert")
                {
                    // Revert to original contents
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(string.Format(RecipeConstants.REVERTED_RECIPE_MESSAGE, recipeName));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    originalRecipe.DisplayRecipe();

                    // Save the original recipe
                    print.AddRecipe(originalRecipe);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(string.Format(RecipeConstants.RECIPE_SAVED_MESSAGE, recipeName));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    // Save the scaled recipe
                    print.AddRecipe(scaledRecipe);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(string.Format(RecipeConstants.SCALED_RECIPE_SAVED_MESSAGE, recipeName));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            else
            {
                // Save the original recipe
                print.AddRecipe(originalRecipe);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Format(RecipeConstants.RECIPE_SAVED_MESSAGE, recipeName));
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            // Returning to the menu
            Console.WriteLine("\nReturning to the main menu...");
        }

        // Method to notify if recipe exceeds calories limit
        private static void NotifyIfExceedsCalories(Recipe recipe, Action<double> notificationHandler)
        {
            double totalCalories = recipe.CalculateTotalCalories();
            if (totalCalories > 300)
            {
                notificationHandler?.Invoke(totalCalories);
            }
        }

        // Method to view recipes
        public static void ViewRecipes(InputHandler inputHandler, Print print)
        {
            bool returnToMenu = true;

            while (returnToMenu)
            {
                print.recipes.Sort((x, y) => string.Compare(x.Name, y.Name));
                print.DisplayRecipeList();

                string recipeName = inputHandler.GetNonEmptyInput(RecipeConstants.VIEW_RECIPES_PROMPT, "Display option");

                if (recipeName.ToLower() == "back")
                {
                    returnToMenu = false;
                }
                else
                {
                    Recipe recipe = print.GetRecipe(recipeName);
                    if (recipe != null)
                    {
                        print.DisplayRecipeDetails(recipeName);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(string.Format(RecipeConstants.RECIPE_NOT_FOUND_MESSAGE, recipeName));
                    }
                }
            }
        }

        // Method to delete a recipe
        public static void DeleteRecipe(InputHandler inputHandler, Print print)
        {
            bool returnToMenu = true;

            while (returnToMenu)
            {
                print.recipes.Sort((x, y) => string.Compare(x.Name, y.Name));
                print.DisplayRecipeList();

                string recipeName = inputHandler.GetNonEmptyInput(RecipeConstants.DELETE_RECIPE_PROMPT, "Delete option");

                if (recipeName.ToLower() == "back")
                {
                    returnToMenu = false;
                }
                else
                {
                    Recipe recipeToDelete = print.GetRecipe(recipeName);
                    if (recipeToDelete != null)
                    {
                        print.DeleteRecipe(recipeName);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(string.Format(RecipeConstants.RECIPE_DELETED_MESSAGE, recipeName));
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(string.Format(RecipeConstants.RECIPE_NOT_FOUND_MESSAGE, recipeName));
                    }
                }
            }
        }

        // Method to scale a recipe
        public static void ScaleRecipe(Recipe recipe, InputHandler inputHandler)
        {
            Console.WriteLine(RecipeConstants.SCALE_RECIPE_HEADER);
            Console.WriteLine("==================");

            double factor;
            do
            {
                factor = inputHandler.GetPositiveDoubleInput(RecipeConstants.SCALING_FACTOR_PROMPT);
                if (factor != 0.5 && factor != 2 && factor != 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Scaling factor must be 0.5, 2, or 3.");
                }
            } while (factor != 0.5 && factor != 2 && factor != 3);

            // Make a copy of the original recipe
            Recipe originalRecipe = new Recipe(recipe.Name);
            foreach (var ingredient in recipe.Ingredients)
            {
                originalRecipe.AddIngredient(ingredient.Name, ingredient.Quantity, ingredient.Unit, ingredient.Calories, ingredient.FoodGroup);
            }
            originalRecipe.Steps.AddRange(recipe.Steps);

            // Scale the recipe
            recipe.ScaleRecipeByFactor(factor);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(RecipeConstants.RECIPE_SCALED_MESSAGE);

            // Display the scaled recipe
            Console.WriteLine(RecipeConstants.SCALED_RECIPE_HEADER);
            recipe.DisplayRecipe();

        }

        // Method to filter recipes
        public static void FilterRecipe(Print print, InputHandler inputHandler)
        {
            Console.WriteLine("\nFilter Recipes:");
            Console.WriteLine("==================");

            // Prompt user to choose a filtering option
            Console.WriteLine("Choose a filtering option:");
            Console.WriteLine("a. Filter by ingredient name");
            Console.WriteLine("b. Filter by food group");
            Console.WriteLine("c. Filter by maximum calories");
            string filterOption = inputHandler.GetNonEmptyInput("Enter your choice (a/b/c): ", "Filtering option");

            switch (filterOption.ToLower())
            {
                case "a":
                    // Filter by ingredient name
                    string ingredientName = inputHandler.GetNonEmptyInput("Enter the name of the ingredient: ", "Ingredient name");
                    printFilteredRecipes(print, r => r.Ingredients.Any(i => i.Name.ToLower() == ingredientName.ToLower()));
                    break;
                case "b":
                    // Display food groups
                    Console.WriteLine("Food Groups:");
                    for (int i = 0; i < RecipeConstants.FOOD_GROUPS.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {RecipeConstants.FOOD_GROUPS[i]}");
                    }
                    // Filter by food group
                    int foodGroupOption = inputHandler.GetFoodGroupOption("Choose a food group:");
                    string foodGroup = RecipeConstants.FOOD_GROUPS[foodGroupOption - 1];
                    printFilteredRecipes(print, r => r.Ingredients.Any(i => i.FoodGroup.ToLower() == foodGroup.ToLower()));
                    break;
                case "c":
                    // Filter by maximum calories
                    double maxCalories = inputHandler.GetPositiveDoubleInput("Enter the maximum number of calories: ");
                    printFilteredRecipes(print, r => r.CalculateTotalCalories() <= maxCalories);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Invalid filtering option.");
                    break;
            }
        }

        // Helper method to print filtered recipes
        private static void printFilteredRecipes(Print print, Func<Recipe, bool> filterFunc)
        {
            List<Recipe> filteredRecipes = print.recipes.Where(filterFunc).ToList();
            if (filteredRecipes.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nFiltered Recipes:");
                foreach (Recipe recipe in filteredRecipes)
                {
                    Console.WriteLine(recipe.Name);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes found matching the criteria.");
            }
        }

    }
}

