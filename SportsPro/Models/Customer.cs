using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SportsPro.Models
{
    public class Customer
    {
		public int CustomerID { get; set; }

		[Display(Name = "First Name")]
		[Required(ErrorMessage = "Please enter a name")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[Required(ErrorMessage = "Please enter a name")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter an address")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Please enter a city")]
		public string City { get; set; }

		[Required(ErrorMessage = "Please enter a state")]
		public string State { get; set; }

		[Display(Name = "Postal Code")]
		[Required(ErrorMessage = "Please enter a postal code")]
		public string PostalCode { get; set; }

		public string CountryID { get; set; }

		[Required(ErrorMessage = "Please enter a country")]
		public Country Country { get; set; }

		[Required(ErrorMessage = "Please enter a phone number.")]
		[RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Please enter an email.")]
		[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
		public string Email { get; set; }

		[Display(Name = "Name")]
		public string FullName => FirstName + " " + LastName;   // read-only property
	}
}