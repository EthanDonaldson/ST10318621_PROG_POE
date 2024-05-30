using ST10318621_PROG_POE.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10318621_PROG_POE.Classes

{
    class Recipe
    {
        public string Name { get; private set; }
        private List<Ingredient> ingredients;
        private List<Step> steps;
        private List<double> originalQuantities;

        public Recipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<Step>();
            originalQuantities = new List<double>();
        }

        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the name of the recipe:");
            Name = ReadNonEmptyInput("Recipe name cannot be empty");

            EnterIngredients();
            EnterSteps();
        }

        public void EnterIngredients()
        {
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
                string name = ReadNonEmptyInput("Ingredient name cannot be empty");

                double quantity;
                while (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ResetColor();
                }

                Console.WriteLine($"Enter the unit of measurement for {name}:");
                string unit = ReadNonEmptyInput("Unit of measurement cannot be empty");

                double calories;
                while (!double.TryParse(Console.ReadLine(), out calories) || calories < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ResetColor();
                }

                Console.WriteLine($"Enter the food group for {name}:");
                string foodGroup = ReadNonEmptyInput("Food group cannot be empty");

                AddIngredient(new Ingredient(name, quantity, unit, calories, foodGroup));
            }
        }

        public void EnterSteps()
        {
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
                string description = ReadNonEmptyInput("Step description cannot be empty");
                AddStep(new Step(description));
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

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
            originalQuantities.Add(ingredient.Quantity);
        }

        public void AddStep(Step step)
        {
            steps.Add(step);
        }

        public void ClearData()
        {
            ingredients.Clear();
            originalQuantities.Clear();
            steps.Clear();
            Console.WriteLine("Data cleared.");
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
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity = originalQuantities[i] * factor;
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
    }
}

