using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Schedules.Command.DeleteSchedule
{
    internal class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, BaseResponse>
    {
        private readonly IScheduleRepository _scheduleRepository;

        public DeleteScheduleCommandHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<BaseResponse> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var existingSchedule = await _scheduleRepository.GetScheduleByConsultantIdAndDateAsync(request.ConsultantId, request.Date);

            if (existingSchedule == null)
                throw new Exceptions.NotFoundException("Schedule not found!");

            var deleted = await _scheduleRepository.DeleteAsync(existingSchedule);
            return new BaseResponse() { Success = deleted, Message = deleted ? "Deleted successfully." : "Failed to delete the schedule!" }; ;
        }
    }
}

