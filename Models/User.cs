using System;
using System.Collections.Generic;

namespace MusicLibrary.Models;

public partial class User
{
    public User(string email, string name, string password)
    {
        Email = email;
        Name = name;
        Password = password;
    }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
