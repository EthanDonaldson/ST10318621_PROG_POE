using ST10318621_PROG_POE.Classes;
using System.Collections.Generic;
using System;

public class Recipe
{
    public string Name { get; set; } // Public set accessor

    private List<Ingredient> ingredients;
    private List<Step> steps;
    private List<double> originalQuantities;    // Delegate for recipe calorie notifications
    public delegate void RecipeCalorieNotification(Recipe recipe);

    public Recipe()
    {
        ingredients = new List<Ingredient>();
        steps = new List<Step>();
        originalQuantities = new List<double>();
    }

    // Adds an ingredient to the recipe
    public void AddIngredient(Ingredient ingredient)
    {
        ingredients.Add(ingredient);
        originalQuantities.Add(ingredient.Quantity);
    }

    public List<Ingredient> GetIngredients()
    {
        return ingredients;
    }

    // Prompts the user to enter recipe details
    public void EnterRecipeDetails()
    {
        Console.WriteLine("Enter the name of the recipe:");
        Name = ReadNonEmptyInput("Recipe name cannot be empty. Please enter the name of the recipe:");

        EnterIngredients();
        EnterSteps();
    }

    // Prompts the user to enter ingredients for the recipe
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

            string foodGroup = SelectFoodGroup();

            ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
        }
    }

    // Prompts the user to enter steps for the recipe
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

    // Prompts the user to select a food group from predefined options
    private string SelectFoodGroup()
    {
        Console.WriteLine("Select the food group for the ingredient:");
        Console.WriteLine("1. Grains");
        Console.WriteLine("2. Vegetables");
        Console.WriteLine("3. Fruits");
        Console.WriteLine("4. Dairy");
        Console.WriteLine("5. Protein");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Please select a valid option.");
            Console.ResetColor();
        }

        switch (choice)
        {
            case 1: return "Grains";
            case 2: return "Vegetables";
            case 3: return "Fruits";
            case 4: return "Dairy";
            case 5: return "Protein";
            default: return "Unknown";
        }
    }

    // Reads non-empty input from the user
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

    // Displays the recipe details
    public void DisplayRecipe()
    {
        Console.WriteLine("****************************************");
        Console.WriteLine($"Recipe: {Name}");
        Console.WriteLine("****************************************");
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
        }
        Console.WriteLine("****************************************");
        Console.WriteLine("Steps:");
        foreach (var step in steps)
        {
            Console.WriteLine(step.Description);
        }
        Console.WriteLine("****************************************");

        double totalCalories = CalculateTotalCalories();
        Console.WriteLine($"Total Calories: {totalCalories}");
        DisplayCalorieMessage(totalCalories);
    }

    // Scales the recipe by a given factor
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

    // Resets ingredient quantities to their original values
    public void ResetQuantities()
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            ingredients[i].Quantity = originalQuantities[i];
        }

        Console.WriteLine("Quantities reset to original values.");
    }

    // Clears all data from the recipe
    public void ClearData()
    {
        Name = "";
        ingredients.Clear();
        steps.Clear();
        originalQuantities.Clear();
    }

    // Checks the total calories and triggers a notification if it exceeds 300
    public void CheckCaloriesAndNotify(RecipeCalorieNotification notificationDelegate)
    {
        double totalCalories = CalculateTotalCalories();
        if (totalCalories > 300)
        {
            notificationDelegate?.Invoke(this);
        }
    }

    // Calculates the total calories of the recipe
    public double CalculateTotalCalories()
    {
        double totalCalories = 0;
        foreach (var ingredient in ingredients)
        {
            totalCalories += ingredient.Quantity * ingredient.Calories;
        }
        return totalCalories;
    }

    // Displays a message based on the total calorie count
    private void DisplayCalorieMessage(double totalCalories)
    {
        if (totalCalories < 200)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("This recipe is low in calories, suitable for a snack.");
            Console.ResetColor();
        }
        else if (totalCalories >= 200 && totalCalories <= 500)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("This recipe has moderate calories, suitable for a balanced meal.");
            Console.ResetColor();
        }
        else if (totalCalories > 500)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This recipe is high in calories and should be consumed sparingly.");
            Console.ResetColor();
        }
    }
}

