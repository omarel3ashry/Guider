using Guider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.Dto
{
    public class AppointmentToReturnDto
    {

        public int Id { get; set; }
        public AppointmentState State { get; set; }
        public float Duration { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }
        public string PaymentIntentId { get; set; } = string.Empty;
        public string ClientSecretKey { get; set; } = string.Empty;



    }
}
