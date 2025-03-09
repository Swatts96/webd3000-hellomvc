using System;
using System.ComponentModel.DataAnnotations.Schema;
using HelloMVC.Models;

namespace HelloMVC.Models
{
    public class Comment
    {
        // Primary key
        public int CommentId { get; set; }

        // Properties
        public required string Content { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }

        // Foreign key to Discussion
        public int DiscussionId { get; set; }

        // Navigation property for the many-to-one relationship with Discussion
        public required Discussion? Discussion { get; set; }

        // New: Foreign key to ApplicationUser
        public string? ApplUserId { get; set; }

        // New: Nullable navigation property
        [ForeignKey("AppUserId")]
        public virtual AppUser? AppUser { get; set; }
    }
}