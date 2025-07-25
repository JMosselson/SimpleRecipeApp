------------------------

# Recipe App

## Introduction

Welcome to the Recipe App! This application allows you to create and manage recipes easily. With this app, you can input your recipe details, scale them according to your needs, and manage your recipes effortlessly.

## Running the App

To run the Recipe App:
1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Build the project.
4. Run the application.

## Features

- User-Friendly Interface: Provides a simple and intuitive interface for entering and managing recipes.
- Flexible Scaling: Easily scale recipes by factors such as 0.5, 2, or 3 to adjust serving sizes.
- Error Handling: Includes mechanisms to ensure valid user inputs throughout the application.
- Efficient Recipe Management: Manage multiple recipes efficiently with clear organization and options to clear data and start over.

## Code Overview

This code is a GUI application written in C# for a Recipe App. Let's break down how it works:

### 1. Print Class

Purpose: Manages the display and storage of recipes.

Methods:
- AddRecipe: Adds a new recipe to the list.
- DeleteRecipe: Deletes a recipe from the list.
- DisplayAllRecipes: Displays all recipes currently stored.
- DisplayRecipeDetails: Displays detailed information for a specific recipe.

### 2. Recipe Class

Purpose: Represents a recipe.

Properties:
- Name: Name of the recipe.
- Ingredients: List of Ingredient objects.
- Steps: List of step descriptions.

Methods:
- AddIngredient: Adds an ingredient to the recipe.
- AddStep: Adds a step to the recipe.
- DisplayRecipe: Displays the recipe details.
- ScaleRecipeByFactor: Scales the recipe by a given factor.
- ResetQuantities: Resets ingredient quantities.
- Clone: Creates a copy of the recipe object.
- CalculateTotalCalories: Calculates the total calories of the recipe.
- FilterRecipes: Filters recipes by various criteria (ingredient name, food group, maximum calories).

### 3. Ingredient Class

Purpose: Represents an ingredient with name, quantity, and unit properties.

Properties:
- Name: Name of the ingredient.
- Quantity: Quantity of the ingredient.
- Unit: Unit of measurement for the ingredient.
- Calories: Calories per quantity of the ingredient.
- FoodGroup: Food group of the ingredient.

### 4. InputHandler Class

Purpose: Handles user input validation.

Methods:
- GetStringInput: Prompts the user for a non-empty string input.
- GetIntInput: Prompts the user for a positive integer input.
- GetDoubleInput: Prompts the user for a positive double input.
- GetFoodGroup: Prompts the user to select a food group from a predefined list.

### 5. GUI Windows

- MainWindow: Main window of the application providing users with options to manage recipes.
- InputDialog: Dialog window for inputting recipe details.
- OutputDialog: Dialog window for displaying recipe details or notifications.


## Conclusion
The Recipe App provides a robust solution for managing recipes with efficiency and ease. Whether you're creating new recipes, scaling existing ones, or organizing your culinary creations, our application simplifies the process through an intuitive interface and comprehensive feature set.

By Jordan Mosselson

------------------------
