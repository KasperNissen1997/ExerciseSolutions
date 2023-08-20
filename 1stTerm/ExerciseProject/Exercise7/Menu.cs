namespace ExerciseProject.Exercise7
{
    internal class Menu
    {
        public string title;

        MenuItem[] menuItems = new MenuItem[15];
        int itemCount;

        public Menu (string title) {
            this.title = title;
        }

        public void Show () {
            Console.WriteLine(title);
            Console.WriteLine();
            
            for (int i = 0; i < itemCount; i++) {
                Console.WriteLine("  " + i + ": " + menuItems[i].title);
            }
            Console.WriteLine();

            Console.Write("Tryk menupunkt eller 0 for at afslutte: ");
        }

        public void AddMenuItem (string menuTitle) {
            MenuItem mi = new MenuItem(menuTitle);
            menuItems[itemCount] = mi;
            itemCount++;
        }

        public int SelectMenuItem () {
            string input = Console.ReadLine();

            if (input == "") {
                Console.Write("Der blev ikke indtastet noget input."
                    + "\n"
                    + "Lad os prøve igen: ");
                return SelectMenuItem();
            }

            if (!int.TryParse(input, out int selection)) {
                Console.Write("Der må have været noget der gik galt da inputtet skulle converteres til et heltal.\n"
                    + "Vær venlig at sikre at det indtastede svarer til et heltal i nummerform, som \"2\" eller \"4\".\n"
                    + "\n"
                    + "Lad os prøve igen: ");
                return SelectMenuItem();
            }

            if (selection < 0 || selection > itemCount) {
                Console.Write("Vær venlig kun at indtaste tal mellem 0 og " + itemCount + ".\n"
                    + "\n"
                    + "Lad os prøve igen: ");
                return SelectMenuItem();
            }

            Console.WriteLine();

            return selection;
        }
    }
}
