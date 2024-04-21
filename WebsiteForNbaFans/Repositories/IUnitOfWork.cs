using WebsiteForNbaFans.Models;

namespace WebsiteForNbaFans.Repositories
{
    public interface IUnitOfWork
    {
        IArticleRepository ArticleRepository { get; }
        Task SaveChangesAsync(/*CancellationToken cancellationToken = default*/);
        void Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NbaWebContext _context;
        private readonly Lazy<IArticleRepository> articleRepository;

        public UnitOfWork(NbaWebContext nbaWebContext)
        {
            this._context = nbaWebContext;
            this.articleRepository = new Lazy<IArticleRepository>(() => new ArticleRepository(this._context));

        }

        public IArticleRepository ArticleRepository => this.articleRepository.Value;

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
