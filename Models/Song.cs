using System;
using System.Collections.Generic;

namespace MusicLibrary.Models;

public partial class Song
{
    public int? ArtistId { get; set; }

    public string AName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Genre { get; set; }

    public string? FeaturedArtists { get; set; }

    public int? Length { get; set; }

    public virtual Album ANameNavigation { get; set; } = null!;

    public virtual Artist? Artist { get; set; }
}
