using WebsiteForNbaFans.Models;

namespace WebsiteForNbaFans.Repositories
{
    public interface IUnitOfWork
    {
        ITeamRepository TeamRepository { get; }
        Task SaveChangesAsync(/*CancellationToken cancellationToken = default*/);
        void Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NbaWebContext _context;
        private readonly Lazy<ITeamRepository> teamRepository;

        public UnitOfWork(NbaWebContext nbaWebContext)
        {
            this._context = nbaWebContext;
            this.teamRepository = new Lazy<ITeamRepository>(() => new TeamRepository(this._context));

        }

        public ITeamRepository TeamRepository => this.teamRepository.Value;

        public void Save()
        {
            this._context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return this._context.SaveChangesAsync();   
        }
    }
}
