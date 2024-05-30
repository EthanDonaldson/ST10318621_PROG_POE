using ST10318621_PROG_POE.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10318621_PROG_POE.Classes {

    public class Recipe
    {
        public string Name { get; private set; }
        private List<Ingredient> ingredients;
        private List<Step> steps;
        private List<double> originalQuantities;
        public delegate void RecipeCalorieNotification(Recipe recipe);

        public Recipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<Step>();
            originalQuantities = new List<double>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
            originalQuantities.Add(ingredient.Quantity);
        }

        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the name of the recipe:");
            Name = ReadNonEmptyInput("Recipe name cannot be empty. Please enter the name of the recipe:");

            EnterIngredients();
            EnterSteps();
        }

        private void EnterIngredients()
        {
            ingredients.Clear(); // Clear previous ingredients

            Console.WriteLine("Enter the number of ingredients:");

            int numIngredients;
            while (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ResetColor();
            }

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                string name = Console.ReadLine().Trim();

                double quantity;
                while (!double.TryParse(ReadNonEmptyInput($"Enter the quantity of {name}:"), out quantity) || quantity <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ResetColor();
                }

                string unit = ReadNonEmptyInput($"Enter the unit of measurement for {name}:");

                double calories;
                while (!double.TryParse(ReadNonEmptyInput($"Enter the calories for {name}:"), out calories) || calories < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ResetColor();
                }

                string foodGroup = ReadNonEmptyInput($"Enter the food group for {name}:");

                ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            }
        }

        private void EnterSteps()
        {
            steps.Clear(); // Clear previous steps

            Console.WriteLine("Enter the number of steps:");

            int numSteps;
            while (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ResetColor();
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                string description = ReadNonEmptyInput($"Enter the description for step {i + 1}:");
                steps.Add(new Step(description));
            }
        }

        private string ReadNonEmptyInput(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine()?.Trim();
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }

            Console.WriteLine("Steps:");
            foreach (var step in steps)
            {
                Console.WriteLine(step.Description);
            }
        }

        public void ScaleRecipe(double factor)
        {
            if (factor <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid scale factor. Scale factor must be greater than zero.");
                Console.ResetColor();
                return;
            }

            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }

            Console.WriteLine("Recipe scaled.");
        }

        public void ResetQuantities()
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity = originalQuantities[i];
            }

            Console.WriteLine("Quantities reset to original values.");
        }

        public void ClearData()
        {
            Name = "";
            ingredients.Clear();
            steps.Clear();
            originalQuantities.Clear();
        }

        public void CheckCaloriesAndNotify(RecipeCalorieNotification notificationDelegate)
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            if (totalCalories > 300)
            {
                notificationDelegate?.Invoke(this);
            }
        }
        public double CalculateTotalCalories() // Ensure this method is public
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Quantity * ingredient.Calories;
            }
            return totalCalories;
        }
    }
}


