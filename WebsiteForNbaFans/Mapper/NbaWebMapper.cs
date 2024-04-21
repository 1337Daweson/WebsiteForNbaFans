using AutoMapper;

namespace WebsiteForNbaFans.Mapper
{
    public class NbaWebMapper : Profile
    {
        public NbaWebMapper()
        {
            CreateMap<Models.Article, DTO.Article>();
        }
    }
}
