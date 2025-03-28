using AutoMapper;
using JokesApi_BAL.Models;
using JokesApi_BAL.Models.Category;
using JokesApi_BAL.Models.Joke;
using JokesApi_DAL.Entities;

namespace JokesApi_BAL.Extensions
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            

            CreateMap<Joke, JokeModel>().ReverseMap();

        }
    }
}
