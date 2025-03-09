using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloMVC.Data;
using HelloMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace HelloMVC.Controllers
{
    [Authorize]
    public class DiscussionsController : Controller
    {
        private readonly HelloMVCContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;  // For file system paths

        public DiscussionsController(HelloMVCContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Discussions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Discussion.ToListAsync());
        }

        // GET: Discussions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discussion = await _context.Discussion
                .Include(d => d.Comments) // Include related comments
                .FirstOrDefaultAsync(m => m.DiscussionId == id);
            if (discussion == null)
            {
                return NotFound();
            }

            return View(discussion);
        }


        // GET: Discussions/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Discussions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Notice we removed ImageFilename from the Bind list since it will be set by our code.
        public async Task<IActionResult> Create([Bind("DiscussionId,Title,Content,IsPublic")] Discussion discussion, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                // If an image was uploaded, process it.
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Generate a unique file name using a GUID and keep the original extension.
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                    // Build the path to the "images" folder in wwwroot.
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");

                    // Ensure the folder exists. If not, create it.
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Combine the path and file name.
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Save the file to disk.
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    // Store the unique file name in the model.
                    discussion.ImageFilename = uniqueFileName;
                }

                // Set the creation date.
                discussion.CreateDate = DateTime.Now;

                _context.Add(discussion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(discussion);
        }


        // GET: Discussions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discussion = await _context.Discussion.FindAsync(id);
            if (discussion == null)
            {
                return NotFound();
            }
            return View(discussion);
        }

        // POST: Discussions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiscussionId,Title,Content,ImageFilename,CreateDate,IsPublic")] Discussion discussion)
        {
            if (id != discussion.DiscussionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discussion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscussionExists(discussion.DiscussionId))
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
            return View(discussion);
        }

        // GET: Discussions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discussion = await _context.Discussion
                .FirstOrDefaultAsync(m => m.DiscussionId == id);
            if (discussion == null)
            {
                return NotFound();
            }

            return View(discussion);
        }

        // POST: Discussions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discussion = await _context.Discussion.FindAsync(id);
            if (discussion != null)
            {
                _context.Discussion.Remove(discussion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscussionExists(int id)
        {
            return _context.Discussion.Any(e => e.DiscussionId == id);
        }
    }
}
