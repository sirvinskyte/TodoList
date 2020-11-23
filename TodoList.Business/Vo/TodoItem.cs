using System;
using System.Collections.Generic;
using TodoList.Business.Services.Interfaces;
using TodoList.Commons;

namespace TodoList.Business.Vo
{
    public class TodoItem : IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; } = 3;
        public StatusType Status { get; set; } = StatusType.Backlog;
        public DateTime CreationDate { get; set; } = DateTime.Now.Date;
        public DateTime? DeadLineDate { get; set; }
        public IList<TodoItemTag> TodoItemTags { get; set; }
#nullable enable
        public Category? Category { get; set; } = null;
    }
}
