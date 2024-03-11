using Microsoft.EntityFrameworkCore;
using WebsiteForNbaFans.Models;

namespace WebsiteForNbaFans.Repositories
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllAsync();
        Task<Team?> GetTeamByIdAsync(int id);
    }

    public class TeamRepository : ITeamRepository
    {
        private readonly NbaWebContext _context;
        public TeamRepository(NbaWebContext context)
        {
            _context = context;
        }

        public Task<List<Team>> GetAllAsync()
        {
            return this._context.Teams.AsNoTracking().ToListAsync();
        }

        public Task<Team?> GetTeamByIdAsync(int id)
        {
            return this._context.Teams.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
