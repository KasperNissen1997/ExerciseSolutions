namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class EmployeeRepository
    {
        List<Employee> employees;

        public EmployeeRepository () {
            employees = new List<Employee>();
        }

        public void Add (Employee employee) {
            employees.Add(employee);
        }

        public Employee Get (string initials) {
            foreach (Employee employee in employees) {
                if (employee.Initials == initials) 
                    return employee;
            }

            return null;
        }

        public void Remove (Employee employee) {
            employees.Remove(employee);
        }
    }
}
