using System.Collections.Generic;

namespace TodoList.Business.Services.Interfaces
{
    public interface IDataProvider<T>
    {
        public List<T> GetItems();
        public T GetItem(int id);
        public void AddItem(T t);
        public void UpdateItem(int id, T t);
        public void DeleteItem(int id);
    }
}
