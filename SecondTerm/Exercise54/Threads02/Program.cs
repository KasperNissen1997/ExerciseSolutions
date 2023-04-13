using System;
using System.Threading;

namespace Threads02
{
    #region First code snippet
    //public class Program
    //{
    //    private readonly object _accumLock = new();

    //    private double accum = 0.0;
    //    private const int WEATHERSTATIONS = 100;
    //    private const int MEASURES = 1000;
    //    private const double VALUE = 1.0;

    //    static void Main(string[] args)
    //    {
    //        Program p = new Program();
    //        p.Run();
    //    }

    //    private void Run()
    //    {
    //        const double EXPECTED = WEATHERSTATIONS * MEASURES * VALUE;

    //        for (int i = 0; i < 10; i++)
    //        {
    //            accum = 0.0;
    //            double result = Measure();

    //            if (result != EXPECTED)
    //                Console.WriteLine("ERROR: " + (EXPECTED - result));
    //        }

    //        Console.Write("Press a key ..."); 
    //        Console.ReadKey();
    //    }

    //    private double Measure()
    //    {
    //        Thread[] threads = new Thread[WEATHERSTATIONS];

    //        for (int i = 0; i < WEATHERSTATIONS; i++)
    //        {
    //            threads[i] = new Thread(Sensor);
    //            threads[i].Start();
    //        }

    //        // Do not join until all threads are started
    //        for (int i = 0; i < WEATHERSTATIONS; i++)
    //            threads[i].Join();

    //        return accum;
    //    }

    //    private void Sensor()
    //    {
    //        for (int i = 0; i < MEASURES; i++)
    //        {
    //            lock (_accumLock)
    //            {
    //                double temp = accum;

    //                // Do some work 
    //                // Thread.Sleep(1);

    //                accum = temp + VALUE;
    //            }
    //        }
    //    }
    //}
    #endregion

    #region Second code snippet
    //class Program
    //{
    //    private const int ITERATIONS = 1000000;
    //    private Int64 _number;
    //    public Int64 Number 
    //    { 
    //        get 
    //        { 
    //            return _number; 
    //        } 

    //        set 
    //        { 
    //            _number = value; 
    //        } 
    //    }

    //    static void Main(string[] args)
    //    {
    //        Program p = new Program();
    //        p.Run();
    //    }

    //    private void Run()
    //    {
    //        Number = 0;
    //        Thread adder = new Thread(Add);
    //        Thread subtractor = new Thread(Subtract);

    //        adder.Start();
    //        subtractor.Start();
    //        adder.Join();
    //        subtractor.Join();

    //        Console.Write($"Number: {Number}. \t\tPress any key...");
    //        Console.ReadKey();
    //    }

    //    private void Add()
    //    {
    //        for (int i = 0; i < ITERATIONS; i++)
    //        {
    //            Interlocked.Increment(ref _number);
    //        }
    //    }

    //    private void Subtract()
    //    {
    //        for (int i = 0; i < ITERATIONS; i++)
    //        {
    //            Interlocked.Decrement(ref _number);
    //        }
    //    }
    //}
    #endregion

    #region Third code snippet
    class Program
    {
        static void Main(string[] args)
        {
            Program myprogram = new Program();
            myprogram.run();
        }

        public void run()
        {
            Console.WriteLine("Start");

            Buffer buffer = new Buffer(50);

            Producer producer1 = new Producer("Opel", buffer);
            Producer producer2 = new Producer("Audi", buffer);
            Consumer consumer1 = new Consumer("Forhandler 1", buffer);
            Consumer consumer2 = new Consumer("Forhandler 2", buffer);
            Consumer consumer3 = new Consumer("Forhandler 3", buffer);

            Thread tp1 = new Thread(producer1.Run);
            Thread tp2 = new Thread(producer2.Run);
            Thread tc1 = new Thread(consumer1.Run);
            Thread tc2 = new Thread(consumer2.Run);
            Thread tc3 = new Thread(consumer3.Run);

            System.Console.WriteLine("\nEnter for consumer 1 start");
            System.Console.ReadLine();
            tc1.Start();

            System.Console.WriteLine("\nEnter for producer 1 start");
            System.Console.ReadLine();
            tp1.Start();

            System.Console.WriteLine("\nEnter for consumer 2 start");
            System.Console.ReadLine();
            tc2.Start();

            System.Console.WriteLine("\nEnter for producer 2 start");
            System.Console.ReadLine();
            tp2.Start();

            System.Console.WriteLine("\nEnter for consumer 3 start");
            System.Console.ReadLine();
            tc3.Start();

            System.Console.WriteLine("\nStop tråde");
            System.Console.ReadLine();

            producer1.SignalStop();
            producer2.SignalStop();
            consumer1.SignalStop();
            consumer2.SignalStop();
            consumer3.SignalStop();

            tp1.Join();
            tp2.Join();
            tc1.Join();
            tc2.Join();
            tc3.Join();
            System.Console.WriteLine("\nEnter for Exit");
            System.Console.ReadLine();
            System.Console.WriteLine("Exit");
        }
    }
    #endregion
}