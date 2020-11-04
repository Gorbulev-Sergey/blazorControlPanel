using blazorControlPanel.Data;
using blazorControlPanel.Models;
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
        Task<string> create(imagesAlbum album);
        Task<int> update(imagesAlbum album);
        Task<int> delete(int id);
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

        public async Task<string> create(imagesAlbum album)
        {
            _context.imagesAlbums.Add(album);
            await _context.SaveChangesAsync();
            return "Фотоальбом создан";
        }

        public Task<int> delete(int id)
        {
            throw new NotImplementedException();
        }        

        public Task<int> update(imagesAlbum album)
        {
            throw new NotImplementedException();
        }
    }
}
