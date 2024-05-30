using ST10318621_PROG_POE.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Ethan Donaldson 
 * ST10318621
 * Group 2
 * 
 * Change forground colour according to GeeksforGeeks (2019), How to change Foreground Color of Text in Console [Online]
 * available at: https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/ [Accessed may 17 2024]
 * 
 * Collections according to Khandelwal. V, An Ultimate One-Stop Solution Guide to Collections in C# Programming With Examples [Online]
 * available at :https://www.simplilearn.com/tutorials/c-sharp-tutorial/collections-in-c-sharp [Accessed 30 May 2024]
 * 
 * Troeleson, A. Japikse, P. 2022. Pro C# with .NET 6 Foundational principles and practices in programming. Chamsbersburg, PA, USA
 */

namespace ST10318621_PROG_POE.Classes {

    // This class represents a recipe with ingredients, steps, and related functionalities
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

        // Adds an ingredient to the recipe and stores its original quantity
        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
            originalQuantities.Add(ingredient.Quantity);
        }

        // Prompts the user to enter details for the recipe
        public void EnterRecipeDetails()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the name of the recipe:");
            Console.ResetColor();
            Name = ReadNonEmptyInput("Recipe name cannot be empty. Please enter the name of the recipe:");

            EnterIngredients();
            EnterSteps();
        }

        // Prompts the user to enter details for each ingredient
        private void EnterIngredients()
        {
            ingredients.Clear(); // Clear previous ingredients

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the number of ingredients:");
            Console.ResetColor();

            int numIngredients;
            while (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ResetColor();
            }

            for (int i = 0; i < numIngredients; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                Console.ResetColor();
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

        // Prompts the user to enter details for each step
        private void EnterSteps()
        {
            steps.Clear(); // Clear previous steps

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the number of steps:");
            Console.ResetColor();

            int numSteps;
            while (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ResetColor();
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Enter step {i + 1}:");
                Console.ResetColor();
                string description = ReadNonEmptyInput($"Enter the description for step {i + 1}:");
                steps.Add(new Step(description));
            }
        }

        // Reads non-empty input from the user with a prompt
        private string ReadNonEmptyInput(string prompt)
        {
            string input;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(prompt);
                Console.ResetColor();
                input = Console.ReadLine()?.Trim();
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        // Displays the recipe details
        public void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Recipe: {Name}");
            Console.ResetColor();

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

        // Scales the recipe quantities by a given factor
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Recipe scaled.");
            Console.ResetColor();
        }

        // Resets the ingredient quantities to their original values
        public void ResetQuantities()
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity = originalQuantities[i];
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Quantities reset to original values.");
            Console.ResetColor();
        }

        // Clears all data from the recipe
        public void ClearData()
        {
            Name = "";
            ingredients.Clear();
            steps.Clear();
            originalQuantities.Clear();
        }

        // Checks total calories and notifies if exceeding a threshold
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

        // Calculates the total calories for the recipe
        public double CalculateTotalCalories()
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


