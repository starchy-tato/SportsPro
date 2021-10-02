using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SportsPro.Models
{
    public class Customer
    {
		public int CustomerID { get; set; }

		[Display(Name = "First Name")]
		[Required(ErrorMessage = "Please enter a name")]
		[StringLength(51, MinimumLength =1, ErrorMessage = "First name must between 1 to 51 characters.")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[Required(ErrorMessage = "Please enter a name")]
		[StringLength(51, MinimumLength = 1, ErrorMessage = "Last name must between 1 to 51 characters.")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter an address")]
		[StringLength(51, MinimumLength = 1, ErrorMessage = "Address must between 1 to 51 characters.")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Please enter a city")]
		[StringLength(51, MinimumLength = 1, ErrorMessage = "City must between 1 to 51 characters.")]
		public string City { get; set; }

		[Required(ErrorMessage = "Please enter a state")]
		[StringLength(51, MinimumLength = 1, ErrorMessage = "State must between 1 to 51 characters.")]
		public string State { get; set; }

		[Display(Name = "Postal Code")]
		[Required(ErrorMessage = "Please enter a postal code")]
		[StringLength(21, MinimumLength = 1, ErrorMessage = "Postal code must between 1 to 21 characters.")]
		public string PostalCode { get; set; }

		public string CountryID { get; set; }

		//[Required(ErrorMessage = "Please enter a country")]
		public Country Country { get; set; }

		[Required(ErrorMessage = "Please enter a phone number.")]
		[RegularExpression(@"^([\(]{1}[0-9]{3}[\)]{1}[ ]{1}[0-9]{3}[\-]{1}[0-9]{4})$", ErrorMessage = "Please use (999) 999-9999 format")]
		
		public string Phone { get; set; }

		[Required(ErrorMessage = "Please enter an email.")]
		[StringLength(51, MinimumLength = 1, ErrorMessage = "Email must between 1 to 51 characters.")]
		[DataType(DataType.EmailAddress)]
		[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
		public string Email { get; set; }

		[Display(Name = "Name")]
		public string FullName => FirstName + " " + LastName;   // read-only property
	}
}