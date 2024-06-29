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

        public CreateScheduleCommandHandler(IScheduleRepository scheduleRepository, IConsultantRepository consultantRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _consultantRepository = consultantRepository;
        }

        public async Task<bool> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var consultant = await _consultantRepository.GetByIdAsync(request.ConsultantId);

            if (consultant == null)
            {
                throw new ArgumentException("Invalid ConsultantId");
            }

            List<Schedule> schedules = new List<Schedule>();
            foreach (var schedule in request.Schedules)
            {
                for (int i = 0; i < schedule.TimeSpan; i++)
                {
                    schedules.Add(new Schedule { ConsultantId = request.ConsultantId, Date = schedule.Date.AddHours(i), IsReserved = false });
                }
            }

            return await _scheduleRepository.AddSchedulesAsync(schedules);
        }
    }
}


