using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10318621_PROG_POE.Classes
{
    static class UnitConverter
    {
        public static (double, string) ConvertUnits(double quantity, string unit)
        {
            // Example conversion: 16 tablespoons = 1 cup
            if (unit == "tablespoons" && quantity >= 16)
            {
                return (quantity / 16, "cups");
            }
            // Add more conversions as needed

            return (quantity, unit);
        }
    }
}
