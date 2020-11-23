namespace TodoList.Web.ViewModel
{
    public class TodoItemTagViewModel
    {
        public int TodoItemId { get; set; }
        public TodoItemViewModel TodoItem { get; set; }
        public int TagId { get; set; }
        public TagViewModel Tag { get; set; }
    }
}
