using System.Collections.Generic;
using System.Threading.Tasks;

namespace photoviewer.core.Data
{
    public interface ICrudServiceAsync<T> : IDependency where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task<T> GetAsync(long id);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAllAsync();
    }
}
