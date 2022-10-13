namespace ExerciseProject.Exercise15x16x17x18
{
    public class Utility
    {
        public double GetValueOfMerchandise (Merchandise merchandise) {
            if (merchandise is Amulet) {
                Amulet amulet = (Amulet) merchandise;

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

            if (merchandise is Book) {
                Book book = (Book) merchandise;

                return book.Price;
            }

            return 0;
        }

        public double GetValueOfCourse (Course course) {
            double hourlyRate = 875;

            return (course.DurationInMinutes % 60 == 0) ? 
                hourlyRate * (course.DurationInMinutes / 60) : 
                hourlyRate * (course.DurationInMinutes / 60 + 1);
        }
    }
}
