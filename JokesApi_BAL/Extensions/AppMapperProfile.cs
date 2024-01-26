using AutoMapper;
using JokesApi_BAL.Models;
using JokesApi_DAL.Entities;

namespace JokesApi_BAL.Extensions
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Joke, JokeModel>().ReverseMap();

        }
    }
}
