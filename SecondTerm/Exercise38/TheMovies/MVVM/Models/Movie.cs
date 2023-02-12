using System;
using System.Text;

namespace TheMoviesSQL.MVVM.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Genres { get; set; }
        public TimeSpan Duration { get; set; }
        public string Instructor { get; set; }
        public DateOnly PremiereDate { get; set; }

        public Movie(string title, string genres, TimeSpan duration, string instructor, DateOnly premiereDate)
        {
            Title = title;
            Genres = genres;
            Duration = duration;
            Instructor = instructor;
            PremiereDate = premiereDate;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Title + ";");
            sb.Append(Genres + ";");
            sb.Append(Duration + ";");
            sb.Append(Instructor + ";");
            sb.Append(PremiereDate);

            return sb.ToString();
        }
    }
}
