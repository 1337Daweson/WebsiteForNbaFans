using System;
using System.Collections.Generic;

namespace WebsiteForNbaFans.Models;

public partial class TeamSeasonStat
{
    public int? Id { get; set; }

    public int SeasonYear { get; set; }

    public int Wins { get; set; }

    public int Losses { get; set; }

    public decimal WinPercentage { get; set; }

    public virtual Team? IdNavigation { get; set; }
}
