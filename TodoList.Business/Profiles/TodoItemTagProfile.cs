using AutoMapper;
using TodoList.Business.Vo;
using TodoList.Data.Models;

namespace TodoList.Business.Profiles
{
    class TodoItemTagProfile : Profile
    {
        public TodoItemTagProfile()
        {
            CreateMap<TodoItemTagDao, TodoItemTag>().ReverseMap();
        }
    }
}
