using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public class IncidentsManager
    {
        /// <summary>
        /// get all incident properties, including customer, product and technician 
        /// </summary>
        /// <returns>list of incident properties</returns>
        public static List<Incident> GetAll()
        {
            SportsProContext db = new SportsProContext();
            List<Incident> incidents = db.Incidents.
                Include(i => i.Customer).Include(i => i.Product).Include(i => i.Technician).ToList();
            return incidents;


        }

    }
}
