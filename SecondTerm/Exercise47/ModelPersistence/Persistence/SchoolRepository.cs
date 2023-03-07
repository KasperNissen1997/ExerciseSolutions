using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelPersistence.Models;

namespace ModelPersistence.Persistence
{
    public class SchoolRepository : Repository
    {
        private List<School> schools;

        public SchoolRepository()
        {
            Load();
        }

        protected override void Load()
        {
            schools = RetrieveAll();
        }

        protected override void Save()
        {
            throw new NotImplementedException();
        }

        public School Create(string phone, string name, string address)
        {
            School school;

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new("INSERT INTO LÆRERVIKAREN_SCHOOL (Phone, Name, Address) VALUES (@phone, @name, @address)", connection);

                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;

                command.ExecuteNonQuery();

                school = new(phone, name, address);

                schools.Add(school);
            }

            return school;
        }

        public List<School> RetrieveAll()
        {
            List<School> result = new();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM LÆRERVIKAREN_SCHOOL", connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string phone = dataReader["Phone"].ToString();
                        string name = dataReader["Name"].ToString();
                        string address = dataReader["Address"].ToString();

                        School school = new(phone, name, address);

                        result.Add(school);
                    }
                }
            }

            return result;
        }

        public School Retrieve(string phoneNumber)
        {
            foreach (School school in schools)
                if (school.Phone == phoneNumber)
                    return school;

            return null;
        }

        public void Update(School school)
        {
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new("UPDATE TABLE LÆRERVIKAREN_SCHOOL SET Name = @name, Address = @address WHERE Phone = @phone", connection);
               
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = school.Name;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = school.Address;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(School school)
        {
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new("DELETE FROM LÆRERVIKAREN_SUBSTITUTE_ORDER WHERE Phone = @phone", connection);

                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = school.Phone;

                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM LÆRERVIKAREN_SCHOOL WHERE Phone = @phone";

                command.ExecuteNonQuery();

                schools.Remove(school);
            }
        }
    }
}
