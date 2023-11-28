using System;
using System.Collections.Generic;

namespace MusicLibrary.Models;

public partial class Playlist
{
    public string? Email { get; set; }

    public int PlaylistId { get; set; }

    public string? Name { get; set; }

    public int? Numofsongs { get; set; }

    public int? PLength { get; set; }

    public virtual User? EmailNavigation { get; set; }
}
