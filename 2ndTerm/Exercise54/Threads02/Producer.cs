﻿namespace Threads02
{
    class Producer
    {
        private string name;
        private bool stop = false;
        private Buffer buffer;

        private Random randomGenerator = new((int) DateTime.Now.Ticks);
        private int count = 0;

        public Producer(string name, Buffer buffer)
        {
            this.name = name;
            this.buffer = buffer;
        }

        public void Run()
        {
            while (!stop)
            {
                ++count;
                Car car = new Car(name, count.ToString());
                System.Console.WriteLine("Produce:" + car);
                buffer.Put(car);

                Thread.Sleep(randomGenerator.Next(50, 1500));
            }
        }

        public void SignalStop()
        {
            stop = true;
        }
    }
}
