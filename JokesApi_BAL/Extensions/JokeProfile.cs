using AutoMapper;
using JokesApi_BAL.Models.Joke;
using JokesApi_DAL.Entities;

namespace JokesApi_BAL.Extensions
{
    public class JokeProfile : Profile
    {
        public JokeProfile()
        {
            CreateMap<Joke, JokeModel>().ReverseMap();
            CreateMap<Joke, JokeDetailModel>()
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.Likes.Count));
            CreateMap<Joke, CreateJokeModel>().ReverseMap();
            CreateMap<Joke, UpdateJokeModel>().ReverseMap();
        }
    }
}
