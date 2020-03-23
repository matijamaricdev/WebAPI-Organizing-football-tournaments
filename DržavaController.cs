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
    public class DržavaController : Controller
    {
        private readonly ZavrsniRadContext _context;

        public DržavaController(ZavrsniRadContext context)
        {
            _context = context;
        }

        // GET: Država
        public async Task<IActionResult> Index()
        {
            return View(await _context.Države.ToListAsync());
        }

        // GET: Država/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var država = await _context.Države
                .FirstOrDefaultAsync(m => m.Id == id);
            if (država == null)
            {
                return NotFound();
            }

            return View(država);
        }

        // GET: Država/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Država/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime")] Država država)
        {
            if (ModelState.IsValid)
            {
                _context.Add(država);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(država);
        }

        // GET: Država/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var država = await _context.Države.FindAsync(id);
            if (država == null)
            {
                return NotFound();
            }
            return View(država);
        }

        // POST: Država/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime")] Država država)
        {
            if (id != država.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(država);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DržavaExists(država.Id))
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
            return View(država);
        }

        // GET: Država/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var država = await _context.Države
                .FirstOrDefaultAsync(m => m.Id == id);
            if (država == null)
            {
                return NotFound();
            }

            return View(država);
        }

        // POST: Država/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var država = await _context.Države.FindAsync(id);
            _context.Države.Remove(država);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DržavaExists(int id)
        {
            return _context.Države.Any(e => e.Id == id);
        }
    }
}
