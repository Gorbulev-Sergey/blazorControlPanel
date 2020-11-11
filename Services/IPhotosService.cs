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
    interface IPhotosService
    {
        Task<List<imageAlbum>> imageAlbums();
        Task<imageAlbum> imageAlbum(int id);
        Task create(imageAlbum album);
        Task update(imageAlbum album);
        Task delete(int id);
    }

    public class PhotosService : IPhotosService
    {
        //ApplicationDbContext _context;
        DbContextOptions<ApplicationDbContext> _options;

        public PhotosService(ApplicationDbContext context, DbContextOptions<ApplicationDbContext> options)
        {
            //_context = context;
            _options = options;
        }
        
        public async Task<List<imageAlbum>> imageAlbums()
        {
            using (var context=new ApplicationDbContext(_options))
            {
                return await context.imageAlbums.Include(i => i.images).ToListAsync();
            }                
        }
        public async Task<imageAlbum> imageAlbum(int id)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                return await context.imageAlbums.Include(i => i.images).FirstOrDefaultAsync(a => a.ID == id);
            }            
        }

        public async Task create(imageAlbum album)
        {
            using (var context = new ApplicationDbContext(_options))
            { 
                context.imageAlbums.Add(album);
                await context.SaveChangesAsync();
            }             
        }

        public async Task delete(int id)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.imageAlbums.Remove(context.imageAlbums.Include(i => i.images).FirstOrDefault(a => a.ID == id));
                await context.SaveChangesAsync();
            }            
        }        

        public async Task update(imageAlbum album)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Update<imageAlbum>(album);
                await context.SaveChangesAsync();
            }            
        }
    }
}
