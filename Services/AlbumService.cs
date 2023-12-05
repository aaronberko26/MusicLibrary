using MusicLibrary.Models;
using MusicLibrary.Repositories;
using System.Collections.Generic;

namespace MusicLibrary.Services
{
    public interface IAlbumService
    {
        IEnumerable<Album> GetAll();
        List <Album> GetAlbum(int artistId);
        //void AddAlbum(int artistId, string albumName, string label, string albumLength, string albumGenre, int numOfSongs, int year, ICollection<Song> albumSongs, Artist artist);
        void AddAlbum(Album album); 
       // void DeleteAlbum(int artistId, string albumName);
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

        public List<Album> GetAlbum(int artistId)
        {
            return _albumRepository.GetAlbum(artistId);
        }

        public void AddAlbum(Album album) 
        {
            _albumRepository.AddAlbum(album);
        }

        /*public void DeleteAlbum(int artistId, string albumName)
        {
            _albumRepository.DeleteAlbum(artistId, albumName);
        }*/

       
    }
}
