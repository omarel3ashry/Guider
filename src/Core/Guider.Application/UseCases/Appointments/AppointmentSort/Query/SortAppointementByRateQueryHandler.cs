using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Application.UseCases.Consultants.ConsultantPagination.Query;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.AppointmentSort.Query
{
    public class SortAppointementByRateQueryHandler : IRequestHandler<SortAppointmentByRateQuery, PaginatedList<SortconsultantByRateDto, Consultant>>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;

        public SortAppointementByRateQueryHandler(IConsultantRepository consultantRepository, IMapper mapper)
        {
           
            _mapper = mapper;
            _consultantRepository = consultantRepository;
        }

        public async Task<PaginatedList<SortconsultantByRateDto, Consultant>> Handle(SortAppointmentByRateQuery request, CancellationToken cancellationToken)
        {
            var sortedConsultants = await _consultantRepository.GetSortedByAverageRateAsync(request.Ascending);
            var paginatedList = await PaginatedList<SortconsultantByRateDto, Consultant>.CreateAsync(sortedConsultants, _mapper, request.Page, request.PageSize);

            return paginatedList;
        }
    }
}
