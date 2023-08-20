namespace ExerciseProject.Exercise11x12
{
    public class DataHandler
    {
        public string DataFileName { get; private set; }

        public DataHandler (string dataFileName) { 
            DataFileName = dataFileName;

            // create the file at dataFileName if it doesn't exist
            if (!File.Exists(DataFileName)) {
                File.Create(DataFileName).Close();
            }
        }

        public void SavePerson (Person person) {
            try {
                StreamWriter sw = new StreamWriter (DataFileName);

                sw.WriteLine(person.MakeTitle());

                sw.Close();
            } 
            catch (DirectoryNotFoundException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Directory \"" + DataFileName + "\" couldn't be found.");
                Console.ResetColor();
                Console.WriteLine(" Please make sure there is a directory at the specified path.\n");
            }
        }

        public Person LoadPerson () {
            try {
                StreamReader sr = new StreamReader(DataFileName);

                string[] personData = sr.ReadLine().Split(';');

                sr.Close();

                return new Person(
                        personData[0],
                        DateTime.ParseExact(personData[1], "dd-MM-yyyy HH':'mm':'ss", null),
                        double.Parse(personData[2]),
                        bool.Parse(personData[3]),
                        int.Parse(personData[4]));
            }
            catch (FileNotFoundException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("File at \"" + DataFileName + "\" couldn't be found.");
                Console.ResetColor();
                Console.WriteLine(" Please make sure there is a file at the specified path.\n");
            }
            catch (DirectoryNotFoundException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Directory at \"" + DataFileName + "\" couldn't be found.");
                Console.ResetColor();
                Console.WriteLine(" Please make sure there is a directory at the specified path.\n");
            }

            return null;
        }

        public void SavePersons (Person[] persons) {
            try {
                StreamWriter sw = new StreamWriter(DataFileName);

                foreach (Person person in persons) {
                    sw.WriteLine(person.MakeTitle());
                }

                sw.Close();
            }
            catch (DirectoryNotFoundException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Directory \"" + DataFileName + "\" couldn't be found.");
                Console.ResetColor();
                Console.WriteLine(" Please make sure there is a directory at the specified path.\n");
            }
        }

        public Person[] LoadPersons () {
            try {
                Person[] persons;

                // create an array at the exact required size
                using (StreamReader sr = new StreamReader(DataFileName)) {
                    int i = 0;

                    while (sr.ReadLine() != null) 
                    { 
                        i++; 
                    }

                    persons = new Person[i];
                }

                using (StreamReader sr = new StreamReader(DataFileName)) {
                    int i = 0;

                    while (!sr.EndOfStream) {
                        string[] personData = sr.ReadLine().Split(';');

                        persons[i] = new Person(
                                personData[0],
                                DateTime.ParseExact(personData[1], "dd-MM-yyyy HH':'mm':'ss", null),
                                double.Parse(personData[2]),
                                bool.Parse(personData[3]),
                                int.Parse(personData[4]));

                        i++;
                    }
                }

                return persons;

            }
            catch (FileNotFoundException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("File at \"" + DataFileName + "\" couldn't be found.");
                Console.ResetColor();
                Console.WriteLine(" Please make sure there is a file at the specified path.\n");
            }
            catch (DirectoryNotFoundException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Directory at \"" + DataFileName + "\" couldn't be found.");
                Console.ResetColor();
                Console.WriteLine(" Please make sure there is a directory at the specified path.\n");
            }

            return null;
        }
    }
}
