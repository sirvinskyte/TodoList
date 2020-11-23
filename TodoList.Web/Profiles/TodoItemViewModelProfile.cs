using AutoMapper;
using TodoList.Business.Vo;
using TodoList.Web.ViewModel;

namespace TodoList.Web.Profiles
{
    public class TodoItemViewModelProfile : Profile
    {
        public TodoItemViewModelProfile()
        {
            CreateMap<TodoItem, TodoItemViewModel>().ReverseMap();
        }
    }
}
