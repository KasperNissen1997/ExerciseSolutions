using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProject.Exercise15And16And17
{
    public class Utility
    {
        public double GetValueOfBook (Book book) {
            return book.Price;
        }

        public double GetValueOfAmulet (Amulet amulet) {
            switch (amulet.Quality) {
                case Level.low:
                    return 12.5;
                case Level.medium:
                    return 20;
                case Level.high:
                    return 27.5;
                default:
                    return 0;
            }
        }
    }
}
