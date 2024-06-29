using Guider.Application.Responses;
using Guider.Application.UseCases.Appointments.Query.AppointmentSort;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.SubCategories.Query.sortbyhourlyRate
{
    public class sortByHourlyRateQuery : IRequest<PaginatedList<SortconsultantByRateDto, Consultant>>
    {

        public bool Ascending { get; }
        public int Page { get; }
        public int PageSize { get; }
        public int SubCategoryId { get; }

        public sortByHourlyRateQuery(bool ascending, int page, int pageSize, int subCategoryId)
        {
            Ascending = ascending;
            Page = page;
            PageSize = pageSize;
            SubCategoryId = subCategoryId;
        }

    }
}
