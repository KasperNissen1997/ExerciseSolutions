using ExerciseProject.Exercise11x12;
using System.Text;

namespace ExerciseProject.Exercise15x16x17x18x19
{
    public class ValuableRepository : IPersistable
    {
        List<IValuable> valuables = new List<IValuable>();

        public void AddValuable (IValuable valuable) {
            valuables.Add(valuable);
        }

        public IValuable GetValuable (string id) {
            foreach (IValuable valuable in valuables) {
                if (valuable is Amulet amulet)
                    if (amulet.ItemId == id)
                        return amulet;

                if (valuable is Book book)
                    if (book.ItemId == id)
                        return book;

                if (valuable is Course course)
                    if (course.Name == id)
                        return course;
            }

            return null;
        }

        public double GetTotalValue () {
            double totalValue = 0;

            foreach (IValuable valuable in valuables) {
                totalValue += valuable.GetValue();
            }

            return totalValue;
        }

        public int Count () {
            return valuables.Count;
        }

        public void Save (string fileName = @"..\..\..\ValuableRepository.txt") {
            if (!File.Exists(fileName)) // does the file exist?
                File.Create(fileName).Close(); // if not, create it, and close the fileStream

            try {
                using (StreamWriter sw = new StreamWriter(fileName)) {
                    foreach (IValuable valuable in valuables) {
                        if (valuable is Amulet amulet)
                            sw.WriteLine("AMULET;" + amulet.ItemId + ";" + amulet.Design + ";" + amulet.Quality);

                        if (valuable is Book book)
                            sw.WriteLine("BOG;" + book.ItemId + ";" + book.Title + ";" + book.Price);

                        if (valuable is Course course)
                            sw.WriteLine("KURSUS;" + course.Name + ";" + course.DurationInMinutes);
                    }
                }
            }
            catch (DirectoryNotFoundException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Directory \"" + fileName + "\" couldn't be found.");
                Console.ResetColor();
                Console.WriteLine(" Please make sure there is a directory at the specified path.\n");
            }
        }

        public void Load (string fileName = @"..\..\..\ValuableRepository.txt") {
            try {
                using (StreamReader sr = new StreamReader(fileName)) {
                    while (!sr.EndOfStream) {
                        string[] readLine = sr.ReadLine().Split(';');

                        switch (readLine[0]) {
                            case "AMULET":
                                if (Enum.TryParse(readLine[3], out Level quality))
                                    AddValuable(new Amulet(readLine[1], quality, readLine[2]));
                                else
                                    throw new FormatException("String representation: \"" + readLine[2] + "\" of enum Level couldn't be parsed!");
                                break;
                            case "BOG":
                                if (double.TryParse(readLine[3], out double price))
                                    AddValuable(new Book(readLine[1], readLine[2], price));
                                else
                                    throw new FormatException("String representation: \"" + readLine[2] + "\" of double Price couldn't be parsed!");
                                break;
                            case "KURSUS":
                                if (int.TryParse(readLine[2], out int durationInMinutes))
                                    AddValuable(new Course(readLine[1], durationInMinutes));
                                else
                                    throw new FormatException("String representation: \"" + readLine[2] + "\" of int DurationInMinutes couldn't be parsed!");
                                break;
                        }
                    }
                }
            }
            catch (FileNotFoundException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("File at \"" + fileName + "\" couldn't be found.");
                Console.ResetColor();
                Console.WriteLine(" Please make sure there is a file at the specified path.\n");
            }
            catch (DirectoryNotFoundException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Directory at \"" + fileName + "\" couldn't be found.");
                Console.ResetColor();
                Console.WriteLine(" Please make sure there is a directory at the specified path.\n");
            }
            catch (FormatException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Wrong formatting in the read text at \"" + fileName + "\".");
                Console.ResetColor();
                Console.WriteLine(" Consider manually inspecting the file to ensure the same formatting applies everywhere.\n");
            }
        }
    }
}
