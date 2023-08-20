using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPersistence.Models
{
    public class SubstituteOrder
    {
        public int Identifier { get; set; }

        // Properties
        public int Hours { get; set; }

        // References
        public School School { get; set; }

        public SubstituteOrder(int identifier, int hours, School school)
        {
            Identifier = identifier;
            Hours = hours;
            School = school;
        }

        public SubstituteOrder(School school, int hours) : this(0, hours, school) { }
    }
}
