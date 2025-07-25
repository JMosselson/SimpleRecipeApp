using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using ProgPoeGui.Model;
using ProgPoeGui.Util;
using ProgPoeGui.ExceptionHandling;

namespace ProgPoeGui
{
    public partial class MainWindow : Window
    {
        public Print print;
        public InputHandler inputHandler;

        public MainWindow()
        {
            InitializeComponent();
            print = new Print();
            inputHandler = new InputHandler();
            this.WindowState = WindowState.Maximized;
        }

        // Event handler for creating a recipe  
        public void CreateRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe.CreateRecipe(inputHandler, print);            
        }

        // Event handler for viewing recipes
        public void ViewRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe.ViewRecipes(inputHandler, print);
        }

        // Event handler for deleting a recipe
        public void DeleteRecipeButton_Click(object sender, RoutedEventArgs e)
        {           
          Recipe.DeleteRecipe(inputHandler, print);
        }

        // Event handler for filtering recipes
        public void FilterRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe.FilterRecipe(print, inputHandler);
        }

        // Event handler for quitting the application
        public void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
