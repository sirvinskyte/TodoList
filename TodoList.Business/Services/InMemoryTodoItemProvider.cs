using System.Collections.Generic;
using TodoList.Business.Services.Interfaces;
using TodoList.Business.Vo;

namespace TodoList.Business.Services
{
    public class InMemoryTodoItemProvider : IDataProvider<TodoItem>
    {
        private static List<TodoItem> todoItems = new List<TodoItem>();
        public List<TodoItem> GetItems()
        {
            return todoItems;
        }
        public TodoItem GetItem(int id)
        {
            return todoItems[id];
        }
        public void AddItem(TodoItem todoItem)
        {
            todoItems.Add(todoItem);
        }
        public void UpdateItem(int id, TodoItem todoItem)
        {
            int index = todoItems.FindLastIndex(a => a.Id == id);
            todoItems[index] = todoItem;
        }
        public void DeleteItem(int id)
        {
            int index = todoItems.FindLastIndex(a => a.Id == id);
            todoItems.RemoveAt(index);
        }
    }
}
