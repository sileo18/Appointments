using System.Net;

namespace Appointments_API.Models
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<String> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}
