using Blazor_10.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Server.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model) {

            model.Entity<Blog>()
                .HasOne(p => p.User)
                .WithMany(p => p.Blogs)
                .HasForeignKey(p => p.UserId);

            model.Entity<Comment>()
                .HasOne(p => p.Blog)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.BlogId);

            model.Entity<User>()
                .HasOne(p => p.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.RoleId);

            model.Entity<User>()
                .HasOne(p => p.Status);

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
