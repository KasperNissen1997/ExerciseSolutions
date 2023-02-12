namespace ExerciseProject.Exercise15x16x17x18x19
{
    public class Amulet : Merchandise
    {
        public string Design { get; set; }
        public Level Quality { get; set; }

        static public double LowQualityValue { get; set; } = 12.5;
        static public double MediumQualityValue { get; set; } = 20.0;
        static public double HighQualityValue { get; set; } = 27.5;

        public Amulet (string itemId, Level quality, string design) : base () {
            ItemId = itemId;
            Design = design;
            Quality = quality;
        }

        public Amulet (string itemId, Level quality) : this (itemId, quality, "") { }

        public Amulet (string itemId) : this (itemId, Level.medium, "") { }

        public override string ToString() {
            return "ItemId: " + ItemId + ", Quality: " + Quality + ", Design: " + Design;
        }

        public override double GetValue() {
            switch (Quality) {
                case Level.low:
                    return LowQualityValue;
                case Level.medium:
                    return MediumQualityValue;
                case Level.high:
                    return HighQualityValue;
                default:
                    return 0;
            }
        }
    }
}
