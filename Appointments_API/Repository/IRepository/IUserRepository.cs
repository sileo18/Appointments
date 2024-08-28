using Appointments_API.Models;
using System.Linq.Expressions;

namespace Appointments_API.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        //Task<List<User>> GetAll(Expression<Func<User>> filter = null);
        
        Task UpdateAsync(User entity);
       
       
    }
}
