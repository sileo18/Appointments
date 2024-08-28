using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Appointments_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserRepository(ApplicationDbContext dbcontext) 
        { 
            _dbcontext = dbcontext;
        }
        public async Task CreateAsync(User entity)
        {
            await _dbcontext.users.AddAsync(entity);
            await Save();

        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> filter = null, bool tracked = true)
        {
            IQueryable<User> query = _dbcontext.users;

            if (!tracked) { query.AsNoTracking(); }

            if (filter!=null) { query = query.Where(filter); }

            return await query.FirstOrDefaultAsync();
            
        }

        public async Task RemoveAsync(User entity)
        {


            _dbcontext.users.Remove(entity);
            await Save();
        }

        public async Task UpdateAsync(User entity)
        {
            _dbcontext.users.Update(entity);
            await Save();
        }

        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
