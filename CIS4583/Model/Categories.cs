using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CIS4583.Model
{
	public class Categories  
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Categorie class.
		/// </summary>
		public Categories()
		{
			this.ProductList = new List<Product>();

		}

		

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the categoryID value.
		/// </summary>
		public int? categoryID { get; set; }

        /// <summary>
        /// Gets or sets the categoryName value.
        /// </summary>
         [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Category")]
        public string categoryName { get; set; }

		
		/// <summary>
		/// Gets or sets the Product value.
		/// </summary>
		public List<Product>  ProductList { get; set; }


		#endregion
		 
	}
}

