using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication65;

namespace WebApplication65.Controllers
{
    public class ScalesController : Controller
    {
        private readonly PayScaleDbContext _context;

        public ScalesController(PayScaleDbContext context)
        {
            _context = context;
        }

        // GET: Scales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Scales.ToListAsync());
        }

        // GET: Scales/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scale = await _context.Scales
                .FirstOrDefaultAsync(m => m.Payband == id);
            if (scale == null)
            {
                return NotFound();
            }

            return View(scale);
        }

        // GET: Scales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Scales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Payband,PaySalary")] Scale scale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scale);
        }

        // GET: Scales/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scale = await _context.Scales.FindAsync(id);
            if (scale == null)
            {
                return NotFound();
            }
            return View(scale);
        }

        // POST: Scales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Payband,PaySalary")] Scale scale)
        {
            if (id != scale.Payband)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScaleExists(scale.Payband))
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
            return View(scale);
        }

        // GET: Scales/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scale = await _context.Scales
                .FirstOrDefaultAsync(m => m.Payband == id);
            if (scale == null)
            {
                return NotFound();
            }

            return View(scale);
        }

        // POST: Scales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var scale = await _context.Scales.FindAsync(id);
            _context.Scales.Remove(scale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScaleExists(string id)
        {
            return _context.Scales.Any(e => e.Payband == id);
        }
    }
}
