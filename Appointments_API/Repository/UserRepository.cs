using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Appointments_API.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserRepository(ApplicationDbContext dbcontext) : base(dbcontext) 
        { 
            _dbcontext = dbcontext;
        }        

        public async Task UpdateAsync(User entity)
        {
            _dbcontext.users.Update(entity);
            await _dbcontext.SaveChangesAsync();
        }

        
    }
}
