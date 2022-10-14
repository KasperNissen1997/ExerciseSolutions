namespace ExerciseProject.Exercise15x16x17x18x19
{
    public abstract class Merchandise
    {
        public string ItemId { get; set; }

        public override string ToString () {
            return "ItemId: " + ItemId;
        }
    }
}
