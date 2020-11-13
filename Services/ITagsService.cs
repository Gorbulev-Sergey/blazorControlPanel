using blazorControlPanel.Data;
using blazorControlPanel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Services
{
    interface ITagsService
    {
        List<tag> tags();
    }

    public class TagsService : ITagsService
    {
        DbContextOptions<ApplicationDbContext> options;
        public TagsService(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }
        public List<tag> tags()
        {
            using (var context = new ApplicationDbContext(options))
            {
                return context.tags.ToList();
            }
        }
    }
}
