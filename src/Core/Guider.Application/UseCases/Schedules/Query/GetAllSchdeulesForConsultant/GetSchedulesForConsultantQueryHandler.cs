using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;

namespace Guider.Application.UseCases.Schedules.Query.GetAllSchdeulesForConsultant
{

    public class GetSchedulesForConsultantQueryHandler : IRequestHandler<GetSchedulesForConsultantQuery, List<ScheduleDto>>
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public GetSchedulesForConsultantQueryHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public async Task<List<ScheduleDto>> Handle(GetSchedulesForConsultantQuery request, CancellationToken cancellationToken)
        {
            var schedules = await _scheduleRepository.GetSchedulesByConsultantIdAsync(request.ConsultantId);
            return _mapper.Map<List<ScheduleDto>>(schedules);
        }
    }
}

