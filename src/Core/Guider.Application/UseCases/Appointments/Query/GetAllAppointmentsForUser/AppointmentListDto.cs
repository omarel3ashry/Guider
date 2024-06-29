using Guider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.Query.GetAllForConsultant
{
    internal class AppointmentListDto
    {
        public int Id { get; set; }
        public float Rate { get; set; }
        public AppointmentState State { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
    }
}
