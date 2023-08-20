using ModelPersistence.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPersistence.Persistence
{
    public class SubstituteOrderRepository : Repository
    {
        private List<SubstituteOrder> orders;

        public SubstituteOrderRepository()
        {
            Load();
        }

        protected override void Load()
        {
            orders = RetrieveAll();
        }

        protected override void Save()
        {
            throw new NotImplementedException();
        }

        public SubstituteOrder Create(int hours, int schoolPhone)
        {
            SchoolRepository schoolRepo = new();

            SubstituteOrder order;

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new("INSERT INTO LÆRERVIKAREN_SUBSTITUTE_ORDER (Hours, Phone) VALUES (@hours, @schoolPhone) SELECT @@IDENTITY", connection);

                command.Parameters.Add("@hours", SqlDbType.Int).Value = hours;
                command.Parameters.Add("@schoolPhone", SqlDbType.Int).Value = schoolPhone;

                int identifier = Convert.ToInt32(command.ExecuteScalar());

                School school = schoolRepo.Retrieve(schoolPhone);

                order = new(identifier, hours, school);

                orders.Add(order);
            }

            return order;
        }

        public List<SubstituteOrder> RetrieveAll()
        {
            SchoolRepository schoolRepo = new();

            List<SubstituteOrder> result = new();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM LÆRERVIKAREN_SUBSTITUTE_ORDER", connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int identifier = int.Parse(dataReader["OrderId"].ToString());
                        int hours = int.Parse(dataReader["Hours"].ToString());
                        int schoolPhone = int.Parse(dataReader["Phone"].ToString());

                        School school = schoolRepo.Retrieve(schoolPhone);

                        SubstituteOrder order = new(identifier, hours, school);

                        result.Add(order);
                    }
                }
            }

            return result;
        }

        public SubstituteOrder Retrieve(int identifier)
        {
            foreach (SubstituteOrder substituteOrder in orders)
                if (substituteOrder.Identifier == identifier)
                    return substituteOrder;

            return null;
        }

        public void Update(SubstituteOrder order)
        {
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new("UPDATE TABLE LÆRERVIKAREN_SUBSTITUTE_ORDER SET Hours = @hours WHERE OrderId = @identifier", connection);

                command.Parameters.Add("@hours", SqlDbType.Int).Value = order.Hours;
                command.Parameters.Add("@identifier", SqlDbType.Int).Value = order.Identifier;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(SubstituteOrder order)
        {
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                SqlCommand command = new("DELETE FROM LÆRERVIKAREN_SUBSTITUE_ORDER WHERE OrderId = @identifier", connection);

                command.Parameters.Add("@identifier", SqlDbType.Int).Value = order.Identifier;

                command.ExecuteNonQuery();

                orders.Remove(order);
            }
        }
    }
}
