using Appointments_API.Models;
using System.Linq.Expressions;

namespace Appointments_API.Repository.IRepository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        //Task<List<User>> GetAll(Expression<Func<User>> filter = null);
        
        Task UpdateAsync(Appointment entity);
       
       
    }
}
