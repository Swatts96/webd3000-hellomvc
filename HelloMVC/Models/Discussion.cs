﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool IsPublic { get; set; } = false;

        // One-to-many relationship with Comment
        public required ICollection<Comment> Comments { get; set; } = new List<Comment>();

        // Foreign key to AppUser
        public string? AppUserId { get; set; }

        // Nullable navigation property
        [ForeignKey("AppUserId")]
        public virtual AppUser? AppUser { get; set; }
    }
}