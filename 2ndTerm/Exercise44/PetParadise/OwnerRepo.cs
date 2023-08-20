using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PetParadise
{
    public class OwnerRepo
    {
        // private readonly string connectionString = ConfigurationManager.ConnectionStrings["DatabaseServerInstance"].ConnectionString;
        private readonly string connectionString = "Server=10.56.8.36; Database=DB_2023_36; User Id=STUDENT_36; Password=OPENDB_36";

        private List<Owner> owners = new List<Owner>();

        public OwnerRepo()
        {
            owners = GetAll();
        }

        public int Add(Owner owner)
        {
            // Add new owner to database and to repository
            // Return the database id of the owner

            int result = -1;

            // IMPLEMENT THIS!

            return result;
        }
        public List<Owner> GetAll()
        {
            List<Owner> result = new();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM PETPARADISE_OWNER", connection);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Owner owner = new()
                        {
                            OwnerId = int.Parse(dr["OwnerId"].ToString()),
                            FirstName = dr["OwnerFirstName"].ToString(),
                            LastName = dr["OwnerLastName"].ToString(),
                            Email = dr["OwnerEmail"].ToString()
                        };

                        string phone = dr["OwnerPhone"].ToString();

                        if (!string.IsNullOrEmpty(phone))
                            owner.Phone = phone;

                        result.Add(owner);
                    }
                }
            }

            return result;
        }
        public Owner GetById(int id)
        {
            Owner result = null;

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM PETPARADISE_OWNER WHERE OwnerId = @OwnerId", connection);

                command.Parameters.Add("@OwnerId", SqlDbType.Int).Value = id;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result = new()
                        {
                            OwnerId = int.Parse(dr["OwnerId"].ToString()),
                            FirstName = dr["OwnerFirstName"].ToString(),
                            LastName = dr["OwnerLastName"].ToString(),
                            Email = dr["OwnerEmail"].ToString()
                        };

                        string phone = dr["OwnerPhone"].ToString();

                        if (!string.IsNullOrEmpty(phone))
                            result.Phone = phone;
                    }
                }
            }

            return result;
        }
        public void Update(Owner owner)
        {
            // Update existing owner on database

            // IMPLEMENT THIS!
        }
        public void Remove(Owner owner)
        {
            // Delete existing owner in database

            // IMPLEMENT THIS!
        }

    }
}
