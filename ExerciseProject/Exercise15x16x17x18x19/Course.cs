namespace ExerciseProject.Exercise15x16x17x18x19
{
    public class Course : IValuable
    {
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }

        static public double CourseHourValue { get; set; } = 875.0;

        public Course (string name, int durationInMinutes) {
            Name = name;
            DurationInMinutes = durationInMinutes;
        }

        public Course (string name) : this (name, 0) { }

        public override string ToString () {
            return "Name: " + Name + ", Duration in Minutes: " + DurationInMinutes + ", Value: " + GetValue();
        }

        public double GetValue () {
            return (DurationInMinutes % 60 == 0) ?
                CourseHourValue * (DurationInMinutes / 60) :
                CourseHourValue * (DurationInMinutes / 60 + 1);
        }
    }
}
