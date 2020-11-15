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
            //posts = Set<post>();
            //comments = Set<comment>();
            //likes = Set<like>();
            //tags = Set<tag>();
            //imageAlbums = Set<imageAlbum>();
            //schedule = Set<schedule_string>();
            //posts_tags = Set<post_tag>();
        }

        public DbSet<post> posts { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<like> likes { get; set; }
        public DbSet<tag> tags { get; set; }
        public DbSet<imageAlbum> imageAlbums { get; set; }
        public DbSet<schedule_string> schedule { get; set; }
        public DbSet<post_tag> posts_tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связи многие-ко-многим для post-tag
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<post>()
            .HasMany(p => p.tags)
            .WithMany(p => p.posts)
            .UsingEntity<post_tag>(
                j => j
                    .HasOne(pt => pt.tag)
                    .WithMany(t => t.posts_tags)
                    .HasForeignKey(pt => pt.tagID),
                j => j
                    .HasOne(pt => pt.post)
                    .WithMany(p => p.posts_tags)
                    .HasForeignKey(pt => pt.postID),
                j =>
                {
                    j.HasKey(t => new { t.postID, t.tagID });
                });
        }
    }
}
