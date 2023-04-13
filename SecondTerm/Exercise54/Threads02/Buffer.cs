namespace Threads02
{
    class Buffer
    {
        private Queue<Car> bufferData;
        private int capacity;

        private object bufferLock = new();
        private bool _isBufferLockTaken;

        public Buffer(int capacity)
        {
            this.capacity = capacity;
            bufferData = new Queue<Car>();
        }

        public void Put(Car car)
        {
            Monitor.Enter(bufferLock);
            
            try
            {
                while (IsFull())
                    Monitor.Wait(bufferLock);

                // Add a car to the queue
                bufferData.Enqueue(car);

                if (bufferData.Count > capacity)
                    throw new System.ArgumentException("Køen er fuld");

                Monitor.Pulse(bufferLock);
            }
            finally
            {
                Monitor.Exit(bufferLock);
            }
        }

        public Car Get()
        {
            Car car = null;

            Monitor.Enter(bufferLock);
            
            try
            {
                while (IsEmpty())
                    Monitor.Wait(bufferLock);

                car = bufferData.Dequeue();

                Monitor.Pulse(bufferLock);
            }
            finally
            {
                Monitor.Exit(bufferLock);
            }

            return car;
        }

        public bool IsEmpty()
        {
            bool isEmpty;

            lock (bufferLock)
                isEmpty = bufferData.Count == 0;

            return isEmpty;
        }

        public bool IsFull()
        {
            bool isFull;

            lock (bufferLock)
                isFull = bufferData.Count == capacity;

            return isFull;
        }
    }
}
