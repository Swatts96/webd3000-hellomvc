using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HelloMVC.Models;

namespace HelloMVC.Data
{
    public class HelloMVCContext : IdentityDbContext<AppUser>
    {
        public HelloMVCContext (DbContextOptions<HelloMVCContext> options)
            : base(options)
        {
        }

        public DbSet<HelloMVC.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<HelloMVC.Models.Comment> Comment { get; set; } = default!;
    }
}
