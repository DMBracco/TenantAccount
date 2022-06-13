using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TenantAccount.Data;
using TenantAccount.Data.Entities;

namespace TenantAccount.Controllers
{
    [Authorize]
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ContractController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Сontract
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var applicationDbContext = new List<Сontract>();

            if (!User.IsInRole("admin"))
            {
                applicationDbContext = await _context.Сontracts.Include(с => с.Status).Where(s => s.IdentityUser.Id == userId).ToListAsync();
            }
            else
            {
                applicationDbContext = await _context.Сontracts.Include(с => с.Status).ToListAsync();
            }

            return View(applicationDbContext);
        }

        // GET: Сontract/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Сontracts == null)
            {
                return NotFound();
            }

            var сontract = await _context.Сontracts
                .Include(с => с.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сontract == null)
            {
                return NotFound();
            }

            return View(сontract);
        }

        // GET: Сontract/Create
        public IActionResult Create()
        {
            ViewData["StatusId"] = new SelectList(_context.СontractStatuses, "Id", "Name");
            return View();
        }

        // POST: Сontract/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Сontract сontract)
        {
            IdentityUser user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                сontract.IdentityUser = user;

                _context.Add(сontract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(_context.СontractStatuses, "Id", "Name", сontract.StatusId);
            return View(сontract);
        }

        // GET: Сontract/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Сontracts == null)
            {
                return NotFound();
            }

            var сontract = await _context.Сontracts.FindAsync(id);
            if (сontract == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.СontractStatuses, "Id", "Name", сontract.StatusId);
            return View(сontract);
        }

        // POST: Сontract/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Сontract сontract)
        {
            if (id != сontract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(сontract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!СontractExists(сontract.Id))
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
            ViewData["StatusId"] = new SelectList(_context.СontractStatuses, "Id", "Name", сontract.StatusId);
            return View(сontract);
        }

        // GET: Сontract/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Сontracts == null)
            {
                return NotFound();
            }

            var сontract = await _context.Сontracts
                .Include(с => с.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сontract == null)
            {
                return NotFound();
            }

            return View(сontract);
        }

        // POST: Сontract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Сontracts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Сontracts'  is null.");
            }
            var сontract = await _context.Сontracts.FindAsync(id);
            if (сontract != null)
            {
                _context.Сontracts.Remove(сontract);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool СontractExists(int id)
        {
          return (_context.Сontracts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
