using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoList.Business.Services.Interfaces
{
    public interface IEFDataProvider<T>
    {
        public Task DeleteItemAsync(int id);
        public Task<List<T>> GetItemsAsync();
        public Task<T> GetItemAsync(int id);
        public Task AddItemAsync(T t);
        public Task UpdateItemAsync(T t);
    }
}
