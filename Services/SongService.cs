using MusicLibrary.Models;
using MusicLibrary.Repositories;

namespace MusicLibrary.Services
{
    public interface ISongService
    {
        IEnumerable<Song> GetAll();
        Song GetSongByName(string albumName, string songName);
        void AddSong(Song newSong);
        void DeleteSong(string albumName, string albumSongName);
        void UpdateSong(string albumName, string songName, string genre, string featured, int length);
        List<Song> GetSongsFromArtist(string artistName);
        List<Song> GetSongsFromAlbum(string albumName);
    }

    public class SongService: ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository ?? throw new ArgumentNullException(nameof(songRepository));
        }

        public IEnumerable<Song> GetAll()
        {
            return _songRepository.GetAll();
        }

        public Song GetSongByName(string albumName, string songName)
        {
            return _songRepository.GetSongByName(albumName, songName);
        }

        public void AddSong(Song newSong)
        {
            _songRepository.AddSong(newSong);
        }

        public void DeleteSong(string albumName, string albumSongName)
        {
            _songRepository.DeleteSong(albumName, albumSongName);
        }

        public void UpdateSong(string albumName, string songName, string genre, string featured, int length)
        {
            _songRepository.UpdateSong(albumName, songName, genre, featured, length);
        }

        public List<Song> GetSongsFromArtist(string artistName)
        {
            return _songRepository.GetSongFromArtist(artistName);
        }

        public List<Song> GetSongsFromAlbum(string albumName)
        {
            return _songRepository.GetSongFromAlbum(albumName);
        }
    }
}
