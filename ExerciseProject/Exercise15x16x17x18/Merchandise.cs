namespace ExerciseProject.Exercise15x16x17x18
{
    public abstract class Merchandise
    {
        public string ItemId { get; set; }

        public override string ToString () {
            return "ItemId: " + ItemId;
        }
    }
}
