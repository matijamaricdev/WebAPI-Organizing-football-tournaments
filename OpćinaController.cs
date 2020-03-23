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
    public class OpćinaController : Controller
    {
        private readonly ZavrsniRadContext _context;

        public OpćinaController(ZavrsniRadContext context)
        {
            _context = context;
        }

        // GET: Općina
        public async Task<IActionResult> Index()
        {
            var zavrsniRadContext = _context.Općine.Include(o => o.Županija);
            return View(await zavrsniRadContext.ToListAsync());
        }

        // GET: Općina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var općina = await _context.Općine
                .Include(o => o.Županija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (općina == null)
            {
                return NotFound();
            }

            return View(općina);
        }

        // GET: Općina/Create
        public IActionResult Create()
        {
            ViewData["ŽupanijaId"] = new SelectList(_context.Županije, "Id", "Id");
            //ViewData["ŽupanijaIme"] = new SelectList(_context.Županije, "Ime", "Ime");
            return View();
        }

        // POST: Općina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,ŽupanijaId")] Općina općina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(općina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ŽupanijaId"] = new SelectList(_context.Županije, "Id", "Id", općina.ŽupanijaId);
            //ViewData["ŽupanijaIme"] = new SelectList(_context.Županije, "Ime", "Ime");
            return View(općina);
        }

        // GET: Općina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var općina = await _context.Općine.FindAsync(id);
            if (općina == null)
            {
                return NotFound();
            }
            ViewData["ŽupanijaId"] = new SelectList(_context.Županije, "Id", "Id", općina.ŽupanijaId);
            return View(općina);
        }

        // POST: Općina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,ŽupanijaId")] Općina općina)
        {
            if (id != općina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(općina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpćinaExists(općina.Id))
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
            ViewData["ŽupanijaId"] = new SelectList(_context.Županije, "Id", "Id", općina.ŽupanijaId);
            return View(općina);
        }

        // GET: Općina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var općina = await _context.Općine
                .Include(o => o.Županija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (općina == null)
            {
                return NotFound();
            }

            return View(općina);
        }

        // POST: Općina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var općina = await _context.Općine.FindAsync(id);
            _context.Općine.Remove(općina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpćinaExists(int id)
        {
            return _context.Općine.Any(e => e.Id == id);
        }
    }
}
