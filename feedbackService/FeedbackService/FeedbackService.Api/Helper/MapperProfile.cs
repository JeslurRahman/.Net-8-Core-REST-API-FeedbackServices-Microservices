using AutoMapper;

namespace FeedbackService.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        { 
            CreateMap<Infrastructure.Entities.Feedback, Core.Models.FeedbackDTO>().ReverseMap();
        }
    }
}
