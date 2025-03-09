using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloMVC.Data;
using HelloMVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HelloMVCContext _context;

        public HomeController(HelloMVCContext context)
        {
            _context = context;
        }

        // GET: Home/Index
        public async Task<IActionResult> Index()
        {
            // Load discussions, including comments, ordered descending by CreateDate
            var discussions = await _context.Discussion
                .Include(d => d.AppUser)
                .OrderByDescending(d => d.CreateDate)
                .ToListAsync();


            return View(discussions);
        }

        // GET: Home/GetDiscussion/5
        public async Task<IActionResult> GetDiscussion(int id)
        {
            // Load a single discussion (with its comments)
            var discussion = await _context.Discussion
            .Include(d => d.AppUser)            // Load the discussion owner
            .Include(d => d.Comments)
                .ThenInclude(c => c.AppUser)     // Load the comment owners
            .FirstOrDefaultAsync(d => d.DiscussionId == id);


            if (discussion == null)
            {
                return NotFound();
            }
            // Optionally order the comments descending
            discussion.Comments = discussion.Comments.OrderByDescending(c => c.CreateDate).ToList();
            return View(discussion);
        }

        // GET: Home/Profile/{id}
        public async Task<IActionResult> Profile(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            // Get the user from the Identity database (via _context.Users)
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Get all discussions created by the user
            var discussions = await _context.Discussion
                .Where(d => d.AppUserId == id)
                .OrderByDescending(d => d.CreateDate)
                .ToListAsync();

            var model = new ProfileViewModel
            {
                User = user,
                Discussions = discussions
            };

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
