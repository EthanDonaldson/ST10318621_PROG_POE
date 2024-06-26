﻿using ST10318621_PROG_POE.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10318621_PROG_POE.Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("****************************************");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. List Recipes");
                Console.WriteLine("3. Exit");
                Console.WriteLine("****************************************");
                Console.ResetColor();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        recipeManager.AddRecipe();
                        break;
                    case "2":
                        recipeManager.ListRecipes();
                        break;
                    case "3":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}

