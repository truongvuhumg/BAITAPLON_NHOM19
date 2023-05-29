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
    public class ChitietmuontraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChitietmuontraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chitietmuontra
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Chitietmuontra.Include(c => c.Book).Include(c => c.Phieumuonsach);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Chitietmuontra/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Chitietmuontra == null)
            {
                return NotFound();
            }

            var chitietmuontra = await _context.Chitietmuontra
                .Include(c => c.Book)
                .Include(c => c.Phieumuonsach)
                .FirstOrDefaultAsync(m => m.Maphieu == id);
            if (chitietmuontra == null)
            {
                return NotFound();
            }

            return View(chitietmuontra);
        }

        // GET: Chitietmuontra/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID");
            ViewData["Maphieu"] = new SelectList(_context.Phieumuonsach, "Maphieu", "Maphieu");
            return View();
        }

        // POST: Chitietmuontra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maphieu,BookID,Ngaymuon,ngaytra")] Chitietmuontra chitietmuontra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitietmuontra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", chitietmuontra.BookID);
            ViewData["Maphieu"] = new SelectList(_context.Phieumuonsach, "Maphieu", "Maphieu", chitietmuontra.Maphieu);
            return View(chitietmuontra);
        }

        // GET: Chitietmuontra/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Chitietmuontra == null)
            {
                return NotFound();
            }

            var chitietmuontra = await _context.Chitietmuontra.FindAsync(id);
            if (chitietmuontra == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", chitietmuontra.BookID);
            ViewData["Maphieu"] = new SelectList(_context.Phieumuonsach, "Maphieu", "Maphieu", chitietmuontra.Maphieu);
            return View(chitietmuontra);
        }

        // POST: Chitietmuontra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Maphieu,BookID,Ngaymuon,ngaytra")] Chitietmuontra chitietmuontra)
        {
            if (id != chitietmuontra.Maphieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitietmuontra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietmuontraExists(chitietmuontra.Maphieu))
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
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", chitietmuontra.BookID);
            ViewData["Maphieu"] = new SelectList(_context.Phieumuonsach, "Maphieu", "Maphieu", chitietmuontra.Maphieu);
            return View(chitietmuontra);
        }

        // GET: Chitietmuontra/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Chitietmuontra == null)
            {
                return NotFound();
            }

            var chitietmuontra = await _context.Chitietmuontra
                .Include(c => c.Book)
                .Include(c => c.Phieumuonsach)
                .FirstOrDefaultAsync(m => m.Maphieu == id);
            if (chitietmuontra == null)
            {
                return NotFound();
            }

            return View(chitietmuontra);
        }

        // POST: Chitietmuontra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Chitietmuontra == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Chitietmuontra'  is null.");
            }
            var chitietmuontra = await _context.Chitietmuontra.FindAsync(id);
            if (chitietmuontra != null)
            {
                _context.Chitietmuontra.Remove(chitietmuontra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitietmuontraExists(string id)
        {
          return (_context.Chitietmuontra?.Any(e => e.Maphieu == id)).GetValueOrDefault();
        }
    }
}
