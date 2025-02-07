using System;
using System.Collections.Generic;
using HelloMVC.Models;

namespace HelloMVC.Models
{
    public class Discussion
    {
        // Primary key
        public int DiscussionId { get; set; }

        // Properties
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string ImageFilename { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public bool isPublic { get; set; } = false;

        // One-to-many relationship with Comment
        public required ICollection<Comment> Comment { get; set; }

        public List<Discussion>? Comments { get; set; } //nullable
    }
}