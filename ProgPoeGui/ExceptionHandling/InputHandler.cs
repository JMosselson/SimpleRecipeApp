using ProgPoeGui.Util;
using System;
using System.Windows;

namespace ProgPoeGui.ExceptionHandling
{
    public class InputHandler
    {
        // Method to get a non-empty string input from the user
        public string GetNonEmptyInput(string prompt, string fieldName)
        {
            string input;
            do
            {
                input = InputDialog.ShowDialog(prompt, fieldName);
                if (string.IsNullOrWhiteSpace(input))
                {
                    OutputDialog.ShowDialog($"{fieldName} cannot be empty!", "Error");
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        // Method to get a positive integer input from the user
        public int GetPositiveIntInput(string prompt)
        {
            int value;
            bool validInput;
            do
            {
                string input = InputDialog.ShowDialog(prompt, "Positive Integer");
                validInput = int.TryParse(input, out value) && value > 0;
                if (!validInput)
                {
                    OutputDialog.ShowDialog("Please enter a valid positive integer.", "Error");
                }
            } while (!validInput);
            return value;
        }

        // Method to get a positive double input from the user
        public double GetPositiveDoubleInput(string prompt)
        {
            double value;
            bool validInput;
            do
            {
                string input = InputDialog.ShowDialog(prompt, "Positive Double");
                validInput = double.TryParse(input, out value) && value > 0;
                if (!validInput)
                {
                    OutputDialog.ShowDialog("Please enter a valid positive number.", "Error");
                }
            } while (!validInput);
            return value;
        }

        // Method to get a food group option from the user
        public int GetFoodGroupOption(string prompt)
        {
            int option;
            bool validInput;
            do
            {
                string input = InputDialog.ShowDialog(prompt, "Food Group Option");
                validInput = int.TryParse(input, out option) && option >= 1 && option <= RecipeConstants.FOOD_GROUPS.Length;
                if (!validInput)
                {
                    OutputDialog.ShowDialog("Please enter a valid option.", "Error");
                }
            } while (!validInput);
            return option;
        }
    }
}
