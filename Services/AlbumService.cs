using MusicLibrary.Models;
using MusicLibrary.Repositories;
using System.Collections.Generic;

namespace MusicLibrary.Services
{
    public interface IAlbumService
    {
        IEnumerable<Album> GetAll();
        Album GetAlbum(string albumName);
        //void AddAlbum(int artistId, string albumName, string label, string albumLength, string albumGenre, int numOfSongs, int year, ICollection<Song> albumSongs, Artist artist);
        void AddAlbum(Album album); 
        void DeleteAlbum(int artistId, string albumName);
        void UpdateAlbum(Album album);
        //void UpdateAlbum(int artistId, string albumName, string label, string albumLength, string albumGenre, int numOfSongs, int year, ICollection<Song> albumSongs, Artist artist);
    }
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository ?? throw new ArgumentNullException(nameof(albumRepository));
        }

        public IEnumerable<Album> GetAll()
        {
            return _albumRepository.GetAll();
        }

        public Album GetAlbum(string albumName)
        {
            return _albumRepository.GetAlbum(albumName);
        }

        /*public void AddAlbum(int artistId, string albumName, string label, string albumLength, string albumGenre, int numOfSongs, int year, ICollection<Song> albumSongs, Artist artist)
        {
            _albumRepository.AddAlbum(artistId, albumName, label, albumLength, albumGenre, numOfSongs, year, albumSongs, artist);
        }*/

        public void AddAlbum(Album album) 
        {
            _albumRepository.AddAlbum(album);
        }

        public void DeleteAlbum(int artistId, string albumName)
        {
            _albumRepository.DeleteAlbum(artistId, albumName);
        }

        /*public void UpdateAlbum(int artistId, string albumName, string label, string albumLength, string albumGenre, int numOfSongs, int year, ICollection<Song> albumSongs, Artist artist)
        {
            _albumRepository.UpdateAlbum(artistId, albumName, label, albumLength, albumGenre, numOfSongs, year, albumSongs, artist);
        }*/

        public void UpdateAlbum(Album album)
        {
            // Add any business logic or validation here if needed
            _albumRepository.UpdateAlbum(album);
            // You might want to include additional business logic or validation after updating the album
        }


    }
}
