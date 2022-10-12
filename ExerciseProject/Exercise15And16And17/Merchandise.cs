namespace ExerciseProject.Exercise15And16And17
{
    public abstract class Merchandise
    {
        public string ItemId { get; set; }

        public override string ToString () {
            return "ItemId: " + ItemId;
        }
    }
}
