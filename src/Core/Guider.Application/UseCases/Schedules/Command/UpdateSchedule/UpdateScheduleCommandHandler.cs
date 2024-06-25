using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Schedules.Command.UpdateSchedule
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, bool>
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;
        public UpdateScheduleCommandHandler(IScheduleRepository scheduleRepository, IConsultantRepository consultantRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _consultantRepository = consultantRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var existingSchedule = await _scheduleRepository.GetScheduleByConsultantIdAndDateAsync(request.ConsultantId, request.Date);

            if (existingSchedule == null)
            {
                throw new ArgumentException("Schedule not found for the given consultant and date.");
            }

            //var updatedSchedule = new Schedule
            //{
            //    ConsultantId = request.ConsultantId,
            //    Date = request.NewDate,
            //    IsReserved = false

            //};
            List<Schedule> schedules = new List<Schedule>();

            for (int i = 0; i < request.TimeSpan; i++)
            {
                schedules.Add(new Schedule { ConsultantId = request.ConsultantId, Date = request.NewDate.AddHours(i), IsReserved = false });
            }

            return await _scheduleRepository.UpdateScheduleAsync(existingSchedule, schedules);
        }
    }
}