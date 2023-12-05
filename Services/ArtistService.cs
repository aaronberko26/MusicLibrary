using MusicLibrary.Models;
using MusicLibrary.Repositories;

namespace MusicLibrary.Services
{
    public interface IArtistService
    {
        IEnumerable<Artist> GetAll();
        Artist GetArtist(int artistId);
        void AddArtist(Artist artist);
        int GetArtistIdByName(string name);
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

        public void AddArtist(Artist artist)
        {
            _artistRepository.AddArtist(artist);
        }

        public int GetArtistIdByName(string name)
        {
            return _artistRepository.GetArtistIdByName(name);
        }
    }
}