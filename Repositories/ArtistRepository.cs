using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLibrary.Repositories
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetAll();
        Artist GetArtist(int artistId);
        //void AddArtist(int artistId, string artistName, ICollection<Album> albums, ICollection<Song> songs);
        void AddArtist(Artist artist);
        int GetArtistIdByName(string name);
    }
    public class ArtistRepository : IArtistRepository
    {
        private readonly MusicLibraryContext _dbContext;

        public ArtistRepository(MusicLibraryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Artist> GetAll()
        {
            return _dbContext.Artists.ToList();
        }

        public Artist GetArtist(int artistId)
        {
            Artist searchedArtitst = _dbContext.Artists.Find(artistId);

            if (searchedArtitst != null)
            {
                return searchedArtitst;
            }
            else
            {
                throw new InvalidOperationException("Artist not found");
            }
        }

        public void AddArtist(Artist artist)
        {
            _dbContext.Artists.Add(artist);
            _dbContext.SaveChanges();
        }

        public int GetArtistIdByName(string name)
        {
            var artist = _dbContext.Artists.FirstOrDefault(a => a.Name == name);
            return artist.ArtistId;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
