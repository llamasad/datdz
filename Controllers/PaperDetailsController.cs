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
    public class PaperDetailsController : Controller
    {
        private readonly ApplicationContext _context;
       
        public PaperDetailsController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: PaperDetails
      public async Task<IActionResult> Index(string searchString)
{
    if (_context.PaperDetail == null)
    {
        return Problem("Entity set 'ApplicationContext.PaperDetail'  is null.");
    }

    var movies = from m in _context.PaperDetail
                select m;

    if (!String.IsNullOrEmpty(searchString))
    {
        movies = movies.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
    }

    return View(await movies.ToListAsync());
}

        // GET: PaperDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperDetail = await _context.PaperDetail
                .Include(p => p.PaperType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paperDetail == null)
            {
                return NotFound();
            }

            return View(paperDetail);
        }

        // GET: PaperDetails/Create
        public IActionResult Create()
        {
            ViewData["PaperTypeId"] = new SelectList(_context.Set<PaperType>(), "Id", "TypeName");
            return View();
        }

        // POST: PaperDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,PaperTypeId,PublishedDate,Abstract")] PaperDetail paperDetail)
        {
            if (true)
            {
                _context.Add(paperDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaperTypeId"] = new SelectList(_context.Set<PaperType>(), "Id", "TypeName", paperDetail.PaperTypeId);
            return View(paperDetail);
        }

        // GET: PaperDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperDetail = await _context.PaperDetail.FindAsync(id);
            if (paperDetail == null)
            {
                return NotFound();
            }
            ViewData["PaperTypeId"] = new SelectList(_context.Set<PaperType>(), "Id", "TypeName", paperDetail.PaperTypeId);
            return View(paperDetail);
        }

        // POST: PaperDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,PaperTypeId,PublishedDate,Abstract")] PaperDetail paperDetail)
        {
            if (id != paperDetail.Id)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(paperDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaperDetailExists(paperDetail.Id))
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
            ViewData["PaperTypeId"] = new SelectList(_context.Set<PaperType>(), "Id", "TypeName", paperDetail.PaperTypeId);
            return View(paperDetail);
        }

        // GET: PaperDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperDetail = await _context.PaperDetail
                .Include(p => p.PaperType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paperDetail == null)
            {
                return NotFound();
            }

            return View(paperDetail);
        }

        // POST: PaperDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paperDetail = await _context.PaperDetail.FindAsync(id);
            if (paperDetail != null)
            {
                _context.PaperDetail.Remove(paperDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaperDetailExists(int id)
        {
            return _context.PaperDetail.Any(e => e.Id == id);
        }
    }
}
