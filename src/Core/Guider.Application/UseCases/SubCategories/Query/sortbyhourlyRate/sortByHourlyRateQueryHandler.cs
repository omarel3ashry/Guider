using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Application.UseCases.Appointments.Query.AppointmentSort;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.SubCategories.Query.sortbyhourlyRate
{
    public class sortByHourlyRateQueryHandler : IRequestHandler<sortByHourlyRateQuery, PaginatedList<SortconsultantByRateDto, Consultant>>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;
        public sortByHourlyRateQueryHandler(IMapper mapper, IConsultantRepository consultantRepository)
        {

            _mapper = mapper;
            _consultantRepository = consultantRepository;
        }
        public async Task<PaginatedList<SortconsultantByRateDto, Consultant>> Handle(sortByHourlyRateQuery request, CancellationToken cancellationToken)
        {
            var sortedConsultants = await _consultantRepository.GetSubCategorySortedByHourlyRateAsync(request.Ascending, request.SubCategoryId);
            var paginatedList = await PaginatedList<SortconsultantByRateDto, Consultant>.CreateAsync(sortedConsultants, _mapper, request.Page, request.PageSize);

            return paginatedList;
        }
    }
}
