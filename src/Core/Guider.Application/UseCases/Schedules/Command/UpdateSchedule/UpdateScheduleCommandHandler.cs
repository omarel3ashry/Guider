using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var updatedSchedule = new Schedule
            {
                ConsultantId = request.ConsultantId,
                Date = request.NewDate,
                IsReserved = false
                
            };

            return await _scheduleRepository.UpdateScheduleAsync(request.ConsultantId, request.Date, updatedSchedule);
        }
    }
}