using ExerciseProject.Exercise15x16x17;

namespace UtilityLib
{
    public class Utility
    {
        public double GetValueOfBook (Book book) {
            return book.Price;
        }

        public double GetValueOfAmulet (Amulet amulet) {
            switch (amulet.Quality) {
                case Level.low:
                    return 12.5;
                case Level.medium:
                    return 20;
                case Level.high:
                    return 27.5;
                default:
                    return 0;
            }
        }

        public double GetValueOfCourse (Course course) {
            double hourlyRate = 875;

            return (course.DurationInMinutes % 60 == 0) ? 
                hourlyRate * (course.DurationInMinutes / 60) : 
                hourlyRate * (course.DurationInMinutes / 60 + 1);
        }
    }
}
