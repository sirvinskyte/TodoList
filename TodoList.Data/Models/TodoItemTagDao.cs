namespace TodoList.Data.Models
{
    public class TodoItemTagDao
    {
        public int TodoItemId { get; set; }
        public TodoItemDao TodoItem { get; set; }
        public int TagId { get; set; }
        public TagDao Tag { get; set; }
    }
}
