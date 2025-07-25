using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ProgPoeGui.ExceptionHandling;
using ProgPoeGui.Util;

namespace ProgPoeGui.Model
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
            string ingredientsText = "\nIngredients:\n";
            foreach (var ingredient in Ingredients)
            {
                double adjustedCalories = ingredient.Calories; // Consider adjusting calories here if needed
                ingredientsText += $"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({adjustedCalories} calories) - {ingredient.FoodGroup}\n";
            }

            string stepsText = "\nSteps:\n";
            for (int i = 0; i < Steps.Count; i++)
            {
                stepsText += $"{i + 1}. {Steps[i]}\n";
            }

            double totalCalories = CalculateTotalCalories();

            string recipeText = $"\nRecipe: {Name}\n{ingredientsText}{stepsText}\nTotal Calories: {totalCalories}";

            OutputDialog.ShowDialog(recipeText, "Recipe Details");
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

            // Display the scaled recipe
            DisplayRecipe();
        }



        // Method to reset ingredient quantities (used for reverting scaled recipes)
        public void ResetQuantities(List<Ingredient> originalIngredients)
        {
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].Quantity = originalIngredients[i].Quantity;
                // Reset any other properties as needed
            }

            OutputDialog.ShowDialog("Ingredient quantities reset successfully.", "Quantities Reset");
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
            try
            {
                while (true)
                {
                    OutputDialog.ShowDialog(RecipeConstants.RECIPE_CREATION_HEADER, "Recipe Creation");

                    // Get recipe name
                    string recipeName;
                    do
                    {
                        recipeName = InputDialog.ShowDialog("Please enter the recipe name:", "Recipe Name");
                        if (string.IsNullOrWhiteSpace(recipeName))
                        {
                            OutputDialog.ShowDialog("Error: Recipe name cannot be empty.", "Input Error");
                        }
                    } while (string.IsNullOrWhiteSpace(recipeName));

                    Recipe originalRecipe = new Recipe(recipeName);

                    // Get ingredients
                    int numIngredients;
                    do
                    {
                        numIngredients = inputHandler.GetPositiveIntInput(RecipeConstants.NUM_INGREDIENTS_PROMPT);
                        if (numIngredients <= 0)
                        {
                            OutputDialog.ShowDialog("Error: Number of ingredients must be a positive integer.", "Input Error");
                        }
                    } while (numIngredients <= 0);

                    for (int i = 0; i < numIngredients; i++)
                    {
                        OutputDialog.ShowDialog(string.Format(RecipeConstants.INGREDIENT_DETAIL_PROMPT, i + 1), "Ingredient Detail");

                        string name;
                        do
                        {
                            name = InputDialog.ShowDialog(RecipeConstants.INGREDIENT_NAME_PROMPT, "Ingredient Name");
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                OutputDialog.ShowDialog("Error: Ingredient name cannot be empty.", "Input Error");
                            }
                        } while (string.IsNullOrWhiteSpace(name));

                        double quantity;
                        do
                        {
                            string quantityInput = InputDialog.ShowDialog(RecipeConstants.QUANTITY_PROMPT, "Quantity (Units Come After)");
                            if (!double.TryParse(quantityInput, out quantity) || quantity <= 0)
                            {
                                OutputDialog.ShowDialog("Error: Quantity must be a positive number.", "Input Error");
                            }
                        } while (quantity <= 0);

                        string unit;
                        do
                        {
                            unit = InputDialog.ShowDialog(RecipeConstants.UNIT_PROMPT, "Unit");
                            if (string.IsNullOrWhiteSpace(unit))
                            {
                                OutputDialog.ShowDialog("Error: Unit cannot be empty.", "Input Error");
                            }
                        } while (string.IsNullOrWhiteSpace(unit));

                        double calories;
                        bool validCalories;
                        do
                        {
                            string caloriesInput = InputDialog.ShowDialog(RecipeConstants.CALORIES_PROMPT, "Calories");
                            validCalories = double.TryParse(caloriesInput, out calories) && calories >= 0;
                            if (!validCalories)
                            {
                                OutputDialog.ShowDialog("Error: Calories must be a non-negative number.", "Input Error");
                            }
                        } while (!validCalories);

                        // Display food group options
                        string foodGroupOptions = $"{RecipeConstants.FOOD_GROUP_PROMPT}\n";
                        for (int j = 0; j < RecipeConstants.FOOD_GROUPS.Length; j++)
                        {
                            foodGroupOptions += $"{j + 1}. {RecipeConstants.FOOD_GROUPS[j]}\n";
                        }
                        OutputDialog.ShowDialog(foodGroupOptions, "Food Group Options");

                        // Get food group input
                        int foodGroupOption;
                        do
                        {
                            foodGroupOption = inputHandler.GetFoodGroupOption("Enter the food group option:");
                            if (foodGroupOption < 1 || foodGroupOption > RecipeConstants.FOOD_GROUPS.Length)
                            {
                                OutputDialog.ShowDialog("Error: Invalid food group option.", "Input Error");
                            }
                        } while (foodGroupOption < 1 || foodGroupOption > RecipeConstants.FOOD_GROUPS.Length);

                        string foodGroup = RecipeConstants.FOOD_GROUPS[foodGroupOption - 1];
                        originalRecipe.AddIngredient(name, quantity, unit, calories, foodGroup);
                    }

                    // Get steps
                    int numSteps;
                    do
                    {
                        numSteps = inputHandler.GetPositiveIntInput(RecipeConstants.NUM_STEPS_PROMPT);
                        if (numSteps <= 0)
                        {
                            OutputDialog.ShowDialog("Error: Number of steps must be a positive integer.", "Input Error");
                        }
                    } while (numSteps <= 0);

                    for (int i = 0; i < numSteps; i++)
                    {
                        OutputDialog.ShowDialog(string.Format(RecipeConstants.STEP_PROMPT, i + 1), "Step Detail");
                        string description;
                        do
                        {
                            description = InputDialog.ShowDialog("Please enter the step description:", "Step Description");
                            if (string.IsNullOrWhiteSpace(description))
                            {
                                OutputDialog.ShowDialog("Error: Step description cannot be empty.", "Input Error");
                            }
                        } while (string.IsNullOrWhiteSpace(description));

                        originalRecipe.AddStep(description);
                    }

                    Recipe scaledRecipe = originalRecipe.Clone(); // Create a clone of the original recipe to scale

                    // Display original recipe details
                    OutputDialog.ShowDialog("\nOriginal Recipe created successfully!", "Recipe Creation Success");
                    originalRecipe.DisplayRecipe();

                    // Check if the original recipe exceeds 300 calories and notify the user
                    NotifyIfExceedsCalories(originalRecipe, (totalCalories) =>
                    {
                        OutputDialog.ShowDialog(string.Format(RecipeConstants.CALORIES_EXCEED_LIMIT_WARNING, totalCalories), "Calories Warning");
                    });

                    // Offer save, scale, or reset option
                    string saveOrScale;
                    do
                    {
                        saveOrScale = InputDialog.ShowDialog(RecipeConstants.SAVE_OR_SCALE_PROMPT, "Save or Scale Option").ToLower();
                        if (saveOrScale != "save" && saveOrScale != "scale")
                        {
                            OutputDialog.ShowDialog("Error: Please enter either 'save' or 'scale'.", "Input Error");
                        }
                    } while (saveOrScale != "save" && saveOrScale != "scale");

                    if (saveOrScale == "scale")
                    {
                        ScaleRecipe(scaledRecipe, inputHandler);

                        string saveOrRevert;
                        do
                        {
                            saveOrRevert = InputDialog.ShowDialog(RecipeConstants.SAVE_OR_REVERT_PROMPT, "Save or Revert Option").ToLower();
                            if (saveOrRevert != "save" && saveOrRevert != "revert")
                            {
                                OutputDialog.ShowDialog("Error: Please enter either 'save' or 'revert'.", "Input Error");
                            }
                        } while (saveOrRevert != "save" && saveOrRevert != "revert");

                        if (saveOrRevert == "revert")
                        {
                            // Revert to original contents
                            OutputDialog.ShowDialog(string.Format(RecipeConstants.REVERTED_RECIPE_MESSAGE, recipeName), "Recipe Reverted");
                            originalRecipe.DisplayRecipe();

                            // Save the original recipe
                            print.AddRecipe(originalRecipe);
                            OutputDialog.ShowDialog(string.Format(RecipeConstants.RECIPE_SAVED_MESSAGE, recipeName), "Recipe Saved");
                        }
                        else
                        {
                            // Save the scaled recipe
                            print.AddRecipe(scaledRecipe);
                            OutputDialog.ShowDialog(string.Format(RecipeConstants.SCALED_RECIPE_SAVED_MESSAGE, recipeName), "Scaled Recipe Saved");
                        }
                    }
                    else
                    {
                        // Save the original recipe
                        print.AddRecipe(originalRecipe);
                        OutputDialog.ShowDialog(string.Format(RecipeConstants.RECIPE_SAVED_MESSAGE, recipeName), "Recipe Saved");
                    }

                    // Ask if the user wants to create another recipe
                    string createAnother;
                    do
                    {
                        createAnother = InputDialog.ShowDialog("Do you want to create another recipe? (yes/no):", "Create Another").ToLower();
                        if (createAnother != "yes" && createAnother != "no")
                        {
                            OutputDialog.ShowDialog("Error: Please enter 'yes' or 'no'.", "Input Error");
                        }
                    } while (createAnother != "yes" && createAnother != "no");

                    if (createAnother == "no")
                    {
                        // Returning to the menu
                        OutputDialog.ShowDialog("\nReturning to the main menu...", "Main Menu");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                OutputDialog.ShowDialog($"An unexpected error occurred: {ex.Message}", "Error");
            }
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
            while (true) // Continue indefinitely until explicitly exited
            {
                try
                {
                    // Sort recipes alphabetically by name
                    print.recipes.Sort((x, y) => string.Compare(x.Name, y.Name));
                    print.DisplayRecipeList();

                    // Prompt user for the name of the recipe to view
                    string recipeName = InputDialog.ShowDialog(RecipeConstants.VIEW_RECIPES_PROMPT, "Display option");

                    // Check if the input dialog was closed or the input was empty
                    if (string.IsNullOrEmpty(recipeName))
                    {
                        break; // Exit the loop to return to the original options
                    }

                    // Check if the user wants to go back to the menu
                    if (recipeName.Equals("menu", StringComparison.OrdinalIgnoreCase))
                    {
                        break; // Exit the loop to return to the original options
                    }

                    // Attempt to view the recipe entered
                    Recipe recipe = print.GetRecipe(recipeName);
                    if (recipe != null)
                    {
                        print.DisplayRecipeDetails(recipeName);
                    }
                    else
                    {
                        OutputDialog.ShowDialog(string.Format(RecipeConstants.RECIPE_NOT_FOUND_MESSAGE, recipeName), "Recipe Not Found");
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (assuming there's a logging mechanism)
                    // Logger.LogError("An error occurred while viewing the recipe.", ex);

                    // Show an error message to the user
                    OutputDialog.ShowDialog("An unexpected error occurred. Please try again.", "Error");
                }
            }
        }


        // Method to delete a recipe
        public static void DeleteRecipe(InputHandler inputHandler, Print print)
        {
            while (true) // Continue indefinitely until explicitly exited
            {
                try
                {
                    // Sort recipes alphabetically by name
                    print.recipes.Sort((x, y) => string.Compare(x.Name, y.Name));
                    print.DisplayRecipeList();

                    // Prompt user for the name of the recipe to delete
                    string recipeName = InputDialog.ShowDialog(RecipeConstants.DELETE_RECIPE_PROMPT, "Delete option");

                    // Check if the input dialog was closed or the input was empty
                    if (string.IsNullOrEmpty(recipeName))
                    {
                        break; // Exit the loop to return to the original options
                    }

                    // Check if the user wants to go back to the menu
                    if (recipeName.Equals("menu", StringComparison.OrdinalIgnoreCase))
                    {
                        break; // Exit the loop to return to the original options
                    }

                    // Attempt to delete the recipe entered
                    Recipe recipeToDelete = print.GetRecipe(recipeName);
                    if (recipeToDelete != null)
                    {
                        print.DeleteRecipe(recipeName);
                        OutputDialog.ShowDialog(string.Format(RecipeConstants.RECIPE_DELETED_MESSAGE, recipeName), "Recipe Deleted");
                    }
                    else
                    {
                        OutputDialog.ShowDialog(string.Format(RecipeConstants.RECIPE_NOT_FOUND_MESSAGE, recipeName), "Recipe Not Found");
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (assuming there's a logging mechanism)
                    // Logger.LogError("An error occurred while deleting the recipe.", ex);

                    // Show an error message to the user
                    OutputDialog.ShowDialog("An unexpected error occurred. Please try again.", "Error");
                }
            }
        }




        // Method to scale a recipe
        public static void ScaleRecipe(Recipe recipe, InputHandler inputHandler)
        {
            double factor;
            do
            {
                factor = Convert.ToDouble(InputDialog.ShowDialog(RecipeConstants.SCALING_FACTOR_PROMPT, "Scaling Factor"));
                if (factor != 0.5 && factor != 2 && factor != 3)
                {
                    OutputDialog.ShowDialog("Error: Scaling factor must be 0.5, 2, or 3.", "Error");
                }
            } while (factor != 0.5 && factor != 2 && factor != 3);

            // Scale the recipe
            recipe.ScaleRecipeByFactor(factor);

        }

        // Method to filter a recipe
        public static void FilterRecipe(Print print, InputHandler inputHandler)
        {
            while (true) // Continue indefinitely until explicitly exited
            {
                try
                {
                    string filterOption = InputDialog.ShowDialog(RecipeConstants.FILTER_OPTION_PROMPT, "Filtering Option");

                    // Check if the input dialog was closed or the input was empty
                    if (string.IsNullOrEmpty(filterOption))
                    {
                        break; // Exit the loop to return to the original options
                    }

                    // Check if the user wants to go back to the menu
                    if (filterOption.Equals("menu", StringComparison.OrdinalIgnoreCase))
                    {
                        break; // Exit the loop to return to the original options
                    }

                    if (!string.IsNullOrWhiteSpace(filterOption))
                    {
                        filterOption = filterOption.ToLower();
                        string output = "\nFilter Recipes:";

                        switch (filterOption)
                        {
                            case "a":
                                string ingredientName = InputDialog.ShowDialog(RecipeConstants.INGREDIENT_NAME_PROMPT, "Ingredient Name");

                                // Check if the input dialog was closed or the input was empty
                                if (string.IsNullOrEmpty(ingredientName))
                                {
                                    break; // Exit the loop to return to the original options
                                }

                                // Check if the user wants to go back to the menu
                                if (ingredientName.Equals("menu", StringComparison.OrdinalIgnoreCase))
                                {
                                    break; // Exit the loop to return to the original options
                                }

                                if (!string.IsNullOrWhiteSpace(ingredientName))
                                {
                                    output += PrintFilteredRecipes(print, r => r.Ingredients.Any(i => i.Name.ToLower() == ingredientName.ToLower()));
                                }
                                else
                                {
                                    OutputDialog.ShowDialog("Error: No ingredient matching criteria.", "Error");
                                    continue;
                                }
                                break;
                            case "b":
                                output += RecipeConstants.FOOD_GROUPS_HEADER;
                                for (int i = 0; i < RecipeConstants.FOOD_GROUPS.Length; i++)
                                {
                                    output += $"{i + 1}. {RecipeConstants.FOOD_GROUPS[i]}\n";
                                }
                                int foodGroupOption;
                                string foodGroupOptionInput = InputDialog.ShowDialog(RecipeConstants.CHOOSE_FOOD_GROUP_PROMPT, "Food Group");

                                // Check if the input dialog was closed or the input was empty
                                if (string.IsNullOrEmpty(foodGroupOptionInput))
                                {
                                    break; // Exit the loop to return to the original options
                                }

                                // Check if the user wants to go back to the menu
                                if (foodGroupOptionInput.Equals("menu", StringComparison.OrdinalIgnoreCase))
                                {
                                    break; // Exit the loop to return to the original options
                                }

                                if (int.TryParse(foodGroupOptionInput, out foodGroupOption) && foodGroupOption > 0 && foodGroupOption <= RecipeConstants.FOOD_GROUPS.Length)
                                {
                                    string foodGroup = RecipeConstants.FOOD_GROUPS[foodGroupOption - 1];
                                    output += PrintFilteredRecipes(print, r => r.Ingredients.Any(i => i.FoodGroup.ToLower() == foodGroup.ToLower()));
                                }
                                else
                                {
                                    OutputDialog.ShowDialog("Error: Invalid food group option.", "Error");
                                    continue;
                                }
                                break;
                            case "c":
                                double exactCalories;
                                string exactCaloriesInput = InputDialog.ShowDialog(RecipeConstants.EXACT_CALORIES_PROMPT, "Exact Calories");

                                // Check if the input dialog was closed or the input was empty
                                if (string.IsNullOrEmpty(exactCaloriesInput))
                                {
                                    break; // Exit the loop to return to the original options
                                }

                                // Check if the user wants to go back to the menu
                                if (exactCaloriesInput.Equals("menu", StringComparison.OrdinalIgnoreCase))
                                {
                                    break; // Exit the loop to return to the original options
                                }

                                if (!string.IsNullOrWhiteSpace(exactCaloriesInput) && double.TryParse(exactCaloriesInput, out exactCalories))
                                {
                                    output += PrintFilteredRecipes(print, r => r.CalculateTotalCalories() == exactCalories);
                                }
                                else
                                {
                                    OutputDialog.ShowDialog("Error: Invalid input for exact calories.", "Error");
                                    continue;
                                }
                                break;
                            default:
                                OutputDialog.ShowDialog("Error: Invalid filtering option.", "Error");
                                continue;
                        }

                        OutputDialog.ShowDialog(output, "Filtered Recipes");
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (assuming there's a logging mechanism)
                    // Logger.LogError("An error occurred while filtering recipes.", ex);

                    // Show an error message to the user
                    OutputDialog.ShowDialog("An unexpected error occurred. Please try again.", "Error");
                }
            }
        }

        // Helper method to print filtered recipes
        private static string PrintFilteredRecipes(Print print, Func<Recipe, bool> filterFunc)
        {
            List<Recipe> filteredRecipes = print.recipes.Where(filterFunc).ToList();
            if (filteredRecipes.Count > 0)
            {
                string result = "\nFiltered Recipes:\n";
                foreach (Recipe recipe in filteredRecipes)
                {
                    result += recipe.Name + "\n";
                }
                return result;
            }
            else
            {
                OutputDialog.ShowDialog("No recipes found matching the criteria.", "Filtered Recipes");
                return string.Empty;
            }
        }
    }
}

