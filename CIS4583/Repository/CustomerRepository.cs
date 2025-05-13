using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using CIS4583.Model;
using CIS4583.IRepository;

namespace CIS4583.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ProductConnection");
        }

        public Customer Customer_Select(Customer _Customer)
        {
            Customer customer = null;
            using (var connection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("usp_Customer_Select", connection) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@CustomerID", _Customer.CustomerId);
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        customer = MapDataReaderToCustomer(reader);
                }
            }
            return customer;
        }

        public List<Customer> Customer_SelectList()
        {
            var list = new List<Customer>();
            using (var connection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("usp_Customer_SelectList", connection) { CommandType = CommandType.StoredProcedure })
            {
                connection.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                        list.Add(MapDataReaderToCustomer(reader));
                }
            }
            return list;
        }

        public bool Customer_Insert(Customer customer)
        {
            int affected;
            using (var connection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("INSERT INTO Customer (FirstName, MiddleName, LastName, Street, City, State, Zip) VALUES (@FirstName, @MiddleName, @LastName, @Street, @City, @State, @Zip)", connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", customer.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Street", customer.Street ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@City", customer.City ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@State", customer.State ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Zip", customer.Zip ?? (object)DBNull.Value);

                connection.Open();
                affected = cmd.ExecuteNonQuery();
            }
            return affected > 0;
        }

        public bool Customer_Update(Customer customer)
        {
            int affected;
            using (var connection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("usp_Customer_Update", connection) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerId);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", (object)customer.MiddleName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Street", (object)customer.Street ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@City", (object)customer.City ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@State", (object)customer.State ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Zip", (object)customer.Zip ?? DBNull.Value);

                connection.Open();
                affected = cmd.ExecuteNonQuery();
            }
            return affected > 0;
        }

        public bool Customer_Delete(Customer customer)
        {
            int affected;
            using (var connection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("usp_Customer_Delete", connection) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerId);
                connection.Open();
                affected = cmd.ExecuteNonQuery();
            }
            return affected > 0;
        }

        private static Customer MapDataReaderToCustomer(SqlDataReader reader)
        {
            return new Customer
            {
                CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                MiddleName = reader.IsDBNull(reader.GetOrdinal("MiddleName"))
                                 ? null
                                 : reader.GetString(reader.GetOrdinal("MiddleName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                Street = reader.IsDBNull(reader.GetOrdinal("Street"))
                                 ? null
                                 : reader.GetString(reader.GetOrdinal("Street")),
                City = reader.IsDBNull(reader.GetOrdinal("City"))
                                 ? null
                                 : reader.GetString(reader.GetOrdinal("City")),
                State = reader.IsDBNull(reader.GetOrdinal("State"))
                                 ? null
                                 : reader.GetString(reader.GetOrdinal("State")),
                Zip = reader.IsDBNull(reader.GetOrdinal("Zip"))
                                 ? null
                                 : reader.GetString(reader.GetOrdinal("Zip"))
            };
        }
    }
}
