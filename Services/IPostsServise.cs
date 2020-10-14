using blazorControlPanel.Data;
using blazorControlPanel.Models;
using Microsoft.AspNetCore.Authorization;
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
        Task<string> create(post post);
    }

    public class PostsService : IPostsServise
    {
        ApplicationDbContext _context;
        public PostsService(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles ="Администратор")]
        public async Task<string> create(post post)
        {
            if (post != null)
            {
                _context.posts.Add(post);
                await _context.SaveChangesAsync();
                return "Сохранена";
            }
            return "Не сохранена";
        }

        public async Task<List<post>> posts()
        {
            return await _context.posts.ToListAsync();         
        }
    }
}
