using AutoMapper;
using TodoList.Business.Vo;
using TodoList.Data.Models;

namespace TodoList.Business.Profiles
{
    class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<TagDao, Tag>().ReverseMap();
        }
    }
}
