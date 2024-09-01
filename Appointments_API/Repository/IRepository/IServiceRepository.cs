using Appointments_API.Models;
using System.Linq.Expressions;

namespace Appointments_API.Repository.IRepository
{
    public interface IServiceRepository : IRepository<Service>
    {
        //Task<List<User>> GetAll(Expression<Func<User>> filter = null);
        
        Task UpdateAsync(Service entity);
       
       
    }
}
