using System.Collections.Generic;
using TodoList.Business.Services.Interfaces;
using TodoList.Business.Vo;

namespace TodoList.Business.Services
{
    public class InMemoryCategoryProvider : IDataProvider<Category>
    {
        private static List<Category> categories = new List<Category>();
        public List<Category> GetItems()
        {
            return categories;
        }
        public Category GetItem(int id)
        {
            return categories[id];
        }
        public void AddItem(Category category)
        {
            categories.Add(category);
        }
        public void UpdateItem(int id, Category category)
        {
            int index = categories.FindLastIndex(a => a.Id == id);
            categories[index] = category;
        }
        public void DeleteItem(int id)
        {
            int index = categories.FindLastIndex(a => a.Id == id);
            categories.RemoveAt(index);
        }
    }
}
