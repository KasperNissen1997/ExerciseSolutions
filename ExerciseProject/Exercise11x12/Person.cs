namespace ExerciseProject.Exercise11x12
{
    public class Person
    {
        string _name;
        public string Name { 
            get { return _name; } 
            set {
                if (value.Length > 0)
                    _name = value;
                else
                    throw new ArgumentException("A name has to be at least 1 character long.");
            } 
        }

        DateTime _birthDate;
        public DateTime BirthDate {
            get { return _birthDate; }
            set {
                if (value > new DateTime(1900, 1, 1))
                    _birthDate = value;
                else
                    throw new ArgumentException("The birthdate must be set after " + new DateTime(1900, 1, 1).ToString() + ".");
            } 
        }

        double _height;
        public double Height { 
            get { return _height; }
            set {
                if (value > 0)
                    _height = value;
                else
                    throw new ArgumentException("The height must be above 0.");
            } 
        }

        int _noOfChildren;
        public int NoOfChildren { 
            get { return _noOfChildren; }
            set {
                if (value >= 0)
                    _noOfChildren = value;
                else
                    throw new ArgumentException("The number of children cannot be negative.");
            } 
        }

        public bool IsMarried { get; set; }

        public Person (string name, DateTime birthDate, double height, bool isMarried, int noOfChildren) {
            Name = name;
            BirthDate = birthDate;
            Height = height;
            IsMarried = isMarried;
            NoOfChildren = noOfChildren;
        }

        public Person (string name, DateTime birthDate, double height, bool isMarried) : this (name, birthDate, height, isMarried, 0) { } 


        public string MakeTitle () {
            return Name + ";" 
                + BirthDate.ToString("dd-MM-yyyy HH':'mm':'ss") + ";" 
                + Height + ";" 
                + IsMarried + ";" 
                + NoOfChildren;
        }
    }
}
