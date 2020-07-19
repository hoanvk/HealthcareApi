using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthCareApi.Models;

namespace HealthCareApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly ModelContext _context;

        public ProductController(ModelContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            return View(await _context.HeaProducts.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heaProducts = await _context.HeaProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (heaProducts == null)
            {
                return NotFound();
            }

            return View(heaProducts);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdName,ProdCode,UpdatedDate,UpdatedBy")] HeaProducts heaProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heaProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(heaProducts);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heaProducts = await _context.HeaProducts.FindAsync(id);
            if (heaProducts == null)
            {
                return NotFound();
            }
            return View(heaProducts);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdName,ProdCode,UpdatedDate,UpdatedBy")] HeaProducts heaProducts)
        {
            if (id != heaProducts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(heaProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeaProductsExists(heaProducts.Id))
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
            return View(heaProducts);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heaProducts = await _context.HeaProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (heaProducts == null)
            {
                return NotFound();
            }

            return View(heaProducts);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var heaProducts = await _context.HeaProducts.FindAsync(id);
            _context.HeaProducts.Remove(heaProducts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeaProductsExists(int id)
        {
            return _context.HeaProducts.Any(e => e.Id == id);
        }
    }
}
