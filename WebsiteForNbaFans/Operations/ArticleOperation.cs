using AutoMapper;
using WebsiteForNbaFans.DTO;
using WebsiteForNbaFans.Repositories;

namespace WebsiteForNbaFans.Operations
{
    public interface IArticleOperation
    {
        Task<List<Team>> GetAll();
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

        public async Task<List<Team>> GetAll()
        {
            var result = await this.unitOfWork.TeamRepository.GetAllAsync();

            return result
                .Select(team => this.mapper.Map<Team>(team))
                .ToList();
        }
    }
}
