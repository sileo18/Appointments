using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Appointments_API.Repository
{
    public class ProfessionalRepository : Repository<Professional>, IProfessionalRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public ProfessionalRepository(ApplicationDbContext dbcontext) : base(dbcontext) 
        { 
            _dbcontext = dbcontext;
        }        

        public async Task UpdateAsync(Professional entity)
        {
            _dbcontext.professionals.Update(entity);
            await _dbcontext.SaveChangesAsync();
        }

        
    }
}
