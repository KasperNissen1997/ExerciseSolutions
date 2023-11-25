using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        private const int MAX_HASH_VALUE = 99;
        private const int HASH_VALUE_LENGTH = 2;


        static void Main(string[] args)
        {
            Program program = new();
            program.Run();

            Console.ReadKey(true);
        }

        private void Run()
        {
            bool running = true;
            Console.WriteLine("Enter a password and get the hashed value.");
            while (running)
            {
                Console.Write("Enter password ('q' to end) : ");
                string answer = Console.ReadLine();
                if (answer.Equals("q"))
                {
                    running = false;
                    Console.WriteLine("Bye");
                }
                else
                {
                    Console.WriteLine("Provided hashing algorithm: " + PadZero(ProvidedGetHashValue(answer), HASH_VALUE_LENGTH));
                    Console.WriteLine("Personal hashing algorithm: " + PadZero(PersonalGetHashValue(answer), HASH_VALUE_LENGTH));
                }
            }
        }

        public string PadZero(int value, int length)
        {
            string result = value.ToString();
            for (int idx = 0; result.Length < HASH_VALUE_LENGTH; idx++)
            {
                result = "0" + result;
            }
            return result;
        }

        /// <summary>
        /// The provided implemtnation of a weak hashing algorithm.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>A hash of the password, in the form of an integer between 0 and 99.</returns>
        public int ProvidedGetHashValue(string password)
        {
            int result = 0;
            for (int i = 0; i < password.Length; i++)
            {
                result += Convert.ToInt16(password[i] * i);
            }
            return result % (MAX_HASH_VALUE + 1);
        }

        /// <summary>
        /// My custom implementation of a weak hashing algorithm.
        /// </summary>
        /// <param name="secret">The string to hash.</param>
        /// <returns>A hash of secret, in the form of an integer between 0 and 99.</returns>
        public int PersonalGetHashValue(string secret)
        {
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(secret));
            int hashValue = BitConverter.ToInt32(hashBytes, 0);
            hashValue %= 100;

            if (hashValue < 0)
                hashValue *= -1;

            return hashValue;
        }
    }
}
