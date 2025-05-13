using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CIS4583.Model
{
	public class Product 
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Product class.
		/// </summary>
		public Product()
		{
            CategorList = new List<Categories>();
            SupplierList = new List<Supplier>();

        }


		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the productID value.
		/// </summary>
		public int? productID { get; set; }

        /// <summary>
        /// Gets or sets the productName value.
        /// </summary>
         [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Product Name")]
        public string productName { get; set; }

        /// <summary>
        /// Gets or sets the supplierID value.
        /// </summary>
           [Required(ErrorMessage = "{0} is required!")]
        public int supplierID { get; set; }


        [DisplayName("Company Name")]
        public string companyName { get; set; }

        /// <summary>
        /// Gets or sets the categoryID value.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required!")]
        public int categoryID { get; set; }


        [DisplayName("Category Name")]
        public string categoryName { get; set; }


        /// <summary>
        /// Gets or sets the unitPrice value.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Unit Price")]
        public decimal unitPrice { get; set; }

        /// <summary>
        /// Gets or sets the unitsInStock value.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Units InStock")]
        public int unitsInStock { get; set; }

        /// <summary>
        /// Gets or sets the unitsOnOrder value.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Units In Order")]
        public int unitsOnOrder { get; set; }

        public List<Categories> CategorList { get; set; }

        public List<Supplier> SupplierList { get; set; }

        

        #endregion

    }
}

