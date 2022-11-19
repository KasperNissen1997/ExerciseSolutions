namespace TusindfrydWPF.Models
{
    public class FlowerSort
    {
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public int ProductionTime { get; set; }
        public int HalfLifeTime { get; set; }
        public double Size { get; set; }

        public FlowerSort (string name, string picturePath, int productionTime, int halfLifeTime, double size)
        {
            Name = name;
            PicturePath = picturePath;
            ProductionTime = productionTime;
            HalfLifeTime = halfLifeTime;
            Size = size;
        }

        public string GetTitle () {
            return string.Format($"{0};{1};{2};{3};{4}", Name, PicturePath, ProductionTime, HalfLifeTime, Size);
        }

        public override string ToString () {
            return Name;
        }
    }
}
