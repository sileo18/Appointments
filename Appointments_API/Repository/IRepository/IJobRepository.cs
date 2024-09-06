using Appointments_API.Models;
using System.Linq.Expressions;

namespace Appointments_API.Repository.IRepository
{
    public interface IJobRepository : IRepository<Job>
    {
        //Task<List<User>> GetAll(Expression<Func<User>> filter = null);
        
        Task UpdateAsync(Job entity);
       
       
    }
}
