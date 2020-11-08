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
        ApplicationDbContext _context;

        public CommentsServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<comment> comments()
        {
            return _context.comments.ToList();
        }
    }
}
