using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoList.Business.Services.Interfaces
{
    public interface IEFManyToManyDataProvider<T>
    {

        public Task DeleteItemAsync(int id1, int id2);
        public Task<List<T>> GetItemsAsync();
        public Task<T> GetItemAsync(int id1, int id2);
        public Task AddItemAsync(T t);
        public Task UpdateItemAsync(T t, int id1, int id2);
    }
}
