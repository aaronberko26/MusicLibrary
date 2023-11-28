namespace MusicLibrary.Models
{
    public class AlbumInputModel
    {
        public int ArtistId { get; set; }
        public string AlbumName { get; set; }
        public string Label { get; set; }
        public string AlbumLength { get; set; }
        public string AlbumGenre { get; set; }
        public int NumOfSongs { get; set; }
        public int Year { get; set; }
        public ICollection<Song> AlbumSongs { get; set; }
        public Artist Artist { get; set; }
    }

}
