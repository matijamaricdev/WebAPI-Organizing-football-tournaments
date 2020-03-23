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
    public class ŽupanijaController : Controller
    {
        private readonly ZavrsniRadContext _context;

        public ŽupanijaController(ZavrsniRadContext context)
        {
            _context = context;
        }

        // GET: Županija
        public async Task<IActionResult> Index()
        {
            var zavrsniRadContext = _context.Županije.Include(ž => ž.Država);
            return View(await zavrsniRadContext.ToListAsync());
        }

        // GET: Županija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var županija = await _context.Županije
                .Include(ž => ž.Država)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (županija == null)
            {
                return NotFound();
            }

            return View(županija);
        }

        // GET: Županija/Create
        public IActionResult Create()
        {
            ViewData["DržavaId"] = new SelectList(_context.Države, "Id", "Ime");
            return View();
        }

        // POST: Županija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,DržavaId")] Županija županija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(županija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DržavaId"] = new SelectList(_context.Države, "Id", "Ime", županija.DržavaId);
            return View(županija);
        }

        // GET: Županija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var županija = await _context.Županije.FindAsync(id);
            if (županija == null)
            {
                return NotFound();
            }
            ViewData["DržavaId"] = new SelectList(_context.Države, "Id", "Ime", županija.DržavaId);
            return View(županija);
        }

        // POST: Županija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,DržavaId")] Županija županija)
        {
            if (id != županija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(županija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ŽupanijaExists(županija.Id))
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
            ViewData["DržavaId"] = new SelectList(_context.Države, "Id", "Ime", županija.DržavaId);
            return View(županija);
        }

        // GET: Županija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var županija = await _context.Županije
                .Include(ž => ž.Država)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (županija == null)
            {
                return NotFound();
            }

            return View(županija);
        }

        // POST: Županija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var županija = await _context.Županije.FindAsync(id);
            _context.Županije.Remove(županija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ŽupanijaExists(int id)
        {
            return _context.Županije.Any(e => e.Id == id);
        }
    }
}
