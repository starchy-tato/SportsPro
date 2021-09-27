using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Incident
    {
		public int IncidentID { get; set; }

		[Required(ErrorMessage = "Please select a customer")]
		public int CustomerID { get; set; }     // foreign key property
		public Customer Customer { get; set; }  // navigation property

		[Required(ErrorMessage = "Please select a product")]
		public int ProductID { get; set; }     // foreign key property
		public Product Product { get; set; }   // navigation property

		//[DataType(DataType(?int))] make this a nullable int type
		public int? TechnicianID { get; set; }     // foreign key property - nullable
		public Technician Technician { get; set; }   // navigation property

		[Required(ErrorMessage = "Please enter a title")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Please enter a description")]
		public string Description { get; set; }

		[Display(Name = "Date Opened")]
		[DataType(DataType.Date)]
		public DateTime DateOpened { get; set; } = DateTime.Now;

		[Display(Name = "Date Closed")]
		[DataType(DataType.Date)]
		public DateTime? DateClosed { get; set; } = null;
	}
}