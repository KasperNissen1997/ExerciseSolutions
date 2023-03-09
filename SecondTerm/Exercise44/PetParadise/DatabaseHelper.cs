using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PetParadise
{
    public class DatabaseHelper
    {
        private static readonly string connectionString = "Server=10.56.8.36; Database=DB_2023_36; User Id=STUDENT_36; Password=OPENDB_36";

        public static List<string> GetAllPetNamesOwnedByOwner(string firstName, string lastName)
        {
            List<string> result = new List<string>();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new("SELECT PETPARADISE_PET.PetName FROM " +
                    "PETPARADISE_PET INNER JOIN PETPARADISE_OWNER ON PETPARADISE_PET.OwnerId = PETPARADISE_OWNER.OwnerId " +
                    "WHERE PETPARADISE_OWNER.OwnerFirstName = @OwnerFirstName AND PETPARADISE_OWNER.OwnerLastName = @OwnerLastName;", connection);

                command.Parameters.Add("@OwnerFirstName", SqlDbType.NVarChar).Value = firstName;
                command.Parameters.Add("@OwnerLastName", SqlDbType.NVarChar).Value = lastName;

                using (SqlDataReader dr = command.ExecuteReader())
                    while (dr.Read())
                        result.Add(dr["PetName"].ToString());
            }

            return result;
        }
        public static List<Treatment> GetAllTreatmentsPaidByOwner(string firstName, string lastName)
        {
            List<Treatment> result = new List<Treatment>();

            TreatmentRepo treatRepo = new();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new("SELECT PETPARADISE_TREATMENT.TreatId FROM PETPARADISE_TREATMENT JOIN PETPARADISE_PET " +
                    "ON PETPARADISE_TREATMENT.PetId = PETPARADISE_PET.PetId " +
                    "JOIN PETPARADISE_OWNER " +
                    "ON PETPARADISE_PET.OwnerId = PETPARADISE_OWNER.OwnerId " +
                    "WHERE PETPARADISE_OWNER.OwnerFirstName = @OwnerFirstName AND PETPARADISE_OWNER.OwnerLastName = @OwnerLastName;", connection);

                command.Parameters.Add("@OwnerFirstName", SqlDbType.NVarChar).Value = firstName;
                command.Parameters.Add("@OwnerLastName", SqlDbType.NVarChar).Value = lastName;

                using (SqlDataReader dr = command.ExecuteReader())
                    while (dr.Read())
                        result.Add(treatRepo.GetById(int.Parse(dr["TreatId"].ToString())));
            }

            return result;
        }
    }
}
