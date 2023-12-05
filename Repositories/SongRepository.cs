using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLibrary.Repositories
{
    public interface ISongRepository
    {
        List<Song> GetAll();
        Song GetSongByName(string albumName, string songName);
        void AddSong(Song newSong);
        void DeleteSong(string albumName, string albumSongName);
        void UpdateSong(string albumName, string songName, string genre, string featured, int length);
        List<Song> GetSongFromArtist(string artistName);
        List<Song> GetSongFromAlbum(string albumName);
    }

    public class SongRepository: ISongRepository
    {
        private readonly MusicLibraryContext _dbContext;

        public SongRepository(MusicLibraryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Song> GetAll()
        {
            return _dbContext.Songs.ToList();
        }

        public Song GetSongByName(string albumName, string songName)
        {
            return _dbContext.Songs
                 .FirstOrDefault(song =>
                     song.AName == albumName &&
                     song.Name == songName);
        }

        public List<Song> GetSongFromArtist(string artistName)
        {
            // Retrieve the artist by name
            var artist = _dbContext.Artists
                .FirstOrDefault(a => a.Name == artistName);

            if (artist == null)
            {
                return new List<Song>(); // or throw an exception, handle accordingly
            }

            // Retrieve songs by ArtistId
            return _dbContext.Songs
                .Where(song => song.ArtistId == artist.ArtistId)
                .ToList();
        }

        public List<Song> GetSongFromAlbum(string albumName)
        {
            var album = _dbContext.Albums.FirstOrDefault(a => a.AName == albumName);

            if(album == null)
            {
                return new List<Song>();
            }

            return _dbContext.Songs.Where(song => song.AName.Equals(albumName)).ToList();
        }

        public void AddSong(Song newSong)
        {
            _dbContext.Songs.Add(newSong);
            _dbContext.SaveChanges();
        }

        public void DeleteSong(string albumName, string albumSongName)
        {
            var songToDelete = _dbContext.Songs
               .FirstOrDefault(song =>
                   song.AName == albumName &&
                   song.Name == albumSongName);

            if (songToDelete != null)
            {
                _dbContext.Songs.Remove(songToDelete);
                _dbContext.SaveChanges();
            }
            else
            {
                // Handle the case where the song is not found.
                throw new InvalidOperationException("Song not found");
            }
        }

        public void UpdateSong(string albumName, string songName, string genre, string featured, int length)
        {
            var existingSong = _dbContext.Songs
                .FirstOrDefault(song =>
                    song.AName == albumName &&
                    song.Name == songName);

            if (existingSong != null)
            {
                // Update the properties of the existing song with the new values
                existingSong.Genre = genre;
                existingSong.FeaturedArtists = featured;
                existingSong.Length = length;

                // If you need to update the album reference, uncomment the line below
                // existingSong.ANameNavigation = updatedSong.ANameNavigation;

                _dbContext.SaveChanges();
            }
            else
            {
                // Handle the case where the song is not found.
                throw new InvalidOperationException("Song not found");
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

