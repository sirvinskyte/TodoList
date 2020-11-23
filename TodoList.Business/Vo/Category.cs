using System.Collections.Generic;
using TodoList.Business.Services.Interfaces;

namespace TodoList.Business.Vo
{
    public class Category : IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TodoItem> TodoItems { get; set; }
    }
}
