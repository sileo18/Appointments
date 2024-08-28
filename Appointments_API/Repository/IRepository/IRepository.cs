using Appointments_API.Models;
using System.Linq.Expressions;

namespace Appointments_API.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);        
        Task Save();
    }
}
