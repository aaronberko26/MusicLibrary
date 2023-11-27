using System;
using System.Collections.Generic;

namespace MusicLibrary.Models;

public partial class SongPlaylist
{
    public int? PlaylistId { get; set; }

    public string? SongName { get; set; }

    public virtual Playlist? Playlist { get; set; }

    public virtual Song? SongNameNavigation { get; set; }
}
