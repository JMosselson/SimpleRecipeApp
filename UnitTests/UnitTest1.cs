using ProgrammingPOE.Model;

namespace UnitTests
{
    public class RecipeTests
    {
        [Fact]
        public void CalculateTotalCalories_Returns_CorrectTotal()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.AddIngredient("Ingredient 1", 100, "grams", 50, "Food Group 1");
            recipe.AddIngredient("Ingredient 2", 200, "ml", 75, "Food Group 2");
            recipe.AddIngredient("Ingredient 3", 150, "grams", 60, "Food Group 3");

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.Equal(185, totalCalories); // 50 + 75 + 60 = 185
        }
    }
}
