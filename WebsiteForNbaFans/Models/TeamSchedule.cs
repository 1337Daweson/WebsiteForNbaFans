using System;
using System.Collections.Generic;

namespace WebsiteForNbaFans.Models;

public partial class TeamSchedule
{
    public int Id { get; set; }

    public int? TeamId { get; set; }

    public int? OpponentTeamId { get; set; }

    public DateTime GameDate { get; set; }

    public virtual Team? OpponentTeam { get; set; }

    public virtual Team? Team { get; set; }
}
