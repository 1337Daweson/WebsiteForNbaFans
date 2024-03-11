using System;
using System.Collections.Generic;

namespace WebsiteForNbaFans.Models;

public partial class GameResult
{
    public int Id { get; set; }

    public int? HomeTeamId { get; set; }

    public int? AwayTeamId { get; set; }

    public int HomeTeamScore { get; set; }

    public int AwayTeamScore { get; set; }

    public DateTime GameDate { get; set; }

    public virtual Team? AwayTeam { get; set; }

    public virtual Team? HomeTeam { get; set; }

    public virtual ICollection<PlayerGameStat> PlayerGameStats { get; set; } = new List<PlayerGameStat>();
}
