using System.Collections.Generic;

namespace TodoList.Business.Vo
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<TodoItemTag> TodoItemTags { get; set; }
    }
}
