namespace ExerciseProject.Exercise9x10
{
    public class OrangeTree
    {
        private int _age;
        public int Age { 
            get { return _age; } 
            set { _age = (value < 0) ? 0 : value; } 
        }

        private int _height;
        public int Height {
            get { return _height; }
            set { _height = value; }
        }

        private bool _treeAlive;
        public bool TreeAlive {
            get { return _treeAlive; }
            set { _treeAlive = value; } 
        }

        private int _numOranges;
        public int NumOranges { 
            get { return _numOranges; }
            private set { _numOranges = value; } 
        }

        private int _orangesEaten;
        public int OrangesEaten { 
            get { return _orangesEaten; }
            private set { _orangesEaten = value; } 
        }

        
        public void OneYearPasses () {
            Age++;
            OrangesEaten = 0;

            if (Age >= 80)
                TreeAlive = false;

            if (TreeAlive) {
                Height += 2;
                NumOranges = (Age - 1) * 5;
            }
            else {
                NumOranges = 0;
            }
        }

        public void EatOrange (int count) {
            if (count <= NumOranges) {
                OrangesEaten += count;
                NumOranges -= count;
            } 
            else {
                Console.Write("This shit wack yo, no oranges can feed you you glutton!");
            }
        }
    }
}
