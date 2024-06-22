using Guider.Application.Responses;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Appointments.AppointmentSort.Query
{
    public class SortAppointmentByRateQuery : IRequest<PaginatedList<SortconsultantByRateDto, Consultant>>
    {
        public bool Ascending { get; }
        public int Page { get; }
        public int PageSize { get; }

        public SortAppointmentByRateQuery(bool ascending, int page, int pageSize)
        {
            Ascending = ascending;
            Page = page;
            PageSize = pageSize;
        }

    }
}
