using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Clients.Query.GetClientDetails
{
    public class ClienttoReturnVM
    {
        public int Id { get; set; }
        public UserClientDto user { get; set; }
       public List<AppointmentDTO> Appointments { get; set; }
    }
}