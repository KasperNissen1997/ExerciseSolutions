namespace ExerciseProject.Exercise15x16x17x18
{
    public class CourseRepository
    {
        List<Course> courses = new List<Course>();

        public void AddCourse (Course course) {
            courses.Add(course);
        }

        public Course GetCourse (string name) {
            foreach (Course course in courses) {
                if (course.Name == name) {
                    return course;
                }
            }

            return null;
        }

        public double GetTotalValue () {
            Utility util = new Utility();

            double totalValue = 0;

            foreach (Course course in courses) {
                totalValue += util.GetValueOfCourse(course);
            }

            return totalValue;
        }
    }
}
