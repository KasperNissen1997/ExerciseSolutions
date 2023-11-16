using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new();

            int hash1 = program.GetHashValue("mitKodeord");
            int hash2 = program.GetHashValue("mitAndetKodeord");
            int hash21 = program.GetHashValue("mitAndetKodeord");
            int hash3 = program.GetHashValue("mitTredjeKodeord");
            int hash4 = program.GetHashValue("mitFjerdeKodeord");
            int hash5 = program.GetHashValue("mitFemteKodeord");

            Console.WriteLine("Hello, World!");
        }

        public int GetHashValue(string password)
        {
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            int hashValue = BitConverter.ToInt32(hashBytes, 0);
            hashValue %= 100;

            if (hashValue < 0)
                hashValue *= -1;

            return hashValue;
        }
    }
}
