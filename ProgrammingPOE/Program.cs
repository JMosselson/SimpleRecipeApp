using System;
using ProgrammingPOE.ExceptionHandling;
using ProgrammingPOE.Model;
using ProgrammingPOE.Util;

namespace ProgrammingPOE
{
    class Program
    {
        // Main method
        static void Main(string[] args)
        {
            // Initialize objects
            Print print = new Print();
            InputHandler inputHandler = new InputHandler();
            bool continueApplication = true;

            // Application loop
            while (continueApplication)
            {
                // Display menu
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(RecipeConstants.MENU_WELCOME);
                Console.WriteLine(RecipeConstants.MENU_OPTIONS);

                // Get user input for menu option
                string option = inputHandler.GetNonEmptyInput(RecipeConstants.MENU_SELECT_OPTION, "Menu option");

                // Process user input
                switch (option)
                {
                    case "1":
                        Recipe.CreateRecipe(inputHandler, print);
                        break;
                    case "2":
                        Recipe.ViewRecipes(inputHandler, print);
                        break;
                    case "3":
                        Recipe.DeleteRecipe(inputHandler, print);
                        break;
                    case "4":
                        Recipe.FilterRecipe(print, inputHandler);
                        break;
                    case "5":
                        continueApplication = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(RecipeConstants.MENU_INVALID_OPTION);
                        break;
                        
                }
            }
        }
    }
}
