using System;
using System.IO;

namespace ExerciseProject.Exercise11
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
            StreamWriter sw;
            try {
                sw = new StreamWriter (DataFileName);

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
            string[] personData;

            try {
                StreamReader sr = new StreamReader (DataFileName);

                personData = sr.ReadLine().Split(';');

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
    }
}
