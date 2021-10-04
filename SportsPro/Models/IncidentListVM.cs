using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public class IncidentListVM: IncidentVM
    {
        private List<Customer> customers { get; set; }
        public List<Customer> Customers
        {
            get => customers;
            set
            {
                customers = new List<Customer>
                {
                    new Customer {CustomerID = Convert.ToInt32("all"), FirstName = "All"}
                };
                customers.AddRange(value);
            }
        }

        public List<Product> products { get; set; }
        public List<Product> Products
        {
            get => products;
            set
            {
                products = new List<Product>
                {
                    new Product {ProductID = Convert.ToInt32("all"), Name = "All"}
                };
                products.AddRange(value);
            }
        }

        public List <Technician> technicians { get; set; }
        public List<Technician> Technicians
        {
            get => technicians;
            set
            {
                technicians = new List<Technician>
                {
                    new Technician {TechnicianID = Convert.ToInt32("all"), Name = "All"}
                };
                technicians.AddRange(value);
            }
        }

        //string that specifies whether page is for add or edit operation
        //method to help view determine active link
        public string CheckActiveTech(string c) =>
            c.ToLower() == ActiveTech.ToLower() ? "active" : "";

    }//end class
}//end namespace
