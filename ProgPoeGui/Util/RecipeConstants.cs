using System;

namespace ProgPoeGui.Util
{
    public static class RecipeConstants
    {
        // Menu options
        public const string MENU_WELCOME = "\nWelcome to the Recipe App!";
        public const string MENU_OPTIONS = "\n===========================\n1) Create a recipe\n2) View recipes\n3) Delete a recipe\n4) Filter Recipe \n5) Quit";
        public const string MENU_SELECT_OPTION = "\nSelect number 1, 2, 3, 4 or 5:";
        public const string MENU_INVALID_OPTION = "Error: Invalid option. Please select a valid option.";

        // Ingredient food groups
        public static readonly string[] FOOD_GROUPS =
        {
            "Starchy foods",
            "Vegetables and fruits",
            "Dry beans, peas, lentils and soya",
            "Chicken, fish, meat and eggs",
            "Milk and dairy products",
            "Fats and oil",
            "Water"
        };
        public const string FOOD_GROUP_PROMPT = "Select Food Group:";
        public const string FOOD_GROUP_OPTION_ERROR = "Error: Please enter a valid food group option (1-7).";

        // Recipe creation
        public const string RECIPE_CREATION_HEADER = "\nCreating a Recipe:";
        public const string RECIPE_NAME_PROMPT = "Enter the name of the recipe:";
        public const string NUM_INGREDIENTS_PROMPT = "\nEnter the number of ingredients:";
        public const string INGREDIENT_DETAIL_PROMPT = "\nEnter details for ingredient {0}:";
        public const string INGREDIENT_NAME_PROMPT = "Ingredient Name:";
        public const string QUANTITY_PROMPT = "Quantity (Units Come After):";
        public const string UNIT_PROMPT = "Unit (EG: ml, l, mg, g, kg:";
        public const string CALORIES_PROMPT = "Calories:";
        public const string NUM_STEPS_PROMPT = "\nEnter the number of steps:";
        public const string STEP_PROMPT = "\nEnter step {0}:";
        public const string SAVE_OR_SCALE_PROMPT = "\nDo you want to save or scale the recipe? (Type 'save' or 'scale')";
        public const string SAVE_OR_REVERT_PROMPT = "\nDo you want to save or revert the scaled recipe? (save/revert)";
        public const string RECIPE_SAVED_MESSAGE = "\nOriginal Recipe '{0}' saved successfully!";
        public const string SCALED_RECIPE_SAVED_MESSAGE = "\nScaled Recipe '{0}' saved successfully!";
        public const string REVERTED_RECIPE_MESSAGE = "\nScaled recipe '{0}' reverted successfully!";

        // Recipe viewing and deletion
        public const string VIEW_RECIPES_PROMPT = "\nEnter the name of the recipe to display, or type 'Menu' for the menu:";
        public const string DELETE_RECIPE_PROMPT = "\nEnter the name of the recipe to delete, or type 'Menu' for the menu:";

        // Scaling recipe
        public const string SCALING_FACTOR_PROMPT = "Enter scaling factor (0,5 for half, 2 for double, 3 for triple):";
        public const string RECIPE_SCALED_MESSAGE = "\nRecipe scaled successfully!";

        // Warning message
        public const string CALORIES_EXCEED_LIMIT_WARNING = "\nWarning: This recipe contains {0} calories, which exceeds 300 calories.";

        // Error messages
        public const string POSITIVE_INTEGER_ERROR = "Error: Please enter a positive integer.";
        public const string POSITIVE_NUMBER_ERROR = "Error: Please enter a positive number.";

        // Header messages
        public const string RECIPE_DELETED_MESSAGE = "Recipe '{0}' deleted successfully!";
        public const string RECIPE_NOT_FOUND_MESSAGE = "Error: Recipe '{0}' not found.";

        // Other constants
        public const string SCALE_RECIPE_HEADER = "\nScale Recipe:";
        public const string SCALED_RECIPE_HEADER = "\nScaled Recipe:";

        // New constants
        public const string FILTER_OPTION_PROMPT = "Choose an option to filter recipes:\na. Filter by ingredient name\nb. Filter by food group\nc. Filter by maximum calories\nEnter your choice (a/b/c), or type 'Menu' for the menu: ";
        public const string FOOD_GROUPS_HEADER = "Food Groups:\n";
        public const string CHOOSE_FOOD_GROUP_PROMPT = "Enter the food group option:";
        public const string MAX_CALORIES_PROMPT = "Enter the maximum calories:";
        public const string RECIPE_SCALED_TITLE = "Recipe Scaled";
        public const string EXACT_CALORIES_PROMPT = "Enter the Number of Calories";
    }
}
