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
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageFilename { get; set; }
        public DateTime CreateDate { get; set; }

        // One-to-many relationship with Comment
        public ICollection<Comment> Comments { get; set; }
    }
}