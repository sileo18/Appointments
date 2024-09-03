using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Appointments_API.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public ServiceRepository (ApplicationDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task UpdateAsync(Service entity)
        {
            _dbcontext.services.Update(entity);
            await _dbcontext.SaveChangesAsync();
        }
       
    }
}
