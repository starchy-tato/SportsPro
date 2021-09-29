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
    public class IncidentsController : Controller
    {
        private readonly SportsProContext _context;

        public IncidentsController(SportsProContext context)
        {
            _context = context;
        }

        // GET: Incidents
        public async Task<IActionResult> Index()
        {
            var sportsProContext = _context.Incidents.Include(i => i.Customer).Include(i => i.Product).Include(i => i.Technician);
            return View(await sportsProContext.ToListAsync());
        }

        // GET: Incidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .FirstOrDefaultAsync(m => m.IncidentID == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // GET: Incidents/Create
        public IActionResult Create()
        {

            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName");
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name");
            ViewData["TechnicianID"] = new SelectList(_context.Technicians, "TechnicianID", "Name");

            //shows create title in razor page
            ViewBag.Action = "Create";
            ViewBag.Customers = _context.Customers;
            ViewBag.Products = _context.Products;
            ViewBag.Technicians = _context.Technicians;

            //merging the create and edit razor pages
            return View("Edit", new Incident());
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IncidentID,CustomerID,ProductID,TechnicianID,Title,Description,DateOpened,DateClosed")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "Address", incident.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", incident.ProductID);
            ViewData["TechnicianID"] = new SelectList(_context.Technicians, "TechnicianID", "Name", incident.TechnicianID);
            return View(incident);
        }

        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName", incident.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", incident.ProductID);
            ViewData["TechnicianID"] = new SelectList(_context.Technicians, "TechnicianID", "Name", incident.TechnicianID);
            ViewBag.Action = "Edit";
            ViewBag.Customers = _context.Customers;
            ViewBag.Products = _context.Products;
            ViewBag.Technicians = _context.Technicians;
            return View(incident);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IncidentID,CustomerID,ProductID,TechnicianID,Title,Description,DateOpened,DateClosed")] Incident incident)
        {
            if (id != incident.IncidentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentExists(incident.IncidentID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "Address", incident.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", incident.ProductID);
            ViewData["TechnicianID"] = new SelectList(_context.Technicians, "TechnicianID", "Name", incident.TechnicianID);
            return View(incident);
        }

        // GET: Incidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .FirstOrDefaultAsync(m => m.IncidentID == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentExists(int id)
        {
            return _context.Incidents.Any(e => e.IncidentID == id);
        }
    }
}
