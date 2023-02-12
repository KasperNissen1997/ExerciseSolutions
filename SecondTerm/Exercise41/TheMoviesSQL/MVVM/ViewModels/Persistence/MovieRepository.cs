using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using TheMoviesSQL.MVVM.Models;
using System.Configuration;
using System.Runtime.ConstrainedExecution;
using System.Windows;
using System.Windows.Controls;

namespace TheMoviesSQL.MVVM.ViewModels.Persistence
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

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DatabaseServerInstance"].ConnectionString;

        private List<Movie> movies = new();

        #region Persistance
        private void Load()
        {
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT MovieId, Title, Genre, Duration, Instructor, PremiereDate from MOVIE", connection);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int identifier = int.Parse(dr["MovieId"].ToString());
                        string title = dr["Title"].ToString();
                        string genre = dr["Genre"].ToString();
                        TimeSpan duration = TimeSpan.Parse(dr["Duration"].ToString());
                        string instructor = dr["Instructor"].ToString();
                        DateTime premiereDateTime = DateTime.Parse(dr["PremiereDate"].ToString());

                        movies.Add(new(identifier, title, genre, duration, instructor, premiereDateTime));
                    }
                }
            }
        }
        #endregion

        #region CRUD
        public Movie Create(string title, string genre, TimeSpan duration, string instructor, DateTime premiereDateTime)
        {
            Movie movie;

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new("INSERT INTO MOVIE (Title, Genre, Duration, Instructor, PremiereDate) VALUES (@Title, @Genre, @Duration, @Instructor, @PremiereDate) SELECT @@IDENTITY", connection);

                command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                command.Parameters.Add("@Genre", SqlDbType.NVarChar).Value = genre;
                command.Parameters.Add("@Duration", SqlDbType.Time).Value = duration;
                command.Parameters.Add("@Instructor", SqlDbType.NVarChar).Value = instructor;
                command.Parameters.Add("@PremiereDate", SqlDbType.DateTime2).Value = premiereDateTime;

                int identifier = Convert.ToInt32(command.ExecuteScalar());

                movie = new(identifier, title, genre, duration, instructor, premiereDateTime);

                movies.Add(movie);
            }

            return movie;
        }

        public List<Movie> RetrieveAll()
        {
            return new(movies);
        }

        public Movie Retrieve(int identifier)
        {
            foreach (Movie movie in movies)
                if (movie.Identifier == identifier)
                    return movie;

            return null;
        }

        public void Update(Movie movie)
        {
            if (!movies.Contains(movie))
                return;

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new("UPDATE MOVIE SET Title=@Title, Genre=@Genre, Duration=@Duration, Instructor=@Instructor, PremiereDate=@PremiereDate WHERE MovieId=@Identifier", connection);

                command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = movie.Title;
                command.Parameters.Add("@Genre", SqlDbType.NVarChar).Value = movie.Genre;
                command.Parameters.Add("@Duration", SqlDbType.Time).Value = movie.Duration;
                command.Parameters.Add("@Instructor", SqlDbType.NVarChar).Value = movie.Instructor;
                command.Parameters.Add("@PremiereDate", SqlDbType.DateTime2).Value = movie.PremiereDateTime;
                command.Parameters.Add("@Identifier", SqlDbType.Int).Value = movie.Identifier;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Movie movie)
        {
            if (!movies.Contains(movie))
                return;

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new("SELECT DisplayId FROM DISPLAY WHERE MovieId=@MovieIdentifier", connection);
                command.Parameters.Add("@MovieIdentifier", SqlDbType.Int).Value = movie.Identifier;

                List<int> displayIdentifiers = new();
                using (SqlDataReader dr = command.ExecuteReader())
                    while (dr.Read())
                        displayIdentifiers.Add(int.Parse(dr["DisplayId"].ToString()));

                SqlParameter displayIdentifierParameter = command.CreateParameter();
                displayIdentifierParameter.ParameterName = "@DisplayIdentifier";
                displayIdentifierParameter.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(displayIdentifierParameter);

                foreach (int displayIdentifier in displayIdentifiers)
                {
                    displayIdentifierParameter.Value = displayIdentifier;

                    command.CommandText = "DELETE FROM HALL_DISPLAY WHERE DisplayId=@DisplayIdentifier";
                    command.ExecuteNonQuery();

                    command.CommandText = "DELETE FROM BOOKING WHERE DisplayId=@DisplayIdentifier";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "DELETE FROM DISPLAY WHERE MovieId=@MovieIdentifier";
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM MOVIE WHERE MovieId=@MovieIdentifier";
                command.ExecuteNonQuery();
            }
            
            movies.Remove(movie);
        }
        #endregion
    }
}
