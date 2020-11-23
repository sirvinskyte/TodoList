using AutoMapper;
using TodoList.Business.Vo;
using TodoList.Web.ViewModel;

namespace TodoList.Web.Profiles
{
    public class CategoryViewModelProfile : Profile
    {
        public CategoryViewModelProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
