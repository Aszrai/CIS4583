using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using CIS4583.Model;
using CIS4583.IRepository;

namespace CIS4583.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        #region Fields
        private string _connectionString;

        #endregion

        #region Constructors

        public CategoriesRepository(IConfiguration configuration)
        {

            _connectionString = configuration.GetConnectionString("ProductConnection");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Selects a record from the Categories table by its primary key.
        /// </summary>
        public Categories Categories_Select(Categories _CategoriesLine)
        {
            Categories CategoriesLine = new Categories();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Categories_Select", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.Parameters.AddWithValue("@CategoryID", _CategoriesLine.categoryID);
                SqlDataReader myReader = sqlCmd.ExecuteReader();
                while (myReader.Read())
                {
                    CategoriesLine = MapDataReaderCategories(myReader);
                }
            }
            return CategoriesLine;
        }


        /// <summary>
        /// Selects a record from the Categories table by its primary key.
        /// </summary>
        public List<Categories> Categories_SelectList()
        {
            List<Categories> CategoriesList = new List<Categories>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Categories_SelectList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader myReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    Categories CategoriesLine = new Categories();
                    CategoriesLine = MapDataReaderCategories(myReader);
                    CategoriesList.Add(CategoriesLine);
                }
            }
            return CategoriesList;
        }

        /// <summary>
        /// Saves a record to the Categories table.
        /// </summary>
        public bool Categories_Insert(Categories CategoriesLine)
        {
            bool status = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Categories_Insert", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                 sqlCmd.Parameters.AddWithValue("@CategoryName", CategoriesLine.categoryName);               
                int numberOfRecordsAffected = sqlCmd.ExecuteNonQuery();
                if (numberOfRecordsAffected > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        /// <summary>
        /// Saves a record to the Categories table.
        /// </summary>
        public bool Categories_Update(Categories CategoriesLine)
        {
            bool status = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Categories_Update", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.CommandText = "usp_Categories_Update";
                sqlCmd.Parameters.AddWithValue("@CategoryID", CategoriesLine.categoryID);
                sqlCmd.Parameters.AddWithValue("@CategoryName", CategoriesLine.categoryName);               
                int numberOfRecordsAffected = sqlCmd.ExecuteNonQuery();
                if (numberOfRecordsAffected > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        /// <summary>
        /// Deletes a record from the Categories table by its primary key.
        /// </summary>
        public bool Categories_Delete(Categories CategoriesLine)
        {
            bool status = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Categories_Delete", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.Parameters.AddWithValue("@CategoryID", CategoriesLine.categoryID);
                int numberOfRecordsAffected = sqlCmd.ExecuteNonQuery();
                if (numberOfRecordsAffected > 0)
                {
                    status = true;
                }
            }
            return status;
        }



        /// <summary>
        /// Creates a new instance of the Categories class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static Categories MapDataReaderCategories(SqlDataReader myReader)
        {
            Categories CategoriesLine = new Categories();
            if (!myReader.IsDBNull(myReader.GetOrdinal("CategoryID"))) CategoriesLine.categoryID = myReader.GetInt32(myReader.GetOrdinal("CategoryID"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("CategoryName"))) CategoriesLine.categoryName = myReader.GetString(myReader.GetOrdinal("CategoryName")); 
            return CategoriesLine;
        }


        #endregion
    }
}
