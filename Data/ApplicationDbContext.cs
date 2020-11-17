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
        }

        public DbSet<post> posts { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<like> likes { get; set; }
        public DbSet<tag> tags { get; set; }
        public DbSet<imageAlbum> imageAlbums { get; set; }
        public DbSet<schedule_string> schedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Настройка связи многие - ко - многим для post-tag
            //modelBuilder.Entity<posttag>().HasKey(k => new { k.postID, k.tagID });
            
            //modelBuilder.Entity<posttag>()
            //    .HasOne(x => x.tag)
            //    .WithMany(x => x.poststags)
            //    .HasForeignKey(x => x.tagID);

            //modelBuilder.Entity<posttag>()
            //    .HasOne(x => x.post)
            //    .WithMany(x => x.poststags)
            //    .HasForeignKey(x => x.postID);            
            
            base.OnModelCreating(modelBuilder);            
        }
    }
}
