using Appointments_API.Models;
using System.Linq.Expressions;

namespace Appointments_API.Repository.IRepository
{
    public interface IUserRepository
    {
        //Task<List<User>> GetAll(Expression<Func<User>> filter = null);

        Task<User> GetAsync(Expression<Func<User, bool>> filter = null, bool tracked=true);
        Task CreateAsync(User entity);
        Task RemoveAsync(User entity);
        Task Save();
       
    }
}
