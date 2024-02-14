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
    public class TimesheetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimesheetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Timesheets
        public async Task<IActionResult> Index()
        {
              return _context.timesheets != null ? 
                          View(await _context.timesheets.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.timesheets'  is null.");
        }

        // GET: Timesheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.timesheets == null)
            {
                return NotFound();
            }

            var timesheet = await _context.timesheets
                .FirstOrDefaultAsync(m => m.TimesheetID == id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return View(timesheet);
        }

        // GET: Timesheets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Timesheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimesheetID,EmployeeID,Date,HoursWorked")] Timesheet timesheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timesheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timesheet);
        }

        // GET: Timesheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.timesheets == null)
            {
                return NotFound();
            }

            var timesheet = await _context.timesheets.FindAsync(id);
            if (timesheet == null)
            {
                return NotFound();
            }
            return View(timesheet);
        }

        // POST: Timesheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimesheetID,EmployeeID,Date,HoursWorked")] Timesheet timesheet)
        {
            if (id != timesheet.TimesheetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timesheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimesheetExists(timesheet.TimesheetID))
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
            return View(timesheet);
        }

        // GET: Timesheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.timesheets == null)
            {
                return NotFound();
            }

            var timesheet = await _context.timesheets
                .FirstOrDefaultAsync(m => m.TimesheetID == id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return View(timesheet);
        }

        // POST: Timesheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.timesheets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.timesheets'  is null.");
            }
            var timesheet = await _context.timesheets.FindAsync(id);
            if (timesheet != null)
            {
                _context.timesheets.Remove(timesheet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimesheetExists(int id)
        {
          return (_context.timesheets?.Any(e => e.TimesheetID == id)).GetValueOrDefault();
        }
    }
}
