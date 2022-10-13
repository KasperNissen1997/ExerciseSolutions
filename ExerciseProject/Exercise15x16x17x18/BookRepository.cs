namespace ExerciseProject.Exercise15x16x17x18
{
    public class BookRepository
    {
        List<Book> books = new List<Book>();

        public void AddBook (Book book) {
            books.Add(book);
        }

        public Book GetBook (string itemId) {
            foreach (Book book in books) {
                if (book.ItemId == itemId) {
                    return book;
                }
            }

            return null;
        }

        public double GetTotalValue () {
            Utility util = new Utility();

            double totalValue = 0;

            foreach (Book book in books) {
                totalValue += util.GetValueOfBook(book);
            }

            return totalValue;
        }
    }
}
