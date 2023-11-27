using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLibrary.Repositories
{
    public interface IAlbumRepository
    {
        IEnumerable <Album> GetAll();
        Album GetAlbum(string albumName);
        //void AddAlbum(int artistId, string albumName, string label, string albumLength, string albumGenre, int numOfSongs, int year, ICollection<Song> albumSongs, Artist artist);
        void AddAlbum(Album album);
        void DeleteAlbum(int artistId, string albumName);
       // void UpdateAlbum(int artistId, string albumName, string label, string albumLength, string albumGenre, int numOfSongs, int year, ICollection<Song> albumSongs, Artist artist);
        void UpdateAlbum(Album album);    
    }

    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicLibraryContext _dbContext;

        public AlbumRepository(MusicLibraryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Album> GetAll()
        {
            return _dbContext.Albums.ToList();
        }

        public Album GetAlbum(string albumName)
        {
            Album searchedAlbum = _dbContext.Albums.Find(albumName);

            if (searchedAlbum != null)
            {
                return searchedAlbum;
            }
            else
            {
                throw new InvalidOperationException("Album not found");
            }
        }

        public Album GetAlbumByArtistAndName(int artistId, string albumName)
        {
            Album searchedAlbum = _dbContext.Albums.FirstOrDefault(album => album.AName == albumName);

            if(searchedAlbum != null)
            {
                return searchedAlbum;
            }
            else
            {
                throw new InvalidOperationException("Album not found");
            }
        }



        /*public void UpdateAlbum(int artistId, string albumName, string label, string albumLength, string albumGenre, int numOfSongs, int year, ICollection<Song> albumSongs, Artist artist)
        {
            Album existingAlbum = GetAlbumByArtistAndName(artistId, albumName);

            if (existingAlbum != null)
            {
                existingAlbum.ArtistId = artistId;
                existingAlbum.AName = albumName;
                existingAlbum.Label = label;
                existingAlbum.ALength = albumLength;
                existingAlbum.AGenre = albumGenre;
                existingAlbum.Numofsongs = numOfSongs;
                existingAlbum.Year = year;
                existingAlbum.Artist = artist;

                // Update or add songs as needed
                existingAlbum.Songs.Clear(); // Assuming you want to replace existing songs
                foreach (var song in albumSongs)
                {
                    existingAlbum.Songs.Add(song);
                }

                // Save changes to the database
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Album not found");
            }
        }*/

        public void UpdateAlbum(Album album)
        {
            _dbContext.Albums.Update(album);
            _dbContext.SaveChanges();
        }

        /*public void AddAlbum(int artistId, string albumName, string label, string albumLength, string albumGenre, int numOfSongs, int year, ICollection<Song> albumSongs, Artist artist)
        {
            Album newAlbum = new Album(artistId, albumName, label, albumLength, albumGenre, numOfSongs, year, albumSongs, artist);
            _dbContext.Albums.Add(newAlbum);
        }*/

        public void AddAlbum(Album album)
        {
            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();
        }

        public void DeleteAlbum(int artistId, string albumName)
        {
            Album albumToDelete = GetAlbumByArtistAndName(artistId, albumName); 

            if(albumToDelete != null)
            {
                _dbContext.Albums.Remove(albumToDelete);
            }
            else
            {
                throw new InvalidOperationException("Album not found");
            }
        }
    }
}
