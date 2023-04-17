namespace ThreadsSemaphore
{
    class Buffer
    {
        private int capacity;
        private Queue<Car> bufferData;

        private SemaphoreSlim bufferElementsSemaphore;
        private SemaphoreSlim bufferQueueSemaphore;

        public Buffer(int capacity)
        {
            this.capacity = capacity;
            bufferData = new Queue<Car>();

            bufferElementsSemaphore = new(1);
            bufferQueueSemaphore = new(capacity);
        }

        public void Put(Car car)
        {
            while (IsFull())
                bufferQueueSemaphore.Wait();

            // Add a car to the queue
            bufferData.Enqueue(car);

            if (bufferData.Count > capacity)
                throw new ArgumentException("Køen er fuld");

            bufferQueueSemaphore.Release();
        }

        public Car Get()
        {
            Car car = null;

            while (IsEmpty())
                bufferQueueSemaphore.Wait();

            car = bufferData.Dequeue();

            bufferQueueSemaphore.Release();

            return car;
        }

        public bool IsEmpty()
        {
            bool isEmpty;

            bufferElementsSemaphore.Wait();

            isEmpty = bufferData.Count == 0;

            bufferElementsSemaphore.Release();

            return isEmpty;
        }

        public bool IsFull()
        {
            bool isFull;

            bufferElementsSemaphore.Wait();

            isFull = bufferData.Count == capacity;

            bufferElementsSemaphore.Release();

            return isFull;
        }
    }
}
