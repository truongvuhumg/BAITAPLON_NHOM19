using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QUANLYTHUVIEN.Models;

namespace QUANLYTHUVIEN.Controllers
{
    public class PhieumuonsachController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhieumuonsachController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Phieumuonsach
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Phieumuonsach.Include(p => p.Employee).Include(p => p.Readers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Phieumuonsach/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Phieumuonsach == null)
            {
                return NotFound();
            }

            var phieumuonsach = await _context.Phieumuonsach
                .Include(p => p.Employee)
                .Include(p => p.Readers)
                .FirstOrDefaultAsync(m => m.Maphieu == id);
            if (phieumuonsach == null)
            {
                return NotFound();
            }

            return View(phieumuonsach);
        }

        // GET: Phieumuonsach/Create
        public IActionResult Create()
        {
            ViewData["EmployeeName"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
            ViewData["ReaderName"] = new SelectList(_context.Readers, "ReaderID", "ReaderID");
            return View();
        }

        // POST: Phieumuonsach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maphieu,ReaderName,EmployeeName")] Phieumuonsach phieumuonsach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phieumuonsach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeName"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", phieumuonsach.EmployeeName);
            ViewData["ReaderName"] = new SelectList(_context.Readers, "ReaderID", "ReaderID", phieumuonsach.ReaderName);
            return View(phieumuonsach);
        }

        // GET: Phieumuonsach/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Phieumuonsach == null)
            {
                return NotFound();
            }

            var phieumuonsach = await _context.Phieumuonsach.FindAsync(id);
            if (phieumuonsach == null)
            {
                return NotFound();
            }
            ViewData["EmployeeName"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", phieumuonsach.EmployeeName);
            ViewData["ReaderName"] = new SelectList(_context.Readers, "ReaderID", "ReaderID", phieumuonsach.ReaderName);
            return View(phieumuonsach);
        }

        // POST: Phieumuonsach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Maphieu,ReaderName,EmployeeName")] Phieumuonsach phieumuonsach)
        {
            if (id != phieumuonsach.Maphieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieumuonsach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieumuonsachExists(phieumuonsach.Maphieu))
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
            ViewData["EmployeeName"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", phieumuonsach.EmployeeName);
            ViewData["ReaderName"] = new SelectList(_context.Readers, "ReaderID", "ReaderID", phieumuonsach.ReaderName);
            return View(phieumuonsach);
        }

        // GET: Phieumuonsach/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Phieumuonsach == null)
            {
                return NotFound();
            }

            var phieumuonsach = await _context.Phieumuonsach
                .Include(p => p.Employee)
                .Include(p => p.Readers)
                .FirstOrDefaultAsync(m => m.Maphieu == id);
            if (phieumuonsach == null)
            {
                return NotFound();
            }

            return View(phieumuonsach);
        }

        // POST: Phieumuonsach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Phieumuonsach == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Phieumuonsach'  is null.");
            }
            var phieumuonsach = await _context.Phieumuonsach.FindAsync(id);
            if (phieumuonsach != null)
            {
                _context.Phieumuonsach.Remove(phieumuonsach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieumuonsachExists(string id)
        {
          return (_context.Phieumuonsach?.Any(e => e.Maphieu == id)).GetValueOrDefault();
        }
    }
}
