using AutoMapper;
using TodoList.Business.Vo;
using TodoList.Data.Models;

namespace TodoList.Business.Profiles
{
    class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<TodoItemDao, TodoItem>().ReverseMap();
        }
    }
}
