using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZavrsniRad.Models;

namespace ZavrsniRad.Controllers
{
    public class IgračController : Controller
    {
        private readonly ZavrsniRadContext _context;

        public IgračController(ZavrsniRadContext context)
        {
            _context = context;
        }

        // GET: Igrač
        public async Task<IActionResult> Index()
        {
            var zavrsniRadContext = _context.Igrači.Include(i => i.Tim);
            return View(await zavrsniRadContext.ToListAsync());
        }

        // GET: Igrač/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igrač = await _context.Igrači
                .Include(i => i.Tim)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (igrač == null)
            {
                return NotFound();
            }

            return View(igrač);
        }

        // GET: Igrač/Create
        public IActionResult Create()
        {
            ViewData["TimId"] = new SelectList(_context.Timovi, "Id", "Ime");
            return View();
        }

        // POST: Igrač/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,TimId")] Igrač igrač)
        {
            if (ModelState.IsValid)
            {
                _context.Add(igrač);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TimId"] = new SelectList(_context.Timovi, "Id", "Ime", igrač.TimId);
            return View(igrač);
        }

        // GET: Igrač/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igrač = await _context.Igrači.FindAsync(id);
            if (igrač == null)
            {
                return NotFound();
            }
            ViewData["TimId"] = new SelectList(_context.Timovi, "Id", "Ime", igrač.TimId);
            return View(igrač);
        }

        // POST: Igrač/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,TimId")] Igrač igrač)
        {
            if (id != igrač.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(igrač);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IgračExists(igrač.Id))
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
            ViewData["TimId"] = new SelectList(_context.Timovi, "Id", "Ime", igrač.TimId);
            return View(igrač);
        }

        // GET: Igrač/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igrač = await _context.Igrači
                .Include(i => i.Tim)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (igrač == null)
            {
                return NotFound();
            }

            return View(igrač);
        }

        // POST: Igrač/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var igrač = await _context.Igrači.FindAsync(id);
            _context.Igrači.Remove(igrač);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IgračExists(int id)
        {
            return _context.Igrači.Any(e => e.Id == id);
        }
    }
}
