using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.AppointmentSort.Query
{
    public class SortAppointmentByRateQuery : IRequest<List<SortAppointementByRateDto>>
    {
        public bool Ascending { get; }
        public SortAppointmentByRateQuery(bool ascending)
        {
            Ascending = ascending;
        }

    }
}
