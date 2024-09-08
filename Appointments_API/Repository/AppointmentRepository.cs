using Appointments_API.Data;
using Appointments_API.Models;
using Appointments_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Appointments_API.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public AppointmentRepository(ApplicationDbContext dbcontext) : base(dbcontext) 
        { 
            _dbcontext = dbcontext;
        }        

        public async Task UpdateAsync(Appointment entity)
        {
            _dbcontext.Appointments.Update(entity);
            await _dbcontext.SaveChangesAsync();
        }        

        
    }
}
