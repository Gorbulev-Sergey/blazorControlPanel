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
        Task<int> update(post post);
        Task<int> delete(int id);
    }

    [Authorize(Roles ="администратор, редактор")]
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

        [Authorize(Roles ="администратор, редактор")]
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

        [Authorize(Roles = "администратор, редактор")]
        public async Task<int> update(post post)
        {
            _context.Entry(post).State = EntityState.Modified;            
            return await _context.SaveChangesAsync();            
        }

        [Authorize(Roles = "Администратор, Редактор")]
        public async Task<int> delete(int id)
        {
            _context.posts.Remove(_context.posts.FirstOrDefault(p=>p.ID==id));
            return await _context.SaveChangesAsync();
        }
    }
}
