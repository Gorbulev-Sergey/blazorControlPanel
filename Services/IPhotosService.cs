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
        Task<List<imagesAlbum>> imagesAlbums();
        Task<imagesAlbum> imagesAlbum(int id);
        Task create(imagesAlbum album);
        Task update(imagesAlbum album);
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
        
        public async Task<List<imagesAlbum>> imagesAlbums()
        {
            using (var context=new ApplicationDbContext(_options))
            {
                return await context.imagesAlbums.Include(i => i.images).ToListAsync();
            }                
        }
        public async Task<imagesAlbum> imagesAlbum(int id)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                return await context.imagesAlbums.Include(i => i.images).FirstOrDefaultAsync(a => a.ID == id);
            }            
        }

        public async Task create(imagesAlbum album)
        {
            using (var context = new ApplicationDbContext(_options))
            { 
                context.imagesAlbums.Add(album);
                await context.SaveChangesAsync();
            }             
        }

        public async Task delete(int id)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.imagesAlbums.Remove(context.imagesAlbums.Include(i => i.images).FirstOrDefault(a => a.ID == id));
                await context.SaveChangesAsync();
            }            
        }        

        public async Task update(imagesAlbum album)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Update<imagesAlbum>(album);
                await context.SaveChangesAsync();
            }            
        }
    }
}
