using System;
using System.Collections.Generic;
using System.IO;
using TheMovies.MVVM.Models;

namespace TheMovies.MVVM.ViewModels.Persistence
{
    public class MovieRepository
    {
        #region Singleton Pattern
        private static MovieRepository _instance;
        public static MovieRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MovieRepository();

                return _instance;
            }
        }

        private MovieRepository()
        {
            Load();
        }
        #endregion

        private readonly string filePath = Path.GetFullPath("../../../Data/Movies.csv");

        private List<Movie> movies { get; set; } = new();

        #region Persistance
        public void Load()
        {
            if (!File.Exists(filePath))
                return;

            using (StreamReader sr = new(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string readLine = sr.ReadLine();
                    string[] splitLine = readLine.Split(';');

                    string title = splitLine[0];
                    string genres = splitLine[1];
                    TimeSpan duration = TimeSpan.Parse(splitLine[2]);
                    string instructor = splitLine[3];
                    DateOnly premiereDate = DateOnly.Parse(splitLine[4]);

                    Create(title, genres, duration, instructor, premiereDate);
                }
            }
        }

        public void Save()
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            using (StreamWriter sw = new(filePath))
            {
                foreach (Movie movie in movies)
                {
                    sw.WriteLine(movie.ToString());
                }
            }
        }
        #endregion

        #region CRUD
        public Movie Create(string title, string genres, TimeSpan duration, string instructor, DateOnly premiereDate)
        {
            Movie movie = new(title, genres, duration, instructor, premiereDate);

            movies.Add(movie);

            return movie;
        }

        public List<Movie> RetrieveAll()
        {
            return new(movies);
        }

        public void Delete(Movie movie)
        {
            if (movies.Contains(movie))
                movies.Remove(movie);
        }
        #endregion
    }
}
