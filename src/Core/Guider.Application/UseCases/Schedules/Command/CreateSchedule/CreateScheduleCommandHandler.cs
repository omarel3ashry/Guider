using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Schedules.Command.CreateSchedule
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, bool>
    {

        private readonly IScheduleRepository _scheduleRepository;
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;

        public CreateScheduleCommandHandler(IScheduleRepository scheduleRepository, IConsultantRepository consultantRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _consultantRepository = consultantRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var consultant = await _consultantRepository.GetByIdAsync(request.ConsultantId);

            if (consultant == null)
            {
                throw new ArgumentException("Invalid ConsultantId");
            }

            var schedules = request.Schedules.Select(s => _mapper.Map<Schedule>(s)).ToList();
            foreach (var schedule in schedules)
            {
                schedule.ConsultantId = request.ConsultantId;
            }

            return await _scheduleRepository.AddSchedulesAsync(schedules);
        }
    }
}


