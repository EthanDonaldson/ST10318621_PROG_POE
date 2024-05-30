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

        public delegate void CaloriesExceededHandler(string message);
        public event CaloriesExceededHandler OnCaloriesExceeded;

        public Recipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<Step>();
            originalQuantities = new List<double>();
            OnCaloriesExceeded += DisplayCalorieWarning;
        }

        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the name of the recipe:");
            Name = Console.ReadLine();

            EnterIngredients();
            EnterSteps();
            DisplayRecipe();
        }

        public void EnterIngredients()
        {
            Console.WriteLine("Enter the number of ingredients:");

            if (int.TryParse(Console.ReadLine(), out int numIngredients) && numIngredients > 0)
            {
                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                    string name = Console.ReadLine();

                    double quantity;
                    while (true)
                    {
                        Console.WriteLine($"Enter the quantity of {name}:");
                        if (double.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            Console.ResetColor();
                        }
                    }

                    Console.WriteLine($"Enter the unit of measurement for {name}:");
                    string unit = Console.ReadLine();

                    double calories;
                    while (true)
                    {
                        Console.WriteLine($"Enter the number of calories for {name}:");
                        if (double.TryParse(Console.ReadLine(), out calories) && calories >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            Console.ResetColor();
                        }
                    }

                    Console.WriteLine($"Enter the food group for {name}:");
                    string foodGroup = Console.ReadLine();

                    AddIngredient(new Ingredient(name, quantity, unit, calories, foodGroup));
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ResetColor();
            }
        }

        public void EnterSteps()
        {
            Console.WriteLine("Enter the number of steps:");

            if (int.TryParse(Console.ReadLine(), out int numSteps) && numSteps > 0)
            {
                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"Enter step {i + 1}:");
                    string description = Console.ReadLine();
                    AddStep(new Step(description));
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ResetColor();
            }
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

        public void ScaleRecipe(double factor)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity *= factor;
                (double newQuantity, string newUnit) = UnitConverter.ConvertUnits(ingredients[i].Quantity, ingredients[i].Unit);
                ingredients[i].Quantity = newQuantity;
                ingredients[i].Unit = newUnit;
            }
            DisplayRecipe();
        }

        public void ResetQuantities()
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity = originalQuantities[i];
                (double newQuantity, string newUnit) = UnitConverter.ConvertUnits(ingredients[i].Quantity, ingredients[i].Unit);
                ingredients[i].Quantity = newQuantity;
                ingredients[i].Unit = newUnit;
            }
            Console.WriteLine("Quantities reset to original values.");
            DisplayRecipe();
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Recipe: {Name}");
            Console.ResetColor();

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            double totalCalories = CalculateTotalCalories();
            if (totalCalories > 300)
            {
                OnCaloriesExceeded?.Invoke($"Warning: The total calories of this recipe exceed 300 (Total: {totalCalories} calories).");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }

            Console.WriteLine($"Total Calories: {totalCalories}");
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        private void DisplayCalorieWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

