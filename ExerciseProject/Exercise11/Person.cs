using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProject.Exercise11
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public bool IsMarried { get; set; }
        public int NoOfChildren { get; set; }

        public Person (string name, DateTime birthDate, double height, bool isMarried, int noOfChildren) {
            Name = name;
            BirthDate = birthDate;
            Height = height;
            IsMarried = isMarried;
            NoOfChildren = noOfChildren;
        }

        public string MakeTitle () {
            return Name + ";" 
                + BirthDate.ToString("dd-MM-yyyy HH':'mm':'ss") + ";" 
                + Height + ";" 
                + IsMarried + ";" 
                + NoOfChildren;
        }
    }
}
