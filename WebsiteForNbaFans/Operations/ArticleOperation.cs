using AutoMapper;
using WebsiteForNbaFans.DTO;
using WebsiteForNbaFans.Repositories;

namespace WebsiteForNbaFans.Operations
{
    public interface IArticleOperation
    {
        Task<List<Article>> GetArticlesAsync();
        Task<Article> GetArticleByIdAsync(int id);
    }
    public class ArticleOperation : IArticleOperation
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ArticleOperation(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            var result = await this.unitOfWork.ArticleRepository.GetArticleByIdAsync(id);

            return this.mapper.Map<Article>(result);
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            var result = await this.unitOfWork.ArticleRepository.GetAllAsync();

            return result
                .Select(team => this.mapper.Map<Article>(team))
                .ToList();
        }
    }
}
