using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public class IncidentVM
    {
        //view model for the Incident Manager page (Index view)
        public int IncidentID { get; set; }

        //incident title
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        //customer name
        [Required(ErrorMessage = "Please select a customer")]
        [Display(Name = "Name")]
        public string FullName { get; set; }
        //public Customer Customer { get; set; }

        //product name
        [Required(ErrorMessage = "Please select a product")]
        [Display(Name = "Product")]
        public string Name { get; set; }
        //public Product Product { get; set; }

        //incident date opened
        [Display(Name = "Date Opened")]
        [DataType(DataType.Date)]
        public DateTime DateOpened { get; set; } = DateTime.Now;

        //incident date closed
        [Display(Name = "Date Closed")]
        [DataType(DataType.Date)]
        public DateTime? DateClosed { get; set; } = null;

        //incident description
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        //technician name
        public int? TechnicianID { get; set; }
        public Technician Technician { get; set; }

    }
}
