using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.ConsultantPagination
{
    public class GetPaginatedConsultantsQueryHandler : IRequestHandler<GetPaginatedConsultantsQuery, PaginatedConsultantDto>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public GetPaginatedConsultantsQueryHandler(IConsultantRepository consultantRepository, IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            _consultantRepository = consultantRepository;
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<PaginatedConsultantDto> Handle(GetPaginatedConsultantsQuery request, CancellationToken cancellationToken)
        {

            var result = await _consultantRepository.GetPaginatedConsultantsAsync(request.Page, request.PageSize);

            var consultants = result.Consultants.Select(c => _mapper.Map<ConsultantDto>(c)).ToList();
            //foreach (var consultant in consultants)
            //{
            //    var id = consultant.Id;
            //    var avgRate = await _appointmentRepository.CalculateAverageRate(id);
            //    consultant.AverageRate = avgRate;
            //}

            return new PaginatedConsultantDto
            {
                Consultants = consultants,
                TotalCount = result.TotalCount
            };

        }
    }
}