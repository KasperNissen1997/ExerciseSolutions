using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

namespace PetParadise
{
    public class PetRepo
    {
        // private readonly string connectionString = ConfigurationManager.ConnectionStrings["DatabaseServerInstance"].ConnectionString;
        private readonly string connectionString = "Server=10.56.8.36; Database=DB_2023_36; User Id=STUDENT_36; Password=OPENDB_36";

        private List<Pet> pets = new List<Pet>();

        public PetRepo()
        {
            pets = GetAll();
        }

        public int Add(Pet pet)
        {
            // Add new pet to database and to repository
            // Return the database id of the pet

            int result = -1;

            // IMPLEMENT THIS!

            return result;
        }
        public List<Pet> GetAll()
        {
            List<Pet> result = new();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM PETPARADISE_PET", connection);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Pet pet = new()
                        {
                            PetId = int.Parse(dr["PetId"].ToString()),
                            Name = dr["PetName"].ToString(),
                            PetType = (PetTypes) Enum.Parse(typeof(PetTypes), dr["PetType"].ToString()),
                            Breed = dr["PetBreed"].ToString(),
                            Weight = double.Parse(dr["PetWeight"].ToString())
                        };

                        string dob = dr["PetDOB"].ToString();

                        if (!string.IsNullOrEmpty(dob))
                            pet.DOB = DateTime.Parse(dob);
                        else
                            pet.DOB = DateTime.MinValue;

                        result.Add(pet);
                    }
                }
            }

            return result;
        }
        public Pet GetById(int id)
        {
            Pet result = null;

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM PETPARADISE_PET WHERE PetId = @PetId", connection);

                command.Parameters.Add("@PetId", SqlDbType.Int).Value = id;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result = new()
                        {
                            PetId = int.Parse(dr["PetId"].ToString()),
                            Name = dr["PetName"].ToString(),
                            PetType = (PetTypes) Enum.Parse(typeof(PetTypes), dr["PetType"].ToString()),
                            Breed = dr["PetBreed"].ToString(),
                            Weight = double.Parse(dr["PetWeight"].ToString())
                        };

                        string dob = dr["PetDOB"].ToString();

                        if (!string.IsNullOrEmpty(dob))
                            result.DOB = DateTime.Parse(dob);
                    }
                }
            }

            return result;
        }
        public void Update(Pet pet)
        {
            // Update existing pet on database

            // IMPLEMENT THIS!
        }
        public void Remove(Pet pet)
        {
            // Delete existing pet in database

            // IMPLEMENT THIS!
        }
    }
}
