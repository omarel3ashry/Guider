using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.AppointmentSort.Query
{
    public class SortAppointementByRateQueryHandler : IRequestHandler<SortAppointmentByRateQuery, List<SortAppointementByRateDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public SortAppointementByRateQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<List<SortAppointementByRateDto>> Handle(SortAppointmentByRateQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.GetSortedByRateAsync(request.Ascending);
            return _mapper.Map<List<SortAppointementByRateDto>>(appointments);
        }
    }
}
