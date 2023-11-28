using System;
using System.Collections.Generic;

namespace MusicLibrary.Models;

public partial class Album
{
    /*public Album(int artistId, string albumName, string label, string albumLength, string albumGenre, int numOfSongs, int year, ICollection<Song> albumSongs, Artist artist)
    {
        ArtistId = artistId;
        AName = albumName;
        Label = label;
        ALength = albumLength;
        AGenre = albumGenre;
        Numofsongs = numOfSongs;
        Year = year;
        Songs = albumSongs;
        Artist = artist;
    }*/

    public int ArtistId { get; set; }

    public string AName { get; set; }

    public string ALength { get; set; }

    public string AGenre { get; set; }

    public int Numofsongs { get; set; }

    public string Label { get; set; }

    public int Year { get; set; }

    public virtual Artist Artist { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
