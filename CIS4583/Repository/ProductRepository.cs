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
    public class ProductRepository : IProductRepository
    {
        #region Fields
        private string _connectionString;

        #endregion

        #region Constructors

        public ProductRepository(IConfiguration configuration)
        {

            _connectionString = configuration.GetConnectionString("ProductConnection");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Selects a record from the Product table by its primary key.
        /// </summary>
        public Product Product_Select(Product _ProductLine)
        {
            Product ProductLine = new Product();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Product_Select", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.Parameters.AddWithValue("@ProductID", _ProductLine.productID);
                SqlDataReader myReader = sqlCmd.ExecuteReader();
                while (myReader.Read())
                {
                    ProductLine = MapDataReaderProduct(myReader);
                }
            }
            return ProductLine;
        }

        /// <summary>
        /// Selects a record from the Product table by its foreign key.
        /// </summary>
        public List<Product> Product_Categories_SelectList(Product _ProductLine)
        {
            List<Product> ProductList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Product_Categories_SelectList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.Parameters.AddWithValue("@ProductID", _ProductLine.productID);
                SqlDataReader myReader = sqlCmd.ExecuteReader();
                while (myReader.Read())
                {
                    Product ProductLine = new Product();
                    ProductLine = MapDataReaderProduct(myReader);
                    ProductList.Add(ProductLine);
                }
            }
            return ProductList;
        }
        /// <summary>
        /// Selects a record from the Product table by its foreign key.
        /// </summary>
        public List<Product> Product_Supplier_SelectList(Product _ProductLine)
        {
            List<Product> ProductList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Product_Suppliers_SelectList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.Parameters.AddWithValue("@ProductID", _ProductLine.productID);
                SqlDataReader myReader = sqlCmd.ExecuteReader();
                while (myReader.Read())
                {
                    Product ProductLine = new Product();
                    ProductLine = MapDataReaderProduct(myReader);
                    ProductList.Add(ProductLine);
                }
            }
            return ProductList;
        }


        /// <summary>
        /// Selects a record from the Product table by its primary key.
        /// </summary>
        public List<Product> Product_SelectList()
        {
            List<Product> ProductList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Product_SelectList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader myReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    Product ProductLine = new Product();
                    ProductLine = MapDataReaderProduct(myReader);
                    ProductList.Add(ProductLine);
                }
            }
            return ProductList;
        }

        /// <summary>
        /// Saves a record to the Product table.
        /// </summary>
        public bool Product_Insert(Product ProductLine)
        {
            bool status = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Product_Insert", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();             
                sqlCmd.Parameters.AddWithValue("@ProductName", ProductLine.productName);
                sqlCmd.Parameters.AddWithValue("@SupplierID", ((ProductLine.supplierID != null) ? (object)ProductLine.supplierID : DBNull.Value));
                sqlCmd.Parameters.AddWithValue("@CategoryID", ((ProductLine.categoryID != null) ? (object)ProductLine.categoryID : DBNull.Value));
                sqlCmd.Parameters.AddWithValue("@UnitPrice", ((ProductLine.unitPrice != null) ? (object)ProductLine.unitPrice : DBNull.Value));
                sqlCmd.Parameters.AddWithValue("@UnitsInStock", ((ProductLine.unitsInStock != null) ? (object)ProductLine.unitsInStock : DBNull.Value));
                sqlCmd.Parameters.AddWithValue("@UnitsOnOrder", ((ProductLine.unitsOnOrder != null) ? (object)ProductLine.unitsOnOrder : DBNull.Value));
                int numberOfRecordsAffected = sqlCmd.ExecuteNonQuery();
                if (numberOfRecordsAffected > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        /// <summary>
        /// Saves a record to the Product table.
        /// </summary>
        public bool Product_Update(Product ProductLine)
        {
            bool status = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Product_Update", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.CommandText = "usp_Product_Update";
                sqlCmd.Parameters.AddWithValue("@ProductID", ProductLine.productID);
                sqlCmd.Parameters.AddWithValue("@ProductName", ProductLine.productName);
                sqlCmd.Parameters.AddWithValue("@SupplierID", ((ProductLine.supplierID != null) ? (object)ProductLine.supplierID : DBNull.Value));
                sqlCmd.Parameters.AddWithValue("@CategoryID", ((ProductLine.categoryID != null) ? (object)ProductLine.categoryID : DBNull.Value));
                sqlCmd.Parameters.AddWithValue("@UnitPrice", ((ProductLine.unitPrice != null) ? (object)ProductLine.unitPrice : DBNull.Value));
                sqlCmd.Parameters.AddWithValue("@UnitsInStock", ((ProductLine.unitsInStock != null) ? (object)ProductLine.unitsInStock : DBNull.Value));
                sqlCmd.Parameters.AddWithValue("@UnitsOnOrder", ((ProductLine.unitsOnOrder != null) ? (object)ProductLine.unitsOnOrder : DBNull.Value));
                int numberOfRecordsAffected = sqlCmd.ExecuteNonQuery();
                if (numberOfRecordsAffected > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        /// <summary>
        /// Deletes a record from the Product table by its primary key.
        /// </summary>
        public bool Product_Delete(Product ProductLine)
        {
            bool status = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Product_Delete", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                sqlCmd.Parameters.AddWithValue("@ProductID", ProductLine.productID);
                int numberOfRecordsAffected = sqlCmd.ExecuteNonQuery();
                if (numberOfRecordsAffected > 0)
                {
                    status = true;
                }
            }
            return status;
        }


        /// <summary>
        /// Creates a new instance of the Product class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static Product MapDataReaderProduct(SqlDataReader myReader)
        {
            Product ProductLine = new Product();
            if (!myReader.IsDBNull(myReader.GetOrdinal("ProductID"))) ProductLine.productID = myReader.GetInt32(myReader.GetOrdinal("ProductID"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("ProductName"))) ProductLine.productName = myReader.GetString(myReader.GetOrdinal("ProductName"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("SupplierID"))) ProductLine.supplierID = myReader.GetInt32(myReader.GetOrdinal("SupplierID"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("CompanyName"))) ProductLine.companyName = myReader.GetString(myReader.GetOrdinal("CompanyName"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("CategoryName"))) ProductLine.categoryName = myReader.GetString(myReader.GetOrdinal("CategoryName"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("CategoryID"))) ProductLine.categoryID = myReader.GetInt32(myReader.GetOrdinal("CategoryID"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("UnitPrice"))) ProductLine.unitPrice = myReader.GetDecimal(myReader.GetOrdinal("UnitPrice"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("UnitsInStock"))) ProductLine.unitsInStock = myReader.GetInt32(myReader.GetOrdinal("UnitsInStock"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("UnitsOnOrder"))) ProductLine.unitsOnOrder = myReader.GetInt32(myReader.GetOrdinal("UnitsOnOrder"));


            return ProductLine;
        }


        #endregion
    }
}
