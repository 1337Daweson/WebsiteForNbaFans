using System;
using System.Collections.Generic;

namespace WebsiteForNbaFans.Models;

public partial class ConferenceStanding
{
    public int? Id { get; set; }

    public int SeasonYear { get; set; }

    public int? TeamId { get; set; }

    public int Wins { get; set; }

    public int Losses { get; set; }

    public decimal WinPercentage { get; set; }

    public virtual Conference? IdNavigation { get; set; }

    public virtual Team? Team { get; set; }
}
