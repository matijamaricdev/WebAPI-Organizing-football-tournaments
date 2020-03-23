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
    public class NagradaController : Controller
    {
        private readonly ZavrsniRadContext _context;

        public NagradaController(ZavrsniRadContext context)
        {
            _context = context;
        }

        // GET: Nagradas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nagrade.ToListAsync());
        }

        // GET: Nagradas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nagrada = await _context.Nagrade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nagrada == null)
            {
                return NotFound();
            }

            return View(nagrada);
        }

        // GET: Nagradas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nagradas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime")] Nagrada nagrada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nagrada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nagrada);
        }

        // GET: Nagradas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nagrada = await _context.Nagrade.FindAsync(id);
            if (nagrada == null)
            {
                return NotFound();
            }
            return View(nagrada);
        }

        // POST: Nagradas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime")] Nagrada nagrada)
        {
            if (id != nagrada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nagrada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NagradaExists(nagrada.Id))
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
            return View(nagrada);
        }

        // GET: Nagradas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nagrada = await _context.Nagrade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nagrada == null)
            {
                return NotFound();
            }

            return View(nagrada);
        }

        // POST: Nagradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nagrada = await _context.Nagrade.FindAsync(id);
            _context.Nagrade.Remove(nagrada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NagradaExists(int id)
        {
            return _context.Nagrade.Any(e => e.Id == id);
        }
    }
}
