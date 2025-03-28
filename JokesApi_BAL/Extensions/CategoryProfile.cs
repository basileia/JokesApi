using AutoMapper;
using JokesApi_BAL.Models.Category;
using JokesApi_BAL.Models.Joke;
using JokesApi_DAL.Entities;

namespace JokesApi_BAL.Extensions
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryModel, Category>().ReverseMap();
            CreateMap<CategoryDetailModel, Category>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();
        }        
    }
}
