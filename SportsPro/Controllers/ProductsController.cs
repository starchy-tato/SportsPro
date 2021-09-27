using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class ProductsController : Controller
    {
        public SportsProContext context { get; set; }

    

        public ProductsController()
        {
            //default constructor
        }

        // GET: Products
        public IActionResult Index()
        {
            SportsProContext db = new SportsProContext();
            List<Product> products = db.Products.ToList();
            
            return View(products);
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            SportsProContext db = new SportsProContext();
            Product product =  db.Products
                .FirstOrDefault(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            //shows create title in webpage
            ViewBag.Action = "Create";

            //merging the create and edit razor page
            return View("Edit", new Product());
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductID,ProductCode,Name,YearlyPrice,ReleaseDate")] Product product)
        {
            SportsProContext db = new SportsProContext();
            if (ModelState.IsValid)
            {
                db.Add(product);
                 db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SportsProContext db = new SportsProContext();
            ViewBag.Action = "Edit";
            Product product =  db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ProductID,ProductCode,Name,YearlyPrice,ReleaseDate")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            SportsProContext db = new SportsProContext();
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(product);
                     db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SportsProContext db = new SportsProContext();
            Product product =  db.Products
                .FirstOrDefault(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            SportsProContext db = new SportsProContext();
            Product product =  db.Products.Find(id);
            db.Products.Remove(product);
             db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            SportsProContext db = new SportsProContext();
            return db.Products.Any(e => e.ProductID == id);
        }
    }
}
