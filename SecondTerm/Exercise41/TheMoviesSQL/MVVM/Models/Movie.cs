using System;
using System.Text;

namespace TheMoviesSQL.MVVM.Models
{
    public class Movie
    {
        public int Identifier { get; }

        public string Title { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration { get; set; }
        public string Instructor { get; set; }
        public DateTime PremiereDateTime { get; set; }

        public Movie(int identifier, string title, string genre, TimeSpan duration, string instructor, DateTime premiereDateTime)
        {
            Identifier = identifier;

            Title = title;
            Genre = genre;
            Duration = duration;
            Instructor = instructor;
            PremiereDateTime = premiereDateTime;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Title + ";");
            sb.Append(Genre + ";");
            sb.Append(Duration + ";");
            sb.Append(Instructor + ";");
            sb.Append(PremiereDateTime);

            return sb.ToString();
        }
    }
}
