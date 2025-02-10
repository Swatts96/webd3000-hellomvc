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
                .Include(d => d.Comments)
                .OrderByDescending(d => d.CreateDate)
                .ToListAsync();
            return View(discussions);
        }

        // GET: Home/GetDiscussion/5
        public async Task<IActionResult> GetDiscussion(int id)
        {
            // Load a single discussion (with its comments)
            var discussion = await _context.Discussion
                .Include(d => d.Comments)
                .FirstOrDefaultAsync(d => d.DiscussionId == id);
            if (discussion == null)
            {
                return NotFound();
            }
            // Optionally order the comments descending
            discussion.Comments = discussion.Comments.OrderByDescending(c => c.CreateDate).ToList();
            return View(discussion);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

//// Create 3 discussion objects 
//Discussion discussion1 = new Discussion()
//            {
//                DiscussionId = 1,
//                Title = "Sidney Crosby Injured before four nations tournament",
//                Content = "He was injured and now he can't play",
//                ImageFilename = "crosby.jpg",
//                IsPublic = true, // Ensure this property exists in your Discussion model
//                Comments = new List<Comment>() // Each discussion has comments
//            };

//            Discussion discussion2 = new Discussion()
//            {
//                DiscussionId = 2,
//                Title = "Connor Mcdavid traded to Minnesota??",
//                Content = "He was injured and now he can't play",
//                ImageFilename = "crosby.jpg",
//                IsPublic = true,
//                Comments = new List<Comment>() // Each discussion has comments
//            };

//            Discussion discussion3 = new Discussion()
//            {
//                DiscussionId = 3, // Corrected ID
//                Title = "Malkin playing",
//                Content = "He was injured and now he can't play",
//                ImageFilename = "malkin.jpg",
//                IsPublic = true,
//                Comments = new List<Comment>() // Each discussion has comments
//            };

//            // Add to the list
//            discussions.Add(discussion1);
//            discussions.Add(discussion2);
//            discussions.Add(discussion3);

//            // Pass the list to the view
//            return View(discussions)