using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloMVC.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Location { get; set; }

        public string? ImageFilename { get; set; }

        [NotMapped] // Prevent storing in the database
        public IFormFile? ImageFile { get; set; }
    }
}
