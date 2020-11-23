using System.Collections.Generic;

namespace TodoList.Data.Models
{
    public class CategoryDao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TodoItemDao> TodoItems { get; set; }
    }
}
