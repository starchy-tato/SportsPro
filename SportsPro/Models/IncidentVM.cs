using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public class IncidentVM
    {
        public Incident Incident { get; set; }

        public Customer Customer { get; set; }
        public Product product { get; set; }
        public Technician technician { get; set; }
      
        public int IncidentID { get; set; }

        public Incident currentIncident { get; set; }

        public string ActiveTech { get; set; }

    }
}
