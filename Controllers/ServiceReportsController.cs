using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fleet_tracking_system.Data;
using Fleet_tracking_system.Models;

namespace Fleet_tracking_system.Controllers
{
    public class ServiceReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceReports
        public async Task<IActionResult> Index()
        {
              return _context.ServiceReports != null ? 
                          View(await _context.ServiceReports.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ServiceReports'  is null.");
        }

        // GET: ServiceReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceReports == null)
            {
                return NotFound();
            }

            var serviceReport = await _context.ServiceReports
                .FirstOrDefaultAsync(m => m.ReportID == id);
            if (serviceReport == null)
            {
                return NotFound();
            }

            return View(serviceReport);
        }

        // GET: ServiceReports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportID,VehicleID,ServiceType,CompletionDate,Cost")] ServiceReport serviceReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceReport);
        }

        // GET: ServiceReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceReports == null)
            {
                return NotFound();
            }

            var serviceReport = await _context.ServiceReports.FindAsync(id);
            if (serviceReport == null)
            {
                return NotFound();
            }
            return View(serviceReport);
        }

        // POST: ServiceReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportID,VehicleID,ServiceType,CompletionDate,Cost")] ServiceReport serviceReport)
        {
            if (id != serviceReport.ReportID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceReportExists(serviceReport.ReportID))
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
            return View(serviceReport);
        }

        // GET: ServiceReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceReports == null)
            {
                return NotFound();
            }

            var serviceReport = await _context.ServiceReports
                .FirstOrDefaultAsync(m => m.ReportID == id);
            if (serviceReport == null)
            {
                return NotFound();
            }

            return View(serviceReport);
        }

        // POST: ServiceReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceReports == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ServiceReports'  is null.");
            }
            var serviceReport = await _context.ServiceReports.FindAsync(id);
            if (serviceReport != null)
            {
                _context.ServiceReports.Remove(serviceReport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceReportExists(int id)
        {
          return (_context.ServiceReports?.Any(e => e.ReportID == id)).GetValueOrDefault();
        }
    }
}
