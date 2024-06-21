//using AutoMapper;
//using Guider.Application.Contracts.Persistence;
//using Guider.Application.UseCases.Consultants.ConsultantPagination.Query;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Guider.Application.UseCases.Appointments.AppointmentSort.Query
//{
//    public class SortAppointementByRateQueryHandler : IRequestHandler<SortAppointmentByRateQuery, PaginatedConsultantDto>
//    {
//        private readonly IAppointmentRepository _appointmentRepository;
//        private readonly IMapper _mapper;

//        public SortAppointementByRateQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
//        {
//            _appointmentRepository = appointmentRepository;
//            _mapper = mapper;
//        }

//        public async Task<PaginatedConsultantDto> Handle(SortAppointmentByRateQuery request, CancellationToken cancellationToken)
//        {
//            var (appointments, totalCount) = await _appointmentRepository.GetSortedByRateAsync(request.Ascending, request.Page, request.PageSize);
//            var appointmentDtos = _mapper.Map<PaginatedConsultantDto>(appointments);

//            return new PaginatedResultDto<SortAppointmentByRateDto>
//            {
//                Items = appointmentDtos,
//                TotalCount = totalCount
//            };
//        }
//    }
//}
