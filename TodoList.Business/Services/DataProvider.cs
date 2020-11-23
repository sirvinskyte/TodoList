using System.Collections.Generic;
using TodoList.Business.Services.Interfaces;

namespace TodoList.Business.Services
{
    public class DataProvider<T> : IDataProvider<T> where T : IHasId
    {
        private static int id = 0;
        private static List<T> items = new List<T>();
        public void AddItem(T t)
        {
            t.Id = id++;
            items.Add(t);
        }

        public void DeleteItem(int id)
        {
            int index = items.FindIndex(a => a.Id == id);
            items.RemoveAt(index);
        }

        public T GetItem(int id)
        {
            return items.Find(a => a.Id == id);
        }

        public List<T> GetItems()
        {
            return items;
        }

        public void UpdateItem(int id, T t)
        {
            int index = items.FindIndex(a => a.Id == id);
            items[index] = t;
        }
    }
}
