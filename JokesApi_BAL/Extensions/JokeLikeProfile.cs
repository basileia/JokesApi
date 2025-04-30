using AutoMapper;
using JokesApi_BAL.Models.JokeLike;
using JokesApi_DAL.Entities;

namespace JokesApi_BAL.Extensions
{
    public class JokeLikeProfile : Profile
    {
        public JokeLikeProfile()
        {
            CreateMap<JokeLike, JokeLikeModel>()
                .ForMember(dest => dest.JokeId, opt => opt.MapFrom(src => src.JokeId))
                .ForMember(dest => dest.IsLikedByUser, opt => opt.Ignore())
                .ForMember(dest => dest.LikeCount, opt => opt.Ignore());

            CreateMap<JokeLikeUpdateModel, JokeLike>().ReverseMap();
        }
    }
}
