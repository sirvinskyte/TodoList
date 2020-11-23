using AutoMapper;
using TodoList.Business.Vo;
using TodoList.Web.ViewModel;

namespace TodoList.Web.Profiles
{
    public class TodoItemTagViewModelProfile : Profile
    {
        public TodoItemTagViewModelProfile()
        {
            CreateMap<TodoItemTag, TodoItemTagViewModel>().ReverseMap();
        }
    }
}
