using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Appointments_API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbcontext;

        internal DbSet<T> dbSet;    

        public Repository(ApplicationDbContext dbcontext)   
        {
            _dbcontext = dbcontext;
            this.dbSet = _dbcontext.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await Save();

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (!tracked) { query.AsNoTracking(); }

            if (filter != null) { query = query.Where(filter); }

            return await query.FirstOrDefaultAsync();

        }

        public async Task RemoveAsync(T entity)
        {


            dbSet.Remove(entity);
            await Save();
        }        

        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
