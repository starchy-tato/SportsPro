using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Technician
    {
		public int TechnicianID { get; set; }	   

		[Required(ErrorMessage = "Please enter a name."), MaxLength(30)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter an email.")]
		[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter a phone number.")]
		[RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
		public string Phone { get; set; }
	}
}
