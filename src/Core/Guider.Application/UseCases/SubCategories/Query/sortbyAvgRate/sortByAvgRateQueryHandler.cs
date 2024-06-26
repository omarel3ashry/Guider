using AutoMapper;
using Guider.Application.Contracts.Persistence;
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
    public class sortByAvgRateQueryHandler : IRequestHandler<sortByAvgRateQuery, PaginatedList<SortconsultantByRateDto, Consultant>>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;
        public sortByAvgRateQueryHandler(IMapper mapper,IConsultantRepository consultantRepository)
        {
                _mapper = mapper;
                _consultantRepository = consultantRepository;
        }
        public async Task<PaginatedList<SortconsultantByRateDto, Consultant>> Handle(sortByAvgRateQuery request, CancellationToken cancellationToken)
        {
            var sortedConsultants = await _consultantRepository.GetSubCategorySortedByAverageRateAsync(request.Ascending, request.SubCategoryId);
            var paginatedList = await PaginatedList<SortconsultantByRateDto, Consultant>.CreateAsync(sortedConsultants, _mapper, request.Page, request.PageSize);

            return paginatedList;
        }
    }
}
