using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10318621_PROG_POE.Classes
{
    // This class provides methods to convert units of measurement
    public class UnitConverter
    {
        // Converts various units to grams
        public static double ConvertToGrams(double quantity, string unit)
        {
            unit = unit.ToLower(); // Convert unit to lowercase

            switch (unit)
            {
                case "g":
                case "grams":
                    return quantity;
                case "kg":
                case "kilograms":
                    return quantity * 1000;
                case "oz":
                case "ounces":
                    return quantity * 28.35; // 1 ounce = 28.35 grams
                case "lb":
                case "pounds":
                    return quantity * 453.59; // 1 pound = 453.59 grams
                case "tsp":
                case "teaspoons":
                    return quantity * 4.93; // 1 teaspoon = 4.93 grams
                case "tbsp":
                case "tablespoons":
                    return quantity * 14.79; // 1 tablespoon = 14.79 grams
                default:
                    throw new ArgumentException("Invalid unit.");
            }
        }

        // Converts various units to liters
        public static double ConvertToLiters(double quantity, string unit)
        {
            unit = unit.ToLower(); // Convert unit to lowercase

            switch (unit)
            {
                case "ml":
                case "milliliters":
                    return quantity / 1000;
                case "l":
                case "liters":
                    return quantity;
                case "fl oz":
                case "fluid ounces":
                    return quantity * 0.029574; // 1 fluid ounce = 0.029574 liters
                case "cup":
                case "cups":
                    return quantity * 0.236588; // 1 cup = 0.236588 liters
                default:
                    throw new ArgumentException("Invalid unit.");
            }
        }
    }
}

