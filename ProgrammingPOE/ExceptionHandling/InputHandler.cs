using ProgrammingPOE.Util;
using System;

namespace ProgrammingPOE.ExceptionHandling
{
    public class InputHandler
    {
        // Method to get a non-empty string input from the user
        public string GetNonEmptyInput(string prompt, string fieldName)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{fieldName} cannot be empty!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
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
                Console.Write(prompt);
                validInput = int.TryParse(Console.ReadLine(), out value) && value > 0;
                if (!validInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid positive integer.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
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
                Console.Write(prompt);
                validInput = double.TryParse(Console.ReadLine(), out value) && value > 0;
                if (!validInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid positive number.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
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
                Console.Write(prompt);
                validInput = int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= RecipeConstants.FOOD_GROUPS.Length;
                if (!validInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid option.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            } while (!validInput);
            return option;
        }
    }
}
