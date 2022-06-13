using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TenantAccount.Data;
using TenantAccount.Data.Entities;
using System.Security.Claims;

namespace TenantAccount.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MessagesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var messages = _context.Messages.Include(s => s.IdentityUser).ToList();
            return View(messages);
        }

        public IActionResult Create(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();
            var message = new Message { IdentityUser = user };
            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByIdAsync(message.IdentityUser.Id).GetAwaiter().GetResult();
                message.IdentityUser = user;

                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(message);
        }

        public IActionResult UserMesseges()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var messages = _context.Messages.Include(s => s.IdentityUser).Where(s => s.IdentityUser.Id == userId).ToList();

            return View(messages);
        }

        public IActionResult Read(int id)
        {
            var message = _context.Messages.FirstOrDefault(s => s.Id == id);

            if (message != null)
            {
                message.Read = 1;
                _context.SaveChanges();
            }

            return RedirectToAction("UserMesseges");
        }
    }
}
