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
        private ApplicationDbContext _context;

        public PhotosService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<imagesAlbum>> imagesAlbums()
        {
            return await _context.imagesAlbums.Include(i=>i.images).ToListAsync();
        }
        public async Task<imagesAlbum> imagesAlbum(int id)
        {
            return await _context.imagesAlbums.Include(i => i.images).FirstOrDefaultAsync(a=>a.ID==id);
        }

        public async Task create(imagesAlbum album)
        {
            _context.imagesAlbums.Add(album);
            await _context.SaveChangesAsync();
        }

        public async Task delete(int id)
        {
            _context.imagesAlbums.Remove(_context.imagesAlbums.Include(i => i.images).FirstOrDefault(a => a.ID == id));
            await _context.SaveChangesAsync();
        }        

        public async Task update(imagesAlbum album)
        {
            _context.Update<imagesAlbum>(album);
            await _context.SaveChangesAsync();
        }
    }
}
