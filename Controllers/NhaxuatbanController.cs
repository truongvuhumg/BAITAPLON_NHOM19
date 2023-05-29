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
    public class NhaxuatbanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhaxuatbanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nhaxuatban
        public async Task<IActionResult> Index()
        {
              return _context.Nhaxuatban != null ? 
                          View(await _context.Nhaxuatban.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Nhaxuatban'  is null.");
        }

        // GET: Nhaxuatban/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhaxuatban == null)
            {
                return NotFound();
            }

            var nhaxuatban = await _context.Nhaxuatban
                .FirstOrDefaultAsync(m => m.NXBID == id);
            if (nhaxuatban == null)
            {
                return NotFound();
            }

            return View(nhaxuatban);
        }

        // GET: Nhaxuatban/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhaxuatban/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NXBID,NXBName,NXBAddress,Phone")] Nhaxuatban nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaxuatban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaxuatban);
        }

        // GET: Nhaxuatban/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhaxuatban == null)
            {
                return NotFound();
            }

            var nhaxuatban = await _context.Nhaxuatban.FindAsync(id);
            if (nhaxuatban == null)
            {
                return NotFound();
            }
            return View(nhaxuatban);
        }

        // POST: Nhaxuatban/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NXBID,NXBName,NXBAddress,Phone")] Nhaxuatban nhaxuatban)
        {
            if (id != nhaxuatban.NXBID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaxuatban);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaxuatbanExists(nhaxuatban.NXBID))
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
            return View(nhaxuatban);
        }

        // GET: Nhaxuatban/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhaxuatban == null)
            {
                return NotFound();
            }

            var nhaxuatban = await _context.Nhaxuatban
                .FirstOrDefaultAsync(m => m.NXBID == id);
            if (nhaxuatban == null)
            {
                return NotFound();
            }

            return View(nhaxuatban);
        }

        // POST: Nhaxuatban/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhaxuatban == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nhaxuatban'  is null.");
            }
            var nhaxuatban = await _context.Nhaxuatban.FindAsync(id);
            if (nhaxuatban != null)
            {
                _context.Nhaxuatban.Remove(nhaxuatban);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaxuatbanExists(string id)
        {
          return (_context.Nhaxuatban?.Any(e => e.NXBID == id)).GetValueOrDefault();
        }
    }
}
