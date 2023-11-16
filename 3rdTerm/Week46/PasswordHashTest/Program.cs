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
            int hash3 = program.GetHashValue("mitTredjeKodeord");
            int hash4 = program.GetHashValue("mitFjerdeKodeord");
            int hash5 = program.GetHashValue("mitFemteKodeord");

            Console.WriteLine($"Expected hash: 71 | Actual hash: {hash1} | Hashed value: \"mitKodeord\"");
            Console.WriteLine($"Expected hash: 75 | Actual hash: {hash2} | Hashed value: \"mitAndetKodeord\"");
            Console.WriteLine($"Expected hash: 47 | Actual hash: {hash3} | Hashed value: \"mitTredjeKodeord\"");
            Console.WriteLine($"Expected hash: 35 | Actual hash: {hash4} | Hashed value: \"mitFjerdeKodeord\"");
            Console.WriteLine($"Expected hash: 7  | Actual hash: {hash5}  | Hashed value: \"mitFemteKodeord\"");
            Console.ReadKey(true);
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
