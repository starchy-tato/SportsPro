using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Models
{
    public class Product
    {
		public int ProductID { get; set; }

		[Required(ErrorMessage = "Please enter a product code")]
		[Display(Name = "Code")]
		public string ProductCode { get; set; }

		[Required(ErrorMessage = "Please enter a name")]
		public string Name { get; set; }

		[Display(Name = "Price")]
		[Required(ErrorMessage = "Please enter a price")]
		[Range(0, 1000000)]
		[Column(TypeName = "decimal(8,2)")]
		[DataType(DataType.Currency)]
		public decimal YearlyPrice { get; set; }

		[Display(Name = "Release Date")]
		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; } = DateTime.Now;
	}
}
