using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10318621_PROG_POE.Classes
{
    class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe()
        {
            Recipe recipe = new Recipe();
            recipe.EnterRecipeDetails();
            recipes.Add(recipe);
            AskToScaleOrClearRecipe(recipe);
        }

        public void ListRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();

            Console.WriteLine("Recipes:");
            for (int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");
            }

            Console.WriteLine("Enter the number of the recipe you want to view:");

            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= sortedRecipes.Count)
            {
                sortedRecipes[index - 1].DisplayRecipe();
                AskToScaleOrClearRecipe(sortedRecipes[index - 1]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input.");
                Console.ResetColor();
            }
        }

        private void AskToScaleOrClearRecipe(Recipe recipe)
        {
            Console.WriteLine("Do you want to scale the recipe? (yes/no)");
            string scaleChoice = Console.ReadLine().ToLower();

            if (scaleChoice == "yes")
            {
                Console.WriteLine("Enter scale factor (0.5 for half, 2 for double, 3 for triple):");
                if (double.TryParse(Console.ReadLine(), out double factor) && (factor == 0.5 || factor == 2 || factor == 3))
                {
                    recipe.ScaleRecipe(factor);
                    Console.WriteLine("Recipe scaled. Do you want to reset the quantities? (yes/no)");
                    string resetChoice = Console.ReadLine().ToLower();

                    if (resetChoice == "yes")
                    {
                        recipe.ResetQuantities();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid scale factor.");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("Do you want to clear the recipe data and add a new recipe? (yes/no)");
            string clearChoice = Console.ReadLine().ToLower();

            if (clearChoice == "yes")
            {
                recipe.ClearData();
                AddRecipe();
            }
        }
    }
}
