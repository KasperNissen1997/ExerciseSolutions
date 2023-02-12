using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.MVVM.ViewModels
{
    public class AddMovieViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int DurationHours { get; set; }
        public int DurationMinutes { get; set; }
        public string Instructor { get; set; }
        public DateTime PremiereDateTime { get; set; }

        public AddMovieViewModel()
        {
            PremiereDateTime = DateTime.Now;
        }
    }
}
