namespace ExerciseProject.Exercise15x16x17x18x19
{
    public class Utility
    {
        public double LowQualityValue { get; set; } = 12.5;
        public double MediumQualityValue { get; set; } = 20.0;
        public double HighQualityValue { get; set; } = 27.5;
        

        public double GetValueOfMerchandise (Merchandise merchandise) {
            if (merchandise is Amulet) {
                Amulet amulet = (Amulet) merchandise;

                switch (amulet.Quality) {
                    case Level.low:
                        return LowQualityValue;
                    case Level.medium:
                        return MediumQualityValue;
                    case Level.high:
                        return HighQualityValue;
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
            double hourlyRate = CourseHourValue;

            return (course.DurationInMinutes % 60 == 0) ? 
                hourlyRate * (course.DurationInMinutes / 60) : 
                hourlyRate * (course.DurationInMinutes / 60 + 1);
        }
    }
}
