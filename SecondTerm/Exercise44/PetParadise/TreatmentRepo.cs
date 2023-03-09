using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PetParadise
{
    public class TreatmentRepo
    {
        // private readonly string connectionString = ConfigurationManager.ConnectionStrings["DatabaseServerInstance"].ConnectionString;
        private readonly string connectionString = "Server=10.56.8.36; Database=DB_2023_36; User Id=STUDENT_36; Password=OPENDB_36";

        private List<Treatment> treatments = new List<Treatment>();

        public TreatmentRepo()
        {
            treatments = GetAll();
        }

        public int Add(Treatment treatment)
        {
            // Add new treatment to database and to repository
            // Return the database id of the treatment

            int result = -1;

            // IMPLEMENT THIS!

            return result;
        }

        public List<Treatment> GetAll()
        {
            List<Treatment> result = new();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM PETPARADISE_TREATMENT", connection);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Treatment treatment = new()
                        {
                            TreatId = int.Parse(dr["TreatId"].ToString()),
                            Service = dr["TreatService"].ToString(),
                            Date = DateTime.Parse(dr["TreatDate"].ToString()),
                            Charge = double.Parse(dr["TreatCharge"].ToString())
                        };

                        result.Add(treatment);
                    }
                }
            }

            return result;
        }
        public Treatment GetById(int id)
        {
            Treatment result = null;

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM PETPARADISE_TREATMENT WHERE TreatId = @TreatId", connection);

                command.Parameters.Add("@TreatId", SqlDbType.Int).Value = id;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result = new()
                        {
                            TreatId = int.Parse(dr["TreatId"].ToString()),
                            Service = dr["TreatService"].ToString(),
                            Date = DateTime.Parse(dr["TreatDate"].ToString()),
                            Charge = double.Parse(dr["TreatCharge"].ToString())
                        };
                    }
                }
            }

            return result;
        }
        public void Update(Treatment treatment)
        {
            // Update existing treatment on database

            // IMPLEMENT THIS!
        }
        public void Remove(Treatment treatment)
        {
            // Delete existing treatment in database

            // IMPLEMENT THIS!
        }
    }
}
