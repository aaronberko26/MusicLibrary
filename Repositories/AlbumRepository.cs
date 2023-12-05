using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLibrary.Repositories
{
    public interface IAlbumRepository
    {
        List <Album> GetAll();
        List <Album> GetAlbum(int artistId);
        void AddAlbum(Album album);
        //void DeleteAlbum(int artistId, string albumName);
    }

    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicLibraryContext _dbContext;

        public AlbumRepository(MusicLibraryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Album> GetAll()
        {
            return _dbContext.Albums.ToList();
        }

        public List<Album> GetAlbum(int artistId)
        {
            List<Album> matchingAlbums = _dbContext.Albums.Where(album => album.ArtistId == artistId).ToList();

            if (matchingAlbums.Count > 0)
            {
                return matchingAlbums;
            }
            else
            {
                throw new InvalidOperationException("No albums found for the specified artistId");
            }
        }

        public void AddAlbum(Album album)
        {
            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();
        }

        /*public void DeleteAlbum(int artistId, string albumName)
        {
            Album albumToDelete = GetAlbum(artistId, albumName); 

            if(albumToDelete != null)
            {
                _dbContext.Albums.Remove(albumToDelete);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Album not found");
            }
        }*/

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
