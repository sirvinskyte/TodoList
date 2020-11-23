using System.Collections.Generic;

namespace TodoList.Data.Models
{
    public class TagDao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<TodoItemTagDao> TodoItemTags { get; set; }
    }
}
