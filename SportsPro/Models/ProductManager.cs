using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public class ProductManager
    {
        /// <summary>
        /// add another row to the table
        /// </summary>
        /// <param name="product">movie to add</param>
        public static void AddProduct(Product product)
        {
            SportsProContext db = new SportsProContext();
            db.Products.Add(product);
            db.SaveChanges();
        }

        /// <summary>
        /// updates product record
        /// </summary>
        /// <param name="product">new data</param>
        public static void UpdateProduct(Product product)
        {
            SportsProContext db = new SportsProContext();
            Product oldProd = db.Products.Find(product.ProductID);
            oldProd.ProductCode = product.ProductCode;
            oldProd.Name = product.Name;
            oldProd.YearlyPrice = product.YearlyPrice;
            oldProd.ReleaseDate = product.ReleaseDate;
            db.SaveChanges();
        }



        /// <summary>
        /// deletes product record
        /// </summary>
        /// <param name="id">id of the product</param>
        /// <param name="product">product to delete</param>
        public static void DeleteProduct(int id, Product product)
        {
            SportsProContext db = new SportsProContext();
            Product oldProd = db.Products.Find(id);
            db.Products.Remove(oldProd);
            db.SaveChanges();
        }

    }//end class
}//end namespace
