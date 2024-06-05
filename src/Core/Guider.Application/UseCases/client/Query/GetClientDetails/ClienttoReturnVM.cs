using Guider.Domain.Entities;

namespace Guider.Application.UseCases.client.Query.GetClientDetails
{
    public class ClienttoReturnVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IReadOnlyCollection<AppointmentDTO> Appointments { get; set; }
    }
}