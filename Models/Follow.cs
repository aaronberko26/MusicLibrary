using System;
using System.Collections.Generic;

namespace MusicLibrary.Models;

public partial class Follow
{
    public string? Email { get; set; }

    public string? Name { get; set; }

    public virtual User? EmailNavigation { get; set; }

    public virtual Artist? NameNavigation { get; set; }
}
