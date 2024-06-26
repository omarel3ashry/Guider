using Guider.Application.Responses;
using Guider.Application.UseCases.Appointments.Query.AppointmentSort;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.SubCategories.Query.sortbyAvgRate
{
    public class sortByAvgRateQuery : IRequest<PaginatedList<SortconsultantByRateDto, Consultant>>
    {
        public bool Ascending { get; }
        public int Page { get; }
        public int PageSize { get; }
        public int SubCategoryId { get; }

        public sortByAvgRateQuery(bool ascending, int page, int pageSize, int subCategoryId)
        {
            Ascending = ascending;
            Page = page;
            PageSize = pageSize;
            SubCategoryId = subCategoryId;
        }

    }
}
