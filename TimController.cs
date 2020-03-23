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
    public class TimController : Controller
    {
        private readonly ZavrsniRadContext _context;

        public TimController(ZavrsniRadContext context)
        {
            _context = context;
        }

        // GET: Tim
        public async Task<IActionResult> Index()
        {
            ViewData["REZULTAT"] = "Rezultat";
            ViewData["PRVITIM"] = "Prvi tim";
            ViewData["DRUGITIM"] = "Drugi tim";
            ViewData["VS"] = "Protiv";
            ViewData["DD"] = "CB Dobar dan";
            ViewData["Oziris"] = "CB Oziris";
            ViewData["Doberman"] = "CB Doberman";
            ViewData["2CH"] = "CB Two Chellos";
            ViewData["Zero"] = "0";
            ViewData["One"] = "1";
            ViewData["Two"] = "2";
            ViewData["Blank"] = "-";

            return View(await _context.Timovi.ToListAsync());
        }

        // GET: Tim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tim = await _context.Timovi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tim == null)
            {
                return NotFound();
            }

            return View(tim);
        }

        // GET: Tim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Broj_igraca,Kotizacija,Godine_igranja")] Tim tim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tim);
        }

        // GET: Tim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tim = await _context.Timovi.FindAsync(id);
            if (tim == null)
            {
                return NotFound();
            }
            return View(tim);
        }

        // POST: Tim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Broj_igraca,Kotizacija,Godine_igranja")] Tim tim)
        {
            if (id != tim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimExists(tim.Id))
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
            return View(tim);
        }

        // GET: Tim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tim = await _context.Timovi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tim == null)
            {
                return NotFound();
            }

            return View(tim);
        }

        // POST: Tim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tim = await _context.Timovi.FindAsync(id);
            _context.Timovi.Remove(tim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimExists(int id)
        {
            return _context.Timovi.Any(e => e.Id == id);
        }
    }
}
