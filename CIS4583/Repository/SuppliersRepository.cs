using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CIS4583.Model;
using CIS4583.IRepository;

namespace CIS4583.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        #region Fields
        private string _connectionString;

        #endregion

        #region Constructors

        public SupplierRepository(IConfiguration configuration)
        {

            _connectionString = configuration.GetConnectionString("ProductConnection");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Selects a record from the Supplier table by its primary key.
        /// </summary>
        public Supplier Supplier_Select(Supplier _SupplierLine)
        {
            Supplier SupplierLine = new Supplier();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Supplier_Select", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.Parameters.AddWithValue("@SupplierID", _SupplierLine.supplierID);
                SqlDataReader myReader = sqlCmd.ExecuteReader();
                while (myReader.Read())
                {
                    SupplierLine = MapDataReaderSupplier(myReader);
                }
            }
            return SupplierLine;
        }


        /// <summary>
        /// Selects a record from the Supplier table by its primary key.
        /// </summary>
        public List<Supplier> Supplier_SelectList()
        {
            List<Supplier> SupplierList = new List<Supplier>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Supplier_SelectList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader myReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    Supplier SupplierLine = new Supplier();
                    SupplierLine = MapDataReaderSupplier(myReader);
                    SupplierList.Add(SupplierLine);
                }
            }
            return SupplierList;
        }

        /// <summary>
        /// Saves a record to the Supplier table.
        /// </summary>
        public bool Supplier_Insert(Supplier SupplierLine)
        {
            bool status = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Supplier_Insert", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.Parameters.AddWithValue("@CompanyName", SupplierLine.companyName);
                sqlCmd.Parameters.AddWithValue("@Address", SupplierLine.address != null ? SupplierLine.address : DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@City", SupplierLine.city != null ? SupplierLine.city : DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@Region", SupplierLine.region != null ? SupplierLine.region : DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@PostalCode", SupplierLine.postalCode != null ? SupplierLine.postalCode : DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@Country", SupplierLine.country != null ? SupplierLine.country : DBNull.Value);
                int numberOfRecordsAffected = sqlCmd.ExecuteNonQuery();
                if (numberOfRecordsAffected > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        /// <summary>
        /// Saves a record to the Supplier table.
        /// </summary>
        public bool Supplier_Update(Supplier SupplierLine)
        {
            bool status = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Supplier_Update", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.CommandText = "usp_Supplier_Update";
                sqlCmd.Parameters.AddWithValue("@SupplierID", SupplierLine.supplierID);
                sqlCmd.Parameters.AddWithValue("@CompanyName", SupplierLine.companyName);
                sqlCmd.Parameters.AddWithValue("@Address", SupplierLine.address != null ? SupplierLine.address : DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@City", SupplierLine.city != null ? SupplierLine.city : DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@Region", SupplierLine.region != null ? SupplierLine.region : DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@PostalCode", SupplierLine.postalCode != null ? SupplierLine.postalCode : DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@Country", SupplierLine.country != null ? SupplierLine.country : DBNull.Value);
                int numberOfRecordsAffected = sqlCmd.ExecuteNonQuery();
                if (numberOfRecordsAffected > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        /// <summary>
        /// Deletes a record from the Supplier table by its primary key.
        /// </summary>
        public bool Supplier_Delete(Supplier SupplierLine)
        {
            bool status = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Supplier_Delete", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.Parameters.AddWithValue("@SupplierID", SupplierLine.supplierID);
                int numberOfRecordsAffected = sqlCmd.ExecuteNonQuery();
                if (numberOfRecordsAffected > 0)
                {
                    status = true;
                }
            }
            return status;
        }


        /// <summary>
        /// Creates a new instance of the Supplier class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static Supplier MapDataReaderSupplier(SqlDataReader myReader)
        {
            Supplier SupplierLine = new Supplier();
            if (!myReader.IsDBNull(myReader.GetOrdinal("SupplierID"))) SupplierLine.supplierID = myReader.GetInt32(myReader.GetOrdinal("SupplierID"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("CompanyName"))) SupplierLine.companyName = myReader.GetString(myReader.GetOrdinal("CompanyName"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("Address"))) SupplierLine.address = myReader.GetString(myReader.GetOrdinal("Address"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("City"))) SupplierLine.city = myReader.GetString(myReader.GetOrdinal("City"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("Region"))) SupplierLine.region = myReader.GetString(myReader.GetOrdinal("Region"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("PostalCode"))) SupplierLine.postalCode = myReader.GetString(myReader.GetOrdinal("PostalCode"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("Country"))) SupplierLine.country = myReader.GetString(myReader.GetOrdinal("Country"));


            return SupplierLine;
        }


        #endregion
    }
}
