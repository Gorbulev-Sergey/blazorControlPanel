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
        Task<post> create(post post);
    }

    public class PostsService : IPostsServise
    {
        ApplicationDbContext _context;
        public PostsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<post> create(post post)
        {
            if (post != null)
            {
                _context.posts.Add(post);
                await _context.SaveChangesAsync();
            }
            return post;
        }

        public async Task<List<post>> posts()
        {
            return await _context.posts.ToListAsync();         
        }
    }
}
