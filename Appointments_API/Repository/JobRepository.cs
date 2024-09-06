using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Appointments_API.Repository
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public JobRepository (ApplicationDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task UpdateAsync(Job entity)
        {
            _dbcontext.Jobs.Update(entity);
            await _dbcontext.SaveChangesAsync();
        }
       
    }
}
