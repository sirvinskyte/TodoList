using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Web.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<TodoItemViewModel> TodoItems { get; set; }
    }
}
