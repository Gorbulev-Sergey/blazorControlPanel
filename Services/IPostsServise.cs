using blazorControlPanel.Data;
using blazorControlPanel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorControlPanel.Services
{
    interface IPostsServise
    {
        Task<List<post>> posts();
    }

    public class PostsService : IPostsServise
    {
        ApplicationDbContext _context;
        public PostsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<post>> posts()
        {
            return await _context.posts.ToListAsync();         
        }
    }
}
