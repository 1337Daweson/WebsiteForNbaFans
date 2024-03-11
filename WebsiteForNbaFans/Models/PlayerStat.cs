using System;
using System.Collections.Generic;

namespace WebsiteForNbaFans.Models;

public partial class PlayerStat
{
    public int Id { get; set; }

    public string PlayerName { get; set; } = null!;

    public int Points { get; set; }

    public int Assists { get; set; }

    public int Rebounds { get; set; }

    public int? TeamId { get; set; }

    public int? Blocks { get; set; }

    public int? Steals { get; set; }

    public virtual ICollection<PlayerGameStat> PlayerGameStats { get; set; } = new List<PlayerGameStat>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
