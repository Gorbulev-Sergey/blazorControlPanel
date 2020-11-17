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
        post post(int ID);
        Task<string> create(post post);
        Task update(post post);
        Task delete(int id);

        event Action Фильтр_изменён;
        void Изменить_фильтр();
    }
        
    public class PostsService : IPostsServise
    {
        //ApplicationDbContext _context;
        DbContextOptions<ApplicationDbContext> _options;  

        public PostsService(DbContextOptions<ApplicationDbContext> options)
        {
            //_context = context;
            _options = options;
        }

        public async Task<List<post>> posts()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                return await context.posts.Include(t=>t.tags).ToListAsync();
            }            
        }
        public post post(int ID)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                return context.posts.Include(t => t.tags).FirstOrDefault(p => p.ID == ID);
            }
        }

        public async Task<string> create(post post)
        {
            if (post != null)
            {
                var tags = post.tags;
                post.tags = new List<tag>();
                DateTime дата = post.created = DateTime.Now;

                using (var context = new ApplicationDbContext(_options))
                {
                    context.posts.Add(post);
                    await context.SaveChangesAsync();
                                           
                    context.posts.Include(t => t.tags).FirstOrDefault(p => p.created == дата).tags.AddRange(tags);
                    await context.SaveChangesAsync();

                    return "Сохранена";
                }
            }
            return "Не сохранена";
        }

        public async Task update(post post)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Entry(post).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
                        
        }

        public async Task delete(int id)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.posts.Remove(context.posts.FirstOrDefault(p=>p.ID==id));
                await context.SaveChangesAsync();
            }
            
        }

        public event Action Фильтр_изменён;
        public void Изменить_фильтр()
        {
            Фильтр_изменён?.Invoke();
        }
    }
}
