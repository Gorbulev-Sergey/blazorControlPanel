using System;
using System.Collections.Generic;
using System.Text;
using blazorControlPanel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace blazorControlPanel.Data
{
    public class ApplicationDbContext : IdentityDbContext<user>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            posts = Set<post>();
            comments = Set<comment>();
            likes = Set<like>();
            tags = Set<tag>();
            imageAlbums = Set<imageAlbum>();
            schedule = Set<schedule_string>();
        }

        public DbSet<post> posts { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<like> likes { get; set; }
        public DbSet<tag> tags { get; set; }
        public DbSet<imageAlbum> imageAlbums { get; set; }
        public DbSet<schedule_string> schedule { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<post_tag>()
            //.HasKey(t => new { t.postID, t.tagID });

            //builder.Entity<post_tag>()
            //    .HasOne(sc => sc.post)
            //    .WithMany(s => s.posts_tags)
            //    .HasForeignKey(sc => sc.postID);

            //builder.Entity<post_tag>()
            //    .HasOne(sc => sc.tag)
            //    .WithMany(c => c.posts_tags)
            //    .HasForeignKey(sc => sc.tagID);
        }
    }
}
