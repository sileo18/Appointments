using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Appointments_API.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public CustomerRepository(ApplicationDbContext dbcontext) : base(dbcontext) 
        { 
            _dbcontext = dbcontext;
        }        

        public async Task UpdateAsync(Customer entity)
        {
            _dbcontext.Customers.Update(entity);
            await _dbcontext.SaveChangesAsync();
        }

        
    }
}
