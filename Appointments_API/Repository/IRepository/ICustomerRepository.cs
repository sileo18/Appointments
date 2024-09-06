using Appointments_API.Models;
using System.Linq.Expressions;

namespace Appointments_API.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        //Task<List<User>> GetAll(Expression<Func<User>> filter = null);
        
        Task UpdateAsync(Customer entity);
       
       
    }
}
