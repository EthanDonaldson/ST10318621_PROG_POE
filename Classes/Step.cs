using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10318621_PROG_POE.Classes
{
    // This class represents a single step in a recipe
    public class Step
    {
        public string Description { get; set; }

        public Step(string description)
        {
            Description = description;
        }
    }
}

