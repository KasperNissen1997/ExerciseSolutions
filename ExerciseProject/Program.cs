using ExerciseFlowLib;
using ExerciseProject.Exercise11x12;
using ExerciseProject.Exercise5;
using ExerciseProject.Exercise7;
using ExerciseProject.Exercise21_Tusindfryd;
using TotallySafeLib;
using System.Speech.Synthesis;
using CustomExceptionHandling;

namespace ExerciseProject
{
    public class Program
    {
        static void Main (string[] args) {
            // exercise1 ~ not implemented
            // exercise2 ~ not implemented
            bool exercise3 = false;
            bool exercise4 = false;
            bool exercise5 = false;
            bool exercise6 = false;
            bool exercise7 = false;
            // exercise8 ~ not implemented
            // exercise9 ~ in folder Exercise9x10
            // exercise10 ~ in folder Exercise9x10
            bool exercise11 = false;
            // exercise12 ~ in folder Exercise11x12
            // exercise13 ~ implemented as one or multiple methods
            // exercise14 ~ in folder Exercise14
            // exercise15 ~ in folder Exercise15x16x17x18x19
            // exercise16 ~ in folder Exercise15x16x17x18x19
            // exercise17 ~ in folder Exercise15x16x17x18x19
            // exercise18 ~ in folder Exercise15x16x17x18x19
            // exercise19 ~ in folder Exercise15x16x17x18x19
            // exercise20 ~ solved elsewhere
            bool exercise21 = true; // also in folder Exercise21-Tusindfryd

            #region Exercise 3 - C# Data
            if (exercise3) {
                #region Exercise 3.1
                string inputHeight, inputWidth;
                int height, width;

                Console.Write("Height: ");
                inputHeight = Console.ReadLine();
                Console.Write("Width: ");
                inputWidth = Console.ReadLine();
                Console.WriteLine();

                int.TryParse(inputHeight, out height);
                int.TryParse(inputWidth, out width);

                Console.WriteLine("The area of the rectangle is " + (height * width) + ".");
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                #region Exercise 3.2
                string x1, y1, x2, y2;
                (double, double) firstCoordinate, secondCoordinate;

                Console.Write("First 'x' coordinate: ");
                x1 = Console.ReadLine();
                Console.Write("First 'y' coordinate: ");
                y1 = Console.ReadLine();
                Console.Write("Second 'x' coordinate: ");
                x2 = Console.ReadLine();
                Console.Write("Second 'y' coordinate: ");
                y2 = Console.ReadLine();

                double.TryParse(x1, out firstCoordinate.Item1);
                double.TryParse(y1, out firstCoordinate.Item2);
                double.TryParse(x2, out secondCoordinate.Item1);
                double.TryParse(y2, out secondCoordinate.Item2);

                Console.WriteLine("You've entered: " + firstCoordinate + ", " + secondCoordinate + ".");
                Console.WriteLine("The slope between the two coordinates is " + CalculateSlope(firstCoordinate, secondCoordinate) + "."); ;
                Console.WriteLine();

                Console.WriteLine("Testing out different calculations: ");
                Console.WriteLine("(3, 3), (5, 5) = " + CalculateSlope((3, 3), (5, 5)) + ".");
                Console.WriteLine("(3, 3), (5, 4) = " + CalculateSlope((3, 3), (5, 4)) + ".");
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                ExerciseFlow.FinishExercise("exercise 3 - C# Data");
            }
            #endregion

            #region Exercise 4 - Loops
            if (exercise4) {
                #region Exercise 2.2
                Console.Write("You come across a mean-looking brit, obviously sad that their queen died. He sees you and says:\n"
                    + "\"Ay bruv, what'cha glaring at you nook?\"\n"
                    + "You think for a bit, and then you reply:\n"
                    + "\n"
                    + "1 - \"You, obviously, ya wiggy.\"\n"
                    + "2 - \"Uhm u-uh nothing s-s-senpaiii >.<\" *get naked and try to embrace the chav*\n"
                    + "3 - \"Your bulging veiny girthy forearms mate.\"\n"
                    + "\n"
                    + "Enter choice here: ");
                string userInput = Console.ReadLine();
                Console.WriteLine();

                int userSelection = int.Parse(userInput);
                
                switch (userSelection) {
                    case 1:
                        Console.WriteLine("Oy, my hair's all tuzzled and I'm tired, of course you're sneaking a peek, freak.");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Casper, stay away from me!");
                        Console.ResetColor();
                        break;
                    case 3:
                        Console.WriteLine("Wanna cop a feel? C:");
                        break;
                    default:
                        Console.WriteLine("You speaking in tongues? Witch-level-shit, I'll stay away!");
                        break;
                }
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                #region Exercise 2.4
                Console.Write("Please enter a string of atleast length 6: ");
                userInput = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Now I'll show you the 2nd, 4th and 6th character from the string you entered:\n"
                    + "2nd char: {0}\n"
                    + "4th char: {1}\n"
                    + "6th char: {2}\n",
                    userInput[1], userInput[3], userInput[5]);
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                #region Exercise 2.5
                Console.WriteLine("Using the string you entered in the previous exercise, I'll now show you the position of each character in it!");
                Console.WriteLine();

                int stringIndexCount = 0;
                while (stringIndexCount < userInput.Length) {
                    Console.WriteLine(stringIndexCount + ": " + userInput[stringIndexCount]);
                    stringIndexCount++;
                }
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                #region Exercise 2.6
                Console.WriteLine("And now, because I feel daring, I'll do it using a do-while loop in the background! BEHOLD:");
                Console.WriteLine();

                stringIndexCount = 0;
                do {
                    Console.WriteLine(stringIndexCount + ": " + userInput[stringIndexCount]);
                    stringIndexCount++;
                }
                while (stringIndexCount < userInput.Length);
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                #region Exercise 2.7
                Console.Write("Input a random integer: ");
                userInput = Console.ReadLine();
                Console.WriteLine();

                int a = int.Parse(userInput);

                Console.Write("Great, can you do it again? I'd be impressed - here: ");
                userInput = Console.ReadLine();
                Console.WriteLine();

                int b = int.Parse(userInput);

                Console.WriteLine("Awesome! Check this out - I'll show you the remainder of the division (first number / second number) with these two integers below:\n"
                    + "\n"
                    + "The integer coefficient: " + (a / b) + "\n"
                    + "The remainder of the division: " + (a % b));
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                ExerciseFlow.FinishExercise("exercise 4 - Loops");
            }
            #endregion

            #region Exercise 5 - Methods
            if (exercise5) {
                int result = 0;
                Calculator calc = new Calculator();

                bool keepRunning = true;

                do {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Result: " + result);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Choose action:");
                    Console.WriteLine();
                    Console.WriteLine("1 - Add");
                    Console.WriteLine("2 - Subtract");
                    Console.WriteLine("3 - Divide");
                    Console.WriteLine("4 - Mulitply");
                    Console.WriteLine();
                    Console.WriteLine("5 - Exit");
                    Console.WriteLine();

                    Console.Write("... ");
                    string input = Console.ReadLine();
                    Console.WriteLine();

                    int userSelection = 0; 
                    int.TryParse(input, out userSelection);

                    switch (userSelection) {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You vegetable! >.>");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            break;
                        case 1:
                            userSelection = GetInput();
                            result = calc.Add(result, userSelection);
                            break;
                        case 2:
                            userSelection = GetInput();
                            result = calc.Subtract(result, userSelection);
                            break;
                        case 3:
                            userSelection = GetInput();
                            result = (int) calc.Divide(result, userSelection);
                            break;
                        case 4:
                            userSelection = GetInput();
                            result = calc.Multiply(result, userSelection);
                            break;
                        case 5:
                            keepRunning = false;
                            break;
                    }

                    Console.Clear();
                } while (keepRunning);

                ExerciseFlow.FinishExercise("exercise 5 - Methods");
            }
            #endregion

            #region Exercise 6 - Arrays
            if (exercise6) {
                #region Exercise 3.1, 3.2
                (string, int)[] nameAgePairs = {
                     ("Casper", 22),
                     ("Kasper", 24),
                     ("Jonathan", 24),
                     ("Mathias", 26),
                     ("Jonas", 30),
                     ("Alexander", 24)
                };

                double averageAge;
                int ageSum = 0;

                for (int x = 0; x < nameAgePairs.Length; x++) {
                    Console.WriteLine(nameAgePairs[x].Item1 + " er " + nameAgePairs[x].Item2 + " år gammel.");
                    ageSum += nameAgePairs[x].Item2;
                }

                Console.WriteLine(); // formatting

                averageAge = (double) ageSum / nameAgePairs.Length;

                Console.WriteLine("Den gennemsnitlige alder er " + averageAge + " år.");
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                #region Exercise 3.3
                int userSelection = 0;

                do {
                    Console.Write("Hvilken alder skal der søges efter?: ");
                    string input1 = Console.ReadLine();
                    Console.WriteLine();

                    try {
                        userSelection = int.Parse(input1); // converts the input to an integer
                    } catch (FormatException) {
                        Console.WriteLine("Du gjorde et godt forsøg - det er menneskeligt at fejle <3");
                        Console.WriteLine("Bare ikke gør det mere vel? Skrive et heltal over 0, tak.");
                        Console.WriteLine();
                        Console.WriteLine("https://en.wikipedia.org/wiki/Integer - læs op på det hvis du er i tvivl...");
                        Console.WriteLine();
                    }

                    if (userSelection < 0) {
                        Console.WriteLine("Man kan skida ikke have en negativ alder, tænk dig nu om...");
                        Console.WriteLine();
                        userSelection = 0; // ensure the loop continues
                    }
                } while (userSelection == 0);

                bool ageFound = false;
                for (int x = 0; x < nameAgePairs.Length; x++) {
                    if (nameAgePairs[x].Item2 == userSelection) {
                        ageFound = true;
                        break; // stops the loop if age has been found
                    }
                }

                if (ageFound)
                    Console.WriteLine("Alderen er blevet fundet!");
                else 
                    Console.WriteLine("Alderen findes ikke i vores array.");
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                #region Exercise 3.4
                Console.Write("Declare the size of your group: ");
                string input2 = Console.ReadLine();

                int arraySize;
                if (int.TryParse(input2, out _))
                    arraySize = int.Parse(input2);
                else {
                    Console.WriteLine("Input was not parsable as an integer - default value of \"0\" used.");
                    arraySize = 0;
                }

                int[] ages = new int[arraySize];

                for (int i = 0; i < ages.Length; i++) {
                    Console.Write("Enter an age: ");
                    input2 = Console.ReadLine();

                    if (int.TryParse(input2, out _))
                        ages[i] = int.Parse(input2);
                    else {
                        Console.WriteLine("Input was not parsable as an integer - default value of \"0\" used.");
                        ages[i] = 0;
                    }
                }
                Console.WriteLine();

                double sum = 0;
                for (int i = 0; i < ages.Length; i++) {
                    if (i != ages.Length - 1)
                        Console.Write(ages[i] + ", ");
                    else
                        Console.WriteLine(ages[i] + ".");

                    sum += ages[i];
                }

                Console.WriteLine("The average age is: " + sum / ages.Length);
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                #region Exercise 4.1
                int[] testArray = new int[] { 1, 2, 3, 4, 5, 5, 2, 3, 3, 3, 3, 7 };
                Console.WriteLine("Purely for testing purposes: " + SockMerchant(testArray));
                Console.WriteLine("The above should result in \"4\".");
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                #region Exercise 4.2
                testArray = new int[] { 6, 3, 7, 1, 2, 3, 5, 8, 9, 6, 9 };
                Console.WriteLine("Purely for testing purposes: " + CandleBlower(testArray));
                Console.WriteLine("The above should result in \"2\".");
                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                ExerciseFlow.FinishExercise("exercise 6 - Arrays");
            }
            #endregion

            #region Exercise 7 - Menu
            if (exercise7) {
                #region Exercise 2.1, 2.2, 2.3, 2.4, 2.5, 2.6
                Menu mainMenu = new Menu("Min fantastiske menu");

                mainMenu.AddMenuItem("Gør dit");
                mainMenu.AddMenuItem("Gør dat");
                mainMenu.AddMenuItem("Gør noget");
                mainMenu.AddMenuItem("Få svaret på livet, universet og alting");

                bool runMenu = true;
                do {
                    mainMenu.Show();

                    switch (mainMenu.SelectMenuItem()) {
                        case 0:
                            runMenu = false;
                            break;
                        case 1:
                            Console.WriteLine("Gør dit");
                            Console.WriteLine();
                            break;
                        case 2:
                            Console.WriteLine("Gør dat");
                            Console.WriteLine();
                            break;
                        case 3:
                            Console.WriteLine("Gør noget");
                            Console.WriteLine();
                            break;
                        case 4:
                            Console.WriteLine("42");
                            Console.WriteLine();
                            break;
                    }

                    if (runMenu) {
                        Console.Write("...");
                        Console.ReadLine();
                        Console.Clear();
                    }
                } while (runMenu);

                ExerciseFlow.FinishTask();
                #endregion

                ExerciseFlow.FinishExercise("exercise 7 - Menu");
            }
            #endregion

            #region Exercise 11 - Persistence
            if (exercise11) {
                Person person = new Person("Ander Andersen", new DateTime(1975, 8, 24), 175.9, true, 3);

                DataHandler handler = new DataHandler(@"..\..\..\Exercise11And12\Data.txt");
                handler.SavePerson(person);

                Console.Write("Writing Person: ");
                Console.WriteLine(person.MakeTitle());

                ExerciseFlow.FinishExercise("exercise 11 - Persistence");
            }
            #endregion

            #region Exercise 21 - Custom exception handling
            if (exercise21) {
                #region Exercise 2.1, 2.2, 2.3, 2.4, 2.5
                int testInt = 0;
                double testDouble = 0;

                try {
                    testDouble = TotallySafe.Divider(0);

                    Console.WriteLine(testDouble);
                } catch (DivideByZeroException ex) {
                    Console.WriteLine(ex.Message);
                }

                try {
                    testInt = TotallySafe.StringToInt("fem");

                    Console.WriteLine(testInt);
                } catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                }

                try {
                    testInt = TotallySafe.GetValueAtPosition(-2);

                    Console.WriteLine(testInt);
                } catch (IndexOutOfRangeException ex) {
                    Console.WriteLine(ex.Message);
                } catch (NegativeIndexOutOfRangeException ex) {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();

                ExerciseFlow.FinishTask();
                #endregion

                #region Exercise 3.3
                Controller controller = new Controller();

                Console.WriteLine("Currently, the flowerTypeRepo contains " + controller.flowerTypeRepo.Count() + " elements.\n" +
                    "Now we attempt to register a new flower type...\n");

                string imageFolderPath = @"..\..\..\Exercise21-Tusindfryd\Images\";
                controller.RegisterNewFlowerType("African Marigold", imageFolderPath + "african-marigold.png", 30, 120, 0.0225);

                Console.WriteLine("After calling the \"RegisterNewFlowerType\" method with appropriate parameters, the flowerTypeRepo now contains " + controller.flowerTypeRepo.Count() + " elements.\n");
                #endregion

                ExerciseFlow.FinishExercise("exercise 21 - Custom exception handling");
            }
            #endregion

            #region Lololol
            //SpeechSynthesizer speakSynth = new SpeechSynthesizer();
            //speakSynth.SetOutputToDefaultAudioDevice();

            //string[] names = {
            //    "Jonas",
            //    "Matias",
            //    "Jonathan",
            //    "Alexander",
            //    "Casper"
            //};

            //foreach (string name in names) {
            //    speakSynth.Speak("Fuck you " + name);
            //}

            //speakSynth.Speak("You all suck at table football haha \n" +
            //    "Suck it boys");
            #endregion

            ExerciseFlow.EndProgram();
        }

        #region Exercise 3 - helper method(s)
        public static double CalculateSlope ((double, double) firstCoordinate, (double, double) secondCoordinate) {
            return (secondCoordinate.Item2 - firstCoordinate.Item2) / (secondCoordinate.Item1 - firstCoordinate.Item1);
        }
        #endregion

        #region Exercise 5 - helper method(s)
        static int GetInput () {
            Console.Write("Enter a new number: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            int userSelection = 0;
            int.TryParse(input, out userSelection);

            return userSelection;
        }
        #endregion

        #region Exercise 6 - bonus exercise(s)
        public static int SockMerchant (int[] socks) {
            // get the unique sock color count
            int uniqueSockColors = 0;
            for (int i = 0; i < socks.Length; i++) {
                bool isUnique = true;

                for (int j = 0; j < i; j++) {
                    if (socks[i] == socks[j]) {
                        isUnique = false;
                    }
                }

                if (isUnique)
                    uniqueSockColors++;
            }

            (int, int)[] colorCounts = new (int, int)[uniqueSockColors];

            // for each unique sock color, add a entry in colorCount 
            int index = 0;
            for (int i = 0; i < socks.Length; i++) {
                bool isUnique = true;

                for (int j = 0; j < i; j++) {
                    if (socks[i] == socks[j]) {
                        isUnique = false;
                    }
                }

                if (isUnique) {
                    colorCounts[index] = (socks[i], 0);
                    index++;
                }
            }

            // count the number of each color
            for (int i = 0; i < colorCounts.Length; i++) {
                for (int j = 0; j < socks.Length; j++) {
                    if (colorCounts[i].Item1 == socks[j]) {
                        colorCounts[i].Item2++;
                    }
                }
            }

            // find the amount of pairs that can be made
            int pairs = 0;
            foreach ((int, int) colorCount in colorCounts) {
                pairs += colorCount.Item2 / 2;
            }

            return pairs;
        }

        public static int CandleBlower (int[] candles) {
            int currentHighestCandle = 0; 
            int candlesBlown = 0;

            foreach (int candle in candles) {
                if (candle > currentHighestCandle) {
                    currentHighestCandle = candle;
                    candlesBlown = 0;
                }

                if (candle == currentHighestCandle) {
                    candlesBlown++;
                }
            }

            return candlesBlown;
        }
        #endregion

        #region Exercise 13 - Tigger and Winnie the Pooh
        public static string JumpTiggerAndVinnie (int tiggerPos, int tiggerVelocity, int vinniePos, int vinnieVelocity) {
            if (tiggerPos > 10000 || tiggerVelocity > 10000 || vinniePos > 10000 || vinnieVelocity > 10000)
                return "NO";
            
            if (tiggerPos == vinniePos)
                return tiggerPos + "," + vinniePos;

            if (tiggerPos < vinniePos)
                return FindCollision(tiggerPos, tiggerVelocity, vinniePos, vinnieVelocity);
            else
                return FindCollision(vinniePos, vinnieVelocity, tiggerPos, tiggerVelocity);
        }

        private static string FindCollision (int x1Pos, int x1Vel, int x2Pos, int x2Vel) {
            int i = 0;
            
            if (x1Vel < x2Vel) {
                return "NO";
            }

            while (x1Pos < x2Pos) {

                x1Pos += x1Vel;
                x2Pos += x2Vel;
                i += 1;

                if (x1Pos == x2Pos)
                    return x1Pos + "," + x2Pos;
            }

            return "NO";
        }
        #endregion
    }
}