using Guider.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Schedules.Command.DeleteSchedule
{
    internal class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, bool>
    {
        private readonly IScheduleRepository _scheduleRepository;

        public DeleteScheduleCommandHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<bool> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var existingSchedule = await _scheduleRepository.GetScheduleByConsultantIdAndDateAsync(request.ConsultantId, request.Date);

            if (existingSchedule == null)
                return false; // Schedule not found or already deleted

            await _scheduleRepository.DeleteAsync(existingSchedule);
            return true;
        }
    }
}

