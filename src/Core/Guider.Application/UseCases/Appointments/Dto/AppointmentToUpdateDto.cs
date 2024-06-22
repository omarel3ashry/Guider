using Guider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.Dto
{
    public class AppointmentToUpdateDto
    {
        public int Id { get; set; }
        public AppointmentState State { get; set; }
        public DateTime Date { get; set; }
        public string PaymentIntentId { get; set; }
        public string ClientSecretKey { get; set; }



    }
}
