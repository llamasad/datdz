using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPaper.Data;

namespace MvcPaper.Controllers
{
    public class PaperTypesController : Controller
    {
        private readonly ApplicationContext _context;

        public PaperTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: PaperTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaperType.ToListAsync());
        }

        // GET: PaperTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperType = await _context.PaperType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paperType == null)
            {
                return NotFound();
            }

            return View(paperType);
        }

        // GET: PaperTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaperTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeName")] PaperType paperType)
        {    Console.WriteLine(ModelState.IsValid);
            
            
                _context.Add(paperType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(paperType);
        }

        // GET: PaperTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperType = await _context.PaperType.FindAsync(id);
            if (paperType == null)
            {
                return NotFound();
            }
            return View(paperType);
        }

        // POST: PaperTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeName")] PaperType paperType)
        {
            if (id != paperType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paperType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaperTypeExists(paperType.Id))
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
            return View(paperType);
        }

        // GET: PaperTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperType = await _context.PaperType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paperType == null)
            {
                return NotFound();
            }

            return View(paperType);
        }

        // POST: PaperTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paperType = await _context.PaperType.FindAsync(id);
            if (paperType != null)
            {
                _context.PaperType.Remove(paperType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaperTypeExists(int id)
        {
            return _context.PaperType.Any(e => e.Id == id);
        }
    }
}
