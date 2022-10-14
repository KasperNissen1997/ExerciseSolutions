namespace ExerciseProject.Exercise15x16x17x18x19
{
    public class Amulet : Merchandise
    {
        public string Design { get; set; }
        public Level Quality { get; set; }

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
    }
}
