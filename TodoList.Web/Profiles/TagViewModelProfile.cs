using AutoMapper;
using TodoList.Business.Vo;
using TodoList.Web.ViewModel;

namespace TodoList.Web.Profiles
{
    public class TagViewModelProfile : Profile
    {
        public TagViewModelProfile()
        {
            CreateMap<Tag, TagViewModel>().ReverseMap();
        }
    }
}
