namespace ExerciseProject.Exercise15x16x17x18x19
{
    public class Book : Merchandise
    {
        public string Title { get; set; }
        public double Price { get; set; }

        public Book (string itemId, string title, double price) : base () {
            ItemId = itemId;
            Title = title;
            Price = price;
        }

        public Book (string itemId, string title) : this (itemId, title, 0) { }

        public Book (string itemId) : this (itemId, "", 0) { }
        
        public string ToString () {
            return "ItemId: " + ItemId + ", Title: " + Title + ", Price: " + Price;
        }
    }
}
