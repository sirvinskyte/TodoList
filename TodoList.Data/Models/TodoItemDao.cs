using System;
using System.Collections.Generic;
using TodoList.Commons;

namespace TodoList.Data.Models
{
    public class TodoItemDao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; } = 3;
        public StatusType Status { get; set; } = StatusType.Backlog;
        public DateTime CreationDate { get; set; } = DateTime.Now.Date;
        public DateTime? DeadLineDate { get; set; }
        public IList<TodoItemTagDao> TodoItemTags { get; set; }
#nullable enable
        public CategoryDao? Category { get; set; } = null;
    }
}
