using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Web.ViewModel
{
    public enum StatusType
    {
        Backlog,
        Wip,
        Done,
        Archived
    }
    public class TodoItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, 5)]
        public int Priority { get; set; } = 3;
        [EnumDataType(typeof(StatusType))]
        public StatusType Status { get; set; } = StatusType.Backlog;
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; } = DateTime.Now.Date;
        [DataType(DataType.Date)]
        public DateTime? DeadLineDate { get; set; }
        public IList<TodoItemTagViewModel> TodoItemTags { get; set; }
#nullable enable
        public CategoryViewModel? Category { get; set; } = null;
    }
}
