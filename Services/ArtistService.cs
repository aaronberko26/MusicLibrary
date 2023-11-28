using MusicLibrary.Models;
using MusicLibrary.Repositories;

namespace MusicLibrary.Services
{
    public interface IArtistService
    {
        IEnumerable<Artist> GetAll();
        Artist GetArtist(int artistId);
        //void AddArtist(int artistId, string artistName, ICollection<Album> albums, ICollection<Song> songs);
        void AddArtist(Artist artist);
        void DeleteArtist(int artistId);
        //void UpdateArtist(int artistId, string artistName, ICollection<Album> albums, ICollection<Song> songs);
        void UpdateArtist(Artist artist);   
    }
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository ?? throw new ArgumentNullException(nameof(artistRepository));
        }

        public IEnumerable<Artist> GetAll()
        {
            return _artistRepository.GetAll();
        }

        public Artist GetArtist(int artistId)
        {
            return _artistRepository.GetArtist(artistId);
        }

        /*public void AddArtist(int artistId, string artistName, ICollection<Album> albums, ICollection<Song> songs)
        {
            _artistRepository.AddArtist(artistId, artistName, albums, songs);   
        }*/

        public void AddArtist(Artist artist)
        {
            _artistRepository.AddArtist(artist);
        }

        public void DeleteArtist(int artistId)
        {
            _artistRepository.DeleteArtist(artistId);
        }

        /*public void UpdateArtist(int artistId, string artistName, ICollection<Album> albums, ICollection<Song> songs)
        {
            _artistRepository.UpdateArtist(artistId, artistName, albums, songs);
        }*/

        public void UpdateArtist(Artist artist)
        {
            _artistRepository.UpdateArtist(artist);
        }
    }
}