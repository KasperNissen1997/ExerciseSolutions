﻿namespace ThreadsSemaphore
{
    class Car
    {
        private string name;
        private string serial;
        public string Name { get { return name; } }
        public string Serial { get { return serial; } }

        public Car(string name, string serial)
        {
            this.name = name;
            this.serial = serial;
        }

        public override string ToString()
        {
            return name + " " + serial;
        }
    }
}
