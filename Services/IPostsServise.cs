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

        event Action Фильтр_изменён;
        void Изменить_фильтр();
    }
        
    public class PostsService : IPostsServise
    {
        //ApplicationDbContext _context;
        DbContextOptions<ApplicationDbContext> _options;  

        public PostsService(ApplicationDbContext context, DbContextOptions<ApplicationDbContext> options)
        {
            //_context = context;
            _options = options;
        }

        public async Task<List<post>> posts()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                return await context.posts.ToListAsync();
            }            
        }

        public async Task<string> create(post post)
        {
            if (post != null)
            {
                using (var context = new ApplicationDbContext(_options))
                {
                    context.posts.Add(post);
                    await context.SaveChangesAsync();
                    return "Сохранена";
                }                
            }
            return "Не сохранена";
        }

        public async Task<int> update(post post)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Entry(post).State = EntityState.Modified;   
                return await context.SaveChangesAsync();
            }
                        
        }

        public async Task<int> delete(int id)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.posts.Remove(context.posts.FirstOrDefault(p=>p.ID==id));
                return await context.SaveChangesAsync();
            }
            
        }

        public event Action Фильтр_изменён;
        public void Изменить_фильтр()
        {
            Фильтр_изменён?.Invoke();
        }
    }
}
