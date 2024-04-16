using Microsoft.EntityFrameworkCore;
using WebsiteForNbaFans.Models;

namespace WebsiteForNbaFans.Repositories
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAllAsync();
        Task<Article?> GetArticleByIdAsync(int id);
    }

    public class ArticleRepository : IArticleRepository
    {
        private readonly NbaWebContext _context;
        public ArticleRepository(NbaWebContext context)
        {
            _context = context;
        }

        public Task<List<Article>> GetAllAsync()
        {
            return this._context.Articles.AsNoTracking().ToListAsync();
        }

        public Task<Article?> GetArticleByIdAsync(int id)
        {
            return this._context.Articles.AsNoTracking().FirstOrDefaultAsync(x => x.ArticleId == id);
        }
    }
}
