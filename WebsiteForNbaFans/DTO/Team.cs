using WebsiteForNbaFans.Models;

namespace WebsiteForNbaFans.DTO
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? ConferenceId { get; set; }

        public virtual Conference? Conference { get; set; }
    }
}
