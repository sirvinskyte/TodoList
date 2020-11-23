using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Web.ViewModel
{
    public class TagViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<TodoItemTagViewModel> TodoItemTags { get; set; }
    }
}
