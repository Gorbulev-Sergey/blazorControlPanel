using blazorControlPanel.Data;
using blazorControlPanel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Services
{
    interface ICommentsServices
    {
        List<comment> comments();
    }

    public class CommentsServices : ICommentsServices
    {
        //ApplicationDbContext _context;
        DbContextOptions<ApplicationDbContext> _options;

        public CommentsServices(ApplicationDbContext context, DbContextOptions<ApplicationDbContext> options)
        {
            //_context = context;
            _options = options;
        }
        public List<comment> comments()
        {
            using(var context = new ApplicationDbContext(_options))
            {
                return context.comments.ToList();
            }            
        }
    }
}
