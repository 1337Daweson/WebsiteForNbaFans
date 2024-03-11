using System;
using System.Collections.Generic;

namespace WebsiteForNbaFans.Models;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ConferenceId { get; set; }

    public virtual Conference? Conference { get; set; }

    public virtual ICollection<GameResult> GameResultAwayTeams { get; set; } = new List<GameResult>();

    public virtual ICollection<GameResult> GameResultHomeTeams { get; set; } = new List<GameResult>();

    public virtual ICollection<TeamSchedule> TeamScheduleOpponentTeams { get; set; } = new List<TeamSchedule>();

    public virtual ICollection<TeamSchedule> TeamScheduleTeams { get; set; } = new List<TeamSchedule>();

    public virtual ICollection<PlayerStat> Players { get; set; } = new List<PlayerStat>();
}
