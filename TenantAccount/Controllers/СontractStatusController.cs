using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TenantAccount.Data;
using TenantAccount.Data.Entities;

namespace TenantAccount.Controllers
{
    [Authorize(Roles = "admin")]
    public class ContractStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContractStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: СontractStatus
        public async Task<IActionResult> Index()
        {
              return _context.СontractStatuses != null ? 
                          View(await _context.СontractStatuses.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.СontractStatuses'  is null.");
        }

        // GET: СontractStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.СontractStatuses == null)
            {
                return NotFound();
            }

            var сontractStatus = await _context.СontractStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сontractStatus == null)
            {
                return NotFound();
            }

            return View(сontractStatus);
        }

        // GET: СontractStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: СontractStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] СontractStatus сontractStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(сontractStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(сontractStatus);
        }

        // GET: СontractStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.СontractStatuses == null)
            {
                return NotFound();
            }

            var сontractStatus = await _context.СontractStatuses.FindAsync(id);
            if (сontractStatus == null)
            {
                return NotFound();
            }
            return View(сontractStatus);
        }

        // POST: СontractStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] СontractStatus сontractStatus)
        {
            if (id != сontractStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(сontractStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!СontractStatusExists(сontractStatus.Id))
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
            return View(сontractStatus);
        }

        // GET: СontractStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.СontractStatuses == null)
            {
                return NotFound();
            }

            var сontractStatus = await _context.СontractStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сontractStatus == null)
            {
                return NotFound();
            }

            return View(сontractStatus);
        }

        // POST: СontractStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.СontractStatuses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.СontractStatuses'  is null.");
            }
            var сontractStatus = await _context.СontractStatuses.FindAsync(id);
            if (сontractStatus != null)
            {
                _context.СontractStatuses.Remove(сontractStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool СontractStatusExists(int id)
        {
          return (_context.СontractStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
