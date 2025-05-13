using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CIS4583.Model
{
	public class Supplier  
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Supplier class.
		/// </summary>
		public Supplier()
		{
			this.ProductList = new List<Product>();

		}

		

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the supplierID value.
		/// </summary>
		public int? supplierID { get; set; }

        /// <summary>
        /// Gets or sets the companyName value.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Company Name")]
        public string companyName { get; set; }

        /// <summary>
        /// Gets or sets the address value.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Address")]
        public string address { get; set; }

        /// <summary>
        /// Gets or sets the city value.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("City")]
        public string city { get; set; }

        /// <summary>
        /// Gets or sets the region value.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Region")]
        public string region { get; set; }

        /// <summary>
        /// Gets or sets the postalCode value.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Postal Code")]
        public string postalCode { get; set; }

        /// <summary>
        /// Gets or sets the country value.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Country")]
        public string country { get; set; }
		/// <summary>
		/// Gets or sets the Product value.
		/// </summary>
		public List<Product>  ProductList { get; set; }


		#endregion
		 
	}
}

