using System;
using System.Collections.Generic;

namespace MusicLibrary.Models;

public partial class Album
{

    public int ArtistId { get; set; }

    public string AName { get; set; }

    public string ALength { get; set; }

    public string AGenre { get; set; }

    public int Numofsongs { get; set; }

    public string Label { get; set; }

    public int Year { get; set; }

}
