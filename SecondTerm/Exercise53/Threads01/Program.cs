namespace Threads01
{
    public class Program
    {
        private object _myLock = new();

        private char _sharedChar;
        private const int SIMULATE_WORK = 100;

        static void Main(string[] args)
        {
            // Method
            Thread methodThread = new(PrintHelloWorld);

            // Lambda
            Thread lambdaThread = new((message) =>
            {
                for (int i = 0; i < 4; i++)
                    Console.WriteLine(message);
            });

            // Anonymous method
            Thread anonymousThread = new Thread(delegate (object? message)
            {
                for (int i = 0; i < 4; i++)
                    Console.WriteLine(message ?? "");
            });

            methodThread.Start("Hello world (Method)");
            lambdaThread.Start("Hello world (Lambda)");
            anonymousThread.Start("Hello world (Anonymous method)");

            Program p = new();
            p.Run();
        }

        private static void PrintHelloWorld(object message)
        {
            for (int i = 0; i < 4; i++)
                Console.WriteLine(message.ToString());
        }

        public void Run()
        {
            Thread tA = new Thread(WriteA);
            Thread tB = new Thread(WriteB);
            tA.Name = "Thread A";
            tB.Name = "Thread B";
            tA.Start();
            tB.Start();
            tA.Join();
            tB.Join();
            Console.Write("\nPress a key ....");
            Console.ReadKey();
        }

        private void WriteA()
        {
            for (int i = 0; i < 10; i++)
            {
                
                lock (_myLock)
                {
                    _sharedChar = 'A';
                    Thread.Sleep(SIMULATE_WORK);
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {_sharedChar}");
                }

                Thread.Yield();
            }
        }

        private void WriteB()
        {
            for (int i = 0; i < 10; i++)
            {
                lock (_myLock)
                {
                    _sharedChar = 'B';
                    Thread.Sleep(SIMULATE_WORK);
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {_sharedChar}");
                }
                
                Thread.Yield();
            }
        }
    }
}
