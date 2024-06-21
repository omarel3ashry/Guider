using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.Consultants.ConsultantPagination.Query;
using MediatR;

namespace Guider.Application.UseCases.Consultants.ConsultantsAll.Query
{
    public class GetAllConsultantsQueryHandler : IRequestHandler<GetAllConsultantsQuery, List<CounsultantsDto>>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAllConsultantsQueryHandler(IConsultantRepository consultantRepository, IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            _consultantRepository = consultantRepository;
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<CounsultantsDto>> Handle(GetAllConsultantsQuery request, CancellationToken cancellationToken)
        {
            var consultants = await _consultantRepository.GetAllConsultantsAsync();
            var CounsultantsDto= _mapper.Map<List<CounsultantsDto>>(consultants);
            foreach (var consultant in CounsultantsDto)
            {
                var id=consultant.Id;
                var avgRate=await _appointmentRepository.CalculateAverageRate(id);
                consultant.AverageRate=avgRate;
            }
            return CounsultantsDto;
        }
    }
}