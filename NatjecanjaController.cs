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
    public class NatjecanjaController : Controller
    {
        private readonly ZavrsniRadContext _context;

        public NatjecanjaController(ZavrsniRadContext context)
        {
            _context = context;
        }

        // GET: Natjecanja
        public async Task<IActionResult> Index()
        {
            ViewData["DatumOdigravanja"] = "Datum odigravanja";
            ViewData["UkupnoTimova"] = "Ukupno timova";
            return View(await _context.Natjecanje.ToListAsync());
        }

        // GET: Natjecanja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natjecanja = await _context.Natjecanje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (natjecanja == null)
            {
                return NotFound();
            }

            return View(natjecanja);
        }

        // GET: Natjecanja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Natjecanja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Datum_odigravanja,Ukupno_timova")] Natjecanja natjecanja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(natjecanja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(natjecanja);
        }

        // GET: Natjecanja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natjecanja = await _context.Natjecanje.FindAsync(id);
            if (natjecanja == null)
            {
                return NotFound();
            }
            return View(natjecanja);
        }

        // POST: Natjecanja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Datum_odigravanja,Ukupno_timova")] Natjecanja natjecanja)
        {
            if (id != natjecanja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(natjecanja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NatjecanjaExists(natjecanja.Id))
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
            return View(natjecanja);
        }

        // GET: Natjecanja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natjecanja = await _context.Natjecanje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (natjecanja == null)
            {
                return NotFound();
            }

            return View(natjecanja);
        }

        // POST: Natjecanja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var natjecanja = await _context.Natjecanje.FindAsync(id);
            _context.Natjecanje.Remove(natjecanja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NatjecanjaExists(int id)
        {
            return _context.Natjecanje.Any(e => e.Id == id);
        }
    }
}
