namespace TusindfrydWPF.Models
{
    public class FlowerSort
    {
        private static int iDCount = 0;

        public int ID { get; private set; }

        public string Name { get; set; }
        public string PicturePath { get; set; }
        public int ProductionTime { get; set; }
        public int HalfLifeTime { get; set; }
        public double Size { get; set; }

        public FlowerSort (string name, string picturePath, int productionTime, int halfLifeTime, double size)
        {
            ID = iDCount++;

            Name = name;
            PicturePath = picturePath;
            ProductionTime = productionTime;
            HalfLifeTime = halfLifeTime;
            Size = size;
        }

        public string GetTitle () {
            return string.Format($"{Name};{PicturePath};{ProductionTime};{HalfLifeTime};{Size}");
        }

        public override string ToString () {
            return Name;
        }
    }
}
