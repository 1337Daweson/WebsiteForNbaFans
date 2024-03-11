using System;
using System.Collections.Generic;

namespace WebsiteForNbaFans.Models;

public partial class PlayerGameStat
{
    public int Id { get; set; }

    public int? PlayerId { get; set; }

    public int? GameId { get; set; }

    public int Points { get; set; }

    public int Rebounds { get; set; }

    public int Assists { get; set; }

    public virtual GameResult? Game { get; set; }

    public virtual PlayerStat? Player { get; set; }
}
