using AutoMapper;
using FluentValidation;
using Guider.Application.Contracts.Infrastructure;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Application.UseCases.Appointments.Query.GetById;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Appointments.Command.AddAppointment
{
    public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommand, BaseResponse<AppointmentDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IValidator<AddAppointmentCommand> _validator;
        private readonly IMapper _mapper;
        private readonly IBackgroundJob _backgroundJob;

        public AddAppointmentCommandHandler(IAppointmentRepository appointmentRepository,
                                            IScheduleRepository scheduleRepository,
                                            IValidator<AddAppointmentCommand> validator,
                                            IMapper mapper,
                                            IBackgroundJob backgroundJob
                                           )
        {
            _appointmentRepository = appointmentRepository;
            _scheduleRepository = scheduleRepository;
            _validator = validator;
            _mapper = mapper;
            _backgroundJob = backgroundJob;
        }

        public async Task<BaseResponse<AppointmentDto>> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var appointment = _mapper.Map<Appointment>(request);

            var added = await _appointmentRepository.AddAsync(appointment);


            if (added)
            {
                var createdAppointment = await _appointmentRepository.GetWithIncludesAsync(appointment.Id);
                _backgroundJob.ScheduleAppointment(request.Date, createdAppointment!.Client.UserId, createdAppointment.Consultant.UserId, appointment.Id);
                await _scheduleRepository.UpdateScheduleStateAsync(request.ConsultantId, request.Date, true, request.Duration);
                var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
                return new BaseResponse<AppointmentDto>() { Message = "Appointment reserved successfully.", Result = appointmentDto };
            }

            return new BaseResponse<AppointmentDto>() { Success = false, Message = "Failed to reserve appointment!" };
        }
    }
}