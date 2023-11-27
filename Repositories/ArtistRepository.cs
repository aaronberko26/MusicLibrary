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
        void DeleteArtist(int artistId);
        //void UpdateArtist(int artistId, string artistName, ICollection<Album> albums, ICollection<Song> songs);
        void UpdateArtist(Artist artist);
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

       /* public void AddArtist(int artistId, string artistName, ICollection<Album> albums, ICollection<Song> songs)
        {
            Artist newArtist = new Artist(artistId, artistName, albums, songs);
            _dbContext.Artists.Add(newArtist);
        }*/

        public void AddArtist(Artist artist)
        {
            _dbContext.Artists.Add(artist);
            _dbContext.SaveChanges();
        }

        public void DeleteArtist(int artistId)
        {
            Artist artistToDelete = GetArtist(artistId);
            if (artistToDelete != null)
            {
                _dbContext.Artists.Remove(artistToDelete);
            }
            else
            {
                throw new InvalidOperationException("Artist not found");
            }
        }

        /*public void UpdateArtist(int artistId, string artistName, ICollection<Album> albums, ICollection<Song> songs)
        {
            Artist updatedArtist = GetArtist(artistId);

            if (updatedArtist != null)
            {
                updatedArtist.ArtistId = artistId;
                updatedArtist.Name = artistName;
                updatedArtist.Albums = albums;
                updatedArtist.Songs = songs;
            }
            else { throw new InvalidOperationException("Artist not found"); }
        }*/

        public void UpdateArtist(Artist artist)
        {
            _dbContext.Update(artist);
            _dbContext.SaveChanges();
        }
    }
}
