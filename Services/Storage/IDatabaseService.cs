using System.Collections.Generic;
using System.Threading.Tasks;

namespace oculus_sport.Services.Storage
{
    public interface IDatabaseService
    {
        Task<T> GetItemAsync<T>(string id) where T : class;
        Task<IEnumerable<T>> GetItemsAsync<T>() where T : class;
        Task<bool> AddItemAsync<T>(T item);
        Task<bool> UpdateItemAsync<T>(T item);
        Task<bool> DeleteItemAsync<T>(string id);
    }
}
