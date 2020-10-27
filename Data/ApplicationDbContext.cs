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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            posts = Set<post>();
            comments = Set<comment>();
            likes = Set<like>();
            imagesAlbums = Set<imagesAlbum>();
            schedules = Set<schedule>();
        }

        public DbSet<post> posts { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<like> likes { get; set; }
        public DbSet<imagesAlbum> imagesAlbums { get; set; }
        public DbSet<schedule> schedules { get; set; }
        public DbSet<schedule_string> schedules_strings { get; set; }
    }
}
