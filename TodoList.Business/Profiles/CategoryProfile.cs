using AutoMapper;
using TodoList.Business.Vo;
using TodoList.Data.Models;

namespace TodoList.Business.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDao, Category>().ReverseMap();
        }
    }
}
